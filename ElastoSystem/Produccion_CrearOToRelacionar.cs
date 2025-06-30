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
    public partial class Produccion_CrearOToRelacionar : Form
    {
        private int resultado = -1;
        public Produccion_CrearOToRelacionar()
        {
            InitializeComponent();
        }

        private void Produccion_CrearOToRelacionar_Load(object sender, EventArgs e)
        {

        }

        private void btnRelacionar_Click(object sender, EventArgs e)
        {
            resultado = 0;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCrearOT_Click(object sender, EventArgs e)
        {
            resultado = 1;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public int ShowDialogResult()
        {
            this.ShowDialog();
            return resultado;
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
            resultado = -1;
            this.Close();
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
