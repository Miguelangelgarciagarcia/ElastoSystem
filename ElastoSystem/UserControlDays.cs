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
    public partial class UserControlDays : UserControl
    {
        public static string static_day;
        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        public void days(int numday)
        {
            lblDays.Text = numday + "";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {

        }

        private void displayEvent()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            string sql = "SELECT * FROM elastosystem_mtto_preventivohistorial WHERE Estatus = 'ACTIVO' AND Inicio = ?";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("Inicio", Mtto_ManttoPreventivo.static_year + "-" + Mtto_ManttoPreventivo.static_month + "-" + lblDays.Text);
            MySqlDataReader reader = cmd.ExecuteReader();

            List<string> eventos = new List<string>();
            while (reader.Read())
            {
                eventos.Add(reader["Activo"].ToString());
            }

            if (eventos.Count > 2)
            {
                lblEvents.Text = string.Join("\n", eventos.Take(2)) + "\n...";
            }
            else
            {
                lblEvents.Text = string.Join("\n", eventos);
            }

            reader.DisposeAsync();
            cmd.Dispose();
            conn.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            displayEvent();
        }

        private void lblEvents_Click(object sender, EventArgs e)
        {

        }

        private void lblEvents_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsCerrarMtto.Show(lblEvents, e.Location);
            }
            else
            {
                static_day = lblDays.Text;

                Mtto_ActividadesDia mtto_ActividadesDia = new Mtto_ActividadesDia();
                mtto_ActividadesDia.ShowDialog();
            }
        }

        private void UserControlDays_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsCerrarMtto.Show(lblEvents, e.Location);
            }
            else
            {
                static_day = lblDays.Text;

                Mtto_ActividadesDia mtto_ActividadesDia = new Mtto_ActividadesDia();
                mtto_ActividadesDia.ShowDialog();
            }
        }

        private void MttoPreventivo_Click(object sender, EventArgs e)
        {
            Mtto_AdelantarPreventivo mtto_Adelantar = new Mtto_AdelantarPreventivo();
            mtto_Adelantar.ShowDialog();
        }
    }
}
