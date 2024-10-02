using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElastoSystem
{
    public partial class Maquinado_Solicitud : Form
    {
        string validacion = "0";
        public Maquinado_Solicitud()
        {
            InitializeComponent();
        }
        private void Fecha()
        {
            DateTime fechaActual = DateTime.Now;
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string fechaLarga = fechaActual.ToString("dddd, dd 'de' MMMM 'del' yyyy", CultureInfo.CurrentCulture);
            fechaLarga = textInfo.ToTitleCase(fechaLarga);
            lblfecha.Text = fechaLarga;
        }
        private void Folio()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionElastoSystem);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT ID_MAQUINADO FROM elastosystem_maquinado";

            try
            {
                int ultimoFolio = 0;
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string folioString = reader["ID_MAQUINADO"].ToString();
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
        private void Limpiar()
        {
            cbPrioridad.Text = null;
            txbRecomendacionesSugerencias.Text = null;
            cbTipo.Text = null;
            txbDescripcion.Text = null;
            txbDescripcionDelMaquinado.Text = null;
            lblRutaArchivo.Text = null;
            txbNombreArchivo.Text = null;
            pbImagen.Image = null;
        }

        private byte[] archivoBytes;

        private void CargarArchivo()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Todos los archivos (*.*)|*.*";
            openFileDialog.Title = "Seleccionar Archivo";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                string fileName = Path.GetFileName(filePath);

                txbNombreArchivo.Text = fileName;
                lblRutaArchivo.Text = filePath;

                try
                {
                    archivoBytes = File.ReadAllBytes(filePath);

                    if (EsImagen(filePath))
                    {
                        pbImagen.Image = Image.FromFile(filePath);
                        validacion = "1";
                    }
                    else
                    {
                        pbImagen.Image = null;
                        MessageBox.Show("Archivo cargado correctamente, pero no se puede previsualizar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        validacion = "1";
                    }


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

        private bool EsImagen(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            string[] extensionesImagen = { ".png", ".jpg", ".jpeg", ".gif", ".bmp" };

            return extensionesImagen.Contains(extension);
        }

        private void EnviarSolicitud()
        {
            string fecha = DateTime.Now.ToString("yyyy/MM/dd");
            string rutaarchivo = lblRutaArchivo.Text.Replace("\\", "\\\\");
            string estatus = "ACTIVA";
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionElastoSystem);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                if (validacion == "1")
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO elastosystem_maquinado (FECHA, SOLICITANTE, PRIORIDAD, RECOMENDACIONES, TIPO, DESCRIPCION, DESCRIPCION_MAQUINADO, ARCHIVO, RUTA, ESTATUS) VALUES (@FECHA, @SOLICITANTE, @PRIORIDAD, @RECOMENDACIONES, @TIPO, @DESCRIPCION, @DESCRIPCION_MAQUINADO, @ARCHIVO, @RUTA, @ESTATUS);";

                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    cmd.Parameters.AddWithValue("@SOLICITANTE", txbSolicitante.Text);
                    cmd.Parameters.AddWithValue("@PRIORIDAD", cbPrioridad.Text);
                    cmd.Parameters.AddWithValue("@RECOMENDACIONES", txbRecomendacionesSugerencias.Text);
                    cmd.Parameters.AddWithValue("@TIPO", cbTipo.Text);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", txbDescripcion.Text);
                    cmd.Parameters.AddWithValue("@DESCRIPCION_MAQUINADO", txbDescripcionDelMaquinado.Text);
                    cmd.Parameters.AddWithValue("@ARCHIVO", archivoBytes);
                    cmd.Parameters.AddWithValue("@RUTA", rutaarchivo);
                    cmd.Parameters.AddWithValue("@ESTATUS", estatus);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO elastosystem_maquinado (FECHA, SOLICITANTE, PRIORIDAD, RECOMENDACIONES, TIPO, DESCRIPCION, DESCRIPCION_MAQUINADO, ESTATUS) VALUES (@FECHA, @SOLICITANTE, @PRIORIDAD, @RECOMENDACIONES, @TIPO, @DESCRIPCION, @DESCRIPCION_MAQUINADO, @ESTATUS);";

                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    cmd.Parameters.AddWithValue("@SOLICITANTE", txbSolicitante.Text);
                    cmd.Parameters.AddWithValue("@PRIORIDAD", cbPrioridad.Text);
                    cmd.Parameters.AddWithValue("@RECOMENDACIONES", txbRecomendacionesSugerencias.Text);
                    cmd.Parameters.AddWithValue("@TIPO", cbTipo.Text);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", txbDescripcion.Text);
                    cmd.Parameters.AddWithValue("@DESCRIPCION_MAQUINADO", txbDescripcionDelMaquinado.Text);
                    cmd.Parameters.AddWithValue("@ESTATUS", estatus);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("REQUERIMIENTO " + lblFolio.Text + " ENVIADO CON EXITO");
                Limpiar();
                Folio();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL REGISTRAR EL MAQUINADO " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void MandarALlamarHistorial()
        {
            try
            {
                string tabla = @"SELECT ID_MAQUINADO, FECHA, PRIORIDAD, DESCRIPCION_MAQUINADO, ESTATUS
                                FROM elastosystem_maquinado
                                WHERE SOLICITANTE = @SOLICITANTE
                                ORDER BY ID_MAQUINADO DESC";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionLocal);
                mySqlAdapter.SelectCommand.Parameters.AddWithValue("@SOLICITANTE", txbSolicitante.Text);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dgvHistorialMaquinado.DataSource = dt;
                dgvHistorialMaquinado.Columns["ID_MAQUINADO"].HeaderText = "FOLIO";
                dgvHistorialMaquinado.Columns["DESCRIPCION_MAQUINADO"].HeaderText = "MAQUINADO";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Maquinado_Solicitud_Load(object sender, EventArgs e)
        {
            Fecha();
            Folio();
            txbSolicitante.Text = VariablesGlobales.Usuario;
            MandarALlamarHistorial();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void cbSolicitante_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            CargarArchivo();
        }

        private void btnEnviarSolicitud_Click(object sender, EventArgs e)
        {
            EnviarSolicitud();
        }
    }
}
