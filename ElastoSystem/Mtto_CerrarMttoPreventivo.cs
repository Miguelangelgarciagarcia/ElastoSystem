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
    public partial class Mtto_CerrarMttoPreventivo : Form
    {
        private Form formularioPadre;
        public Mtto_CerrarMttoPreventivo(int id, Form padre)
        {
            InitializeComponent();
            txbID.Text = id.ToString();
            formularioPadre = padre;
            CargarDatosMtto();
        }

        private void CargarDatosMtto()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Tipo, Activo, Actividad, Inicio FROM elastosystem_mtto_preventivohistorial WHERE ID = @ID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", int.Parse(txbID.Text));

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txbTipo.Text = reader["Tipo"].ToString();
                            txbActivo.Text = reader["Activo"].ToString();
                            txbActividad.Text = reader["Actividad"].ToString();
                            DateTime fechaInicio = Convert.ToDateTime(reader["Inicio"]);
                            txbFechaInicio.Text = fechaInicio.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron datos para el ID proporcionado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ENCONTRAR DATOS DEL ID: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            CargarDescripcion();
        }

        private void CargarDescripcion()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Descripcion, Periodicidad FROM elastosystem_mtto_actividadesxactivo WHERE Activo = @ACTIVO AND Actividad = @ACTIVIDAD AND Tipo = @TIPO";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ACTIVO", txbActivo.Text);
                    cmd.Parameters.AddWithValue("@ACTIVIDAD", txbActividad.Text);
                    cmd.Parameters.AddWithValue("@TIPO", txbTipo.Text);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txbDescripcionFin.Text = reader["Descripcion"].ToString();
                            txbPerio.Text = reader["Periodicidad"].ToString();
                        }
                        else
                        {
                            txbDescripcionFin.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ENCONTRAR LA DESCRIPCION: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void Mtto_CerrarMttoPreventivo_Load(object sender, EventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbRealizo.Text))
            {
                MessageBox.Show("DEBES DE AGREGAR QUIEN REALIZO");
            }
            else
            {
                FinalizarMtto();
            }
        }

        private void FinalizarMtto()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE elastosystem_mtto_preventivohistorial SET Fin = @FIN, Quien = @QUIEN, Observaciones = @OBSERVACIONES, Estatus = @ESTATUS WHERE ID = @ID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FIN", dtpFechaCierre.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@QUIEN", txbRealizo.Text);
                    cmd.Parameters.AddWithValue("@OBSERVACIONES", txbObservaciones.Text);
                    cmd.Parameters.AddWithValue("@ESTATUS", "FINALIZADA");
                    cmd.Parameters.AddWithValue("@ID", int.Parse(txbID.Text));
                    cmd.ExecuteNonQuery();
                    GenerarProximo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL FINALIZAR MANTENIMIENTO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void GenerarProximo()
        {
            int periodicidadDias = 0;
            int.TryParse(txbPerio.Text, out periodicidadDias);
            DateTime proximaFecha = dtpFechaCierre.Value.AddDays(periodicidadDias);

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO elastosystem_mtto_preventivohistorial (Tipo, Activo, Actividad, Inicio, Estatus) VALUES (@TIPO, @ACTIVO, @ACTIVIDAD, @INICIO, @ESTATUS)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TIPO", txbTipo.Text);
                    cmd.Parameters.AddWithValue("@ACTIVO", txbActivo.Text);
                    cmd.Parameters.AddWithValue("@ACTIVIDAD", txbActividad.Text);
                    cmd.Parameters.AddWithValue("@INICIO", proximaFecha.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@ESTATUS", "ACTIVO");
                    cmd.ExecuteNonQuery();

                    formularioPadre.Close();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL GENERAR EL PROXIMO MANTENIMIENTO: " + ex.Message);
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

        private void btncerrar_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
