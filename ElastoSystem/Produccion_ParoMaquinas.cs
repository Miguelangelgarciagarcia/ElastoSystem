using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElastoSystem
{
    public partial class Produccion_ParoMaquinas : Form
    {
        public string Nave { get; set; }
        public string FechaTexto { get; set; }
        public DateTime Fecha { get; set; }
        public Produccion_ParoMaquinas()
        {
            InitializeComponent();
        }

        private void Produccion_ParoMaquinas_Load(object sender, EventArgs e)
        {
            lblNave.Text = Nave;
            lblFecha.Text = FechaTexto;
            CargarMaquinas();
            CargarFallas();
            CargarParosDelDia();
            txbHoraInicio.Text = "__:__";
            txbHoraFinal.Text = "__:__";
        }

        private void CargarMaquinas()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string query = @"
                        SELECT ID, Nombre
                        FROM elastosystem_mtto_inventariomaquinas
                        WHERE Indicador = 1
                            AND Ubicacion = @NAVE
                        ORDER BY Nombre ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NAVE", Nave);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dtMaquinas = new DataTable();
                            da.Fill(dtMaquinas);

                            cbMaquinas.DataSource = null;
                            cbMaquinas.Items.Clear();

                            cbMaquinas.DataSource = dtMaquinas;
                            cbMaquinas.DisplayMember = "Nombre";
                            cbMaquinas.ValueMember = "ID";
                            cbMaquinas.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las máquinas:\n" + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarFallas()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string query = @"
                        SELECT Codigo, Falla, CONCAT(Codigo, ' - ', Falla) AS CodigoFalla
                        FROM elastosystem_produccion_fallas
                        ORDER BY ID ASC";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dtFallas = new DataTable();
                        da.Fill(dtFallas);

                        cbFalla.DataSource = dtFallas;
                        cbFalla.DisplayMember = "CodigoFalla";
                        cbFalla.ValueMember = "Codigo";
                        cbFalla.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las fallas:\n" + ex.Message, "Error de coneción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarParosDelDia()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            p.ID,
                            m.Nombre AS NombreMaquina,
                            CONCAT(f.Codigo, ' - ', f.Falla) AS FallaCompleta,
                            DATE_FORMAT(p.Hora_Inicio, '%H:%i') AS HoraInicioStr,
                            DATE_FORMAT(p.Hora_Fin, '%H:%i') AS HoraFinStr,
                            p.Observaciones
                        FROM elastosystem_produccion_paros p
                        INNER JOIN elastosystem_mtto_inventariomaquinas m ON p.ID_Maquina = m.ID
                        INNER JOIN elastosystem_produccion_fallas f ON p.Codigo_Falla = f.Codigo
                        WHERE p.Fecha = @FECHA
                            AND p.Nave = @NAVE
                        ORDER BY p.Hora_Inicio ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FECHA", Fecha.Date);
                        cmd.Parameters.AddWithValue("@NAVE", Nave);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dtParos = new DataTable();
                            da.Fill(dtParos);

                            dgvParosMaquinas.DataSource = dtParos;

                            if (dgvParosMaquinas.Columns.Count > 0)
                            {
                                dgvParosMaquinas.Columns["ID"].Visible = false;
                                dgvParosMaquinas.Columns["NombreMaquina"].HeaderText = "Máquina";
                                dgvParosMaquinas.Columns["FallaCompleta"].HeaderText = "Falla";
                                dgvParosMaquinas.Columns["HoraInicioStr"].HeaderText = "Inicio";
                                dgvParosMaquinas.Columns["HoraFinStr"].HeaderText = "Fin";

                                dgvParosMaquinas.Columns["HoraInicioStr"].Width = 80;
                                dgvParosMaquinas.Columns["HoraFinStr"].Width = 80;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los paros del día:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Visible = false;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncerrar_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
        }

        private void cbMaquinas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void txbHoraFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    string digitos = txbHoraFinal.Text.Replace(":", "").Replace("_", "");
                    if (digitos.Length > 0)
                        digitos = digitos.Substring(0, digitos.Length - 1);

                    txbHoraFinal.Text = FormatearHoraConPlaceholder(digitos);
                    txbHoraFinal.SelectionStart = txbHoraFinal.Text.Length;
                    e.Handled = true;
                }
                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            e.Handled = true;

            string numeros = txbHoraFinal.Text.Replace(":", "").Replace("_", "");

            if (numeros.Length >= 4)
                return;

            numeros += e.KeyChar;

            txbHoraFinal.Text = FormatearHoraConPlaceholder(numeros);
            txbHoraFinal.SelectionStart = txbHoraFinal.Text.Length;
        }

        private string FormatearHoraConPlaceholder(string digitos)
        {
            digitos = digitos.PadRight(4, '_').Substring(0, 4);

            string hora = digitos.Substring(0, 2);
            string minuto = digitos.Substring(2, 2);

            return hora + ":" + minuto;
        }

        private void txbHoraInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    string digitos = txbHoraInicio.Text.Replace(":", "").Replace("_", "");
                    if (digitos.Length > 0)
                        digitos = digitos.Substring(0, digitos.Length - 1);

                    txbHoraInicio.Text = FormatearHoraConPlaceholder(digitos);
                    txbHoraInicio.SelectionStart = txbHoraInicio.Text.Length;
                    e.Handled = true;
                }
                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            e.Handled = true;

            string numeros = txbHoraInicio.Text.Replace(":", "").Replace("_", "");

            if (numeros.Length >= 4)
                return;

            numeros += e.KeyChar;

            txbHoraInicio.Text = FormatearHoraConPlaceholder(numeros);
            txbHoraInicio.SelectionStart = txbHoraInicio.Text.Length;
        }

        private void btnRegistrarParo_Click(object sender, EventArgs e)
        {
            if (cbMaquinas.SelectedIndex == -1 || cbMaquinas.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona una máquina.", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbMaquinas.Focus();
                return;
            }

            if (cbFalla.SelectedIndex == -1 || cbFalla.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona el tipo de falla.", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbFalla.Focus();
                return;
            }

            if (!EsHoraValida(txbHoraInicio.Text))
            {
                MessageBox.Show("La hora de inicio no es válida o está incompleta.\nFormato correcto: HH:MM (ej. 08:30)", "Hora incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbHoraInicio.Focus();
                txbHoraInicio.SelectAll();
                return;
            }

            if (!EsHoraValida(txbHoraFinal.Text))
            {
                MessageBox.Show("La hora final no es válida o está incompleta.\nFormato correcto: HH:MM (ej. 16:45)", "Hora incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbHoraFinal.Focus();
                txbHoraFinal.SelectAll();
                return;
            }

            TimeSpan horaInicio = TimeSpan.Parse(txbHoraInicio.Text);
            TimeSpan horaFinal = TimeSpan.Parse(txbHoraFinal.Text);

            if (horaFinal <= horaInicio)
            {
                MessageBox.Show("La hora final debe ser mayor que la hora de inicio.\n" +
                                $"Ejemplo válido: 08:00 → 16:00\n" +
                                $"No permitido: {txbHoraInicio.Text} → {txbHoraFinal.Text}", "Orden de horas incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbHoraFinal.Focus();
                txbHoraFinal.SelectAll();
                return;
            }

            int idMaquina = Convert.ToInt32(cbMaquinas.SelectedValue);
            string codigoFalla = cbFalla.SelectedValue.ToString();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string queryDuplicadoExacto = @"
                        SELECT COUNT(*)
                        FROM elastosystem_produccion_paros
                        WHERE ID_Maquina = @ID_MAQUINA
                            AND Codigo_Falla = @CODIGO_FALLA
                            AND Fecha = @FECHA
                            AND (
                                (Hora_Inicio <= @HORA_INICIO AND Hora_Fin > @HORA_INICIO) OR
                                (Hora_Inicio < @HORA_FIN AND Hora_Fin >= @HORA_FIN) OR
                                (Hora_Inicio >= @HORA_INICIO AND Hora_Fin <= @HORA_FIN)
                            )";

                    using (MySqlCommand cmdDup = new MySqlCommand(queryDuplicadoExacto, conn))
                    {
                        cmdDup.Parameters.AddWithValue("@ID_MAQUINA", idMaquina);
                        cmdDup.Parameters.AddWithValue("@CODIGO_FALLA", codigoFalla);
                        cmdDup.Parameters.AddWithValue("@FECHA", Fecha.Date);
                        cmdDup.Parameters.AddWithValue("@HORA_INICIO", horaInicio);
                        cmdDup.Parameters.AddWithValue("@HORA_FIN", horaFinal);

                        if (Convert.ToInt32(cmdDup.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("Ya existe un paro registrado con la misma máquina y misma falla en este rango de horario.", "Duplicado no permitido", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    string querySolapado = @"
                        SELECT COUNT(*)
                        FROM elastosystem_produccion_paros
                        WHERE ID_Maquina = @ID_MAQUINA
                            AND Codigo_Falla <> @CODIGO_FALLA
                            AND Fecha = @FECHA
                            AND (
                                (Hora_Inicio <= @HORA_INICIO AND Hora_Fin > @HORA_INICIO) OR
                                (Hora_Inicio < @HORA_FIN AND Hora_Fin >= @HORA_FIN) OR
                                (Hora_Inicio >= @HORA_INICIO AND Hora_Fin <= @HORA_FIN)
                            )";

                    using (MySqlCommand cmdSol = new MySqlCommand(querySolapado, conn))
                    {
                        cmdSol.Parameters.AddWithValue("@ID_MAQUINA", idMaquina);
                        cmdSol.Parameters.AddWithValue("@CODIGO_FALLA", codigoFalla);
                        cmdSol.Parameters.AddWithValue("@FECHA", Fecha.Date);
                        cmdSol.Parameters.AddWithValue("@HORA_INICIO", horaInicio);
                        cmdSol.Parameters.AddWithValue("@HORA_FIN", horaFinal);

                        if (Convert.ToInt32(cmdSol.ExecuteScalar()) > 0)
                        {
                            var dr = MessageBox.Show(
                                "Ya existe otro paro en esta máquina con diferente falla en este horario.\n\n¿Deseas continuar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr != DialogResult.Yes) return;
                        }
                    }

                    string insert = @"
                        INSERT INTO elastosystem_produccion_paros
                        (Nave, ID_Maquina, Codigo_Falla, Hora_Inicio, Hora_Fin, Observaciones, Fecha)
                        VALUES
                        (@NAVE, @ID_MAQUINA, @CODIGO_FALLA, @HORA_INICIO, @HORA_FIN, @OBS, @FECHA)";

                    using (MySqlCommand cmdInsert = new MySqlCommand(insert, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@NAVE", Nave);
                        cmdInsert.Parameters.AddWithValue("@ID_MAQUINA", idMaquina);
                        cmdInsert.Parameters.AddWithValue("@CODIGO_FALLA", codigoFalla);
                        cmdInsert.Parameters.AddWithValue("@HORA_INICIO", horaInicio);
                        cmdInsert.Parameters.AddWithValue("@HORA_FIN", horaFinal);
                        cmdInsert.Parameters.AddWithValue("@OBS", txbObservaciones?.Text.Trim() ?? "");
                        cmdInsert.Parameters.AddWithValue("@FECHA", Fecha.Date);

                        cmdInsert.ExecuteNonQuery();
                    }
                    CargarParosDelDia();
                    cbMaquinas.SelectedIndex = -1;
                    cbFalla.SelectedIndex = -1;
                    txbHoraInicio.Text = "__:__";
                    txbHoraFinal.Text = "__:__";
                    if (txbObservaciones != null) txbObservaciones.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el paro:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool EsHoraValida(string textoHora)
        {
            if (textoHora.Contains("_") || textoHora.Length != 5 || textoHora[2] != ':')
                return false;

            string[] partes = textoHora.Split(':');
            if (!int.TryParse(partes[0], out int hora) || !int.TryParse(partes[1], out int minuto))
                return false;

            return hora >= 0 && hora <= 23 && minuto >= 0 && minuto <= 59;
        }

        private void dgvParosMaquinas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvParosMaquinas.ClearSelection();
        }

        private void dgvParosMaquinas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewRow fila = dgvParosMaquinas.Rows[e.RowIndex];
            int idParo = Convert.ToInt32(fila.Cells["ID"].Value);

            string maquina = fila.Cells["NombreMaquina"].Value.ToString();
            string falla = fila.Cells["FallaCompleta"].Value.ToString();
            string horario = $"{fila.Cells["HoraInicioStr"].Value} - {fila.Cells["HoraFinStr"].Value}";

            DialogResult resultado = MessageBox.Show(
                $"¿Estás seguro de eliminar este paro?\n\n" +
                $"Máquina: {maquina}\n" +
                $"Falla: {falla}\n" +
                $"Horario: {horario}\n" +
                $"Fecha: {Fecha:dd/MM/yyyy}",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (resultado != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM elastosystem_produccion_paros WHERE ID = @ID";

                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", idParo);
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if(filasAfectadas > 0)
                        {
                            MessageBox.Show("Paro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarParosDelDia();
                            cbMaquinas.SelectedIndex = -1;
                            cbFalla.SelectedIndex = -1;
                            txbHoraInicio.Text = "__:__";
                            txbHoraFinal.Text = "__:__";
                            txbObservaciones.Clear();
                            cbMaquinas.Focus();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el paro. Puede que ya no exista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el paro:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
