using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElastoSystem
{
    public partial class Compras_RequisicionesEnviadas : Form
    {
        public Compras_RequisicionesEnviadas()
        {
            InitializeComponent();
        }
        private void CargarRequisicionesPendientes()
        {
            try
            {
                string tabla = $"SELECT ID, ID_ALT, Usuario, Fecha, Estatus FROM elastosystem_compras_requisicion WHERE Usuario = '{VariablesGlobales.Usuario}'";
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

        private void CargarRequisicionesPendientesFULL()
        {
            try
            {
                string tabla = $"SELECT ID, ID_ALT, Usuario, Fecha, Estatus FROM elastosystem_compras_requisicion";
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
                string tabla = "SELECT * FROM elastosystem_compras_requisicion_desglosada WHERE ID = '" + lblFolio.Text + "'";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dt.Columns["TipoUso"].ColumnName = "Tipo Uso";
                dgvPartidas.DataSource = dt;
                dgvPartidas.Columns["ID"].Visible = false;
                dgvPartidas.Columns["Tipo Uso"].Visible = false;
                dgvPartidas.Columns["Comentarios"].Visible = false;
                dgvPartidas.Columns["ID_Producto"].Visible = false;
                dgvPartidas.Columns["OC"].Visible = false;
                dgvPartidas.Columns["FechaInicio"].Visible = false;
                dgvPartidas.Columns["FechaFinal"].Visible = false;
                dgvPartidas.Columns["Compra_Online"].Visible = false;
                dgvPartidas.Columns["Ruta_Comprobante"].Visible = false;
                dgvPartidas.Columns["Comprobante"].Visible = false;
                dgvPartidas.Columns["Autorizo"].Visible = false;
                dgvPartidas.Columns["Motivo"].Visible = false;
                dgvPartidas.Columns["Cotizacion1"].Visible = false;
                dgvPartidas.Columns["Ruta_Cotizacion1"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Compras_RequisicionesEnviadas_Load(object sender, EventArgs e)
        {
            CargarID();
        }

        string idusuario;
        private void CargarID()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            try
            {
                string query = "SELECT ID FROM elastosystem_login WHERE Usuario = @USUARIO";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@USUARIO", VariablesGlobales.Usuario);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    idusuario = reader["ID"].ToString();
                }

                RevisarUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL LLAMAR ID DE USUARIO: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void RevisarUsuario()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            try
            {
                string query = "SELECT Compras_VG FROM elastosystem_permisos_menu WHERE ID = @ID";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@ID", idusuario);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string comprasVGValue = reader["Compras_VG"].ToString();
                    if (comprasVGValue == "True")
                    {
                        CargarRequisicionesPendientesFULL();
                    }
                    else
                    {
                        CargarRequisicionesPendientes();
                        txbBuscadorGeneral.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL LLAMAR PENDIENTES: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void dgvRequisicions_DoubleClick(object sender, EventArgs e)
        {
            txbTipoUso.Clear();
            txbNotas.Clear();
            lblFolio.Text = "";
            lblFolioREQ.Text = "";
            lblFechaInicio.Text = "-------------";
            lblFechaFinal.Text = "-------------";
            lblEstatus.Text = "-------------";
            lblOC.Visible = false;
            lblOCResultado.Text = "-------------";
            txbComprobante.Clear();
            lblOCResultado.Visible = false;
            btnDescargarComprobante.Visible = false;
            btnDescargarCotizacion.Visible = false;
            txbRutCot.Clear();


            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblFolio.Text = id;

                string folio = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                lblFolioREQ.Text = folio;
                lblFolioREQ.Visible = true;
            }
            MandarALlamarPartidas();
        }

        private void dgvPartidas_Click(object sender, EventArgs e)
        {
            lblEstatus.Text = "-------------";
            lblFechaInicio.Text = "-------------";
            lblFechaFinal.Text = "-------------";
            lblOC.Visible = false;
            lblOCResultado.Visible = false;
            lblOCResultado.Text = "-------------";
            txbComprobante.Clear();
            btnDescargarComprobante.Visible = false;
            txbTipoUso.Clear();
            txbNotas.Clear();

            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string idproducto = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblIDProducto.Text = idproducto;

                string tipouso = dgv.Rows[rowIndex].Cells[7].Value.ToString();
                txbTipoUso.Text = tipouso;

                string comentarios = dgv.Rows[rowIndex].Cells[8].Value.ToString();
                txbNotas.Text = comentarios;

                string estatus = dgv.Rows[rowIndex].Cells[9].Value.ToString();
                lblEstatus.Text = estatus;

                string fechainicio = Convert.ToDateTime(dgv.Rows[rowIndex].Cells[12].Value).ToString("yyyy-MM-dd");
                lblFechaInicio.Text = fechainicio;

                if (estatus == "CERRADA")
                {
                    lblOC.Visible = true;
                    lblOCResultado.Visible = true;
                    string oc = dgv.Rows[rowIndex].Cells[10].Value.ToString();
                    lblOCResultado.Text = oc;

                    string fechafinal = Convert.ToDateTime(dgv.Rows[rowIndex].Cells[13].Value).ToString("yyyy-MM-dd");
                    lblFechaFinal.Text = fechafinal;

                    string comprobante = dgv.Rows[rowIndex].Cells[14].Value.ToString();
                    txbComprobante.Text = comprobante;

                    if (string.IsNullOrEmpty(txbComprobante.Text))
                    {

                    }
                    else
                    {
                        btnDescargarComprobante.Visible = true;
                        MandarALlamarComprobante();
                    }
                }

                string cotizacion = dgv.Rows[rowIndex].Cells[19].Value.ToString();
                txbRutCot.Text = cotizacion;

                if (string.IsNullOrEmpty(txbRutCot.Text))
                {
                    btnDescargarCotizacion.Visible = false;
                }
                else
                {
                    btnDescargarCotizacion.Visible = true;
                    MandarALlamarCotizacion();
                }
            }
        }

        private void dgvRequisicions_Click(object sender, EventArgs e)
        {
            txbTipoUso.Clear();
            txbNotas.Clear();
            lblFolio.Text = "";
            lblFolioREQ.Text = "";
            lblFechaInicio.Text = "-------------";
            lblFechaFinal.Text = "-------------";
            lblEstatus.Text = "-------------";
            lblOC.Visible = false;
            lblOCResultado.Text = "-------------";
            txbComprobante.Clear();
            lblOCResultado.Visible = false;
            btnDescargarComprobante.Visible = false;
            btnDescargarCotizacion.Visible = false;
            txbRutCot.Clear();

            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblFolio.Text = id;

                string folio = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                lblFolioREQ.Text = folio;
                lblFolioREQ.Visible = true;
            }
            MandarALlamarPartidas();
        }

        private void dgvRequisicions_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void cbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvPartidas_DoubleClick(object sender, EventArgs e)
        {
            lblEstatus.Text = "-------------";
            lblFechaInicio.Text = "-------------";
            lblFechaFinal.Text = "-------------";
            lblOC.Visible = false;
            lblOCResultado.Visible = false;
            lblOCResultado.Text = "-------------";
            txbComprobante.Clear();
            btnDescargarComprobante.Visible = false;
            txbTipoUso.Clear();
            txbNotas.Clear();

            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string idproducto = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblIDProducto.Text = idproducto;

                string tipouso = dgv.Rows[rowIndex].Cells[7].Value.ToString();
                txbTipoUso.Text = tipouso;

                string comentarios = dgv.Rows[rowIndex].Cells[8].Value.ToString();
                txbNotas.Text = comentarios;

                string estatus = dgv.Rows[rowIndex].Cells[9].Value.ToString();
                lblEstatus.Text = estatus;

                string fechainicio = Convert.ToDateTime(dgv.Rows[rowIndex].Cells[12].Value).ToString("yyyy-MM-dd");
                lblFechaInicio.Text = fechainicio;

                if (estatus == "CERRADA")
                {
                    lblOC.Visible = true;
                    lblOCResultado.Visible = true;
                    string oc = dgv.Rows[rowIndex].Cells[10].Value.ToString();
                    lblOCResultado.Text = oc;

                    string fechafinal = Convert.ToDateTime(dgv.Rows[rowIndex].Cells[13].Value).ToString("yyyy-MM-dd");
                    lblFechaFinal.Text = fechafinal;

                    string comprobante = dgv.Rows[rowIndex].Cells[14].Value.ToString();
                    txbComprobante.Text = comprobante;

                    if (string.IsNullOrEmpty(txbComprobante.Text))
                    {

                    }
                    else
                    {
                        btnDescargarComprobante.Visible = true;
                        MandarALlamarComprobante();
                    }
                }

                string cotizacion = dgv.Rows[rowIndex].Cells[19].Value.ToString();
                txbRutCot.Text = cotizacion;

                if (string.IsNullOrEmpty(txbRutCot.Text))
                {
                    btnDescargarCotizacion.Visible = false;
                }
                else
                {
                    btnDescargarCotizacion.Visible = true;
                    MandarALlamarCotizacion();
                }
            }
        }

        byte[] comprobanteBytes;
        private void MandarALlamarComprobante()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Comprobante, Ruta_Comprobante FROM elastosystem_compras_requisicion_desglosada WHERE ID_PRODUCTO LIKE '" + lblIDProducto.Text + "'";
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
                            comprobanteBytes = (byte[])reader["Comprobante"];
                            txbNombreArchivo.Text = reader.GetString("Ruta_Comprobante");
                            string rutacompleta = txbNombreArchivo.Text;
                            txbRuta.Text = rutacompleta;
                            string nombrearchivo = Path.GetFileName(rutacompleta);
                            txbNombreArchivo.Text = nombrearchivo;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR AL ASIGNAR NOMBRE Y RUTA: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL LLAMAR COMPROBANTE: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        byte[] cotizacionBytes;
        private void MandarALlamarCotizacion()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Cotizacion1, Ruta_Cotizacion1 FROM elastosystem_compras_requisicion_desglosada WHERE ID_PRODUCTO LIKE '" + lblIDProducto.Text + "'";
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
                            txbNombreCotizacion.Text = reader.GetString("Ruta_Cotizacion1");
                            string rutacompleta = txbNombreCotizacion.Text;
                            txbRutaCotizacion.Text = rutacompleta;
                            string nombrearchivo = Path.GetFileName(rutacompleta);
                            txbNombreCotizacion.Text = nombrearchivo;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR AL ASIGNAR NOMBRE Y RUTA DE COTIZACION: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL LLAMAR COTIZACIÓN: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void Buscador()
        {
            try
            {

                string valorBusqueda = txbBuscador.Text.Trim();
                string consulta;

                if (string.IsNullOrEmpty(valorBusqueda))
                {
                    consulta = $"SELECT ID, ID_ALT, Usuario, Fecha, Estatus FROM elastosystem_compras_requisicion WHERE Usuario = '{VariablesGlobales.Usuario}'";
                }
                else
                {
                    consulta = $"SELECT ID, ID_ALT, Usuario, Fecha, Estatus FROM elastosystem_compras_requisicion WHERE (ID LIKE @ValorBusqueda OR ID_ALT LIKE @ValorBusqueda) AND Usuario = '{VariablesGlobales.Usuario}'";
                }

                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, VariablesGlobales.ConexionBDElastotecnica);

                if (!string.IsNullOrEmpty(valorBusqueda))
                {
                    adaptador.SelectCommand.Parameters.AddWithValue("@ValorBusqueda", "%" + valorBusqueda + "%");
                }

                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                dt.Columns["ID_ALT"].ColumnName = "Folio";
                dt.Columns["Usuario"].ColumnName = "Solicitante";

                dgvRequisicions.DataSource = dt;

                dgvRequisicions.Columns["ID"].Visible = false;

                dt.DefaultView.Sort = "Folio DESC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar datos: " + ex.Message);
            }
        }

        private void BuscadorGeneral()
        {
            try
            {
                string valorBusqueda = txbBuscadorGeneral.Text.Trim();
                string consulta;

                if (string.IsNullOrEmpty(valorBusqueda))
                {
                    consulta = $"SELECT ID, ID_ALT, Usuario, Fecha, Estatus FROM elastosystem_compras_requisicion";
                }
                else
                {
                    consulta = $"SELECT ID, ID_ALT, Usuario, Fecha, Estatus FROM elastosystem_compras_requisicion WHERE (ID LIKE @ValorBusqueda OR ID_ALT LIKE @ValorBusqueda OR Usuario LIKE @ValorBusqueda)";
                }

                MySqlDataAdapter adapatador = new MySqlDataAdapter(consulta, VariablesGlobales.ConexionBDElastotecnica);

                if (!string.IsNullOrEmpty(valorBusqueda))
                {
                    adapatador.SelectCommand.Parameters.AddWithValue("@ValorBusqueda", "%" + valorBusqueda + "%");
                }

                DataTable dt = new DataTable();
                adapatador.Fill(dt);

                dt.Columns["ID_ALT"].ColumnName = "Folio";
                dt.Columns["Usuario"].ColumnName = "Solicitante";

                dgvRequisicions.DataSource = dt;

                dgvRequisicions.Columns["ID"].Visible = false;

                dt.DefaultView.Sort = "Folio DESC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL BUSCAR DATOS: " + ex.Message);
            }
        }

        private void txbBuscador_TextChanged(object sender, EventArgs e)
        {
            Buscador();
        }

        private void btnDescargarComprobante_Click(object sender, EventArgs e)
        {
            DescargarComprobante();
        }

        private void DescargarComprobante()
        {
            string extensionArchivo = Path.GetExtension(txbRuta.Text);
            string nombreArchivo = txbNombreArchivo.Text;

            SaveFileDialog save = new SaveFileDialog
            {
                FileName = nombreArchivo,
                Filter = "Todos los archivos (*.*)|*.*",
                DefaultExt = extensionArchivo
            };

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllBytes(save.FileName, comprobanteBytes);
                    MessageBox.Show("Archivo guardado correctamente.");
                    string argument = "/select, \"" + save.FileName + "\"";
                    System.Diagnostics.Process.Start("explorer.exe", argument);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL GUARDAR EL ARCHIVO: " + ex.Message);
                }
            }
        }

        private void btnDescargarCotizacion_Click(object sender, EventArgs e)
        {
            DescargarCotizacion();
        }

        private void DescargarCotizacion()
        {
            string extensionCotizacion = Path.GetExtension(txbRutaCotizacion.Text);
            string nombreCotizacion = txbNombreCotizacion.Text;

            SaveFileDialog file = new SaveFileDialog
            {
                FileName = nombreCotizacion,
                Filter = "Todos los archivos (*.*)|*.*",
                DefaultExt = extensionCotizacion
            };

            if (file.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllBytes(file.FileName, cotizacionBytes);
                    MessageBox.Show("Archivo guardado correctamente.");
                    string argument = "/select, \"" + file.FileName + "\"";
                    System.Diagnostics.Process.Start("explorer.exe", argument);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL GUARDAR LA COTIZACIÓN: " + ex.Message);
                }
            }
        }

        private void txbBuscadorGeneral_TextChanged(object sender, EventArgs e)
        {
            BuscadorGeneral();
        }
    }
}
