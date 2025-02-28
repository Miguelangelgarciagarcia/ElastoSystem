using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Wordprocessing;
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
    public partial class AlmacenRegistrarExistencias : Form
    {
        public AlmacenRegistrarExistencias()
        {
            InitializeComponent();
            OrdenTab();

        }

        private void MandarALlamarAlmacen()
        {
            string tabla = "SELECT ID_Producto, Producto, Descripcion, Existencias, Unidad FROM elastosystem_almacen";
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
            DataTable dt = new DataTable();
            mySqlAdapter.Fill(dt);
            dgvAlmacen.DataSource = dt;
            dgvAlmacen.Columns["ID_Producto"].Visible = false;
        }


        private void OrdenTab()
        {
            txbID.TabIndex = 0;
            txbProducto.TabIndex = 1;
            txbExistencias.TabIndex = 2;
            txbAdd.TabIndex = 3;
            txbNotas.TabIndex = 4;
            button2.TabIndex = 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void AlmacenRegistrarExistencias_Load(object sender, EventArgs e)
        {
            MandarALlamarAlmacen();
            MandarALlamarHistorialRegistro();
        }

        private void MandarALlamarHistorialRegistro()
        {
            string tabla = "SELECT * FROM elastosystem_almacenregistrosexistencias ORDER BY ID DESC";
            MySqlDataAdapter adaptador = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dgvHistorial.DataSource = dt;
            dgvHistorial.Columns["ID"].Visible = false;
            dgvHistorial.Columns["ID_Producto"].Visible = false;
            dgvHistorial.Columns["EDOP"].Visible = false;
            dgvHistorial.Columns["Autorizo"].Visible = false;
            dgvHistorial.Columns["OC"].HeaderText = "Nota";
        }

        private void txbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(button1_Click, EventArgs.Empty);
            }
        }

        private void Limpiar()
        {
            txbID.Clear();
            txbProducto.Clear();
            txbExistencias.Clear();
            txbAdd.Clear();
            txbNotas.Clear();
            MandarALlamarAlmacen();
            MandarALlamarHistorialRegistro();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbID.Text))
            {
                if (!string.IsNullOrEmpty(txbAdd.Text))
                {
                    double resultado = 0;
                    double existencias = 0;
                    double agregado = 0;

                    double.TryParse(txbExistencias.Text, out existencias);
                    double.TryParse(txbAdd.Text, out agregado);

                    DateTime saveNow = DateTime.Now;
                    string fecha = saveNow.ToShortDateString();
                    string hora = saveNow.ToShortTimeString();

                    try
                    {
                        using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                        {
                            conn.Open();

                            if(agregado < existencias || agregado > existencias)
                            {
                                resultado = agregado - existencias;

                                using(MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO elastosystem_almacenregistrosexistencias (Usuario, ID_Producto, Producto, Operacion, Fecha, Hora, OC) VALUES (@USUARIO, @IDPRODUCTO, @PRODUCTO, @OPERACION, @FECHA, @HORA, @OC)", conn))
                                {
                                    cmdInsert.Parameters.AddWithValue("@USUARIO", VariablesGlobales.Usuario);
                                    cmdInsert.Parameters.AddWithValue("@IDPRODUCTO", txbID.Text);
                                    cmdInsert.Parameters.AddWithValue("@PRODUCTO", txbProducto.Text);
                                    cmdInsert.Parameters.AddWithValue("@OPERACION", resultado);
                                    cmdInsert.Parameters.AddWithValue("@FECHA", fecha);
                                    cmdInsert.Parameters.AddWithValue("@HORA", hora);
                                    cmdInsert.Parameters.AddWithValue("@OC", txbNotas.Text);
                                    cmdInsert.ExecuteNonQuery();
                                }

                                using(MySqlCommand cmdUpdate = new MySqlCommand("UPDATE elastosystem_almacen SET Existencias = @EXISTENCIAS WHERE ID_Producto = @IDPROD", conn))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@EXISTENCIAS", txbAdd.Text);
                                    cmdUpdate.Parameters.AddWithValue("@IDPROD", txbID.Text);
                                    cmdUpdate.ExecuteNonQuery();
                                }

                                MessageBox.Show("EXISTENCIAS ACTUALIZADAS");
                                Limpiar();
                            }
                            else
                            {
                                MessageBox.Show("NO SE ACTUALIZA YA QUE ES EL MISMO VALOR INICIAL Y FINAL");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR AL ACTUALIZAR EXISTENCIAS: " + ex);
                    }
                }
                else
                {
                    MessageBox.Show("NO HAS INGRESADO NADA EN LA EXISTENCIA FINAL");
                }
            }
            else
            {
                MessageBox.Show("DEBES DE SELECCIONAR UN PRODUCTO");
                return;
            }
        }

        private void txbclave_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {

        }

        private void txbBuscador_TextChanged(object sender, EventArgs e)
        {
            Buscador();
        }

        private void Buscador()
        {
            try
            {
                string valorBusqueda = txbBuscador.Text;

                if (string.IsNullOrEmpty(valorBusqueda))
                {
                    MandarALlamarAlmacen();
                }
                else
                {
                    string consulta = "SELECT ID_Producto, Producto, Descripcion, Existencias, Unidad FROM elastosystem_almacen WHERE ID_Producto LIKE @VALORBUSQUEDA OR Producto LIKE @VALORBUSQUEDA OR Descripcion LIKE @VALORBUSQUEDA";
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, VariablesGlobales.ConexionBDElastotecnica);
                    adaptador.SelectCommand.Parameters.AddWithValue("@VALORBUSQUEDA", "%" + valorBusqueda + "%");
                    DataSet data = new DataSet();
                    adaptador.Fill(data, "Resultados");
                    dgvAlmacen.DataSource = data.Tables["Resultados"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL BUSCAR PRODUCTO: " + ex);
            }
        }

        private void txbAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            VariablesGlobales.ValidarSoloNoyPunto(e, txbAdd);
        }

        private void dgvAlmacen_Click(object sender, EventArgs e)
        {
            txbID.Clear();
            txbProducto.Clear();
            txbExistencias.Clear();
            txbAdd.Clear();
            txbNotas.Clear();

            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                txbID.Text = id;

                string producto = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                txbProducto.Text = producto;

                string existencias = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                txbExistencias.Text = existencias;

                txbAdd.Focus();

            }
        }
    }
}
