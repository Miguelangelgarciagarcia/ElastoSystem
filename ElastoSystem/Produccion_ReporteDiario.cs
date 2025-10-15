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
                            SELECT * FROM elastosystem_produccion_ot
                            WHERE Estatus = 'ABIERTA' AND Nave = 'NAVE 1'";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);

                            dt.Columns.Add("Produccion", typeof(int));
                            foreach(DataRow row in dt.Rows)
                            {
                                row["Produccion"] = 0;
                            }

                            dt.Columns.Add("Operador", typeof(string));
                            dt.Columns.Add("PNCOP", typeof(int));
                            dt.Columns.Add("PROOP", typeof(int));
                            dt.Columns.Add("PNCRE", typeof(int));
                            dt.Columns.Add("REPROCESO", typeof(int));
                            dt.Columns.Add("ObservacionesP", typeof(string));

                            dgvNave1.DataSource = dt;

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
                            dgvNave1.Columns["PNCRE"].Visible = false;
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
    }
}
