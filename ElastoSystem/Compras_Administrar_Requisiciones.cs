using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using MySql.Data.MySqlClient;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Org.BouncyCastle.Asn1.Cmp;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Vml;
using System.Diagnostics.Eventing.Reader;

namespace ElastoSystem
{
    public partial class Compras_Administrar_Requisiciones : Form
    {
        public Compras_Administrar_Requisiciones()
        {
            InitializeComponent();
        }
        private void CargarRequisiciones()
        {
            try
            {
                string tabla = "SELECT ID, ID_ALT, Usuario, Fecha FROM elastosystem_compras_requisicion WHERE Estatus = 'ABIERTA'";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dt.Columns["ID_ALT"].ColumnName = "Folio";
                dt.Columns["Usuario"].ColumnName = "Solicitante";
                dgvRequisicions.DataSource = dt;
                dgvRequisicions.Columns["ID"].Visible = false;
                dt.DefaultView.Sort = "Folio DESC";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MandarALlamarPartidas()
        {
            try
            {
                string tabla = "SELECT ID_Producto, Descripcion, Cantidad, Unidad, Precio, Proveedor, TipoUso, Comentarios, Compra_Online, Cotizacion1, Ruta_Cotizacion1 FROM elastosystem_compras_requisicion_desglosada WHERE ID = '" + txbFolio.Text + "' AND Estatus = 'ABIERTA'";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    AlmacenarRequisicion();
                }
                else
                {
                    dgvPartidas.DataSource = dt;
                    dgvPartidas.Columns["ID_Producto"].Visible = false;
                    dgvPartidas.Columns["Cantidad"].Visible = false;
                    dgvPartidas.Columns["Unidad"].Visible = false;
                    dgvPartidas.Columns["Precio"].Visible = false;
                    dgvPartidas.Columns["Proveedor"].Visible = false;
                    dgvPartidas.Columns["TipoUso"].Visible = false;
                    dgvPartidas.Columns["Comentarios"].Visible = false;
                    dgvPartidas.Columns["Compra_Online"].Visible = false;
                    dgvPartidas.Columns["Cotizacion1"].Visible = false;
                    dgvPartidas.Columns["Ruta_Cotizacion1"].Visible = false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AlmacenarRequisicion()
        {
            try
            {
                string estatus = "CERRADA";
                MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                conn.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conn;
                comando.CommandText = "UPDATE elastosystem_compras_requisicion SET Estatus = @ESTATUS WHERE ID = @ID";
                comando.Parameters.AddWithValue("@ESTATUS", estatus);
                comando.Parameters.AddWithValue("@ID", txbFolio.Text);
                comando.ExecuteNonQuery();
                conn.Close();
                CargarRequisiciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ALMACENAR REQUISICION: " + ex.Message);
            }
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
        private void AgregarADgv()
        {
            if (string.IsNullOrEmpty(txbDescripcion.Text) || string.IsNullOrEmpty(txbCantidad.Text) || string.IsNullOrEmpty(txbUnidad.Text) || string.IsNullOrEmpty(txbPrecio.Text))
            {
                MessageBox.Show("DEBES DE LLENAR LOS CAMPOS OBLIGATORIOS");
                PartidasPBVisibles();
            }
            else
            {
                PartidasPBOculto();
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
                    string unidad = txbUnidad.Text;
                    string descripcion = txbDescripcion.Text + "\n" + "Requisicion: " + txbReqFolio.Text + ",    " + "Solicito: " + lblSolicito.Text + ",    " + "Uso: " + txbTipoUso.Text + "\n" + "Comentarios: " + txbNotas.Text;
                    string precio = txbPrecio.Text;
                    string req = txbReqFolio.Text;

                    int partida = dgvListaMateriales.Rows.Count + 1;

                    dgvListaMateriales.Rows.Add(partida, folio, cantidad, unidad, descripcion, precio, importe, req);
                    LimpiarAgregarPartidas();
                    dgvListaMateriales.Enabled = true;

                    Total();
                    AgregarALista();
                    MessageBox.Show("PRODUCTO AGREGADO");

                    pbTabla.Visible = false;
                    pbCorreo.Visible = false;
                    pbTelefono.Visible = false;
                    pbProveedor.Visible = false;
                    pbContacto.Visible = false;
                    lblCampos.Visible = false;
                    pbCampos.Visible = false;

                }
                else
                {
                    MessageBox.Show("REVISA TUS DATOS EN PRECIO O CANTIDAD, NO SON NUMEROS VALIDOS");
                }
            }
        }

        private void ExtraerValoresDescripcion(string descripcionlarga)
        {
            string antesDeRequisicion = "";
            string requisicion = "";
            string solicito = "";
            string uso = "";
            string comentarios = "";

            var regexAntesDeRequiscion = new Regex(@"^(.*?)(\r?\n|$)", RegexOptions.Singleline);
            var matchAntesDeRequiscion = regexAntesDeRequiscion.Match(descripcionlarga);
            if (matchAntesDeRequiscion.Success)
            {
                antesDeRequisicion = matchAntesDeRequiscion.Groups[1].Value.Trim();
            }

            txbDescripcion.Text = antesDeRequisicion;

            var regexRequisicion = new Regex(@"Requisicion:\s*(.*?),", RegexOptions.IgnoreCase);
            var matchRequisicion = regexRequisicion.Match(descripcionlarga);
            if (matchRequisicion.Success)
            {
                requisicion = matchRequisicion.Groups[1].Value.Trim();
            }

            txbReqFolio.Text = requisicion;

            var regexSolicito = new Regex(@"Solicito:\s*([^,]+)", RegexOptions.IgnoreCase);
            var matchSolicito = regexSolicito.Match(descripcionlarga);
            if (matchSolicito.Success)
            {
                solicito = matchSolicito.Groups[1].Value.Trim();
            }

            lblSolicito.Text = solicito;

            var regexUso = new Regex(@"Uso:\s*(.*?)\n", RegexOptions.IgnoreCase);
            var matchUso = regexUso.Match(descripcionlarga);
            if (matchUso.Success)
            {
                uso = matchUso.Groups[1].Value.Trim();
            }

            txbTipoUso.Text = uso;

            var regexComentarios = new Regex(@"Comentarios:\s*(.*)", RegexOptions.IgnoreCase);
            var matchComentarios = regexComentarios.Match(descripcionlarga);
            if (matchComentarios.Success)
            {
                comentarios = matchComentarios.Groups[1].Value.Trim();
            }

            txbNotas.Text = comentarios;

        }

        List<string> listFolios = new List<string>();
        List<string> listReqs = new List<string>();

        private void AgregarALista()
        {
            listFolios.Add(lblIDProducto.Text);
            listReqs.Add(txbReqFolio.Text);
        }


        private void LimpiarAgregarPartidas()
        {
            txbCantidad.Clear();
            txbUnidad.Clear();
            txbPrecio.Clear();
            txbDescripcion.Clear();
            txbProovedorRecomendado.Clear();
            txbTipoUso.Clear();
            txbNotas.Clear();
            btnCompraAutorizada.Visible = false;
            btnDescargarCotizacion.Visible = false;
        }

        private void PartidasPBVisibles()
        {
            lblCamposPartidas.Visible = true;
            pbCamposPartidas.Visible = true;
            pbCantidad.Visible = true;
            pbUnidad.Visible = true;
            pbPrecio.Visible = true;
            pbDescripcion.Visible = true;
        }

        private void PartidasPBOculto()
        {
            lblCamposPartidas.Visible = false;
            pbCamposPartidas.Visible = false;
            pbUnidad.Visible = false;
            pbPrecio.Visible = false;
            pbDescripcion.Visible = false;
            pbCantidad.Visible = false;
        }

        private void Total()
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
        private void MandarALlamarDatosProveedor()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            String nombre = cbProveedores.Text;
            MySqlDataReader reader = null;
            string sql = "SELECT ID, Contacto, Telefono, Email FROM elastosystem_compras_proveedores WHERE Nombre LIKE '" + nombre + "' ";
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txbIDProveedor.Text = reader.GetString("ID");
                        txbAtencion.Text = reader.GetString("Contacto");
                        txbTelefono.Text = reader.GetString("Telefono");
                        txbCorreo.Text = reader.GetString("Email");
                    }

                    txbProveedorC.Text = cbProveedores.Text;
                    txbContactoC.Text = txbAtencion.Text;
                    txbTelefonoC.Text = txbTelefono.Text;
                    txbCorreoC.Text = txbCorreo.Text;
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

        private void CompararDatosProveedor()
        {
            bool proveedorDiferente = !string.IsNullOrEmpty(txbProveedorC.Text) && cbProveedores.Text != txbProveedorC.Text;
            bool contactoDiferente = !string.IsNullOrEmpty(txbContactoC.Text) && txbAtencion.Text != txbContactoC.Text;
            bool telefonoDiferente = !string.IsNullOrEmpty(txbTelefonoC.Text) && txbTelefono.Text != txbTelefonoC.Text;
            bool correoDiferente = !string.IsNullOrEmpty(txbCorreoC.Text) && txbCorreo.Text != txbCorreoC.Text;
            if (proveedorDiferente || contactoDiferente || telefonoDiferente || correoDiferente)
            {
                btnNuevoProveedor.Visible = true;
                btnEditarProveedor.Visible = true;
            }
            else
            {
                btnNuevoProveedor.Visible = false;
                btnEditarProveedor.Visible = false;
            }

            if ((string.IsNullOrEmpty(txbProveedorC.Text) && !string.IsNullOrEmpty(cbProveedores.Text)) ||
                (string.IsNullOrEmpty(txbContactoC.Text) && !string.IsNullOrEmpty(txbAtencion.Text)) ||
                (string.IsNullOrEmpty(txbTelefonoC.Text) && !string.IsNullOrEmpty(txbTelefono.Text)) ||
                (string.IsNullOrEmpty(txbCorreoC.Text) && !string.IsNullOrEmpty(txbCorreo.Text)))
            {
                btnAgregarProveedor.Visible = true;
            }
            else
            {
                btnAgregarProveedor.Visible = false;
            }
        }

        private void Folio()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Folio FROM elastosystem_compras_oc";

            try
            {
                int ultimoFolio = 0;
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string folioString = reader["Folio"].ToString();
                        if (int.TryParse(folioString, out int folio))
                        {
                            ultimoFolio = folio;
                        }
                        else
                        {

                        }
                    }
                    ultimoFolio = ultimoFolio + 1;
                    lblFolio.Text = ultimoFolio.ToString();
                    lblFolioOC.Text = "OC-" + ultimoFolio.ToString();
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
        }
        private void LimpiarCampos()
        {
            lblFolio.Text = "";

            lblIDProducto.Text = "";
            txbCantidad.Clear();
            txbUnidad.Clear();
            txbPrecio.Clear();
            txbDescripcion.Clear();
            txbProovedorRecomendado.Clear();
            txbTipoUso.Clear();
            txbNotas.Clear();
            btnAlmacenar.Visible = false;
            chbCompraOnline.Checked = false;
            btnCompraAutorizada.Visible = false;

            cbProveedores.SelectedIndex = -1;
            txbAtencion.Clear();
            txbTelefono.Clear();
            txbCorreo.Clear();
            dgvListaMateriales.Rows.Clear();
            txbTotalLetra.Clear();
            txbSubtotal.Clear();
            txbIVA.Clear();
            txbTotal.Clear();
            chbIVA.Checked = true;

            cbRequisicion.SelectedIndex = -1;
            cbMoneda.SelectedIndex = -1;
            cbConfirmacionPedido.SelectedIndex = -1;
            cbCondicionPago.SelectedIndex = -1;
            txbTiempoEntrega.Clear();
            txbLugarEntrega.Text = "ELASTOTECNICA CARR. ANIMAS-COYOTEPEC KM. 4, COYOTEPEC, ESTADO DE MÉXICO";
            txbCotizacion.Clear();
            cbFormaPago.SelectedIndex = -1;
            chbCerSi.Checked = true;
        }

        private void Compras_Administrar_Requisiciones_Load(object sender, EventArgs e)
        {
            Folio();
            CargarRequisiciones();
            MandarALlamarProveedores();
            chbCerSi.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void dgvRequisicions_DoubleClick(object sender, EventArgs e)
        {
            LimpiarAgregarPartidas();
            dgvPartidas.DataSource = null;
            dgvPartidas.Rows.Clear();
            PartidasPBOculto();
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                txbFolio.Text = id;

                string req = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                txbReqFolio.Text = req;

                string solicito = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                lblSolicito.Text = solicito;

            }
            MandarALlamarPartidas();
        }

        private void dgvPartidas_DoubleClick(object sender, EventArgs e)
        {
            PartidasPBOculto();
            LimpiarAgregarPartidas();
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblIDProducto.Text = id;

                string descripcion = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                txbDescripcion.Text = descripcion;

                string cantidad = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                txbCantidad.Text = cantidad;

                string unidad = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                txbUnidad.Text = unidad;

                string precio = dgv.Rows[rowIndex].Cells[4].Value.ToString();
                txbPrecio.Text = precio;

                string proovedor = dgv.Rows[rowIndex].Cells[5].Value.ToString();
                txbProovedorRecomendado.Text = proovedor;

                string tipouso = dgv.Rows[rowIndex].Cells[6].Value.ToString();
                txbTipoUso.Text = tipouso;

                string comentarios = dgv.Rows[rowIndex].Cells[7].Value.ToString();
                txbNotas.Text = comentarios;

                bool compraonl = Convert.ToBoolean(dgv.Rows[rowIndex].Cells[8].Value);
                chbCompraOnline.Checked = compraonl;
                btnAlmacenar.Visible = compraonl;

                RevisarSiHayCotizacion();

            }

            RevisarBotonAlmacenar();
        }

        byte[] cotizacionBytes;
        private void RevisarSiHayCotizacion()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Cotizacion1, Ruta_Cotizacion1 FROM elastosystem_compras_requisicion_desglosada WHERE ID_Producto LIKE '" + lblIDProducto.Text + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            cotizacionBytes = (byte[])reader["Cotizacion1"];

                            if (cotizacionBytes != null && cotizacionBytes.Length > 0)
                            {
                                btnDescargarCotizacion.Visible = true;
                            }
                            else
                            {
                                btnDescargarCotizacion.Visible = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            btnDescargarCotizacion.Visible = false;
                        }
                        try
                        {
                            txbNombreCotizacion.Text = reader.GetString("Ruta_Cotizacion1");
                            string rutacompleta = txbNombreCotizacion.Text;
                            txbRutaCotizacion.Text = rutacompleta;
                            string nombrearchivo = System.IO.Path.GetFileName(rutacompleta);
                            txbNombreCotizacion.Text = nombrearchivo;
                        }
                        catch
                        {
                            txbNombreCotizacion.Text = string.Empty;
                            txbRutaCotizacion.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL PROCESAR COTIZACION: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void RevisarBotonAlmacenar()
        {
            btnCompraAutorizada.Visible = false;
            MandarALlamarNoUsuario();
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            try
            {
                string query = "SELECT Compras_AlmacenarREQ FROM elastosystem_permisos_menu WHERE ID = @ID";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@ID", lblNo.Text);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string almacenarValue = reader["Compras_AlmacenarREQ"].ToString();
                    if (almacenarValue == "True")
                    {
                        btnCompraAutorizada.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO AL REVISAR BOTON PARA ALMACENAR " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void MandarALlamarNoUsuario()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            string usuario = VariablesGlobales.Usuario;
            MySqlDataReader reader = null;
            string sql = "SELECT ID FROM elastosystem_login WHERE Usuario = '" + usuario + "'";
            try
            {
                HashSet<string> unicos = new HashSet<string>();
                MySqlCommand comando = new MySqlCommand(sql, conn);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lblNo.Text = reader.GetString(0);
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL OBTENER NUMERO DEL USUARIO" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AgregarADgv();
        }

        private void cbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAgregarProveedor.Visible = false;
            MandarALlamarDatosProveedor();
            CompararDatosProveedor();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cbProveedores.SelectedIndex >= 0 && dgvListaMateriales.RowCount > 0 && txbAtencion.Text.Length > 0 && txbTelefono.Text.Length > 0 && txbCorreo.Text.Length > 0)
            {
                lblCampos.Visible = false; pbCampos.Visible = false; pbProveedor.Visible = false; pbContacto.Visible = false; pbTelefono.Visible = false; pbCorreo.Visible = false; pbTabla.Visible = false;
                tabControl1.SelectedIndex = 2;
            }
            else
            {
                MessageBox.Show("LLENA TODOS LOS CAMPOS OBILGATORIOS");
                lblCampos.Visible = true;
                pbCampos.Visible = true;
                pbProveedor.Visible = true;
                pbContacto.Visible = true;
                pbTelefono.Visible = true;
                pbCorreo.Visible = true;
                pbTabla.Visible = true;
            }
        }

        private void btnAgregarPartidas_Click(object sender, EventArgs e)
        {
        }

        private void dgvListaMateriales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCerSi.Checked)
            {
                chbCerNo.Checked = false;
            }
        }

        private void chbCerNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCerNo.Checked)
            {
                chbCerSi.Checked = false;
            }
        }

