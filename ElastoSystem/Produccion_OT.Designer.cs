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
            txbNombreArea = new TextBox();
            txbArea = new TextBox();
            label7 = new Label();
            label10 = new Label();
            cbTurno = new ComboBox();
            txbEspecificacion = new TextBox();
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
            label32 = new Label();
            label24 = new Label();
            label6 = new Label();
            panel3 = new Panel();
            label25 = new Label();
            label9 = new Label();
            panel8 = new Panel();
            label29 = new Label();
            label21 = new Label();
            panel5 = new Panel();
            label26 = new Label();
            label18 = new Label();
            panel7 = new Panel();
            label28 = new Label();
            label20 = new Label();
            panel10 = new Panel();
            label31 = new Label();
            label23 = new Label();
            panel9 = new Panel();
            label30 = new Label();
            label22 = new Label();
            panel6 = new Panel();
            label27 = new Label();
            label19 = new Label();
            button1 = new Button();
            panel12 = new Panel();
            label33 = new Label();
            label8 = new Label();
            dgvIngresos = new DataGridView();
            Fecha = new DataGridViewTextBoxColumn();
            Operador = new DataGridViewTextBoxColumn();
            PNCOP = new DataGridViewTextBoxColumn();
            PROOP = new DataGridViewTextBoxColumn();
            PNCRE = new DataGridViewTextBoxColumn();
            PCTOTAL = new DataGridViewTextBoxColumn();
            REPROCESO = new DataGridViewTextBoxColumn();
            OBSERVACIONES = new DataGridViewTextBoxColumn();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel11.SuspendLayout();
            panel3.SuspendLayout();
            panel8.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            panel6.SuspendLayout();
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
            panel1.Controls.Add(txbNombreArea);
            panel1.Controls.Add(txbArea);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(cbTurno);
            panel1.Controls.Add(txbEspecificacion);
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
            btnVerEspecificacion.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnVerEspecificacion.ForeColor = Color.White;
            btnVerEspecificacion.Location = new Point(133, 215);
            btnVerEspecificacion.Name = "btnVerEspecificacion";
            btnVerEspecificacion.Size = new Size(273, 29);
            btnVerEspecificacion.TabIndex = 124;
            btnVerEspecificacion.Text = "VER ESPECIFICACION";
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
            label16.Location = new Point(427, 180);
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
            txbObservaciones.Location = new Point(545, 177);
            txbObservaciones.Multiline = true;
            txbObservaciones.Name = "txbObservaciones";
            txbObservaciones.ReadOnly = true;
            txbObservaciones.Size = new Size(364, 64);
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
            // txbEspecificacion
            // 
            txbEspecificacion.Font = new Font("Montserrat", 10F);
            txbEspecificacion.Location = new Point(15, 217);
            txbEspecificacion.Name = "txbEspecificacion";
            txbEspecificacion.ReadOnly = true;
            txbEspecificacion.Size = new Size(32, 24);
            txbEspecificacion.TabIndex = 107;
            txbEspecificacion.TextAlign = HorizontalAlignment.Center;
            txbEspecificacion.Visible = false;
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
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel8);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel7);
            panel2.Controls.Add(panel10);
            panel2.Controls.Add(panel9);
            panel2.Controls.Add(panel6);
            panel2.Location = new Point(950, 39);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 706);
            panel2.TabIndex = 93;
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(3, 42, 76);
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.Controls.Add(label32);
            panel11.Controls.Add(label24);
            panel11.Location = new Point(17, 598);
            panel11.Name = "panel11";
            panel11.Size = new Size(166, 94);
            panel11.TabIndex = 127;
            // 
            // label32
            // 
            label32.BackColor = Color.Transparent;
            label32.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            label32.ForeColor = Color.White;
            label32.Location = new Point(-1, 50);
            label32.Name = "label32";
            label32.Size = new Size(166, 34);
            label32.TabIndex = 134;
            label32.Text = "00000";
            label32.TextAlign = ContentAlignment.TopCenter;
            // 
            // label24
            // 
            label24.BackColor = Color.Transparent;
            label24.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label24.ForeColor = Color.White;
            label24.Location = new Point(-1, 5);
            label24.Name = "label24";
            label24.Size = new Size(166, 40);
            label24.TabIndex = 125;
            label24.Text = "PRODUCTO CONFORME:";
            label24.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(17, 37);
            label6.Name = "label6";
            label6.Size = new Size(166, 34);
            label6.TabIndex = 95;
            label6.Text = "ERROR";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(3, 42, 76);
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label25);
            panel3.Controls.Add(label9);
            panel3.Location = new Point(17, 80);
            panel3.Name = "panel3";
            panel3.Size = new Size(166, 68);
            panel3.TabIndex = 126;
            // 
            // label25
            // 
            label25.BackColor = Color.Transparent;
            label25.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            label25.ForeColor = Color.White;
            label25.Location = new Point(-1, 32);
            label25.Name = "label25";
            label25.Size = new Size(166, 34);
            label25.TabIndex = 129;
            label25.Text = "00";
            label25.TextAlign = ContentAlignment.TopCenter;
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
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(3, 42, 76);
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(label29);
            panel8.Controls.Add(label21);
            panel8.Location = new Point(17, 376);
            panel8.Name = "panel8";
            panel8.Size = new Size(166, 68);
            panel8.TabIndex = 127;
            // 
            // label29
            // 
            label29.BackColor = Color.Transparent;
            label29.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            label29.ForeColor = Color.White;
            label29.Location = new Point(-1, 27);
            label29.Name = "label29";
            label29.Size = new Size(166, 34);
            label29.TabIndex = 131;
            label29.Text = "00%";
            label29.TextAlign = ContentAlignment.TopCenter;
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
            panel5.Controls.Add(label26);
            panel5.Controls.Add(label18);
            panel5.Location = new Point(17, 154);
            panel5.Name = "panel5";
            panel5.Size = new Size(166, 68);
            panel5.TabIndex = 127;
            // 
            // label26
            // 
            label26.BackColor = Color.Transparent;
            label26.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            label26.ForeColor = Color.White;
            label26.Location = new Point(-1, 27);
            label26.Name = "label26";
            label26.Size = new Size(166, 34);
            label26.TabIndex = 130;
            label26.Text = "000";
            label26.TextAlign = ContentAlignment.TopCenter;
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
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(3, 42, 76);
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(label28);
            panel7.Controls.Add(label20);
            panel7.Location = new Point(17, 302);
            panel7.Name = "panel7";
            panel7.Size = new Size(166, 68);
            panel7.TabIndex = 127;
            // 
            // label28
            // 
            label28.BackColor = Color.Transparent;
            label28.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            label28.ForeColor = Color.White;
            label28.Location = new Point(-1, 27);
            label28.Name = "label28";
            label28.Size = new Size(166, 34);
            label28.TabIndex = 132;
            label28.Text = "000";
            label28.TextAlign = ContentAlignment.TopCenter;
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
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(3, 42, 76);
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(label31);
            panel10.Controls.Add(label23);
            panel10.Location = new Point(17, 524);
            panel10.Name = "panel10";
            panel10.Size = new Size(166, 68);
            panel10.TabIndex = 127;
            // 
            // label31
            // 
            label31.BackColor = Color.Transparent;
            label31.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            label31.ForeColor = Color.White;
            label31.Location = new Point(-1, 26);
            label31.Name = "label31";
            label31.Size = new Size(166, 34);
            label31.TabIndex = 134;
            label31.Text = "00%";
            label31.TextAlign = ContentAlignment.TopCenter;
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
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(3, 42, 76);
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(label30);
            panel9.Controls.Add(label22);
            panel9.Location = new Point(17, 450);
            panel9.Name = "panel9";
            panel9.Size = new Size(166, 68);
            panel9.TabIndex = 127;
            // 
            // label30
            // 
            label30.BackColor = Color.Transparent;
            label30.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            label30.ForeColor = Color.White;
            label30.Location = new Point(-1, 26);
            label30.Name = "label30";
            label30.Size = new Size(166, 34);
            label30.TabIndex = 133;
            label30.Text = "000";
            label30.TextAlign = ContentAlignment.TopCenter;
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
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(3, 42, 76);
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(label27);
            panel6.Controls.Add(label19);
            panel6.Location = new Point(17, 228);
            panel6.Name = "panel6";
            panel6.Size = new Size(166, 68);
            panel6.TabIndex = 127;
            // 
            // label27
            // 
            label27.BackColor = Color.Transparent;
            label27.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            label27.ForeColor = Color.White;
            label27.Location = new Point(-1, 28);
            label27.Name = "label27";
            label27.Size = new Size(166, 34);
            label27.TabIndex = 131;
            label27.Text = "000";
            label27.TextAlign = ContentAlignment.TopCenter;
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
            panel12.Controls.Add(label33);
            panel12.Controls.Add(label8);
            panel12.Location = new Point(527, 691);
            panel12.Name = "panel12";
            panel12.Size = new Size(417, 41);
            panel12.TabIndex = 128;
            // 
            // label33
            // 
            label33.BackColor = Color.Transparent;
            label33.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            label33.ForeColor = Color.White;
            label33.Location = new Point(243, 3);
            label33.Name = "label33";
            label33.Size = new Size(166, 34);
            label33.TabIndex = 135;
            label33.Text = "00000";
            label33.TextAlign = ContentAlignment.TopCenter;
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
            dgvIngresos.Columns.AddRange(new DataGridViewColumn[] { Fecha, Operador, PNCOP, PROOP, PNCRE, PCTOTAL, REPROCESO, OBSERVACIONES });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvIngresos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvIngresos.GridColor = SystemColors.ActiveCaptionText;
            dgvIngresos.Location = new Point(12, 349);
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
            // 
            // Fecha
            // 
            Fecha.HeaderText = "Fecha";
            Fecha.Name = "Fecha";
            Fecha.ReadOnly = true;
            // 
            // Operador
            // 
            Operador.HeaderText = "Operador";
            Operador.Name = "Operador";
            Operador.ReadOnly = true;
            // 
            // PNCOP
            // 
            PNCOP.HeaderText = "PNC OP";
            PNCOP.Name = "PNCOP";
            PNCOP.ReadOnly = true;
            // 
            // PROOP
            // 
            PROOP.HeaderText = "PRO OP";
            PROOP.Name = "PROOP";
            PROOP.ReadOnly = true;
            // 
            // PNCRE
            // 
            PNCRE.HeaderText = "PNC RE";
            PNCRE.Name = "PNCRE";
            PNCRE.ReadOnly = true;
            // 
            // PCTOTAL
            // 
            PCTOTAL.HeaderText = "PC TOTAL";
            PCTOTAL.Name = "PCTOTAL";
            PCTOTAL.ReadOnly = true;
            // 
            // REPROCESO
            // 
            REPROCESO.HeaderText = "REPROCESO";
            REPROCESO.Name = "REPROCESO";
            REPROCESO.ReadOnly = true;
            // 
            // OBSERVACIONES
            // 
            OBSERVACIONES.HeaderText = "OBSERVACIONES";
            OBSERVACIONES.Name = "OBSERVACIONES";
            OBSERVACIONES.ReadOnly = true;
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
            panel8.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel6.ResumeLayout(false);
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
        private Label label6;
        private Button button1;
        private Panel panel3;
        private Panel panel11;
        private Panel panel8;
        private Panel panel5;
        private Panel panel7;
        private Panel panel10;
        private Panel panel9;
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
        private Label label25;
        private Label label29;
        private Label label26;
        private Label label28;
        private Label label31;
        private Label label30;
        private Label label27;
        private Label label32;
        private Label label33;
        private DataGridView dgvIngresos;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Operador;
        private DataGridViewTextBoxColumn PNCOP;
        private DataGridViewTextBoxColumn PROOP;
        private DataGridViewTextBoxColumn PNCRE;
        private DataGridViewTextBoxColumn PCTOTAL;
        private DataGridViewTextBoxColumn REPROCESO;
        private DataGridViewTextBoxColumn OBSERVACIONES;
    }
}