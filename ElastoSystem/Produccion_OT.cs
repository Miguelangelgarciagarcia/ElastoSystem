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
    public partial class Produccion_OT : Form
    {
        public string FolioOT { get; set; }
        public string ClaveProd { get; set; }
        public Produccion_OT()
        {
            InitializeComponent();
        }

        private Color colorOriginalPNCPor;
        private Color colorOriginalReprocesoPor;
        private bool parpadeandoPNC = false;
        private bool parpadeandoReproceso = false;

        private void Produccion_OT_Load(object sender, EventArgs e)
        {
            lblOrdenTrabajo.Text = "ORDEN DE TRABAJO: " + FolioOT;

            colorOriginalPNCPor = pnlPNCPor.BackColor;
            colorOriginalReprocesoPor = pnlReprocesoPor.BackColor;

            CargarInfoOT();
            CargarRegistros();
            RevisarPermisosActualizar();

            if (btnActualizarOT.Visible)
            {
                dtpFechaInicio.Enabled = true;
                dtpFechaFinal.Enabled = true;
                cbTurno.Enabled = true;
                txbCantidad.ReadOnly = false;
                txbLote.ReadOnly = false;
                cbMolde.Enabled = true;
                txbObservaciones.ReadOnly = false;
                cbMaquinas.Enabled = true;
            }
            else
            {
                dtpFechaInicio.Enabled = false;
                dtpFechaFinal.Enabled = false;
                cbTurno.Enabled = false;
                txbCantidad.ReadOnly = true;
                txbLote.ReadOnly = true;
                cbMolde.Enabled = false;
                txbObservaciones.ReadOnly = true;
                cbMaquinas.Enabled = false;
            }
        }

        private void RevisarPermisosActualizar()
        {
            if (string.IsNullOrWhiteSpace(VariablesGlobales.Usuario))
            {
                btnActualizarOT.Visible = false;
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string queryUsuario = "SELECT ID FROM elastosystem_login WHERE Usuario = @USUARIO LIMIT 1";
                    int userId = 0;

                    using (MySqlCommand cmdUsuario = new MySqlCommand(queryUsuario, conn))
                    {
                        cmdUsuario.Parameters.AddWithValue("@USUARIO", VariablesGlobales.Usuario.Trim());
                        object result = cmdUsuario.ExecuteScalar();

                        if (result == null || result == DBNull.Value || !int.TryParse(result.ToString(), out userId))
                        {
                            btnActualizarOT.Visible = false;
                            return;
                        }
                    }

                    string queryPermiso = "SELECT ActualizarOT FROM elastosystem_permisos_menu WHERE ID = @ID LIMIT 1";
                    using (MySqlCommand cmdPermiso = new MySqlCommand(queryPermiso, conn))
                    {
                        cmdPermiso.Parameters.AddWithValue("@ID", userId);
                        object result = cmdPermiso.ExecuteScalar();

                        bool tienePermiso = false;
                        if (result != null && result != DBNull.Value)
                        {
                            tienePermiso = Convert.ToBoolean(result);
                        }

                        btnActualizarOT.Visible = tienePermiso;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL VERIFICAR PERMISOS: " + ex.Message, "Error de permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnActualizarOT.Visible = false;
            }
        }

        private void CargarInfoOT()
        {
            string ot = FolioOT;

            if (string.IsNullOrWhiteSpace(ot))
            {
                MessageBox.Show("ERROR AL OBTENER ORDEN DE TRABAJO");
                return;
            }

            using (var conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM elastosystem_produccion_ot WHERE Folio = @FOLIO LIMIT 1";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FOLIO", ot);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dtpFechaInicio.Value = Convert.ToDateTime(reader["FechaInicio"].ToString());
                                dtpFechaFinal.Value = Convert.ToDateTime(reader["FechaTermino"].ToString());
                                lblAutorizo.Text = reader["Autorizo"].ToString();
                                cbTurno.Text = reader["Turno"].ToString();
                                txbLote.Text = reader["Lote"].ToString();
                                cbMolde.Items.Add(reader["Molde"].ToString());
                                cbMolde.SelectedIndex = 0;
                                txbCantidad.Text = reader["Cantidad"].ToString();
                                txbEspecificacion.Text = reader["Especificacion"].ToString();
                                txbArea.Text = reader["Area"].ToString();
                                txbNombreArea.Text = reader["NombreArea"].ToString();
                                cbMaquinas.Items.Add(reader["Maquina"].ToString());
                                cbMaquinas.SelectedIndex = 0;
                                txbSolicitudFabricacion.Text = reader["SF"].ToString();
                                txbObservaciones.Text = reader["Observaciones"].ToString();
                                lblNave.Text = reader["Nave"].ToString();
                                CargarMaquinasDisponibles();
                                if (txbEspecificacion.Text.Length > 0)
                                {
                                    ComprobarAV();
                                }
                                else
                                {
                                    RevisarAVGenerales();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL OBTENER DATOS DE LA ORDEN DE TRABAJO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void CargarMaquinasDisponibles()
        {
            string nave = lblNave.Text.Trim();
            if(string.IsNullOrWhiteSpace(nave))
            {
                return;
            }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string query = @"
                        SELECT im.Nombre
                        FROM elastosystem_mtto_inventariomaquinas im
                        WHERE im.Ubicacion = @UBICACION
                            AND im.Orden_Trabajo = 1
                            AND NOT EXISTS (
                                SELECT 1
                                FROM elastosystem_produccion_ot ot
                                WHERE ot.Maquina = im.Nombre
                                    AND ot.Estatus = 'ABIERTA'
                            )
                        ORDER BY im.Nombre";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UBICACION", nave);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nombreMaquina = reader["Nombre"].ToString();
                                if (!string.IsNullOrWhiteSpace(nombreMaquina))
                                {
                                    cbMaquinas.Items.Add(nombreMaquina);
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR MÁQUINAS DISPONIBLES: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComprobarAV()
        {
            string nombreAV = txbEspecificacion.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombreAV))
            {
                btnVerEspecificacion.Visible = false;
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM elastosystem_produccion_av WHERE Nombre = @NOMBRE";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NOMBRE", nombreAV);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            btnVerEspecificacion.Visible = true;
                        }
                        else
                        {
                            RevisarAVGenerales();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL COMPROBAR AYUDA VISUAL ESPECÍFICA: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnVerEspecificacion.Visible = false;
            }
        }

        private void RevisarAVGenerales()
        {
            if (string.IsNullOrWhiteSpace(FolioOT) || string.IsNullOrWhiteSpace(ClaveProd))
            {
                btnVerEspecificacion.Visible = false;
                return;
            }

            string[] partes = FolioOT.Split('-');
            if (partes.Length < 3 || !int.TryParse(partes[partes.Length - 1], out int noOperacion))
            {
                btnVerEspecificacion.Visible = false;
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string familia = "";
                    string ayudaVisual = "";

                    string queryFamilia = "SELECT Familia FROM elastosystem_sae_productos WHERE Producto = @CLAVE LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(queryFamilia, conn))
                    {
                        cmd.Parameters.AddWithValue("@CLAVE", ClaveProd.Trim());
                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value || string.IsNullOrWhiteSpace(result.ToString()))
                        {
                            btnVerEspecificacion.Visible = false;
                            return;
                        }

                        familia = result.ToString().Trim();
                    }

                    string queryAyuda = @"
                        SELECT AyudaVisual
                        FROM elastosystem_produccion_hoja_ruta
                        WHERE Familia = @FAMILIA
                            AND NoOperacion = @NOOPERACION
                        LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(queryAyuda, conn))
                    {
                        cmd.Parameters.AddWithValue("@FAMILIA", familia);
                        cmd.Parameters.AddWithValue("@NOOPERACION", noOperacion);

                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value || string.IsNullOrWhiteSpace(result.ToString()))
                        {
                            btnVerEspecificacion.Visible = false;
                            return;
                        }

                        ayudaVisual = result.ToString().Trim();
                    }

                    if (!string.IsNullOrWhiteSpace(ayudaVisual) && ayudaVisual != txbEspecificacion.Text.Trim())
                    {
                        txbEspecificacion.Text = ayudaVisual;
                        ComprobarAV();
                    }
                    else
                    {
                        btnVerEspecificacion.Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL REVISAR AYUDA VISUAL GENERAL: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnVerEspecificacion.Visible = false;
            }
        }

        private void CargarRegistros()
        {
            if (string.IsNullOrWhiteSpace(FolioOT))
            {
                dgvIngresos.DataSource = null;
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            r.Fecha,
                            r.Turno,
                            TRIM(
                                CONCAT(
                                    IFNULL(CONCAT(op.Nombre, ' ', op.Apellido_Paterno,
                                                    IFNULL(CONCAT(' ', op.Apellido_Materno), '')), ''),
                                    IF(ap.ID IS NOT NULL,
                                        CONCAT(' // ', ap.Nombre, ' ', ap.Apellido_Paterno,
                                                IFNULL(CONCAT(' ', ap.Apellido_Materno), '')),
                                        '')
                                )
                            ) AS Operador,
                            r.POP, 
                            r.PNCOP,
                            r.PNCRevision,
                            r.Reproceso, 
                            r.Observaciones
                        FROM elastosystem_produccion_registro_diario r
                        LEFT JOIN elastosystem_rh op ON r.ID_Operador = op.ID
                        LEFT JOIN elastosystem_rh ap ON r.ID_Apoyo = ap.ID
                        WHERE r.Orden_Trabajo = @FOLIOOT
                        ORDER BY r.Fecha DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FOLIOOT", FolioOT);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            dt.Columns.Add("TurnoAbreviado", typeof(string));
                            dt.Columns.Add("Total", typeof(int));

                            foreach (DataRow row in dt.Rows)
                            {
                                string turnoOriginal = row["Turno"].ToString().Trim().ToUpper();

                                string abreviado = turnoOriginal switch
                                {
                                    "MIXTO" => "X",
                                    "MATUTINO" => "M",
                                    "VESPERTINO" => "V",
                                    "NOCTURNO" => "N",
                                    _ => turnoOriginal
                                };

                                row["TurnoAbreviado"] = abreviado;

                                int pop = Convert.ToInt32(row["POP"]);
                                int pncop = Convert.ToInt32(row["PNCOP"]);
                                int reproceso = Convert.ToInt32(row["Reproceso"]);
                                int pncrevision = Convert.ToInt32(row["PNCRevision"]);
                                row["Total"] = pop - pncop - reproceso - pncrevision;
                            }

                            dgvIngresos.DataSource = dt;

                            if (dgvIngresos.Columns.Count > 0)
                            {
                                dgvIngresos.Columns["Turno"].Visible = false;
                                dgvIngresos.Columns["TurnoAbreviado"].HeaderText = "Turno";
                                dgvIngresos.Columns["TurnoAbreviado"].Width = 60;
                                dgvIngresos.Columns["TurnoAbreviado"].DisplayIndex = 1;

                                dgvIngresos.Columns["POP"].HeaderText = "PRO OP";
                                dgvIngresos.Columns["PNCOP"].HeaderText = "PNC OP";
                                dgvIngresos.Columns["PNCRevision"].HeaderText = "PNC RE";

                                dgvIngresos.Columns["Fecha"].Width = 100;
                                dgvIngresos.Columns["Operador"].Width = 150;
                                dgvIngresos.Columns["POP"].Width = 90;
                                dgvIngresos.Columns["PNCOP"].Width = 90;
                                dgvIngresos.Columns["Reproceso"].Width = 90;
                                dgvIngresos.Columns["PNCRevision"].Width = 90;
                                dgvIngresos.Columns["Total"].Width = 90;
                                dgvIngresos.Columns["Observaciones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                                dgvIngresos.Columns["POP"].DefaultCellStyle.Format = "N0";
                                dgvIngresos.Columns["PNCOP"].DefaultCellStyle.Format = "N0";
                                dgvIngresos.Columns["Reproceso"].DefaultCellStyle.Format = "N0";
                                dgvIngresos.Columns["PNCRevision"].DefaultCellStyle.Format = "N0";
                                dgvIngresos.Columns["Total"].DefaultCellStyle.Format = "N0";

                                dgvIngresos.Columns["Total"].DisplayIndex = dgvIngresos.Columns["Observaciones"].Index;

                                Calcular();

                                if (dt.Rows.Count == 0)
                                {
                                    MessageBox.Show("NO HAY REGISTROS EN LA ORDEN DE TRABAJO");
                                    lblProduccionEnOperacion.Text = string.Empty;
                                    lblProduccionXTurno.Text = string.Empty;
                                    lblDiasRestantes.Text = string.Empty;
                                    lblPNCEnOperacion.Text = string.Empty;
                                    lblPNCEnRevision.Text = string.Empty;
                                    lblPNCTotal.Text = string.Empty;
                                    lblPorPNC.Text = string.Empty;
                                    lblReprocesoTotal.Text = string.Empty;
                                    lblPorReproceso.Text = string.Empty;
                                    lblProductoConforme.Text = string.Empty;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR REGISTROS: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvIngresos.DataSource = null;
            }
        }

        private void Calcular()
        {
            if (dgvIngresos.DataSource == null || dgvIngresos.Rows.Count == 0)
            {
                lblProduccionEnOperacion.Text = "0";
                lblPNCEnOperacion.Text = "0";
                lblPNCEnRevision.Text = "0";
                lblReprocesoTotal.Text = "0";
                lblPNCTotal.Text = "0";
                lblPorPNC.Text = "0.00%";
                lblPorReproceso.Text = "0.00%";
                lblProductoConforme.Text = "0";
                CalcularPromedio();
                return;
            }

            int totalPOP = 0;
            int totalPNCOP = 0;
            int totalPNCRevision = 0;
            int totalReproceso = 0;

            foreach (DataGridViewRow row in dgvIngresos.Rows)
            {
                if (row.Cells["Operador"].Value != null &&
                    row.Cells["Operador"].Value.ToString().Contains("No hay registros"))
                {
                    continue;
                }

                if (int.TryParse(row.Cells["POP"].Value?.ToString(), out int pop)) totalPOP += pop;
                if (int.TryParse(row.Cells["PNCOP"].Value?.ToString(), out int pncop)) totalPNCOP += pncop;
                if (int.TryParse(row.Cells["PNCRevision"].Value?.ToString(), out int pncrev)) totalPNCRevision += pncrev;
                if (int.TryParse(row.Cells["Reproceso"].Value.ToString(), out int repro)) totalReproceso += repro;
            }

            int pncTotal = totalPNCOP + totalPNCRevision + totalReproceso;
            int productoConforme = totalPOP - pncTotal;

            double porPNC = totalPOP > 0 ? (pncTotal * 100.0) / totalPOP : 0;
            double porReproceso = totalPOP > 0 ? (totalReproceso * 100.0) / totalPOP : 0;

            lblProduccionEnOperacion.Text = totalPOP.ToString("N0");
            lblPNCEnOperacion.Text = totalPNCOP.ToString("N0");
            lblPNCEnRevision.Text = totalPNCRevision.ToString("N0");
            lblReprocesoTotal.Text = totalReproceso.ToString("N0");
            lblPNCTotal.Text = pncTotal.ToString("N0");
            lblPorPNC.Text = porPNC.ToString("N2") + "%";
            lblPorReproceso.Text = porReproceso.ToString("N2") + "%";
            lblProductoConforme.Text = productoConforme.ToString("N0");
            Parpadeo();
            CalcularPromedio();
        }

        private void Parpadeo()
        {
            if (double.TryParse(lblPorPNC.Text.Replace("%", "").Trim(), out double porPNC))
            {
                if (porPNC >= 5.0)
                {
                    if (!parpadeandoPNC)
                    {
                        parpadeandoPNC = true;
                        pnlPNCPor.BackColor = Color.Red;
                        timerParpadeoPNC.Start();
                    }
                }
                else
                {
                    if (parpadeandoPNC)
                    {
                        timerParpadeoPNC.Stop();
                        pnlPNCPor.BackColor = colorOriginalPNCPor;
                        parpadeandoPNC = false;
                    }
                }
            }
            else
            {
                if (parpadeandoPNC)
                {
                    timerParpadeoPNC.Stop();
                    pnlPNCPor.BackColor = colorOriginalPNCPor;
                    parpadeandoPNC = false;
                }
            }




            if (double.TryParse(lblPorReproceso.Text.Replace("%", "").Trim(), out double porReproceso))
            {
                if (porReproceso >= 5.0)
                {
                    if (!parpadeandoReproceso)
                    {
                        parpadeandoReproceso = true;
                        pnlReprocesoPor.BackColor = Color.Red;
                        timerParpadeoReproceso.Start();
                    }
                }
                else
                {
                    if (parpadeandoReproceso)
                    {
                        timerParpadeoReproceso.Stop();
                        pnlReprocesoPor.BackColor = colorOriginalReprocesoPor;
                        parpadeandoReproceso = false;
                    }
                }
            }
            else
            {
                if (parpadeandoReproceso)
                {
                    timerParpadeoReproceso.Stop();
                    pnlReprocesoPor.BackColor = colorOriginalReprocesoPor;
                    parpadeandoReproceso = false;
                }
            }
        }

        private void CalcularPromedio()
        {
            lblProduccionXTurno.Text = "SR";
            lblDiasRestantes.Text = "N/A";

            if (string.IsNullOrWhiteSpace(ClaveProd) ||
                string.IsNullOrWhiteSpace(FolioOT) ||
                cbTurno.SelectedItem == null)
            {
                return;
            }

            string sufijoActual = FolioOT.Split('-').Last();
            string seleccionTurno = cbTurno.SelectedItem.ToString().Trim();

            string condicionTurno = "";
            if (seleccionTurno == "1 TURNO")
            {
                condicionTurno = "AND r.Turno = 'MIXTO'";
            }
            else
            {
                condicionTurno = "AND r.Turno IN ('MATUTINO', 'VESPERTINO', 'NOCTURNO')";
            }

            int produccionDiariaEsperada = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string query = $@"
                        SELECT
                            (r.POP - r.PNCOP - r.Reproceso - r.PNCRevision) AS TotalDiario
                        FROM elastosystem_produccion_registro_diario r
                        INNER JOIN elastosystem_produccion_ot ot ON r.Orden_Trabajo = ot.Folio
                        INNER JOIN elastosystem_almacen_solicitud_fabricacion sf ON ot.SF = sf.Folio_ALT
                        WHERE sf.Clave = @CLAVE
                            AND SUBSTRING_INDEX(ot.Folio, '-', -1) = @SUFIJO
                            {condicionTurno}
                            AND (r.POP - r.PNCOP - r.Reproceso - r.PNCRevision) > 0
                        ORDER BY TotalDiario DESC
                        LIMIT 5";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CLAVE", ClaveProd);
                        cmd.Parameters.AddWithValue("@SUFIJO", sufijoActual);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<int> mejores5 = new List<int>();
                            while (reader.Read())
                            {
                                int totalDiario = reader.GetInt32("TotalDiario");
                                mejores5.Add(totalDiario);
                            }

                            if (mejores5.Count == 0)
                            {
                                lblProduccionXTurno.Text = "SR";
                                lblDiasRestantes.Text = "N/A";
                                return;
                            }

                            double promedio = mejores5.Average();
                            produccionDiariaEsperada = (int)Math.Round(promedio, MidpointRounding.AwayFromZero);
                            lblProduccionXTurno.Text = produccionDiariaEsperada.ToString("N0");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CALCULAR PRODUCCIÓN POR TURNO: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblProduccionXTurno.Text = "ERROR";
                lblDiasRestantes.Text = "ERROR";
                return;
            }

            if (!int.TryParse(txbCantidad.Text.Replace(",", ""), out int cantidadObjetivo) ||
                !int.TryParse(lblProductoConforme.Text.Replace(",", ""), out int produccionConforme) ||
                produccionDiariaEsperada <= 0)
            {
                lblDiasRestantes.Text = "N/A";
                return;
            }

            int faltante = cantidadObjetivo - produccionConforme;

            if (faltante <= 0)
            {
                lblDiasRestantes.Text = "0";
                return;
            }

            int diasRestantes = (int)Math.Ceiling((double)faltante / produccionDiariaEsperada);

            lblDiasRestantes.Text = diasRestantes.ToString();
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

        private byte[] ayudaVisualPdfAV;
        private void btnVerEspecificacion_Click(object sender, EventArgs e)
        {
            CargarAV();
        }

        private void CargarAV()
        {
            string nombreav = txbEspecificacion.Text;

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Archivo FROM elastosystem_produccion_av WHERE Nombre = @NOMBRE LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NOMBRE", nombreav);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        ayudaVisualPdfAV = (byte[])resultado;
                        MostrarAV();
                    }
                    else
                    {
                        ayudaVisualPdfAV = null;
                        MessageBox.Show("NO SE ENCONTRO EL ARCHIVO ASOCIADO A LA AYUDA VISUAL");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL OBTENER LA AYUDA VISUAL: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void MostrarAV()
        {
            if (ayudaVisualPdfAV != null)
            {
                string rutaTemporal = Path.Combine(Path.GetTempPath(), "tempAV.pdf");
                File.WriteAllBytes(rutaTemporal, ayudaVisualPdfAV);

                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = rutaTemporal,
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }
            else
            {
                MessageBox.Show("NO HAY ARCHIVO CARGADO PARA VISAULIZAR");
            }
        }

        private void dgvIngresos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvIngresos.ClearSelection();
        }
        int grosor = 2;
        Color colorBorde = Color.Red;
        private void pnlReproceso_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                using (Pen pen = new Pen(colorBorde, grosor))
                {
                    Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private void pnlReprocesoPor_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                using (Pen pen = new Pen(colorBorde, grosor))
                {
                    Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private void pnlPNC_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                using (Pen pen = new Pen(colorBorde, grosor))
                {
                    Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private void pnlPNCPor_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                using (Pen pen = new Pen(colorBorde, grosor))
                {
                    Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private void timerParpadeoPNC_Tick(object sender, EventArgs e)
        {
            if (pnlPNCPor.BackColor == Color.Red)
            {
                pnlPNCPor.BackColor = colorOriginalPNCPor;
            }
            else
            {
                pnlPNCPor.BackColor = Color.Red;
            }


        }

        private void timerParpadeoReproceso_Tick(object sender, EventArgs e)
        {
            if (pnlReprocesoPor.BackColor == Color.Red)
            {
                pnlReprocesoPor.BackColor = colorOriginalReprocesoPor;
            }
            else
            {
                pnlReprocesoPor.BackColor = Color.Red;
            }
        }

        private void btnActualizarOT_Click(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value.Date > dtpFechaFinal.Value.Date)
            {
                MessageBox.Show("La fecha de inicio debe ser menor o igual a la fecha final.", "Validación de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool hayRegistrosFueraDeRango = false;
            string mensajeError = "";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string query = @"
                        SELECT COUNT(*)
                        FROM elastosystem_produccion_registro_diario
                        WHERE Orden_Trabajo = @FOLIOOT
                            AND (
                                Fecha < @NUEVAFECHAINICIO
                                OR Fecha > @NUEVAFECHAFINAL
                            )";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FOLIOOT", FolioOT);
                        cmd.Parameters.AddWithValue("@NUEVAFECHAINICIO", dtpFechaInicio.Value.Date);
                        cmd.Parameters.AddWithValue("@NUEVAFECHAFINAL", dtpFechaFinal.Value.Date);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        hayRegistrosFueraDeRango = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar registros existentes:\n" + ex.Message, "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (hayRegistrosFueraDeRango)
            {
                MessageBox.Show(
                    "No se puede modificar el rango de fechas.\n\n" +
                    "Existen registros diarios cuya fecha está fuera del nuevo rango propuesto.\n" +
                    "Primero elimine o ajuste los registros que estén antes de la fecha de inicio\n" +
                    "o después de la fecha final.",
                    "Rango de fechas inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

            if (!string.IsNullOrWhiteSpace(cbMaquinas.Text))
            {
                string maquinaSeleccionada = cbMaquinas.Text.Trim();

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                    {
                        conn.Open();

                        string query = @"
                            SELECT COUNT(*)
                            FROM elastosystem_produccion_ot
                            WHERE Maquina = @MAQUINA
                                AND Estatus = 'ABIERTA'
                                AND Folio != @FOLIOOT";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MAQUINA", maquinaSeleccionada);
                            cmd.Parameters.AddWithValue("@FOLIOOT", FolioOT);

                            int count = Convert.ToInt32(cmd.ExecuteScalar());

                            if (count > 0)
                            {
                                MessageBox.Show(
                                    $"La máquina '{maquinaSeleccionada}' ya está asignada a otra orden de trabajo ABIERTA.\n\n" +
                                    "No es posible asignarla a esta orden hasta que la otra OT se cierre o cambie de máquina.",
                                    "Máquina en uso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Stop);

                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar disponibilidad de la máquina:\n" + ex.Message, "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            if (int.TryParse(txbCantidad.Text.Replace(",", ""), out int nuevaCantidad) &&
                int.TryParse(lblProductoConforme.Text.Replace(",", ""), out int productoConforme))
            {
                if (nuevaCantidad < productoConforme)
                {
                    MessageBox.Show(
                        $"La cantidad objetivo no puede ser menor que la cantidad ya producida conforme.\n\n" +
                        $"Cantidad producidad conforme actual: {productoConforme:N0}\n" +
                        $"Cantidad objetivo propuesta: {nuevaCantidad:N0}\n\n" +
                        "Si necesita ajustar la cantidad, primero corrija o elimine registros de producción que excedan la nueva cantidad deseada.",
                        "Cantidad inválida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);

                    return;
                }
            }
            else
            {
                MessageBox.Show("La cantidad objetivo debe ser un número entero válido.", "Error de dato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ActualizarOT();
        }

        private void ActualizarOT()
        {
            DateTime originalFechaIncio = dtpFechaInicio.Value;
            DateTime originalFechaFinal = dtpFechaFinal.Value;
            string originalTurno = "";
            string originalLote = "";
            string originalMolde = "";
            int originalCantidad = 0;
            string originalMaquina = "";
            string originalObservaciones = "";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = @"
                        SELECT FechaInicio, FechaTermino, Turno, Lote, Molde, Cantidad, Maquina, Observaciones
                        FROM elastosystem_produccion_ot
                        WHERE Folio = @FOLIO AND Estatus = 'ABIERTA'";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FOLIO", FolioOT);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                originalFechaIncio = reader.GetDateTime("FechaInicio");
                                originalFechaFinal = reader.GetDateTime("FechaTermino");
                                originalTurno = reader["Turno"].ToString();
                                originalLote = reader["Lote"].ToString();
                                originalMolde = reader["Molde"].ToString();
                                originalCantidad = Convert.ToInt32(reader["Cantidad"]);
                                originalMaquina = reader["Maquina"].ToString();
                                originalObservaciones = reader["Observaciones"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No se encontró la orden de trabajo o no está ABIERTA.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos originales:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime nuevaFechaInicio = dtpFechaInicio.Value.Date;
            DateTime nuevaFechaFinal = dtpFechaFinal.Value.Date;
            string nuevoTurno = cbTurno.Text.Trim();
            string nuevoLote = txbLote.Text.Trim();
            string nuevoMolde = cbMolde.Text.Trim();
            int nuevaCantidad = int.Parse(txbCantidad.Text.Replace(",", ""));
            string nuevaMaquina = cbMaquinas.Text.Trim();
            string nuevasObservaciones = txbObservaciones.Text.Trim();

            var cambios = new List<string>();

            if (originalFechaIncio != nuevaFechaInicio)
                cambios.Add($"Fecha Inicio: original {originalFechaIncio:dd/MM/yyyy} → cambió a {nuevaFechaInicio:dd/MM/yyyy}");

            if (originalFechaFinal != nuevaFechaFinal)
                cambios.Add($"Fecha Término: original {originalFechaFinal:dd/MM/yyyy} → cambió a {nuevaFechaFinal:dd/MM/yyyy}");

            if (originalTurno != nuevoTurno)
                cambios.Add($"Turno: original '{originalTurno}' → cambió a '{nuevoTurno}'");

            if (originalLote != nuevoLote)
                cambios.Add($"Lote: original '{originalLote}' → cambió a '{nuevoLote}'");

            if (originalMolde != nuevoMolde)
                cambios.Add($"Molde: original '{originalMolde}' → cambió a '{nuevoMolde}'");

            if (originalCantidad != nuevaCantidad)
                cambios.Add($"Cantidad: original {originalCantidad:N0} → cambió a {nuevaCantidad:N0}");

            if (originalMaquina != nuevaMaquina)
                cambios.Add($"Máquina: original '{originalMaquina}' → cambió a '{nuevaMaquina}'");

            if (originalObservaciones != nuevasObservaciones)
                cambios.Add($"Observaciones: cambió (texto modificado)");

            if (cambios.Count == 0)
            {
                MessageBox.Show("No se detectaron cambios en los datos de la orden de trabajo.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string textoCambios = ""+string.Join("\n", cambios);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string insertCambios = @"
                        INSERT INTO elastosystem_produccion_ot_cambios (Usuario, Fecha, Cambios, Folio)
                        VALUES (@USUARIO, @FECHA, @CAMBIOS, @FOLIO)";

                    using (MySqlCommand cmdInsert = new MySqlCommand(insertCambios, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@USUARIO", VariablesGlobales.Usuario ?? "DESCONOCIDO");
                        cmdInsert.Parameters.AddWithValue("@FECHA", DateTime.Now);
                        cmdInsert.Parameters.AddWithValue("@CAMBIOS", textoCambios);
                        cmdInsert.Parameters.AddWithValue("@FOLIO", FolioOT);
                        cmdInsert.ExecuteNonQuery();
                    }

                    string updateOT = @"
                        UPDATE elastosystem_produccion_ot
                        SET
                            FechaInicio = @FECHAINICIO,
                            FechaTermino = @FECHATERMINO,
                            Turno = @TURNO,
                            Lote = @LOTE,
                            Molde = @MOLDE,
                            Cantidad = @CANTIDAD,
                            Maquina = @MAQUINA,
                            Observaciones = @OBSERVACIONES
                        WHERE Folio = @FOLIO";

                    using (MySqlCommand cmdUpdate = new MySqlCommand(updateOT, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@FECHAINICIO", nuevaFechaInicio);
                        cmdUpdate.Parameters.AddWithValue("@FECHATERMINO", nuevaFechaFinal);
                        cmdUpdate.Parameters.AddWithValue("@TURNO", nuevoTurno);
                        cmdUpdate.Parameters.AddWithValue("@LOTE", nuevoLote);
                        cmdUpdate.Parameters.AddWithValue("@MOLDE", nuevoMolde);
                        cmdUpdate.Parameters.AddWithValue("@CANTIDAD", nuevaCantidad);
                        cmdUpdate.Parameters.AddWithValue("@MAQUINA", nuevaMaquina);
                        cmdUpdate.Parameters.AddWithValue("@OBSERVACIONES", nuevasObservaciones);
                        cmdUpdate.Parameters.AddWithValue("@FOLIO", FolioOT);

                        int filas = cmdUpdate.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            MessageBox.Show("Orden de trabajo actualizada correctamente.\n\nLos cambios han sido registrados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar la orden de trabajo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los cambios:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            VariablesGlobales.ValidarNumeroEntero(e, txbCantidad);
        }
    }
}
