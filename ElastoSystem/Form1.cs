using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Isopoh.Cryptography.Argon2;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace ElastoSystem
{
    public partial class Form1 : Form
    {
        

        public void PruebaConexionMySql()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            try
            {
                mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Conectarse a la Base de Datos de Elastotecnica");
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
        public void login()
        {

            tbusuario.TabIndex = 0;
            tbpassword.TabIndex = 1;

            string query = "SELECT ID, Usuario, Paswd, Estatus FROM elastosystem_login WHERE Usuario = @Usuario";
            MySqlConnection databaseConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            commandDatabase.Parameters.AddWithValue("@Usuario", tbusuario.Text);
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string id = reader["ID"].ToString();
                        string storedHashedPassword = reader["Paswd"].ToString();
                        string estatus = reader["Estatus"].ToString();

                        if ( estatus != "ACTIVO")
                        {
                            MessageBox.Show("El usuario no está activo. Contacte al administrador");
                            return;
                        }

                        if(IsPasswordValid(tbpassword.Text, storedHashedPassword))
                        {
                            VariablesGlobales.Usuario = tbusuario.Text;

                            MessageBox.Show("Bienvenido " + tbusuario.Text);
                            MenuPrincipal menuPrincipal = new();
                            menuPrincipal.TextoLabelID = id;
                            menuPrincipal.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("ERROR en Usuario o contraseña, vulve a intentar");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("ERROR en Usuario o Contraseña, vuelve a intentarlo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                databaseConnection.Close();
            }
        }

        private bool IsPasswordValid(string password, string storedHashedPassword)
        {
            return Argon2.Verify(storedHashedPassword, password);
        }

        public Form1()
        {
            InitializeComponent();

            PruebaConexionMySql();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConectarSAE();
            MandarALlamarIP();
            if (VariablesGlobales.IPServidor == "10.120.1.104")
            {
                panel3.BackColor = Color.Red;
                lblModoPrueba.Visible = true;
            }
            else
            {

            }

        }
        private void ConectarSAE()
        {
            try
            {
                FbConnectionStringBuilder cadena = new FbConnectionStringBuilder();
                cadena.UserID = "SYSDBA";
                cadena.Password = "masterkey";
                cadena.Database = VariablesGlobales.DireccionBDSAE;
                cadena.DataSource = VariablesGlobales.IPSAE;
                cadena.Port = 3050;

                using(FbConnection conexion = new FbConnection(cadena.ConnectionString))
                {
                    conexion.Open();
                    conexion.Close();
                    CargarExistenciaSAE();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR DE CONEXION CON LA BASE DE DATOS DE ASPEL: " + ex.Message);
            }
        }
        private void CargarExistenciaSAE()
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

                bindingSource1.DataSource = datos.Tables[0];
                dgvProductosSAE.DataSource = bindingSource1;

                ActualizarBDProductosSAE();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR LOS PRODUCTOS DE ASPEL SAE: "+ex.Message);
            }
        }

        private void ActualizarBDProductosSAE()
        {
            try
            {
                using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
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

                            if(count > 0)
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
                CargarDescripciones();
                VariablesGlobales.UltimaActualizacion();

            }
            catch(Exception ex)
            {
                MessageBox.Show("HUBO UN ERROR AL ACTUALIZAR EXISTENCIAS DE SAE EN BD: " + ex.Message);
            }
        }

        private void CargarDescripciones()
        {
            try
            {
                FbConnectionStringBuilder cadenaFB = new FbConnectionStringBuilder();
                cadenaFB.UserID = "SYSDBA";
                cadenaFB.Password = "masterkey";
                cadenaFB.Database = VariablesGlobales.DireccionBDSAE;
                cadenaFB.DataSource = VariablesGlobales.IPSAE;
                cadenaFB.Port = 3050;

                using (FbConnection connFB = new FbConnection(cadenaFB.ConnectionString))
                {
                    connFB.Open();
                    string sqlFB = "SELECT CVE_ART, DESCR FROM inve01";
                    FbCommand cmdFB = new FbCommand(sqlFB, connFB);
                    FbDataReader reader = cmdFB.ExecuteReader();

                    using(MySqlConnection connMySQL = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                    {
                        connMySQL.Open();

                        while (reader.Read())
                        {
                            string cveArt = reader["CVE_ART"].ToString().Trim();
                            string descrSAE = reader["DESCR"].ToString().Trim();

                            string selectQuery = "SELECT Descripcion FROM elastosystem_sae_productos WHERE Producto = @CVE_ART";
                            MySqlCommand selectCmd = new MySqlCommand(selectQuery, connMySQL);
                            selectCmd.Parameters.AddWithValue("@CVE_ART", cveArt);
                            object result = selectCmd.ExecuteScalar();

                            if(result != null)
                            {
                                string descrMySQL = result.ToString().Trim();

                                if(descrSAE != descrMySQL)
                                {
                                    string updateQuery = "UPDATE elastosystem_sae_productos SET Descripcion = @DESCR WHERE Producto = @CVE_ART";
                                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, connMySQL);
                                    updateCmd.Parameters.AddWithValue("@DESCR", descrSAE);
                                    updateCmd.Parameters.AddWithValue("@CVE_ART", cveArt);
                                    updateCmd.ExecuteNonQuery();
                                }
                            }
                        }
                        connMySQL.Close();
                    }

                    reader.Close();
                    connFB.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR DESCRIPCIONES DE PRODUCTOS DE SAE: " + ex.Message);
            }
        }

        

        private void MandarALlamarIP()
        {
            lblIP.Text = VariablesGlobales.IPServidor;
        }

        //CODIGO PARA MOVER PANEL SUPERIOR
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void tbpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbusuario_Enter(object sender, EventArgs e)
        {
            if (tbusuario.Text == "Usuario")
            {
                tbusuario.Text = "";
                tbusuario.ForeColor = Color.DimGray;
            }
        }

        private void tbusuario_Leave(object sender, EventArgs e)
        {
            if (tbusuario.Text == "")
            {
                tbusuario.Text = "Usuario";
                tbusuario.ForeColor = Color.DarkGray;
            }
        }

        private void tbpassword_Enter(object sender, EventArgs e)
        {
            tbpassword.UseSystemPasswordChar = true;

            if (tbpassword.Text == "Contraseña")
            {
                tbpassword.Text = "";
                tbpassword.ForeColor = Color.DimGray;
            }
        }

        private void tbpassword_Leave(object sender, EventArgs e)
        {
            if (tbpassword.Text == "")
            {
                tbpassword.Text = "Contraseña";
                tbpassword.ForeColor = Color.DarkGray;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.facebook.com/elastotecnica/?locale=es_LA",
                UseShellExecute = true
            });
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "http://www.youtube.com/@elastotecnicasadecv1154",
                UseShellExecute = true
            });
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.instagram.com/elastotecnica/?hl=es",
                UseShellExecute = true
            });
        }

        private void tbpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                login();
            }
        }

        private void tbusuario_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlmacenTemporal frm2 = new AlmacenTemporal();
            frm2.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Contabilidad_DescargaMasiva temporal = new();
            temporal.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbpassword_MouseClick(object sender, MouseEventArgs e)
        {
            tbpassword.UseSystemPasswordChar = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tbusuario_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btncerrar_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.Visible = false;
        }

        private void btnminimizar_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.Visible = false;
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}