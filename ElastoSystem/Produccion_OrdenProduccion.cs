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
            dtpFechaEntrega.MinDate = DateTime.Now.AddDays(1);
            dgvProcesosCriticos.Columns["Operacion"].ReadOnly = true;
            dgvProcesosCriticos.Columns["Descripcion"].ReadOnly = true;
            dgvProcesosCriticos.Columns["OT"].ReadOnly = true;
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
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = @"
                        SELECT
                            Folio_ALT,
                            SolicitudFabricacion,
                            Clave,
                            Firma
                        FROM elastosystem_produccion_orden_produccion
                        WHERE Estatus = 'Activa'
                        ORDER BY Folio_ALT ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);
                            dgvOrdenesActivas.DataSource = dt;
                            dgvOrdenesActivas.Columns["Folio_ALT"].HeaderText = "Folio";
                            dgvOrdenesActivas.Columns["SolicitudFabricacion"].HeaderText = "Solicitud de Fabricación";
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR ORDENES DE PRODUCCION ACTIVAS: " + ex.Message);
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = @"
                        SELECT
                            Folio_ALT,
                            SolicitudFabricacion,
                            Clave,
                            Firma
                        FROM elastosystem_produccion_orden_produccion
                        WHERE Estatus = 'Finalizada'
                        ORDER BY Folio_ALT ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);
                            dgvOrdenesFinalizadas.DataSource = dt;
                            dgvOrdenesFinalizadas.Columns["Folio_ALT"].HeaderText = "Folio";
                            dgvOrdenesFinalizadas.Columns["SolicitudFabricacion"].HeaderText = "Solicitud de Fabricación";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR ORDENES DE PRODUCCION FINALIZADAS: " + ex.Message);
            }
        }

        private void dgvSolicitudesFabricacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dtpFechaEntrega.Value = DateTime.Now.AddDays(1);

            txbFamilia.Clear();

            pnlInicio.Visible = false;
            btnRegresar.Visible = true;

            lblSolicitudFabricacion.Text = "ERROR";
            lblSolicitante.Text = "ERROR";
            lblClave.Text = "ERROR";
            lblCantidad.Text = "ERROR";
            txbNotas.Clear();

            lblFolio.Text = "ERROR";
            lblFolioOriginal.Text = "ERROR";
            lblClave2.Text = "ERROR";
            lblDescripcion.Text = "ERROR";
            txbCantidad.Clear();
            chbLinea.Checked = true;
            chbProdEspecial.Checked = false;
            txbCliente.Clear();
            txbOC.Clear();
            txbEspecificacion.Clear();
            dgvProcesosCriticos.DataSource = null;
            btnDatosProdEspecial.Visible = false;

            AsignarFolio();

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

            MandarALlamarDescripcion();
            CargarCriticos();
            dgvProcesosCriticos.ClearSelection();
        }

        private void CargarCriticos()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            hp.NoOperacion AS Operacion,
                            hp.Descripcion,
                            hp.CantidadUnidad,
                            hr.Estatus
                        FROM elastosystem_produccion_hoja_producto hp
                        INNER JOIN elastosystem_produccion_hoja_ruta hr
                            ON hp.Familia = hr.Familia AND hp.NoOperacion = hr.NoOperacion
                        WHERE
                            hp.Producto = @CLAVE
                            AND hr.Critico = 1
                        ORDER BY hp.NoOperacion;";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CLAVE", lblClave.Text);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvProcesosCriticos.Rows.Clear();

                        while (reader.Read())
                        {
                            string operacion = reader["Operacion"].ToString();
                            string descripcion = reader["Descripcion"].ToString();
                            string cantidadUnidad = reader["CantidadUnidad"].ToString();
                            string estatus = reader["Estatus"].ToString();

                            string otPersonalizado = $"OT-{lblFolioOriginal.Text}-{operacion}";
                            string valorCero = "0";

                            dgvProcesosCriticos.Rows.Add(
                                operacion,
                                descripcion,
                                cantidadUnidad,
                                otPersonalizado,
                                valorCero,
                                estatus
                            );
                        }

                        foreach(DataGridViewRow row in dgvProcesosCriticos.Rows)
                        {
                            if (row.Cells["Estatus"].Value != null && row.Cells["Estatus"].Value.ToString() == "INACTIVA")
                            {
                                row.Visible = false;
                            }
                        }

                        if(dgvProcesosCriticos.Rows.Count == 0)
                        {
                            MessageBox.Show("No se encontraron operaciones críticas para el producto seleccionado, revisa tu Hoja de Ruta.");
                            btnRegresar.PerformClick();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR OPERACIONES CRITICAS: " + ex.Message);
                }
            }
        }

        private void AsignarFolio()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Folio FROM elastosystem_produccion_orden_produccion";

            try
            {
                int ultimoFolio = 0;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string folioString = reader["Folio"].ToString();
                        if (int.TryParse(folioString, out int folio))
                        {
                            ultimoFolio = folio;
                        }
                        else
                        {

                        }
                    }
                    ultimoFolio = ultimoFolio + 1;
                    lblFolio.Text = "OP-" + ultimoFolio.ToString();
                    lblFolioOriginal.Text = ultimoFolio.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ASIGNAR FOLIO A LA OP: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void MandarALlamarDescripcion()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    string query = "SELECT Descripcion FROM elastosystem_sae_productos WHERE Producto = @CLAVE";
                    cmd.Parameters.AddWithValue("@CLAVE", lblClave.Text);
                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    object resultado = cmd.ExecuteScalar();
                    if (resultado != null)
                    {
                        lblDescripcion.Text = resultado.ToString();
                    }
                    else
                    {
                        lblDescripcion.Text = "PRODUCTO SIN DESCRIPCION";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL OBTENER LA DESCRIPCION DE PRODUCTO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
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
            if (chbLinea.Checked == true)
            {
                chbProdEspecial.Checked = false;
                txbCliente.Clear();
                txbOC.Clear();
                txbEspecificacion.Clear();
            }
        }

        private void chbProdEspecial_CheckedChanged(object sender, EventArgs e)
        {
            if (chbProdEspecial.Checked == true)
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

        private void txbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            VariablesGlobales.ValidarNumeroEntero(e, txbCantidad);
        }

        private void CalcularCantidadesCriticas()
        {
            int cantidad = 0;

            if (!string.IsNullOrWhiteSpace(txbCantidad.Text))
            {
                if (!int.TryParse(txbCantidad.Text, out cantidad))
                {
                    MessageBox.Show("Por favor, ingresa un número entero válido.");
                    return;
                }
            }

            foreach (DataGridViewRow row in dgvProcesosCriticos.Rows)
            {
                if (row.Cells[2].Value != null)
                {
                    if (int.TryParse(row.Cells[2].Value.ToString(), out int cantidadUnidad))
                    {
                        int resultado = cantidad * cantidadUnidad;
                        row.Cells[4].Value = resultado.ToString();
                    }
                    else
                    {
                        row.Cells[4].Value = "0";
                    }
                }
                else
                {
                    row.Cells[4].Value = "0";
                }
            }
        }

        private void txbCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                CalcularCantidadesCriticas();
            }
        }

        private void txbCantidad_Leave(object sender, EventArgs e)
        {
            CalcularCantidadesCriticas();
        }

        private void btnFirmar_Click(object sender, EventArgs e)
        {
            if (dgvProcesosCriticos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona al menos una operación crítica para firmar.");
                return;
            }

            if (txbCantidad.Text == "")
            {
                MessageBox.Show("Por favor, ingresa una cantidad válida.");
                return;
            }

            int cantidadSF = int.Parse(lblCantidad.Text);
            int cantidadOP = int.Parse(txbCantidad.Text);

            if (cantidadOP < cantidadSF)
            {
                Produccion_OPMenor opMenor = new Produccion_OPMenor();
                if (opMenor.ShowDialog() == DialogResult.OK)
                {
                    FirmarOrdenProduccion();
                }
                else
                {
                    return;
                }
            }
            else
            {
                FirmarOrdenProduccion();
            }

        }

        private void FirmarOrdenProduccion()
        {
            ObtenerFamilia();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT COUNT(*) FROM elastosystem_produccion_orden_produccion WHERE Folio = @FOLIO";
                        cmd.Parameters.AddWithValue("@FOLIO", lblFolioOriginal.Text);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            AsignarFolio();
                            FirmarOrdenProduccion();
                        }
                        else
                        {
                            cmd.CommandText = "SELECT COUNT(*) FROM elastosystem_produccion_orden_produccion WHERE SolicitudFabricacion = @SOLICITUDF";
                            cmd.Parameters.AddWithValue("@SOLICITUDF", lblSolicitudFabricacion.Text);
                            count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (count > 0)
                            {
                                MessageBox.Show("Ya existe una orden de producción para esta solicitud de fabricación.");
                                return;
                            }
                            else
                            {
                                cmd.CommandText = @"
                                INSERT INTO elastosystem_produccion_orden_produccion
                                (Folio, Folio_ALT, Firma, SolicitudFabricacion, Tipo, FechaInicio, FechaEntrega, Clave, CantidadSolicitada, Estatus, Cliente, OC, Especificacion)
                                VALUES
                                (@FOLIO, @FOLIO_ALT, @FIRMA, @SOLICITUDFABRICACION, @TIPO, @FECHAINICIO, @FECHAENTREGA, @CLAVE, @CANTIDADSOLICITADA, @ESTATUS, @CLIENTE, @OC, @ESPECIFICACION)";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@FOLIO", lblFolioOriginal.Text);
                                cmd.Parameters.AddWithValue("@FOLIO_ALT", lblFolio.Text);
                                cmd.Parameters.AddWithValue("@FIRMA", VariablesGlobales.Usuario);
                                cmd.Parameters.AddWithValue("@SOLICITUDFABRICACION", lblSolicitudFabricacion.Text);
                                cmd.Parameters.AddWithValue("@TIPO", chbLinea.Checked ? "Linea" : "Especial");
                                cmd.Parameters.AddWithValue("@FECHAINICIO", DateTime.Now.ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@FECHAENTREGA", dtpFechaEntrega.Value);
                                cmd.Parameters.AddWithValue("@CLAVE", lblClave.Text);
                                cmd.Parameters.AddWithValue("@CANTIDADSOLICITADA", txbCantidad.Text);
                                cmd.Parameters.AddWithValue("@ESTATUS", "Activa");
                                cmd.Parameters.AddWithValue("@CLIENTE", txbCliente.Text);
                                cmd.Parameters.AddWithValue("@OC", txbOC.Text);
                                cmd.Parameters.AddWithValue("@ESPECIFICACION", txbEspecificacion.Text);

                                cmd.ExecuteNonQuery();

                                CrearOTPrevias();
                                enProcesoSolicitudFabricacion();
                                MessageBox.Show("ORDEN DE PRODUCCION FIRMADA CORRECTAMENTE.");
                                Limpiar();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL FIRMAR LA ORDEN DE PRODUCCIÓN: " + ex.Message);
                return;
            }
        }

        private void ObtenerFamilia()
        {
            try
            {
                using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT Familia FROM elastosystem_sae_productos WHERE Producto = @PRODUCTO";
                        cmd.Parameters.AddWithValue("@PRODUCTO", lblClave.Text);

                        object result = cmd.ExecuteScalar();
                        if(result != null && result != DBNull.Value)
                        {
                            txbFamilia.Text = result.ToString();
                        }
                        else
                        {
                            txbFamilia.Clear();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR AL OBTENER LA FAMILIA DEL PRODUCTO: " + ex.Message);
                txbFamilia.Clear();
            }
        }

        private void CrearOTPrevias()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    foreach (DataGridViewRow fila in dgvProcesosCriticos.Rows)
                    {
                        if (fila.IsNewRow) continue;

                        string operacion = fila.Cells["Operacion"].Value?.ToString() ?? "";
                        string descripcion = fila.Cells["Descripcion"].Value?.ToString() ?? "";
                        string cantidad = fila.Cells["Cantidad"].Value?.ToString() ?? "0";
                        string estatus = fila.Selected ? "Activa" : "Inactiva";

                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = @"
                                INSERT INTO elastosystem_produccion_ot_precreadas
                                (OP, Operacion, Descripcion, Cantidad, Estatus, Familia)
                                VALUES
                                (@OP, @OPERACION, @DESCRIPCION, @CANTIDAD, @ESTATUS, @FAMILIA)";
                            cmd.Parameters.AddWithValue("@OP", lblFolio.Text);
                            cmd.Parameters.AddWithValue("@OPERACION", operacion);
                            cmd.Parameters.AddWithValue("@DESCRIPCION", descripcion);
                            cmd.Parameters.AddWithValue("@CANTIDAD", cantidad);
                            cmd.Parameters.AddWithValue("@ESTATUS", estatus);
                            cmd.Parameters.AddWithValue("@FAMILIA", txbFamilia.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CREAR LAS OT PREVIAS: " + ex.Message);
            }
        }

        private void enProcesoSolicitudFabricacion()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    string enProceso = "En Proceso";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    string query = "UPDATE elastosystem_almacen_solicitud_fabricacion SET Estatus = @ESTATUS, OP = @OP, Cantidad_Produccion = @CANTIDADPRODUCCION WHERE Folio_ALT = @FOLIO_ALT";
                    cmd.Parameters.AddWithValue("@ESTATUS", enProceso);
                    cmd.Parameters.AddWithValue("@OP", lblFolio.Text);
                    cmd.Parameters.AddWithValue("@CANTIDADPRODUCCION", txbCantidad.Text);
                    cmd.Parameters.AddWithValue("@FOLIO_ALT", lblSolicitudFabricacion.Text);
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CERRAR SOLICITUD DE FABRICACION: " + ex.Message);
            }
        }

        private void Limpiar()
        {
            pnlInicio.Visible = true;
            btnRegresar.Visible = false;
            CargarSolicitudesFabricacion();
            CargarOrdenesProduccion();
        }

        private void dgvOrdenesActivas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvOrdenesActivas.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvOrdenesActivas.Rows[hit.RowIndex];
                    string valorFirma = fila.Cells["Firma"].Value?.ToString();

                    if (string.IsNullOrEmpty(valorFirma))
                        return;

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

                                string queryPermiso = "SELECT AdminOP FROM elastosystem_permisos_menu WHERE ID = @ID";
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
                        dgvOrdenesActivas.ClearSelection();
                        fila.Selected = true;

                        cmsOP.Show(dgvOrdenesActivas, e.Location);
                    }
                }
            }
        }

        private void AdminOP_Click(object sender, EventArgs e)
        {
            if (dgvOrdenesActivas.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvOrdenesActivas.SelectedRows[0];

                string folio = fila.Cells["Folio_ALT"].Value?.ToString() ?? "";
                string solicitud = fila.Cells["SolicitudFabricacion"].Value?.ToString() ?? "";

                Produccion_AdministrarOP formOP = new Produccion_AdministrarOP(folio, solicitud);
                formOP.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una orden de producción activa para administrar.");
                return;
            }
        }

        private void btnDatosProdEspecial_Click(object sender, EventArgs e)
        {
            CargarInfo();
        }

        private void dgvOrdenesActivas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvOrdenesActivas.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvOrdenesActivas.SelectedRows[0];

                string folio = fila.Cells["Folio_ALT"].Value?.ToString() ?? "";
                string solicitud = fila.Cells["SolicitudFabricacion"].Value?.ToString() ?? "";

                Produccion_OP formOP = new Produccion_OP(folio, solicitud);
                formOP.Show();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una orden de producción activa para ver sus detalles.");
                return;
            }
        }
    }
}
