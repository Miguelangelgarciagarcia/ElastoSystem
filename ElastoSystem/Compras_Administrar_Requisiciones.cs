using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using MySql.Data.MySqlClient;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Org.BouncyCastle.Asn1.Cmp;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing;

namespace ElastoSystem
{
    public partial class Compras_Administrar_Requisiciones : Form
    {
        public Compras_Administrar_Requisiciones()
        {
            InitializeComponent();
        }
        private void CargarRequisiciones()
        {
            try
            {
                string tabla = "SELECT ID, Usuario, Fecha FROM elastosystem_compras_requisicion WHERE Estatus = 'ABIERTA'";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dt.Columns["ID"].ColumnName = "Folio";
                dt.Columns["Usuario"].ColumnName = "Solicitante";
                dgvRequisicions.DataSource = dt;
                dt.DefaultView.Sort = "Folio DESC";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MandarALlamarPartidas()
        {
            try
            {
                string tabla = "SELECT ID_Producto, Descripcion, Cantidad, Unidad, Precio, Proveedor, TipoUso, Comentarios FROM elastosystem_compras_requisicion_desglosada WHERE ID = '" + txbFolio.Text + "'";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dgvPartidas.DataSource = dt;
                dgvPartidas.Columns["ID_Producto"].Visible = false;
                dgvPartidas.Columns["Cantidad"].Visible = false;
                dgvPartidas.Columns["Unidad"].Visible = false;
                dgvPartidas.Columns["Precio"].Visible = false;
                dgvPartidas.Columns["Proveedor"].Visible = false;
                dgvPartidas.Columns["TipoUso"].Visible = false;
                dgvPartidas.Columns["Comentarios"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MandarALlamarProveedores()
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
                        cbProveedores.Items.Add(reader["Nombre"].ToString());
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
            cbProveedores.Sorted = true;
        }
        private void AgregarADgv()
        {
            if (string.IsNullOrEmpty(txbDescripcion.Text) || string.IsNullOrEmpty(txbCantidad.Text) || string.IsNullOrEmpty(txbUnidad.Text) || string.IsNullOrEmpty(txbPrecio.Text))
            {
                MessageBox.Show("DEBES DE LLENAR LOS CAMPOS OBLIGATORIOS");
                PartidasPBVisibles();
            }
            else
            {
                PartidasPBOculto();
                double valor1;
                double valor2;
                string pre = txbPrecio.Text;
                pre = pre.Replace("$", "").Replace(" ", " ");
                txbPrecio.Text = pre;

                if (double.TryParse(txbPrecio.Text, out valor1) && double.TryParse(txbCantidad.Text, out valor2))
                {
                    double importe = valor1 * valor2;
                    importe = Math.Round(importe, 2);
                    string id = lblIDProducto.Text;
                    string cantidad = txbCantidad.Text;
                    string unidad = txbUnidad.Text;
                    string descripcion = txbDescripcion.Text;
                    string precio = txbPrecio.Text;

                    dgvListaMateriales.Rows.Add(id, cantidad, unidad, descripcion, precio, importe);
                    LimpiarAgregarPartidas();
                    dgvListaMateriales.Enabled = true;

                    Total();
                    MessageBox.Show("PRODUCTO AGREGADO");
                }
                else
                {
                    MessageBox.Show("REVISA TUS DATOS EN PRECIO O CANTIDAD, NO SON NUMEROS VALIDOS");
                }
            }
        }


        private void LimpiarAgregarPartidas()
        {
            txbCantidad.Clear();
            txbUnidad.Clear();
            txbPrecio.Clear();
            txbDescripcion.Clear();
            txbProovedorRecomendado.Clear();
            txbTipoUso.Clear();
            txbNotas.Clear();
        }

        private void PartidasPBVisibles()
        {
            lblCamposPartidas.Visible = true;
            pbCamposPartidas.Visible = true;
            pbCantidad.Visible = true;
            pbUnidad.Visible = true;
            pbPrecio.Visible = true;
            pbDescripcion.Visible = true;
        }

        private void PartidasPBOculto()
        {
            lblCamposPartidas.Visible = false;
            pbCamposPartidas.Visible = false;
            pbUnidad.Visible = false;
            pbPrecio.Visible = false;
            pbDescripcion.Visible = false;
            pbCantidad.Visible = false;
        }

        private void Total()
        {
            double suma = 0;
            double iva = 0;
            double total = 0;
            // Iterar a través de las filas del DataGridView
            foreach (DataGridViewRow fila in dgvListaMateriales.Rows)
            {
                // Obtener el valor de la celda en la tercera columna (índice 2)
                // y tratar de convertirlo a double
                double valorCelda;
                if (double.TryParse(fila.Cells[4].Value.ToString(), out valorCelda))
                {
                    // Si la conversión es exitosa, agregar el valor a la suma
                    suma += valorCelda;
                }
            }
            iva = suma * 0.16;
            iva = Math.Round(iva, 2);
            total = suma + iva;
            total = Math.Round(total, 2);
            txbSubtotal.Text = suma.ToString();
            txbIVA.Text = iva.ToString();
            txbTotal.Text = total.ToString();
        }
        private void MandarALlamarDatosProveedor()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            String nombre = cbProveedores.Text;
            MySqlDataReader reader = null;
            string sql = "SELECT Contacto, Telefono, Email FROM elastosystem_compras_proveedores WHERE Nombre LIKE '" + nombre + "' ";
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txbAtencion.Text = reader.GetString("Contacto");
                        txbTelefono.Text = reader.GetString("Telefono");
                        txbCorreo.Text = reader.GetString("Email");
                    }
                }
                else
                {
                    MessageBox.Show("ERROR LLAMAR A SISTEMAS");
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
        private void Folio()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Folio FROM elastosystem_compras_oc";

            try
            {
                int ultimoFolio = 0;
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
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
                    lblFolio.Text = ultimoFolio.ToString();
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
        private void LimpiarCampos()
        {

            txbNotas.Clear();
            txbTipoUso.Clear();
            txbDescripcion.Clear();
            txbCantidad.Clear();
            txbUnidad.Clear();
            txbPrecio.Clear();
            cbProveedores.Text = null;
            txbAtencion.Clear();
            txbTelefono.Clear();
            txbCorreo.Clear();
            txbCotizacion.Clear();
            dgvListaMateriales.Rows.Clear();
            txbTotalLetra.Clear();
            txbSubtotal.Clear();
            txbIVA.Clear();
            txbTotal.Clear();
            cbMoneda.Text = null;
            cbConfirmacionPedido.Text = null;
            cbCondicionPago.Text = null;
            txbTiempoEntrega.Clear();
            txbLugarEntrega.Text = "ELASTOTECNICA CARR. ANIMAS-COYOTEPEC KM. 4, COYOTEPEC, ESTADO DE MÉXICO";
            cbFormaPago.Text = null;
            chbCerSi.Checked = true;
            lblFolio.Text = "";
        }
        private void AlmacenarRequisicion()
        {
            /*
            MySqlConnection conn = new MySqlConnection(connectionStringelastotec);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO req2version2 (ID_REQ, SOLICITANTE, DIA, MES, ANO, NOTAS, USO) VALUES ('" + lblFolio.Text + "', '" + lblSolicito.Text + "', '" + lblDia.Text + "', '" + lblMes.Text + "', '" + lblAno.Text + "', '" + txbNotas.Text + "', '" + txbTipoUso.Text + "');";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Requisicion: " + lblFolio.Text + " almacenada");
                txbNotas.Clear(); txbTipoUso.Clear();
                EliminarPendientes();
                MandarAIndicador();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            */
        }
        private void EliminarPendientes()
        {
            /*
            MySqlConnection mySqlConnection = new MySqlConnection(connectionStringelastotec);
            mySqlConnection.Open();
            MySqlCommand comando = new MySqlCommand();
            comando.Connection = mySqlConnection;
            comando.CommandText = "DELETE FROM reqversion2 WHERE ID_REQ = '" + lblFolio.Text + "' ";
            comando.ExecuteNonQuery();
            mySqlConnection.Close();
            CargarRequisiciones();
            */
        }
        private void MandarAIndicador()
        {
            /*
            MySqlConnection conn = new MySqlConnection(connectionStringelastotec);
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT FECHA_ORD FROM indicador_compras WHERE FOLIO_REQ = @FolioReq";
                cmd.Parameters.AddWithValue("@FolioReq", lblFolio.Text);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    string fechaOrd = result.ToString();

                    if (fechaOrd == "0000-00-00")
                    {
                        DateTime fechainicio = DateTime.Now;
                        string fechai = fechainicio.ToString("yyyy-MM-dd");
                        int dia = fechainicio.Day;
                        int mes = fechainicio.Month;
                        int anio = fechainicio.Year;
                        string fechastr = anio + "-" + mes + "-" + dia;

                        cmd.CommandText = "UPDATE indicador_compras SET FECHA_REF = @FechaRef, FECHA_ORD = @FechaOrd WHERE FOLIO_REQ = @FolioReq";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@FechaRef", fechai);
                        cmd.Parameters.AddWithValue("@FechaOrd", fechastr);
                        cmd.Parameters.AddWithValue("@FolioReq", lblFolio.Text);
                        cmd.ExecuteNonQuery();

                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró la fecha en la base de datos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar el UPDATE: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }




            DateTime fechainicio = DateTime.Now;
            string fechai = fechainicio.ToString("yyyy-MM-dd");
            int dia = fechainicio.Day;
            int mes = fechainicio.Month;
            int anio = fechainicio.Year;
            string fechastr = anio+"-"+mes+"-"+dia;
            MySqlConnection conn = new MySqlConnection(connectionStringelastotec);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE indicador_compras SET FECHA_REF ='" + fechai + "', FECHA_ORD='" + fechastr + "' WHERE FOLIO_REQ ='" + lblFolio.Text + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            */
        }

        private void Compras_Administrar_Requisiciones_Load(object sender, EventArgs e)
        {
            Folio();
            CargarRequisiciones();
            MandarALlamarProveedores();
            chbCerSi.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void dgvRequisicions_DoubleClick(object sender, EventArgs e)
        {
            PartidasPBOculto();
            btnAlmacenar.Visible = true;
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                txbFolio.Text = id;

                string solicito = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                lblSolicito.Text = solicito;

            }
            MandarALlamarPartidas();
        }

        private void dgvPartidas_DoubleClick(object sender, EventArgs e)
        {
            PartidasPBOculto();
            LimpiarAgregarPartidas();
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblIDProducto.Text = id;

                string descripcion = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                txbDescripcion.Text = descripcion;

                string cantidad = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                txbCantidad.Text = cantidad;

                string unidad = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                txbUnidad.Text = unidad;

                string precio = dgv.Rows[rowIndex].Cells[4].Value.ToString();
                txbPrecio.Text = precio;

                string proovedor = dgv.Rows[rowIndex].Cells[5].Value.ToString();
                txbProovedorRecomendado.Text = proovedor;

                string tipouso = dgv.Rows[rowIndex].Cells[6].Value.ToString();
                txbTipoUso.Text = tipouso;

                string comentarios = dgv.Rows[rowIndex].Cells[7].Value.ToString();
                txbNotas.Text = comentarios;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AgregarADgv();
        }

        private void cbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            MandarALlamarDatosProveedor();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cbProveedores.SelectedIndex >= 0 && dgvListaMateriales.RowCount > 0 && txbCotizacion.Text.Length > 0)
            {
                lblCampos.Visible = false; pbCampos.Visible = false; pbProveedor.Visible = false; pbCotizacion.Visible = false;
            }
            else
            {
                MessageBox.Show("LLENA TODOS LOS CAMPOS OBILGATORIOS");
                lblCampos.Visible = true;
                pbCampos.Visible = true;
                pbProveedor.Visible = true;
                pbCotizacion.Visible = true;
            }
        }

        private void btnAgregarPartidas_Click(object sender, EventArgs e)
        {
        }

        private void dgvListaMateriales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCerSi.Checked)
            {
                chbCerNo.Checked = false;
            }
        }

