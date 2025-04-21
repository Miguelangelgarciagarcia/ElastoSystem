namespace ElastoSystem
{
    partial class Produccion_AdministrarProcesos
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
            DataGridViewCellStyle dataGridViewCellStyle31 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle32 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle33 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle34 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle35 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle36 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle37 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle38 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle39 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle40 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabHojaRuta = new TabPage();
            btnActualizarProceso = new Button();
            btnAgregarProceso = new Button();
            btnEliminarProceso = new Button();
            btnGuardarHojaRuta = new Button();
            txbTiempoOperacion = new TextBox();
            label12 = new Label();
            txbTiempoPreparacion = new TextBox();
            label11 = new Label();
            txbNoOperacion = new TextBox();
            txbPreparacion = new TextBox();
            label10 = new Label();
            txbTipoMaquina = new TextBox();
            label9 = new Label();
            label8 = new Label();
            cbArea = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            chbCritico = new CheckBox();
            btnNuevo = new Button();
            cbFamilia = new ComboBox();
            txbDescripcion = new TextBox();
            label7 = new Label();
            label4 = new Label();
            btnExportarPDF = new Button();
            dgvHojaRuta = new DataGridView();
            tabFamilias = new TabPage();
            tabAdministrar = new TabPage();
            panel3 = new Panel();
            txbHule = new TextBox();
            btnEditarHules = new Button();
            txbHuleOriginal = new TextBox();
            btnNuevoHules = new Button();
            btnEliminarHules = new Button();
            btnAgregarHules = new Button();
            label17 = new Label();
            dgvHules = new DataGridView();
            label18 = new Label();
            panel2 = new Panel();
            cbNaveAreas = new ComboBox();
            txbAreas = new TextBox();
            label14 = new Label();
            btnEditarAreas = new Button();
            txbAreasOriginal = new TextBox();
            btnNuevoAreas = new Button();
            btnAgregarAreas = new Button();
            label13 = new Label();
            btnEliminarAreas = new Button();
            dgvAreas = new DataGridView();
            label2 = new Label();
            panel1 = new Panel();
            label15 = new Label();
            dgvFamilias = new DataGridView();
            btnEliminarFamilias = new Button();
            txbFamiliaOriginal = new TextBox();
            txbFamilia = new TextBox();
            btnNuevoFamilias = new Button();
            btnAgregarFamilias = new Button();
            label3 = new Label();
            btnEditarFamilias = new Button();
            label1 = new Label();
            txbInsumos = new TextBox();
            label16 = new Label();
            txbNave = new TextBox();
            tabControl1.SuspendLayout();
            tabHojaRuta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHojaRuta).BeginInit();
            tabAdministrar.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHules).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAreas).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFamilias).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabHojaRuta);
            tabControl1.Controls.Add(tabFamilias);
            tabControl1.Controls.Add(tabAdministrar);
            tabControl1.Location = new Point(12, 74);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1314, 745);
            tabControl1.TabIndex = 13;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabHojaRuta
            // 
            tabHojaRuta.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabHojaRuta.Controls.Add(txbNave);
            tabHojaRuta.Controls.Add(txbInsumos);
            tabHojaRuta.Controls.Add(label16);
            tabHojaRuta.Controls.Add(btnActualizarProceso);
            tabHojaRuta.Controls.Add(btnAgregarProceso);
            tabHojaRuta.Controls.Add(btnEliminarProceso);
            tabHojaRuta.Controls.Add(btnGuardarHojaRuta);
            tabHojaRuta.Controls.Add(txbTiempoOperacion);
            tabHojaRuta.Controls.Add(label12);
            tabHojaRuta.Controls.Add(txbTiempoPreparacion);
            tabHojaRuta.Controls.Add(label11);
            tabHojaRuta.Controls.Add(txbNoOperacion);
            tabHojaRuta.Controls.Add(txbPreparacion);
            tabHojaRuta.Controls.Add(label10);
            tabHojaRuta.Controls.Add(txbTipoMaquina);
            tabHojaRuta.Controls.Add(label9);
            tabHojaRuta.Controls.Add(label8);
            tabHojaRuta.Controls.Add(cbArea);
            tabHojaRuta.Controls.Add(label6);
            tabHojaRuta.Controls.Add(label5);
            tabHojaRuta.Controls.Add(chbCritico);
            tabHojaRuta.Controls.Add(btnNuevo);
            tabHojaRuta.Controls.Add(cbFamilia);
            tabHojaRuta.Controls.Add(txbDescripcion);
            tabHojaRuta.Controls.Add(label7);
            tabHojaRuta.Controls.Add(label4);
            tabHojaRuta.Controls.Add(btnExportarPDF);
            tabHojaRuta.Controls.Add(dgvHojaRuta);
            tabHojaRuta.Location = new Point(4, 24);
            tabHojaRuta.Name = "tabHojaRuta";
            tabHojaRuta.Padding = new Padding(3);
            tabHojaRuta.Size = new Size(1306, 717);
            tabHojaRuta.TabIndex = 1;
            tabHojaRuta.Text = "Hoja de Ruta";
            tabHojaRuta.UseVisualStyleBackColor = true;
            tabHojaRuta.Click += tabHojaRuta_Click;
            // 
            // btnActualizarProceso
            // 
            btnActualizarProceso.BackColor = Color.FromArgb(255, 102, 0);
            btnActualizarProceso.Cursor = Cursors.Hand;
            btnActualizarProceso.FlatAppearance.BorderSize = 0;
            btnActualizarProceso.FlatStyle = FlatStyle.Flat;
            btnActualizarProceso.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnActualizarProceso.ForeColor = Color.White;
            btnActualizarProceso.Location = new Point(1053, 218);
            btnActualizarProceso.Name = "btnActualizarProceso";
            btnActualizarProceso.Size = new Size(171, 35);
            btnActualizarProceso.TabIndex = 68;
            btnActualizarProceso.Text = "Actualizar Proceso";
            btnActualizarProceso.UseVisualStyleBackColor = false;
            btnActualizarProceso.Visible = false;
            // 
            // btnAgregarProceso
            // 
            btnAgregarProceso.BackColor = Color.FromArgb(255, 102, 0);
            btnAgregarProceso.Cursor = Cursors.Hand;
            btnAgregarProceso.FlatAppearance.BorderSize = 0;
            btnAgregarProceso.FlatStyle = FlatStyle.Flat;
            btnAgregarProceso.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnAgregarProceso.ForeColor = Color.White;
            btnAgregarProceso.Location = new Point(1053, 218);
            btnAgregarProceso.Name = "btnAgregarProceso";
            btnAgregarProceso.Size = new Size(171, 35);
            btnAgregarProceso.TabIndex = 67;
            btnAgregarProceso.Text = "Agregar Proceso";
            btnAgregarProceso.UseVisualStyleBackColor = false;
            btnAgregarProceso.Visible = false;
            // 
            // btnEliminarProceso
            // 
            btnEliminarProceso.BackColor = Color.FromArgb(255, 102, 0);
            btnEliminarProceso.Cursor = Cursors.Hand;
            btnEliminarProceso.FlatAppearance.BorderSize = 0;
            btnEliminarProceso.FlatStyle = FlatStyle.Flat;
            btnEliminarProceso.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnEliminarProceso.ForeColor = Color.White;
            btnEliminarProceso.Location = new Point(1053, 77);
            btnEliminarProceso.Name = "btnEliminarProceso";
            btnEliminarProceso.Size = new Size(171, 35);
            btnEliminarProceso.TabIndex = 66;
            btnEliminarProceso.Text = "Eliminar Proceso";
            btnEliminarProceso.UseVisualStyleBackColor = false;
            btnEliminarProceso.Visible = false;
            // 
            // btnGuardarHojaRuta
            // 
            btnGuardarHojaRuta.BackColor = Color.FromArgb(255, 102, 0);
            btnGuardarHojaRuta.Cursor = Cursors.Hand;
            btnGuardarHojaRuta.FlatAppearance.BorderSize = 0;
            btnGuardarHojaRuta.FlatStyle = FlatStyle.Flat;
            btnGuardarHojaRuta.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnGuardarHojaRuta.ForeColor = Color.White;
            btnGuardarHojaRuta.Location = new Point(1083, 670);
            btnGuardarHojaRuta.Name = "btnGuardarHojaRuta";
            btnGuardarHojaRuta.Size = new Size(202, 35);
            btnGuardarHojaRuta.TabIndex = 65;
            btnGuardarHojaRuta.Text = "Guardar Hoja de Ruta";
            btnGuardarHojaRuta.UseVisualStyleBackColor = false;
            btnGuardarHojaRuta.Visible = false;
            // 
            // txbTiempoOperacion
            // 
            txbTiempoOperacion.Font = new Font("Montserrat", 11F);
            txbTiempoOperacion.Location = new Point(633, 197);
            txbTiempoOperacion.Name = "txbTiempoOperacion";
            txbTiempoOperacion.Size = new Size(189, 25);
            txbTiempoOperacion.TabIndex = 64;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Montserrat", 11F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(476, 200);
            label12.Name = "label12";
            label12.Size = new Size(151, 21);
            label12.TabIndex = 63;
            label12.Text = "Tiempo Operacion:";
            // 
            // txbTiempoPreparacion
            // 
            txbTiempoPreparacion.Font = new Font("Montserrat", 11F);
            txbTiempoPreparacion.Location = new Point(265, 196);
            txbTiempoPreparacion.Name = "txbTiempoPreparacion";
            txbTiempoPreparacion.Size = new Size(189, 25);
            txbTiempoPreparacion.TabIndex = 62;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Montserrat", 11F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(95, 199);
            label11.Name = "label11";
            label11.Size = new Size(164, 21);
            label11.TabIndex = 61;
            label11.Text = "Tiempo Preparacion:";
            // 
            // txbNoOperacion
            // 
            txbNoOperacion.Font = new Font("Montserrat", 11F);
            txbNoOperacion.Location = new Point(212, 65);
            txbNoOperacion.Name = "txbNoOperacion";
            txbNoOperacion.Size = new Size(144, 25);
            txbNoOperacion.TabIndex = 60;
            // 
            // txbPreparacion
            // 
            txbPreparacion.Font = new Font("Montserrat", 11F);
            txbPreparacion.Location = new Point(212, 165);
            txbPreparacion.Name = "txbPreparacion";
            txbPreparacion.Size = new Size(662, 25);
            txbPreparacion.TabIndex = 59;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 11F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(68, 168);
            label10.Name = "label10";
            label10.Size = new Size(103, 21);
            label10.TabIndex = 58;
            label10.Text = "Preparacion:";
            // 
            // txbTipoMaquina
            // 
            txbTipoMaquina.Font = new Font("Montserrat", 11F);
            txbTipoMaquina.Location = new Point(212, 134);
            txbTipoMaquina.Name = "txbTipoMaquina";
            txbTipoMaquina.Size = new Size(662, 25);
            txbTipoMaquina.TabIndex = 57;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Montserrat", 11F);
            label9.ForeColor = Color.White;
            label9.Location = new Point(68, 137);
            label9.Name = "label9";
            label9.Size = new Size(138, 21);
            label9.TabIndex = 56;
            label9.Text = "Tipo de Maquina:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 11F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(706, 68);
            label8.Name = "label8";
            label8.Size = new Size(51, 21);
            label8.TabIndex = 54;
            label8.Text = "Nave:";
            // 
            // cbArea
            // 
            cbArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cbArea.Font = new Font("Montserrat", 11F);
            cbArea.FormattingEnabled = true;
            cbArea.Items.AddRange(new object[] { "NAVE 1", "NAVE 2" });
            cbArea.Location = new Point(433, 62);
            cbArea.Name = "cbArea";
            cbArea.Size = new Size(245, 29);
            cbArea.TabIndex = 53;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 11F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(379, 65);
            label6.Name = "label6";
            label6.Size = new Size(48, 21);
            label6.TabIndex = 52;
            label6.Text = "Area:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 11F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(68, 65);
            label5.Name = "label5";
            label5.Size = new Size(118, 21);
            label5.TabIndex = 50;
            label5.Text = "No. Operacion:";
            // 
            // chbCritico
            // 
            chbCritico.AutoSize = true;
            chbCritico.Font = new Font("Montserrat", 11F);
            chbCritico.ForeColor = Color.White;
            chbCritico.Location = new Point(778, 228);
            chbCritico.Name = "chbCritico";
            chbCritico.Size = new Size(77, 25);
            chbCritico.TabIndex = 49;
            chbCritico.Text = "Critico";
            chbCritico.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(255, 102, 0);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(1083, 13);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(141, 35);
            btnNuevo.TabIndex = 48;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Visible = false;
            // 
            // cbFamilia
            // 
            cbFamilia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFamilia.Font = new Font("Montserrat", 11F);
            cbFamilia.FormattingEnabled = true;
            cbFamilia.Items.AddRange(new object[] { "NAVE 1", "NAVE 2" });
            cbFamilia.Location = new Point(192, 17);
            cbFamilia.Name = "cbFamilia";
            cbFamilia.Size = new Size(206, 29);
            cbFamilia.TabIndex = 47;
            // 
            // txbDescripcion
            // 
            txbDescripcion.Font = new Font("Montserrat", 11F);
            txbDescripcion.Location = new Point(212, 103);
            txbDescripcion.Name = "txbDescripcion";
            txbDescripcion.Size = new Size(662, 25);
            txbDescripcion.TabIndex = 46;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 11F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(68, 106);
            label7.Name = "label7";
            label7.Size = new Size(100, 21);
            label7.TabIndex = 45;
            label7.Text = "Descripcion:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 11F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(68, 20);
            label4.Name = "label4";
            label4.Size = new Size(68, 21);
            label4.TabIndex = 44;
            label4.Text = "Familia:";
            // 
            // btnExportarPDF
            // 
            btnExportarPDF.BackColor = Color.FromArgb(255, 102, 0);
            btnExportarPDF.Cursor = Cursors.Hand;
            btnExportarPDF.FlatAppearance.BorderSize = 0;
            btnExportarPDF.FlatStyle = FlatStyle.Flat;
            btnExportarPDF.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnExportarPDF.ForeColor = Color.White;
            btnExportarPDF.Location = new Point(20, 670);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(202, 35);
            btnExportarPDF.TabIndex = 43;
            btnExportarPDF.Text = "Exportar PDF";
            btnExportarPDF.UseVisualStyleBackColor = false;
            btnExportarPDF.Visible = false;
            // 
            // dgvHojaRuta
            // 
            dgvHojaRuta.AllowUserToAddRows = false;
            dgvHojaRuta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHojaRuta.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvHojaRuta.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle31.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.BackColor = Color.White;
            dataGridViewCellStyle31.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold);
            dataGridViewCellStyle31.ForeColor = Color.Black;
            dataGridViewCellStyle31.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle31.SelectionForeColor = Color.White;
            dataGridViewCellStyle31.WrapMode = DataGridViewTriState.True;
            dgvHojaRuta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            dgvHojaRuta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle32.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle32.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle32.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle32.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = DataGridViewTriState.False;
            dgvHojaRuta.DefaultCellStyle = dataGridViewCellStyle32;
            dgvHojaRuta.GridColor = SystemColors.ActiveCaptionText;
            dgvHojaRuta.Location = new Point(20, 273);
            dgvHojaRuta.Name = "dgvHojaRuta";
            dgvHojaRuta.ReadOnly = true;
            dataGridViewCellStyle33.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle33.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle33.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle33.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle33.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle33.SelectionForeColor = Color.White;
            dataGridViewCellStyle33.WrapMode = DataGridViewTriState.True;
            dgvHojaRuta.RowHeadersDefaultCellStyle = dataGridViewCellStyle33;
            dgvHojaRuta.RowHeadersVisible = false;
            dataGridViewCellStyle34.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.BackColor = Color.White;
            dataGridViewCellStyle34.Font = new Font("Montserrat", 11.25F);
            dataGridViewCellStyle34.ForeColor = Color.Black;
            dataGridViewCellStyle34.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle34.SelectionForeColor = Color.White;
            dgvHojaRuta.RowsDefaultCellStyle = dataGridViewCellStyle34;
            dgvHojaRuta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHojaRuta.Size = new Size(1265, 386);
            dgvHojaRuta.TabIndex = 42;
            // 
            // tabFamilias
            // 
            tabFamilias.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabFamilias.Location = new Point(4, 24);
            tabFamilias.Name = "tabFamilias";
            tabFamilias.Size = new Size(1306, 717);
            tabFamilias.TabIndex = 2;
            tabFamilias.Text = "Administrar Familias";
            tabFamilias.UseVisualStyleBackColor = true;
            // 
            // tabAdministrar
            // 
            tabAdministrar.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabAdministrar.Controls.Add(panel3);
            tabAdministrar.Controls.Add(panel2);
            tabAdministrar.Controls.Add(panel1);
            tabAdministrar.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            tabAdministrar.Location = new Point(4, 24);
            tabAdministrar.Name = "tabAdministrar";
            tabAdministrar.Padding = new Padding(3);
            tabAdministrar.Size = new Size(1306, 717);
            tabAdministrar.TabIndex = 0;
            tabAdministrar.Text = "Administrar";
            tabAdministrar.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(3, 42, 76);
            panel3.Controls.Add(txbHule);
            panel3.Controls.Add(btnEditarHules);
            panel3.Controls.Add(txbHuleOriginal);
            panel3.Controls.Add(btnNuevoHules);
            panel3.Controls.Add(btnEliminarHules);
            panel3.Controls.Add(btnAgregarHules);
            panel3.Controls.Add(label17);
            panel3.Controls.Add(dgvHules);
            panel3.Controls.Add(label18);
            panel3.Location = new Point(886, 20);
            panel3.Name = "panel3";
            panel3.Size = new Size(400, 676);
            panel3.TabIndex = 6;
            // 
            // txbHule
            // 
            txbHule.Font = new Font("Montserrat", 12F);
            txbHule.Location = new Point(127, 109);
            txbHule.Name = "txbHule";
            txbHule.Size = new Size(205, 27);
            txbHule.TabIndex = 48;
            txbHule.KeyDown += txbHule_KeyDown;
            txbHule.KeyPress += txbHule_KeyPress;
            // 
            // btnEditarHules
            // 
            btnEditarHules.BackColor = Color.FromArgb(255, 102, 0);
            btnEditarHules.Cursor = Cursors.Hand;
            btnEditarHules.FlatAppearance.BorderSize = 0;
            btnEditarHules.FlatStyle = FlatStyle.Flat;
            btnEditarHules.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnEditarHules.ForeColor = Color.White;
            btnEditarHules.Location = new Point(285, 201);
            btnEditarHules.Name = "btnEditarHules";
            btnEditarHules.Size = new Size(98, 27);
            btnEditarHules.TabIndex = 45;
            btnEditarHules.Text = "EDITAR";
            btnEditarHules.UseVisualStyleBackColor = false;
            btnEditarHules.Visible = false;
            btnEditarHules.Click += btnEditarHules_Click;
            // 
            // txbHuleOriginal
            // 
            txbHuleOriginal.Font = new Font("Montserrat", 12F);
            txbHuleOriginal.Location = new Point(338, 109);
            txbHuleOriginal.Name = "txbHuleOriginal";
            txbHuleOriginal.Size = new Size(27, 27);
            txbHuleOriginal.TabIndex = 45;
            txbHuleOriginal.Visible = false;
            // 
            // btnNuevoHules
            // 
            btnNuevoHules.BackColor = Color.FromArgb(255, 102, 0);
            btnNuevoHules.Cursor = Cursors.Hand;
            btnNuevoHules.FlatAppearance.BorderSize = 0;
            btnNuevoHules.FlatStyle = FlatStyle.Flat;
            btnNuevoHules.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnNuevoHules.ForeColor = Color.White;
            btnNuevoHules.Location = new Point(285, 26);
            btnNuevoHules.Name = "btnNuevoHules";
            btnNuevoHules.Size = new Size(98, 27);
            btnNuevoHules.TabIndex = 47;
            btnNuevoHules.Text = "NUEVO";
            btnNuevoHules.UseVisualStyleBackColor = false;
            btnNuevoHules.Visible = false;
            btnNuevoHules.Click += btnNuevoHules_Click;
            // 
            // btnEliminarHules
            // 
            btnEliminarHules.BackColor = Color.FromArgb(255, 102, 0);
            btnEliminarHules.Cursor = Cursors.Hand;
            btnEliminarHules.FlatAppearance.BorderSize = 0;
            btnEliminarHules.FlatStyle = FlatStyle.Flat;
            btnEliminarHules.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnEliminarHules.ForeColor = Color.White;
            btnEliminarHules.Location = new Point(22, 201);
            btnEliminarHules.Name = "btnEliminarHules";
            btnEliminarHules.Size = new Size(98, 27);
            btnEliminarHules.TabIndex = 46;
            btnEliminarHules.Text = "ELIMINAR";
            btnEliminarHules.UseVisualStyleBackColor = false;
            btnEliminarHules.Visible = false;
            btnEliminarHules.Click += btnEliminarHules_Click;
            // 
            // btnAgregarHules
            // 
            btnAgregarHules.BackColor = Color.FromArgb(255, 102, 0);
            btnAgregarHules.Cursor = Cursors.Hand;
            btnAgregarHules.FlatAppearance.BorderSize = 0;
            btnAgregarHules.FlatStyle = FlatStyle.Flat;
            btnAgregarHules.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnAgregarHules.ForeColor = Color.White;
            btnAgregarHules.Location = new Point(285, 201);
            btnAgregarHules.Name = "btnAgregarHules";
            btnAgregarHules.Size = new Size(98, 27);
            btnAgregarHules.TabIndex = 44;
            btnAgregarHules.Text = "AGREGAR";
            btnAgregarHules.UseVisualStyleBackColor = false;
            btnAgregarHules.Click += btnAgregarHules_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Transparent;
            label17.Font = new Font("Montserrat", 11F);
            label17.ForeColor = Color.White;
            label17.Location = new Point(57, 113);
            label17.Name = "label17";
            label17.Size = new Size(48, 21);
            label17.TabIndex = 49;
            label17.Text = "Hule:";
            // 
            // dgvHules
            // 
            dgvHules.AllowUserToAddRows = false;
            dgvHules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHules.BackgroundColor = Color.White;
            dataGridViewCellStyle35.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle35.BackColor = Color.White;
            dataGridViewCellStyle35.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle35.ForeColor = Color.Black;
            dataGridViewCellStyle35.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle35.SelectionForeColor = Color.White;
            dataGridViewCellStyle35.WrapMode = DataGridViewTriState.True;
            dgvHules.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle35;
            dgvHules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHules.Location = new Point(22, 244);
            dgvHules.Name = "dgvHules";
            dgvHules.ReadOnly = true;
            dgvHules.RowHeadersVisible = false;
            dataGridViewCellStyle36.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle36.BackColor = Color.White;
            dataGridViewCellStyle36.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle36.ForeColor = Color.Black;
            dataGridViewCellStyle36.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle36.SelectionForeColor = Color.White;
            dgvHules.RowsDefaultCellStyle = dataGridViewCellStyle36;
            dgvHules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHules.Size = new Size(361, 413);
            dgvHules.TabIndex = 21;
            dgvHules.CellClick += dgvHules_CellClick;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.Transparent;
            label18.Font = new Font("Montserrat", 15F, FontStyle.Bold);
            label18.ForeColor = Color.White;
            label18.Location = new Point(33, 25);
            label18.Name = "label18";
            label18.Size = new Size(72, 27);
            label18.TabIndex = 22;
            label18.Text = "Hules";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(3, 42, 76);
            panel2.Controls.Add(cbNaveAreas);
            panel2.Controls.Add(txbAreas);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(btnEditarAreas);
            panel2.Controls.Add(txbAreasOriginal);
            panel2.Controls.Add(btnNuevoAreas);
            panel2.Controls.Add(btnAgregarAreas);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(btnEliminarAreas);
            panel2.Controls.Add(dgvAreas);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(445, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(400, 676);
            panel2.TabIndex = 5;
            // 
            // cbNaveAreas
            // 
            cbNaveAreas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNaveAreas.Font = new Font("Montserrat", 11F);
            cbNaveAreas.FormattingEnabled = true;
            cbNaveAreas.Items.AddRange(new object[] { "NAVE 1", "NAVE 2" });
            cbNaveAreas.Location = new Point(122, 130);
            cbNaveAreas.Name = "cbNaveAreas";
            cbNaveAreas.Size = new Size(205, 29);
            cbNaveAreas.TabIndex = 56;
            // 
            // txbAreas
            // 
            txbAreas.Font = new Font("Montserrat", 12F);
            txbAreas.Location = new Point(122, 95);
            txbAreas.Name = "txbAreas";
            txbAreas.Size = new Size(205, 27);
            txbAreas.TabIndex = 48;
            txbAreas.KeyDown += txbAreas_KeyDown;
            txbAreas.KeyPress += txbAreas_KeyPress;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Montserrat", 11F);
            label14.ForeColor = Color.White;
            label14.Location = new Point(52, 133);
            label14.Name = "label14";
            label14.Size = new Size(51, 21);
            label14.TabIndex = 50;
            label14.Text = "Nave:";
            // 
            // btnEditarAreas
            // 
            btnEditarAreas.BackColor = Color.FromArgb(255, 102, 0);
            btnEditarAreas.Cursor = Cursors.Hand;
            btnEditarAreas.FlatAppearance.BorderSize = 0;
            btnEditarAreas.FlatStyle = FlatStyle.Flat;
            btnEditarAreas.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnEditarAreas.ForeColor = Color.White;
            btnEditarAreas.Location = new Point(284, 201);
            btnEditarAreas.Name = "btnEditarAreas";
            btnEditarAreas.Size = new Size(98, 27);
            btnEditarAreas.TabIndex = 45;
            btnEditarAreas.Text = "EDITAR";
            btnEditarAreas.UseVisualStyleBackColor = false;
            btnEditarAreas.Visible = false;
            btnEditarAreas.Click += btnEditarAreas_Click;
            // 
            // txbAreasOriginal
            // 
            txbAreasOriginal.Font = new Font("Montserrat", 12F);
            txbAreasOriginal.Location = new Point(333, 95);
            txbAreasOriginal.Name = "txbAreasOriginal";
            txbAreasOriginal.Size = new Size(29, 27);
            txbAreasOriginal.TabIndex = 45;
            txbAreasOriginal.Visible = false;
            // 
            // btnNuevoAreas
            // 
            btnNuevoAreas.BackColor = Color.FromArgb(255, 102, 0);
            btnNuevoAreas.Cursor = Cursors.Hand;
            btnNuevoAreas.FlatAppearance.BorderSize = 0;
            btnNuevoAreas.FlatStyle = FlatStyle.Flat;
            btnNuevoAreas.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnNuevoAreas.ForeColor = Color.White;
            btnNuevoAreas.Location = new Point(284, 25);
            btnNuevoAreas.Name = "btnNuevoAreas";
            btnNuevoAreas.Size = new Size(98, 27);
            btnNuevoAreas.TabIndex = 47;
            btnNuevoAreas.Text = "NUEVO";
            btnNuevoAreas.UseVisualStyleBackColor = false;
            btnNuevoAreas.Visible = false;
            btnNuevoAreas.Click += btnNuevoAreas_Click;
            // 
            // btnAgregarAreas
            // 
            btnAgregarAreas.BackColor = Color.FromArgb(255, 102, 0);
            btnAgregarAreas.Cursor = Cursors.Hand;
            btnAgregarAreas.FlatAppearance.BorderSize = 0;
            btnAgregarAreas.FlatStyle = FlatStyle.Flat;
            btnAgregarAreas.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnAgregarAreas.ForeColor = Color.White;
            btnAgregarAreas.Location = new Point(284, 201);
            btnAgregarAreas.Name = "btnAgregarAreas";
            btnAgregarAreas.Size = new Size(98, 27);
            btnAgregarAreas.TabIndex = 44;
            btnAgregarAreas.Text = "AGREGAR";
            btnAgregarAreas.UseVisualStyleBackColor = false;
            btnAgregarAreas.Click += btnAgregarAreas_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 11F);
            label13.ForeColor = Color.White;
            label13.Location = new Point(52, 99);
            label13.Name = "label13";
            label13.Size = new Size(48, 21);
            label13.TabIndex = 49;
            label13.Text = "Area:";
            // 
            // btnEliminarAreas
            // 
            btnEliminarAreas.BackColor = Color.FromArgb(255, 102, 0);
            btnEliminarAreas.Cursor = Cursors.Hand;
            btnEliminarAreas.FlatAppearance.BorderSize = 0;
            btnEliminarAreas.FlatStyle = FlatStyle.Flat;
            btnEliminarAreas.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnEliminarAreas.ForeColor = Color.White;
            btnEliminarAreas.Location = new Point(23, 201);
            btnEliminarAreas.Name = "btnEliminarAreas";
            btnEliminarAreas.Size = new Size(98, 27);
            btnEliminarAreas.TabIndex = 46;
            btnEliminarAreas.Text = "ELIMINAR";
            btnEliminarAreas.UseVisualStyleBackColor = false;
            btnEliminarAreas.Visible = false;
            btnEliminarAreas.Click += btnEliminarAreas_Click;
            // 
            // dgvAreas
            // 
            dgvAreas.AllowUserToAddRows = false;
            dgvAreas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAreas.BackgroundColor = Color.White;
            dataGridViewCellStyle37.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle37.BackColor = Color.White;
            dataGridViewCellStyle37.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle37.ForeColor = Color.Black;
            dataGridViewCellStyle37.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle37.SelectionForeColor = Color.White;
            dataGridViewCellStyle37.WrapMode = DataGridViewTriState.True;
            dgvAreas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle37;
            dgvAreas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAreas.Location = new Point(21, 244);
            dgvAreas.Name = "dgvAreas";
            dgvAreas.ReadOnly = true;
            dgvAreas.RowHeadersVisible = false;
            dataGridViewCellStyle38.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle38.BackColor = Color.White;
            dataGridViewCellStyle38.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle38.ForeColor = Color.Black;
            dataGridViewCellStyle38.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle38.SelectionForeColor = Color.White;
            dgvAreas.RowsDefaultCellStyle = dataGridViewCellStyle38;
            dgvAreas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAreas.Size = new Size(361, 413);
            dgvAreas.TabIndex = 21;
            dgvAreas.CellClick += dgvAreas_CellClick;
            dgvAreas.CellContentClick += dgvAreas_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 15F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(22, 24);
            label2.Name = "label2";
            label2.Size = new Size(72, 27);
            label2.TabIndex = 22;
            label2.Text = "Areas";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(dgvFamilias);
            panel1.Controls.Add(btnEliminarFamilias);
            panel1.Controls.Add(txbFamiliaOriginal);
            panel1.Controls.Add(txbFamilia);
            panel1.Controls.Add(btnNuevoFamilias);
            panel1.Controls.Add(btnAgregarFamilias);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnEditarFamilias);
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 676);
            panel1.TabIndex = 4;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Montserrat", 11F);
            label15.ForeColor = Color.White;
            label15.Location = new Point(46, 113);
            label15.Name = "label15";
            label15.Size = new Size(68, 21);
            label15.TabIndex = 50;
            label15.Text = "Familia:";
            // 
            // dgvFamilias
            // 
            dgvFamilias.AllowUserToAddRows = false;
            dgvFamilias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFamilias.BackgroundColor = Color.White;
            dataGridViewCellStyle39.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle39.BackColor = Color.White;
            dataGridViewCellStyle39.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle39.ForeColor = Color.Black;
            dataGridViewCellStyle39.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle39.SelectionForeColor = Color.White;
            dataGridViewCellStyle39.WrapMode = DataGridViewTriState.True;
            dgvFamilias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle39;
            dgvFamilias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFamilias.Location = new Point(21, 244);
            dgvFamilias.Name = "dgvFamilias";
            dgvFamilias.ReadOnly = true;
            dgvFamilias.RowHeadersVisible = false;
            dataGridViewCellStyle40.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle40.BackColor = Color.White;
            dataGridViewCellStyle40.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle40.ForeColor = Color.Black;
            dataGridViewCellStyle40.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle40.SelectionForeColor = Color.White;
            dgvFamilias.RowsDefaultCellStyle = dataGridViewCellStyle40;
            dgvFamilias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFamilias.Size = new Size(361, 413);
            dgvFamilias.TabIndex = 20;
            dgvFamilias.CellClick += dgvFamilias_CellClick;
            dgvFamilias.CellContentClick += dgvFamilias_CellContentClick;
            dgvFamilias.Click += dgvFamilias_Click;
            // 
            // btnEliminarFamilias
            // 
            btnEliminarFamilias.BackColor = Color.FromArgb(255, 102, 0);
            btnEliminarFamilias.Cursor = Cursors.Hand;
            btnEliminarFamilias.FlatAppearance.BorderSize = 0;
            btnEliminarFamilias.FlatStyle = FlatStyle.Flat;
            btnEliminarFamilias.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnEliminarFamilias.ForeColor = Color.White;
            btnEliminarFamilias.Location = new Point(23, 201);
            btnEliminarFamilias.Name = "btnEliminarFamilias";
            btnEliminarFamilias.Size = new Size(98, 27);
            btnEliminarFamilias.TabIndex = 41;
            btnEliminarFamilias.Text = "ELIMINAR";
            btnEliminarFamilias.UseVisualStyleBackColor = false;
            btnEliminarFamilias.Visible = false;
            btnEliminarFamilias.Click += btnEliminarFamilias_Click;
            // 
            // txbFamiliaOriginal
            // 
            txbFamiliaOriginal.Font = new Font("Montserrat", 12F);
            txbFamiliaOriginal.Location = new Point(344, 109);
            txbFamiliaOriginal.Name = "txbFamiliaOriginal";
            txbFamiliaOriginal.Size = new Size(30, 27);
            txbFamiliaOriginal.TabIndex = 44;
            txbFamiliaOriginal.Visible = false;
            // 
            // txbFamilia
            // 
            txbFamilia.Font = new Font("Montserrat", 12F);
            txbFamilia.Location = new Point(132, 109);
            txbFamilia.Name = "txbFamilia";
            txbFamilia.Size = new Size(205, 27);
            txbFamilia.TabIndex = 43;
            txbFamilia.KeyDown += txbFamilia_KeyDown;
            txbFamilia.KeyPress += txbFamilia_KeyPress;
            // 
            // btnNuevoFamilias
            // 
            btnNuevoFamilias.BackColor = Color.FromArgb(255, 102, 0);
            btnNuevoFamilias.Cursor = Cursors.Hand;
            btnNuevoFamilias.FlatAppearance.BorderSize = 0;
            btnNuevoFamilias.FlatStyle = FlatStyle.Flat;
            btnNuevoFamilias.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnNuevoFamilias.ForeColor = Color.White;
            btnNuevoFamilias.Location = new Point(284, 25);
            btnNuevoFamilias.Name = "btnNuevoFamilias";
            btnNuevoFamilias.Size = new Size(98, 27);
            btnNuevoFamilias.TabIndex = 42;
            btnNuevoFamilias.Text = "NUEVO";
            btnNuevoFamilias.UseVisualStyleBackColor = false;
            btnNuevoFamilias.Visible = false;
            btnNuevoFamilias.Click += btnNuevoFamilias_Click;
            // 
            // btnAgregarFamilias
            // 
            btnAgregarFamilias.BackColor = Color.FromArgb(255, 102, 0);
            btnAgregarFamilias.Cursor = Cursors.Hand;
            btnAgregarFamilias.FlatAppearance.BorderSize = 0;
            btnAgregarFamilias.FlatStyle = FlatStyle.Flat;
            btnAgregarFamilias.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnAgregarFamilias.ForeColor = Color.White;
            btnAgregarFamilias.Location = new Point(284, 201);
            btnAgregarFamilias.Name = "btnAgregarFamilias";
            btnAgregarFamilias.Size = new Size(98, 27);
            btnAgregarFamilias.TabIndex = 39;
            btnAgregarFamilias.Text = "AGREGAR";
            btnAgregarFamilias.UseVisualStyleBackColor = false;
            btnAgregarFamilias.Click += btnAgregarFamilias_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 15F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(22, 25);
            label3.Name = "label3";
            label3.Size = new Size(99, 27);
            label3.TabIndex = 21;
            label3.Text = "Familias";
            // 
            // btnEditarFamilias
            // 
            btnEditarFamilias.BackColor = Color.FromArgb(255, 102, 0);
            btnEditarFamilias.Cursor = Cursors.Hand;
            btnEditarFamilias.FlatAppearance.BorderSize = 0;
            btnEditarFamilias.FlatStyle = FlatStyle.Flat;
            btnEditarFamilias.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnEditarFamilias.ForeColor = Color.White;
            btnEditarFamilias.Location = new Point(284, 201);
            btnEditarFamilias.Name = "btnEditarFamilias";
            btnEditarFamilias.Size = new Size(98, 27);
            btnEditarFamilias.TabIndex = 40;
            btnEditarFamilias.Text = "EDITAR";
            btnEditarFamilias.UseVisualStyleBackColor = false;
            btnEditarFamilias.Visible = false;
            btnEditarFamilias.Click += btnEditarFamilias_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 22F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(16, 21);
            label1.Name = "label1";
            label1.Size = new Size(426, 41);
            label1.TabIndex = 14;
            label1.Text = "ADMINISTRAR PROCESOS";
            // 
            // txbInsumos
            // 
            txbInsumos.Font = new Font("Montserrat", 11F);
            txbInsumos.Location = new Point(212, 227);
            txbInsumos.Name = "txbInsumos";
            txbInsumos.Size = new Size(533, 25);
            txbInsumos.TabIndex = 70;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Montserrat", 11F);
            label16.ForeColor = Color.White;
            label16.Location = new Point(68, 230);
            label16.Name = "label16";
            label16.Size = new Size(77, 21);
            label16.TabIndex = 69;
            label16.Text = "Insumos:";
            // 
            // txbNave
            // 
            txbNave.Font = new Font("Montserrat", 11F);
            txbNave.Location = new Point(763, 65);
            txbNave.Name = "txbNave";
            txbNave.ReadOnly = true;
            txbNave.Size = new Size(111, 25);
            txbNave.TabIndex = 71;
            // 
            // Produccion_AdministrarProcesos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(label1);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_AdministrarProcesos";
            Text = "Produccion_AdministrarProcesos";
            Load += Produccion_AdministrarProcesos_Load;
            tabControl1.ResumeLayout(false);
            tabHojaRuta.ResumeLayout(false);
            tabHojaRuta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHojaRuta).EndInit();
            tabAdministrar.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHules).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAreas).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFamilias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabAdministrar;
        private TabPage tabHojaRuta;
        private Label label1;
        private Panel panel2;
        private Panel panel1;
        private Label label2;
        private Label label3;
        private Button btnNuevoFamilias;
        private Button btnEliminarFamilias;
        private Button btnEditarFamilias;
        private Button btnAgregarFamilias;
        private TextBox txbAreas;
        private Button btnNuevoAreas;
        private Button btnEliminarAreas;
        private Button btnEditarAreas;
        private Button btnAgregarAreas;
        private TextBox txbFamilia;
        private DataGridView dgvFamilias;
        private DataGridView dgvAreas;
        private TextBox txbAreasOriginal;
        private TextBox txbFamiliaOriginal;
        private DataGridView dgvHojaRuta;
        private Button btnExportarPDF;
        private CheckBox chbCritico;
        private Button btnNuevo;
        private ComboBox cbFamilia;
        private TextBox txbDescripcion;
        private Label label7;
        private Label label4;
        private ComboBox cbNave;
        private Label label8;
        private ComboBox cbArea;
        private Label label6;
        private Label label5;
        private TextBox txbTiempoOperacion;
        private Label label12;
        private TextBox txbTiempoPreparacion;
        private Label label11;
        private TextBox txbNoOperacion;
        private TextBox txbPreparacion;
        private Label label10;
        private TextBox txbTipoMaquina;
        private Label label9;
        private Button btnActualizarProceso;
        private Button btnAgregarProceso;
        private Button btnEliminarProceso;
        private Button btnGuardarHojaRuta;
        private Label label13;
        private Label label14;
        private ComboBox cbNaveAreas;
        private Label label15;
        private TabPage tabFamilias;
        private Panel panel3;
        private TextBox txbHule;
        private Button btnEditarHules;
        private Button btnAgregarHules;
        private TextBox txbHuleOriginal;
        private Label label17;
        private Button btnEliminarHules;
        private DataGridView dgvHules;
        private Button btnNuevoHules;
        private Label label18;
        private TextBox txbInsumos;
        private Label label16;
        private TextBox txbNave;
    }
}