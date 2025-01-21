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
    public partial class Almacen_Admin_Inventario : Form
    {
        public Almacen_Admin_Inventario()
        {
            InitializeComponent();
        }

        private void Almacen_Admin_Inventario_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            cbProductos.Items.Clear();
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);

            try
            {
                mySqlConnection.Open();
                string sql = "SELECT Producto FROM elastosystem_sae_productos";

                List<string> productos = new List<string>();
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = comando.ExecuteReader();

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
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbConsumoMensual.Clear();
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            String producto = cbProductos.Text;
            MySqlDataReader reader = null;
            string sql = "SELECT 1M FROM elastosystem_sae_productos WHERE Producto ='" + producto + "' ";
            try
            {
                HashSet<string> unicos = new HashSet<string>();
                MySqlCommand comando = new MySqlCommand(sql, conn);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txbConsumoMensual.Text = reader.GetString(0);

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
                conn.Close();
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            CalcularMesesYAgregar();
        }

        private void Limpiar()
        {
            cbProductos.SelectedIndex = -1;
            txbConsumoMensual.Clear();
        }

        private void CalcularMesesYAgregar()
        {
            int m1 = int.Parse(txbConsumoMensual.Text);
            int m2 = m1 * 2;
            int m3 = m1 * 3;

            using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "UPDATE elastosystem_sae_productos SET 1M = @MES1, 2M = @MES2, 3M = @MES3 WHERE Producto = @PRODUCTO";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@MES1", m1);
                    cmd.Parameters.AddWithValue("@MES2", m2);
                    cmd.Parameters.AddWithValue("@MES3", m3);
                    cmd.Parameters.AddWithValue("@PRODUCTO", cbProductos.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if(rowsAffected > 0)
                    {
                        MessageBox.Show("PRODUCTO ACTUALIZADO CORRECTAMENTE");
                        Limpiar();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR LOS DATOS: "+ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

        }
    }
}
