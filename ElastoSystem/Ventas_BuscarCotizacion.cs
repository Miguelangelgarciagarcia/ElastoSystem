using DocumentFormat.OpenXml.Spreadsheet;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ElastoSystem.Compras_Administrar_Requisiciones;

namespace ElastoSystem
{
    public partial class Ventas_BuscarCotizacion : Form
    {
        public Ventas_BuscarCotizacion()
        {
            InitializeComponent();
        }
        private void Fecha()
        {
            DateTime fechaActual = DateTime.Now;
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string fechaLarga = fechaActual.ToString("dd '/' MMMM '/' yyyy", CultureInfo.CurrentCulture);
            fechaLarga = textInfo.ToTitleCase(fechaLarga);
            lblFecha.Text = fechaLarga;
        }
        private void LimpiarCotizacion()
        {
            Fecha();
            lblIDCliente.Text = null;
            txbContacto.Clear();
            txbEmpresa.Clear();
            txbTelefono.Text = null;
            txbCorreo.Text = null;
            cbClave.Text = null;
            cbProductos.Text = null;
            txbCantidad.Text = null;
            txbPrecio.Text = null;
            dgvListaProductos.DataSource = null;
            dgvListaProductos.Rows.Clear();
            txbPartidas.Text = null;
            chbSigla03.Checked = true;
            txbSubtotal.Text = null;
            txbIVA.Text = null;
            chbDescuento.Checked = false;
            txbTotal.Text = null;
        }
        private void Clave()
        {
            cbClave.Items.Clear();
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Clave FROM elastosystem_ventas_productos";
            try
            {
                HashSet<string> unicos = new HashSet<string>();
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbClave.Items.Add(reader["Clave"].ToString());
                    }
                    cbClave.Sorted = true;
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
        private void Productos()
        {
            cbProductos.Items.Clear();
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Nombre FROM elastosystem_ventas_productos";
            try
            {
                HashSet<string> unicos = new HashSet<string>();
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbProductos.Items.Add(reader["Nombre"].ToString());
                    }
                    cbProductos.Sorted = true;
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
        private void AgregarADGV()
        {
            if (string.IsNullOrEmpty(txbCantidad.Text) || string.IsNullOrEmpty(txbPrecio.Text) || string.IsNullOrEmpty(cbClave.Text) || string.IsNullOrEmpty(cbProductos.Text))
            {
                MessageBox.Show("DEBES DE LLENAR TODOS LOS CAMPOS PARA AGREGAR UN PRODUCTO");
            }
            else
            {
                double valor1;
                double valor2;
                string pre = txbPrecio.Text;
                pre = pre.Replace("$", "").Replace(" ", " ");
                txbPrecio.Text = pre;

                if (double.TryParse(txbPrecio.Text, out valor1) && double.TryParse(txbCantidad.Text, out valor2))
                {
                    double importe = valor1 * valor2;
                    importe = Math.Round(importe, 2);
                    string clave = cbClave.Text;
                    string producto = cbProductos.Text;
                    string cantidad = txbCantidad.Text;
                    string precio = txbPrecio.Text;

                    DataTable dt = (DataTable)dgvListaProductos.DataSource;
                    DataRow newrow = dt.NewRow();
                    newrow["Clave"] = clave;
                    newrow["Producto"] = producto;
                    newrow["Precio"] = precio;
                    newrow["Cantidad"] = cantidad;
                    newrow["Importe"] = importe;
                    dt.Rows.Add(newrow);

                    cbClave.Text = null; cbProductos.Text = null; txbCantidad.Clear(); txbPrecio.Clear();
                    dgvListaProductos.Enabled = true;

                    Total();
                }
                else
                {
                    MessageBox.Show("REVISA TUS DATOS EN PRECIO O CANTIDAD, NO SON NUMEROS VALIDOS");
                }
            }
        }
        private void InfoClave()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            String clave = cbClave.Text;
            MySqlDataReader reader = null;
            string sql = "SELECT Nombre, Precio_A FROM elastosystem_ventas_productos WHERE Clave LIKE '" + clave + "' ";
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbProductos.Text = reader.GetString("Nombre");
                        txbPrecio.Text = reader.GetString("Precio_A");
                    }
                }
                else
                {
                    //MessageBox.Show("ERROR AL LLAMAR LOS DATOS");
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
        private void InfoProducto()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            String producto = cbProductos.Text;
            MySqlDataReader reader = null;
            string sql = "SELECT Clave, Precio_A FROM elastosystem_ventas_productos WHERE Nombre LIKE '" + producto + "' ";
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbClave.Text = reader.GetString("Clave");
                        txbPrecio.Text = reader.GetString("Precio_A");
                    }
                }
                else
                {
                    //MessageBox.Show("ERROR AL LLAMAR LOS DATOS");
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
        private void Total()
        {
            if (chbDescuento.Checked && !string.IsNullOrEmpty(txbDescuento.Text))
            {
                txbDescuento.Text = txbDescuento.Text.Replace("%", "").Replace(" ", "");
                double descuento = 0;
                double.TryParse(txbDescuento.Text, out descuento);

                double suma = 0;
                double iva = 0;
                double total = 0;
                foreach (DataGridViewRow fila in dgvListaProductos.Rows)
                {
                    double valorCelda;
                    if (double.TryParse(fila.Cells[4].Value.ToString(), out valorCelda))
                    {
                        suma += valorCelda;
                    }
                }
                descuento = descuento * 0.01;
                double op = suma * descuento;
                double sumadescuento = suma - op;
                double ivades = sumadescuento * 0.16;
                ivades = Math.Round(ivades, 2);
                double totaldes = sumadescuento + ivades;
                totaldes = Math.Round(totaldes, 2);
                txbTotal.Text = totaldes.ToString();

                iva = suma * 0.16;
                iva = Math.Round(iva, 2);
                total = suma + iva;
                total = Math.Round(total, 2);
                suma = Math.Round(suma, 2);
                txbSubtotal.Text = suma.ToString();
                txbIVA.Text = iva.ToString();
            }
            else
            {
                double suma = 0;
                double iva = 0;
                double total = 0;
                foreach (DataGridViewRow fila in dgvListaProductos.Rows)
                {
                    double valorCelda;
                    if (double.TryParse(fila.Cells[4].Value.ToString(), out valorCelda))
                    {
                        suma += valorCelda;
                    }
                }
                iva = suma * 0.16;
                iva = Math.Round(iva, 2);
                total = suma + iva;
                total = Math.Round(total, 2);
                suma = Math.Round(suma, 2);
                txbSubtotal.Text = suma.ToString();
                txbIVA.Text = iva.ToString();
                txbTotal.Text = total.ToString();
            }
        }
        private void MandarACotizacion()
        {
            string fecha = DateTime.Now.ToString("yyyy/MM/dd");
            bool boolsigla = chbSigla03.Checked;
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE elastosystem_ventas_cotizacion SET Fecha = @FECHA, Contacto = @CONTACTO, Empresa = @EMPRESA, Descuento = @DESCUENTO, Subtotal = @SUBTOTAL, IVA = @IVA, Total = @TOTAL, Sigla03 = @SIGLA03, Excepto = @EXCEPTO WHERE ID = @ID";
                cmd.Parameters.AddWithValue("@ID", txbFolio.Text);
                cmd.Parameters.AddWithValue("@FECHA", fecha);
                cmd.Parameters.AddWithValue("@CONTACTO", txbContacto.Text);
                cmd.Parameters.AddWithValue("@EMPRESA", txbEmpresa.Text);
                cmd.Parameters.AddWithValue("@DESCUENTO", txbDescuento.Text);
                cmd.Parameters.AddWithValue("@SUBTOTAL", txbSubtotal.Text);
                cmd.Parameters.AddWithValue("@IVA", txbIVA.Text);
                cmd.Parameters.AddWithValue("@TOTAL", txbTotal.Text);
                cmd.Parameters.AddWithValue("@SIGLA03", boolsigla);
                cmd.Parameters.AddWithValue("@EXCEPTO",txbPartidas.Text);
                cmd.ExecuteNonQuery();
                EliminarPedidos();
                MandarAPedidos();
                Limpiar();
                btnBuscador.PerformClick();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void Limpiar()
        {
            Fecha();
            txbFolio.Clear();
            txbFolioVisible.Clear();
            txbContacto.Clear();
            txbEmpresa.Clear();
            txbTelefono.Clear();
            txbCorreo.Clear();
            cbClave.Text = null;
            cbProductos.Text = null;
            txbCantidad.Text = null;
            txbPrecio.Text = null;
            chbSigla03.Checked = true;
            chbDescuento.Checked = false;
            txbTotal.Clear();
            txbTotalLetras.Clear();
            dgvListaProductos.DataSource = null;
            dgvListaProductos.Rows.Clear();
            dgvListaProductos.Columns.Clear();
            txbSubtotal.Text = null;
            txbIVA.Text = null;

        }
        private void EliminarPedidos()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            try
            {
                cmd.CommandText = "DELETE FROM elastosystem_ventas_cotizacion_desglosada WHERE ID = '" + txbFolio.Text + "'";
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void MandarAPedidos()
        {
            int filas = dgvListaProductos.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                string clave = dgvListaProductos.Rows[i].Cells["Clave"].Value.ToString();
                string producto = dgvListaProductos.Rows[i].Cells["Producto"].Value.ToString();
                int cantidad = Convert.ToInt32(dgvListaProductos.Rows[i].Cells["Cantidad"].Value);
                double precio = Convert.ToDouble(dgvListaProductos.Rows[i].Cells["Precio"].Value);
                double importe = Convert.ToDouble(dgvListaProductos.Rows[i].Cells["Importe"].Value);

                MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO elastosystem_ventas_cotizacion_desglosada (ID, Clave, Producto, Cantidad, Precio, Importe) VALUES (@ID, @CLAVE, @PRODUCTO, @CANTIDAD, @PRECIO, @IMPORTE);";
                    cmd.Parameters.AddWithValue("@ID", txbFolio.Text);
                    cmd.Parameters.AddWithValue("@CLAVE", clave);
                    cmd.Parameters.AddWithValue("@PRODUCTO", producto);
                    cmd.Parameters.AddWithValue("@CANTIDAD", cantidad);
                    cmd.Parameters.AddWithValue("@PRECIO", precio);
                    cmd.Parameters.AddWithValue("@IMPORTE", importe);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void Ventas_BuscarCotizacion_Load(object sender, EventArgs e)
        {
            txbBuscador.Focus();
            Fecha();
            Clave();
            Productos();
            MandarALlamarCotizaciones();
        }

        private void MandarALlamarCotizaciones()
        {
            string tabla = "SELECT * FROM elastosystem_ventas_cotizacion";
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
            DataTable dt = new DataTable();
            mySqlAdapter.Fill(dt);
            dgvCotizaciones.DataSource = dt;
            dt.DefaultView.Sort = "ID DESC";
            dgvCotizaciones.Columns["ID"].Visible = false;
            dgvCotizaciones.Columns["ID_ALT"].HeaderText = "Folio";
            dgvCotizaciones.Columns["ID_Cliente"].Visible = false;
            dgvCotizaciones.Columns["Descuento"].Visible = false;
            dgvCotizaciones.Columns["Subtotal"].Visible = false;
            dgvCotizaciones.Columns["IVA"].Visible = false;
            dgvCotizaciones.Columns["Sigla03"].Visible = false;
            dgvCotizaciones.Columns["Excepto"].Visible = false;
        }

        private void Buscador()
        {
            try
            {
                string valorBusqueda = txbBuscador.Text;
                string consulta = "SELECT * FROM elastosystem_ventas_cotizacion WHERE ID_ALT LIKE @ValorBusqueda OR ID LIKE @ValorBusqueda OR Contacto LIKE @ValorBusqueda OR Empresa LIKE @ValorBusqueda";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, VariablesGlobales.ConexionBDElastotecnica);

                adaptador.SelectCommand.Parameters.AddWithValue("@ValorBusqueda", "%" + valorBusqueda + "%");

                DataSet datos = new DataSet();

                adaptador.Fill(datos, "Resultados");

                dgvCotizaciones.DataSource = datos.Tables["Resultados"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar datos: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            pnlBuscador.Visible = true;
            LimpiarCotizacion();
            MandarALlamarCotizaciones();
        }

        private void cbFolio_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void chbSigla03_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSigla03.Checked)
            {
                txbPartidas.Visible = false;
                lblExcepto.Visible = false;
            }
            else
            {
                txbPartidas.Visible = true;
                lblExcepto.Visible = true;
            }
        }

        private void chbDescuento_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDescuento.Checked)
            {
                txbDescuento.Enabled = true;
                Total();
            }
            else
            {
                txbDescuento.Text = "0";
                txbDescuento.Enabled = false;
                Total();
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            cbClave.Text = null;
            cbProductos.Text = null;
            txbCantidad.Clear();
            txbPrecio.Clear();
        }

        private void cbContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbFolio_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            AgregarADGV();
        }

        private void cbClave_SelectedIndexChanged(object sender, EventArgs e)
        {
            InfoClave();
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            InfoProducto();
        }

        private void txbDescuento_TextChanged(object sender, EventArgs e)
        {
            Total();
        }

        private void dgvListaProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indiceFilaSeleccionada = e.RowIndex;

            if (indiceFilaSeleccionada >= 0 && indiceFilaSeleccionada < dgvListaProductos.Rows.Count)
            {
                DataGridViewRow filaSeleccionada = dgvListaProductos.Rows[indiceFilaSeleccionada];

                string clave = filaSeleccionada.Cells[0].Value.ToString();
                string producto = filaSeleccionada.Cells[1].Value.ToString();
                string precio = filaSeleccionada.Cells[2].Value.ToString();
                string cantidad = filaSeleccionada.Cells[3].Value.ToString();

                cbClave.Text = clave;
                cbProductos.Text = producto;
                txbPrecio.Text = precio;
                txbCantidad.Text = cantidad;

                dgvListaProductos.Rows.RemoveAt(indiceFilaSeleccionada);
            }
            Total();
        }

