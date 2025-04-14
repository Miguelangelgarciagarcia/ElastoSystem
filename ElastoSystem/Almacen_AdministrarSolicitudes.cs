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
    public partial class Almacen_AdministrarSolicitudes : Form
    {
        public Almacen_AdministrarSolicitudes()
        {
            InitializeComponent();
        }

        private void Almacen_AdministrarSolicitudes_Load(object sender, EventArgs e)
        {
            CargarSAE();
            CargarSolicitudes();
        }

        private void CargarSAE()
        {
            try
            {
                dgvProductosSAE2.AutoGenerateColumns = true;

                FbConnectionStringBuilder cadena = new FbConnectionStringBuilder();
                cadena.UserID = "SYSDBA";
                cadena.Password = "masterkey";
                cadena.Database = VariablesGlobales.DireccionBDSAE;
                cadena.DataSource = VariablesGlobales.IPSAE;
                cadena.Port = 3050;

                FbConnection conn = new FbConnection(cadena.ConnectionString);
                FbCommand comando = new FbCommand();
                FbDataAdapter adaptador = new FbDataAdapter();
                DataSet datos = new DataSet();
                string sql = "SELECT CVE_ART, EXIST FROM mult01 WHERE CVE_ALM = 1";

                comando.Connection = conn;
                comando.CommandText = sql;
                adaptador.SelectCommand = comando;

                conn.Open();
                adaptador.Fill(datos);
                conn.Close();

                bSAspelSAE.DataSource = datos.Tables[0];
                dgvProductosSAE2.DataSource = bSAspelSAE;

                ActualizarBDProductosSAE();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR LOS PRODUCTOS DE ASPEL SAE: " + ex.Message);
            }
        }

        private void ActualizarBDProductosSAE()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dgvProductosSAE2.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string cveArt = row.Cells["CVE_ART"].Value.ToString();
                            string existencia = row.Cells["EXIST"].Value.ToString();

                            string checkQuery = "SELECT COUNT(*) FROM elastosystem_sae_productos WHERE Producto = @CVE_ART";
                            MySqlCommand cmd = new MySqlCommand(checkQuery, conn);
                            cmd.Parameters.AddWithValue("@CVE_ART", cveArt);
                            int count = Convert.ToInt32(cmd.ExecuteScalar());

                            if (count > 0)
                            {
                                string updateQuery = "UPDATE elastosystem_sae_productos SET Existencia = @EXISTENCIA WHERE Producto = @CVE_ART";
                                MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                                updateCmd.Parameters.AddWithValue("@EXISTENCIA", existencia);
                                updateCmd.Parameters.AddWithValue("@CVE_ART", cveArt);
                                updateCmd.ExecuteNonQuery();
                            }
                            else
                            {
                                string insertQuery = "INSERT INTO elastosystem_sae_productos (Producto, Existencia) VALUES (@CVE_ART, @EXISTENCIAS)";
                                MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                                insertCmd.Parameters.AddWithValue("@CVE_ART", cveArt);
                                insertCmd.Parameters.AddWithValue("@EXISTENCIAS", existencia);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                    conn.Close();
                }
                VariablesGlobales.UltimaActualizacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HUBO UN ERROR AL ACTUALIZAR EXISTENCIAS DE SAE EN BD: " + ex.Message);
            }
        }

        private void CargarSolicitudes()
        {
            try
            {
                dgvSolicitudes.DataSource = null;
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = @"
                        SELECT
                            Folio_ALT,
                            IFNULL(Fecha, '0000-00-00') AS Fecha,
                            Clave,
                            Cantidad,
                            Notas
                        FROM elastosystem_almacen_solicitud_fabricacion
                        WHERE Estatus = 'Enviada'
                        ORDER BY Folio_ALT DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);
                            dgvSolicitudes.DataSource = dt;
                            dgvSolicitudes.Columns["Folio_ALT"].HeaderText = "Folio";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las solicitudes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSolicitudes_Click(object sender, EventArgs e)
        {
            lblClave.Text = string.Empty;
            lblCantidadActual.Text = string.Empty;
            lblMeses.Text = string.Empty;
            lbl1Mes.Text = string.Empty;
            lbl2Meses.Text = string.Empty;
            lbl3Meses.Text = string.Empty;
            lbl4Meses.Text = string.Empty;
            lblFolio.Text = string.Empty;
            lblFecha.Text = string.Empty;
            txbCantidad.Text = string.Empty;
            txbNotas.Text = string.Empty;

            btnCancelarSolicitud.Visible = true;
            btnActualizarSolicitud.Visible = true;

            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string folio = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblFolio.Text = folio;

                string fecha = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                if (fecha != "0000-00-00")
                {
                    lblFecha.Text = fecha;
                }

                string clave = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                lblClave.Text = clave;

                string cantidad = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                txbCantidad.Text = cantidad;

                string notas = dgv.Rows[rowIndex].Cells[4].Value.ToString();
                txbNotas.Text = notas;

                CargarInformacion();
            }
        }

        private void CargarInformacion()
        {
            string sql = "SELECT `Existencia`, `1M`, `2M`, `3M`, `4M`, `Meses` FROM elastosystem_sae_productos WHERE Producto = @PRODUCTO";
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@PRODUCTO", lblClave.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int cantidadActual = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                int mes1 = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                                int mes2 = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                                int mes3 = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                                int mes4 = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                                double mesesprom = reader.IsDBNull(5) ? 0 : reader.GetDouble(5);

                                lblCantidadActual.Text = cantidadActual.ToString();
                                lbl1Mes.Text = mes1.ToString();
                                lbl2Meses.Text = mes2.ToString();
                                lbl3Meses.Text = mes3.ToString();
                                lbl4Meses.Text = (mes4 + 1).ToString();
                                lblMeses.Text = mesesprom.ToString();

                                if (lbl1Mes.Text == "0" && lbl2Meses.Text == "0" && lbl3Meses.Text == "0" && lbl4Meses.Text == "1")
                                {
                                    lbl1Mes.Text = "------";
                                    lbl2Meses.Text = "------";
                                    lbl3Meses.Text = "------";
                                    lbl4Meses.Text = "------";
                                    lblMeses.Text = "SD";

                                    return;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL LLAMAR EL RESTO DE INFORMACION DEL PRODUCTO: " + ex.Message);
                }
            }
        }

        private void btnCancelarSolicitud_Click(object sender, EventArgs e)
        {
            CancelarSolicitud();
        }

        private void CancelarSolicitud()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    string cancelacion = "Cancelada";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    string query = "UPDATE elastosystem_almacen_solicitud_fabricacion SET Estatus = @ESTATUS, OP = @OP, Finalizado = @FINALIZADO WHERE Folio_ALT = @FOLIO";
                    cmd.Parameters.AddWithValue("@ESTATUS", cancelacion);
                    cmd.Parameters.AddWithValue("OP", cancelacion);
                    cmd.Parameters.AddWithValue("@FINALIZADO", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@FOLIO", lblFolio.Text);
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("SOLICITUD DE FABRICACION CANCELADA CON EXITO");
                    Limpiar();
                    CargarSAE();
                    CargarSolicitudes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CANCELAR LA SOLICITUD DE FABRICACION: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void Limpiar()
        {
            lblClave.Text = "-------------------";
            lblCantidadActual.Text = "-------------------";
            lblMeses.Text = "------";
            lbl1Mes.Text = "------";
            lbl2Meses.Text = "------";
            lbl3Meses.Text = "------";
            lbl4Meses.Text = "------";
            lblFolio.Text = "-------------------";
            lblFecha.Text = "-------------------";
            txbCantidad.Clear();
            txbNotas.Clear();

            btnCancelarSolicitud.Visible = false;
            btnActualizarSolicitud.Visible = false;
        }

        private void txbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            VariablesGlobales.ValidarNumeroEntero(e, txbCantidad);
        }

        private void btnActualizarSolicitud_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txbCantidad.Text) || txbCantidad.Text == "0")
            {
                MessageBox.Show("NO PUEDES ACTUALIZAR UNA SOLICITUD DE FABRICACION CON CANTIDAD EN 0");
                return;
            }

            int cantidadActual = int.TryParse(lblCantidadActual.Text, out int actual) ? actual : 0;
            int cantidad4Meses = int.TryParse(lbl4Meses.Text, out int cuatroMeses) ? cuatroMeses : 0;
            int cantidad = int.TryParse(txbCantidad.Text, out int txb) ? txb : 0;

            if(cantidadActual + cantidad >= cantidad4Meses)
            {
                Almacen_SobreInventario2 sobreInventario = new Almacen_SobreInventario2();
                if(sobreInventario.ShowDialog() == DialogResult.OK)
                {
                    ActualizarSolicitud();
                }
            }
            else
            {
                ActualizarSolicitud();
            }   
        }

        private void ActualizarSolicitud()
        {
            using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    string query = "UPDATE elastosystem_almacen_solicitud_fabricacion SET Fecha = @FECHA, Hora = @HORA, Solicitante = @SOLICITANTE, Cantidad = @CANTIDAD, Notas = @NOTAS WHERE Folio_ALT = @FOLIO";
                    cmd.Parameters.AddWithValue("@FECHA", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@HORA", DateTime.Now.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@SOLICITANTE", VariablesGlobales.Usuario);
                    cmd.Parameters.AddWithValue("@CANTIDAD", txbCantidad.Text);
                    cmd.Parameters.AddWithValue("@NOTAS", txbNotas.Text);
                    cmd.Parameters.AddWithValue("@FOLIO", lblFolio.Text);
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("SOLICITUD DE FABRICACION ACTUALIZADA CON EXITO");
                    Limpiar();
                    CargarSAE();
                    CargarSolicitudes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR LA SOLICITUD DE FABRICACION: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
