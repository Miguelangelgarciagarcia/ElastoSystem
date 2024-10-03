using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Parameters;
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
    public partial class Ventas_Clientes : Form
    {
        public Ventas_Clientes()
        {
            InitializeComponent();
        }
        private void OrdenTab()
        {
            txbEmpresa.TabIndex = 0;
            txbCliente.TabIndex = 1;
            txbTelefono.TabIndex = 2;
            txbCorreo.TabIndex = 3;
            txbRFC.TabIndex = 4;
            txbDireccion.TabIndex = 5;
            txbBanco.TabIndex = 6;
            txbNoCuenta.TabIndex = 7;
            txbClabe.TabIndex = 8;
        }
        private void MandarALlamarBDClientes()
        {
            string tabla = "SELECT * FROM elastosystem_ventas_clientes";
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
            DataTable dt = new DataTable();
            mySqlAdapter.Fill(dt);
            dgvClientes.DataSource = dt;
            dt.DefaultView.Sort = "Empresa ASC";
            dgvClientes.Columns["ID"].Visible = false;
            dgvClientes.Columns["RFC"].Visible = false;
            dgvClientes.Columns["Banco"].Visible=false;
            dgvClientes.Columns["NoCuenta"].Visible= false;
            dgvClientes.Columns["Clabe"].Visible = false;
        }
        private void AgregarCliente()
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                mySqlConnection.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = mySqlConnection;
                if (string.IsNullOrWhiteSpace(txbEmpresa.Text) || string.IsNullOrWhiteSpace(txbCliente.Text) || string.IsNullOrWhiteSpace(txbTelefono.Text) || string.IsNullOrEmpty(txbCorreo.Text) || string.IsNullOrEmpty(txbRFC.Text) || string.IsNullOrEmpty(txbDireccion.Text) || string.IsNullOrEmpty(txbBanco.Text) || string.IsNullOrEmpty(txbNoCuenta.Text) || string.IsNullOrEmpty(txbClabe.Text))
                {
                    MessageBox.Show("Favor de Ingresar todos los datos obligatorios.");
                    VisiblesCampos();
                }
                else
                {
                    comando.CommandText = "INSERT INTO elastosystem_ventas_clientes (Empresa, Direccion, Telefono, Correo, RFC, Contacto, Banco, NoCuenta, Clabe) VALUES('" + txbEmpresa.Text + "','" + txbDireccion.Text + "','" + txbTelefono.Text + "' , '" + txbCorreo.Text + "','" + txbRFC.Text + "','" + txbCliente.Text + "','" + txbBanco.Text + "' , '" + txbNoCuenta.Text + "', '" + txbClabe.Text + "');";
                    comando.ExecuteNonQuery();
                    mySqlConnection.Close();
                    MessageBox.Show("Cliente: " + txbCliente.Text + " registrado");
                    LimpiarDatosCliente();
                    MandarALlamarBDClientes();
                    OcultarCampos();
                }
            }
            catch
            {
                MessageBox.Show("Error al registrar datos");
            }
        }

        private void VisiblesCampos()
        {
            lblCampos.Visible = true;
            pbCampos.Visible = true;
            pbEmpresa.Visible = true;
            pbCliente.Visible = true;
            pbTelefono.Visible = true;
            pbCorreo.Visible = true;
            pbRFC.Visible = true;
            pbDireccion.Visible = true; 
            pbBanco.Visible = true;
            pbNoCuenta.Visible = true;
            pbClabe.Visible = true;
        }

        private void OcultarCampos()
        {
            lblCampos.Visible = false;
            pbCampos.Visible = false;
            pbEmpresa.Visible = false;
            pbCliente.Visible = false;
            pbTelefono.Visible = false;
            pbCorreo.Visible = false;
            pbRFC.Visible = false;
            pbDireccion.Visible = false;
            pbBanco.Visible = false;
            pbNoCuenta.Visible = false;
            pbClabe.Visible = false;
        }

        private void LimpiarDatosCliente()
        {
            txbEmpresa.Clear();
            txbCliente.Clear();
            txbTelefono.Clear();
            txbCorreo.Clear();
            txbRFC.Clear();
            txbDireccion.Clear();
            txbBanco.Clear();
            txbNoCuenta.Clear();
            txbClabe.Clear();
            txbBuscador.Clear();
            
        }
        private void BotonesHabilitadosEInhabilitadosDGV()
        {
            btnAgregarCliente.Visible = false;
            btnNuevo.Visible = true;
            btnEliminar.Visible = true;
            btnActualizar.Visible = true;

            btnEliminar.Enabled = true;
            btnActualizar.Enabled = true;
            btnNuevo.Enabled = true;
        }
        private void BotonesHabilitadosEInhabilitadosNuevo()
        {
            btnNuevo.Visible = false;
            btnEliminar.Visible = false;
            btnActualizar.Visible = false;
            btnAgregarCliente.Visible = true;

        }
        private void EliminarRegistro()
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                mySqlConnection.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = mySqlConnection;
                comando.CommandText = "DELETE FROM elastosystem_ventas_clientes WHERE ID = '" + lblID.Text + "'";
                comando.ExecuteNonQuery();
                mySqlConnection.Close();
                MessageBox.Show("Cliente: " + txbEmpresa.Text + " eliminado");
                LimpiarDatosCliente();
                MandarALlamarBDClientes();
            }
            catch
            {
                MessageBox.Show("Error al eliminar cliente");
            }
        }
        private void ActualizarRegistro()
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                mySqlConnection.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = mySqlConnection;
                if (string.IsNullOrWhiteSpace(txbEmpresa.Text) || string.IsNullOrWhiteSpace(txbCliente.Text) || string.IsNullOrWhiteSpace(txbTelefono.Text) || string.IsNullOrEmpty(txbCorreo.Text) || string.IsNullOrEmpty(txbRFC.Text) || string.IsNullOrEmpty(txbDireccion.Text) || string.IsNullOrEmpty(txbBanco.Text) || string.IsNullOrEmpty(txbNoCuenta.Text) || string.IsNullOrEmpty(txbClabe.Text))
                {
                    MessageBox.Show("Favor de Ingresar todos los datos");
                    VisiblesCampos();
                }
                else
                {
                    comando.CommandText = "UPDATE elastosystem_ventas_clientes SET Empresa = '" + txbEmpresa.Text + "', Direccion = '" + txbDireccion.Text + "', Telefono = '" + txbTelefono.Text + "', Correo = '" + txbCorreo.Text + "', RFC = '" + txbRFC.Text + "', Contacto = '" + txbCliente.Text + "', Banco = '" + txbBanco.Text + "', NoCuenta = '" + txbNoCuenta.Text + "', Clabe = '" + txbClabe.Text + "' WHERE ID = '" + lblID.Text + "'";
                    comando.ExecuteNonQuery();
                    mySqlConnection.Close();
                    MessageBox.Show("Cliente: " + txbCliente.Text + " actaualizado");
                    LimpiarDatosCliente();
                    MandarALlamarBDClientes();
                    OcultarCampos();
                }
            }
            catch
            {
                MessageBox.Show("Error al actualizar datos");
            }
        }
        private void Buscador()
        {
            try
            {
                string valorBusqueda = txbBuscador.Text;
                string consulta = "SELECT * FROM elastosystem_ventas_clientes WHERE Empresa LIKE @ValorBusqueda OR Contacto LIKE @ValorBusqueda";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, VariablesGlobales.ConexionBDElastotecnica);

                adaptador.SelectCommand.Parameters.AddWithValue("@ValorBusqueda", "%" + valorBusqueda + "%");

                DataSet datos = new DataSet();

                adaptador.Fill(datos, "Resultados");

                dgvClientes.DataSource = datos.Tables["Resultados"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar datos: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Ventas_Clientes_Load(object sender, EventArgs e)
        {
            MandarALlamarBDClientes();
            OrdenTab();
        }
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            AgregarCliente();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarDatosCliente();
        }
        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {

        }
        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            OcultarCampos();
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblID.Text = id;

                string empresa = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                txbEmpresa.Text = empresa;

                string direccion = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                txbDireccion.Text = direccion;

                string telefono = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                txbTelefono.Text = telefono;

                string correo = dgv.Rows[rowIndex].Cells[4].Value.ToString();
                txbCorreo.Text = correo;

                string rfc = dgv.Rows[rowIndex].Cells[5].Value.ToString();
                txbRFC.Text = rfc;

                string cliente = dgv.Rows[rowIndex].Cells[6].Value.ToString();
                txbCliente.Text = cliente;

                string banco = dgv.Rows[rowIndex].Cells[7].Value.ToString();
                txbBanco.Text = banco;

                string nocuenta = dgv.Rows[rowIndex].Cells[8].Value.ToString();
                txbNoCuenta.Text = nocuenta;

                string clabe = dgv.Rows[rowIndex].Cells[9].Value.ToString();
                txbClabe.Text = clabe;

            }
            BotonesHabilitadosEInhabilitadosDGV();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BotonesHabilitadosEInhabilitadosNuevo();
            LimpiarDatosCliente();
            lblID.Text = string.Empty;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarRegistro();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscador();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txbBuscador_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txbBuscador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Buscador();
            }
        }

        private void txbBuscador_TextChanged(object sender, EventArgs e)
        {
            OcultarCampos();
            Buscador();
        }
    }
}
