using MySql.Data.MySqlClient;
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
    public partial class Produccion_PT : Form
    {
        private string _folioOP;
        public Produccion_PT(string folioOP)
        {
            InitializeComponent();
            _folioOP = folioOP?.Trim();

            lblOP.Text = _folioOP;

            lblFecha.Text = DateTime.Today.ToLongDateString();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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

        private void txbCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            VariablesGlobales.ValidarNumeroEntero(e, txbCantidad);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cbTurno.SelectedIndex == -1 || txbLote.Text == "" || txbCantidad.Text == "")
            {
                MessageBox.Show("Debes de llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                RegistrarPT();
            }
        }

        private void RegistrarPT()
        {
            string op = lblOP.Text?.Trim();
            string turno = cbTurno.SelectedItem?.ToString()?.Trim();
            string lote = txbLote.Text?.Trim();
            string cantidadStr = txbCantidad.Text?.Trim();
            string usuario = VariablesGlobales.Usuario?.Trim();

            if (!int.TryParse(cantidadStr, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero positivo.", "Error en cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string insertQuery = @"
                        INSERT INTO elastosystem_produccion_pt
                        (OP, Fecha, Turno, Cantidad, Lote, Entrego)
                        VALUES
                        (@OP, @FECHA, @TURNO, @CANTIDAD, @LOTE, @ENTREGO)";

                    using (MySqlCommand cmdInsert = new MySqlCommand(insertQuery, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@OP", op);
                        cmdInsert.Parameters.AddWithValue("@FECHA", DateTime.Today);
                        cmdInsert.Parameters.AddWithValue("@TURNO", turno);
                        cmdInsert.Parameters.AddWithValue("@CANTIDAD", cantidad);
                        cmdInsert.Parameters.AddWithValue("@LOTE", lote);
                        cmdInsert.Parameters.AddWithValue("@ENTREGO", usuario);

                        int filas = cmdInsert.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            MessageBox.Show("Producto Terminado registrado correctamente.\n\n" +
                                            $"OP: {op}\n" +
                                            $"Fecha: {DateTime.Today:dd/MM/yyyy}\n" +
                                            $"Turno: {turno}\n" +
                                            $"Cantidad:{cantidad}\n" +
                                            $"Lote: {lote}\n" +
                                            $"Entregó: {usuario}",
                                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            cbTurno.SelectedIndex = -1;
                            txbCantidad.Clear();
                            txbLote.Clear();

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar el PT. Intenta de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar Producto Terminado:\n" + ex.Message, "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
