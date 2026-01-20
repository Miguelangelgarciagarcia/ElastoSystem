namespace ElastoSystem
{
    partial class Produccion_OP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produccion_OP));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            panel4 = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox6 = new PictureBox();
            label1 = new Label();
            lblFolioOP = new Label();
            label21 = new Label();
            panel1 = new Panel();
            lblCantidad = new Label();
            label5 = new Label();
            lblDescripcion = new Label();
            label7 = new Label();
            lblClave = new Label();
            label4 = new Label();
            panel2 = new Panel();
            label11 = new Label();
            lblFechaEntrega = new Label();
            lblSolicitudFabricacion = new Label();
            label8 = new Label();
            lblFechaInicio = new Label();
            label10 = new Label();
            panel3 = new Panel();
            txbEspecificacion = new TextBox();
            txbOC = new TextBox();
            txbCliente = new TextBox();
            btnDatosProdEspecial = new Button();
            chbProdEspecial = new CheckBox();
            label3 = new Label();
            chbLinea = new CheckBox();
            lblAutorizo = new Label();
            panel5 = new Panel();
            label12 = new Label();
            label9 = new Label();
            label6 = new Label();
            label2 = new Label();
            panel11 = new Panel();
            panel10 = new Panel();
            panel9 = new Panel();
            panel8 = new Panel();
            dgvOperaciones = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            OT = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            label13 = new Label();
            panel6 = new Panel();
            dgvIngresos = new DataGridView();
            Fecha = new DataGridViewTextBoxColumn();
            Turno = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            Lote = new DataGridViewTextBoxColumn();
            Entrega = new DataGridViewTextBoxColumn();
            label14 = new Label();
            txbCantidad = new TextBox();
            label15 = new Label();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            panel7 = new Panel();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOperaciones).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIngresos).BeginInit();
            panel7.SuspendLayout();
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
            panel4.Size = new Size(817, 30);
            panel4.TabIndex = 86;
            panel4.MouseDown += panel4_MouseDown;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(783, 4);
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
            pictureBox6.Location = new Point(783, 4);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(23, 23);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 18;
            pictureBox6.TabStop = false;
            pictureBox6.Click += pictureBox6_Click;
            pictureBox6.MouseLeave += pictureBox6_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 20F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 43);
            label1.Name = "label1";
            label1.Size = new Size(378, 42);
            label1.TabIndex = 87;
            label1.Text = "ORDEN DE PRODUCCIÓN";
            // 
            // lblFolioOP
            // 
            lblFolioOP.AutoSize = true;
            lblFolioOP.BackColor = Color.Transparent;
            lblFolioOP.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblFolioOP.ForeColor = Color.White;
            lblFolioOP.Location = new Point(678, 58);
            lblFolioOP.Name = "lblFolioOP";
            lblFolioOP.Size = new Size(73, 25);
            lblFolioOP.TabIndex = 88;
            lblFolioOP.Text = "ERROR";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.Transparent;
            label21.Font = new Font("Montserrat", 12F);
            label21.ForeColor = Color.White;
            label21.Location = new Point(621, 58);
            label21.Name = "label21";
            label21.Size = new Size(53, 25);
            label21.TabIndex = 89;
            label21.Text = "Folio:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(lblCantidad);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblDescripcion);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(lblClave);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(12, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(793, 69);
            panel1.TabIndex = 90;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.BackColor = Color.Transparent;
            lblCantidad.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            lblCantidad.ForeColor = Color.White;
            lblCantidad.Location = new Point(655, 35);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(66, 24);
            lblCantidad.TabIndex = 88;
            lblCantidad.Text = "ERROR";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 11F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(655, 12);
            label5.Name = "label5";
            label5.Size = new Size(82, 24);
            label5.TabIndex = 87;
            label5.Text = "Cantidad:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.BackColor = Color.Transparent;
            lblDescripcion.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            lblDescripcion.ForeColor = Color.White;
            lblDescripcion.Location = new Point(134, 35);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(66, 24);
            lblDescripcion.TabIndex = 86;
            lblDescripcion.Text = "ERROR";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 11F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(134, 12);
            label7.Name = "label7";
            label7.Size = new Size(100, 24);
            label7.TabIndex = 85;
            label7.Text = "Descripcion:";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.BackColor = Color.Transparent;
            lblClave.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            lblClave.ForeColor = Color.White;
            lblClave.Location = new Point(15, 35);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(66, 24);
            lblClave.TabIndex = 74;
            lblClave.Text = "ERROR";
            lblClave.TextChanged += lblClave_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 11F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(15, 12);
            label4.Name = "label4";
            label4.Size = new Size(54, 24);
            label4.TabIndex = 73;
            label4.Text = "Clave:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(3, 42, 76);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(lblFechaEntrega);
            panel2.Controls.Add(lblSolicitudFabricacion);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(lblFechaInicio);
            panel2.Controls.Add(label10);
            panel2.Location = new Point(13, 158);
            panel2.Name = "panel2";
            panel2.Size = new Size(447, 100);
            panel2.TabIndex = 91;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Montserrat", 11F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(15, 67);
            label11.Name = "label11";
            label11.Size = new Size(122, 24);
            label11.TabIndex = 89;
            label11.Text = "Fecha Entrega:";
            // 
            // lblFechaEntrega
            // 
            lblFechaEntrega.AutoSize = true;
            lblFechaEntrega.BackColor = Color.Transparent;
            lblFechaEntrega.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            lblFechaEntrega.ForeColor = Color.White;
            lblFechaEntrega.Location = new Point(143, 67);
            lblFechaEntrega.Name = "lblFechaEntrega";
            lblFechaEntrega.Size = new Size(66, 24);
            lblFechaEntrega.TabIndex = 88;
            lblFechaEntrega.Text = "ERROR";
            // 
            // lblSolicitudFabricacion
            // 
            lblSolicitudFabricacion.AutoSize = true;
            lblSolicitudFabricacion.BackColor = Color.Transparent;
            lblSolicitudFabricacion.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            lblSolicitudFabricacion.ForeColor = Color.White;
            lblSolicitudFabricacion.Location = new Point(211, 12);
            lblSolicitudFabricacion.Name = "lblSolicitudFabricacion";
            lblSolicitudFabricacion.Size = new Size(66, 24);
            lblSolicitudFabricacion.TabIndex = 86;
            lblSolicitudFabricacion.Text = "ERROR";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 11F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(15, 40);
            label8.Name = "label8";
            label8.Size = new Size(102, 24);
            label8.TabIndex = 85;
            label8.Text = "Fecha Inicio:";
            label8.Click += label8_Click;
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.BackColor = Color.Transparent;
            lblFechaInicio.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            lblFechaInicio.ForeColor = Color.White;
            lblFechaInicio.Location = new Point(123, 40);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(66, 24);
            lblFechaInicio.TabIndex = 74;
            lblFechaInicio.Text = "ERROR";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 11F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(15, 12);
            label10.Name = "label10";
            label10.Size = new Size(190, 24);
            label10.TabIndex = 73;
            label10.Text = "Solicitud de Fabricacion:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(3, 42, 76);
            panel3.Controls.Add(txbEspecificacion);
            panel3.Controls.Add(txbOC);
            panel3.Controls.Add(txbCliente);
            panel3.Controls.Add(btnDatosProdEspecial);
            panel3.Controls.Add(chbProdEspecial);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(chbLinea);
            panel3.Controls.Add(lblAutorizo);
            panel3.Location = new Point(466, 158);
            panel3.Name = "panel3";
            panel3.Size = new Size(339, 100);
            panel3.TabIndex = 92;
            // 
            // txbEspecificacion
            // 
            txbEspecificacion.Font = new Font("Montserrat", 12F);
            txbEspecificacion.Location = new Point(236, 67);
            txbEspecificacion.Name = "txbEspecificacion";
            txbEspecificacion.Size = new Size(18, 27);
            txbEspecificacion.TabIndex = 101;
            txbEspecificacion.Visible = false;
            // 
            // txbOC
            // 
            txbOC.Font = new Font("Montserrat", 12F);
            txbOC.Location = new Point(212, 67);
            txbOC.Name = "txbOC";
            txbOC.Size = new Size(18, 27);
            txbOC.TabIndex = 100;
            txbOC.Visible = false;
            // 
            // txbCliente
            // 
            txbCliente.Font = new Font("Montserrat", 12F);
            txbCliente.Location = new Point(188, 67);
            txbCliente.Name = "txbCliente";
            txbCliente.Size = new Size(18, 27);
            txbCliente.TabIndex = 99;
            txbCliente.Visible = false;
            // 
            // btnDatosProdEspecial
            // 
            btnDatosProdEspecial.BackColor = Color.FromArgb(255, 102, 0);
            btnDatosProdEspecial.Cursor = Cursors.Hand;
            btnDatosProdEspecial.FlatAppearance.BorderSize = 0;
            btnDatosProdEspecial.FlatStyle = FlatStyle.Flat;
            btnDatosProdEspecial.Font = new Font("Montserrat", 8F, FontStyle.Bold);
            btnDatosProdEspecial.ForeColor = Color.White;
            btnDatosProdEspecial.Location = new Point(162, 35);
            btnDatosProdEspecial.Name = "btnDatosProdEspecial";
            btnDatosProdEspecial.Size = new Size(164, 26);
            btnDatosProdEspecial.TabIndex = 93;
            btnDatosProdEspecial.Text = "Datos de Prod Especial";
            btnDatosProdEspecial.UseVisualStyleBackColor = false;
            btnDatosProdEspecial.Visible = false;
            btnDatosProdEspecial.Click += btnDatosProdEspecial_Click;
            // 
            // chbProdEspecial
            // 
            chbProdEspecial.AutoSize = true;
            chbProdEspecial.BackColor = Color.Transparent;
            chbProdEspecial.Font = new Font("Montserrat", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbProdEspecial.ForeColor = Color.White;
            chbProdEspecial.Location = new Point(21, 39);
            chbProdEspecial.Name = "chbProdEspecial";
            chbProdEspecial.Size = new Size(130, 28);
            chbProdEspecial.TabIndex = 94;
            chbProdEspecial.Text = "Prod Especial";
            chbProdEspecial.UseVisualStyleBackColor = false;
            chbProdEspecial.CheckedChanged += chbProdEspecial_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 11F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(15, 67);
            label3.Name = "label3";
            label3.Size = new Size(76, 24);
            label3.TabIndex = 89;
            label3.Text = "Autorizo:";
            // 
            // chbLinea
            // 
            chbLinea.AutoSize = true;
            chbLinea.BackColor = Color.Transparent;
            chbLinea.Font = new Font("Montserrat", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbLinea.ForeColor = Color.White;
            chbLinea.Location = new Point(21, 12);
            chbLinea.Name = "chbLinea";
            chbLinea.Size = new Size(70, 28);
            chbLinea.TabIndex = 93;
            chbLinea.Text = "Linea";
            chbLinea.UseVisualStyleBackColor = false;
            chbLinea.CheckedChanged += chbLinea_CheckedChanged;
            // 
            // lblAutorizo
            // 
            lblAutorizo.AutoSize = true;
            lblAutorizo.BackColor = Color.Transparent;
            lblAutorizo.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            lblAutorizo.ForeColor = Color.White;
            lblAutorizo.Location = new Point(97, 67);
            lblAutorizo.Name = "lblAutorizo";
            lblAutorizo.Size = new Size(66, 24);
            lblAutorizo.TabIndex = 88;
            lblAutorizo.Text = "ERROR";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(3, 42, 76);
            panel5.Controls.Add(label12);
            panel5.Controls.Add(label9);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(panel11);
            panel5.Controls.Add(panel10);
            panel5.Controls.Add(panel9);
            panel5.Controls.Add(panel8);
            panel5.Controls.Add(dgvOperaciones);
            panel5.Controls.Add(label13);
            panel5.Location = new Point(13, 264);
            panel5.Name = "panel5";
            panel5.Size = new Size(792, 232);
            panel5.TabIndex = 95;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Montserrat", 6F, FontStyle.Bold);
            label12.ForeColor = Color.White;
            label12.Location = new Point(502, 210);
            label12.Name = "label12";
            label12.Size = new Size(73, 13);
            label12.TabIndex = 96;
            label12.Text = "OT FINALIZADA";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Montserrat", 6F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(431, 210);
            label9.Name = "label9";
            label9.Size = new Size(35, 13);
            label9.TabIndex = 95;
            label9.Text = "SIN OT";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 6F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(332, 210);
            label6.Name = "label6";
            label6.Size = new Size(63, 13);
            label6.TabIndex = 94;
            label6.Text = "OT PAUSADA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 6F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(239, 210);
            label2.Name = "label2";
            label2.Size = new Size(58, 13);
            label2.TabIndex = 93;
            label2.Text = "OT ABIERTA";
            // 
            // panel11
            // 
            panel11.BackColor = Color.Gray;
            panel11.Location = new Point(486, 210);
            panel11.Name = "panel11";
            panel11.Size = new Size(10, 10);
            panel11.TabIndex = 92;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(255, 128, 128);
            panel10.Location = new Point(415, 210);
            panel10.Name = "panel10";
            panel10.Size = new Size(10, 10);
            panel10.TabIndex = 91;
            // 
            // panel9
            // 
            panel9.BackColor = Color.Yellow;
            panel9.Location = new Point(316, 210);
            panel9.Name = "panel9";
            panel9.Size = new Size(10, 10);
            panel9.TabIndex = 90;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(128, 255, 128);
            panel8.Location = new Point(223, 210);
            panel8.Name = "panel8";
            panel8.Size = new Size(10, 10);
            panel8.TabIndex = 89;
            // 
            // dgvOperaciones
            // 
            dgvOperaciones.AllowUserToAddRows = false;
            dgvOperaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOperaciones.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvOperaciones.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvOperaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvOperaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOperaciones.Columns.AddRange(new DataGridViewColumn[] { ID, Descripcion, OT, Cantidad });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvOperaciones.DefaultCellStyle = dataGridViewCellStyle2;
            dgvOperaciones.GridColor = SystemColors.ActiveCaptionText;
            dgvOperaciones.Location = new Point(15, 38);
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
            dataGridViewCellStyle4.Font = new Font("Montserrat", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvOperaciones.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvOperaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOperaciones.Size = new Size(764, 163);
            dgvOperaciones.TabIndex = 88;
            dgvOperaciones.CellDoubleClick += dgvOperaciones_CellDoubleClick;
            dgvOperaciones.DataBindingComplete += dgvOperaciones_DataBindingComplete;
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
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            label13.ForeColor = Color.White;
            label13.Location = new Point(113, 11);
            label13.Name = "label13";
            label13.Size = new Size(567, 24);
            label13.TabIndex = 87;
            label13.Text = "MATERIALES Y PROCESOS UTILIZADOS PARA FABRICAR EL PRODUCTO";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(3, 42, 76);
            panel6.Controls.Add(dgvIngresos);
            panel6.Controls.Add(label14);
            panel6.Location = new Point(14, 501);
            panel6.Name = "panel6";
            panel6.Size = new Size(792, 193);
            panel6.TabIndex = 96;
            // 
            // dgvIngresos
            // 
            dgvIngresos.AllowUserToAddRows = false;
            dgvIngresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIngresos.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvIngresos.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Montserrat", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvIngresos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvIngresos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIngresos.Columns.AddRange(new DataGridViewColumn[] { Fecha, Turno, dataGridViewTextBoxColumn3, Lote, Entrega });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvIngresos.DefaultCellStyle = dataGridViewCellStyle6;
            dgvIngresos.GridColor = SystemColors.ActiveCaptionText;
            dgvIngresos.Location = new Point(13, 42);
            dgvIngresos.MultiSelect = false;
            dgvIngresos.Name = "dgvIngresos";
            dgvIngresos.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle7.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvIngresos.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvIngresos.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Montserrat", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dgvIngresos.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dgvIngresos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIngresos.Size = new Size(764, 139);
            dgvIngresos.TabIndex = 89;
            // 
            // Fecha
            // 
            Fecha.HeaderText = "Fecha";
            Fecha.Name = "Fecha";
            Fecha.ReadOnly = true;
            // 
            // Turno
            // 
            Turno.HeaderText = "Turno";
            Turno.Name = "Turno";
            Turno.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.FillWeight = 53.426712F;
            dataGridViewTextBoxColumn3.HeaderText = "Cantidad";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Lote
            // 
            Lote.HeaderText = "# de Lote";
            Lote.Name = "Lote";
            Lote.ReadOnly = true;
            // 
            // Entrega
            // 
            Entrega.HeaderText = "Entrega";
            Entrega.Name = "Entrega";
            Entrega.ReadOnly = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            label14.ForeColor = Color.White;
            label14.Location = new Point(132, 10);
            label14.Name = "label14";
            label14.Size = new Size(492, 24);
            label14.TabIndex = 88;
            label14.Text = "PRODUCTOS TERMINADOS ENTREGADOS AL ALMACEN DE PT";
            // 
            // txbCantidad
            // 
            txbCantidad.Font = new Font("Montserrat", 12F);
            txbCantidad.Location = new Point(341, 707);
            txbCantidad.Name = "txbCantidad";
            txbCantidad.Size = new Size(168, 27);
            txbCantidad.TabIndex = 98;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            label15.ForeColor = Color.White;
            label15.Location = new Point(515, 711);
            label15.Name = "label15";
            label15.Size = new Size(277, 24);
            label15.TabIndex = 97;
            label15.Text = "PRODUCCIÓN TOTAL ENTREGADA";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.BackColor = Color.Transparent;
            checkBox2.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox2.ForeColor = Color.White;
            checkBox2.Location = new Point(42, 9);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(229, 26);
            checkBox2.TabIndex = 99;
            checkBox2.Text = "GERENTE DE PRODUCCIÓN";
            checkBox2.UseVisualStyleBackColor = false;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.BackColor = Color.Transparent;
            checkBox3.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox3.ForeColor = Color.White;
            checkBox3.Location = new Point(368, 9);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(102, 26);
            checkBox3.TabIndex = 100;
            checkBox3.Text = "ALMACEN";
            checkBox3.UseVisualStyleBackColor = false;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.BackColor = Color.Transparent;
            checkBox4.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox4.ForeColor = Color.White;
            checkBox4.Location = new Point(553, 9);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(195, 26);
            checkBox4.TabIndex = 101;
            checkBox4.Text = "GERENTE DE CALIDAD";
            checkBox4.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(3, 42, 76);
            panel7.Controls.Add(checkBox4);
            panel7.Controls.Add(checkBox2);
            panel7.Controls.Add(checkBox3);
            panel7.Location = new Point(14, 749);
            panel7.Name = "panel7";
            panel7.Size = new Size(793, 45);
            panel7.TabIndex = 91;
            // 
            // Produccion_OP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(817, 806);
            Controls.Add(panel7);
            Controls.Add(txbCantidad);
            Controls.Add(label15);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label21);
            Controls.Add(lblFolioOP);
            Controls.Add(label1);
            Controls.Add(panel4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_OP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Produccion_OP";
            Load += Produccion_OP_Load;
            Shown += Produccion_OP_Shown;
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOperaciones).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIngresos).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel4;
        private PictureBox pictureBox4;
        private PictureBox pictureBox6;
        private Label label1;
        private Label lblFolioOP;
        private Label label21;
        private Panel panel1;
        private Label lblClave;
        private Label label4;
        private Label lblDescripcion;
        private Label label7;
        private Label lblCantidad;
        private Label label5;
        private Panel panel2;
        private Label lblFechaEntrega;
        private Label lblSolicitudFabricacion;
        private Label label8;
        private Label lblFechaInicio;
        private Label label10;
        private Label label11;
        private Panel panel3;
        private Label label3;
        private Label lblAutorizo;
        private CheckBox chbProdEspecial;
        private CheckBox chbLinea;
        private Button btnDatosProdEspecial;
        private Panel panel5;
        private Panel panel6;
        private Label label13;
        private DataGridView dgvOperaciones;
        private Label label14;
        private DataGridView dgvIngresos;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Turno;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn Lote;
        private DataGridViewTextBoxColumn Entrega;
        private TextBox txbCantidad;
        private Label label15;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private Panel panel7;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn OT;
        private DataGridViewTextBoxColumn Cantidad;
        private TextBox txbCliente;
        private TextBox txbEspecificacion;
        private TextBox txbOC;
        private Panel panel8;
        private Panel panel10;
        private Panel panel9;
        private Panel panel11;
        private Label label2;
        private Label label6;
        private Label label12;
        private Label label9;
    }
}