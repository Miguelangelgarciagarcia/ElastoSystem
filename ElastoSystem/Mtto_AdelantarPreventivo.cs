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
    public partial class Mtto_AdelantarPreventivo : Form
    {
        public Mtto_AdelantarPreventivo()
        {
            InitializeComponent();
        }

        private void Mtto_AdelantarPreventivo_Load(object sender, EventArgs e)
        {
            CargarProximos();
        }

        private void CargarProximos()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT ID, Tipo, Activo, Actividad, Inicio FROM elastosystem_mtto_preventivohistorial WHERE Estatus = @ESTATUS ORDER BY Inicio";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ESTATUS", "ACTIVO");

                    MySqlDataAdapter adptador = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adptador.Fill(dt);
                    dgvProximos.DataSource = dt;
                    dgvProximos.Columns["ID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR PROXIMOS MANTENIMIENTOS: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void dgvProximos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idSeleccionado = Convert.ToInt32(dgvProximos.Rows[e.RowIndex].Cells["ID"].Value);

                Mtto_CerrarMttoPreventivo frmCerrar = new Mtto_CerrarMttoPreventivo(idSeleccionado, this);
                frmCerrar.ShowDialog();
            }
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void btncerrar_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.Visible = false;
        }
    }
}
