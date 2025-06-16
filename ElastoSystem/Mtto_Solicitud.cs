using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElastoSystem
{
    public partial class Mtto_Solicitud : Form
    {
        public Mtto_Solicitud()
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
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Folio FROM elastosystem_mtto_req";

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
                    lblFolio.Text = "MTO-"+ultimoFolio.ToString();
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
        private void MandarALlamarMaquinas()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Nombre FROM elastosystem_mtto_inventariomaquinas WHERE Estatus = 'ACTIVA'";
            try
            {
                HashSet<string> unicos = new HashSet<string>();
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string maquinas = reader["Nombre"].ToString();

                        if (!unicos.Contains(maquinas))
                        {
                            cbMaquinas.Items.Add(maquinas);
                            unicos.Add(maquinas);
                        }
                        else
                        {

                        }
                        cbMaquinas.Sorted = true;
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
        private void MandarALlamarUbicacion()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Ubicacion FROM elastosystem_mtto_inventariomaquinas WHERE Nombre LIKE '" + cbMaquinas.Text + "' ";
            string maq = cbMaquinas.Text;
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbUbicacion.Text = reader["Ubicacion"].ToString();
                    }
                }
                else
                {

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            cbMaquinas.Text = maq;
        }
        private void MandarALlamarImagen()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Imagen FROM elastosystem_mtto_inventariomaquinas WHERE Nombre LIKE '" + cbMaquinas.Text + "' ";
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
        private void MandarALlamarMaquinasXUbicaion()
        {
            cbMaquinas.Items.Clear();
            string ofi = cbUbicacion.Text;
            cbMaquinas.SelectedIndex = -1;

            if (ofi == "OFICINAS")
            {
                cbMaquinas.Items.Add("AGREGAR DESCRIPCION");
            }
            else
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string sql = "SELECT Nombre FROM elastosystem_mtto_inventariomaquinas WHERE Ubicacion LIKE @UBICACION AND ESTATUS = 'ACTIVA'";

                    using(MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UBICACION", cbUbicacion.Text);

                        try
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        cbMaquinas.Items.Add(reader["Nombre"].ToString());
                                    }
                                    cbMaquinas.Sorted = true;
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("ERROR AL CARGAR LAS MAQUINAS: " + ex.Message);
                        }
                    }
                    conn.Close();
                }
            }
        }
        private void EnviarRequerimiento()
        {
            string estatus = "ACTIVA";
            DateTime fechainicio = DateTime.Now;
            string fechai = fechainicio.ToString("yyyy-MM-dd");
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;

                cmd.CommandText = "SELECT COUNT(*) FROM elastosystem_mtto_req WHERE Folio = @FOLIOORI";
                cmd.Parameters.AddWithValue("@FOLIOORI", lblFolioOriginal.Text);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    Folio();
                    EnviarRequerimiento();
                    return;
                }

                cmd.CommandText = "INSERT INTO elastosystem_mtto_req (Folio, Folio_ALT, Fecha, Solicitante, Prioridad, Tipo_Falla, Mantenimiento, Ubicacion, Maquina, Descripcion, Recomendaciones_Sugerencias, Refacciones, Estatus) " + 
                                  "VALUES (@FOLIO, @FOLIOALT, @FECHA, @SOLICITANTE, @PRIORIDAD, @TIPOFALLA, @MANTENIMIENTO, @UBICACION, @MAQUINA, @DESCRIPCION, @RECOMENDACIONES, @REFACCIONES, @ESTATUS);";
                cmd.Parameters.AddWithValue("@FOLIO", lblFolioOriginal.Text);
                cmd.Parameters.AddWithValue("@FOLIOALT", lblFolio.Text);
                cmd.Parameters.AddWithValue("@FECHA", fechai);
                cmd.Parameters.AddWithValue("@SOLICITANTE", VariablesGlobales.Usuario);
                cmd.Parameters.AddWithValue("@PRIORIDAD", cbPrioridad.Text);
                cmd.Parameters.AddWithValue("@TIPOFALLA", cbTipoFalla.Text);
                cmd.Parameters.AddWithValue("@MANTENIMIENTO", cbTipoReq.Text);
                cmd.Parameters.AddWithValue("@UBICACION", cbUbicacion.Text);
                cmd.Parameters.AddWithValue("@MAQUINA", cbMaquinas.Text);
                cmd.Parameters.AddWithValue("@DESCRIPCION", txbDescripcion.Text);
                cmd.Parameters.AddWithValue("@RECOMENDACIONES", txbRecSug.Text);
                cmd.Parameters.AddWithValue("@REFACCIONES", txbRefacciones.Text);
                cmd.Parameters.AddWithValue("@ESTATUS", estatus);
                cmd.ExecuteNonQuery();
                EnviarCorreo();
                MessageBox.Show("Orden: " + lblFolio.Text + " enviada con exito");
                Limpiar();
                Folio();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                List<string> correosDestino = new List<string>();
                using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = "SELECT Correo FROM elastosystem_ajustes_correos WHERE Area = @AREA";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AREA", "Requisicion de Mantenimiento");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            correosDestino.Add(reader.GetString("Correo"));
                        }
                    }
                }

                if(correosDestino.Count == 0)
                {
                    MessageBox.Show("No se encontraron correos de destino para enviar la notificación.");
                    return;
                }

                SmtpClient smtpClient = new SmtpClient("smtp.ionos.mx");
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("notificaciones.elastosystem@elastotecnica.com.mx", "El@st0Sys25.");
                smtpClient.EnableSsl = true;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("notificaciones.elastosystem@elastotecnica.com.mx");
                
                foreach (string correo in correosDestino)
                {
                    mailMessage.To.Add(correo);
                }

                mailMessage.Subject = "REQUERIMIENTO DE MANTENIMIENTO: " + lblFolio.Text;

                StringBuilder cuerpoCorreo = new StringBuilder();
                cuerpoCorreo.AppendLine("<html><body style='font-family: Arial, sans-serif;'>");
                cuerpoCorreo.AppendLine($"<h2 style='color: #2E86C1;'>Detalles del Requerimiento {lblFolio.Text}</h2>");
                cuerpoCorreo.AppendLine($"<h5>Solicitante: {VariablesGlobales.Usuario}</h5><br><br>");

                cuerpoCorreo.AppendLine("<h3 style='color: #2E86C1;'>Detalles de la Falla</h3>");
                cuerpoCorreo.AppendLine($"<p><strong>Prioridad:</strong> {cbPrioridad.Text}</p>");
                cuerpoCorreo.AppendLine($"<p><strong>Tipo de Falla:</strong> {cbTipoFalla.Text}</p>");
                cuerpoCorreo.AppendLine($"<p><strong>Descripcion:</strong> {txbDescripcion.Text}</p><br><br>");

                cuerpoCorreo.AppendLine("<h3 style='color: #2E86C1;'>Datos del Equipo</h3>");
                cuerpoCorreo.AppendLine($"<p><strong>Mantenimiento:</strong> {cbTipoReq.Text}</p>");
                cuerpoCorreo.AppendLine($"<p><strong>Ubicacion:</strong> {cbUbicacion.Text}</p>");
                cuerpoCorreo.AppendLine($"<p><strong>Maquina:</strong> {cbMaquinas.Text}</p><br><br>");

                cuerpoCorreo.AppendLine("<h3 style='color: #2E86C1;'>Apoyo y Accesorios</h3>");
                cuerpoCorreo.AppendLine($"<p><strong>Recomendaciones / Sugerencias:</strong> {txbRecSug.Text}</p>");
                cuerpoCorreo.AppendLine($"<p><strong>Refacciones:</strong> {txbRefacciones.Text}</p>");

                cuerpoCorreo.AppendLine("</body></html>");

                mailMessage.IsBodyHtml = true;
                mailMessage.Body = cuerpoCorreo.ToString();

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ENVIAR CORREO: " + ex.Message);
            }
        }

        private void Limpiar()
        {
            cbTipoReq.SelectedIndex = -1;
            cbUbicacion.SelectedIndex = -1;
            cbMaquinas.Items.Clear();
            pbImagen.Image = null;
            cbPrioridad.SelectedIndex = -1;
            cbTipoFalla.SelectedIndex = -1;
            txbDescripcion.Clear();
            txbRecSug.Clear();
            txbRefacciones.Clear();
        }

        private void Mtto_Solicitud_Load(object sender, EventArgs e)
        {
            Fecha();
            Folio();
        }

        private void cbMaquinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            MandarALlamarUbicacion();
            MandarALlamarImagen();
        }

        private void cbUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            MandarALlamarMaquinasXUbicaion();
        }

        private void btnEnviarReq_Click(object sender, EventArgs e)
        {
            if(cbTipoReq.Text.Length > 0 && cbUbicacion.Text.Length > 0 && cbMaquinas.Text.Length > 0 && cbPrioridad.Text.Length > 0 && cbTipoFalla.Text.Length > 0 && txbDescripcion.Text.Length > 0)
            {
                lblCamposPartidas.Visible = false;
                pbCamposPartidas.Visible = false;
                pbMantenimiento.Visible = false;
                pbUbicacion.Visible = false;
                pbMaquina.Visible = false;
                pbPrioridad.Visible = false;
                pbTipoFalla.Visible = false;
                pbDescripcion.Visible = false;

                EnviarRequerimiento();
            }
            else
            {
                MessageBox.Show("DEBES DE LLENAR TODOS LOS CAMPOS OBLIGATORIOS");
                lblCamposPartidas.Visible = true;
                pbCamposPartidas.Visible = true;
                pbMantenimiento.Visible = true;
                pbUbicacion.Visible = true;
                pbMaquina.Visible = true;
                pbPrioridad.Visible = true;
                pbTipoFalla.Visible= true;
                pbDescripcion.Visible= true;
            }
        }

        private void cbTipoReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMaquinas.Items.Clear();
            cbUbicacion.SelectedIndex = -1;

            if(cbTipoReq.SelectedIndex == 2)
            {
                MandarALlamarMaquinas();
            }
            
        }
    }
}
