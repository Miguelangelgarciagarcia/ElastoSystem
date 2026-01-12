using Isopoh.Cryptography.Argon2;
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
using System.Security.Cryptography;
using Isopoh.Cryptography.Argon2;
using System.Xml.Linq;

namespace ElastoSystem
{
    public partial class SistemasPermisos : Form
    {
        public SistemasPermisos()
        {
            InitializeComponent();
        }


        private void MandarALlamarUsuarios()
        {
            cbUsuarios.Items.Clear();
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Usuario FROM elastosystem_login";
            try
            {
                HashSet<string> unicos = new HashSet<string>();
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbUsuarios.Items.Add(reader["Usuario"].ToString());
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

        private void MandarALlamarNo()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            mySqlConnection.Open();
            String no = cbUsuarios.Text;
            MySqlDataReader reader = null;
            string sql = "SELECT ID FROM elastosystem_login WHERE Usuario ='" + no + "' ";
            try
            {
                HashSet<string> unicos = new HashSet<string>();
                MySqlCommand comando = new MySqlCommand(sql, mySqlConnection);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lblNumeroTemp.Text = reader.GetInt32(0).ToString();

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

        private void MandarALlamarPermisos()
        {
            string id = lblNumeroTemp.Text;
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            try
            {
                string query = @"SELECT 
                                Almacen, 
                                    Nuevo_Producto, Editar_Producto, Registrar_Existencias, Control_Almacen, Consulta_Salidas, Admin_Inventario, Inventario_Almacen, Almacen_Fabricacion, Admin_SolicitudFabr, 
                                Compras, 
                                    ComprasReq, Indicador_Compras, ComprasAdmiReq, ComprasAdmiPro, ComprasReqEnviadas, Consumibles_Almacen, Consumibles_Almacen, Compras_ConsultarOCs, 
                                Recursos_Humanos, 
                                    Registro_Trabajador, Generar_Credencial, 
                                Sistemas, 
                                    Requisicion, Permisos, Pendientes_Sistemas, 
                                Ventas, 
                                    BuscarCotizacion, Clientes, CatalogoProductos, NuevaCotizacion, 
                                Produccion, 
                                    Reporte, Administrar_Procesos, Orden_Produccion,
                                Maquinado, 
                                    Solicitud_Maquinado, Pendientes_Maquinado, Historial_Maquinado, 
                                Mantenimiento, 
                                    SolicitudMtto, PendientesMtto, HistoricoMtto, InventarioMaquinas, Mtto_Preventivo, IndicadorMtto 
                                FROM elastosystem_permisos_menu WHERE ID = @id";

                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string almacenValue = reader["Almacen"].ToString();
                    if (almacenValue == "True")
                    {
                        chbAlmacen.Checked = true;
                        string nuevoproductoValue = reader["Nuevo_Producto"].ToString();
                        if (nuevoproductoValue == "True")
                        {
                            chbNuevoProducto.Checked = true;
                        }

                        string editarproductoValue = reader["Editar_Producto"].ToString();
                        if (editarproductoValue == "True")
                        {
                            chbEditarProducto.Checked = true;
                        }

                        string registrarexistenciasValue = reader["Registrar_Existencias"].ToString();
                        if (registrarexistenciasValue == "True")
                        {
                            chbRegistrarExistencias.Checked = true;
                        }

                        string controlalmacenValue = reader["Control_Almacen"].ToString();
                        if (controlalmacenValue == "True")
                        {
                            chbControlAlmacen.Checked = true;
                        }

                        string consultasalidasValue = reader["Consulta_Salidas"].ToString();
                        if (consultasalidasValue == "True")
                        {
                            chbConsultaSalidas.Checked = true;
                        }

                        string admininventarioptValue = reader["Admin_Inventario"].ToString();
                        if (admininventarioptValue == "True")
                        {
                            chbAdminInventarioPT.Checked = true;
                        }

                        string inventarioalmacenptValue = reader["Inventario_Almacen"].ToString();
                        if (inventarioalmacenptValue == "True")
                        {
                            chbInventarioAlmacenPT.Checked = true;
                        }

                        string solicitudFabricacionValue = reader["Almacen_Fabricacion"].ToString();
                        if (solicitudFabricacionValue == "True")
                        {
                            chbSolicitudFabricacion.Checked = true;
                        }

                        string adminSolicitudFabrValue = reader["Admin_SolicitudFabr"].ToString();
                        if (adminSolicitudFabrValue == "True")
                        {
                            chbAdminSolFab.Checked = true;
                        }
                    }

                    string comprasValue = reader["Compras"].ToString();
                    if (comprasValue == "True")
                    {
                        chbCompras.Checked = true;
                        string comprasreqValue = reader["ComprasReq"].ToString();
                        if (comprasreqValue == "True")
                        {
                            chbReqCompra.Checked = true;
                        }

                        string indicadorcomprasValue = reader["Indicador_Compras"].ToString();
                        if (indicadorcomprasValue == "True")
                        {
                            chbIndicadorCompras.Checked = true;
                        }

                        string comprasadmireqValue = reader["ComprasAdmiReq"].ToString();
                        if (comprasadmireqValue == "True")
                        {
                            chbAdmiReq.Checked = true;
                        }

                        string comprasadmiproValue = reader["ComprasAdmiPro"].ToString();
                        if (comprasadmiproValue == "True")
                        {
                            chbAdmiProvee.Checked = true;
                        }

                        string comprasreqenviadasValue = reader["ComprasReqEnviadas"].ToString();
                        if (comprasreqenviadasValue == "True")
                        {
                            chbReqEnviadas.Checked = true;
                        }

                        string consumiblesalmacenValue = reader["Consumibles_Almacen"].ToString();
                        if (consumiblesalmacenValue == "True")
                        {
                            chbConsumiblesAlmacen.Checked = true;
                        }

                        string consultarocsValue = reader["Compras_ConsultarOCs"].ToString();
                        if (consultarocsValue == "True")
                        {
                            chbConsultarOCs.Checked = true;
                        }

                    }

                    string recursoshumanosValue = reader["Recursos_Humanos"].ToString();
                    if (recursoshumanosValue == "True")
                    {
                        chbRecursosHumanos.Checked = true;
                        string registrotrabajadorValue = reader["Registro_Trabajador"].ToString();
                        if (registrotrabajadorValue == "True")
                        {
                            chbRegistroTrabajador.Checked = true;
                        }

                        string generarcredencialValue = reader["Generar_Credencial"].ToString();
                        if (generarcredencialValue == "True")
                        {
                            chbGenerarCredencial.Checked = true;
                        }

                    }

                    string sistemasValue = reader["Sistemas"].ToString();
                    if (sistemasValue == "True")
                    {
                        chbSistemas.Checked = true;
                        string requisicionValue = reader["Requisicion"].ToString();
                        if (requisicionValue == "True")
                        {
                            chbRequisicion.Checked = true;
                        }

                        string permisosValue = reader["Permisos"].ToString();
                        if (permisosValue == "True")
                        {
                            chbPermisos.Checked = true;
                        }
                        string pendientesSistemasValue = reader["Pendientes_Sistemas"].ToString();
                        if (pendientesSistemasValue == "True")
                        {
                            chbPendientesSistemas.Checked = true;
                        }

                    }

                    string ventasValue = reader["Ventas"].ToString();
                    if (ventasValue == "True")
                    {
                        chbVentas.Checked = true;
                        string buscarcotizacionValue = reader["BuscarCotizacion"].ToString();
                        if (buscarcotizacionValue == "True")
                        {
                            chbBuscarCotizacion.Checked = true;
                        }

                        string clientesValue = reader["Clientes"].ToString();
                        if (clientesValue == "True")
                        {
                            chbClientes.Checked = true;
                        }

                        string catalogoproductosValue = reader["CatalogoProductos"].ToString();
                        if (catalogoproductosValue == "True")
                        {
                            chbCatalogoProductos.Checked = true;
                        }

                        string nuevacotizacionValue = reader["NuevaCotizacion"].ToString();
                        if (nuevacotizacionValue == "True")
                        {
                            chbNuevaCotizacion.Checked = true;
                        }

                    }

                    string produccionValue = reader["Produccion"].ToString();
                    if (produccionValue == "True")
                    {
                        chbProduccion.Checked = true;
                        string reporteValue = reader["Reporte"].ToString();
                        if (reporteValue == "True")
                        {
                            chbReporteProduccion.Checked = true;
                        }
                        string administrarprocesosValue = reader["Administrar_Procesos"].ToString();
                        if (administrarprocesosValue == "True")
                        {
                            chbAdministrarProcesos.Checked = true;
                        }
                        string ordenproduccionValue = reader["Orden_Produccion"].ToString();
                        if (ordenproduccionValue == "True")
                        {
                            chbOrdenProduccion.Checked = true;
                        }

                    }

                    string maquinadoValue = reader["Maquinado"].ToString();
                    if (maquinadoValue == "True")
                    {
                        chbMaquinado.Checked = true;
                        string solicitud_maquinadoValue = reader["Solicitud_Maquinado"].ToString();
                        if (solicitud_maquinadoValue == "True")
                        {
                            chbSolicitudMaquinado.Checked = true;
                        }

                        string pendientes_maquinadoValue = reader["Pendientes_Maquinado"].ToString();
                        if (pendientes_maquinadoValue == "True")
                        {
                            chbPendientesMaquinado.Checked = true;
                        }

                        string historial_maquinadoValue = reader["Historial_Maquinado"].ToString();
                        if (historial_maquinadoValue == "True")
                        {
                            chbHistorialMaquinado.Checked = true;
                        }

                    }

                    string mantenimientoValue = reader["Mantenimiento"].ToString();
                    if (mantenimientoValue == "True")
                    {
                        chbMantenimiento.Checked = true;

                        string solicitudmttoValue = reader["SolicitudMtto"].ToString();
                        if (solicitudmttoValue == "True")
                        {
                            chbSolicitudMtto.Checked = true;
                        }

                        string pendientesmttoValue = reader["PendientesMtto"].ToString();
                        if (pendientesmttoValue == "True")
                        {
                            chbPendientesMtto.Checked = true;
                        }

                        string historicomttoValue = reader["HistoricoMtto"].ToString();
                        if (historicomttoValue == "True")
                        {
                            chbHistorialMtto.Checked = true;
                        }

                        string inventariomaquinasValue = reader["InventarioMaquinas"].ToString();
                        if (inventariomaquinasValue == "True")
                        {
                            chbInventarioMaquinas.Checked = true;
                        }

                        string mttopreventicoValue = reader["Mtto_Preventivo"].ToString();
                        if (mttopreventicoValue == "True")
                        {
                            chbMttoPreventivo.Checked = true;
                        }

                        string indicadormttoValue = reader["IndicadorMtto"].ToString();
                        if (indicadormttoValue == "True")
                        {
                            chbIndicadorMtto.Checked = true;
                        }
                    }

                }
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

        private void LimpiarCheckBox()
        {
            chbAlmacen.Checked = false;
            chbNuevoProducto.Checked = false;
            chbEditarProducto.Checked = false;
            chbRegistrarExistencias.Checked = false;
            chbControlAlmacen.Checked = false;
            chbConsultaSalidas.Checked = false;
            chbAdminInventarioPT.Checked = false;
            chbInventarioAlmacenPT.Checked = false;
            chbSolicitudFabricacion.Checked = false;
            chbAdminSolFab.Checked = false;

            chbCompras.Checked = false;
            chbConsumiblesAlmacen.Checked = false;
            chbReqCompra.Checked = false;
            chbAdmiReq.Checked = false;
            chbAdmiProvee.Checked = false;
            chbReqEnviadas.Checked = false;
            chbIndicadorCompras.Checked = false;
            chbConsumiblesAlmacen.Checked = false;
            chbConsultarOCs.Checked = false;

            chbRecursosHumanos.Checked = false;
            chbRegistroTrabajador.Checked = false;
            chbGenerarCredencial.Checked = false;

            chbSistemas.Checked = false;
            chbRequisicion.Checked = false;
            chbPermisos.Checked = false;
            chbPendientesSistemas.Checked = false;

            
            chbBuscarCotizacion.Checked = false;
            chbClientes.Checked = false;
            chbCatalogoProductos.Checked = false;
            chbNuevaCotizacion.Checked = false;
            chbVentas.Checked = false;

            chbProduccion.Checked = false;
            chbReporteProduccion.Checked = false;
            chbAdministrarProcesos.Checked = false;
            chbOrdenProduccion.Checked = false;

            chbMaquinado.Checked = false;
            chbSolicitudMaquinado.Checked = false;
            chbPendientesMaquinado.Checked = false;
            chbHistorialMaquinado.Checked = false;

            chbMantenimiento.Checked = false;
            chbSolicitudMtto.Checked = false;
            chbPendientesMtto.Checked = false;
            chbHistorialMtto.Checked = false;
            chbInventarioMaquinas.Checked = false;
            chbMttoPreventivo.Checked = false;
            chbIndicadorMtto.Checked = false;
        }

        private void ActualizarPermisos()
        {
            bool boolAlmacen = chbAlmacen.Checked;
            bool boolNuevoProducto = chbNuevoProducto.Checked;
            bool boolEditarProducto = chbEditarProducto.Checked;
            bool boolRegistrarExistencias = chbRegistrarExistencias.Checked;
            bool boolControlAlmacen = chbControlAlmacen.Checked;
            bool boolConsultaSalidas = chbConsultaSalidas.Checked;
            bool boolAdminInventarioPT = chbAdminInventarioPT.Checked;
            bool boolInventarioAlmacenPT = chbInventarioAlmacenPT.Checked;
            bool boolSolicitudFabricacion = chbSolicitudFabricacion.Checked;
            bool boolAdminSolFab = chbAdminSolFab.Checked;

            bool boolCompras = chbCompras.Checked;
            bool boolConsumiblesAlmacen = chbConsumiblesAlmacen.Checked;
            bool boolRequerimientosCompras = chbReqCompra.Checked;
            bool boolAdministrarReq = chbAdmiReq.Checked;
            bool boolAdmiProvee = chbAdmiProvee.Checked;
            bool boolReqEnviadas = chbReqEnviadas.Checked;
            bool boolIndicadorCompras = chbIndicadorCompras.Checked;
            bool boolConsultarOCs = chbConsultarOCs.Checked;

            bool boolRecursosHumanos = chbRecursosHumanos.Checked;
            bool boolRegistroTrabajador = chbRegistroTrabajador.Checked;
            bool boolGenerarCredencial = chbGenerarCredencial.Checked;

            bool boolSistemas = chbSistemas.Checked;
            bool boolRequisicion = chbRequisicion.Checked;
            bool boolPermisos = chbPermisos.Checked;
            bool boolPendientesSistemas = chbPendientesSistemas.Checked;

            bool boolVentas = chbVentas.Checked;
            bool boolBuscarCotizacion = chbBuscarCotizacion.Checked;
            bool boolClientes = chbClientes.Checked;
            bool boolCatalogoProductos = chbCatalogoProductos.Checked;
            bool boolNuevaCotizacion = chbNuevaCotizacion.Checked;

            bool boolProduccion = chbProduccion.Checked;
            bool boolReporte = chbReporteProduccion.Checked;
            bool boolAdministrarProcesos = chbAdministrarProcesos.Checked;
            bool boolOrdenProduccion = chbOrdenProduccion.Checked;

            bool boolMaquinado = chbMaquinado.Checked;
            bool boolSolicitud_Maquinado = chbSolicitudMaquinado.Checked;
            bool boolPendientes_Maquinado = chbPendientesMaquinado.Checked;
            bool boolHistorial_Maquinado = chbHistorialMaquinado.Checked;

            bool boolMantenimiento = chbMantenimiento.Checked;
            bool boolSolicitudMtto = chbSolicitudMtto.Checked;
            bool boolPendientesMtto = chbPendientesMtto.Checked;
            bool boolHistorialMtto = chbHistorialMtto.Checked;
            bool boolInventarioMaquinas = chbInventarioMaquinas.Checked;
            bool boolMttoPreventivo = chbMttoPreventivo.Checked;
            bool boolIndicadorMtto = chbIndicadorMtto.Checked;

            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE elastosystem_permisos_menu SET Almacen = " + boolAlmacen + ", Nuevo_Producto = " + boolNuevoProducto + ", Editar_Producto = " + boolEditarProducto + ", Registrar_Existencias = " + boolRegistrarExistencias + ", Control_Almacen = " + boolControlAlmacen + ", Consulta_Salidas = " + boolConsultaSalidas + ", Admin_Inventario = " + boolAdminInventarioPT + ", Inventario_Almacen = " + boolInventarioAlmacenPT + ", Almacen_Fabricacion = " + boolSolicitudFabricacion + ", Admin_SolicitudFabr = " + boolAdminSolFab + ", Compras = " + boolCompras + ", ComprasReq = " + boolRequerimientosCompras + ", Indicador_Compras = " + boolIndicadorCompras + ", ComprasAdmiReq = " + boolAdministrarReq + ", ComprasAdmiPro = " + boolAdmiProvee + ", ComprasReqEnviadas = " + boolReqEnviadas + ", Consumibles_Almacen = " + boolConsumiblesAlmacen + ", Compras_ConsultarOCs = " + boolConsultarOCs + ", Recursos_Humanos = " + boolRecursosHumanos + ", Registro_Trabajador = " + boolRegistroTrabajador + ", Generar_Credencial = " + boolGenerarCredencial + ", Sistemas = " + boolSistemas + ", Requisicion = " + boolRequisicion + ", Pendientes_Sistemas = " + boolPendientesSistemas + " , Permisos = " + boolPermisos + ", Ventas = " + boolVentas + ", BuscarCotizacion = " + boolBuscarCotizacion + ", Clientes = " + boolClientes + ", CatalogoProductos = " + boolCatalogoProductos + ", NuevaCotizacion = " + boolNuevaCotizacion + ", Produccion = " + boolProduccion + ", Reporte = " + boolReporte + ", Administrar_Procesos = " + boolAdministrarProcesos + ", Orden_Produccion = " + boolOrdenProduccion + ", Maquinado = " + boolMaquinado + ", Solicitud_Maquinado = " + boolSolicitud_Maquinado + ", Pendientes_Maquinado = " + boolPendientes_Maquinado + ", Historial_Maquinado = " + boolHistorial_Maquinado + ", Mantenimiento = " + boolMantenimiento + ", SolicitudMtto = " + boolSolicitudMtto + ", PendientesMtto = " + boolPendientesMtto + ", HistoricoMtto = " + boolHistorialMtto + ", InventarioMaquinas = " + boolInventarioMaquinas + ", Mtto_Preventivo = " + boolMttoPreventivo + ", IndicadorMtto = " + boolIndicadorMtto + "  WHERE ID = '" + lblNumeroTemp.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("DATOS ACTUALIZADOS CON EXITO");
                LimpiarCheckBox();
                cbUsuarios.Text = String.Empty;
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

        private void MandarALlamarInfoUsuarios()
        {
            try
            {
                string userQuery = "SELECT ID, Usuario, Paswd, Correo,  No_Trabajador, Estatus FROM elastosystem_login";
                MySqlDataAdapter userinfoAdapter = new MySqlDataAdapter(userQuery, VariablesGlobales.ConexionBDElastotecnica);
                DataTable dt = new DataTable();
                userinfoAdapter.Fill(dt);
                dgvUsuarioyPassword.DataSource = dt;

                dgvUsuarioyPassword.Columns["ID"].Visible = false;
                dgvUsuarioyPassword.Columns["Paswd"].Visible = false;
                dgvUsuarioyPassword.Columns["Usuario"].HeaderText = "USUARIO";
                dgvUsuarioyPassword.Columns["No_Trabajador"].HeaderText = "No. TRABAJADOR";
                dgvUsuarioyPassword.Columns["Estatus"].HeaderText = "ESTATUS";
                dt.DefaultView.Sort = "Usuario ASC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mandar a llamar a los usuarios y contraseñas del campo Gestion de Usuarios: " + ex.Message);
            }
        }

        private void Buscador()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);

            try
            {
                conn.Open();

                string valorBusqueda = txbBuscador.Text;
                string searchQuery = "SELECT ID, Paswd, Usuario, No_Trabajador, Estatus FROM elastosystem_login WHERE Usuario LIKE @ValorBusqueda OR No_Trabajador LIKE @ValorBusqueda";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(searchQuery, VariablesGlobales.ConexionBDElastotecnica);
                adaptador.SelectCommand.Parameters.AddWithValue("@ValorBusqueda", "%" + valorBusqueda + "%");

                DataTable tableResultados = new DataTable();
                adaptador.Fill(tableResultados);

                dgvUsuarioyPassword.DataSource = tableResultados;

                dgvUsuarioyPassword.Columns["ID"].Visible = false;
                dgvUsuarioyPassword.Columns["Paswd"].Visible = false;
                tableResultados.DefaultView.Sort = "Usuario ASC";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscador datos: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void SistemasPermisos_Load(object sender, EventArgs e)
        {
            MandarALlamarUsuarios();
            MandarALlamarUsuariosEspeciales();
            MandarALlamarInfoUsuarios();
        }

        private void MandarALlamarUsuariosEspeciales()
        {
            cbUsuariosEspeciales.Items.Clear();
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlDataReader reader = null;
            string sql = "SELECT Usuario FROM elastosystem_login";
            try
            {
                HashSet<string> list = new HashSet<string>();
                MySqlCommand comando = new MySqlCommand(sql, conn);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cbUsuariosEspeciales.Items.Add(reader["Usuario"].ToString());
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL MANDAR A LLAMAR USUARIOS AL COMBOBOX DE PERMISOS ESPECIALES" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void cbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarCheckBox();
            MandarALlamarNo();
            MandarALlamarPermisos();
        }

        private void chbAlmacen_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAlmacen.Checked == false)
            {
                chbNuevoProducto.Checked = false;
                chbEditarProducto.Checked = false;
                chbRegistrarExistencias.Checked = false;
                chbControlAlmacen.Checked = false;
                chbConsultaSalidas.Checked = false;
                chbAdminInventarioPT.Checked = false;
                chbInventarioAlmacenPT.Checked = false;
                chbSolicitudFabricacion.Checked = false;
                chbAdminSolFab.Checked = false;
            }
        }

        private void chbCompras_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCompras.Checked == false)
            {
                chbIndicadorCompras.Checked = false;
                chbReqCompra.Checked = false;
                chbAdmiReq.Checked = false;
                chbAdmiProvee.Checked = false;
                chbReqEnviadas.Checked = false;
                chbConsumiblesAlmacen.Checked = false;
                chbConsultarOCs.Checked = false;
            }
        }

        private void chbRecursosHumanos_CheckedChanged(object sender, EventArgs e)
        {
            if (chbRecursosHumanos.Checked == false)
            {
                chbRegistroTrabajador.Checked = false;
                chbGenerarCredencial.Checked = false;
            }
        }

        private void chbSistemas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSistemas.Checked == false)
            {
                chbRequisicion.Checked = false;
                chbPermisos.Checked = false;
                chbPendientesSistemas.Checked = false;
            }
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            ActualizarPermisos();
            cbUsuarios.SelectedIndex = -1;
            LimpiarCheckBox();
        }

