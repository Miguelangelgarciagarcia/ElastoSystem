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
    public partial class Compras_EliminarPartidaDeOC : Form
    {
        public string Eliminar { get; private set; }

        public Compras_EliminarPartidaDeOC()
        {
            InitializeComponent();
        }

        private void Compras_EliminarPartidaDeOC_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.Visible = false;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar = "Eliminar";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
