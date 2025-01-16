using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElastoSystem
{
    public partial class Maquinado_Administrar : Form
    {
        string validacion = "0";
        public Maquinado_Administrar()
        {
            InitializeComponent();

        }
        private void MandarALlamarPendientesMaquinado()
        {
            try
            {
                string tabla = @"SELECT ID_MAQUINADO, ID_MAQUINADO_ALT, FECHA, SOLICITANTE, PRIORIDAD, RECOMENDACIONES, TIPO, DESCRIPCION, DESCRIPCION_MAQUINADO 
                                FROM elastosystem_maquinado
                                WHERE ESTATUS = 'ACTIVA'
                                ORDER BY 
                                   CASE 
                                    WHEN PRIORIDAD = 'CRITICA' THEN 1
                                     WHEN PRIORIDAD = 'ALTA' THEN 2
                                    WHEN PRIORIDAD = 'MEDIA' THEN 3
                                    WHEN PRIORIDAD = 'BAJA' THEN 4
                                    ELSE 5
                                END,
                                ID_MAQUINADO DESC";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dgvPendientesMaquinado.DataSource = dt;
                dgvPendientesMaquinado.Columns["ID_MAQUINADO"].Visible = false;
                dgvPendientesMaquinado.Columns["RECOMENDACIONES"].Visible = false;
                dgvPendientesMaquinado.Columns["TIPO"].Visible = false;
                dgvPendientesMaquinado.Columns["DESCRIPCION"].Visible = false;
                dgvPendientesMaquinado.Columns["ID_MAQUINADO_ALT"].HeaderText = "FOLIO";
                dgvPendientesMaquinado.Columns["DESCRIPCION_MAQUINADO"].HeaderText = "MAQUINADO";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        byte[] archivoBytes;
        byte[] comprobanteBytes;
        private void MandarALlamarRestoMaquinado()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT ARCHIVO, RUTA FROM elastosystem_maquinado WHERE ID_MAQUINADO LIKE '" + lblFolio.Text + "' ";
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("ARCHIVO")))
                            {
                                archivoBytes = (byte[])reader["ARCHIVO"];

                                if (archivoBytes != null && archivoBytes.Length > 0)
                                {
                                    if (EsImagen(archivoBytes))
                                    {
                                        using (MemoryStream ms = new MemoryStream(archivoBytes))
                                        {
                                            pbImagen.Image = Image.FromStream(ms);
                                        }
                                    }
                                    else
                                    {
                                        pbImagen.Image = null;
                                    }
                                    validacion = "1";
                                }
                                else
                                {
                                    pbImagen.Image = null;
                                    validacion = "0";
                                }
                            }
                            else
                            {
                                archivoBytes = null;
                                pbImagen.Image = null;
                                validacion = "0";
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            pbImagen.Image = null;
                            validacion = "0";
                            MessageBox.Show("Error al procesar el archivo" + ex.Message);
                        }
                        try
                        {
                            txbNombreArchivo.Text = reader.GetString("RUTA");
                            string rutacompleta = txbNombreArchivo.Text;
                            txbRuta.Text = rutacompleta;
                            string nombrearchivo = Path.GetFileName(rutacompleta);
                            txbNombreArchivo.Text = nombrearchivo;
                        }
                        catch
                        {
                            txbNombreArchivo.Text = string.Empty;
                        }

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
        }

        private bool EsImagen(byte[] archivoBytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(archivoBytes))
                {
                    Image.FromStream(ms);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void DescargarImagen()
        {
            if (archivoBytes != null && archivoBytes.Length > 0)
            {
                string extensionArchivo = Path.GetExtension(txbRuta.Text);
                string nombreArchivo = txbNombreArchivo.Text;

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = nombreArchivo,
                    Filter = "Todos los archivos (*.*)|*.*",
                    DefaultExt = extensionArchivo
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, archivoBytes);
                        MessageBox.Show("Archivo guardado correctamente");
                        string argument = "/select, \"" + saveFileDialog.FileName + "\"";
                        System.Diagnostics.Process.Start("explorer.exe", argument);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay archivo para descargar.");
            }
        }
        private void Limpiar()
        {
            txbSolicitante.Clear();
            txbPrioridad.Clear();
            txbFecha.Clear();
            txbTipo.Clear();
            txbFolio.Clear();
            pbImagen.Image = null;
            txbNombreArchivo.Clear();
            txbDescripcion.Clear();
            txbDescripcionMaquinado.Clear();
            txbRecomendaciones.Clear();
            dgvPendientesMaquinado.DataSource = null;
            dgvPendientesMaquinado.Rows.Clear();
            dgvPendientesMaquinado.Columns.Clear();
        }


        private void Maquinado_Administrar_Load(object sender, EventArgs e)
        {
            MandarALlamarPendientesMaquinado();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MandarALlamarPendientesMaquinado();
        }

        private void dgvPendientesSistemas_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string folio_original = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblFolio.Text = folio_original;

                string folio = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                txbFolio.Text = folio;

                string fechaConHora = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                DateTime fecha = Convert.ToDateTime(fechaConHora);
                string fechaFormateada = fecha.ToString("yyyy-MM-dd");
                txbFecha.Text = fechaFormateada;

                string solicitante = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                txbSolicitante.Text = solicitante;

                string prioridad = dgv.Rows[rowIndex].Cells[4].Value.ToString();
                txbPrioridad.Text = prioridad;

                string recomendaciones = dgv.Rows[rowIndex].Cells[5].Value.ToString();
                txbRecomendaciones.Text = recomendaciones;

                string tipo = dgv.Rows[rowIndex].Cells[6].Value.ToString();
                txbTipo.Text = tipo;

                string descripcion = dgv.Rows[rowIndex].Cells[7].Value.ToString();
                txbDescripcion.Text = descripcion;

                string maquinado = dgv.Rows[rowIndex].Cells[8].Value.ToString();
                txbDescripcionMaquinado.Text = maquinado;


            }
            MandarALlamarRestoMaquinado();
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            DescargarImagen();
        }

        private void btnRealizado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbFolio.Text))
            {
                MessageBox.Show("No se ha seleccionado ningun maquinado");
            }
            else
            {
                pnlRealizado.Visible = true;
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            pnlRealizado.Visible = false;
            txbNombreComprobante.Clear();
            comprobanteBytes = null;
            lblRutaComprobante.Text = string.Empty;
            Limpiar();
            MandarALlamarPendientesMaquinado();
        }

        private void CargarComprobante()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Todos los archivos (*.*)|*.*";
            openFileDialog.Title = "Seleccionar Archivo";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                string fileName = Path.GetFileName(filePath);

                txbNombreComprobante.Text = fileName;
                lblRutaComprobante.Text = filePath;

                try
                {
                    comprobanteBytes = File.ReadAllBytes(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el archivo" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No se seleccionó ningún archivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            CargarComprobante();
        }

        private void btnFinalizado_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txbNombreComprobante.Text) &&
                !string.IsNullOrWhiteSpace(lblRutaComprobante.Text) &&
                comprobanteBytes != null && comprobanteBytes.Length > 0)
            {
                MandarComprobanteABD();
            }
            else
            {
                MessageBox.Show("Debes de subir tu comprobante");
            }
        }

        private void MandarComprobanteABD()
        {
            string fecha = DateTime.Now.ToString("yyyy/MM/dd");
            string rutaarchivo = lblRutaComprobante.Text.Replace("\\", "\\\\");
            string estatus = "FINALIZADA";
            string usuario = VariablesGlobales.Usuario;
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE elastosystem_maquinado SET ESTATUS = @Estatus, FECHA_TERMINO = @FechaTermino, RUTA_COMPROBANTE = @RutaComprobante, COMPROBANTE = @Comprobante, USUARIO_FINALIZO = @UsuarioFinalizo WHERE ID_MAQUINADO = @IdMaquinado";

                cmd.Parameters.AddWithValue("@IdMaquinado", lblFolio.Text);
                cmd.Parameters.AddWithValue("@Estatus", estatus);
                cmd.Parameters.AddWithValue("@FechaTermino", fecha);
                cmd.Parameters.AddWithValue("@RutaComprobante", rutaarchivo);
                cmd.Parameters.AddWithValue("@Comprobante", comprobanteBytes);
                cmd.Parameters.AddWithValue("@UsuarioFinalizo", usuario);
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("MAQUINADO " + txbFolio.Text + " FINALIZADO CON EXITO");
                Limpiar();
                btnRegresar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL FINALIZAR EL MAQUINADO " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
