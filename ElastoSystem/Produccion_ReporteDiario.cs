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
    public partial class Produccion_ReporteDiario : Form
    {
        public Produccion_ReporteDiario()
        {
            InitializeComponent();
        }

        private void Produccion_ReporteDiario_Load(object sender, EventArgs e)
        {
            CargarN1();
        }

        private void CargarN1()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = @"
                            SELECT 
                                op.Clave AS Producto,
                                ot.* 
                            FROM elastosystem_produccion_ot ot
                            INNER JOIN elastosystem_produccion_orden_produccion op
                                ON ot.SF = op.SolicitudFabricacion
                            WHERE ot.Estatus = 'ABIERTA' 
                                AND ot.Nave = 'NAVE 1'";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            dt.Columns.Add("Produccion", typeof(int));
                            foreach (DataRow row in dt.Rows)
                            {
                                row["Produccion"] = 0;
                            }

                            dt.Columns.Add("Operador", typeof(string));
                            dt.Columns.Add("PNCOP", typeof(int));
                            dt.Columns.Add("PROOP", typeof(int));
                            dt.Columns.Add("REPROCESO", typeof(int));
                            dt.Columns.Add("ObservacionesP", typeof(string));

                            dgvNave1.DataSource = dt;

                            dgvNave1.Columns["Producto"].DisplayIndex = 0;
                            dgvNave1.Columns["Producto"].HeaderText = "Producto";
                            dgvNave1.Columns["Produccion"].Width = 120;

                            dgvNave1.Columns["NombreArea"].DisplayIndex = 1;
                            dgvNave1.Columns["NombreArea"].HeaderText = "Actividad";

                            dgvNave1.Columns["ID"].Visible = false;
                            dgvNave1.Columns["FechaInicio"].Visible = false;
                            dgvNave1.Columns["FechaTermino"].Visible = false;
                            dgvNave1.Columns["Autorizo"].Visible = false;
                            dgvNave1.Columns["Lote"].Visible = false;
                            dgvNave1.Columns["Molde"].Visible = false;
                            dgvNave1.Columns["Cantidad"].Visible = false;
                            dgvNave1.Columns["Especificacion"].Visible = false;
                            dgvNave1.Columns["Area"].Visible = false;
                            dgvNave1.Columns["SF"].Visible = false;
                            dgvNave1.Columns["Observaciones"].Visible = false;
                            dgvNave1.Columns["Nave"].Visible = false;
                            dgvNave1.Columns["Estatus"].Visible = false;

                            dgvNave1.Columns["Operador"].Visible = false;
                            dgvNave1.Columns["PNCOP"].Visible = false;
                            dgvNave1.Columns["PROOP"].Visible = false;
                            dgvNave1.Columns["REPROCESO"].Visible = false;
                            dgvNave1.Columns["ObservacionesP"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR ORDENES DE TRABAJO ACTIVAS DE NAVE 1: " + ex.Message);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvNave1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LimpiarN1()
        {
            txbProducto.Clear();
            txbActividad.Clear();
            cbTurno.SelectedIndex = -1;
            cbOperador.SelectedIndex = -1;
            txbMaquina.Clear();
            txbHorasTrabajadas.Clear();
            txbProductoOP.Clear();
            txbPNCOperacion.Clear();
            txbReproceso.Clear();
            txbPCTotal.Clear();
            txbObservaciones.Clear();
        }

        private void dgvNave1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LimpiarN1();

            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string producto = dgv.Rows[rowIndex].Cells["Producto"].Value.ToString();
                txbProducto.Text = producto;

                string actividad = dgv.Rows[rowIndex].Cells["NombreArea"].Value.ToString();
                txbActividad.Text = actividad;

                string turno = dgv.Rows[rowIndex].Cells["Turno"].Value.ToString();
                cbTurno.Text = turno;

                string maquina = dgv.Rows[rowIndex].Cells["Maquina"].Value.ToString();
                txbMaquina.Text = maquina;
            }
        }
    }
}
