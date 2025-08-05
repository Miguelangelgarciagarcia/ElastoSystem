using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElastoSystem
{
    public partial class Mtto_ManttoPreventivo : Form
    {
        int month, year;
        public static int static_month, static_year;
        public Mtto_ManttoPreventivo()
        {
            InitializeComponent();
        }

        private void Mtto_ManttoPreventivo_Load(object sender, EventArgs e)
        {
            displaDays();
            dtpFechaInicio.MinDate = DateTime.Now;
        }

        private void displaDays()
        {
            dayContainer.Controls.Clear();
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lblDate.Text = monthname + " " + year;

            static_month = month;
            static_year = year;

            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                dayContainer.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                dayContainer.Controls.Add(ucdays);
            }
        }

        private void tabCalendarioActividades_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();
            month++;

            if (month > 12)
            {
                month = 1;
                year++;
            }

            static_month = month;
            static_year = year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lblDate.Text = monthname + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                dayContainer.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                dayContainer.Controls.Add(ucdays);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();
            month--;

            if (month < 1)
            {
                month = 12;
                year--;
            }

            static_month = month;
            static_year = year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lblDate.Text = monthname + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                dayContainer.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                dayContainer.Controls.Add(ucdays);
            }
        }

        private void cbActividadesDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarActividades();
            btnNuevaActividad.Visible = false;
            btnActualizarActividad.Visible = false;
            btnAgregarActividad.Visible = true;
            txbActividad.Clear();
        }

        private void CargarActividades()
        {
            if (cbActividadesDe.SelectedIndex == -1)
            {
                dgvActividades.DataSource = null;
                return;
            }
            else
            {
                dgvActividades.DataSource = null;
                string actividadesde = cbActividadesDe.SelectedItem.ToString();
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT * FROM elastosystem_mtto_actividades WHERE ActividadDe = @ACTIVIDADDE ORDER BY Actividad";

                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ACTIVIDADDE", actividadesde);

                        MySqlDataAdapter adpatador = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adpatador.Fill(dt);

                        dgvActividades.DataSource = dt;

                        dgvActividades.Columns["ID"].Visible = false;
                        dgvActividades.Columns["ActividadDe"].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR AL CARGAR ACTIVIDADES: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void btnAgregarActividad_Click(object sender, EventArgs e)
        {
            if (cbActividadesDe.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txbActividad.Text))
            {
                MessageBox.Show("No puedes dejar campos vacios.");
                return;
            }

            AgregarActividades();
        }

        private void AgregarActividades()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM elastosystem_mtto_actividades WHERE ActividadDe = @ACTIVIDADDE AND Actividad = @ACTIVIDAD";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@ACTIVIDADDE", cbActividadesDe.SelectedItem.ToString());
                    checkCmd.Parameters.AddWithValue("@ACTIVIDAD", txbActividad.Text.Trim());

                    int existe = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (existe > 0)
                    {
                        MessageBox.Show("La actividad ya existe.");
                        return;
                    }

                    string insertQuery = "INSERT INTO elastosystem_mtto_actividades (ActividadDe, Actividad) VALUES (@ACTIVIDADDE, @ACTIVIDAD)";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);

                    insertCmd.Parameters.AddWithValue("@ACTIVIDADDE", cbActividadesDe.SelectedItem.ToString());
                    insertCmd.Parameters.AddWithValue("@ACTIVIDAD", txbActividad.Text.Trim());

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        CargarActividades();
                        txbActividad.Clear();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar la actividad.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL AGREGAR LA ACTIVIDAD: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnAgregarInfrestructura_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbInfrestructura.Text))
            {
                MessageBox.Show("No puedes dejar campos vacios.");
                return;
            }
            AgregarInfrestructura();
        }

        private void AgregarInfrestructura()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM elastosystem_mtto_infrestructura WHERE Infrestructura = @INFRESTRUCTURA";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@INFRESTRUCTURA", txbInfrestructura.Text.Trim());

                    int existe = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (existe > 0)
                    {
                        MessageBox.Show("La infrestructura ya existe.");
                        return;
                    }

                    string insertQuery = "INSERT INTO elastosystem_mtto_infrestructura (Infrestructura) VALUES (@INFRAESTRUCTURA)";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);

                    insertCmd.Parameters.AddWithValue("@INFRAESTRUCTURA", txbInfrestructura.Text.Trim());

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        txbInfrestructura.Clear();
                        CargarInfrestructuras();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar la infraestructura.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL AGREGAR INFRAESTRUCTURA: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void CargarInfrestructuras()
        {
            try
            {
                string query = "SELECT * FROM elastosystem_mtto_infrestructura ORDER BY Infrestructura";
                MySqlDataAdapter adptador = new MySqlDataAdapter(query, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                adptador.Fill(dt);
                dgvInfrestructuras.DataSource = dt;
                dgvInfrestructuras.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR INFRAESTRUCTURAS: " + ex.Message);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                displaDays();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                btnHistorial.Visible = false;
                btnProximos.Visible = false;
                chbMaquina.Checked = false;
                chbInfrestructura.Checked = false;
                btnNueva.Visible = false;
                btnEliminarActividad.Visible = false;
                btnActualizar.Visible = false;
                cbActivo.SelectedIndex = -1;
                cbActivo.Items.Clear();
                cbActividad.SelectedIndex = -1;
                cbActividad.Items.Clear();
                txbDescripcion.Clear();
                txbPeriodicidad.Clear();
                dgvMantenimientos.DataSource = null;
                txbActividadE.Clear();
                txbActividadE.Visible = false;
                chbMaquina.Enabled = true;
                chbInfrestructura.Enabled = true;
                dtpFechaInicio.Value = DateTime.Now;
                btnAsignarActividad.Visible = true;
                lblFechaInicio.Visible = true;
                dtpFechaInicio.Visible = true;
                cbActividad.Enabled = true;
                cbActivo.Enabled = true;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                CargarInfrestructuras();
                cbActividadesDe.SelectedIndex = -1;
                txbActividad.Clear();
                txbIDActividad.Clear();
                txbActividadOriginal.Clear();
                txbInfrestructura.Clear();
                txbIDInfrestructura.Clear();
                txbInfrestructuraOriginal.Clear();
                btnActualizarActividad.Visible = false;
                btnActualizarInfrestructura.Visible = false;
                btnAgregarActividad.Visible = true;
                btnAgregarInfrestructura.Visible = true;
            }
        }

        private void dgvActividades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNuevaActividad.Visible = true;
            btnActualizarActividad.Visible = true;
            btnAgregarActividad.Visible = false;

            txbActividad.Clear();

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvActividades.Rows[e.RowIndex];
                txbIDActividad.Text = row.Cells["ID"].Value.ToString();
                txbActividad.Text = row.Cells["Actividad"].Value.ToString();
                txbActividadOriginal.Text = row.Cells["Actividad"].Value.ToString();
            }
        }

        private void dgvInfrestructuras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNuevaInfrestructura.Visible = true;
            btnActualizarInfrestructura.Visible = true;
            btnAgregarInfrestructura.Visible = false;

            txbInfrestructura.Clear();

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvInfrestructuras.Rows[e.RowIndex];
                txbIDInfrestructura.Text = row.Cells["ID"].Value.ToString();
                txbInfrestructura.Text = row.Cells["Infrestructura"].Value.ToString();
                txbInfrestructuraOriginal.Text = row.Cells["Infrestructura"].Value.ToString();
            }
        }

        private void btnNuevaActividad_Click(object sender, EventArgs e)
        {
            btnNuevaActividad.Visible = false;
            btnActualizarActividad.Visible = false;
            btnAgregarActividad.Visible = true;
            txbActividad.Clear();
            txbActividadOriginal.Clear();
            txbIDActividad.Clear();
            CargarActividades();
        }

        private void btnNuevaInfrestructura_Click(object sender, EventArgs e)
        {
            btnNuevaInfrestructura.Visible = false;
            btnActualizarInfrestructura.Visible = false;
            btnAgregarInfrestructura.Visible = true;
            txbInfrestructura.Clear();
            txbInfrestructuraOriginal.Clear();
            txbIDInfrestructura.Clear();
            CargarInfrestructuras();
        }

        private void btnActualizarActividad_Click(object sender, EventArgs e)
        {
            if (cbActividadesDe.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txbActividad.Text))
            {
                MessageBox.Show("No puedes dejar campos vacios.");
                return;
            }
            ActualizarActividad();
        }

        private void ActualizarActividad()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM elastosystem_mtto_actividades WHERE Actividad = @NUEVAACTIVIDAD AND ActividadDe = @ACTIVIDADDE AND Actividad != @ACTIVIDAD_ORIGINAL";

                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@NUEVAACTIVIDAD", txbActividad.Text.Trim());
                    checkCmd.Parameters.AddWithValue("@ACTIVIDADDE", cbActividadesDe.SelectedItem.ToString());
                    checkCmd.Parameters.AddWithValue("@ACTIVIDAD_ORIGINAL", txbActividadOriginal.Text.Trim());

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("La actividad ya existe.");
                        return;
                    }

                    string updateQuery = "UPDATE elastosystem_mtto_actividades SET Actividad = @NUEVAACTIVIDAD WHERE ID = @ID";

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Parameters.AddWithValue("@NUEVAACTIVIDAD", txbActividad.Text.Trim());
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txbIDActividad.Text.Trim()));
                    cmd.Connection = conn;
                    cmd.CommandText = updateQuery;
                    cmd.ExecuteNonQuery();

                    string selectActividadDeQuery = "SELECT ActividadDe FROM elastosystem_mtto_actividades WHERE ID = @ID";
                    MySqlCommand selectActividadDeCmd = new MySqlCommand(selectActividadDeQuery, conn);
                    selectActividadDeCmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txbIDActividad.Text.Trim()));

                    string actividadDe = "";
                    using (MySqlDataReader reader = selectActividadDeCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            actividadDe = reader["ActividadDe"].ToString();
                        }
                    }

                    string tipoMapeado = "";
                    if (actividadDe == "MAQUINAS")
                    {
                        tipoMapeado = "MAQUINA";
                    }
                    else if (actividadDe == "INFRESTRUCTURAS")
                    {
                        tipoMapeado = "INFRESTRUCTURA";
                    }
                    else
                    {
                        tipoMapeado = actividadDe;
                    }

                    string updateActividadesXActivoQuery = "UPDATE elastosystem_mtto_actividadesxactivo SET Actividad = @NUEVAACTIVIDAD WHERE Tipo = @TIPO AND Actividad = @ACTIVIDAD_ORIGINAL";
                    MySqlCommand updateActividadesXActivoCmd = new MySqlCommand(updateActividadesXActivoQuery, conn);
                    updateActividadesXActivoCmd.Parameters.AddWithValue("@NUEVAACTIVIDAD", txbActividad.Text.Trim());
                    updateActividadesXActivoCmd.Parameters.AddWithValue("@TIPO", tipoMapeado);
                    updateActividadesXActivoCmd.Parameters.AddWithValue("@ACTIVIDAD_ORIGINAL", txbActividadOriginal.Text.Trim());
                    int actividadesXActivoActualizadas = updateActividadesXActivoCmd.ExecuteNonQuery();

                    string updateHistorialQuery = "UPDATE elastosystem_mtto_preventivohistorial SET Actividad = @NUEVAACTIVIDAD WHERE Tipo = @TIPO AND Actividad = @ACTIVIDAD_ORIGINAL";
                    MySqlCommand updateHistorialCmd = new MySqlCommand(updateHistorialQuery, conn);
                    updateHistorialCmd.Parameters.AddWithValue("@NUEVAACTIVIDAD", txbActividad.Text.Trim());
                    updateHistorialCmd.Parameters.AddWithValue("@TIPO", tipoMapeado);
                    updateHistorialCmd.Parameters.AddWithValue("@ACTIVIDAD_ORIGINAL", txbActividadOriginal.Text.Trim());
                    int historialActualizado = updateHistorialCmd.ExecuteNonQuery();

                    btnNuevaActividad.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR ACTIVIDAD: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnActualizarInfrestructura_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbInfrestructura.Text))
            {
                MessageBox.Show("No puedes dejar campos vacios.");
                return;
            }
            ActualizarInfrestructura();
        }

        private void ActualizarInfrestructura()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM elastosystem_mtto_infrestructura WHERE Infrestructura = @NUEVAINFRESTRUCTURA AND INFRESTRUCTURA != @INFRESTRUCTURA_ORIGINAL";

                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@NUEVAINFRESTRUCTURA", txbInfrestructura.Text.Trim());
                    checkCmd.Parameters.AddWithValue("@INFRESTRUCTURA_ORIGINAL", txbInfrestructuraOriginal.Text.Trim());

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("La infrestructura ya existe.");
                        return;
                    }

                    string updateQuery = "UPDATE elastosystem_mtto_infrestructura SET Infrestructura = @NUEVAINFRESTRUCTURA WHERE ID = @ID";

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Parameters.AddWithValue("@NUEVAINFRESTRUCTURA", txbInfrestructura.Text.Trim());
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txbIDInfrestructura.Text.Trim()));
                    cmd.Connection = conn;
                    cmd.CommandText = updateQuery;
                    cmd.ExecuteNonQuery();

                    string updateActividadesQuery = "UPDATE elastosystem_mtto_actividadesxactivo SET Activo = @NUEVAINFRESTRUCTURA WHERE Tipo = @TIPO AND Activo = @INFRESTRUCTURA_ORIGINAL";
                    MySqlCommand updateActividadesCmd = new MySqlCommand(updateActividadesQuery, conn);
                    updateActividadesCmd.Parameters.AddWithValue("@NUEVAINFRESTRUCTURA", txbInfrestructura.Text.Trim());
                    updateActividadesCmd.Parameters.AddWithValue("@TIPO", "INFRESTRUCTURA");
                    updateActividadesCmd.Parameters.AddWithValue("@INFRESTRUCTURA_ORIGINAL", txbInfrestructuraOriginal.Text.Trim());
                    int actividadesActualizadas = updateActividadesCmd.ExecuteNonQuery();

                    string updateHistorialQuery = "UPDATE elastosystem_mtto_preventivohistorial SET Activo = @NUEVAINFRESTRUCTURA WHERE Tipo = @TIPO AND Activo = @INFRESTRUCTURA_ORIGINAL";
                    MySqlCommand updateHistorialCmd = new MySqlCommand(updateHistorialQuery, conn);
                    updateHistorialCmd.Parameters.AddWithValue("@NUEVAINFRESTRUCTURA", txbInfrestructura.Text.Trim());
                    updateHistorialCmd.Parameters.AddWithValue("@TIPO", "INFRESTRUCTURA");
                    updateHistorialCmd.Parameters.AddWithValue("@INFRESTRUCTURA_ORIGINAL", txbInfrestructuraOriginal.Text.Trim());
                    int historialActualizado = updateHistorialCmd.ExecuteNonQuery();

                    btnNuevaInfrestructura.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR ACTIVIDAD: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void chbMaquina_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMaquina.Checked == true)
            {
                chbInfrestructura.Checked = false;
                Limpiar();
                MandarALlamarMaquinas();
                btnProximos.Visible = false;
                btnHistorial.Visible = false;
            }
        }

        private void MandarALlamarMaquinas()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Nombre FROM elastosystem_mtto_inventariomaquinas ORDER BY Nombre";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbActivo.Items.Add(reader["Nombre"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL LLAMAR A LAS MAQUINAS: " + ex.Message);
                return;
            }
            finally
            {
                conn.Close();
            }
        }

        private void chbInfrestructura_CheckedChanged(object sender, EventArgs e)
        {
            if (chbInfrestructura.Checked == true)
            {
                chbMaquina.Checked = false;
                Limpiar();
                MandarALlamarInfrestructura();
                btnProximos.Visible = false;
                btnHistorial.Visible = false;
            }
        }

        private void MandarALlamarInfrestructura()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Infrestructura FROM elastosystem_mtto_infrestructura ORDER BY Infrestructura";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbActivo.Items.Add(reader["Infrestructura"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL LLAMAR A LAS INFRAESTRUCTURAS: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Limpiar()
        {
            cbActivo.Items.Clear();
            cbActividad.Items.Clear();
            txbDescripcion.Clear();
            txbPeriodicidad.Clear();

            dtpFechaInicio.Value = DateTime.Now;

            btnNueva.Visible = false;
            btnActualizar.Visible = false;
            btnEliminarActividad.Visible = false;
            btnAsignarActividad.Visible = true;

            dgvMantenimientos.DataSource = null;
        }

        private void cbActivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbActivo.SelectedIndex != -1)
            {
                cbActividad.Items.Clear();
                dtpFechaInicio.Value = DateTime.Now;
                txbDescripcion.Clear();
                txbPeriodicidad.Clear();
                btnHistorial.Visible = true;
                btnProximos.Visible = true;
                if (chbMaquina.Checked == true)
                {
                    using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                    {
                        try
                        {
                            conn.Open();
                            string query = @"
                                SELECT Actividad
                                FROM elastosystem_mtto_actividades
                                WHERE ActividadDe = 'MAQUINAS'
                                AND Actividad NOT IN (
                                    SELECT Actividad
                                    FROM elastosystem_mtto_actividadesxactivo
                                    WHERE Tipo = 'MAQUINA'
                                    AND Activo = @ACTIVO
                                )
                                ORDER BY Actividad";

                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ACTIVO", cbActivo.SelectedItem.ToString());

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    cbActividad.Items.Add(reader["Actividad"].ToString());
                                }
                            }
                            CargarActividadesAsignadas();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR AL CARGAR ACTIVIDADES: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
                else
                {
                    using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                    {
                        try
                        {
                            conn.Open();
                            string query = @"
                                SELECT Actividad
                                FROM elastosystem_mtto_actividades
                                WHERE ActividadDe = 'INFRESTRUCTURAS'
                                AND Actividad NOT IN (
                                    SELECT Actividad
                                    FROM elastosystem_mtto_actividadesxactivo
                                    WHERE Tipo = 'INFRESTRUCTURA'
                                    AND Activo = @ACTIVO
                                )
                                ORDER BY Actividad";

                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ACTIVO", cbActivo.SelectedItem.ToString());

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    cbActividad.Items.Add(reader["Actividad"].ToString());
                                }
                            }
                            CargarActividadesAsignadas();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR AL CARGAR ACTIVIDADES: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }

        private void CargarActividadesAsignadas()
        {
            dgvMantenimientos.DataSource = null;
            string tipo = chbMaquina.Checked ? "MAQUINA" : (chbInfrestructura.Checked ? "INFRESTRUCTURA" : "");
            if (cbActivo.SelectedIndex == -1 || string.IsNullOrEmpty(tipo))
            {
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT * FROM elastosystem_mtto_actividadesxactivo WHERE Activo = @ACTIVO AND Tipo = @TIPO ORDER BY Actividad";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ACTIVO", cbActivo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@TIPO", tipo);

                    MySqlDataAdapter adptador = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adptador.Fill(dt);
                    dgvMantenimientos.DataSource = dt;
                    dgvMantenimientos.Columns["ID"].Visible = false;
                    dgvMantenimientos.Columns["Tipo"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR ACTIVIDADES ASIGNADAS: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txbPeriodicidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            VariablesGlobales.ValidarNumeroEntero(e, txbPeriodicidad);
        }

        private void btnAsignarActividad_Click(object sender, EventArgs e)
        {
            if (cbActivo.SelectedIndex == -1 || cbActividad.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txbPeriodicidad.Text))
            {
                MessageBox.Show("No puedes dejar campos vacios.");
                return;
            }

            if (!int.TryParse(txbPeriodicidad.Text, out int periodicidad) || periodicidad <= 0)
            {
                MessageBox.Show("La periodicidad no puede ser 0.");
                return;
            }

            AsignarActividadEquipo();
        }

        private void AsignarActividadEquipo()
        {
            string tipo = chbMaquina.Checked ? "MAQUINA" : (chbInfrestructura.Checked ? "INFRESTRUCTURA" : "");
            if (string.IsNullOrEmpty(tipo))
            {
                MessageBox.Show("Debes seleccionar un tipo de activo (Maquina o Infrestructura).");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string checkQuery = @"SELECT COUNT(*) FROM elastosystem_mtto_actividadesxactivo
                                            WHERE Activo = @ACTIVO AND Actividad = @ACTIVIDAD AND TIPO = @TIPO";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@ACTIVO", cbActivo.SelectedItem.ToString());
                    checkCmd.Parameters.AddWithValue("@ACTIVIDAD", cbActividad.SelectedItem.ToString());
                    checkCmd.Parameters.AddWithValue("@TIPO", tipo);

                    int existe = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (existe > 0)
                    {
                        MessageBox.Show("La actividad ya está asignada a este activo.");
                        return;
                    }

                    string insertQuery = @"INSERT INTO elastosystem_mtto_actividadesxactivo
                                            (Tipo, Activo, Actividad, Descripcion, Periodicidad)
                                            VALUES (@TIPO, @ACTIVO, @ACTIVIDAD, @DESCRIPCION, @PERIODICIDAD)";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@TIPO", tipo);
                    insertCmd.Parameters.AddWithValue("@ACTIVO", cbActivo.SelectedItem.ToString());
                    insertCmd.Parameters.AddWithValue("@ACTIVIDAD", cbActividad.SelectedItem.ToString());
                    insertCmd.Parameters.AddWithValue("@DESCRIPCION", txbDescripcion.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@PERIODICIDAD", txbPeriodicidad.Text.Trim());

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        IniciarActividad();
                        MessageBox.Show("Actividad asignada correctamente al activo");
                        cbActivo.SelectedIndex = -1;
                        cbActividad.SelectedIndex = -1;
                        txbDescripcion.Clear();
                        txbPeriodicidad.Clear();
                        dgvMantenimientos.DataSource = null;
                        btnProximos.Visible = false;
                        btnHistorial.Visible = false;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo asignar la actividad al activo.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL AGREGAR ACTIVIDAD: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void IniciarActividad()
        {
            string tipo = chbMaquina.Checked ? "MAQUINA" : (chbInfrestructura.Checked ? "INFRESTRUCTURA" : "");
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string insertQuery = @"INSERT INTO elastosystem_mtto_preventivohistorial
                                            (Tipo, Activo, Actividad, Inicio, Estatus)
                                            VALUES(@TIPO, @ACTIVO, @ACTIVIDAD, @INICIO, @ESTATUS)";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@TIPO", tipo);
                    insertCmd.Parameters.AddWithValue("@ACTIVO", cbActivo.SelectedItem.ToString());
                    insertCmd.Parameters.AddWithValue("@ACTIVIDAD", cbActividad.SelectedItem.ToString());
                    insertCmd.Parameters.AddWithValue("@INICIO", dtpFechaInicio.Value.Date);
                    insertCmd.Parameters.AddWithValue("@ESTATUS", "ACTIVO");

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No se agrego el inicio de la actividad");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL INICIAR ACTIVIDAD: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void dgvMantenimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNueva.Visible = true;
            btnAsignarActividad.Visible = false;
            btnActualizar.Visible = true;
            btnEliminarActividad.Visible = true;
            txbActividadE.Visible = true;
            chbMaquina.Enabled = false;
            chbInfrestructura.Enabled = false;
            cbActivo.Enabled = false;
            cbActividad.Enabled = false;
            dtpFechaInicio.Visible = false;
            lblFechaInicio.Visible = false;

            txbDescripcion.Clear();
            txbPeriodicidad.Clear();
            txbID.Clear();

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMantenimientos.Rows[e.RowIndex];
                txbID.Text = row.Cells["ID"].Value.ToString();
                txbActividadE.Text = row.Cells["Actividad"].Value.ToString();
                txbDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                txbPeriodicidad.Text = row.Cells["Periodicidad"].Value.ToString();
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            txbActividadE.Clear();
            txbDescripcion.Clear();
            txbPeriodicidad.Clear();
            txbID.Clear();
            cbActividad.SelectedIndex = -1;
            txbActividadE.Visible = false;

            dtpFechaInicio.Visible = true;
            lblFechaInicio.Visible = true;

            btnEliminarActividad.Visible = false;
            btnNueva.Visible = false;
            btnAsignarActividad.Visible = true;
            btnActualizar.Visible = false;
            chbMaquina.Enabled = true;
            chbInfrestructura.Enabled = true;
            cbActivo.Enabled = true;
            cbActividad.Enabled = true;
        }

        private void btnEliminarActividad_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string selectQuery = "SELECT Tipo, Activo, Actividad FROM elastosystem_mtto_actividadesxactivo WHERE ID = @ID";
                    MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn);
                    selectCmd.Parameters.AddWithValue("@ID", txbID.Text);

                    string tipo = "";
                    string activo = "";
                    string actividad = "";

                    using (MySqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tipo = reader["Tipo"].ToString();
                            activo = reader["Activo"].ToString();
                            actividad = reader["Actividad"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontro la actividad a eliminar");
                            return;
                        }
                    }
                    conn.Close();
                    conn.Open();

                    string deleteHistorialQuery = "DELETE FROM elastosystem_mtto_preventivohistorial WHERE Tipo = @TIPO AND Activo = @ACTIVO AND Actividad = @ACTIVIDAD AND Estatus = @ESTATUS";
                    MySqlCommand deleteHistorialCmd = new MySqlCommand(deleteHistorialQuery, conn);
                    deleteHistorialCmd.Parameters.AddWithValue("@TIPO", tipo);
                    deleteHistorialCmd.Parameters.AddWithValue("@ACTIVO", activo);
                    deleteHistorialCmd.Parameters.AddWithValue("@ACTIVIDAD", actividad);
                    deleteHistorialCmd.Parameters.AddWithValue("@ESTATUS", "ACTIVO");

                    int historialRowsAffected = deleteHistorialCmd.ExecuteNonQuery();

                    string deleteQuery = "DELETE FROM elastosystem_mtto_actividadesxactivo WHERE ID = @ID";
                    MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);

                    cmd.Parameters.AddWithValue("@ID", txbID.Text);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("ACTIVIDAD ELIMINADA CORRECTAMENTE");
                        btnNueva.PerformClick();
                        cbActivo.SelectedIndex = -1;
                        dgvMantenimientos.DataSource = null;
                        btnProximos.Visible = false;
                        btnHistorial.Visible = false;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ELIMINAR LA ACTIVIDAD DEL ACTIVO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbPeriodicidad.Text))
            {
                MessageBox.Show("No puedes dejar campos vacios.");
                return;
            }

            if (!int.TryParse(txbPeriodicidad.Text, out int periodicidad) || periodicidad <= 0)
            {
                MessageBox.Show("La periodicidad no puede ser 0.");
                return;
            }

            int periodicidadAnterior = 0;
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string selectQuery = "SELECT Periodicidad FROM elastosystem_mtto_actividadesxactivo WHERE ID = @ID";
                    MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn);
                    selectCmd.Parameters.AddWithValue("@ID", txbID.Text);
                    object result = selectCmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out periodicidadAnterior))
                    {
                        if (periodicidadAnterior != periodicidad)
                        {
                            ActualizarUltimoRegistro();
                        }
                    }

                    string updateQuery = "UPDATE elastosystem_mtto_actividadesxactivo SET Descripcion = @DESCRIPCION , Periodicidad = @PERIODICIDAD WHERE ID = @ID";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Parameters.AddWithValue("@DESCRIPCION", txbDescripcion.Text);
                    cmd.Parameters.AddWithValue("@PERIODICIDAD", txbPeriodicidad.Text);
                    cmd.Parameters.AddWithValue("@ID", txbID.Text);
                    cmd.Connection = conn;
                    cmd.CommandText = updateQuery;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("ACTIVIDAD ACTUALIZADA CORRECTAMENTE");
                    btnNueva.PerformClick();
                    cbActivo.SelectedIndex = -1;
                    dgvMantenimientos.DataSource = null;
                    btnHistorial.Visible = false;
                    btnProximos.Visible = false;
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void ActualizarUltimoRegistro()
        {

        }

        private void cbActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Now;
            txbDescripcion.Clear();
            txbPeriodicidad.Clear();
        }

        private void btnProximos_Click(object sender, EventArgs e)
        {
            try
            {
                string activoSeleccionado = cbActivo.SelectedItem.ToString();

                string tipo = "";
                if (chbMaquina.Checked)
                {
                    tipo = "MAQUINA";
                }
                else
                {
                    tipo = "INFRESTRUCTURA";
                }

                Mtto_ProximosPreventivo formProximos = new Mtto_ProximosPreventivo();

                formProximos.ActivoSelect = activoSeleccionado;
                formProximos.TipoSelect = tipo;

                formProximos.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ABRIR PROXIMOS: " + ex.Message);
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                string activoSeleccionado = cbActivo.SelectedItem.ToString();

                string tipo = "";
                if (chbMaquina.Checked)
                {
                    tipo = "MAQUINA";
                }
                else
                {
                    tipo = "INFRESTRUCTURA";
                }

                Mtto_HistorialPreventivo formHistorial = new Mtto_HistorialPreventivo();

                formHistorial.ActivoSeleccionado = activoSeleccionado;
                formHistorial.TipoSeleccionado = tipo;

                formHistorial.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ABRIR HISTORIAL: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            Mtto_ConsultasPreventivo formHistorial = new Mtto_ConsultasPreventivo();
            formHistorial.ShowDialog();
        }
    }
}
