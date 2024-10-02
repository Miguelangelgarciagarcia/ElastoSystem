using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Crypto.Parameters;
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
    public partial class Maquinado_Historial : Form
    {
        public Maquinado_Historial()
        {
            InitializeComponent();
        }

        private void Maquinado_Historial_Load(object sender, EventArgs e)
        {
            MandarALlamarMaquinadosFinalizados();
        }

        private void MandarALlamarMaquinadosFinalizados()
        {
            try
            {
                string tabla = @"SELECT ID_MAQUINADO, FECHA, FECHA_TERMINO, SOLICITANTE, DESCRIPCION_MAQUINADO, USUARIO_FINALIZO 
                                FROM elastosystem_maquinado
                                WHERE ESTATUS = 'FINALIZADA'";
                MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionElastoSystem);
                DataTable dt = new DataTable();
                mySqlAdapter.Fill(dt);
                dgvHistorialMaquinado.DataSource = dt;
                dgvHistorialMaquinado.Columns["ID_MAQUINADO"].HeaderText = "FOLIO";
                dgvHistorialMaquinado.Columns["FECHA"].HeaderText = "FECHA SOLICITUD";
                dgvHistorialMaquinado.Columns["FECHA_TERMINO"].HeaderText = "SE FINALIZO";
                dgvHistorialMaquinado.Columns["DESCRIPCION_MAQUINADO"].HeaderText = "MAQUINADO";
                dgvHistorialMaquinado.Columns["USUARIO_FINALIZO"].HeaderText = "FINALIZO";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Buscador()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionElastoSystem);

            try
            {
                conn.Open();

                string valorBusqueda = txbBuscador.Text;
                string searchQuery = "SELECT ID_MAQUINADO, FECHA, FECHA_TERMINO, SOLICITANTE, DESCRIPCION_MAQUINADO, USUARIO_FINALIZO FROM elastosystem_maquinado WHERE (ID_MAQUINADO LIKE @ValorBusqueda OR SOLICITANTE LIKE @ValorBusqueda OR DESCRIPCION_MAQUINADO LIKE @ValorBusqueda OR USUARIO_FINALIZO LIKE @ValorBusqueda) AND ESTATUS = 'FINALIZADA' AND FECHA IS NOT NULL AND FECHA_TERMINO IS NOT NULL";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(searchQuery, VariablesGlobales.ConexionElastoSystem);
                adaptador.SelectCommand.Parameters.AddWithValue("@ValorBusqueda", "%" + valorBusqueda + "%");

                DataTable tableResultados = new DataTable();
                adaptador.Fill(tableResultados);

                dgvHistorialMaquinado.DataSource = tableResultados;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscador datos: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void txbBuscador_TextChanged(object sender, EventArgs e)
        {
            Buscador();
        }

        private void dgvHistorialMaquinado_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistorialMaquinado.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvHistorialMaquinado.SelectedRows[0];
                string primerDato = selectedRow.Cells[0].Value.ToString();
                txbFolio.Text = primerDato;

                MandarALlamarComprobante();
            }
        }

        byte[] comprobanteBytes;
        private void MandarALlamarComprobante()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionElastoSystem);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT COMPROBANTE, RUTA_COMPROBANTE FROM elastosystem_maquinado WHERE ID_MAQUINADO LIKE '" + txbFolio.Text + "' ";
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        try
                        {

                            comprobanteBytes = (byte[])reader["COMPROBANTE"];
                            txbNombreArchivo.Text = reader.GetString("RUTA_COMPROBANTE");
                            string rutacompleta = txbNombreArchivo.Text;
                            txbRuta.Text = rutacompleta;
                            string nombrearchivo = Path.GetFileName(rutacompleta);
                            txbNombreArchivo.Text = nombrearchivo;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al procesar el archivo" + ex.Message);
                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        private void DescargarComprobante()
        {
            string extensionArchivo = Path.GetExtension(txbRuta.Text);
            string nombreArchivo = txbNombreArchivo.Text;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = nombreArchivo,
                Filter = "Todos los archivos (*.*)|*.*",
                DefaultExt = extensionArchivo
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllBytes(saveFileDialog.FileName, comprobanteBytes);
                    MessageBox.Show("Archivo guardado correctamente");
                    string argument = "/select, \"" + saveFileDialog.FileName + "\"";
                    System.Diagnostics.Process.Start("explorer.exe", argument);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                }
            }
        }

        private void txbFolio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
        }

        private void btnDescargar_Click_1(object sender, EventArgs e)
        {
            DescargarComprobante();
        }
    }
}
