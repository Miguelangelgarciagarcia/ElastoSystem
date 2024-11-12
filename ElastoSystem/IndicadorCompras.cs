using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom.Compiler;
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
    public partial class IndicadorCompras : Form
    {
        public IndicadorCompras()
        {
            InitializeComponent();
        }
        private void IndicadorCompras_Load(object sender, EventArgs e)
        {
            string tabla = "SELECT ID, Descripcion, Estatus, OC, FechaInicio, FechaFinal FROM elastosystem_compras_requisicion_desglosada";
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
            DataTable dt = new DataTable();

            mySqlAdapter.Fill(dt);

            dt.Columns.Add("IDFormateado", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                row["IDFormateado"] = "REQ-" + row["ID"].ToString();
            }

            dt.DefaultView.Sort = "FechaInicio DESC";

            dgv.DataSource = dt.DefaultView.ToTable();

            dgv.Columns["IDFormateado"].DisplayIndex = 0;
            dgv.Columns["ID"].Visible = false;

            dgv.Columns["IDFormateado"].HeaderText = "Requisicion";

            IndicadorGlobal();
            DefinirAnios();

        }

        private void DefinirAnios()
        {
            string queryanios = @"SELECT DISTINCT YEAR(FechaInicio) AS Anio
                                  FROM elastosystem_compras_requisicion_desglosada
                                  WHERE FechaInicio IS NOT NULL
                                  ORDER BY Anio";

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(queryanios, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cbAnios.Items.Clear();

                        while (reader.Read())
                        {
                            int anio = reader.GetInt32("Anio");
                            cbAnios.Items.Add(anio);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL CARGAR LOS AÑOS; " + ex.Message);
                }
            }
        }

        private void IndicadorGlobal()
        {
            string query = @"SELECT
                                AVG(
                                    CASE
                                        WHEN DATEDIFF(FechaFinal, FechaInicio) < 0 THEN 0
                                        ELSE DATEDIFF(FechaFinal, FechaInicio)
                                    END
                                ) AS PromedioDiasTranscurridos,
                                COUNT(*) AS RegistrosContados
                            FROM
                                elastosystem_compras_requisicion_desglosada
                            WHERE
                                FechaFinal IS NOT NULL";

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            double promedioDias = reader["PromedioDiasTranscurridos"] != DBNull.Value ? Convert.ToDouble(reader["PromedioDiasTranscurridos"]) : 0.0;
                            int registrosContados = reader["RegistrosContados"] != DBNull.Value ? Convert.ToInt32(reader["RegistrosContados"]) : 0;

                            lblPromedioGlobal.Text = "El promedio global es: " + promedioDias + " dias, con " + registrosContados + " registros";
                        }
                        else
                        {
                            MessageBox.Show("ERROR GLOBAL");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: "+ex.Message);
                }
            }
        }

        private void cbbimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbAnios.SelectedIndex == -1)
            {
                
            }
            else
            {
                string anioSeleccionado = cbAnios.SelectedItem.ToString();

                if (cbbimestre.SelectedIndex == 0)
                {
                    string query = @"
                                        SELECT 
                                            AVG(
                                                CASE
                                                    WHEN DATEDIFF(FechaFinal, FechaInicio) < 0 THEN 0
                                                    ELSE DATEDIFF(FechaFinal, FechaInicio)
                                                END
                                            ) AS PromedioDiasTranscurridos,
                                            COUNT(*) AS RegistrosContados
                                            FROM 
                                                elastosystem_compras_requisicion_desglosada
                                            WHERE 
                                                FechaFinal IS NOT NULL
                                            AND YEAR(FechaInicio) = @ANIO
                                            AND MONTH(FechaInicio) IN (1,2);";

                    MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ANIO", anioSeleccionado);

                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            object promedio = reader["PromedioDiasTranscurridos"];
                            string promedioFormateado = string.Format("{0:F2}", promedio);
                            object registrosContados = reader["RegistrosContados"];

                            if (Convert.ToInt32(registrosContados) == 0)
                            {
                                txbic.Text = string.Empty;
                                lblOCTotal.Text = string.Empty;
                                MessageBox.Show("No se encontraron registros.");
                            }
                            else
                            {
                                lblOCTotal.Text = "El promedio es: " + promedioFormateado + " dias, con " + registrosContados + " registros";
                                txbic.Text = promedioFormateado;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else if (cbbimestre.SelectedIndex == 1)
                {
                    string query = @"
                                        SELECT 
                                            AVG(
                                                CASE
                                                    WHEN DATEDIFF(FechaFinal, FechaInicio) < 0 THEN 0
                                                    ELSE DATEDIFF(FechaFinal, FechaInicio)
                                                END
                                            ) AS PromedioDiasTranscurridos,
                                            COUNT(*) AS RegistrosContados
                                            FROM 
                                                elastosystem_compras_requisicion_desglosada
                                            WHERE 
                                                FechaFinal IS NOT NULL
                                            AND YEAR(FechaInicio) = @ANIO
                                            AND MONTH(FechaInicio) IN (3,4);";

                    MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ANIO", anioSeleccionado);

                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            object promedio = reader["PromedioDiasTranscurridos"];
                            string promedioFormateado = string.Format("{0:F2}", promedio);
                            object registrosContados = reader["RegistrosContados"];

                            if (Convert.ToInt32(registrosContados) == 0)
                            {
                                txbic.Text = string.Empty;
                                lblOCTotal.Text = string.Empty;
                                MessageBox.Show("No se encontraron registros.");
                            }
                            else
                            {
                                lblOCTotal.Text = "El promedio es: " + promedioFormateado + " dias, con " + registrosContados + " registros";
                                txbic.Text = promedioFormateado;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else if (cbbimestre.SelectedIndex == 2)
                {
                    string query = @"
                                        SELECT 
                                            AVG(
                                                CASE
                                                    WHEN DATEDIFF(FechaFinal, FechaInicio) < 0 THEN 0
                                                    ELSE DATEDIFF(FechaFinal, FechaInicio)
                                                END
                                            ) AS PromedioDiasTranscurridos,
                                            COUNT(*) AS RegistrosContados
                                            FROM 
                                                elastosystem_compras_requisicion_desglosada
                                            WHERE 
                                                FechaFinal IS NOT NULL
                                            AND YEAR(FechaInicio) = @ANIO
                                            AND MONTH(FechaInicio) IN (5,6);";

                    MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ANIO", anioSeleccionado);

                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            object promedio = reader["PromedioDiasTranscurridos"];
                            string promedioFormateado = string.Format("{0:F2}", promedio);
                            object registrosContados = reader["RegistrosContados"];

                            if (Convert.ToInt32(registrosContados) == 0)
                            {
                                txbic.Text = string.Empty;
                                lblOCTotal.Text = string.Empty;
                                MessageBox.Show("No se encontraron registros.");
                            }
                            else
                            {
                                lblOCTotal.Text = "El promedio es: " + promedioFormateado + " dias, con " + registrosContados + " registros";
                                txbic.Text = promedioFormateado;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else if (cbbimestre.SelectedIndex == 3)
                {
                    string query = @"
                                        SELECT 
                                            AVG(
                                                CASE
                                                    WHEN DATEDIFF(FechaFinal, FechaInicio) < 0 THEN 0
                                                    ELSE DATEDIFF(FechaFinal, FechaInicio)
                                                END
                                            ) AS PromedioDiasTranscurridos,
                                            COUNT(*) AS RegistrosContados
                                            FROM 
                                                elastosystem_compras_requisicion_desglosada
                                            WHERE 
                                                FechaFinal IS NOT NULL
                                            AND YEAR(FechaInicio) = @ANIO
                                            AND MONTH(FechaInicio) IN (7,8);";

                    MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ANIO", anioSeleccionado);

                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            object promedio = reader["PromedioDiasTranscurridos"];
                            string promedioFormateado = string.Format("{0:F2}", promedio);
                            object registrosContados = reader["RegistrosContados"];

                            if (Convert.ToInt32(registrosContados) == 0)
                            {
                                txbic.Text = string.Empty;
                                lblOCTotal.Text = string.Empty;
                                MessageBox.Show("No se encontraron registros.");
                            }
                            else
                            {
                                lblOCTotal.Text = "El promedio es: " + promedioFormateado + " dias, con " + registrosContados + " registros";
                                txbic.Text = promedioFormateado;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else if (cbbimestre.SelectedIndex == 4)
                {
                    string query = @"
                                        SELECT 
                                            AVG(
                                                CASE
                                                    WHEN DATEDIFF(FechaFinal, FechaInicio) < 0 THEN 0
                                                    ELSE DATEDIFF(FechaFinal, FechaInicio)
                                                END
                                            ) AS PromedioDiasTranscurridos,
                                            COUNT(*) AS RegistrosContados
                                            FROM 
                                                elastosystem_compras_requisicion_desglosada
                                            WHERE 
                                                FechaFinal IS NOT NULL
                                            AND YEAR(FechaInicio) = @ANIO
                                            AND MONTH(FechaInicio) IN (9,10);";

                    MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ANIO", anioSeleccionado);

                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            object promedio = reader["PromedioDiasTranscurridos"];
                            string promedioFormateado = string.Format("{0:F2}", promedio);
                            object registrosContados = reader["RegistrosContados"];

                            if (Convert.ToInt32(registrosContados) == 0)
                            {
                                txbic.Text = string.Empty;
                                lblOCTotal.Text = string.Empty;
                                MessageBox.Show("No se encontraron registros.");
                            }
                            else
                            {
                                lblOCTotal.Text = "El promedio es: " + promedioFormateado + " dias, con " + registrosContados + " registros";
                                txbic.Text = promedioFormateado;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    string query = @"
                                        SELECT 
                                            AVG(
                                                CASE
                                                    WHEN DATEDIFF(FechaFinal, FechaInicio) < 0 THEN 0
                                                    ELSE DATEDIFF(FechaFinal, FechaInicio)
                                                END
                                            ) AS PromedioDiasTranscurridos,
                                            COUNT(*) AS RegistrosContados
                                            FROM 
                                                elastosystem_compras_requisicion_desglosada
                                            WHERE 
                                                FechaFinal IS NOT NULL
                                            AND YEAR(FechaInicio) = @ANIO
                                            AND MONTH(FechaInicio) IN (11,12);";

                    MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ANIO", anioSeleccionado);

                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            object promedio = reader["PromedioDiasTranscurridos"];
                            string promedioFormateado = string.Format("{0:F2}", promedio);
                            object registrosContados = reader["RegistrosContados"];

                            if (Convert.ToInt32(registrosContados) == 0)
                            {
                                txbic.Text = string.Empty;
                                lblOCTotal.Text = string.Empty;
                                MessageBox.Show("No se encontraron registros.");
                            }
                            else
                            {
                                lblOCTotal.Text = "El promedio es: " + promedioFormateado + " dias, con " + registrosContados + " registros";
                                txbic.Text = promedioFormateado;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void cbanio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbAnios.SelectedIndex != -1)
            {
                string anioSeleccionado = cbAnios.SelectedItem.ToString();

                if (string.IsNullOrWhiteSpace(cbbimestre.Text))
                {
                    string query = @"
                                    SELECT 
                                        AVG(
                                            CASE
                                                WHEN DATEDIFF(FechaFinal, FechaInicio) < 0 THEN 0
                                                ELSE DATEDIFF(FechaFinal, FechaInicio)
                                            END
                                        ) AS PromedioDiasTranscurridos,
                                        COUNT(*) AS RegistrosContados
                                        FROM 
                                            elastosystem_compras_requisicion_desglosada
                                        WHERE 
                                            FechaFinal IS NOT NULL
                                        AND YEAR(FechaInicio) = @ANIO;";

                    MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ANIO", anioSeleccionado);

                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            object promedio = reader["PromedioDiasTranscurridos"];
                            string promedioFormateado = string.Format("{0:F2}", promedio);
                            object registrosContados = reader["RegistrosContados"];

                            if (Convert.ToInt32(registrosContados) == 0)
                            {
                                txbic.Text = string.Empty;
                                lblOCTotal.Text = string.Empty;
                                MessageBox.Show("No se encontraron registros.");
                            }
                            else
                            {
                                lblOCTotal.Text = "El promedio es: " + promedioFormateado + " dias, con " + registrosContados + " registros";
                                txbic.Text = promedioFormateado;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    if(cbbimestre.SelectedIndex == 0)
                    {
                        string query = @"
                                        SELECT 
                                            AVG(
                                                CASE
                                                    WHEN DATEDIFF(FechaFinal, FechaInicio) < 0 THEN 0
                                                    ELSE DATEDIFF(FechaFinal, FechaInicio)
                                                END
                                            ) AS PromedioDiasTranscurridos,
                                            COUNT(*) AS RegistrosContados
                                            FROM 
                                                elastosystem_compras_requisicion_desglosada
                                            WHERE 
                                                FechaFinal IS NOT NULL
                                            AND YEAR(FechaInicio) = @ANIO
                                            AND MONTH(FechaInicio) IN (1,2);";

                        MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                        try
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ANIO", anioSeleccionado);

                            MySqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                object promedio = reader["PromedioDiasTranscurridos"];
                                string promedioFormateado = string.Format("{0:F2}", promedio);
                                object registrosContados = reader["RegistrosContados"];

                                if (Convert.ToInt32(registrosContados) == 0)
                                {
                                    txbic.Text = string.Empty;
                                    lblOCTotal.Text = string.Empty;
                                    MessageBox.Show("No se encontraron registros.");
                                }
                                else
                                {
                                    lblOCTotal.Text = "El promedio es: " + promedioFormateado + " dias, con " + registrosContados + " registros";
                                    txbic.Text = promedioFormateado;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                    else if (cbbimestre.SelectedIndex == 1)
                    {
                        string query = @"
                                        SELECT 
                                            AVG(
                                                CASE
                                                    WHEN DATEDIFF(FechaFinal, FechaInicio) < 0 THEN 0
                                                    ELSE DATEDIFF(FechaFinal, FechaInicio)
                                                END
                                            ) AS PromedioDiasTranscurridos,
                                            COUNT(*) AS RegistrosContados
                                            FROM 
                                                elastosystem_compras_requisicion_desglosada
                                            WHERE 
                                                FechaFinal IS NOT NULL
                                            AND YEAR(FechaInicio) = @ANIO
                                            AND MONTH(FechaInicio) IN (3,4);";

                        MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                        try
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ANIO", anioSeleccionado);

                            MySqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                object promedio = reader["PromedioDiasTranscurridos"];
                                string promedioFormateado = string.Format("{0:F2}", promedio);
                                object registrosContados = reader["RegistrosContados"];

                                if (Convert.ToInt32(registrosContados) == 0)
                                {
                                    txbic.Text = string.Empty;
                                    lblOCTotal.Text = string.Empty;
                                    MessageBox.Show("No se encontraron registros.");
                                }
                                else
                                {
                                    lblOCTotal.Text = "El promedio es: " + promedioFormateado + " dias, con " + registrosContados + " registros";
                                    txbic.Text = promedioFormateado;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                    else if (cbbimestre.SelectedIndex == 2)
                    {
                        string query = @"
                                        SELECT 
                                            AVG(
                                                CASE
                                                    WHEN DATEDIFF(FechaFinal, FechaInicio) < 0 THEN 0
                                                    ELSE DATEDIFF(FechaFinal, FechaInicio)
                                                END
                                            ) AS PromedioDiasTranscurridos,
                                            COUNT(*) AS RegistrosContados
                                            FROM 
                                                elastosystem_compras_requisicion_desglosada
                                            WHERE 
                                                FechaFinal IS NOT NULL
                                            AND YEAR(FechaInicio) = @ANIO
                                            AND MONTH(FechaInicio) IN (5,6);";

                        MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                        try
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ANIO", anioSeleccionado);

                            MySqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                object promedio = reader["PromedioDiasTranscurridos"];
                                string promedioFormateado = string.Format("{0:F2}", promedio);
                                object registrosContados = reader["RegistrosContados"];

                                if (Convert.ToInt32(registrosContados) == 0)
                                {
                                    txbic.Text = string.Empty;
                                    lblOCTotal.Text = string.Empty;
                                    MessageBox.Show("No se encontraron registros.");
                                }
                                else
                                {
                                    lblOCTotal.Text = "El promedio es: " + promedioFormateado + " dias, con " + registrosContados + " registros";
                                    txbic.Text = promedioFormateado;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                    else if(cbbimestre.SelectedIndex == 3)
                    {
                        string query = @"
                                        SELECT 
                                            AVG(
                                                CASE
                                                    WHEN DATEDIFF(FechaFinal, FechaInicio) < 0 THEN 0
                                                    ELSE DATEDIFF(FechaFinal, FechaInicio)
                                                END
                                            ) AS PromedioDiasTranscurridos,
                                            COUNT(*) AS RegistrosContados
                                            FROM 
                                                elastosystem_compras_requisicion_desglosada
                                            WHERE 
                                                FechaFinal IS NOT NULL
                                            AND YEAR(FechaInicio) = @ANIO
                                            AND MONTH(FechaInicio) IN (7,8);";

                        MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                        try
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ANIO", anioSeleccionado);

                            MySqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                object promedio = reader["PromedioDiasTranscurridos"];
                                string promedioFormateado = string.Format("{0:F2}", promedio);
                                object registrosContados = reader["RegistrosContados"];

                                if (Convert.ToInt32(registrosContados) == 0)
                                {
                                    txbic.Text = string.Empty;
                                    lblOCTotal.Text = string.Empty;
                                    MessageBox.Show("No se encontraron registros.");
                                }
                                else
                                {
                                    lblOCTotal.Text = "El promedio es: " + promedioFormateado + " dias, con " + registrosContados + " registros";
                                    txbic.Text = promedioFormateado;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                    else if(cbbimestre.SelectedIndex == 4)
                    {
                        string query = @"
                                        SELECT 
                                            AVG(
                                                CASE
                                                    WHEN DATEDIFF(FechaFinal, FechaInicio) < 0 THEN 0
                                                    ELSE DATEDIFF(FechaFinal, FechaInicio)
                                                END
                                            ) AS PromedioDiasTranscurridos,
                                            COUNT(*) AS RegistrosContados
                                            FROM 
                                                elastosystem_compras_requisicion_desglosada
                                            WHERE 
                                                FechaFinal IS NOT NULL
                                            AND YEAR(FechaInicio) = @ANIO
                                            AND MONTH(FechaInicio) IN (9,10);";

                        MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                        try
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ANIO", anioSeleccionado);

                            MySqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                object promedio = reader["PromedioDiasTranscurridos"];
                                string promedioFormateado = string.Format("{0:F2}", promedio);
                                object registrosContados = reader["RegistrosContados"];

                                if (Convert.ToInt32(registrosContados) == 0)
                                {
                                    txbic.Text = string.Empty;
                                    lblOCTotal.Text = string.Empty;
                                    MessageBox.Show("No se encontraron registros.");
                                }
                                else
                                {
                                    lblOCTotal.Text = "El promedio es: " + promedioFormateado + " dias, con " + registrosContados + " registros";
                                    txbic.Text = promedioFormateado;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                    else
                    {
                        string query = @"
                                        SELECT 
                                            AVG(
                                                CASE
                                                    WHEN DATEDIFF(FechaFinal, FechaInicio) < 0 THEN 0
                                                    ELSE DATEDIFF(FechaFinal, FechaInicio)
                                                END
                                            ) AS PromedioDiasTranscurridos,
                                            COUNT(*) AS RegistrosContados
                                            FROM 
                                                elastosystem_compras_requisicion_desglosada
                                            WHERE 
                                                FechaFinal IS NOT NULL
                                            AND YEAR(FechaInicio) = @ANIO
                                            AND MONTH(FechaInicio) IN (11,12);";

                        MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
                        try
                        {
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ANIO", anioSeleccionado);

                            MySqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                object promedio = reader["PromedioDiasTranscurridos"];
                                string promedioFormateado = string.Format("{0:F2}", promedio);
                                object registrosContados = reader["RegistrosContados"];


                                if (Convert.ToInt32(registrosContados) == 0)
                                {
                                    txbic.Text = string.Empty;
                                    lblOCTotal.Text = string.Empty;
                                    MessageBox.Show("No se encontraron registros.");
                                }
                                else
                                {
                                    lblOCTotal.Text = "El promedio es: " + promedioFormateado + " dias, con " + registrosContados + " registros";
                                    txbic.Text = promedioFormateado;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }

        private void txbic_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txbic.Text, out double valor))
            {
                if (valor >=0 && valor <= 3)
                {
                    txbic.BackColor = System.Drawing.Color.Green;
                    txbic.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    txbic.BackColor = System.Drawing.Color.Red;
                    txbic.ForeColor = System.Drawing.Color.White;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txbic.Text))
                {
                    txbic.BackColor = System.Drawing.Color.White;
                    txbic.ForeColor = System.Drawing.Color.Black;
                }
            }
        }
    }
}
