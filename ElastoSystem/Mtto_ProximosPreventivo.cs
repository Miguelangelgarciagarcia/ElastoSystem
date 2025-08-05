using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElastoSystem
{
    public partial class Mtto_ProximosPreventivo : Form
    {
        public string ActivoSelect { get; set; }
        public string TipoSelect { get; set; }
        public Mtto_ProximosPreventivo()
        {
            InitializeComponent();
        }

        private void Mtto_ProximosPreventivo_Load(object sender, EventArgs e)
        {
            CargarProximos();
            Revisar();
        }

        private void Revisar()
        {
            try
            {
                if(dgvProximos.DataSource == null || dgvProximos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay actividades proximas para mostrar");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al revisar los datos: " + ex.Message);
                this.Close();
            }
        }

        private void CargarProximos()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT Actividad, Inicio FROM elastosystem_mtto_preventivohistorial WHERE Estatus = 'ACTIVO' AND Activo = @ACTIVO AND Tipo = @TIPO ORDER BY Inicio DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ACTIVO", ActivoSelect);
                    cmd.Parameters.AddWithValue("@TIPO", TipoSelect);

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dgvProximos.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR PROXIMOS: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncerrar_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.Visible = false;
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