        private void EnviarFolioOCAProductos()
        {
            try
            {
                string fecha = DateTime.Now.ToString("yyyy/MM/dd");
                string estatus = "CERRADA";
                MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                conn.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conn;
                comando.CommandText = "UPDATE elastosystem_compras_requisicion_desglosada SET Estatus = @ESTATUS, OC = @OC, FechaFinal = @FECHAFINAL WHERE ID_Producto = @ID";
                comando.Parameters.AddWithValue("@ESTATUS", estatus);
                comando.Parameters.AddWithValue("@OC", lblFolioOC.Text);
                comando.Parameters.AddWithValue("@FECHAFINAL", fecha);
                comando.Parameters.Add("@ID", MySqlDbType.VarChar);

                foreach (string idProducto in listFolios)
                {
                    comando.Parameters["@ID"].Value = idProducto;

                    comando.ExecuteNonQuery();
                }

                listFolios.Clear();



                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL DARLE FOLIO A LA LISTA: " + ex.Message);
            }
        }

        private void AlmacenarProducto()
        {
            try
            {
                string estatus = "CERRADA";
                string oc = "COMPRA ONLINE";
                string fecha = DateTime.Now.ToString("yyyy/MM/dd");
                MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                conn.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conn;
                comando.CommandText = "UPDATE elastosystem_compras_requisicion_desglosada SET FechaFinal = @FECHAFINAL, Estatus = @ESTATUS, OC = @OC WHERE ID_Producto = @ID";
                comando.Parameters.AddWithValue("@FECHAFINAL", fecha);
                comando.Parameters.AddWithValue("@ESTATUS", estatus);
                comando.Parameters.AddWithValue("@OC", oc);
                comando.Parameters.AddWithValue("@ID", lblIDProducto.Text);
                comando.ExecuteNonQuery();
                MessageBox.Show("PRODUCTO ALMACENADO CORRECTAMENTE");
                conn.Close();
                btnAlmacenar.Visible = false;
                chbCompraOnline.Checked = false;
                txbCantidad.Clear();
                txbUnidad.Clear();
                txbPrecio.Clear();
                txbDescripcion.Clear();
                txbProovedorRecomendado.Clear();
                txbTipoUso.Clear();
                txbNotas.Clear();
                lblIDProducto.Text = string.Empty;
                dgvPartidas.DataSource = null;
                dgvPartidas.Rows.Clear();
                CargarRequisiciones();
                btnCompraAutorizada.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ALMACENAR: " + ex.Message);
            }
        }

