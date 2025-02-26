namespace ElastoSystem
{
    partial class Sistemas_PendientesSistemas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPendientes = new TabPage();
            txbRuta = new TextBox();
            pbImagen = new PictureBox();
            txbNombreArchivo = new TextBox();
            btnDescargar = new Button();
            btnActualizarTicket = new Button();
            btnTomarTicket = new Button();
            label5 = new Label();
            label4 = new Label();
            cbNivelPrio = new ComboBox();
            label7 = new Label();
            cbTipoReq = new ComboBox();
            label3 = new Label();
            lblSolicitante = new Label();
            txbDescripcion = new TextBox();
            label6 = new Label();
            lblFolioOriginal = new Label();
            lblFolio = new Label();
            label8 = new Label();
            dgvPendientes = new DataGridView();
            tabEnProceso = new TabPage();
            txbComentarios = new TextBox();
            label14 = new Label();
            txbRutaComprobante = new TextBox();
            txbNombreComprobante = new TextBox();
            btnCargarArchivo = new Button();
            txbNomArcEnProceso = new TextBox();
            txbRutaEnProceso = new TextBox();
            btnFinTicket = new Button();
            txbDesEnProceso = new TextBox();
            lblFolioOriginalEnProceso = new Label();
            btnDescarEnProceso = new Button();
            lblCategoriaEnProceso = new Label();
            lblPrioridadEnProceso = new Label();
            lblSolicitanteEnProceso = new Label();
            lblFolioEnProceso = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label2 = new Label();
            dgvEnProceso = new DataGridView();
            tabFinalizado = new TabPage();
            txbNomFin = new TextBox();
            txbRutaFin = new TextBox();
            txbFolioFin = new TextBox();
            btnDesComprobante = new Button();
            label15 = new Label();
            dgvFinalizado = new DataGridView();
            tabControl1.SuspendLayout();
            tabPendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbImagen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPendientes).BeginInit();
            tabEnProceso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEnProceso).BeginInit();
            tabFinalizado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFinalizado).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(36, 37);
            label1.Name = "label1";
            label1.Size = new Size(407, 44);
            label1.TabIndex = 1;
            label1.Text = "ADMINISTRAR TICKETS";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPendientes);
            tabControl1.Controls.Add(tabEnProceso);
            tabControl1.Controls.Add(tabFinalizado);
            tabControl1.Location = new Point(29, 96);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1281, 710);
            tabControl1.TabIndex = 13;
            // 
            // tabPendientes
            // 
            tabPendientes.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabPendientes.Controls.Add(txbRuta);
            tabPendientes.Controls.Add(pbImagen);
            tabPendientes.Controls.Add(txbNombreArchivo);
            tabPendientes.Controls.Add(btnDescargar);
            tabPendientes.Controls.Add(btnActualizarTicket);
            tabPendientes.Controls.Add(btnTomarTicket);
            tabPendientes.Controls.Add(label5);
            tabPendientes.Controls.Add(label4);
            tabPendientes.Controls.Add(cbNivelPrio);
            tabPendientes.Controls.Add(label7);
            tabPendientes.Controls.Add(cbTipoReq);
            tabPendientes.Controls.Add(label3);
            tabPendientes.Controls.Add(lblSolicitante);
            tabPendientes.Controls.Add(txbDescripcion);
            tabPendientes.Controls.Add(label6);
            tabPendientes.Controls.Add(lblFolioOriginal);
            tabPendientes.Controls.Add(lblFolio);
            tabPendientes.Controls.Add(label8);
            tabPendientes.Controls.Add(dgvPendientes);
            tabPendientes.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            tabPendientes.Location = new Point(4, 24);
            tabPendientes.Name = "tabPendientes";
            tabPendientes.Padding = new Padding(3);
            tabPendientes.Size = new Size(1273, 682);
            tabPendientes.TabIndex = 0;
            tabPendientes.Text = "PENDIENTES";
            tabPendientes.UseVisualStyleBackColor = true;
            tabPendientes.Click += tabPendientes_Click;
            // 
            // txbRuta
            // 
            txbRuta.Font = new Font("Montserrat", 12F);
            txbRuta.Location = new Point(1038, 92);
            txbRuta.Name = "txbRuta";
            txbRuta.ReadOnly = true;
            txbRuta.Size = new Size(204, 27);
            txbRuta.TabIndex = 36;
            txbRuta.Visible = false;
            // 
            // pbImagen
            // 
            pbImagen.BackColor = Color.White;
            pbImagen.Location = new Point(694, 31);
            pbImagen.Name = "pbImagen";
            pbImagen.Size = new Size(217, 217);
            pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            pbImagen.TabIndex = 41;
            pbImagen.TabStop = false;
            // 
            // txbNombreArchivo
            // 
            txbNombreArchivo.Font = new Font("Montserrat", 9F);
            txbNombreArchivo.Location = new Point(674, 254);
            txbNombreArchivo.Name = "txbNombreArchivo";
            txbNombreArchivo.ReadOnly = true;
            txbNombreArchivo.Size = new Size(252, 22);
            txbNombreArchivo.TabIndex = 40;
            // 
            // btnDescargar
            // 
            btnDescargar.BackColor = Color.FromArgb(255, 102, 0);
            btnDescargar.Cursor = Cursors.Hand;
            btnDescargar.FlatAppearance.BorderSize = 0;
            btnDescargar.FlatStyle = FlatStyle.Flat;
            btnDescargar.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnDescargar.ForeColor = Color.White;
            btnDescargar.Location = new Point(674, 287);
            btnDescargar.Name = "btnDescargar";
            btnDescargar.Size = new Size(252, 38);
            btnDescargar.TabIndex = 39;
            btnDescargar.Text = "DESCARGAR";
            btnDescargar.UseVisualStyleBackColor = false;
            btnDescargar.Click += btnDescargar_Click;
            // 
            // btnActualizarTicket
            // 
            btnActualizarTicket.BackColor = Color.FromArgb(255, 102, 0);
            btnActualizarTicket.Cursor = Cursors.Hand;
            btnActualizarTicket.FlatAppearance.BorderSize = 0;
            btnActualizarTicket.FlatStyle = FlatStyle.Flat;
            btnActualizarTicket.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnActualizarTicket.ForeColor = Color.White;
            btnActualizarTicket.Location = new Point(1023, 31);
            btnActualizarTicket.Name = "btnActualizarTicket";
            btnActualizarTicket.Size = new Size(219, 33);
            btnActualizarTicket.TabIndex = 37;
            btnActualizarTicket.Text = "ACTUALIZAR TICKET";
            btnActualizarTicket.UseVisualStyleBackColor = false;
            btnActualizarTicket.Visible = false;
            btnActualizarTicket.Click += btnActualizarTicket_Click_1;
            // 
            // btnTomarTicket
            // 
            btnTomarTicket.BackColor = Color.FromArgb(255, 102, 0);
            btnTomarTicket.Cursor = Cursors.Hand;
            btnTomarTicket.FlatAppearance.BorderSize = 0;
            btnTomarTicket.FlatStyle = FlatStyle.Flat;
            btnTomarTicket.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnTomarTicket.ForeColor = Color.White;
            btnTomarTicket.Location = new Point(1006, 280);
            btnTomarTicket.Name = "btnTomarTicket";
            btnTomarTicket.Size = new Size(236, 33);
            btnTomarTicket.TabIndex = 36;
            btnTomarTicket.Text = "TOMAR TICKET";
            btnTomarTicket.UseVisualStyleBackColor = false;
            btnTomarTicket.Visible = false;
            btnTomarTicket.Click += btnTomarTicket_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 15F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(524, 356);
            label5.Name = "label5";
            label5.Size = new Size(240, 27);
            label5.TabIndex = 32;
            label5.Text = "TICKETS PENDIENTES";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 11F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(38, 190);
            label4.Name = "label4";
            label4.Size = new Size(100, 21);
            label4.TabIndex = 31;
            label4.Text = "Descripción:";
            // 
            // cbNivelPrio
            // 
            cbNivelPrio.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNivelPrio.Font = new Font("Montserrat", 11F);
            cbNivelPrio.FormattingEnabled = true;
            cbNivelPrio.Items.AddRange(new object[] { "Alta", "Media", "Baja" });
            cbNivelPrio.Location = new Point(216, 115);
            cbNivelPrio.Name = "cbNivelPrio";
            cbNivelPrio.Size = new Size(345, 29);
            cbNivelPrio.TabIndex = 30;
            cbNivelPrio.SelectedIndexChanged += cbNivelPrio_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 11F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(38, 118);
            label7.Name = "label7";
            label7.Size = new Size(146, 21);
            label7.TabIndex = 29;
            label7.Text = "Nivel de Prioridad:";
            // 
            // cbTipoReq
            // 
            cbTipoReq.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoReq.Font = new Font("Montserrat", 11F);
            cbTipoReq.FormattingEnabled = true;
            cbTipoReq.Items.AddRange(new object[] { "Consulta General", "Fallo en Equipo de Computo", "Mantenimiento Preventivo", "Problemas de Impresoras/Periféricos", "Problema de Seguridad", "Problemas de Red", "Requerimientos de Hardware", "Requerimientos de Software", "Respaldo de Datos", "Sin Acceso al Sistema", "Solicitud de Capacitación", "Solicitud de Cambio o Mejora" });
            cbTipoReq.Location = new Point(215, 151);
            cbTipoReq.Name = "cbTipoReq";
            cbTipoReq.Size = new Size(346, 29);
            cbTipoReq.TabIndex = 28;
            cbTipoReq.SelectedIndexChanged += cbTipoReq_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 11F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(38, 154);
            label3.Name = "label3";
            label3.Size = new Size(162, 21);
            label3.TabIndex = 27;
            label3.Text = "Categoria del Ticket:";
            // 
            // lblSolicitante
            // 
            lblSolicitante.AutoSize = true;
            lblSolicitante.BackColor = Color.Transparent;
            lblSolicitante.Font = new Font("Montserrat", 11F);
            lblSolicitante.ForeColor = Color.White;
            lblSolicitante.Location = new Point(216, 82);
            lblSolicitante.Name = "lblSolicitante";
            lblSolicitante.Size = new Size(70, 21);
            lblSolicitante.TabIndex = 26;
            lblSolicitante.Text = "----------";
            // 
            // txbDescripcion
            // 
            txbDescripcion.Font = new Font("Montserrat", 11F);
            txbDescripcion.Location = new Point(38, 219);
            txbDescripcion.Multiline = true;
            txbDescripcion.Name = "txbDescripcion";
            txbDescripcion.Size = new Size(523, 115);
            txbDescripcion.TabIndex = 25;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 11F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(38, 82);
            label6.Name = "label6";
            label6.Size = new Size(91, 21);
            label6.TabIndex = 24;
            label6.Text = "Solicitante:";
            // 
            // lblFolioOriginal
            // 
            lblFolioOriginal.AutoSize = true;
            lblFolioOriginal.BackColor = Color.Transparent;
            lblFolioOriginal.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            lblFolioOriginal.ForeColor = Color.White;
            lblFolioOriginal.Location = new Point(445, 31);
            lblFolioOriginal.Name = "lblFolioOriginal";
            lblFolioOriginal.Size = new Size(61, 30);
            lblFolioOriginal.TabIndex = 23;
            lblFolioOriginal.Text = "------";
            lblFolioOriginal.Visible = false;
            // 
            // lblFolio
            // 
            lblFolio.AutoSize = true;
            lblFolio.BackColor = Color.Transparent;
            lblFolio.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            lblFolio.ForeColor = Color.White;
            lblFolio.Location = new Point(215, 31);
            lblFolio.Name = "lblFolio";
            lblFolio.Size = new Size(93, 30);
            lblFolio.TabIndex = 22;
            lblFolio.Text = "----------";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(38, 31);
            label8.Name = "label8";
            label8.Size = new Size(75, 30);
            label8.TabIndex = 21;
            label8.Text = "Folio:";
            // 
            // dgvPendientes
            // 
            dgvPendientes.AllowUserToAddRows = false;
            dgvPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPendientes.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPendientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPendientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPendientes.Location = new Point(19, 386);
            dgvPendientes.Name = "dgvPendientes";
            dgvPendientes.ReadOnly = true;
            dgvPendientes.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvPendientes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvPendientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPendientes.Size = new Size(1238, 279);
            dgvPendientes.TabIndex = 20;
            dgvPendientes.Click += dgvPendientes_Click;
            dgvPendientes.DoubleClick += dgvPendientes_DoubleClick;
            // 
            // tabEnProceso
            // 
            tabEnProceso.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabEnProceso.Controls.Add(txbComentarios);
            tabEnProceso.Controls.Add(label14);
            tabEnProceso.Controls.Add(txbRutaComprobante);
            tabEnProceso.Controls.Add(txbNombreComprobante);
            tabEnProceso.Controls.Add(btnCargarArchivo);
            tabEnProceso.Controls.Add(txbNomArcEnProceso);
            tabEnProceso.Controls.Add(txbRutaEnProceso);
            tabEnProceso.Controls.Add(btnFinTicket);
            tabEnProceso.Controls.Add(txbDesEnProceso);
            tabEnProceso.Controls.Add(lblFolioOriginalEnProceso);
            tabEnProceso.Controls.Add(btnDescarEnProceso);
            tabEnProceso.Controls.Add(lblCategoriaEnProceso);
            tabEnProceso.Controls.Add(lblPrioridadEnProceso);
            tabEnProceso.Controls.Add(lblSolicitanteEnProceso);
            tabEnProceso.Controls.Add(lblFolioEnProceso);
            tabEnProceso.Controls.Add(label9);
            tabEnProceso.Controls.Add(label10);
            tabEnProceso.Controls.Add(label11);
            tabEnProceso.Controls.Add(label12);
            tabEnProceso.Controls.Add(label13);
            tabEnProceso.Controls.Add(label2);
            tabEnProceso.Controls.Add(dgvEnProceso);
            tabEnProceso.Cursor = Cursors.Hand;
            tabEnProceso.Location = new Point(4, 24);
            tabEnProceso.Name = "tabEnProceso";
            tabEnProceso.Padding = new Padding(3);
            tabEnProceso.Size = new Size(1273, 682);
            tabEnProceso.TabIndex = 1;
            tabEnProceso.Text = "EN PROCESO";
            tabEnProceso.UseVisualStyleBackColor = true;
            tabEnProceso.Click += tabEnProceso_Click;
            // 
            // txbComentarios
            // 
            txbComentarios.Font = new Font("Montserrat", 11F);
            txbComentarios.Location = new Point(770, 496);
            txbComentarios.Multiline = true;
            txbComentarios.Name = "txbComentarios";
            txbComentarios.Size = new Size(471, 81);
            txbComentarios.TabIndex = 59;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Montserrat", 11F);
            label14.ForeColor = Color.White;
            label14.Location = new Point(770, 468);
            label14.Name = "label14";
            label14.Size = new Size(109, 21);
            label14.TabIndex = 58;
            label14.Text = "Comentarios:";
            // 
            // txbRutaComprobante
            // 
            txbRutaComprobante.Font = new Font("Montserrat", 9F);
            txbRutaComprobante.Location = new Point(947, 380);
            txbRutaComprobante.Name = "txbRutaComprobante";
            txbRutaComprobante.ReadOnly = true;
            txbRutaComprobante.Size = new Size(27, 22);
            txbRutaComprobante.TabIndex = 57;
            txbRutaComprobante.Visible = false;
            // 
            // txbNombreComprobante
            // 
            txbNombreComprobante.Font = new Font("Montserrat", 9F);
            txbNombreComprobante.Location = new Point(770, 431);
            txbNombreComprobante.Name = "txbNombreComprobante";
            txbNombreComprobante.ReadOnly = true;
            txbNombreComprobante.Size = new Size(286, 22);
            txbNombreComprobante.TabIndex = 56;
            txbNombreComprobante.TextAlign = HorizontalAlignment.Center;
            // 
            // btnCargarArchivo
            // 
            btnCargarArchivo.BackColor = Color.FromArgb(255, 102, 0);
            btnCargarArchivo.Cursor = Cursors.Hand;
            btnCargarArchivo.FlatAppearance.BorderSize = 0;
            btnCargarArchivo.FlatStyle = FlatStyle.Flat;
            btnCargarArchivo.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnCargarArchivo.ForeColor = Color.White;
            btnCargarArchivo.Location = new Point(1062, 429);
            btnCargarArchivo.Name = "btnCargarArchivo";
            btnCargarArchivo.Size = new Size(179, 29);
            btnCargarArchivo.TabIndex = 55;
            btnCargarArchivo.Text = "CARGAR COMPROBANTE";
            btnCargarArchivo.UseVisualStyleBackColor = false;
            btnCargarArchivo.Click += btnCargarArchivo_Click;
            // 
            // txbNomArcEnProceso
            // 
            txbNomArcEnProceso.Font = new Font("Montserrat", 9F);
            txbNomArcEnProceso.Location = new Point(811, 35);
            txbNomArcEnProceso.Name = "txbNomArcEnProceso";
            txbNomArcEnProceso.ReadOnly = true;
            txbNomArcEnProceso.Size = new Size(22, 22);
            txbNomArcEnProceso.TabIndex = 54;
            txbNomArcEnProceso.Visible = false;
            // 
            // txbRutaEnProceso
            // 
            txbRutaEnProceso.Font = new Font("Montserrat", 9F);
            txbRutaEnProceso.Location = new Point(786, 35);
            txbRutaEnProceso.Name = "txbRutaEnProceso";
            txbRutaEnProceso.ReadOnly = true;
            txbRutaEnProceso.Size = new Size(19, 22);
            txbRutaEnProceso.TabIndex = 53;
            txbRutaEnProceso.Visible = false;
            // 
            // btnFinTicket
            // 
            btnFinTicket.BackColor = Color.FromArgb(255, 102, 0);
            btnFinTicket.Cursor = Cursors.Hand;
            btnFinTicket.FlatAppearance.BorderSize = 0;
            btnFinTicket.FlatStyle = FlatStyle.Flat;
            btnFinTicket.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnFinTicket.ForeColor = Color.White;
            btnFinTicket.Location = new Point(898, 597);
            btnFinTicket.Name = "btnFinTicket";
            btnFinTicket.Size = new Size(236, 33);
            btnFinTicket.TabIndex = 52;
            btnFinTicket.Text = "FINALIZAR TICKET";
            btnFinTicket.UseVisualStyleBackColor = false;
            btnFinTicket.Click += btnFinTicket_Click;
            // 
            // txbDesEnProceso
            // 
            txbDesEnProceso.Font = new Font("Montserrat", 11F);
            txbDesEnProceso.Location = new Point(770, 244);
            txbDesEnProceso.Multiline = true;
            txbDesEnProceso.Name = "txbDesEnProceso";
            txbDesEnProceso.ReadOnly = true;
            txbDesEnProceso.Size = new Size(471, 115);
            txbDesEnProceso.TabIndex = 51;
            // 
            // lblFolioOriginalEnProceso
            // 
            lblFolioOriginalEnProceso.AutoSize = true;
            lblFolioOriginalEnProceso.BackColor = Color.Transparent;
            lblFolioOriginalEnProceso.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            lblFolioOriginalEnProceso.ForeColor = Color.White;
            lblFolioOriginalEnProceso.Location = new Point(974, 27);
            lblFolioOriginalEnProceso.Name = "lblFolioOriginalEnProceso";
            lblFolioOriginalEnProceso.Size = new Size(93, 30);
            lblFolioOriginalEnProceso.TabIndex = 50;
            lblFolioOriginalEnProceso.Text = "----------";
            lblFolioOriginalEnProceso.Visible = false;
            // 
            // btnDescarEnProceso
            // 
            btnDescarEnProceso.BackColor = Color.FromArgb(255, 102, 0);
            btnDescarEnProceso.Cursor = Cursors.Hand;
            btnDescarEnProceso.FlatAppearance.BorderSize = 0;
            btnDescarEnProceso.FlatStyle = FlatStyle.Flat;
            btnDescarEnProceso.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnDescarEnProceso.ForeColor = Color.White;
            btnDescarEnProceso.Location = new Point(1006, 375);
            btnDescarEnProceso.Name = "btnDescarEnProceso";
            btnDescarEnProceso.Size = new Size(235, 28);
            btnDescarEnProceso.TabIndex = 49;
            btnDescarEnProceso.Text = "Descargar Archivo Adjunto";
            btnDescarEnProceso.UseVisualStyleBackColor = false;
            btnDescarEnProceso.Visible = false;
            btnDescarEnProceso.Click += btnDescarEnProceso_Click;
            // 
            // lblCategoriaEnProceso
            // 
            lblCategoriaEnProceso.AutoSize = true;
            lblCategoriaEnProceso.BackColor = Color.Transparent;
            lblCategoriaEnProceso.Font = new Font("Montserrat", 11F);
            lblCategoriaEnProceso.ForeColor = Color.White;
            lblCategoriaEnProceso.Location = new Point(974, 177);
            lblCategoriaEnProceso.Name = "lblCategoriaEnProceso";
            lblCategoriaEnProceso.Size = new Size(0, 21);
            lblCategoriaEnProceso.TabIndex = 47;
            // 
            // lblPrioridadEnProceso
            // 
            lblPrioridadEnProceso.AutoSize = true;
            lblPrioridadEnProceso.BackColor = Color.Transparent;
            lblPrioridadEnProceso.Font = new Font("Montserrat", 11F);
            lblPrioridadEnProceso.ForeColor = Color.White;
            lblPrioridadEnProceso.Location = new Point(974, 141);
            lblPrioridadEnProceso.Name = "lblPrioridadEnProceso";
            lblPrioridadEnProceso.Size = new Size(0, 21);
            lblPrioridadEnProceso.TabIndex = 46;
            // 
            // lblSolicitanteEnProceso
            // 
            lblSolicitanteEnProceso.AutoSize = true;
            lblSolicitanteEnProceso.BackColor = Color.Transparent;
            lblSolicitanteEnProceso.Font = new Font("Montserrat", 11F);
            lblSolicitanteEnProceso.ForeColor = Color.White;
            lblSolicitanteEnProceso.Location = new Point(974, 105);
            lblSolicitanteEnProceso.Name = "lblSolicitanteEnProceso";
            lblSolicitanteEnProceso.Size = new Size(0, 21);
            lblSolicitanteEnProceso.TabIndex = 45;
            // 
            // lblFolioEnProceso
            // 
            lblFolioEnProceso.AutoSize = true;
            lblFolioEnProceso.BackColor = Color.Transparent;
            lblFolioEnProceso.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            lblFolioEnProceso.ForeColor = Color.White;
            lblFolioEnProceso.Location = new Point(974, 66);
            lblFolioEnProceso.Name = "lblFolioEnProceso";
            lblFolioEnProceso.Size = new Size(0, 30);
            lblFolioEnProceso.TabIndex = 44;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Montserrat", 11F);
            label9.ForeColor = Color.White;
            label9.Location = new Point(770, 213);
            label9.Name = "label9";
            label9.Size = new Size(100, 21);
            label9.TabIndex = 43;
            label9.Text = "Descripción:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 11F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(770, 141);
            label10.Name = "label10";
            label10.Size = new Size(146, 21);
            label10.TabIndex = 42;
            label10.Text = "Nivel de Prioridad:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Montserrat", 11F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(770, 177);
            label11.Name = "label11";
            label11.Size = new Size(162, 21);
            label11.TabIndex = 41;
            label11.Text = "Categoria del Ticket:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Montserrat", 11F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(770, 105);
            label12.Name = "label12";
            label12.Size = new Size(91, 21);
            label12.TabIndex = 39;
            label12.Text = "Solicitante:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            label13.ForeColor = Color.White;
            label13.Location = new Point(770, 66);
            label13.Name = "label13";
            label13.Size = new Size(75, 30);
            label13.TabIndex = 38;
            label13.Text = "Folio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 15F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(28, 28);
            label2.Name = "label2";
            label2.Size = new Size(245, 27);
            label2.TabIndex = 34;
            label2.Text = "TICKETS EN PROCESO";
            // 
            // dgvEnProceso
            // 
            dgvEnProceso.AllowUserToAddRows = false;
            dgvEnProceso.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEnProceso.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvEnProceso.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvEnProceso.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnProceso.Location = new Point(17, 69);
            dgvEnProceso.Name = "dgvEnProceso";
            dgvEnProceso.ReadOnly = true;
            dgvEnProceso.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvEnProceso.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvEnProceso.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEnProceso.Size = new Size(729, 585);
            dgvEnProceso.TabIndex = 33;
            dgvEnProceso.Click += dgvEnProceso_Click;
            // 
            // tabFinalizado
            // 
            tabFinalizado.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabFinalizado.Controls.Add(txbNomFin);
            tabFinalizado.Controls.Add(txbRutaFin);
            tabFinalizado.Controls.Add(txbFolioFin);
            tabFinalizado.Controls.Add(btnDesComprobante);
            tabFinalizado.Controls.Add(label15);
            tabFinalizado.Controls.Add(dgvFinalizado);
            tabFinalizado.Location = new Point(4, 24);
            tabFinalizado.Name = "tabFinalizado";
            tabFinalizado.Size = new Size(1273, 682);
            tabFinalizado.TabIndex = 2;
            tabFinalizado.Text = "FINALIZADO";
            tabFinalizado.UseVisualStyleBackColor = true;
            tabFinalizado.Click += tabFinalizado_Click;
            // 
            // txbNomFin
            // 
            txbNomFin.Font = new Font("Montserrat", 9F);
            txbNomFin.Location = new Point(814, 29);
            txbNomFin.Name = "txbNomFin";
            txbNomFin.ReadOnly = true;
            txbNomFin.Size = new Size(70, 22);
            txbNomFin.TabIndex = 53;
            txbNomFin.Visible = false;
            // 
            // txbRutaFin
            // 
            txbRutaFin.Font = new Font("Montserrat", 9F);
            txbRutaFin.Location = new Point(917, 29);
            txbRutaFin.Name = "txbRutaFin";
            txbRutaFin.ReadOnly = true;
            txbRutaFin.Size = new Size(70, 22);
            txbRutaFin.TabIndex = 52;
            txbRutaFin.Visible = false;
            // 
            // txbFolioFin
            // 
            txbFolioFin.Font = new Font("Montserrat", 9F);
            txbFolioFin.Location = new Point(718, 29);
            txbFolioFin.Name = "txbFolioFin";
            txbFolioFin.ReadOnly = true;
            txbFolioFin.Size = new Size(70, 22);
            txbFolioFin.TabIndex = 51;
            txbFolioFin.Visible = false;
            // 
            // btnDesComprobante
            // 
            btnDesComprobante.BackColor = Color.FromArgb(255, 102, 0);
            btnDesComprobante.Cursor = Cursors.Hand;
            btnDesComprobante.FlatAppearance.BorderSize = 0;
            btnDesComprobante.FlatStyle = FlatStyle.Flat;
            btnDesComprobante.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnDesComprobante.ForeColor = Color.White;
            btnDesComprobante.Location = new Point(993, 23);
            btnDesComprobante.Name = "btnDesComprobante";
            btnDesComprobante.Size = new Size(252, 35);
            btnDesComprobante.TabIndex = 50;
            btnDesComprobante.Text = "Descargar Comprobante";
            btnDesComprobante.UseVisualStyleBackColor = false;
            btnDesComprobante.Click += button1_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Montserrat", 15F, FontStyle.Bold);
            label15.ForeColor = Color.White;
            label15.Location = new Point(41, 23);
            label15.Name = "label15";
            label15.Size = new Size(250, 27);
            label15.TabIndex = 36;
            label15.Text = "TICKETS FINALIZADOS";
            // 
            // dgvFinalizado
            // 
            dgvFinalizado.AllowUserToAddRows = false;
            dgvFinalizado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFinalizado.BackgroundColor = Color.White;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvFinalizado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvFinalizado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFinalizado.Location = new Point(30, 64);
            dgvFinalizado.Name = "dgvFinalizado";
            dgvFinalizado.ReadOnly = true;
            dgvFinalizado.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dgvFinalizado.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvFinalizado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFinalizado.Size = new Size(1215, 585);
            dgvFinalizado.TabIndex = 35;
            dgvFinalizado.SelectionChanged += dgvFinalizado_SelectionChanged;
            // 
            // Sistemas_PendientesSistemas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Sistemas_PendientesSistemas";
            Text = "Sistemas_PendientesSistemas";
            Load += Sistemas_PendientesSistemas_Load;
            tabControl1.ResumeLayout(false);
            tabPendientes.ResumeLayout(false);
            tabPendientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbImagen).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPendientes).EndInit();
            tabEnProceso.ResumeLayout(false);
            tabEnProceso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEnProceso).EndInit();
            tabFinalizado.ResumeLayout(false);
            tabFinalizado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFinalizado).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPendientes;
        private TabPage tabEnProceso;
        private TabPage tabFinalizado;
        private DataGridView dgvPendientes;
        private Button btnTomarTicket;
        private Label lblFolioOriginal;
        private Label lblFolio;
        private Label label8;
        private TextBox txbDescripcion;
        private Label label6;
        private Label lblSolicitante;
        private ComboBox cbNivelPrio;
        private Label label7;
        private ComboBox cbTipoReq;
        private Label label3;
        private Label label4;
        private Button btnActualizarTicket;
        private Label label5;
        private PictureBox pbImagen;
        private TextBox txbNombreArchivo;
        private Button btnDescargar;
        private TextBox txbRuta;
        private Label label2;
        private DataGridView dgvEnProceso;
        private Button btnDesComprobante;
        private Label label18;
        private Label lblCategoriaEnProceso;
        private Label lblPrioridadEnProceso;
        private Label lblSolicitanteEnProceso;
        private Label lblFolioEnProceso;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txbComentarios;
        private Label label12;
        private Label label13;
        private Button btnDescarEnProceso;
        private Label lblFolioOriginalEnProceso;
        private Button btnFinTicket;
        private TextBox txbDesEnProceso;
        private TextBox txbNomArcEnProceso;
        private TextBox txbRutaEnProceso;
        private TextBox txbNombreComprobante;
        private Button btnCargarArchivo;
        private TextBox txbRutaComprobante;
        private Label label14;
        private Label label15;
        private DataGridView dgvFinalizado;
        private TextBox txbFolioFin;
        private TextBox txbNomFin;
        private TextBox txbRutaFin;
    }
}