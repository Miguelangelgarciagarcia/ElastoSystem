using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElastoSystem
{
    public partial class Produccion_ProdEspecial : Form
    {
        public string Resultado { get; private set; }

        public string Cliente
        {
            get => txbCliente.Text;
            set => txbCliente.Text = value;
        }

        public string OC
        {
            get => txbOC.Text;
            set => txbOC.Text = value;
        }

        public string Especificacion
        {
            get => txbEspecificacion.Text;
            set => txbEspecificacion.Text = value;
        }

        public Produccion_ProdEspecial()
        {
            InitializeComponent();
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
        //CODIGO PARA MOVER PANEL SUPERIOR
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txbCliente.Text) ||
                string.IsNullOrWhiteSpace(txbOC.Text) ||
                string.IsNullOrWhiteSpace(txbEspecificacion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Resultado = $"{txbCliente.Text}-{txbOC.Text}-{txbEspecificacion.Text}";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