        private void TomarFolio()
        {
            DateTime fechaac = DateTime.Today;
            string fecha = fechaac.ToString("yyyy-MM-dd");
            bool cercal = false;
            if (chbCerSi.Checked)
            {
                cercal = true;
            }
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO elastosystem_compras_oc (Folio, Folio_ALT, Fecha, Proveedor, Contacto, Telefono, Correo, Subtotal, IVA, Total, RequisicionCompra, Moneda, ConfirmacionPedido, CondicionPago, TiempoEntrega, LugarEntrega, Cotizacion, FormaPago, CertificadoCalidad, Requisiciones) VALUES (@FOLIO, @FOLIO_ALT, @FECHA, @PROVEEDOR, @CONTACTO, @TELEFONO, @CORREO, @SUBTOTAL, @IVA, @TOTAL, @REQUISICIONCOMPRA, @MONEDA, @CONFIRMACIONPEDIDO, @CONDICIONPAGO, @TIEMPOENTREGA, @LUGARENTREGA, @COTIZACION, @FORMAPAGO, @CERTIFICADOCALIDAD, @REQUISICIONES);";
                cmd.Parameters.AddWithValue("@FOLIO", lblFolio.Text);
                cmd.Parameters.AddWithValue("@FOLIO_ALT", lblFolioOC.Text);
                cmd.Parameters.AddWithValue("@FECHA", fecha);
                cmd.Parameters.AddWithValue("@PROVEEDOR", cbProveedores.Text);
                cmd.Parameters.AddWithValue("@CONTACTO", txbAtencion.Text);
                cmd.Parameters.AddWithValue("@TELEFONO", txbTelefono.Text);
                cmd.Parameters.AddWithValue("@CORREO", txbCorreo.Text);
                cmd.Parameters.AddWithValue("@SUBTOTAL", txbSubtotal.Text);
                cmd.Parameters.AddWithValue("@IVA", txbIVA.Text);
                cmd.Parameters.AddWithValue("@TOTAL", txbTotal.Text);
                cmd.Parameters.AddWithValue("@REQUISICIONCOMPRA", cbRequisicion.Text);
                cmd.Parameters.AddWithValue("@MONEDA", cbMoneda.Text);
                cmd.Parameters.AddWithValue("@CONFIRMACIONPEDIDO", cbConfirmacionPedido.Text);
                cmd.Parameters.AddWithValue("@CONDICIONPAGO", cbCondicionPago.Text);
                cmd.Parameters.AddWithValue("@TIEMPOENTREGA", txbTiempoEntrega.Text);
                cmd.Parameters.AddWithValue("@LUGARENTREGA", txbLugarEntrega.Text);
                cmd.Parameters.AddWithValue("@COTIZACION", txbCotizacion.Text);
                cmd.Parameters.AddWithValue("@FORMAPAGO", cbFormaPago.Text);
                cmd.Parameters.AddWithValue("@CERTIFICADOCALIDAD", cercal);
                cmd.Parameters.AddWithValue("@REQUISICIONES", listaRequisiciones);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL GUARDAR FACTURA EN LA BASE DE DATOS: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        string listaRequisiciones = " ";

        private void ListaRequisiciones()
        {
            listReqs = listReqs.Distinct().ToList();
            listaRequisiciones = String.Join(", ", listReqs);
            listReqs.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (cbMoneda.SelectedIndex >= 0 && cbConfirmacionPedido.SelectedIndex >= 0 && cbCondicionPago.Text.Length >= 0 && txbTiempoEntrega.Text.Length > 0 && txbLugarEntrega.Text.Length > 0 && cbFormaPago.SelectedIndex >= 0 && cbRequisicion.SelectedIndex >= 0 && txbCotizacion.Text.Length > 0 && cbProveedores.Text.Length >= 0 && txbAtencion.Text.Length > 0 && txbTelefono.Text.Length > 0 && txbCorreo.Text.Length > 0)
            {
                lblCampos2.Visible = false;
                pbCampos2.Visible = false;
                pbMoneda.Visible = false;
                pbConfirmacion.Visible = false;
                pbCondicion.Visible = false;
                pbTiempo.Visible = false;
                pbLugar.Visible = false;
                pbForma.Visible = false;
                pbCalidad.Visible = false;
                pbRequi.Visible = false;
                pbCotizacion.Visible = false;

                pbCampos.Visible = false;
                lblCampos.Visible = false;
                pbProveedor.Visible = false;
                pbContacto.Visible = false;
                pbTelefono.Visible = false;
                pbCorreo.Visible = false;
                pbTabla.Visible = false;

                if (decimal.TryParse(txbTotal.Text, out decimal numero))
                {
                    if (cbMoneda.Text == "DOLARES")
                    {
                        string numeroEnLetras = VariablesGlobales.ConvertidorNumerosALetrasUSD.ConvertirNumeroALetras(numero);
                        txbTotalLetra.Text = numeroEnLetras;
                    }
                    else if (cbMoneda.Text == "EUROS")
                    {
                        string numeroEnLetras = VariablesGlobales.ConvertidorNumerosALetrasEuro.ConvertirNumeroALetras(numero);
                        txbTotalLetra.Text = numeroEnLetras;
                    }
                    else
                    {
                        string numeroEnLetras = VariablesGlobales.ConvertidorNumerosALetrasPESOS.ConvertirNumeroALetras(numero);
                        txbTotalLetra.Text = numeroEnLetras;
                    }
                }

                MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT COUNT(*) FROM elastosystem_compras_oc WHERE Folio = @Folio";
                    cmd.Parameters.AddWithValue("@Folio", lblFolio.Text);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        Folio();
                        btnGenerarOC.PerformClick();
                    }
                    else
                    {
                        string certificadodecalidad = " ";
                        if (chbCerSi.Checked)
                        {
                            certificadodecalidad = "SE REQUIERE CERTIFICADO DE CALIDAD";
                        }
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                        saveFileDialog.Title = "Guardar PDF";
                        saveFileDialog.FileName = lblFolioOC.Text + ".pdf";

                        ListaRequisiciones();

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (cbRequisicion.Text == "ELASTOTECNICA")
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

                                string oc = lblFolioOC.Text;
                                string ocyrequi = "\n \n \n \n \n \n" + "  " + oc + "\n \n" + "  " + listaRequisiciones;
                                iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(ocyrequi, font);
                                string empresa = cbProveedores.Text;
                                string atencion = txbAtencion.Text;
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
                                DateTime fechaActual = DateTime.Today;
                                string fechahoy = fechaActual.ToString("yyyy-MM-dd");
                                string barraconfirmacion = "CONFIRMACION DEL PEDIDO: " + confirmaciondelpedido + "               FECHA: " + fechahoy;
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
                                string cantidadletras = txbTotalLetra.Text;
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
                                string use = txbTipoUso.Text;
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

                                TomarFolio();

                                MessageBox.Show("PDF guardado como '" + System.IO.Path.GetFileName(rutaArchivoPDF) + "'", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (System.IO.File.Exists(rutaArchivoPDF))
                                {
                                    System.Diagnostics.Process.Start("explorer.exe", rutaArchivoPDF);
                                }
                                else
                                {
                                    MessageBox.Show("El archivo no se puede encontrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                EnviarFolioOCAProductos();
                                LimpiarCampos();
                                tabControl1.SelectedIndex = 0;
                                Folio();
                                CargarRequisiciones();
                                MandarALlamarProveedores();
                                dgvPartidas.DataSource = null;
                                dgvPartidas.Rows.Clear();

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

                                string oc = lblFolioOC.Text;
                                string ocyrequi = "\n \n";
                                iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(ocyrequi, fontand);
                                DateTime fech = DateTime.Now;
                                string fechaS = fech.ToString("yyyy-MM-dd");
                                string datosdelproveedor = "\n" + "ORDEN DE COMPRA: " + oc + "               FECHA: " + fechaS;
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
                                DateTime fechaActual = DateTime.Today;
                                string fechahoy = fechaActual.ToString("yyyy-MM-dd");
                                string barraconfirmacion = "CONFIRMACION DEL PEDIDO: " + confirmaciondelpedido + "               FECHA: " + fechahoy;
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
                                string cantidadletras = txbTotalLetra.Text;
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
                                string use = txbTipoUso.Text;
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

                                TomarFolio();

                                MessageBox.Show("PDF guardado como '" + System.IO.Path.GetFileName(rutaArchivoPDF) + "'", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (System.IO.File.Exists(rutaArchivoPDF))
                                {
                                    System.Diagnostics.Process.Start("explorer.exe", rutaArchivoPDF);
                                }
                                else
                                {
                                    MessageBox.Show("El archivo no se puede encontrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                EnviarFolioOCAProductos();
                                LimpiarCampos();
                                tabControl1.SelectedIndex = 0;
                                Folio();
                                CargarRequisiciones();
                                MandarALlamarProveedores();
                                dgvPartidas.DataSource = null;
                                dgvPartidas.Rows.Clear();

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

                                DateTime fechaActual = DateTime.Today;
                                string fechahoy = fechaActual.ToString("yyyy-MM-dd");
                                string oc = lblFolioOC.Text;
                                string ocyrequi = "\n \n \n \n \n \n" + "  " + oc + "\n \n" + "  " + listaRequisiciones;
                                iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(ocyrequi, font);
                                string empresa = cbProveedores.Text;
                                string atencion = txbAtencion.Text;
                                string telefono = txbTelefono.Text;
                                string correo = txbCorreo.Text;
                                string datosdelproveedor = empresa + "\n " + atencion + "\n " + telefono + "\n " + correo;
                                string datos = "Orden de compra:         " + oc + "                                                                    FECHA: " + fechahoy + "\n" + "Numero de cotización:   " + txbCotizacion.Text + "\n \n" + "Datos del proveedor:" + "\n" + empresa + "\n" + atencion + "\n" + telefono + "\n" + correo;
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
                                string cantidadletras = txbTotalLetra.Text;
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
                                string use = txbTipoUso.Text;
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

                                TomarFolio();

                                MessageBox.Show("PDF guardado como '" + System.IO.Path.GetFileName(rutaArchivoPDF) + "'", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (System.IO.File.Exists(rutaArchivoPDF))
                                {
                                    System.Diagnostics.Process.Start("explorer.exe", rutaArchivoPDF);
                                }
                                else
                                {
                                    MessageBox.Show("El archivo no se puede encontrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                EnviarFolioOCAProductos();
                                LimpiarCampos();
                                tabControl1.SelectedIndex = 0;
                                Folio();
                                CargarRequisiciones();
                                MandarALlamarProveedores();
                                dgvPartidas.DataSource = null;
                                dgvPartidas.Rows.Clear();
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar Folios: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("DEBES DE LLENAR LOS CAMPOS OBLIGATORIOS");
                if (string.IsNullOrEmpty(txbAtencion.Text) || string.IsNullOrEmpty(txbTelefono.Text) || string.IsNullOrEmpty(txbCorreo.Text) || string.IsNullOrEmpty(cbProveedores.Text))
                {
                    tabControl1.SelectedIndex = 1;
                    pbProveedor.Visible = true;
                    pbContacto.Visible = true;
                    pbTelefono.Visible = true;
                    pbCorreo.Visible = true;
                    pbCampos.Visible = true;
                    lblCampos.Visible = true;
                }
                else
                {
                    pbCampos2.Visible = true;
                    lblCampos2.Visible = true;
                    pbMoneda.Visible = true;
                    pbConfirmacion.Visible = true;
                    pbCondicion.Visible = true;
                    pbTiempo.Visible = true;
                    pbLugar.Visible = true;
                    pbForma.Visible = true;
                    pbCotizacion.Visible = true;
                    pbRequi.Visible = true;
                    pbCalidad.Visible = true;
                }
            }
        }

        private void txbTotal_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chbIVA.Checked)
            {
                double subt;
                subt = double.Parse(txbTotal.Text);
                double ivaa = 0;
                double totall = 0;
                ivaa = subt * 0.16;
                totall = subt + ivaa;
                txbIVA.Text = ivaa.ToString();
                txbTotal.Text = totall.ToString();

            }
            else
            {
                string sub = txbSubtotal.Text;
                txbIVA.Text = null;
                txbTotal.Text = sub;
            }
        }

        private void dgvListaMateriales_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                lblIDProducto.Text = id;

                string cantidad = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                txbCantidad.Text = cantidad;

                string unidad = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                txbUnidad.Text = unidad;

                string descripcion = dgv.Rows[rowIndex].Cells[4].Value.ToString();
                //txbDescripcion.Text = descripcion;
                ExtraerValoresDescripcion(descripcion);

                string precio = dgv.Rows[rowIndex].Cells[5].Value.ToString();
                txbPrecio.Text = precio;

                EliminarDeCantidades();
                RevisarSiHayCotizacion();
            }
        }

        private void EliminarDeCantidades()
        {
            foreach (DataGridViewRow row in dgvListaMateriales.SelectedRows)
            {
                dgvListaMateriales.Rows.Remove(row);
            }
            RenumerarPartidas();
            Total();
            EliminarDeLista();
            tabControl1.SelectedIndex = 0;
        }

        private void RenumerarPartidas()
        {
            for (int i = 0; i < dgvListaMateriales.Rows.Count; i++)
            {
                dgvListaMateriales.Rows[i].Cells["Partida"].Value = i + 1;
            }
        }

        private void EliminarDeLista()
        {
            listFolios.Remove(lblIDProducto.Text);
        }

        private void cbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            AgregarProveedor();
        }

        private void AgregarProveedor()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                conn.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conn;
                if (string.IsNullOrEmpty(txbAtencion.Text) || string.IsNullOrEmpty(txbTelefono.Text) || string.IsNullOrEmpty(txbCorreo.Text) || string.IsNullOrEmpty(cbProveedores.Text))
                {
                    MessageBox.Show("Favor de ingresar todos los datos obligatorios");
                    pbCampos.Visible = true;
                    lblCampos.Visible = true;
                    pbProveedor.Visible = true;
                    pbContacto.Visible = true;
                    pbTelefono.Visible = true;
                    pbCorreo.Visible = true;
                }
                else
                {
                    comando.CommandText = "INSERT INTO elastosystem_compras_proveedores (Nombre, Contacto, Telefono, Email) VALUES (@NOMBRE, @CONTACTO, @TELEFONO, @CORREO)";
                    comando.Parameters.AddWithValue("@NOMBRE", cbProveedores.Text);
                    comando.Parameters.AddWithValue("@CONTACTO", txbAtencion.Text);
                    comando.Parameters.AddWithValue("@TELEFONO", txbTelefono.Text);
                    comando.Parameters.AddWithValue("@CORREO", txbCorreo.Text);
                    comando.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("PROVEEDOR AGREGADO CON EXITO");
                    MandarALlamarProveedores();
                    pbCampos.Visible = false;
                    lblCampos.Visible = false;
                    pbProveedor.Visible = false;
                    pbContacto.Visible = false;
                    pbTelefono.Visible = false;
                    pbCorreo.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL AGREGAR PROVEEDOR: " + ex.Message);
            }
        }

        private void txbAtencion_TextChanged(object sender, EventArgs e)
        {
            CompararDatosProveedor();
        }

        private void txbTelefono_TextChanged(object sender, EventArgs e)
        {
            CompararDatosProveedor();
        }

        private void txbCorreo_TextChanged(object sender, EventArgs e)
        {
            CompararDatosProveedor();
        }

        private void cbProveedores_TextChanged(object sender, EventArgs e)
        {
            CompararDatosProveedor();
        }

        private void btnEditarProveedor_Click(object sender, EventArgs e)
        {
            EditarProveedor();
        }

        private void EditarProveedor()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                conn.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conn;
                if (string.IsNullOrEmpty(txbAtencion.Text) || string.IsNullOrEmpty(txbTelefono.Text) || string.IsNullOrEmpty(txbCorreo.Text) || string.IsNullOrEmpty(cbProveedores.Text))
                {
                    MessageBox.Show("Favor de ingresar todos los datos obligatorios");
                    pbCampos.Visible = true;
                    lblCampos.Visible = true;
                    pbProveedor.Visible = true;
                    pbContacto.Visible = true;
                    pbTelefono.Visible = true;
                    pbCorreo.Visible = true;
                }
                else
                {
                    comando.CommandText = "UPDATE elastosystem_compras_proveedores SET Nombre = @NOMBRE, Contacto = @CONTACTO, Telefono = @TELEFONO, Email = @CORREO WHERE ID = @ID";
                    comando.Parameters.AddWithValue("@ID", txbIDProveedor.Text);
                    comando.Parameters.AddWithValue("@NOMBRE", cbProveedores.Text);
                    comando.Parameters.AddWithValue("@CONTACTO", txbAtencion.Text);
                    comando.Parameters.AddWithValue("@TELEFONO", txbTelefono.Text);
                    comando.Parameters.AddWithValue("@CORREO", txbCorreo.Text);
                    comando.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Proveedor actualizado");
                    MandarALlamarProveedores();
                    txbProveedorC.Text = cbProveedores.Text;
                    txbContactoC.Text = txbAtencion.Text;
                    txbTelefonoC.Text = txbTelefono.Text;
                    txbCorreoC.Text = txbCorreo.Text;
                    CompararDatosProveedor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ACTUALIZAR DATOS: " + ex.Message);
            }
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            cbProveedores.Text = " ";
            txbProveedorC.Clear();
            txbAtencion.Clear();
            txbContactoC.Clear();
            txbTelefono.Clear();
            txbTelefonoC.Clear();
            txbCorreo.Clear();
            txbCorreoC.Clear();
            txbIDProveedor.Clear();
            btnNuevoProveedor.Visible = false;
            btnEditarProveedor.Visible = false;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

        }

        private void btnAlmacenar_Click(object sender, EventArgs e)
        {
            AlmacenarProducto();
        }

        private void btnCompraAutorizada_Click(object sender, EventArgs e)
        {
            pnlComprobante.Visible = true;
        }

        private void CompraFinalizadaAutorizada()
        {
            try
            {
                string estatus = "CERRADA";
                string ruta_archivo = lblRutaArchivo.Text.Replace("\\", "\\\\");
                string oc = "COMPRA AUTORIZADA POR: " + VariablesGlobales.Usuario;
                string fecha = DateTime.Now.ToString("yyyy/MM/dd");
                MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                conn.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conn;
                comando.CommandText = "UPDATE elastosystem_compras_requisicion_desglosada SET FechaFinal = @FECHAFINAL, Estatus = @ESTATUS, OC = @OC, Ruta_Comprobante = @RUTACOMPROBANTE, Comprobante = @COMPROBANTE, Autorizo = @AUTORIZO, Motivo = @MOTIVO WHERE ID_Producto = @ID";
                comando.Parameters.AddWithValue("@FECHAFINAL", fecha);
                comando.Parameters.AddWithValue("@ESTATUS", estatus);
                comando.Parameters.AddWithValue("@OC", oc);
                comando.Parameters.AddWithValue("@ID", lblIDProducto.Text);
                comando.Parameters.AddWithValue("@RUTACOMPROBANTE", ruta_archivo);
                comando.Parameters.AddWithValue("COMPROBANTE", archivoBytes);
                comando.Parameters.AddWithValue("@AUTORIZO", VariablesGlobales.Usuario);
                comando.Parameters.AddWithValue("@MOTIVO", txbMotivo.Text);
                comando.ExecuteNonQuery();
                MessageBox.Show("PRODUCTO FINALIZADO CORRECTAMENTE");
                conn.Close();
                btnCerrar.PerformClick();
                btnAlmacenar.Visible = false;
                chbCompraOnline.Checked = false;
                txbCantidad.Clear();
                txbUnidad.Clear();
                txbPrecio.Clear();
                txbDescripcion.Clear();
                txbProovedorRecomendado.Clear();
                txbTipoUso.Clear();
                txbNotas.Clear();
                lblIDProducto.Text = string.Empty;
                dgvPartidas.DataSource = null;
                dgvPartidas.Rows.Clear();
                CargarRequisiciones();
                btnCompraAutorizada.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ALMACENAR PRODUCTO: " + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            pnlComprobante.Visible = false;
            LimpiarPanelComprobante();
        }

        private void LimpiarPanelComprobante()
        {
            pbComprobante.Image = null;
            txbNombreArchivo.Clear();
            lblRutaArchivo.Text = string.Empty;
        }

        private void btnCargarDoc_Click(object sender, EventArgs e)
        {
            CargarDocumento();
        }

        private byte[] archivoBytes;
        private void CargarDocumento()
        {
            OpenFileDialog file = new OpenFileDialog();

            file.Filter = "Todos los archivos (*.*)|*.*";
            file.Title = "Seleccionar Archivo";

            if (file.ShowDialog() == DialogResult.OK)
            {
                string filePath = file.FileName;

                string fileName = System.IO.Path.GetFileName(filePath);

                txbNombreArchivo.Text = fileName;
                lblRutaArchivo.Text = filePath;
                pbComprobante.Image = null;

                try
                {
                    archivoBytes = File.ReadAllBytes(filePath);

                    if (EsImagen(filePath))
                    {
                        pbComprobante.Image = System.Drawing.Image.FromFile(filePath);
                    }
                    else
                    {
                        pbComprobante.Image = null;
                        MessageBox.Show("ARCHIVO CARGADO CORRECTAMENTE");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR EL ARCHIVO: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("NO SE SELECCIONO NINGUN ARCHIVO");
            }
        }

        private bool EsImagen(string filePath)
        {
            string extension = System.IO.Path.GetExtension(filePath).ToLower();

            string[] extensionesImagen = { ".png", ".jpg", ".jpeg", ".gif", ".bmp" };

            return extensionesImagen.Contains(extension);
        }

        private void btnFinalizarReq_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombreArchivo.Text) || string.IsNullOrEmpty(txbMotivo.Text))
            {
                MessageBox.Show("Necesitas cargar un comprobante para finalizar o agregar motivo");
            }
            else
            {
                CompraFinalizadaAutorizada();
            }
        }

        private void btnDescargarCotizacion_Click(object sender, EventArgs e)
        {
            DescargarCotizacion();
        }

        private void DescargarCotizacion()
        {
            if (cotizacionBytes != null && cotizacionBytes.Length > 0)
            {
                string extensionArchivo = System.IO.Path.GetExtension(txbRutaCotizacion.Text);
                string nombreArchivo = txbNombreCotizacion.Text;

                SaveFileDialog file = new SaveFileDialog()
                {
                    FileName = nombreArchivo,
                    Filter = "Todos los archivos (*.*)|*.*",
                    DefaultExt = extensionArchivo
                };

                if (file.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllBytes(file.FileName, cotizacionBytes);
                        MessageBox.Show("ARCHIVO GUARDADO CORRECTAMENTE");
                        string argument = "/select, \"" + file.FileName + "\"";
                        System.Diagnostics.Process.Start("explorer.exe", argument);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR AL GUARDAR EL ARCHIVO: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay archivo valido para descargar.");
            }
        }

        private void dgvRequisicions_Click(object sender, EventArgs e)
        {
            LimpiarAgregarPartidas();
            dgvPartidas.DataSource = null;
            dgvPartidas.Rows.Clear();
            PartidasPBOculto();
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                txbFolio.Text = id;

                string req = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                txbReqFolio.Text = req;

                string solicito = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                lblSolicito.Text = solicito;

            }
            MandarALlamarPartidas();
        }

        private void dgvPartidas_Click(object sender, EventArgs e)
        {
            PartidasPBOculto();
            LimpiarAgregarPartidas();
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblIDProducto.Text = id;

                string descripcion = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                txbDescripcion.Text = descripcion;

                string cantidad = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                txbCantidad.Text = cantidad;

                string unidad = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                txbUnidad.Text = unidad;

                string precio = dgv.Rows[rowIndex].Cells[4].Value.ToString();
                txbPrecio.Text = precio;

                string proovedor = dgv.Rows[rowIndex].Cells[5].Value.ToString();
                txbProovedorRecomendado.Text = proovedor;

                string tipouso = dgv.Rows[rowIndex].Cells[6].Value.ToString();
                txbTipoUso.Text = tipouso;

                string comentarios = dgv.Rows[rowIndex].Cells[7].Value.ToString();
                txbNotas.Text = comentarios;

                bool compraonl = Convert.ToBoolean(dgv.Rows[rowIndex].Cells[8].Value);
                chbCompraOnline.Checked = compraonl;
                btnAlmacenar.Visible = compraonl;

                RevisarSiHayCotizacion();

            }

            RevisarBotonAlmacenar();
        }
    }
}
