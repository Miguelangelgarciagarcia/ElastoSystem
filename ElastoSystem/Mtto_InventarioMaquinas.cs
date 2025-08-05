using DocumentFormat.OpenXml.Office.Word;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElastoSystem
{
    public partial class Mtto_InventarioMaquinas : Form
    {
        public Mtto_InventarioMaquinas()
        {
            InitializeComponent();
        }

        private void MandarALlamarBDInventarioMaquinas()
        {
            string tabla = "SELECT * FROM elastosystem_mtto_inventariomaquinas";
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
            DataTable dt = new DataTable();
            mySqlAdapter.Fill(dt);
            dgvBD.DataSource = dt;
            dgvBD.Columns["ID"].Visible = false;
            dgvBD.Columns["Imagen"].Visible = false;
            dgvBD.Columns["Orden_Trabajo"].Visible = false;
            dgvBD.Columns["Mantenimiento"].Visible = false;
            dgvBD.Columns["Indicador"].Visible = false;
        }
        private void EliminarRegistro()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM elastosystem_mtto_inventariomaquinas WHERE ID = @ID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", lblID.Text);
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Maquina " + txbNombre.Text + " eliminada");
                        }
                        else
                        {
                            MessageBox.Show("No se encontro la maquina con el ID especificado");
                        }
                    }
                    MandarALlamarBDInventarioMaquinas();
                    Limpiar();
                    btnNueva.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ELIMINAR EL REGISTRO: " + ex.Message);
                }
            }
        }
        private void AgregarRegistro()
        {
            bool booordentrabajo = chbOrdenTrabajo.Checked;
            bool boomantenimiento = chbMantenimiento.Checked;
            bool booindicador = chbIndicador.Checked;

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                conn.Open();
                string query;

                if (pbImagen.Image != null)
                {
                    query = "INSERT INTO elastosystem_mtto_inventariomaquinas " +
                        "(Nombre, Modelo, No_Serie, Ubicacion, Imagen, Estatus, Orden_Trabajo, Mantenimiento, Indicador) " +
                        "VALUES (@NOMBRE, @MODELO, @NOSERIE, @UBICACION, @IMAGEN, @ESTATUS, @ORDENTRABAJO, @MANTENIMIENTO, @INDICADOR)";
                }
                else
                {
                    query = "INSERT INTO elastosystem_mtto_inventariomaquinas " +
                        "(Nombre, Modelo, No_Serie, Ubicacion, Estatus, Orden_Trabajo, Mantenimiento, Indicador) " +
                        "VALUES (@NOMBRE, @MODELO, @NOSERIE, @UBICACION, @ESTATUS, @ORDENTRABAJO, @MANTENIMIENTO, @INDICADOR)";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NOMBRE", txbNombre.Text);
                    cmd.Parameters.AddWithValue("@MODELO", txbModelo.Text);
                    cmd.Parameters.AddWithValue("@NOSERIE", txbNumeroSerie.Text);
                    cmd.Parameters.AddWithValue("@UBICACION", cbUbicacion.Text);
                    cmd.Parameters.AddWithValue("@ESTATUS", cbEstatus.Text);
                    cmd.Parameters.AddWithValue("@ORDENTRABAJO", booordentrabajo);
                    cmd.Parameters.AddWithValue("@MANTENIMIENTO", boomantenimiento);
                    cmd.Parameters.AddWithValue("@INDICADOR", booindicador);

                    if (pbImagen.Image != null)
                    {
                        byte[] bytesFoto;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pbImagen.Image.Save(ms, ImageFormat.Jpeg);
                            bytesFoto = ms.ToArray();
                        }
                        cmd.Parameters.AddWithValue("@IMAGEN", bytesFoto);
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Maquina " + txbNombre.Text + " agregada con exito");
                }
            }

            MandarALlamarBDInventarioMaquinas();
            Limpiar();
            btnNueva.PerformClick();
        }
        private void EditarRegistro()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string nombreOriginal = "";
                    using (MySqlCommand cmdSelect = new MySqlCommand("SELECT Nombre FROM elastosystem_mtto_inventariomaquinas WHERE ID = @ID", conn))
                    {
                        cmdSelect.Parameters.AddWithValue("@ID", lblID.Text);
                        using (MySqlDataReader reader = cmdSelect.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nombreOriginal = reader["Nombre"].ToString();
                            }
                        }
                    }

                    string query;
                    MySqlCommand cmd = new MySqlCommand();
                    bool boolordentrabajo = chbOrdenTrabajo.Checked;
                    bool boolmantenimiento = chbMantenimiento.Checked;
                    bool boolindicador = chbIndicador.Checked;

                    if (pbImagen.Image != null && imagencargada == 0)
                    {
                        byte[] bytesFoto;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pbImagen.Image.Save(ms, ImageFormat.Jpeg);
                            bytesFoto = ms.ToArray();
                        }

                        query = "UPDATE elastosystem_mtto_inventariomaquinas " +
                            "SET Nombre = @NOMBRE, Modelo = @MODELO, No_Serie = @NOSERIE, Ubicacion = @UBICACION, Imagen = @IMAGEN, Estatus = @ESTATUS, Orden_Trabajo = @ORDENTRABAJO, Mantenimiento = @MANTENIMIENTO, Indicador = @INDICADOR " +
                            "WHERE ID = @ID";

                        cmd.Parameters.AddWithValue("@IMAGEN", bytesFoto);
                    }
                    else
                    {
                        query = "UPDATE elastosystem_mtto_inventariomaquinas " +
                            "SET Nombre = @NOMBRE, Modelo = @MODELO, No_Serie = @NOSERIE, Ubicacion = @UBICACION, Estatus = @ESTATUS, Orden_Trabajo = @ORDENTRABAJO, Mantenimiento = @MANTENIMIENTO, Indicador = @INDICADOR " +
                            "WHERE ID = @ID";
                    }

                    cmd.Parameters.AddWithValue("@ID", lblID.Text);
                    cmd.Parameters.AddWithValue("@NOMBRE", txbNombre.Text);
                    cmd.Parameters.AddWithValue("@MODELO", txbModelo.Text);
                    cmd.Parameters.AddWithValue("@NOSERIE", txbNumeroSerie.Text);
                    cmd.Parameters.AddWithValue("@UBICACION", cbUbicacion.Text);
                    cmd.Parameters.AddWithValue("@ESTATUS", cbEstatus.Text);
                    cmd.Parameters.AddWithValue("@ORDENTRABAJO", boolordentrabajo);
                    cmd.Parameters.AddWithValue("@MANTENIMIENTO", boolmantenimiento);
                    cmd.Parameters.AddWithValue("@INDICADOR", boolindicador);

                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    if(nombreOriginal != txbNombre.Text.Trim())
                    {
                        ActualizarReferenciasEnOtrasTablas(nombreOriginal, txbNombre.Text.Trim());
                    }

                    MessageBox.Show("Maquina " + txbNombre.Text + " modificada con exito.");
                    MandarALlamarBDInventarioMaquinas();
                    Limpiar();
                    btnNueva.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL MODIFICAR LA MAQUINA: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void ActualizarReferenciasEnOtrasTablas(string nombreOriginal, string nombreNuevo)
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string queryActividades = "UPDATE elastosystem_mtto_actividadesxactivo " +
                                                "SET Activo = @NOMBRE_NUEVO " +
                                                "WHERE Tipo = 'MAQUINA' AND Activo = @NOMBRE_ORIGINAL";

                    using(MySqlCommand cmdActividades = new MySqlCommand(queryActividades, conn))
                    {
                        cmdActividades.Parameters.AddWithValue("@NOMBRE_NUEVO", nombreNuevo);
                        cmdActividades.Parameters.AddWithValue("@NOMBRE_ORIGINAL", nombreOriginal);
                        int registrosActividades = cmdActividades.ExecuteNonQuery();
                    }

                    string queryHistorial = "UPDATE elastosystem_mtto_preventivohistorial " +
                                                "SET Activo = @NOMBRE_NUEVO " +
                                                "WHERE Tipo = 'MAQUINA' AND Activo = @NOMBRE_ORIGINAL";

                    using(MySqlCommand cmdHistorial = new MySqlCommand(queryHistorial, conn))
                    {
                        cmdHistorial.Parameters.AddWithValue("@NOMBRE_NUEVO", nombreNuevo);
                        cmdHistorial.Parameters.AddWithValue("@NOMBRE_ORIGINAL", nombreOriginal);
                        int registrosHistorial = cmdHistorial.ExecuteNonQuery();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR REFERENCIAS: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void Limpiar()
        {
            txbNombre.Clear();
            txbModelo.Clear();
            txbNumeroSerie.Clear();
            cbUbicacion.SelectedIndex = -1;
            cbEstatus.SelectedIndex = -1;
            chbOrdenTrabajo.Checked = false;
            chbMantenimiento.Checked = false;
            chbIndicador.Checked = false;
            pbImagen.Image = null;
            lblID.Text = string.Empty;
        }
        private void CargarImagen()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.png;*.jpg;*.jpeg;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaImagen = openFileDialog.FileName;

                try
                {
                    pbImagen.Image = Image.FromFile(rutaImagen);
                    imagencargada = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                }
            }
        }

        private void Tabuladores()
        {
            txbNombre.TabIndex = 0;
            txbModelo.TabIndex = 1;
            txbNumeroSerie.TabIndex = 2;
            cbUbicacion.TabIndex = 3;
            cbEstatus.TabIndex = 4;
            chbOrdenTrabajo.TabIndex = 5;
            chbMantenimiento.TabIndex = 6;
            chbIndicador.TabIndex = 7;
            btnAgregar.TabIndex = 8;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
            txbBuscador.Clear();
        }
        private void Mtto_InventarioMaquinas_Load(object sender, EventArgs e)
        {
            MandarALlamarBDInventarioMaquinas();
            Tabuladores();
        }

        int imagencargada = 0;

        private void dgvBD_DoubleClick(object sender, EventArgs e)
        {
            imagencargada = 0;
            Tabuladores();
            Limpiar();
            DataGridView dgvBD = (DataGridView)sender;

            if (dgvBD.SelectedCells.Count > 0)
            {
                int rowIndex = dgvBD.SelectedCells[0].RowIndex;

                string id = dgvBD.Rows[rowIndex].Cells[0].Value.ToString();
                lblID.Text = id;

                string nombre = dgvBD.Rows[rowIndex].Cells[1].Value.ToString();
                txbNombre.Text = nombre;

                string modelo = dgvBD.Rows[rowIndex].Cells[2].Value.ToString();
                txbModelo.Text = modelo;

                string no_serie = dgvBD.Rows[rowIndex].Cells[3].Value.ToString();
                txbNumeroSerie.Text = no_serie;

                string ubicacion = dgvBD.Rows[rowIndex].Cells[4].Value.ToString();
                cbUbicacion.Text = ubicacion;

                object imagen = dgvBD.Rows[rowIndex].Cells[5].Value;
                if (imagen != DBNull.Value && imagen != null)
                {
                    try
                    {
                        byte[] imageData = (byte[])imagen;

                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pbImagen.Image = Image.FromStream(ms);
                            imagencargada = 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        pbImagen.Image = null;
                    }
                }
                else
                {
                    pbImagen.Image = null;
                }

                string estatus = dgvBD.Rows[rowIndex].Cells[6].Value.ToString();
                cbEstatus.Text = estatus;

                string orden_trabajo = dgvBD.Rows[rowIndex].Cells[7].Value.ToString();
                if (orden_trabajo == "True")
                {
                    chbOrdenTrabajo.Checked = true;
                }

                string mantenimiento = dgvBD.Rows[rowIndex].Cells[8].Value.ToString();
                if (mantenimiento == "True")
                {
                    chbMantenimiento.Checked = true;
                }

                string indicador = dgvBD.Rows[rowIndex].Cells[9].Value.ToString();
                if (indicador == "True")
                {
                    chbIndicador.Checked = true;
                }
                btnAgregar.Visible = false;
                btnNueva.Visible = true;
                btnEliminar.Visible = true;
                btnModificar.Visible = true;
            }
        }
        private void btnNueva_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnNueva.Visible = false;
            btnAgregar.Visible = true;
            btnEliminar.Visible = false;
            btnModificar.Visible = false;
            txbBuscador.Clear();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarRegistro();
            txbBuscador.Clear();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            EditarRegistro();
            txbBuscador.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CargarImagen();
        }
        private void btnActualizarPermisos_Click(object sender, EventArgs e)
        {

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

                if (string.IsNullOrEmpty(valorBusqueda))
                {
                    MandarALlamarBDInventarioMaquinas();
                }
                else
                {
                    string consulta = "SELECT * FROM elastosystem_mtto_inventariomaquinas WHERE Nombre LIKE @ValorBusqueda OR No_Serie LIKE @ValorBusqueda";

                    MySqlDataAdapter adapatador = new MySqlDataAdapter(consulta, VariablesGlobales.ConexionBDElastotecnica);

                    adapatador.SelectCommand.Parameters.AddWithValue("@ValorBusqueda", "%" + valorBusqueda + "%");

                    DataSet datos = new DataSet();

                    adapatador.Fill(datos, "Resultados");

                    dgvBD.DataSource = datos.Tables["Resultados"];
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR AL BUSCAR MAQUINA: "+ex.Message);
            }
        }
    }
}
