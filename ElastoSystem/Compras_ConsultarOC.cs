using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElastoSystem
{
    public partial class Compras_ConsultarOC : Form
    {
        public Compras_ConsultarOC()
        {
            InitializeComponent();
        }

        private void Compras_ConsultarOC_Load(object sender, EventArgs e)
        {
            MandarALlamarOcs();
            MandarALlamarProveedores();
        }

        private void MandarALlamarProveedores()
        {
            cbProveedores.Items.Clear();
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Nombre FROM elastosystem_compras_proveedores";
            try
            {
                HashSet<string> unicos = new HashSet<string>();
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbProveedores.Items.Add(reader["Nombre"].ToString());
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            cbProveedores.Sorted = true;
        }

        private void MandarALlamarDatosProveedor()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            String nombre = cbProveedores.Text;
            MySqlDataReader reader = null;
            string sql = "SELECT Contacto, Telefono, Email FROM elastosystem_compras_proveedores WHERE Nombre LIKE '" + nombre + "' ";
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txbContacto.Text = reader.GetString("Contacto");
                        txbTelefono.Text = reader.GetString("Telefono");
                        txbCorreo.Text = reader.GetString("Email");
                    }
                }
                else
                {
                    MessageBox.Show("ERROR LLAMAR A SISTEMAS");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        private void MandarALlamarOcs()
        {
            dgvOrdenesCompra.DataSource = null;
            dgvOrdenesCompra.Rows.Clear();

            string tabla = "SELECT * FROM elastosystem_compras_oc";
            MySqlDataAdapter mysqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
            DataTable dt = new DataTable();
            mysqlAdapter.Fill(dt);
            dgvOrdenesCompra.DataSource = dt;
            dt.DefaultView.Sort = "Folio DESC";
            dgvOrdenesCompra.Columns["Folio"].Visible = false;
            dgvOrdenesCompra.Columns["Subtotal"].Visible = false;
            dgvOrdenesCompra.Columns["IVA"].Visible = false;
            dgvOrdenesCompra.Columns["Total"].Visible = false;
            dgvOrdenesCompra.Columns["Moneda"].Visible = false;
            dgvOrdenesCompra.Columns["ConfirmacionPedido"].Visible = false;
            dgvOrdenesCompra.Columns["CondicionPago"].Visible = false;
            dgvOrdenesCompra.Columns["TiempoEntrega"].Visible = false;
            dgvOrdenesCompra.Columns["LugarEntrega"].Visible = false;
            dgvOrdenesCompra.Columns["FormaPago"].Visible = false;
            dgvOrdenesCompra.Columns["CertificadoCalidad"].Visible = false;
            dgvOrdenesCompra.Columns["Requisiciones"].Visible = false;
            dgvOrdenesCompra.Columns["Folio_ALT"].HeaderText = "Folio";
            dgvOrdenesCompra.Columns["RequisicionCompra"].HeaderText = "Requisicion";
        }

        private void Buscador()
        {
            try
            {
                string valorBusqueda = txbBuscador.Text;

                if (string.IsNullOrWhiteSpace(valorBusqueda))
                {
                    MandarALlamarOcs();
                }
                else
                {
                    string consulta = "SELECT * FROM elastosystem_compras_oc WHERE Folio_ALT LIKE @ValorBusqueda OR Folio LIKE @ValorBusqueda OR Fecha LIKE @ValorBusqueda OR Proveedor LIKE @ValorBusqueda OR Contacto LIKE @ValorBusqueda OR RequisicionCompra LIKE @ValorBusqueda OR Cotizacion LIKE @ValorBusqueda";

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, VariablesGlobales.ConexionBDElastotecnica);

                    adaptador.SelectCommand.Parameters.AddWithValue("@ValorBusqueda", "%" + valorBusqueda + "%");

                    DataSet datos = new DataSet();

                    adaptador.Fill(datos, "Resultados");

                    dgvOrdenesCompra.DataSource = datos.Tables["Resultados"];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar datos: " + ex.Message);
            }
        }

        private void txbBuscador_TextChanged(object sender, EventArgs e)
        {
            Buscador();
        }

        private void dgvOrdenesCompra_DoubleClick(object sender, EventArgs e)
        {
            Limpiar();
            LimpiarCajasProducto();
            txbSubtotal.Text = string.Empty;
            txbIVA.Text = string.Empty;
            txbTotal.Text = string.Empty;
            dgvListaMateriales.Rows.Clear();
            chbIVA.Checked = false;
            listFolios.Clear();
            listReqs.Clear();


            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string folio = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                lblFolio.Text = folio;

                string requisicion = dgv.Rows[rowIndex].Cells[10].Value.ToString();
                cbRequisicion.Text = requisicion;
                cbRequisicion2.Text = requisicion;

                DateTime fecha = Convert.ToDateTime(dgv.Rows[rowIndex].Cells[2].Value);
                lblFecha.Text = fecha.ToString("dd / MMMM / yyyy", new System.Globalization.CultureInfo("es-ES"));

                string proveedor = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                cbProveedores.Text = proveedor;
                cbProveedores2.Text = proveedor;

                string contacto = dgv.Rows[rowIndex].Cells[4].Value.ToString();
                txbContacto.Text = contacto;
                txbContacto2.Text = contacto;

                string telefono = dgv.Rows[rowIndex].Cells[5].Value.ToString();
                txbTelefono.Text = telefono;
                txbTelefono2.Text = telefono;

                string correo = dgv.Rows[rowIndex].Cells[6].Value.ToString();
                txbCorreo.Text = correo;
                txbCorreo2.Text = correo;

                string moneda = dgv.Rows[rowIndex].Cells[11].Value.ToString();
                cbMoneda.Text = moneda;
                cbMoneda2.Text = moneda;

                string confirmacionpedido = dgv.Rows[rowIndex].Cells[12].Value.ToString();
                cbConfirmacionPedido.Text = confirmacionpedido;
                cbConfirmacionPedido2.Text = confirmacionpedido;

                string condicionpago = dgv.Rows[rowIndex].Cells[13].Value.ToString();
                cbCondicionPago.Text = condicionpago;
                cbCondicionPago2.Text = condicionpago;

                bool cercalidad = Convert.ToBoolean(dgv.Rows[rowIndex].Cells[18].Value);
                if (cercalidad == true)
                {
                    chbCerSi.Checked = true;
                }
                else
                {
                    chbCerNo.Checked = true;
                }

                string tiempoentrega = dgv.Rows[rowIndex].Cells[14].Value.ToString();
                txbTiempoEntrega.Text = tiempoentrega;
                txbTiempoEntrega2.Text = tiempoentrega;

                string lugarentrega = dgv.Rows[rowIndex].Cells[15].Value.ToString();
                txbLugarEntrega.Text = lugarentrega;
                txbLugarEntrega2.Text = lugarentrega;

                string cotizacion = dgv.Rows[rowIndex].Cells[16].Value.ToString();
                txbCotizacion.Text = cotizacion;
                txbCotizacion2.Text = cotizacion;

                string formapago = dgv.Rows[rowIndex].Cells[17].Value.ToString();
                cbFormaPago.Text = formapago;
                cbFormaPago2.Text = formapago;

                MandarALlamarPartidas();

                /*string subtotal = dgv.Rows[rowIndex].Cells[7].Value.ToString();
                txbSubtotal.Text = subtotal;*/

                string iva = dgv.Rows[rowIndex].Cells[8].Value.ToString();
                if (iva == "0")
                {
                    chbIVA.Checked = false;
                }
                else
                {
                    chbIVA.Checked = true;
                }
                txbIVA.Text = iva;

                /*string total = dgv.Rows[rowIndex].Cells[9].Value.ToString();
                txbTotal.Text = total;*/

                txbBuscador.Clear();
                pnlBuscador.Visible = false;
                btnAbrirOCs.Visible = true;


            }
        }

        private void MandarALlamarPartidas()
        {
            try
            {
                string consulta = @"SELECT d.Cantidad, d.Unidad, d.ID_Producto, d.ID, d.Descripcion, d.TipoUso, d.Comentarios, d.Precio, r.Usuario 
                                    FROM elastosystem_compras_requisicion_desglosada d
                                    JOIN elastosystem_compras_requisicion r ON d.ID = r.ID
                                    WHERE d.OC = @OC";
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(consulta, conn);
                    mySqlAdapter.SelectCommand.Parameters.AddWithValue("@OC", lblFolio.Text);

                    DataTable dt = new DataTable();
                    mySqlAdapter.Fill(dt);

                    dgvListaMateriales.Rows.Clear();

                    int partidaCounter = 1;

                    foreach (DataRow row in dt.Rows)
                    {
                        int rowIndex = dgvListaMateriales.Rows.Add();

                        dgvListaMateriales.Rows[rowIndex].Cells["Partida"].Value = partidaCounter;
                        dgvListaMateriales.Rows[rowIndex].Cells["ID"].Value = row["ID_Producto"];
                        dgvListaMateriales.Rows[rowIndex].Cells["Cantidad"].Value = row["Cantidad"];
                        dgvListaMateriales.Rows[rowIndex].Cells["Unidad"].Value = row["Unidad"];

                        string descripcionCompleta = $"{row["Descripcion"]}\nRequisicion: REQ-{row["ID"]} Solicito: {row["Usuario"]} Uso: {row["TipoUso"]}\nComentarios: {row["Comentarios"]}";
                        dgvListaMateriales.Rows[rowIndex].Cells["Descripcion"].Value = descripcionCompleta;

                        dgvListaMateriales.Rows[rowIndex].Cells["Precio"].Value = row["Precio"];

                        float cantidad = Convert.ToSingle(row["Cantidad"]);
                        float precio = Convert.ToSingle(row["Precio"]);
                        float importe = cantidad * precio;

                        dgvListaMateriales.Rows[rowIndex].Cells["Importe"].Value = importe;

                        string req = $"REQ-{row["ID"]}";
                        dgvListaMateriales.Rows[rowIndex].Cells["Requisicion"].Value = req;

                        partidaCounter++;
                    }
                }
                AgregarAListasMasivo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llamar las partidas: " + ex.Message);
            }
        }

        List<string> listFolios = new List<string>();
        List<string> listReqs = new List<string>();

        private void AgregarAListasMasivo()
        {
            foreach (DataGridViewRow row in dgvListaMateriales.Rows)
            {
                if (!row.IsNewRow)
                {
                    string id = row.Cells["ID"].Value?.ToString();
                    if (!string.IsNullOrEmpty(id))
                    {
                        listFolios.Add(id);
                    }

                    string requisicion = row.Cells["Requisicion"].Value?.ToString();
                    if (!string.IsNullOrEmpty(requisicion))
                    {
                        listReqs.Add(requisicion);
                    }
                }
            }

            lblFolios.Text = $"Folios: {string.Join(", ", listFolios)}";
            lblReqs.Text = $"Requisiciones: {string.Join(", ", listReqs)}";
        }

        private void Limpiar()
        {
            lblFolio.Text = "ERROR";
            cbRequisicion.SelectedIndex = -1;
            cbRequisicion2.SelectedIndex = -1;
            cbProveedores.Text = string.Empty;
            cbProveedores2.Text = string.Empty;
            txbContacto.Clear();
            txbContacto2.Clear();
            txbTelefono.Clear();
            txbTelefono2.Clear();
            txbCorreo.Clear();
            txbCorreo2.Clear();
            cbMoneda.SelectedIndex = -1;
            cbMoneda2.SelectedIndex = -1;
            cbConfirmacionPedido.SelectedIndex = -1;
            cbConfirmacionPedido2.SelectedIndex = -1;
            cbCondicionPago.SelectedIndex = -1;
            cbCondicionPago2.SelectedIndex = -1;
            txbTiempoEntrega.Clear();
            txbTiempoEntrega2.Clear();
            txbLugarEntrega.Clear();
            txbLugarEntrega2.Clear();
            txbCotizacion.Clear();
            txbCotizacion2.Clear();
            cbFormaPago.SelectedIndex = -1;
            cbFormaPago2.SelectedIndex = -1;
        }

        private void chbCerNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCerNo.Checked)
            {
                chbCerSi.Checked = false;
            }
        }

        private void chbCerSi_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCerSi.Checked)
            {
                chbCerNo.Checked = false;
            }
        }

        private void cbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            MandarALlamarDatosProveedor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnAbrirOCs.Visible = false;
            pnlBuscador.Visible = true;

            txbDescripcion.ReadOnly = true;
            txbCantidad.ReadOnly = true;
            txbPrecio.ReadOnly = true;
            txbComentarios.ReadOnly = true;
            cbUnidad.Enabled = false;
            cbTipoUso.Enabled = false;

            Limpiar();
            LimpiarCajasProducto();
            pbCamposPartidas.Visible = false;
            lblCamposPartidas.Visible = false;
            pbDescripcion.Visible = false;
            pbCantidad.Visible = false;
            pbUnidad.Visible = false;
            pbPrecio.Visible = false;
            pbTipoUso.Visible = false;
            lblCamposObligatorios2.Visible = false;
            pbCamposObligatorios2.Visible = false;
            pbRequisicion.Visible = false;
            pbProveedor.Visible = false;
            pbContacto.Visible = false;
            pbTelefono.Visible = false;
            pbCorreo.Visible = false;
            pbMoneda.Visible = false;
            pbConfirmacion.Visible = false;
            pbCondicion.Visible = false;
            pbTiempoEntrega.Visible = false;
            pbLugarEntrega.Visible = false;
            pbCotizacion.Visible = false;
            pbFormaPago.Visible = false;

            MandarALlamarOcs();
            MandarALlamarProveedores();

        }

        private void dgvListaMateriales_DoubleClick(object sender, EventArgs e)
        {
            txbDescripcion.ReadOnly = false;
            txbCantidad.ReadOnly = false;
            txbPrecio.ReadOnly = false;
            txbComentarios.ReadOnly = false;
            cbUnidad.Enabled = true;
            cbTipoUso.Enabled = true;

            LimpiarCajasProducto();

            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                lblIDProducto.Text = id;

                string cantidad = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                txbCantidad.Text = cantidad;

                string unidad = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                cbUnidad.Text = unidad;

                string descripcion = dgv.Rows[rowIndex].Cells[4].Value.ToString();
                ExtraerValoresDescripcion(descripcion);

                string precio = dgv.Rows[rowIndex].Cells[5].Value.ToString();
                txbPrecio.Text = precio;

                string requisicion = dgv.Rows[rowIndex].Cells[7].Value.ToString();
                lblRequisicion.Text = requisicion;

                EliminarDeCantidades();

            }
        }

        private void LimpiarCajasProducto()
        {
            txbDescripcion.Clear();
            txbCantidad.Clear();
            cbUnidad.SelectedIndex = -1;
            txbPrecio.Clear();
            cbTipoUso.SelectedIndex = -1;
            txbComentarios.Clear();
            lblIDProducto.Text = string.Empty;
            lblRequisicion.Text = string.Empty;
            lblSolicito.Text = string.Empty;
        }

        private void ExtraerValoresDescripcion(string descripcionlarga)
        {
            string antesDeRequisicion = "";
            string requisicion = "";
            string solicito = "";
            string uso = "";
            string comentarios = "";

            var regexAntesDeRequisicion = new Regex(@"^(.*?)\s*Requisicion:", RegexOptions.Singleline);
            var matchAntesDeRequisicon = regexAntesDeRequisicion.Match(descripcionlarga);
            if (matchAntesDeRequisicon.Success)
            {
                antesDeRequisicion = matchAntesDeRequisicon.Groups[1].Value.Trim();
            }

            txbDescripcion.Text = antesDeRequisicion;

            var regexSolicito = new Regex(@"Solicito:\s*(.*?)\s*Uso:", RegexOptions.IgnoreCase);
            var matchSolicito = regexSolicito.Match(descripcionlarga);
            if (matchSolicito.Success)
            {
                solicito = matchSolicito.Groups[1].Value.Trim();
            }

            lblSolicito.Text = solicito;

            var regexUso = new Regex(@"Uso:\s*(.*?)\s*Comentarios:", RegexOptions.IgnoreCase);
            var matchUso = regexUso.Match(descripcionlarga);
            if (matchUso.Success)
            {
                uso = matchUso.Groups[1].Value.Trim();
            }

            cbTipoUso.Text = uso;

            var regexComentarios = new Regex(@"Comentarios:\s*(.*)", RegexOptions.IgnoreCase);
            var matchComentarios = regexComentarios.Match(descripcionlarga);
            if (matchComentarios.Success)
            {
                comentarios = matchComentarios.Groups[1].Value.Trim();
            }

            txbComentarios.Text = comentarios;
        }

        private void dgvListaMateriales_Click(object sender, EventArgs e)
        {
            LimpiarCajasProducto();
        }

        private void EliminarDeCantidades()
        {
            foreach (DataGridViewRow row in dgvListaMateriales.SelectedRows)
            {
                dgvListaMateriales.Rows.Remove(row);
            }
            RenumerarPartidas();

            if (chbIVA.Checked)
            {
                TotalIVA();
            }
            else
            {
                Total();
            }
            EliminarDeListas();
        }

        private void EliminarDeListas()
        {
            listFolios.Remove(lblIDProducto.Text);
            listReqs.Remove(lblRequisicion.Text);

            lblFolios.Text = $"Folios: {string.Join(", ", listFolios)}";
            lblReqs.Text = $"Requisiciones: {string.Join(", ", listReqs)}";
        }

        private void RenumerarPartidas()
        {
            for (int i = 0; i < dgvListaMateriales.Rows.Count; i++)
            {
                dgvListaMateriales.Rows[i].Cells["Partida"].Value = i + 1;
            }
        }

        private void TotalIVA()
        {
            double suma = 0;
            double iva = 0;
            double total = 0;
            foreach (DataGridViewRow fila in dgvListaMateriales.Rows)
            {
                double valorCelda;
                if (double.TryParse(fila.Cells[6].Value.ToString(), out valorCelda))
                {
                    suma += valorCelda;
                }
            }
            iva = suma * 0.16;
            iva = Math.Round(iva, 2);
            total = suma + iva;
            total = Math.Round(total, 2);
            txbSubtotal.Text = suma.ToString();
            txbIVA.Text = iva.ToString();
            txbTotal.Text = total.ToString();
        }

        private void Total()
        {
            double suma = 0;
            double total = 0;
            foreach (DataGridViewRow fila in dgvListaMateriales.Rows)
            {
                double valorCelda;
                if (double.TryParse(fila.Cells[6].Value.ToString(), out valorCelda))
                {
                    suma += valorCelda;
                }
            }
            total = suma;
            total = Math.Round(total, 2);
            txbSubtotal.Text = suma.ToString();
            txbIVA.Text = string.Empty;
            txbTotal.Text = total.ToString();
        }

        private void chbIVA_CheckedChanged(object sender, EventArgs e)
        {
            if (chbIVA.Checked)
            {
                TotalIVA();
            }
            else
            {
                Total();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarADGV();
        }

        private void AgregarADGV()
        {
            if (string.IsNullOrEmpty(txbDescripcion.Text) || string.IsNullOrEmpty(txbCantidad.Text) || string.IsNullOrEmpty(txbPrecio.Text) || cbUnidad.SelectedIndex == -1 || cbTipoUso.SelectedIndex == -1)
            {
                MessageBox.Show("Debes de llenar los campos obligatorios");
                pbCamposPartidas.Visible = true;
                lblCamposPartidas.Visible = true;
                pbDescripcion.Visible = true;
                pbCantidad.Visible = true;
                pbUnidad.Visible = true;
                pbPrecio.Visible = true;
                pbTipoUso.Visible = true;
            }
            else
            {
                pbCamposPartidas.Visible = false;
                lblCamposPartidas.Visible = false;
                pbDescripcion.Visible = false;
                pbCantidad.Visible = false;
                pbUnidad.Visible = false;
                pbPrecio.Visible = false;
                pbTipoUso.Visible = false;

                double valor1;
                double valor2;
                string pre = txbPrecio.Text;
                pre = pre.Replace("$", "").Replace(" ", " ");
                txbPrecio.Text = pre;

                if (double.TryParse(txbPrecio.Text, out valor1) && double.TryParse(txbCantidad.Text, out valor2))
                {
                    double importe = valor1 * valor2;
                    importe = Math.Round(importe, 2);
                    string folio = lblIDProducto.Text;
                    string cantidad = txbCantidad.Text;
                    string unidad = cbUnidad.Text;
                    string descripcion = txbDescripcion.Text + "\n" + "Requisicion: " + lblRequisicion.Text + ",    " + "Solicito: " + lblSolicito.Text + ",    " + "Uso: " + cbTipoUso.Text + "\n" + "Comentarios: " + txbComentarios.Text;
                    string precio = txbPrecio.Text;
                    string req = lblRequisicion.Text;

                    int partida = dgvListaMateriales.Rows.Count + 1;

                    dgvListaMateriales.Rows.Add(partida, folio, cantidad, unidad, descripcion, precio, importe, req);

                    if (chbIVA.Checked)
                    {
                        TotalIVA();
                    }
                    else
                    {
                        Total();
                    }
                    AgregarAListas();
                    MessageBox.Show("PRODUCTO AGREGADO");
                    LimpiarCajasProducto();
                }
                else
                {
                    MessageBox.Show("REVISA TUS DATOS EN PRECIO O CANTIDAD, NO SON NUMEROS VALIDOS");
                }
            }
        }

        private void AgregarAListas()
        {
            listFolios.Add(lblIDProducto.Text);
            listReqs.Add(lblRequisicion.Text);

            lblFolios.Text = $"Folios: {string.Join(", ", listFolios)}";
            lblReqs.Text = $"Requisiciones: {string.Join(", ", listReqs)}";
        }

        string listarequisiciones = "";
        private void ListaRequisiciones()
        {
            listReqs = listReqs.Distinct().ToList();
            listarequisiciones = string.Join(", ", listReqs);
        }

        string RespuestaGuardado = "IGUAL";

        private void RevisarCambios()
        {
            if(cbRequisicion.Text != cbRequisicion2.Text ||
               cbProveedores.Text != cbProveedores2.Text ||
               txbContacto.Text != txbContacto2.Text ||
               txbTelefono.Text != txbTelefono2.Text ||
               txbCorreo.Text != txbCorreo2.Text ||
               cbMoneda.Text != cbMoneda2.Text ||
               cbConfirmacionPedido.Text != cbConfirmacionPedido2.Text ||
               cbCondicionPago.Text != cbCondicionPago2.Text ||
               txbTiempoEntrega.Text != txbTiempoEntrega2.Text ||
               txbLugarEntrega.Text != txbLugarEntrega2.Text ||
               txbCotizacion.Text != txbCotizacion2.Text ||
               cbFormaPago.Text != cbFormaPago2.Text)
            {
                

                using (Compras_CambiosOC dialogo = new Compras_CambiosOC())
                {
                    if(dialogo.ShowDialog() == DialogResult.OK)
                    {
                        RespuestaGuardado = dialogo.OCSave;
                        if(RespuestaGuardado == "Sobreescribir")
                        {
                            ActualizarOC();   
                        }
                        else if(RespuestaGuardado == "NuevaOC")
                        {
                            MessageBox.Show("NuevaOC");
                        }
                        else
                        {

                        }
                    }
                }
            }
        }

        private void ActualizarOC()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE elastosystem_compras_oc SET Proveedor = @PROVEEDOR, Contacto = @CONTACTO, Telefono = @TELEFONO, Correo = @CORREO, RequisicionCompra = @REQUISICIONCOMPRA, Moneda = @MONEDA, ConfirmacionPedido = @CONFIRMACIONPEDIDO, CondicionPago = @CONDICIONPAGO, TiempoEntrega = @TIEMPOENTREGA, LugarEntrega = @LUGARENTREGA, Cotizacion = @COTIZACION, FormaPago = @FORMAPAGO, Requisiciones = @REQUISICIONES WHERE Folio_ALT = @FOLIOALT";
                cmd.Parameters.AddWithValue("@FOLIOALT", lblFolio.Text);
                cmd.Parameters.AddWithValue("@PROVEEDOR", cbProveedores.Text);
                cmd.Parameters.AddWithValue("@CONTACTO", txbContacto.Text);
                cmd.Parameters.AddWithValue("@TELEFONO", txbTelefono.Text);
                cmd.Parameters.AddWithValue("@CORREO", txbCorreo.Text);
                cmd.Parameters.AddWithValue("@REQUISICIONCOMPRA", cbRequisicion.Text);
                cmd.Parameters.AddWithValue("@MONEDA", cbMoneda.Text);
                cmd.Parameters.AddWithValue("@CONFIRMACIONPEDIDO", cbConfirmacionPedido.Text);
                cmd.Parameters.AddWithValue("@CONDICIONPAGO", cbCondicionPago.Text);
                cmd.Parameters.AddWithValue("@TIEMPOENTREGA", txbTiempoEntrega.Text);
                cmd.Parameters.AddWithValue("@LUGARENTREGA", txbLugarEntrega.Text);
                cmd.Parameters.AddWithValue("@COTIZACION", txbCotizacion.Text);
                cmd.Parameters.AddWithValue("@FORMAPAGO", cbFormaPago.Text);
                cmd.Parameters.AddWithValue("@REQUISICIONES", listarequisiciones);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar oc en la base de datos" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnGenerarOC_Click(object sender, EventArgs e)
        {
            if(decimal.TryParse(txbTotal.Text, out decimal numero))
            {
                if (cbMoneda.Text == "DOLARES")
                {
                    string numeroEnLetras = VariablesGlobales.ConvertidorNumerosALetrasUSD.ConvertirNumeroALetras(numero);
                    lblTotalLetra.Text = numeroEnLetras;
                }
                else if (cbMoneda.Text == "EUROS")
                {
                    string numeroEnLetras = VariablesGlobales.ConvertidorNumerosALetrasEuro.ConvertirNumeroALetras(numero);
                    lblTotalLetra.Text = numeroEnLetras;
                }
                else
                {
                    string numeroEnLetras = VariablesGlobales.ConvertidorNumerosALetrasPESOS.ConvertirNumeroALetras(numero);
                    lblTotalLetra.Text = numeroEnLetras;
                }

                if (cbRequisicion.SelectedIndex >= 0 && cbProveedores.Text.Length > 0 && txbContacto.Text.Length > 0 && txbTelefono.Text.Length > 0 && txbCorreo.Text.Length > 0 && cbMoneda.SelectedIndex >= 0 && cbConfirmacionPedido.SelectedIndex >= 0 && cbCondicionPago.Text.Length > 0 && txbTiempoEntrega.Text.Length > 0 && txbLugarEntrega.Text.Length > 0 && txbCotizacion.Text.Length > 0 && cbFormaPago.SelectedIndex >= 0)
                {
                    lblCamposObligatorios2.Visible = false;
                    pbCamposObligatorios2.Visible = false;
                    pbRequisicion.Visible = false;
                    pbProveedor.Visible = false;
                    pbContacto.Visible = false;
                    pbTelefono.Visible = false;
                    pbCorreo.Visible = false;
                    pbMoneda.Visible = false;
                    pbConfirmacion.Visible = false;
                    pbCondicion.Visible = false;
                    pbTiempoEntrega.Visible = false;
                    pbLugarEntrega.Visible = false;
                    pbCotizacion.Visible = false;
                    pbFormaPago.Visible = false;
                    ListaRequisiciones();

                    RespuestaGuardado = "IGUAL";
                    RevisarCambios();
                    if(RespuestaGuardado == "Sobreescribir" || RespuestaGuardado == "NuevaOC" || RespuestaGuardado == "IGUAL")
                    {

                    }
                    else
                    {
                        return;
                    }

                    string certificadodecalidad = " ";
                    if (chbCerSi.Checked)
                    {
                        certificadodecalidad = "SE REQUIERE CERTIFICADO DE CALIDAD";
                    }
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Guardar PDF";
                    saveFileDialog.FileName = lblFolio.Text;

                    

                    if(saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if(cbRequisicion.Text == "ELASTOTECNICA")
                        {
                            ///////////////////////////////////////////////////////////////
                            string rutaArchivoPDF = saveFileDialog.FileName;
                            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 36, 36, 20, 36);
                            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivoPDF, FileMode.Create));
                            doc.Open();

                            // ENCABEZADO
                            string rutaImagen = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\ElastoSystem\\oc_encabezado.jpg";
                            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(rutaImagen);
                            float anchoObjetivoencabezado = 540f;
                            float altoObjetivoencabezado = 125f;
                            imagen.ScaleToFit(anchoObjetivoencabezado, altoObjetivoencabezado);
                            float posYImagen1 = doc.PageSize.Height - doc.TopMargin - imagen.ScaledHeight;
                            imagen.SetAbsolutePosition(doc.Left, posYImagen1);
                            doc.Add(imagen);

                            //PIE DE PAGINA
                            string rutaimagenpie = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\ElastoSystem\\pie_de_pagina.jpg";
                            iTextSharp.text.Image imagepie = iTextSharp.text.Image.GetInstance(rutaimagenpie);
                            float anchopie = 540f;
                            float altopie = 125f;
                            imagepie.ScaleToFit(anchopie, altopie);
                            float posypie = 15f;
                            imagepie.SetAbsolutePosition(doc.Left, posypie);
                            doc.Add(imagepie);


                            iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 6);
                            iTextSharp.text.Font fontCantidadLetras = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.BOLD);
                            iTextSharp.text.Font fontfolios = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8);
                            iTextSharp.text.Font fontceldas = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.UNDEFINED, 8);
                            iTextSharp.text.Font fontgrandes = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9);

                            iTextSharp.text.Font fontocyreq = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7);
                            fontocyreq.Color = BaseColor.WHITE;

                            doc.Add(new iTextSharp.text.Paragraph("\n \n"));

                            string oc = lblFolio.Text;
                            string ocyrequi = "\n \n \n \n \n \n" + "  " + oc + "\n \n" + "  " + listarequisiciones;
                            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(ocyrequi, font);
                            string empresa = cbProveedores.Text;
                            string atencion = txbContacto.Text;
                            string telefono = txbTelefono.Text;
                            string correo = txbCorreo.Text;
                            string datosdelproveedor = empresa + "\n " + atencion + "\n " + telefono + "\n " + correo;
                            iTextSharp.text.Paragraph datospro = new iTextSharp.text.Paragraph(datosdelproveedor, font);

                            // Crear una tabla con una fila y dos celdas
                            PdfPTable tableaa = new PdfPTable(3);
                            tableaa.WidthPercentage = 100;
                            tableaa.SetWidths(new float[] { 50, 20, 30 });

                            // Primera celda: párrafo de condiciones
                            PdfPCell cellOC = new PdfPCell(new Phrase(ocyrequi, fontocyreq));
                            cellOC.HorizontalAlignment = Element.ALIGN_LEFT;
                            cellOC.PaddingLeft = 90;
                            cellOC.BorderWidth = 0;
                            tableaa.AddCell(cellOC);

                            PdfPCell cellVacia = new PdfPCell(new Phrase(" "));
                            cellVacia.BorderWidth = 0;
                            tableaa.AddCell(cellVacia);

                            // Segunda celda: párrafo de firma
                            PdfPCell cellProo = new PdfPCell(new Phrase(datosdelproveedor, font));
                            cellProo.HorizontalAlignment = Element.ALIGN_RIGHT;
                            cellProo.BorderWidth = 0;
                            tableaa.AddCell(cellProo);

                            doc.Add(tableaa);

                            doc.Add(new iTextSharp.text.Paragraph("\n"));

                            iTextSharp.text.Font whiteFonta = new iTextSharp.text.Font(font);
                            whiteFonta.Color = BaseColor.WHITE;
                            string confirmaciondelpedido = cbConfirmacionPedido.Text;
                            string fechaoc = lblFecha.Text;
                            DateTime fechaConvertida;
                            if(DateTime.TryParse(fechaoc, out fechaConvertida))
                            {
                                fechaoc = fechaConvertida.ToString("yyyy-MM-dd");
                            }
                            string barraconfirmacion = "CONFIRMACION DEL PEDIDO: " + confirmaciondelpedido + "               FECHA: " + fechaoc;
                            iTextSharp.text.Paragraph barraconfi = new iTextSharp.text.Paragraph(barraconfirmacion, font);
                            PdfPTable tablef = new PdfPTable(1);
                            tablef.WidthPercentage = 100;
                            PdfPCell cellf = new PdfPCell(new Phrase(barraconfirmacion, whiteFonta));
                            cellf.BorderWidth = 0;
                            cellf.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            cellf.BackgroundColor = new BaseColor(7, 34, 59);
                            tablef.AddCell(cellf);
                            doc.Add(tablef);


                            PdfPTable table = new PdfPTable(6);
                            table.WidthPercentage = 100;

                            float[] columnWidths = new float[] { 7f, 7f, 7f, 59f, 10f, 10f };
                            table.SetWidths(columnWidths);
                            for (int i = 0; i < dgvListaMateriales.Columns.Count; i++)
                            {
                                if (dgvListaMateriales.Columns[i].Visible)
                                {
                                    iTextSharp.text.Font whiteFont = new iTextSharp.text.Font(font);
                                    whiteFont.Color = BaseColor.WHITE;

                                    PdfPCell cell = new PdfPCell(new Phrase(dgvListaMateriales.Columns[i].HeaderText, whiteFont));
                                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                                    cell.BackgroundColor = new BaseColor(7, 34, 59);
                                    table.AddCell(cell);
                                }
                            }
                            doc.Add(table);

                            int maxFilasPorPagina = 20;
                            int numFilas = dgvListaMateriales.Rows.Count;
                            int filaActual = 0;
                            int limiteFilasPrimeraPagina = 20;
                            while (filaActual < numFilas)
                            {
                                if (filaActual % maxFilasPorPagina == 0 && filaActual != 0)
                                {
                                    doc.NewPage();
                                }
                                int filasRestantes = numFilas - filaActual;
                                int filasEnEstaPagina = Math.Min(filasRestantes, maxFilasPorPagina);
                                PdfPTable tableParte1 = new PdfPTable(6);
                                tableParte1.WidthPercentage = 100;
                                float[] columnWidths1 = new float[] { 7f, 7f, 7f, 59f, 10f, 10f };
                                tableParte1.SetWidths(columnWidths1);

                                PdfPTable tableParte2 = new PdfPTable(6);
                                tableParte2.WidthPercentage = 100;
                                float[] columnWidths2 = new float[] { 7f, 7f, 7f, 59f, 10f, 10f };
                                tableParte2.SetWidths(columnWidths2);

                                for (int i = 0; i < filasEnEstaPagina; i++)
                                {
                                    int indiceFila = filaActual + i;
                                    PdfPTable tablaActual = indiceFila < limiteFilasPrimeraPagina ? tableParte1 : tableParte2;

                                    for (int j = 0; j < dgvListaMateriales.Columns.Count; j++)
                                    {
                                        if (dgvListaMateriales.Columns[j].Visible)
                                        {
                                            string valorCelda = dgvListaMateriales.Rows[indiceFila].Cells[j].Value.ToString();
                                            PdfPCell cell;

                                            if (j == 5 || j == 6)
                                            {
                                                valorCelda = "$ " + valorCelda;
                                                cell = new PdfPCell(new Phrase(valorCelda, fontceldas));
                                            }
                                            else
                                            {
                                                cell = new PdfPCell(new Phrase(valorCelda, fontceldas));
                                            }

                                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                                            tablaActual.AddCell(cell);
                                        }
                                    }
                                }

                                doc.Add(tableParte1);

                                doc.Add(tableParte2);

                                filaActual += filasEnEstaPagina;
                            }


                            doc.Add(new iTextSharp.text.Paragraph("\n"));


                            iTextSharp.text.Font whiteFontb = new iTextSharp.text.Font(fontgrandes);
                            whiteFontb.Color = BaseColor.WHITE;
                            string cantidadletras = lblTotalLetra.Text;
                            string cantidadeneletracompleta = "\n \n **" + cantidadletras + "**";
                            iTextSharp.text.Paragraph letracuadro = new iTextSharp.text.Paragraph(cantidadeneletracompleta, fontCantidadLetras);
                            string subtotal = txbSubtotal.Text;
                            string iva = txbIVA.Text;
                            string total = txbTotal.Text;
                            string cantidades = " $" + subtotal + "\n \n" + "$" + iva + "\n \n " + "$" + total;
                            iTextSharp.text.Paragraph cantidadescuadro = new iTextSharp.text.Paragraph(cantidades, font);

                            PdfPTable tableTotales = new PdfPTable(2);
                            tableTotales.WidthPercentage = 100;
                            tableTotales.SetWidths(new float[] { 70, 30 });

                            PdfPCell cellLet = new PdfPCell(new Phrase(cantidadeneletracompleta, fontCantidadLetras));
                            cellLet.HorizontalAlignment = Element.ALIGN_CENTER;
                            cellLet.BorderWidth = 0;
                            tableTotales.AddCell(cellLet);


                            PdfPCell cellTotales = new PdfPCell(new Phrase(cantidades, whiteFontb));
                            cellTotales.HorizontalAlignment = Element.ALIGN_LEFT;
                            cellTotales.PaddingLeft = 105;
                            cellTotales.BorderWidth = 0;
                            tableTotales.AddCell(cellTotales);
                            float tableY = writer.GetVerticalPosition(false);
                            float tableeY = tableY - 58;
                            doc.Add(tableTotales);


                            // CANTIDAD
                            string rutaImagen4 = "";
                            if (cbMoneda.Text == "DOLARES")
                            {
                                rutaImagen4 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\ElastoSystem\\cantidades_USD.jpg";
                                iTextSharp.text.Image imagen4 = iTextSharp.text.Image.GetInstance(rutaImagen4);
                                imagen4.ScaleToFit(170f, 170f);
                                imagen4.SetAbsolutePosition(410, tableeY);
                                doc.Add(imagen4);
                            }
                            else if (cbMoneda.Text == "EUROS")
                            {
                                rutaImagen4 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\ElastoSystem\\cantidades_Euros.jpg";
                                iTextSharp.text.Image imagen4 = iTextSharp.text.Image.GetInstance(rutaImagen4);
                                imagen4.ScaleToFit(150f, 150f);
                                imagen4.SetAbsolutePosition(430, tableeY + 5);
                                doc.Add(imagen4);
                            }
                            else
                            {
                                rutaImagen4 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\ElastoSystem\\cantidades.jpg";
                                iTextSharp.text.Image imagen4 = iTextSharp.text.Image.GetInstance(rutaImagen4);
                                imagen4.ScaleToFit(170f, 170f);
                                imagen4.SetAbsolutePosition(410, tableeY);
                                doc.Add(imagen4);
                            }



                            string cotizacion = txbCotizacion.Text;
                            string condicionpago = cbCondicionPago.Text;
                            string tiempoentrega = txbTiempoEntrega.Text;
                            string lugarentrega = txbLugarEntrega.Text;
                            string formapago = cbFormaPago.Text;
                            string condi = "--------------------------------------------------CONDICIONES--------------------------------------------------" + "\n" + "COTIZACIÓN: " + cotizacion + "\n" + "CONDICIÓN DE PAGO: " + condicionpago + "\n" + "TIEMPO DE ENTREGA: " + tiempoentrega + "\n" + "LUGAR DE ENTREGA: " + "\n" + lugarentrega + "\n" + "HORARIO DE RECEPCION DE MATERIALES 8:00 AM - 16:00 PM" + "\n" + "FAVOR DE ESPECIFICAR EN LA FACTURA LA FORMA DE PAGO:" + "\n" + formapago + "\n" + "ENTREGAR MATERIALES CON COPIA DE SU ORDEN DE COMPRA" + "\n" + certificadodecalidad;
                            iTextSharp.text.Paragraph condiciones = new iTextSharp.text.Paragraph(condi, font);

                            string solicit = lblSolicito.Text;
                            string use = cbTipoUso.Text;
                            string firma = "\n \n \n \n \n \n \n \n \n \n" + "FIRMA DE RECIBIDO: _______________________";
                            //string firma = "\n \n \n \n \n \n \n" + "FIRMA DE RECIBIDO: _______________________" + "\n \n" + "SOLICITO: " + solicit + "\n" + "USO: " + use;
                            iTextSharp.text.Paragraph firm = new iTextSharp.text.Paragraph(firma, font);

                            // Crear una tabla con una fila y dos celdas
                            PdfPTable tablea = new PdfPTable(3);
                            tablea.WidthPercentage = 100;
                            tablea.SetWidths(new float[] { 60, 40, 10 });

                            // Primera celda: párrafo de condiciones
                            PdfPCell cellCondiciones = new PdfPCell(new Phrase(condi, font));
                            cellCondiciones.HorizontalAlignment = Element.ALIGN_LEFT;
                            cellCondiciones.BorderWidth = 0;
                            tablea.AddCell(cellCondiciones);

                            // Segunda celda: párrafo de firma
                            PdfPCell cellFirma = new PdfPCell(new Phrase(firma, font));
                            cellFirma.HorizontalAlignment = Element.ALIGN_CENTER;
                            cellFirma.BorderWidth = 0;
                            tablea.AddCell(cellFirma);
                            string f = " ";
                            PdfPCell cellF = new PdfPCell(new Phrase(f, font));
                            cellF.HorizontalAlignment = Element.ALIGN_CENTER;
                            cellF.BorderWidth = 0;
                            tablea.AddCell(cellF);
                            float posXTabla = 36f;
                            float posYTabla = 165f;
                            float pie = 15f;
                            tablea.TotalWidth = doc.PageSize.Width;
                            tablea.WriteSelectedRows(0, -1, posXTabla, posYTabla, writer.DirectContent);


                            //PIE DE PAGINA
                            string rutaImagen3 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\ElastoSystem\\pie_de_pagina.jpg";
                            float anchoObjetiv = 540f;
                            float altoObjetiv = 125f;
                            iTextSharp.text.Image imagen3 = iTextSharp.text.Image.GetInstance(rutaImagen3);
                            imagen3.ScaleToFit(anchoObjetiv, altoObjetiv);
                            imagen3.SetAbsolutePosition(doc.Left, pie);
                            doc.Add(imagen3);
                            doc.Close();

                            if (RespuestaGuardado == "Sobreescribir")
                            {
                                MessageBox.Show("DATOS ACTUALIZADOS");
                            }

                            MessageBox.Show("PDF guardado como '" + System.IO.Path.GetFileName(rutaArchivoPDF) + "'", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (System.IO.File.Exists(rutaArchivoPDF))
                            {
                                System.Diagnostics.Process.Start("explorer.exe", rutaArchivoPDF);
                            }
                            else
                            {
                                MessageBox.Show("El archivo no se puede encontrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            
                            dgvListaMateriales.DataSource = null;
                            dgvListaMateriales.Rows.Clear();
                            btnAbrirOCs.PerformClick();
                        }
                        //////////////////////////////////////////////////////////////ANDREA/////////////////////////////////////////////////////////////////////////
                        else if (cbRequisicion.Text == "ANDREA")
                        {
                            if (txbLugarEntrega.Text == "ELASTOTECNICA CARR. ANIMAS-COYOTEPEC KM. 4, COYOTEPEC, ESTADO DE MÉXICO")
                            {
                                txbLugarEntrega.Text = "CARR. ANIMAS-COYOTEPEC KM. 4, COYOTEPEC, ESTADO DE MÉXICO";
                            }
                            else
                            {

                            }
                            string rutaArchivoPDF = saveFileDialog.FileName;
                            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 36, 36, 20, 36);
                            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivoPDF, FileMode.Create));
                            doc.Open();

                            // ENCABEZADO
                            string rutaImagen = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\Elastosystem\\oc_encabezado_andrea.jpg";
                            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(rutaImagen);
                            float anchoObjetivoencabezado = 540f;
                            float altoObjetivoencabezado = 125f;
                            imagen.ScaleToFit(anchoObjetivoencabezado, altoObjetivoencabezado);
                            float posYImagen1 = doc.PageSize.Height - doc.TopMargin - imagen.ScaledHeight;
                            imagen.SetAbsolutePosition(doc.Left, posYImagen1);
                            doc.Add(imagen);

                            //PIE DE PAGINA
                            string rutaimagenpie = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\Elastosystem\\pie_de_pagina_andrea.jpg";
                            iTextSharp.text.Image imagepie = iTextSharp.text.Image.GetInstance(rutaimagenpie);
                            float anchopie = 540f;
                            float altopie = 125f;
                            imagepie.ScaleToFit(anchopie, altopie);
                            float posypie = 15f;
                            imagepie.SetAbsolutePosition(doc.Left, posypie);
                            doc.Add(imagepie);


                            iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 6);
                            iTextSharp.text.Font fontceldas = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.UNDEFINED, 8);
                            iTextSharp.text.Font fontgrandes = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9);
                            iTextSharp.text.Font fontand = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10);
                            iTextSharp.text.Font fontCantidadLetras = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.BOLD);

                            doc.Add(new iTextSharp.text.Paragraph("\n"));

                            string oc = lblFolio.Text;
                            string ocyrequi = "\n \n";
                            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(ocyrequi, fontand);
                            string fechaoc = lblFecha.Text;
                            DateTime fechaConvertida;
                            if(DateTime.TryParse(fechaoc, out fechaConvertida))
                            {
                                fechaoc = fechaConvertida.ToString("yyyy-MM-dd");
                            }
                            string datosdelproveedor = "\n" + "ORDEN DE COMPRA: " + oc + "               FECHA: " + fechaoc;
                            iTextSharp.text.Paragraph datospro = new iTextSharp.text.Paragraph(datosdelproveedor, fontand);

                            // Crear una tabla con una fila y dos celdas
                            PdfPTable tableaa = new PdfPTable(2);
                            tableaa.WidthPercentage = 100;
                            tableaa.SetWidths(new float[] { 40, 60 });

                            // Primera celda: párrafo de condiciones
                            PdfPCell cellOC = new PdfPCell(new Phrase(ocyrequi, fontand));
                            cellOC.HorizontalAlignment = Element.ALIGN_LEFT;
                            cellOC.PaddingLeft = 48;
                            cellOC.BorderWidth = 0;
                            tableaa.AddCell(cellOC);

                            // Segunda celda: párrafo de firma
                            PdfPCell cellProo = new PdfPCell(new Phrase(datosdelproveedor, fontand));
                            cellProo.HorizontalAlignment = Element.ALIGN_RIGHT;
                            cellProo.BorderWidth = 0;
                            tableaa.AddCell(cellProo);

                            // Agregar la tabla al documento
                            doc.Add(tableaa);

                            doc.Add(new iTextSharp.text.Paragraph("\n \n"));

                            string info = "Andrea Alitzel Vázquez Ramirez \n" + "RFC: VARA9408086L2 \n" + "DIRECCIÓN: RANCHO EL VERGEL #16B COLONIA: \n" + "SAN ANTONIO, CUAUTITLAN IZCALLI, ESTADO DE MÉXICO C.P: 54725 \n" + "USO DE CFDI: GASTOS EN GENERAL";
                            iTextSharp.text.Paragraph infand = new iTextSharp.text.Paragraph(info, fontand);
                            infand.Alignment = Element.ALIGN_CENTER;
                            doc.Add(infand);

                            doc.Add(new iTextSharp.text.Paragraph("\n"));

                            iTextSharp.text.Font whiteFonta = new iTextSharp.text.Font(font);
                            whiteFonta.Color = BaseColor.WHITE;
                            string confirmaciondelpedido = cbConfirmacionPedido.Text;
                            string barraconfirmacion = "CONFIRMACION DEL PEDIDO: " + confirmaciondelpedido + "               FECHA: " + fechaoc;
                            iTextSharp.text.Paragraph barraconfi = new iTextSharp.text.Paragraph(barraconfirmacion, font);
                            PdfPTable tablef = new PdfPTable(1);
                            tablef.WidthPercentage = 100;
                            PdfPCell cellf = new PdfPCell(new Phrase(barraconfirmacion, whiteFonta));
                            cellf.BorderWidth = 0;
                            cellf.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            cellf.BackgroundColor = new BaseColor(56, 17, 36);
                            tablef.AddCell(cellf);
                            doc.Add(tablef);




                            PdfPTable table = new PdfPTable(6);
                            table.WidthPercentage = 100;

                            float[] columnWidths = new float[] { 7f, 7f, 7f, 59f, 10f, 10f };
                            table.SetWidths(columnWidths);
                            for (int i = 0; i < dgvListaMateriales.Columns.Count; i++)
                            {
                                if (dgvListaMateriales.Columns[i].Visible)
                                {
                                    iTextSharp.text.Font whiteFont = new iTextSharp.text.Font(font);
                                    whiteFont.Color = BaseColor.WHITE;

                                    PdfPCell cell = new PdfPCell(new Phrase(dgvListaMateriales.Columns[i].HeaderText, whiteFont));
                                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                                    cell.BackgroundColor = new BaseColor(56, 17, 36);
                                    table.AddCell(cell);
                                }
                            }
                            doc.Add(table);



                            int maxFilasPorPagina = 20;
                            int numFilas = dgvListaMateriales.Rows.Count;
                            int filaActual = 0;
                            int limiteFilasPrimeraPagina = 20;
                            while (filaActual < numFilas)
                            {
                                if (filaActual % maxFilasPorPagina == 0 && filaActual != 0)
                                {
                                    doc.NewPage();
                                }
                                int filasRestantes = numFilas - filaActual;
                                int filasEnEstaPagina = Math.Min(filasRestantes, maxFilasPorPagina);
                                PdfPTable tableParte1 = new PdfPTable(6);
                                tableParte1.WidthPercentage = 100;
                                float[] columnWidths1 = new float[] { 7f, 7f, 7f, 59f, 10f, 10f };
                                tableParte1.SetWidths(columnWidths1);

                                PdfPTable tableParte2 = new PdfPTable(6);
                                tableParte2.WidthPercentage = 100;
                                float[] columnWidths2 = new float[] { 7f, 7f, 7f, 59f, 10f, 10f };
                                tableParte2.SetWidths(columnWidths2);

                                for (int i = 0; i < filasEnEstaPagina; i++)
                                {
                                    int indiceFila = filaActual + i;
                                    PdfPTable tablaActual = indiceFila < limiteFilasPrimeraPagina ? tableParte1 : tableParte2;

                                    for (int j = 0; j < dgvListaMateriales.Columns.Count; j++)
                                    {
                                        if (dgvListaMateriales.Columns[j].Visible)
                                        {
                                            string valorCelda = dgvListaMateriales.Rows[indiceFila].Cells[j].Value.ToString();
                                            PdfPCell cell;

                                            if (j == 5 || j == 6)
                                            {
                                                valorCelda = "$ " + valorCelda;
                                                cell = new PdfPCell(new Phrase(valorCelda, fontceldas));
                                            }
                                            else
                                            {
                                                cell = new PdfPCell(new Phrase(valorCelda, fontceldas));
                                            }

                                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                                            tablaActual.AddCell(cell);
                                        }
                                    }
                                }

                                doc.Add(tableParte1);

                                doc.Add(tableParte2);

                                filaActual += filasEnEstaPagina;
                            }

                            doc.Add(new iTextSharp.text.Paragraph("\n"));


                            iTextSharp.text.Font whiteFontb = new iTextSharp.text.Font(fontand);
                            whiteFontb.Color = BaseColor.WHITE;
                            string cantidadletras = lblTotalLetra.Text;
                            string monedaescogida = cbMoneda.Text;
                            string cantidadeneletracompleta = "\n \n **" + cantidadletras + " " + "**";
                            iTextSharp.text.Paragraph letracuadro = new iTextSharp.text.Paragraph(cantidadeneletracompleta, fontCantidadLetras);
                            string subtotal = txbSubtotal.Text;
                            string iva = txbIVA.Text;
                            string total = txbTotal.Text;
                            string cantidades = "$" + subtotal + "\n \n" + "$" + iva + "\n \n " + "$" + total;
                            iTextSharp.text.Paragraph cantidadescuadro = new iTextSharp.text.Paragraph(cantidades, font);

                            PdfPTable tableTotales = new PdfPTable(2);
                            tableTotales.WidthPercentage = 100;
                            tableTotales.SetWidths(new float[] { 70, 30 });

                            PdfPCell cellLet = new PdfPCell(new Phrase(cantidadeneletracompleta, fontCantidadLetras));
                            cellLet.HorizontalAlignment = Element.ALIGN_CENTER;
                            cellLet.BorderWidth = 0;
                            tableTotales.AddCell(cellLet);


                            PdfPCell cellTotales = new PdfPCell(new Phrase(cantidades, whiteFontb));
                            cellTotales.HorizontalAlignment = Element.ALIGN_LEFT;
                            cellTotales.PaddingLeft = 105;
                            cellTotales.BorderWidth = 0;
                            tableTotales.AddCell(cellTotales);
                            float tableY = writer.GetVerticalPosition(false);
                            float tableeY = tableY - 58;
                            doc.Add(tableTotales);



                            // CANTIDAD
                            string rutaImagen4 = "";
                            if (cbMoneda.Text == "DOLARES")
                            {
                                rutaImagen4 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\Elastosystem\\cantidades_USD_andrea.jpg";
                            }
                            else if (cbMoneda.Text == "EUROS")
                            {
                                rutaImagen4 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\Elastosystem\\cantidades_Euros_andrea.jpg";
                            }
                            else
                            {
                                rutaImagen4 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\Elastosystem\\cantidades_andrea.jpg";
                            }
                            iTextSharp.text.Image imagen4 = iTextSharp.text.Image.GetInstance(rutaImagen4);
                            imagen4.ScaleToFit(150f, 150f);
                            imagen4.SetAbsolutePosition(430, tableeY);
                            doc.Add(imagen4);



                            string cotizacion = txbCotizacion.Text;
                            string condicionpago = cbCondicionPago.Text;
                            string tiempoentrega = txbTiempoEntrega.Text;
                            string lugarentrega = txbLugarEntrega.Text;
                            string formapago = cbFormaPago.Text;
                            string condi = "--------------------------------------------------CONDICIONES--------------------------------------------------" + "\n" + "COTIZACIÓN: " + cotizacion + "\n" + "CONDICIÓN DE PAGO: " + condicionpago + "\n" + "TIEMPO DE ENTREGA: " + tiempoentrega + "\n" + "LUGAR DE ENTREGA: " + "\n" + lugarentrega + "\n" + "HORARIO DE RECEPCION DE MATERIALES 8:00 AM - 16:00 PM" + "\n" + "FORMA DE PAGO:" + formapago + "\n" + "METODO DE PAGO: PPD" + "\n" + "USO DE CFDI: ADQUISICION DE MERCANCIA" + "\n" + "ENTREGAR MATERIALES CON COPIA DE SU ORDEN DE COMPRA" + "\n" + certificadodecalidad;
                            iTextSharp.text.Paragraph condiciones = new iTextSharp.text.Paragraph(condi, font);

                            string solicit = lblSolicito.Text;
                            string use = cbTipoUso.Text;
                            string firma = "\n \n \n \n \n \n \n \n \n \n" + "FIRMA DE RECIBIDO: _______________________";
                            //string firma = "\n \n \n \n \n \n \n \n" + "FIRMA DE RECIBIDO: _______________________" + "\n \n" + "SOLICITO: " + solicit + "\n" + "USO: " + use;
                            iTextSharp.text.Paragraph firm = new iTextSharp.text.Paragraph(firma, font);

                            // Crear una tabla con una fila y dos celdas
                            PdfPTable tablea = new PdfPTable(3);
                            tablea.WidthPercentage = 100;
                            tablea.SetWidths(new float[] { 60, 40, 10 });

                            // Primera celda: párrafo de condiciones
                            PdfPCell cellCondiciones = new PdfPCell(new Phrase(condi, font));
                            cellCondiciones.HorizontalAlignment = Element.ALIGN_LEFT;
                            cellCondiciones.BorderWidth = 0;
                            tablea.AddCell(cellCondiciones);

                            // Segunda celda: párrafo de firma
                            PdfPCell cellFirma = new PdfPCell(new Phrase(firma, font));
                            cellFirma.HorizontalAlignment = Element.ALIGN_CENTER;
                            cellFirma.BorderWidth = 0;
                            tablea.AddCell(cellFirma);
                            string f = " ";
                            PdfPCell cellF = new PdfPCell(new Phrase(f, font));
                            cellF.HorizontalAlignment = Element.ALIGN_CENTER;
                            cellF.BorderWidth = 0;
                            tablea.AddCell(cellF);
                            float posXTabla = 36f;
                            float posYTabla = 173f;
                            float pie = 15f;
                            tablea.TotalWidth = doc.PageSize.Width;
                            tablea.WriteSelectedRows(0, -1, posXTabla, posYTabla, writer.DirectContent);


                            //PIE DE PAGINA
                            string rutaImagen3 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\Elastosystem\\pie_de_pagina_andrea.jpg";
                            float anchoObjetiv = 540f;
                            float altoObjetiv = 125f;
                            iTextSharp.text.Image imagen3 = iTextSharp.text.Image.GetInstance(rutaImagen3);
                            imagen3.ScaleToFit(anchoObjetiv, altoObjetiv);
                            imagen3.SetAbsolutePosition(doc.Left, pie);
                            doc.Add(imagen3);
                            doc.Close();

                            if (RespuestaGuardado == "Sobreescribir")
                            {
                                MessageBox.Show("DATOS ACTUALIZADOS");
                            }

                            MessageBox.Show("PDF guardado como '" + System.IO.Path.GetFileName(rutaArchivoPDF) + "'", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (System.IO.File.Exists(rutaArchivoPDF))
                            {
                                System.Diagnostics.Process.Start("explorer.exe", rutaArchivoPDF);
                            }
                            else
                            {
                                MessageBox.Show("El archivo no se puede encontrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            dgvListaMateriales.DataSource = null;
                            dgvListaMateriales.Rows.Clear();
                            btnAbrirOCs.PerformClick();

                        }
                        /////////////////////////////////////////////////////////BROSMA
                        else
                        {
                            if (txbLugarEntrega.Text == "ELASTOTECNICA CARR. ANIMAS-COYOTEPEC KM. 4, COYOTEPEC, ESTADO DE MÉXICO")
                            {
                                txbLugarEntrega.Text = "CARR. ANIMAS-COYOTEPEC KM. 4, COYOTEPEC, ESTADO DE MÉXICO";
                            }
                            else
                            {

                            }
                            string rutaArchivoPDF = saveFileDialog.FileName;
                            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 36, 36, 20, 36);
                            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivoPDF, FileMode.Create));
                            doc.Open();

                            string rutaImagen = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\ElastoSystem\\oc_encabezado_brosma.jpg";
                            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(rutaImagen);
                            float anchoObjetivoencabezado = 540f;
                            float altoObjetivoencabezado = 125f;
                            imagen.ScaleToFit(anchoObjetivoencabezado, altoObjetivoencabezado);
                            float posYImagen1 = doc.PageSize.Height - doc.TopMargin - imagen.ScaledHeight;
                            imagen.SetAbsolutePosition(doc.Left, posYImagen1);
                            doc.Add(imagen);

                            string rutaimagenpie = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\ElastoSystem\\pie_brosma.jpg";
                            iTextSharp.text.Image imagepie = iTextSharp.text.Image.GetInstance(rutaimagenpie);
                            float anchopie = 540f;
                            float altopie = 125f;
                            imagepie.ScaleToFit(anchopie, altopie);
                            float posypie = 15f;
                            imagepie.SetAbsolutePosition(doc.Left, posypie);
                            doc.Add(imagepie);

                            iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 6);
                            iTextSharp.text.Font fontCantidadLetras = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.BOLD);
                            iTextSharp.text.Font fontfolios = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8);
                            iTextSharp.text.Font fontceldas = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.UNDEFINED, 8);
                            iTextSharp.text.Font fontgrandes = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9);
                            iTextSharp.text.Font fontdatosencabezado = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8);

                            iTextSharp.text.Font fontocyreq = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7);
                            fontocyreq.Color = BaseColor.WHITE;

                            doc.Add(new iTextSharp.text.Paragraph("\n \n"));

                            string fechaoc = lblFecha.Text;
                            DateTime fechaConvertida;
                            if(DateTime.TryParse(fechaoc, out fechaConvertida))
                            {
                                fechaoc = fechaConvertida.ToString("yyyy-MM-dd");
                            }
                            string oc = lblFolio.Text;
                            string ocyrequi = "\n \n \n \n \n \n" + "  " + oc + "\n \n" + "  " + listarequisiciones;
                            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(ocyrequi, font);
                            string empresa = cbProveedores.Text;
                            string atencion = txbContacto.Text;
                            string telefono = txbTelefono.Text;
                            string correo = txbCorreo.Text;
                            string datosdelproveedor = empresa + "\n " + atencion + "\n " + telefono + "\n " + correo;
                            string datos = "Orden de compra:         " + oc + "                                                                    FECHA: " + fechaoc + "\n" + "Numero de cotización:   " + txbCotizacion.Text + "\n \n" + "Datos del proveedor:" + "\n" + empresa + "\n" + atencion + "\n" + telefono + "\n" + correo;
                            iTextSharp.text.Paragraph datospro = new iTextSharp.text.Paragraph(datosdelproveedor, font);

                            // Crear una tabla con una fila y dos celdas
                            PdfPTable tableaa = new PdfPTable(2);
                            tableaa.WidthPercentage = 100;
                            tableaa.SetWidths(new float[] { 25, 75 });


                            PdfPCell cellVacia = new PdfPCell(new Phrase(" "));
                            cellVacia.BorderWidth = 0;
                            tableaa.AddCell(cellVacia);

                            // Segunda celda: párrafo de firma
                            PdfPCell cellProo = new PdfPCell(new Phrase(datos, fontdatosencabezado));
                            cellProo.HorizontalAlignment = Element.ALIGN_LEFT;
                            cellProo.BorderWidth = 0;
                            tableaa.AddCell(cellProo);

                            doc.Add(tableaa);



                            doc.Add(new iTextSharp.text.Paragraph("\n"));

                            iTextSharp.text.Font whiteFonta = new iTextSharp.text.Font(font);
                            whiteFonta.Color = BaseColor.WHITE;
                            string confirmaciondelpedido = cbConfirmacionPedido.Text;

                            string barraconfirmacion = "CONFIRMACION DEL PEDIDO: " + confirmaciondelpedido;
                            iTextSharp.text.Paragraph barraconfi = new iTextSharp.text.Paragraph(barraconfirmacion, font);
                            PdfPTable tablef = new PdfPTable(1);
                            tablef.WidthPercentage = 100;
                            PdfPCell cellf = new PdfPCell(new Phrase(barraconfirmacion, whiteFonta));
                            cellf.BorderWidth = 0;
                            cellf.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            cellf.BackgroundColor = new BaseColor(2, 39, 58);
                            tablef.AddCell(cellf);
                            doc.Add(tablef);


                            PdfPTable table = new PdfPTable(6);
                            table.WidthPercentage = 100;

                            float[] columnWidths = new float[] { 7f, 7f, 7f, 59f, 10f, 10f };
                            table.SetWidths(columnWidths);
                            for (int i = 0; i < dgvListaMateriales.Columns.Count; i++)
                            {
                                if (dgvListaMateriales.Columns[i].Visible)
                                {
                                    iTextSharp.text.Font whiteFont = new iTextSharp.text.Font(font);
                                    whiteFont.Color = BaseColor.WHITE;

                                    PdfPCell cell = new PdfPCell(new Phrase(dgvListaMateriales.Columns[i].HeaderText, whiteFont));
                                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                                    cell.BackgroundColor = new BaseColor(2, 39, 58);
                                    table.AddCell(cell);
                                }
                            }
                            doc.Add(table);

                            int maxFilasPorPagina = 20;
                            int numFilas = dgvListaMateriales.Rows.Count;
                            int filaActual = 0;
                            int limiteFilasPrimeraPagina = 20;
                            while (filaActual < numFilas)
                            {
                                if (filaActual % maxFilasPorPagina == 0 && filaActual != 0)
                                {
                                    doc.NewPage();
                                }
                                int filasRestantes = numFilas - filaActual;
                                int filasEnEstaPagina = Math.Min(filasRestantes, maxFilasPorPagina);
                                PdfPTable tableParte1 = new PdfPTable(6);
                                tableParte1.WidthPercentage = 100;
                                float[] columnWidths1 = new float[] { 7f, 7f, 7f, 59f, 10f, 10f };
                                tableParte1.SetWidths(columnWidths1);

                                PdfPTable tableParte2 = new PdfPTable(6);
                                tableParte2.WidthPercentage = 100;
                                float[] columnWidths2 = new float[] { 7f, 7f, 7f, 59f, 10f, 10f };
                                tableParte2.SetWidths(columnWidths2);

                                for (int i = 0; i < filasEnEstaPagina; i++)
                                {
                                    int indiceFila = filaActual + i;
                                    PdfPTable tablaActual = indiceFila < limiteFilasPrimeraPagina ? tableParte1 : tableParte2;

                                    for (int j = 0; j < dgvListaMateriales.Columns.Count; j++)
                                    {
                                        if (dgvListaMateriales.Columns[j].Visible)
                                        {
                                            string valorCelda = dgvListaMateriales.Rows[indiceFila].Cells[j].Value.ToString();
                                            PdfPCell cell;

                                            if (j == 5 || j == 6)
                                            {
                                                valorCelda = "$ " + valorCelda;
                                                cell = new PdfPCell(new Phrase(valorCelda, fontceldas));
                                            }
                                            else
                                            {
                                                cell = new PdfPCell(new Phrase(valorCelda, fontceldas));
                                            }

                                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                                            tablaActual.AddCell(cell);
                                        }
                                    }
                                }

                                doc.Add(tableParte1);

                                doc.Add(tableParte2);

                                filaActual += filasEnEstaPagina;
                            }


                            doc.Add(new iTextSharp.text.Paragraph("\n"));


                            iTextSharp.text.Font whiteFontb = new iTextSharp.text.Font(fontgrandes);
                            whiteFontb.Color = BaseColor.WHITE;
                            string cantidadletras = lblTotalLetra.Text;
                            string cantidadeneletracompleta = "\n \n **" + cantidadletras + "**";
                            iTextSharp.text.Paragraph letracuadro = new iTextSharp.text.Paragraph(cantidadeneletracompleta, fontCantidadLetras);
                            string subtotal = txbSubtotal.Text;
                            string iva = txbIVA.Text;
                            string total = txbTotal.Text;
                            string cantidades = " $" + subtotal + "\n \n" + "$" + iva + "\n \n " + "$" + total;
                            iTextSharp.text.Paragraph cantidadescuadro = new iTextSharp.text.Paragraph(cantidades, font);

                            PdfPTable tableTotales = new PdfPTable(2);
                            tableTotales.WidthPercentage = 100;
                            tableTotales.SetWidths(new float[] { 70, 30 });

                            PdfPCell cellLet = new PdfPCell(new Phrase(cantidadeneletracompleta, fontCantidadLetras));
                            cellLet.HorizontalAlignment = Element.ALIGN_CENTER;
                            cellLet.BorderWidth = 0;
                            tableTotales.AddCell(cellLet);


                            PdfPCell cellTotales = new PdfPCell(new Phrase(cantidades, whiteFontb));
                            cellTotales.HorizontalAlignment = Element.ALIGN_LEFT;
                            cellTotales.PaddingLeft = 85;
                            cellTotales.BorderWidth = 0;
                            tableTotales.AddCell(cellTotales);
                            float tableY = writer.GetVerticalPosition(false);
                            float tableeY = tableY - 58;
                            doc.Add(tableTotales);


                            // CANTIDAD
                            string rutaImagen4 = "";
                            if (cbMoneda.Text == "DOLARES")
                            {
                                rutaImagen4 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\ElastoSystem\\cantidades_USD_brosma.jpg";
                            }
                            else if (cbMoneda.Text == "EUROS")
                            {
                                rutaImagen4 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\ElastoSystem\\cantidades_Euros_brosma.jpg";
                            }
                            else
                            {
                                rutaImagen4 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\ElastoSystem\\cantidades_brosma.jpg";
                            }
                            iTextSharp.text.Image imagen4 = iTextSharp.text.Image.GetInstance(rutaImagen4);
                            imagen4.ScaleToFit(138f, 138f);
                            imagen4.SetAbsolutePosition(435, tableeY + 5);
                            doc.Add(imagen4);


                            string cotizacion = txbCotizacion.Text;
                            string condicionpago = cbCondicionPago.Text;
                            string tiempoentrega = txbTiempoEntrega.Text;
                            string lugarentrega = txbLugarEntrega.Text;
                            string formapago = cbFormaPago.Text;
                            string condi = "--------------------------------------------------CONDICIONES--------------------------------------------------" + "\n" + "COTIZACIÓN: " + cotizacion + "\n" + "CONDICIÓN DE PAGO: " + condicionpago + "\n" + "TIEMPO DE ENTREGA: " + tiempoentrega + "\n" + "LUGAR DE ENTREGA: " + "\n" + lugarentrega + "\n" + "HORARIO DE RECEPCION DE MATERIALES 8:00 AM - 16:00 PM" + "\n" + "FAVOR DE ESPECIFICAR EN LA FACTURA LA FORMA DE PAGO:" + "\n" + formapago + "\n" + "ENTREGAR MATERIALES CON COPIA DE SU ORDEN DE COMPRA" + "\n" + certificadodecalidad;
                            iTextSharp.text.Paragraph condiciones = new iTextSharp.text.Paragraph(condi, font);

                            string solicit = lblSolicito.Text;
                            string use = cbTipoUso.Text;
                            string firma = "\n \n \n \n" + "FIRMA DE RECIBIDO: _______________________";
                            //string firma = "\n \n \n \n \n \n \n" + "FIRMA DE RECIBIDO: _______________________" + "\n \n" + "SOLICITO: " + solicit + "\n" + "USO: " + use;
                            iTextSharp.text.Paragraph firm = new iTextSharp.text.Paragraph(firma, font);

                            // Crear una tabla con una fila y dos celdas
                            PdfPTable tablea = new PdfPTable(3);
                            tablea.WidthPercentage = 100;
                            tablea.SetWidths(new float[] { 60, 40, 10 });

                            // Primera celda: párrafo de condiciones
                            PdfPCell cellCondiciones = new PdfPCell(new Phrase(condi, font));
                            cellCondiciones.HorizontalAlignment = Element.ALIGN_LEFT;
                            cellCondiciones.BorderWidth = 0;
                            tablea.AddCell(cellCondiciones);

                            // Segunda celda: párrafo de firma
                            PdfPCell cellFirma = new PdfPCell(new Phrase(firma, font));
                            cellFirma.HorizontalAlignment = Element.ALIGN_CENTER;
                            cellFirma.BorderWidth = 0;
                            tablea.AddCell(cellFirma);
                            string f = " ";
                            PdfPCell cellF = new PdfPCell(new Phrase(f, font));
                            cellF.HorizontalAlignment = Element.ALIGN_CENTER;
                            cellF.BorderWidth = 0;
                            tablea.AddCell(cellF);
                            float posXTabla = 36f;
                            float posYTabla = 145f;
                            float pie = 15f;
                            tablea.TotalWidth = doc.PageSize.Width;
                            tablea.WriteSelectedRows(0, -1, posXTabla, posYTabla, writer.DirectContent);


                            //PIE DE PAGINA
                            string rutaImagen3 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\ElastoSystem\\pie_brosma.jpg";
                            float anchoObjetiv = 540f;
                            float altoObjetiv = 125f;
                            iTextSharp.text.Image imagen3 = iTextSharp.text.Image.GetInstance(rutaImagen3);
                            imagen3.ScaleToFit(anchoObjetiv, altoObjetiv);
                            imagen3.SetAbsolutePosition(doc.Left, pie);
                            doc.Add(imagen3);
                            doc.Close();

                            if (RespuestaGuardado == "Sobreescribir")
                            {
                                MessageBox.Show("DATOS ACTUALIZADOS");
                            }

                            MessageBox.Show("PDF guardado como '" + System.IO.Path.GetFileName(rutaArchivoPDF) + "'", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (System.IO.File.Exists(rutaArchivoPDF))
                            {
                                System.Diagnostics.Process.Start("explorer.exe", rutaArchivoPDF);
                            }
                            else
                            {
                                MessageBox.Show("El archivo no se puede encontrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            dgvListaMateriales.DataSource = null;
                            dgvListaMateriales.Rows.Clear();
                            btnAbrirOCs.PerformClick();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("DEBES DE LLENAR TODOS LOS CAMPOS OBLIGATORIOS");
                    lblCamposObligatorios2.Visible = true;
                    pbCamposObligatorios2.Visible = true;
                    pbRequisicion.Visible = true;
                    pbProveedor.Visible = true;
                    pbContacto.Visible = true;
                    pbTelefono.Visible = true;
                    pbCorreo.Visible = true;
                    pbMoneda.Visible = true;
                    pbConfirmacion.Visible = true;
                    pbCondicion.Visible = true;
                    pbTiempoEntrega.Visible = true;
                    pbLugarEntrega.Visible = true;
                    pbCotizacion.Visible = true;
                    pbFormaPago.Visible = true;
                }
            }
        }
    }
}
