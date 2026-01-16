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
    public partial class Produccion_CrearOT : Form
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string ClaveProducto { get; set; }
        public string FolioOT { get; set; }
        public string FolioOP { get; set; }
        public string SolicitudFabricacion { get; set; }
        public string Operacion { get; set; }

        public Produccion_CrearOT()
        {
            InitializeComponent();
        }

        private void Produccion_CrearOT_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = FechaInicio;
            dtpFechaFinal.Value = FechaFinal;
            dtpFechaInicio.MinDate = FechaInicio;
            dtpFechaFinal.MinDate = FechaInicio;

            lblAutorizo.Text = VariablesGlobales.Usuario;
            cbTurno.SelectedIndex = 0;

            txbProducto.Text = ClaveProducto;
            lblFolioOT.Text = FolioOT;

            txbSolicitudFabricacion.Text = SolicitudFabricacion;

            ObtenerOTPrecreadas();

            //CargarMoldes();

            CargarMaquinas();

            //CargaryCalcularProduccion();
        }

        private void ObtenerOTPrecreadas()
        {
            string op = FolioOP;
            string noOperacion = Operacion?.Trim();

            if (string.IsNullOrWhiteSpace(op) || string.IsNullOrWhiteSpace(noOperacion))
            {
                MessageBox.Show("ERROR AL OBTENER ORDEN DE PRODUCCION Y NO. OPERACION");
                return;
            }

            using (var conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Familia, Cantidad FROM elastosystem_produccion_ot_precreadas WHERE OP = @OP AND Operacion = @NOOPERACION LIMIT 1";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OP", op);
                        cmd.Parameters.AddWithValue("@NOOPERACION", noOperacion);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txbFamilia.Text = reader["Familia"]?.ToString();
                                txbCantidad.Text = reader["Cantidad"]?.ToString();
                            }
                        }
                    }
                    ObtenerInfoHojaProducto();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL OBTENER FAMILIA Y CANTIDAD DE OT PRECREADAS: " + ex.Message);
                }
            }
        }

        private void ObtenerInfoHojaProducto()
        {
            string producto = txbProducto.Text?.Trim();
            string noOperacion = Operacion?.Trim();

            if (string.IsNullOrWhiteSpace(producto) || string.IsNullOrWhiteSpace(noOperacion))
            {
                MessageBox.Show("ERROR AL OBTENER PRODUCTO Y NO. OPERACION");
                return;
            }

            using (var conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Area, NombreArea, Nave FROM elastosystem_produccion_hoja_producto WHERE Producto = @PRODUCTO AND NoOperacion = @NOOPERACION LIMIT 1";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PRODUCTO", producto);
                        cmd.Parameters.AddWithValue("@NOOPERACION", noOperacion);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txbArea.Text = reader["Area"]?.ToString();
                                txbNombreArea.Text = reader["NombreArea"]?.ToString();
                                string nave = reader["Nave"]?.ToString();
                                if (nave == "NAVE 1")
                                {
                                    chbNave1.Checked = true;
                                }
                                else
                                {
                                    chbNave2.Checked = true;
                                }
                            }
                        }
                    }
                    ObtenerHojaRuta();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL OBTENER INFORMACIÓN DE LA HOJA DE PRODUCTO: " + ex.Message);
                }
            }
        }

        private void ObtenerHojaRuta()
        {
            string familia = txbFamilia.Text?.Trim();
            string operacion = Operacion?.Trim();

            if (string.IsNullOrWhiteSpace(familia) || string.IsNullOrWhiteSpace(operacion))
            {
                MessageBox.Show("ERROR AL OBTENER FAMILIA Y OPERACION");
                return;
            }

            using (var conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT AyudaVisual FROM elastosystem_produccion_hoja_ruta WHERE Familia = @FAMILIA AND NoOperacion = @NOOPERACION LIMIT 1";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FAMILIA", familia);
                        cmd.Parameters.AddWithValue("@NOOPERACION", operacion);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txbEspecificacion.Text = reader["AyudaVisual"]?.ToString();
                            }
                        }
                    }

                    if (txbEspecificacion.Text != string.Empty)
                    {
                        btnVerEspecificacion.Visible = true;
                        CargarAV();
                    }
                    else
                    {
                        btnVerEspecificacion.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL OBTENER AYUDA VISUAL");
                }
            }
        }
        private byte[] ayudaVisualPdfAV;
        private void CargarAV()
        {
            string nombreSeleccionado = txbEspecificacion.Text?.Trim();

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Archivo FROM elastosystem_produccion_av WHERE Nombre = @NOMBRE";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NOMBRE", nombreSeleccionado);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        ayudaVisualPdfAV = (byte[])resultado;
                    }
                    else
                    {
                        ayudaVisualPdfAV = null;
                        MessageBox.Show("NO SE ENCONTRO EL ARCHIVO PDF ASOCIADO A LA AYUDA VISUAL.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR ESPECIFICACION: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void CargarMaquinas()
        {
            cbMaquinas.Items.Clear();

            string ubicacion = "";
            if (chbNave1.Checked)
                ubicacion = "NAVE 1";
            else if (chbNave2.Checked)
                ubicacion = "NAVE 2";

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT Nombre
                                    FROM elastosystem_mtto_inventariomaquinas
                                    WHERE Ubicacion = @UBICACION
                                        AND Orden_Trabajo = TRUE
                                    ORDER BY Nombre ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UBICACION", ubicacion);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbMaquinas.Items.Add(reader["Nombre"].ToString());
                            }
                        }
                    }

                    if (cbMaquinas.Items.Count > 0)
                        cbMaquinas.SelectedIndex = 0;
                    else
                        MessageBox.Show($"No se encontraron máquinas en {ubicacion} activas.");


                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR MAQUINAS: " + ex.Message);
                }
                finally
                {

                    conn.Close();
                }
            }
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

        private void chbNave1_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNave1.Checked && chbNave2.Checked)
            {
                chbNave1.Checked = false;
            }
        }

        private void chbNave2_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNave2.Checked && chbNave1.Checked)
            {
                chbNave2.Checked = false;
            }
        }

        private void btnVerEspecificacion_Click(object sender, EventArgs e)
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
                MessageBox.Show("NO HAY ARCHIVO PDF CARGADO PARA VISUALIZAR");
            }
        }

        private void txbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCrearOT_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txbNombreArea.Text))
            {
                MessageBox.Show("EL CAMPO NOMBRE DE AREA NO PUEDE ESTAR VACÍO CONSULTA CON ADMINISTRADOR\nLO PUEDES ACTUALIZAR EN PRODUCCIÓN >> ADMINSTRAR PROCESOS >> RELACIONAR");
                return;
            }
            RevisarDatos();
        }

        private void RevisarDatos()
        {
            if(dtpFechaFinal.Value < dtpFechaInicio.Value)
            {
                MessageBox.Show("LA FECHA FINAL NO PUEDE SER MENOR A LA FECHA INICIAL");
                return;
            }

            if(!int.TryParse(txbCantidad.Text.Trim(), out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("LA CANTIDAD DEBE SER UN NÚMERO ENTERO MAYOR A CERO");
                return;
            }
            if (string.IsNullOrEmpty(txbLote.Text))
            {
                MessageBox.Show("EL CAMPO LOTE NO PUEDE ESTAR VACÍO");
                return;
            }
            RevisarMaquinas();
            
        }

        private void RevisarMaquinas()
        {
            string maquinaSeleccionada = cbMaquinas.Text?.Trim();

            if (string.IsNullOrWhiteSpace(maquinaSeleccionada))
            {
                MessageBox.Show("DEBES SELECCIONAR UNA MAQUINA ANTES DE CREAR LA ORDEN DE TRABAJO");
                return;
            }

            using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT Folio
                                    FROM elastosystem_produccion_ot
                                    WHERE Maquina = @MAQUINA
                                        AND Estatus = 'ABIERTA'
                                    LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MAQUINA", maquinaSeleccionada);

                        object resultado = cmd.ExecuteScalar();

                        if(resultado != null && resultado != DBNull.Value)
                        {
                            string folioActivo = resultado.ToString();
                            MessageBox.Show($"La máquina '{maquinaSeleccionada}' ya tiene una Orden de Trabajo activa.\n" +
                                            $"Orden de Trabajo: {folioActivo}\n" +
                                            $"Por favor, cierra esa OT antes de crear una nueva.");
                            return;
                        }
                        else
                        {
                            CrearOT();
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR AL VERIFICAR LAS MAQUINAS: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void CrearOT()
        {
            string nave = chbNave1.Checked ? "NAVE 1" : "NAVE 2";

            using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = @"INSERT INTO elastosystem_produccion_ot
                                    (Folio, FechaInicio, FechaTermino, Autorizo, Turno, Lote, Molde, Cantidad, Especificacion,
                                    Area, NombreArea, Maquina, SF, Observaciones, Nave, Estatus)
                                    VALUES
                                    (@FOLIO, @FECHAINICIO, @FECHATERMINO, @AUTORIZO, @TURNO, @LOTE, @MOLDE, @CANTIDAD, @ESPECIFICACION,
                                    @AREA, @NOMBREAREA, @MAQUINA, @SF, @OBSERVACIONES, @NAVE, @ESTATUS)";

                    using(MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FOLIO", lblFolioOT.Text.Trim());
                        cmd.Parameters.AddWithValue("@FECHAINICIO", dtpFechaInicio.Value.Date);
                        cmd.Parameters.AddWithValue("@FECHATERMINO", dtpFechaFinal.Value.Date);
                        cmd.Parameters.AddWithValue("@AUTORIZO", lblAutorizo.Text.Trim());
                        cmd.Parameters.AddWithValue("@TURNO", cbTurno.Text.Trim());
                        cmd.Parameters.AddWithValue("@LOTE", txbLote.Text.Trim());
                        cmd.Parameters.AddWithValue("@MOLDE", cbMolde.Text.Trim());
                        cmd.Parameters.AddWithValue("@CANTIDAD", int.Parse(txbCantidad.Text.Trim()));
                        cmd.Parameters.AddWithValue("@ESPECIFICACION", txbEspecificacion.Text.Trim());
                        cmd.Parameters.AddWithValue("@AREA", txbArea.Text.Trim());
                        cmd.Parameters.AddWithValue("@NOMBREAREA", txbNombreArea.Text.Trim());
                        cmd.Parameters.AddWithValue("@MAQUINA", cbMaquinas.Text.Trim());
                        cmd.Parameters.AddWithValue("@SF", txbSolicitudFabricacion.Text.Trim());
                        cmd.Parameters.AddWithValue("@OBSERVACIONES", txbObservaciones.Text.Trim());
                        cmd.Parameters.AddWithValue("@NAVE", nave);
                        cmd.Parameters.AddWithValue("@ESTATUS", "ABIERTA");

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if(filasAfectadas > 0)
                        {
                            string insertHistorico = @"
                                INSERT INTO elastosystem_produccion_ot_cambios
                                (Usuario, Fecha, Cambios, Folio, Turno_Anterior, Turno_Nuevo)
                                VALUES
                                (@USUARIO, @FECHA_INICIO, 'Creacion de OT - Turno inicial asignado', @FOLIO, NULL, @TURNO_INICIAL)";

                            using (MySqlCommand cmdHist = new MySqlCommand(insertHistorico, conn))
                            {
                                cmdHist.Parameters.AddWithValue("@USUARIO", VariablesGlobales.Usuario ?? "SISTEMA");
                                cmdHist.Parameters.AddWithValue("@FECHA_INICIO", dtpFechaInicio.Value.Date);
                                cmdHist.Parameters.AddWithValue("@FOLIO", lblFolioOT.Text.Trim());
                                cmdHist.Parameters.AddWithValue("@TURNO_INICIAL", cbTurno.Text.Trim());
                                cmdHist.ExecuteNonQuery();
                            }

                            MessageBox.Show("ORDEN DE TRABAJO CREADA EXITOSAMENTE");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("NO SE PUDO CREAR LA ORDEN DE TRABAJO, INTENTALO DE NUEVO");
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR AL CREAR ORDEN DE TRABAJO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
