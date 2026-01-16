using DocumentFormat.OpenXml.Office2016.Drawing.Command;
using DocumentFormat.OpenXml.Presentation;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace ElastoSystem
{
    public partial class Produccion_ReporteDiario : Form
    {
        private DateTime fechaMostrada;

        public Produccion_ReporteDiario()
        {
            InitializeComponent();
        }

        private void Produccion_ReporteDiario_Load(object sender, EventArgs e)
        {
            fechaMostrada = DateTime.Today;
            ActualizarLabelFecha();
            CargarTrabajadores();
            CargarPendientesN1();
            CargarRegistradosN1();
        }

        private void ActualizarLabelFecha()
        {
            var cultura = new CultureInfo("es-MX");
            string diaSemana = cultura.TextInfo.ToTitleCase(fechaMostrada.ToString("dddd", cultura));
            string mes = cultura.TextInfo.ToTitleCase(fechaMostrada.ToString("MMMM", cultura));
            lblFechaN1.Text = $"{diaSemana} {fechaMostrada.Day} de {mes} del {fechaMostrada:yyyy}";
        }

        private void ActualizarLabelFecha2()
        {
            var cultura = new CultureInfo("es-MX");
            string diaSemana = cultura.TextInfo.ToTitleCase(fechaMostrada.ToString("dddd", cultura));
            string mes = cultura.TextInfo.ToTitleCase(fechaMostrada.ToString("MMMM", cultura));
            lblFechaN2.Text = $"{diaSemana} {fechaMostrada.Day} de {mes} del {fechaMostrada:yyyy}";
        }

        private void CargarPendientesN1()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string queryOTs = @"
                            SELECT 
                                op.Clave AS Producto,
                                ot.Folio,
                                ot.Turno,
                                ot.NombreArea,
                                ot.Maquina,
                                ot.Molde
                            FROM elastosystem_produccion_ot ot
                            INNER JOIN elastosystem_produccion_orden_produccion op 
                                ON ot.SF = op.SolicitudFabricacion
                            WHERE ot.Estatus = 'ABIERTA' 
                                AND ot.Nave = 'NAVE 1'
                                AND @FECHA >= ot.FechaInicio;";

                    DataTable dtOriginal = new DataTable();
                    using (MySqlCommand cmd = new MySqlCommand(queryOTs, conn))
                    {
                        cmd.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);
                        new MySqlDataAdapter(cmd).Fill(dtOriginal);
                    }

                    string queryRegistrados = @"
                        SELECT Orden_Trabajo, Turno
                        FROM elastosystem_produccion_registro_diario
                        WHERE DATE(Fecha) = @FECHA;";

                    DataTable dtRegistrados = new DataTable();
                    using (MySqlCommand cmdReg = new MySqlCommand(queryRegistrados, conn))
                    {
                        cmdReg.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);
                        new MySqlDataAdapter(cmdReg).Fill(dtRegistrados);
                    }

                    DataTable dtFinal = dtOriginal.Clone();

                    foreach (DataRow row in dtOriginal.Rows)
                    {
                        string folio = row["Folio"].ToString();
                        string turnoActual = row["Turno"].ToString().Trim().ToUpper();

                        string turnoVigente = turnoActual;

                        string queryHistorico = @"
                            SELECT Turno_Nuevo
                            FROM elastosystem_produccion_ot_cambios
                            WHERE Folio = @FOLIO
                                AND Fecha <= @FECHA
                                AND Turno_Nuevo IS NOT NULL
                            ORDER BY Fecha DESC, ID DESC
                            LIMIT 1;";

                        using (MySqlCommand cmdHist = new MySqlCommand(queryHistorico, conn))
                        {
                            cmdHist.Parameters.AddWithValue("@FOLIO", folio);
                            cmdHist.Parameters.AddWithValue("@FECHA", fechaMostrada.Date.AddDays(1).AddSeconds(-1));
                            object result = cmdHist.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                turnoVigente = result.ToString().Trim().ToUpper();
                            }
                        }

                        var turnosRegistradosHoy = dtRegistrados.AsEnumerable()
                            .Where(r => r["Orden_Trabajo"].ToString() == folio)
                            .Select(r => r["Turno"].ToString().Trim().ToUpper())
                            .ToList();

                        string[] turnosEsperados;
                        if (turnoVigente == "1 TURNO")
                        {
                            turnosEsperados = new[] { "MIXTO" };
                        }
                        else if (turnoVigente == "2 TURNOS")
                        {
                            turnosEsperados = new[] { "MATUTINO", "VESPERTINO" };
                        }
                        else
                        {
                            turnosEsperados = new[] { "MATUTINO", "VESPERTINO", "NOCTURNO" }; 
                        }

                        foreach (string turnoEsperado in turnosEsperados)
                        {
                            if (!turnosRegistradosHoy.Contains(turnoEsperado))
                            {
                                var nuevo = dtFinal.NewRow();
                                nuevo.ItemArray = row.ItemArray.Clone() as object[];
                                nuevo["Turno"] = turnoEsperado;
                                dtFinal.Rows.Add(nuevo);
                            }
                        }
                    }

                    var ordenDeseado = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
                    {
                        { "MATUTINO", 1},
                        { "MIXTO", 2 },
                        { "VESPERTINO", 3 },
                        { "NOCTURNO", 4 }
                    };

                    var filasOrdenadas = dtFinal.AsEnumerable()
                        .OrderBy(r => ordenDeseado.ContainsKey(r["Turno"].ToString()) ? ordenDeseado[r["Turno"].ToString()] : 99)
                        .ThenBy(r => r["Maquina"])
                        .ToList();

                    DataTable dtOrdenado = dtFinal.Clone();
                    foreach (var row in filasOrdenadas)
                        dtOrdenado.ImportRow(row);

                    dgvPendientesNave1.DataSource = dtOrdenado;

                    dgvPendientesNave1.Columns["Turno"].DisplayIndex = 0;
                    dgvPendientesNave1.Columns["Maquina"].DisplayIndex = 1;
                    dgvPendientesNave1.Columns["Producto"].DisplayIndex = 2;
                    dgvPendientesNave1.Columns["NombreArea"].DisplayIndex = 3;

                    dgvPendientesNave1.Columns["Producto"].HeaderText = "Producto";
                    dgvPendientesNave1.Columns["Folio"].Visible = false;
                    dgvPendientesNave1.Columns["NombreArea"].HeaderText = "Actividad";
                    dgvPendientesNave1.Columns["Molde"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR PENDIENTES: " + ex.Message);
            }
        }

        private void CargarPendientesN2()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string queryOTs = @"
                            SELECT 
                                op.Clave AS Producto,
                                ot.Folio,
                                ot.Turno,
                                ot.NombreArea,
                                ot.Maquina,
                                ot.Molde
                            FROM elastosystem_produccion_ot ot
                            INNER JOIN elastosystem_produccion_orden_produccion op ON ot.SF = op.SolicitudFabricacion
                            WHERE ot.Estatus = 'ABIERTA' 
                                AND ot.Nave = 'NAVE 2'
                                AND @FECHA >= ot.FechaInicio;";

                    DataTable dtOriginal = new DataTable();
                    using (MySqlCommand cmd = new MySqlCommand(queryOTs, conn))
                    {
                        cmd.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);
                        new MySqlDataAdapter(cmd).Fill(dtOriginal);
                    }

                    string queryRegistrados = @"
                        SELECT Orden_Trabajo, Turno
                        FROM elastosystem_produccion_registro_diario
                        WHERE DATE(Fecha) = @FECHA;";

                    DataTable dtRegistrados = new DataTable();
                    using (MySqlCommand cmdReg = new MySqlCommand(queryRegistrados, conn))
                    {
                        cmdReg.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);
                        new MySqlDataAdapter(cmdReg).Fill(dtRegistrados);
                    }

                    DataTable dtFinal = dtOriginal.Clone();

                    foreach (DataRow row in dtOriginal.Rows)
                    {
                        string folio = row["Folio"].ToString();
                        string turnoOT = (row["Turno"]?.ToString() ?? "").Trim().ToUpper();

                        var turnosRegistrados = dtRegistrados.AsEnumerable()
                            .Where(r => r["Orden_Trabajo"].ToString() == folio)
                            .Select(r => r["Turno"].ToString().Trim().ToUpper())
                            .ToList();

                        if (turnoOT == "1 TURNO")
                        {
                            if (!turnosRegistrados.Contains("MIXTO"))
                            {
                                var nuevo = dtFinal.NewRow();
                                nuevo.ItemArray = row.ItemArray.Clone() as object[];
                                nuevo["Turno"] = "MIXTO";
                                dtFinal.Rows.Add(nuevo);
                            }
                        }
                        else if (turnoOT == "2 TURNOS")
                        {
                            string[] posibles = { "MATUTINO", "VESPERTINO" };
                            foreach (string t in posibles)
                                if (!turnosRegistrados.Contains(t))
                                {
                                    var nuevo = dtFinal.NewRow();
                                    nuevo.ItemArray = row.ItemArray.Clone() as object[];
                                    nuevo["Turno"] = t;
                                    dtFinal.Rows.Add(nuevo);
                                }
                        }
                        else
                        {
                            string[] posibles = { "MATUTINO", "VESPERTINO", "NOCTURNO" };
                            foreach (string t in posibles)
                                if (!turnosRegistrados.Contains(t))
                                {
                                    var nuevo = dtFinal.NewRow();
                                    nuevo.ItemArray = row.ItemArray.Clone() as object[];
                                    nuevo["Turno"] = t;
                                    dtFinal.Rows.Add(nuevo);
                                }
                        }
                    }

                    var ordenDeseado = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
                    {
                        { "MATUTINO", 1},
                        { "MIXTO", 2},
                        { "VESPERTINO", 3},
                        { "NOCTURNO", 4}
                    };

                    var filasOrdenadas = dtFinal.AsEnumerable()
                        .OrderBy(r => ordenDeseado.ContainsKey(r["Turno"].ToString()) ? ordenDeseado[r["Turno"].ToString()] : 99)
                        .ThenBy(r => r["Maquina"])
                        .ToList();

                    DataTable dtOrdenado = dtFinal.Clone();
                    foreach (var row in filasOrdenadas)
                        dtOrdenado.ImportRow(row);

                    dgvPendientesNave2.DataSource = dtOrdenado;

                    dgvPendientesNave2.Columns["Turno"].DisplayIndex = 0;
                    dgvPendientesNave2.Columns["Maquina"].DisplayIndex = 1;
                    dgvPendientesNave2.Columns["Producto"].DisplayIndex = 2;
                    dgvPendientesNave2.Columns["NombreArea"].DisplayIndex = 3;

                    dgvPendientesNave2.Columns["Producto"].HeaderText = "Producto";
                    dgvPendientesNave2.Columns["Folio"].Visible = false;
                    dgvPendientesNave2.Columns["NombreArea"].HeaderText = "Actividad";
                    dgvPendientesNave2.Columns["Molde"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR PENDIENTES: " + ex.Message);
            }
        }

        private void CargarRegistradosN1()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            r.ID, r.Orden_Trabajo, r.Turno, r.Maquina,
                            r.ID_Operador, r.ID_Apoyo, r.POP, r.PNCOP, r.Reproceso, r.Observaciones, r.PNCRevision,
                            op.Clave AS Producto, ot.NombreArea
                        FROM elastosystem_produccion_registro_diario r
                        INNER JOIN elastosystem_produccion_ot ot ON r.Orden_Trabajo = ot.Folio
                        INNER JOIN elastosystem_produccion_orden_produccion op ON ot.SF = op.SolicitudFabricacion
                        WHERE DATE(r.Fecha) = @FECHA AND ot.Nave = 'NAVE 1';";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);
                        DataTable dt = new DataTable();
                        new MySqlDataAdapter(cmd).Fill(dt);

                        DataTable dtRH = new DataTable();
                        new MySqlDataAdapter("SELECT ID, CONCAT(Nombre,' ',Apellido_Paterno,' ', Apellido_Materno) AS NombreCompleto FROM elastosystem_rh", conn).Fill(dtRH);

                        dt.Columns.Add("Operador", typeof(string));
                        dt.Columns.Add("Apoyo", typeof(string));

                        foreach (DataRow row in dt.Rows)
                        {
                            string idOp = row["ID_Operador"]?.ToString() ?? "";
                            string idAp = row["ID_Apoyo"]?.ToString() ?? "";

                            var op = dtRH.AsEnumerable().FirstOrDefault(x => x["ID"].ToString() == idOp);
                            var ap = dtRH.AsEnumerable().FirstOrDefault(x => x["ID"].ToString() == idAp);

                            row["Operador"] = op != null ? op["NombreCompleto"].ToString() : "";
                            row["Apoyo"] = ap != null ? ap["NombreCompleto"].ToString() : "";
                        }

                        var ordenTurnos = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
                        {
                            { "MATUTINO", 1 },
                            { "MIXTO", 2 },
                            { "VESPERTINO", 3 },
                            { "NOCTURNO", 4 }
                        };

                        var filasOrdenadas = dt.AsEnumerable()
                            .OrderBy(r => ordenTurnos.ContainsKey(r["Turno"].ToString()) ? ordenTurnos[r["Turno"].ToString()] : 99)
                            .ThenBy(r => r["Maquina"])
                            .ToList();

                        DataTable dtOrdenado = dt.Clone();
                        foreach (var row in filasOrdenadas)
                            dtOrdenado.ImportRow(row);

                        dgvRegistradosNave1.DataSource = dtOrdenado;

                        dgvRegistradosNave1.Columns["NombreArea"].HeaderText = "Actividad";
                        dgvRegistradosNave1.Columns["Orden_Trabajo"].HeaderText = "Folio";
                        dgvRegistradosNave1.Columns["ID"].Visible = false;
                        dgvRegistradosNave1.Columns["ID_Operador"].Visible = false;
                        dgvRegistradosNave1.Columns["ID_Apoyo"].Visible = false;
                        dgvRegistradosNave1.Columns["POP"].Visible = false;
                        dgvRegistradosNave1.Columns["PNCOP"].Visible = false;
                        dgvRegistradosNave1.Columns["Reproceso"].Visible = false;
                        dgvRegistradosNave1.Columns["Observaciones"].Visible = false;
                        dgvRegistradosNave1.Columns["PNCRevision"].Visible = false;
                        dgvRegistradosNave1.Columns["Operador"].Visible = false;
                        dgvRegistradosNave1.Columns["Apoyo"].Visible = false;
                        dgvRegistradosNave1.Columns["Orden_Trabajo"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR REGISTRADOS:" + ex.Message);
            }
        }

        private void CargarRegistradosN2()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            r.ID, r.Orden_Trabajo, r.Turno, r.Maquina,
                            r.ID_Operador, r.ID_Apoyo, r.POP, r.PNCOP, r.Reproceso, r.Observaciones, r.PNCRevision,
                            op.Clave AS Producto, ot.NombreArea
                        FROM elastosystem_produccion_registro_diario r
                        INNER JOIN elastosystem_produccion_ot ot ON r.Orden_Trabajo = ot.Folio
                        INNER JOIN elastosystem_produccion_orden_produccion op ON ot.SF = op.SolicitudFabricacion
                        WHERE DATE(r.Fecha) = @FECHA AND ot.Nave = 'NAVE 2';";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);
                        DataTable dt = new DataTable();
                        new MySqlDataAdapter(cmd).Fill(dt);

                        DataTable dtRH = new DataTable();
                        new MySqlDataAdapter("SELECT ID, CONCAT(Nombre,' ',Apellido_Paterno,' ', Apellido_Materno) AS NombreCompleto FROM elastosystem_rh", conn).Fill(dtRH);

                        dt.Columns.Add("Operador", typeof(string));
                        dt.Columns.Add("Apoyo", typeof(string));

                        foreach (DataRow row in dt.Rows)
                        {
                            string idOp = row["ID_Operador"]?.ToString() ?? "";
                            string idAp = row["ID_Apoyo"]?.ToString() ?? "";

                            var op = dtRH.AsEnumerable().FirstOrDefault(x => x["ID"].ToString() == idOp);
                            var ap = dtRH.AsEnumerable().FirstOrDefault(x => x["ID"].ToString() == idAp);

                            row["Operador"] = op != null ? op["NombreCompleto"].ToString() : "";
                            row["Apoyo"] = ap != null ? ap["NombreCompleto"].ToString() : "";
                        }

                        var ordenTurnos = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
                        {
                            { "MATUTINO", 1 },
                            { "MIXTO", 2 },
                            { "VESPERTINO", 3 },
                            { "NOCTURNO", 4 }
                        };

                        var filasOrdenadas = dt.AsEnumerable()
                            .OrderBy(r => ordenTurnos.ContainsKey(r["Turno"].ToString()) ? ordenTurnos[r["Turno"].ToString()] : 99)
                            .ThenBy(r => r["Maquina"])
                            .ToList();

                        DataTable dtOrdenado = dt.Clone();
                        foreach (var row in filasOrdenadas)
                            dtOrdenado.ImportRow(row);

                        dgvRegistradosNave2.DataSource = dtOrdenado;

                        dgvRegistradosNave2.Columns["NombreArea"].HeaderText = "Actividad";
                        dgvRegistradosNave2.Columns["Orden_Trabajo"].HeaderText = "Folio";
                        dgvRegistradosNave2.Columns["ID"].Visible = false;
                        dgvRegistradosNave2.Columns["ID_Operador"].Visible = false;
                        dgvRegistradosNave2.Columns["ID_Apoyo"].Visible = false;
                        dgvRegistradosNave2.Columns["POP"].Visible = false;
                        dgvRegistradosNave2.Columns["PNCOP"].Visible = false;
                        dgvRegistradosNave2.Columns["Reproceso"].Visible = false;
                        dgvRegistradosNave2.Columns["Observaciones"].Visible = false;
                        dgvRegistradosNave2.Columns["PNCRevision"].Visible = false;
                        dgvRegistradosNave2.Columns["Operador"].Visible = false;
                        dgvRegistradosNave2.Columns["Apoyo"].Visible = false;
                        dgvRegistradosNave2.Columns["Orden_Trabajo"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR REGISTRADOS:" + ex.Message);
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

                            cbOperadorN1.DataSource = dt.Copy();
                            cbOperadorN1.DisplayMember = "NombreCompleto";
                            cbOperadorN1.ValueMember = "ID";
                            cbOperadorN1.SelectedIndex = -1;
                            cbOperadorN1.MaxDropDownItems = 5;

                            cbOperadorN1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            cbOperadorN1.AutoCompleteSource = AutoCompleteSource.CustomSource;

                            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
                            foreach (DataRow row in dt.Rows)
                            {
                                autoComplete.Add(row["NombreCompleto"].ToString());
                            }
                            cbOperadorN1.AutoCompleteCustomSource = autoComplete;

                            cbApoyoN1.DataSource = dt.Copy();
                            cbApoyoN1.DisplayMember = "NombreCompleto";
                            cbApoyoN1.ValueMember = "ID";
                            cbApoyoN1.SelectedIndex = -1;
                            cbApoyoN1.MaxDropDownItems = 5;

                            cbApoyoN1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            cbApoyoN1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            cbApoyoN1.AutoCompleteCustomSource = autoComplete;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR TRABAJADORES: " + ex.Message);
            }
        }

        private void CargarTrabajadores2()
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

                            cbOperadorN2.DataSource = dt.Copy();
                            cbOperadorN2.DisplayMember = "NombreCompleto";
                            cbOperadorN2.ValueMember = "ID";
                            cbOperadorN2.SelectedIndex = -1;
                            cbOperadorN2.MaxDropDownItems = 5;

                            cbOperadorN2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            cbOperadorN2.AutoCompleteSource = AutoCompleteSource.CustomSource;

                            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
                            foreach (DataRow row in dt.Rows)
                            {
                                autoComplete.Add(row["NombreCompleto"].ToString());
                            }
                            cbOperadorN2.AutoCompleteCustomSource = autoComplete;

                            cbApoyoN2.DataSource = dt.Copy();
                            cbApoyoN2.DisplayMember = "NombreCompleto";
                            cbApoyoN2.ValueMember = "ID";
                            cbApoyoN2.SelectedIndex = -1;
                            cbApoyoN2.MaxDropDownItems = 5;

                            cbApoyoN2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            cbApoyoN2.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            cbApoyoN2.AutoCompleteCustomSource = autoComplete;
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
            if (tabControl1.SelectedIndex == 0)
            {
                LimpiarN1();
                fechaMostrada = DateTime.Today;
                ActualizarLabelFecha();
                CargarTrabajadores();
                CargarPendientesN1();
                CargarRegistradosN1();
                lblPNCRevisionN1.Visible = false;
                txbPNCRevisionN1.Visible = false;
                btnActualizarN1.Visible = false;
                btnRegistrarN1.Visible = false;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                LimpiarN2();
                fechaMostrada = DateTime.Today;
                ActualizarLabelFecha2();
                CargarTrabajadores2();
                CargarPendientesN2();
                CargarRegistradosN2();
                lblPNCRevision2.Visible = false;
                txbPNCRevision2.Visible = false;
                btnActualizar2.Visible = false;
                btnRegistrar2.Visible = false;
            }
        }

        private void dgvNave1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LimpiarN1()
        {
            txbProductoN1.Clear();
            lblFolioN1.Text = string.Empty;
            txbActividadN1.Clear();
            txbTurnoN1.Clear();
            lblMoldeN1.Text = string.Empty;
            txbHorasTrabajadasN1.Clear();
            txbMaquinaN1.Clear();
            cbOperadorN1.SelectedIndex = -1;
            cbApoyoN1.SelectedIndex = -1;
            txbObservacionesN1.Clear();
            txbProductoOPN1.Clear();
            txbPNCOperacionN1.Clear();
            txbReprocesoN1.Clear();
            txbPNCRevisionN1.Clear();
            txbPCTotalN1.Clear();
            lblIDOperadorN1.Text = string.Empty;
            lblIDApoyoN1.Text = string.Empty;
            lblIDRegistroN1.Text = string.Empty;
        }

        private void LimpiarN2()
        {
            txbProductoN2.Clear();
            lblFolioN2.Text = string.Empty;
            txbActividadN2.Clear();
            txbTurnoN2.Clear();
            lblMoldeN2.Text = string.Empty;
            txbHorasTrabajadasN2.Clear();
            txbMaquinaN2.Clear();
            cbOperadorN2.SelectedIndex = -1;
            cbApoyoN2.SelectedIndex = -1;
            txbObservacionesN2.Clear();
            txbProductoOP2.Clear();
            txbPNCOperacionN2.Clear();
            txbReproceso2.Clear();
            txbPNCRevision2.Clear();
            txbPCTotal2.Clear();
            lblIDOperador2.Text = string.Empty;
            lblIDApoyo2.Text = string.Empty;
            lblIDRegistro2.Text = string.Empty;
        }

        private void dgvNave1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvRegistradosNave1.ClearSelection();
            LimpiarN1();
            btnRegistrarN1.Visible = true;
            btnActualizarN1.Visible = false;
            lblPNCRevisionN1.Visible = false;
            txbPNCRevisionN1.Visible = false;

            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string producto = dgv.Rows[rowIndex].Cells["Producto"].Value.ToString();
                txbProductoN1.Text = producto;

                string actividad = dgv.Rows[rowIndex].Cells["NombreArea"].Value.ToString();
                txbActividadN1.Text = actividad;

                string folio = dgv.Rows[rowIndex].Cells["Folio"].Value.ToString();
                lblFolioN1.Text = folio;

                string turno = dgv.Rows[rowIndex].Cells["Turno"].Value.ToString();
                txbTurnoN1.Text = turno;

                string maquina = dgv.Rows[rowIndex].Cells["Maquina"].Value.ToString();
                txbMaquinaN1.Text = maquina;

                string molde = dgv.Rows[rowIndex].Cells["Molde"].Value.ToString();
                lblMoldeN1.Text = molde;
            }
        }

        private void cbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txbTurnoN1.Text == "MIXTO")
            {
                txbHorasTrabajadasN1.Text = "9.5";
            }
            else
            {
                txbHorasTrabajadasN1.Text = "7.5";
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
            if (cbOperadorN1.SelectedIndex != -1)
            {
                lblIDOperadorN1.Text = cbOperadorN1.SelectedValue.ToString();

                if (cbApoyoN1.SelectedIndex != -1 && cbApoyoN1.SelectedValue.ToString() == cbOperadorN1.SelectedValue.ToString())
                {
                    MessageBox.Show("El operador y el apoyo no pueden ser la misma persona.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbApoyoN1.SelectedIndex = -1;
                    lblIDApoyoN1.Text = string.Empty;
                }
            }
            else
            {
                lblIDOperadorN1.Text = string.Empty;
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
            double productoOP = string.IsNullOrWhiteSpace(txbProductoOPN1.Text) ? 0 : Convert.ToDouble(txbProductoOPN1.Text);
            double pncOperacion = string.IsNullOrWhiteSpace(txbPNCOperacionN1.Text) ? 0 : Convert.ToDouble(txbPNCOperacionN1.Text);
            double reproceso = string.IsNullOrWhiteSpace(txbReprocesoN1.Text) ? 0 : Convert.ToDouble(txbReprocesoN1.Text);
            double pncRevision = string.IsNullOrWhiteSpace(txbPNCRevisionN1.Text) ? 0 : Convert.ToDouble(txbPNCRevisionN1.Text);

            double total = productoOP - pncOperacion - reproceso - pncRevision;

            txbPCTotalN1.Text = total.ToString("0.##");
        }

        private void CalcularPCTotal2()
        {
            double productoOP = string.IsNullOrWhiteSpace(txbProductoOP2.Text) ? 0 : Convert.ToDouble(txbProductoOP2.Text);
            double pncOperacion = string.IsNullOrWhiteSpace(txbPNCOperacionN2.Text) ? 0 : Convert.ToDouble(txbPNCOperacionN2.Text);
            double reproceso = string.IsNullOrWhiteSpace(txbReproceso2.Text) ? 0 : Convert.ToDouble(txbReproceso2.Text);
            double pncRevision = string.IsNullOrWhiteSpace(txbPNCRevision2.Text) ? 0 : Convert.ToDouble(txbPNCRevision2.Text);

            double total = productoOP - pncOperacion - reproceso - pncRevision;

            txbPCTotal2.Text = total.ToString("0.##");
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
            if (string.IsNullOrWhiteSpace(lblFolioN1.Text))
            {
                MessageBox.Show("Selecciona una orden de trabajo primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbOperadorN1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(lblIDOperadorN1.Text))
            {
                MessageBox.Show("Selecciona un operador válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txbHorasTrabajadasN1.Text) || !double.TryParse(txbHorasTrabajadasN1.Text.Replace('.', ','), out _))
            {
                MessageBox.Show("Ingresa horas trabajadas válidas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txbProductoOPN1.Text)) txbProductoOPN1.Text = "0";
            if (string.IsNullOrWhiteSpace(txbPNCOperacionN1.Text)) txbPNCOperacionN1.Text = "0";
            if (string.IsNullOrWhiteSpace(txbReprocesoN1.Text)) txbReprocesoN1.Text = "0";
            if (string.IsNullOrWhiteSpace(txbPNCRevisionN1.Text)) txbPNCRevisionN1.Text = "0";

            string folio = lblFolioN1.Text.Trim();
            string turno = txbTurnoN1.Text.Trim();
            string idOperador = lblIDOperadorN1.Text.Trim();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string queryOp = "SELECT COUNT(*) FROM elastosystem_produccion_registro_diario WHERE ID_Operador = @IDOP AND DATE(Fecha) = @FECHA";
                    using (MySqlCommand cmd = new MySqlCommand(queryOp, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDOP", idOperador);
                        cmd.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);
                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("El operador ya tiene un registro en esta fecha.", "Ya registrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    string queryDup = "SELECT COUNT(*) FROM elastosystem_produccion_registro_diario WHERE Orden_Trabajo = @OT AND Turno = @TURNO AND DATE(Fecha) = @FECHA";
                    using (MySqlCommand cmd = new MySqlCommand(queryDup, conn))
                    {
                        cmd.Parameters.AddWithValue("@OT", folio);
                        cmd.Parameters.AddWithValue("@TURNO", turno);
                        cmd.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);
                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show($"Ya existe un registro para esta OT y turno en {fechaMostrada:dd/MM/yyyy}", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    string insert = @"
                        INSERT INTO elastosystem_produccion_registro_diario
                        (Orden_Trabajo, Fecha, Turno, Horas, Maquina, Molde, ID_Operador, ID_Apoyo, POP, PNCOP, Reproceso, Observaciones, Firma, PNCRevision)
                        VALUES
                        (@OT, @FECHA, @TURNO, @HORAS, @MAQUINA, @MOLDE, @IDOP, @IDAP, @POP, @PNCOP, @REPRO, @OBS, @FIRMA, @PNCREV);";

                    using (MySqlCommand cmd = new MySqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@OT", folio);
                        cmd.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);
                        cmd.Parameters.AddWithValue("@TURNO", turno);
                        cmd.Parameters.AddWithValue("@HORAS", txbHorasTrabajadasN1.Text.Trim());
                        cmd.Parameters.AddWithValue("@MAQUINA", txbMaquinaN1.Text);
                        cmd.Parameters.AddWithValue("@MOLDE", lblMoldeN1.Text);
                        cmd.Parameters.AddWithValue("@IDOP", idOperador);
                        cmd.Parameters.AddWithValue("@IDAP", string.IsNullOrWhiteSpace(lblIDApoyoN1.Text) ? DBNull.Value : (object)lblIDApoyoN1.Text.Trim());
                        cmd.Parameters.AddWithValue("@POP", Convert.ToDouble(txbProductoOPN1.Text));
                        cmd.Parameters.AddWithValue("@PNCOP", Convert.ToDouble(txbPNCOperacionN1.Text));
                        cmd.Parameters.AddWithValue("@REPRO", Convert.ToDouble(txbReprocesoN1.Text));
                        cmd.Parameters.AddWithValue("@OBS", txbObservacionesN1.Text.Trim());
                        cmd.Parameters.AddWithValue("@FIRMA", VariablesGlobales.Usuario);
                        cmd.Parameters.AddWithValue("@PNCREV", Convert.ToDouble(txbPNCRevisionN1.Text));

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            LimpiarN1();
                            btnRegistrarN1.Visible = false;
                            CargarPendientesN1();
                            CargarRegistradosN1();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL REGISTRAR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Dictionary<string, (TimeSpan Start, TimeSpan End)> ObtenerHorariosTurnos()
        {
            return new Dictionary<string, (TimeSpan Start, TimeSpan End)>(StringComparer.OrdinalIgnoreCase)
            {
                { "MATUTINO", (new TimeSpan(6, 0, 0), new TimeSpan(14, 0, 0)) },
                { "MIXTO", (new TimeSpan(7, 0, 0), new TimeSpan(17, 0, 0)) },
                { "VESPERTINO", (new TimeSpan(14, 0, 0), new TimeSpan(22, 0, 0)) }
            };
        }

        private List<string> ObtenerMaquinasPendientesN1(string turno)
        {
            return dgvPendientesNave1.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow && (r.Cells["Turno"]?.Value?.ToString() ?? "").Equals(turno, StringComparison.OrdinalIgnoreCase))
                .Select(r => r.Cells["Maquina"]?.Value?.ToString() ?? "")
                .Where(m => !string.IsNullOrWhiteSpace(m))
                .Distinct()
                .ToList();
        }

        private bool TieneCoberturaParosN1(string turno, List<string> maquinas)
        {
            if (!maquinas.Any()) return true;
            var horarios = ObtenerHorariosTurnos();
            if (!horarios.TryGetValue(turno, out var horarioTurno)) return false;
            TimeSpan duracionTurno = horarioTurno.End - horarioTurno.Start;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    foreach (string maquina in maquinas)
                    {
                        string query = @"
                            SELECT Hora_Inicio, Hora_Fin
                            FROM elastosystem_produccion_paros p
                            INNER JOIN elastosystem_mtto_inventariomaquinas m ON p.ID_Maquina = m.ID
                            WHERE m.Nombre = @MAQUINA
                                AND p.Fecha = @FECHA
                                AND p.Nave = 'NAVE 1'";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MAQUINA", maquina);
                            cmd.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                TimeSpan totalOverlap = TimeSpan.Zero;
                                while (reader.Read())
                                {
                                    TimeSpan inicioParo = reader.GetTimeSpan("Hora_Inicio");
                                    TimeSpan finParo = reader.GetTimeSpan("Hora_Fin");
                                    TimeSpan overlapStart = TimeSpan.FromTicks(Math.Max(horarioTurno.Start.Ticks, inicioParo.Ticks));
                                    TimeSpan overlapEnd = TimeSpan.FromTicks(Math.Min(horarioTurno.End.Ticks, finParo.Ticks));
                                    if (overlapEnd > overlapStart)
                                    {
                                        totalOverlap += overlapEnd - overlapStart;
                                    }
                                }
                                if (totalOverlap < duracionTurno) return false;
                            }
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void btnFirmarReporteN1_Click(object sender, EventArgs e)
        {
            if (dgvRegistradosNave1.Rows.Count == 0 || dgvRegistradosNave1.DataSource == null)
            {
                MessageBox.Show("No se puede generar el reporte.\n\nNo hay registros de producción en NAVE 1 para esta fecha.", "Sin Registros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime hoy = DateTime.Today;
            var pendientesMatutino = ObtenerMaquinasPendientesN1("MATUTINO");
            var pendientesMixto = ObtenerMaquinasPendientesN1("MIXTO");
            var pendientesVespertino = ObtenerMaquinasPendientesN1("VESPERTINO");

            var todosLosPendientes = pendientesMatutino
                .Concat(pendientesMixto)
                .Concat(pendientesVespertino)
                .Distinct()
                .ToList();

            if (fechaMostrada.Date > hoy)
            {
                MessageBox.Show("No se puede generar reporte de una fecha futura.", "Fecha no permitida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else if (fechaMostrada.Date < hoy)
            {
                var faltantes = new List<string>();
                if (pendientesMatutino.Any() && !TieneCoberturaParosN1("MATUTINO", pendientesMatutino))
                    faltantes.Add($"MATUTINO → {string.Join(", ", pendientesMatutino)}");
                if (pendientesMixto.Any() && !TieneCoberturaParosN1("MIXTO", pendientesMixto))
                    faltantes.Add($"MIXTO → {string.Join(", ", pendientesMixto)}");
                if (pendientesVespertino.Any() && !TieneCoberturaParosN1("VESPERTINO", pendientesVespertino))
                    faltantes.Add($"VESPERTINO → {string.Join(", ", pendientesVespertino)}");

                if (faltantes.Any())
                {
                    MessageBox.Show(
                        $"Esta en una fecha pasada ({fechaMostrada:dd/MM/yyyy}).\n" +
                        $"Todos los pendientes deben tener paros que cubran al menos la duración del turno.\n\n" +
                        $"Turnos sin cobertura suficiente:\n" +
                        string.Join("\n", faltantes) + "\n\n" +
                        $"Registra paros adecuados antes de generar el reporte.",
                        "Faltan paros con cobertura", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    AbrirParoMaquinas("NAVE 1", lblFechaN1.Text, fechaMostrada);
                    return;
                }
            }
            else
            {
                TimeSpan horaActual = DateTime.Now.TimeOfDay;
                TimeSpan horaObligaMatutino = new TimeSpan(8, 0, 0);
                TimeSpan horaObligaMixto = new TimeSpan(15, 0, 0);
                TimeSpan horaObligaVespertino = new TimeSpan(18, 0, 0);

                var faltantes = new List<string>();
                if (horaActual >= horaObligaMatutino && pendientesMatutino.Any() && !TieneCoberturaParosN1("MATUTINO", pendientesMatutino))
                    faltantes.Add($"MATUTINO → {string.Join(", ", pendientesMatutino)}");
                if (horaActual >= horaObligaMixto && pendientesMixto.Any() && !TieneCoberturaParosN1("MIXTO", pendientesMixto))
                    faltantes.Add($"MIXTO → {string.Join(", ", pendientesMixto)}");
                if (horaActual >= horaObligaVespertino && pendientesVespertino.Any() && !TieneCoberturaParosN1("VESPERTINO", pendientesVespertino))
                    faltantes.Add($"VESPERTINO → {string.Join(", ", pendientesVespertino)}");

                if (faltantes.Any())
                {
                    MessageBox.Show(
                        $"Son las {DateTime.Now:HH:mm} y ya es obligatorio registrar paros para los siguientes turnos pendientes:\n\n" +
                        string.Join("\n", faltantes) + "\n\n" +
                        $"Por favor, registra paros que cubran al menos la duración del turno antes de generar el reporte.",
                        "Faltan paros con cobertura", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    AbrirParoMaquinas("NAVE 1", lblFechaN1.Text, fechaMostrada);
                    return;
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
            saveFileDialog.Title = "Guardar Reporte de Producción";
            saveFileDialog.FileName = $"Reporte de Produccion Nave 1 {fechaMostrada:yyyy-MM-dd}.pdf";

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            string rutaArchivo = saveFileDialog.FileName;
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 36, 36, 36, 36);

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                var tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                var textoFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                var cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 12, BaseColor.BLACK);
                BaseColor grisClaro = new BaseColor(230, 230, 230);

                doc.Add(new Paragraph("REPORTE DE PRODUCCIÓN NAVE 1", tituloFont) { Alignment = Element.ALIGN_LEFT, SpacingAfter = 5 });
                doc.Add(new Paragraph("Fecha: " + lblFechaN1.Text, textoFont) { Alignment = Element.ALIGN_LEFT, SpacingAfter = 1 });

                string fechaGen = DateTime.Now.ToString("dddd dd 'de' MMMM 'del' yyyy HH:mm", new CultureInfo("es-MX"));
                fechaGen = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fechaGen);
                doc.Add(new Paragraph("Generado: " + fechaGen, textoFont) { Alignment = Element.ALIGN_LEFT, SpacingAfter = 15 });

                doc.Add(new Paragraph("Registrados", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)) { Alignment = Element.ALIGN_CENTER, SpacingAfter = 10 });

                PdfPTable tabla = new PdfPTable(4);
                tabla.WidthPercentage = 100;
                tabla.SetWidths(new float[] { 15f, 25f, 35f, 25f });

                string[] encabezados = { "TURNO", "NOMBRE", "ACTIVIDAD", "CANTIDAD" };
                foreach (string h in encabezados)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(h, headerFont));
                    celda.BackgroundColor = grisClaro;
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                    celda.Padding = 10;
                    tabla.AddCell(celda);
                }

                double totalOP = 0, totalPNC = 0, totalFinal = 0;

                foreach (DataGridViewRow row in dgvRegistradosNave1.Rows)
                {
                    if (row.IsNewRow) continue;

                    string turno = row.Cells["Turno"].Value?.ToString() ?? "";
                    string operador = row.Cells["Operador"].Value?.ToString() ?? "";
                    string maquina = row.Cells["Maquina"].Value?.ToString() ?? "";
                    string producto = row.Cells["Producto"].Value?.ToString() ?? "";
                    string area = row.Cells["NombreArea"].Value?.ToString() ?? "";
                    string apoyo = row.Cells["Apoyo"].Value?.ToString() ?? "";
                    string observaciones = row.Cells["Observaciones"].Value?.ToString() ?? "";

                    double pop = Convert.ToDouble(row.Cells["POP"].Value ?? 0);
                    double pncop = Convert.ToDouble(row.Cells["PNCOP"].Value ?? 0);
                    double reproceso = Convert.ToDouble(row.Cells["Reproceso"].Value ?? 0);
                    double pncrevision = Convert.ToDouble(row.Cells["PNCRevision"].Value ?? 0);

                    double pnc = pncop + reproceso + pncrevision;
                    double cantidadFinal = pop - pnc;

                    totalOP += pop;
                    totalPNC += pnc;
                    totalFinal += cantidadFinal;

                    string actividadTexto = $"{maquina} / {producto} / {area}";
                    string cantidadTexto = $"{pop:N0} - {pnc:N0} = {cantidadFinal:N0}";

                    tabla.AddCell(new PdfPCell(new Phrase(turno, boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8 });
                    tabla.AddCell(new PdfPCell(new Phrase(operador, cellFont)) { Padding = 8 });
                    tabla.AddCell(new PdfPCell(new Phrase(actividadTexto, cellFont)) { Padding = 8 });
                    tabla.AddCell(new PdfPCell(new Phrase(cantidadTexto, boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8 });
                }
                doc.Add(tabla);

                var filasConInfo = new List<DataGridViewRow>();
                var filasPendientes = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in dgvRegistradosNave1.Rows)
                {
                    if (row.IsNewRow) continue;
                    string apoyo = row.Cells["Apoyo"].Value?.ToString() ?? "";
                    string obs = row.Cells["Observaciones"].Value?.ToString() ?? "";
                    if (!string.IsNullOrWhiteSpace(apoyo) || !string.IsNullOrWhiteSpace(obs))
                        filasConInfo.Add(row);
                }

                foreach (DataGridViewRow row in dgvPendientesNave1.Rows)
                {
                    if (!row.IsNewRow)
                        filasPendientes.Add(row);
                }

                if (filasConInfo.Any() || filasPendientes.Any())
                {
                    doc.Add(new Paragraph("Observaciones", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)) { Alignment = Element.ALIGN_CENTER, SpacingBefore = 20, SpacingAfter = 10 });

                    PdfPTable tablaObs = new PdfPTable(3);
                    tablaObs.WidthPercentage = 100;
                    tablaObs.SetWidths(new float[] { 15f, 40f, 45f });

                    string[] encabezadosObs = { "TURNO", "ACTIVIDAD", "OBSERVACIONES" };
                    foreach (string h in encabezadosObs)
                    {
                        PdfPCell celda = new PdfPCell(new Phrase(h, headerFont));
                        celda.BackgroundColor = grisClaro;
                        celda.HorizontalAlignment = Element.ALIGN_CENTER;
                        celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                        celda.Padding = 9;
                        tablaObs.AddCell(celda);
                    }

                    var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                    var fontNoRegistro = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.RED);
                    BaseColor fondoPendiente = new BaseColor(255, 230, 230);

                    foreach (DataGridViewRow row in filasConInfo)
                    {
                        string turno = row.Cells["Turno"].Value?.ToString() ?? "";
                        string maquina = row.Cells["Maquina"].Value?.ToString() ?? "";
                        string producto = row.Cells["Producto"].Value?.ToString() ?? "";
                        string area = row.Cells["NombreArea"].Value?.ToString() ?? "";
                        string apoyo = row.Cells["Apoyo"].Value?.ToString() ?? "";
                        string obs = row.Cells["Observaciones"].Value?.ToString()?.Trim() ?? "";

                        string actividad = $"{maquina} / {producto} / {area}".Trim();

                        var partes = new List<string>();
                        if (!string.IsNullOrWhiteSpace(apoyo)) partes.Add($"Apoyo: {apoyo}");
                        if (!string.IsNullOrWhiteSpace(obs)) partes.Add($"Observaciones: {obs}");
                        string textoObs = string.Join("\n", partes);

                        tablaObs.AddCell(new PdfPCell(new Phrase(turno, boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8 });
                        tablaObs.AddCell(new PdfPCell(new Phrase(actividad, fontNormal)) { Padding = 8 });
                        tablaObs.AddCell(new PdfPCell(new Phrase(textoObs, fontNormal)) { Padding = 8 });
                    }

                    foreach (DataGridViewRow row in filasPendientes)
                    {
                        string turno = row.Cells["Turno"].Value?.ToString() ?? "";
                        string maquina = row.Cells["Maquina"].Value?.ToString() ?? "";
                        string producto = row.Cells["Producto"].Value?.ToString() ?? "";
                        string area = row.Cells["NombreArea"].Value?.ToString() ?? "";

                        string actividad = $"{maquina} / {producto} / {area}".Trim();

                        tablaObs.AddCell(new PdfPCell(new Phrase(turno, boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8, BackgroundColor = fondoPendiente });
                        tablaObs.AddCell(new PdfPCell(new Phrase(actividad, fontNormal)) { Padding = 8, BackgroundColor = fondoPendiente });
                        tablaObs.AddCell(new PdfPCell(new Phrase("NO HAY REGISTRO", fontNoRegistro)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8, BackgroundColor = fondoPendiente });
                    }
                    doc.Add(tablaObs);

                    using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                    {
                        conn.Open();

                        string queryParos = @"
                            SELECT
                                m.Nombre AS Maquina,
                                CONCAT(f.Codigo, ' - ', f.Falla) AS Falla,
                                p.Hora_Inicio,
                                p.Hora_Fin,
                                p.Observaciones
                            FROM elastosystem_produccion_paros p
                            INNER JOIN elastosystem_mtto_inventariomaquinas m ON p.ID_Maquina = m.ID
                            INNER JOIN elastosystem_produccion_fallas f ON p.Codigo_Falla = f.Codigo
                            WHERE p.Nave = @NAVE
                                AND p.Fecha = @FECHA
                            ORDER BY p.Hora_Inicio ASC";

                        using (MySqlCommand cmd = new MySqlCommand(queryParos, conn))
                        {
                            cmd.Parameters.AddWithValue("@NAVE", "NAVE 1");
                            cmd.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);

                            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                            {
                                DataTable dtParos = new DataTable();
                                da.Fill(dtParos);

                                if (dtParos.Rows.Count > 0)
                                {
                                    doc.Add(new Paragraph("PAROS REGISTRADOS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))
                                    { Alignment = Element.ALIGN_CENTER, SpacingBefore = 20, SpacingAfter = 10 });

                                    PdfPTable tablaParos = new PdfPTable(5);
                                    tablaParos.WidthPercentage = 100;
                                    tablaParos.SetWidths(new float[] { 20f, 30f, 12f, 12f, 26f });

                                    BaseColor headerColor = new BaseColor(200, 220, 255);
                                    var headerFont2 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);

                                    string[] encabezadosParos = { "MÁQUINA", "FALLA", "INICIO", "FIN", "OBSERVACIONES" };
                                    foreach (string h in encabezadosParos)
                                    {
                                        PdfPCell celda = new PdfPCell(new Phrase(h, headerFont2));
                                        celda.BackgroundColor = headerColor;
                                        celda.HorizontalAlignment = Element.ALIGN_CENTER;
                                        celda.Padding = 6;
                                        tablaParos.AddCell(celda);
                                    }

                                    var cellFont2 = FontFactory.GetFont(FontFactory.HELVETICA, 8);

                                    foreach (DataRow row in dtParos.Rows)
                                    {
                                        tablaParos.AddCell(new PdfPCell(new Phrase(row["Maquina"].ToString(), cellFont2)) { Padding = 5 });
                                        tablaParos.AddCell(new PdfPCell(new Phrase(row["Falla"].ToString(), cellFont2)) { Padding = 5 });
                                        tablaParos.AddCell(new PdfPCell(new Phrase(((TimeSpan)row["Hora_Inicio"]).ToString(@"hh\:mm"), cellFont2)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                                        tablaParos.AddCell(new PdfPCell(new Phrase(((TimeSpan)row["Hora_Fin"]).ToString(@"hh\:mm"), cellFont2)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                                        tablaParos.AddCell(new PdfPCell(new Phrase(row["Observaciones"]?.ToString() ?? "", cellFont2)) { Padding = 5 });
                                    }

                                    doc.Add(tablaParos);
                                }
                                else
                                {
                                    doc.Add(new Paragraph("PAROS REGISTRADOS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))
                                    { Alignment = Element.ALIGN_CENTER, SpacingBefore = 20, SpacingAfter = 8 });

                                    doc.Add(new Paragraph("No se registraron paros en este día.", FontFactory.GetFont(FontFactory.HELVETICA, 10))
                                    { Alignment = Element.ALIGN_CENTER, SpacingAfter = 10 });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL GENERAR PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                doc.Close();
            }

            if (File.Exists(rutaArchivo))
            {
                try
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = rutaArchivo,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo abrir el PDF automáticamente:\n" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("El archivo no se pudo encontrar después de guardarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbApoyo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbApoyoN1.SelectedIndex != -1)
            {
                lblIDApoyoN1.Text = cbApoyoN1.SelectedValue.ToString();

                if (cbOperadorN1.SelectedIndex != -1 && cbOperadorN1.SelectedValue.ToString() == cbApoyoN1.SelectedValue.ToString())
                {
                    MessageBox.Show("El apoyo no puede ser el mismo que el operador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbApoyoN1.SelectedIndex = -1;
                    lblIDApoyoN1.Text = string.Empty;
                }
            }
            else
            {
                lblIDApoyoN1.Text = string.Empty;
            }
        }

        private void dgvNave1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPendientesNave1.ClearSelection();
        }

        private void txbTurnoN1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbTurnoN1.Text))
            {
                return;
            }

            switch (txbTurnoN1.Text)
            {
                case "MATUTINO":
                    txbHorasTrabajadasN1.Text = "7.5";
                    break;

                case "VESPERTINO":
                    txbHorasTrabajadasN1.Text = "7.5";
                    break;

                case "MIXTO":
                    txbHorasTrabajadasN1.Text = "9.5";
                    break;

                default:
                    break;
            }
        }

        private void dgvRegistradosNave1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvRegistradosNave1.ClearSelection();
        }

        private void dgvRegistradosNave1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPendientesNave1.ClearSelection();
            LimpiarN1();
            btnRegistrarN1.Visible = false;
            btnActualizarN1.Visible = true;
            lblPNCRevisionN1.Visible = true;
            txbPNCRevisionN1.Visible = true;

            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells["ID"].Value.ToString();
                lblIDRegistroN1.Text = id;

                string turno = dgv.Rows[rowIndex].Cells["Turno"].Value.ToString();
                txbTurnoN1.Text = turno;

                string maquina = dgv.Rows[rowIndex].Cells["Maquina"].Value.ToString();
                txbMaquinaN1.Text = maquina;

                string pop = dgv.Rows[rowIndex].Cells["POP"].Value.ToString();
                txbProductoOPN1.Text = pop;

                string pncop = dgv.Rows[rowIndex].Cells["PNCOP"].Value.ToString();
                txbPNCOperacionN1.Text = pncop;

                string reproceso = dgv.Rows[rowIndex].Cells["Reproceso"].Value.ToString();
                txbReprocesoN1.Text = reproceso;

                string observaciones = dgv.Rows[rowIndex].Cells["Observaciones"].Value.ToString();
                txbObservacionesN1.Text = observaciones;

                string producto = dgv.Rows[rowIndex].Cells["Producto"].Value.ToString();
                txbProductoN1.Text = producto;

                string nombrearea = dgv.Rows[rowIndex].Cells["NombreArea"].Value.ToString();
                txbActividadN1.Text = nombrearea;

                string operador = dgv.Rows[rowIndex].Cells["Operador"].Value.ToString();
                cbOperadorN1.Text = operador;

                string apoyo = dgv.Rows[rowIndex].Cells["Apoyo"].Value.ToString();
                cbApoyoN1.Text = apoyo;

                string pncrevision = dgv.Rows[rowIndex].Cells["PNCRevision"].Value.ToString();
                txbPNCRevisionN1.Text = pncrevision;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblIDRegistroN1.Text))
            {
                MessageBox.Show("No hay ningún registro selccionado para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbOperadorN1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(lblIDOperadorN1.Text))
            {
                MessageBox.Show("Debes seleccionar un operador válido para actualizar el registro.", "Operador requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txbProductoOPN1.Text)) txbProductoOPN1.Text = "0";
            if (string.IsNullOrWhiteSpace(txbPNCOperacionN1.Text)) txbPNCOperacionN1.Text = "0";
            if (string.IsNullOrWhiteSpace(txbReprocesoN1.Text)) txbReprocesoN1.Text = "0";
            if (string.IsNullOrWhiteSpace(txbPNCRevisionN1.Text)) txbPNCRevisionN1.Text = "0";

            if (!double.TryParse(txbProductoOPN1.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out _))
            {
                MessageBox.Show("El campo 'Producto en OP' debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idRegistro = Convert.ToInt32(lblIDRegistroN1.Text);
            string nuevoIdOperador = lblIDOperadorN1.Text.Trim();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string queryOperadorHoy = @"
                        SELECT COUNT(*)
                        FROM elastosystem_produccion_registro_diario
                        WHERE ID_Operador = @NUEVOOP
                            AND DATE(Fecha) = @FECHA
                            AND ID != @IDREGISTRO;";

                    using (MySqlCommand cmdVal = new MySqlCommand(queryOperadorHoy, conn))
                    {
                        cmdVal.Parameters.AddWithValue("@NUEVOOP", nuevoIdOperador);
                        cmdVal.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);
                        cmdVal.Parameters.AddWithValue("@IDREGISTRO", idRegistro);

                        int conflicto = Convert.ToInt32(cmdVal.ExecuteScalar());
                        if (conflicto > 0)
                        {
                            MessageBox.Show(
                                $"El operador seleccionado ya tiene un registro en la fecha {fechaMostrada:dd 'de' MMMM 'de' yyyy}.\n\n" +
                                "Un operador solo puede tener un registro por día.",
                                "Conflicto de operador",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    string queryUpdate = @"
                        UPDATE elastosystem_produccion_registro_diario
                        SET
                            ID_Operador = @IDOPERADOR,
                            ID_Apoyo = @IDAPOYO,
                            POP = @POP,
                            PNCOP = @PNCOP,
                            Reproceso = @REPROCESO,
                            Observaciones = @OBSERVACIONES,
                            Firma = @FIRMA,
                            PNCRevision = @PNCREV
                        WHERE ID = @IDREGISTRO;";

                    using (MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@IDOPERADOR", nuevoIdOperador);
                        cmdUpdate.Parameters.AddWithValue("@IDAPOYO", string.IsNullOrWhiteSpace(lblIDApoyoN1.Text) ? DBNull.Value : (object)lblIDApoyoN1.Text.Trim());
                        cmdUpdate.Parameters.AddWithValue("@POP", Convert.ToDouble(txbProductoOPN1.Text));
                        cmdUpdate.Parameters.AddWithValue("@PNCOP", Convert.ToDouble(txbPNCOperacionN1.Text));
                        cmdUpdate.Parameters.AddWithValue("@REPROCESO", Convert.ToDouble(txbReprocesoN1.Text));
                        cmdUpdate.Parameters.AddWithValue("@OBSERVACIONES", txbObservacionesN1.Text.Trim());
                        cmdUpdate.Parameters.AddWithValue("@FIRMA", VariablesGlobales.Usuario);
                        cmdUpdate.Parameters.AddWithValue("@PNCREV", Convert.ToDouble(txbPNCRevisionN1.Text));
                        cmdUpdate.Parameters.AddWithValue("@IDREGISTRO", idRegistro);

                        int filas = cmdUpdate.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            LimpiarN1();
                            btnActualizarN1.Visible = false;
                            btnRegistrarN1.Visible = false;
                            lblPNCRevisionN1.Visible = false;
                            txbPNCRevisionN1.Visible = false;
                            CargarPendientesN1();
                            CargarRegistradosN1();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el resgistro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar registro:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbAtrasN1_Click(object sender, EventArgs e)
        {
            LimpiarN1();
            fechaMostrada = fechaMostrada.AddDays(-1);
            ActualizarLabelFecha();
            CargarPendientesN1();
            CargarRegistradosN1();
            lblPNCRevisionN1.Visible = false;
            txbPNCRevisionN1.Visible = false;
            btnActualizarN1.Visible = false;
        }

        private void pbAdelanteN1_Click(object sender, EventArgs e)
        {
            LimpiarN1();
            fechaMostrada = fechaMostrada.AddDays(1);
            ActualizarLabelFecha();
            CargarPendientesN1();
            CargarRegistradosN1();
            lblPNCRevisionN1.Visible = false;
            txbPNCRevisionN1.Visible = false;
            btnActualizarN1.Visible = false;
        }

        private void txbPNCRevisionN1_TextChanged(object sender, EventArgs e)
        {
            CalcularPCTotal();
        }

        private void cbOperadorN2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOperadorN2.SelectedIndex != -1)
            {
                lblIDOperador2.Text = cbOperadorN2.SelectedValue.ToString();

                if (cbApoyoN2.SelectedIndex != -1 && cbApoyoN2.SelectedValue.ToString() == cbOperadorN2.SelectedValue.ToString())
                {
                    MessageBox.Show("El operador y el apoyo no pueden ser la misma persona.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbApoyoN2.SelectedIndex = -1;
                    lblIDApoyo2.Text = string.Empty;
                }
            }
            else
            {
                lblIDOperador2.Text = string.Empty;
            }
        }

        private void cbOperadorN2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbApoyoN2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbApoyoN2.SelectedIndex != -1)
            {
                lblIDApoyo2.Text = cbApoyoN2.SelectedValue.ToString();

                if (cbOperadorN2.SelectedIndex != -1 && cbOperadorN2.SelectedValue.ToString() == cbApoyoN2.SelectedValue.ToString())
                {
                    MessageBox.Show("El apoyo no puede ser el mismo que el operador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbApoyoN2.SelectedIndex = -1;
                    lblIDApoyo2.Text = string.Empty;
                }
            }
            else
            {
                lblIDApoyo2.Text = string.Empty;
            }
        }

        private void txbTurnoN2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbTurnoN2.Text))
            {
                return;
            }

            switch (txbTurnoN2.Text)
            {
                case "MATUTINO":
                    txbHorasTrabajadasN2.Text = "7.5";
                    break;

                case "VESPERTINO":
                    txbHorasTrabajadasN2.Text = "7.5";
                    break;

                case "MIXTO":
                    txbHorasTrabajadasN2.Text = "9.5";
                    break;

                default:
                    break;
            }
        }

        private void txbHorasTrabajadasN2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txbProductoOP2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txbProductoOP2_TextChanged(object sender, EventArgs e)
        {
            CalcularPCTotal2();
        }

        private void txbPNCOperacionN2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txbPNCOperacionN2_TextChanged(object sender, EventArgs e)
        {
            CalcularPCTotal2();
        }

        private void txbReproceso2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txbReproceso2_TextChanged(object sender, EventArgs e)
        {
            CalcularPCTotal2();
        }

        private void txbPNCRevision2_TextChanged(object sender, EventArgs e)
        {
            CalcularPCTotal2();
        }

        private void txbPNCRevision2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txbPNCRevisionN1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnRegistrar2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblFolioN2.Text))
            {
                MessageBox.Show("Selecciona una orden de trabajo primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbOperadorN2.SelectedIndex == -1 || string.IsNullOrWhiteSpace(lblIDOperador2.Text))
            {
                MessageBox.Show("Selecciona un operador válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txbHorasTrabajadasN2.Text) || !double.TryParse(txbHorasTrabajadasN2.Text.Replace('.', ','), out _))
            {
                MessageBox.Show("Ingresa horas trabajadas válidas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txbProductoOP2.Text)) txbProductoOP2.Text = "0";
            if (string.IsNullOrWhiteSpace(txbPNCOperacionN2.Text)) txbPNCOperacionN2.Text = "0";
            if (string.IsNullOrWhiteSpace(txbReproceso2.Text)) txbReproceso2.Text = "0";
            if (string.IsNullOrWhiteSpace(txbPNCRevision2.Text)) txbPNCRevision2.Text = "0";

            string folio = lblFolioN2.Text.Trim();
            string turno = txbTurnoN2.Text.Trim();
            string idOperador = lblIDOperador2.Text.Trim();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string queryOp = "SELECT COUNT(*) FROM elastosystem_produccion_registro_diario WHERE ID_Operador = @IDOP AND DATE(Fecha) = @FECHA";
                    using (MySqlCommand cmd = new MySqlCommand(queryOp, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDOP", idOperador);
                        cmd.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);
                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("El operador ya tiene un registro en esta fecha.", "Ya registrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    string queryDup = "SELECT COUNT(*) FROM elastosystem_produccion_registro_diario WHERE Orden_Trabajo = @OT AND Turno = @TURNO AND DATE(Fecha) = @FECHA";
                    using (MySqlCommand cmd = new MySqlCommand(queryDup, conn))
                    {
                        cmd.Parameters.AddWithValue("@OT", folio);
                        cmd.Parameters.AddWithValue("@TURNO", turno);
                        cmd.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);
                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show($"Ya existe un registro para esta OT y turno en {fechaMostrada:dd/MM/yyyy}", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    string insert = @"
                        INSERT INTO elastosystem_produccion_registro_diario
                        (Orden_Trabajo, Fecha, Turno, Horas, Maquina, Molde, ID_Operador, ID_Apoyo, POP, PNCOP, Reproceso, Observaciones, Firma, PNCRevision)
                        VALUES
                        (@OT, @FECHA, @TURNO, @HORAS, @MAQUINA, @MOLDE, @IDOP, @IDAP, @POP, @PNCOP, @REPRO, @OBS, @FIRMA, @PNCREV);";

                    using (MySqlCommand cmd = new MySqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@OT", folio);
                        cmd.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);
                        cmd.Parameters.AddWithValue("@TURNO", turno);
                        cmd.Parameters.AddWithValue("@HORAS", txbHorasTrabajadasN2.Text.Trim());
                        cmd.Parameters.AddWithValue("@MAQUINA", txbMaquinaN2.Text);
                        cmd.Parameters.AddWithValue("@MOLDE", lblMoldeN2.Text);
                        cmd.Parameters.AddWithValue("@IDOP", idOperador);
                        cmd.Parameters.AddWithValue("@IDAP", string.IsNullOrWhiteSpace(lblIDApoyo2.Text) ? DBNull.Value : (object)lblIDApoyo2.Text.Trim());
                        cmd.Parameters.AddWithValue("@POP", Convert.ToDouble(txbProductoOP2.Text));
                        cmd.Parameters.AddWithValue("@PNCOP", Convert.ToDouble(txbPNCOperacionN2.Text));
                        cmd.Parameters.AddWithValue("@REPRO", Convert.ToDouble(txbReproceso2.Text));
                        cmd.Parameters.AddWithValue("@OBS", txbObservacionesN2.Text.Trim());
                        cmd.Parameters.AddWithValue("@FIRMA", VariablesGlobales.Usuario);
                        cmd.Parameters.AddWithValue("@PNCREV", Convert.ToDouble(txbPNCRevision2.Text));

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            LimpiarN2();
                            btnRegistrar2.Visible = false;
                            CargarPendientesN2();
                            CargarRegistradosN2();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL REGISTRAR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblIDRegistro2.Text))
            {
                MessageBox.Show("No hay ningún registro selccionado para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbOperadorN2.SelectedIndex == -1 || string.IsNullOrWhiteSpace(lblIDOperador2.Text))
            {
                MessageBox.Show("Debes seleccionar un operador válido para actualizar el registro.", "Operador requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txbProductoOP2.Text)) txbProductoOP2.Text = "0";
            if (string.IsNullOrWhiteSpace(txbPNCOperacionN2.Text)) txbPNCOperacionN2.Text = "0";
            if (string.IsNullOrWhiteSpace(txbReproceso2.Text)) txbReproceso2.Text = "0";
            if (string.IsNullOrWhiteSpace(txbPNCRevision2.Text)) txbPNCRevision2.Text = "0";

            if (!double.TryParse(txbProductoOP2.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out _))
            {
                MessageBox.Show("El campo 'Producto en OP' debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idRegistro = Convert.ToInt32(lblIDRegistro2.Text);
            string nuevoIdOperador = lblIDOperador2.Text.Trim();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string queryOperadorHoy = @"
                        SELECT COUNT(*)
                        FROM elastosystem_produccion_registro_diario
                        WHERE ID_Operador = @NUEVOOP
                            AND DATE(Fecha) = @FECHA
                            AND ID != @IDREGISTRO;";

                    using (MySqlCommand cmdVal = new MySqlCommand(queryOperadorHoy, conn))
                    {
                        cmdVal.Parameters.AddWithValue("@NUEVOOP", nuevoIdOperador);
                        cmdVal.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);
                        cmdVal.Parameters.AddWithValue("@IDREGISTRO", idRegistro);

                        int conflicto = Convert.ToInt32(cmdVal.ExecuteScalar());
                        if (conflicto > 0)
                        {
                            MessageBox.Show(
                                $"El operador seleccionado ya tiene un registro en la fecha {fechaMostrada:dd 'de' MMMM 'de' yyyy}.\n\n" +
                                "Un operador solo puede tener un registro por día.",
                                "Conflicto de operador",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    string queryUpdate = @"
                        UPDATE elastosystem_produccion_registro_diario
                        SET
                            ID_Operador = @IDOPERADOR,
                            ID_Apoyo = @IDAPOYO,
                            POP = @POP,
                            PNCOP = @PNCOP,
                            Reproceso = @REPROCESO,
                            Observaciones = @OBSERVACIONES,
                            Firma = @FIRMA,
                            PNCRevision = @PNCREV
                        WHERE ID = @IDREGISTRO;";

                    using (MySqlCommand cmdUpdate = new MySqlCommand(queryUpdate, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@IDOPERADOR", nuevoIdOperador);
                        cmdUpdate.Parameters.AddWithValue("@IDAPOYO", string.IsNullOrWhiteSpace(lblIDApoyo2.Text) ? DBNull.Value : (object)lblIDApoyo2.Text.Trim());
                        cmdUpdate.Parameters.AddWithValue("@POP", Convert.ToDouble(txbProductoOP2.Text));
                        cmdUpdate.Parameters.AddWithValue("@PNCOP", Convert.ToDouble(txbPNCOperacionN2.Text));
                        cmdUpdate.Parameters.AddWithValue("@REPROCESO", Convert.ToDouble(txbReproceso2.Text));
                        cmdUpdate.Parameters.AddWithValue("@OBSERVACIONES", txbObservacionesN2.Text.Trim());
                        cmdUpdate.Parameters.AddWithValue("@FIRMA", VariablesGlobales.Usuario);
                        cmdUpdate.Parameters.AddWithValue("@PNCREV", Convert.ToDouble(txbPNCRevision2.Text));
                        cmdUpdate.Parameters.AddWithValue("@IDREGISTRO", idRegistro);

                        int filas = cmdUpdate.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            LimpiarN2();
                            btnActualizar2.Visible = false;
                            btnRegistrar2.Visible = false;
                            lblPNCRevision2.Visible = false;
                            txbPNCRevision2.Visible = false;
                            CargarPendientesN2();
                            CargarRegistradosN2();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el resgistro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar registro:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbAtrasN2_Click(object sender, EventArgs e)
        {
            LimpiarN2();
            fechaMostrada = fechaMostrada.AddDays(-1);
            ActualizarLabelFecha2();
            CargarPendientesN2();
            CargarRegistradosN2();
            lblPNCRevision2.Visible = false;
            txbPNCRevision2.Visible = false;
            btnActualizar2.Visible = false;
        }

        private void pbAdelanteN2_Click(object sender, EventArgs e)
        {
            LimpiarN2();
            fechaMostrada = fechaMostrada.AddDays(1);
            ActualizarLabelFecha2();
            CargarPendientesN2();
            CargarRegistradosN2();
            lblPNCRevision2.Visible = false;
            txbPNCRevision2.Visible = false;
            btnActualizar2.Visible = false;
        }

        private void dgvPendientesNave2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPendientesNave2.ClearSelection();
        }

        private void dgvPendientesNave2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvRegistradosNave2.ClearSelection();
            LimpiarN2();
            btnRegistrar2.Visible = true;
            btnActualizar2.Visible = false;
            lblPNCRevision2.Visible = false;
            txbPNCRevision2.Visible = false;

            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string producto = dgv.Rows[rowIndex].Cells["Producto"].Value.ToString();
                txbProductoN2.Text = producto;

                string actividad = dgv.Rows[rowIndex].Cells["NombreArea"].Value.ToString();
                txbActividadN2.Text = actividad;

                string folio = dgv.Rows[rowIndex].Cells["Folio"].Value.ToString();
                lblFolioN2.Text = folio;

                string turno = dgv.Rows[rowIndex].Cells["Turno"].Value.ToString();
                txbTurnoN2.Text = turno;

                string maquina = dgv.Rows[rowIndex].Cells["Maquina"].Value.ToString();
                txbMaquinaN2.Text = maquina;

                string molde = dgv.Rows[rowIndex].Cells["Molde"].Value.ToString();
                lblMoldeN2.Text = molde;
            }
        }

        private void dgvPendientesNave2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRegistradosNave2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvRegistradosNave2.ClearSelection();
        }

        private void dgvRegistradosNave2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPendientesNave2.ClearSelection();
            LimpiarN2();
            btnRegistrar2.Visible = false;
            btnActualizar2.Visible = true;
            lblPNCRevision2.Visible = true;
            txbPNCRevision2.Visible = true;

            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;

                string id = dgv.Rows[rowIndex].Cells["ID"].Value.ToString();
                lblIDRegistro2.Text = id;

                string turno = dgv.Rows[rowIndex].Cells["Turno"].Value.ToString();
                txbTurnoN2.Text = turno;

                string maquina = dgv.Rows[rowIndex].Cells["Maquina"].Value.ToString();
                txbMaquinaN2.Text = maquina;

                string pop = dgv.Rows[rowIndex].Cells["POP"].Value.ToString();
                txbProductoOP2.Text = pop;

                string pncop = dgv.Rows[rowIndex].Cells["PNCOP"].Value.ToString();
                txbPNCOperacionN2.Text = pncop;

                string reproceso = dgv.Rows[rowIndex].Cells["Reproceso"].Value.ToString();
                txbReproceso2.Text = reproceso;

                string observaciones = dgv.Rows[rowIndex].Cells["Observaciones"].Value.ToString();
                txbObservacionesN2.Text = observaciones;

                string producto = dgv.Rows[rowIndex].Cells["Producto"].Value.ToString();
                txbProductoN2.Text = producto;

                string nombrearea = dgv.Rows[rowIndex].Cells["NombreArea"].Value.ToString();
                txbActividadN2.Text = nombrearea;

                string operador = dgv.Rows[rowIndex].Cells["Operador"].Value.ToString();
                cbOperadorN2.Text = operador;

                string apoyo = dgv.Rows[rowIndex].Cells["Apoyo"].Value.ToString();
                cbApoyoN2.Text = apoyo;

                string pncrevision = dgv.Rows[rowIndex].Cells["PNCRevision"].Value.ToString();
                txbPNCRevision2.Text = pncrevision;
            }
        }

        private void AbrirParoMaquinas(string nave, string fechaTexto, DateTime fecha)
        {
            using (Produccion_ParoMaquinas frm = new Produccion_ParoMaquinas())
            {
                frm.Nave = nave;
                frm.FechaTexto = fechaTexto;
                frm.Fecha = fecha;
                frm.ShowDialog(this);
            }
        }

        private void btnParoMaquinasN1_Click(object sender, EventArgs e)
        {
            AbrirParoMaquinas("NAVE 1", lblFechaN1.Text, fechaMostrada);
        }

        private void btnParoMaquinasN2_Click(object sender, EventArgs e)
        {
            AbrirParoMaquinas("NAVE 2", lblFechaN2.Text, fechaMostrada);
        }

        private List<string> ObtenerMaquinasPendientesN2(string turno)
        {
            return dgvPendientesNave2.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow && (r.Cells["Turno"]?.Value?.ToString() ?? "").Equals(turno, StringComparison.OrdinalIgnoreCase))
                .Select(r => r.Cells["Maquina"]?.Value?.ToString() ?? "")
                .Where(m => !string.IsNullOrWhiteSpace(m))
                .Distinct()
                .ToList();
        }

        private bool TieneCoberturaParosN2(string turno, List<string> maquinas)
        {
            if (!maquinas.Any()) return true;
            var horarios = ObtenerHorariosTurnos();
            if (!horarios.TryGetValue(turno, out var horarioTurno)) return false;
            TimeSpan duracionTurno = horarioTurno.End - horarioTurno.Start;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    foreach (string maquina in maquinas)
                    {
                        string query = @"
                            SELECT Hora_Inicio, Hora_Fin
                            FROM elastosystem_produccion_paros p
                            INNER JOIN elastosystem_mtto_inventariomaquinas m ON p.ID_Maquina = m.ID
                            WHERE m.Nombre = @MAQUINA
                                AND p.Fecha = @FECHA
                                AND p.Nave = 'NAVE 2'";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MAQUINA", maquina);
                            cmd.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                TimeSpan totalOverlap = TimeSpan.Zero;
                                while (reader.Read())
                                {
                                    TimeSpan inicioParo = reader.GetTimeSpan("Hora_Inicio");
                                    TimeSpan finParo = reader.GetTimeSpan("Hora_Fin");
                                    TimeSpan overlapStart = TimeSpan.FromTicks(Math.Max(horarioTurno.Start.Ticks, inicioParo.Ticks));
                                    TimeSpan overlapEnd = TimeSpan.FromTicks(Math.Min(horarioTurno.End.Ticks, finParo.Ticks));
                                    if (overlapEnd > overlapStart)
                                    {
                                        totalOverlap += overlapEnd - overlapStart;
                                    }
                                }
                                if (totalOverlap < duracionTurno) return false;
                            }
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void btnGenerarReporteN2_Click(object sender, EventArgs e)
        {
            if (dgvRegistradosNave2.Rows.Count == 0 || dgvRegistradosNave2.DataSource == null)
            {
                MessageBox.Show("No se puede generar el reporte.\n\nNo hay registros de producción en NAVE 2 para esta fecha.", "Sin Registros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime hoy = DateTime.Today;
            var pendientesMatutino = ObtenerMaquinasPendientesN2("MATUTINO");
            var pendientesMixto = ObtenerMaquinasPendientesN2("MIXTO");
            var pendientesVespertino = ObtenerMaquinasPendientesN2("VESPERTINO");

            var todosLosPendientes = pendientesMatutino
                .Concat(pendientesMixto)
                .Concat(pendientesVespertino)
                .Distinct()
                .ToList();

            if (fechaMostrada.Date > hoy)
            {
                MessageBox.Show("No se puede generar reporte de una fecha futura.", "Fecha no permitida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else if (fechaMostrada.Date < hoy)
            {
                var faltantes = new List<string>();
                if (pendientesMatutino.Any() && !TieneCoberturaParosN2("MATUTINO", pendientesMatutino))
                    faltantes.Add($"MATUTINO → {string.Join(", ", pendientesMatutino)}");
                if (pendientesMixto.Any() && !TieneCoberturaParosN2("MIXTO", pendientesMixto))
                    faltantes.Add($"MIXTO → {string.Join(", ", pendientesMixto)}");
                if (pendientesVespertino.Any() && !TieneCoberturaParosN2("VESPERTINO", pendientesVespertino))
                    faltantes.Add($"VESPERTINO → {string.Join(", ", pendientesVespertino)}");

                if (faltantes.Any())
                {
                    MessageBox.Show(
                        $"Esta en una fecha pasada ({fechaMostrada:dd/MM/yyyy}).\n" +
                        $"Todos los pendientes deben tener paros que cubran al menos la duración del turno.\n\n" +
                        $"Turnos sin cobertura suficiente:\n" +
                        string.Join("\n", faltantes) + "\n\n" +
                        $"Registra paros adecuados antes de generar el reporte.",
                        "Faltan paros con cobertura", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    AbrirParoMaquinas("NAVE 2", lblFechaN2.Text, fechaMostrada);
                    return;
                }
            }
            else
            {
                TimeSpan horaActual = DateTime.Now.TimeOfDay;
                TimeSpan horaObligaMatutino = new TimeSpan(8, 0, 0);
                TimeSpan horaObligaMixto = new TimeSpan(15, 0, 0);
                TimeSpan horaObligaVespertino = new TimeSpan(18, 0, 0);

                var faltantes = new List<string>();
                if (horaActual >= horaObligaMatutino && pendientesMatutino.Any() && !TieneCoberturaParosN2("MATUTINO", pendientesMatutino))
                    faltantes.Add($"MATUTINO → {string.Join(", ", pendientesMatutino)}");
                if (horaActual >= horaObligaMixto && pendientesMixto.Any() && !TieneCoberturaParosN2("MIXTO", pendientesMixto))
                    faltantes.Add($"MIXTO → {string.Join(", ", pendientesMixto)}");
                if (horaActual >= horaObligaVespertino && pendientesVespertino.Any() && !TieneCoberturaParosN2("VESPERTINO", pendientesVespertino))
                    faltantes.Add($"VESPERTINO → {string.Join(", ", pendientesVespertino)}");

                if (faltantes.Any())
                {
                    MessageBox.Show(
                        $"Son las {DateTime.Now:HH:mm} y ya es obligatorio registrar paros para los siguientes turnos pendientes:\n\n" +
                        string.Join("\n", faltantes) + "\n\n" +
                        $"Por favor, registra paros que cubran al menos la duración del turno antes de generar el reporte.",
                        "Faltan paros con cobertura", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    AbrirParoMaquinas("NAVE 2", lblFechaN2.Text, fechaMostrada);
                    return;
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
            saveFileDialog.Title = "Guardar Reporte de Producción";
            saveFileDialog.FileName = $"Reporte de Produccion Nave 2 {fechaMostrada:yyyy-MM-dd}.pdf";

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            string rutaArchivo = saveFileDialog.FileName;
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 36, 36, 36, 36);

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                var tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                var textoFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                var cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 12, BaseColor.BLACK);
                BaseColor grisClaro = new BaseColor(230, 230, 230);

                doc.Add(new Paragraph("REPORTE DE PRODUCCIÓN NAVE 2", tituloFont) { Alignment = Element.ALIGN_LEFT, SpacingAfter = 5 });
                doc.Add(new Paragraph("Fecha: " + lblFechaN2.Text, textoFont) { Alignment = Element.ALIGN_LEFT, SpacingAfter = 1 });

                string fechaGen = DateTime.Now.ToString("dddd dd 'de' MMMM 'del' yyyy HH:mm", new CultureInfo("es-MX"));
                fechaGen = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fechaGen);
                doc.Add(new Paragraph("Generado: " + fechaGen, textoFont) { Alignment = Element.ALIGN_LEFT, SpacingAfter = 15 });

                doc.Add(new Paragraph("Registrados", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)) { Alignment = Element.ALIGN_CENTER, SpacingAfter = 10 });

                PdfPTable tabla = new PdfPTable(4);
                tabla.WidthPercentage = 100;
                tabla.SetWidths(new float[] { 15f, 25f, 35f, 25f });

                string[] encabezados = { "TURNO", "NOMBRE", "ACTIVIDAD", "CANTIDAD" };
                foreach (string h in encabezados)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(h, headerFont));
                    celda.BackgroundColor = grisClaro;
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                    celda.Padding = 10;
                    tabla.AddCell(celda);
                }

                double totalOP = 0, totalPNC = 0, totalFinal = 0;

                foreach (DataGridViewRow row in dgvRegistradosNave2.Rows)
                {
                    if (row.IsNewRow) continue;

                    string turno = row.Cells["Turno"].Value?.ToString() ?? "";
                    string operador = row.Cells["Operador"].Value?.ToString() ?? "";
                    string maquina = row.Cells["Maquina"].Value?.ToString() ?? "";
                    string producto = row.Cells["Producto"].Value?.ToString() ?? "";
                    string area = row.Cells["NombreArea"].Value?.ToString() ?? "";
                    string apoyo = row.Cells["Apoyo"].Value?.ToString() ?? "";
                    string observaciones = row.Cells["Observaciones"].Value?.ToString() ?? "";

                    double pop = Convert.ToDouble(row.Cells["POP"].Value ?? 0);
                    double pncop = Convert.ToDouble(row.Cells["PNCOP"].Value ?? 0);
                    double reproceso = Convert.ToDouble(row.Cells["Reproceso"].Value ?? 0);
                    double pncrevision = Convert.ToDouble(row.Cells["PNCRevision"].Value ?? 0);

                    double pnc = pncop + reproceso + pncrevision;
                    double cantidadFinal = pop - pnc;

                    totalOP += pop;
                    totalPNC += pnc;
                    totalFinal += cantidadFinal;

                    string actividadTexto = $"{maquina} / {producto} / {area}";
                    string cantidadTexto = $"{pop:N0} - {pnc:N0} = {cantidadFinal:N0}";

                    tabla.AddCell(new PdfPCell(new Phrase(turno, boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8 });
                    tabla.AddCell(new PdfPCell(new Phrase(operador, cellFont)) { Padding = 8 });
                    tabla.AddCell(new PdfPCell(new Phrase(actividadTexto, cellFont)) { Padding = 8 });
                    tabla.AddCell(new PdfPCell(new Phrase(cantidadTexto, boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8 });
                }
                doc.Add(tabla);

                var filasConInfo = new List<DataGridViewRow>();
                var filasPendientes = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in dgvRegistradosNave2.Rows)
                {
                    if (row.IsNewRow) continue;
                    string apoyo = row.Cells["Apoyo"].Value?.ToString() ?? "";
                    string obs = row.Cells["Observaciones"].Value?.ToString() ?? "";
                    if (!string.IsNullOrWhiteSpace(apoyo) || !string.IsNullOrWhiteSpace(obs))
                        filasConInfo.Add(row);
                }

                foreach (DataGridViewRow row in dgvPendientesNave2.Rows)
                {
                    if (!row.IsNewRow)
                        filasPendientes.Add(row);
                }

                if (filasConInfo.Any() || filasPendientes.Any())
                {
                    doc.Add(new Paragraph("Observaciones", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)) { Alignment = Element.ALIGN_CENTER, SpacingBefore = 20, SpacingAfter = 10 });

                    PdfPTable tablaObs = new PdfPTable(3);
                    tablaObs.WidthPercentage = 100;
                    tablaObs.SetWidths(new float[] { 15f, 40f, 45f });

                    string[] encabezadosObs = { "TURNO", "ACTIVIDAD", "OBSERVACIONES" };
                    foreach (string h in encabezadosObs)
                    {
                        PdfPCell celda = new PdfPCell(new Phrase(h, headerFont));
                        celda.BackgroundColor = grisClaro;
                        celda.HorizontalAlignment = Element.ALIGN_CENTER;
                        celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                        celda.Padding = 9;
                        tablaObs.AddCell(celda);
                    }

                    var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                    var fontNoRegistro = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.RED);
                    BaseColor fondoPendiente = new BaseColor(255, 230, 230);

                    foreach (DataGridViewRow row in filasConInfo)
                    {
                        string turno = row.Cells["Turno"].Value?.ToString() ?? "";
                        string maquina = row.Cells["Maquina"].Value?.ToString() ?? "";
                        string producto = row.Cells["Producto"].Value?.ToString() ?? "";
                        string area = row.Cells["NombreArea"].Value?.ToString() ?? "";
                        string apoyo = row.Cells["Apoyo"].Value?.ToString() ?? "";
                        string obs = row.Cells["Observaciones"].Value?.ToString()?.Trim() ?? "";

                        string actividad = $"{maquina} / {producto} / {area}".Trim();

                        var partes = new List<string>();
                        if (!string.IsNullOrWhiteSpace(apoyo)) partes.Add($"Apoyo: {apoyo}");
                        if (!string.IsNullOrWhiteSpace(obs)) partes.Add($"Observaciones: {obs}");
                        string textoObs = string.Join("\n", partes);

                        tablaObs.AddCell(new PdfPCell(new Phrase(turno, boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8 });
                        tablaObs.AddCell(new PdfPCell(new Phrase(actividad, fontNormal)) { Padding = 8 });
                        tablaObs.AddCell(new PdfPCell(new Phrase(textoObs, fontNormal)) { Padding = 8 });
                    }

                    foreach (DataGridViewRow row in filasPendientes)
                    {
                        string turno = row.Cells["Turno"].Value?.ToString() ?? "";
                        string maquina = row.Cells["Maquina"].Value?.ToString() ?? "";
                        string producto = row.Cells["Producto"].Value?.ToString() ?? "";
                        string area = row.Cells["NombreArea"].Value?.ToString() ?? "";

                        string actividad = $"{maquina} / {producto} / {area}".Trim();

                        tablaObs.AddCell(new PdfPCell(new Phrase(turno, boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8, BackgroundColor = fondoPendiente });
                        tablaObs.AddCell(new PdfPCell(new Phrase(actividad, fontNormal)) { Padding = 8, BackgroundColor = fondoPendiente });
                        tablaObs.AddCell(new PdfPCell(new Phrase("NO HAY REGISTRO", fontNoRegistro)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 8, BackgroundColor = fondoPendiente });
                    }
                    doc.Add(tablaObs);

                    using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                    {
                        conn.Open();

                        string queryParos = @"
                            SELECT
                                m.Nombre AS Maquina,
                                CONCAT(f.Codigo, ' - ', f.Falla) AS Falla,
                                p.Hora_Inicio,
                                p.Hora_Fin,
                                p.Observaciones
                            FROM elastosystem_produccion_paros p
                            INNER JOIN elastosystem_mtto_inventariomaquinas m ON p.ID_Maquina = m.ID
                            INNER JOIN elastosystem_produccion_fallas f ON p.Codigo_Falla = f.Codigo
                            WHERE p.Nave = @NAVE
                                AND p.Fecha = @FECHA
                            ORDER BY p.Hora_Inicio ASC";

                        using (MySqlCommand cmd = new MySqlCommand(queryParos, conn))
                        {
                            cmd.Parameters.AddWithValue("@NAVE", "NAVE 2");
                            cmd.Parameters.AddWithValue("@FECHA", fechaMostrada.Date);

                            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                            {
                                DataTable dtParos = new DataTable();
                                da.Fill(dtParos);

                                if (dtParos.Rows.Count > 0)
                                {
                                    doc.Add(new Paragraph("PAROS REGISTRADOS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))
                                    { Alignment = Element.ALIGN_CENTER, SpacingBefore = 20, SpacingAfter = 10 });

                                    PdfPTable tablaParos = new PdfPTable(5);
                                    tablaParos.WidthPercentage = 100;
                                    tablaParos.SetWidths(new float[] { 20f, 30f, 12f, 12f, 26f });

                                    BaseColor headerColor = new BaseColor(200, 220, 255);
                                    var headerFont2 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);

                                    string[] encabezadosParos = { "MÁQUINA", "FALLA", "INICIO", "FIN", "OBSERVACIONES" };
                                    foreach (string h in encabezadosParos)
                                    {
                                        PdfPCell celda = new PdfPCell(new Phrase(h, headerFont2));
                                        celda.BackgroundColor = headerColor;
                                        celda.HorizontalAlignment = Element.ALIGN_CENTER;
                                        celda.Padding = 6;
                                        tablaParos.AddCell(celda);
                                    }

                                    var cellFont2 = FontFactory.GetFont(FontFactory.HELVETICA, 8);

                                    foreach (DataRow row in dtParos.Rows)
                                    {
                                        tablaParos.AddCell(new PdfPCell(new Phrase(row["Maquina"].ToString(), cellFont2)) { Padding = 5 });
                                        tablaParos.AddCell(new PdfPCell(new Phrase(row["Falla"].ToString(), cellFont2)) { Padding = 5 });
                                        tablaParos.AddCell(new PdfPCell(new Phrase(((TimeSpan)row["Hora_Inicio"]).ToString(@"hh\:mm"), cellFont2)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                                        tablaParos.AddCell(new PdfPCell(new Phrase(((TimeSpan)row["Hora_Fin"]).ToString(@"hh\:mm"), cellFont2)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                                        tablaParos.AddCell(new PdfPCell(new Phrase(row["Observaciones"]?.ToString() ?? "", cellFont2)) { Padding = 5 });
                                    }

                                    doc.Add(tablaParos);
                                }
                                else
                                {
                                    doc.Add(new Paragraph("PAROS REGISTRADOS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))
                                    { Alignment = Element.ALIGN_CENTER, SpacingBefore = 20, SpacingAfter = 8 });

                                    doc.Add(new Paragraph("No se registraron paros en este día.", FontFactory.GetFont(FontFactory.HELVETICA, 10))
                                    { Alignment = Element.ALIGN_CENTER, SpacingAfter = 10 });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL GENERAR PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                doc.Close();
            }

            if (File.Exists(rutaArchivo))
            {
                try
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = rutaArchivo,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo abrir el PDF automáticamente:\n" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("El archivo no se pudo encontrar después de guardarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvRegistradosNave1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvRegistradosNave1.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.Cell && hit.RowIndex >= 0)
                {
                    dgvRegistradosNave1.ClearSelection();
                    dgvRegistradosNave1.Rows[hit.RowIndex].Selected = true;

                    if (TienePermisoEliminarRegistro())
                    {
                        if (MessageBox.Show("¿Estás seguro de eliminar este registro de producción?\n\nEsta acción no se puede deshacer.", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            EliminarRegistroSeleccionadoNave1();
                        }
                        else
                        {
                            dgvRegistradosNave1.ClearSelection();
                        }
                    }
                }
            }
        }

        private bool TienePermisoEliminarRegistro()
        {
            if (string.IsNullOrWhiteSpace(VariablesGlobales.Usuario))
                return false;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();

                    string queryId = "SELECT ID FROM elastosystem_login WHERE Usuario = @USUARIO LIMIT 1";
                    int userId = 0;
                    using (MySqlCommand cmdId = new MySqlCommand(queryId, conn))
                    {
                        cmdId.Parameters.AddWithValue("@USUARIO", VariablesGlobales.Usuario);
                        object result = cmdId.ExecuteScalar();
                        if (result == null || !int.TryParse(result.ToString(), out userId))
                            return false;
                    }

                    string queryPermiso = "SELECT EliminarRegistroProd FROM elastosystem_permisos_menu WHERE ID = @ID LIMIT 1";
                    using (MySqlCommand cmdPerm = new MySqlCommand(queryPermiso, conn))
                    {
                        cmdPerm.Parameters.AddWithValue("@ID", userId);
                        object result = cmdPerm.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToBoolean(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar permisos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return false;
        }

        private void EliminarRegistroSeleccionadoNave1()
        {
            if (dgvRegistradosNave1.SelectedRows.Count == 0)
                return;

            string idRegistro = dgvRegistradosNave1.SelectedRows[0].Cells["ID"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(idRegistro))
            {
                MessageBox.Show("No se pudo obtener el ID del registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = "DELETE FROM elastosystem_produccion_registro_diario WHERE ID = @ID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(idRegistro));
                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarN1();
                            btnActualizarN1.Visible = false;
                            btnRegistrarN1.Visible = false;
                            lblPNCRevisionN1.Visible = false;
                            txbPNCRevisionN1.Visible = false;
                            CargarPendientesN1();
                            CargarRegistradosN1();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRegistradosNave2_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                var hit = dgvRegistradosNave2.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.Cell && hit.RowIndex >= 0)
                {
                    dgvRegistradosNave2.ClearSelection();
                    dgvRegistradosNave2.Rows[hit.RowIndex].Selected = true;

                    if (TienePermisoEliminarRegistro())
                    {
                        if (MessageBox.Show("¿Estás seguro de eliminar este registro de producción?\n\nEsta acción no se puede deshacer.", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            EliminarRegistroSeleccionadoNave2();
                        }
                        else
                        {
                            dgvRegistradosNave2.ClearSelection();
                        }
                    }
                }
            }
        }

        private void EliminarRegistroSeleccionadoNave2()
        {
            if (dgvRegistradosNave2.SelectedRows.Count == 0)
                return;

            string idRegistro = dgvRegistradosNave2.SelectedRows[0].Cells["ID"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(idRegistro))
            {
                MessageBox.Show("No se pudo obtener el ID del registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
                {
                    conn.Open();
                    string query = "DELETE FROM elastosystem_produccion_registro_diario WHERE ID = @ID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(idRegistro));
                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarN2();
                            btnActualizar2.Visible = false;
                            btnRegistrar2.Visible = false;
                            lblPNCRevision2.Visible = false;
                            txbPNCRevision2.Visible = false;
                            CargarPendientesN2();
                            CargarRegistradosN2();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
