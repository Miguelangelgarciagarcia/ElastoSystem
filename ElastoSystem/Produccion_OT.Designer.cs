namespace ElastoSystem
{
    partial class Produccion_OT
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produccion_OT));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel4 = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox6 = new PictureBox();
            lblOrdenTrabajo = new Label();
            panel1 = new Panel();
            btnVerEspecificacion = new Button();
            txbSolicitudFabricacion = new TextBox();
            label16 = new Label();
            label17 = new Label();
            txbObservaciones = new TextBox();
            cbMaquinas = new ComboBox();
            label15 = new Label();
            txbEspecificacion = new TextBox();
            txbNombreArea = new TextBox();
            txbArea = new TextBox();
            label7 = new Label();
            label10 = new Label();
            cbTurno = new ComboBox();
            dtpFechaFinal = new DateTimePicker();
            dtpFechaInicio = new DateTimePicker();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            label13 = new Label();
            lblAutorizo = new Label();
            cbMolde = new ComboBox();
            txbLote = new TextBox();
            label12 = new Label();
            label11 = new Label();
            txbCantidad = new TextBox();
            label14 = new Label();
            panel2 = new Panel();
            panel11 = new Panel();
            lblProductoConforme = new Label();
            label24 = new Label();
            lblProduccionXTurno = new Label();
            panel3 = new Panel();
            lblDiasRestantes = new Label();
            label9 = new Label();
            pnlPNCPor = new Panel();
            lblPorPNC = new Label();
            label21 = new Label();
            panel5 = new Panel();
            lblPNCEnOperacion = new Label();
            label18 = new Label();
            pnlPNC = new Panel();
            lblPNCTotal = new Label();
            label20 = new Label();
            pnlReprocesoPor = new Panel();
            lblPorReproceso = new Label();
            label23 = new Label();
            panel6 = new Panel();
            lblPNCEnRevision = new Label();
            label19 = new Label();
            pnlReproceso = new Panel();
            lblReprocesoTotal = new Label();
            label22 = new Label();
            button1 = new Button();
            panel12 = new Panel();
            lblProduccionEnOperacion = new Label();
            label8 = new Label();
            dgvIngresos = new DataGridView();
            timerParpadeoPNC = new System.Windows.Forms.Timer(components);
            timerParpadeoReproceso = new System.Windows.Forms.Timer(components);
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel11.SuspendLayout();
            panel3.SuspendLayout();
            pnlPNCPor.SuspendLayout();
            panel5.SuspendLayout();
            pnlPNC.SuspendLayout();
            pnlReprocesoPor.SuspendLayout();
            panel6.SuspendLayout();
            pnlReproceso.SuspendLayout();
            panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIngresos).BeginInit();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(153, 255, 255, 255);
            panel4.Controls.Add(pictureBox4);
            panel4.Controls.Add(pictureBox6);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1162, 30);
            panel4.TabIndex = 88;
            panel4.MouseDown += panel4_MouseDown;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(1127, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(23, 23);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 20;
            pictureBox4.TabStop = false;
            pictureBox4.MouseMove += pictureBox4_MouseMove;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Cursor = Cursors.Hand;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(1127, 4);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(23, 23);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 18;
            pictureBox6.TabStop = false;
            pictureBox6.Click += pictureBox6_Click;
            pictureBox6.MouseLeave += pictureBox6_MouseLeave;
            // 
            // lblOrdenTrabajo
            // 
            lblOrdenTrabajo.AutoSize = true;
            lblOrdenTrabajo.BackColor = Color.Transparent;
            lblOrdenTrabajo.Font = new Font("Montserrat", 20F, FontStyle.Bold);
            lblOrdenTrabajo.ForeColor = Color.White;
            lblOrdenTrabajo.Location = new Point(12, 39);
            lblOrdenTrabajo.Name = "lblOrdenTrabajo";
            lblOrdenTrabajo.Size = new Size(433, 42);
            lblOrdenTrabajo.TabIndex = 89;
            lblOrdenTrabajo.Text = "ORDEN DE TRABAJO: ERROR";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(btnVerEspecificacion);
            panel1.Controls.Add(txbSolicitudFabricacion);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(txbObservaciones);
            panel1.Controls.Add(cbMaquinas);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(txbEspecificacion);
            panel1.Controls.Add(txbNombreArea);
            panel1.Controls.Add(txbArea);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(cbTurno);
            panel1.Controls.Add(dtpFechaFinal);
            panel1.Controls.Add(dtpFechaInicio);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(lblAutorizo);
            panel1.Controls.Add(cbMolde);
            panel1.Controls.Add(txbLote);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(txbCantidad);
            panel1.Location = new Point(12, 82);
            panel1.Name = "panel1";
            panel1.Size = new Size(932, 261);
            panel1.TabIndex = 92;
            // 
            // btnVerEspecificacion
            // 
            btnVerEspecificacion.BackColor = Color.FromArgb(255, 102, 0);
            btnVerEspecificacion.Cursor = Cursors.Hand;
            btnVerEspecificacion.FlatAppearance.BorderSize = 0;
            btnVerEspecificacion.FlatStyle = FlatStyle.Flat;
            btnVerEspecificacion.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            btnVerEspecificacion.ForeColor = Color.White;
            btnVerEspecificacion.Location = new Point(484, 198);
            btnVerEspecificacion.Name = "btnVerEspecificacion";
            btnVerEspecificacion.Size = new Size(390, 34);
            btnVerEspecificacion.TabIndex = 124;
            btnVerEspecificacion.Text = "VER ESPECIFICACIÓN";
            btnVerEspecificacion.UseVisualStyleBackColor = false;
            btnVerEspecificacion.Visible = false;
            btnVerEspecificacion.Click += btnVerEspecificacion_Click;
            // 
            // txbSolicitudFabricacion
            // 
            txbSolicitudFabricacion.Font = new Font("Montserrat", 10F);
            txbSolicitudFabricacion.Location = new Point(614, 146);
            txbSolicitudFabricacion.Name = "txbSolicitudFabricacion";
            txbSolicitudFabricacion.ReadOnly = true;
            txbSolicitudFabricacion.Size = new Size(295, 24);
            txbSolicitudFabricacion.TabIndex = 121;
            txbSolicitudFabricacion.TextAlign = HorizontalAlignment.Center;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Montserrat", 10F);
            label16.ForeColor = Color.White;
            label16.Location = new Point(10, 215);
            label16.Name = "label16";
            label16.Size = new Size(116, 22);
            label16.TabIndex = 120;
            label16.Text = "Observaciones:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Transparent;
            label17.Font = new Font("Montserrat", 10F);
            label17.ForeColor = Color.White;
            label17.Location = new Point(427, 149);
            label17.Name = "label17";
            label17.Size = new Size(182, 22);
            label17.TabIndex = 118;
            label17.Text = "Solicitud de Fabricación:";
            // 
            // txbObservaciones
            // 
            txbObservaciones.Font = new Font("Montserrat", 10F);
            txbObservaciones.Location = new Point(132, 212);
            txbObservaciones.Name = "txbObservaciones";
            txbObservaciones.ReadOnly = true;
            txbObservaciones.Size = new Size(273, 24);
            txbObservaciones.TabIndex = 119;
            // 
            // cbMaquinas
            // 
            cbMaquinas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMaquinas.Enabled = false;
            cbMaquinas.Font = new Font("Montserrat", 10F);
            cbMaquinas.FormattingEnabled = true;
            cbMaquinas.Location = new Point(544, 113);
            cbMaquinas.Name = "cbMaquinas";
            cbMaquinas.Size = new Size(365, 28);
            cbMaquinas.TabIndex = 114;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Montserrat", 10F);
            label15.ForeColor = Color.White;
            label15.Location = new Point(427, 116);
            label15.Name = "label15";
            label15.Size = new Size(73, 22);
            label15.TabIndex = 115;
            label15.Text = "Máquina:";
            // 
            // txbEspecificacion
            // 
            txbEspecificacion.Font = new Font("Montserrat", 10F);
            txbEspecificacion.Location = new Point(439, 177);
            txbEspecificacion.Name = "txbEspecificacion";
            txbEspecificacion.ReadOnly = true;
            txbEspecificacion.Size = new Size(32, 24);
            txbEspecificacion.TabIndex = 107;
            txbEspecificacion.TextAlign = HorizontalAlignment.Center;
            txbEspecificacion.Visible = false;
            // 
            // txbNombreArea
            // 
            txbNombreArea.Font = new Font("Montserrat", 10F);
            txbNombreArea.Location = new Point(544, 80);
            txbNombreArea.Name = "txbNombreArea";
            txbNombreArea.ReadOnly = true;
            txbNombreArea.Size = new Size(365, 24);
            txbNombreArea.TabIndex = 113;
            txbNombreArea.TextAlign = HorizontalAlignment.Center;
            // 
            // txbArea
            // 
            txbArea.Font = new Font("Montserrat", 10F);
            txbArea.Location = new Point(544, 48);
            txbArea.Name = "txbArea";
            txbArea.ReadOnly = true;
            txbArea.Size = new Size(365, 24);
            txbArea.TabIndex = 112;
            txbArea.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 10F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(426, 51);
            label7.Name = "label7";
            label7.Size = new Size(45, 22);
            label7.TabIndex = 110;
            label7.Text = "Área:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 10F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(426, 83);
            label10.Name = "label10";
            label10.Size = new Size(107, 22);
            label10.TabIndex = 111;
            label10.Text = "Nombre Área:";
            // 
            // cbTurno
            // 
            cbTurno.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTurno.Enabled = false;
            cbTurno.Font = new Font("Montserrat", 10F);
            cbTurno.FormattingEnabled = true;
            cbTurno.Items.AddRange(new object[] { "1 TURNO", "2 TURNOS", "3 TURNOS" });
            cbTurno.Location = new Point(132, 77);
            cbTurno.Name = "cbTurno";
            cbTurno.Size = new Size(274, 28);
            cbTurno.TabIndex = 96;
            // 
            // dtpFechaFinal
            // 
            dtpFechaFinal.Enabled = false;
            dtpFechaFinal.Font = new Font("Montserrat", 10F);
            dtpFechaFinal.Location = new Point(598, 17);
            dtpFechaFinal.Name = "dtpFechaFinal";
            dtpFechaFinal.Size = new Size(311, 24);
            dtpFechaFinal.TabIndex = 77;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Enabled = false;
            dtpFechaInicio.Font = new Font("Montserrat", 10F);
            dtpFechaInicio.Location = new Point(145, 17);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(311, 24);
            dtpFechaInicio.TabIndex = 76;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 10F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(15, 83);
            label5.Name = "label5";
            label5.Size = new Size(54, 22);
            label5.TabIndex = 96;
            label5.Text = "Turno:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 10F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(15, 52);
            label3.Name = "label3";
            label3.Size = new Size(73, 22);
            label3.TabIndex = 95;
            label3.Text = "Autorizo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 10F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(468, 22);
            label2.Name = "label2";
            label2.Size = new Size(117, 22);
            label2.TabIndex = 75;
            label2.Text = "Fecha Termino:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 10F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(15, 22);
            label4.Name = "label4";
            label4.Size = new Size(97, 22);
            label4.TabIndex = 73;
            label4.Text = "Fecha Inicio:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 10F);
            label13.ForeColor = Color.White;
            label13.Location = new Point(15, 115);
            label13.Name = "label13";
            label13.Size = new Size(76, 22);
            label13.TabIndex = 104;
            label13.Text = "Cantidad:";
            // 
            // lblAutorizo
            // 
            lblAutorizo.AutoSize = true;
            lblAutorizo.BackColor = Color.Transparent;
            lblAutorizo.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            lblAutorizo.ForeColor = Color.White;
            lblAutorizo.Location = new Point(132, 52);
            lblAutorizo.Name = "lblAutorizo";
            lblAutorizo.Size = new Size(61, 22);
            lblAutorizo.TabIndex = 94;
            lblAutorizo.Text = "ERROR";
            // 
            // cbMolde
            // 
            cbMolde.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMolde.Enabled = false;
            cbMolde.Font = new Font("Montserrat", 10F);
            cbMolde.FormattingEnabled = true;
            cbMolde.Location = new Point(132, 176);
            cbMolde.Name = "cbMolde";
            cbMolde.Size = new Size(273, 28);
            cbMolde.TabIndex = 97;
            // 
            // txbLote
            // 
            txbLote.Font = new Font("Montserrat", 10F);
            txbLote.Location = new Point(133, 144);
            txbLote.Name = "txbLote";
            txbLote.ReadOnly = true;
            txbLote.Size = new Size(272, 24);
            txbLote.TabIndex = 103;
            txbLote.TextAlign = HorizontalAlignment.Center;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Montserrat", 10F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(15, 147);
            label12.Name = "label12";
            label12.Size = new Size(44, 22);
            label12.TabIndex = 102;
            label12.Text = "Lote:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Montserrat", 10F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(15, 179);
            label11.Name = "label11";
            label11.Size = new Size(56, 22);
            label11.TabIndex = 98;
            label11.Text = "Molde:";
            // 
            // txbCantidad
            // 
            txbCantidad.Font = new Font("Montserrat", 10F);
            txbCantidad.Location = new Point(133, 112);
            txbCantidad.Name = "txbCantidad";
            txbCantidad.ReadOnly = true;
            txbCantidad.Size = new Size(272, 24);
            txbCantidad.TabIndex = 101;
            txbCantidad.TextAlign = HorizontalAlignment.Center;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label14.ForeColor = Color.White;
            label14.Location = new Point(17, 13);
            label14.Name = "label14";
            label14.Size = new Size(175, 22);
            label14.TabIndex = 117;
            label14.Text = "Producción por Turno:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(3, 42, 76);
            panel2.Controls.Add(panel11);
            panel2.Controls.Add(lblProduccionXTurno);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(pnlPNCPor);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(pnlPNC);
            panel2.Controls.Add(pnlReprocesoPor);
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(pnlReproceso);
            panel2.Location = new Point(950, 39);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 706);
            panel2.TabIndex = 93;
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(3, 42, 76);
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.Controls.Add(lblProductoConforme);
            panel11.Controls.Add(label24);
            panel11.Location = new Point(17, 598);
            panel11.Name = "panel11";
            panel11.Size = new Size(166, 94);
            panel11.TabIndex = 127;
            // 
            // lblProductoConforme
            // 
            lblProductoConforme.BackColor = Color.Transparent;
            lblProductoConforme.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            lblProductoConforme.ForeColor = Color.White;
            lblProductoConforme.Location = new Point(-1, 53);
            lblProductoConforme.Name = "lblProductoConforme";
            lblProductoConforme.Size = new Size(166, 34);
            lblProductoConforme.TabIndex = 134;
            lblProductoConforme.Text = "-----";
            lblProductoConforme.TextAlign = ContentAlignment.TopCenter;
            // 
            // label24
            // 
            label24.BackColor = Color.Transparent;
            label24.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label24.ForeColor = Color.White;
            label24.Location = new Point(-1, 5);
            label24.Name = "label24";
            label24.Size = new Size(166, 45);
            label24.TabIndex = 125;
            label24.Text = "PRODUCTO CONFORME:";
            label24.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblProduccionXTurno
            // 
            lblProduccionXTurno.BackColor = Color.Transparent;
            lblProduccionXTurno.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            lblProduccionXTurno.ForeColor = Color.White;
            lblProduccionXTurno.Location = new Point(17, 37);
            lblProduccionXTurno.Name = "lblProduccionXTurno";
            lblProduccionXTurno.Size = new Size(166, 34);
            lblProduccionXTurno.TabIndex = 95;
            lblProduccionXTurno.Text = "ERROR";
            lblProduccionXTurno.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(3, 42, 76);
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblDiasRestantes);
            panel3.Controls.Add(label9);
            panel3.Location = new Point(17, 80);
            panel3.Name = "panel3";
            panel3.Size = new Size(166, 68);
            panel3.TabIndex = 126;
            // 
            // lblDiasRestantes
            // 
            lblDiasRestantes.BackColor = Color.Transparent;
            lblDiasRestantes.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            lblDiasRestantes.ForeColor = Color.White;
            lblDiasRestantes.Location = new Point(-1, 32);
            lblDiasRestantes.Name = "lblDiasRestantes";
            lblDiasRestantes.Size = new Size(166, 34);
            lblDiasRestantes.TabIndex = 129;
            lblDiasRestantes.Text = "--";
            lblDiasRestantes.TextAlign = ContentAlignment.TopCenter;
            // 
            // label9
            // 
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(-1, 5);
            label9.Name = "label9";
            label9.Size = new Size(166, 20);
            label9.TabIndex = 118;
            label9.Text = "DIAS RESTANTES";
            label9.TextAlign = ContentAlignment.TopCenter;
            // 
            // pnlPNCPor
            // 
            pnlPNCPor.BackColor = Color.FromArgb(3, 42, 76);
            pnlPNCPor.Controls.Add(lblPorPNC);
            pnlPNCPor.Controls.Add(label21);
            pnlPNCPor.Location = new Point(17, 524);
            pnlPNCPor.Name = "pnlPNCPor";
            pnlPNCPor.Size = new Size(166, 68);
            pnlPNCPor.TabIndex = 127;
            pnlPNCPor.Paint += pnlPNCPor_Paint;
            // 
            // lblPorPNC
            // 
            lblPorPNC.BackColor = Color.Transparent;
            lblPorPNC.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            lblPorPNC.ForeColor = Color.White;
            lblPorPNC.Location = new Point(-1, 27);
            lblPorPNC.Name = "lblPorPNC";
            lblPorPNC.Size = new Size(166, 34);
            lblPorPNC.TabIndex = 131;
            lblPorPNC.Text = "--%";
            lblPorPNC.TextAlign = ContentAlignment.TopCenter;
            // 
            // label21
            // 
            label21.BackColor = Color.Transparent;
            label21.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label21.ForeColor = Color.White;
            label21.Location = new Point(-1, 5);
            label21.Name = "label21";
            label21.Size = new Size(166, 20);
            label21.TabIndex = 122;
            label21.Text = "PNC %";
            label21.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(3, 42, 76);
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(lblPNCEnOperacion);
            panel5.Controls.Add(label18);
            panel5.Location = new Point(17, 154);
            panel5.Name = "panel5";
            panel5.Size = new Size(166, 68);
            panel5.TabIndex = 127;
            // 
            // lblPNCEnOperacion
            // 
            lblPNCEnOperacion.BackColor = Color.Transparent;
            lblPNCEnOperacion.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            lblPNCEnOperacion.ForeColor = Color.White;
            lblPNCEnOperacion.Location = new Point(-1, 27);
            lblPNCEnOperacion.Name = "lblPNCEnOperacion";
            lblPNCEnOperacion.Size = new Size(166, 34);
            lblPNCEnOperacion.TabIndex = 130;
            lblPNCEnOperacion.Text = "---";
            lblPNCEnOperacion.TextAlign = ContentAlignment.TopCenter;
            // 
            // label18
            // 
            label18.BackColor = Color.Transparent;
            label18.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label18.ForeColor = Color.White;
            label18.Location = new Point(-1, 5);
            label18.Name = "label18";
            label18.Size = new Size(166, 20);
            label18.TabIndex = 119;
            label18.Text = "PNC EN OPERACION";
            label18.TextAlign = ContentAlignment.TopCenter;
            // 
            // pnlPNC
            // 
            pnlPNC.BackColor = Color.FromArgb(3, 42, 76);
            pnlPNC.Controls.Add(lblPNCTotal);
            pnlPNC.Controls.Add(label20);
            pnlPNC.Location = new Point(17, 450);
            pnlPNC.Name = "pnlPNC";
            pnlPNC.Size = new Size(166, 68);
            pnlPNC.TabIndex = 127;
            pnlPNC.Paint += pnlPNC_Paint;
            // 
            // lblPNCTotal
            // 
            lblPNCTotal.BackColor = Color.Transparent;
            lblPNCTotal.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            lblPNCTotal.ForeColor = Color.White;
            lblPNCTotal.Location = new Point(-1, 27);
            lblPNCTotal.Name = "lblPNCTotal";
            lblPNCTotal.Size = new Size(166, 34);
            lblPNCTotal.TabIndex = 132;
            lblPNCTotal.Text = "---";
            lblPNCTotal.TextAlign = ContentAlignment.TopCenter;
            // 
            // label20
            // 
            label20.BackColor = Color.Transparent;
            label20.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label20.ForeColor = Color.White;
            label20.Location = new Point(-1, 6);
            label20.Name = "label20";
            label20.Size = new Size(166, 20);
            label20.TabIndex = 121;
            label20.Text = "PNC TOTAL";
            label20.TextAlign = ContentAlignment.TopCenter;
            // 
            // pnlReprocesoPor
            // 
            pnlReprocesoPor.BackColor = Color.FromArgb(3, 42, 76);
            pnlReprocesoPor.Controls.Add(lblPorReproceso);
            pnlReprocesoPor.Controls.Add(label23);
            pnlReprocesoPor.Location = new Point(17, 376);
            pnlReprocesoPor.Name = "pnlReprocesoPor";
            pnlReprocesoPor.Size = new Size(166, 68);
            pnlReprocesoPor.TabIndex = 127;
            pnlReprocesoPor.Paint += pnlReprocesoPor_Paint;
            // 
            // lblPorReproceso
            // 
            lblPorReproceso.BackColor = Color.Transparent;
            lblPorReproceso.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            lblPorReproceso.ForeColor = Color.White;
            lblPorReproceso.Location = new Point(-1, 26);
            lblPorReproceso.Name = "lblPorReproceso";
            lblPorReproceso.Size = new Size(166, 34);
            lblPorReproceso.TabIndex = 134;
            lblPorReproceso.Text = "--%";
            lblPorReproceso.TextAlign = ContentAlignment.TopCenter;
            // 
            // label23
            // 
            label23.BackColor = Color.Transparent;
            label23.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label23.ForeColor = Color.White;
            label23.Location = new Point(-1, 5);
            label23.Name = "label23";
            label23.Size = new Size(166, 20);
            label23.TabIndex = 124;
            label23.Text = "REPROCESO %";
            label23.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(3, 42, 76);
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(lblPNCEnRevision);
            panel6.Controls.Add(label19);
            panel6.Location = new Point(17, 228);
            panel6.Name = "panel6";
            panel6.Size = new Size(166, 68);
            panel6.TabIndex = 127;
            // 
            // lblPNCEnRevision
            // 
            lblPNCEnRevision.BackColor = Color.Transparent;
            lblPNCEnRevision.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            lblPNCEnRevision.ForeColor = Color.White;
            lblPNCEnRevision.Location = new Point(-1, 28);
            lblPNCEnRevision.Name = "lblPNCEnRevision";
            lblPNCEnRevision.Size = new Size(166, 34);
            lblPNCEnRevision.TabIndex = 131;
            lblPNCEnRevision.Text = "---";
            lblPNCEnRevision.TextAlign = ContentAlignment.TopCenter;
            // 
            // label19
            // 
            label19.BackColor = Color.Transparent;
            label19.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label19.ForeColor = Color.White;
            label19.Location = new Point(-1, 6);
            label19.Name = "label19";
            label19.Size = new Size(166, 20);
            label19.TabIndex = 120;
            label19.Text = "PNC EN REVISION";
            label19.TextAlign = ContentAlignment.TopCenter;
            // 
            // pnlReproceso
            // 
            pnlReproceso.BackColor = Color.FromArgb(3, 42, 76);
            pnlReproceso.Controls.Add(lblReprocesoTotal);
            pnlReproceso.Controls.Add(label22);
            pnlReproceso.Location = new Point(17, 302);
            pnlReproceso.Name = "pnlReproceso";
            pnlReproceso.Size = new Size(166, 68);
            pnlReproceso.TabIndex = 127;
            pnlReproceso.Paint += pnlReproceso_Paint;
            // 
            // lblReprocesoTotal
            // 
            lblReprocesoTotal.BackColor = Color.Transparent;
            lblReprocesoTotal.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            lblReprocesoTotal.ForeColor = Color.White;
            lblReprocesoTotal.Location = new Point(-1, 26);
            lblReprocesoTotal.Name = "lblReprocesoTotal";
            lblReprocesoTotal.Size = new Size(166, 34);
            lblReprocesoTotal.TabIndex = 133;
            lblReprocesoTotal.Text = "---";
            lblReprocesoTotal.TextAlign = ContentAlignment.TopCenter;
            // 
            // label22
            // 
            label22.BackColor = Color.Transparent;
            label22.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label22.ForeColor = Color.White;
            label22.Location = new Point(-1, 5);
            label22.Name = "label22";
            label22.Size = new Size(166, 20);
            label22.TabIndex = 123;
            label22.Text = "REPROCESO TOTAL";
            label22.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 102, 0);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 698);
            button1.Name = "button1";
            button1.Size = new Size(499, 29);
            button1.TabIndex = 125;
            button1.Text = "GENERAR REPORTE";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(3, 42, 76);
            panel12.BorderStyle = BorderStyle.FixedSingle;
            panel12.Controls.Add(lblProduccionEnOperacion);
            panel12.Controls.Add(label8);
            panel12.Location = new Point(527, 691);
            panel12.Name = "panel12";
            panel12.Size = new Size(417, 41);
            panel12.TabIndex = 128;
            // 
            // lblProduccionEnOperacion
            // 
            lblProduccionEnOperacion.BackColor = Color.Transparent;
            lblProduccionEnOperacion.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            lblProduccionEnOperacion.ForeColor = Color.White;
            lblProduccionEnOperacion.Location = new Point(243, 3);
            lblProduccionEnOperacion.Name = "lblProduccionEnOperacion";
            lblProduccionEnOperacion.Size = new Size(166, 34);
            lblProduccionEnOperacion.TabIndex = 135;
            lblProduccionEnOperacion.Text = "-----";
            lblProduccionEnOperacion.TextAlign = ContentAlignment.TopCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(3, 9);
            label8.Name = "label8";
            label8.Size = new Size(235, 22);
            label8.TabIndex = 129;
            label8.Text = "PRODUCCIÓN EN OPERACION:";
            // 
            // dgvIngresos
            // 
            dgvIngresos.AllowUserToAddRows = false;
            dgvIngresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIngresos.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvIngresos.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvIngresos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvIngresos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvIngresos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvIngresos.GridColor = SystemColors.ActiveCaptionText;
            dgvIngresos.Location = new Point(12, 350);
            dgvIngresos.MultiSelect = false;
            dgvIngresos.Name = "dgvIngresos";
            dgvIngresos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle3.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvIngresos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvIngresos.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvIngresos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvIngresos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIngresos.Size = new Size(932, 334);
            dgvIngresos.TabIndex = 129;
            dgvIngresos.DataBindingComplete += dgvIngresos_DataBindingComplete;
            // 
            // timerParpadeoPNC
            // 
            timerParpadeoPNC.Interval = 500;
            timerParpadeoPNC.Tick += timerParpadeoPNC_Tick;
            // 
            // timerParpadeoReproceso
            // 
            timerParpadeoReproceso.Interval = 500;
            timerParpadeoReproceso.Tick += timerParpadeoReproceso_Tick;
            // 
            // Produccion_OT
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1162, 757);
            Controls.Add(dgvIngresos);
            Controls.Add(panel12);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblOrdenTrabajo);
            Controls.Add(panel4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_OT";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Produccion_OT";
            Load += Produccion_OT_Load;
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel11.ResumeLayout(false);
            panel3.ResumeLayout(false);
            pnlPNCPor.ResumeLayout(false);
            panel5.ResumeLayout(false);
            pnlPNC.ResumeLayout(false);
            pnlReprocesoPor.ResumeLayout(false);
            panel6.ResumeLayout(false);
            pnlReproceso.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIngresos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel4;
        private PictureBox pictureBox4;
        private PictureBox pictureBox6;
        private Label lblOrdenTrabajo;
        private Panel panel1;
        private Button btnVerEspecificacion;
        private TextBox txbSolicitudFabricacion;
        private Label label16;
        private Label label17;
        private TextBox txbObservaciones;
        private Label label14;
        private ComboBox cbMaquinas;
        private Label label15;
        private TextBox txbNombreArea;
        private TextBox txbArea;
        private Label label7;
        private Label label10;
        private ComboBox cbTurno;
        private TextBox txbEspecificacion;
        private DateTimePicker dtpFechaFinal;
        private DateTimePicker dtpFechaInicio;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label4;
        private Label label13;
        private Label lblAutorizo;
        private ComboBox cbMolde;
        private TextBox txbLote;
        private Label label12;
        private Label label11;
        private TextBox txbCantidad;
        private Panel panel2;
        private Label lblProduccionXTurno;
        private Button button1;
        private Panel panel3;
        private Panel panel11;
        private Panel pnlPNCPor;
        private Panel panel5;
        private Panel pnlPNC;
        private Panel pnlReprocesoPor;
        private Panel pnlReproceso;
        private Panel panel6;
        private Panel panel12;
        private Label label8;
        private Label label24;
        private Label label9;
        private Label label21;
        private Label label18;
        private Label label20;
        private Label label23;
        private Label label22;
        private Label label19;
        private Label lblDiasRestantes;
        private Label lblPorPNC;
        private Label lblPNCEnOperacion;
        private Label lblPNCTotal;
        private Label lblPorReproceso;
        private Label lblReprocesoTotal;
        private Label lblPNCEnRevision;
        private Label lblProductoConforme;
        private Label lblProduccionEnOperacion;
        private DataGridView dgvIngresos;
        private System.Windows.Forms.Timer timerParpadeoPNC;
        private System.Windows.Forms.Timer timerParpadeoReproceso;
    }
}