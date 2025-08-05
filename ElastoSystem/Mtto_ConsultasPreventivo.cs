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
    public partial class Mtto_ConsultasPreventivo : Form
    {
        public Mtto_ConsultasPreventivo()
        {
            InitializeComponent();
        }

        private void Mtto_ConsultasPreventivo_Load(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT * FROM elastosystem_mtto_preventivohistorial WHERE Estatus = 'FINALIZADA' ORDER BY Fin DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adadptador = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adadptador.Fill(dt);
                    dgvHistorialGeneral.DataSource = dt;
                    dgvHistorialGeneral.Columns["ID"].Visible = false;
                    dgvHistorialGeneral.Columns["Estatus"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR HISTORIAL: " + ex.Message);
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
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.Visible = false;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Mtto_ConsultasPreventivo_MouseLeave(object sender, EventArgs e)
        {

        }

        private void btncerrar_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
        }

        private void txbBuscador_TextChanged(object sender, EventArgs e)
        {
            Buscador();
        }

        private void Buscador()
        {
            try
            {
                string valorBusqueda = txbBuscador.Text;

                if (string.IsNullOrWhiteSpace(valorBusqueda))
                {
                    CargarHistorial();
                    return;
                }
                else
                {
                    using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                    {
                        conn.Open();
                        string query = @"SELECT * FROM elastosystem_mtto_preventivohistorial WHERE Estatus = 'FINALIZADA' AND (Actividad LIKE @BUSCADOR OR Activo LIKE @BUSCADOR OR Quien LIKE @BUSCADOR OR Tipo LIKE @BUSCADOR) ORDER BY Fin DESC";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@BUSCADOR", "%" + valorBusqueda + "%");
                        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adaptador.Fill(dt);
                        dgvHistorialGeneral.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL BUSCAR: " + ex.Message);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFechaFinal.Value < dtpFechaInicio.Value)
                {
                    MessageBox.Show("La fecha final no puede ser anterior a la fecha inicial.");
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string query;
                    MySqlCommand cmd = new MySqlCommand();

                    if (!string.IsNullOrWhiteSpace(txbBuscador.Text))
                    {
                        query = @"SELECT * FROM elastosystem_mtto_preventivohistorial
                                    WHERE Estatus = 'FINALIZADA'
                                    AND Fin >= @FECHA_INICIO
                                    AND Fin <= @FECHA_FIN
                                    AND (Actividad LIKE @BUSCADOR OR Activo LIKE @BUSCADOR OR Quien LIKE @BUSCADOR OR Tipo LIKE @BUSCADOR)
                                    ORDER BY Fin DESC";
                        cmd.Parameters.AddWithValue("@BUSCADOR", "%" + txbBuscador.Text + "%");
                    }
                    else
                    {
                        query = @"SELECT * FROM elastosystem_mtto_preventivohistorial
                                    WHERE Estatus = 'FINALIZADA'
                                    AND Fin >= @FECHA_INICIO
                                    AND Fin <= @FECHA_FIN
                                    ORDER BY Fin DESC";
                    }

                    cmd.Parameters.AddWithValue("@FECHA_INICIO", dtpFechaInicio.Value.Date);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", dtpFechaFinal.Value.Date.AddDays(1).AddSeconds(-1));

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    dgvHistorialGeneral.DataSource = dt;
                    dgvHistorialGeneral.Columns["ID"].Visible = false;
                    dgvHistorialGeneral.Columns["Estatus"].Visible = false;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL FILTRAR: " + ex.Message);
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if(dgvHistorialGeneral.DataSource == null || dgvHistorialGeneral.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }
            ReporteExcel();
        }
        private void ReporteExcel()
        {
            try
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Guardar reporte como";
                    saveFileDialog.FileName = "Reporte.xlsx";

                    if(saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new ClosedXML.Excel.XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Reporte");

                            for(int i = 0; i < dgvHistorialGeneral.Columns.Count; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = dgvHistorialGeneral.Columns[i].HeaderText;
                            }

                            for(int i = 0; i < dgvHistorialGeneral.Rows.Count; i++)
                            {
                                for(int j = 0; j < dgvHistorialGeneral.Columns.Count; j++)
                                {
                                    worksheet.Cell(i +  2, j + 1).Value = dgvHistorialGeneral.Rows[i].Cells[j].Value?.ToString() ?? string.Empty;
                                }
                            }

                            worksheet.Columns().AdjustToContents();

                            workbook.SaveAs(saveFileDialog.FileName);

                            MessageBox.Show("Archivo Excel generado correctamente");

                            System.Diagnostics.Process.Start("explorer", saveFileDialog.FileName);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR AL EXPORTAR A EXCEL: " + ex.Message);
            }
        }
    }
}
