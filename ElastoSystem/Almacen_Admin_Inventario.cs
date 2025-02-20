using DocumentFormat.OpenXml.Wordprocessing;
using FirebirdSql.Data.FirebirdClient;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElastoSystem
{
    public partial class Almacen_Admin_Inventario : Form
    {
        public Almacen_Admin_Inventario()
        {
            InitializeComponent();
        }

        private async void Almacen_Admin_Inventario_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;

            await Task.Run(() =>
            {
                progressBar1.Invoke((Action)(() => progressBar1.Value = 33));
                LlamarFacturas();

                progressBar1.Invoke((Action)(() => progressBar1.Value = 66));
                LlamarPartidasFacturas();

                progressBar1.Invoke((Action)(() => progressBar1.Value = 77));
                CargarClientes();

                progressBar1.Invoke((Action)(() => progressBar1.Value = 88));

                this.Invoke((Action)(() =>
                {
                    CargarProductos();
                    CargarDatosCombinados();
                }));

                progressBar1.Invoke((Action)(() => progressBar1.Value = 99));

            });

            progressBar1.Visible = false;
            pnlCargando.Visible = false;
            btnDescargarReporte.Visible = true;
            btnFiltrar.Visible = true;
        }

        private void CargarClientes()
        {
            try
            {
                FbConnectionStringBuilder cadena = new FbConnectionStringBuilder();
                cadena.UserID = "SYSDBA";
                cadena.Password = "masterkey";
                cadena.Database = VariablesGlobales.DireccionBDSAE;
                cadena.DataSource = VariablesGlobales.IPSAE;
                cadena.Port = 3050;

                FbConnection conn = new FbConnection(cadena.ConnectionString);
                FbCommand comando = new FbCommand();
                FbDataAdapter adaptador = new FbDataAdapter();
                DataSet datos = new DataSet();
                string sql = "SELECT CLAVE, NOMBRE FROM clie01";

                comando.Connection = conn;
                comando.CommandText = sql;
                adaptador.SelectCommand = comando;

                conn.Open();
                adaptador.Fill(datos);
                conn.Close();

                dgvClientes.Invoke((MethodInvoker)delegate
                {
                    bindingSource4.DataSource = datos.Tables[0];
                    dgvClientes.DataSource = bindingSource4;
                    ActualizarClientes();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR LOS CLIENTES DE ASPEL SAE: " + ex.Message);
            }
        }

        private void ActualizarClientes()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                conn.Open();

                string sqlEliminar = "DELETE FROM elastosystem_sae_clientes";
                MySqlCommand cmdDelete = new MySqlCommand(sqlEliminar, conn);
                cmdDelete.ExecuteNonQuery();

                foreach (DataGridViewRow row in dgvClientes.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string claveCliente = row.Cells["CLAVE"].Value.ToString();
                        string nombreCliente = row.Cells["NOMBRE"].Value.ToString();

                        string sqlInsertar = @"INSERT INTO elastosystem_sae_clientes(Clave, Nombre)
                                                VALUES (@CLAVE, @CLIENTE)";
                        MySqlCommand cmdInsertar = new MySqlCommand(sqlInsertar, conn);
                        cmdInsertar.Parameters.AddWithValue("@CLAVE", claveCliente);
                        cmdInsertar.Parameters.AddWithValue("@CLIENTE", nombreCliente);
                        cmdInsertar.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ACTUALIZAR CLIENTES: " + ex.Message);
            }
        }

        private void CargarDatosCombinados()
        {
            btnDescargarPDF.Visible = false;
            string quey = @"
                SELECT
                    f.Clave_Documento,
                    f.Clave_Cliente,
                    c.Nombre AS Nombre_Cliente,
                    p.Producto,
                    p.Cantidad,
                    f.Status,
                    f.Fecha_Documento
                FROM elastosystem_sae_facturas AS f
                INNER JOIN elastosystem_sae_facturas_partidas AS p
                    ON f.Clave_Documento = p.Clave_Documento
                INNER JOIN elastosystem_sae_clientes AS c
                    ON f.Clave_Cliente = c.Clave
                WHERE f.Status IN ('E', 'O')
                    AND p.Almacen = 1
                ORDER BY f.Fecha_Documento DESC;";

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(quey, conn);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable datos = new DataTable();
                    adaptador.Fill(datos);

                    dgvReporte.Invoke((Action)(() =>
                    {
                        dgvReporte.AutoGenerateColumns = true;
                        dgvReporte.DataSource = datos;
                        dgvReporte.Visible = true;
                        dgvReporte.Columns["Clave_Documento"].HeaderText = "Factura";
                        dgvReporte.Columns["Clave_Cliente"].Visible = false;
                        dgvReporte.Columns["Status"].Visible = false;
                        dgvReporte.Columns["Fecha_Documento"].HeaderText = "Fecha";
                        dgvReporte.Columns["Nombre_Cliente"].HeaderText = "Cliente";
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR DGV DE REPORTE: " + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void LlamarFacturas()
        {
            try
            {
                dgvFacturasSAE.AutoGenerateColumns = true;

                FbConnectionStringBuilder cadena = new FbConnectionStringBuilder();
                cadena.UserID = "SYSDBA";
                cadena.Password = "masterkey";
                cadena.Database = VariablesGlobales.DireccionBDSAE;
                cadena.DataSource = VariablesGlobales.IPSAE;
                cadena.Port = 3050;

                FbConnection conn = new FbConnection(cadena.ConnectionString);
                FbCommand comando = new FbCommand();
                FbDataAdapter adaptador = new FbDataAdapter();
                DataSet datos = new DataSet();
                string sql = "SELECT CVE_DOC, CVE_CLPV, STATUS, FECHA_DOC FROM factf01 WHERE CVE_DOC LIKE 'A      %' AND CVE_DOC NOT IN ('A      6586', 'A      6585', 'A      6584', 'A      6546', 'A      5576', 'A      5452', 'A      5451', 'A      5443')";

                comando.Connection = conn;
                comando.CommandText = sql;
                adaptador.SelectCommand = comando;

                conn.Open();
                adaptador.Fill(datos);
                conn.Close();

                bindingSource1.DataSource = datos.Tables[0];
                dgvFacturasSAE.DataSource = bindingSource1;

                ActualizarFacturas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR LAS FACTURAS DE ASPEL SAE: " + ex.Message);
            }
        }

        private void ActualizarFacturas()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                conn.Open();

                string sqlEliminar = "DELETE FROM elastosystem_sae_facturas";
                MySqlCommand cmdDelete = new MySqlCommand(sqlEliminar, conn);
                cmdDelete.ExecuteNonQuery();

                foreach (DataGridViewRow row in dgvFacturasSAE.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string claveDocumento = row.Cells["CVE_DOC"].Value.ToString();
                        string claveCliente = row.Cells["CVE_CLPV"].Value.ToString();
                        string status = row.Cells["STATUS"].Value.ToString();
                        DateTime fechaDocumento = Convert.ToDateTime(row.Cells["FECHA_DOC"].Value);

                        string sqlInsertar = @"INSERT INTO elastosystem_sae_facturas (Clave_Documento, Clave_Cliente, Status, Fecha_Documento)
                                                VALUES (@CLAVEDOCUMENTO, @CLAVECLIENTE, @STATUS, @FECHADOCUMENTO)";
                        MySqlCommand cmdInsertar = new MySqlCommand(sqlInsertar, conn);
                        cmdInsertar.Parameters.AddWithValue("@CLAVEDOCUMENTO", claveDocumento);
                        cmdInsertar.Parameters.AddWithValue("@CLAVECLIENTE", claveCliente);
                        cmdInsertar.Parameters.AddWithValue("@STATUS", status);
                        cmdInsertar.Parameters.AddWithValue("@FECHADOCUMENTO", fechaDocumento);
                        cmdInsertar.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ACTUALIZAR FACTURAS: " + ex.Message);
            }
        }

        private void LlamarPartidasFacturas()
        {
            try
            {
                dgvPartidasFacturaSAE.AutoGenerateColumns = true;

                FbConnectionStringBuilder cadena = new FbConnectionStringBuilder();
                cadena.UserID = "SYSDBA";
                cadena.Password = "masterkey";
                cadena.Database = VariablesGlobales.DireccionBDSAE;
                cadena.DataSource = VariablesGlobales.IPSAE;
                cadena.Port = 3050;

                FbConnection conn = new FbConnection(cadena.ConnectionString);
                FbCommand comando = new FbCommand();
                FbDataAdapter adaptador = new FbDataAdapter();
                DataSet datos = new DataSet();
                string sql = "SELECT CVE_DOC, CVE_ART, CANT, NUM_ALM FROM par_factf01 WHERE CVE_DOC LIKE 'A      %'";

                comando.Connection = conn;
                comando.CommandText = sql;
                adaptador.SelectCommand = comando;

                conn.Open();
                adaptador.Fill(datos);
                conn.Close();

                bindingSource2.DataSource = datos.Tables[0];
                dgvPartidasFacturaSAE.DataSource = bindingSource2;

                ActualizarPartidas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR LAS PARTIDAS DE LAS FACTURAS DE ASPEL SAE: " + ex.Message);
            }
        }

        private void ActualizarPartidas()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                conn.Open();

                string sqlEliminar = "DELETE FROM elastosystem_sae_facturas_partidas";
                MySqlCommand cmdDelete = new MySqlCommand(sqlEliminar, conn);
                cmdDelete.ExecuteNonQuery();

                foreach (DataGridViewRow row in dgvPartidasFacturaSAE.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string claveDocumento = row.Cells["CVE_DOC"].Value.ToString();
                        string claveArticulo = row.Cells["CVE_ART"].Value.ToString();
                        int cantidad = Convert.ToInt32(Convert.ToDecimal(row.Cells["CANT"].Value));
                        int almacen = Convert.ToInt32(Convert.ToDecimal(row.Cells["NUM_ALM"].Value));

                        string sqlInsertar = @"INSERT INTO elastosystem_sae_facturas_partidas(Clave_Documento, Producto, Cantidad, Almacen)
                                                VALUES (@CLAVEDOCUMENTO, @PRODUCTO, @CANTIDAD, @ALMACEN)";
                        MySqlCommand cmdInsertar = new MySqlCommand(sqlInsertar, conn);
                        cmdInsertar.Parameters.AddWithValue("@CLAVEDOCUMENTO", claveDocumento);
                        cmdInsertar.Parameters.AddWithValue("@PRODUCTO", claveArticulo);
                        cmdInsertar.Parameters.AddWithValue("@CANTIDAD", cantidad);
                        cmdInsertar.Parameters.AddWithValue("@ALMACEN", almacen);
                        cmdInsertar.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ACTUALIZAR PARTIDAS DE FACTURAS: " + ex.Message);
            }
        }

        private void ValidarNumero(KeyPressEventArgs e, TextBox textBox)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void CargarProductos()
        {
            if (cbProductos.InvokeRequired)
            {
                cbProductos.Invoke((Action)(() => CargarProductos()));
                return;
            }
            cbProductos.Items.Clear();
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);

            try
            {
                mySqlConnection.Open();
                string sql = "SELECT Producto FROM elastosystem_sae_productos";

                List<string> productos = new List<string>();
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string producto = reader["Producto"].ToString();
                        if (!string.IsNullOrEmpty(producto) && !producto.StartsWith("0") && !producto.StartsWith(" "))
                        {
                            productos.Add(producto);
                        }
                    }
                }
                productos.Sort();
                cbProductos.Items.AddRange(productos.ToArray());
                autoComplete.AddRange(productos.ToArray());
                cbProductos.AutoCompleteCustomSource = autoComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"OCURRIO UN ERROR AL CARGAR LOS PRODUCTOS: {ex.Message}");
            }
            finally
            {
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbConsumoMensual.Clear();
            txbMaxOC.Clear();

            string producto = cbProductos.Text;

            string sql = "SELECT `1M`, `CantidadMaxOC` FROM elastosystem_sae_productos WHERE Producto = @Producto";

            using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    using(MySqlCommand comando = new MySqlCommand(sql, conn))
                    {
                        comando.Parameters.AddWithValue("@Producto", producto);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int consumoMensual = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                int cantidadMaxOC = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);

                                txbConsumoMensual.Text = consumoMensual.ToString();
                                txbMaxOC.Text = cantidadMaxOC.ToString();
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"OCURRIO UN ERROR AL CARGAR EL CONSUMO MENSUAL: {ex.Message}");
                }
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            CalcularMesesYAgregar();
        }

        private void Limpiar()
        {
            cbProductos.SelectedIndex = -1;
            txbConsumoMensual.Clear();
            txbMaxOC.Clear();
        }

        private void CalcularMesesYAgregar()
        {
            int m1 = int.Parse(txbConsumoMensual.Text);
            int m2 = m1 * 2;
            int m3 = m1 * 3;
            int m4 = m1 * 4;
            int tm = m1 / 3;

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "UPDATE elastosystem_sae_productos SET TM = @TM, 1M = @MES1, 2M = @MES2, 3M = @MES3, 4M = @MES4, CantidadMaxOC = @MAXOC WHERE Producto = @PRODUCTO";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@TM", tm);
                    cmd.Parameters.AddWithValue("@MES1", m1);
                    cmd.Parameters.AddWithValue("@MES2", m2);
                    cmd.Parameters.AddWithValue("@MES3", m3);
                    cmd.Parameters.AddWithValue("@MES4", m4);
                    cmd.Parameters.AddWithValue("@PRODUCTO", cbProductos.Text);
                    cmd.Parameters.AddWithValue("@MAXOC", txbMaxOC.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("PRODUCTO ACTUALIZADO CORRECTAMENTE");
                        Limpiar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR LOS DATOS: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        private void txbConsumoMensual_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(e, txbConsumoMensual);
        }

        private void btnDescargarReporte_Click(object sender, EventArgs e)
        {
            string producto = lblProductos.Text;
            try
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Guardar reporte como";
                    saveFileDialog.FileName = producto + " Reporte.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new ClosedXML.Excel.XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Reporte");

                            for (int i = 0; i < dgvReporte.Columns.Count; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = dgvReporte.Columns[i].HeaderText;
                            }

                            for (int i = 0; i < dgvReporte.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvReporte.Columns.Count; j++)
                                {
                                    worksheet.Cell(i + 2, j + 1).Value = dgvReporte.Rows[i].Cells[j].Value?.ToString() ?? string.Empty;
                                }
                            }

                            worksheet.Columns().AdjustToContents();

                            workbook.SaveAs(saveFileDialog.FileName);

                            MessageBox.Show("Archivo Excel generado correctamente");

                            System.Diagnostics.Process.Start("explorer", saveFileDialog.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL GENERAR EL ARCHIVO EXCEL: " + ex.Message);
            }
        }

        string Producto;
        string Cliente;
        string Fechas;
        string FechaInicio;
        string FechaFinal;

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            using (Almacen_FacturasSAE_Filtro dialogo = new Almacen_FacturasSAE_Filtro())
            {
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    Producto = dialogo.Producto;
                    Cliente = dialogo.Cliente;
                    Fechas = dialogo.Fechas;
                    FechaInicio = dialogo.FechaInicio;
                    FechaFinal = dialogo.FechaFinal;

                    lblProductos.Text = string.Empty; lblClientes.Text = string.Empty; lblFechas.Text = string.Empty; lblFechaInicio.Text = string.Empty; lblFechaFinal.Text = string.Empty;

                    lblProductos.Text = Producto;
                    lblClientes.Text = Cliente;
                    lblFechas.Text = Fechas;
                    lblFechaInicio.Text = FechaInicio;
                    lblFechaFinal.Text = FechaFinal;


                    if (lblProductos.Text == "productostodos" && lblClientes.Text == "clientestodos" && lblFechas.Text == "fechasnofiltradas")
                    {
                        CargarDatosCombinados();
                    }
                    else
                    {
                        Buscador();
                    }
                }
            }
        }

        private void Buscador()
        {
            string query = @"
                    SELECT
                        f.Clave_Documento,
                        f.Clave_Cliente,
                        c.Nombre AS Nombre_Cliente,
                        p.Producto,
                        p.Cantidad,
                        f.Status,
                        f.Fecha_Documento
                    FROM elastosystem_sae_facturas AS f
                    INNER JOIN elastosystem_sae_facturas_partidas AS p
                        ON f.Clave_Documento = p.Clave_Documento
                    INNER JOIN elastosystem_sae_clientes AS c
                        ON f.Clave_Cliente = c.Clave
                    WHERE f.Status IN ('E', 'O')
                        AND p.Almacen = 1";

            if (lblClientes.Text != "clientestodos")
            {
                query += " AND f.Clave_Cliente = @ClaveCliente";
            }

            if (lblProductos.Text != "productostodos")
            {
                query += " AND p.Producto = @Producto";
            }

            if (lblFechas.Text != "fechasnofiltradas")
            {
                query += " AND f.Fecha_Documento BETWEEN @FechaInicio AND @FechaFin";
            }

            query += " ORDER BY f.Fecha_Documento DESC;";

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    if (lblClientes.Text != "clientestodos")
                        cmd.Parameters.AddWithValue("@ClaveCliente", lblClientes.Text);

                    if (lblProductos.Text != "productostodos")
                        cmd.Parameters.AddWithValue("@Producto", lblProductos.Text);

                    if (lblFechas.Text != "fechasnofiltradas")
                    {
                        cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                        cmd.Parameters.AddWithValue("@FechaFin", FechaFinal);
                    }

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable datos = new DataTable();
                    adaptador.Fill(datos);

                    dgvReporte.AutoGenerateColumns = true;
                    dgvReporte.DataSource = datos;
                    dgvReporte.Visible = true;
                    dgvReporte.Columns["Clave_Documento"].HeaderText = "Factura";
                    dgvReporte.Columns["Clave_Cliente"].HeaderText = "Clave Cliente";
                    dgvReporte.Columns["Status"].Visible = false;
                    dgvReporte.Columns["Fecha_Documento"].HeaderText = "Fecha";
                    dgvReporte.Columns["Nombre_Cliente"].HeaderText = "Cliente";

                    bool todosIguales = datos.AsEnumerable()
                        .Select(row => row["Producto"].ToString())
                        .Distinct()
                        .Count() == 1;

                    btnDescargarPDF.Visible = todosIguales;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR DGV DE REPORTE: " + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }


        }

        private void txbMaxOC_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(e, txbMaxOC);
        }

        private void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            string fecha = " ";
            string producto = lblProductos.Text;
            int totalRegistros = dgvReporte.RowCount;
            double sumaTotal = 0, promedioAnios = 0, promedioMeses = 0, promedioDias = 0;
            double maxCantidad = double.MinValue;

            string nombreColumna = "Cantidad";
            string columnaFecha = "Fecha_Documento";
            DateTime fechaInicioH, fechaFinalH;

            Dictionary<int, Dictionary<int, double>> sumasPorAnioYMes = new();

            if (lblFechas.Text == "fechasnofiltradas")
            {
                DateTime minFecha = DateTime.MaxValue;
                DateTime maxFecha = DateTime.MinValue;

                foreach (DataGridViewRow fila in dgvReporte.Rows)
                {
                    if (fila.Cells[columnaFecha].Value != null &&
                        DateTime.TryParse(fila.Cells[columnaFecha].Value.ToString(), out DateTime fechaActual))
                    {
                        minFecha = (fechaActual < minFecha) ? fechaActual : minFecha;
                        maxFecha = (fechaActual > maxFecha) ? fechaActual : maxFecha;
                    }
                }

                fechaInicioH = minFecha;
                fechaFinalH = maxFecha;
                lblFechaInicio.Text = fechaInicioH.ToString("yyyy-MM-dd");
                lblFechaFinal.Text = fechaFinalH.ToString("yyyy-MM-dd");
                fecha = lblFechaInicio.Text + " - " + lblFechaFinal.Text;
            }
            else
            {
                fecha = lblFechas.Text;
            }

            foreach (DataGridViewRow fila in dgvReporte.Rows)
            {
                if (fila.Cells[columnaFecha].Value != null &&
                    DateTime.TryParse(fila.Cells[columnaFecha].Value.ToString(), out DateTime fechaActual) &&
                    fila.Cells[nombreColumna].Value != null &&
                    double.TryParse(fila.Cells[nombreColumna].Value.ToString(), out double valor))
                {
                    sumaTotal += valor;

                    if (valor > maxCantidad)
                    {
                        maxCantidad = valor;
                    }

                    int anio = fechaActual.Year;
                    int mes = fechaActual.Month;

                    if (!sumasPorAnioYMes.ContainsKey(anio))
                        sumasPorAnioYMes[anio] = new Dictionary<int, double>();

                    if (!sumasPorAnioYMes[anio].ContainsKey(mes))
                        sumasPorAnioYMes[anio][mes] = 0;

                    sumasPorAnioYMes[anio][mes] += valor;
                }
            }

            DateTime fechaInicio = DateTime.ParseExact(lblFechaInicio.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime fechaFinal = DateTime.ParseExact(lblFechaFinal.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            TimeSpan diferencia = fechaFinal - fechaInicio;

            double anios = fechaFinal.Year - fechaInicio.Year;
            double meses = fechaFinal.Month - fechaInicio.Month;
            double dias = fechaFinal.Day - fechaInicio.Day;

            if (dias < 0)
            {
                meses--;
                dias += DateTime.DaysInMonth(fechaFinal.Year, fechaFinal.Month == 1 ? 12 : fechaFinal.Month - 1);
            }
            if (meses < 0)
            {
                anios--;
                meses += 12;
            }

            double totalMeses = (anios * 12) + meses;
            double totalDias = diferencia.TotalDays;

            promedioAnios = (anios > 0) ? sumaTotal / anios : 0;
            promedioMeses = (totalMeses > 0) ? sumaTotal / totalMeses : 0;
            promedioDias = (totalDias > 0) ? sumaTotal / totalDias : 0;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
            saveFileDialog.Title = "Guardar PDF";
            saveFileDialog.FileName = producto + " Reporte.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = saveFileDialog.FileName;
                iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 36, 36, 36, 36);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                iTextSharp.text.Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                iTextSharp.text.Paragraph titulo = new iTextSharp.text.Paragraph("Reporte de Datos", tituloFont);
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);
                doc.Add(new iTextSharp.text.Paragraph("\n"));

                iTextSharp.text.Font contenidoFont = FontFactory.GetFont("Arial", 11);
                doc.Add(new iTextSharp.text.Paragraph($"Rango de fecha de consulta: {fecha}", contenidoFont));
                doc.Add(new iTextSharp.text.Paragraph($"Producto consultado: {producto}", contenidoFont));
                doc.Add(new iTextSharp.text.Paragraph($"Total de registros: {totalRegistros}", contenidoFont));
                doc.Add(new iTextSharp.text.Paragraph($"Total de producto: {sumaTotal:F2}", contenidoFont));
                doc.Add(new iTextSharp.text.Paragraph($"Valor máximo en una factura: {maxCantidad:F2}", contenidoFont));
                doc.Add(new iTextSharp.text.Paragraph($"Promedio por año: {promedioAnios:F2}", contenidoFont));
                doc.Add(new iTextSharp.text.Paragraph($"Promedio por mes: {promedioMeses:F2}", contenidoFont));
                doc.Add(new iTextSharp.text.Paragraph($"Promedio por día: {promedioDias:F2}", contenidoFont));
                doc.Add(new iTextSharp.text.Paragraph("\nDETALLE POR AÑO Y MES:", contenidoFont));

                foreach (var anio in sumasPorAnioYMes.Keys.OrderBy(a => a))
                {
                    double sumaAnual = sumasPorAnioYMes[anio].Values.Sum();
                    int cantidadMeses = sumasPorAnioYMes[anio].Count;
                    double promedioMensualAnio = cantidadMeses > 0 ? sumaAnual / cantidadMeses : 0;

                    doc.Add(new iTextSharp.text.Paragraph($"\nTotal {anio} = {sumaAnual:F2}", contenidoFont));
                    doc.Add(new iTextSharp.text.Paragraph($"Promedio mensual {anio} = {promedioMensualAnio:F2}", contenidoFont));

                    int mesMayor = sumasPorAnioYMes[anio].OrderByDescending(m => m.Value).First().Key;

                    foreach (var mes in sumasPorAnioYMes[anio].Keys.OrderBy(m => m))
                    {
                        string nombreMes = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(new DateTime(anio, mes, 1).ToString("MMMM", CultureInfo.CurrentCulture));
                        string textoMes = $"   {nombreMes} {anio} = {sumasPorAnioYMes[anio][mes]:F2}";

                        if (mes == mesMayor)
                        {
                            iTextSharp.text.Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
                            doc.Add(new iTextSharp.text.Paragraph(textoMes, boldFont));
                        }
                        else
                        {
                            doc.Add(new iTextSharp.text.Paragraph(textoMes, contenidoFont));
                        }
                    }
                }

                doc.Close();
                MessageBox.Show("PDF guardado como '" + System.IO.Path.GetFileName(rutaArchivo) + "'", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if(System.IO.File.Exists(rutaArchivo))
                {
                    System.Diagnostics.Process.Start("explorer.exe", rutaArchivo);
                }
                else
                {
                    MessageBox.Show("EL ARCHIVO NO SE PUEDE ENCONTRAR");
                }
            }


        }
    }
}
