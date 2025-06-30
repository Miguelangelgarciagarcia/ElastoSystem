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
    public partial class Produccion_OP : Form
    {
        public Produccion_OP(string folio, string solicitud)
        {
            InitializeComponent();
            lblFolioOP.Text = folio;
            lblSolicitudFabricacion.Text = solicitud;
            CargarInfoOP();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void label8_Click(object sender, EventArgs e)
        {

        }

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

        private void CargarInfoOP()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Firma, Tipo, FechaInicio, FechaEntrega, Clave, CantidadSolicitada, Cliente, OC, Especificacion FROM elastosystem_produccion_orden_produccion WHERE Folio_ALT = @FOLIO";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FOLIO", lblFolioOP.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblAutorizo.Text = reader["Firma"].ToString();

                                string tipo = reader["Tipo"].ToString();
                                if (tipo == "Linea")
                                {
                                    chbLinea.Checked = true;
                                    chbProdEspecial.Checked = false;
                                }
                                else
                                {
                                    chbLinea.Checked = false;
                                    chbProdEspecial.Checked = true;
                                    btnDatosProdEspecial.Visible = true;
                                }

                                if (DateTime.TryParse(reader["FechaInicio"].ToString(), out DateTime fechaInicio))
                                {
                                    lblFechaInicio.Text = fechaInicio.ToString("dd / MMMM / yyyy", new System.Globalization.CultureInfo("es-MX"));
                                }

                                if (DateTime.TryParse(reader["FechaEntrega"].ToString(), out DateTime fechaEntrega))
                                {
                                    lblFechaEntrega.Text = fechaEntrega.ToString("dd / MMMM / yyyy", new System.Globalization.CultureInfo("es-MX"));
                                }

                                lblClave.Text = reader["Clave"].ToString();

                                lblCantidad.Text = reader["CantidadSolicitada"].ToString();

                                txbCliente.Text = reader["Cliente"].ToString();

                                txbOC.Text = reader["OC"].ToString();

                                txbEspecificacion.Text = reader["Especificacion"].ToString();
                            }
                        }
                    }
                    CargarOperaciones();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL OBTENER LA INFORMACION DE LA ORDEN DE PRODUCCION:" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void lblClave_TextChanged(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Descripcion FROM elastosystem_sae_productos WHERE Producto = @PRODUCTO";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PRODUCTO", lblClave.Text);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblDescripcion.Text = reader["Descripcion"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No se encontró la descripción del producto con la clave: " + lblClave.Text);
                                lblDescripcion.Text = "No disponible";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL OBTENER LA DESCRIPCION DEL PRODUCTO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void CargarOperaciones()
        {
            dgvOperaciones.Rows.Clear();

            string folio = lblFolioOP.Text;
            string[] parteFolio = folio.Split('-');
            string variableFolio = parteFolio.Length > 1 ? parteFolio[1] : folio;

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT ID, Descripcion, Operacion, Cantidad, Estatus
                                FROM elastosystem_produccion_ot_precreadas
                                WHERE OP = @OP AND Estatus <> 'Inactiva'
                                ORDER BY
                                    CAST(CASE
                                        WHEN operacion REGEXP '^[0-9]+$' THEN Operacion
                                        WHEN Operacion REGEXP '^[0-9]+-[A-Z]$' THEN SUBSTRING_INDEX(Operacion, '-', 1)
                                        ELSE Operacion
                                    END AS UNSIGNED),
                                    CASE
                                        WHEN Operacion REGEXP '^[0-9]+$' THEN ''
                                        WHEN Operacion REGEXP '^[0-9]+-[A-Z]$' THEN SUBSTRING_INDEX(Operacion , '-', -1)
                                    END";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OP", lblFolioOP.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = reader["ID"].ToString();
                                string descripcion = reader["Descripcion"].ToString();
                                string operacion = reader["Operacion"].ToString();
                                string cantidad = reader["Cantidad"].ToString();

                                string ot = $"OT-{variableFolio}-{operacion}";

                                dgvOperaciones.Rows.Add(id, descripcion, ot, cantidad);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR LAS OPERACIONES: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnDatosProdEspecial_Click(object sender, EventArgs e)
        {
            CargarInfoProdEspecial();
        }

        private void CargarInfoProdEspecial()
        {
            using (var formProdEspecial = new Produccion_ProdEspecial())
            {
                if (!string.IsNullOrWhiteSpace(txbCliente.Text))
                    formProdEspecial.Cliente = txbCliente.Text;

                if (!string.IsNullOrWhiteSpace(txbOC.Text))
                    formProdEspecial.OC = txbOC.Text;

                if (!string.IsNullOrWhiteSpace(txbEspecificacion.Text))
                    formProdEspecial.Especificacion = txbEspecificacion.Text;

                var resultado = formProdEspecial.ShowDialog();

            }
        }

        private void dgvOperaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string idSeleccionado = dgvOperaciones.Rows[e.RowIndex].Cells[0].Value.ToString();

                using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT Estatus FROM elastosystem_produccion_ot_precreadas WHERE OP = @OP AND ID = @ID";
                        using(MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@OP", lblFolioOP.Text);
                            cmd.Parameters.AddWithValue("@ID", idSeleccionado);

                            object result = cmd.ExecuteScalar();

                            if(result != null && result.ToString() == "Activa")
                            {
                                CrearOToRelacionar();
                            }
                            else
                            {
                                AbrirOT();
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("ERROR AL CONSULTAR EL ESTATUS DE LA OPERACION: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void CrearOToRelacionar()
        {
            using(Produccion_CrearOToRelacionar form = new Produccion_CrearOToRelacionar())
            {
                int resultado = form.ShowDialogResult();

                if(resultado == 0)
                {
                    RelacionarOT();
                }
                else if(resultado == 1)
                {
                    CrearOT();
                }
                else
                {
                    return;
                }
            }
        }

        private void RelacionarOT()
        {

        }

        private void CrearOT()
        {
            
        }

        private void AbrirOT()
        {

        }
    }
}
