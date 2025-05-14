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
    public partial class Produccion_ActualizarHR : Form
    {
        public Produccion_ActualizarHR(string familia, string producto, string nave, string noOperacion, string area, string descripcion, string produccion, string nombreArea, string cantidadUnidad)
        {
            InitializeComponent();
            lblFamilia.Text = familia;
            lblProducto.Text = producto;
            lblNave.Text = nave;
            lblNoOperacion.Text = noOperacion;
            lblArea.Text = area;
            lblDescripcion.Text = descripcion;
            lblProduccion.Text = produccion;
            txbNombreArea.Clear(); txbCantidadUnidad.Clear();
            txbNombreArea.Text = nombreArea;
            txbCantidadUnidad.Text = cantidadUnidad;
        }

        private void Produccion_ActualizarHR_Load(object sender, EventArgs e)
        {

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

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnGuardarProceso_Click(object sender, EventArgs e)
        {
            if (txbCantidadUnidad.Text == "")
                txbCantidadUnidad.Text = "0";

            switch ((chbNombreArea.Checked, chbCantidadxUnidad.Checked))
            {
                case (false, false):
                    ActualizarUnicoProducto();
                    break;

                case (true, true):
                    ActualizarTodo();
                    break;

                case (true, false):
                    ActualizarNombreAreaGeneral();
                    break;

                case (false, true):
                    ActualizarNombreAreaUnico();
                    break;

            }
        }

        private void ActualizarNombreAreaUnico()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = @"UPDATE elastosystem_produccion_hoja_producto
                                        SET NombreArea = @NOMBRE_AREA
                                    WHERE Producto = @PRODUCTO AND NoOperacion = @NO_OPERACION";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NOMBRE_AREA", txbNombreArea.Text);
                        cmd.Parameters.AddWithValue("@PRODUCTO", lblProducto.Text);
                        cmd.Parameters.AddWithValue("@NO_OPERACION", lblNoOperacion.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            ActualizarCantidadGeneral();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el proceso.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR PROCESO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void ActualizarCantidadGeneral()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = @"UPDATE elastosystem_produccion_hoja_producto
                                        SET CantidadUnidad = @CANTIDAD_UNIDAD
                                    WHERE Familia = @FAMILIA AND NoOperacion = @NO_OPERACION";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CANTIDAD_UNIDAD", txbCantidadUnidad.Text);
                        cmd.Parameters.AddWithValue("@FAMILIA", lblFamilia.Text);
                        cmd.Parameters.AddWithValue("@NO_OPERACION", lblNoOperacion.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Proceso actualizado correctamente.");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el proceso.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR PROCESO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void ActualizarNombreAreaGeneral()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = @"UPDATE elastosystem_produccion_hoja_producto
                                        SET NombreArea = @NOMBRE_AREA
                                    WHERE Familia = @FAMILIA AND NoOperacion = @NO_OPERACION";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NOMBRE_AREA", txbNombreArea.Text);
                        cmd.Parameters.AddWithValue("@FAMILIA", lblFamilia.Text);
                        cmd.Parameters.AddWithValue("@NO_OPERACION", lblNoOperacion.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            ActualizarCantidadUnidadUnico();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el proceso.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR PROCESO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void ActualizarCantidadUnidadUnico()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = @"UPDATE elastosystem_produccion_hoja_producto
                                        SET CantidadUnidad = @CANTIDAD_UNIDAD
                                    WHERE Producto = @PRODUCTO AND NoOperacion = @NO_OPERACION";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CANTIDAD_UNIDAD", txbCantidadUnidad.Text);
                        cmd.Parameters.AddWithValue("@PRODUCTO", lblProducto.Text);
                        cmd.Parameters.AddWithValue("@NO_OPERACION", lblNoOperacion.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Proceso actualizado correctamente.");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el proceso.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR PROCESO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void ActualizarTodo()
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = @"UPDATE elastosystem_produccion_hoja_producto
                                        SET NombreArea = @NOMBRE_AREA,
                                        CantidadUnidad = @CANTIDAD_UNIDAD
                                    WHERE Familia = @FAMILIA AND NoOperacion = @NO_OPERACION";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NOMBRE_AREA", txbNombreArea.Text);
                        cmd.Parameters.AddWithValue("@CANTIDAD_UNIDAD", txbCantidadUnidad.Text);
                        cmd.Parameters.AddWithValue("@FAMILIA", lblFamilia.Text);
                        cmd.Parameters.AddWithValue("@NO_OPERACION", lblNoOperacion.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Proceso actualizado correctamente.");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el proceso.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR PROCESO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void ActualizarUnicoProducto()
        {
            using(MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string query = @"UPDATE elastosystem_produccion_hoja_producto
                                        SET NombreArea = @NOMBRE_AREA,
                                        CantidadUnidad = @CANTIDAD_UNIDAD
                                    WHERE Producto = @PRODUCTO AND NoOperacion = @NO_OPERACION";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NOMBRE_AREA", txbNombreArea.Text);
                        cmd.Parameters.AddWithValue("@CANTIDAD_UNIDAD", txbCantidadUnidad.Text);
                        cmd.Parameters.AddWithValue("@PRODUCTO", lblProducto.Text);
                        cmd.Parameters.AddWithValue("@NO_OPERACION", lblNoOperacion.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if(rowsAffected > 0)
                        {
                            MessageBox.Show("Proceso actualizado correctamente.");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el proceso.");
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR PROCESO: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txbCantidadUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            VariablesGlobales.ValidarNumeroEntero(e, txbCantidadUnidad);
        }

        private void txbCantidadUnidad_Enter(object sender, EventArgs e)
        {
            if(txbCantidadUnidad.Text == "0")
            {
                txbCantidadUnidad.Clear();
            }
        }
    }
}
