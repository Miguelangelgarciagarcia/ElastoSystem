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
    public partial class Compras_RequisicionesEnviadas : Form
    {
        public Compras_RequisicionesEnviadas()
        {
            InitializeComponent();
        }
        private void CargarRequisicionesPendientes()
        {
            try
            {
                string tabla = $"SELECT ID, ID_ALT, Usuario, Fecha, Estatus FROM elastosystem_compras_requisicion WHERE Usuario = '{VariablesGlobales.Usuario}'";
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
        private void MandarALlamarPartidas()
        {
            try
            {
                string tabla = "SELECT * FROM elastosystem_compras_requisicion_desglosada WHERE ID = '" + lblFolio.Text + "'";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dt.Columns["TipoUso"].ColumnName = "Tipo Uso";
                dgvPartidas.DataSource = dt;
                dgvPartidas.Columns["ID"].Visible = false;
                dgvPartidas.Columns["Tipo Uso"].Visible = false;
                dgvPartidas.Columns["Comentarios"].Visible = false;
                dgvPartidas.Columns["ID_Producto"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Compras_RequisicionesEnviadas_Load(object sender, EventArgs e)
        {
            CargarRequisicionesPendientes();
        }

        private void dgvRequisicions_DoubleClick(object sender, EventArgs e)
        {
            txbTipoUso.Clear();
            txbNotas.Clear();
            lblFolio.Text = "";
            lblFolioREQ.Text = "";


            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblFolio.Text = id;

                string folio = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                lblFolioREQ.Text = folio;
                lblFolioREQ.Visible = true;
            }
            MandarALlamarPartidas();
        }

        private void dgvPartidas_Click(object sender, EventArgs e)
        {

        }

        private void dgvRequisicions_Click(object sender, EventArgs e)
        {
        }

        private void dgvRequisicions_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void cbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvPartidas_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string tipouso = dgv.Rows[rowIndex].Cells[7].Value.ToString();
                txbTipoUso.Text = tipouso;

                string comentarios = dgv.Rows[rowIndex].Cells[8].Value.ToString();
                txbNotas.Text = comentarios;
            }
        }

        private void Buscador()
        {
            try
            {

                string valorBusqueda = txbBuscador.Text.Trim();
                string consulta;

                if (string.IsNullOrEmpty(valorBusqueda))
                {
                    consulta = $"SELECT ID, ID_ALT, Usuario, Fecha, Estatus FROM elastosystem_compras_requisicion WHERE Usuario = '{VariablesGlobales.Usuario}'";
                }
                else
                {
                    consulta = $"SELECT ID, ID_ALT, Usuario, Fecha, Estatus FROM elastosystem_compras_requisicion WHERE (ID LIKE @ValorBusqueda OR ID_ALT LIKE @ValorBusqueda) AND Usuario = '{VariablesGlobales.Usuario}'";
                }

                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, VariablesGlobales.ConexionBDElastotecnica);

                if (!string.IsNullOrEmpty(valorBusqueda))
                {
                    adaptador.SelectCommand.Parameters.AddWithValue("@ValorBusqueda", "%" + valorBusqueda + "%");
                }

                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                dt.Columns["ID_ALT"].ColumnName = "Folio";
                dt.Columns["Usuario"].ColumnName = "Solicitante";

                dgvRequisicions.DataSource = dt;

                dgvRequisicions.Columns["ID"].Visible = false;

                dt.DefaultView.Sort = "Folio DESC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar datos: " + ex.Message);
            }
        }

        private void txbBuscador_TextChanged(object sender, EventArgs e)
        {
            Buscador();
        }
    }
}
