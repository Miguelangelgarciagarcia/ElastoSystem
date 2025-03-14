using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace ElastoSystem
{
    public partial class MenuPrincipal : Form
    {
        public string TextoLabelID
        {
            set { labelid.Text = value; }

        }
        public MenuPrincipal()
        {
            InitializeComponent();
            customDesign();
            openChildForm(new Novedades());
        }

        private void definirMenus()
        {
            string idmenu = labelid.Text;
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            try
            {
                string query = "SELECT Almacen, Nuevo_Producto, Registrar_Existencias, Control_Almacen, Consulta_Salidas, Admin_Inventario, Inventario_Almacen, Almacen_Fabricacion, Compras, Consumibles_Almacen, ComprasReq, ComprasAdmiReq, ComprasAdmiPro, ComprasReqEnviadas, Indicador_Compras, Compras_ConsultarOCs, Recursos_Humanos, Registro_Trabajador, Generar_Credencial, Sistemas, Requisicion, Permisos, Pendientes_Sistemas, Ventas, BuscarCotizacion, Clientes, CatalogoProductos, NuevaCotizacion, Produccion, Reporte, Maquinado, Solicitud_Maquinado, Pendientes_Maquinado, Historial_Maquinado, Mantenimiento, SolicitudMtto, PendientesMtto, HistoricoMtto, InventarioMaquinas FROM elastosystem_permisos_menu WHERE ID = @idmenu";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@idmenu", idmenu);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string almacenValue = reader["Almacen"].ToString();
                    if (almacenValue == "True")
                    {
                        btnalmacen.Enabled = true;
                        btnalmacen.Visible = true;
                        string nuevoproductoValue = reader["Nuevo_Producto"].ToString();
                        if (nuevoproductoValue == "True")
                        {
                            btnNuevoProducto.Enabled = true;
                            btnNuevoProducto.Visible = true;
                        }

                        string registrarexistenciasValue = reader["Registrar_Existencias"].ToString();
                        if (registrarexistenciasValue == "True")
                        {
                            btnRegistrarExistencias.Enabled = true;
                            btnRegistrarExistencias.Visible = true;
                        }

                        string controlalmacenValue = reader["Control_Almacen"].ToString();
                        if (controlalmacenValue == "True")
                        {
                            btnControlAlmacen.Enabled = true;
                            btnControlAlmacen.Visible = true;
                        }

                        string consultasalidasValue = reader["Consulta_Salidas"].ToString();
                        if (consultasalidasValue == "True")
                        {
                            btnConsultaSalidas.Enabled = true;
                            btnConsultaSalidas.Visible = true;
                        }
                        string admininventarioValue = reader["Admin_Inventario"].ToString();
                        if (admininventarioValue == "True")
                        {
                            btnAdminInventario.Enabled = true;
                            btnAdminInventario.Visible = true;
                        }

                        string inventarioalmacenValue = reader["Inventario_Almacen"].ToString();
                        if (inventarioalmacenValue == "True")
                        {
                            btnInventarioAlmacen.Enabled = true;
                            btnInventarioAlmacen.Visible = true;
                        }

                        string almacenFabricacionValue = reader["Almacen_Fabricacion"].ToString();
                        if(almacenFabricacionValue == "True")
                        {
                            btnSolicitudFabricacion.Enabled = true;
                            btnSolicitudFabricacion.Visible = true;
                        }
                    }

                    string comprasValue = reader["Compras"].ToString();
                    if (comprasValue == "True")
                    {
                        button6.Enabled = true;
                        button6.Visible = true;
                        string consumiblesalmacenValue = reader["Consumibles_Almacen"].ToString();
                        if (consumiblesalmacenValue == "True")
                        {
                            btnConsumibles.Enabled = true;
                            btnConsumibles.Visible = true;
                        }

                        string reqcompraValue = reader["ComprasReq"].ToString();
                        if (reqcompraValue == "True")
                        {
                            btnReqCompra.Enabled = true;
                            btnReqCompra.Visible = true;
                        }

                        string adminreqValue = reader["ComprasAdmiReq"].ToString();
                        if (adminreqValue == "True")
                        {
                            btnAdmiReq.Enabled = true;
                            btnAdmiReq.Visible = true;
                        }

                        string adminproValue = reader["ComprasAdmiPro"].ToString();
                        if (adminproValue == "True")
                        {
                            btnAdmiProveedores.Enabled = true;
                            btnAdmiProveedores.Visible = true;
                        }

                        string reqenviadasValue = reader["ComprasReqEnviadas"].ToString();
                        if (reqenviadasValue == "True")
                        {
                            btnReqEnv.Enabled = true;
                            btnReqEnv.Visible = true;
                        }

                        string indicadorcomValue = reader["Indicador_Compras"].ToString();
                        if (indicadorcomValue == "True")
                        {
                            btnIndCompras.Enabled = true;
                            btnIndCompras.Visible = true;
                        }

                        string consultarocValue = reader["Compras_ConsultarOCs"].ToString();
                        if (consultarocValue == "True")
                        {
                            btnConsultarOC.Enabled = true;
                            btnConsultarOC.Visible = true;
                        }
                    }

                    string recursoshumanosValue = reader["Recursos_Humanos"].ToString();
                    if (recursoshumanosValue == "True")
                    {
                        button11.Enabled = true;
                        button11.Visible = true;
                        string registrotrabajadorValue = reader["Registro_Trabajador"].ToString();
                        if (registrotrabajadorValue == "True")
                        {
                            btnRegistroTrabajador.Enabled = true;
                            btnRegistroTrabajador.Visible = true;
                        }

                        string generarcredencialValue = reader["Generar_Credencial"].ToString();
                        if (generarcredencialValue == "True")
                        {
                            btnCredencial.Enabled = true;
                            btnCredencial.Visible = true;
                        }
                    }

                    string sistemasValue = reader["Sistemas"].ToString();
                    if (sistemasValue == "True")
                    {
                        button1.Enabled = true;
                        button1.Visible = true;
                        string requisicionValue = reader["Requisicion"].ToString();
                        if (requisicionValue == "True")
                        {
                            btnSistemasReq.Enabled = true;
                            btnSistemasReq.Visible = true;
                        }
                        string permisosValue = reader["Permisos"].ToString();
                        if (permisosValue == "True")
                        {
                            btnPermisos.Enabled = true;
                            btnPermisos.Visible = true;
                        }
                        string pendientesSistemasValue = reader["Pendientes_Sistemas"].ToString();
                        if (pendientesSistemasValue == "True")
                        {
                            btnPendientesSistemas.Enabled = true;
                            btnPendientesSistemas.Visible = true;
                        }
                    }
                    string ventasValue = reader["Ventas"].ToString();
                    if (ventasValue == "True")
                    {
                        btnVentas.Enabled = true;
                        btnVentas.Visible = true;
                        string buscarcotizacionValue = reader["BuscarCotizacion"].ToString();
                        if (buscarcotizacionValue == "True")
                        {
                            btnBuscarCotizacion.Enabled = true;
                            btnBuscarCotizacion.Visible = true;
                        }
                        string clientesValue = reader["Clientes"].ToString();
                        if (clientesValue == "True")
                        {
                            btnCatalogoClientes.Enabled = true;
                            btnCatalogoClientes.Visible = true;
                        }
                        string catalogoproductosValue = reader["CatalogoProductos"].ToString();
                        if (catalogoproductosValue == "True")
                        {
                            btnCatalogoProductos.Enabled = true;
                            btnCatalogoProductos.Visible = true;
                        }
                        string nuevacotizacionValue = reader["NuevaCotizacion"].ToString();
                        if (nuevacotizacionValue == "True")
                        {
                            btnNuevaCotizacion.Enabled = true;
                            btnNuevaCotizacion.Visible = true;
                        }
                    }
                    string produccionValue = reader["Produccion"].ToString();
                    if (produccionValue == "True")
                    {
                        btnProduccion.Enabled = true;
                        btnProduccion.Visible = true;
                        string reporteValue = reader["Reporte"].ToString();
                        if (reporteValue == "True")
                        {
                            btnReporte.Enabled = true;
                            btnReporte.Visible = true;
                        }
                    }
                    string maquinadoValue = reader["Maquinado"].ToString();
                    if (maquinadoValue == "True")
                    {
                        btnMaquinado.Enabled = true;
                        btnMaquinado.Visible = true;
                        string solicitud_maquinadoValue = reader["Solicitud_Maquinado"].ToString();
                        if (solicitud_maquinadoValue == "True")
                        {
                            btnSolicitudMquinado.Enabled = true;
                            btnSolicitudMquinado.Visible = true;
                        }
                        string pendientes_maquinadoValue = reader["Pendientes_Maquinado"].ToString();
                        if (pendientes_maquinadoValue == "True")
                        {
                            btnPendientesMaquinado.Enabled = true;
                            btnPendientesMaquinado.Visible = true;
                        }
                        string historial_maquinadoValue = reader["Historial_Maquinado"].ToString();
                        if (historial_maquinadoValue == "True")
                        {
                            btnHistoricoMaquinado.Enabled = true;
                            btnHistoricoMaquinado.Visible = true;
                        }
                    }
                    string mantenimientoValue = reader["Mantenimiento"].ToString();
                    if (mantenimientoValue == "True")
                    {
                        btnMantenimiento.Enabled = true;
                        btnMantenimiento.Visible = true;
                        string solicitudmttoValue = reader["SolicitudMtto"].ToString();
                        if (solicitudmttoValue == "True")
                        {
                            btnSolicitudMantenimiento.Enabled = true;
                            btnSolicitudMantenimiento.Visible = true;
                        }
                        string pendientesmttoValue = reader["PendientesMtto"].ToString();
                        if (pendientesmttoValue == "True")
                        {
                            btnPendientesMtto.Enabled = true;
                            btnPendientesMtto.Visible = true;
                        }
                        string historicomttoValue = reader["HistoricoMtto"].ToString();
                        if (historicomttoValue == "True")
                        {
                            btnHistoricoMtto.Enabled = true;
                            btnHistoricoMtto.Visible = true;
                        }
                        string inventariomaquinasValue = reader["InventarioMaquinas"].ToString();
                        if (inventariomaquinasValue == "True")
                        {
                            btnInventarioMaquinas.Enabled = true;
                            btnInventarioMaquinas.Visible = true;
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
        private void EliminarConsumiblesPorSurtir()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            try
            {
                cmd.CommandText = "DELETE FROM elastosystem_almacenconsumiblesporsurtir";
                cmd.ExecuteNonQuery();

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
        private void PorSurtir()
        {
            MySqlConnection conn = new MySqlConnection(VariablesGlobales.ConexionBDElastotecnica);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            try
            {
                cmd.CommandText = "INSERT INTO elastosystem_almacenconsumiblesporsurtir (id_producto, producto, existencias, stock_minimo) SELECT id_producto, producto, existencias, stock_minimo FROM elastosystem_almacen WHERE stock_minimo >= existencias AND Estatus = 'ACTIVO'";
                cmd.ExecuteNonQuery();
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
        private void MandarCorreoCompras()
        {
            string tabla = "SELECT Producto, Existencias, Stock_Minimo FROM elastosystem_almacenconsumiblesporsurtir";
            MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(tabla, VariablesGlobales.ConexionBDElastotecnica);
            DataTable dt = new DataTable();
            mySqlAdapter.Fill(dt);

            dgv.DataSource = dt;

            string idmenu = labelid.Text;
            if (idmenu == "3")
            {
                try
                {
                    SmtpClient smtpClient = new SmtpClient("smtp.ionos.mx")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("notificaciones.elastosystem@elastotecnica.com.mx", "El@st0Sys25."),
                        EnableSsl = true
                    };

                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress("notificaciones.elastosystem@elastotecnica.com.mx", "ELASTOTECNICA ALMACEN"),
                        Subject = "COMPRAS PARA ALMACEN",
                        IsBodyHtml = true,
                        Body = ConstruirCuerpoCorreoHTML(dt)
                    };

                    //mailMessage.To.Add("dmedina@elastotecnica.com");
                    //mailMessage.To.Add("ini.medina@gmail.com");
                    //mailMessage.To.Add("compras@elastotecnica.com.mx");
                    mailMessage.To.Add("miguel.garcia@elastotecnnica.com.mx");

                    smtpClient.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ENVIAR EL CORREO: " + ex.Message);
                }
            }
            else
            {

            }
        }

        private string ConstruirCuerpoCorreoHTML(DataTable dataTable)
        {
            StringBuilder cuerpoCorreo = new StringBuilder();

            cuerpoCorreo.AppendLine("<html><body>");
            cuerpoCorreo.AppendLine("<h2>CONSUMIBLES PENDIENTES POR COMPRAR PARA ALMACEN:</h2>");
            cuerpoCorreo.AppendLine("<table border='1' style='border-collapse: collapse; width: 100%; font-family: Arial, sans-serif;'>");

            cuerpoCorreo.AppendLine("<tr style='background-color: #f2f2f2;'>");
            foreach (DataColumn columna in dataTable.Columns)
            {
                cuerpoCorreo.AppendLine($"<th style='padding: 8px; text-align: center; border: 1px solid #ddd;'>{columna.ColumnName}</th>");
            }
            cuerpoCorreo.AppendLine("</tr>");

            foreach (DataRow fila in dataTable.Rows)
            {
                cuerpoCorreo.AppendLine("<tr>");
                foreach (var celda in fila.ItemArray)
                {
                    string valorCelda = celda != null ? celda.ToString() : "";
                    cuerpoCorreo.AppendLine($"<td style='padding: 8px; text-align: center; border: 1px solid #ddd;'>{valorCelda}</td>");
                }
                cuerpoCorreo.AppendLine("</tr>");
            }

            cuerpoCorreo.AppendLine("</table>");
            cuerpoCorreo.AppendLine("</body></html>");

            return cuerpoCorreo.ToString();
        }

        private void customDesign()
        {
            panelSubMenuAlmacen.Visible = false;
            panelSubMenu2.Visible = false;
            panelSubMenu3.Visible = false;
            panelSubMenu4.Visible = false;
            sbmVentas.Visible = false;
            sbmProduccion.Visible = false;
            sbmMaquinado.Visible = false;
            sbmMantenimiento.Visible = false;
        }
        private void HideSubMenu()
        {
            if (panelSubMenuAlmacen.Visible == true)
                panelSubMenuAlmacen.Visible = false;
            if (panelSubMenu2.Visible == true)
                panelSubMenu2.Visible = false;
            if (panelSubMenu3.Visible == true)
                panelSubMenu3.Visible = false;
            if (panelSubMenu4.Visible == true)
                panelSubMenu4.Visible = false;
            if (sbmVentas.Visible == true)
                sbmVentas.Visible = false;
            if (sbmProduccion.Visible == true)
                sbmProduccion.Visible = false;
            if (sbmMaquinado.Visible == true)
                sbmMaquinado.Visible = false;
            if (sbmMantenimiento.Visible == true)
                sbmMantenimiento.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void PBICerrar_Click(object sender, EventArgs e)
        {
            Form1 RegresarAlLogin = new();
            RegresarAlLogin.Show();
            this.Hide();
        }

        private void PBIconoMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PBICerrar_MouseLeave(object sender, EventArgs e)
        {
            PBNaranja.Visible = true;
        }

        private void PBNaranja_MouseMove(object sender, MouseEventArgs e)
        {
            PBNaranja.Visible = false;
        }

        private void PBIconoMin_MouseLeave(object sender, EventArgs e)
        {
            PBAzul.Visible = true;
        }

        private void PBAzul_MouseMove(object sender, MouseEventArgs e)
        {
            PBAzul.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuAlmacen);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenu2);

        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            openChildForm(new Almacen_NuevoProducto());
            HideSubMenu();
        }

        private void btnControlAlmacen_Click(object sender, EventArgs e)
        {
            openChildForm(new AlmacenRegistrarExistencias());
            HideSubMenu();
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            openChildForm(new RFormAlmacen());
            HideSubMenu();
        }

        private void btnConsultaSalidas_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            Almacen_Control frm2 = new();
            frm2.Show();
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(childForm);
            panelPrincipal.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        //CODIGO PARA MOVER PANEL SUPERIOR
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnConsultaSalidas_Click_1(object sender, EventArgs e)
        {
            openChildForm(new AlmacenBuscadorRegistrosTrabajadores());
            HideSubMenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenu3);
        }

        private void panelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelrol_TextChanged(object sender, EventArgs e)
        {
            definirMenus();
            EliminarConsumiblesPorSurtir();
            PorSurtir();
            MandarCorreoCompras();
            ModoPrueba();
        }

        private void ModoPrueba()
        {
            if (VariablesGlobales.IPServidor == "10.120.1.104")
            {
                PBarraTitulo.BackColor = System.Drawing.Color.Red;
                lblModoPruebaMenu.Visible = true;
            }
            else
            {

            }
        }

        private void btninfo_Click(object sender, EventArgs e)
        {
            Info info = new();
            info.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openChildForm(new ConsumiblesAlmacen());
            HideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new Compras_RequisicionMaterial());
            HideSubMenu();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openChildForm(new Novedades());
            HideSubMenu();
        }

        private void btnRegistroTrabajador_Click(object sender, EventArgs e)
        {
            openChildForm(new NuevoUsuarioRH());
            HideSubMenu();
        }

        private void btnCredencial_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            RH_Credencial rhcred = new();
            rhcred.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenu4);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new ReqSistemas());
            HideSubMenu();
        }

        private void panelSubMenu3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            openChildForm(new SistemasPermisos());
            HideSubMenu();
        }

        private void PBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showSubMenu(sbmVentas);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new Ventas_BuscarCotizacion());
            HideSubMenu();
        }

        private void panelSideMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProduccion_Click(object sender, EventArgs e)
        {
            showSubMenu(sbmProduccion);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            /*openChildForm(new Produccion_Reporte());
            HideSubMenu();*/
        }

        private void btnAdmiReq_Click(object sender, EventArgs e)
        {
            openChildForm(new Compras_Administrar_Requisiciones());
            HideSubMenu();
        }

        private void btnAdmiProveedores_Click(object sender, EventArgs e)
        {
            openChildForm(new Compras_Proovedores());
            HideSubMenu();
        }

        private void btnReqEnv_Click(object sender, EventArgs e)
        {
            openChildForm(new Compras_RequisicionesEnviadas());
            HideSubMenu();
        }

        private void btnIndCompras_Click(object sender, EventArgs e)
        {
            openChildForm(new IndicadorCompras());
            HideSubMenu();
        }

        private void btnCatalogoClientes_Click(object sender, EventArgs e)
        {
            openChildForm(new Ventas_Clientes());
            HideSubMenu();
        }

        private void btnCatalogoProductos_Click(object sender, EventArgs e)
        {
            openChildForm(new Ventas_ListaPrecios());
            HideSubMenu();
        }

        private void btnNuevaCotizacion_Click(object sender, EventArgs e)
        {
            openChildForm(new Ventas_Cotizacion());
            HideSubMenu();
        }

        private void btnMaquinado_Click(object sender, EventArgs e)
        {
            showSubMenu(sbmMaquinado);
        }

        private void btnSolicitudMquinado_Click(object sender, EventArgs e)
        {
            openChildForm(new Maquinado_Solicitud());
            HideSubMenu();
        }

        private void btnPendientesMaquinado_Click(object sender, EventArgs e)
        {
            openChildForm(new Maquinado_Administrar());
            HideSubMenu();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Maquinado_Historial());
            HideSubMenu();
        }

        private void btnConsultarOC_Click(object sender, EventArgs e)
        {
            openChildForm(new Compras_ConsultarOC());
            HideSubMenu();
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            showSubMenu(sbmMantenimiento);
        }

        private void btnSolicitudMantenimiento_Click(object sender, EventArgs e)
        {
            openChildForm(new Mtto_Solicitud());
            HideSubMenu();
        }

        private void btnInventarioMaquinas_Click(object sender, EventArgs e)
        {
            openChildForm(new Mtto_InventarioMaquinas());
            HideSubMenu();
        }

        private void btnPendientesMtto_Click(object sender, EventArgs e)
        {
            openChildForm(new Mantenimiento_Pendientes());
            HideSubMenu();
        }

        private void btnHistoricoMtto_Click(object sender, EventArgs e)
        {
            openChildForm(new Mantenimiento_Historico());
            HideSubMenu();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnAdminInventario_Click(object sender, EventArgs e)
        {
            openChildForm(new Almacen_Admin_Inventario());
            HideSubMenu();
        }

        private void btnInventarioAlmacen_Click(object sender, EventArgs e)
        {
            openChildForm(new Almacen_InventarioAlmacen());
            HideSubMenu();
        }

        private void btnPendientesSistemas_Click(object sender, EventArgs e)
        {
            openChildForm(new Sistemas_PendientesSistemas());
            HideSubMenu();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            openChildForm(new Almacen_Fabricacion());
            HideSubMenu();
        }
    }
}
