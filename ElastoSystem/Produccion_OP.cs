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
        private DateTime? _fechaInicio;
        private DateTime? _fechaEntrega;
        private string _claveProducto;
        private string _folioOTSeleccionado;
        private string _folioOP;
        private string _folioSolicitudFabricacion;
        private string _operacion;

        public Produccion_OP(string folio, string solicitud)
        {
            InitializeComponent();
            lblFolioOP.Text = folio;
            _folioOP = folio;
            lblSolicitudFabricacion.Text = solicitud;
            _folioSolicitudFabricacion = solicitud;

            CargarInfoOP();
            CargarPT();
            CargarFirmas();

            chbFirmaGProduccion.CheckedChanged += CheckboxFirma_CheckedChanged;
            chbFirmaAlmacen.CheckedChanged += CheckboxFirma_CheckedChanged;
            chbFirmaGCalidad.CheckedChanged += CheckboxFirma_CheckedChanged;

            RevisarPermisoRegistroPT();
        }

        private void CargarPT()
        {
            string folioOP = lblFolioOP.Text?.Trim();

            if (string.IsNullOrWhiteSpace(folioOP))
            {
                txbCantidad.Text = "0";
                dgvIngresos.Rows.Clear();
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string querySuma = @"
                        SELECT COALESCE(SUM(Cantidad), 0) AS TotalCantidad
                        FROM elastosystem_produccion_pt
                        WHERE OP = @OP";

                    decimal totalCantidad = 0;
                    using (MySqlCommand cmdSuma = new MySqlCommand(querySuma, conn))
                    {
                        cmdSuma.Parameters.AddWithValue("@OP", folioOP);
                        object result = cmdSuma.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            totalCantidad = Convert.ToDecimal(result);
                        }
                    }

                    txbCantidad.Text = totalCantidad.ToString("N0");

                    string queryRegistros = @"
                        SELECT
                            ID,
                            Fecha,
                            Turno,
                            Cantidad,
                            Lote,
                            Entrego
                        FROM elastosystem_produccion_pt
                        WHERE OP = @OP
                        ORDER BY ID DESC";

                    using (MySqlCommand cmdRegistros = new MySqlCommand(queryRegistros, conn))
                    {
                        cmdRegistros.Parameters.AddWithValue("@OP", folioOP);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmdRegistros))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvIngresos.DataSource = dt;

                            dgvIngresos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                            dgvIngresos.Columns["Cantidad"].DefaultCellStyle.Format = "N0";
                            dgvIngresos.Columns["ID"].Visible = false;
                        }
                    }

                    if (dgvIngresos.Rows.Count == 0)
                    {

                    }

                    dgvIngresos.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar registros de PT:\n" + ex.Message, "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbCantidad.Text = "0";
                    dgvIngresos.Rows.Clear();
                }
            }
        }

        private void RevisarPermisoRegistroPT()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT pm.RegistroPT
                        FROM elastosystem_login l
                        INNER JOIN elastosystem_permisos_menu pm ON l.ID = pm.ID
                        WHERE l.Usuario = @USUARIO
                        LIMIT 1";

                    bool tienePermiso = false;

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@USUARIO", VariablesGlobales.Usuario);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            tienePermiso = Convert.ToBoolean(result);
                        }
                    }

                    btnRegistrarPT.Visible = tienePermiso;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar permiso para Registrar PT:\n" + ex.Message, "Error de permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnRegistrarPT.Visible = false;
                }
            }
        }

        private void CheckboxFirma_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk == null) return;

            string permisoRequerido = "";
            string columnaDB = "";

            if (chk == chbFirmaGProduccion)
            {
                permisoRequerido = "Firma_GProduccion";
                columnaDB = "FProduccion";
            }
            else if (chk == chbFirmaAlmacen)
            {
                permisoRequerido = "Firma_Almacen";
                columnaDB = "FAlmacen";
            }
            else if (chk == chbFirmaGCalidad)
            {
                permisoRequerido = "Firma_GCalidad";
                columnaDB = "FCalidad";
            }

            if (!TienePermisoFirma(permisoRequerido))
            {
                MessageBox.Show($"No tienes permiso para firmar en {chk.Text}.", "Sin permiso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chk.CheckedChanged -= CheckboxFirma_CheckedChanged;
                chk.Checked = !chk.Checked;
                chk.CheckedChanged += CheckboxFirma_CheckedChanged;
                return;
            }

            ActualizarFirmaEnBD(columnaDB, chk.Checked);

            ValidarPosibilidadCerrarOP();
        }

        private bool TienePermisoFirma(string nombrePermiso)
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT p." + nombrePermiso + @"
                        FROM elastosystem_permisos_menu p
                        INNER JOIN elastosystem_login l ON p.ID = l.ID
                        WHERE l.Usuario = @USUARIO";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@USUARIO", VariablesGlobales.Usuario);
                        object result = cmd.ExecuteScalar();
                        return result != null && Convert.ToBoolean(result);
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        private void ActualizarFirmaEnBD(string columna, bool valor)
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = $@"
                        UPDATE elastosystem_produccion_orden_produccion
                        SET {columna} = @VALOR
                        WHERE Folio_ALT = @FOLIO";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@VALOR", valor);
                        cmd.Parameters.AddWithValue("@FOLIO", lblFolioOP.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR AL GUARDAR FIRMA {columna}:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ValidarPosibilidadCerrarOP()
        {
            bool firmasCompletas = chbFirmaGProduccion.Checked &&
                                   chbFirmaAlmacen.Checked &&
                                   chbFirmaGCalidad.Checked;

            if (!firmasCompletas) return;

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string queryEstatus = "SELECT Estatus FROM elastosystem_produccion_orden_produccion WHERE Folio_ALT = @FOLIO";
                    using (MySqlCommand cmdEstatus = new MySqlCommand(queryEstatus, conn))
                    {
                        cmdEstatus.Parameters.AddWithValue("@FOLIO", lblFolioOP.Text.Trim());
                        string estatus = cmdEstatus.ExecuteScalar()?.ToString()?.Trim();

                        if (estatus != "Activa") return;
                    }

                    if (!decimal.TryParse(txbCantidad.Text, out decimal producida) ||
                        !decimal.TryParse(lblCantidad.Text, out decimal solicitada) ||
                        producida < solicitada)
                    {
                        return;
                    }

                    bool todasFinalizadas = true;
                    foreach (DataGridViewRow row in dgvOperaciones.Rows)
                    {
                        string estatusOT = row.Cells["EstatusOT"].Value?.ToString()?.Trim().ToUpper();
                        if (estatusOT != "FINALIZADA")
                        {
                            todasFinalizadas = false;
                            break;
                        }
                    }

                    if (!todasFinalizadas) return;

                    DialogResult resp = MessageBox.Show(
                        "La Orden de Producción cumple con todos los requisitos:\n" +
                        "• Todas las firmas están completas\n" +
                        "• Cantidad producida mayor o igual a la solicitada\n" +
                        "• Todas las operaciones están FINALIZADAS\n\n" +
                        "¿Desea cerrar la Orden de Producción ahora?",
                        "Cerrar Orden de Producción",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (resp == DialogResult.Yes)
                    {
                        //CERRAR ORDEN DE PRODUCCION
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL VALIDAR CIERRE DE OP:\n" + ex.Message);
                }
            }
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
                                    _fechaInicio = fechaInicio;
                                }

                                if (DateTime.TryParse(reader["FechaEntrega"].ToString(), out DateTime fechaEntrega))
                                {
                                    lblFechaEntrega.Text = fechaEntrega.ToString("dd / MMMM / yyyy", new System.Globalization.CultureInfo("es-MX"));
                                    _fechaEntrega = fechaEntrega;
                                }

                                lblClave.Text = reader["Clave"].ToString();
                                _claveProducto = lblClave.Text;

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

        private void CargarFirmas()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT FProduccion, FAlmacen, FCalidad,
                               Estatus, CantidadSolicitada
                        FROM elastosystem_produccion_orden_produccion
                        WHERE Folio_ALT = @FOLIO";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FOLIO", lblFolioOP.Text.Trim());

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                chbFirmaGProduccion.Checked = reader.GetBoolean("FProduccion");
                                chbFirmaAlmacen.Checked = reader.GetBoolean("FAlmacen");
                                chbFirmaGCalidad.Checked = reader.GetBoolean("FCalidad");

                                string estatusOP = reader["Estatus"].ToString().Trim();
                                lblEstatusOP.Text = estatusOP;
                            }
                        }
                    }

                    ValidarPosibilidadCerrarOP();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR FIRMAS:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            string folioOP = lblFolioOP.Text?.Trim();
            if (string.IsNullOrWhiteSpace(folioOP))
            {
                return;
            }

            string[] partesFolio = folioOP.Split('-');
            string variableFolio = partesFolio.Length > 1 ? partesFolio[1] : folioOP;

            if (!dgvOperaciones.Columns.Contains("Maquina"))
            {
                DataGridViewTextBoxColumn colMaquina = new DataGridViewTextBoxColumn
                {
                    Name = "Maquina",
                    HeaderText = "Máquina",
                    ReadOnly = true,
                    Width = 150,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
                };
                dgvOperaciones.Columns.Add(colMaquina);
            }

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            p.ID, 
                            p.Descripcion, 
                            p.Operacion, 
                            COALESCE(o.Cantidad, p.Cantidad) AS CantidadReal, 
                            p.Estatus,
                            COALESCE(o.Maquina, '') AS Maquina,
                            COALESCE(o.Estatus, 'SIN_OT') AS EstatusOT
                        FROM elastosystem_produccion_ot_precreadas p
                        LEFT JOIN elastosystem_produccion_ot o
                            ON o.Folio = CONCAT('OT-', @VARIABLEFOLIO, '-', p.Operacion)
                        WHERE p.OP = @OP 
                            AND p.Estatus <> 'Inactiva'
                        ORDER BY
                            CAST(CASE
                                WHEN p.Operacion REGEXP '^[0-9]+$' THEN p.Operacion
                                WHEN p.Operacion REGEXP '^[0-9]+-[A-Z]$' THEN SUBSTRING_INDEX(p.Operacion, '-', 1)
                                ELSE p.Operacion
                            END AS UNSIGNED),
                            CASE
                                WHEN p.Operacion REGEXP '^[0-9]+$' THEN ''
                                WHEN p.Operacion REGEXP '^[0-9]+-[A-Z]$' THEN SUBSTRING_INDEX(p.Operacion , '-', -1)
                            END";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OP", folioOP);
                        cmd.Parameters.AddWithValue("@VARIABLEFOLIO", variableFolio);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = reader["ID"].ToString();
                                string descripcion = reader["Descripcion"].ToString();
                                string operacion = reader["Operacion"].ToString();
                                string cantidad = reader["CantidadReal"].ToString();
                                string maquina = reader["Maquina"].ToString();
                                string estatusOT = reader["EstatusOT"].ToString().Trim().ToUpper();
                                string otGenerada = $"OT-{variableFolio}-{operacion}";

                                int rowIndex = dgvOperaciones.Rows.Add(id, descripcion, otGenerada, cantidad, maquina);

                                DataGridViewRow row = dgvOperaciones.Rows[rowIndex];

                                switch (estatusOT)
                                {
                                    case "ABIERTA":
                                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                                        row.DefaultCellStyle.ForeColor = Color.Black;
                                        break;

                                    case "PAUSADA":
                                        row.DefaultCellStyle.BackColor = Color.Yellow;
                                        row.DefaultCellStyle.ForeColor = Color.Black;
                                        break;

                                    case "FINALIZADA":
                                        row.DefaultCellStyle.BackColor = dgvOperaciones.DefaultCellStyle.BackColor;
                                        row.DefaultCellStyle.ForeColor = dgvOperaciones.DefaultCellStyle.ForeColor;
                                        break;

                                    default:
                                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                                        row.DefaultCellStyle.ForeColor = Color.Black;
                                        break;
                                }
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
            if (e.RowIndex < 0) return;

            string folioBuscado = dgvOperaciones.Rows[e.RowIndex].Cells[2].Value?.ToString()?.Trim();
            _folioOTSeleccionado = folioBuscado;

            if (string.IsNullOrEmpty(folioBuscado))
            {
                MessageBox.Show("No se pudo obtener el Folio de la OT");
                return;
            }

            string[] partesFolio = folioBuscado.Split('-');
            if (partesFolio.Length >= 3)
            {
                _operacion = string.Join("-", partesFolio.Skip(2));
            }
            else
            {
                MessageBox.Show("ERROR AL OBTENER OPERACION");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM elastosystem_produccion_ot WHERE Folio LIKE CONCAT('%', @FOLIO, '%')";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FOLIO", folioBuscado);

                        object result = cmd.ExecuteScalar();
                        int coincidencias = 0;
                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            coincidencias = count;
                        }

                        if (coincidencias > 0)
                        {
                            AbrirOT();
                        }
                        else
                        {
                            CrearOToRelacionar();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CONSULTAR FOLIO EN OT: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void CrearOToRelacionar()
        {
            using (Produccion_CrearOToRelacionar form = new Produccion_CrearOToRelacionar())
            {
                int resultado = form.ShowDialogResult();

                if (resultado == 0)
                {
                    RelacionarOT();
                }
                else if (resultado == 1)
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
            try
            {
                DateTime fechaInicio = _fechaInicio ?? DateTime.Now;
                DateTime fechaEntrega = _fechaEntrega ?? DateTime.Now;
                string claveProducto = !string.IsNullOrWhiteSpace(_claveProducto) ? _claveProducto : lblClave.Text?.Trim();
                string folioOT = _folioOTSeleccionado;

                if (string.IsNullOrWhiteSpace(folioOT))
                {
                    MessageBox.Show("ERROR AL OBTENER EL VALOR DE LA ORDEN DE TRABAJO");
                    return;
                }

                using (var form = new Produccion_CrearOT())
                {
                    form.FechaInicio = fechaInicio;
                    form.FechaFinal = fechaEntrega;
                    form.ClaveProducto = claveProducto;
                    form.FolioOT = folioOT;
                    form.FolioOP = _folioOP;
                    form.SolicitudFabricacion = _folioSolicitudFabricacion;
                    form.Operacion = _operacion;

                    dgvOperaciones.ClearSelection();
                    dgvOperaciones.CurrentCell = null;

                    DialogResult resultado = form.ShowDialog(this);

                    if(resultado == DialogResult.OK)
                    {
                        CargarOperaciones();
                        ValidarPosibilidadCerrarOP();
                    }
                    else if (resultado == DialogResult.Cancel)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ABRIR LA CREACION DE OT: " + ex.Message);
            }
        }

        private void AbrirOT()
        {
            try
            {
                string folioOT = _folioOTSeleccionado;
                string clave = lblClave.Text;

                if (string.IsNullOrWhiteSpace(folioOT))
                {
                    MessageBox.Show("ERROR AL OBTENER EL VALOR DE LA ORDEN DE TRABAJO");
                    return;
                }

                using (var form = new Produccion_OT())
                {
                    form.FolioOT = folioOT;
                    form.ClaveProd = clave;
                    dgvOperaciones.ClearSelection();
                    dgvOperaciones.CurrentCell = null;

                    var resultado = form.ShowDialog(this);

                    if (resultado == DialogResult.OK || resultado == DialogResult.Cancel)
                    {
                        CargarOperaciones();
                        ValidarPosibilidadCerrarOP();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ABRIR LA ORDEN DE TRABAJO: " + ex.Message);
            }
        }

        private void Produccion_OP_Load(object sender, EventArgs e)
        {
            ValidarPosibilidadCerrarOP();
        }

        private void dgvOperaciones_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvOperaciones.ClearSelection();
        }

        private void Produccion_OP_Shown(object sender, EventArgs e)
        {
            dgvOperaciones.ClearSelection();
            dgvOperaciones.CurrentCell = null;
        }

        private void chbProdEspecial_CheckedChanged(object sender, EventArgs e)
        {
            if (chbLinea.Checked)
            {
                chbProdEspecial.Checked = false;
            }
        }

        private void chbLinea_CheckedChanged(object sender, EventArgs e)
        {
            if (chbProdEspecial.Checked)
            {
                chbLinea.Checked = false;
            }
        }

        private void btnRegistrarPT_Click(object sender, EventArgs e)
        {
            string folioOP = lblFolioOP.Text?.Trim();

            if (string.IsNullOrWhiteSpace(folioOP))
            {
                MessageBox.Show("No se pudo obtener el folio de la Orden de Producción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var formPT = new Produccion_PT(folioOP))
            {
                var resultado = formPT.ShowDialog(this);

                if (resultado == DialogResult.OK)
                {
                    CargarInfoOP();
                    CargarPT();
                    ValidarPosibilidadCerrarOP();
                }
            }
        }

        private void dgvIngresos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvIngresos.ClearSelection();
        }
    }
}
