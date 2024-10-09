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
    public partial class Ventas_Cotizacion_TiempoEntrega : Form
    {
        public string Entrega {  get; private set; }

        public Ventas_Cotizacion_TiempoEntrega()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Entrega = txbTiempoEntrega.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
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
    }
}
