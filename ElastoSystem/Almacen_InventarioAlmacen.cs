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
    public partial class Almacen_InventarioAlmacen : Form
    {
        public Almacen_InventarioAlmacen()
        {
            InitializeComponent();
        }

        private void Almacen_InventarioAlmacen_Load(object sender, EventArgs e)
        {
            MandarALlamarProductos();
        }

        private void MandarALlamarProductos()
        {
            try
            {
                string update = @"
                    UPDATE elastosystem_sae_productos
                    SET Estatus = CASE
                        WHEN `1M` IS NULL OR `1M` = 0 THEN '----------'
                        WHEN Existencia < `TM` THEN 'Critico'
                        WHEN Existencia >= `TM` AND Existencia < `1M` THEN 'Resurtir'
                        WHEN Existencia >= `1M` AND Existencia < `3M` THEN 'Programar'
                        WHEN Existencia >= `3M` AND Existencia < `4M` THEN 'Suficiente'
                        WHEN Existencia > `4M` THEN 'Sobre Inventario'
                        ELSE ''
                    END,
                    Meses = CASE
                        WHEN `1M` IS NOT NULL AND `1M` > 0 THEN ROUND(Existencia / `1M`, 2)
                        ELSE 0
                    END";

                MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                MySqlCommand cmd = new MySqlCommand(update, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                string query = @"
                    SELECT *
                    FROM elastosystem_sae_productos
                    WHERE Producto NOT LIKE '0%' AND Producto NOT LIKE ' %'
                    ORDER BY
                        CASE
                            WHEN Estatus = 'Critico' THEN 1
                            WHEN Estatus = 'Resurtir' THEN 2
                            WHEN Estatus = 'Programar' THEN 3
                            WHEN Estatus = 'Suficiente' THEN 4
                            WHEN Estatus = 'Sobre Inventario' THEN 5
                            ELSE 6
                        END, Meses ASC";
                MySqlDataAdapter adapatador = new MySqlDataAdapter(query, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                adapatador.Fill(dt);
                dgvProductosSAE.DataSource = dt;

                dgvProductosSAE.Columns["ID"].Visible = false;
                dgvProductosSAE.Columns["TM"].Visible = false;
                dgvProductosSAE.Columns["4M"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL LLAMAR PRODUCTOS: " + ex.Message);
            }
        }

        private void dgvProductosSAE_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProductosSAE.Columns[e.ColumnIndex].Name == "Estatus")
            {
                string estatus = e.Value?.ToString();
                if (!string.IsNullOrEmpty(estatus))
                {
                    DataGridViewRow row = dgvProductosSAE.Rows[e.RowIndex];
                    switch (estatus)
                    {
                        case "Critico":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(226, 6, 19);
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                        case "Resurtir":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(189, 22, 34);
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                        case "Programar":
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        case "Suficiente":
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                        case "Sobre Inventario":
                            row.DefaultCellStyle.BackColor = Color.Blue;
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;
                        default:
                            row.DefaultCellStyle.BackColor = Color.White;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            break;
                    }
                }
            }
        }
        private void dgvProductosSAE_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProductosSAE.ClearSelection();
        }
    }
}
