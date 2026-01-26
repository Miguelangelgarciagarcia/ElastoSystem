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
    public partial class Mtto_CerrarMultiple_Preventivo : Form
    {
        private readonly List<DataGridViewRow> filasSeleccionadas;
        private readonly Mtto_ActividadesDia formPadre;

        public Mtto_CerrarMultiple_Preventivo(List<DataGridViewRow> filas, Mtto_ActividadesDia padre = null)
        {
            InitializeComponent();
            this.filasSeleccionadas = filas ?? new List<DataGridViewRow>();
            this.formPadre = padre;

            if (dgvACerrar.Columns.Count == 0 && formPadre != null && filasSeleccionadas.Count > 0)
            {
                foreach (DataGridViewColumn col in formPadre.PendientesGrid.Columns)
                {
                    var nuevaCol = (DataGridViewColumn)col.Clone();
                    dgvACerrar.Columns.Add(nuevaCol);
                }

                if (!dgvACerrar.Columns.Contains("Periodicidad"))
                {
                    var colPeriodicidad = new DataGridViewTextBoxColumn
                    {
                        Name = "Periodicidad",
                        HeaderText = "Periodicidad"
                    };
                    dgvACerrar.Columns.Add(colPeriodicidad);
                }
            }

            CopiarFilasSeleccionadas();
        }

        private void CopiarFilasSeleccionadas()
        {
            dgvACerrar.Rows.Clear();

            foreach (DataGridViewRow filaOrigen in filasSeleccionadas)
            {
                if (filaOrigen.IsNewRow) continue;

                int indiceNueva = dgvACerrar.Rows.Add();
                DataGridViewRow filaNueva = dgvACerrar.Rows[indiceNueva];

                foreach (DataGridViewCell celdaOrigen in filaOrigen.Cells)
                {
                    string colName = celdaOrigen.OwningColumn.Name;
                    if (dgvACerrar.Columns.Contains(colName))
                    {
                        filaNueva.Cells[colName].Value = celdaOrigen.Value;
                    }
                }
            }

            CargarPeriodicidadEnGrid();

            dgvACerrar.Columns["Tipo"].Visible = false;
        }

        private void CargarPeriodicidadEnGrid()
        {
            if (dgvACerrar.Rows.Count == 0) return;

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dgvACerrar.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string tipo = row.Cells["Tipo"]?.Value?.ToString() ?? "";
                        string activo = row.Cells["Activo"]?.Value?.ToString() ?? "";
                        string actividad = row.Cells["Actividad"]?.Value?.ToString() ?? "";

                        if (string.IsNullOrWhiteSpace(tipo) || string.IsNullOrWhiteSpace(activo) || string.IsNullOrWhiteSpace(actividad))
                            continue;

                        string query = @"
                            SELECT Periodicidad
                            FROM elastosystem_mtto_actividadesxactivo
                            WHERE Tipo = @TIPO
                                AND Activo = @ACTIVO
                                AND Actividad = @ACTIVIDAD
                            LIMIT 1";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@TIPO", tipo);
                            cmd.Parameters.AddWithValue("@ACTIVO", activo);
                            cmd.Parameters.AddWithValue("@ACTIVIDAD", actividad);

                            object result = cmd.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                            {
                                row.Cells["Periodicidad"].Value = result.ToString();
                            }
                            else
                            {
                                MessageBox.Show("ERROR");
                            }
                        }
                    }
                    dgvACerrar.Columns["Periodicidad"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar periodicidad:\n" + ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.Visible = false;
        }

        private void btncerrar_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (txbRealizo.Text.Trim() == "")
            {
                MessageBox.Show("Debes de ingresar el nombre de la persona que realizó las actividades.", "Información incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FinalizacionMultiple();
        }

        private void FinalizacionMultiple()
        {
            if (dgvACerrar.Rows.Count == 0)
            {
                MessageBox.Show("No hay actividades para finalizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string quien = txbRealizo.Text.Trim();
            string observaciones = txbObservaciones.Text.Trim();
            DateTime fechaCierre = dtpFechaCierre.Value.Date;

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dgvACerrar.Rows)
                    {
                        if (row.IsNewRow) continue;

                        if (!int.TryParse(row.Cells["ID"]?.Value?.ToString(), out int id)) continue;

                        string tipo         = row.Cells["Tipo"]?.Value?.ToString() ?? "";
                        string activo       = row.Cells["Activo"]?.Value?.ToString() ?? "";
                        string actividad    = row.Cells["Actividad"]?.Value?.ToString() ?? "";
                        string perioStr     = row.Cells["Periodicidad"]?.Value?.ToString() ?? "0";

                        if (string.IsNullOrWhiteSpace(tipo) || string.IsNullOrWhiteSpace(activo) || string.IsNullOrWhiteSpace(actividad))
                            continue;

                        string updateQuery = @"
                            UPDATE elastosystem_mtto_preventivohistorial
                            SET Fin = @FIN,
                                Quien = @QUIEN,
                                Observaciones = @OBSERVACIONES,
                                Estatus = @ESTATUS
                            WHERE ID = @ID";

                        using (MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, conn))
                        {
                            cmdUpdate.Parameters.AddWithValue("@FIN", fechaCierre.ToString("yyyy-MM-dd"));
                            cmdUpdate.Parameters.AddWithValue("@QUIEN", quien);
                            cmdUpdate.Parameters.AddWithValue("@OBSERVACIONES", observaciones);
                            cmdUpdate.Parameters.AddWithValue("@ESTATUS", "FINALIZADA");
                            cmdUpdate.Parameters.AddWithValue("@ID", id);

                            cmdUpdate.ExecuteNonQuery();
                        }

                        if (!int.TryParse(perioStr, out int periodicidadDias) || periodicidadDias <= 0)
                        {
                            MessageBox.Show("ERROR EN PERIODICIDAD");
                            continue;
                        }

                        DateTime proximaFecha = fechaCierre.AddDays(periodicidadDias);

                        string insertQuery = @"
                            INSERT INTO elastosystem_mtto_preventivohistorial
                            (Tipo, Activo, Actividad, Inicio, Estatus)
                            VALUES (@TIPO, @ACTIVO, @ACTIVIDAD, @INICIO, @ESTATUS)";

                        using (MySqlCommand cmdInsert = new MySqlCommand(insertQuery, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@TIPO", tipo);
                            cmdInsert.Parameters.AddWithValue("@ACTIVO", activo);
                            cmdInsert.Parameters.AddWithValue("@ACTIVIDAD", actividad);
                            cmdInsert.Parameters.AddWithValue("@INICIO", proximaFecha.ToString("yyyy-MM-dd"));
                            cmdInsert.Parameters.AddWithValue("@ESTATUS", "ACTIVO");

                            cmdInsert.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"Se finalizaron {dgvACerrar.Rows.Count} actividades correctamente y se generaron los próximos mantenimientos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error durante la finalización múltiple:\n" + ex.Message, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
