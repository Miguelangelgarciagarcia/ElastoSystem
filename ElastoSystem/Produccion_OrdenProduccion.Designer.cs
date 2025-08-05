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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle26 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle27 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle28 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle29 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle30 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle31 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle32 = new DataGridViewCellStyle();
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
            btnDatosProdEspecial = new Button();
            txbEspecificacion = new TextBox();
            txbOC = new TextBox();
            txbCliente = new TextBox();
            lblFolioOriginal = new Label();
            dtpFechaEntrega = new DateTimePicker();
            lblDescripcion = new Label();
            label7 = new Label();
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
            panel3 = new Panel();
            dgvProcesosCriticos = new DataGridView();
            Operacion = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            CantidadUnidad = new DataGridViewTextBoxColumn();
            OT = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Estatus = new DataGridViewTextBoxColumn();
            cmsOP = new ContextMenuStrip(components);
            AdminOP = new ToolStripMenuItem();
            txbFamilia = new TextBox();
            pnlInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudesFabricacion).BeginInit();
            tabControl1.SuspendLayout();
            tabActivas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenesActivas).BeginInit();
            tabFinalizadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenesFinalizadas).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProcesosCriticos).BeginInit();
            cmsOP.SuspendLayout();
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
            label1.Size = new Size(568, 44);
            label1.TabIndex = 3;
            label1.Text = "CREAR ORDEN DE PRODUCCIÓN";
            // 
            // pnlInicio
            // 
            pnlInicio.BackColor = Color.FromArgb(3, 42, 76);
            pnlInicio.Controls.Add(dgvSolicitudesFabricacion);
            pnlInicio.Controls.Add(tabControl1);
            pnlInicio.Controls.Add(label2);
            pnlInicio.Controls.Add(label8);
            pnlInicio.Location = new Point(25, 90);
            pnlInicio.Name = "pnlInicio";
            pnlInicio.Size = new Size(1278, 729);
            pnlInicio.TabIndex = 21;
            // 
            // dgvSolicitudesFabricacion
            // 
            dgvSolicitudesFabricacion.AllowUserToAddRows = false;
            dgvSolicitudesFabricacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSolicitudesFabricacion.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvSolicitudesFabricacion.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = Color.White;
            dataGridViewCellStyle17.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            dataGridViewCellStyle17.ForeColor = Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle17.SelectionForeColor = Color.White;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            dgvSolicitudesFabricacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dgvSolicitudesFabricacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle18.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle18.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.False;
            dgvSolicitudesFabricacion.DefaultCellStyle = dataGridViewCellStyle18;
            dgvSolicitudesFabricacion.GridColor = SystemColors.ActiveCaptionText;
            dgvSolicitudesFabricacion.Location = new Point(32, 64);
            dgvSolicitudesFabricacion.Name = "dgvSolicitudesFabricacion";
            dgvSolicitudesFabricacion.ReadOnly = true;
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle19.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle19.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle19.SelectionForeColor = Color.White;
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
            dgvSolicitudesFabricacion.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dgvSolicitudesFabricacion.RowHeadersVisible = false;
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = Color.White;
            dataGridViewCellStyle20.Font = new Font("Montserrat", 11.25F);
            dataGridViewCellStyle20.ForeColor = Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle20.SelectionForeColor = Color.White;
            dgvSolicitudesFabricacion.RowsDefaultCellStyle = dataGridViewCellStyle20;
            dgvSolicitudesFabricacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSolicitudesFabricacion.Size = new Size(1198, 254);
            dgvSolicitudesFabricacion.TabIndex = 51;
            dgvSolicitudesFabricacion.CellDoubleClick += dgvSolicitudesFabricacion_CellDoubleClick;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabActivas);
            tabControl1.Controls.Add(tabFinalizadas);
            tabControl1.Location = new Point(32, 371);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1224, 342);
            tabControl1.TabIndex = 23;
            // 
            // tabActivas
            // 
            tabActivas.BackColor = Color.FromArgb(3, 42, 76);
            tabActivas.Controls.Add(dgvOrdenesActivas);
            tabActivas.Location = new Point(4, 24);
            tabActivas.Name = "tabActivas";
            tabActivas.Padding = new Padding(3);
            tabActivas.Size = new Size(1216, 314);
            tabActivas.TabIndex = 1;
            tabActivas.Text = "Activas";
            // 
            // dgvOrdenesActivas
            // 
            dgvOrdenesActivas.AllowUserToAddRows = false;
            dgvOrdenesActivas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenesActivas.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvOrdenesActivas.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = Color.White;
            dataGridViewCellStyle21.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            dataGridViewCellStyle21.ForeColor = Color.Black;
            dataGridViewCellStyle21.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle21.SelectionForeColor = Color.White;
            dataGridViewCellStyle21.WrapMode = DataGridViewTriState.True;
            dgvOrdenesActivas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            dgvOrdenesActivas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle22.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle22.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = DataGridViewTriState.False;
            dgvOrdenesActivas.DefaultCellStyle = dataGridViewCellStyle22;
            dgvOrdenesActivas.GridColor = SystemColors.ActiveCaptionText;
            dgvOrdenesActivas.Location = new Point(10, 6);
            dgvOrdenesActivas.Name = "dgvOrdenesActivas";
            dgvOrdenesActivas.ReadOnly = true;
            dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle23.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle23.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle23.SelectionForeColor = Color.White;
            dataGridViewCellStyle23.WrapMode = DataGridViewTriState.True;
            dgvOrdenesActivas.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            dgvOrdenesActivas.RowHeadersVisible = false;
            dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = Color.White;
            dataGridViewCellStyle24.Font = new Font("Montserrat", 11.25F);
            dataGridViewCellStyle24.ForeColor = Color.Black;
            dataGridViewCellStyle24.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle24.SelectionForeColor = Color.White;
            dgvOrdenesActivas.RowsDefaultCellStyle = dataGridViewCellStyle24;
            dgvOrdenesActivas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenesActivas.Size = new Size(1198, 299);
            dgvOrdenesActivas.TabIndex = 42;
            dgvOrdenesActivas.CellDoubleClick += dgvOrdenesActivas_CellDoubleClick;
            dgvOrdenesActivas.MouseClick += dgvOrdenesActivas_MouseClick;
            // 
            // tabFinalizadas
            // 
            tabFinalizadas.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabFinalizadas.Controls.Add(dgvOrdenesFinalizadas);
            tabFinalizadas.Location = new Point(4, 24);
            tabFinalizadas.Name = "tabFinalizadas";
            tabFinalizadas.Size = new Size(1216, 314);
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
            dataGridViewCellStyle25.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = Color.White;
            dataGridViewCellStyle25.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            dataGridViewCellStyle25.ForeColor = Color.Black;
            dataGridViewCellStyle25.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle25.SelectionForeColor = Color.White;
            dataGridViewCellStyle25.WrapMode = DataGridViewTriState.True;
            dgvOrdenesFinalizadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            dgvOrdenesFinalizadas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle26.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle26.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle26.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle26.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = DataGridViewTriState.False;
            dgvOrdenesFinalizadas.DefaultCellStyle = dataGridViewCellStyle26;
            dgvOrdenesFinalizadas.GridColor = SystemColors.ActiveCaptionText;
            dgvOrdenesFinalizadas.Location = new Point(9, 7);
            dgvOrdenesFinalizadas.Name = "dgvOrdenesFinalizadas";
            dgvOrdenesFinalizadas.ReadOnly = true;
            dataGridViewCellStyle27.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle27.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle27.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle27.SelectionForeColor = Color.White;
            dataGridViewCellStyle27.WrapMode = DataGridViewTriState.True;
            dgvOrdenesFinalizadas.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            dgvOrdenesFinalizadas.RowHeadersVisible = false;
            dataGridViewCellStyle28.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = Color.White;
            dataGridViewCellStyle28.Font = new Font("Montserrat", 11.25F);
            dataGridViewCellStyle28.ForeColor = Color.Black;
            dataGridViewCellStyle28.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle28.SelectionForeColor = Color.White;
            dgvOrdenesFinalizadas.RowsDefaultCellStyle = dataGridViewCellStyle28;
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
            label2.Location = new Point(32, 339);
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
            label8.Location = new Point(32, 21);
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
            panel2.Controls.Add(btnDatosProdEspecial);
            panel2.Controls.Add(txbEspecificacion);
            panel2.Controls.Add(txbOC);
            panel2.Controls.Add(txbCliente);
            panel2.Controls.Add(lblFolioOriginal);
            panel2.Controls.Add(dtpFechaEntrega);
            panel2.Controls.Add(lblDescripcion);
            panel2.Controls.Add(label7);
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
            // btnDatosProdEspecial
            // 
            btnDatosProdEspecial.BackColor = Color.FromArgb(255, 102, 0);
            btnDatosProdEspecial.Cursor = Cursors.Hand;
            btnDatosProdEspecial.FlatAppearance.BorderSize = 0;
            btnDatosProdEspecial.FlatStyle = FlatStyle.Flat;
            btnDatosProdEspecial.Font = new Font("Montserrat", 8F, FontStyle.Bold);
            btnDatosProdEspecial.ForeColor = Color.White;
            btnDatosProdEspecial.Location = new Point(640, 131);
            btnDatosProdEspecial.Name = "btnDatosProdEspecial";
            btnDatosProdEspecial.Size = new Size(152, 26);
            btnDatosProdEspecial.TabIndex = 91;
            btnDatosProdEspecial.Text = "Datos de Prod Especial";
            btnDatosProdEspecial.UseVisualStyleBackColor = false;
            btnDatosProdEspecial.Visible = false;
            btnDatosProdEspecial.Click += btnDatosProdEspecial_Click;
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
            // lblFolioOriginal
            // 
            lblFolioOriginal.AutoSize = true;
            lblFolioOriginal.BackColor = Color.Transparent;
            lblFolioOriginal.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblFolioOriginal.ForeColor = Color.White;
            lblFolioOriginal.Location = new Point(674, 59);
            lblFolioOriginal.Name = "lblFolioOriginal";
            lblFolioOriginal.Size = new Size(71, 22);
            lblFolioOriginal.TabIndex = 86;
            lblFolioOriginal.Text = "ERROR";
            lblFolioOriginal.Visible = false;
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
            lblDescripcion.Size = new Size(71, 22);
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
            label7.Size = new Size(108, 22);
            label7.TabIndex = 83;
            label7.Text = "Descripcion:";
            // 
            // chbProdEspecial
            // 
            chbProdEspecial.AutoSize = true;
            chbProdEspecial.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chbProdEspecial.ForeColor = Color.White;
            chbProdEspecial.Location = new Point(497, 133);
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
            chbLinea.Location = new Point(401, 133);
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
            btnFirmar.Location = new Point(202, 233);
            btnFirmar.Name = "btnFirmar";
            btnFirmar.Size = new Size(486, 30);
            btnFirmar.TabIndex = 80;
            btnFirmar.Text = "CREAR / FIRMAR";
            btnFirmar.UseVisualStyleBackColor = false;
            btnFirmar.Click += btnFirmar_Click;
            // 
            // txbCantidad
            // 
            txbCantidad.Font = new Font("Montserrat", 12F);
            txbCantidad.Location = new Point(121, 134);
            txbCantidad.Name = "txbCantidad";
            txbCantidad.Size = new Size(168, 27);
            txbCantidad.TabIndex = 74;
            txbCantidad.KeyDown += txbCantidad_KeyDown;
            txbCantidad.KeyPress += txbCantidad_KeyPress;
            txbCantidad.Leave += txbCantidad_Leave;
            // 
            // lblClave2
            // 
            lblClave2.AutoSize = true;
            lblClave2.BackColor = Color.Transparent;
            lblClave2.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblClave2.ForeColor = Color.White;
            lblClave2.Location = new Point(82, 59);
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
            label13.Location = new Point(19, 173);
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
            label14.Location = new Point(19, 137);
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
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(3, 42, 76);
            panel3.Controls.Add(dgvProcesosCriticos);
            panel3.Location = new Point(25, 388);
            panel3.Name = "panel3";
            panel3.Size = new Size(1269, 431);
            panel3.TabIndex = 80;
            // 
            // dgvProcesosCriticos
            // 
            dgvProcesosCriticos.AllowUserToAddRows = false;
            dgvProcesosCriticos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProcesosCriticos.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvProcesosCriticos.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle29.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = Color.White;
            dataGridViewCellStyle29.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            dataGridViewCellStyle29.ForeColor = Color.Black;
            dataGridViewCellStyle29.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle29.SelectionForeColor = Color.White;
            dataGridViewCellStyle29.WrapMode = DataGridViewTriState.True;
            dgvProcesosCriticos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            dgvProcesosCriticos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProcesosCriticos.Columns.AddRange(new DataGridViewColumn[] { Operacion, Descripcion, CantidadUnidad, OT, Cantidad, Estatus });
            dataGridViewCellStyle30.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle30.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle30.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle30.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = DataGridViewTriState.False;
            dgvProcesosCriticos.DefaultCellStyle = dataGridViewCellStyle30;
            dgvProcesosCriticos.GridColor = SystemColors.ActiveCaptionText;
            dgvProcesosCriticos.Location = new Point(19, 16);
            dgvProcesosCriticos.Name = "dgvProcesosCriticos";
            dataGridViewCellStyle31.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle31.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle31.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle31.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle31.SelectionForeColor = Color.White;
            dataGridViewCellStyle31.WrapMode = DataGridViewTriState.True;
            dgvProcesosCriticos.RowHeadersDefaultCellStyle = dataGridViewCellStyle31;
            dgvProcesosCriticos.RowHeadersVisible = false;
            dataGridViewCellStyle32.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle32.BackColor = Color.White;
            dataGridViewCellStyle32.Font = new Font("Montserrat", 11.25F);
            dataGridViewCellStyle32.ForeColor = Color.Black;
            dataGridViewCellStyle32.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle32.SelectionForeColor = Color.White;
            dgvProcesosCriticos.RowsDefaultCellStyle = dataGridViewCellStyle32;
            dgvProcesosCriticos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProcesosCriticos.Size = new Size(1225, 395);
            dgvProcesosCriticos.TabIndex = 52;
            // 
            // Operacion
            // 
            Operacion.HeaderText = "Operacion";
            Operacion.Name = "Operacion";
            // 
            // Descripcion
            // 
            Descripcion.HeaderText = "Descripcion";
            Descripcion.Name = "Descripcion";
            // 
            // CantidadUnidad
            // 
            CantidadUnidad.HeaderText = "CantidadUnidad";
            CantidadUnidad.Name = "CantidadUnidad";
            CantidadUnidad.Visible = false;
            // 
            // OT
            // 
            OT.HeaderText = "OT";
            OT.Name = "OT";
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            // 
            // Estatus
            // 
            Estatus.HeaderText = "Estatus";
            Estatus.Name = "Estatus";
            Estatus.Visible = false;
            // 
            // cmsOP
            // 
            cmsOP.Items.AddRange(new ToolStripItem[] { AdminOP });
            cmsOP.Name = "cmsOP";
            cmsOP.Size = new Size(253, 26);
            // 
            // AdminOP
            // 
            AdminOP.Name = "AdminOP";
            AdminOP.Size = new Size(252, 22);
            AdminOP.Text = "Administrar Orden de Producción";
            AdminOP.Click += AdminOP_Click;
            // 
            // txbFamilia
            // 
            txbFamilia.Font = new Font("Montserrat", 12F);
            txbFamilia.Location = new Point(960, 45);
            txbFamilia.Name = "txbFamilia";
            txbFamilia.Size = new Size(168, 27);
            txbFamilia.TabIndex = 88;
            txbFamilia.Visible = false;
            // 
            // Produccion_OrdenProduccion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(txbFamilia);
            Controls.Add(pnlInicio);
            Controls.Add(panel3);
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
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProcesosCriticos).EndInit();
            cmsOP.ResumeLayout(false);
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
        private Label lblDescripcion;
        private Label label7;
        private DateTimePicker dtpFechaEntrega;
        private Label lblFolioOriginal;
        private Panel panel3;
        private DataGridView dgvProcesosCriticos;
        private TextBox txbEspecificacion;
        private TextBox txbOC;
        private TextBox txbCliente;
        private ContextMenuStrip cmsOP;
        private ToolStripMenuItem AdminOP;
        private Button btnDatosProdEspecial;
        private TextBox txbFamilia;
        private DataGridViewTextBoxColumn Operacion;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn CantidadUnidad;
        private DataGridViewTextBoxColumn OT;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Estatus;
    }
}