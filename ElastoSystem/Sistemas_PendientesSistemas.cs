using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
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
    public partial class Sistemas_PendientesSistemas : Form
    {
        string validacion = "0";
        public Sistemas_PendientesSistemas()
        {
            InitializeComponent();
        }

        private void Sistemas_PendientesSistemas_Load(object sender, EventArgs e)
        {
            MandarALlamarPendientes();
            MandarALlamarEnProceso();
            MandarALlamarTicketsFinalizados();
        }

        private void MandarALlamarPendientes()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = @"
                            SELECT Folio, Folio_ALT, TipoReq, FechaInicio, HoraInicio, Descripcion, Solicitante, Prioridad
                            FROM elastosystem_sistemas_req
                            WHERE Estatus = 'ABIERTO'
                            ORDER BY
                                CASE
                                    WHEN Prioridad = 'Alta' THEN 1
                                    WHEN Prioridad = 'Media' THEN 2
                                    WHEN Prioridad = 'Baja' THEN 3
                                    ELSE 4
                                END,
                                FechaInicio ASC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);
                            dgvPendientes.DataSource = dt;
                            dgvPendientes.Columns["Folio"].Visible = false;
                            dgvPendientes.Columns["Folio_ALT"].HeaderText = "Folio";
                            dgvPendientes.Columns["TipoReq"].HeaderText = "Requerimiento";
                            dgvPendientes.Columns["FechaInicio"].HeaderText = "Fecha";
                            dgvPendientes.Columns["HoraInicio"].HeaderText = "Hora";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL LLAMAR PENDIENTES DE SISTEMAS: " + ex.Message);
            }
        }

        private void MandarALlamarEnProceso()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = @"
                            SELECT Folio, Folio_ALT, TipoReq, Descripcion, Solicitante, Prioridad
                            FROM elastosystem_sistemas_req
                            WHERE Estatus = 'EN PROCESO' AND Asignado_a = @Usuario
                            ORDER BY
                                CASE
                                    WHEN Prioridad = 'Alta' THEN 1
                                    WHEN Prioridad = 'Media' THEN 2
                                    WHEN Prioridad = 'Baja' THEN 3
                                    ELSE 4
                                END,
                                FechaInicio ASC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", VariablesGlobales.Usuario);

                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);
                            dgvEnProceso.DataSource = dt;
                            dgvEnProceso.Columns["Folio"].Visible = false;
                            dgvEnProceso.Columns["Folio_ALT"].HeaderText = "Folio";
                            dgvEnProceso.Columns["TipoReq"].HeaderText = "Requerimiento";
                            dgvEnProceso.Columns["Solicitante"].Visible = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL LLAMAR TICKETS EN PROCESO: " + ex.Message);
            }
        }

        private void MandarALlamarTicketsFinalizados()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = @"
                            SELECT Folio, Folio_ALT, TipoReq, FechaInicio, HoraInicio, FechaTermino, HoraTermino, Descripcion, Solicitante, Prioridad, Asignado_a
                            FROM elastosystem_sistemas_req
                            WHERE Estatus = 'FINALIZADO'
                            ORDER BY FechaInicio DESC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adaptador.Fill(dt);
                            dgvFinalizado.DataSource = dt;
                            dgvFinalizado.Columns["Folio"].Visible = false;
                            dgvFinalizado.Columns["Folio_ALT"].HeaderText = "Folio";
                            dgvFinalizado.Columns["TipoReq"].HeaderText = "Requerimiento";
                            dgvFinalizado.Columns["FechaInicio"].HeaderText = "Fecha Inicio";
                            dgvFinalizado.Columns["HoraInicio"].HeaderText = "Hora Inicio";
                            dgvFinalizado.Columns["FechaTermino"].HeaderText = "Fecha Fin";
                            dgvFinalizado.Columns["HoraTermino"].HeaderText = "Hora Fin";
                            dgvFinalizado.Columns["Asignado_a"].HeaderText = "Finalizado Por";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL LLAMAR TICKETS FINALIZADOS: " + ex.Message);
            }
        }

        private void dgvPendientes_Click(object sender, EventArgs e)
        {
            prioycategoria = 0;
            lblFolio.Text = string.Empty;
            lblFolioOriginal.Text = string.Empty;
            lblSolicitante.Text = string.Empty;
            cbNivelPrio.SelectedIndex = -1;
            cbTipoReq.SelectedIndex = -1;
            txbDescripcion.Text = string.Empty;
            pbImagen.Image = null;
            txbNombreArchivo.Text = string.Empty;
            txbRuta.Text = string.Empty;
            cbTipoReq.Items.Clear();
            cbTipoReq.Items.Add("Consulta General");
            cbTipoReq.Items.Add("Fallo en Equipo de Computo");
            cbTipoReq.Items.Add("Mantenimiento Preventivo");
            cbTipoReq.Items.Add("Problemas de Impresoras/Periféricos");
            cbTipoReq.Items.Add("Problema de Seguridad");
            cbTipoReq.Items.Add("Problemas de Red");
            cbTipoReq.Items.Add("Requerimientos de Hardware");
            cbTipoReq.Items.Add("Requerimientos de Software");
            cbTipoReq.Items.Add("Respaldo de Datos");
            cbTipoReq.Items.Add("Sin Acceso al Sistema");
            cbTipoReq.Items.Add("Solicitud de Capacitación");
            cbTipoReq.Items.Add("Solicitud de Cambio o Mejora");

            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string folio = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblFolioOriginal.Text = folio;

                string folioAlt = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                lblFolio.Text = folioAlt;

                string tipoReq = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                cbTipoReq.Text = tipoReq;

                string descripcion = dgv.Rows[rowIndex].Cells[5].Value.ToString();
                txbDescripcion.Text = descripcion;

                string solicitante = dgv.Rows[rowIndex].Cells[6].Value.ToString();
                lblSolicitante.Text = solicitante;

                string prioridad = dgv.Rows[rowIndex].Cells[7].Value.ToString();
                cbNivelPrio.Text = prioridad;

                btnActualizarTicket.Visible = true;
                btnTomarTicket.Visible = true;

                MandarALlamarRecurso();

                prioycategoria = 1;
            }
        }
        byte[] archivoBytes;
        private void MandarALlamarRecurso()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Recursos, Ruta_Recursos FROM elastosystem_sistemas_req WHERE Folio LIKE '" + lblFolioOriginal.Text + "' ";
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
                            if (!reader.IsDBNull(reader.GetOrdinal("Recursos")))
                            {
                                archivoBytes = (byte[])reader["Recursos"];

                                if (archivoBytes != null && archivoBytes.Length > 0)
                                {
                                    if (EsImagen(archivoBytes))
                                    {
                                        using (MemoryStream ms = new MemoryStream(archivoBytes))
                                        {
                                            pbImagen.Image = Image.FromStream(ms);
                                        }
                                    }
                                    else
                                    {
                                        pbImagen.Image = null;
                                    }
                                    validacion = "1";
                                }
                                else
                                {
                                    pbImagen.Image = null;
                                    validacion = "0";
                                }
                            }
                            else
                            {
                                archivoBytes = null;
                                pbImagen.Image = null;
                                validacion = "0";
                            }

                        }
                        catch (Exception ex)
                        {
                            pbImagen.Image = null;
                            validacion = "0";
                            MessageBox.Show("Error al procesar el archivo" + ex.Message);
                        }
                        try
                        {
                            txbNombreArchivo.Text = reader.GetString("Ruta_Recursos");
                            string rutacompleta = txbNombreArchivo.Text;
                            txbRuta.Text = rutacompleta;
                            string nombrearchivo = Path.GetFileName(rutacompleta);
                            txbNombreArchivo.Text = nombrearchivo;
                        }
                        catch
                        {
                            txbNombreArchivo.Text = string.Empty;
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

        private bool EsImagen(byte[] archivoBytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(archivoBytes))
                {
                    Image.FromStream(ms);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            DescargarArchivo();
        }

        private void DescargarArchivo()
        {
            if (archivoBytes != null && archivoBytes.Length > 0)
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
                        File.WriteAllBytes(saveFileDialog.FileName, archivoBytes);
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
            else
            {
                MessageBox.Show("No hay archivo para descargar.");
            }
        }

        int prioycategoria = 0;
        private void dgvPendientes_DoubleClick(object sender, EventArgs e)
        {

        }

        private void cbNivelPrio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prioycategoria == 0)
            {

            }
            else
            {
                string selectedText = cbTipoReq.Text;
                cbTipoReq.Items.Clear();

                if (cbNivelPrio.SelectedIndex == 0)
                {
                    cbTipoReq.Items.Add("Fallo en Equipo de Computo");
                    cbTipoReq.Items.Add("Problema de Seguridad");
                    cbTipoReq.Items.Add("Problemas de Red");
                    cbTipoReq.Items.Add("Sin Acceso al Sistema");
                }
                else if (cbNivelPrio.SelectedIndex == 1)
                {
                    cbTipoReq.Items.Add("Problemas de Impresoras/Periféricos");
                    cbTipoReq.Items.Add("Requerimientos de Hardware");
                    cbTipoReq.Items.Add("Requerimientos de Software");
                    cbTipoReq.Items.Add("Solicitud de Cambio o Mejora");
                }
                else
                {
                    cbTipoReq.Items.Add("Consulta General");
                    cbTipoReq.Items.Add("Mantenimiento Preventivo");
                    cbTipoReq.Items.Add("Respaldo de Datos");
                    cbTipoReq.Items.Add("Solicitud de Capacitación");
                }

                if (cbTipoReq.Items.Contains(selectedText))
                {
                    cbTipoReq.Text = selectedText;
                }
                else
                {
                    cbTipoReq.SelectedIndex = -1;
                }
            }
        }

        private void cbTipoReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prioycategoria == 0)
            {

            }
            else
            {
                if (cbTipoReq.Text == "Fallo en Equipo de Computo" ||
                cbTipoReq.Text == "Problema de Seguridad" ||
                cbTipoReq.Text == "Problemas de Red" ||
                cbTipoReq.Text == "Sin Acceso al Sistema")
                {
                    cbNivelPrio.Text = "Alta";
                }
                else if (cbTipoReq.Text == "Problemas de Impresoras/Periféricos" ||
                    cbTipoReq.Text == "Requerimientos de Hardware" ||
                    cbTipoReq.Text == "Requerimientos de Software" ||
                    cbTipoReq.Text == "Solicitud de Cambio o Mejora")
                {
                    cbNivelPrio.Text = "Media";
                }
                else
                {
                    cbNivelPrio.Text = "Baja";
                }
            }
        }

        private void btnActualizarTicket_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizarTicket_Click_1(object sender, EventArgs e)
        {
            if (cbTipoReq.Text == string.Empty || cbNivelPrio.Text == string.Empty || txbDescripcion.Text == string.Empty)
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE elastosystem_sistemas_req SET TipoReq = @TipoReq, Prioridad = @Prioridad, Descripcion = @Descripcion WHERE Folio = @Folio";
                cmd.Parameters.AddWithValue("@TipoReq", cbTipoReq.Text);
                cmd.Parameters.AddWithValue("@Prioridad", cbNivelPrio.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txbDescripcion.Text);
                cmd.Parameters.AddWithValue("@Folio", lblFolioOriginal.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ticket Actualizado Correctamente");
                lblFolio.Text = string.Empty; lblFolioOriginal.Text = string.Empty; lblSolicitante.Text = string.Empty;
                cbNivelPrio.SelectedIndex = -1; cbTipoReq.SelectedIndex = -1; txbDescripcion.Text = string.Empty;
                pbImagen.Image = null; txbNombreArchivo.Text = string.Empty; txbRuta.Text = string.Empty;
                btnActualizarTicket.Visible = false; btnTomarTicket.Visible = false; archivoBytes = null;
                MandarALlamarEnProceso();
                MandarALlamarPendientes();
                MandarALlamarTicketsFinalizados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ACTUALIZAR TICKET: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnTomarTicket_Click_1(object sender, EventArgs e)
        {
            if (cbTipoReq.Text == string.Empty || cbNivelPrio.Text == string.Empty || txbDescripcion.Text == string.Empty)
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE elastosystem_sistemas_req SET TipoReq = @TIPOREQ, Prioridad = @PRIORIDAD, Descripcion = @DESCRIPCION, Estatus = @ESTATUS, Asignado_a = @ASIGNADOA WHERE Folio = @FOLIO";
                cmd.Parameters.AddWithValue("@TIPOREQ", cbTipoReq.Text);
                cmd.Parameters.AddWithValue("@PRIORIDAD", cbNivelPrio.Text);
                cmd.Parameters.AddWithValue("@DESCRIPCION", txbDescripcion.Text);
                cmd.Parameters.AddWithValue("@ESTATUS", "EN PROCESO");
                cmd.Parameters.AddWithValue("@ASIGNADOA", VariablesGlobales.Usuario);
                cmd.Parameters.AddWithValue("@FOLIO", lblFolioOriginal.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ticket Asignado Correctamente");
                lblFolio.Text = string.Empty; lblFolioOriginal.Text = string.Empty; lblSolicitante.Text = string.Empty;
                cbNivelPrio.SelectedIndex = -1; cbTipoReq.SelectedIndex = -1; txbDescripcion.Text = string.Empty;
                pbImagen.Image = null; txbNombreArchivo.Text = string.Empty; txbRuta.Text = string.Empty;
                btnActualizarTicket.Visible = false; btnTomarTicket.Visible = false; archivoBytes = null;
                MandarALlamarEnProceso();
                MandarALlamarPendientes();
                MandarALlamarTicketsFinalizados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ACTUALIZAR TICKET: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        byte[] archivoBytesProceso;
        private void dgvEnProceso_Click(object sender, EventArgs e)
        {
            lblFolioEnProceso.Text = string.Empty;
            lblFolioOriginalEnProceso.Text = string.Empty;
            lblSolicitanteEnProceso.Text = string.Empty;
            lblPrioridadEnProceso.Text = string.Empty;
            lblCategoriaEnProceso.Text = string.Empty;
            txbDesEnProceso.Text = string.Empty;
            btnDescarEnProceso.Visible = false;
            //txbNombreArchivo.Text = string.Empty;
            //txbRuta.Text = string.Empty;

            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string folio = dgv.Rows[rowIndex].Cells[0].Value.ToString();
                lblFolioOriginalEnProceso.Text = folio;

                string folioAlt = dgv.Rows[rowIndex].Cells[1].Value.ToString();
                lblFolioEnProceso.Text = folioAlt;

                string tipoReq = dgv.Rows[rowIndex].Cells[2].Value.ToString();
                lblCategoriaEnProceso.Text = tipoReq;

                string descripcion = dgv.Rows[rowIndex].Cells[3].Value.ToString();
                txbDesEnProceso.Text = descripcion;

                string solicitante = dgv.Rows[rowIndex].Cells[4].Value.ToString();
                lblSolicitanteEnProceso.Text = solicitante;

                string prioridad = dgv.Rows[rowIndex].Cells[5].Value.ToString();
                lblPrioridadEnProceso.Text = prioridad;

                MandarALlamarArchivoAdjunto();
            }
        }

        private void MandarALlamarArchivoAdjunto()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Recursos, Ruta_Recursos FROM elastosystem_sistemas_req WHERE Folio LIKE '" + lblFolioOriginalEnProceso.Text + "' ";
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
                            if (!reader.IsDBNull(reader.GetOrdinal("Recursos")))
                            {
                                archivoBytesProceso = (byte[])reader["Recursos"];
                                btnDescarEnProceso.Visible = true;
                            }
                            else
                            {
                                archivoBytesProceso = null;
                                btnDescarEnProceso.Visible = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al procesar el archivo" + ex.Message);
                        }
                        try
                        {
                            txbNomArcEnProceso.Text = reader.GetString("Ruta_Recursos");
                            string rutacompleta = txbNomArcEnProceso.Text;
                            txbRutaEnProceso.Text = rutacompleta;
                            string nombrearchivo = Path.GetFileName(rutacompleta);
                            txbNomArcEnProceso.Text = nombrearchivo;
                        }
                        catch
                        {
                            txbNomArcEnProceso.Text = string.Empty;
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

        private void btnDescarEnProceso_Click(object sender, EventArgs e)
        {
            DescargarArchivoProceso();
        }

        private void DescargarArchivoProceso()
        {
            if (archivoBytesProceso != null && archivoBytesProceso.Length > 0)
            {
                string extensionArchivo = Path.GetExtension(txbRutaEnProceso.Text);
                string nombreArchivo = txbNomArcEnProceso.Text;

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
                        File.WriteAllBytes(saveFileDialog.FileName, archivoBytesProceso);
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
            else
            {
                MessageBox.Show("No hay archivo para descargar.");
            }
        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            CargarComprobante();
        }

        byte[] comprobanteBytes;
        private void CargarComprobante()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Todos los archivos (*.*)|*.*";
            openFileDialog.Title = "Seleccionar Archivo";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePathc = openFileDialog.FileName;

                string fileName = Path.GetFileName(filePathc);

                txbNombreComprobante.Text = fileName;
                txbRutaComprobante.Text = filePathc;

                try
                {
                    comprobanteBytes = File.ReadAllBytes(filePathc);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el archivo" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No se seleccionó ningún archivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFinTicket_Click(object sender, EventArgs e)
        {
            if (lblFolioEnProceso.Text == string.Empty)
            {
                MessageBox.Show("Favor de seleccionar un ticket en proceso");
                return;
            }
            if (comprobanteBytes == null)
            {
                MessageBox.Show("Favor de cargar un comprobante");
                return;
            }
            FinalizarTicket();
        }

        private void FinalizarTicket()
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string rutaarchivo = txbRutaComprobante.Text.Replace("\\", "\\\\");
            string estatus = "FINALIZADO";
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE elastosystem_sistemas_req SET FechaTermino = @FECHATERMINO, HoraTermino = @HORATERMINO, Estatus = @ESTATUS, Comprobante = @COMPROBANTE, Ruta_Comprobante = @RUTACOMPROBANTE, Comentarios = @COMENTARIOS WHERE Folio = @FOLIO";
                cmd.Parameters.AddWithValue("@FECHATERMINO", fecha);
                cmd.Parameters.AddWithValue("@HORATERMINO", DateTime.Now.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("@ESTATUS", estatus);
                cmd.Parameters.AddWithValue("@COMPROBANTE", comprobanteBytes);
                cmd.Parameters.AddWithValue("@RUTACOMPROBANTE", rutaarchivo);
                cmd.Parameters.AddWithValue("@COMENTARIOS", txbComentarios.Text);
                cmd.Parameters.AddWithValue("@FOLIO", lblFolioOriginalEnProceso.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ticket Finalizado Correctamente");
                lblFolioEnProceso.Text = string.Empty; lblFolioOriginalEnProceso.Text = string.Empty; lblSolicitanteEnProceso.Text = string.Empty;
                lblPrioridadEnProceso.Text = string.Empty; lblCategoriaEnProceso.Text = string.Empty; txbDesEnProceso.Text = string.Empty;
                txbRutaComprobante.Text = string.Empty; txbNombreComprobante.Text = string.Empty; txbComentarios.Text = string.Empty;
                comprobanteBytes = null;
                btnDescarEnProceso.Visible = false;
                MandarALlamarEnProceso();
                MandarALlamarPendientes();
                MandarALlamarTicketsFinalizados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL FINALIZAR TICKET: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void tabEnProceso_Click(object sender, EventArgs e)
        {
            MandarALlamarEnProceso();
            MandarALlamarPendientes();
            MandarALlamarTicketsFinalizados();
        }

        private void tabPendientes_Click(object sender, EventArgs e)
        {
            MandarALlamarEnProceso();
            MandarALlamarPendientes();
            MandarALlamarTicketsFinalizados();
        }

        private void tabFinalizado_Click(object sender, EventArgs e)
        {
            MandarALlamarEnProceso();
            MandarALlamarPendientes();
            MandarALlamarTicketsFinalizados();
        }

        private void dgvFinalizado_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFinalizado.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFinalizado.SelectedRows[0];
                string primerDato = selectedRow.Cells[0].Value.ToString();
                txbFolioFin.Text = primerDato;

                MandarALlamarComprobante();
            }
        }

        byte[] comprobanteBytesFinalizado;
        private void MandarALlamarComprobante()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                conn.Open();
                string query = "SELECT Comprobante, Ruta_Comprobante FROM elastosystem_sistemas_req WHERE Folio LIKE @FOLIO";
                try
                {
                    using (MySqlCommand comando = new MySqlCommand(query, conn))
                    {
                        comando.Parameters.AddWithValue("@FOLIO", txbFolioFin.Text);
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    try
                                    {
                                        if (!reader.IsDBNull(reader.GetOrdinal("Comprobante")))
                                        {
                                            comprobanteBytesFinalizado = (byte[])reader["Comprobante"];
                                        }
                                        else
                                        {
                                            comprobanteBytesFinalizado = null;
                                        }
                                        if (!reader.IsDBNull(reader.GetOrdinal("Ruta_Comprobante")))
                                        {
                                            txbNomFin.Text = reader.GetString("Ruta_Comprobante");
                                            string rutacompleta = txbNomFin.Text;
                                            txbRutaFin.Text = rutacompleta;
                                            string nombrearchivo = Path.GetFileName(rutacompleta);
                                            txbNomFin.Text = nombrearchivo;
                                        }
                                        else
                                        {
                                            txbNomFin.Text = string.Empty;
                                            txbRutaFin.Text = string.Empty;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error al procesar el archivo" + ex.Message);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR EN LA CONSULTA: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DescargarComprobante();
        }

        private void DescargarComprobante()
        {
            string extensionArchivo = Path.GetExtension(txbRutaFin.Text);
            string nombreArchivo = txbNomFin.Text;

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
                    File.WriteAllBytes(saveFileDialog.FileName, comprobanteBytesFinalizado);
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
    }
}
