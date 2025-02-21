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
    public partial class Compras_VincularPartidas : Form
    {
        public Compras_VincularPartidas(string idProducto)
        {
            InitializeComponent();
            lblIDProducto.Text = idProducto;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Compras_VincularPartidas_Load(object sender, EventArgs e)
        {
            CargarRequisiciones();
        }

        private void CargarRequisiciones()
        {
            try
            {
                string tabla = "SELECT ID, ID_ALT, Usuario, Fecha FROM elastosystem_compras_requisicion WHERE Estatus = 'ABIERTA'";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dt.Columns["ID_ALT"].ColumnName = "Folio";
                dt.Columns["Usuario"].ColumnName = "Solicitante";
                dgvRequisicions.DataSource = dt;
                dgvRequisicions.Columns["ID"].Visible = false;
                dt.DefaultView.Sort = "Folio DESC";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvRequisicions_Click(object sender, EventArgs e)
        {
            dgvPartidas.DataSource = null;
            dgvPartidas.Rows.Clear();
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                txbFolio.Text = id;

                string req = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                txbReqFolio.Text = req;

                string solicito = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                lblSolicito.Text = solicito;

            }
            MandarALlamarPartidas();
        }

        private void MandarALlamarPartidas()
        {
            try
            {
                string query = "SELECT ID_Producto, Descripcion " +
                                "FROM elastosystem_compras_requisicion_desglosada " +
                                "WHERE ID = @FOLIO AND Estatus = 'ABIERTA' AND ID_Producto <> @IDPRODUCTO";

                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FOLIO", txbFolio.Text.Trim());
                        cmd.Parameters.AddWithValue("@IDPRODUCTO", lblIDProducto.Text.Trim());

                        MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        mySqlAdapter.Fill(dt);

                        dgvPartidas.DataSource = dt;
                        dgvPartidas.Columns["ID_Producto"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL OBTENER PARTIDAS: " + ex.Message);
            }
        }
        private void dgvPartidas_Click(object sender, EventArgs e)
        {

        }
        private List<int> listaProductos = new List<int>();
        private void dgvPartidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvPartidas.Rows[e.RowIndex];

                if (int.TryParse(filaSeleccionada.Cells["ID_Producto"].Value.ToString(), out int idProducto))
                {
                    string descripcion = filaSeleccionada.Cells["Descripcion"].Value.ToString();

                    if (!listaProductos.Contains(idProducto))
                    {
                        listaProductos.Add(idProducto);
                        dgvLista.Rows.Add(idProducto, descripcion);
                    }
                    else
                    {
                        MessageBox.Show("El producto ya ha sido agregado");
                    }
                }
                else
                {
                    MessageBox.Show("Error al convertir ID_Producto a numero");
                }
            }
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvLista.Rows[e.RowIndex];

                if (int.TryParse(filaSeleccionada.Cells["ID_Producto"].Value.ToString(), out int idProducto))
                {
                    if (listaProductos.Contains(idProducto))
                    {
                        listaProductos.Remove(idProducto);
                    }

                    dgvLista.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    MessageBox.Show("Error al obtener el ID del producto");
                }
            }
        }

        private void btnAgregarPartidas_Click(object sender, EventArgs e)
        {
            if(listaProductos.Count > 0)
            {
                Compras_Administrar_Requisiciones compras_Form = Application.OpenForms["Compras_Administrar_Requisiciones"] as Compras_Administrar_Requisiciones;
                if(compras_Form != null)
                {
                    compras_Form.RecibirListaProductos(listaProductos);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No hay productos en la lista para agregar");
            }
        }
    }
}
