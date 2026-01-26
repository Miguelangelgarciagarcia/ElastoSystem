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
    public partial class Mtto_ActividadesDia : Form
    {
        public Mtto_ActividadesDia()
        {
            InitializeComponent();
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

        private void Mtto_ActividadesDia_Load(object sender, EventArgs e)
        {
            lblFecha.Text = UserControlDays.static_day + "/" + Mtto_ManttoPreventivo.static_month.ToString() + "/" + Mtto_ManttoPreventivo.static_year.ToString();
            CargarPendientes();
            CargarFinalizados();
            Revisar();
            dgvPendientes.ContextMenuStrip = cmsFinalizarPendientes;
        }

        private void CargarPendientes()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT ID, Tipo, Activo, Actividad, Inicio FROM elastosystem_mtto_preventivohistorial WHERE Estatus = @ESTATUS AND Inicio = @INICIO";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ESTATUS", "ACTIVO");

                    int dia = int.Parse(UserControlDays.static_day);
                    int mes = Mtto_ManttoPreventivo.static_month;
                    int anio = Mtto_ManttoPreventivo.static_year;
                    DateTime fecha = new DateTime(anio, mes, dia);

                    string fechaMySQL = fecha.ToString("yyyy-MM-dd");
                    cmd.Parameters.AddWithValue("@INICIO", fechaMySQL);

                    MySqlDataAdapter adptador = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adptador.Fill(dt);
                    dgvPendientes.DataSource = dt;
                    dgvPendientes.Columns["ID"].Visible = false;
                    dgvPendientes.Columns["Inicio"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR PENDIENTES DEL DIA: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void CargarFinalizados()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT Tipo, Activo, Actividad, Fin, Quien, Observaciones FROM elastosystem_mtto_preventivohistorial WHERE Estatus = @ESTATUS AND Inicio = @INICIO";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ESTATUS", "FINALIZADA");

                    int dia = int.Parse(UserControlDays.static_day);
                    int mes = Mtto_ManttoPreventivo.static_month;
                    int anio = Mtto_ManttoPreventivo.static_year;
                    DateTime fecha = new DateTime(anio, mes, dia);

                    string fechaMySQL = fecha.ToString("yyyy-MM-dd");
                    cmd.Parameters.AddWithValue("@INICIO", fechaMySQL);

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);
                    dgvFinalizados.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR ACTIVIDADES FINALIZADAS DEL DIA: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void Revisar()
        {
            bool pendientesVacio = dgvPendientes.Rows.Count == 0 || (dgvPendientes.Rows.Count == 1 && dgvPendientes.Rows[0].IsNewRow);
            bool finalizadosVacio = dgvFinalizados.Rows.Count == 0 || (dgvFinalizados.Rows.Count == 1 && dgvFinalizados.Rows[0].IsNewRow);

            if (pendientesVacio && finalizadosVacio)
            {
                this.Close();
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

        private void dgvPendientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPendientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idSeleccionado = Convert.ToInt32(dgvPendientes.Rows[e.RowIndex].Cells["ID"].Value);

                Mtto_CerrarMttoPreventivo frmCerrar = new Mtto_CerrarMttoPreventivo(idSeleccionado, this);
                frmCerrar.ShowDialog();
            }
        }

        private void cmsFinalizarPendientes_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dgvPendientes.SelectedRows.Count <= 1)
            {
                e.Cancel = true;
            }
        }

        public DataGridView PendientesGrid => dgvPendientes;

        private void tsmiFinalizarTodos_Click(object sender, EventArgs e)
        {
            if (dgvPendientes.SelectedRows.Count <= 1) return;

            int cantidad = dgvPendientes.SelectedRows.Count;

            DialogResult respuesta = MessageBox.Show(
                $"¿Estás seguro que deseas FINALIZAR los {cantidad} pendientes seleccionados?",
                "Confirmar finalización múltiple",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            var seleccionadas = dgvPendientes.SelectedRows
                .Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .ToList();

            Mtto_CerrarMultiple_Preventivo frmCerrarMultiple = new Mtto_CerrarMultiple_Preventivo(seleccionadas, this);

            frmCerrarMultiple.ShowDialog();

            if (frmCerrarMultiple.DialogResult == DialogResult.OK)
            {
                CargarPendientes();
                CargarFinalizados();
                Revisar();
            }
        }
    }
}
