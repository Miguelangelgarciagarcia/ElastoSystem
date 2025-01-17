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
    public partial class Mantenimiento_Historico : Form
    {
        public Mantenimiento_Historico()
        {
            InitializeComponent();
        }

        private void Mantenimiento_Historico_Load(object sender, EventArgs e)
        {
            CargarID();
        }

        string idusuario;
        private void CargarID()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            try
            {
                string query = "SELECT ID FROM elastosystem_login WHERE Usuario = @USUARIO";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@USUARIO", VariablesGlobales.Usuario);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    idusuario = reader["ID"].ToString();
                }

                RevisarUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL LLAMAR ID DE USUARIO: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void RevisarUsuario()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            try
            {
                string query = "SELECT Mantenimiento_VG FROM elastosystem_permisos_menu WHERE ID = @ID";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@ID", idusuario);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string comprasVGValue = reader["Mantenimiento_VG"].ToString();
                    if (comprasVGValue == "True")
                    {
                        CargarHistoricoFULL();
                    }
                    else
                    {
                        CargarHistorico();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL LLAMAR PENDIENTES: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void CargarHistorico()
        {
            string query = @"
                SELECT * 
                FROM elastosystem_mtto_req
                WHERE Solicitante = @SOLICITANTE
                ORDER BY Fecha DESC,
                CASE Estatus
                    WHEN 'ACTIVA' THEN 1
                    WHEN 'FINALIZADA' THEN 2
                    ELSE 3
                END ASC";
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SOLICITANTE", VariablesGlobales.Usuario);

                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);
                            dgvMantenimiento.DataSource = dt;
                            dgvMantenimiento.Columns["Folio"].Visible = false;
                            dgvMantenimiento.Columns["Solicitante"].Visible = false;
                            dgvMantenimiento.Columns["Tipo_Falla"].Visible = false;
                            dgvMantenimiento.Columns["Mantenimiento"].Visible = false;
                            dgvMantenimiento.Columns["Ubicacion"].Visible = false;
                            dgvMantenimiento.Columns["Recomendaciones_Sugerencias"].Visible = false;
                            dgvMantenimiento.Columns["Refacciones"].Visible = false;
                            dgvMantenimiento.Columns["Ruta_Comprobante"].Visible = false;
                            dgvMantenimiento.Columns["Comprobante"].Visible = false;
                            dgvMantenimiento.Columns["Folio_ALT"].HeaderText = "Folio";
                            dgvMantenimiento.Columns["Fecha_Termino"].HeaderText = "Fecha Fin";
                            dgvMantenimiento.Columns["Usuario_Finalizo"].HeaderText = "Finalizo";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR EL HISTORICO DE MANTENIMIENTO: " + ex.Message);
                }
            }
        }

        private void CargarHistoricoFULL()
        {
            string query = @"
                SELECT * 
                FROM elastosystem_mtto_req
                ORDER BY Fecha DESC,
                CASE Estatus
                    WHEN 'ACTIVA' THEN 1
                    WHEN 'FINALIZADA' THEN 2
                    ELSE 3
                END ASC";
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {

                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);
                            dgvMantenimiento.DataSource = dt;
                            dgvMantenimiento.Columns["Folio"].Visible = false;
                            dgvMantenimiento.Columns["Tipo_Falla"].Visible = false;
                            dgvMantenimiento.Columns["Mantenimiento"].Visible = false;
                            dgvMantenimiento.Columns["Ubicacion"].Visible = false;
                            dgvMantenimiento.Columns["Recomendaciones_Sugerencias"].Visible = false;
                            dgvMantenimiento.Columns["Refacciones"].Visible = false;
                            dgvMantenimiento.Columns["Ruta_Comprobante"].Visible = false;
                            dgvMantenimiento.Columns["Comprobante"].Visible = false;
                            dgvMantenimiento.Columns["Folio_ALT"].HeaderText = "Folio";
                            dgvMantenimiento.Columns["Fecha_Termino"].HeaderText = "Fecha Fin";
                            dgvMantenimiento.Columns["Usuario_Finalizo"].HeaderText = "Finalizo";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR EL HISTORICO DE MANTENIMIENTO: " + ex.Message);
                }
            }
        }

        private void btnCargarDoc_Click(object sender, EventArgs e)
        {
            DescargarComprobante();
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

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllBytes(saveFileDialog.FileName, comprobanteBytes);
                    MessageBox.Show("Archivo guardado correctamente");
                    string argument = "/select, \"" + saveFileDialog.FileName + "\"";
                    System.Diagnostics.Process.Start("explorer.exe", argument);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR AL GUARDAR EL ARCHIVO: "+ex.Message);
                }
            }
        }

        private void dgvMantenimiento_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvMantenimiento.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvMantenimiento.SelectedRows[0];
                string primerDato = selectedRow.Cells[0].Value.ToString();
                txbFolio.Text = primerDato;

                MandarALlamarComprobante();
            }
        }

        byte[] comprobanteBytes;
        private void MandarALlamarComprobante()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Comprobante, Ruta_Comprobante FROM elastosystem_mtto_req WHERE Folio LIKE '" + txbFolio.Text + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            comprobanteBytes = (byte[])reader["Comprobante"];
                            txbNombreArchivo.Text = reader.GetString("Ruta_Comprobante");
                            string rutacompleta = txbNombreArchivo.Text;
                            txbRuta.Text = rutacompleta;
                            string nombrearchivo = Path.GetFileName(rutacompleta);
                            txbNombreArchivo.Text = nombrearchivo;

                            if(string.IsNullOrEmpty(txbNombreArchivo.Text) && string.IsNullOrEmpty(txbRuta.Text))
                            {
                                btnDescargar.Visible = false;
                            }
                            else
                            {
                                btnDescargar.Visible = true;
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("ERROR AL PROCESAR EL ARCHIVO: " + ex.Message);
                        }
                    }
                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR: "+ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
