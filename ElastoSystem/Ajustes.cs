using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ElastoSystem
{
    public partial class Ajustes : Form
    {
        public Ajustes()
        {
            InitializeComponent();
        }

        private void cbUsuariosEspeciales_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAgregar.Visible = true;
            btnEliminar.Visible = false;
            btnActualizar.Visible = false;
            txbCorreo.Clear();
            txbCorreoOriginal.Clear();

            CargarCorreos();
        }

        private void CargarCorreos()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = "SELECT * FROM elastosystem_ajustes_correos WHERE Area = @AREA ORDER BY Correo";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AREA", cbCorreo.Text);

                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);
                            dgvCorreo.DataSource = dt;

                            dgvCorreo.Columns["ID"].Visible = false;
                            dgvCorreo.Columns["Area"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR CORREOS: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string correo = txbCorreo.Text.Trim();

            if (EsCorreoValido(correo))
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    try
                    {
                        conn.Open();

                        string check = "SELECT COUNT(*) FROM elastosystem_ajustes_correos WHERE Correo = @CORREO AND Area = @AREA";
                        MySqlCommand cmd = new MySqlCommand(check, conn);
                        cmd.Parameters.AddWithValue("@CORREO", correo);
                        cmd.Parameters.AddWithValue("@AREA", cbCorreo.Text);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("El correo ya ha sido agregado");
                            return;
                        }

                        string insertQuery = "INSERT INTO elastosystem_ajustes_correos (Correo, Area) VALUES (@CORREO, @AREA)";
                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);

                        insertCmd.Parameters.AddWithValue("@CORREO", correo);
                        insertCmd.Parameters.AddWithValue("@AREA", cbCorreo.Text);

                        int rowsAffected = insertCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Correo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txbCorreo.Clear();
                            CargarCorreos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar el correo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al agregar el correo: " + ex.Message);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("El correo electrónico no es válido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool EsCorreoValido(string correo)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, patron);
        }

        private void dgvCorreo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEliminar.Visible = true;
            btnActualizar.Visible = true;
            btnNuevo.Visible = true;
            btnAgregar.Visible = false;


            txbCorreo.Clear();
            txbCorreoOriginal.Clear();

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCorreo.Rows[e.RowIndex];
                txbCorreo.Text = row.Cells["Correo"].Value.ToString();
                txbCorreoOriginal.Text = row.Cells["Correo"].Value.ToString();
            }
        }

        private void txbCorreo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAgregar.PerformClick();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarCorreo();
        }

        private void EliminarCorreo()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM elastosystem_ajustes_correos WHERE Correo = @CORREO AND Area = @AREA";
                    MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);

                    cmd.Parameters.AddWithValue("@CORREO", txbCorreoOriginal.Text.Trim());
                    cmd.Parameters.AddWithValue("@AREA", cbCorreo.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Correo eliminado correctamente.");
                        txbCorreo.Clear();
                        txbCorreoOriginal.Clear();
                        CargarCorreos();
                        btnActualizar.Visible = false;
                        btnEliminar.Visible = false;
                        btnNuevo.Visible = false;
                        btnAgregar.Visible = true;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ELIMINAR CORREO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string correo = txbCorreo.Text.Trim();
            if (EsCorreoValido(correo))
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    try
                    {
                        conn.Open();

                        string checkQuery = "SELECT COUNT(*) FROM elastosystem_ajustes_correos WHERE Correo = @CORREO AND Area = @AREA AND NOT (Correo = @CORREO_ORIGINAL AND Area = @AREA_ORIGINAL)";

                        MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                        checkCmd.Parameters.AddWithValue("@CORREO", correo);
                        checkCmd.Parameters.AddWithValue("@AREA", cbCorreo.Text);
                        checkCmd.Parameters.AddWithValue("@CORREO_ORIGINAL", txbCorreoOriginal.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@AREA_ORIGINAL", cbCorreo.Text);

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("El correo ya ha sido agregado anteriormente.");
                            return;
                        }

                        string updateQuery = "UPDATE elastosystem_ajustes_correos SET Correo = @CORREO WHERE Area = @AREA_ORIGINAL AND Correo = @CORREO_ORIGINAL";

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Parameters.AddWithValue("@CORREO", correo);
                        cmd.Parameters.AddWithValue("@AREA_ORIGINAL", cbCorreo.Text);
                        cmd.Parameters.AddWithValue("@CORREO_ORIGINAL", txbCorreoOriginal.Text.Trim());
                        cmd.Connection = conn;
                        cmd.CommandText = updateQuery;
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Correo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txbCorreo.Clear();
                        txbCorreoOriginal.Clear();
                        CargarCorreos();
                        btnActualizar.Visible = false;
                        btnEliminar.Visible = false;
                        btnNuevo.Visible = false;
                        btnAgregar.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR AL ACTUALIZAR CORREO: " + ex.Message);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("El correo elcetrónico no es válido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txbCorreo.Clear();
            txbCorreoOriginal.Clear();
            btnEliminar.Visible = false;
            btnActualizar.Visible = false;
            btnNuevo.Visible = false;
            btnAgregar.Visible = true;
            CargarCorreos();
        }

        private void Ajustes_Load(object sender, EventArgs e)
        {

        }
    }
}
