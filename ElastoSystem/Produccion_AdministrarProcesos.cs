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
using System.IO;
using System.Diagnostics;

namespace ElastoSystem
{
    public partial class Produccion_AdministrarProcesos : Form
    {
        public Produccion_AdministrarProcesos()
        {
            InitializeComponent();
        }

        bool status = false;
        private void Produccion_AdministrarProcesos_Load(object sender, EventArgs e)
        {
            LimpiarHojaRuta();
            HRCargarFamilias();
            HRCargarAreas();
            HRCargarHules();
        }

        private void CargarFamilias()
        {
            try
            {
                string query = "SELECT Familia FROM elastosystem_produccion_familia WHERE Estatus = 'Activa'";
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
            CargarFamiliaAV();
        }

        private void AgregarFamilia()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string check = "SELECT Estatus FROM elastosystem_produccion_familia WHERE Familia = @FAMILIA";
                    MySqlCommand cmd = new MySqlCommand(check, conn);
                    cmd.Parameters.AddWithValue("@FAMILIA", txbFamilia.Text.Trim());

                    object result = cmd.ExecuteScalar();

                    if(result != null)
                    {
                        string estatus = result.ToString();
                        if(estatus == "Activa")
                        {
                            MessageBox.Show("La familia ya existe.");
                        }
                        else
                        {
                            Produccion_ActivarFamilia activarFamiliaForm = new Produccion_ActivarFamilia();
                            DialogResult resultForm = activarFamiliaForm.ShowDialog();

                            if(resultForm == DialogResult.OK)
                            {
                                ActivarFamilia();
                                
                                txbFamilia.Clear();
                                txbFamiliaOriginal.Clear();
                                CargarFamilias();
                                CargarFamiliaAV();
                            }
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO elastosystem_produccion_familia (Familia, Estatus) VALUES (@FAMILIA, 'Activa')";
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

        private void ActivarFamilia()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string updateQuery = "UPDATE elastosystem_produccion_familia SET Estatus = 'Activa' WHERE Familia = @FAMILIA";

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Parameters.AddWithValue("@FAMILIA", txbFamilia.Text.Trim());
                    cmd.Connection = conn;
                    cmd.CommandText = updateQuery;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Familia reactivada correctamente.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR AL RECATIVAR FAMILIA: " + ex.Message);
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
            CargarFamiliaAV();
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

                    ActualizarTodoRegistroFamilia();

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

        private void ActualizarTodoRegistroFamilia()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string familiaOriginal = txbFamiliaOriginal.Text.Trim();
                    string nuevaFamilia = txbFamilia.Text.Trim();

                    List<string> tablas = new List<string>
                    {
                        "elastosystem_sae_productos",
                        "elastosystem_produccion_encabezado",
                        "elastosystem_produccion_hoja_producto",
                        "elastosystem_produccion_hoja_ruta",
                        "elastosystem_produccion_av"
                    };

                    foreach (string tabla in tablas)
                    {
                        string updateQuery = $"UPDATE {tabla} SET Familia = @NUEVA_FAMILIA WHERE Familia = @FAMILIA_ORIGINAL";

                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@NUEVA_FAMILIA", nuevaFamilia);
                            cmd.Parameters.AddWithValue("@FAMILIA_ORIGINAL", familiaOriginal);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    CargarFamiliaAV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR TODOS LOS REGISTROS DONDE SE ENCONTRO LA FAMILIA: " + ex.Message);
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

                    ActualizarTodasLasAreas();

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

        private void ActualizarTodasLasAreas()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string areaOriginal = txbAreasOriginal.Text.Trim();
                    string nuevaArea = txbAreas.Text.Trim();
                    string nuevaNave = cbNaveAreas.Text.Trim();

                    List<string> tablas = new List<string>
                    {
                        "elastosystem_produccion_hoja_producto",
                        "elastosystem_produccion_hoja_ruta"
                    };

                    foreach (string tabla in tablas)
                    {
                        string updateQuery = $"UPDATE {tabla} SET Area = @NUEVA_AREA, Nave = @NUEVA_NAVE WHERE Area = @AREA_ORIGINAL";

                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@NUEVA_AREA", nuevaArea);
                            cmd.Parameters.AddWithValue("@NUEVA_NAVE", nuevaNave);
                            cmd.Parameters.AddWithValue("@AREA_ORIGINAL", areaOriginal);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR TODOS LOS REGISTROS DONDE SE ENCONTRO EL AREA: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnEliminarFamilias_Click(object sender, EventArgs e)
        {

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
            if (tabControl1.SelectedIndex == 0)
            {
                LimpiarHojaRuta();
                HRCargarFamilias();
                HRCargarAreas();
                HRCargarHules();
                cbAV.SelectedIndex = -1;
                btnVerAV.Visible = false;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                LimpiarCamposEncabezado();
                CargarFamiliasAdmin();
                CargarEncabezados();
            }
            if (tabControl1.SelectedIndex == 2)
            {
                CargarFamiliasRelacion();
                CargarProductosRelacion();
                CargarHojasRuta();
                txbFamiliaOrig.Clear();
                txbProducto.Clear();
                txbBuscador.Clear();
                txbBuscadorHR.Clear();
            }
            if (tabControl1.SelectedIndex == 3)
            {
                CargarFamilias();
                CargarAreas();
                CargarHules();
                CargarFamiliaAV();
                dgvAV.DataSource = null;
            }
        }

        private void CargarFamiliaAV()
        {
            cbFamiliaAyV.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Familia FROM elastosystem_produccion_familia WHERE Estatus = 'Activa' ORDER BY Familia ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string familia = reader["Familia"].ToString();
                        cbFamiliaAyV.Items.Add(familia);
                    }

                    cbFamiliaAyV.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR FAMILIAS DE AYUDA VISUAL: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void CargarHojasRuta()
        {
            string query = "SELECT * FROM elastosystem_produccion_hoja_producto ORDER BY Producto ASC, NoOperacion ASC";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(query, VariablesGlobales.ConexionBDElastotecnica);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dgvHojasRuta.DataSource = dt;
            dgvHojasRuta.Columns["ID"].Visible = false;
            dgvHojasRuta.Columns["Nave"].Width = 70;
            dgvHojasRuta.Columns["NoOperacion"].Width = 100;
            dgvHojasRuta.Columns["CantidadUnidad"].HeaderText = "C/U";
            dgvHojasRuta.Columns["CantidadUnidad"].Width = 40;
        }

        private void CargarFamiliasRelacion()
        {
            cbFamiliaRelacion.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Familia FROM elastosystem_produccion_familia WHERE Estatus = 'Activa' ORDER BY Familia ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string familia = reader["Familia"].ToString();
                        cbFamiliaRelacion.Items.Add(familia);
                    }
                    cbFamiliaRelacion.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR FAMILIAS: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void CargarProductosRelacion()
        {
            string tabla = "SELECT Producto, Familia FROM elastosystem_sae_productos ORDER BY Producto";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dgvProductosFamilias.DataSource = dt;
        }

        private void CargarEncabezados()
        {
            string query = @"SELECT e.* 
                             FROM elastosystem_produccion_encabezado e
                             JOIN elastosystem_produccion_familia f ON e.Familia = f.Familia
                             WHERE f.Estatus = 'Activa'";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(query, VariablesGlobales.ConexionBDElastotecnica);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dgvEncabezados.DataSource = dt;
            dgvEncabezados.Columns["ID"].Visible = false;
            dgvEncabezados.Columns["Imagen"].Visible = false;
        }

        private void CargarFamiliasAdmin()
        {
            cbFamiliaAdministrar.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT Familia
                        FROM elastosystem_produccion_familia
                        WHERE Estatus = 'Activa'
                        ORDER BY Familia ASC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string familia = reader["Familia"].ToString();
                        cbFamiliaAdministrar.Items.Add(familia);
                    }

                    cbFamiliaAdministrar.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR FAMILIAS: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void HRCargarFamilias()
        {
            cbFamilia.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Familia FROM elastosystem_produccion_familia WHERE Estatus = 'Activa' ORDER BY Familia ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string familia = reader["Familia"].ToString();
                        cbFamilia.Items.Add(familia);
                    }

                    cbFamilia.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR FAMILIAS: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void LimpiarHojaRuta()
        {
            cbFamilia.SelectedIndex = -1;
            txbNoOperacion.Clear();
            cbArea.SelectedIndex = -1;
            txbNave.Clear();
            txbDescripcion.Clear();
            txbTipoMaquina.Clear();
            txbPreparacion.Clear();
            txbTiempoPreparacion.Clear();
            txbTiempoOperacion.Clear();
            txbInsumos.Clear();
            chbCritico.Checked = false;
            dgvHojaRuta.DataSource = null;
            pbCampos.Visible = false;
            lblCamposObligatorios.Visible = false;
            pbNoOperacion.Visible = false;
            pbArea.Visible = false;
            pbNave.Visible = false;
            pbDescripcion.Visible = false;
        }

        private void HRCargarAreas()
        {
            cbArea.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Area FROM elastosystem_produccion_area ORDER BY Area ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string area = reader["Area"].ToString();
                        cbArea.Items.Add(area);
                    }

                    cbArea.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR AREAS: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void HRCargarHules()
        {
            cbHule.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Hule FROM elastosystem_produccion_hules ORDER BY Hule ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string hule = reader["Hule"].ToString();
                        cbHule.Items.Add(hule);
                    }

                    cbHule.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR HULES: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
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

                    ActualizarGeneralHules();

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

        private void ActualizarGeneralHules()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string huleOriginal = txbHuleOriginal.Text.Trim();
                    string nuevoHule = txbHule.Text.Trim();

                    string updateMaterialQuery = @"
                        UPDATE elastosystem_produccion_encabezado
                        SET Material = REPLACE(Material, @HULE_ORIGINAL, @NUEVO_HULE)
                        WHERE Material LIKE CONCAT('%', @HULE_ORIGINAL, '%')";

                    using (MySqlCommand cmdMaterial = new MySqlCommand(updateMaterialQuery, conn))
                    {
                        cmdMaterial.Parameters.AddWithValue("@HULE_ORIGINAL", huleOriginal);
                        cmdMaterial.Parameters.AddWithValue("@NUEVO_HULE", nuevoHule);
                        cmdMaterial.ExecuteNonQuery();
                    }

                    string updateInsumosQuery = @"
                        UPDATE elastosystem_produccion_hoja_ruta
                        SET Insumos = REPLACE(Insumos, @HULE_ORIGINAL, @NUEVO_HULE)
                        WHERE Insumos LIKE CONCAT('%', @HULE_ORIGINAL, '%')";

                    using (MySqlCommand cmdInsumos = new MySqlCommand(updateInsumosQuery, conn))
                    {
                        cmdInsumos.Parameters.AddWithValue("@HULE_ORIGINAL", huleOriginal);
                        cmdInsumos.Parameters.AddWithValue("@NUEVO_HULE", nuevoHule);
                        cmdInsumos.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR HULES EN TODOS LOS REGISTROS: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            //elastosystem_produccion_encabezado Material
            //elastosystem_produccion_hoja_ruta Insumos
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
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ELIMINAR HULE: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbArea.SelectedIndex != -1)
            {
                string areaSeleccionada = cbArea.SelectedItem.ToString();
                ObtenerNaveDeArea(areaSeleccionada);
            }
        }

        private void ObtenerNaveDeArea(string areaSeleccionada)
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Nave FROM elastosystem_produccion_area WHERE Area = @AREA LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AREA", areaSeleccionada);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        txbNave.Text = result.ToString();
                    }
                    else
                    {
                        txbNave.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL OBTENER NAVE DE AREA: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void cbFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFamilia.SelectedIndex != -1)
            {
                txbID.Clear();
                txbNoOperacion.Clear();
                cbArea.SelectedIndex = -1;
                txbNave.Clear();
                txbDescripcion.Clear();
                txbTipoMaquina.Clear();
                txbPreparacion.Clear();
                txbTiempoPreparacion.Clear();
                txbTiempoOperacion.Clear();
                txbInsumos.Clear();
                chbCritico.Checked = false;
                dgvHojaRuta.DataSource = null;
                cbHule.SelectedIndex = -1;
                cbAV.SelectedIndex = -1;

                MandarALlamarHojaRuta();
                btnExportarPDF.Visible = true;
                btnAgregarProceso.Visible = true;
                btnNuevo.Visible = false;
                btnEliminarProceso.Visible = false;
                btnActualizarProceso.Visible = false;

                lblCamposObligatorios.Visible = false;
                pbCampos.Visible = false;
                pbNoOperacion.Visible = false;
                pbArea.Visible = false;
                pbNave.Visible = false;
                pbDescripcion.Visible = false;

                CargarAyudasVisuales();
            }
        }

        private void CargarAyudasVisuales()
        {
            cbAV.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Nombre FROM elastosystem_produccion_av WHERE Familia = @FAMILIA ORDER BY Nombre ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FAMILIA", cbFamilia.SelectedItem.ToString());

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string nombreAV = reader["Nombre"].ToString();
                        cbAV.Items.Add(nombreAV);
                    }

                    cbAV.SelectedIndex = -1;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR AYUDAS VISUALES: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        private void MandarALlamarHojaRuta()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM elastosystem_produccion_hoja_ruta WHERE Familia = @FAMILIA ORDER BY NoOperacion ASC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FAMILIA", cbFamilia.SelectedItem.ToString());

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable tablaHojaRuta = new DataTable();
                    adaptador.Fill(tablaHojaRuta);

                    dgvHojaRuta.DataSource = tablaHojaRuta;

                    dgvHojaRuta.Columns["ID"].Visible = false;
                    dgvHojaRuta.Columns["Familia"].Visible = false;
                    dgvHojaRuta.Columns["NoOperacion"].HeaderText = "Operación";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR HOJA DE RUTA: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnAgregarProceso_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbNoOperacion.Text) || string.IsNullOrWhiteSpace(cbArea.Text) || string.IsNullOrWhiteSpace(txbNave.Text) || string.IsNullOrWhiteSpace(txbDescripcion.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios.");
                lblCamposObligatorios.Visible = true; pbCampos.Visible = true; pbNoOperacion.Visible = true; pbArea.Visible = true; pbNave.Visible = true; pbDescripcion.Visible = true;
                return;
            }
            lblCamposObligatorios.Visible = false; pbCampos.Visible = false; pbNoOperacion.Visible = false; pbArea.Visible = false; pbNave.Visible = false; pbDescripcion.Visible = false;
            AgregarProceso();

        }

