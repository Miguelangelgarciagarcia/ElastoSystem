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
    public partial class Mantenimiento_Pendientes : Form
    {
        public Mantenimiento_Pendientes()
        {
            InitializeComponent();
        }

        private void Mantenimiento_Pendientes_Load(object sender, EventArgs e)
        {
            PendientesMtto();
        }

        private void PendientesMtto()
        {
            string tabla = @"
                SELECT * 
                FROM elastosystem_mtto_req 
                WHERE Estatus = 'ACTIVA'
                ORDER BY Fecha ASC,
                CASE Prioridad
                    WHEN 'CRITICA' THEN 1
                    WHEN 'ALTA' THEN 2
                    WHEN 'MEDIA' THEN 3
                    WHEN 'BAJA' THEN 4
                    ELSE 5
                END ASC";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dgvPendientesMtto.DataSource = dt;

            dgvPendientesMtto.Columns["Folio"].Visible = false;
            dgvPendientesMtto.Columns["Mantenimiento"].Visible = false;
            dgvPendientesMtto.Columns["Ubicacion"].Visible = false;
            dgvPendientesMtto.Columns["Maquina"].Visible = false;
            dgvPendientesMtto.Columns["Descripcion"].Visible = false;
            dgvPendientesMtto.Columns["Recomendaciones_Sugerencias"].Visible = false;
            dgvPendientesMtto.Columns["Refacciones"].Visible = false;
            dgvPendientesMtto.Columns["Estatus"].Visible = false;
            dgvPendientesMtto.Columns["Fecha_Termino"].Visible = false;
            dgvPendientesMtto.Columns["Ruta_Comprobante"].Visible = false;
            dgvPendientesMtto.Columns["Comprobante"].Visible = false;
            dgvPendientesMtto.Columns["Usuario_Finalizo"].Visible = false;
            dgvPendientesMtto.Columns["Folio_ALT"].HeaderText = "Folio";
            dgvPendientesMtto.Columns["Tipo_Falla"].HeaderText = "Tipo Falla";
            dgvPendientesMtto.Columns["Notas"].Visible = false;
        }

        private void dgvPendientesMtto_DoubleClick(object sender, EventArgs e)
        {
            Limpiar();
            DataGridView dgvPendientes = (DataGridView)sender;

            if (dgvPendientes.SelectedCells.Count > 0)
            {
                int rowIndex = dgvPendientes.SelectedCells[0].RowIndex;

                string folio = dgvPendientes.Rows[rowIndex].Cells[1].Value.ToString();
                txbFolio.Text = folio;

                string solicitante = dgvPendientes.Rows[rowIndex].Cells[3].Value.ToString();
                txbSolicitante.Text = solicitante;

                string prioridad = dgvPendientes.Rows[rowIndex].Cells[4].Value.ToString();
                txbPrioridad.Text = prioridad;

                string tipofalla = dgvPendientes.Rows[rowIndex].Cells[5].Value.ToString();
                txbTipoFalla.Text = tipofalla;

                string mantenimiento = dgvPendientes.Rows[rowIndex].Cells[6].Value.ToString();
                txbMantenimiento.Text = mantenimiento;

                string ubicacion = dgvPendientes.Rows[rowIndex].Cells[7].Value.ToString();
                txbUbicacion.Text = ubicacion;

                string maquina = dgvPendientes.Rows[rowIndex].Cells[8].Value.ToString();
                txbMaquina.Text = maquina;

                string descripcion = dgvPendientes.Rows[rowIndex].Cells[9].Value.ToString();
                txbDescripcion.Text = descripcion;

                string recomendaciones = dgvPendientes.Rows[rowIndex].Cells[10].Value.ToString();
                txbRecomendaciones.Text = recomendaciones;

                string refacciones = dgvPendientes.Rows[rowIndex].Cells[11].Value.ToString();
                txbRefacciones.Text = refacciones;
            }
        }

        private void Limpiar()
        {
            txbFolio.Clear();
            txbSolicitante.Clear();
            txbMantenimiento.Clear();
            txbUbicacion.Clear();
            txbMaquina.Clear();
            pbImagen.Image = null;
            txbPrioridad.Clear();
            txbTipoFalla.Clear();
            txbDescripcion.Clear();
            txbRecomendaciones.Clear();
            txbRefacciones.Clear();
        }

        private void txbMaquina_TextChanged(object sender, EventArgs e)
        {
            BuscarImagen();
        }

        private void BuscarImagen()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Imagen FROM elastosystem_mtto_inventariomaquinas WHERE Nombre LIKE '" + txbMaquina.Text + "'";
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
                            byte[] imageData = (byte[])reader["Imagen"];
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pbImagen.Image = Image.FromStream(ms);
                            }
                        }
                        catch
                        {
                            pbImagen.Image = null;
                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL LLAMAR IMAGEN: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnCargarComprobante_Click(object sender, EventArgs e)
        {
            LimpiarPanelComprobante();
            if (string.IsNullOrEmpty(txbFolio.Text))
            {

            }
            else
            {
                pnlComprobante.Visible = true;
            }
        }

        private void LimpiarPanelComprobante()
        {
            pbComprobante.Image = null;
            txbNombreArchivo.Clear();
            lblRutaArchivo.Text = string.Empty;
            txbNotas.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            pnlComprobante.Visible = false;
            LimpiarPanelComprobante();
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

                string fileName = Path.GetFileName(filePath);

                txbNombreArchivo.Text = fileName;
                lblRutaArchivo.Text = filePath;
                pbComprobante.Image = null;

                try
                {
                    archivoBytes = File.ReadAllBytes(filePath);

                    if (EsImagen(filePath))
                    {
                        pbComprobante.Image = Image.FromFile(filePath);
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
            string extension = Path.GetExtension(filePath).ToLower();

            string[] extensionesImagen = { ".png", ".jpg", ".jpeg", ".gif", ".bmp" };

            return extensionesImagen.Contains(extension);
        }

        private void btnFinalizarReq_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombreArchivo.Text))
            {
                MessageBox.Show("Necesitas cargar un comprobante para finalizar");
            }
            else
            {
                MandarComprobante();
            }
        }

        private void MandarComprobante()
        {
            string fecha = DateTime.Now.ToString("yyyy/MM/dd");
            string ruta_archivo = lblRutaArchivo.Text.Replace("\\", "\\\\");
            string estatus = "FINALIZADA";
            string usuario = VariablesGlobales.Usuario;
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE elastosystem_mtto_req SET Estatus = @ESTATUS, Fecha_Termino = @FECHATERMINO, Ruta_Comprobante = @RUTACOMPROBANTE, Comprobante = @COMPROBANTE, Usuario_Finalizo = @USUARIOFINALIZO, Notas = @NOTAS WHERE Folio_ALT = @FOLIO";
                cmd.Parameters.AddWithValue("@FOLIO", txbFolio.Text);
                cmd.Parameters.AddWithValue("@ESTATUS", estatus);
                cmd.Parameters.AddWithValue("@FECHATERMINO", fecha);
                cmd.Parameters.AddWithValue("@RUTACOMPROBANTE", ruta_archivo);
                cmd.Parameters.AddWithValue("@COMPROBANTE", archivoBytes);
                cmd.Parameters.AddWithValue("@USUARIOFINALIZO", usuario);
                cmd.Parameters.AddWithValue("@NOTAS", txbNotas.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("MANTENIMIENTO " + txbFolio.Text + " FINALIZADO CON EXITO");
                Limpiar();
                LimpiarPanelComprobante();
                btnCerrar.PerformClick();
                PendientesMtto();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR AL FINALIZAR EL MANTENIMIENTO");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
