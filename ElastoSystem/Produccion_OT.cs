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
    public partial class Produccion_OT : Form
    {
        public string FolioOT { get; set; }
        public Produccion_OT()
        {
            InitializeComponent();
        }

        private void Produccion_OT_Load(object sender, EventArgs e)
        {
            lblOrdenTrabajo.Text = "ORDEN DE TRABAJO: " + FolioOT;

            CargarInfoOT();
        }

        private void CargarInfoOT()
        {
            string ot = FolioOT;

            if (string.IsNullOrWhiteSpace(ot))
            {
                MessageBox.Show("ERROR AL OBTENER ORDEN DE TRABAJO");
                return;
            }

            using (var conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM elastosystem_produccion_ot WHERE Folio = @FOLIO LIMIT 1";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FOLIO", ot);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dtpFechaInicio.Value = Convert.ToDateTime(reader["FechaInicio"].ToString());
                                dtpFechaFinal.Value = Convert.ToDateTime(reader["FechaTermino"].ToString());
                                lblAutorizo.Text = reader["Autorizo"].ToString();
                                cbTurno.Text = reader["Turno"].ToString();
                                txbLote.Text = reader["Lote"].ToString();
                                cbMolde.Items.Add(reader["Molde"].ToString());
                                cbMolde.SelectedIndex = 0;
                                txbCantidad.Text = reader["Cantidad"].ToString();
                                txbEspecificacion.Text = reader["Especificacion"].ToString();
                                txbArea.Text = reader["Area"].ToString();
                                txbNombreArea.Text = reader["NombreArea"].ToString();
                                cbMaquinas.Items.Add(reader["Maquina"].ToString());
                                cbMaquinas.SelectedIndex = 0;
                                txbSolicitudFabricacion.Text = reader["SF"].ToString();
                                txbObservaciones.Text = reader["Observaciones"].ToString();

                                if (txbEspecificacion.Text.Length > 0)
                                {
                                    btnVerEspecificacion.Visible = true;
                                }
                                else
                                {
                                    btnVerEspecificacion.Visible = false;
                                }

                                //CargarDesgloseOT();

                                //Calcular();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL OBTENER DATOS DE LA ORDEN DE TRABAJO: " + ex.Message);
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
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.Visible = false;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private byte[] ayudaVisualPdfAV;
        private void btnVerEspecificacion_Click(object sender, EventArgs e)
        {
            CargarAV();
        }

        private void CargarAV()
        {
            string nombreav = txbEspecificacion.Text;

            using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Archivo FROM elastosystem_produccion_av WHERE Nombre = @NOMBRE LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NOMBRE", nombreav);

                    object resultado = cmd.ExecuteScalar();

                    if(resultado != null && resultado != DBNull.Value)
                    {
                        ayudaVisualPdfAV = (byte[])resultado;
                        MostrarAV();
                    }
                    else
                    {
                        ayudaVisualPdfAV = null;
                        MessageBox.Show("NO SE ENCONTRO EL ARCHIVO ASOCIADO A LA AYUDA VISUAL");
                        return;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR AL OBTENER LA AYUDA VISUAL: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void MostrarAV()
        {
            if(ayudaVisualPdfAV != null)
            {
                string rutaTemporal = Path.Combine(Path.GetTempPath(), "tempAV.pdf");
                File.WriteAllBytes(rutaTemporal, ayudaVisualPdfAV);

                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = rutaTemporal,
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }
            else
            {
                MessageBox.Show("NO HAY ARCHIVO CARGADO PARA VISAULIZAR");
            }
        }
    }
}