        private void txbNoOperacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void AgregarProceso()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string check = "SELECT COUNT(*) FROM elastosystem_produccion_hoja_ruta WHERE NoOperacion = @NO_OPERACION AND Familia = @FAMILIA";
                    MySqlCommand cmd = new MySqlCommand(check, conn);
                    cmd.Parameters.AddWithValue("@NO_OPERACION", txbNoOperacion.Text.Trim());
                    cmd.Parameters.AddWithValue("@FAMILIA", cbFamilia.SelectedItem.ToString());

                    int procesoCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (procesoCount > 0)
                    {
                        MessageBox.Show("El Número de proceso ya existe.");
                        return;
                    }

                    string hule = cbHule.Text.Trim();
                    string insumos = txbInsumos.Text.Trim();
                    string insumosFinal = "";

                    if (!string.IsNullOrWhiteSpace(hule))
                    {
                        insumosFinal = hule + " //";
                        if (!string.IsNullOrWhiteSpace(insumos))
                        {
                            insumosFinal += " " + insumos;
                        }
                    }
                    else
                    {
                        insumosFinal = insumos;
                    }

                    string insertQuery = "INSERT INTO elastosystem_produccion_hoja_ruta (Familia, NoOperacion, Area, Nave, Descripcion, TipoMaquina, Preparacion, TiempoPreparacion, TiempoOperacion, Insumos, Critico, AyudaVisual) VALUES (@FAMILIA, @NO_OPERACION, @AREA, @NAVE, @DESCRIPCION, @TIPOMAQUINA, @PREPARACION, @TIEMPO_PREPARACION, @TIEMPO_OPERACION, @INSUMOS, @CRITICO, @AYUDAVISUAL)";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);

