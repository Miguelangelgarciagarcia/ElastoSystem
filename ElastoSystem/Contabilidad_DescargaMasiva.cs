using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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
    public partial class Contabilidad_DescargaMasiva : Form
    {
        private string rutaCer = "";
        private string rutaKey = "";
        private string contraseniaKey = "";
        private X509Certificate2 certificado = null;
        private RSA llavePrivada = null;

        public Contabilidad_DescargaMasiva()
        {
            InitializeComponent();
        }

        private void Contabilidad_DescargaMasiva_Load(object sender, EventArgs e)
        {

        }

        private void btnCargarCertificado_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Certificado (.cer)|*.cer";
            openFileDialog.Title = "Seleccionar archivo .cer";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaCer = openFileDialog.FileName;

                try
                {
                    certificado = new X509Certificate2(rutaCer);
                    lblCertificado.Text = "Certificado cargado";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el certificado: " + ex.Message);
                    lblCertificado.Text = "No se eligió archivo";

                }
            }
        }

        private void btnCargarKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Llave privada (.key)|*.key";
            openFileDialog.Title = "Seleccionar archivo .key";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaKey = openFileDialog.FileName;
                lblClavePrivada.Text = "Llave privada cargada";
            }
            else
            {
                MessageBox.Show("No se seleccionó ningún archivo .key");
                lblClavePrivada.Text = "No se eligió archivo";
            }
        }

        private void btnValidarFiel_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(rutaCer) || string.IsNullOrWhiteSpace(rutaKey))
            {
                MessageBox.Show("Primero debes cargar el archivo .cer y el archivo .key.");
                return;
            }

            contraseniaKey = txbContrCertificado.Text.Trim();

            if (string.IsNullOrWhiteSpace(contraseniaKey))
            {
                MessageBox.Show("Ingresa la contraseña del certificado");
                return;
            }

            try
            {
                byte[] keyBytes = File.ReadAllBytes(rutaKey);
                llavePrivada = RSA.Create();

                llavePrivada.ImportEncryptedPkcs8PrivateKey(
                    Encoding.UTF8.GetBytes(contraseniaKey),
                    keyBytes,
                    out _
                );

                MessageBox.Show("La FIEL es válida");
            }
            catch (CryptographicException)
            {
                MessageBox.Show("Contraseña incorrecta o la llave no corresponde al certificado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar la FIEL: " + ex.Message);
            }
        }
    }
}
