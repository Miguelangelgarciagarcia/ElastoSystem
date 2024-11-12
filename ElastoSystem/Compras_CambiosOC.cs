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
    public partial class Compras_CambiosOC : Form
    {
        public string OCSave { get; private set; }


        public Compras_CambiosOC()
        {
            InitializeComponent();
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            txbRespuesta.Text = "CERRADO";
            OCSave = txbRespuesta.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            txbRespuesta.Text = "Sobreescribir";
            OCSave = txbRespuesta.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNuevaOC_Click(object sender, EventArgs e)
        {
            txbRespuesta.Text = "NuevaOC";
            OCSave = txbRespuesta.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
