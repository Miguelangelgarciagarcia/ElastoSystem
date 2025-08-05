namespace ElastoSystem
{
    partial class Mtto_ManttoPreventivo
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabCalendarioActividades = new TabPage();
            lblDate = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            lblCampos = new Label();
            btnNext = new Button();
            btnPrevious = new Button();
            dayContainer = new FlowLayoutPanel();
            tabAsignacionPorEquipos = new TabPage();
            dtpFechaInicio = new DateTimePicker();
            lblFechaInicio = new Label();
            btnHistorial = new Button();
            txbID = new TextBox();
            txbActividadE = new TextBox();
            chbInfrestructura = new CheckBox();
            chbMaquina = new CheckBox();
            txbPeriodicidad = new TextBox();
            label16 = new Label();
            txbDescripcion = new TextBox();
            label15 = new Label();
            label14 = new Label();
            cbActividad = new ComboBox();
            btnNueva = new Button();
            btnEliminarActividad = new Button();
            btnActualizar = new Button();
            btnAsignarActividad = new Button();
            btnProximos = new Button();
            dgvMantenimientos = new DataGridView();
            label13 = new Label();
            cbActivo = new ComboBox();
            tabConfiguracion = new TabPage();
            panel1 = new Panel();
            txbInfrestructuraOriginal = new TextBox();
            txbIDInfrestructura = new TextBox();
            btnNuevaInfrestructura = new Button();
            txbInfrestructura = new TextBox();
            label12 = new Label();
            btnAgregarInfrestructura = new Button();
            btnActualizarInfrestructura = new Button();
            dgvInfrestructuras = new DataGridView();
            label8 = new Label();
            panel2 = new Panel();
            txbActividadOriginal = new TextBox();
            txbIDActividad = new TextBox();
            btnNuevaActividad = new Button();
            txbActividad = new TextBox();
            label11 = new Label();
            btnAgregarActividad = new Button();
            btnActualizarActividad = new Button();
            dgvActividades = new DataGridView();
            label10 = new Label();
            cbActividadesDe = new ComboBox();
            label9 = new Label();
            btnHistorialGeneral = new Button();
            tabControl1.SuspendLayout();
            tabCalendarioActividades.SuspendLayout();
            tabAsignacionPorEquipos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMantenimientos).BeginInit();
            tabConfiguracion.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInfrestructuras).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActividades).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(21, 22);
            label1.Name = "label1";
            label1.Size = new Size(699, 44);
            label1.TabIndex = 3;
            label1.Text = "PLAN DE MANTENIMIENTO PREVENTIVO";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabCalendarioActividades);
            tabControl1.Controls.Add(tabAsignacionPorEquipos);
            tabControl1.Controls.Add(tabConfiguracion);
            tabControl1.Location = new Point(29, 78);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1281, 741);
            tabControl1.TabIndex = 13;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabCalendarioActividades
            // 
            tabCalendarioActividades.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabCalendarioActividades.Controls.Add(btnHistorialGeneral);
            tabCalendarioActividades.Controls.Add(lblDate);
            tabCalendarioActividades.Controls.Add(label7);
            tabCalendarioActividades.Controls.Add(label6);
            tabCalendarioActividades.Controls.Add(label5);
            tabCalendarioActividades.Controls.Add(label4);
            tabCalendarioActividades.Controls.Add(label3);
            tabCalendarioActividades.Controls.Add(label2);
            tabCalendarioActividades.Controls.Add(lblCampos);
            tabCalendarioActividades.Controls.Add(btnNext);
            tabCalendarioActividades.Controls.Add(btnPrevious);
            tabCalendarioActividades.Controls.Add(dayContainer);
            tabCalendarioActividades.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            tabCalendarioActividades.Location = new Point(4, 24);
            tabCalendarioActividades.Name = "tabCalendarioActividades";
            tabCalendarioActividades.Padding = new Padding(3);
            tabCalendarioActividades.Size = new Size(1273, 713);
            tabCalendarioActividades.TabIndex = 0;
            tabCalendarioActividades.Text = "Calendario de Actividades";
            tabCalendarioActividades.UseVisualStyleBackColor = true;
            tabCalendarioActividades.Click += tabCalendarioActividades_Click;
            // 
            // lblDate
            // 
            lblDate.BackColor = Color.Transparent;
            lblDate.Font = new Font("Montserrat", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.White;
            lblDate.Location = new Point(413, 14);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(411, 35);
            lblDate.TabIndex = 61;
            lblDate.Text = "MONTH YEAR";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 12F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(1120, 54);
            label7.Name = "label7";
            label7.Size = new Size(70, 22);
            label7.TabIndex = 60;
            label7.Text = "Sabado";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 12F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(945, 54);
            label6.Name = "label6";
            label6.Size = new Size(70, 22);
            label6.TabIndex = 59;
            label6.Text = "Viernes";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 12F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(781, 54);
            label5.Name = "label5";
            label5.Size = new Size(66, 22);
            label5.TabIndex = 58;
            label5.Text = "Jueves";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(598, 54);
            label4.Name = "label4";
            label4.Size = new Size(86, 22);
            label4.TabIndex = 57;
            label4.Text = "Miercoles";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(434, 54);
            label3.Name = "label3";
            label3.Size = new Size(64, 22);
            label3.TabIndex = 56;
            label3.Text = "Martes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(256, 54);
            label2.Name = "label2";
            label2.Size = new Size(59, 22);
            label2.TabIndex = 55;
            label2.Text = "Lunes";
            // 
            // lblCampos
            // 
            lblCampos.AutoSize = true;
            lblCampos.BackColor = Color.Transparent;
            lblCampos.Font = new Font("Montserrat", 12F);
            lblCampos.ForeColor = Color.White;
            lblCampos.Location = new Point(74, 54);
            lblCampos.Name = "lblCampos";
            lblCampos.Size = new Size(86, 22);
            lblCampos.TabIndex = 54;
            lblCampos.Text = "Domingo";
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(255, 102, 0);
            btnNext.Cursor = Cursors.Hand;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(656, 668);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(190, 29);
            btnNext.TabIndex = 10;
            btnNext.Text = "Siguiente";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.BackColor = Color.FromArgb(255, 102, 0);
            btnPrevious.Cursor = Cursors.Hand;
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnPrevious.ForeColor = Color.White;
            btnPrevious.Location = new Point(426, 668);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(190, 29);
            btnPrevious.TabIndex = 9;
            btnPrevious.Text = "Atras";
            btnPrevious.UseVisualStyleBackColor = false;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // dayContainer
            // 
            dayContainer.Location = new Point(28, 82);
            dayContainer.Name = "dayContainer";
            dayContainer.Size = new Size(1222, 580);
            dayContainer.TabIndex = 0;
            // 
            // tabAsignacionPorEquipos
            // 
            tabAsignacionPorEquipos.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabAsignacionPorEquipos.Controls.Add(dtpFechaInicio);
            tabAsignacionPorEquipos.Controls.Add(lblFechaInicio);
            tabAsignacionPorEquipos.Controls.Add(btnHistorial);
            tabAsignacionPorEquipos.Controls.Add(txbID);
            tabAsignacionPorEquipos.Controls.Add(txbActividadE);
            tabAsignacionPorEquipos.Controls.Add(chbInfrestructura);
            tabAsignacionPorEquipos.Controls.Add(chbMaquina);
            tabAsignacionPorEquipos.Controls.Add(txbPeriodicidad);
            tabAsignacionPorEquipos.Controls.Add(label16);
            tabAsignacionPorEquipos.Controls.Add(txbDescripcion);
            tabAsignacionPorEquipos.Controls.Add(label15);
            tabAsignacionPorEquipos.Controls.Add(label14);
            tabAsignacionPorEquipos.Controls.Add(cbActividad);
            tabAsignacionPorEquipos.Controls.Add(btnNueva);
            tabAsignacionPorEquipos.Controls.Add(btnEliminarActividad);
            tabAsignacionPorEquipos.Controls.Add(btnActualizar);
            tabAsignacionPorEquipos.Controls.Add(btnAsignarActividad);
            tabAsignacionPorEquipos.Controls.Add(btnProximos);
            tabAsignacionPorEquipos.Controls.Add(dgvMantenimientos);
            tabAsignacionPorEquipos.Controls.Add(label13);
            tabAsignacionPorEquipos.Controls.Add(cbActivo);
            tabAsignacionPorEquipos.Location = new Point(4, 24);
            tabAsignacionPorEquipos.Name = "tabAsignacionPorEquipos";
            tabAsignacionPorEquipos.Padding = new Padding(3);
            tabAsignacionPorEquipos.Size = new Size(1273, 713);
            tabAsignacionPorEquipos.TabIndex = 1;
            tabAsignacionPorEquipos.Text = "Asignación por Equipos";
            tabAsignacionPorEquipos.UseVisualStyleBackColor = true;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaInicio.Location = new Point(193, 274);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(397, 26);
            dtpFechaInicio.TabIndex = 68;
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.BackColor = Color.Transparent;
            lblFechaInicio.Font = new Font("Montserrat", 12F);
            lblFechaInicio.ForeColor = Color.White;
            lblFechaInicio.Location = new Point(28, 277);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(134, 22);
            lblFechaInicio.TabIndex = 67;
            lblFechaInicio.Text = "Fecha de Inicio:";
            // 
            // btnHistorial
            // 
            btnHistorial.BackColor = Color.FromArgb(255, 102, 0);
            btnHistorial.Cursor = Cursors.Hand;
            btnHistorial.FlatAppearance.BorderSize = 0;
            btnHistorial.FlatStyle = FlatStyle.Flat;
            btnHistorial.Font = new Font("Montserrat", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHistorial.ForeColor = Color.White;
            btnHistorial.Location = new Point(1054, 655);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(184, 33);
            btnHistorial.TabIndex = 51;
            btnHistorial.Text = "HISTORIAL";
            btnHistorial.UseVisualStyleBackColor = false;
            btnHistorial.Visible = false;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // txbID
            // 
            txbID.Font = new Font("Montserrat", 12F);
            txbID.Location = new Point(628, 132);
            txbID.Name = "txbID";
            txbID.Size = new Size(37, 27);
            txbID.TabIndex = 66;
            txbID.Visible = false;
            // 
            // txbActividadE
            // 
            txbActividadE.Enabled = false;
            txbActividadE.Font = new Font("Montserrat", 12F);
            txbActividadE.Location = new Point(193, 133);
            txbActividadE.Name = "txbActividadE";
            txbActividadE.Size = new Size(397, 27);
            txbActividadE.TabIndex = 65;
            txbActividadE.Visible = false;
            // 
            // chbInfrestructura
            // 
            chbInfrestructura.AutoSize = true;
            chbInfrestructura.Font = new Font("Montserrat", 18F, FontStyle.Bold);
            chbInfrestructura.ForeColor = Color.White;
            chbInfrestructura.Location = new Point(260, 26);
            chbInfrestructura.Name = "chbInfrestructura";
            chbInfrestructura.Size = new Size(265, 37);
            chbInfrestructura.TabIndex = 64;
            chbInfrestructura.Text = "INFRESTRUCTURA";
            chbInfrestructura.UseVisualStyleBackColor = true;
            chbInfrestructura.CheckedChanged += chbInfrestructura_CheckedChanged;
            // 
            // chbMaquina
            // 
            chbMaquina.AutoSize = true;
            chbMaquina.Font = new Font("Montserrat", 18F, FontStyle.Bold);
            chbMaquina.ForeColor = Color.White;
            chbMaquina.Location = new Point(58, 26);
            chbMaquina.Name = "chbMaquina";
            chbMaquina.Size = new Size(159, 37);
            chbMaquina.TabIndex = 63;
            chbMaquina.Text = "MAQUINA";
            chbMaquina.UseVisualStyleBackColor = true;
            chbMaquina.CheckedChanged += chbMaquina_CheckedChanged;
            // 
            // txbPeriodicidad
            // 
            txbPeriodicidad.Font = new Font("Montserrat", 12F);
            txbPeriodicidad.Location = new Point(193, 225);
            txbPeriodicidad.Name = "txbPeriodicidad";
            txbPeriodicidad.Size = new Size(397, 27);
            txbPeriodicidad.TabIndex = 62;
            txbPeriodicidad.KeyPress += txbPeriodicidad_KeyPress;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Montserrat", 12F);
            label16.ForeColor = Color.White;
            label16.Location = new Point(28, 230);
            label16.Name = "label16";
            label16.Size = new Size(159, 22);
            label16.TabIndex = 61;
            label16.Text = "Periodicidad (dias):";
            // 
            // txbDescripcion
            // 
            txbDescripcion.Font = new Font("Montserrat", 12F);
            txbDescripcion.Location = new Point(193, 178);
            txbDescripcion.Name = "txbDescripcion";
            txbDescripcion.Size = new Size(397, 27);
            txbDescripcion.TabIndex = 60;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Montserrat", 12F);
            label15.ForeColor = Color.White;
            label15.Location = new Point(28, 183);
            label15.Name = "label15";
            label15.Size = new Size(108, 22);
            label15.TabIndex = 59;
            label15.Text = "Descripcion:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Montserrat", 12F);
            label14.ForeColor = Color.White;
            label14.Location = new Point(28, 136);
            label14.Name = "label14";
            label14.Size = new Size(87, 22);
            label14.TabIndex = 58;
            label14.Text = "Actividad:";
            // 
            // cbActividad
            // 
            cbActividad.DropDownStyle = ComboBoxStyle.DropDownList;
            cbActividad.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbActividad.FormattingEnabled = true;
            cbActividad.Location = new Point(193, 132);
            cbActividad.Name = "cbActividad";
            cbActividad.Size = new Size(397, 29);
            cbActividad.TabIndex = 57;
            cbActividad.SelectedIndexChanged += cbActividad_SelectedIndexChanged;
            // 
            // btnNueva
            // 
            btnNueva.BackColor = Color.FromArgb(255, 102, 0);
            btnNueva.Cursor = Cursors.Hand;
            btnNueva.FlatAppearance.BorderSize = 0;
            btnNueva.FlatStyle = FlatStyle.Flat;
            btnNueva.Font = new Font("Montserrat", 11.25F, FontStyle.Bold);
            btnNueva.ForeColor = Color.White;
            btnNueva.Location = new Point(628, 90);
            btnNueva.Name = "btnNueva";
            btnNueva.Size = new Size(183, 33);
            btnNueva.TabIndex = 56;
            btnNueva.Text = "NUEVA";
            btnNueva.UseVisualStyleBackColor = false;
            btnNueva.Visible = false;
            btnNueva.Click += btnNueva_Click;
            // 
            // btnEliminarActividad
            // 
            btnEliminarActividad.BackColor = Color.FromArgb(255, 102, 0);
            btnEliminarActividad.Cursor = Cursors.Hand;
            btnEliminarActividad.FlatAppearance.BorderSize = 0;
            btnEliminarActividad.FlatStyle = FlatStyle.Flat;
            btnEliminarActividad.Font = new Font("Montserrat", 11.25F, FontStyle.Bold);
            btnEliminarActividad.ForeColor = Color.White;
            btnEliminarActividad.Location = new Point(122, 327);
            btnEliminarActividad.Name = "btnEliminarActividad";
            btnEliminarActividad.Size = new Size(332, 33);
            btnEliminarActividad.TabIndex = 55;
            btnEliminarActividad.Text = "ELIMINAR";
            btnEliminarActividad.UseVisualStyleBackColor = false;
            btnEliminarActividad.Visible = false;
            btnEliminarActividad.Click += btnEliminarActividad_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(255, 102, 0);
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Montserrat", 11.25F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(628, 272);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(257, 33);
            btnActualizar.TabIndex = 54;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Visible = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnAsignarActividad
            // 
            btnAsignarActividad.BackColor = Color.FromArgb(255, 102, 0);
            btnAsignarActividad.Cursor = Cursors.Hand;
            btnAsignarActividad.FlatAppearance.BorderSize = 0;
            btnAsignarActividad.FlatStyle = FlatStyle.Flat;
            btnAsignarActividad.Font = new Font("Montserrat", 11.25F, FontStyle.Bold);
            btnAsignarActividad.ForeColor = Color.White;
            btnAsignarActividad.Location = new Point(628, 225);
            btnAsignarActividad.Name = "btnAsignarActividad";
            btnAsignarActividad.Size = new Size(257, 33);
            btnAsignarActividad.TabIndex = 53;
            btnAsignarActividad.Text = "AGREGAR";
            btnAsignarActividad.UseVisualStyleBackColor = false;
            btnAsignarActividad.Click += btnAsignarActividad_Click;
            // 
            // btnProximos
            // 
            btnProximos.BackColor = Color.FromArgb(255, 102, 0);
            btnProximos.Cursor = Cursors.Hand;
            btnProximos.FlatAppearance.BorderSize = 0;
            btnProximos.FlatStyle = FlatStyle.Flat;
            btnProximos.Font = new Font("Montserrat", 11.25F, FontStyle.Bold);
            btnProximos.ForeColor = Color.White;
            btnProximos.Location = new Point(28, 655);
            btnProximos.Name = "btnProximos";
            btnProximos.Size = new Size(201, 33);
            btnProximos.TabIndex = 52;
            btnProximos.Text = "PROXIMOS";
            btnProximos.UseVisualStyleBackColor = false;
            btnProximos.Visible = false;
            btnProximos.Click += btnProximos_Click;
            // 
            // dgvMantenimientos
            // 
            dgvMantenimientos.AllowUserToAddRows = false;
            dgvMantenimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMantenimientos.BackgroundColor = Color.White;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvMantenimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvMantenimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMantenimientos.Location = new Point(28, 371);
            dgvMantenimientos.Name = "dgvMantenimientos";
            dgvMantenimientos.ReadOnly = true;
            dgvMantenimientos.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dgvMantenimientos.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dgvMantenimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMantenimientos.Size = new Size(1210, 268);
            dgvMantenimientos.TabIndex = 50;
            dgvMantenimientos.CellClick += dgvMantenimientos_CellClick;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 12F);
            label13.ForeColor = Color.White;
            label13.Location = new Point(28, 95);
            label13.Name = "label13";
            label13.Size = new Size(62, 22);
            label13.TabIndex = 44;
            label13.Text = "Activo:";
            // 
            // cbActivo
            // 
            cbActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbActivo.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbActivo.FormattingEnabled = true;
            cbActivo.Location = new Point(193, 91);
            cbActivo.MaxDropDownItems = 2;
            cbActivo.Name = "cbActivo";
            cbActivo.Size = new Size(397, 29);
            cbActivo.TabIndex = 43;
            cbActivo.SelectedIndexChanged += cbActivo_SelectedIndexChanged;
            // 
            // tabConfiguracion
            // 
            tabConfiguracion.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabConfiguracion.Controls.Add(panel1);
            tabConfiguracion.Controls.Add(panel2);
            tabConfiguracion.Location = new Point(4, 24);
            tabConfiguracion.Name = "tabConfiguracion";
            tabConfiguracion.Size = new Size(1273, 713);
            tabConfiguracion.TabIndex = 2;
            tabConfiguracion.Text = "Configuración";
            tabConfiguracion.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(txbInfrestructuraOriginal);
            panel1.Controls.Add(txbIDInfrestructura);
            panel1.Controls.Add(btnNuevaInfrestructura);
            panel1.Controls.Add(txbInfrestructura);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(btnAgregarInfrestructura);
            panel1.Controls.Add(btnActualizarInfrestructura);
            panel1.Controls.Add(dgvInfrestructuras);
            panel1.Controls.Add(label8);
            panel1.Location = new Point(654, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(580, 656);
            panel1.TabIndex = 7;
            // 
            // txbInfrestructuraOriginal
            // 
            txbInfrestructuraOriginal.Font = new Font("Montserrat", 12F);
            txbInfrestructuraOriginal.Location = new Point(79, 138);
            txbInfrestructuraOriginal.Name = "txbInfrestructuraOriginal";
            txbInfrestructuraOriginal.Size = new Size(35, 27);
            txbInfrestructuraOriginal.TabIndex = 52;
            txbInfrestructuraOriginal.Visible = false;
            // 
            // txbIDInfrestructura
            // 
            txbIDInfrestructura.Font = new Font("Montserrat", 12F);
            txbIDInfrestructura.Location = new Point(38, 138);
            txbIDInfrestructura.Name = "txbIDInfrestructura";
            txbIDInfrestructura.Size = new Size(35, 27);
            txbIDInfrestructura.TabIndex = 50;
            txbIDInfrestructura.Visible = false;
            // 
            // btnNuevaInfrestructura
            // 
            btnNuevaInfrestructura.BackColor = Color.FromArgb(255, 102, 0);
            btnNuevaInfrestructura.Cursor = Cursors.Hand;
            btnNuevaInfrestructura.FlatAppearance.BorderSize = 0;
            btnNuevaInfrestructura.FlatStyle = FlatStyle.Flat;
            btnNuevaInfrestructura.Font = new Font("Montserrat", 11.25F, FontStyle.Bold);
            btnNuevaInfrestructura.ForeColor = Color.White;
            btnNuevaInfrestructura.Location = new Point(412, 56);
            btnNuevaInfrestructura.Name = "btnNuevaInfrestructura";
            btnNuevaInfrestructura.Size = new Size(130, 30);
            btnNuevaInfrestructura.TabIndex = 49;
            btnNuevaInfrestructura.Text = "NUEVA";
            btnNuevaInfrestructura.UseVisualStyleBackColor = false;
            btnNuevaInfrestructura.Visible = false;
            btnNuevaInfrestructura.Click += btnNuevaInfrestructura_Click;
            // 
            // txbInfrestructura
            // 
            txbInfrestructura.Font = new Font("Montserrat", 12F);
            txbInfrestructura.Location = new Point(165, 92);
            txbInfrestructura.Name = "txbInfrestructura";
            txbInfrestructura.Size = new Size(377, 27);
            txbInfrestructura.TabIndex = 51;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Montserrat", 12F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(38, 95);
            label12.Name = "label12";
            label12.Size = new Size(121, 22);
            label12.TabIndex = 50;
            label12.Text = "Infrestructura:";
            // 
            // btnAgregarInfrestructura
            // 
            btnAgregarInfrestructura.BackColor = Color.FromArgb(255, 102, 0);
            btnAgregarInfrestructura.Cursor = Cursors.Hand;
            btnAgregarInfrestructura.FlatAppearance.BorderSize = 0;
            btnAgregarInfrestructura.FlatStyle = FlatStyle.Flat;
            btnAgregarInfrestructura.Font = new Font("Montserrat", 11.25F, FontStyle.Bold);
            btnAgregarInfrestructura.ForeColor = Color.White;
            btnAgregarInfrestructura.Location = new Point(402, 136);
            btnAgregarInfrestructura.Name = "btnAgregarInfrestructura";
            btnAgregarInfrestructura.Size = new Size(130, 33);
            btnAgregarInfrestructura.TabIndex = 49;
            btnAgregarInfrestructura.Text = "AGREGAR";
            btnAgregarInfrestructura.UseVisualStyleBackColor = false;
            btnAgregarInfrestructura.Click += btnAgregarInfrestructura_Click;
            // 
            // btnActualizarInfrestructura
            // 
            btnActualizarInfrestructura.BackColor = Color.FromArgb(255, 102, 0);
            btnActualizarInfrestructura.Cursor = Cursors.Hand;
            btnActualizarInfrestructura.FlatAppearance.BorderSize = 0;
            btnActualizarInfrestructura.FlatStyle = FlatStyle.Flat;
            btnActualizarInfrestructura.Font = new Font("Montserrat", 11.25F, FontStyle.Bold);
            btnActualizarInfrestructura.ForeColor = Color.White;
            btnActualizarInfrestructura.Location = new Point(174, 136);
            btnActualizarInfrestructura.Name = "btnActualizarInfrestructura";
            btnActualizarInfrestructura.Size = new Size(130, 33);
            btnActualizarInfrestructura.TabIndex = 48;
            btnActualizarInfrestructura.Text = "ACTUALIZAR";
            btnActualizarInfrestructura.UseVisualStyleBackColor = false;
            btnActualizarInfrestructura.Visible = false;
            btnActualizarInfrestructura.Click += btnActualizarInfrestructura_Click;
            // 
            // dgvInfrestructuras
            // 
            dgvInfrestructuras.AllowUserToAddRows = false;
            dgvInfrestructuras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInfrestructuras.BackgroundColor = Color.White;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvInfrestructuras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvInfrestructuras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInfrestructuras.Location = new Point(38, 204);
            dgvInfrestructuras.Name = "dgvInfrestructuras";
            dgvInfrestructuras.ReadOnly = true;
            dgvInfrestructuras.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle10.ForeColor = Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle10.SelectionForeColor = Color.White;
            dgvInfrestructuras.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dgvInfrestructuras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInfrestructuras.Size = new Size(504, 411);
            dgvInfrestructuras.TabIndex = 44;
            dgvInfrestructuras.CellClick += dgvInfrestructuras_CellClick;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(158, 19);
            label8.Name = "label8";
            label8.Size = new Size(285, 26);
            label8.TabIndex = 4;
            label8.Text = "ALTA DE INFRESTRUCTURA";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(3, 42, 76);
            panel2.Controls.Add(txbActividadOriginal);
            panel2.Controls.Add(txbIDActividad);
            panel2.Controls.Add(btnNuevaActividad);
            panel2.Controls.Add(txbActividad);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(btnAgregarActividad);
            panel2.Controls.Add(btnActualizarActividad);
            panel2.Controls.Add(dgvActividades);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(cbActividadesDe);
            panel2.Controls.Add(label9);
            panel2.Location = new Point(15, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(580, 656);
            panel2.TabIndex = 6;
            // 
            // txbActividadOriginal
            // 
            txbActividadOriginal.Font = new Font("Montserrat", 12F);
            txbActividadOriginal.Location = new Point(74, 204);
            txbActividadOriginal.Name = "txbActividadOriginal";
            txbActividadOriginal.Size = new Size(31, 27);
            txbActividadOriginal.TabIndex = 50;
            txbActividadOriginal.Visible = false;
            // 
            // txbIDActividad
            // 
            txbIDActividad.Font = new Font("Montserrat", 12F);
            txbIDActividad.Location = new Point(33, 206);
            txbIDActividad.Name = "txbIDActividad";
            txbIDActividad.Size = new Size(35, 27);
            txbIDActividad.TabIndex = 49;
            txbIDActividad.Visible = false;
            // 
            // btnNuevaActividad
            // 
            btnNuevaActividad.BackColor = Color.FromArgb(255, 102, 0);
            btnNuevaActividad.Cursor = Cursors.Hand;
            btnNuevaActividad.FlatAppearance.BorderSize = 0;
            btnNuevaActividad.FlatStyle = FlatStyle.Flat;
            btnNuevaActividad.Font = new Font("Montserrat", 11.25F, FontStyle.Bold);
            btnNuevaActividad.ForeColor = Color.White;
            btnNuevaActividad.Location = new Point(397, 124);
            btnNuevaActividad.Name = "btnNuevaActividad";
            btnNuevaActividad.Size = new Size(130, 30);
            btnNuevaActividad.TabIndex = 48;
            btnNuevaActividad.Text = "NUEVA";
            btnNuevaActividad.UseVisualStyleBackColor = false;
            btnNuevaActividad.Visible = false;
            btnNuevaActividad.Click += btnNuevaActividad_Click;
            // 
            // txbActividad
            // 
            txbActividad.Font = new Font("Montserrat", 12F);
            txbActividad.Location = new Point(126, 160);
            txbActividad.Name = "txbActividad";
            txbActividad.Size = new Size(411, 27);
            txbActividad.TabIndex = 47;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Montserrat", 12F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(33, 163);
            label11.Name = "label11";
            label11.Size = new Size(87, 22);
            label11.TabIndex = 46;
            label11.Text = "Actividad:";
            // 
            // btnAgregarActividad
            // 
            btnAgregarActividad.BackColor = Color.FromArgb(255, 102, 0);
            btnAgregarActividad.Cursor = Cursors.Hand;
            btnAgregarActividad.FlatAppearance.BorderSize = 0;
            btnAgregarActividad.FlatStyle = FlatStyle.Flat;
            btnAgregarActividad.Font = new Font("Montserrat", 11.25F, FontStyle.Bold);
            btnAgregarActividad.ForeColor = Color.White;
            btnAgregarActividad.Location = new Point(397, 204);
            btnAgregarActividad.Name = "btnAgregarActividad";
            btnAgregarActividad.Size = new Size(130, 33);
            btnAgregarActividad.TabIndex = 45;
            btnAgregarActividad.Text = "AGREGAR";
            btnAgregarActividad.UseVisualStyleBackColor = false;
            btnAgregarActividad.Click += btnAgregarActividad_Click;
            // 
            // btnActualizarActividad
            // 
            btnActualizarActividad.BackColor = Color.FromArgb(255, 102, 0);
            btnActualizarActividad.Cursor = Cursors.Hand;
            btnActualizarActividad.FlatAppearance.BorderSize = 0;
            btnActualizarActividad.FlatStyle = FlatStyle.Flat;
            btnActualizarActividad.Font = new Font("Montserrat", 11.25F, FontStyle.Bold);
            btnActualizarActividad.ForeColor = Color.White;
            btnActualizarActividad.Location = new Point(169, 204);
            btnActualizarActividad.Name = "btnActualizarActividad";
            btnActualizarActividad.Size = new Size(130, 33);
            btnActualizarActividad.TabIndex = 44;
            btnActualizarActividad.Text = "ACTUALIZAR";
            btnActualizarActividad.UseVisualStyleBackColor = false;
            btnActualizarActividad.Visible = false;
            btnActualizarActividad.Click += btnActualizarActividad_Click;
            // 
            // dgvActividades
            // 
            dgvActividades.AllowUserToAddRows = false;
            dgvActividades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActividades.BackgroundColor = Color.White;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = Color.White;
            dataGridViewCellStyle11.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle11.SelectionForeColor = Color.White;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            dgvActividades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dgvActividades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActividades.Location = new Point(33, 262);
            dgvActividades.Name = "dgvActividades";
            dgvActividades.ReadOnly = true;
            dgvActividades.RowHeadersVisible = false;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = Color.White;
            dataGridViewCellStyle12.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle12.ForeColor = Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle12.SelectionForeColor = Color.White;
            dgvActividades.RowsDefaultCellStyle = dataGridViewCellStyle12;
            dgvActividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvActividades.Size = new Size(504, 353);
            dgvActividades.TabIndex = 43;
            dgvActividades.CellClick += dgvActividades_CellClick;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 12F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(33, 77);
            label10.Name = "label10";
            label10.Size = new Size(130, 22);
            label10.TabIndex = 42;
            label10.Text = "Actividades de:";
            // 
            // cbActividadesDe
            // 
            cbActividadesDe.DropDownStyle = ComboBoxStyle.DropDownList;
            cbActividadesDe.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbActividadesDe.FormattingEnabled = true;
            cbActividadesDe.Items.AddRange(new object[] { "MAQUINAS", "INFRESTRUCTURAS" });
            cbActividadesDe.Location = new Point(169, 75);
            cbActividadesDe.Name = "cbActividadesDe";
            cbActividadesDe.Size = new Size(368, 29);
            cbActividadesDe.TabIndex = 6;
            cbActividadesDe.SelectedIndexChanged += cbActividadesDe_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Montserrat", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(162, 19);
            label9.Name = "label9";
            label9.Size = new Size(241, 26);
            label9.TabIndex = 5;
            label9.Text = "ALTA DE ACTIVIDADES";
            // 
            // btnHistorialGeneral
            // 
            btnHistorialGeneral.BackColor = Color.FromArgb(255, 102, 0);
            btnHistorialGeneral.Cursor = Cursors.Hand;
            btnHistorialGeneral.FlatAppearance.BorderSize = 0;
            btnHistorialGeneral.FlatStyle = FlatStyle.Flat;
            btnHistorialGeneral.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnHistorialGeneral.ForeColor = Color.White;
            btnHistorialGeneral.Location = new Point(1060, 14);
            btnHistorialGeneral.Name = "btnHistorialGeneral";
            btnHistorialGeneral.Size = new Size(190, 29);
            btnHistorialGeneral.TabIndex = 14;
            btnHistorialGeneral.Text = "Historial General";
            btnHistorialGeneral.UseVisualStyleBackColor = false;
            btnHistorialGeneral.Click += button1_Click;
            // 
            // Mtto_ManttoPreventivo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Mtto_ManttoPreventivo";
            Text = "Mtto_ManttoPreventivo";
            Load += Mtto_ManttoPreventivo_Load;
            tabControl1.ResumeLayout(false);
            tabCalendarioActividades.ResumeLayout(false);
            tabCalendarioActividades.PerformLayout();
            tabAsignacionPorEquipos.ResumeLayout(false);
            tabAsignacionPorEquipos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMantenimientos).EndInit();
            tabConfiguracion.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInfrestructuras).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActividades).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TabControl tabControl1;
        private TabPage tabCalendarioActividades;
        private TabPage tabAsignacionPorEquipos;
        private TabPage tabConfiguracion;
        private FlowLayoutPanel dayContainer;
        private Button btnPrevious;
        private Button btnNext;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label lblCampos;
        private Label lblDate;
        private Panel panel1;
        private Label label8;
        private Panel panel2;
        private Label label9;
        private ComboBox cbActividadesDe;
        private Label label10;
        private DataGridView dgvActividades;
        private Button btnAgregarActividad;
        private Button btnActualizarActividad;
        private Label label11;
        private TextBox txbActividad;
        private TextBox txbInfrestructura;
        private Label label12;
        private Button btnAgregarInfrestructura;
        private Button btnActualizarInfrestructura;
        private DataGridView dgvInfrestructuras;
        private Button btnNuevaInfrestructura;
        private Button btnNuevaActividad;
        private TextBox txbIDInfrestructura;
        private TextBox txbIDActividad;
        private TextBox txbInfrestructuraOriginal;
        private TextBox txbActividadOriginal;
        private Button btnProximos;
        private Button btnHistorial;
        private DataGridView dgvMantenimientos;
        private Label label13;
        private ComboBox cbActivo;
        private Button btnNueva;
        private Button btnEliminarActividad;
        private Button btnActualizar;
        private Button btnAsignarActividad;
        private TextBox txbPeriodicidad;
        private Label label16;
        private TextBox txbDescripcion;
        private Label label15;
        private Label label14;
        private ComboBox cbActividad;
        private CheckBox chbInfrestructura;
        private CheckBox chbMaquina;
        private TextBox txbActividadE;
        private TextBox txbID;
        private Label lblFechaInicio;
        private DateTimePicker dtpFechaInicio;
        private Button btnHistorialGeneral;
    }
}