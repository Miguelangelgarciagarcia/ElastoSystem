using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElastoSystem
{
    public partial class Mtto_Indicador : Form
    {
        public Mtto_Indicador()
        {
            InitializeComponent();
        }

        private void Mtto_Indicador_Load(object sender, EventArgs e)
        {
            CargarAnios();

            int mesActual = DateTime.Now.Month;
            if (cbMeses.Items.Count >= mesActual)
            {
                cbMeses.SelectedIndex = mesActual - 1;
            }

            if (cbAnio.SelectedIndex != -1 && cbMeses.SelectedIndex != -1)
            {
                CargarMaquinas();
            }
        }

        private void CargarAnios()
        {
            try
            {
                cbAnio.Items.Clear();

                int anioActual = DateTime.Now.Year;
                int anioBase = 2025;

                for (int year = anioActual; year >= anioBase; year--)
                {
                    cbAnio.Items.Add(year);
                }

                if (cbAnio.Items.Contains(anioActual))
                {
                    cbAnio.SelectedItem = anioActual;
                }
                else if (cbAnio.Items.Count > 0)
                {
                    cbAnio.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los años: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbAnio.Items.Clear();
                cbAnio.Items.Add(2025);
                cbAnio.SelectedIndex = 0;
            }
        }

        private void cbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAnio.SelectedIndex == -1 || cbMeses.SelectedIndex == -1)
            {
                dgvMaquinas.DataSource = null;
                return;
            }
            else
            {
                CargarMaquinas();
            }
        }

        private void cbMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAnio.SelectedIndex == -1 || cbMeses.SelectedIndex == -1)
            {
                dgvMaquinas.DataSource = null;
                return;
            }
            else
            {
                CargarMaquinas();
            }
        }

        private void CargarMaquinas()
        {
            int anioSeleccionado = Convert.ToInt32(cbAnio.SelectedItem);
            string mesSeleccionado = cbMeses.SelectedItem.ToString().ToUpper();

            int numeroMes = 0;
            switch (mesSeleccionado)
            {
                case "ENERO": numeroMes = 1; break;
                case "FEBRERO": numeroMes = 2; break;
                case "MARZO": numeroMes = 3; break;
                case "ABRIL": numeroMes = 4; break;
                case "MAYO": numeroMes = 5; break;
                case "JUNIO": numeroMes = 6; break;
                case "JULIO": numeroMes = 7; break;
                case "AGOSTO": numeroMes = 8; break;
                case "SEPTIEMBRE": numeroMes = 9; break;
                case "OCTUBRE": numeroMes = 10; break;
                case "NOVIEMBRE": numeroMes = 11; break;
                case "DICIEMBRE": numeroMes = 12; break;
                default:
                    MessageBox.Show("Mes no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            DateTime fechaInicio = new DateTime(anioSeleccionado, numeroMes, 1);
            DateTime fechaFin = fechaInicio.AddMonths(1).AddDays(-1);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            m.Nombre AS Maquina,
                            COUNT(p.ID) AS NoFallas
                        FROM elastosystem_mtto_inventariomaquinas m
                        LEFT JOIN elastosystem_produccion_paros p
                            ON m.ID = p.ID_Maquina
                            AND p.Codigo_Falla = 'F13'
                            AND p.Fecha >= @FECHAINICIO
                            AND p.Fecha <= @FECHAFIN
                        WHERE m.Indicador = 1
                        GROUP BY m.ID, m.Nombre
                        ORDER BY NoFallas DESC, m.Nombre ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FECHAINICIO", fechaInicio.Date);
                        cmd.Parameters.AddWithValue("@FECHAFIN", fechaFin.Date);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            dgvMaquinas.DataSource = dt;

                            if (dgvMaquinas.Columns.Count > 0)
                            {
                                dgvMaquinas.Columns["Maquina"].HeaderText = "Máquina";
                                dgvMaquinas.Columns["NoFallas"].HeaderText = "No. Fallas";
                                dgvMaquinas.Columns["Maquina"].Width = 300;
                                dgvMaquinas.Columns["NoFallas"].Width = 120;
                                dgvMaquinas.Columns["NoFallas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                        }
                    }
                }
                CargarRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR LAS MÁQUINAS:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvMaquinas.DataSource = null;
            }
        }

        private void CargarRegistros()
        {
            if (cbAnio.SelectedIndex == -1 || cbMeses.SelectedIndex == -1)
            {
                dgvRegistros.DataSource = null;
                return;
            }

            int anioSeleccionado = Convert.ToInt32(cbAnio.SelectedItem);
            string mesSeleccionado = cbMeses.SelectedItem.ToString().ToUpper();
            int numeroMes = 0;
            switch (mesSeleccionado)
            {
                case "ENERO": numeroMes = 1; break;
                case "FEBRERO": numeroMes = 2; break;
                case "MARZO": numeroMes = 3; break;
                case "ABRIL": numeroMes = 4; break;
                case "MAYO": numeroMes = 5; break;
                case "JUNIO": numeroMes = 6; break;
                case "JULIO": numeroMes = 7; break;
                case "AGOSTO": numeroMes = 8; break;
                case "SEPTIEMBRE": numeroMes = 9; break;
                case "OCTUBRE": numeroMes = 10; break;
                case "NOVIEMBRE": numeroMes = 11; break;
                case "DICIEMBRE": numeroMes = 12; break;
                default:
                    MessageBox.Show("Mes no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            DateTime fechaInicio = new DateTime(anioSeleccionado, numeroMes, 1);
            DateTime fechaFin = fechaInicio.AddMonths(1).AddDays(-1);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = @"
                        SELECT
                            p.Nave,
                            m.Nombre AS Maquina,
                            DATE_FORMAT(p.Hora_Inicio, '%H:%i') AS HoraInicio,
                            DATE_FORMAT(p.Hora_Fin, '%H:%i') AS HoraFin,
                            p.Observaciones,
                            p.Fecha
                        FROM elastosystem_produccion_paros p
                        INNER JOIN elastosystem_mtto_inventariomaquinas m ON p.ID_Maquina = m.ID
                        WHERE p.Fecha >= @FECHAINICIO
                            AND p.Fecha <= @FECHAFIN
                            AND p.Codigo_Falla = 'F13'
                        ORDER BY p.Fecha ASC, p.Hora_Inicio ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FECHAINICIO", fechaInicio.Date);
                        cmd.Parameters.AddWithValue("@FECHAFin", fechaFin.Date);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            dgvRegistros.DataSource = dt;

                            if (dgvRegistros.Columns.Count > 0)
                            {
                                dgvRegistros.Columns["Maquina"].HeaderText = "Máquina";
                                dgvRegistros.Columns["HoraInicio"].HeaderText = "Hora Inicio";
                                dgvRegistros.Columns["HoraFin"].HeaderText = "Hora Fin";
                                dgvRegistros.Columns["Nave"].Width = 80;
                                dgvRegistros.Columns["Maquina"].Width = 200;
                                dgvRegistros.Columns["HoraInicio"].Width = 100;
                                dgvRegistros.Columns["HoraFin"].Width = 100;
                                dgvRegistros.Columns["Observaciones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            }
                        }
                    }
                }
                CalcularIndicador();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR LOS REGISTROS DE MANTENIMIENTO:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvRegistros.DataSource = null;
            }
        }

        private void CalcularIndicador()
        {
            if (dgvMaquinas.DataSource == null || dgvMaquinas.Rows.Count == 0)
            {
                txbTotalFallas.Text = "0";
                txbIndicador.Text = "0.00";
                txbIndicador.ForeColor = Color.Green;
                return;
            }

            int totalFallas = 0;
            foreach (DataGridViewRow row in dgvMaquinas.Rows)
            {
                if (row.Cells["NoFallas"].Value != null)
                {
                    totalFallas += Convert.ToInt32(row.Cells["NoFallas"].Value);
                }
            }
            txbTotalFallas.Text = totalFallas.ToString();

            int totalMaquinas = dgvMaquinas.Rows.Count;

            int anio = Convert.ToInt32(cbAnio.SelectedItem);
            int mes = 0;
            string mesTexto = cbMeses.SelectedItem.ToString().ToUpper();
            switch (mesTexto)
            {
                case "ENERO": mes = 1; break;
                case "FEBRERO": mes = 2; break;
                case "MARZO": mes = 3; break;
                case "ABRIL": mes = 4; break;
                case "MAYO": mes = 5; break;
                case "JUNIO": mes = 6; break;
                case "JULIO": mes = 7; break;
                case "AGOSTO": mes = 8; break;
                case "SEPTIEMBRE": mes = 9; break;
                case "OCTUBRE": mes = 10; break;
                case "NOVIEMBRE": mes = 11; break;
                case "DICIEMBRE": mes = 12; break;
            }

            int diasDelMes = DateTime.DaysInMonth(anio, mes);

            double denominador = (double)totalMaquinas * diasDelMes;
            double indicador = denominador > 0 ? totalFallas / denominador : 0;
            indicador = indicador * 100;

            txbIndicador.Text = indicador.ToString("0.00");

            if (indicador > 2)
            {
                txbIndicador.BackColor = Color.Red;
                txbIndicador.ForeColor = Color.White;
            }
            else
            {
                txbIndicador.BackColor = Color.Green;
                txbIndicador.ForeColor = Color.White;
            }
        }

        private void dgvMaquinas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvMaquinas.ClearSelection();
        }

        private void dgvRegistros_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvRegistros.ClearSelection();
        }
    }
}