                    insertCmd.Parameters.AddWithValue("@FAMILIA", cbFamilia.SelectedItem.ToString());
                    insertCmd.Parameters.AddWithValue("@NO_OPERACION", txbNoOperacion.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@AREA", cbArea.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@NAVE", txbNave.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@DESCRIPCION", txbDescripcion.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@TIPOMAQUINA", txbTipoMaquina.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@PREPARACION", txbPreparacion.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@TIEMPO_PREPARACION", txbTiempoPreparacion.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@TIEMPO_OPERACION", txbTiempoOperacion.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@INSUMOS", insumosFinal);
                    insertCmd.Parameters.AddWithValue("@CRITICO", chbCritico.Checked ? 1 : 0);
                    insertCmd.Parameters.AddWithValue("@AYUDAVISUAL", cbAV.Text.Trim());

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        SincronizarHojaProductoDesdeHojaRuta(cbFamilia.SelectedItem.ToString());

                        MandarALlamarHojaRuta();
                        RevisarHule();

                        txbNoOperacion.Clear();
                        cbArea.SelectedIndex = -1;
                        cbAV.SelectedIndex = -1;
                        txbNave.Clear();
                        txbDescripcion.Clear();
                        txbTipoMaquina.Clear();
                        txbPreparacion.Clear();
                        txbTiempoPreparacion.Clear();
                        txbTiempoOperacion.Clear();
                        txbInsumos.Clear();
                        chbCritico.Checked = false;
                        cbHule.SelectedIndex = -1;
                        btnExportarPDF.Visible = true;
                        btnAgregarProceso.Visible = true;
                        btnVerAV.Visible = false;


                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el proceso.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL AGREGAR PROCESO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void SincronizarHojaProductoDesdeHojaRuta(string familia)
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    List<string> productos = new List<string>();
                    string queryProductos = "SELECT Producto FROM elastosystem_sae_productos WHERE Familia = @FAMILIA";

