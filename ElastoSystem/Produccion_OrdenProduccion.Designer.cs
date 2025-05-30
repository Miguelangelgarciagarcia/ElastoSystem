namespace ElastoSystem
{
    partial class Produccion_OrdenProduccion
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
            DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle26 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle27 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle28 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle29 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle30 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle31 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle32 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle33 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle34 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle35 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle36 = new DataGridViewCellStyle();
            label1 = new Label();
            pnlInicio = new Panel();
            dgvSolicitudesFabricacion = new DataGridView();
            tabControl1 = new TabControl();
            tabActivas = new TabPage();
            dgvOrdenesActivas = new DataGridView();
            tabFinalizadas = new TabPage();
            dgvOrdenesFinalizadas = new DataGridView();
            label2 = new Label();
            label8 = new Label();
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
            btnRegresar = new Button();
            panel2 = new Panel();
            chbProdEspecial = new CheckBox();
            chbLinea = new CheckBox();
            btnFirmar = new Button();
            txbCantidad = new TextBox();
            lblClave2 = new Label();
            lblFolio = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            pnlInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudesFabricacion).BeginInit();
            tabControl1.SuspendLayout();
            tabActivas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenesActivas).BeginInit();
            tabFinalizadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenesFinalizadas).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(25, 31);
            label1.Name = "label1";
            label1.Size = new Size(442, 44);
            label1.TabIndex = 3;
            label1.Text = "ORDEN DE PRODUCCIÓN";
            // 
            // pnlInicio
            // 
            pnlInicio.BackColor = Color.FromArgb(3, 42, 76);
            pnlInicio.Controls.Add(dgvSolicitudesFabricacion);
            pnlInicio.Controls.Add(tabControl1);
            pnlInicio.Controls.Add(label2);
            pnlInicio.Controls.Add(label8);
            pnlInicio.Location = new Point(25, 572);
            pnlInicio.Name = "pnlInicio";
            pnlInicio.Size = new Size(1285, 231);
            pnlInicio.TabIndex = 21;
            // 
            // dgvSolicitudesFabricacion
            // 
            dgvSolicitudesFabricacion.AllowUserToAddRows = false;
            dgvSolicitudesFabricacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSolicitudesFabricacion.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvSolicitudesFabricacion.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle25.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = Color.White;
            dataGridViewCellStyle25.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            dataGridViewCellStyle25.ForeColor = Color.Black;
            dataGridViewCellStyle25.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle25.SelectionForeColor = Color.White;
            dataGridViewCellStyle25.WrapMode = DataGridViewTriState.True;
            dgvSolicitudesFabricacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            dgvSolicitudesFabricacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle26.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle26.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle26.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle26.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = DataGridViewTriState.False;
            dgvSolicitudesFabricacion.DefaultCellStyle = dataGridViewCellStyle26;
            dgvSolicitudesFabricacion.GridColor = SystemColors.ActiveCaptionText;
            dgvSolicitudesFabricacion.Location = new Point(32, 49);
            dgvSolicitudesFabricacion.Name = "dgvSolicitudesFabricacion";
            dgvSolicitudesFabricacion.ReadOnly = true;
            dataGridViewCellStyle27.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle27.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle27.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle27.SelectionForeColor = Color.White;
            dataGridViewCellStyle27.WrapMode = DataGridViewTriState.True;
            dgvSolicitudesFabricacion.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            dgvSolicitudesFabricacion.RowHeadersVisible = false;
            dataGridViewCellStyle28.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = Color.White;
            dataGridViewCellStyle28.Font = new Font("Montserrat", 11.25F);
            dataGridViewCellStyle28.ForeColor = Color.Black;
            dataGridViewCellStyle28.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle28.SelectionForeColor = Color.White;
            dgvSolicitudesFabricacion.RowsDefaultCellStyle = dataGridViewCellStyle28;
            dgvSolicitudesFabricacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSolicitudesFabricacion.Size = new Size(1198, 269);
            dgvSolicitudesFabricacion.TabIndex = 51;
            dgvSolicitudesFabricacion.CellDoubleClick += dgvSolicitudesFabricacion_CellDoubleClick;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabActivas);
            tabControl1.Controls.Add(tabFinalizadas);
            tabControl1.Location = new Point(32, 379);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1224, 313);
            tabControl1.TabIndex = 23;
            // 
            // tabActivas
            // 
            tabActivas.BackColor = Color.FromArgb(3, 42, 76);
            tabActivas.Controls.Add(dgvOrdenesActivas);
            tabActivas.Location = new Point(4, 24);
            tabActivas.Name = "tabActivas";
            tabActivas.Padding = new Padding(3);
            tabActivas.Size = new Size(1216, 285);
            tabActivas.TabIndex = 1;
            tabActivas.Text = "Activas";
            // 
            // dgvOrdenesActivas
            // 
            dgvOrdenesActivas.AllowUserToAddRows = false;
            dgvOrdenesActivas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenesActivas.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvOrdenesActivas.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle29.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = Color.White;
            dataGridViewCellStyle29.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            dataGridViewCellStyle29.ForeColor = Color.Black;
            dataGridViewCellStyle29.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle29.SelectionForeColor = Color.White;
            dataGridViewCellStyle29.WrapMode = DataGridViewTriState.True;
            dgvOrdenesActivas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            dgvOrdenesActivas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle30.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle30.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle30.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle30.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = DataGridViewTriState.False;
            dgvOrdenesActivas.DefaultCellStyle = dataGridViewCellStyle30;
            dgvOrdenesActivas.GridColor = SystemColors.ActiveCaptionText;
            dgvOrdenesActivas.Location = new Point(12, 9);
            dgvOrdenesActivas.Name = "dgvOrdenesActivas";
            dgvOrdenesActivas.ReadOnly = true;
            dataGridViewCellStyle31.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle31.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle31.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle31.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle31.SelectionForeColor = Color.White;
            dataGridViewCellStyle31.WrapMode = DataGridViewTriState.True;
            dgvOrdenesActivas.RowHeadersDefaultCellStyle = dataGridViewCellStyle31;
            dgvOrdenesActivas.RowHeadersVisible = false;
            dataGridViewCellStyle32.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle32.BackColor = Color.White;
            dataGridViewCellStyle32.Font = new Font("Montserrat", 11.25F);
            dataGridViewCellStyle32.ForeColor = Color.Black;
            dataGridViewCellStyle32.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle32.SelectionForeColor = Color.White;
            dgvOrdenesActivas.RowsDefaultCellStyle = dataGridViewCellStyle32;
            dgvOrdenesActivas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenesActivas.Size = new Size(1198, 269);
            dgvOrdenesActivas.TabIndex = 42;
            // 
            // tabFinalizadas
            // 
            tabFinalizadas.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabFinalizadas.Controls.Add(dgvOrdenesFinalizadas);
            tabFinalizadas.Location = new Point(4, 24);
            tabFinalizadas.Name = "tabFinalizadas";
            tabFinalizadas.Size = new Size(1216, 285);
            tabFinalizadas.TabIndex = 2;
            tabFinalizadas.Text = "Finalizadas";
            tabFinalizadas.UseVisualStyleBackColor = true;
            // 
            // dgvOrdenesFinalizadas
            // 
            dgvOrdenesFinalizadas.AllowUserToAddRows = false;
            dgvOrdenesFinalizadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenesFinalizadas.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvOrdenesFinalizadas.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle33.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle33.BackColor = Color.White;
            dataGridViewCellStyle33.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            dataGridViewCellStyle33.ForeColor = Color.Black;
            dataGridViewCellStyle33.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle33.SelectionForeColor = Color.White;
            dataGridViewCellStyle33.WrapMode = DataGridViewTriState.True;
            dgvOrdenesFinalizadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle33;
            dgvOrdenesFinalizadas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle34.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle34.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle34.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle34.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = DataGridViewTriState.False;
            dgvOrdenesFinalizadas.DefaultCellStyle = dataGridViewCellStyle34;
            dgvOrdenesFinalizadas.GridColor = SystemColors.ActiveCaptionText;
            dgvOrdenesFinalizadas.Location = new Point(9, 7);
            dgvOrdenesFinalizadas.Name = "dgvOrdenesFinalizadas";
            dgvOrdenesFinalizadas.ReadOnly = true;
            dataGridViewCellStyle35.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle35.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle35.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle35.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle35.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle35.SelectionForeColor = Color.White;
            dataGridViewCellStyle35.WrapMode = DataGridViewTriState.True;
            dgvOrdenesFinalizadas.RowHeadersDefaultCellStyle = dataGridViewCellStyle35;
            dgvOrdenesFinalizadas.RowHeadersVisible = false;
            dataGridViewCellStyle36.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle36.BackColor = Color.White;
            dataGridViewCellStyle36.Font = new Font("Montserrat", 11.25F);
            dataGridViewCellStyle36.ForeColor = Color.Black;
            dataGridViewCellStyle36.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle36.SelectionForeColor = Color.White;
            dgvOrdenesFinalizadas.RowsDefaultCellStyle = dataGridViewCellStyle36;
            dgvOrdenesFinalizadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenesFinalizadas.Size = new Size(1198, 269);
            dgvOrdenesFinalizadas.TabIndex = 50;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 14F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(32, 345);
            label2.Name = "label2";
            label2.Size = new Size(290, 26);
            label2.TabIndex = 22;
            label2.Text = "ORDENES DE PRODUCCION";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 14F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(32, 16);
            label8.Name = "label8";
            label8.Size = new Size(325, 26);
            label8.TabIndex = 21;
            label8.Text = "SOLICITUDES DE FABRICACION";
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
            panel1.Location = new Point(25, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(432, 285);
            panel1.TabIndex = 22;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.BackColor = Color.Transparent;
            lblCantidad.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblCantidad.ForeColor = Color.White;
            lblCantidad.Location = new Point(111, 131);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(71, 22);
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
            lblClave.Size = new Size(71, 22);
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
            lblSolicitante.Size = new Size(71, 22);
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
            lblSolicitudFabricacion.Size = new Size(71, 22);
            lblSolicitudFabricacion.TabIndex = 70;
            lblSolicitudFabricacion.Text = "ERROR";
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
            label6.Size = new Size(59, 22);
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
            label5.Size = new Size(86, 22);
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
            label4.Size = new Size(57, 22);
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
            label3.Size = new Size(96, 22);
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
            label21.Size = new Size(203, 22);
            label21.TabIndex = 65;
            label21.Text = "Solicitud de Fabricacion:";
            // 
            // btnRegresar
            // 
            btnRegresar.BackColor = Color.FromArgb(255, 102, 0);
            btnRegresar.Cursor = Cursors.Hand;
            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnRegresar.ForeColor = Color.White;
            btnRegresar.Location = new Point(1152, 50);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(142, 34);
            btnRegresar.TabIndex = 78;
            btnRegresar.Text = "REGRESAR";
            btnRegresar.UseVisualStyleBackColor = false;
            btnRegresar.Visible = false;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(3, 42, 76);
            panel2.Controls.Add(chbProdEspecial);
            panel2.Controls.Add(chbLinea);
            panel2.Controls.Add(btnFirmar);
            panel2.Controls.Add(txbCantidad);
            panel2.Controls.Add(lblClave2);
            panel2.Controls.Add(lblFolio);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label16);
            panel2.Location = new Point(463, 90);
            panel2.Name = "panel2";
            panel2.Size = new Size(831, 285);
            panel2.TabIndex = 79;
            // 
            // chbProdEspecial
            // 
            chbProdEspecial.AutoSize = true;
            chbProdEspecial.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbProdEspecial.ForeColor = Color.White;
            chbProdEspecial.Location = new Point(531, 91);
            chbProdEspecial.Name = "chbProdEspecial";
            chbProdEspecial.Size = new Size(137, 26);
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
            chbLinea.Location = new Point(435, 91);
            chbLinea.Name = "chbLinea";
            chbLinea.Size = new Size(72, 26);
            chbLinea.TabIndex = 81;
            chbLinea.Text = "Linea";
            chbLinea.UseVisualStyleBackColor = true;
            chbLinea.CheckedChanged += chbLinea_CheckedChanged;
            // 
            // btnFirmar
            // 
            btnFirmar.BackColor = Color.FromArgb(255, 102, 0);
            btnFirmar.Cursor = Cursors.Hand;
            btnFirmar.FlatAppearance.BorderSize = 0;
            btnFirmar.FlatStyle = FlatStyle.Flat;
            btnFirmar.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnFirmar.ForeColor = Color.White;
            btnFirmar.Location = new Point(202, 235);
            btnFirmar.Name = "btnFirmar";
            btnFirmar.Size = new Size(486, 30);
            btnFirmar.TabIndex = 80;
            btnFirmar.Text = "CREAR / FIRMAR";
            btnFirmar.UseVisualStyleBackColor = false;
            btnFirmar.Visible = false;
            // 
            // txbCantidad
            // 
            txbCantidad.Font = new Font("Montserrat", 12F);
            txbCantidad.Location = new Point(121, 92);
            txbCantidad.Name = "txbCantidad";
            txbCantidad.Size = new Size(168, 27);
            txbCantidad.TabIndex = 74;
            // 
            // lblClave2
            // 
            lblClave2.AutoSize = true;
            lblClave2.BackColor = Color.Transparent;
            lblClave2.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblClave2.ForeColor = Color.White;
            lblClave2.Location = new Point(121, 59);
            lblClave2.Name = "lblClave2";
            lblClave2.Size = new Size(71, 22);
            lblClave2.TabIndex = 71;
            lblClave2.Text = "ERROR";
            // 
            // lblFolio
            // 
            lblFolio.AutoSize = true;
            lblFolio.BackColor = Color.Transparent;
            lblFolio.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblFolio.ForeColor = Color.White;
            lblFolio.Location = new Point(674, 25);
            lblFolio.Name = "lblFolio";
            lblFolio.Size = new Size(71, 22);
            lblFolio.TabIndex = 70;
            lblFolio.Text = "ERROR";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 12F);
            label13.ForeColor = Color.White;
            label13.Location = new Point(19, 131);
            label13.Name = "label13";
            label13.Size = new Size(130, 22);
            label13.TabIndex = 68;
            label13.Text = "Fecha Entrega:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Montserrat", 12F);
            label14.ForeColor = Color.White;
            label14.Location = new Point(19, 95);
            label14.Name = "label14";
            label14.Size = new Size(86, 22);
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
            label15.Size = new Size(57, 22);
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
            label16.Size = new Size(51, 22);
            label16.TabIndex = 65;
            label16.Text = "Folio:";
            // 
            // Produccion_OrdenProduccion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(pnlInicio);
            Controls.Add(panel2);
            Controls.Add(btnRegresar);
            Controls.Add(panel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_OrdenProduccion";
            Text = "Produccion_OrdenProduccion";
            Load += Produccion_OrdenProduccion_Load;
            pnlInicio.ResumeLayout(false);
            pnlInicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudesFabricacion).EndInit();
            tabControl1.ResumeLayout(false);
            tabActivas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrdenesActivas).EndInit();
            tabFinalizadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrdenesFinalizadas).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel pnlInicio;
        private Label label2;
        private Label label8;
        private TabControl tabControl1;
        private TabPage tabActivas;
        private DataGridView dgvOrdenesActivas;
        private TabPage tabFinalizadas;
        private DataGridView dgvOrdenesFinalizadas;
        private DataGridView dgvSolicitudesFabricacion;
        private Panel panel1;
        private Label label3;
        private Label label21;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txbNotas;
        private Label lblCantidad;
        private Label lblClave;
        private Label lblSolicitante;
        private Label lblSolicitudFabricacion;
        private Button btnRegresar;
        private Panel panel2;
        private Button btnFirmar;
        private TextBox txbCantidad;
        private Label lblClave2;
        private Label lblFolio;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private CheckBox chbProdEspecial;
        private CheckBox chbLinea;
    }
}