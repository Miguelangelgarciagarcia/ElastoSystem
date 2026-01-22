namespace ElastoSystem
{
    partial class Produccion_AdministrarOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produccion_AdministrarOP));
            panel3 = new Panel();
            txbDescripcion = new TextBox();
            label10 = new Label();
            cbEstatus = new ComboBox();
            lblID = new Label();
            label9 = new Label();
            txbCantidadDGV = new TextBox();
            lblOT = new Label();
            label8 = new Label();
            label2 = new Label();
            btnDuplicarOperacion = new Button();
            btnActualizarOperacion = new Button();
            dgvOperaciones = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            OT = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Estatus = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            btnDatosProdEspecial = new Button();
            txbEspecificacion = new TextBox();
            txbOC = new TextBox();
            txbCliente = new TextBox();
            dtpFechaEntrega = new DateTimePicker();
            lblDescripcion = new Label();
            label7 = new Label();
            chbProdEspecial = new CheckBox();
            chbLinea = new CheckBox();
            btnGuardarCambios = new Button();
            txbCantidad = new TextBox();
            lblClave2 = new Label();
            lblFolio = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            panel1 = new Panel();
            lblCantidad = new Label();
            lblClave = new Label();
            lblSolicitante = new Label();
            lblSolicitudFabricacion = new Label();
            txbNotas = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label21 = new Label();
            label1 = new Label();
            panel4 = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox6 = new PictureBox();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOperaciones).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(3, 42, 76);
            panel3.Controls.Add(txbDescripcion);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(cbEstatus);
            panel3.Controls.Add(lblID);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(txbCantidadDGV);
            panel3.Controls.Add(lblOT);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(btnDuplicarOperacion);
            panel3.Controls.Add(btnActualizarOperacion);
            panel3.Controls.Add(dgvOperaciones);
            panel3.Location = new Point(36, 407);
            panel3.Name = "panel3";
            panel3.Size = new Size(1269, 431);
            panel3.TabIndex = 83;
            // 
            // txbDescripcion
            // 
            txbDescripcion.Font = new Font("Montserrat", 12F);
            txbDescripcion.Location = new Point(133, 15);
            txbDescripcion.Name = "txbDescripcion";
            txbDescripcion.ReadOnly = true;
            txbDescripcion.Size = new Size(740, 27);
            txbDescripcion.TabIndex = 97;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 12F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(19, 18);
            label10.Name = "label10";
            label10.Size = new Size(110, 25);
            label10.TabIndex = 96;
            label10.Text = "Descripcion:";
            // 
            // cbEstatus
            // 
            cbEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstatus.Font = new Font("Montserrat", 12F);
            cbEstatus.FormattingEnabled = true;
            cbEstatus.Items.AddRange(new object[] { "Activa", "Inactiva" });
            cbEstatus.Location = new Point(637, 48);
            cbEstatus.Name = "cbEstatus";
            cbEstatus.Size = new Size(236, 33);
            cbEstatus.TabIndex = 95;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.BackColor = Color.Transparent;
            lblID.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblID.ForeColor = Color.White;
            lblID.Location = new Point(941, 15);
            lblID.Name = "lblID";
            lblID.Size = new Size(96, 25);
            lblID.TabIndex = 94;
            lblID.Text = "ID ERROR";
            lblID.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Montserrat", 12F);
            label9.ForeColor = Color.White;
            label9.Location = new Point(559, 54);
            label9.Name = "label9";
            label9.Size = new Size(74, 25);
            label9.TabIndex = 93;
            label9.Text = "Estatus:";
            // 
            // txbCantidadDGV
            // 
            txbCantidadDGV.Font = new Font("Montserrat", 12F);
            txbCantidadDGV.Location = new Point(369, 51);
            txbCantidadDGV.Name = "txbCantidadDGV";
            txbCantidadDGV.Size = new Size(168, 27);
            txbCantidadDGV.TabIndex = 92;
            txbCantidadDGV.KeyPress += txbCantidadDGV_KeyPress;
            // 
            // lblOT
            // 
            lblOT.AutoSize = true;
            lblOT.BackColor = Color.Transparent;
            lblOT.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblOT.ForeColor = Color.White;
            lblOT.Location = new Point(60, 54);
            lblOT.Name = "lblOT";
            lblOT.Size = new Size(73, 25);
            lblOT.TabIndex = 74;
            lblOT.Text = "ERROR";
            lblOT.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 12F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(267, 54);
            label8.Name = "label8";
            label8.Size = new Size(87, 25);
            label8.TabIndex = 91;
            label8.Text = "Cantidad:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(19, 54);
            label2.Name = "label2";
            label2.Size = new Size(37, 25);
            label2.TabIndex = 74;
            label2.Text = "OT:";
            // 
            // btnDuplicarOperacion
            // 
            btnDuplicarOperacion.BackColor = Color.FromArgb(255, 102, 0);
            btnDuplicarOperacion.Cursor = Cursors.Hand;
            btnDuplicarOperacion.FlatAppearance.BorderSize = 0;
            btnDuplicarOperacion.FlatStyle = FlatStyle.Flat;
            btnDuplicarOperacion.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnDuplicarOperacion.ForeColor = Color.White;
            btnDuplicarOperacion.Location = new Point(280, 89);
            btnDuplicarOperacion.Name = "btnDuplicarOperacion";
            btnDuplicarOperacion.Size = new Size(285, 30);
            btnDuplicarOperacion.TabIndex = 82;
            btnDuplicarOperacion.Text = "DUPLICAR OPERACION";
            btnDuplicarOperacion.UseVisualStyleBackColor = false;
            btnDuplicarOperacion.Visible = false;
            btnDuplicarOperacion.Click += btnDuplicarOperacion_Click;
            // 
            // btnActualizarOperacion
            // 
            btnActualizarOperacion.BackColor = Color.FromArgb(255, 102, 0);
            btnActualizarOperacion.Cursor = Cursors.Hand;
            btnActualizarOperacion.FlatAppearance.BorderSize = 0;
            btnActualizarOperacion.FlatStyle = FlatStyle.Flat;
            btnActualizarOperacion.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnActualizarOperacion.ForeColor = Color.White;
            btnActualizarOperacion.Location = new Point(941, 50);
            btnActualizarOperacion.Name = "btnActualizarOperacion";
            btnActualizarOperacion.Size = new Size(285, 30);
            btnActualizarOperacion.TabIndex = 81;
            btnActualizarOperacion.Text = "ACTUALIZAR OPERACION";
            btnActualizarOperacion.UseVisualStyleBackColor = false;
            btnActualizarOperacion.Visible = false;
            btnActualizarOperacion.Click += btnActualizarOperacion_Click;
            // 
            // dgvOperaciones
            // 
            dgvOperaciones.AllowUserToAddRows = false;
            dgvOperaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOperaciones.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvOperaciones.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvOperaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvOperaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOperaciones.Columns.AddRange(new DataGridViewColumn[] { ID, Descripcion, OT, Cantidad, Estatus });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvOperaciones.DefaultCellStyle = dataGridViewCellStyle2;
            dgvOperaciones.GridColor = SystemColors.ActiveCaptionText;
            dgvOperaciones.Location = new Point(19, 137);
            dgvOperaciones.MultiSelect = false;
            dgvOperaciones.Name = "dgvOperaciones";
            dgvOperaciones.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle3.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvOperaciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvOperaciones.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 11.25F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvOperaciones.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvOperaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOperaciones.Size = new Size(1225, 274);
            dgvOperaciones.TabIndex = 52;
            dgvOperaciones.CellClick += dgvOperaciones_CellClick;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            // 
            // Descripcion
            // 
            Descripcion.FillWeight = 122.525246F;
            Descripcion.HeaderText = "Descripcion";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            // 
            // OT
            // 
            OT.FillWeight = 82.5252457F;
            OT.HeaderText = "OT";
            OT.Name = "OT";
            OT.ReadOnly = true;
            // 
            // Cantidad
            // 
            Cantidad.FillWeight = 53.426712F;
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            // 
            // Estatus
            // 
            Estatus.FillWeight = 61.5228653F;
            Estatus.HeaderText = "Estatus";
            Estatus.Name = "Estatus";
            Estatus.ReadOnly = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(3, 42, 76);
            panel2.Controls.Add(btnDatosProdEspecial);
            panel2.Controls.Add(txbEspecificacion);
            panel2.Controls.Add(txbOC);
            panel2.Controls.Add(txbCliente);
            panel2.Controls.Add(dtpFechaEntrega);
            panel2.Controls.Add(lblDescripcion);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(chbProdEspecial);
            panel2.Controls.Add(chbLinea);
            panel2.Controls.Add(btnGuardarCambios);
            panel2.Controls.Add(txbCantidad);
            panel2.Controls.Add(lblClave2);
            panel2.Controls.Add(lblFolio);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label16);
            panel2.Location = new Point(474, 109);
            panel2.Name = "panel2";
            panel2.Size = new Size(831, 285);
            panel2.TabIndex = 82;
            // 
            // btnDatosProdEspecial
            // 
            btnDatosProdEspecial.BackColor = Color.FromArgb(255, 102, 0);
            btnDatosProdEspecial.Cursor = Cursors.Hand;
            btnDatosProdEspecial.FlatAppearance.BorderSize = 0;
            btnDatosProdEspecial.FlatStyle = FlatStyle.Flat;
            btnDatosProdEspecial.Font = new Font("Montserrat", 8F, FontStyle.Bold);
            btnDatosProdEspecial.ForeColor = Color.White;
            btnDatosProdEspecial.Location = new Point(646, 131);
            btnDatosProdEspecial.Name = "btnDatosProdEspecial";
            btnDatosProdEspecial.Size = new Size(152, 26);
            btnDatosProdEspecial.TabIndex = 90;
            btnDatosProdEspecial.Text = "Datos de Prod Especial";
            btnDatosProdEspecial.UseVisualStyleBackColor = false;
            btnDatosProdEspecial.Visible = false;
            btnDatosProdEspecial.Click += button1_Click;
            // 
            // txbEspecificacion
            // 
            txbEspecificacion.Font = new Font("Montserrat", 12F);
            txbEspecificacion.Location = new Point(406, 54);
            txbEspecificacion.Name = "txbEspecificacion";
            txbEspecificacion.Size = new Size(168, 27);
            txbEspecificacion.TabIndex = 89;
            txbEspecificacion.Visible = false;
            // 
            // txbOC
            // 
            txbOC.Font = new Font("Montserrat", 12F);
            txbOC.Location = new Point(406, 22);
            txbOC.Name = "txbOC";
            txbOC.Size = new Size(168, 27);
            txbOC.TabIndex = 88;
            txbOC.Visible = false;
            // 
            // txbCliente
            // 
            txbCliente.Font = new Font("Montserrat", 12F);
            txbCliente.Location = new Point(232, 22);
            txbCliente.Name = "txbCliente";
            txbCliente.Size = new Size(168, 27);
            txbCliente.TabIndex = 87;
            txbCliente.Visible = false;
            // 
            // dtpFechaEntrega
            // 
            dtpFechaEntrega.Font = new Font("Montserrat", 12F);
            dtpFechaEntrega.Location = new Point(155, 169);
            dtpFechaEntrega.Name = "dtpFechaEntrega";
            dtpFechaEntrega.Size = new Size(341, 27);
            dtpFechaEntrega.TabIndex = 85;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.BackColor = Color.Transparent;
            lblDescripcion.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblDescripcion.ForeColor = Color.White;
            lblDescripcion.Location = new Point(133, 95);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(73, 25);
            lblDescripcion.TabIndex = 84;
            lblDescripcion.Text = "ERROR";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 12F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(19, 95);
            label7.Name = "label7";
            label7.Size = new Size(110, 25);
            label7.TabIndex = 83;
            label7.Text = "Descripcion:";
            // 
            // chbProdEspecial
            // 
            chbProdEspecial.AutoSize = true;
            chbProdEspecial.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbProdEspecial.ForeColor = Color.White;
            chbProdEspecial.Location = new Point(503, 133);
            chbProdEspecial.Name = "chbProdEspecial";
            chbProdEspecial.Size = new Size(139, 29);
            chbProdEspecial.TabIndex = 82;
            chbProdEspecial.Text = "Prod Especial";
            chbProdEspecial.UseVisualStyleBackColor = true;
            chbProdEspecial.CheckedChanged += chbProdEspecial_CheckedChanged;
            // 
            // chbLinea
            // 
            chbLinea.AutoSize = true;
            chbLinea.Checked = true;
            chbLinea.CheckState = CheckState.Checked;
            chbLinea.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbLinea.ForeColor = Color.White;
            chbLinea.Location = new Point(407, 133);
            chbLinea.Name = "chbLinea";
            chbLinea.Size = new Size(74, 29);
            chbLinea.TabIndex = 81;
            chbLinea.Text = "Linea";
            chbLinea.UseVisualStyleBackColor = true;
            chbLinea.CheckedChanged += chbLinea_CheckedChanged;
            // 
            // btnGuardarCambios
            // 
            btnGuardarCambios.BackColor = Color.FromArgb(255, 102, 0);
            btnGuardarCambios.Cursor = Cursors.Hand;
            btnGuardarCambios.FlatAppearance.BorderSize = 0;
            btnGuardarCambios.FlatStyle = FlatStyle.Flat;
            btnGuardarCambios.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnGuardarCambios.ForeColor = Color.White;
            btnGuardarCambios.Location = new Point(133, 222);
            btnGuardarCambios.Name = "btnGuardarCambios";
            btnGuardarCambios.Size = new Size(555, 32);
            btnGuardarCambios.TabIndex = 80;
            btnGuardarCambios.Text = "GUARDAR CAMBIOS";
            btnGuardarCambios.UseVisualStyleBackColor = false;
            btnGuardarCambios.Click += btnGuardarCambios_Click;
            // 
            // txbCantidad
            // 
            txbCantidad.Font = new Font("Montserrat", 12F);
            txbCantidad.Location = new Point(121, 134);
            txbCantidad.Name = "txbCantidad";
            txbCantidad.Size = new Size(168, 27);
            txbCantidad.TabIndex = 74;
            txbCantidad.KeyPress += txbCantidad_KeyPress;
            // 
            // lblClave2
            // 
            lblClave2.AutoSize = true;
            lblClave2.BackColor = Color.Transparent;
            lblClave2.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblClave2.ForeColor = Color.White;
            lblClave2.Location = new Point(82, 59);
            lblClave2.Name = "lblClave2";
            lblClave2.Size = new Size(73, 25);
            lblClave2.TabIndex = 71;
            lblClave2.Text = "ERROR";
            lblClave2.TextChanged += lblClave2_TextChanged;
            // 
            // lblFolio
            // 
            lblFolio.AutoSize = true;
            lblFolio.BackColor = Color.Transparent;
            lblFolio.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblFolio.ForeColor = Color.White;
            lblFolio.Location = new Point(674, 25);
            lblFolio.Name = "lblFolio";
            lblFolio.Size = new Size(73, 25);
            lblFolio.TabIndex = 70;
            lblFolio.Text = "ERROR";
            lblFolio.TextChanged += lblFolio_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 12F);
            label13.ForeColor = Color.White;
            label13.Location = new Point(19, 173);
            label13.Name = "label13";
            label13.Size = new Size(132, 25);
            label13.TabIndex = 68;
            label13.Text = "Fecha Entrega:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Montserrat", 12F);
            label14.ForeColor = Color.White;
            label14.Location = new Point(19, 137);
            label14.Name = "label14";
            label14.Size = new Size(87, 25);
            label14.TabIndex = 67;
            label14.Text = "Cantidad:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Montserrat", 12F);
            label15.ForeColor = Color.White;
            label15.Location = new Point(19, 59);
            label15.Name = "label15";
            label15.Size = new Size(58, 25);
            label15.TabIndex = 66;
            label15.Text = "Clave:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Montserrat", 12F);
            label16.ForeColor = Color.White;
            label16.Location = new Point(617, 25);
            label16.Name = "label16";
            label16.Size = new Size(53, 25);
            label16.TabIndex = 65;
            label16.Text = "Folio:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(lblCantidad);
            panel1.Controls.Add(lblClave);
            panel1.Controls.Add(lblSolicitante);
            panel1.Controls.Add(lblSolicitudFabricacion);
            panel1.Controls.Add(txbNotas);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label21);
            panel1.Location = new Point(36, 109);
            panel1.Name = "panel1";
            panel1.Size = new Size(432, 285);
            panel1.TabIndex = 81;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.BackColor = Color.Transparent;
            lblCantidad.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblCantidad.ForeColor = Color.White;
            lblCantidad.Location = new Point(111, 131);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(73, 25);
            lblCantidad.TabIndex = 73;
            lblCantidad.Text = "ERROR";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.BackColor = Color.Transparent;
            lblClave.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblClave.ForeColor = Color.White;
            lblClave.Location = new Point(82, 95);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(73, 25);
            lblClave.TabIndex = 72;
            lblClave.Text = "ERROR";
            // 
            // lblSolicitante
            // 
            lblSolicitante.AutoSize = true;
            lblSolicitante.BackColor = Color.Transparent;
            lblSolicitante.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblSolicitante.ForeColor = Color.White;
            lblSolicitante.Location = new Point(121, 59);
            lblSolicitante.Name = "lblSolicitante";
            lblSolicitante.Size = new Size(73, 25);
            lblSolicitante.TabIndex = 71;
            lblSolicitante.Text = "ERROR";
            // 
            // lblSolicitudFabricacion
            // 
            lblSolicitudFabricacion.AutoSize = true;
            lblSolicitudFabricacion.BackColor = Color.Transparent;
            lblSolicitudFabricacion.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblSolicitudFabricacion.ForeColor = Color.White;
            lblSolicitudFabricacion.Location = new Point(228, 25);
            lblSolicitudFabricacion.Name = "lblSolicitudFabricacion";
            lblSolicitudFabricacion.Size = new Size(73, 25);
            lblSolicitudFabricacion.TabIndex = 70;
            lblSolicitudFabricacion.Text = "ERROR";
            lblSolicitudFabricacion.TextChanged += lblSolicitudFabricacion_TextChanged;
            lblSolicitudFabricacion.Click += lblSolicitudFabricacion_Click;
            // 
            // txbNotas
            // 
            txbNotas.Font = new Font("Montserrat", 12F);
            txbNotas.Location = new Point(19, 197);
            txbNotas.Multiline = true;
            txbNotas.Name = "txbNotas";
            txbNotas.ReadOnly = true;
            txbNotas.Size = new Size(393, 68);
            txbNotas.TabIndex = 51;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 12F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(19, 167);
            label6.Name = "label6";
            label6.Size = new Size(61, 25);
            label6.TabIndex = 69;
            label6.Text = "Notas:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 12F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(19, 131);
            label5.Name = "label5";
            label5.Size = new Size(87, 25);
            label5.TabIndex = 68;
            label5.Text = "Cantidad:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(19, 95);
            label4.Name = "label4";
            label4.Size = new Size(58, 25);
            label4.TabIndex = 67;
            label4.Text = "Clave:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(19, 59);
            label3.Name = "label3";
            label3.Size = new Size(98, 25);
            label3.TabIndex = 66;
            label3.Text = "Solicitante:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.Transparent;
            label21.Font = new Font("Montserrat", 12F);
            label21.ForeColor = Color.White;
            label21.Location = new Point(19, 25);
            label21.Name = "label21";
            label21.Size = new Size(205, 25);
            label21.TabIndex = 65;
            label21.Text = "Solicitud de Fabricacion:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(303, 49);
            label1.Name = "label1";
            label1.Size = new Size(694, 49);
            label1.TabIndex = 84;
            label1.Text = "ADMINISTRAR ORDEN DE PRODUCCIÓN";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(153, 255, 255, 255);
            panel4.Controls.Add(pictureBox4);
            panel4.Controls.Add(pictureBox6);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1333, 30);
            panel4.TabIndex = 85;
            panel4.MouseDown += panel4_MouseDown;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(1303, 4);
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
            pictureBox6.Location = new Point(1303, 4);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(23, 23);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 18;
            pictureBox6.TabStop = false;
            pictureBox6.Click += pictureBox6_Click;
            pictureBox6.MouseLeave += pictureBox6_MouseLeave;
            // 
            // Produccion_AdministrarOP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1333, 853);
            Controls.Add(panel4);
            Controls.Add(label1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_AdministrarOP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Produccion_AdministrarOP";
            Load += Produccion_AdministrarOP_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOperaciones).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private DataGridView dgvOperaciones;
        private Panel panel2;
        private TextBox txbEspecificacion;
        private TextBox txbOC;
        private TextBox txbCliente;
        private DateTimePicker dtpFechaEntrega;
        private Label lblDescripcion;
        private Label label7;
        private CheckBox chbProdEspecial;
        private CheckBox chbLinea;
        private Button btnGuardarCambios;
        private TextBox txbCantidad;
        private Label lblClave2;
        private Label lblFolio;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Panel panel1;
        private Label lblCantidad;
        private Label lblClave;
        private Label lblSolicitante;
        private Label lblSolicitudFabricacion;
        private TextBox txbNotas;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label21;
        private Label label1;
        private Panel panel4;
        private PictureBox pictureBox4;
        private PictureBox pictureBox6;
        private Button btnDatosProdEspecial;
        private Button btnDuplicarOperacion;
        private Button btnActualizarOperacion;
        private Label label9;
        private TextBox txbCantidadDGV;
        private Label lblOT;
        private Label label8;
        private Label label2;
        private Label lblID;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn OT;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Estatus;
        private ComboBox cbEstatus;
        private TextBox txbDescripcion;
        private Label label10;
    }
}