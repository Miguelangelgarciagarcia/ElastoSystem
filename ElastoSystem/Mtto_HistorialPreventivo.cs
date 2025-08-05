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
    public partial class Mtto_HistorialPreventivo : Form
    {
        public string ActivoSeleccionado { get; set; }
        public string TipoSeleccionado { get; set; }
        public Mtto_HistorialPreventivo()
        {
            InitializeComponent();
        }

        private void Mtto_HistorialPreventivo_Load(object sender, EventArgs e)
        {
            CargarHistorial();
            Revisar();
        }

        private void Revisar()
        {
            try
            {
                if(dgvHistorial.DataSource == null || dgvHistorial.Rows.Count == 0)
                {
                    MessageBox.Show("No hay historial para mostrar");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al revisar los datos: " + ex.Message);
                this.Close();
            }
        }

        private void CargarHistorial()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT Actividad, Inicio, Fin, Quien, Observaciones FROM elastosystem_mtto_preventivohistorial WHERE Estatus = 'FINALIZADA' AND Activo = @ACTIVO AND Tipo = @TIPO order by Fin DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ACTIVO", ActivoSeleccionado);
                    cmd.Parameters.AddWithValue("@TIPO", TipoSeleccionado);

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dgvHistorial.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR EL HISTORIAL: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
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

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.Visible = false;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncerrar_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
        }

        private void txbBuscador_TextChanged(object sender, EventArgs e)
        {
            Buscador();
        }

        private void Buscador()
        {
            try
            {
                string valorBusqueda = txbBuscador.Text;

                if (string.IsNullOrWhiteSpace(valorBusqueda))
                {
                    CargarHistorial();
                }
                else
                {
                    using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                    {
                        conn.Open();

                        string consulta = @"SELECT Actividad, Inicio, Fin, Quien, Observaciones
                                            FROM elastosystem_mtto_preventivohistorial
                                            WHERE Estatus = 'FINALIZADA'
                                            AND Activo = @ACTIVO
                                            AND Tipo = @TIPO
                                            AND (Actividad LIKE @ValorBusqueda OR Quien LIKE @ValorBusqueda)
                                            ORDER BY Fin DESC";

                        MySqlCommand cmd = new MySqlCommand(consulta, conn);
                        cmd.Parameters.AddWithValue("@ACTIVO", ActivoSeleccionado);
                        cmd.Parameters.AddWithValue("@TIPO", TipoSeleccionado);
                        cmd.Parameters.AddWithValue("@ValorBusqueda", "%" + valorBusqueda + "%");

                        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adaptador.Fill(dt);
                        dgvHistorial.DataSource = dt;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR AL BUSCAR: " + ex.Message);
            }
        }
    }
}
