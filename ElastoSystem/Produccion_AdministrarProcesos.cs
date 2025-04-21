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
    public partial class Produccion_AdministrarProcesos : Form
    {
        public Produccion_AdministrarProcesos()
        {
            InitializeComponent();
        }

        private void Produccion_AdministrarProcesos_Load(object sender, EventArgs e)
        {

        }

        private void CargarFamilias()
        {
            try
            {
                string query = "SELECT Familia FROM elastosystem_produccion_familia";
                MySqlDataAdapter adaptador = new MySqlDataAdapter(query, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dgvFamilias.DataSource = dt;
                dgvFamilias.ColumnHeadersVisible = false;
                dt.DefaultView.Sort = "Familia ASC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR FAMILIAS: " + ex.Message);
            }
        }

        private void CargarAreas()
        {
            try
            {
                string query = "SELECT Area, Nave FROM elastosystem_produccion_area";
                MySqlDataAdapter adaptador = new MySqlDataAdapter(query, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dgvAreas.DataSource = dt;
                dgvAreas.ColumnHeadersVisible = false;
                dt.DefaultView.Sort = "Area ASC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR AREAS: " + ex.Message);
            }
        }

        private void CargarHules()
        {
            try
            {
                string query = "SELECT Hule FROM elastosystem_produccion_hules";
                MySqlDataAdapter adaptador = new MySqlDataAdapter(query, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dgvHules.DataSource = dt;
                dgvHules.ColumnHeadersVisible = false;
                dt.DefaultView.Sort = "Hule ASC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR HULES: " + ex.Message);
            }
        }

        private void btnAgregarFamilias_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbFamilia.Text))
            {
                MessageBox.Show("Por favor, ingrese una familia.");
                return;
            }
            AgregarFamilia();
        }

        private void AgregarFamilia()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string check = "SELECT COUNT(*) FROM elastosystem_produccion_familia WHERE Familia = @FAMILIA";
                    MySqlCommand cmd = new MySqlCommand(check, conn);
                    cmd.Parameters.AddWithValue("@FAMILIA", txbFamilia.Text.Trim());

                    int familiaCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (familiaCount > 0)
                    {
                        MessageBox.Show("La familia ya existe.");
                        return;
                    }

                    string insertQuery = "INSERT INTO elastosystem_produccion_familia (Familia) VALUES (@FAMILIA)";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);

                    insertCmd.Parameters.AddWithValue("@FAMILIA", txbFamilia.Text.Trim());

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Familia agregada correctamente.");
                        txbFamilia.Clear();
                        CargarFamilias();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar la familia.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL AGREGAR FAMILIA A LA BASE DE DATOS: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txbFamilia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAgregarFamilias.PerformClick();
            }
        }

        private void btnAgregarAreas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbAreas.Text) || string.IsNullOrWhiteSpace(cbNaveAreas.Text))
            {
                MessageBox.Show("No puedes dejar las casillas vacia.");
                return;
            }
            AgregarAreas();
        }

        private void AgregarAreas()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string check = "SELECT COUNT(*) FROM elastosystem_produccion_area WHERE Area = @AREA";
                    MySqlCommand cmd = new MySqlCommand(check, conn);
                    cmd.Parameters.AddWithValue("@AREA", txbAreas.Text.Trim());

                    int areasCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (areasCount > 0)
                    {
                        MessageBox.Show("El área ya existe.");
                        return;
                    }

                    string insertQuery = "INSERT INTO elastosystem_produccion_area (Area, Nave) VALUES (@AREA, @NAVE)";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);

                    insertCmd.Parameters.AddWithValue("@AREA", txbAreas.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@NAVE", cbNaveAreas.Text.Trim());

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Área agregada correctamente.");
                        txbAreas.Clear();
                        CargarAreas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el área.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL AGREGAR AREA: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txbAreas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAgregarAreas.PerformClick();
            }
        }

        private void dgvFamilias_Click(object sender, EventArgs e)
        {

        }

        private void dgvFamilias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAreas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvFamilias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNuevoFamilias.Visible = true;
            btnEliminarFamilias.Visible = true;
            btnEditarFamilias.Visible = true;
            btnAgregarFamilias.Visible = false;

            txbFamilia.Clear();

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvFamilias.Rows[e.RowIndex];
                txbFamilia.Text = row.Cells[0].Value.ToString();
                txbFamiliaOriginal.Text = row.Cells[0].Value.ToString();
            }
        }

        private void dgvAreas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNuevoAreas.Visible = true;
            btnEliminarAreas.Visible = true;
            btnEditarAreas.Visible = true;
            btnAgregarAreas.Visible = false;

            txbAreas.Clear();
            cbNaveAreas.SelectedIndex = -1;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAreas.Rows[e.RowIndex];
                txbAreas.Text = row.Cells[0].Value.ToString();
                txbAreasOriginal.Text = row.Cells[0].Value.ToString();
                cbNaveAreas.Text = row.Cells[1].Value.ToString();
            }
        }

        private void btnNuevoFamilias_Click(object sender, EventArgs e)
        {
            btnNuevoFamilias.Visible = false;
            btnEliminarFamilias.Visible = false;
            btnEditarFamilias.Visible = false;
            btnAgregarFamilias.Visible = true;

            txbFamilia.Clear();
            txbFamiliaOriginal.Clear();

            CargarFamilias();
        }

        private void btnNuevoAreas_Click(object sender, EventArgs e)
        {
            btnNuevoAreas.Visible = false;
            btnEliminarAreas.Visible = false;
            btnEditarAreas.Visible = false;
            btnAgregarAreas.Visible = true;

            txbAreas.Clear();
            txbAreasOriginal.Clear();
            cbNaveAreas.SelectedIndex = -1;

            CargarAreas();
        }

        private void btnEditarFamilias_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbFamilia.Text))
            {
                MessageBox.Show("No puedes dejar la casilla vacia.");
                return;
            }
            ActualizarFamilia();
        }

        private void ActualizarFamilia()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM elastosystem_produccion_familia WHERE Familia = @NUEVA_FAMILIA AND Familia != @FAMILIA_ORIGINAL";

                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@NUEVA_FAMILIA", txbFamilia.Text.Trim());
                    checkCmd.Parameters.AddWithValue("@FAMILIA_ORIGINAL", txbFamiliaOriginal.Text.Trim());

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("La familia ya existe.");
                        return;
                    }

                    string updateQuery = "UPDATE elastosystem_produccion_familia SET Familia = @FAMILIA WHERE Familia = @FAMILIA_ORIGINAL";

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Parameters.AddWithValue("@FAMILIA", txbFamilia.Text.Trim());
                    cmd.Parameters.AddWithValue("@FAMILIA_ORIGINAL", txbFamiliaOriginal.Text.Trim());
                    cmd.Connection = conn;
                    cmd.CommandText = updateQuery;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Familia actualizada correctamente.");
                    btnNuevoFamilias.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR FAMILIA: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnEditarAreas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbAreas.Text) || string.IsNullOrWhiteSpace(cbNaveAreas.Text))
            {
                MessageBox.Show("No puedes dejar las casillas vacia.");
                return;
            }
            ActualizarArea();
        }

        private void ActualizarArea()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM elastosystem_produccion_area WHERE Area = @NUEVA_AREA AND Area != @AREA_ORIGINAL";

                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@NUEVA_AREA", txbAreas.Text.Trim());
                    checkCmd.Parameters.AddWithValue("@AREA_ORIGINAL", txbAreasOriginal.Text.Trim());

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("El área ya existe.");
                        return;
                    }

                    string updateQuery = "UPDATE elastosystem_produccion_area SET Area = @AREA, Nave = @NAVE WHERE Area = @AREA_ORIGINAL";

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Parameters.AddWithValue("@AREA", txbAreas.Text.Trim());
                    cmd.Parameters.AddWithValue("@NAVE", cbNaveAreas.Text.Trim());
                    cmd.Parameters.AddWithValue("@AREA_ORIGINAL", txbAreasOriginal.Text.Trim());
                    cmd.Connection = conn;
                    cmd.CommandText = updateQuery;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Área actualizada correctamente.");
                    btnNuevoAreas.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR AREA: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnEliminarFamilias_Click(object sender, EventArgs e)
        {
            EliminarFamilia();
        }

        private void EliminarFamilia()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string deletQuery = "DELETE FROM elastosystem_produccion_familia WHERE Familia = @FAMILIA";
                    MySqlCommand cmd = new MySqlCommand(deletQuery, conn);

                    cmd.Parameters.AddWithValue("@FAMILIA", txbFamiliaOriginal.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("FAMILIA ELIMINADA CORRECTAMENTE");
                        btnNuevoFamilias.PerformClick();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ELIMINAR FAMILIA: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnEliminarAreas_Click(object sender, EventArgs e)
        {
            EliminarArea();
        }
        private void EliminarArea()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM elastosystem_produccion_area WHERE Area = @AREA";
                    MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);

                    cmd.Parameters.AddWithValue("@AREA", txbAreasOriginal.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("AREA ELIMINADA CORRECTAMENTE");
                        btnNuevoAreas.PerformClick();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERRO AL ELIMINAR AREA: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txbFamilia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txbAreas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                CargarFamilias();
                CargarAreas();
                CargarHules();
            }
        }

        private void btnAgregarHules_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbHule.Text))
            {
                MessageBox.Show("Por favor, ingrese un hule.");
                return;
            }
            AgregarHule();
        }

        private void AgregarHule()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string check = "SELECT COUNT(*) FROM elastosystem_produccion_hules WHERE Hule = @HULE";
                    MySqlCommand cmd = new MySqlCommand(check, conn);
                    cmd.Parameters.AddWithValue("@HULE", txbHule.Text.Trim());
                    int huleCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (huleCount > 0)
                    {
                        MessageBox.Show("El hule ya existe.");
                        return;
                    }
                    string insertQuery = "INSERT INTO elastosystem_produccion_hules (Hule) VALUES (@HULE)";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@HULE", txbHule.Text.Trim());
                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Hule agregado correctamente.");
                        txbHule.Clear();
                        CargarHules();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el hule.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL AGREGAR EL HULE: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txbHule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAgregarHules.PerformClick();
            }
        }

        private void txbHule_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void dgvHules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNuevoHules.Visible = true;
            btnEliminarHules.Visible = true;
            btnEditarHules.Visible = true;
            btnAgregarHules.Visible = false;

            txbHule.Clear();

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHules.Rows[e.RowIndex];
                txbHule.Text = row.Cells[0].Value.ToString();
                txbHuleOriginal.Text = row.Cells[0].Value.ToString();
            }
        }

        private void btnNuevoHules_Click(object sender, EventArgs e)
        {
            btnNuevoHules.Visible = false;
            btnEliminarHules.Visible = false;
            btnEditarHules.Visible = false;
            btnAgregarHules.Visible = true;

            txbHule.Clear();
            txbHuleOriginal.Clear();

            CargarHules();
        }

        private void btnEditarHules_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbHule.Text))
            {
                MessageBox.Show("No puedes dejar la casilla vacia.");
                return;
            }
            ActualizarHule();
        }

        private void ActualizarHule()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM elastosystem_produccion_hules WHERE Hule = @NUEVO_HULE AND Hule != @HULE_ORIGINAL";

                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@NUEVO_HULE", txbHule.Text.Trim());
                    checkCmd.Parameters.AddWithValue("@HULE_ORIGINAL", txbHuleOriginal.Text.Trim());

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("El hule ya existe.");
                        return;
                    }

                    string updateQuery = "UPDATE elastosystem_produccion_hules SET Hule = @HULE WHERE Hule = @HULE_ORIGINAL";

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Parameters.AddWithValue("@HULE", txbHule.Text.Trim());
                    cmd.Parameters.AddWithValue("@HULE_ORIGINAL", txbHuleOriginal.Text.Trim());
                    cmd.Connection = conn;
                    cmd.CommandText = updateQuery;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Hule actualizado correctamente.");
                    btnNuevoHules.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR HULE: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void tabHojaRuta_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarHules_Click(object sender, EventArgs e)
        {
            EliminarHule();
        }

        private void EliminarHule()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM elastosystem_produccion_hules WHERE Hule = @HULE";
                    MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);

                    cmd.Parameters.AddWithValue("@HULE", txbHuleOriginal.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("HULE ELIMINADO CORRECTAMENTE");
                        btnNuevoHules.PerformClick();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR AL ELIMINAR HULE: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
