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
    public partial class Almacen_Fabricacion : Form
    {
        public Almacen_Fabricacion()
        {
            InitializeComponent();
        }

        private void Almacen_Fabricacion_Load(object sender, EventArgs e)
        {

        }

        private void MandarALlamarProductos()
        {
            try
            {
                string update = @"
                    UPDATE elastosystem_sae_productos
                    SET Estatus = CASE
                        WHEN `1M` IS NULL OR `1M` = 0 THEN '--------------'
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

                MySqlDataAdapter adaptadopr = new MySqlDataAdapter(query, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                adaptadopr.Fill(dt);
                dgvProductosSAE.DataSource = dt;

                dgvProductosSAE.Columns["ID"].Visible = false;
                dgvProductosSAE.Columns["TM"].Visible = false;
                dgvProductosSAE.Columns["CantidadMaxOC"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR al llamar productos de Aspel SAE" + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            pnlAlmacen.Visible = false;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            pnlAlmacen.Visible = true;
            MandarALlamarProductos();
        }
    }
}
