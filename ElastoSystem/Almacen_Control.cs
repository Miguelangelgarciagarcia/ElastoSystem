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
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                conn.Open();
                string id = txbNoTrabajador.Text;
                string nombre = "", app = "", apm = "";
                string sql = "SELECT Nombre, Apellido_Paterno, Apellido_Materno FROM elastosystem_rh WHERE ID = @ID";

                try
                {
                    using (MySqlCommand comando = new MySqlCommand(sql, conn))
                    {
                        comando.Parameters.AddWithValue("@ID", id);
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    nombre = reader.GetString(0);
                                    app = reader.GetString(1);
                                    apm = reader.GetString(2);
                                    lblNombreTrabajador.Text = $"{nombre} {app} {apm}";
                                }
                            }
                            else
                            {
                                Almacen_Control_UsuarioInvalido usuarioInvalido = new Almacen_Control_UsuarioInvalido();
                                usuarioInvalido.ShowDialog();
                                txbNoTrabajador.Clear();
                                txbNoTrabajador.Focus();
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL LLAMAR NOMBRE DE TRABAJADOR: " + ex.Message);
                    txbNoTrabajador.Clear();
                    txbNoTrabajador.Focus();
                }
            }
        }
        private void MandarALlamarProducto()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string id = txbIDProducto.Text.Trim();

                    string sql = "SELECT Producto, Unidad FROM elastosystem_almacen WHERE ID_Producto = @IDPRODUCTO";
                    using (MySqlCommand comando = new MySqlCommand(sql, conn))
                    {
                        comando.Parameters.AddWithValue("@IDPRODUCTO", id);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    lblNombreProducto.Text = reader.GetString(0);
                                    lblUnidad.Text = reader.GetString(1);
                                }
                                ExistenciasYEnvioTemporal();
                            }
                            else
                            {
                                Almacen_Control_ProductoInvalido productoInvalido = new Almacen_Control_ProductoInvalido();
                                productoInvalido.ShowDialog();
                                txbIDProducto.Clear();
                                txbIDProducto.Focus();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL LLAMAR PRODUCTO: " + ex.Message);
                    txbIDProducto.Clear();
                    txbIDProducto.Focus();
                }
            }
        }
        private void ExistenciasYEnvioTemporal()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string idProducto = txbIDProducto.Text.Trim();

                    string sql = "SELECT Existencias, Producto, Unidad FROM elastosystem_almacen WHERE ID_Producto = @IDPRODUCTO";
                    using (MySqlCommand comando = new MySqlCommand(sql, conn))
                    {
                        comando.Parameters.AddWithValue("@IDPRODUCTO", idProducto);
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int existencias = reader.GetInt32(0);
                                string producto = reader.GetString(1);
                                string unidad = reader.GetString(2);

                                if (existencias <= 0)
                                {
                                    Almacen_Control_StockInsuficiente stockInsuficiente = new Almacen_Control_StockInsuficiente();
                                    stockInsuficiente.ShowDialog();
                                    txbIDProducto.Clear();
                                    txbIDProducto.Focus();
                                    return;
                                }

                                reader.Close();

                                string updateSql = "UPDATE elastosystem_almacen SET Existencias = Existencias - 1 WHERE ID_Producto = @IDPRODUCTO";
                                using (MySqlCommand updateCommand = new MySqlCommand(updateSql, conn))
                                {
                                    updateCommand.Parameters.AddWithValue("@IDPRODUCTO", idProducto);
                                    updateCommand.ExecuteNonQuery();
                                }

                                bool productoEncontrado = false;
                                foreach (DataGridViewRow row in dgvLista.Rows)
                                {
                                    if (row.Cells["ID_Producto"].Value != null && row.Cells["ID_Producto"].Value.ToString() == idProducto)
                                    {
                                        int cantidadActual = Convert.ToInt32(row.Cells["Cantidad"].Value);
                                        row.Cells["Cantidad"].Value = cantidadActual + 1;
                                        productoEncontrado = true;
                                        break;
                                    }
                                }

                                if (!productoEncontrado)
                                {
                                    dgvLista.Rows.Add(idProducto, 1, producto, unidad);
                                }

                                txbIDProducto.Clear();
                                txbIDProducto.Focus();
                            }
                            else
                            {
                                MessageBox.Show("ID de producto no encontrado en la base de datos");
                                txbIDProducto.Clear();
                                txbIDProducto.Focus();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL LLAMAR EXISTENCIAS Y ENVIAR A TEMPORAL: " + ex.Message);
                }
            }
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

            dgvLista.DataSource = null;
            dgvLista.Rows.Clear();

            txbNoTrabajador.Focus();
            lblNombreTrabajador.Text = string.Empty;
            lblNombreProducto.Text = string.Empty;
            lblUnidad.Text = string.Empty;
        }
        private void MandaALlamarBDSalidas()
        {
            string tabla = "SELECT * FROM elastosystem_almacenregistro_salidas";
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
            DataTable dt = new DataTable();
            mySqlAdapter.Fill(dt);
            dgvBD.DataSource = dt;
            dt.DefaultView.Sort = "Folio DESC";
            dgvBD.Columns["Folio"].Visible = false;
            dgvBD.Columns["No_Trabajador"].Visible = false;
            dgvBD.Columns["Fecha"].Visible = false;
            dgvBD.Columns["Hora"].Visible = false;
            dgvBD.Columns["Fechas"].HeaderText = "Fecha";
            dgvBD.Columns["Horas"].HeaderText = "Hora";
        }

        private void txbNoTrabajador_KeyPress(object sender, KeyPressEventArgs e)
        {
            VariablesGlobales.ValidarNumeroEntero(e, txbNoTrabajador);

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
            VariablesGlobales.ValidarNumeroEntero(e, txbIDProducto);

            if (e.KeyChar == (char)Keys.Enter)
            {
                string texto = txbIDProducto.Text;
                if (texto.Contains(Environment.NewLine))
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
                progressBar1.Invoke((Action)(() => progressBar1.Value = 15));
                CargarSAE();

                progressBar1.Invoke((Action)(() => progressBar1.Value = 33));
                MandarALlamarProductos();

                progressBar1.Invoke((Action)(() => progressBar1.Value = 66));

                progressBar1.Invoke((Action)(() => progressBar1.Value = 88));
                MandarCorreoPrioridadesAlmacen();

                progressBar1.Invoke((Action)(() => progressBar1.Value = 99));

            });

            MandaALlamarBDSalidas();
            OrdenTabuladores();

            pnlCargando.Visible = false;
        }

        private void CargarSAE()
        {
            try
            {
                dgvProductosSAE.AutoGenerateColumns = true;

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
                dgvProductosSAE.DataSource = bSAspelSAE;

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

                    foreach (DataGridViewRow row in dgvProductosSAE.Rows)
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
                using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dgvLista.Rows)
                    {
                        string query = @"INSERT INTO elastosystem_almacenregistro_salidas
                                        (No_Trabajador, Nombre, Producto, Cantidad, Fechas, Horas, Nota, Unidad)
                                        VALUES
                                        (@NO_TRABAJADOR, @NOMBRE, @PRODUCTO, @CANTIDAD, @FECHA, @HORA, @NOTA, @UNIDAD)";

                        using(MySqlCommand comando = new MySqlCommand(query, conn))
                        {
                            comando.Parameters.AddWithValue("@NO_TRABAJADOR", txbNoTrabajador.Text);
                            comando.Parameters.AddWithValue("@NOMBRE", lblNombreTrabajador.Text);
                            comando.Parameters.AddWithValue("@PRODUCTO", row.Cells["Producto"].Value.ToString());
                            comando.Parameters.AddWithValue("@CANTIDAD", Convert.ToInt32(row.Cells["Cantidad"].Value));
                            comando.Parameters.AddWithValue("@UNIDAD", row.Cells["Unidad"].Value.ToString());
                            comando.Parameters.AddWithValue("@FECHA", DateTime.Now.ToString("yyyy-MM-dd"));
                            comando.Parameters.AddWithValue("@HORA", DateTime.Now.ToString("HH:mm:ss"));
                            comando.Parameters.AddWithValue("@NOTA", txbNota.Text);

                            comando.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                    MandaALlamarBDSalidas();
                    LimpiarYReinicar();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR AL SURTIR MATERIAL: " + ex.Message);
            }
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

        private void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvLista.Rows.Count == 0) return;

            DataGridViewRow fila = dgvLista.Rows[e.RowIndex];

            string idProducto = fila.Cells["ID_Producto"].Value?.ToString();
            if (string.IsNullOrEmpty(idProducto)) return;

            int cantidadActual = Convert.ToInt32(fila.Cells["Cantidad"].Value);

            cantidadActual--;

            if (cantidadActual == 0)
            {
                dgvLista.Rows.RemoveAt(e.RowIndex);
            }
            else
            {
                fila.Cells["Cantidad"].Value = cantidadActual;
            }

            ActualizarExistencia(idProducto);
        }

        private void ActualizarExistencia(string idProducto)
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string updateSql = "UPDATE elastosystem_almacen SET Existencias = Existencias + 1 WHERE ID_Producto = @IDPRODUCTO";

                    using (MySqlCommand updateCommand = new MySqlCommand(updateSql, conn))
                    {
                        updateCommand.Parameters.AddWithValue("@IDPRODUCTO", idProducto);
                        updateCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR EXISTENCIAS: " + ex.Message);
                }
            }
        }
    }
}
