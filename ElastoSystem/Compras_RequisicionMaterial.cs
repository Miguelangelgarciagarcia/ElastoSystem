using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElastoSystem
{
    public partial class Compras_RequisicionMaterial : Form
    {
        public Compras_RequisicionMaterial()
        {
            InitializeComponent();
            ConfigurarDGV();
        }

        private void ConfigurarDGV()
        {
            dgvCotizaciones.ColumnHeadersVisible = false;

            dgvCotizaciones.Columns.Add("Nombre", "Nombre del Archivo");
            dgvCotizaciones.Columns.Add("Ruta", "Ruta del Archivo");
            dgvCotizaciones.Columns.Add("Tamano", "Tamano (bytes)");

            dgvCotizaciones.Columns[1].Visible = false;
            dgvCotizaciones.Columns[2].Visible = false;
        }

        private void AgregarADgv()
        {
            if (string.IsNullOrEmpty(txbDescripcion.Text) || string.IsNullOrEmpty(txbCantidad.Text) || cbUnidad.SelectedIndex == -1)
            {
                MessageBox.Show("DEBES DE LLENAR LOS CAMPOS OBLIGATORIOS");
                return;
            }

            string descripcion = txbDescripcion.Text;
            string cantidad = txbCantidad.Text;
            string unidad = cbUnidad.Text;
            string precio = string.IsNullOrEmpty(txbPrecio.Text) || txbPrecio.Text == "." ? "0" : txbPrecio.Text;
            string proveedor = cbProveedor.Text;
            string tipouso = cbTipoUso.Text;
            string comentarios = txbNotas.Text;
            bool chbOnline = chbCompraOnline.Checked;

            List<object> rowData = new List<object>
            {
                descripcion, cantidad, unidad, precio, proveedor, tipouso, comentarios, chbOnline
            };

            for(int i = 0; i < dgvCotizaciones.Rows.Count; i++)
            {
                if (dgvCotizaciones.Rows[i].Cells[0].Value != null)
                {
                    rowData.Add(dgvCotizaciones.Rows[i].Cells[2].Value);
                    rowData.Add(dgvCotizaciones.Rows[i].Cells[0].Value);
                    rowData.Add(dgvCotizaciones.Rows[i].Cells[1].Value);
                }
            }

            dgvListaMateriales.Rows.Add(rowData.ToArray());

            txbDescripcion.Clear();
            txbCantidad.Clear();
            cbUnidad.Text = null;
            txbPrecio.Clear();
            cbProveedor.Text = null;
            cbTipoUso.Text = null;
            txbNotas.Clear();
            chbCompraOnline.Checked = false;
            archivoByte = null;
            dgvCotizaciones.DataSource = null;
            dgvCotizaciones.Rows.Clear();
        }
        private void Tabs()
        {
            txbDescripcion.Focus();
            txbDescripcion.TabIndex = 0;
            txbCantidad.TabIndex = 1;
            cbUnidad.TabIndex = 2;
            txbPrecio.TabIndex = 3;
            cbProveedor.TabIndex = 4;
            btnAgregar.TabIndex = 5;
        }
        private void Eliminar()
        {
            foreach (DataGridViewRow row in dgvListaMateriales.SelectedRows)
            {
                dgvListaMateriales.Rows.Remove(row);
            }
            txbDescripcion.Clear(); txbCantidad.Clear(); cbUnidad.Text = null; txbPrecio.Clear(); cbProveedor.Text = null; cbTipoUso.Text = null; txbNotas.Clear(); dgvCotizaciones.DataSource = null; dgvCotizaciones.Rows.Clear(); archivoByte = null;
            btnEliminar.Visible = false;
            btnModificar.Visible = false;
            btnAgregar.Visible = true;
            btnNuevo.Visible = false;
            txbDescripcion.Focus();
        }
        private void Nuevo()
        {
            txbDescripcion.Clear();
            txbCantidad.Clear();
            cbUnidad.Text = null;
            txbPrecio.Clear();
            cbProveedor.Text = null;
            cbTipoUso.Text = null;
            txbNotas.Clear();
            dgvCotizaciones.DataSource = null;
            dgvCotizaciones.Rows.Clear();
            archivoByte = null;
            btnEliminar.Visible = false;
            btnModificar.Visible = false;
            btnAgregar.Visible = true;
            btnNuevo.Visible = false;
            txbDescripcion.Focus();
        }
        private void Modificar()
        {
            foreach (DataGridViewRow row in dgvListaMateriales.SelectedRows)
            {
                dgvListaMateriales.Rows.Remove(row);
            }
            AgregarADgv();
            btnNuevo.PerformClick();
        }
        private void MaNdarALlamarProveedores()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Nombre FROM elastosystem_compras_proveedores";
            try
            {
                HashSet<string> unicos = new HashSet<string>();
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbProveedor.Items.Add(reader["Nombre"].ToString());
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            cbProveedor.Sorted = true;
        }
        private void Fecha()
        {
            DateTime fechaActual = DateTime.Now;
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string fechaLarga = fechaActual.ToString("dddd, dd 'de' MMMM 'del' yyyy", CultureInfo.CurrentCulture);
            fechaLarga = textInfo.ToTitleCase(fechaLarga);
            lblfecha.Text = fechaLarga;
        }
        private void Folio()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT ID FROM elastosystem_compras_requisicion";

            try
            {
                int ultimoFolio = 0;
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string folioString = reader["ID"].ToString();
                        if (int.TryParse(folioString, out int folio))
                        {
                            ultimoFolio = folio;
                        }
                        else
                        {

                        }
                    }
                    ultimoFolio = ultimoFolio + 1;
                    lblFolio.Text = ultimoFolio.ToString();
                    lblFolioREQ.Text = "REQ-" + ultimoFolio.ToString();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
        private void EnviarRequerimiento()
        {
            string fecha = DateTime.Now.AddDays(1).ToString("yyyy/MM/dd");
            string estatus = "ABIERTA";
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT COUNT(*) FROM elastosystem_compras_requisicion WHERE ID = @ID";
                cmd.Parameters.AddWithValue("@ID", lblFolio.Text);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    Folio();
                    EnviarRequerimiento();
                }
                else
                {
                    cmd.CommandText = "INSERT INTO elastosystem_compras_requisicion (ID, ID_ALT, Usuario, Fecha, Estatus)" + "VALUES (@IDREQ, @IDALT, @SOLICITANTE, @FECHA, @ESTATUS)";
                    cmd.Parameters.AddWithValue("@IDREQ", lblFolio.Text);
                    cmd.Parameters.AddWithValue("@IDALT", lblFolioREQ.Text);
                    cmd.Parameters.AddWithValue("@SOLICITANTE", VariablesGlobales.Usuario);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    cmd.Parameters.AddWithValue("@ESTATUS", estatus);

                    cmd.ExecuteNonQuery();
                    EnviarRequisicionDesglosada();
                    txbDescripcion.Clear(); txbCantidad.Clear(); cbUnidad.Text = null; txbPrecio.Clear(); cbProveedor.Text = null; dgvListaMateriales.Rows.Clear(); txbNotas.Clear(); cbTipoUso.Text = null;
                    dgvCotizaciones.DataSource = null; dgvCotizaciones.Rows.Clear(); archivoByte = null;
                    MessageBox.Show("Orden: " + lblFolioREQ.Text + " enviada con exito");
                    Folio();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally { conn.Close(); }
        }
        private void EnviarRequisicionDesglosada()
        {
            string fechainicio = DateTime.Now.AddDays(1).ToString("yyyy/MM/dd");
            int filas = dgvListaMateriales.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                string descripcion = dgvListaMateriales.Rows[i].Cells["Descripcion"].Value.ToString();
                float cantidad = Convert.ToSingle(dgvListaMateriales.Rows[i].Cells["Cantidad"].Value);
                string unidad = dgvListaMateriales.Rows[i].Cells["Unidad"].Value.ToString();
                float precio = Convert.ToSingle(dgvListaMateriales.Rows[i].Cells["Precio"].Value);
                string proveedor = dgvListaMateriales.Rows[i].Cells["Proveedor"].Value.ToString();
                string tipouso = dgvListaMateriales.Rows[i].Cells["TipoUso"].Value.ToString();
                string comentarios = dgvListaMateriales.Rows[i].Cells["Comentarios"].Value.ToString();
                string estatus = "ABIERTA";
                bool online = Convert.ToBoolean(dgvListaMateriales.Rows[i].Cells["Onlinea"].Value);
                int valorOnline = online ? 1 : 0;

                object cotizacion1 = dgvListaMateriales.Rows[i].Cells["Cotizacion"].Value;
                byte[] archivo1 = cotizacion1 != null ? (byte[])cotizacion1 : null;
                object rutaCotizacionObj1 = dgvListaMateriales.Rows[i].Cells["Ruta"].Value;
                string rutaCotizacion1 = rutaCotizacionObj1 != null ? rutaCotizacionObj1.ToString() : string.Empty;

                object cotizacion2 = dgvListaMateriales.Rows[i].Cells["Cotizacion2"].Value;
                byte[] archivo2 = cotizacion2 != null ? (byte[])cotizacion2 : null;
                object rutaCotizacionObj2 = dgvListaMateriales.Rows[i].Cells["Ruta2"].Value;
                string rutaCotizacion2 = rutaCotizacionObj2 != null ? rutaCotizacionObj2.ToString() : string.Empty;

                object cotizacion3 = dgvListaMateriales.Rows[i].Cells["Cotizacion3"].Value;
                byte[] archivo3 = cotizacion3 != null ? (byte[])cotizacion3 : null;
                object rutaCotizacionObj3 = dgvListaMateriales.Rows[i].Cells["Ruta3"].Value;
                string rutaCotizacion3 = rutaCotizacionObj3 != null ? rutaCotizacionObj3.ToString() : string.Empty;

                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"INSERT INTO elastosystem_compras_requisicion_desglosada
                            (ID, Descripcion, Cantidad, Unidad, Precio, Proveedor, TipoUso, Comentarios, Estatus, Compra_Online, FechaInicio, Cotizacion1, Ruta_Cotizacion1, Cotizacion2, Ruta_Cotizacion2, Cotizacion3, Ruta_Cotizacion3)
                            VALUES (@ID, @DESCRIPCION, @CANTIDAD, @UNIDAD, @PRECIO, @PROVEEDOR, @TIPOUSO, @COMENTARIOS, @ESTATUS, @ONLINE, @FECHAINICIO, @COTIZACION1, @RUTACOTIZACION1, @COTIZACION2, @RUTACOTIZACION2, @COTIZACION3, @RUTACOTIZACION3);";

                        cmd.Parameters.AddWithValue("@ID", lblFolio.Text);
                        cmd.Parameters.AddWithValue("@DESCRIPCION", descripcion);
                        cmd.Parameters.AddWithValue("@CANTIDAD", cantidad);
                        cmd.Parameters.AddWithValue("@UNIDAD", unidad);
                        cmd.Parameters.AddWithValue("@PRECIO", precio);
                        cmd.Parameters.AddWithValue("@PROVEEDOR", proveedor);
                        cmd.Parameters.AddWithValue("@TIPOUSO", tipouso);
                        cmd.Parameters.AddWithValue("@COMENTARIOS", comentarios);
                        cmd.Parameters.AddWithValue("@ESTATUS", estatus);
                        cmd.Parameters.AddWithValue("@ONLINE", valorOnline);
                        cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);

                        if (archivo1 != null)
                            cmd.Parameters.Add("@COTIZACION1", MySqlDbType.LongBlob).Value = archivo1;
                        else
                            cmd.Parameters.AddWithValue("@COTIZACION1", DBNull.Value);

                        if (!string.IsNullOrEmpty(rutaCotizacion1))
                            cmd.Parameters.AddWithValue("@RUTACOTIZACION1", rutaCotizacion1);
                        else
                            cmd.Parameters.AddWithValue("@RUTACOTIZACION1", DBNull.Value);

                        if (archivo2 != null)
                            cmd.Parameters.Add("@COTIZACION2", MySqlDbType.LongBlob).Value = archivo2;
                        else
                            cmd.Parameters.AddWithValue("@COTIZACION2", DBNull.Value);

                        if (!string.IsNullOrEmpty(rutaCotizacion2))
                            cmd.Parameters.AddWithValue("@RUTACOTIZACION2", rutaCotizacion2);
                        else
                            cmd.Parameters.AddWithValue("@RUTACOTIZACION2", DBNull.Value);

                        if (archivo3 != null)
                            cmd.Parameters.Add("@COTIZACION3", MySqlDbType.LongBlob).Value = archivo3;
                        else
                            cmd.Parameters.AddWithValue("@COTIZACION3", DBNull.Value);

                        if (!string.IsNullOrEmpty(rutaCotizacion3))
                            cmd.Parameters.AddWithValue("@RUTACOTIZACION3", rutaCotizacion3);
                        else
                            cmd.Parameters.AddWithValue("@RUTACOTIZACION3", DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarADgv();
        }

        private void Compras_RequisicionMaterial_Load(object sender, EventArgs e)
        {
            MaNdarALlamarProveedores();
            Fecha();
            Folio();
            Tabs();
        }

        private void dgvListaMateriales_DoubleClick(object sender, EventArgs e)
        {
            btnEliminar.Visible = true;
            btnModificar.Visible = true;
            btnAgregar.Visible = false;
            btnNuevo.Visible = true;

            txbDescripcion.Clear();
            txbCantidad.Clear();
            cbUnidad.SelectedIndex = -1;
            txbPrecio.Clear();
            cbProveedor.SelectedIndex = -1;
            cbTipoUso.SelectedIndex = -1;
            txbNotas.Clear();
            chbCompraOnline.Checked = false;
            dgvCotizaciones.Rows.Clear();

            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string descripcion = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                txbDescripcion.Text = descripcion;

                string cantidad = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                txbCantidad.Text = cantidad;

                string unidad = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                cbUnidad.Text = unidad;

                string precio = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                txbPrecio.Text = precio;

                string proveedor = dgv.Rows[rowIndex].Cells[4].Value.ToString();
                cbProveedor.Text = proveedor;

                string tipouso = dgv.Rows[rowIndex].Cells[5].Value.ToString();
                cbTipoUso.Text = tipouso;

                string comentarios = dgv.Rows[rowIndex].Cells[6].Value.ToString();
                txbNotas.Text = comentarios;

                bool chbOnline = Convert.ToBoolean(dgv.Rows[rowIndex].Cells[7].Value);
                chbCompraOnline.Checked = chbOnline;

                int columnaInicio = 8;
                int maxCotizaciones = 3;

                for(int i = 0; i < maxCotizaciones; i++)
                {
                    int colFileBytes = columnaInicio + (i * 3);
                    int colFileName = columnaInicio + (i * 3) + 1;
                    int colFilePath = columnaInicio + (i * 3) + 2;

                    if (colFilePath < dgv.Columns.Count &&
                        dgv.Rows[rowIndex].Cells[colFileBytes].Value != null &&
                        dgv.Rows[rowIndex].Cells[colFileName].Value != null &&
                        dgv.Rows[rowIndex].Cells[colFilePath].Value != null)
                    {
                        byte[] fileBytes = (byte[])dgv.Rows[rowIndex].Cells[colFileBytes].Value;
                        string fileName = dgv.Rows[rowIndex].Cells[colFileName].Value.ToString();
                        string filePath = dgv.Rows[rowIndex].Cells[colFilePath].Value.ToString();

                        dgvCotizaciones.Rows.Add(fileName, filePath, fileBytes);
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnEnviarReq_Click(object sender, EventArgs e)
        {
            EnviarRequerimiento();
        }

        private void btnEnviarReq_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                EnviarRequerimiento();
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dgvListaMateriales.Rows.Count == 0)
            {
                MessageBox.Show("No hay materiales para enviar la requisición.");
                return;
            }
            EnviarRequerimiento();
        }

        private void cbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void txbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            VariablesGlobales.ValidarSoloNoyPunto(e, txbCantidad);
        }

        private void txbPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            VariablesGlobales.ValidarSoloNoyPunto(e, txbPrecio);
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            if (dgvCotizaciones.Rows.Count >= 3)
            {
                MessageBox.Show("El máximo de cotizaciones es 3, no puedes agregar más.");
                return;
            }
            CargarCotizacion();
        }

        private byte[] archivoByte;
        private void CargarCotizacion()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Todos los archivos (*.*)|*.*";
            file.Title = "Seleccionar Archivo";

            if (file.ShowDialog() == DialogResult.OK)
            {
                string filePath = file.FileName;
                string fileName = Path.GetFileName(filePath);
                try
                {
                    archivoByte = null;
                    archivoByte = File.ReadAllBytes(filePath);
                    AgregarCotizacionAlGrid(fileName, filePath, archivoByte);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR COTIZACION: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No se selecciono ningun archivo");
            }
        }

        private void AgregarCotizacionAlGrid(string fileName, string filePath, byte[] fileBytes)
        {
            dgvCotizaciones.Rows.Add(fileName, filePath, fileBytes);
        }

        private void dgvCotizaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                dgvCotizaciones.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
