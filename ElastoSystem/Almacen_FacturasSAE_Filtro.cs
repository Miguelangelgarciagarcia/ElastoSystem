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
    public partial class Almacen_FacturasSAE_Filtro : Form
    {
        public string Producto { get; private set; }
        public string Cliente { get; private set; }
        public string Fechas { get; private set; }
        public string FechaInicio { get; private set; }
        public string FechaFinal { get; private set; }

        public Almacen_FacturasSAE_Filtro()
        {
            InitializeComponent();
        }

        private void Almacen_FacturasSAE_Filtro_Load(object sender, EventArgs e)
        {
            CargarProductos();
            LlamarClientes();
        }

        private void LlamarClientes()
        {
            cbClientes.Items.Clear();
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();

            FbConnectionStringBuilder cadena = new FbConnectionStringBuilder
            {
                UserID = "SYSDBA",
                Password = "masterkey",
                Database = VariablesGlobales.DireccionBDSAE,
                DataSource = VariablesGlobales.IPSAE,
                Port = 3050
            };

            using (FbConnection conn = new FbConnection(cadena.ConnectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT CLAVE, NOMBRE FROM clie01 WHERE STATUS = 'A'";
                    FbCommand cmd = new FbCommand(sql, conn);
                    FbDataReader reader = cmd.ExecuteReader();

                    Dictionary<string, string> clientes = new Dictionary<string, string>();

                    while (reader.Read())
                    {
                        string clave = reader["CLAVE"].ToString();
                        string nombre = reader["NOMBRE"].ToString();

                        if (!string.IsNullOrEmpty(nombre))
                        {
                            clientes[nombre] = clave;
                        }
                    }

                    var nombresClientes = clientes.Keys.ToList();
                    nombresClientes.Sort();

                    cbClientes.Items.AddRange(nombresClientes.ToArray());
                    autoComplete.AddRange(nombresClientes.ToArray());
                    cbClientes.AutoCompleteCustomSource = autoComplete;

                    VariablesGlobales.ClientesSAE = clientes;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR CLIENTES DE SAE: " + ex.Message);
                }
            }
        }

        private void CargarProductos()
        {
            cbProductos.Items.Clear();
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);

            try
            {
                conn.Open();
                string sql = "SELECT Producto FROM elastosystem_sae_productos";

                List<string> productos = new List<string>();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string producto = reader["Producto"].ToString();
                        if (!string.IsNullOrEmpty(producto) && !producto.StartsWith("0") && !producto.StartsWith(" "))
                        {
                            productos.Add(producto);
                        }
                    }
                }
                productos.Sort();
                cbProductos.Items.AddRange(productos.ToArray());
                autoComplete.AddRange(productos.ToArray());
                cbProductos.AutoCompleteCustomSource = autoComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"OCURRIO UN ERROR AL CARGAR LOS PRODUCTOS: {ex.Message}");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
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

        private void txbFechaInicio_TextChanged(object sender, EventArgs e)
        {
            chbNoFiltrarFechas.Checked = false;
            if (txbFechaInicio.Text == string.Empty && txbFechaFin.Text == string.Empty)
            {
                chbNoFiltrarFechas.Checked = true;
            }
            string texto = txbFechaInicio.Text.Replace("-", "");

            if (texto.Length > 8) texto = texto.Substring(0, 8);

            string nuevoTexto = "";

            for (int i = 0; i < texto.Length; i++)
            {
                if (i == 4 || i == 6) nuevoTexto += "-";
                nuevoTexto += texto[i];
            }

            txbFechaInicio.Text = nuevoTexto;
            txbFechaInicio.SelectionStart = txbFechaInicio.Text.Length;
        }

        private void txbFechaFin_TextChanged(object sender, EventArgs e)
        {
            chbNoFiltrarFechas.Checked = false;
            if (txbFechaInicio.Text == string.Empty && txbFechaFin.Text == string.Empty)
            {
                chbNoFiltrarFechas.Checked = true;
            }
            string texto = txbFechaFin.Text.Replace("-", "");

            if (texto.Length > 8) texto = texto.Substring(0, 8);

            string nuevoTexto = "";

            for (int i = 0; i < texto.Length; i++)
            {
                if (i == 4 || i == 6) nuevoTexto += "-";
                nuevoTexto += texto[i];
            }

            txbFechaFin.Text = nuevoTexto;
            txbFechaFin.SelectionStart = txbFechaFin.Text.Length;
        }

        private void txbFechaInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txbFechaFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fechainicio, fechafinal;

            bool inicioValido = DateTime.TryParseExact(txbFechaInicio.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out fechainicio);
            bool finalValido = DateTime.TryParseExact(txbFechaFin.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out fechafinal);

            if(inicioValido && string.IsNullOrWhiteSpace(txbFechaFin.Text))
            {
                fechafinal = DateTime.Today;
                txbFechaFin.Text = fechafinal.ToString("yyyy-MM-dd");
                finalValido = true;
            }

            if (string.IsNullOrWhiteSpace(txbFechaInicio.Text) && string.IsNullOrWhiteSpace(txbFechaFin.Text))
            {

            }
            else if (inicioValido && finalValido)
            {
                if (fechafinal < fechainicio)
                {
                    MessageBox.Show("LA FECHA FINAL NO PUEDE SER MENOR QUE LA FECHA DE INICIO");
                    return;
                }
            }
            else
            {
                MessageBox.Show("FORMATO DE FECHA INCORRECTO. USA EL FORMATO: YYYY-MM-DD");
                return;
            }

            string productos = chbTodoslosProductos.Checked ? "productostodos" : cbProductos.Text;
            string clientes = chbTodosClientes.Checked ? "clientestodos" : lblClaveCliente.Text;
            string fechas = chbNoFiltrarFechas.Checked ? "fechasnofiltradas" : $"{txbFechaInicio.Text} - {txbFechaFin.Text}";

            string fechaini = chbNoFiltrarFechas.Checked ? null : txbFechaInicio.Text;
            string fechafn = chbNoFiltrarFechas.Checked ? null : txbFechaFin.Text;

            Producto = productos;
            Cliente = clientes;
            Fechas = fechas;
            FechaInicio = fechaini;
            FechaFinal = fechafn;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void chbTodoslosProductos_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTodoslosProductos.Checked)
            {
                cbProductos.SelectedIndex = -1;
            }

            if (!chbTodoslosProductos.Checked && string.IsNullOrWhiteSpace(cbProductos.Text))
            {
                chbTodoslosProductos.Checked = true;
            }
        }

        private void chbNoFiltrarFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNoFiltrarFechas.Checked)
            {
                txbFechaInicio.Clear();
                txbFechaFin.Clear();
            }

            if (!chbNoFiltrarFechas.Checked && string.IsNullOrWhiteSpace(txbFechaInicio.Text) && string.IsNullOrWhiteSpace(txbFechaFin.Text))
            {
                chbNoFiltrarFechas.Checked = true;
            }
        }

        private void cbProductos_TextChanged(object sender, EventArgs e)
        {
            chbTodoslosProductos.Checked = false;
            if (cbProductos.Text == string.Empty)
            {
                chbTodoslosProductos.Checked = true;
            }
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            chbTodoslosProductos.Checked = false;
            if (cbProductos.Text == string.Empty)
            {
                chbTodoslosProductos.Checked = true;
            }
        }

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            chbTodosClientes.Checked = false;
            if (cbClientes.Text == string.Empty)
            {
                chbTodosClientes.Checked = true;
            }
            if (cbClientes.SelectedItem != null)
            {
                string nombreSeleccionado = cbClientes.SelectedItem.ToString();

                if (VariablesGlobales.ClientesSAE.ContainsKey(nombreSeleccionado))
                {
                    lblClaveCliente.Text = VariablesGlobales.ClientesSAE[nombreSeleccionado];
                }
            }
        }

        private void cbClientes_TextChanged(object sender, EventArgs e)
        {
            chbTodosClientes.Checked = false;
            if (cbClientes.Text == string.Empty)
            {
                chbTodosClientes.Checked = true;
            }
        }

        private void chbTodosClientes_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTodosClientes.Checked)
            {
                cbClientes.SelectedIndex = -1;
            }

            if (!chbTodosClientes.Checked && string.IsNullOrWhiteSpace(cbClientes.Text))
            {
                chbTodosClientes.Checked = true;
            }
        }
    }
}