                    using (MySqlCommand cmdProductos = new MySqlCommand(queryProductos, conn))
                    {
                        cmdProductos.Parameters.AddWithValue("@FAMILIA", familia);
                        using (var reader = cmdProductos.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                productos.Add(reader.GetString("Producto"));
                            }
                        }
                    }

                    if (productos.Count == 0)
                        return;


                    var procesos = new List<Dictionary<string, object>>();
                    string queryProcesos = "SELECT * FROM elastosystem_produccion_hoja_ruta WHERE Familia = @FAMILIA";
                    using (MySqlCommand cmdProcesos = new MySqlCommand(queryProcesos, conn))
                    {
                        cmdProcesos.Parameters.AddWithValue("@FAMILIA", familia);
                        using (var reader = cmdProcesos.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var proceso = new Dictionary<string, object>()
                                {
                                    ["NoOperacion"] = reader["NoOperacion"],
                                    ["Nave"] = reader["Nave"],
                                    ["Area"] = reader["Area"],
                                    ["Descripcion"] = reader["Descripcion"]
                                };
                                procesos.Add(proceso);
                            }
                        }
                    }

                    foreach (var producto in productos)
                    {
                        foreach (var proceso in procesos)
                        {
                            string checkQuery = @"SELECT COUNT(*) FROM elastosystem_produccion_hoja_producto
                                                WHERE Producto = @PRODUCTO AND NoOperacion = @NO_OPERACION";
                            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                            {
                                checkCmd.Parameters.AddWithValue("@PRODUCTO", producto);
                                checkCmd.Parameters.AddWithValue("@NO_OPERACION", proceso["NoOperacion"]);

                                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                                if (exists == 0)
                                {
                                    string insertHojaProducto = @"INSERT INTO elastosystem_produccion_hoja_producto
                                                (Producto, Familia, Nave, NoOperacion, Area, Descripcion)
                                                VALUES (@PRODUCTO, @FAMILIA, @NAVE, @NO_OPERACION, @AREA, @DESCRIPCION)";
                                    using (MySqlCommand insertCmd = new MySqlCommand(insertHojaProducto, conn))
                                    {
                                        insertCmd.Parameters.AddWithValue("@PRODUCTO", producto);
                                        insertCmd.Parameters.AddWithValue("@FAMILIA", familia);
                                        insertCmd.Parameters.AddWithValue("@NAVE", proceso["Nave"]);
                                        insertCmd.Parameters.AddWithValue("@NO_OPERACION", proceso["NoOperacion"]);
                                        insertCmd.Parameters.AddWithValue("@AREA", proceso["Area"]);
                                        insertCmd.Parameters.AddWithValue("@DESCRIPCION", proceso["Descripcion"]);

                                        insertCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL SINCORNIZAR EL NUEVO PROCESO CON LAS HOJAS DE RUTA DE LOS PRODUCTO EXISTENTES: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void RevisarHule()
        {
            string familiaSeleccionada = cbFamilia.Text.Trim();

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT COUNT(*) FROM elastosystem_produccion_encabezado
                                    WHERE Familia = @FAMILIA";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FAMILIA", familiaSeleccionada);

                        int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

                        if (cantidad > 0)
                        {
                            string hojaRutaQuery = "SELECT Insumos FROM elastosystem_produccion_hoja_ruta WHERE Familia = @FAMILIA";
                            using (MySqlCommand hojaRutaCmd = new MySqlCommand(hojaRutaQuery, conn))
                            {
                                hojaRutaCmd.Parameters.AddWithValue("@FAMILIA", familiaSeleccionada);

                                using (MySqlDataReader reader = hojaRutaCmd.ExecuteReader())
                                {
                                    List<string> listaHules = new List<string>();

                                    while (reader.Read())
                                    {
                                        string insumos = reader["Insumos"]?.ToString();

                                        if (!string.IsNullOrEmpty(insumos) && insumos.Contains("//"))
                                        {
                                            string[] partes = insumos.Split(new string[] { "//" }, StringSplitOptions.None);
                                            string antesDeDiagonal = partes[0].Trim();

                                            if (!string.IsNullOrEmpty(antesDeDiagonal))
                                            {
                                                listaHules.Add(antesDeDiagonal);
                                            }
                                        }
                                    }

                                    reader.Close();

                                    if (listaHules.Count > 0)
                                    {
                                        string nuevosHules = string.Join(", ", listaHules.Distinct());

                                        string selectMateriales = "SELECT ID, Material FROM elastosystem_produccion_encabezado WHERE Familia = @FAMILIA";
                                        using (MySqlCommand selectCmd = new MySqlCommand(selectMateriales, conn))
                                        {
                                            selectCmd.Parameters.AddWithValue("@FAMILIA", familiaSeleccionada);

                                            using (MySqlDataReader materialReader = selectCmd.ExecuteReader())
                                            {
                                                List<(int id, string nuevoMaterial)> actualizaciones = new List<(int, string)>();

                                                while (materialReader.Read())
                                                {
                                                    int id = Convert.ToInt32(materialReader["ID"]);
                                                    string materialActual = materialReader["Material"]?.ToString() ?? "";

                                                    string nuevoMaterial = "";

                                                    if (materialActual.Contains("//"))
                                                    {
                                                        string despuesDeDiagonal = materialActual.Substring(materialActual.IndexOf("//"));
                                                        nuevoMaterial = nuevosHules + " " + despuesDeDiagonal;
                                                    }
                                                    else
                                                    {
                                                        nuevoMaterial = nuevosHules + " // " + materialActual;
                                                    }
                                                    actualizaciones.Add((id, nuevoMaterial));
                                                }

                                                materialReader.Close();

                                                foreach (var item in actualizaciones)
                                                {
                                                    string updateQuery = "UPDATE elastosystem_produccion_encabezado SET Material = @MATERIAL WHERE ID = @ID";
                                                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                                                    {
                                                        updateCmd.Parameters.AddWithValue("@MATERIAL", item.nuevoMaterial);
                                                        updateCmd.Parameters.AddWithValue("@ID", item.id);
                                                        updateCmd.ExecuteNonQuery();
                                                    }
                                                }

                                            }
                                        }


                                    }

                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL REVISAR SI EXISTE LA FAMILIA EN ENCABEZADOS: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txbTiempoPreparacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbTiempoOperacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvHojaRuta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNuevo.Visible = true;
            btnEliminarProceso.Visible = true;
            btnActualizarProceso.Visible = true;
            btnAgregarProceso.Visible = false;
            btnVerAV.Visible = false;
            cbHule.SelectedIndex = -1;
            cbAV.SelectedIndex = -1;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHojaRuta.Rows[e.RowIndex];
                txbID.Text = row.Cells[0].Value.ToString();
                txbNoOperacion.Text = row.Cells[2].Value.ToString();
                cbArea.Text = row.Cells[3].Value.ToString();
                txbNave.Text = row.Cells[4].Value.ToString();
                txbDescripcion.Text = row.Cells[5].Value.ToString();
                txbTipoMaquina.Text = row.Cells[6].Value.ToString();
                txbPreparacion.Text = row.Cells[7].Value.ToString();
                txbTiempoPreparacion.Text = row.Cells[8].Value.ToString();
                txbTiempoOperacion.Text = row.Cells[9].Value.ToString();

                string insumos = row.Cells[10].Value.ToString().Trim();
                cbHule.SelectedIndex = -1;
                txbInsumos.Clear();

                if (insumos.Contains("//"))
                {
                    string[] partes = insumos.Split(new string[] { "//" }, StringSplitOptions.None);

                    cbHule.Text = partes[0].Trim();

                    if (partes.Length > 1)
                        txbInsumos.Text = partes[1].Trim();
                }
                else
                {
                    cbHule.SelectedIndex = -1;
                    txbInsumos.Text = insumos;
                }
                chbCritico.Checked = Convert.ToBoolean(row.Cells[11].Value);
                cbAV.Text = row.Cells[12].Value.ToString();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lblCamposObligatorios.Visible = false; pbCampos.Visible = false; pbNoOperacion.Visible = false; pbArea.Visible = false; pbNave.Visible = false; pbDescripcion.Visible = false;
            btnNuevo.Visible = false;
            btnEliminarProceso.Visible = false;
            btnActualizarProceso.Visible = false;
            btnAgregarProceso.Visible = true;
            btnVerAV.Visible = false;

            txbID.Clear();
            txbNoOperacion.Clear();
            cbArea.SelectedIndex = -1;
            txbNave.Clear();
            txbDescripcion.Clear();
            txbTipoMaquina.Clear();
            txbPreparacion.Clear();
            txbTiempoPreparacion.Clear();
            txbTiempoOperacion.Clear();
            txbInsumos.Clear();
            chbCritico.Checked = false;
            cbHule.SelectedIndex = -1;
            cbAV.SelectedIndex = -1;

            MandarALlamarHojaRuta();
        }

        private void btnEliminarProceso_Click(object sender, EventArgs e)
        {
            EliminarProceso();
        }

        private void EliminarProceso()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string selectQuery = "SELECT NoOperacion, Familia FROM elastosystem_produccion_hoja_ruta WHERE ID = @ID";
                    string noOperacion = "";
                    string familia = "";

                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@ID", txbID.Text.Trim());

                        using (var reader = selectCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                noOperacion = reader["NoOperacion"].ToString();
                                familia = reader["Familia"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el proceso con ese ID.");
                                return;
                            }
                        }
                    }

                    EliminarProcesoDeHojaProducto(noOperacion, familia);

                    string deleteQuery = "DELETE FROM elastosystem_produccion_hoja_ruta WHERE ID = @ID";
                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", txbID.Text.Trim());
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            RevisarHule();
                            btnNuevo.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el proceso.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ELIMINAR PROCESO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void EliminarProcesoDeHojaProducto(string noOperacion, string familia)
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string deleteQuery = @"DELETE FROM elastosystem_produccion_hoja_producto
                                            WHERE NoOperacion = @NO_OPERACION AND Familia = @FAMILIA";
                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@NO_OPERACION", noOperacion);
                        cmd.Parameters.AddWithValue("@FAMILIA", familia);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ELIMINAR EL PROCESO EN elastosystem_produccion_hoja_producto: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnActualizarProceso_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbNoOperacion.Text) || string.IsNullOrWhiteSpace(cbArea.Text) || string.IsNullOrWhiteSpace(txbNave.Text) || string.IsNullOrWhiteSpace(txbDescripcion.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios.");
                lblCamposObligatorios.Visible = true; pbCampos.Visible = true; pbNoOperacion.Visible = true; pbArea.Visible = true; pbNave.Visible = true; pbDescripcion.Visible = true;
                return;
            }
            lblCamposObligatorios.Visible = false; pbCampos.Visible = false; pbNoOperacion.Visible = false; pbArea.Visible = false; pbNave.Visible = false; pbDescripcion.Visible = false;
            ActualizarProceso();
        }

        private void ActualizarProceso()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string id = txbID.Text.Trim();
                    string nuevaNoOperacion = txbNoOperacion.Text.Trim();
                    string nuevaDescripcion = txbDescripcion.Text.Trim();
                    string nuevaArea = cbArea.Text.Trim();
                    string nuevaNave = txbNave.Text.Trim();

                    string oldNoOperacion = "", familia = "";
                    string selectQuery = "SELECT NoOperacion, Familia FROM elastosystem_produccion_hoja_ruta WHERE ID = @ID";
                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@ID", id);
                        using (var reader = selectCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                oldNoOperacion = reader["NoOperacion"].ToString();
                                familia = reader["Familia"].ToString();
                            }
                        }
                    }

                    string checkQuery = "SELECT COUNT(*) FROM elastosystem_produccion_hoja_ruta WHERE NoOperacion = @NO_OPERACION AND Familia = @FAMILIA AND ID != @ID";
                    MySqlCommand cmd = new MySqlCommand(checkQuery, conn);
                    cmd.Parameters.AddWithValue("@NO_OPERACION", nuevaNoOperacion);
                    cmd.Parameters.AddWithValue("@FAMILIA", familia);
                    cmd.Parameters.AddWithValue("@ID", id);
                    int procesoCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (procesoCount > 0)
                    {
                        MessageBox.Show("Ya existe un proceso con ese número de operación en la misma familia.");
                        return;
                    }

                    string insumos = "";
                    bool hayHule = !string.IsNullOrWhiteSpace(cbHule.Text.Trim());
                    bool hayInsumo = !string.IsNullOrWhiteSpace(txbInsumos.Text.Trim());

                    if (hayHule && hayInsumo)
                        insumos = cbHule.Text.Trim() + " // " + txbInsumos.Text.Trim();
                    else if (hayHule && !hayInsumo)
                        insumos = cbHule.Text.Trim() + " //";
                    else
                        insumos = txbInsumos.Text.Trim();

                    string updateQuery = @"UPDATE elastosystem_produccion_hoja_ruta 
                                            SET NoOperacion = @NO_OPERACION, Area = @AREA, Nave = @NAVE, Descripcion = @DESCRIPCION, 
                                                TipoMaquina = @TIPOMAQUINA, Preparacion = @PREPARACION, TiempoPreparacion = @TIEMPO_PREPARACION, 
                                                TiempoOperacion = @TIEMPO_OPERACION, Insumos = @INSUMOS, Critico = @CRITICO, AyudaVisual = @AYUDAVISUAL 
                                            WHERE ID = @ID";

                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@NO_OPERACION", nuevaNoOperacion);
                    updateCmd.Parameters.AddWithValue("@AREA", nuevaArea);
                    updateCmd.Parameters.AddWithValue("@NAVE", nuevaNave);
                    updateCmd.Parameters.AddWithValue("@DESCRIPCION", nuevaDescripcion);
                    updateCmd.Parameters.AddWithValue("@TIPOMAQUINA", txbTipoMaquina.Text.Trim());
                    updateCmd.Parameters.AddWithValue("@PREPARACION", txbPreparacion.Text.Trim());
                    updateCmd.Parameters.AddWithValue("@TIEMPO_PREPARACION", txbTiempoPreparacion.Text.Trim());
                    updateCmd.Parameters.AddWithValue("@TIEMPO_OPERACION", txbTiempoOperacion.Text.Trim());
                    updateCmd.Parameters.AddWithValue("@INSUMOS", insumos);
                    updateCmd.Parameters.AddWithValue("@CRITICO", chbCritico.Checked ? 1 : 0);
                    updateCmd.Parameters.AddWithValue("@AYUDAVISUAL", cbAV.Text.Trim());
                    updateCmd.Parameters.AddWithValue("@ID", id);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        string updateProductoQuery = @"UPDATE elastosystem_produccion_hoja_producto
                                                        SET NoOperacion = @NUEVO_NO_OPERACION, Descripcion = @DESCRIPCION, Area = @AREA, Nave = @NAVE 
                                                        WHERE NoOperacion = @OLD_NO_OPERACION AND Familia = @FAMILIA";

                        using (MySqlCommand updateProdCmd = new MySqlCommand(updateProductoQuery, conn))
                        {
                            updateProdCmd.Parameters.AddWithValue("@NUEVO_NO_OPERACION", nuevaNoOperacion);
                            updateProdCmd.Parameters.AddWithValue("@DESCRIPCION", nuevaDescripcion);
                            updateProdCmd.Parameters.AddWithValue("@AREA", nuevaArea);
                            updateProdCmd.Parameters.AddWithValue("@NAVE", nuevaNave);
                            updateProdCmd.Parameters.AddWithValue("@OLD_NO_OPERACION", oldNoOperacion);
                            updateProdCmd.Parameters.AddWithValue("@FAMILIA", familia);

                            updateProdCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Proceso actualizado correctamente.");
                        RevisarHule();
                        btnNuevo.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el proceso.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR PROCESO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        private void cbFamiliaAdministrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFamiliaAdministrar.SelectedIndex != -1 && status == false)
            {
                LimpiarCamposEncabezado();
                CargarTodosHulesHR();
            }
        }

        private void LimpiarCamposEncabezado()
        {
            cbLinea.SelectedIndex = -1;
            txbNombreEncabezado.Clear();
            txbMaterialEncabezado.Clear();
            txbCalibreEncabezado.Clear();
            txbSubensamble.Clear();
            txbDibujo.Clear();
            pbImagen.Image = null;
            txbIDAdministrar.Clear();

            lblCamposAdmin.Visible = false; pbCamposAdmin.Visible = false; pbFamiliaAdmin.Visible = false; pbLineaAdmin.Visible = false; pbNombreAdmin.Visible = false; pbMaterialAdmin.Visible = false; pbCalibreAdmin.Visible = false; pbSubensambleAdmin.Visible = false; pbDibujoAdmin.Visible = false;

            btnNuevoEncabezado.Visible = false;
            btnEliminarEncabezado.Visible = false;
            btnActualizarEncabezado.Visible = false;

            btnAgregarEncabezado.Visible = true;
        }

        private void CargarTodosHulesHR()
        {
            string familiaSeleccionada = cbFamiliaAdministrar.SelectedItem?.ToString();

            List<string> hules = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT Insumos
                        FROM elastosystem_produccion_hoja_ruta
                        WHERE Familia = @FAMILIA";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FAMILIA", familiaSeleccionada);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string insumos = reader["Insumos"].ToString();

                        if (insumos.Contains("//"))
                        {
                            string hule = insumos.Split(new[] { "//" }, StringSplitOptions.None)[0].Trim();
                            if (!string.IsNullOrEmpty(hule))
                                hules.Add(hule);
                        }
                    }

                    var hulesUnicos = hules.Distinct().ToList();

                    txbMaterialEncabezado.Text = hulesUnicos.Count > 0 ? string.Join(", ", hulesUnicos) + " // " : "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR HULES DE LA FAMILIA: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnNuevoEncabezado_Click(object sender, EventArgs e)
        {
            cbFamiliaAdministrar.Enabled = true;
            cbLinea.Enabled = true;
            status = false;
            LimpiarCamposEncabezado();
            cbFamiliaAdministrar.SelectedIndex = -1;
        }

        private void btnAgregarEncabezado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbLinea.Text) || string.IsNullOrWhiteSpace(txbNombreEncabezado.Text) || string.IsNullOrWhiteSpace(txbMaterialEncabezado.Text) || string.IsNullOrWhiteSpace(txbCalibreEncabezado.Text) || string.IsNullOrWhiteSpace(txbSubensamble.Text) || string.IsNullOrWhiteSpace(txbDibujo.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios.");
                pbCamposAdmin.Visible = true; lblCamposAdmin.Visible = true; pbFamiliaAdmin.Visible = true; pbLineaAdmin.Visible = true;
                pbNombreAdmin.Visible = true; pbMaterialAdmin.Visible = true; pbCalibreAdmin.Visible = true; pbSubensambleAdmin.Visible = true; pbDibujoAdmin.Visible = true;
                return;
            }
            if (pbImagen.Image == null)
            {
                MessageBox.Show("Por favor, cargar una imagen.");
                return;
            }

            pbCamposAdmin.Visible = false; lblCamposAdmin.Visible = false; pbFamiliaAdmin.Visible = false; pbLineaAdmin.Visible = false;
            pbNombreAdmin.Visible = false; pbMaterialAdmin.Visible = false; pbCalibreAdmin.Visible = false; pbSubensambleAdmin.Visible = false; pbDibujoAdmin.Visible = false;

            AgregarEncabezado();
        }

        private void AgregarEncabezado()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM elastosystem_produccion_encabezado WHERE Familia = @FAMILIA AND Linea = @LINEA";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@FAMILIA", cbFamiliaAdministrar.SelectedItem.ToString());
                        checkCmd.Parameters.AddWithValue("@LINEA", cbLinea.Text.Trim());

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Ya existe un encabezado con esa familia y línea.");
                            return;
                        }
                    }

                    string query = "INSERT INTO elastosystem_produccion_encabezado (Familia, Linea, Nombre, Material, Calibre, Subensamble, DibIng, Imagen) VALUES (@FAMILIA, @LINEA, @NOMBRE, @MATERIAL, @CALIBRE, @SUBENSAMBLE, @DIBING, @IMAGEN)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FAMILIA", cbFamiliaAdministrar.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@LINEA", cbLinea.Text.Trim());
                        cmd.Parameters.AddWithValue("@NOMBRE", txbNombreEncabezado.Text.Trim());
                        cmd.Parameters.AddWithValue("@MATERIAL", txbMaterialEncabezado.Text.Trim());
                        cmd.Parameters.AddWithValue("@CALIBRE", txbCalibreEncabezado.Text.Trim());
                        cmd.Parameters.AddWithValue("@SUBENSAMBLE", txbSubensamble.Text.Trim());
                        cmd.Parameters.AddWithValue("@DIBING", txbDibujo.Text.Trim());
                        byte[] bytesFoto;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pbImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            bytesFoto = ms.ToArray();
                        }
                        cmd.Parameters.AddWithValue("@IMAGEN", bytesFoto);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Encabezado agregado correctamente.");
                        status = false;
                        CargarEncabezados();
                        LimpiarAdministrar();
                        btnNuevo.Visible = false; btnEliminarProceso.Visible = false; btnActualizarProceso.Visible = false; btnAgregarProceso.Visible = true;
                        CargarFamiliasAdmin();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL AGREGAR ENCABEZADO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void LimpiarAdministrar()
        {
            cbFamiliaAdministrar.SelectedIndex = -1;
            cbLinea.SelectedIndex = -1;
            txbNombreEncabezado.Clear();
            txbMaterialEncabezado.Clear();
            txbCalibreEncabezado.Clear();
            txbSubensamble.Clear();
            txbDibujo.Clear();
            pbImagen.Image = null;
            txbIDAdministrar.Clear();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            CargarImagen();
        }

        private void CargarImagen()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.png;*.jpg;*.jpeg;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaImagen = openFileDialog.FileName;

                try
                {
                    using (var imgTemp = Image.FromFile(rutaImagen))
                    {
                        pbImagen.Image = new Bitmap(imgTemp);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR IMAGEN: " + ex.Message);
                }
            }
        }

        private void txbSubensamble_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvEncabezados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNuevoEncabezado.Visible = true;
            btnEliminarEncabezado.Visible = true;
            btnActualizarEncabezado.Visible = true;
            btnAgregarEncabezado.Visible = false;

            status = true;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEncabezados.Rows[e.RowIndex];
                txbIDAdministrar.Text = row.Cells[0].Value.ToString();
                cbFamiliaAdministrar.Text = row.Cells[1].Value.ToString();
                cbLinea.Text = row.Cells[2].Value.ToString();
                txbNombreEncabezado.Text = row.Cells[3].Value.ToString();
                txbMaterialEncabezado.Text = row.Cells[4].Value.ToString();
                txbCalibreEncabezado.Text = row.Cells[5].Value.ToString();
                txbSubensamble.Text = row.Cells[6].Value.ToString();
                txbDibujo.Text = row.Cells[7].Value.ToString();

                byte[] imagenBytes = (byte[])row.Cells[8].Value;

                if (imagenBytes != null && imagenBytes.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        using (var imgTemp = Image.FromStream(ms))
                        {
                            pbImagen.Image = new Bitmap(imgTemp);
                        }
                    }
                }
                else
                {
                    pbImagen.Image = null;
                }

                cbFamiliaAdministrar.Enabled = false;
                cbLinea.Enabled = false;
            }
        }

        private void btnEliminarEncabezado_Click(object sender, EventArgs e)
        {
            EliminarEncabezado();
        }

        private void EliminarEncabezado()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM elastosystem_produccion_encabezado WHERE ID = @ID";

                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", txbIDAdministrar.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Encabezado eliminado correctamente.");
                            LimpiarAdministrar();
                            status = false;
                            btnNuevoEncabezado.Visible = false; btnEliminarEncabezado.Visible = false; btnActualizarEncabezado.Visible = false; btnAgregarEncabezado.Visible = true;
                            CargarEncabezados();
                            cbFamiliaAdministrar.Enabled = true;
                            cbLinea.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el encabezado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ELIMINAR ENCABEZADO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnActualizarEncabezado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbLinea.Text) || string.IsNullOrWhiteSpace(txbNombreEncabezado.Text) ||
                string.IsNullOrWhiteSpace(txbMaterialEncabezado.Text) || string.IsNullOrWhiteSpace(txbCalibreEncabezado.Text) ||
                string.IsNullOrWhiteSpace(txbSubensamble.Text) || string.IsNullOrWhiteSpace(txbDibujo.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios.");
                pbCamposAdmin.Visible = true; lblCamposAdmin.Visible = true; pbFamiliaAdmin.Visible = true; pbLineaAdmin.Visible = true;
                pbNombreAdmin.Visible = true; pbMaterialAdmin.Visible = true; pbCalibreAdmin.Visible = true; pbSubensambleAdmin.Visible = true; pbDibujoAdmin.Visible = true;
                return;
            }

            pbCamposAdmin.Visible = false; lblCamposAdmin.Visible = false; pbFamiliaAdmin.Visible = false; pbLineaAdmin.Visible = false;
            pbNombreAdmin.Visible = false; pbMaterialAdmin.Visible = false; pbCalibreAdmin.Visible = false; pbSubensambleAdmin.Visible = false; pbDibujoAdmin.Visible = false;

            if (pbImagen.Image == null)
            {
                MessageBox.Show("Por favor, cargar una imagen.");
                return;
            }

            ActualizarEncabezado();
        }

        private void ActualizarEncabezado()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = @"UPDATE elastosystem_produccion_encabezado
                                        SET Nombre = @NOMBRE,
                                        Material = @MATERIAL, Calibre = @CALIBRE, Subensamble = @SUBENSAMBLE,
                                        DibIng = @DIBING, Imagen = @IMAGEN
                                    WHERE ID = @ID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txbIDAdministrar.Text));
                        cmd.Parameters.AddWithValue("@NOMBRE", txbNombreEncabezado.Text.Trim());
                        cmd.Parameters.AddWithValue("@MATERIAL", txbMaterialEncabezado.Text.Trim());
                        cmd.Parameters.AddWithValue("@CALIBRE", txbCalibreEncabezado.Text.Trim());
                        cmd.Parameters.AddWithValue("@SUBENSAMBLE", txbSubensamble.Text.Trim());
                        cmd.Parameters.AddWithValue("@DIBING", txbDibujo.Text.Trim());

                        byte[] imagenBytes;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pbImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            imagenBytes = ms.ToArray();
                        }
                        cmd.Parameters.AddWithValue("@IMAGEN", imagenBytes);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Encabezado actualizado correctamente.");
                            CargarEncabezados();
                            LimpiarAdministrar();
                            btnNuevoEncabezado.Visible = false; btnEliminarEncabezado.Visible = false; btnActualizarEncabezado.Visible = false; btnAgregarEncabezado.Visible = true;
                            cbFamiliaAdministrar.Enabled = true;
                            cbLinea.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el encabezado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR ENCABEZADO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txbBuscador_TextChanged(object sender, EventArgs e)
        {
            Buscador();
        }

        private void Buscador()
        {
            try
            {
                string valorBusqueda = txbBuscador.Text.Trim();

                if (string.IsNullOrEmpty(valorBusqueda))
                {
                    CargarProductosRelacion();
                }
                else
                {
                    string consulta = "SELECT Producto, Familia FROM elastosystem_sae_productos WHERE Producto LIKE @VALORBUSQUEDA OR Familia LIKE @VALORBUSQUEDA";

                    MySqlDataAdapter adapatador = new MySqlDataAdapter(consulta, VariablesGlobales.ConexionBDElastotecnica);

                    adapatador.SelectCommand.Parameters.AddWithValue("@VALORBUSQUEDA", "%" + valorBusqueda + "%");

                    DataSet datos = new DataSet();

                    adapatador.Fill(datos, "Resultados");

                    dgvProductosFamilias.DataSource = datos.Tables["Resultados"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL BUSCAR: " + ex.Message);
            }
        }

        private void dgvProductosFamilias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbProducto.Clear();
            txbFamiliaOrig.Clear();
            cbFamiliaRelacion.SelectedIndex = -1;

            DataGridView dgvBD = (DataGridView)sender;

            if (dgvBD.SelectedCells.Count > 0)
            {
                int rowIndex = dgvBD.SelectedCells[0].RowIndex;

                string producto = dgvBD.Rows[rowIndex].Cells[0].Value.ToString();
                txbProducto.Text = producto;

                string familia = dgvBD.Rows[rowIndex].Cells[1].Value.ToString();
                cbFamiliaRelacion.Text = familia;
                txbFamiliaOrig.Text = familia;
            }
        }

        private void btnActualizarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbProducto.Text) && string.IsNullOrWhiteSpace(cbFamiliaRelacion.Text))
            {
                MessageBox.Show("No existe nada por actualizar");
                return;
            }
            if (string.IsNullOrWhiteSpace(txbProducto.Text))
            {
                MessageBox.Show("No existe producto para actualizar.");
                return;
            }
            if (string.IsNullOrWhiteSpace(cbFamiliaRelacion.Text))
            {
                MessageBox.Show("No existe familia para el producto.");
                return;
            }

            ActualizarProducto();
            CargarHojasRuta();

        }

        private void ActualizarProducto()
        {

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string selectQuery = "SELECT Familia FROM elastosystem_sae_productos WHERE Producto = @PRODUCTO";
                    MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn);
                    selectCmd.Parameters.AddWithValue("@PRODUCTO", txbProducto.Text.Trim());

                    object currentFamiliaObj = selectCmd.ExecuteScalar();
                    string currentFamilia = currentFamiliaObj != null ? currentFamiliaObj.ToString() : "";

                    if (currentFamilia.Equals(cbFamiliaRelacion.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("No se han realizado cambios en la familia del producto.");
                        return;
                    }

                    string updateQuery = "UPDATE elastosystem_sae_productos SET Familia = @FAMILIA WHERE Producto = @PRODUCTO";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@FAMILIA", cbFamiliaRelacion.Text.Trim());
                    updateCmd.Parameters.AddWithValue("@PRODUCTO", txbProducto.Text.Trim());

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        if (string.IsNullOrWhiteSpace(currentFamilia))
                        {
                            AgregarHojaProducto();
                        }
                        else
                        {
                            EliminaryAgregarHojaProducto();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL RELACIONAR EL PRODUCTO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void AgregarHojaProducto()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM elastosystem_produccion_hoja_ruta WHERE Familia = @FAMILIA";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@FAMILIA", cbFamiliaRelacion.Text.Trim());

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count == 0)
                    {
                        txbBuscador.Clear();
                        txbProducto.Clear();
                        txbFamiliaOrig.Clear();
                        cbFamiliaRelacion.SelectedIndex = -1;
                        CargarFamiliasRelacion();
                        CargarProductosRelacion();
                        return;
                    }

                    List<(string Nave, string NoOperacion, string Area, string Descripcion)> registros = new List<(string, string, string, string)>();

                    string selectQuery = "SELECT Nave, NoOperacion, Area, Descripcion FROM elastosystem_produccion_hoja_ruta WHERE Familia = @FAMILIA";
                    MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn);
                    selectCmd.Parameters.AddWithValue("@FAMILIA", cbFamiliaRelacion.Text.Trim());

                    using (MySqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            registros.Add((
                                reader["Nave"].ToString(),
                                reader["NoOperacion"].ToString(),
                                reader["Area"].ToString(),
                                reader["Descripcion"].ToString()
                            ));
                        }
                    }

                    foreach (var reg in registros)
                    {
                        string insertQuery = @"INSERT INTO elastosystem_produccion_hoja_producto
                                                (Producto, Familia, Nave, NoOperacion, Area, Descripcion, NombreArea, ProduccionEstandar, CantidadUnidad)
                                                VALUES(@PRODUCTO, @FAMILIA, @NAVE, @NOOPERACION, @AREA, @DESCRIPCION, '', '', '')";

                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@PRODUCTO", txbProducto.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@FAMILIA", cbFamiliaRelacion.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@NAVE", reg.Nave);
                            insertCmd.Parameters.AddWithValue("@NOOPERACION", reg.NoOperacion);
                            insertCmd.Parameters.AddWithValue("@AREA", reg.Area);
                            insertCmd.Parameters.AddWithValue("@DESCRIPCION", reg.Descripcion);

                            insertCmd.ExecuteNonQuery();
                        }
                    }

                    txbBuscador.Clear();
                    txbProducto.Clear();
                    txbFamiliaOrig.Clear();
                    cbFamiliaRelacion.SelectedIndex = -1;
                    CargarFamiliasRelacion();
                    CargarProductosRelacion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL AGREGAR A produccion_hoja_producto: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void EliminaryAgregarHojaProducto()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string deleteQuery = @"DELETE FROM elastosystem_produccion_hoja_producto
                                            WHERE Producto = @PRODUCTO AND Familia = @FAMILIA";

                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@PRODUCTO", txbProducto.Text.Trim());
                        deleteCmd.Parameters.AddWithValue("@FAMILIA", txbFamiliaOrig.Text.Trim());

                        deleteCmd.ExecuteNonQuery();
                    }

                    AgregarHojaProducto();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ELIMINAR Y AGREGAR A produccion_hoja_producto: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txbBuscadorHR_TextChanged(object sender, EventArgs e)
        {
            BuscadorHR();
        }

        private void BuscadorHR()
        {
            try
            {
                String valorBusqueda = txbBuscadorHR.Text.Trim();

                if (string.IsNullOrEmpty(valorBusqueda))
                {
                    CargarHojasRuta();
                }
                else
                {
                    string consulta = "SELECT * FROM elastosystem_produccion_hoja_producto WHERE Producto LIKE @VALORBUSQUEDA OR Familia LIKE @VALORBUSQUEDA OR Descripcion LIKE @VALORBUSQUEDA ORDER BY Producto ASC, NoOperacion ASC";

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, VariablesGlobales.ConexionBDElastotecnica);

                    adaptador.SelectCommand.Parameters.AddWithValue("@VALORBUSQUEDA", "%" + valorBusqueda + "%");

                    DataSet datos = new DataSet();

                    adaptador.Fill(datos, "Resultados");

                    dgvHojasRuta.DataSource = datos.Tables["Resultados"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL BUSCAR: " + ex.Message);
            }
        }

        private void dgvHojasRuta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvHojasRuta.Rows[e.RowIndex];

                string familia = fila.Cells["Familia"].Value.ToString();
                string producto = fila.Cells["Producto"].Value.ToString();
                string nave = fila.Cells["Nave"].Value.ToString();
                string noOperacion = fila.Cells["NoOperacion"].Value.ToString();
                string area = fila.Cells["Area"].Value.ToString();
                string descripcion = fila.Cells["Descripcion"].Value.ToString();
                string produccion = fila.Cells["ProduccionEstandar"].Value.ToString();
                string nombreArea = fila.Cells["NombreArea"].Value.ToString();
                string cantidadUnidad = fila.Cells["CantidadUnidad"].Value.ToString();

                Produccion_ActualizarHR ventana = new Produccion_ActualizarHR(familia, producto, nave, noOperacion, area, descripcion, produccion, nombreArea, cantidadUnidad);
                DialogResult resultado = ventana.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    CargarHojasRuta();
                }
            }
        }

        private void cbFamiliaAyV_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAyudasVisualesFamilia();
            btnAgregarAV.Visible = true;
            btnEditarAV.Visible = false;
            btnEliminarAV.Visible = false;
            btnNuevoAV.Visible = false;
            txbIDAV.Clear();
            ayudaVisualPdf = null;
            txbArchivo.Clear();
        }

        private void CargarAyudasVisualesFamilia()
        {
            if (cbFamiliaAyV.SelectedIndex != -1)
            {
                dgvAV.DataSource = null;
                string familia = cbFamiliaAyV.SelectedItem.ToString();
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    try
                    {
                        conn.Open();

                        string query = "SELECT * FROM elastosystem_produccion_av WHERE Familia = @FAMILIA ORDER BY Nombre";

                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@FAMILIA", familia);

                        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adaptador.Fill(dt);

                        dgvAV.DataSource = dt;

                        dgvAV.Columns["ID"].Visible = false;
                        dgvAV.Columns["Familia"].Visible = false;
                        dgvAV.Columns["Archivo"].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR AL CARGAR AYUDAS VISUALES: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private byte[] ayudaVisualPdf;

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
            openFileDialog.Title = "Seleccionar archivo PDF";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog.FileName;
                FileInfo fileInfo = new FileInfo(rutaArchivo);

                if (fileInfo.Length > 10 * 1024 * 1024)
                {
                    MessageBox.Show("El archivo seleccionado supera el tamaño máximo permitido de 10 MB.", "Archivo demasiado grande", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombreArchivoSinExtension = Path.GetFileNameWithoutExtension(rutaArchivo);

                ayudaVisualPdf = File.ReadAllBytes(rutaArchivo);
                txbArchivo.Text = nombreArchivoSinExtension;
            }
        }

        private void btnNuevoAV_Click(object sender, EventArgs e)
        {
            ayudaVisualPdf = null;
            txbArchivo.Clear();
            btnNuevoAV.Visible = false;
            btnEliminarAV.Visible = false;
            btnAgregarAV.Visible = true;
            btnEditarAV.Visible = false;
        }

        private void txbArchivo_TextChanged(object sender, EventArgs e)
        {
            if (ayudaVisualPdf != null)
            {
                btnVer.Visible = true;
            }
            else
            {
                btnVer.Visible = false;
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (ayudaVisualPdf != null)
            {
                string rutaTemporal = Path.Combine(Path.GetTempPath(), "tempAV.pdf");
                File.WriteAllBytes(rutaTemporal, ayudaVisualPdf);

                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = rutaTemporal,
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }
            else
            {
                MessageBox.Show("No hay archivo PDF cargado para ver.");
            }
        }

        private void btnAgregarAV_Click(object sender, EventArgs e)
        {
            if (cbFamiliaAyV.SelectedIndex == -1 || ayudaVisualPdf == null || string.IsNullOrWhiteSpace(txbArchivo.Text))
            {
                MessageBox.Show("Debes de seleccionar una familia, cargar un archivo PDF y declarar un nombre para el archivo.");
                return;
            }

            string familia = cbFamiliaAyV.SelectedItem.ToString();
            string nombreArchivo = txbArchivo.Text;

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string queryCheck = "SELECT COUNT(*) FROM elastosystem_produccion_av WHERE Familia = @FAMILIA AND Nombre = @NOMBRE";
                    MySqlCommand cmdCheck = new MySqlCommand(queryCheck, conn);
                    cmdCheck.Parameters.AddWithValue("@FAMILIA", familia);
                    cmdCheck.Parameters.AddWithValue("@NOMBRE", nombreArchivo);

                    int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Ya existe una ayuda visual con ese nombre en la familia seleccionada.");
                        return;
                    }

                    string queryInsert = "INSERT INTO elastosystem_produccion_av (Familia, Nombre, Archivo) VALUES (@FAMILIA, @NOMBRE, @ARCHIVO)";
                    MySqlCommand cmdInsert = new MySqlCommand(queryInsert, conn);
                    cmdInsert.Parameters.AddWithValue("@FAMILIA", familia);
                    cmdInsert.Parameters.AddWithValue("@NOMBRE", nombreArchivo);
                    cmdInsert.Parameters.AddWithValue("@ARCHIVO", ayudaVisualPdf);

                    cmdInsert.ExecuteNonQuery();

                    MessageBox.Show("Ayuda visual agregada correctamente.");

                    CargarAyudasVisualesFamilia();
                    ayudaVisualPdf = null;
                    txbArchivo.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL AGREGAR AYUDA VISUAL: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void dgvAV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNuevoAV.Visible = true;
            btnEliminarAV.Visible = true;
            btnAgregarAV.Visible = false;
            btnEditarAV.Visible = true;

            txbArchivo.Clear();
            txbNombreOriginal.Clear();
            ayudaVisualPdf = null;
            txbIDAV.Clear();

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAV.Rows[e.RowIndex];
                txbIDAV.Text = row.Cells[0].Value.ToString();
                if (row.Cells[3].Value != DBNull.Value)
                {
                    ayudaVisualPdf = (byte[])row.Cells[3].Value;
                }
                else
                {
                    ayudaVisualPdf = null;
                }
                txbArchivo.Text = row.Cells[2].Value.ToString();
                txbNombreOriginal.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnEliminarAV_Click(object sender, EventArgs e)
        {
            EliminarAV();
            CargarAyudasVisualesFamilia();
        }

        private void EliminarAV()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM elastosystem_produccion_av WHERE ID = @ID";
                    MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);

                    cmd.Parameters.AddWithValue("@ID", txbIDAV.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("AYUDA VISUAL ELIMINADA CORRECTAMENTE");
                        EliminarRegistrosAV();
                        btnNuevoAV.PerformClick();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ELIMINAR AYUDA VISUAL: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void EliminarRegistrosAV()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string updateQuery = "UPDATE elastosystem_produccion_hoja_ruta SET AyudaVisual = '' WHERE AyudaVisual = @AYUDA_VISUAL";
                    MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@AYUDA_VISUAL", txbNombreOriginal.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL VACIAR AV EN LA HOJA DE RUTA: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnEditarAV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbArchivo.Text) || ayudaVisualPdf == null)
            {
                MessageBox.Show("Debes de cargar un archivo PDF y declarar un nombre para el archivo.");
                return;
            }
            ActualizarAV();
            CargarAyudasVisualesFamilia();
        }

        private void ActualizarAV()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM elastosystem_produccion_av WHERE Nombre = @NOMBRE AND Nombre != @NOMBRE_ORIGINAL";

                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@NOMBRE", txbArchivo.Text.Trim());
                    checkCmd.Parameters.AddWithValue("@NOMBRE_ORIGINAL", txbNombreOriginal.Text.Trim());

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Ya existe una ayuda visual con ese nombre en la familia seleccionada.");
                        return;
                    }

                    string updateQuery = "UPDATE elastosystem_produccion_av SET Nombre = @NOMBRE , Archivo = @ARCHIVO WHERE ID = @ID";
                    MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@NOMBRE", txbArchivo.Text.Trim());
                    cmd.Parameters.AddWithValue("@ARCHIVO", ayudaVisualPdf);
                    cmd.Parameters.AddWithValue("@ID", txbIDAV.Text.Trim());
                    cmd.Connection = conn;
                    cmd.CommandText = updateQuery;
                    cmd.ExecuteNonQuery();

                    ActualizarRegistrosAV();

                    MessageBox.Show("Ayuda visual actualizada correctamente.");
                    btnEliminarAV.Visible = false;
                    btnAgregarAV.Visible = true;
                    btnEditarAV.Visible = false;
                    btnNuevoAV.Visible = false;
                    ayudaVisualPdf = null;
                    txbArchivo.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR AYUDA VISUAL: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void ActualizarRegistrosAV()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string updateQuery = "UPDATE elastosystem_produccion_hoja_ruta SET AyudaVisual = @NUEVO WHERE AyudaVisual = @ANTERIOR";
                    MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@NUEVO", txbArchivo.Text.Trim());
                    cmd.Parameters.AddWithValue("@ANTERIOR", txbNombreOriginal.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR REGISTROS EN LA HOJA DE RUTA: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void cbAV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAV.SelectedIndex == -1)
            {
                return;
            }

            btnVerAV.Visible = true;
            ConsultarAV();
        }


        private byte[] ayudaVisualPdfAV;
        private void ConsultarAV()
        {
            string nombreSeleccionado = cbAV.SelectedItem.ToString();

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Archivo FROM elastosystem_produccion_av WHERE Nombre = @NOMBRE";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NOMBRE", nombreSeleccionado);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        ayudaVisualPdfAV = (byte[])resultado;
                    }
                    else
                    {
                        ayudaVisualPdfAV = null;
                        MessageBox.Show("No se encontró el archivo PDF asociado a la ayuda visual seleccionada.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ENCONTRAR LA AYUDA VISUAL: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnVerAV_Click(object sender, EventArgs e)
        {
            if (ayudaVisualPdfAV != null)
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
                MessageBox.Show("No hay archivo PDF cargado para ver.");
            }
        }

        private void dgvFamilias_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvFamilias.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvFamilias.Rows[hit.RowIndex];

                    bool tienePermiso = false;

                    using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                    {
                        try
                        {
                            conn.Open();
                            string queryID = "SELECT ID FROM elastosystem_login WHERE Usuario = @USUARIO";
                            MySqlCommand cmdID = new MySqlCommand(queryID, conn);
                            cmdID.Parameters.AddWithValue("@USUARIO", VariablesGlobales.Usuario);

                            object idObj = cmdID.ExecuteScalar();

                            if (idObj != null)
                            {
                                int idUsuario = Convert.ToInt32(idObj);

                                string queryPermiso = "SELECT EliminarFamilias FROM elastosystem_permisos_menu WHERE ID = @ID";
                                MySqlCommand cmdPermiso = new MySqlCommand(queryPermiso, conn);
                                cmdPermiso.Parameters.AddWithValue("@ID", idUsuario);

                                object permisoObj = cmdPermiso.ExecuteScalar();
                                if (permisoObj != null && permisoObj != DBNull.Value)
                                {
                                    tienePermiso = Convert.ToBoolean(permisoObj);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR AL VERIFICAR PERMISOS: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }

                    if (tienePermiso)
                    {
                        dgvFamilias.ClearSelection();
                        fila.Selected = true;

                        cmsFamilias.Show(dgvFamilias, e.Location);
                    }

                }
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            Produccion_EliminarFamilia eliminarFamilia = new Produccion_EliminarFamilia();
            DialogResult result = eliminarFamilia.ShowDialog();

            if(result == DialogResult.OK)
            {
                OcultarFamilia();

                txbFamilia.Clear();
                txbFamiliaOriginal.Clear();
                CargarFamilias();
                CargarFamiliaAV();
                btnNuevoFamilias.PerformClick();
            }
        }

        private void OcultarFamilia()
        {
            using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string updateQuery = "UPDATE elastosystem_produccion_familia SET Estatus = 'Inactiva' WHERE Familia = @FAMILIA";

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Parameters.AddWithValue("@FAMILIA", txbFamiliaOriginal.Text.Trim());
                    cmd.Connection = conn;
                    cmd.CommandText = updateQuery;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Familia oculta correctamente.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR AL OCULTAR FAMILIA: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
