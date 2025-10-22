namespace ElastoSystem
{
    partial class Produccion_ReporteDiario
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabNave1 = new TabPage();
            txbReproceso = new TextBox();
            label15 = new Label();
            txbPCTotal = new TextBox();
            label14 = new Label();
            txbPNCOperacion = new TextBox();
            label12 = new Label();
            txbProductoOP = new TextBox();
            label11 = new Label();
            txbHorasTrabajadas = new TextBox();
            label9 = new Label();
            txbObservaciones = new TextBox();
            label8 = new Label();
            txbMaquina = new TextBox();
            label7 = new Label();
            btnGuardar = new Button();
            cbOperador = new ComboBox();
            label6 = new Label();
            cbTurno = new ComboBox();
            label5 = new Label();
            txbActividad = new TextBox();
            label4 = new Label();
            txbProducto = new TextBox();
            label10 = new Label();
            label2 = new Label();
            btnFirmarReporteN1 = new Button();
            dgvNave1 = new DataGridView();
            tabNave2 = new TabPage();
            label3 = new Label();
            btnActualizarEncabezado = new Button();
            dgvNave2 = new DataGridView();
            tabEditarReporte = new TabPage();
            textBox7 = new TextBox();
            label13 = new Label();
            tabControl1.SuspendLayout();
            tabNave1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNave1).BeginInit();
            tabNave2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNave2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 22F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(16, 21);
            label1.Name = "label1";
            label1.Size = new Size(403, 41);
            label1.TabIndex = 15;
            label1.Text = "REPORTE PRODUCCIÓN";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabNave1);
            tabControl1.Controls.Add(tabNave2);
            tabControl1.Controls.Add(tabEditarReporte);
            tabControl1.Location = new Point(12, 78);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1314, 732);
            tabControl1.TabIndex = 16;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabNave1
            // 
            tabNave1.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabNave1.Controls.Add(txbReproceso);
            tabNave1.Controls.Add(label15);
            tabNave1.Controls.Add(txbPCTotal);
            tabNave1.Controls.Add(label14);
            tabNave1.Controls.Add(txbPNCOperacion);
            tabNave1.Controls.Add(label12);
            tabNave1.Controls.Add(txbProductoOP);
            tabNave1.Controls.Add(label11);
            tabNave1.Controls.Add(txbHorasTrabajadas);
            tabNave1.Controls.Add(label9);
            tabNave1.Controls.Add(txbObservaciones);
            tabNave1.Controls.Add(label8);
            tabNave1.Controls.Add(txbMaquina);
            tabNave1.Controls.Add(label7);
            tabNave1.Controls.Add(btnGuardar);
            tabNave1.Controls.Add(cbOperador);
            tabNave1.Controls.Add(label6);
            tabNave1.Controls.Add(cbTurno);
            tabNave1.Controls.Add(label5);
            tabNave1.Controls.Add(txbActividad);
            tabNave1.Controls.Add(label4);
            tabNave1.Controls.Add(txbProducto);
            tabNave1.Controls.Add(label10);
            tabNave1.Controls.Add(label2);
            tabNave1.Controls.Add(btnFirmarReporteN1);
            tabNave1.Controls.Add(dgvNave1);
            tabNave1.Location = new Point(4, 24);
            tabNave1.Name = "tabNave1";
            tabNave1.Padding = new Padding(3);
            tabNave1.Size = new Size(1306, 704);
            tabNave1.TabIndex = 1;
            tabNave1.Text = "NAVE 1";
            tabNave1.UseVisualStyleBackColor = true;
            // 
            // txbReproceso
            // 
            txbReproceso.Font = new Font("Montserrat", 11F);
            txbReproceso.Location = new Point(805, 176);
            txbReproceso.Name = "txbReproceso";
            txbReproceso.ReadOnly = true;
            txbReproceso.Size = new Size(142, 25);
            txbReproceso.TabIndex = 138;
            txbReproceso.TextAlign = HorizontalAlignment.Center;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Montserrat", 11F);
            label15.ForeColor = Color.White;
            label15.Location = new Point(687, 179);
            label15.Name = "label15";
            label15.Size = new Size(112, 21);
            label15.TabIndex = 137;
            label15.Text = "REPROCESO:";
            // 
            // txbPCTotal
            // 
            txbPCTotal.Font = new Font("Montserrat", 11F);
            txbPCTotal.Location = new Point(1095, 176);
            txbPCTotal.Name = "txbPCTotal";
            txbPCTotal.ReadOnly = true;
            txbPCTotal.Size = new Size(142, 25);
            txbPCTotal.TabIndex = 136;
            txbPCTotal.TextAlign = HorizontalAlignment.Center;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Montserrat", 11F);
            label14.ForeColor = Color.White;
            label14.Location = new Point(994, 176);
            label14.Name = "label14";
            label14.Size = new Size(95, 21);
            label14.TabIndex = 135;
            label14.Text = "P.C. TOTAL:";
            // 
            // txbPNCOperacion
            // 
            txbPNCOperacion.Font = new Font("Montserrat", 11F);
            txbPNCOperacion.Location = new Point(509, 176);
            txbPNCOperacion.Name = "txbPNCOperacion";
            txbPNCOperacion.ReadOnly = true;
            txbPNCOperacion.Size = new Size(142, 25);
            txbPNCOperacion.TabIndex = 132;
            txbPNCOperacion.TextAlign = HorizontalAlignment.Center;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Montserrat", 11F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(375, 176);
            label12.Name = "label12";
            label12.Size = new Size(128, 21);
            label12.TabIndex = 131;
            label12.Text = "P.N.C EN OPER:";
            // 
            // txbProductoOP
            // 
            txbProductoOP.Font = new Font("Montserrat", 11F);
            txbProductoOP.Location = new Point(214, 173);
            txbProductoOP.Name = "txbProductoOP";
            txbProductoOP.ReadOnly = true;
            txbProductoOP.Size = new Size(142, 25);
            txbProductoOP.TabIndex = 130;
            txbProductoOP.TextAlign = HorizontalAlignment.Center;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Montserrat", 11F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(49, 176);
            label11.Name = "label11";
            label11.Size = new Size(159, 21);
            label11.TabIndex = 129;
            label11.Text = "PRODUCTO EN OP:";
            // 
            // txbHorasTrabajadas
            // 
            txbHorasTrabajadas.Font = new Font("Montserrat", 11F);
            txbHorasTrabajadas.Location = new Point(1080, 126);
            txbHorasTrabajadas.Name = "txbHorasTrabajadas";
            txbHorasTrabajadas.ReadOnly = true;
            txbHorasTrabajadas.Size = new Size(206, 25);
            txbHorasTrabajadas.TabIndex = 128;
            txbHorasTrabajadas.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Montserrat", 11F);
            label9.ForeColor = Color.White;
            label9.Location = new Point(934, 129);
            label9.Name = "label9";
            label9.Size = new Size(140, 21);
            label9.TabIndex = 127;
            label9.Text = "Horas Trabajadas:";
            // 
            // txbObservaciones
            // 
            txbObservaciones.Font = new Font("Montserrat", 11F);
            txbObservaciones.Location = new Point(164, 218);
            txbObservaciones.Name = "txbObservaciones";
            txbObservaciones.ReadOnly = true;
            txbObservaciones.Size = new Size(783, 25);
            txbObservaciones.TabIndex = 126;
            txbObservaciones.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 11F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(36, 221);
            label8.Name = "label8";
            label8.Size = new Size(122, 21);
            label8.TabIndex = 125;
            label8.Text = "Observaciones:";
            // 
            // txbMaquina
            // 
            txbMaquina.Font = new Font("Montserrat", 11F);
            txbMaquina.Location = new Point(659, 127);
            txbMaquina.Name = "txbMaquina";
            txbMaquina.ReadOnly = true;
            txbMaquina.Size = new Size(267, 25);
            txbMaquina.TabIndex = 124;
            txbMaquina.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 11F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(574, 130);
            label7.Name = "label7";
            label7.Size = new Size(79, 21);
            label7.TabIndex = 123;
            label7.Text = "Maquina:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(255, 102, 0);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(953, 213);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(333, 35);
            btnGuardar.TabIndex = 122;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // cbOperador
            // 
            cbOperador.Enabled = false;
            cbOperador.Font = new Font("Montserrat", 11F);
            cbOperador.FormattingEnabled = true;
            cbOperador.Items.AddRange(new object[] { "MATUTINO", "MIXTO", "VESPERTINO" });
            cbOperador.Location = new Point(123, 123);
            cbOperador.Name = "cbOperador";
            cbOperador.Size = new Size(437, 29);
            cbOperador.TabIndex = 120;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 11F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(33, 126);
            label6.Name = "label6";
            label6.Size = new Size(84, 21);
            label6.TabIndex = 121;
            label6.Text = "Operador:";
            // 
            // cbTurno
            // 
            cbTurno.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTurno.Enabled = false;
            cbTurno.Font = new Font("Montserrat", 11F);
            cbTurno.FormattingEnabled = true;
            cbTurno.Items.AddRange(new object[] { "ESPECIAL", "MATUTINO", "MIXTO", "VESPERTINO" });
            cbTurno.Location = new Point(979, 80);
            cbTurno.Name = "cbTurno";
            cbTurno.Size = new Size(307, 29);
            cbTurno.TabIndex = 118;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 11F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(916, 83);
            label5.Name = "label5";
            label5.Size = new Size(57, 21);
            label5.TabIndex = 119;
            label5.Text = "Turno:";
            // 
            // txbActividad
            // 
            txbActividad.Font = new Font("Montserrat", 11F);
            txbActividad.Location = new Point(445, 80);
            txbActividad.Name = "txbActividad";
            txbActividad.ReadOnly = true;
            txbActividad.Size = new Size(456, 25);
            txbActividad.TabIndex = 117;
            txbActividad.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 11F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(357, 83);
            label4.Name = "label4";
            label4.Size = new Size(83, 21);
            label4.TabIndex = 116;
            label4.Text = "Actividad:";
            // 
            // txbProducto
            // 
            txbProducto.Font = new Font("Montserrat", 11F);
            txbProducto.Location = new Point(119, 80);
            txbProducto.Name = "txbProducto";
            txbProducto.ReadOnly = true;
            txbProducto.Size = new Size(222, 25);
            txbProducto.TabIndex = 115;
            txbProducto.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 11F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(31, 83);
            label10.Name = "label10";
            label10.Size = new Size(82, 21);
            label10.TabIndex = 114;
            label10.Text = "Producto:";
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 22F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(21, 18);
            label2.Name = "label2";
            label2.Size = new Size(1265, 41);
            label2.TabIndex = 75;
            label2.Text = "NAVE 1";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnFirmarReporteN1
            // 
            btnFirmarReporteN1.BackColor = Color.FromArgb(255, 102, 0);
            btnFirmarReporteN1.Cursor = Cursors.Hand;
            btnFirmarReporteN1.FlatAppearance.BorderSize = 0;
            btnFirmarReporteN1.FlatStyle = FlatStyle.Flat;
            btnFirmarReporteN1.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnFirmarReporteN1.ForeColor = Color.White;
            btnFirmarReporteN1.Location = new Point(525, 646);
            btnFirmarReporteN1.Name = "btnFirmarReporteN1";
            btnFirmarReporteN1.Size = new Size(275, 35);
            btnFirmarReporteN1.TabIndex = 74;
            btnFirmarReporteN1.Text = "FIRMAR REPORTE";
            btnFirmarReporteN1.UseVisualStyleBackColor = false;
            // 
            // dgvNave1
            // 
            dgvNave1.AllowUserToAddRows = false;
            dgvNave1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNave1.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvNave1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvNave1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNave1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvNave1.DefaultCellStyle = dataGridViewCellStyle2;
            dgvNave1.GridColor = SystemColors.ActiveCaptionText;
            dgvNave1.Location = new Point(21, 264);
            dgvNave1.Name = "dgvNave1";
            dgvNave1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle3.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvNave1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvNave1.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 11.25F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvNave1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvNave1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNave1.Size = new Size(1265, 361);
            dgvNave1.TabIndex = 73;
            dgvNave1.CellClick += dgvNave1_CellClick;
            dgvNave1.CellDoubleClick += dgvNave1_CellDoubleClick;
            // 
            // tabNave2
            // 
            tabNave2.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabNave2.Controls.Add(label3);
            tabNave2.Controls.Add(btnActualizarEncabezado);
            tabNave2.Controls.Add(dgvNave2);
            tabNave2.Location = new Point(4, 24);
            tabNave2.Name = "tabNave2";
            tabNave2.Size = new Size(1306, 704);
            tabNave2.TabIndex = 2;
            tabNave2.Text = "NAVE 2";
            tabNave2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 22F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(24, 15);
            label3.Name = "label3";
            label3.Size = new Size(1265, 41);
            label3.TabIndex = 76;
            label3.Text = "NAVE 2";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnActualizarEncabezado
            // 
            btnActualizarEncabezado.BackColor = Color.FromArgb(255, 102, 0);
            btnActualizarEncabezado.Cursor = Cursors.Hand;
            btnActualizarEncabezado.FlatAppearance.BorderSize = 0;
            btnActualizarEncabezado.FlatStyle = FlatStyle.Flat;
            btnActualizarEncabezado.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnActualizarEncabezado.ForeColor = Color.White;
            btnActualizarEncabezado.Location = new Point(1015, 648);
            btnActualizarEncabezado.Name = "btnActualizarEncabezado";
            btnActualizarEncabezado.Size = new Size(275, 35);
            btnActualizarEncabezado.TabIndex = 72;
            btnActualizarEncabezado.Text = "FIRMAR REPORTE";
            btnActualizarEncabezado.UseVisualStyleBackColor = false;
            btnActualizarEncabezado.Visible = false;
            // 
            // dgvNave2
            // 
            dgvNave2.AllowUserToAddRows = false;
            dgvNave2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNave2.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvNave2.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvNave2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvNave2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvNave2.DefaultCellStyle = dataGridViewCellStyle6;
            dgvNave2.GridColor = SystemColors.ActiveCaptionText;
            dgvNave2.Location = new Point(25, 67);
            dgvNave2.Name = "dgvNave2";
            dgvNave2.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle7.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvNave2.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvNave2.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Montserrat", 11.25F);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dgvNave2.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dgvNave2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNave2.Size = new Size(1265, 565);
            dgvNave2.TabIndex = 50;
            // 
            // tabEditarReporte
            // 
            tabEditarReporte.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabEditarReporte.Location = new Point(4, 24);
            tabEditarReporte.Name = "tabEditarReporte";
            tabEditarReporte.Size = new Size(1306, 704);
            tabEditarReporte.TabIndex = 3;
            tabEditarReporte.Text = "EDITAR REPORTE";
            tabEditarReporte.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            textBox7.Font = new Font("Montserrat", 11F);
            textBox7.Location = new Point(1069, 37);
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new Size(142, 25);
            textBox7.TabIndex = 134;
            textBox7.TextAlign = HorizontalAlignment.Center;
            textBox7.Visible = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 11F);
            label13.ForeColor = Color.White;
            label13.Location = new Point(905, 40);
            label13.Name = "label13";
            label13.Size = new Size(158, 21);
            label13.TabIndex = 133;
            label13.Text = "P.N.C EN REVISION:";
            label13.Visible = false;
            // 
            // Produccion_ReporteDiario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Controls.Add(textBox7);
            Controls.Add(label13);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_ReporteDiario";
            Text = "Produccion_ReporteDiario";
            Load += Produccion_ReporteDiario_Load;
            tabControl1.ResumeLayout(false);
            tabNave1.ResumeLayout(false);
            tabNave1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNave1).EndInit();
            tabNave2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNave2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TabControl tabControl1;
        private TabPage tabNave1;
        private TabPage tabNave2;
        private Button btnActualizarEncabezado;
        private DataGridView dgvNave2;
        private TabPage tabEditarReporte;
        private Label label2;
        private Button btnFirmarReporteN1;
        private DataGridView dgvNave1;
        private Label label3;
        private TextBox txbActividad;
        private Label label4;
        private TextBox txbProducto;
        private Label label10;
        private ComboBox cbTurno;
        private Label label5;
        private Button btnGuardar;
        private ComboBox cbOperador;
        private Label label6;
        private TextBox txbHorasTrabajadas;
        private Label label9;
        private TextBox txbObservaciones;
        private Label label8;
        private TextBox txbMaquina;
        private Label label7;
        private TextBox txbPCTotal;
        private Label label14;
        private TextBox textBox7;
        private Label label13;
        private TextBox txbPNCOperacion;
        private Label label12;
        private TextBox txbProductoOP;
        private Label label11;
        private TextBox txbReproceso;
        private Label label15;
    }
}