        private void btnGenerarCot_Click(object sender, EventArgs e)
        {
            if (txbContacto.Text.Length > 0 && txbEmpresa.Text.Length > 0 && txbTelefono.Text.Length > 0 && txbCorreo.Text.Length > 0 && dgvListaProductos.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar PDF";
                saveFileDialog.FileName = txbFolioVisible.Text + ".pdf";

                string contactocguion = txbContacto.Text;
                string contactosguion;
                try
                {
                    string[] partes = contactocguion.Split('-');
                    contactosguion = partes[1].Trim();
                }
                catch
                {
                    contactosguion = contactocguion;
                }


                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string aviso = "";
                    if (chbSigla03.Checked)
                    {
                        aviso = "LOS MATERIALES CUENTAN CON AVISO DE PRUEBA SIGLA 03 CFE";
                    }
                    else if (!chbSigla03.Checked && string.IsNullOrEmpty(txbPartidas.Text))
                    {
                        aviso = "LOS MATERIALES NO CUENTAN CON AVISO DE PRUEBA SIGLA 03 CFE";
                    }
                    else
                    {
                        aviso = "LOS MATERIALES CUENTAN CON AVISO DE PRUEBA SIGLA 03 CFE, EXCEPTO: " + txbPartidas.Text;
                    }
                    string rutaArchivoPDF = saveFileDialog.FileName;
                    iTextSharp.text.Document doc = new iTextSharp.text.Document();
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivoPDF, FileMode.Create));
                    doc.Open();


