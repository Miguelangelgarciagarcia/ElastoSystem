using Gma.QrCodeNet.Encoding.Windows.Render;
using Gma.QrCodeNet.Encoding;
using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Vml;
using static QRCoder.PayloadGenerator;

namespace ElastoSystem
{
    public partial class NuevoUsuarioRH : Form
    {
        int opc = 0;
        public NuevoUsuarioRH()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cbEstatus.Text == string.Empty || txbNom.Text == string.Empty || txbApPat.Text == string.Empty || txbApMa.Text == string.Empty ||
                cbSex.Text == string.Empty || tbFechaNacimiento.Text == string.Empty || cbLugarNacimiento.Text == string.Empty || txbIM.Text == string.Empty ||
                txbRF.Text == string.Empty || txCURP.Text == string.Empty || txbCPFiscal.Text == string.Empty || cbDepartamento.Text == string.Empty || cbPuesto.Text == string.Empty||
                txbCalle.Text == string.Empty || txbColonia.Text == string.Empty || txbPoblacion.Text == string.Empty || cbEntidadFederativa.Text == string.Empty || txbPais.Text == string.Empty ||
                txbCorreo1.Text == string.Empty || txbCP.Text == string.Empty || txbTelefono1.Text == string.Empty || cbNivelEstudios.Text == string.Empty || cbEstadoCivil.Text == string.Empty)
            {
                MessageBox.Show("FAVOR DE LLENAR TODOS LOS CAMPOS OBLIGATORIOS");
                pbCampos.Visible = true; lblCampos.Visible = true; pbEstatus.Visible = true; pbNombre.Visible = true; pbApellidoPaterno.Visible = true; pbApellidoMaterno.Visible = true; 
                pbSexo.Visible = true; pbFechaNacimiento.Visible = true; pbLugarNacimiento.Visible = true; pbIMSS.Visible = true; pbRFC.Visible = true; pbCURP.Visible = true; pbCodigoPostalFiscal.Visible = true; 
                pbDepartamento.Visible = true; pbPuesto.Visible = true; pbCalle.Visible = true; pbColonia.Visible = true; pbPoblacion.Visible = true; pbEntidadFederativa.Visible = true; pbPais.Visible = true; 
                pbCorreoElectronico.Visible = true; pbCodigoPostal.Visible = true; pbTelefono.Visible = true; pbNivelEstudios.Visible = true; pbEstadoCivil.Visible = true;
                return;
            }
            else
            {
                pbCampos.Visible = false; lblCampos.Visible = false; pbEstatus.Visible = false; pbNombre.Visible = false; pbApellidoPaterno.Visible = false; pbApellidoMaterno.Visible = false;
                pbSexo.Visible = false; pbFechaNacimiento.Visible = false; pbLugarNacimiento.Visible = false; pbIMSS.Visible = false; pbRFC.Visible = false; pbCURP.Visible = false; pbCodigoPostalFiscal.Visible = false;
                pbDepartamento.Visible = false; pbPuesto.Visible = false; pbCalle.Visible = false; pbColonia.Visible = false; pbPoblacion.Visible = false; pbEntidadFederativa.Visible = false; pbPais.Visible = false;
                pbCorreoElectronico.Visible = false; pbCodigoPostal.Visible = false; pbTelefono.Visible = false; pbNivelEstudios.Visible = false; pbEstadoCivil.Visible = false;
            }

            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                if (opc == 1)
                {
                    byte[] bytesFoto;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pbFoto.Image.Save(ms, ImageFormat.Jpeg);
                        bytesFoto = ms.ToArray();
                    }
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO elastosystem_rh (ID, Nombre, Apellido_Paterno, Apellido_Materno, CURP, Foto, Estatus, Sexo, Fecha_Nacimiento, Lugar_Nacimiento, IMSS, RFC, CPF, Departamento, Puesto, CalleYNum, Colonia, Poblacion, EntidadFederativa, Pais, Correo1, Correo2, CP, Telefono1, Telefono2, Nivel_Estudios, Profesion, Estado_Civil, Tipo_Sangre) VALUES ('" + cbClave.Text + "', '" + txbNom.Text + "', '" + txbApPat.Text + "', '" + txbApMa.Text + "', '" + txCURP.Text + "', @Foto, '" + cbEstatus.Text + "', '" + cbSex.Text + "', '" + tbFechaNacimiento.Text + "', '" + cbLugarNacimiento.Text + "', '" + txbIM.Text + "', '" + txbRF.Text + "', '" + txbCPFiscal.Text + "', '" + cbDepartamento.Text + "', '" + cbPuesto.Text + "', '" + txbCalle.Text + "', '" + txbColonia.Text + "', '" + txbPoblacion.Text + "', '" + cbEntidadFederativa.Text + "', '" + txbPais.Text + "', '" + txbCorreo1.Text + "', '" + txbCorreo2.Text + "', '" + txbCP.Text + "', '" + txbTelefono1.Text + "', '" + txbTelefono2.Text + "', '" + cbNivelEstudios.Text + "', '" + txbProfesion.Text + "', '" + cbEstadoCivil.Text + "', '" + cbTipoSangre.Text + "');";
                    cmd.Parameters.AddWithValue("@Foto", bytesFoto);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO elastosystem_rh (ID, Nombre, Apellido_Paterno, Apellido_Materno, CURP, Estatus, Sexo, Fecha_Nacimiento, Lugar_Nacimiento, IMSS, RFC, CPF, Departamento, Puesto, CalleYNum, Colonia, Poblacion, EntidadFederativa, Pais, Correo1, Correo2, CP, Telefono1, Telefono2, Nivel_Estudios, Profesion, Estado_Civil, Tipo_Sangre) VALUES ('" + cbClave.Text + "', '" + txbNom.Text + "', '" + txbApPat.Text + "', '" + txbApMa.Text + "', '" + txCURP.Text + "', '" + cbEstatus.Text + "', '" + cbSex.Text + "', '" + tbFechaNacimiento.Text + "', '" + cbLugarNacimiento.Text + "', '" + txbIM.Text + "', '" + txbRF.Text + "', '" + txbCPFiscal.Text + "', '" + cbDepartamento.Text + "', '" + cbPuesto.Text + "', '" + txbCalle.Text + "', '" + txbColonia.Text + "', '" + txbPoblacion.Text + "', '" + cbEntidadFederativa.Text + "', '" + txbPais.Text + "', '" + txbCorreo1.Text + "', '" + txbCorreo2.Text + "', '" + txbCP.Text + "', '" + txbTelefono1.Text + "', '" + txbTelefono2.Text + "', '" + cbNivelEstudios.Text + "', '" + txbProfesion.Text + "', '" + cbEstadoCivil.Text + "', '" + cbTipoSangre.Text + "');";
                    cmd.ExecuteNonQuery();
                }
                pbFoto.Image = null;
                MessageBox.Show("TRABAJADOR " + cbClave.Text + " REGISTRADO CON EXITO");
                cbEstatus.SelectedIndex = -1; txbNom.Clear(); txbApPat.Clear(); txbApMa.Clear(); cbSex.SelectedIndex = -1; tbFechaNacimiento.Clear(); cbLugarNacimiento.SelectedIndex = -1; 
                txbIM.Clear(); txbIM.Clear(); txbRF.Clear(); txCURP.Clear(); txbCPFiscal.Clear(); cbDepartamento.SelectedIndex = -1; cbPuesto.SelectedIndex = -1; txbCalle.Clear(); txbColonia.Clear(); 
                txbPoblacion.Clear(); cbEntidadFederativa.SelectedIndex = -1; txbPais.Clear(); txbCorreo1.Clear(); txbCorreo2.Clear(); txbCP.Clear(); txbTelefono1.Clear(); txbTelefono2.Clear(); 
                cbNivelEstudios.SelectedIndex = -1; txbProfesion.Clear(); cbEstadoCivil.SelectedIndex = -1; cbTipoSangre.SelectedIndex = -1; lblNombre.Text = "NUEVO TRABAJADOR"; 
                btnAgergarUsuario.Enabled = true; btnEditarUsuario.Enabled = false;
                MandarALlamarNoTrabajadores();
                NuevoNoTrabajador();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL REGISTRAR AL TRABAJADOR " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            GeneraQr();

        }

        private void NuevoUsuarioRH_Load(object sender, EventArgs e)
        {
            //CargarTrabajadores();
            if (rbJS.Checked = true)
            {
                rbJN.Checked = false;
                txbSalarioxHora.ReadOnly = true;
                txbHorasxDia.ReadOnly = true;
                txbDiasxSemana.ReadOnly = true;
            }
            else if (rbJN.Checked = true)
            {
                rbJS.Checked = false;
                txbSalarioxHora.ReadOnly = false;
                txbHorasxDia.ReadOnly = false;
                txbDiasxSemana.ReadOnly = false;
            }
            else
            {

            }

            MandarALlamarNoTrabajadores();
            NuevoNoTrabajador();
            BloquearBotonDeEditar();

        }

        private void CargarTrabajadores()
        {
            try
            {
                string query = "SELECT ID, Nombre, Apellido_Paterno, Apellido_Materno, Estatus FROM elastosystem_rh";
                MySqlDataAdapter adaptador = new MySqlDataAdapter(query, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dgvTrabajadores.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CARGAR REGISTRO DE TRABAJADORES: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MandarALlamarInformacion();
            BloquearBotonDeAgregar();
            HabilitarBotonDeEditar();
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        private void HabilitarBotonDeEditar()
        {
            btnEditarUsuario.Enabled = true;
        }
        private void BloquearBotonDeEditar()
        {
            btnEditarUsuario.Enabled = false;
        }
        private void BloquearBotonDeAgregar()
        {
            btnAgergarUsuario.Enabled = false;
        }
        private void GeneraQr()
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(cbClave.Text.Trim(), out qrCode);

            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);

            var imagenTemporal = new Bitmap(ms);
            var imagen = new Bitmap(imagenTemporal, new Size(new Point(150, 150)));
            pbqr.Image = imagen;

        }
        private void NuevoNoTrabajador()
        {
            string ultimoItem = cbClave.Items[cbClave.Items.Count - 1].ToString();
            int.TryParse(ultimoItem, out int resultado);
            resultado = resultado + 1;
            cbClave.Text = resultado.ToString();
        }
        private void MandarALlamarNoTrabajadores()
        {
            cbClave.Items.Clear();
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT ID FROM elastosystem_rh";
            try
            {
                HashSet<string> unicos = new HashSet<string>();
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbClave.Items.Add(reader["ID"].ToString());
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
        private void ActualizarDatos()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                if (opc == 1)
                {
                    byte[] bytesFoto;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pbFoto.Image.Save(ms, ImageFormat.Jpeg);
                        bytesFoto = ms.ToArray();
                    }
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE elastosystem_rh SET Foto = @Foto, Estatus = '" + cbEstatus.Text + "', Nombre = '" + txbNom.Text + "', Apellido_Paterno = '" + txbApPat.Text + "', Apellido_Materno = '" + txbApMa.Text + "', Sexo = '" + cbSex.Text + "', Fecha_Nacimiento = '" + tbFechaNacimiento.Text + "', Lugar_Nacimiento = '" + cbLugarNacimiento.Text + "', IMSS = '" + txbIM.Text + "', RFC = '" + txbRF.Text + "', CURP = '" + txCURP.Text + "', CPF = '" + txbCPFiscal.Text + "', Departamento = '" + cbDepartamento.Text + "', Puesto = '" + cbPuesto.Text + "', CalleYNum = '" + txbCalle.Text + "', Colonia = '" + txbColonia.Text + "' , Poblacion = '" + txbPoblacion.Text + "', EntidadFederativa = '" + cbEntidadFederativa.Text + "', Pais = '" + txbPais.Text + "', Correo1 = '" + txbCorreo1.Text + "', Correo2 = '" + txbCorreo2.Text + "', CP = '" + txbCP.Text + "', Telefono1 = '" + txbTelefono1.Text + "', Telefono2 = '" + txbTelefono2.Text + "', Nivel_Estudios = '" + cbNivelEstudios.Text + "', Profesion = '" + txbProfesion.Text + "', Estado_Civil = '" + cbEstadoCivil.Text + "', Tipo_Sangre = '" + cbTipoSangre.Text + "'  WHERE ID = '" + cbClave.Text + "'";
                    cmd.Parameters.AddWithValue("@Foto", bytesFoto);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE elastosystem_rh SET Estatus = '" + cbEstatus.Text + "', Nombre = '" + txbNom.Text + "', Apellido_Paterno = '" + txbApPat.Text + "', Apellido_Materno = '" + txbApMa.Text + "', Sexo = '" + cbSex.Text + "', Fecha_Nacimiento = '" + tbFechaNacimiento.Text + "', Lugar_Nacimiento = '" + cbLugarNacimiento.Text + "', IMSS = '" + txbIM.Text + "', RFC = '" + txbRF.Text + "', CURP = '" + txCURP.Text + "', CPF = '" + txbCPFiscal.Text + "', Departamento = '" + cbDepartamento.Text + "', Puesto = '" + cbPuesto.Text + "', CalleYNum = '" + txbCalle.Text + "', Colonia = '" + txbColonia.Text + "' , Poblacion = '" + txbPoblacion.Text + "', EntidadFederativa = '" + cbEntidadFederativa.Text + "', Pais = '" + txbPais.Text + "', Correo1 = '" + txbCorreo1.Text + "', Correo2 = '" + txbCorreo2.Text + "', CP = '" + txbCP.Text + "', Telefono1 = '" + txbTelefono1.Text + "', Telefono2 = '" + txbTelefono2.Text + "', Nivel_Estudios = '" + cbNivelEstudios.Text + "', Profesion = '" + txbProfesion.Text + "', Estado_Civil = '" + cbEstadoCivil.Text + "', Tipo_Sangre = '" + cbTipoSangre.Text + "'  WHERE ID = '" + cbClave.Text + "'";
                    cmd.ExecuteNonQuery();
                }
                pbFoto.Image = null;
                MessageBox.Show("DATOS ACTUALIZADOS CON EXITO");
                cbEstatus.SelectedIndex = -1; txbNom.Clear(); txbApPat.Clear(); txbApMa.Clear(); cbSex.SelectedIndex = -1; tbFechaNacimiento.Clear(); cbLugarNacimiento.SelectedIndex = -1; txbIM.Clear(); 
                txbRF.Clear(); txCURP.Clear(); txbCPFiscal.Clear(); cbDepartamento.SelectedIndex = -1; cbPuesto.SelectedIndex = -1; txbCalle.Clear(); txbColonia.Clear(); txbPoblacion.Clear(); 
                cbEntidadFederativa.SelectedIndex = -1; txbPais.Clear(); txbCorreo1.Clear(); txbCorreo2.Clear(); txbCP.Clear(); txbTelefono1.Clear(); txbTelefono2.Clear(); 
                cbNivelEstudios.SelectedIndex = -1; txbProfesion.Clear(); cbEstadoCivil.SelectedIndex = -1; cbTipoSangre.SelectedIndex = -1; lblNombre.Text = "NUEVO TRABAJADOR"; 
                btnAgergarUsuario.Enabled = true; btnEditarUsuario.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }



        }
        private void MandarALlamarInformacion()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            String codigo = cbClave.Text;
            MySqlDataReader reader = null;
            string sql = "SELECT * FROM elastosystem_rh WHERE ID = @ID";
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                comando.Parameters.AddWithValue("@ID", codigo);
                reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string nombre = reader.GetString("Nombre");
                        string apellidoPaterno = reader.GetString("Apellido_Paterno");
                        string apellidoMaterno = reader.GetString("Apellido_Materno");
                        lblNombre.Text = $"{nombre} {apellidoPaterno} {apellidoMaterno}";
                        txbNom.Text = nombre;
                        txbApPat.Text = apellidoPaterno;
                        txbApMa.Text = apellidoMaterno;
                        try
                        {
                            if(!reader.IsDBNull(reader.GetOrdinal("Foto")))
                            {
                                byte[] imageData = (byte[])reader["Foto"];
                                using(MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pbFoto.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                pbFoto.Image = null;
                            }
                        }
                        catch
                        {
                            pbFoto.Image = null;
                        }
                        cbEstatus.Text = reader.GetString("Estatus");
                        cbSex.Text = reader.GetString("Sexo");
                        tbFechaNacimiento.Text = reader.GetString("Fecha_Nacimiento");
                        txCURP.Text = reader.GetString("CURP");
                        cbLugarNacimiento.Text = reader.GetString("Lugar_Nacimiento");
                        txbIM.Text = reader.GetString("IMSS");
                        txbRF.Text = reader.GetString("RFC");
                        txbCPFiscal.Text = reader["CPF"].ToString();
                        cbDepartamento.Text = reader.GetString("Departamento");
                        cbPuesto.Text = reader.GetString("Puesto");
                        txbCalle.Text = reader.GetString("CalleYNum");
                        txbColonia.Text = reader.GetString("Colonia");
                        txbPoblacion.Text = reader.GetString("Poblacion");
                        cbEntidadFederativa.Text = reader.GetString("EntidadFederativa");
                        txbPais.Text = reader.GetString("Pais");
                        txbCorreo1.Text = reader.GetString("Correo1");
                        txbCorreo2.Text = reader.GetString("Correo2");
                        txbCP.Text = reader.GetString("CP");
                        txbTelefono1.Text = reader.GetString("Telefono1");
                        txbTelefono2.Text = reader.GetString("Telefono2");
                        cbNivelEstudios.Text = reader.GetString("Nivel_Estudios");
                        txbProfesion.Text = reader.GetString("Profesion");
                        cbEstadoCivil.Text = reader.GetString("Estado_Civil");
                        cbTipoSangre.Text = reader.GetString("Tipo_Sangre");
                        int jcompleta = reader.GetInt32("Jornada_Completa");
                        if (jcompleta == 0)
                        {
                            rbJN.Checked = true;
                            txbSalarioxHora.ReadOnly = false;
                            txbHorasxDia.ReadOnly = false;
                            txbDiasxSemana.ReadOnly = false;
                        }
                        else
                        {
                            rbJS.Checked = true;
                        }
                        txbSalarioxDia.Text = reader["Salario_Dia"].ToString();
                        txbSalarioxHora.Text = reader["Salario_Hora"].ToString();
                        txbHorasxDia.Text = reader["Horas_Dia"].ToString();
                        txbDiasxSemana.Text = reader["Dias_Semana"].ToString();
                        txbFechaApli.Text = reader.GetString("Fecha_Aplica");
                        cbFormaPago.Text = reader.GetString("Forma_Pago");
                    }
                }
                else
                {
                    lblNombre.Text = "ERROR LLAMAR A SISTEMAS";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: "+ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //NuevoUsuarioRH_Load(this, EventArgs.Empty);
        }

        private void rbJS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (cbEstatus.Text == string.Empty || txbNom.Text == string.Empty || txbApPat.Text == string.Empty || txbApMa.Text == string.Empty ||
                cbSex.Text == string.Empty || tbFechaNacimiento.Text == string.Empty || cbLugarNacimiento.Text == string.Empty || txbIM.Text == string.Empty ||
                txbRF.Text == string.Empty || txCURP.Text == string.Empty || txbCPFiscal.Text == string.Empty || cbDepartamento.Text == string.Empty || cbPuesto.Text == string.Empty ||
                txbCalle.Text == string.Empty || txbColonia.Text == string.Empty || txbPoblacion.Text == string.Empty || cbEntidadFederativa.Text == string.Empty || txbPais.Text == string.Empty ||
                txbCorreo1.Text == string.Empty || txbCP.Text == string.Empty || txbTelefono1.Text == string.Empty || cbNivelEstudios.Text == string.Empty || cbEstadoCivil.Text == string.Empty)
            {
                MessageBox.Show("FAVOR DE LLENAR TODOS LOS CAMPOS OBLIGATORIOS");
                pbCampos.Visible = true; lblCampos.Visible = true; pbEstatus.Visible = true; pbNombre.Visible = true; pbApellidoPaterno.Visible = true; pbApellidoMaterno.Visible = true;
                pbSexo.Visible = true; pbFechaNacimiento.Visible = true; pbLugarNacimiento.Visible = true; pbIMSS.Visible = true; pbRFC.Visible = true; pbCURP.Visible = true; pbCodigoPostalFiscal.Visible = true;
                pbDepartamento.Visible = true; pbPuesto.Visible = true; pbCalle.Visible = true; pbColonia.Visible = true; pbPoblacion.Visible = true; pbEntidadFederativa.Visible = true; pbPais.Visible = true;
                pbCorreoElectronico.Visible = true; pbCodigoPostal.Visible = true; pbTelefono.Visible = true; pbNivelEstudios.Visible = true; pbEstadoCivil.Visible = true;
                return;
            }
            else
            {
                pbCampos.Visible = false; lblCampos.Visible = false; pbEstatus.Visible = false; pbNombre.Visible = false; pbApellidoPaterno.Visible = false; pbApellidoMaterno.Visible = false;
                pbSexo.Visible = false; pbFechaNacimiento.Visible = false; pbLugarNacimiento.Visible = false; pbIMSS.Visible = false; pbRFC.Visible = false; pbCURP.Visible = false; pbCodigoPostalFiscal.Visible = false;
                pbDepartamento.Visible = false; pbPuesto.Visible = false; pbCalle.Visible = false; pbColonia.Visible = false; pbPoblacion.Visible = false; pbEntidadFederativa.Visible = false; pbPais.Visible = false;
                pbCorreoElectronico.Visible = false; pbCodigoPostal.Visible = false; pbTelefono.Visible = false; pbNivelEstudios.Visible = false; pbEstadoCivil.Visible = false;
            }
            ActualizarDatos();
            NuevoNoTrabajador();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            opc = 1;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.png;*.jpg;*.jpeg;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaImagen = openFileDialog.FileName;

                try
                {
                    pbFoto.Image = Image.FromFile(rutaImagen);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                }
            }
        }

        private void cbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txbNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnEnviarSolicitud_Click(object sender, EventArgs e)
        {
            pnlTabla.Visible = false;
        }
    }
}