        private void chbCerNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCerNo.Checked)
            {
                chbCerSi.Checked = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (cbMoneda.SelectedIndex >= 0 && cbConfirmacionPedido.SelectedIndex >= 0 && cbCondicionPago.SelectedIndex >= 0 && txbTiempoEntrega.Text.Length > 0 && txbLugarEntrega.Text.Length > 0 && cbFormaPago.SelectedIndex >= 0 && cbRequisicion.SelectedIndex >= 0)
            {
                lblCampos2.Visible = false; pbCampos2.Visible = false; pbMoneda.Visible = false; pbConfirmacion.Visible = false; pbCondicion.Visible = false; pbTiempo.Visible = false; pbLugar.Visible = false; pbForma.Visible = false; pbCalidad.Visible = false; pbRequi.Visible = false;
                string certificadodecalidad = " ";
                if (chbCerSi.Checked)
                {
                    certificadodecalidad = "SE REQUIERE CERTIFICADO DE CALIDAD";
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar PDF";
                saveFileDialog.FileName = lblFolio.Text + ".pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (cbRequisicion.Text == "ELASTOTECNICA")
                    {
                        string rutaArchivoPDF = saveFileDialog.FileName;
                        iTextSharp.text.Document doc = new iTextSharp.text.Document();
                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivoPDF, FileMode.Create));
                        doc.Open();

                        // ENCABEZADO
                        string rutaImagen = "\\\\10.120.1.3\\Departments$\\Sistemas\\ElastoSystem\\Recursos\\ocvieja.jpg";
                        iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(rutaImagen);
                        float anchoObjetivoencabezado = 520f;
                        float altoObjetivoencabezado = 63f;
                        imagen.ScaleToFit(anchoObjetivoencabezado, altoObjetivoencabezado);
                        float posYImagen1 = doc.PageSize.Height - doc.TopMargin - imagen.ScaledHeight;
                        imagen.SetAbsolutePosition(doc.Left, posYImagen1);
                        doc.Add(imagen);

                        // DATOS PROVEEDOR
                        string rutaImagen2 = "\\\\10.120.1.3\\Departments$\\Sistemas\\ElastoSystem\\Recursos\\ocvieja2.jpg";
                        iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance(rutaImagen2);
                        float anchoObjetivoproveedor = 520f;
                        float altoObjetivoproveedor = 63f; //72
                        imagen2.ScaleToFit(anchoObjetivoproveedor, altoObjetivoproveedor);
                        float posYImagen2 = posYImagen1 - imagen2.ScaledHeight - 0.5f;
                        imagen2.SetAbsolutePosition(doc.Left, posYImagen2);
                        doc.Add(imagen2);

                        //PIE DE PAGINA
                        string rutaimagenpie = "\\\\10.120.1.3\\Departments$\\Sistemas\\ElastoSystem\\Recursos\\ocvieja3.jpg";
                        iTextSharp.text.Image imagepie = iTextSharp.text.Image.GetInstance(rutaimagenpie);
                        float anchopie = 520f;
                        float altopie = 68f;
                        imagepie.ScaleToFit(anchopie, altopie);
                        float posypie = 40f;
                        imagepie.SetAbsolutePosition(doc.Left, posypie);
                        doc.Add(imagepie);


                        iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7);
                        iTextSharp.text.Font fontfolios = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8);
                        iTextSharp.text.Font fontceldas = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.UNDEFINED, 10);
                        iTextSharp.text.Font fontgrandes = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9);

                        doc.Add(new iTextSharp.text.Paragraph("\n"));
                        doc.Add(new iTextSharp.text.Paragraph("\n"));
                        doc.Add(new iTextSharp.text.Paragraph("\n"));




                        string oc = lblFolio.Text;
                        string requisicion = lblFolio.Text;
                        string ocyrequi = "\n" + oc + "\n \n" + requisicion;
                        iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(ocyrequi, font);
                        string empresa = cbProveedores.Text;
                        string atencion = txbAtencion.Text;
                        string telefono = txbTelefono.Text;
                        string correo = txbCorreo.Text;
                        string datosdelproveedor = "\n \n \n" + empresa + "\n \n " + atencion + "\n " + telefono + "\n " + correo;
                        iTextSharp.text.Paragraph datospro = new iTextSharp.text.Paragraph(datosdelproveedor, font);

                        // Crear una tabla con una fila y dos celdas
                        PdfPTable tableaa = new PdfPTable(2);
                        tableaa.WidthPercentage = 100;
                        tableaa.SetWidths(new float[] { 60, 40 });

                        // Primera celda: párrafo de condiciones
                        PdfPCell cellOC = new PdfPCell(new Phrase(ocyrequi, fontfolios));
                        cellOC.HorizontalAlignment = Element.ALIGN_LEFT;
                        cellOC.PaddingLeft = 60;
                        cellOC.BorderWidth = 0;
                        tableaa.AddCell(cellOC);

                        // Segunda celda: párrafo de firma
                        PdfPCell cellProo = new PdfPCell(new Phrase(datosdelproveedor, font));
                        cellProo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellProo.BorderWidth = 0;
                        tableaa.AddCell(cellProo);

                        doc.Add(tableaa);

                        doc.Add(new iTextSharp.text.Paragraph("\n"));


                        iTextSharp.text.Font whiteFonta = new iTextSharp.text.Font(font);
                        whiteFonta.Color = BaseColor.WHITE;
                        string confirmaciondelpedido = cbConfirmacionPedido.Text;
                        DateTime fechaActual = DateTime.Today;
                        string fechahoy = fechaActual.ToString("yyyy-MM-dd");
                        string barraconfirmacion = "CONFIRMACION DEL PEDIDO: " + confirmaciondelpedido + " FECHA: " + fechahoy;
                        iTextSharp.text.Paragraph barraconfi = new iTextSharp.text.Paragraph(barraconfirmacion, font);
                        PdfPTable tablef = new PdfPTable(1);
                        tablef.WidthPercentage = 100;
                        PdfPCell cellf = new PdfPCell(new Phrase(barraconfirmacion, whiteFonta));
                        cellf.BorderWidth = 0;
                        cellf.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        cellf.BackgroundColor = new BaseColor(7, 34, 59);
                        tablef.AddCell(cellf);
                        doc.Add(tablef);




                        PdfPTable table = new PdfPTable(dgvListaMateriales.Columns.Count);
                        table.WidthPercentage = 100;

                        float[] columnWidths = new float[] { 8f, 8f, 64f, 10f, 10f };
                        table.SetWidths(columnWidths);
                        for (int i = 0; i < dgvListaMateriales.Columns.Count; i++)
                        {
                            iTextSharp.text.Font whiteFont = new iTextSharp.text.Font(font);
                            whiteFont.Color = BaseColor.WHITE;

                            PdfPCell cell = new PdfPCell(new Phrase(dgvListaMateriales.Columns[i].HeaderText, whiteFont));
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            cell.BackgroundColor = new BaseColor(7, 34, 59);
                            table.AddCell(cell);
                        }
                        doc.Add(table);



                        int maxFilasPorPagina = 20;
                        int numFilas = dgvListaMateriales.Rows.Count;
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
                            PdfPTable tableParte1 = new PdfPTable(dgvListaMateriales.Columns.Count);
                            tableParte1.WidthPercentage = 100;
                            float[] columnWidths1 = new float[] { 8f, 8f, 64f, 10f, 10f };
                            tableParte1.SetWidths(columnWidths1);

                            PdfPTable tableParte2 = new PdfPTable(dgvListaMateriales.Columns.Count);
                            tableParte2.WidthPercentage = 100;
                            float[] columnWidths2 = new float[] { 8f, 8f, 64f, 10f, 10f };
                            tableParte2.SetWidths(columnWidths2);

                            for (int i = 0; i < filasEnEstaPagina; i++)
                            {
                                int indiceFila = filaActual + i;
                                PdfPTable tablaActual = indiceFila < limiteFilasPrimeraPagina ? tableParte1 : tableParte2;

                                for (int j = 0; j < dgvListaMateriales.Columns.Count; j++)
                                {
                                    string valorCelda = dgvListaMateriales.Rows[indiceFila].Cells[j].Value.ToString();
                                    PdfPCell cell;

                                    if (j == 3 || j == 4)
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

                        doc.Add(new iTextSharp.text.Paragraph("\n"));


                        iTextSharp.text.Font whiteFontb = new iTextSharp.text.Font(fontgrandes);
                        whiteFontb.Color = BaseColor.WHITE;
                        string cantidadletras = txbTotalLetra.Text;
                        string monedaescogida = cbMoneda.Text;
                        string cantidadeneletracompleta = "\n \n **" + cantidadletras + " " + monedaescogida + "**";
                        iTextSharp.text.Paragraph letracuadro = new iTextSharp.text.Paragraph(cantidadeneletracompleta, font);
                        string subtotal = txbSubtotal.Text;
                        string iva = txbIVA.Text;
                        string total = txbTotal.Text;
                        string cantidades = " $" + subtotal + "\n \n" + "$" + iva + "\n \n " + "$" + total;
                        iTextSharp.text.Paragraph cantidadescuadro = new iTextSharp.text.Paragraph(cantidades, font);

                        PdfPTable tableTotales = new PdfPTable(2);
                        tableTotales.WidthPercentage = 100;
                        tableTotales.SetWidths(new float[] { 70, 30 });

                        PdfPCell cellLet = new PdfPCell(new Phrase(cantidadeneletracompleta, font));
                        cellLet.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellLet.BorderWidth = 0;
                        tableTotales.AddCell(cellLet);


                        PdfPCell cellTotales = new PdfPCell(new Phrase(cantidades, whiteFontb));
                        cellTotales.HorizontalAlignment = Element.ALIGN_LEFT;
                        cellTotales.PaddingLeft = 85;
                        cellTotales.BorderWidth = 0;
                        tableTotales.AddCell(cellTotales);
                        float tableY = writer.GetVerticalPosition(false);
                        float tableeY = tableY - 58;
                        doc.Add(tableTotales);



                        // CANTIDAD
                        string rutaImagen4 = "\\\\10.120.1.3\\Departments$\\Sistemas\\ElastoSystem\\Recursos\\ocvieja4.jpg";
                        iTextSharp.text.Image imagen4 = iTextSharp.text.Image.GetInstance(rutaImagen4);
                        imagen4.ScaleToFit(170f, 170f);
                        imagen4.SetAbsolutePosition(400, tableeY);
                        doc.Add(imagen4);



                        string cotizacion = txbCotizacion.Text;
                        string condicionpago = cbCondicionPago.Text;
                        string tiempoentrega = txbTiempoEntrega.Text;
                        string lugarentrega = txbLugarEntrega.Text;
                        string formapago = cbFormaPago.Text;
                        string condi = "--------------------------------------------------CONDICIONES--------------------------------------------------" + "\n" + "COTIZACIÓN: " + cotizacion + "\n" + "CONDICIÓN DE PAGO: " + condicionpago + "\n" + "TIEMPO DE ENTREGA: " + tiempoentrega + "\n" + "LUGAR DE ENTREGA: " + "\n" + lugarentrega + "\n" + "HORARIO DE RECEPCION DE MATERIALES 8:00 AM - 16:00 PM" + "\n" + "FAVOR DE ESPECIFICAR EN LA FACTURA LA FORMA DE PAGO:" + "\n" + formapago + "\n" + "ENTREGAR MATERIALES CON COPIA DE SU ORDEN DE COMPRA" + "\n" + certificadodecalidad;
                        iTextSharp.text.Paragraph condiciones = new iTextSharp.text.Paragraph(condi, font);

                        string solicit = lblSolicito.Text;
                        string use = txbTipoUso.Text;
                        string firma = "\n \n \n \n \n \n \n" + "FIRMA DE RECIBIDO: _______________________" + "\n \n" + "SOLICITO: " + solicit + "\n" + "USO: " + use;
                        iTextSharp.text.Paragraph firm = new iTextSharp.text.Paragraph(firma, font);

                        // Crear una tabla con una fila y dos celdas
                        PdfPTable tablea = new PdfPTable(3);
                        tablea.WidthPercentage = 100;
                        tablea.SetWidths(new float[] { 60, 40, 10 });

                        // Primera celda: párrafo de condiciones
                        PdfPCell cellCondiciones = new PdfPCell(new Phrase(condi, font));
                        cellCondiciones.HorizontalAlignment = Element.ALIGN_LEFT;
                        cellCondiciones.BorderWidth = 0;
                        tablea.AddCell(cellCondiciones);

                        // Segunda celda: párrafo de firma
                        PdfPCell cellFirma = new PdfPCell(new Phrase(firma, font));
                        cellFirma.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellFirma.BorderWidth = 0;
                        tablea.AddCell(cellFirma);
                        string f = " ";
                        PdfPCell cellF = new PdfPCell(new Phrase(f, font));
                        cellF.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellF.BorderWidth = 0;
                        tablea.AddCell(cellF);
                        float posXTabla = 40f;
                        float posYTabla = 190f;
                        float pie = 40f;
                        tablea.TotalWidth = doc.PageSize.Width;
                        tablea.WriteSelectedRows(0, -1, posXTabla, posYTabla, writer.DirectContent);


                        //PIE DE PAGINA
                        string rutaImagen3 = "\\\\10.120.1.3\\Departments$\\Sistemas\\ElastoSystem\\Recursos\\ocvieja3.jpg";
                        float anchoObjetiv = 520f;
                        float altoObjetiv = 68f;
                        iTextSharp.text.Image imagen3 = iTextSharp.text.Image.GetInstance(rutaImagen3);
                        imagen3.ScaleToFit(anchoObjetiv, altoObjetiv);
                        imagen3.SetAbsolutePosition(doc.Left, pie);
                        doc.Add(imagen3);


                        doc.Close();

                        MessageBox.Show("PDF guardado como '" + System.IO.Path.GetFileName(rutaArchivoPDF) + "'", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MandarAIndicador();
                        LimpiarCampos();
                    }
                    else
                    {
                        if (txbLugarEntrega.Text == "ELASTOTECNICA CARR. ANIMAS-COYOTEPEC KM. 4, COYOTEPEC, ESTADO DE MÉXICO")
                        {
                            txbLugarEntrega.Text = "CARR. ANIMAS-COYOTEPEC KM. 4, COYOTEPEC, ESTADO DE MÉXICO";
                        }
                        else
                        {

                        }
                        string rutaArchivoPDF = saveFileDialog.FileName;
                        iTextSharp.text.Document doc = new iTextSharp.text.Document();
                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivoPDF, FileMode.Create));
                        doc.Open();

                        // ENCABEZADO
                        string rutaImagen = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\Elastosystem\\encabezado.jpg";
                        iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(rutaImagen);
                        float anchoObjetivoencabezado = 520f;
                        float altoObjetivoencabezado = 63f;
                        imagen.ScaleToFit(anchoObjetivoencabezado, altoObjetivoencabezado);
                        float posYImagen1 = doc.PageSize.Height - doc.TopMargin - imagen.ScaledHeight;
                        imagen.SetAbsolutePosition(doc.Left, posYImagen1);
                        doc.Add(imagen);

                        //PIE DE PAGINA
                        string rutaimagenpie = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\Elastosystem\\pie.jpg";
                        iTextSharp.text.Image imagepie = iTextSharp.text.Image.GetInstance(rutaimagenpie);
                        float anchopie = 520f;
                        float altopie = 68f;
                        imagepie.ScaleToFit(anchopie, altopie);
                        float posypie = 40f;
                        imagepie.SetAbsolutePosition(doc.Left, posypie);
                        doc.Add(imagepie);


                        iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7);
                        iTextSharp.text.Font fontceldas = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.UNDEFINED, 10);
                        iTextSharp.text.Font fontgrandes = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9);
                        iTextSharp.text.Font fontand = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10);

                        doc.Add(new iTextSharp.text.Paragraph("\n"));
                        doc.Add(new iTextSharp.text.Paragraph("\n"));
                        doc.Add(new iTextSharp.text.Paragraph("\n"));


                        string oc = lblFolio.Text;
                        string ocyrequi = "\n \n" + "ORDEN DE COMPRA: " + oc;
                        iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(ocyrequi, fontand);
                        DateTime fech = DateTime.Now;
                        string fechaS = fech.ToString("yyyy-MM-dd");
                        string datosdelproveedor = "\n \n" + "FECHA: " + fechaS;
                        iTextSharp.text.Paragraph datospro = new iTextSharp.text.Paragraph(datosdelproveedor, fontand);

                        // Crear una tabla con una fila y dos celdas
                        PdfPTable tableaa = new PdfPTable(2);
                        tableaa.WidthPercentage = 100;
                        tableaa.SetWidths(new float[] { 60, 40 });

                        // Primera celda: párrafo de condiciones
                        PdfPCell cellOC = new PdfPCell(new Phrase(ocyrequi, fontand));
                        cellOC.HorizontalAlignment = Element.ALIGN_LEFT;
                        cellOC.PaddingLeft = 48;
                        cellOC.BorderWidth = 0;
                        tableaa.AddCell(cellOC);

                        // Segunda celda: párrafo de firma
                        PdfPCell cellProo = new PdfPCell(new Phrase(datosdelproveedor, fontand));
                        cellProo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellProo.BorderWidth = 0;
                        tableaa.AddCell(cellProo);

                        // Agregar la tabla al documento
                        doc.Add(tableaa);


                        string info = "Andrea Alitzel Vázquez Ramirez \n" + "RFC: VARA9408086L2 \n" + "DIRECCIÓN: RANCHO EL VERGEL #16 COLONIA: \n" + "SAN ANTONIO, CUAUTITLAN IZCALLI, ESTADO DE MÉXICO C.P: 54725";
                        iTextSharp.text.Paragraph infand = new iTextSharp.text.Paragraph(info, fontand);
                        infand.Alignment = Element.ALIGN_CENTER;
                        doc.Add(infand);

                        doc.Add(new iTextSharp.text.Paragraph("\n"));

                        iTextSharp.text.Font whiteFonta = new iTextSharp.text.Font(font);
                        whiteFonta.Color = BaseColor.WHITE;
                        string confirmaciondelpedido = cbConfirmacionPedido.Text;
                        DateTime fechaActual = DateTime.Today;
                        string fechahoy = fechaActual.ToString("yyyy-MM-dd");
                        string barraconfirmacion = "CONFIRMACION DEL PEDIDO: " + confirmaciondelpedido + " FECHA: " + fechahoy;
                        iTextSharp.text.Paragraph barraconfi = new iTextSharp.text.Paragraph(barraconfirmacion, font);
                        PdfPTable tablef = new PdfPTable(1);
                        tablef.WidthPercentage = 100;
                        PdfPCell cellf = new PdfPCell(new Phrase(barraconfirmacion, whiteFonta));
                        cellf.BorderWidth = 0;
                        cellf.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        cellf.BackgroundColor = new BaseColor(0, 48, 101);
                        tablef.AddCell(cellf);
                        doc.Add(tablef);




                        PdfPTable table = new PdfPTable(dgvListaMateriales.Columns.Count);
                        table.WidthPercentage = 100;

                        float[] columnWidths = new float[] { 8f, 8f, 64f, 10f, 10f };
                        table.SetWidths(columnWidths);
                        for (int i = 0; i < dgvListaMateriales.Columns.Count; i++)
                        {
                            iTextSharp.text.Font whiteFont = new iTextSharp.text.Font(font);
                            whiteFont.Color = BaseColor.WHITE;

                            PdfPCell cell = new PdfPCell(new Phrase(dgvListaMateriales.Columns[i].HeaderText, whiteFont));
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            cell.BackgroundColor = new BaseColor(0, 48, 101);
                            table.AddCell(cell);
                        }
                        doc.Add(table);



                        int maxFilasPorPagina = 20;
                        int numFilas = dgvListaMateriales.Rows.Count;
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
                            PdfPTable tableParte1 = new PdfPTable(dgvListaMateriales.Columns.Count);
                            tableParte1.WidthPercentage = 100;
                            float[] columnWidths1 = new float[] { 8f, 8f, 64f, 10f, 10f };
                            tableParte1.SetWidths(columnWidths1);

                            PdfPTable tableParte2 = new PdfPTable(dgvListaMateriales.Columns.Count);
                            tableParte2.WidthPercentage = 100;
                            float[] columnWidths2 = new float[] { 8f, 8f, 64f, 10f, 10f };
                            tableParte2.SetWidths(columnWidths2);

                            for (int i = 0; i < filasEnEstaPagina; i++)
                            {
                                int indiceFila = filaActual + i;
                                PdfPTable tablaActual = indiceFila < limiteFilasPrimeraPagina ? tableParte1 : tableParte2;

                                for (int j = 0; j < dgvListaMateriales.Columns.Count; j++)
                                {
                                    string valorCelda = dgvListaMateriales.Rows[indiceFila].Cells[j].Value.ToString();
                                    PdfPCell cell;

                                    if (j == 3 || j == 4)
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

                        doc.Add(new iTextSharp.text.Paragraph("\n"));


                        iTextSharp.text.Font whiteFontb = new iTextSharp.text.Font(fontand);
                        whiteFontb.Color = BaseColor.WHITE;
                        string cantidadletras = txbTotalLetra.Text;
                        string monedaescogida = cbMoneda.Text;
                        string cantidadeneletracompleta = "\n \n **" + cantidadletras + " " + monedaescogida + "**";
                        iTextSharp.text.Paragraph letracuadro = new iTextSharp.text.Paragraph(cantidadeneletracompleta, font);
                        string subtotal = txbSubtotal.Text;
                        string iva = txbIVA.Text;
                        string total = txbTotal.Text;
                        string cantidades = " $" + subtotal + "\n \n" + "$" + iva + "\n \n " + "$" + total;
                        iTextSharp.text.Paragraph cantidadescuadro = new iTextSharp.text.Paragraph(cantidades, font);

                        PdfPTable tableTotales = new PdfPTable(2);
                        tableTotales.WidthPercentage = 100;
                        tableTotales.SetWidths(new float[] { 70, 30 });

                        PdfPCell cellLet = new PdfPCell(new Phrase(cantidadeneletracompleta, font));
                        cellLet.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellLet.BorderWidth = 0;
                        tableTotales.AddCell(cellLet);


                        PdfPCell cellTotales = new PdfPCell(new Phrase(cantidades, whiteFontb));
                        cellTotales.HorizontalAlignment = Element.ALIGN_LEFT;
                        cellTotales.PaddingLeft = 90;
                        cellTotales.BorderWidth = 0;
                        tableTotales.AddCell(cellTotales);
                        float tableY = writer.GetVerticalPosition(false);
                        float tableeY = tableY - 63;
                        doc.Add(tableTotales);



                        // CANTIDAD
                        string rutaImagen4 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\Elastosystem\\cantidades.jpg";
                        iTextSharp.text.Image imagen4 = iTextSharp.text.Image.GetInstance(rutaImagen4);
                        imagen4.ScaleToFit(120f, 120f);
                        imagen4.SetAbsolutePosition(435, tableeY);
                        doc.Add(imagen4);



                        string cotizacion = txbCotizacion.Text;
                        string condicionpago = cbCondicionPago.Text;
                        string tiempoentrega = txbTiempoEntrega.Text;
                        string lugarentrega = txbLugarEntrega.Text;
                        string formapago = cbFormaPago.Text;
                        string condi = "______________________________CONDICIONES______________________________" + "\n" + "COTIZACIÓN: " + cotizacion + "\n" + "CONDICIÓN DE PAGO: " + condicionpago + "\n" + "TIEMPO DE ENTREGA: " + tiempoentrega + "\n" + "LUGAR DE ENTREGA: " + "\n" + lugarentrega + "\n" + "HORARIO DE RECEPCION DE MATERIALES 8:00 AM - 16:00 PM" + "\n" + "FORMA DE PAGO:" + formapago + "\n" + "METODO DE PAGO: PPD" + "\n" + "USO DE CFDI: ADQUISICION DE MERCANCIA" + "\n" + "ENTREGAR MATERIALES CON COPIA DE SU ORDEN DE COMPRA" + "\n" + certificadodecalidad;
                        iTextSharp.text.Paragraph condiciones = new iTextSharp.text.Paragraph(condi, font);

                        string solicit = lblSolicito.Text;
                        string use = txbTipoUso.Text;
                        string firma = "\n \n \n \n \n \n \n \n" + "FIRMA DE RECIBIDO: _______________________" + "\n \n" + "SOLICITO: " + solicit + "\n" + "USO: " + use;
                        iTextSharp.text.Paragraph firm = new iTextSharp.text.Paragraph(firma, font);

                        // Crear una tabla con una fila y dos celdas
                        PdfPTable tablea = new PdfPTable(3);
                        tablea.WidthPercentage = 100;
                        tablea.SetWidths(new float[] { 60, 40, 10 });

                        // Primera celda: párrafo de condiciones
                        PdfPCell cellCondiciones = new PdfPCell(new Phrase(condi, font));
                        cellCondiciones.HorizontalAlignment = Element.ALIGN_LEFT;
                        cellCondiciones.BorderWidth = 0;
                        tablea.AddCell(cellCondiciones);

                        // Segunda celda: párrafo de firma
                        PdfPCell cellFirma = new PdfPCell(new Phrase(firma, font));
                        cellFirma.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellFirma.BorderWidth = 0;
                        tablea.AddCell(cellFirma);
                        string f = " ";
                        PdfPCell cellF = new PdfPCell(new Phrase(f, font));
                        cellF.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellF.BorderWidth = 0;
                        tablea.AddCell(cellF);
                        float posXTabla = 40f;
                        float posYTabla = 198f;
                        float pie = 40f;
                        tablea.TotalWidth = doc.PageSize.Width;
                        tablea.WriteSelectedRows(0, -1, posXTabla, posYTabla, writer.DirectContent);


                        //PIE DE PAGINA
                        string rutaImagen3 = "\\\\10.120.1.3\\Departments$\\Sistemas\\Recursos_Sistemas\\Elastosystem\\pie.jpg";
                        float anchoObjetiv = 520f;
                        float altoObjetiv = 68f;
                        iTextSharp.text.Image imagen3 = iTextSharp.text.Image.GetInstance(rutaImagen3);
                        imagen3.ScaleToFit(anchoObjetiv, altoObjetiv);
                        imagen3.SetAbsolutePosition(doc.Left, pie);
                        doc.Add(imagen3);


                        doc.Close();

                        MessageBox.Show("PDF guardado como '" + System.IO.Path.GetFileName(rutaArchivoPDF) + "'", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MandarAIndicador();
                        LimpiarCampos();

                    }

                }
            }
            else
            {
                MessageBox.Show("DEBES DE LLENAR LOS CAMPOS OBLIGATORIOS");
                pbCampos2.Visible = true;
                lblCampos2.Visible = true;
                pbMoneda.Visible = true;
                pbConfirmacion.Visible = true;
                pbCondicion.Visible = true;
                pbTiempo.Visible = true;
                pbLugar.Visible = true;
                pbForma.Visible = true;
                pbRequi.Visible = true;
                pbCalidad.Visible = true;
            }
        }

        private void txbTotal_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txbTotal.Text, out decimal numero))
            {
                //REVISAR SI ES EN PESOS O DOLARES

                //string numeroEnLetras = VariablesGlobales.ConvertidorNumerosALetras.ConvertirNumeroALetras(numero);
                //txbTotalLetra.Text = numeroEnLetras;
            }
            else
            {

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AlmacenarRequisicion();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chbIVA.Checked)
            {
                double subt;
                subt = double.Parse(txbTotal.Text);
                double ivaa = 0;
                double totall = 0;
                ivaa = subt * 0.16;
                totall = subt + ivaa;
                txbIVA.Text = ivaa.ToString();
                txbTotal.Text = totall.ToString();

            }
            else
            {
                string sub = txbSubtotal.Text;
                txbIVA.Text = null;
                txbTotal.Text = sub;
            }
        }

        private void dgvListaMateriales_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblIDProducto.Text = id;

                string cantidad = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                txbCantidad.Text = cantidad;

                string unidad = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                txbUnidad.Text = unidad;

                string descripcion = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                txbDescripcion.Text = descripcion;

                string precio = dgv.Rows[rowIndex].Cells[4].Value.ToString();
                txbPrecio.Text = precio;

                EliminarDeCantidades();

            }
        }

        private void EliminarDeCantidades()
        {
            foreach (DataGridViewRow row in dgvListaMateriales.SelectedRows)
            {
                dgvListaMateriales.Rows.Remove(row);
            }
            Total();
            tabControl1.SelectedIndex = 0;
        }
    }
}
