using DocumentFormat.OpenXml.Wordprocessing;
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
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElastoSystem
{
    public partial class ReqSistemas : Form
    {
        public ReqSistemas()
        {
            InitializeComponent();
        }
        private void fecha_Tick(object sender, EventArgs e)
        {

        }
        private void MandarALlamarPendientesSistemas()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = @"
                        SELECT Folio_ALT, 
                        IFNULL(FechaInicio, '0000-00-00') AS FechaInicio, 
                        IFNULL(FechaTermino, '0000-00-00') AS FechaTermino, 
                        Descripcion, Prioridad, Estatus 
                        FROM elastosystem_sistemas_req 
                        WHERE Solicitante = @SOLICITANTE    
                        ORDER BY 
                            FIELD(Estatus, 'ABIERTO', 'EN PROCESO', 'FINALIZADO'),
                            FechaInicio DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SOLICITANTE", VariablesGlobales.Usuario);

                        using (MySqlDataAdapter adapatador = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapatador.Fill(dt);
                            dgvPendientesSistemas.DataSource = dt;
                            dgvPendientesSistemas.Columns["Folio_ALT"].HeaderText = "Folio";
                            dgvPendientesSistemas.Columns["FechaInicio"].HeaderText = "Fecha Inicio";
                            dgvPendientesSistemas.Columns["FechaTermino"].HeaderText = "Fecha Termino";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO AL LLAMAR EL HISTORIAL DE REQUERIMIENTOS: " + ex.Message);
            }
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
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Folio FROM elastosystem_sistemas_req";

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
                    lblFolio.Text = "TKS-" + ultimoFolio.ToString();
                    lblFolioOriginal.Text = ultimoFolio.ToString();
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
        private void EnviarRequerimiento()
        {
            string estatus = "ABIERTO";
            string fechainicio = DateTime.Now.ToString("yyyy-MM-dd");
            string horaActual = DateTime.Now.ToString("HH:mm:ss");
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;

                cmd.CommandText = "SELECT COUNT(*) FROM elastosystem_sistemas_req WHERE Folio = @FOLIO";
                cmd.Parameters.AddWithValue("@FOLIO", lblFolioOriginal.Text);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    Folio();
                    EnviarRequerimiento();
                    return;
                }
                cmd.CommandText = "INSERT INTO elastosystem_sistemas_req (Folio, Folio_ALT, TipoReq, FechaInicio, HoraInicio, Descripcion, Solicitante, Prioridad, Estatus, Recursos, Ruta_Recursos) " +
                                    "VALUES (@FOLIOR, @FOLIOALT, @TIPOREQ, @FECHAINICIO, @HORAINICIO, @DESCRIPCION, @SOLICITANTE, @PRIORIDAD, @ESTATUS, @RECURSOS, @RUTARECURSOS);";
                cmd.Parameters.AddWithValue("@FOLIOR", lblFolioOriginal.Text);
                cmd.Parameters.AddWithValue("@FOLIOALT", lblFolio.Text);
                cmd.Parameters.AddWithValue("@TIPOREQ", cbTipoReq.Text);
                cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                cmd.Parameters.AddWithValue("@HORAINICIO", horaActual);
                cmd.Parameters.AddWithValue("@DESCRIPCION", tbDescr.Text);
                cmd.Parameters.AddWithValue("@SOLICITANTE", VariablesGlobales.Usuario);
                cmd.Parameters.AddWithValue("@PRIORIDAD", cbNivelPrio.Text);
                cmd.Parameters.AddWithValue("@ESTATUS", estatus);
                cmd.Parameters.AddWithValue("@RECURSOS", archivoBytes);
                cmd.Parameters.AddWithValue("@RUTARECURSOS", lblRutaArchivo.Text);
                cmd.ExecuteNonQuery();
                EnviarCorreo();
                MessageBox.Show("Ticket: " + lblFolio.Text + " enviado con exito");
                Limpiar();
                Folio();
                MandarALlamarPendientesSistemas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ENVIAR TICKET: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void EnviarCorreo()
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.ionos.mx");
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("notificaciones.elastosystem@elastotecnica.com.mx", "El@st0Sys25.");
                smtpClient.EnableSsl = true;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("notificaciones.elastosystem@elastotecnica.com.mx");
                mailMessage.To.Add("soporte@elastotecnica.com.mx");
                mailMessage.To.Add("miguel.garcia@elastotecnica.com.mx");
                mailMessage.To.Add("imedinaa@elastotecnica.com");
                mailMessage.Subject = "TICKET DE SISTEMAS: "+lblFolio.Text;

                StringBuilder cuerpoCorreo = new StringBuilder();
                cuerpoCorreo.AppendLine("<html><body>");
                cuerpoCorreo.AppendLine($"<h2>Detalles del Ticket {lblFolio.Text}</h2><br>");

                cuerpoCorreo.AppendLine($"<h4>Solicitante: {VariablesGlobales.Usuario}</h4>");
                cuerpoCorreo.AppendLine($"<h4>Nivel de Prioridad: {cbNivelPrio.Text}</h4>");
                cuerpoCorreo.AppendLine($"<h4>Categoria del Ticket: {cbTipoReq.Text}</h4><br>");
                cuerpoCorreo.AppendLine("<h4>Descripcion:");
                cuerpoCorreo.AppendLine($"{tbDescr.Text}");

                cuerpoCorreo.AppendLine("</body></html>");

                mailMessage.IsBodyHtml = true;
                mailMessage.Body = cuerpoCorreo.ToString();

                smtpClient.Send(mailMessage);
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR AL ENVIAR EL CORREO: "+ex.Message);
            }
        }

        private void Limpiar()
        {
            cbTipoReq.SelectedIndex = -1;
            cbNivelPrio.SelectedIndex = -1;
            tbDescr.Clear();
            txbNombreArchivo.Clear();
            lblRutaArchivo.Text = string.Empty;
            archivoBytes = null;
            pbImagen.Image = null;
        }

        private void ReqSistemas_Load(object sender, EventArgs e)
        {
            MandarALlamarPendientesSistemas();
            Fecha();
            Folio();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnviarRequerimiento();
            MandarALlamarPendientesSistemas();
        }

        private void btnEnviarReq_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnEnviarReq_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tbpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            CargarArchivo();
        }

        private byte[] archivoBytes;
        private void CargarArchivo()
        {
            OpenFileDialog opd = new OpenFileDialog();

            opd.Filter = "Todos los archivos (*.*)|*.*";
            opd.Title = "Seleccionar Archivo";

            if (opd.ShowDialog() == DialogResult.OK)
            {
                string filePath = opd.FileName;
                string fileName = Path.GetFileName(filePath);

                txbNombreArchivo.Text = fileName;
                lblRutaArchivo.Text = filePath;

                try
                {
                    archivoBytes = File.ReadAllBytes(filePath);

                    if (EsImagen(filePath))
                    {
                        pbImagen.Image = Image.FromFile(filePath);
                    }
                    else
                    {
                        pbImagen.Image = null;
                        MessageBox.Show("Archivo cargado correctamente");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el archivo: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No se selecciono ningun archivo");
                txbNombreArchivo.Clear();
                lblRutaArchivo.Text = string.Empty;
                archivoBytes = null;
            }
        }

        private bool EsImagen(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            string[] extensionImagen = { ".png", ".jpg", ".jpeg", ".gif", ".bmp" };

            return extensionImagen.Contains(extension);
        }

        private void cbNivelPrio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = cbTipoReq.Text;
            cbTipoReq.Items.Clear();

            if (cbNivelPrio.SelectedIndex == 0)
            {
                cbTipoReq.Items.Add("Fallo en Equipo de Computo");
                cbTipoReq.Items.Add("Problema de Seguridad");
                cbTipoReq.Items.Add("Problemas de Red");
                cbTipoReq.Items.Add("Sin Acceso al Sistema");
            }
            else if (cbNivelPrio.SelectedIndex == 1)
            {
                cbTipoReq.Items.Add("Problemas de Impresoras/Periféricos");
                cbTipoReq.Items.Add("Requerimientos de Hardware");
                cbTipoReq.Items.Add("Requerimientos de Software");
                cbTipoReq.Items.Add("Solicitud de Cambio o Mejora");
            }
            else
            {
                cbTipoReq.Items.Add("Consulta General");
                cbTipoReq.Items.Add("Mantenimiento Preventivo");
                cbTipoReq.Items.Add("Respaldo de Datos");
                cbTipoReq.Items.Add("Solicitud de Capacitación");
            }

            if (cbTipoReq.Items.Contains(selectedText))
            {
                cbTipoReq.Text = selectedText;
            }
            else
            {
                cbTipoReq.SelectedIndex = -1;
            }
        }

        private void cbTipoReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTipoReq.Text == "Fallo en Equipo de Computo" || 
                cbTipoReq.Text == "Problema de Seguridad" || 
                cbTipoReq.Text == "Problemas de Red" ||
                cbTipoReq.Text == "Sin Acceso al Sistema")
            {
                cbNivelPrio.Text = "Alta";
            }
            else if(cbTipoReq.Text == "Problemas de Impresoras/Periféricos" ||
                cbTipoReq.Text == "Requerimientos de Hardware" ||
                cbTipoReq.Text == "Requerimientos de Software" ||
                cbTipoReq.Text == "Solicitud de Cambio o Mejora")
            {
                cbNivelPrio.Text = "Media";
            }
            else
            {
                cbNivelPrio.Text = "Baja";
            }
        }
    }
}
