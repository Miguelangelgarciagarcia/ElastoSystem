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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.IO;
using System.Drawing.Text;
using SpreadsheetLight;
using System.Net.Mail;
using System.Net;
using DocumentFormat.OpenXml.Math;

namespace ElastoSystem
{
    public partial class AlmacenBuscadorRegistrosTrabajadores : Form
    {
        private DateTime fecha1;
        private DateTime fecha2;
        public AlmacenBuscadorRegistrosTrabajadores()
        {
            InitializeComponent();
        }
        
        private void MandarALlamarProductos()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string sql = "SELECT Producto FROM elastosystem_almacen";

                    using (MySqlCommand comando = new MySqlCommand(sql, conn))
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                        while (reader.Read())
                        {
                            string producto = reader["Producto"].ToString();
                            cbProducto.Items.Add(producto);
                            autoCompleteCollection.Add(producto);
                        }

                        cbProducto.Sorted = true;

                        cbProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        cbProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        cbProducto.AutoCompleteCustomSource = autoCompleteCollection;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR PRODUCTOS: " + ex.Message);
            }
        }
        private void AlmacenBuscadorRegistrosTrabajadores_Load(object sender, EventArgs e)
        {
            MandarALlamarNombreCompleto();
            MandarALlamarProductos();
            Calendario1.Visible = false;
            Calendario2.Visible = false;
            pbCalendario1Cerrar.Visible = false;
            pbCalendario2Cerrar.Visible = false;
        }

        private Dictionary<int, string> empleadosDict = new Dictionary<int, string>();
        private void MandarALlamarNombreCompleto()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = "SELECT ID, Nombre, Apellido_Paterno, Apellido_Materno FROM elastosystem_rh";

                    using (MySqlCommand comando = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        empleadosDict.Clear();
                        cbNombreCompleto.Items.Clear();

                        List<string> nombresOrtdenados = new List<string>();

                        while (reader.Read())
                        {
                            int id = reader.GetInt32("ID");
                            string nombreCompleto = $"{reader.GetString("Nombre")} {reader.GetString("Apellido_Paterno")} {reader.GetString("Apellido_Materno")}";

                            empleadosDict[id] = nombreCompleto;
                            nombresOrtdenados.Add(nombreCompleto);
                        }
                        nombresOrtdenados.Sort();
                        cbNombreCompleto.Items.AddRange(nombresOrtdenados.ToArray());
                    }
                }

                cbNombreCompleto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbNombreCompleto.AutoCompleteSource = AutoCompleteSource.ListItems;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR EMPLEADOS: " + ex.Message);
            }
        }

        private void cbApellidoPaterno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbNombre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Calendario2.Visible = false;
            Calendario1.Visible = true;
            pbCalendario1Cerrar.Visible = true;
        }

        private void Calendario1_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtbFechaInicio.Text = Calendario1.SelectionStart.ToString("dd/MM/yyyy");
        }

        private void pbCalendario1Cerrar_Click(object sender, EventArgs e)
        {
            Calendario1.Visible = false;
            pbCalendario1Cerrar.Visible = false;
        }

        private void pbCalendario2_Click(object sender, EventArgs e)
        {
            Calendario1.Visible = false;
            Calendario2.Visible = true;
            pbCalendario2Cerrar.Visible = true;
        }

        private void pbCalendario2Cerrar_Click(object sender, EventArgs e)
        {
            Calendario2.Visible = false;
            pbCalendario2Cerrar.Visible = false;
        }

        private void Calendario2_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtbFechaTermino.Text = Calendario2.SelectionStart.ToString("dd/MM/yyyy");
        }

        private void AlmacenBuscadorRegistrosTrabajadores_Click(object sender, EventArgs e)
        {
            Calendario1.Visible = false;
            Calendario2.Visible = false;
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTodosTrabajadores.Checked)
            {
                txbNoTrabajador.Text = string.Empty;
                cbNombreCompleto.Text = string.Empty;
                cbNombreCompleto.Enabled = false;
            }
            else
            {
                cbNombreCompleto.Enabled = true;
            }

                
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTodosProductos.Checked)
            {
                cbProducto.Text = string.Empty;
                cbProducto.Enabled = false;
            }
            else
            {
                cbProducto.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            txtbFechaInicio.Text = string.Empty;
            txtbFechaTermino.Text = string.Empty;
            pbCalendario1.Enabled = !checkBox3.Checked;
            pbCalendario1Cerrar.Enabled = !checkBox3.Checked;
            pbCalendario2.Enabled = !checkBox3.Checked;
            pbCalendario2Cerrar.Enabled = !checkBox3.Checked;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calendario1.Visible = false;
            Calendario2.Visible = false;
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            if (chbTodosTrabajadores.Checked & chbTodosProductos.Checked & checkBox3.Checked)
            {
                string tabla = "SELECT Folio, No_Trabajador, Nombre, Producto, Cantidad, Unidad, Nota, Fechas, Horas FROM elastosystem_almacenregistro_salidas";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["Folio"].Visible = false;
                dgv.Columns["No_Trabajador"].Visible = false;
                dgv.Columns["Fechas"].HeaderText = "Fecha";
                dgv.Columns["Horas"].HeaderText = "Hora";
            }
            else if (!string.IsNullOrEmpty(txbNoTrabajador.Text) & chbTodosProductos.Checked & checkBox3.Checked)
            {
                String no_traba = txbNoTrabajador.Text;
                string tabla = "SELECT Folio, No_Trabajador, Nombre, Producto, Cantidad, Unidad, Nota, Fechas, Horas FROM elastosystem_almacenregistro_salidas WHERE No_Trabajador = '" + no_traba + "'";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["Folio"].Visible = false;
                dgv.Columns["No_Trabajador"].Visible = false;
                dgv.Columns["Fechas"].HeaderText = "Fecha";
                dgv.Columns["Horas"].HeaderText = "Hora";
            }
            else if (cbProducto.SelectedIndex != -1 & !string.IsNullOrEmpty(txbNoTrabajador.Text) & checkBox3.Checked)
            {
                String no_traba = txbNoTrabajador.Text;
                string producto = cbProducto.Text;
                string tabla = "SELECT Folio, No_Trabajador, Nombre, Producto, Cantidad, Unidad, Nota, Fechas, Horas FROM elastosystem_almacenregistro_salidas WHERE No_Trabajador = '" + no_traba + "'AND Producto = '" + producto + "'";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["Folio"].Visible = false;
                dgv.Columns["No_Trabajador"].Visible = false;
                dgv.Columns["Fechas"].HeaderText = "Fecha";
                dgv.Columns["Horas"].HeaderText = "Hora";
            }
            else if (chbTodosTrabajadores.Checked & cbProducto.SelectedIndex != -1 & checkBox3.Checked)
            {
                string producto = cbProducto.Text;
                string tabla = "SELECT Folio, No_Trabajador, Nombre, Producto, Cantidad, Unidad, Nota, Fechas, Horas FROM elastosystem_almacenregistro_salidas WHERE Producto = '" + producto + "'";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["Folio"].Visible = false;
                dgv.Columns["No_Trabajador"].Visible = false;
                dgv.Columns["Fechas"].HeaderText = "Fecha";
                dgv.Columns["Horas"].HeaderText = "Hora";

            }
            //////////////////////////////////////////////////////////
            else if (chbTodosTrabajadores.Checked & chbTodosProductos.Checked & !string.IsNullOrEmpty(txtbFechaInicio.Text) & !string.IsNullOrEmpty(txtbFechaTermino.Text))
            {
                DateTime fechaInicio = DateTime.ParseExact(txtbFechaInicio.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime fechaFin = DateTime.ParseExact(txtbFechaTermino.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                string fechaini = fechaInicio.ToString("yyyy-MM-dd");
                string fechafin = fechaFin.ToString("yyyy-MM-dd");

                string tabla = "SELECT Folio, No_Trabajador, Nombre, Producto, Cantidad, Unidad, Nota, Fechas, Horas FROM elastosystem_almacenregistro_salidas WHERE Fechas >= '" + fechaini + "' AND Fechas <= '" + fechafin + "'";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["Folio"].Visible = false;
                dgv.Columns["No_Trabajador"].Visible = false;
                dgv.Columns["Fechas"].HeaderText = "Fecha";
                dgv.Columns["Horas"].HeaderText = "Hora";


            }
            else if (!string.IsNullOrEmpty(txbNoTrabajador.Text) & chbTodosProductos.Checked & !string.IsNullOrEmpty(txtbFechaInicio.Text) & !string.IsNullOrEmpty(txtbFechaTermino.Text))
            {
                DateTime fechaInicio = DateTime.ParseExact(txtbFechaInicio.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime fechaFin = DateTime.ParseExact(txtbFechaTermino.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                string fechaini = fechaInicio.ToString("yyyy-MM-dd");
                string fechafin = fechaFin.ToString("yyyy-MM-dd");
                string no_traba = txbNoTrabajador.Text;
                string tabla = "SELECT Folio, No_Trabajador, Nombre, Producto, Cantidad, Unidad, Nota, Fechas, Horas FROM elastosystem_almacenregistro_salidas WHERE Fechas >= '" + fechaini + "' AND Fechas <= '" + fechafin + "' AND No_Trabajador = '" + no_traba + "'";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["Folio"].Visible = false;
                dgv.Columns["No_Trabajador"].Visible = false;
                dgv.Columns["Fechas"].HeaderText = "Fecha";
                dgv.Columns["Horas"].HeaderText = "Hora";
            }
            else if (chbTodosTrabajadores.Checked & cbProducto.SelectedIndex != -1 & !string.IsNullOrEmpty(txtbFechaInicio.Text) & !string.IsNullOrEmpty(txtbFechaTermino.Text))
            {
                DateTime fechaInicio = DateTime.ParseExact(txtbFechaInicio.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime fechaFin = DateTime.ParseExact(txtbFechaTermino.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                string fechaini = fechaInicio.ToString("yyyy-MM-dd");
                string fechafin = fechaFin.ToString("yyyy-MM-dd");
                string product = cbProducto.Text;
                string tabla = "SELECT Folio, No_Trabajador, Nombre, Producto, Cantidad, Unidad, Nota, Fechas, Horas FROM elastosystem_almacenregistro_salidas WHERE Fechas >= '" + fechaini + "' AND Fechas <= '" + fechafin + "' AND Producto = '" + product + "'";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["Folio"].Visible = false;
                dgv.Columns["No_Trabajador"].Visible = false;
                dgv.Columns["Fechas"].HeaderText = "Fecha";
                dgv.Columns["Horas"].HeaderText = "Hora";
            }
            else if (!string.IsNullOrEmpty(txbNoTrabajador.Text) & cbProducto.SelectedIndex != -1 & !string.IsNullOrEmpty(txtbFechaInicio.Text) & !string.IsNullOrEmpty(txtbFechaTermino.Text))
            {
                DateTime fechaInicio = DateTime.ParseExact(txtbFechaInicio.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime fechaFin = DateTime.ParseExact(txtbFechaTermino.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                string fechaini = fechaInicio.ToString("yyyy-MM-dd");
                string fechafin = fechaFin.ToString("yyyy-MM-dd");
                string not = txbNoTrabajador.Text;
                string product = cbProducto.Text;
                string tabla = "SELECT Folio, No_Trabajador, Nombre, Producto, Cantidad, Unidad, Nota, Fechas, Horas FROM elastosystem_almacenregistro_salidas WHERE Fechas >= '" + fechaini + "' AND Fechas <= '" + fechafin + "' AND Producto = '" + product + "' AND No_Trabajador = '" + not + "'";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dgv.DataSource = dt;
                dgv.Columns["Folio"].Visible = false;
                dgv.Columns["No_Trabajador"].Visible = false;
                dgv.Columns["Fechas"].HeaderText = "Fecha";
                dgv.Columns["Horas"].HeaderText = "Hora";
            }
            else
            {
                MessageBox.Show("Debes de seleccionar alguna opcion de los 3 campos requeridos");
                dgv.DataSource = null;
            }
            mySqlConnection.Close();

        }

        private void button2_Click(object sender, EventArgs e, PageSize PageSize, PageSize pageSize)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                ExportarDataGridViewAExcel(dgv);
            }
            else
            {
                MessageBox.Show("No hay nada por exportar");
            }
        }
        private void ExportarDataGridViewAExcel(DataGridView dataGridView)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Guardar reporte como";
                    saveFileDialog.FileName = "Reporte_Consumibles.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new ClosedXML.Excel.XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Reporte");

                            for (int i = 0; i < dataGridView.Columns.Count; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = dataGridView.Columns[i].HeaderText;
                            }

                            for (int i = 0; i < dataGridView.Rows.Count; i++)
                            {
                                for (int j = 0; j < dataGridView.Columns.Count; j++)
                                {
                                    worksheet.Cell(i + 2, j + 1).Value = dataGridView.Rows[i].Cells[j].Value?.ToString() ?? string.Empty;
                                }
                            }
                            worksheet.Columns().AdjustToContents();

                            workbook.SaveAs(saveFileDialog.FileName);

                            MessageBox.Show("Exportación exitosa");
                            System.Diagnostics.Process.Start("explorer.exe", saveFileDialog.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void cbNombreCompleto_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbNombreCompleto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNombreCompleto.SelectedItem != null)
            {
                string seleccionado = cbNombreCompleto.SelectedItem.ToString();

                int idEmpleado = empleadosDict.FirstOrDefault(x => x.Value == seleccionado).Key;

                txbNoTrabajador.Text = idEmpleado.ToString();
            }
        }

        private void cbProducto_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
