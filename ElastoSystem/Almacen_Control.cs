using DocumentFormat.OpenXml.Vml;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace ElastoSystem
{
    public partial class Almacen_Control : Form
    {
        public Almacen_Control()
        {
            InitializeComponent();
        }

        private void MandarALlamarNombre()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            String id = txbNoTrabajador.Text;
            string nombre = ""; string app = ""; string apm = "";
            MySqlDataReader reader = null;
            string sql = "SELECT Nombre, Apellido_Paterno, Apellido_Materno FROM elastosystem_rh WHERE ID ='" + id + "' ";
            try
            {
                HashSet<string> unicos = new HashSet<string>();
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        nombre = reader.GetString(0);
                        app = reader.GetString(1);
                        apm = reader.GetString(2);
                        lblNombreTrabajador.Text = nombre + " " + app + " " + apm;

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
        private void MandarALlamarProducto()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            String id = txbIDProducto.Text;
            string producto = ""; string unidad = "";
            MySqlDataReader reader = null;
            string sql = "SELECT Producto, Unidad FROM elastosystem_almacen WHERE ID_Producto ='" + id + "' ";
            try
            {
                HashSet<string> unicos = new HashSet<string>();
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        producto = reader.GetString(0);
                        unidad = reader.GetString(1);
                        lblNombreProducto.Text = producto;
                        lblUnidad.Text = unidad;
                    }
                    ExistenciasYEnvioTemporal();

                }
                else
                {
                    MessageBox.Show("ID de Producto no encontrado");
                    txbIDProducto.Clear();
                    txbIDProducto.Focus();
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
        private void ExistenciasYEnvioTemporal()
        {
            using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string idProducto = txbIDProducto.Text;
                    string sql = "SELECT Existencias FROM elastosystem_almacen WHERE ID_Producto = @IDProducto";

                    using(MySqlCommand comando = new MySqlCommand(sql, conn))
                    {
                        comando.Parameters.AddWithValue("@IDProducto", idProducto);
                        object result = comando.ExecuteScalar();

                        if(result != null)
                        {
                            int existencias = Convert.ToInt32(result);
                            int cantidad = 1;
                            int total = existencias - cantidad;

                            if(total > 0)
                            {
                                string updateSql = "UPDATE elastosystem_almacen SET Existencias = @Total WHERE ID_Producto = @IDProducto";
                                using(MySqlCommand updateCommand = new MySqlCommand(updateSql, conn))
                                {
                                    updateCommand.Parameters.AddWithValue("@Total", total);
                                    updateCommand.Parameters.AddWithValue("@IDProducto", idProducto);
                                    updateCommand.ExecuteNonQuery();
                                }

                                string checkSql = "SELECT COUNT(*) FROM elastosystem_almacenregistro_salidas_temp WHERE No_Trabajador = @NoTrabajador AND Producto = @Producto";
                                using(MySqlCommand checkCommand = new MySqlCommand(checkSql, conn))
                                {
                                    checkCommand.Parameters.AddWithValue("@NoTrabajador", txbNoTrabajador.Text);
                                    checkCommand.Parameters.AddWithValue("@Producto", lblNombreProducto.Text);

                                    int cantidadExistente = Convert.ToInt32(checkCommand.ExecuteScalar());

                                    if (cantidadExistente > 0)
                                    {
                                        string updateCantidadSql = "UPDATE elastosystem_almacenregistro_salidas_temp SET Cantidad = Cantidad + 1 WHERE No_Trabajador = @NoTrabajador AND Producto = @Producto";
                                        using (MySqlCommand updateCantidadCommand = new MySqlCommand(updateCantidadSql, conn))
                                        {
                                            updateCantidadCommand.Parameters.AddWithValue("@NoTrabajador", txbNoTrabajador.Text);
                                            updateCantidadCommand.Parameters.AddWithValue("@Producto", lblNombreProducto.Text);
                                            updateCantidadCommand.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        string insertSql = "INSERT INTO elastosystem_almacenregistro_salidas_temp (No_Trabajador, Nombre, Producto, Cantidad, Fecha, Hora, Unidad) VALUES (@NoTrabajador, @Nombre, @Producto, 1, @Fecha, @Hora, @Unidad)";
                                        using (MySqlCommand insertCommand = new MySqlCommand(insertSql, conn))
                                        {
                                            DateTime now = DateTime.Now;
                                            insertCommand.Parameters.AddWithValue("@NoTrabajador", txbNoTrabajador.Text);
                                            insertCommand.Parameters.AddWithValue("@Nombre", lblNombreTrabajador.Text);
                                            insertCommand.Parameters.AddWithValue("@Producto", lblNombreProducto.Text);
                                            insertCommand.Parameters.AddWithValue("@Fecha", now.ToShortDateString());
                                            insertCommand.Parameters.AddWithValue("@Hora", now.ToLongTimeString());
                                            insertCommand.Parameters.AddWithValue("@Unidad", lblUnidad.Text);
                                            insertCommand.ExecuteNonQuery();
                                        }
                                    }
                                }
                                MandarALlamarBDTemporal();
                                txbIDProducto.Clear();
                                lblNombreProducto.Text = "Nombre Producto";
                                lblUnidad.Text = "Unidad";
                            }
                            else
                            {
                                MessageBox.Show("No tienes suficiente stock de este producto");
                                txbIDProducto.Clear();
                                txbIDProducto.Focus();
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR: "+ex.Message);
                }
            }
        }
        private void MandarALlamarBDTemporal()
        {
            string tabla = "SELECT Producto, Cantidad, Unidad FROM elastosystem_almacenregistro_salidas_temp";
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
            DataTable dt = new DataTable();
            mySqlAdapter.Fill(dt);
            dgvTemporal.DataSource = dt;
        }
        private void OrdenTabuladores()
        {
            txbNoTrabajador.TabIndex = 0;
            txbIDProducto.TabIndex = 1;
            txbNota.TabIndex = 2;
            btnAceptar.TabIndex = 3;
        }
        private void LimpiarYReinicar()
        {
            txbNoTrabajador.Clear();
            txbIDProducto.Clear();
            txbNota.Clear();
            dgvTemporal.DataSource = null;
            dgvTemporal.Rows.Clear();
            dgvTemporal.Columns.Clear();
            txbNoTrabajador.Focus();
            lblNombreTrabajador.Text = string.Empty;
            lblNombreProducto.Text = string.Empty;
            lblUnidad.Text = string.Empty;
        }
        private void LimpiarBDTemporal()
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                mySqlConnection.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = mySqlConnection;
                comando.CommandText = "DELETE FROM elastosystem_almacenregistro_salidas_temp";
                comando.ExecuteNonQuery();
                mySqlConnection.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                MessageBox.Show("ERROR AL LIMPIAR BASE DE DATOS TEMPORAL");
                this.Hide();
            }
        }
        private void MandaALlamarBDSalidas()
        {
            string tabla = "SELECT * FROM elastosystem_almacenregistro_salidas";
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
            DataTable dt = new DataTable();
            mySqlAdapter.Fill(dt);
            dgvBD.DataSource = dt;
            dt.DefaultView.Sort = "Folio DESC";
        }

        private void txbNoTrabajador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string texto = txbNoTrabajador.Text;

                if (texto.Contains(Environment.NewLine))
                {
                    texto = texto.Replace(Environment.NewLine, "");

                    txbNoTrabajador.Text = texto;
                }

                txbIDProducto.Focus();

                e.Handled = true;
                MandarALlamarNombre();
            }

        }
        private void txbIDProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string texto = txbIDProducto.Text;
                if(texto.Contains(Environment.NewLine))
                {
                    texto = texto.Replace(Environment.NewLine, "");
                    txbIDProducto.Text = texto;
                }
                e.Handled = true;

                MandarALlamarProducto();
            }

        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.Visible = false;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
        }

        private async void Almacen_Control_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;

            await Task.Run(() =>
            {
                progressBar1.Invoke((Action)(() => progressBar1.Value = 33));
                MandarALlamarProductos();
                progressBar1.Invoke((Action)(() => progressBar1.Value = 66));
                progressBar1.Invoke((Action)(() => progressBar1.Value = 88));
                MandarCorreoPrioridadesAlmacen();
                progressBar1.Invoke((Action)(() => progressBar1.Value = 99));

            });

            LimpiarBDTemporal();
            MandaALlamarBDSalidas();
            OrdenTabuladores();

            pnlCargando.Visible = false;
        }

        private void MandarALlamarProductos()
        {
            try
            {
                string update = @"
                    UPDATE elastosystem_sae_productos
                    SET Estatus = CASE
                        WHEN `1M` IS NULL OR `1M` = 0 THEN '----------'
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

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL LLAMAR ACTUALIZAR ESTATUS EN PRODUCTOS: " + ex.Message);
            }
        }

        private void MandarCorreoPrioridadesAlmacen()
        {
            string table = "SELECT Producto, Existencia, Estatus, Meses " +
                            "FROM elastosystem_sae_productos " +
                            "WHERE Estatus = 'Critico' OR Estatus = 'Resurtir' OR Estatus = 'Programar' " +
                            "ORDER BY CASE " +
                            "WHEN Estatus = 'Critico' THEN 1 " +
                            "WHEN Estatus = 'Resurtir' THEN 2 " +
                            "WHEN Estatus = 'Programar' THEN 3 " +
                            "ELSE 4 END, Meses ASC";
            MySqlDataAdapter adapatador = new MySqlDataAdapter(table, VariablesGlobales.ConexionBDElastotecnica);
            DataTable dt = new DataTable();
            adapatador.Fill(dt);

            dgvProductos.DataSource = dt;
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.ionos.mx")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("notificaciones.elastosystem@elastotecnica.com.mx", "El@st0Sys25."),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("notificaciones.elastosystem@elastotecnica.com.mx", "ELASTOTECNICA ALMACEN"),
                    Subject = "PRIORIDADES DE ALMACEN",
                    IsBodyHtml = true,
                    Body = ConstruirCuerpoCorreoHTMLPrioridades(dt)
                };

                //mailMessage.To.Add("imedinaa@elastotecnica.com");
                //mailMessage.To.Add("mario.lopez@elastotecnica.com.mx");
                mailMessage.To.Add("miguel.garcia@elastotecnica.com.mx");
                //mailMessage.To.Add("almacen@elastotecnica.com");

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ENVIAR EL CORREO DE PRIORIDADES DE ALMACEN: " + ex.Message);
            }
        }

        private string ConstruirCuerpoCorreoHTMLPrioridades(DataTable dataTable)
        {
            StringBuilder cuerpoCorreo = new StringBuilder();

            cuerpoCorreo.AppendLine("<html><body>");
            cuerpoCorreo.AppendLine("<h2>PRIORIDADES PARA PRODUCCIÓN:</h2>");
            cuerpoCorreo.AppendLine("<table border='1' style='border-collapse: collapse; width: 100%; font-family: Arial, sans-serif;'>");

            cuerpoCorreo.AppendLine("<tr style='background-color: #f2f2f2;'>");
            foreach (DataColumn columna in dataTable.Columns)
            {
                cuerpoCorreo.AppendLine($"<th style='padding: 8px; text-align: center; border: 1px solid #ddd;'>{columna.ColumnName}</th>");
            }
            cuerpoCorreo.AppendLine("</tr>");

            foreach (DataRow fila in dataTable.Rows)
            {
                string estatus = fila["Estatus"].ToString();
                string colorFila = "#FFFFFF";

                if (estatus == "Critico") colorFila = "FF0000";
                else if (estatus == "Resurtir") colorFila = "CC0000";
                else if (estatus == "Programar") colorFila = "FFFF00";

                cuerpoCorreo.AppendLine($"<tr style='background-color: #{colorFila};'>");

                foreach (var celda in fila.ItemArray)
                {
                    string valorCelda = celda != null ? celda.ToString() : "";
                    cuerpoCorreo.AppendLine($"<td style='padding: 8px; text-align: center; border: 1px solid #ddd;'>{valorCelda}</td>");
                }
                cuerpoCorreo.AppendLine("</tr>");
            }

            cuerpoCorreo.AppendLine("</table>");
            cuerpoCorreo.AppendLine("</body></html>");

            return cuerpoCorreo.ToString();
        }

        private void horayfecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                mySqlConnection.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = mySqlConnection;
                comando.CommandText = "INSERT INTO elastosystem_almacenregistro_salidas (No_Trabajador, Nombre, Producto, Cantidad, Fecha, Hora, Nota, Unidad) SELECT No_Trabajador, Nombre, Producto, Cantidad, Fecha, Hora, @Nota, Unidad FROM elastosystem_almacenregistro_salidas_temp;";
                comando.Parameters.AddWithValue("@Nota", txbNota.Text);
                comando.ExecuteNonQuery();
                mySqlConnection.Close();
                MessageBox.Show("Requerimiento de Trabajador No. " + txbNoTrabajador.Text + " surtido exitosamente");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                MessageBox.Show("ERROR AL SURTIR MATERIAL");
            }
            LimpiarBDTemporal();
            MandaALlamarBDSalidas();
            LimpiarYReinicar();
        }

        private void txbNoTrabajador_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txbNoTrabajador_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                MandarALlamarNombre();
            }
        }
    }
}
