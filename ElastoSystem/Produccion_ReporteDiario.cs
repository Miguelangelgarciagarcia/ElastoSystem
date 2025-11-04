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
    public partial class Produccion_ReporteDiario : Form
    {
        public Produccion_ReporteDiario()
        {
            InitializeComponent();
        }

        private void Produccion_ReporteDiario_Load(object sender, EventArgs e)
        {
            CargarFecha();
            CargarN1();

            CargarTrabajadores();
        }

        private void CargarFecha()
        {
            lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy");
        }

        private void CargarN1()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = @"
                            SELECT 
                                op.Clave AS Producto,
                                ot.* 
                            FROM elastosystem_produccion_ot ot
                            INNER JOIN elastosystem_produccion_orden_produccion op
                                ON ot.SF = op.SolicitudFabricacion
                            WHERE ot.Estatus = 'ABIERTA' 
                                AND ot.Nave = 'NAVE 1'
                                AND ot.Folio NOT IN (
                                    SELECT Orden_Trabajo
                                    FROM elastosystem_produccion_registro_diario
                                    WHERE Fecha = CURDATE()
                                );";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                    {
                        DataTable dtOriginal = new DataTable();
                        adaptador.Fill(dtOriginal);

                        DataTable dtFinal = dtOriginal.Clone();

                        foreach (DataRow row in dtOriginal.Rows)
                        {
                            string turno = row["Turno"]?.ToString()?.Trim().ToUpper() ?? "";

                            if (turno == "1 TURNO")
                            {
                                DataRow nuevo = dtFinal.NewRow();
                                nuevo.ItemArray = row.ItemArray.Clone() as object[];
                                nuevo["Turno"] = "MIXTO";
                                dtFinal.Rows.Add(nuevo);
                            }
                            else if (turno == "2 TURNOS")
                            {
                                string[] turnos = { "MATUTINO", "VESPERTINO" };
                                foreach (string t in turnos)
                                {
                                    DataRow nuevo = dtFinal.NewRow();
                                    nuevo.ItemArray = row.ItemArray.Clone() as object[];
                                    nuevo["Turno"] = t;
                                    dtFinal.Rows.Add(nuevo);
                                }
                            }
                            else
                            {
                                string[] turnos = { "MATUTINO", "VESPERTINO", "NOCTURNO" };
                                foreach (string t in turnos)
                                {
                                    DataRow nuevo = dtFinal.NewRow();
                                    nuevo.ItemArray = row.ItemArray.Clone() as object[];
                                    nuevo["Turno"] = t;
                                    dtFinal.Rows.Add(nuevo);
                                }
                            }
                        }

                        dtFinal.Columns.Add("Produccion", typeof(double));
                        dtFinal.Columns.Add("Operador", typeof(string));
                        dtFinal.Columns.Add("IDOperador", typeof(string));
                        dtFinal.Columns.Add("POP", typeof(double));
                        dtFinal.Columns.Add("PNCOP", typeof(double));
                        dtFinal.Columns.Add("Reproceso", typeof(double));
                        dtFinal.Columns.Add("ObservacionesP", typeof(string));
                        dtFinal.Columns.Add("HorasTrabajadas", typeof(string));
                        dtFinal.Columns.Add("Apoyo", typeof(string));
                        dtFinal.Columns.Add("IDApoyo", typeof(string));

                        foreach (DataRow row in dtFinal.Rows)
                        {
                            row["Produccion"] = 0;
                        }

                        dgvNave1.DataSource = dtFinal;

                        dgvNave1.Columns["Producto"].DisplayIndex = 0;
                        dgvNave1.Columns["Producto"].HeaderText = "Producto";

                        dgvNave1.Columns["Produccion"].Width = 120;
                        dgvNave1.Columns["Produccion"].HeaderText = "Producción";

                        dgvNave1.Columns["NombreArea"].DisplayIndex = 1;
                        dgvNave1.Columns["NombreArea"].HeaderText = "Actividad";

                        dgvNave1.Columns["ID"].Visible = false;
                        dgvNave1.Columns["FechaInicio"].Visible = false;
                        dgvNave1.Columns["FechaTermino"].Visible = false;
                        dgvNave1.Columns["Autorizo"].Visible = false;
                        dgvNave1.Columns["Lote"].Visible = false;
                        dgvNave1.Columns["Molde"].Visible = false;
                        dgvNave1.Columns["Cantidad"].Visible = false;
                        dgvNave1.Columns["Especificacion"].Visible = false;
                        dgvNave1.Columns["Area"].Visible = false;
                        dgvNave1.Columns["SF"].Visible = false;
                        dgvNave1.Columns["Observaciones"].Visible = false;
                        dgvNave1.Columns["Nave"].Visible = false;
                        dgvNave1.Columns["Estatus"].Visible = false;

                        dgvNave1.Columns["Operador"].Visible = false;
                        dgvNave1.Columns["IDOperador"].Visible = false;
                        dgvNave1.Columns["POP"].Visible = false;
                        dgvNave1.Columns["PNCOP"].Visible = false;
                        dgvNave1.Columns["Reproceso"].Visible = false;
                        dgvNave1.Columns["ObservacionesP"].Visible = false;
                        dgvNave1.Columns["HorasTrabajadas"].Visible = false;
                        dgvNave1.Columns["Apoyo"].Visible = false;
                        dgvNave1.Columns["IDApoyo"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR ORDENES DE TRABAJO ACTIVAS DE NAVE 1: " + ex.Message);
            }
        }

        private void CargarTrabajadores()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            ID,
                            CONCAT(Nombre, ' ', Apellido_Paterno, ' ', Apellido_Materno) AS NombreCompleto
                        FROM elastosystem_rh
                        ORDER BY NombreCompleto ASC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            cbOperador.DataSource = dt.Copy();
                            cbOperador.DisplayMember = "NombreCompleto";
                            cbOperador.ValueMember = "ID";
                            cbOperador.SelectedIndex = -1;
                            cbOperador.MaxDropDownItems = 5;

                            cbOperador.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            cbOperador.AutoCompleteSource = AutoCompleteSource.CustomSource;

                            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
                            foreach (DataRow row in dt.Rows)
                            {
                                autoComplete.Add(row["NombreCompleto"].ToString());
                            }
                            cbOperador.AutoCompleteCustomSource = autoComplete;

                            cbApoyo.DataSource = dt.Copy();
                            cbApoyo.DisplayMember = "NombreCompleto";
                            cbApoyo.ValueMember = "ID";
                            cbApoyo.SelectedIndex = -1;
                            cbApoyo.MaxDropDownItems = 5;

                            cbApoyo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            cbApoyo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            cbApoyo.AutoCompleteCustomSource = autoComplete;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR TRABAJADORES: " + ex.Message);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvNave1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LimpiarN1()
        {
            txbProducto.Clear();
            txbActividad.Clear();
            txbTurnoN1.Clear();
            cbOperador.SelectedIndex = -1;
            cbApoyo.SelectedIndex = -1;
            txbMaquina.Clear();
            txbHorasTrabajadas.Clear();
            txbProductoOP.Clear();
            txbPNCOperacion.Clear();
            txbReproceso.Clear();
            txbPCTotal.Clear();
            txbObservaciones.Clear();
            lblIDOperador.Text = string.Empty;
            lblIDApoyo.Text = string.Empty;
        }

        private void dgvNave1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LimpiarN1();

            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string producto = dgv.Rows[rowIndex].Cells["Producto"].Value.ToString();
                txbProducto.Text = producto;

                string actividad = dgv.Rows[rowIndex].Cells["NombreArea"].Value.ToString();
                txbActividad.Text = actividad;

                string turno = dgv.Rows[rowIndex].Cells["Turno"].Value.ToString();
                txbTurnoN1.Text = turno;

                string maquina = dgv.Rows[rowIndex].Cells["Maquina"].Value.ToString();
                txbMaquina.Text = maquina;

                string operador = dgv.Rows[rowIndex].Cells["Operador"].Value.ToString();
                cbOperador.Text = operador;

                string horasTrabajadas = dgv.Rows[rowIndex].Cells["HorasTrabajadas"].Value.ToString();
                txbHorasTrabajadas.Text = horasTrabajadas;

                if (horasTrabajadas == "")
                {
                    if (txbTurnoN1.Text == "MIXTO")
                    {
                        txbHorasTrabajadas.Text = "9.5";
                    }
                    else
                    {
                        txbHorasTrabajadas.Text = "7.5";
                    }
                }

                string pop = dgv.Rows[rowIndex].Cells["POP"].Value.ToString();
                txbProductoOP.Text = pop;

                string pncOP = dgv.Rows[rowIndex].Cells["PNCOP"].Value.ToString();
                txbPNCOperacion.Text = pncOP;

                string reproceso = dgv.Rows[rowIndex].Cells["Reproceso"].Value.ToString();
                txbReproceso.Text = reproceso;

                string produccion = dgv.Rows[rowIndex].Cells["Produccion"].Value.ToString();
                txbPCTotal.Text = produccion;

                string observacionesP = dgv.Rows[rowIndex].Cells["ObservacionesP"].Value.ToString();
                txbObservaciones.Text = observacionesP;

                string apoyo = dgv.Rows[rowIndex].Cells["Apoyo"].Value.ToString();
                cbApoyo.Text = apoyo;
            }
        }

        private void cbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txbTurnoN1.Text == "MIXTO")
            {
                txbHorasTrabajadas.Text = "9.5";
            }
            else
            {
                txbHorasTrabajadas.Text = "7.5";
            }
        }

        private void txbHorasTrabajadas_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (char.IsControl(e.KeyChar))
                return;

            if (e.KeyChar == '.')
            {
                if (txt.Text.Contains(".") || txt.SelectionStart == 0)
                {
                    e.Handled = true;
                }
                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void cbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOperador.SelectedIndex != -1)
            {
                lblIDOperador.Text = cbOperador.SelectedValue.ToString();

                if (cbApoyo.SelectedIndex != -1 && cbApoyo.SelectedValue.ToString() == cbOperador.SelectedValue.ToString())
                {
                    MessageBox.Show("El operador y el apoyo no pueden ser la misma persona.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbApoyo.SelectedIndex = -1;
                    lblIDApoyo.Text = string.Empty;
                }
            }
            else
            {
                lblIDOperador.Text = string.Empty;
            }
        }

        private void cbOperador_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbProductoOP_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (char.IsControl(e.KeyChar))
                return;

            if (e.KeyChar == '.')
            {
                if (txt.Text.Contains(".") || txt.SelectionStart == 0)
                {
                    e.Handled = true;
                }
                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbPNCOperacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (char.IsControl(e.KeyChar))
                return;

            if (e.KeyChar == '.')
            {
                if (txt.Text.Contains(".") || txt.SelectionStart == 0)
                {
                    e.Handled = true;
                }
                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbReproceso_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (char.IsControl(e.KeyChar))
                return;

            if (e.KeyChar == '.')
            {
                if (txt.Text.Contains(".") || txt.SelectionStart == 0)
                {
                    e.Handled = true;
                }
                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbProductoOP_TextChanged(object sender, EventArgs e)
        {
            CalcularPCTotal();
        }

        private void CalcularPCTotal()
        {
            double productoOP = string.IsNullOrWhiteSpace(txbProductoOP.Text) ? 0 : Convert.ToDouble(txbProductoOP.Text);
            double pncOperacion = string.IsNullOrWhiteSpace(txbPNCOperacion.Text) ? 0 : Convert.ToDouble(txbPNCOperacion.Text);
            double reproceso = string.IsNullOrWhiteSpace(txbReproceso.Text) ? 0 : Convert.ToDouble(txbReproceso.Text);

            double total = productoOP - pncOperacion - reproceso;

            txbPCTotal.Text = total.ToString("0.##");
        }

        private void txbPNCOperacion_TextChanged(object sender, EventArgs e)
        {
            CalcularPCTotal();
        }

        private void txbReproceso_TextChanged(object sender, EventArgs e)
        {
            CalcularPCTotal();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (RevisarOperadores())
                return;

            if (RevisarTrabajadoresValidos())
                return;

            if (dgvNave1.SelectedCells.Count == 0)
            {
                MessageBox.Show("SELECCIONA UNA ORDEN DE TRABAJO PARA GUARDAR EL REGISTRO.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dgvNave1.SelectedCells[0].RowIndex;

            if (cbOperador.SelectedIndex == -1)
            {
                MessageBox.Show("SELECCIONA UN OPERADOR ANTES DE GUARDAR.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txbPCTotal.Text))
            {
                MessageBox.Show("DEBES DE INGRESAR UNA CANTDAD VALIDA PARA GUARDAR.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txbHorasTrabajadas.Text))
            {
                MessageBox.Show("DEBES DE INGRESAR LAS HORAS TRABAJADAS PARA GUARDAR.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txbProductoOP.Text))
                txbProductoOP.Text = "0";
            if (string.IsNullOrWhiteSpace(txbPNCOperacion.Text))
                txbPNCOperacion.Text = "0";
            if (string.IsNullOrWhiteSpace(txbReproceso.Text))
                txbReproceso.Text = "0";

            dgvNave1.Rows[rowIndex].Cells["Turno"].Value = txbTurnoN1.Text;
            dgvNave1.Rows[rowIndex].Cells["Operador"].Value = cbOperador.Text;
            dgvNave1.Rows[rowIndex].Cells["IDOperador"].Value = lblIDOperador.Text;
            dgvNave1.Rows[rowIndex].Cells["Produccion"].Value = Convert.ToDouble(txbPCTotal.Text);
            dgvNave1.Rows[rowIndex].Cells["POP"].Value = Convert.ToDouble(txbProductoOP.Text);
            dgvNave1.Rows[rowIndex].Cells["PNCOP"].Value = Convert.ToDouble(txbPNCOperacion.Text);
            dgvNave1.Rows[rowIndex].Cells["Reproceso"].Value = Convert.ToDouble(txbReproceso.Text);
            dgvNave1.Rows[rowIndex].Cells["ObservacionesP"].Value = txbObservaciones.Text;
            dgvNave1.Rows[rowIndex].Cells["HorasTrabajadas"].Value = txbHorasTrabajadas.Text;
            dgvNave1.Rows[rowIndex].Cells["Apoyo"].Value = cbApoyo.Text;
            dgvNave1.Rows[rowIndex].Cells["IDApoyo"].Value = lblIDApoyo.Text;

            LimpiarN1();

            dgvNave1.ClearSelection();
            dgvNave1.CurrentCell = null;
        }

        private bool RevisarOperadores()
        {
            string idOperadorActual = lblIDOperador.Text.Trim();

            if (string.IsNullOrEmpty(idOperadorActual))
                return false;

            foreach (DataGridViewRow row in dgvNave1.Rows)
            {
                if (row.IsNewRow) continue;

                string idOperadorEnFila = row.Cells["IDOperador"].Value?.ToString();

                if (!string.IsNullOrEmpty(idOperadorEnFila) && idOperadorEnFila == idOperadorActual)
                {
                    MessageBox.Show(
                        "El Operador seleccionado ya está asignado a otra orden.\nPor favor, selecciona un operador diferente.",
                        "Operador duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return true;
                }
            }
            return false;
        }

        private bool RevisarTrabajadoresValidos()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                conn.Open();

                if (cbOperador.Text.Trim() != "")
                {
                    if (string.IsNullOrWhiteSpace(lblIDOperador.Text) || !TrabajadorExiste(conn, cbOperador.Text.Trim()))
                    {
                        MessageBox.Show(
                            "El operador seleccionado no es válido o no está dado de alta en el sistema.",
                            "Trabajador inválido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return true;
                    }
                }

                if (cbApoyo.Text.Trim() != "")
                {
                    if (string.IsNullOrWhiteSpace(lblIDApoyo.Text) || !TrabajadorExiste(conn, cbApoyo.Text.Trim()))
                    {
                        MessageBox.Show(
                            "El trabador de apoyo seleccionado no es válido o no está dado de alta en el sistema.",
                            "Trabajador inválido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return true;
                    }
                }
            }

            return false;
        }

        private bool TrabajadorExiste(MySqlConnection conn, string nombreCompleto)
        {
            string query = @"
                SELECT COUNT(*)
                FROM elastosystem_rh
                WHERE CONCAT(Nombre, ' ', Apellido_Paterno, ' ', Apellido_Materno) = @NOMBRECOMPLETO;";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NOMBRECOMPLETO", nombreCompleto);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void btnFirmarReporteN1_Click(object sender, EventArgs e)
        {
            List<string> registrosIncompletos = new List<string>();

            foreach (DataGridViewRow row in dgvNave1.Rows)
            {
                if (row.IsNewRow) continue;

                double produccion = 0;
                double.TryParse(row.Cells["Produccion"].Value?.ToString(), out produccion);

                string operador = row.Cells["Operador"].Value?.ToString();

                if (produccion == 0 && string.IsNullOrWhiteSpace(operador))
                {
                    string producto = row.Cells["Producto"].Value?.ToString() ?? "(Sin Producto)";
                    string actividad = row.Cells["NombreArea"].Value?.ToString() ?? "(Sin Actividad)";
                    registrosIncompletos.Add($"• {producto} - {actividad}");
                }
            }

            if (registrosIncompletos.Count > 0)
            {
                string mensaje = "Se detectaron las siguientes órdenes sin datos completos: \n\n" +
                                    string.Join("\n", registrosIncompletos) +
                                    "\n\n¿Desea continuar de todos modos?";

                DialogResult respuesta = MessageBox.Show(mensaje, "Registros Incompletos", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.No)
                {
                    return;
                }
            }
            RegistrarN1();
        }

        private void RegistrarN1()
        {
            int registrosInsertados = 0;

            try
            {
                using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string insertQuery = @"
                        INSERT INTO elastosystem_produccion_registro_diario
                        (Orden_Trabajo, Fecha, Turno, Horas, Maquina, Molde, ID_Operador, ID_Apoyo, POP, PNCOP, Reproceso, Observaciones, Firma)
                        VALUES
                        (@ORDENTRABAJO, @FECHA, @TURNO, @HORAS, @MAQUINA, @MOLDE, @IDOPERADOR, @IDAPOYO, @POP, @PNCOP, @REPROCESO, @OBSERVACIONES, @FIRMA);";

                    using(MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        foreach (DataGridViewRow row in dgvNave1.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string idOperador = row.Cells["IDOperador"].Value?.ToString();

                            if (string.IsNullOrWhiteSpace(idOperador))
                                continue;

                            string ordenTrabajo = row.Cells["Folio"].Value?.ToString();
                            string turno = row.Cells["Turno"].Value?.ToString() ?? "";
                            string horas = row.Cells["HorasTrabajadas"].Value?.ToString() ?? "0";
                            string maquina = row.Cells["Maquina"].Value?.ToString() ?? "";
                            string molde = row.Cells["Molde"].Value?.ToString() ?? "";
                            string idApoyo = row.Cells["IDApoyo"].Value?.ToString();
                            double pop = Convert.ToDouble(row.Cells["POP"].Value ?? 0);
                            double pncop = Convert.ToDouble(row.Cells["PNCOP"].Value ?? 0);
                            double reproceso = Convert.ToDouble(row.Cells["Reproceso"].Value ?? 0);
                            string observaciones = row.Cells["ObservacionesP"].Value?.ToString() ?? "";
                            string firma = VariablesGlobales.Usuario;

                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@ORDENTRABAJO", ordenTrabajo);
                            cmd.Parameters.AddWithValue("@FECHA", DateTime.Now.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@TURNO", turno);
                            cmd.Parameters.AddWithValue("@HORAS", horas);
                            cmd.Parameters.AddWithValue("@MAQUINA", maquina);
                            cmd.Parameters.AddWithValue("@MOLDE", molde);
                            cmd.Parameters.AddWithValue("@IDOPERADOR", idOperador);
                            cmd.Parameters.AddWithValue("@IDAPOYO", string.IsNullOrWhiteSpace(idApoyo) ? DBNull.Value : (object)idApoyo);
                            cmd.Parameters.AddWithValue("@POP", pop);
                            cmd.Parameters.AddWithValue("@PNCOP", pncop);
                            cmd.Parameters.AddWithValue("@REPROCESO", reproceso);
                            cmd.Parameters.AddWithValue("@OBSERVACIONES", observaciones);
                            cmd.Parameters.AddWithValue("@FIRMA", firma);

                            registrosInsertados += cmd.ExecuteNonQuery(); 
                        }
                    }
                }

                MessageBox.Show("REGISTRO OK");
                //RegistroOK();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR AL GUARDAR EL REPORTE DE NAVE 1: " + ex.Message);
            }
        }

        private void cbApoyo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbApoyo.SelectedIndex != -1)
            {
                lblIDApoyo.Text = cbApoyo.SelectedValue.ToString();

                if (cbOperador.SelectedIndex != -1 && cbOperador.SelectedValue.ToString() == cbApoyo.SelectedValue.ToString())
                {
                    MessageBox.Show("El apoyo no puede ser el mismo que el operador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbApoyo.SelectedIndex = -1;
                    lblIDApoyo.Text = string.Empty;
                }
            }
            else
            {
                lblIDApoyo.Text = string.Empty;
            }
        }

        private void dgvNave1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvNave1.ClearSelection();
        }
    }
}
