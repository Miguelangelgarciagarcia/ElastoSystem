using FirebirdSql.Data.FirebirdClient;
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
    public partial class Produccion_OrdenProduccion : Form
    {
        public Produccion_OrdenProduccion()
        {
            InitializeComponent();
        }

        private void Produccion_OrdenProduccion_Load(object sender, EventArgs e)
        {
            CargarSolicitudesFabricacion();
            CargarOrdenesProduccion();
            CargarDescripciones();
        }

        private void CargarDescripciones()
        {
            try
            {
                FbConnectionStringBuilder cadenaFB = new FbConnectionStringBuilder();
                cadenaFB.UserID = "SYSDBA";
                cadenaFB.Password = "masterkey";
                cadenaFB.Database = VariablesGlobales.DireccionBDSAE;
                cadenaFB.DataSource = VariablesGlobales.IPSAE;
                cadenaFB.Port = 3050;

                using (FbConnection connFB = new FbConnection(cadenaFB.ConnectionString))
                {
                    connFB.Open();
                    string sqlFB = "SELECT CVE_ART, DESCR FROM inve01";
                    FbCommand cmdFB = new FbCommand(sqlFB, connFB);
                    FbDataReader reader = cmdFB.ExecuteReader();

                    using (MySqlConnection connMySQL = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                    {
                        connMySQL.Open();

                        while (reader.Read())
                        {
                            string cveArt = reader["CVE_ART"].ToString().Trim();
                            string descrSAE = reader["DESCR"].ToString().Trim();

                            string selectQuery = "SELECT Descripcion FROM elastosystem_sae_productos WHERE Producto = @CVE_ART";
                            MySqlCommand selectCmd = new MySqlCommand(selectQuery, connMySQL);
                            selectCmd.Parameters.AddWithValue("@CVE_ART", cveArt);
                            object result = selectCmd.ExecuteScalar();

                            if (result != null)
                            {
                                string descrMySQL = result.ToString().Trim();

                                if (descrSAE != descrMySQL)
                                {
                                    string updateQuery = "UPDATE elastosystem_sae_productos SET Descripcion = @DESCR WHERE Producto = @CVE_ART";
                                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, connMySQL);
                                    updateCmd.Parameters.AddWithValue("@DESCR", descrSAE);
                                    updateCmd.Parameters.AddWithValue("@CVE_ART", cveArt);
                                    updateCmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                string insertQuery = "INSERT INTO elastosystem_sae_productos (Producto, Descripcion) VALUES (@CVE_ART, @DESCR)";
                                MySqlCommand insertCmd = new MySqlCommand(insertQuery, connMySQL);
                                insertCmd.Parameters.AddWithValue("@CVE_ART", cveArt);
                                insertCmd.Parameters.AddWithValue("@DESCR", descrSAE);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                        connMySQL.Close();
                    }

                    reader.Close();
                    connFB.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR DESCRIPCIONES DE PRODUCTOS DE SAE: " + ex.Message);
            }
        }

        private void CargarSolicitudesFabricacion()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = @"
                        SELECT
                            Folio_ALT,
                            IFNULL(Fecha, '0000-00-00') AS Fecha,
                            Solicitante,
                            Clave,
                            Cantidad,
                            Notas
                        FROM elastosystem_almacen_solicitud_fabricacion
                        WHERE Estatus = 'Enviada'
                        ORDER BY Folio_ALT ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);
                            dgvSolicitudesFabricacion.DataSource = dt;
                            dgvSolicitudesFabricacion.Columns["Folio_ALT"].HeaderText = "Folio";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR SOLICITUDES DE FABRICACION: " + ex.Message);
            }
        }

        private void CargarOrdenesProduccion()
        {

        }

        private void dgvSolicitudesFabricacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pnlInicio.Visible = false;
            btnRegresar.Visible = true;

            lblSolicitudFabricacion.Text = "ERROR";
            lblSolicitante.Text = "ERROR";
            lblClave.Text = "ERROR";
            lblCantidad.Text = "ERROR";
            txbNotas.Clear();

            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string folio = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblSolicitudFabricacion.Text = folio;

                string solicitante = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                lblSolicitante.Text = solicitante;

                string clave = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                lblClave.Text = clave;
                lblClave2.Text = clave;

                string cantidad = dgv.Rows[rowIndex].Cells[4].Value.ToString();
                lblCantidad.Text = cantidad;

                string notas = dgv.Rows[rowIndex].Cells[5].Value.ToString();
                txbNotas.Text = notas;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            pnlInicio.Visible = true;
            btnRegresar.Visible = false;
            CargarSolicitudesFabricacion();
            CargarOrdenesProduccion();
        }

        private void chbLinea_CheckedChanged(object sender, EventArgs e)
        {
            if(chbLinea.Checked == true)
            {
                chbProdEspecial.Checked = false;
            }
        }

        private void chbProdEspecial_CheckedChanged(object sender, EventArgs e)
        {
            if (chbProdEspecial.Checked == true)
            {
                chbLinea.Checked = false;
                //CargarInfo();
            }
        }

        private void CargarInfo()
        {

        }
    }
}
