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
            if (e.RowIndex < 0) return;

            string folioBuscado = dgvOperaciones.Rows[e.RowIndex].Cells[2].Value?.ToString()?.Trim();
            _folioOTSeleccionado = folioBuscado;

            if (string.IsNullOrEmpty(folioBuscado))
            {
                MessageBox.Show("No se pudo obtener el Folio de la OT");
                return;
            }

            string[] partesFolio = folioBuscado.Split('-');
            if(partesFolio.Length >= 3)
            {
                _operacion = string.Join("-", partesFolio.Skip(2));
            }
            else
            {
                MessageBox.Show("ERROR AL OBTENER OPERACION");
                return;
            }

            using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM elastosystem_produccion_ot WHERE Folio LIKE CONCAT('%', @FOLIO, '%')";
                    using(MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FOLIO", folioBuscado);

                        object result = cmd.ExecuteScalar();
                        int coincidencias = 0;
                        if(result != null && int.TryParse(result.ToString(), out int count))
                        {
                            coincidencias = count;
                        }

                        if(coincidencias > 0)
                        {
                            AbrirOT();
                        }
                        else
                        {
                            CrearOToRelacionar();
                        }
                    }
                }
                catch(Exception ex)
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

                    form.ShowDialog();
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

                if (string.IsNullOrWhiteSpace(folioOT))
                {
                    MessageBox.Show("ERROR AL OBTENER EL VALOR DE LA ORDEN DE TRABAJO");
                    return;
                }

                using(var form = new Produccion_OT())
                {
                    form.FolioOT = folioOT;

                    form.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR AL ABRIR LA ORDEN DE TRABAJO: " + ex.Message);
            }
        }

        private void Produccion_OP_Load(object sender, EventArgs e)
        {

        }
    }
}