                    // ENCABEZADO
                    string rutaImagen = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\Elastosystem\\cotizacion_encabezado.jpg";
                    iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(rutaImagen);
                    float anchoObjetivoencabezado = 520f;
                    float altoObjetivoencabezado = 68f;
                    imagen.ScaleToFit(anchoObjetivoencabezado, altoObjetivoencabezado);
                    float posYImagen1 = doc.PageSize.Height - doc.TopMargin - imagen.ScaledHeight;
                    imagen.SetAbsolutePosition(doc.Left, posYImagen1);
                    doc.Add(imagen);

                    // DATOS CLIENTE
                    string rutaImagen2 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\Elastosystem\\cotizacion_datoscliente.jpg";
                    iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance(rutaImagen2);
                    float anchoObjetivoproveedor = 520f;
                    float altoObjetivoproveedor = 68f;
                    imagen2.ScaleToFit(anchoObjetivoproveedor, altoObjetivoproveedor);
                    float posYImagen2 = posYImagen1 - imagen2.ScaledHeight - 0.5f;
                    imagen2.SetAbsolutePosition(doc.Left, posYImagen2);
                    doc.Add(imagen2);

                    //PIE DE PAGINA
                    string rutaimagenpie = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\Elastosystem\\cotizacion_pie.jpg";
                    iTextSharp.text.Image imagepie = iTextSharp.text.Image.GetInstance(rutaimagenpie);
                    float anchopie = 520f;
                    float altopie = 68f;
                    imagepie.ScaleToFit(anchopie, altopie);
                    float posypie = 40f;
                    imagepie.SetAbsolutePosition(doc.Left, posypie);
                    doc.Add(imagepie);


