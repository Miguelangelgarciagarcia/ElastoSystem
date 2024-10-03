using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class Compras_Proovedores : Form
    {
        public Compras_Proovedores()
        {
            InitializeComponent();
        }
        private void VisiblesCampos()
        {
            pbCampos.Visible = true;
            lblCampos.Visible=true;
            pbNombre.Visible=true;
            pbCorreo.Visible=true;
            pbTelefono.Visible=true;
            pbRFC.Visible=true;
            pbDireccion.Visible=true;
            pbProductos.Visible=true;
            pbContacto.Visible=true;
            pbNumeroCuenta.Visible=true;
        }
        private void OcultarCampos()
        {
            pbCampos.Visible = false;
            lblCampos.Visible=false;
            pbNombre.Visible=false;
            pbCorreo.Visible=false;
            pbTelefono.Visible=false;
            pbRFC.Visible=false;
            pbDireccion.Visible=false;
            pbProductos.Visible=false;
            pbContacto.Visible=false;
            pbNumeroCuenta.Visible = false;
        }
        private void CargarProveedores()
        {
            try
            {
                string tabla = "SELECT ID, Nombre, Email, Telefono, RFC, Direccion, Productos, Contacto, NumeroCuenta, Critico FROM elastosystem_compras_proveedores";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla,VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dgvProveedores.DataSource = dt;
                dgvProveedores.Columns["ID"].Visible = false;
                dgvProveedores.Columns["NumeroCuenta"].Visible = false;
                dgvProveedores.Columns["Critico"].Visible = false;
                dt.DefaultView.Sort = "Nombre ASC";
            }
            catch (Exception ex)
            {

            }
        }
        private void Buscador()
        {
            try
            {

                string valorBusqueda = txbBuscador.Text;
                string consulta = "SELECT ID, Nombre, Email, Telefono, RFC, Direccion, Productos, Contacto, NumeroCuenta, Critico FROM elastosystem_compras_proveedores WHERE Nombre LIKE @ValorBusqueda OR Productos LIKE @ValorBusqueda";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, VariablesGlobales.ConexionBDElastotecnica);

                adaptador.SelectCommand.Parameters.AddWithValue("@ValorBusqueda", "%" + valorBusqueda + "%");

                DataSet datos = new DataSet();

                adaptador.Fill(datos, "Resultados");

                dgvProveedores.DataSource = datos.Tables["Resultados"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar datos: " + ex.Message);
            }
        }
        private void AgregarProveedor()
        {
            try
            {
                bool boolCritico = chbCritico.Checked;
                MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                mySqlConnection.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = mySqlConnection;
                if (string.IsNullOrWhiteSpace(txbNombre.Text) || string.IsNullOrWhiteSpace(txbEmail.Text) || string.IsNullOrWhiteSpace(txbTelefono.Text) || string.IsNullOrEmpty(txbRFC.Text) || string.IsNullOrEmpty(txbDireccion.Text) || string.IsNullOrEmpty(txbProductos.Text) || string.IsNullOrEmpty(txbContacto.Text) || string.IsNullOrEmpty(txbNoCuenta.Text))
                {
                    MessageBox.Show("Favor de ingresar todos los datos");
                    VisiblesCampos();
                }
                else
                {
                    comando.CommandText = "INSERT INTO elastosystem_compras_proveedores (Nombre, Email, Telefono, RFC, Direccion, Productos, Contacto, NumeroCuenta, Critico) VALUES('" + txbNombre.Text + "','" + txbEmail.Text + "','" + txbTelefono.Text + "' , '" + txbRFC.Text + "', '" + txbDireccion.Text + "', '" + txbProductos.Text + "', '" + txbContacto.Text + "', '" + txbNoCuenta.Text + "', " + boolCritico + ");";
                    comando.ExecuteNonQuery();
                    mySqlConnection.Close();
                    MessageBox.Show("Proveedor: " + txbNombre.Text + " registrado");
                    LimpiarCampos();
                    CargarProveedores();
                }
            }
            catch
            {
                MessageBox.Show("Error al registrar datos");
            }
        }
        private void LimpiarCampos()
        {
            txbNombre.Clear();
            txbEmail.Clear();
            txbTelefono.Clear();
            txbRFC.Clear();
            txbDireccion.Clear();
            txbProductos.Clear();
            txbContacto.Clear();
            txbNoCuenta.Clear();
            chbCritico.Checked = false;
            txbBuscador.Clear();
            OcultarCampos();
        }
        private void ModificarProveedor()
        {
            try
            {
                bool boolCritico = chbCritico.Checked;
                MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                mySqlConnection.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = mySqlConnection;
                if (string.IsNullOrWhiteSpace(txbNombre.Text) || string.IsNullOrWhiteSpace(txbEmail.Text) || string.IsNullOrWhiteSpace(txbTelefono.Text) || string.IsNullOrEmpty(txbRFC.Text) || string.IsNullOrEmpty(txbDireccion.Text) || string.IsNullOrEmpty(txbProductos.Text) || string.IsNullOrEmpty(txbContacto.Text) || string.IsNullOrEmpty(txbNoCuenta.Text))
                {
                    MessageBox.Show("Favor de Ingresar todos los datos");
                    VisiblesCampos();
                }
                else
                {
                    comando.CommandText = "UPDATE elastosystem_compras_proveedores SET Nombre = '" + txbNombre.Text + "', Email = '" + txbEmail.Text + "', Telefono = '" + txbTelefono.Text + "', RFC = '" + txbRFC.Text + "', Direccion = '" + txbDireccion.Text + "', Productos = '" + txbProductos.Text + "', Contacto = '" + txbContacto.Text + "', NumeroCuenta = '" + txbNoCuenta.Text + "', Critico = " + boolCritico + " WHERE ID = '" + lblID.Text + "'";
                    comando.ExecuteNonQuery();
                    mySqlConnection.Close();
                    MessageBox.Show("Proveedor: " + txbNombre.Text + " actaualizado");
                    LimpiarCampos();
                    CargarProveedores();
                    lblID.Text = " ";
                }
            }
            catch
            {
                MessageBox.Show("Error al actualizar datos");
            }
        }
        private void EliminarProveedor()
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                mySqlConnection.Open();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = mySqlConnection;
                comando.CommandText = "DELETE FROM elastosystem_compras_proveedores WHERE ID = '" + lblID.Text + "'";
                comando.ExecuteNonQuery();
                mySqlConnection.Close();
                MessageBox.Show("Proveedor: " + txbNombre.Text + " eliminado");
                LimpiarCampos();
                CargarProveedores();
                lblID.Text = " ";
            }
            catch
            {
                MessageBox.Show("Error al eliminar cliente");
            }
        }
        private void chbMostrarTodos_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void dgvProveedores_DoubleClick(object sender, EventArgs e)
        {
            btnAgregar.Visible = false;
            btnEliminar.Visible = true;
            btnModificar.Visible = true;
            btnNuevo.Visible = true;
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblID.Text = id;

                string nombre = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                txbNombre.Text = nombre;

                string email = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                txbEmail.Text = email;

                string telefono = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                txbTelefono.Text = telefono;

                string rfc = dgv.Rows[rowIndex].Cells[4].Value.ToString();
                txbRFC.Text = rfc;

                string direccion = dgv.Rows[rowIndex].Cells[5].Value.ToString();
                txbDireccion.Text = direccion;

                string productos = dgv.Rows[rowIndex].Cells[6].Value.ToString();
                txbProductos.Text = productos;

                string contacto = dgv.Rows[rowIndex].Cells[7].Value.ToString();
                txbContacto.Text = contacto;

                string numerocuenta = dgv.Rows[rowIndex].Cells[8].Value.ToString();
                txbNoCuenta.Text = numerocuenta;

                bool valorBooleano = (bool)dgv.Rows[rowIndex].Cells[9].Value;
                chbCritico.Checked = valorBooleano;
            }
        }
        private void Tabuladores()
        {
            txbNombre.TabIndex = 0;
            txbEmail.TabIndex = 1;
            txbTelefono.TabIndex = 2;
            txbRFC.TabIndex = 3;
            txbDireccion.TabIndex = 4;
            txbProductos.TabIndex = 5;
            txbContacto.TabIndex = 6;
            txbNoCuenta.TabIndex = 7;
            chbCritico.TabIndex = 8;
            btnAgregar.TabIndex = 9;
            txbBuscador.TabIndex = 10;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnNuevo.Visible = false;
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
            btnAgregar.Visible = true;
            LimpiarCampos();
        }

        private void Compras_Proovedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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
            Buscador();
        }

        private void chbCritico_CheckStateChanged(object sender, EventArgs e)
        {
            if (chbCritico.Checked)
            {
                chbCritico.Text = "Critico";
                lblCritico.Text = "1";
            }
            else
            {
                chbCritico.Text = "No Critico";
                lblCritico.Text = "2";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProveedor();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarProveedor();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarProveedor();
        }
    }
}
