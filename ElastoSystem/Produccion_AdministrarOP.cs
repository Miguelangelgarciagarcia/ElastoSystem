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
    public partial class Produccion_AdministrarOP : Form
    {

        string valor = "Inicio";

        public Produccion_AdministrarOP(string folio, string solicitud)
        {
            InitializeComponent();
            lblSolicitudFabricacion.Text = solicitud;
            lblFolio.Text = folio;
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

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Produccion_AdministrarOP_Load(object sender, EventArgs e)
        {
            dgvOperaciones.ClearSelection();
        }

        private void lblSolicitudFabricacion_TextChanged(object sender, EventArgs e)
        {
            if (lblSolicitudFabricacion.Text == "ERROR")
            {

            }
            else
            {
                MandarALlamarInfoSF();
            }
        }

        private void MandarALlamarInfoSF()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Solicitante, Clave, Cantidad, Notas FROM elastosystem_almacen_solicitud_fabricacion WHERE FOLIO_ALT = @FOLIO";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FOLIO", lblSolicitudFabricacion.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblSolicitante.Text = reader["Solicitante"].ToString();
                                lblClave.Text = reader["Clave"].ToString();
                                lblCantidad.Text = reader["Cantidad"].ToString();
                                txbNotas.Text = reader["Notas"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos para la solicitud de fabricación con el folio: " + lblSolicitudFabricacion.Text);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL OBTENER LOS DATOS DE LA SOLICITUD DE FABRICACION: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void lblFolio_TextChanged(object sender, EventArgs e)
        {
            if (lblFolio.Text == "ERROR")
            {

            }
            else
            {
                MandarALlamarInfoOP();
                CargarOperaciones();
            }
        }

        private void CargarOperaciones()
        {
            dgvOperaciones.Rows.Clear();

            string folio = lblFolio.Text;
            string[] parteFolio = folio.Split('-');
            string variableFolio = parteFolio.Length > 1 ? parteFolio[1] : folio;

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT op.ID, op.Descripcion, op.Operacion, op.Cantidad, op.Estatus
                                FROM elastosystem_produccion_ot_precreadas op
                                JOIN elastosystem_produccion_hoja_ruta hr
                                    ON op.Operacion = hr.NoOperacion AND op.Familia = hr.Familia
                                WHERE op.OP = @OP
                                    AND hr.Estatus = 'ACTIVA'
                                ORDER BY
                                    CAST(CASE
                                        WHEN op.operacion REGEXP '^[0-9]+$' THEN op.Operacion
                                        WHEN op.Operacion REGEXP '^[0-9]+-[A-Z]$' THEN SUBSTRING_INDEX(op.Operacion, '-', 1)
                                        ELSE op.Operacion
                                    END AS UNSIGNED),
                                    CASE
                                        WHEN op.Operacion REGEXP '^[0-9]+$' THEN ''
                                        WHEN op.Operacion REGEXP '^[0-9]+-[A-Z]$' THEN SUBSTRING_INDEX(op.Operacion , '-', -1)
                                    END";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OP", lblFolio.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = reader["ID"].ToString();
                                string descripcion = reader["Descripcion"].ToString();
                                string operacion = reader["Operacion"].ToString();
                                string cantidad = reader["Cantidad"].ToString();
                                string estatus = reader["Estatus"].ToString();

                                string ot = $"OT-{variableFolio}-{operacion}";

                                dgvOperaciones.Rows.Add(id, descripcion, ot, cantidad, estatus);
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

        private void MandarALlamarInfoOP()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Clave, CantidadSolicitada, FechaEntrega, Tipo, Cliente, OC, Especificacion FROM elastosystem_produccion_orden_produccion WHERE Folio_ALT = @FOLIO";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FOLIO", lblFolio.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblClave2.Text = reader["Clave"].ToString();
                                txbCantidad.Text = reader["CantidadSolicitada"].ToString();

                                if (DateTime.TryParse(reader["FechaEntrega"].ToString(), out DateTime fechaEntrea))
                                {
                                    dtpFechaEntrega.Value = fechaEntrea;
                                }

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

                                valor = "ProdEspecial";
                                txbCliente.Text = reader["Cliente"].ToString();
                                txbOC.Text = reader["OC"].ToString();
                                txbEspecificacion.Text = reader["Especificacion"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos para la orden de producción con el folio: " + lblFolio.Text);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL OBTENER LOS DATOS DE LA ORDEN DE PRODUCCION: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void lblClave2_TextChanged(object sender, EventArgs e)
        {
            if (lblClave2.Text == "ERROR")
            {
            }
            else
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT Descripcion FROM elastosystem_sae_productos WHERE Producto = @PRODUCTO";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@PRODUCTO", lblClave2.Text);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    lblDescripcion.Text = reader["Descripcion"].ToString();
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró la descripción del producto con la clave: " + lblClave2.Text);
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
        }

        private void chbLinea_CheckedChanged(object sender, EventArgs e)
        {
            if (chbLinea.Checked)
            {
                chbProdEspecial.Checked = false;
                txbCliente.Clear();
                txbOC.Clear();
                txbEspecificacion.Clear();
                btnDatosProdEspecial.Visible = false;
            }
        }

        private void chbProdEspecial_CheckedChanged(object sender, EventArgs e)
        {
            if (chbProdEspecial.Checked && valor != "Inicio")
            {
                chbLinea.Checked = false;
                CargarInfo();
            }
        }

        private void CargarInfo()
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

                if (resultado == DialogResult.OK)
                {
                    txbCliente.Text = formProdEspecial.Cliente;
                    txbOC.Text = formProdEspecial.OC;
                    txbEspecificacion.Text = formProdEspecial.Especificacion;
                    btnDatosProdEspecial.Visible = true;
                }
                else
                {
                    chbLinea.Checked = true;
                    chbProdEspecial.Checked = false;
                    txbCliente.Clear();
                    txbOC.Clear();
                    txbEspecificacion.Clear();
                    btnDatosProdEspecial.Visible = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarInfo();
        }

        private void dgvOperaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnActualizarOperacion.Visible = true;
            btnDuplicarOperacion.Visible = true;

            txbDescripcion.Text = "";
            lblOT.Text = "ERROR";
            txbCantidadDGV.Text = "";
            cbEstatus.SelectedIndex = -1;
            lblID.Text = "ID ERROR";

            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblID.Text = id;

                string descripcion = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                txbDescripcion.Text = descripcion;

                string ot = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                lblOT.Text = ot;
                lblOT.Visible = true;

                if (!string.IsNullOrEmpty(ot))
                {
                    char ultimoCaracter = ot.Last();
                    if (char.IsLetter(ultimoCaracter))
                    {
                        btnDuplicarOperacion.Visible = false;
                    }
                }

                string cantidad = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                txbCantidadDGV.Text = cantidad;

                string estatus = dgv.Rows[rowIndex].Cells[4].Value.ToString();
                cbEstatus.SelectedItem = estatus;
            }
        }

        private void btnActualizarOperacion_Click(object sender, EventArgs e)
        {
            ActualizarOperacion();
        }

        private void ActualizarOperacion()
        {
            if (string.IsNullOrWhiteSpace(txbCantidadDGV.Text))
            {
                MessageBox.Show("Por favor, ingrese una cantidad válida.");
                return;
            }
            else
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE elastosystem_produccion_ot_precreadas SET Cantidad = @CANTIDAD, Estatus = @ESTATUS WHERE ID = @ID";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@CANTIDAD", txbCantidadDGV.Text);
                        cmd.Parameters.AddWithValue("@ESTATUS", cbEstatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ID", lblID.Text);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Operación actualizada correctamente.");
                        txbDescripcion.Clear();
                        lblOT.Text = "";
                        txbCantidadDGV.Clear();
                        cbEstatus.SelectedIndex = -1;
                        btnActualizarOperacion.Visible = false;
                        btnDuplicarOperacion.Visible = false;

                        CargarOperaciones();
                        dgvOperaciones.ClearSelection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR AL ACTUALIZAR LA OPERACION: " + ex.Message);
                    }
                }
            }
        }

        private void txbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            VariablesGlobales.ValidarNumeroEntero(e, txbCantidad);
        }

        private void txbCantidadDGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            VariablesGlobales.ValidarNumeroEntero(e, txbCantidad);
        }

        private void btnDuplicarOperacion_Click(object sender, EventArgs e)
        {
            DuplicarOperacion();
        }

        private void DuplicarOperacion()
        {
            if (string.IsNullOrWhiteSpace(txbCantidad.Text))
            {
                MessageBox.Show("Por favor, ingresa una cantidad válida.");
                return;
            }

            string numeroBase = lblOT.Text.Split('-').Last();
            string nuevaOperacion = "";

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string queryVerificar = "SELECT Operacion FROM elastosystem_produccion_ot_precreadas " +
                        "WHERE OP = @OP AND Operacion LIKE @PATRONOPERACION " +
                        "ORDER BY Operacion DESC LIMIT 1";

                    using (MySqlCommand cmdVerificar = new MySqlCommand(queryVerificar, conn))
                    {
                        cmdVerificar.Parameters.AddWithValue("@OP", lblFolio.Text);
                        cmdVerificar.Parameters.AddWithValue("@PATRONOPERACION", $"{numeroBase}-%");

                        object resultado = cmdVerificar.ExecuteScalar();

                        if (resultado == null)
                        {
                            nuevaOperacion = $"{numeroBase}-A";
                        }
                        else
                        {
                            string ultimaOperacon = resultado.ToString();
                            char ultimaLetra = ultimaOperacon.Last();
                            char siguienteLetra = (char)(ultimaLetra + 1);
                            nuevaOperacion = $"{numeroBase}-{siguienteLetra}";
                        }
                    }

                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        string estatus = "Activa";
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO elastosystem_produccion_ot_precreadas (OP, Operacion, Descripcion, Cantidad, Estatus)" +
                                          "VALUES (@OP, @OPERACION, @DESCRIPCION, @CANTIDAD, @ESTATUS)";
                        cmd.Parameters.AddWithValue("@OP", lblFolio.Text);
                        cmd.Parameters.AddWithValue("@OPERACION", nuevaOperacion);
                        cmd.Parameters.AddWithValue("@DESCRIPCION", txbDescripcion.Text);
                        cmd.Parameters.AddWithValue("@CANTIDAD", txbCantidadDGV.Text);
                        cmd.Parameters.AddWithValue("@ESTATUS", estatus);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Operacion duplicada correctamente");
                        txbDescripcion.Clear();
                        lblOT.Text = "";
                        txbCantidadDGV.Clear();
                        cbEstatus.SelectedIndex = -1;
                        btnActualizarOperacion.Visible = false;
                        btnDuplicarOperacion.Visible = false;
                        CargarOperaciones();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL DUPLICAR LA OPERACION: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        private void lblSolicitudFabricacion_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbCantidad.Text))
            {
                MessageBox.Show("Por favor, ingrese una cantidad válida.");
                return;
            }

            using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE elastosystem_produccion_orden_produccion SET Firma = @FIRMA, Tipo = @TIPO, FechaEntrega = @FECHAENTREGA, CantidadSolicitada = @CANTIDADSOLICITADA, Cliente = @CLIENTE, OC = @OC, Especificacion = @ESPECIFICACION WHERE Folio_ALT = @FOLIO";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FOLIO", lblFolio.Text);
                    cmd.Parameters.AddWithValue("@FIRMA", VariablesGlobales.Usuario);
                    cmd.Parameters.AddWithValue("@TIPO", chbLinea.Checked ? "Linea" : "Especial");
                    cmd.Parameters.AddWithValue("@FECHAENTREGA", dtpFechaEntrega.Value);
                    cmd.Parameters.AddWithValue("@CANTIDADSOLICITADA", txbCantidad.Text);
                    cmd.Parameters.AddWithValue("@CLIENTE", txbCliente.Text);
                    cmd.Parameters.AddWithValue("@OC", txbOC.Text);
                    cmd.Parameters.AddWithValue("@ESPECIFICACION", txbEspecificacion.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cambios guardados correctamente.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR AL GUARDAR LOS CAMBIOS: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