                    iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7);
                    iTextSharp.text.Font fontceldas = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8);
                    iTextSharp.text.Font fontnegritas = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fontcantidades = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9);
                    iTextSharp.text.Font fontgrandes = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9);
                    iTextSharp.text.Font whiteFontb = new iTextSharp.text.Font(fontcantidades);
                    whiteFontb.Color = BaseColor.WHITE;

                    string fecha = lblFecha.Text;
                    string cotizacion = txbFolioVisible.Text;
                    string ocyrequi = "FECHA DE COTIZACIÓN: \n  " + fecha + "\n" + "NO. COTIZACIÓN: \n   " + cotizacion;

                    string contacto = contactosguion;
                    string telefono = txbTelefono.Text;
                    string correo = txbCorreo.Text;
                    string empresa = txbEmpresa.Text;
                    string datosdelproveedor = "A NOMBRE DE: " + contacto + "\n " + telefono + "\n " + correo + "\n " + empresa;


                    PdfPTable tableaa = new PdfPTable(2);
                    tableaa.WidthPercentage = 100;
                    tableaa.SetWidths(new float[] { 60, 40 });

                    PdfPCell cellOC = new PdfPCell(new Phrase(ocyrequi, font));
                    cellOC.HorizontalAlignment = Element.ALIGN_LEFT;
                    cellOC.PaddingLeft = 68;
                    cellOC.BorderWidth = 0;
                    tableaa.AddCell(cellOC);

                    PdfPCell cellProo = new PdfPCell(new Phrase(datosdelproveedor, font));
                    cellProo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellProo.BorderWidth = 0;
                    tableaa.AddCell(cellProo);

                    //doc.Add(tableaa);
                    float pocisionYTableaa = 733f;
                    float pocisionXTableaa = -32f;
                    tableaa.TotalWidth = doc.PageSize.Width;
                    tableaa.WriteSelectedRows(0, -1, pocisionXTableaa, pocisionYTableaa, writer.DirectContent);

                    doc.Add(new iTextSharp.text.Paragraph("\n \n \n \n \n \n \n \n"));


                    PdfPTable table = new PdfPTable(dgvListaProductos.Columns.Count);
                    table.WidthPercentage = 100;

                    float[] columnWidths = new float[] { 15f, 55f, 10f, 10f, 10f };
                    table.SetWidths(columnWidths);
                    for (int i = 0; i < dgvListaProductos.Columns.Count; i++)
                    {
                        iTextSharp.text.Font whiteFont = new iTextSharp.text.Font(font);
                        whiteFont.Color = BaseColor.WHITE;

                        PdfPCell cell = new PdfPCell(new Phrase(dgvListaProductos.Columns[i].HeaderText, whiteFont));
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        cell.BackgroundColor = new BaseColor(7, 34, 59);
                        table.AddCell(cell);
                    }
                    doc.Add(table);

                    int maxFilasPorPagina = 20;
                    int numFilas = dgvListaProductos.Rows.Count;
                    int filaActual = 0;
                    int limiteFilasPrimeraPagina = 20;
                    while (filaActual < numFilas)
                    {
                        if (filaActual % maxFilasPorPagina == 0 && filaActual != 0)
                        {
                            doc.NewPage();
                        }
                        int filasRestantes = numFilas - filaActual;
                        int filasEnEstaPagina = Math.Min(filasRestantes, maxFilasPorPagina);
                        PdfPTable tableParte1 = new PdfPTable(dgvListaProductos.Columns.Count);
                        tableParte1.WidthPercentage = 100;
                        float[] columnWidths1 = new float[] { 15f, 55f, 10f, 10f, 10f };
                        tableParte1.SetWidths(columnWidths1);

                        PdfPTable tableParte2 = new PdfPTable(dgvListaProductos.Columns.Count);
                        tableParte2.WidthPercentage = 100;
                        float[] columnWidths2 = new float[] { 15f, 55f, 10f, 10f, 10f };
                        tableParte2.SetWidths(columnWidths2);

                        for (int i = 0; i < filasEnEstaPagina; i++)
                        {
                            int indiceFila = filaActual + i;
                            PdfPTable tablaActual = indiceFila < limiteFilasPrimeraPagina ? tableParte1 : tableParte2;

                            for (int j = 0; j < dgvListaProductos.Columns.Count; j++)
                            {
                                string valorCelda = dgvListaProductos.Rows[indiceFila].Cells[j].Value.ToString();
                                PdfPCell cell;

                                if (j == 2 || j == 4)
                                {
                                    valorCelda = "$ " + valorCelda;
                                    cell = new PdfPCell(new Phrase(valorCelda, fontceldas));
                                }
                                else
                                {
                                    cell = new PdfPCell(new Phrase(valorCelda, fontceldas));
                                }

                                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                                tablaActual.AddCell(cell);
                            }
                        }

                        doc.Add(tableParte1);

                        doc.Add(tableParte2);

                        filaActual += filasEnEstaPagina;
                    }



                    string cantidadletras = txbTotalLetras.Text;
                    string cantidadeneletracompleta = "\n \n **" + cantidadletras + " DE DOLARES" + "**";
                    string cantidades = "";
                    if (chbDescuento.Checked)
                    {
                        string subtotal = txbSubtotal.Text;
                        string iva = txbIVA.Text;
                        string total = txbTotal.Text;
                        string descuento = txbDescuento.Text + " %";
                        cantidades = "\n $" + subtotal + "\n \n" + descuento + "\n \n " + "$" +iva + "\n \n" + "$" + total;
                    }
                    else
                    {
                        string subtotal = txbSubtotal.Text;
                        string iva = txbIVA.Text;
                        string total = txbTotal.Text;
                        cantidades = "\n $" + subtotal + "\n \n" + "$" + iva + "\n \n " + "$" + total;
                    }

                    PdfPTable tableTotales = new PdfPTable(2);
                    tableTotales.WidthPercentage = 100;
                    tableTotales.SetWidths(new float[] { 70, 30 });

                    PdfPCell cellLet = new PdfPCell(new Phrase(cantidadeneletracompleta, fontnegritas));
                    cellLet.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellLet.BorderWidth = 0;
                    tableTotales.AddCell(cellLet);


                    PdfPCell cellTotales = new PdfPCell(new Phrase(cantidades, whiteFontb));
                    cellTotales.HorizontalAlignment = Element.ALIGN_LEFT;
                    cellTotales.PaddingLeft = 80;
                    cellTotales.BorderWidth = 0;
                    tableTotales.AddCell(cellTotales);
                    float tableY = writer.GetVerticalPosition(false);
                    float tableeY = tableY - 65;
                    doc.Add(tableTotales);

                    if (chbDescuento.Checked)
                    {
                        // CANTIDAD CON DESCUENTO
                        string rutaImagen4 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\Elastosystem\\cotizacion_cantidadesdescuentoUSD.jpg";
                        iTextSharp.text.Image imagen4 = iTextSharp.text.Image.GetInstance(rutaImagen4);
                        imagen4.ScaleToFit(165f, 165f);
                        imagen4.SetAbsolutePosition(385, tableeY - 16);
                        doc.Add(imagen4);
                    }
                    else
                    {
                        // CANTIDAD
                        string rutaImagen4 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\Elastosystem\\cotizacion_cantidadesUSD.jpg";
                        iTextSharp.text.Image imagen4 = iTextSharp.text.Image.GetInstance(rutaImagen4);
                        imagen4.ScaleToFit(165f, 165f);
                        imagen4.SetAbsolutePosition(385, tableeY);
                        doc.Add(imagen4);
                    }

                    string condi = "TODOS LOS MATERIALES SON MARCA ELASTOTECNICA" + "\n" + aviso + "\n" + "LAB PLANTA Ó LINEA DE CARGA DE SU PREFERENCIA" + "\n" + "TIPO DE CAMBIO AL DIA DEL DEPOSITO: http://dof.gob.mx/indicadores.php" + "\n" + "VIGENCIA DE COTIZACIÓN: 7 DIAS NATURALES" + "\n" + "TIEMPO DE ENTREGA INMEDIATO SPV" + "\n" + "ENVIO A AREA METROPOLITANA EN MONTOS MAYORES A $500 USD" + "\n" + "EL ENVIO CORRE POR PARTE DEL CLIENTE POR LA FLETERA DE SU ELECCION";


                    string firma = "\n \n \n \n" + "FLETERA:" + "\n" + "TIPO DE CAMBIO:" + "\n" + "FACTURACION:" + "\n" + "OCURRE / DOMICILIO";

                    PdfPTable tablea = new PdfPTable(3);
                    tablea.WidthPercentage = 100;
                    tablea.SetWidths(new float[] { 60, 40, 10 });

                    PdfPCell cellCondiciones = new PdfPCell(new Phrase(condi, font));
                    cellCondiciones.HorizontalAlignment = Element.ALIGN_LEFT;
                    cellCondiciones.BorderWidth = 0;
                    tablea.AddCell(cellCondiciones);

                    PdfPCell cellFirma = new PdfPCell(new Phrase(firma, font));
                    cellFirma.HorizontalAlignment = Element.ALIGN_LEFT;
                    cellFirma.BorderWidth = 0;
                    tablea.AddCell(cellFirma);
                    string f = " ";
                    PdfPCell cellF = new PdfPCell(new Phrase(f, font));
                    cellF.HorizontalAlignment = Element.ALIGN_LEFT;
                    cellF.BorderWidth = 0;
                    tablea.AddCell(cellF);
                    float posXTabla = 40f;
                    float posYTabla = 175f;
                    float pie = 40f;
                    tablea.TotalWidth = doc.PageSize.Width;
                    tablea.WriteSelectedRows(0, -1, posXTabla, posYTabla, writer.DirectContent);


                    //PIE DE PAGINA
                    string rutaImagen3 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\Elastosystem\\cotizacion_pie.jpg";
                    float anchoObjetiv = 520f;
                    float altoObjetiv = 68f;
                    iTextSharp.text.Image imagen3 = iTextSharp.text.Image.GetInstance(rutaImagen3);
                    imagen3.ScaleToFit(anchoObjetiv, altoObjetiv);
                    imagen3.SetAbsolutePosition(doc.Left, pie);
                    doc.Add(imagen3);


                    doc.Close();

                    
                    MessageBox.Show("PDF guardado como '" + System.IO.Path.GetFileName(rutaArchivoPDF) + "'", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MandarACotizacion();


                    if (System.IO.File.Exists(rutaArchivoPDF))
                    {
                        System.Diagnostics.Process.Start("explorer.exe", rutaArchivoPDF);
                    }
                    else
                    {
                        MessageBox.Show("El archivo no se pudo encontrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("DEBES DE LLENAR TODOS LOS CAMPOS OBLIGATORIOS");
            }
        }

        private void txbTotal_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txbTotal.Text, out decimal numero))
            {
                string numeroEnLetras = VariablesGlobales.ConvertidorNumerosALetrasUSD.ConvertirNumeroALetras(numero);

                txbTotalLetras.Text = numeroEnLetras;
            }
            else
            {

            }
        }

        private void txbBuscador_TextChanged(object sender, EventArgs e)
        {
            Buscador();
        }

        private void dgvCotizaciones_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                txbFolio.Text = id;

                string id_alt = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                txbFolioVisible.Text = id_alt;

                DateTime fecha = Convert.ToDateTime(dgv.Rows[rowIndex].Cells[2].Value);
                lblFecha.Text = fecha.ToString("dd / MMMM / yyyy", new System.Globalization.CultureInfo("es-ES"));

                string id_cliente = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                lblIDCliente.Text = id_cliente;

                string contacto = dgv.Rows[rowIndex].Cells[4].Value.ToString();
                txbContacto.Text = contacto;

                string empresa = dgv.Rows[rowIndex].Cells[5].Value.ToString();
                txbEmpresa.Text = empresa;

                string descuento = dgv.Rows[rowIndex].Cells[6].Value.ToString();
                txbDescuento.Text = descuento;
                chbDescuento.Checked = !string.IsNullOrEmpty(descuento) && descuento !="0";

                string subtotal = dgv.Rows[rowIndex].Cells[7].Value.ToString();
                txbSubtotal.Text = subtotal;

                string iva = dgv.Rows[rowIndex].Cells[8].Value.ToString();
                txbIVA.Text = iva;

                string total = dgv.Rows[rowIndex].Cells[9].Value.ToString();
                txbTotal.Text = total;

                bool sigla03 = dgv.Rows[rowIndex].Cells[10].Value.ToString() == "1";
                chbSigla03.Checked = sigla03;

                string excepto = dgv.Rows[rowIndex].Cells[11].Value.ToString();
                txbPartidas.Text = excepto;

                txbBuscador.Clear();
                pnlBuscador.Visible = false;

                MandarALlamarInfo();

            }
        }

        private void MandarALlamarInfo()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            String id = lblIDCliente.Text;
            MySqlDataReader reader = null;
            string sql = "SELECT Telefono, Correo FROM elastosystem_ventas_clientes WHERE ID LIKE '" + id + "' ";
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txbTelefono.Text = reader.GetString("Telefono");
                        txbCorreo.Text = reader.GetString("Correo");
                    }
                    MandarALlamarPartidas();
                }
                else
                {
                    //MessageBox.Show("ERROR AL LLAMAR LOS DATOS");
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

        private void MandarALlamarPartidas()
        {
            try
            {
                string tabla = "SELECT Clave, Producto, Precio, Cantidad, Importe FROM elastosystem_ventas_cotizacion_desglosada WHERE ID = '" + txbFolio.Text + "'";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dgvListaProductos.DataSource = dt;
                dgvListaProductos.Columns["Clave"].Width = 212;
                dgvListaProductos.Columns["Producto"].Width = 694;
                dgvListaProductos.Columns["Precio"].Width = 120;
                dgvListaProductos.Columns["Cantidad"].Width = 118;
                dgvListaProductos.Columns["Importe"].Width = 120;
                Total();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
