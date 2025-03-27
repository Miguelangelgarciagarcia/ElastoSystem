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
    public partial class Almacen_SobreInventario2 : Form
    {
        public Almacen_SobreInventario2()
        {
            InitializeComponent();
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.Visible = false;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {

        }


        private void pbCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pbCerrar_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
