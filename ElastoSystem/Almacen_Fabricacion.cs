using FirebirdSql.Data.FirebirdClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElastoSystem
{
    public partial class Almacen_Fabricacion : Form
    {
        public Almacen_Fabricacion()
        {
            InitializeComponent();
        }

        private async void Almacen_Fabricacion_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;

            await Task.Run(() =>
            {
                CargarSAE();
                progressBar1.Invoke((Action)(() => progressBar1.Value = 70));
                MandarALlamarProductos();
                progressBar1.Invoke((Action)(() => progressBar1.Value = 80));
                Sincronizacion();
                progressBar1.Invoke((Action)(() => progressBar1.Value = 85));
                CargarClaveProductoInicio();
                progressBar1.Invoke((Action)(() => progressBar1.Value = 90));

                progressBar1.Invoke((Action)(() => progressBar1.Value = 95));
            });

            pnlCarga.Visible = false;
            CargarSolicitudesEnviadas();
            CargarSolicitudesEnProceso();
            CargarSolicitudesFinalizadas();
            Folio();
            Fecha();
            btnAbrir.Visible = true;
        }

        private void CargarSolicitudesEnviadas()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = @"
                        SELECT
                            Folio_ALT,
                            IFNULL(Fecha, '0000-00-00') AS Fecha,
                            Solicitante,
                            Clave,
                            Cantidad,
                            Notas
                        FROM elastosystem_almacen_solicitud_fabricacion
                        WHERE Estatus = 'Enviada'
                        ORDER BY Folio_ALT DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);
                            dgvSolicitudes.DataSource = dt;
                            dgvSolicitudes.Columns["Folio_ALT"].HeaderText = "Folio";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR LAS SOLICITUDES ENVIADAS: " + ex.Message);
            }
        }

        private void CargarSolicitudesEnProceso()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = @"
                        SELECT
                            Folio_ALT,
                            IFNULL(Fecha, '0000-00-00') AS Fecha,
                            Clave,
                            Cantidad,
                            OP,
                            Cantidad_Produccion
                        FROM elastosystem_almacen_solicitud_fabricacion
                        WHERE Estatus = 'En Proceso'
                        ORDER BY Folio_ALT DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);
                            dgvEnProceso.DataSource = dt;
                            dgvEnProceso.Columns["Folio_ALT"].HeaderText = "Folio";
                            dgvEnProceso.Columns["Cantidad_Produccion"].HeaderText = "Produciendo";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR LAS SOLICITUDES EN PROCESO: " + ex.Message);
            }
        }

        private void CargarSolicitudesFinalizadas()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = @"
                        SELECT
                            Folio_ALT,
                            IFNULL(Fecha, '0000-00-00') AS Fecha,
                            Clave,
                            Cantidad,
                            OP,
                            Cantidad_Produccion,
                            IFNULL(Finalizado, '0000-00-00') AS Finalizado
                        FROM elastosystem_almacen_solicitud_fabricacion
                        WHERE Estatus = 'Finalizada' OR Estatus = 'Cancelada'
                        ORDER BY Folio_ALT DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);
                            dgvFinalizadas.DataSource = dt;
                            dgvFinalizadas.Columns["Folio_ALT"].HeaderText = "Folio";
                            dgvFinalizadas.Columns["Cantidad_Produccion"].HeaderText = "Producido";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR LAS SOLICITUDES FINALIZADAS: " + ex.Message);
            }
        }

        private void Fecha()
        {
            DateTime fechaActual = DateTime.Now;
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string fechaLarga = fechaActual.ToString("dddd, dd 'de' MMMM 'de' yyyy", CultureInfo.CurrentCulture);
            fechaLarga = textInfo.ToTitleCase(fechaLarga);
            lblFecha.Text = fechaLarga;
        }

        private void Folio()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlDataReader reader = null;
            string sql = "Select Folio FROM elastosystem_almacen_solicitud_fabricacion";

            try
            {
                int ultimoFolio = 0;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string folioString = reader["Folio"].ToString();
                        if (int.TryParse(folioString, out int folio))
                        {
                            ultimoFolio = folio;
                        }
                    }
                    ultimoFolio = ultimoFolio + 1;
                    lblFolio.Text = "SLF-" + ultimoFolio.ToString();
                    lblFolioOriginal.Text = ultimoFolio.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO AL OBTENER UN NUEVO FOLIO: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void CargarClaveProductoInicio()
        {
            List<string> productos = new List<string>();
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);

            try
            {
                conn.Open();
                string sql = "SELECT Producto FROM elastosystem_sae_productos";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR LA LISTA DE PRODUCTOS: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            if (cbProductos.InvokeRequired)
            {
                cbProductos.Invoke(new Action(() =>
                {
                    cbProductos.Items.Clear();
                    cbProductos.Items.AddRange(productos.ToArray());
                    cbProductos.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                    cbProductos.AutoCompleteCustomSource.AddRange(productos.ToArray());
                }));
            }
            else
            {
                cbProductos.Items.Clear();
                cbProductos.Items.AddRange(productos.ToArray());
                cbProductos.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                cbProductos.AutoCompleteCustomSource.AddRange(productos.ToArray());
            }
        }
        private void MandarALlamarProductos()
        {
            try
            {
                string update = @"
                    UPDATE elastosystem_sae_productos
                    SET Estatus = CASE
                        WHEN `1M` IS NULL OR `1M` = 0 THEN '--------------'
                        WHEN Existencia < `TM` THEN 'Critico'
                        WHEN Existencia >= `TM` AND Existencia < `1M` THEN 'Resurtir'
                        WHEN Existencia >= `1M` AND Existencia < `3M` THEN 'Programar'
                        WHEN Existencia >= `3M` AND Existencia < `4M` THEN 'Suficiente'
                        WHEN Existencia > `4M` THEN 'Sobre Inventario'
                        ELSE ''
                    END,
                    Meses = CASE
                        WHEN `1M` IS NOT NULL AND `1M` > 0 THEN ROUND(Existencia / `1M`, 2)
                        ELSE 0
                    END";

                MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                MySqlCommand cmd = new MySqlCommand(update, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                string query = @"
                    SELECT *
                    FROM elastosystem_sae_productos
                    WHERE Producto NOT LIKE '0%' AND Producto NOT LIKE ' %'
                    ORDER BY
                        CASE
                            WHEN Estatus = 'Critico' THEN 1
                            WHEN Estatus = 'Resurtir' THEN 2
                            WHEN Estatus = 'Programar' THEN 3
                            WHEN Estatus = 'Suficiente' THEN 4
                            WHEN Estatus = 'Sobre Inventario' THEN 5
                            ELSE 6
                        END, Meses ASC";

                MySqlDataAdapter adaptadopr = new MySqlDataAdapter(query, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                adaptadopr.Fill(dt);
                dgvProductosSAE.DataSource = dt;

                dgvProductosSAE.Columns["ID"].Visible = false;
                dgvProductosSAE.Columns["TM"].Visible = false;
                dgvProductosSAE.Columns["CantidadMaxOC"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al llamar productos de Aspel SAE" + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            pnlAlmacen.Visible = false;
            btnAbrir.Visible = true;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            pnlAlmacen.Visible = true;
            btnAbrir.Visible = false;
        }

        private void Sincronizacion()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = "SELECT Actualizacion FROM elastosystem_sae_actualizacion_productos LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            DateTime actualizacion = Convert.ToDateTime(result);
                            lblSincronizacion.Text = "Última sincronización: " + actualizacion.ToString("dd/MM/yyyy HH:mm:ss");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL MANDAR A LLAMAR ULTIMA SINCRONIZACION: " + ex.Message);
            }
        }

        private void CargarSAE()
        {
            try
            {
                dgvProductosSAE2.AutoGenerateColumns = true;

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
                string sql = "SELECT CVE_ART, EXIST FROM mult01 WHERE CVE_ALM = 1";

                comando.Connection = conn;
                comando.CommandText = sql;
                adaptador.SelectCommand = comando;

                conn.Open();
                adaptador.Fill(datos);
                conn.Close();

                bSAspelSAE.DataSource = datos.Tables[0];
                dgvProductosSAE2.DataSource = bSAspelSAE;

                ActualizarBDProductosSAE();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR LOS PRODUCTOS DE ASPEL SAE: " + ex.Message);
            }
        }

        private void ActualizarBDProductosSAE()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dgvProductosSAE2.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string cveArt = row.Cells["CVE_ART"].Value.ToString();
                            string existencia = row.Cells["EXIST"].Value.ToString();

                            string checkQuery = "SELECT COUNT(*) FROM elastosystem_sae_productos WHERE Producto = @CVE_ART";
                            MySqlCommand cmd = new MySqlCommand(checkQuery, conn);
                            cmd.Parameters.AddWithValue("@CVE_ART", cveArt);
                            int count = Convert.ToInt32(cmd.ExecuteScalar());

                            if (count > 0)
                            {
                                string updateQuery = "UPDATE elastosystem_sae_productos SET Existencia = @EXISTENCIA WHERE Producto = @CVE_ART";
                                MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                                updateCmd.Parameters.AddWithValue("@EXISTENCIA", existencia);
                                updateCmd.Parameters.AddWithValue("@CVE_ART", cveArt);
                                updateCmd.ExecuteNonQuery();
                            }
                            else
                            {
                                string insertQuery = "INSERT INTO elastosystem_sae_productos (Producto, Existencia) VALUES (@CVE_ART, @EXISTENCIAS)";
                                MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                                insertCmd.Parameters.AddWithValue("@CVE_ART", cveArt);
                                insertCmd.Parameters.AddWithValue("@EXISTENCIAS", existencia);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                    conn.Close();
                }

                VariablesGlobales.UltimaActualizacion();

            }
            catch (Exception ex)
            {
                MessageBox.Show("HUBO UN ERROR AL ACTUALIZAR EXISTENCIAS DE SAE EN BD: " + ex.Message);
            }
        }

        private void dgvProductosSAE_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProductosSAE.Columns[e.ColumnIndex].Name == "Estatus")
            {
                string estatus = e.Value?.ToString();
                if (!string.IsNullOrEmpty(estatus))
                {
                    DataGridViewRow row = dgvProductosSAE.Rows[e.RowIndex];
                    switch (estatus)
                    {
                        case "Critico":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(200, 30, 45);
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;

                        case "Resurtir":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(220, 70, 85);
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;

                        case "Programar":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 215, 100);
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;

                        case "Suficiente":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(144, 238, 144);
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;

                        case "Sobre Inventario":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(100, 149, 237);
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;

                        default:
                            row.DefaultCellStyle.BackColor = Color.White;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                    }
                }
            }
        }

        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            CargarSAE();
            MandarALlamarProductos();
            Sincronizacion();
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCantidadActual.Text = "------";
            lbl1Mes.Text = "------";
            lbl2Meses.Text = "------";
            lbl3Meses.Text = "------";
            lbl4Meses.Text = "------";
            lblMeses.Text = "------";
            txbCantidad.Clear();
            txbNotas.Clear();

            string producto = cbProductos.Text;

            string sql = "SELECT `Existencia`, `1M`, `2M`, `3M`, `4M`, `Meses` FROM elastosystem_sae_productos WHERE Producto = @PRODUCTO";

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@PRODUCTO", producto);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int cantidadActual = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                int mes1 = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                                int mes2 = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                                int mes3 = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                                int mes4 = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                                double mesesprom = reader.IsDBNull(5) ? 0 : reader.GetDouble(5);

                                lblCantidadActual.Text = cantidadActual.ToString();
                                lbl1Mes.Text = mes1.ToString();
                                lbl2Meses.Text = mes2.ToString();
                                lbl3Meses.Text = mes3.ToString();
                                lbl4Meses.Text = (mes4 + 1).ToString();
                                lblMeses.Text = mesesprom.ToString();

                                if (lblCantidadActual.Text == "0" && lbl1Mes.Text == "0" && lbl2Meses.Text == "0" && lbl3Meses.Text == "0" && lbl4Meses.Text == "0")
                                {
                                    lblCantidadActual.Text = "SD";
                                    lbl1Mes.Text = "------";
                                    lbl2Meses.Text = "------";
                                    lbl3Meses.Text = "------";
                                    lbl4Meses.Text = "------";
                                    lblMeses.Text = "------";

                                    return;
                                }

                                double meses = (double)cantidadActual / mes1;
                                if (meses >= 4)
                                {
                                    txbCantidad.Text = "0";
                                    Almacen_SobreInventario sobreInventario = new Almacen_SobreInventario();
                                    sobreInventario.ShowDialog();
                                }
                                else
                                {
                                    txbCantidad.Text = (mes1 * 4 - cantidadActual).ToString();
                                }



                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR LOS DATOS DEL PRODUCTO: " + ex.Message);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void txbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            VariablesGlobales.ValidarNumeroEntero(e, txbCantidad);
        }

        private void dgvPartidas_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cbProductos.Text = null;
            txbCantidad.Clear();
            txbNotas.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnEnviarSolicitud_Click(object sender, EventArgs e)
        {
            if (ExisteSolicitudEnviada(cbProductos.Text))
            {
                MessageBox.Show("YA EXISTE UNA SOLICITUD DE FABRICACION PARA ESTE PRODUCTO");
                return;
            }

            if (string.IsNullOrEmpty(cbProductos.Text) || string.IsNullOrEmpty(txbCantidad.Text))
            {
                MessageBox.Show("NO PUEDES ENVIAR UNA SOLICITUD DE FABRICACION VACIA");
                return;
            }
            if (txbCantidad.Text == "0")
            {
                MessageBox.Show("NO PUEDES ENVIAR UNA SOLICITUD DE FABRICACION CON CANTIDAD 0");
                return;
            }

            int cantidadActual = int.TryParse(lblCantidadActual.Text, out int actual) ? actual : 0;
            int cantidad4Meses = int.TryParse(lbl4Meses.Text, out int cuatroMeses) ? cuatroMeses : 0;
            int cantidad = int.TryParse(txbCantidad.Text, out int txb) ? txb : 0;

            if (cantidadActual + cantidad >= cantidad4Meses)
            {
                Almacen_SobreInventario2 sobreInventario = new Almacen_SobreInventario2();
                if(sobreInventario.ShowDialog() == DialogResult.OK)
                {
                    EnviarSolicitudFabricacion();
                }
            }
            else
            {
                EnviarSolicitudFabricacion();
            }
        }

        private bool ExisteSolicitudEnviada(string claveProducto)
        {
            using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT COUNT(*) FROM elastosystem_almacen_solicitud_fabricacion WHERE Estatus = 'Enviada' AND Clave = @CLAVE";
                    cmd.Parameters.AddWithValue("@CLAVE", claveProducto);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private void EnviarSolicitudFabricacion()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT COUNT(*) FROM elastosystem_almacen_solicitud_fabricacion WHERE Folio = @FOLIO";
                    cmd.Parameters.AddWithValue("@FOLIO", lblFolioOriginal.Text);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        Folio();
                        EnviarSolicitudFabricacion();
                    }
                    else
                    {
                        string clave = cbProductos.Text;
                        string cantidad = txbCantidad.Text;
                        string notas = txbNotas.Text;

                        cmd.CommandText = @"
                            INSERT INTO elastosystem_almacen_solicitud_fabricacion
                            (Folio, Folio_ALT, Fecha, Hora, Solicitante, Estatus, Clave, Cantidad, Notas)
                            VALUES
                            (@FOLIO, @FOLIO_ALT, @FECHA, @HORA, @SOLICITANTE, @ESTATUS, @CLAVE, @CANTIDAD, @NOTAS)";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@FOLIO", lblFolioOriginal.Text);
                        cmd.Parameters.AddWithValue("@FOLIO_ALT", lblFolio.Text);
                        cmd.Parameters.AddWithValue("@FECHA", DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@HORA", DateTime.Now.ToString("HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@SOLICITANTE", VariablesGlobales.Usuario);
                        cmd.Parameters.AddWithValue("@ESTATUS", "Enviada");
                        cmd.Parameters.AddWithValue("@CLAVE", clave);
                        cmd.Parameters.AddWithValue("@CANTIDAD", cantidad);
                        cmd.Parameters.AddWithValue("@NOTAS", notas);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("SOLICITUD DE FABRICACION ENVIADA CORRECTAMENTE");
                        Limpiar();
                        CargarSolicitudesEnviadas();
                        CargarSolicitudesEnProceso();
                        CargarSolicitudesFinalizadas();
                        Folio();
                    }
                }
            }
        }

        private void Limpiar()
        {
            cbProductos.Text = null;
            txbCantidad.Clear();
            txbNotas.Clear();
        }

        private void txbCantidad_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