        private void chbNuevoProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNuevoProducto.Checked == true)
            {
                chbAlmacen.Checked = true;
            }
        }

        private void chbEditarProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEditarProducto.Checked == true)
            {
                chbAlmacen.Checked = true;
            }
        }

        private void chbRegistrarExistencias_CheckedChanged(object sender, EventArgs e)
        {
            if (chbRegistrarExistencias.Checked == true)
            {
                chbAlmacen.Checked = true;
            }
        }

        private void chbControlAlmacen_CheckedChanged(object sender, EventArgs e)
        {
            if (chbControlAlmacen.Checked == true)
            {
                chbAlmacen.Checked = true;
            }
        }

        private void chbConsultaSalidas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbConsultaSalidas.Checked == true)
            {
                chbAlmacen.Checked = true;
            }
        }

        private void chbIndicadorCompras_CheckedChanged(object sender, EventArgs e)
        {
            if (chbIndicadorCompras.Checked == true)
            {
                chbCompras.Checked = true;
            }
        }

        private void chbConsumiblesAlmacen_CheckedChanged(object sender, EventArgs e)
        {
            if (chbConsumiblesAlmacen.Checked == true)
            {
                chbCompras.Checked = true;
            }
        }

        private void chbRegistroTrabajador_CheckedChanged(object sender, EventArgs e)
        {
            if (chbRegistroTrabajador.Checked == true)
            {
                chbRecursosHumanos.Checked = true;
            }
        }

        private void chbGenerarCredencial_CheckedChanged(object sender, EventArgs e)
        {
            if (chbGenerarCredencial.Checked == true)
            {
                chbRecursosHumanos.Checked = true;
            }
        }

        private void chbRequisicion_CheckedChanged(object sender, EventArgs e)
        {
            if (chbRequisicion.Checked == true)
            {
                chbSistemas.Checked = true;
            }
        }

        private void chbPermisos_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPermisos.Checked == true)
            {
                chbSistemas.Checked = true;
            }
        }

        private void chbVentas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbVentas.Checked == false)
            {
                chbBuscarCotizacion.Checked = false;
                chbClientes.Checked = false;
                chbCatalogoProductos.Checked = false;
                chbNuevaCotizacion.Checked = false;
            }
        }

        private void chbClientes_CheckedChanged(object sender, EventArgs e)
        {
            if (chbClientes.Checked == true)
            {
                chbVentas.Checked = true;
            }
        }

        private void chbProduccion_CheckedChanged(object sender, EventArgs e)
        {
            if (chbProduccion.Checked == false)
            {
                chbReporteProduccion.Checked = false;
                chbAdministrarProcesos.Checked = false;
                chbOrdenProduccion.Checked = false;
            }
        }

        private void chbReporteProduccion_CheckedChanged(object sender, EventArgs e)
        {
            if (chbReporteProduccion.Checked == true)
            {
                chbProduccion.Checked = true;
            }
        }

        private void chbReqCompra_CheckedChanged(object sender, EventArgs e)
        {
            if (chbReqCompra.Checked == true)
            {
                chbCompras.Checked = true;
            }
        }

        private void chbAdmiReq_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAdmiReq.Checked == true)
            {
                chbCompras.Checked = true;
            }
        }

        private void chbAdmiProvee_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAdmiProvee.Checked == true)
            {
                chbCompras.Checked = true;
            }
        }

        private void chbReqEnviadas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbReqEnviadas.Checked == true)
            {
                chbCompras.Checked = true;
            }
        }

        private void chbBuscarCotizacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chbClientes.Checked == true)
            {
                chbVentas.Checked = true;
            }
        }

        private void chbCatalogoProductos_CheckedChanged(object sender, EventArgs e)
        {
            if (chbClientes.Checked == true)
            {
                chbVentas.Checked = true;
            }
        }

        private void chbNuevaCotizacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chbClientes.Checked == true)
            {
                chbVentas.Checked = true;
            }
        }

        private void chbMaquinado_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMaquinado.Checked == false)
            {
                chbSolicitudMaquinado.Checked = false;
                chbPendientesMaquinado.Checked = false;
                chbHistorialMaquinado.Checked = false;
            }
        }

        private void chbSolicitudMaquinado_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSolicitudMaquinado.Checked == true)
            {
                chbMaquinado.Checked = true;
            }
        }

        private void chbPendientesMaquinado_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPendientesMaquinado.Checked == true)
            {
                chbMaquinado.Checked = true;
            }
        }

        private void txbBuscador_TextChanged(object sender, EventArgs e)
        {
            Buscador();
        }

        private void LimpiarCampos()
        {
            txbID.Clear();
            txbUsuario.Clear();
            txbPassword.Clear();
            txbNoTrabajador.Clear();
            cbEstatus.SelectedIndex = -1;
            txbCorreo.Clear();
            lblCampos.Visible = false;
            pbCampos.Visible = false;
            pbUsuario.Visible = false;
            pbPassword.Visible = false;
            pbEstatus.Visible = false;
            pbCorreo.Visible = false;
        }

        private void dgvUsuarioyPassword_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnActualizarUsuario.Visible = true;
            btnEliminar.Visible = true;
            btnNuevo.Visible = true;
            btnAgregar.Visible = false;

            LimpiarCampos();

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuarioyPassword.Rows[e.RowIndex];

                txbID.Text = row.Cells["ID"].Value.ToString();
                txbUsuario.Text = row.Cells["Usuario"].Value.ToString();
                txbNoTrabajador.Text = row.Cells["No_Trabajador"].Value.ToString();
                cbEstatus.Text = row.Cells["Estatus"].Value.ToString();
                txbCorreo.Text = row.Cells["Correo"].Value.ToString();
            }

        }

        private bool VerificarCamposVacios()
        {
            if (string.IsNullOrEmpty(txbUsuario.Text) ||
                string.IsNullOrEmpty(txbPassword.Text) ||
                string.IsNullOrEmpty(cbEstatus.Text) ||
                string.IsNullOrEmpty(txbCorreo.Text))
            {
                MessageBox.Show("Ingresa los datos obligatorios");
                pbCampos.Visible = true;
                lblCampos.Visible = true;
                pbUsuario.Visible = true;
                pbPassword.Visible = true;
                pbEstatus.Visible = true;
                pbCorreo.Visible = true;
                return true;
            }
            else
            {
                pbCampos.Visible = false;
                lblCampos.Visible = false;
                pbUsuario.Visible = false;
                pbPassword.Visible = false;
                pbEstatus.Visible = false;
                pbCorreo.Visible = false;
            }

            return false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            btnNuevo.Visible = false;
            btnActualizarUsuario.Visible = false;
            btnEliminar.Visible = false;
            btnAgregar.Visible = true;
        }

        private void btnActualizarUsuario_Click_1(object sender, EventArgs e)
        {
            if (VerificarCamposVacios())
            {
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string hashedPassword = Argon2.Hash(txbPassword.Text);

                    string updateQuery = "UPDATE elastosystem_login SET Usuario = @Usuario, Paswd = @Password, Correo = @Correo, No_Trabajador = @NoTrabajador, Estatus = @Estatus WHERE ID = @ID";
                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, conn);

                    updateCommand.Parameters.AddWithValue("@ID", txbID.Text);
                    updateCommand.Parameters.AddWithValue("@Usuario", txbUsuario.Text);
                    updateCommand.Parameters.AddWithValue("@Password", hashedPassword);
                    updateCommand.Parameters.AddWithValue("@Correo", txbCorreo.Text);
                    updateCommand.Parameters.AddWithValue("@NoTrabajador", txbNoTrabajador.Text);
                    updateCommand.Parameters.AddWithValue("@Estatus", cbEstatus.Text);

                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Usuario actualizado correctamente");
                        LimpiarCampos();
                        MandarALlamarInfoUsuarios();
                        txbBuscador.Clear();
                        btnNuevo.PerformClick();
                        MandarALlamarUsuarios();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el usuario: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        private void tabGestionUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void ValidarNumero(KeyPressEventArgs e, TextBox textBox)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (VerificarCamposVacios())
            {
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string checkUsuario = "SELECT COUNT(*) FROM elastosystem_login WHERE Usuario = @Usuario";
                    MySqlCommand checkUsuaioCommand = new MySqlCommand(checkUsuario, conn);
                    checkUsuaioCommand.Parameters.AddWithValue("@Usuario", txbUsuario.Text);

                    int UsuarioCount = Convert.ToInt32(checkUsuaioCommand.ExecuteScalar());

                    if (UsuarioCount > 0)
                    {
                        MessageBox.Show("El Usuario ya existe");
                        return;
                    }

                    string hashedPassword = Argon2.Hash(txbPassword.Text);

                    string insertQuery = "INSERT INTO elastosystem_login(Usuario, Paswd, Correo, No_Trabajador, Estatus) VALUES(@Usuario, @Password, @Correo, @NoTrabajador, @Estatus)";
                    MySqlCommand insertCommand = new MySqlCommand(insertQuery, conn);

                    insertCommand.Parameters.AddWithValue("@Usuario", txbUsuario.Text);
                    insertCommand.Parameters.AddWithValue("@Password", hashedPassword);
                    insertCommand.Parameters.AddWithValue("@Correo", txbCorreo.Text);
                    insertCommand.Parameters.AddWithValue("@NoTrabajador", txbNoTrabajador.Text);
                    insertCommand.Parameters.AddWithValue("@Estatus", cbEstatus.Text);

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        AgregarRegistro(conn);
                        MessageBox.Show("Usuario agregado correctamente");
                        LimpiarCampos();
                        txbBuscador.Clear();
                        MandarALlamarInfoUsuarios();
                        btnNuevo.PerformClick();
                        MandarALlamarUsuarios();

                    }
                    else
                    {
                        MessageBox.Show("Error al agregar al usuario");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar al usuario: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void AgregarRegistro(MySqlConnection conn)
        {
            try
            {
                string query = "SELECT LAST_INSERT_ID()";
                MySqlCommand command = new MySqlCommand(query, conn);

                int lastInsertId = Convert.ToInt32(command.ExecuteScalar());

                string insertPermisoQuery = "INSERT INTO elastosystem_permisos_menu(ID) VALUES(@ID)";
                MySqlCommand insertPermisoCommand = new MySqlCommand(insertPermisoQuery, conn);
                insertPermisoCommand.Parameters.AddWithValue("@ID", lastInsertId);

                int rowsAffected = insertPermisoCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {

                }
                else
                {
                    MessageBox.Show("Error al asignar los permisos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingrear el ID a los permisos: " + ex.Message);
            }
        }

        private void txbNoTrabajador_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(e, txbNoTrabajador);
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica))
            {
                try
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM elastosystem_login WHERE ID = @ID";
                    MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, conn);

                    deleteCommand.Parameters.AddWithValue("@ID", txbID.Text);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Usuario eliminado correctamente");
                        LimpiarCampos();
                        txbBuscador.Clear();
                        MandarALlamarInfoUsuarios();
                        btnNuevo.PerformClick();
                        MandarALlamarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("No se encontro ningun usuario con ese ID");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error al eliminar al usuario: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void chbHistorialMaquinado_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHistorialMaquinado.Checked == true)
            {
                chbMaquinado.Checked = true;
            }
        }

        private void chbConsultarOCs_CheckedChanged(object sender, EventArgs e)
        {
            if (chbConsultarOCs.Checked == true)
            {
                chbCompras.Checked = true;
            }
        }

        private void chbMantenimiento_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMantenimiento.Checked == false)
            {
                chbSolicitudMtto.Checked = false;
                chbPendientesMtto.Checked = false;
                chbHistorialMtto.Checked = false;
                chbInventarioMaquinas.Checked = false;
                chbMttoPreventivo.Checked = false;
                chbIndicadorMtto.Checked = false;
            }
        }

        private void chbSolicitudMtto_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSolicitudMtto.Checked == true)
            {
                chbMantenimiento.Checked = true;
            }
        }

        private void chbPendientesMtto_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPendientesMtto.Checked == true)
            {
                chbMantenimiento.Checked = true;
            }
        }

        private void chbHistorialMtto_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHistorialMtto.Checked == true)
            {
                chbMantenimiento.Checked = true;
            }
        }

        private void chbInventarioMaquinas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbInventarioMaquinas.Checked == true)
            {
                chbMantenimiento.Checked = true;
            }
        }

        private void cbUsuariosEspeciales_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarCHBEscpeciales();
            MandarALlamarNoEspecial();
        }

        private void LimpiarCHBEscpeciales()
        {
            chbComprasAlmacenar.Checked = false;
            chbComprasVG.Checked = false;

            chbMantenimientoVG.Checked = false;

            chbMaquinadoVG.Checked = false;

            chbAjustes.Checked = false;

            chbActualizarOT.Checked = false;
            chbAdminOP.Checked = false;
            chbEliminarFamilias.Checked = false;
            chbEliminarRegistroProduccion.Checked = false;
        }

        private void MandarALlamarNoEspecial()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            string usuario = cbUsuariosEspeciales.Text;
            MySqlDataReader reader = null;
            string sql = "SELECT ID FROM elastosystem_login WHERE Usuario = '" + usuario + "'";
            try
            {
                HashSet<string> unicos = new HashSet<string>();
                MySqlCommand comando = new MySqlCommand(sql, conn);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lblNumeroEspecial.Text = reader.GetInt32(0).ToString();
                    }

                    MandarALlamarPermisosEspeciales();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL OBTENER EL NUMERO DE USUARIO" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void MandarALlamarPermisosEspeciales()
        {
            string id = lblNumeroEspecial.Text;
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            try
            {
                string query = "SELECT Compras_AlmacenarREQ, Compras_VG, Mantenimiento_VG, Maquinado_VG, Ajustes, AdminOP, EliminarFamilias, ActualizarOT, EliminarRegistroProd FROM elastosystem_permisos_menu WHERE ID = @ID";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@ID", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string almacenarREQValue = reader["Compras_AlmacenarREQ"].ToString();
                    if (almacenarREQValue == "True")
                    {
                        chbComprasAlmacenar.Checked = true;
                    }

                    string comprasVGValue = reader["Compras_VG"].ToString();
                    if (comprasVGValue == "True")
                    {
                        chbComprasVG.Checked = true;
                    }

                    string mantenimientoVGValue = reader["Mantenimiento_VG"].ToString();
                    if (mantenimientoVGValue == "True")
                    {
                        chbMantenimientoVG.Checked = true;
                    }

                    string maquinadoVGValue = reader["Maquinado_VG"].ToString();
                    if (maquinadoVGValue == "True")
                    {
                        chbMaquinadoVG.Checked = true;
                    }

                    string ajustesValue = reader["Ajustes"].ToString();
                    if (ajustesValue == "True")
                    {
                        chbAjustes.Checked = true;
                    }

                    string adminopValue = reader["AdminOP"].ToString();
                    if (adminopValue == "True")
                    {
                        chbAdminOP.Checked = true;
                    }

                    string eliminarFamiliasValue = reader["EliminarFamilias"].ToString();
                    if (eliminarFamiliasValue == "True")
                    {
                        chbEliminarFamilias.Checked = true;
                    }

                    string actualizarOTValue = reader["ActualizarOT"].ToString();
                    if (actualizarOTValue == "True")
                    {
                        chbActualizarOT.Checked = true;
                    }

                    string eliminarRegistroProdValue = reader["EliminarRegistroProd"].ToString();
                    if (eliminarRegistroProdValue == "True")
                    {
                        chbEliminarRegistroProduccion.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL LLAMAR PERMISOS " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnActualizarPermisosEspeciales_Click(object sender, EventArgs e)
        {
            ActualizarPermisosEspeciales();
        }

        private void ActualizarPermisosEspeciales()
        {
            bool boolAlmacenarReq = chbComprasAlmacenar.Checked;
            bool boolComprasVG = chbComprasVG.Checked;

            bool boolMantenimientoVG = chbMantenimientoVG.Checked;

            bool boolMaquinadoVG = chbMaquinadoVG.Checked;

            bool boolAjustes = chbAjustes.Checked;

            bool boolActualizarOT = chbActualizarOT.Checked;
            bool boolAdminOP = chbAdminOP.Checked;
            bool boolEliminarFamilias = chbEliminarFamilias.Checked;
            bool boolEliminarRegistroProd = chbEliminarRegistroProduccion.Checked;

            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE elastosystem_permisos_menu SET Compras_AlmacenarREQ = " + boolAlmacenarReq + ", Compras_VG = " + boolComprasVG + ", Maquinado_VG = " + boolMaquinadoVG + ", Mantenimiento_VG = " + boolMantenimientoVG + ", Ajustes = " + boolAjustes + ", AdminOP = " + boolAdminOP + ", EliminarFamilias = " + boolEliminarFamilias + ", ActualizarOT = " + boolActualizarOT + ", EliminarRegistroProd = " + boolEliminarRegistroProd + " WHERE ID = '" + lblNumeroEspecial.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Permisos Especiales Actualizados");
                LimpiarCHBEscpeciales();
                cbUsuariosEspeciales.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL ACTUALIZAR PERMISOS ESPECIALES " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbUsuarios.SelectedIndex = -1;
            cbUsuariosEspeciales.SelectedIndex = -1;
            LimpiarCheckBox();
            LimpiarCHBEscpeciales();
        }

        private void cbUsuariosEspeciales_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void dgvUsuarioyPassword_Click(object sender, EventArgs e)
        {

        }

        private void chbAdminInventarioPT_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAdminInventarioPT.Checked == true)
            {
                chbAlmacen.Checked = true;
            }
        }

        private void chbInventarioAlmacenPT_CheckedChanged(object sender, EventArgs e)
        {
            if (chbInventarioAlmacenPT.Checked == true)
            {
                chbAlmacen.Checked = true;
            }
        }

        private void pbOjoCerrado_MouseMove(object sender, MouseEventArgs e)
        {
            if (txbPassword.Text != string.Empty)
            {
                pbOjoCerrado.Visible = false;
                pbOjoAbierto.Visible = true;
                txbPassword.UseSystemPasswordChar = false;
            }
        }

        private void pbOjoAbierto_MouseLeave(object sender, EventArgs e)
        {
            pbOjoAbierto.Visible = false;
            pbOjoCerrado.Visible = true;
            txbPassword.UseSystemPasswordChar = true;
        }

        private void chbPendientesSistemas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPendientesSistemas.Checked == true)
            {
                chbSistemas.Checked = true;
            }
        }

        private void chbSolicitudFabricacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSolicitudFabricacion.Checked == true)
            {
                chbAlmacen.Checked = true;
            }
        }

        private void chbAdminSolFab_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAdminSolFab.Checked == true)
            {
                chbAlmacen.Checked = true;
            }
        }

        private void chbAdministrarProcesos_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAdministrarProcesos.Checked == true)
            {
                chbProduccion.Checked = true;
            }
        }

        private void chbOrdenProduccion_CheckedChanged(object sender, EventArgs e)
        {
            if (chbOrdenProduccion.Checked == true)
            {
                chbProduccion.Checked = true;
            }
        }

        private void chbMttoPreventivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMttoPreventivo.Checked == true)
            {
                chbMantenimiento.Checked = true;
            }
        }

        private void chbIndicadorMtto_CheckedChanged(object sender, EventArgs e)
        {
            if(chbIndicadorMtto.Checked == true)
            {
                chbIndicadorMtto.Checked = true;
            }
        }
    }
}
