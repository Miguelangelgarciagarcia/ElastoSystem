namespace ElastoSystem
{
    partial class Almacen_Fabricacion
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            label1 = new Label();
            pnlAlmacen = new Panel();
            btnSincronizar = new Button();
            lblSincronizacion = new Label();
            dgvProductosSAE2 = new DataGridView();
            btnCerrar = new Button();
            dgvProductosSAE = new DataGridView();
            label9 = new Label();
            btnAbrir = new Button();
            bSAspelSAE = new BindingSource(components);
            cbProductos = new ComboBox();
            label2 = new Label();
            btnEnviarSolicitud = new Button();
            label3 = new Label();
            label5 = new Label();
            label4 = new Label();
            txbCantidad = new TextBox();
            txbNotas = new TextBox();
            panel1 = new Panel();
            btnNuevo = new Button();
            lblMeses = new Label();
            label8 = new Label();
            label7 = new Label();
            lbl4Meses = new Label();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnAgregar = new Button();
            lbl3Meses = new Label();
            lbl2Meses = new Label();
            lbl1Mes = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            lblCantidadActual = new Label();
            label6 = new Label();
            panel2 = new Panel();
            lblFolioOriginal = new Label();
            lblFecha = new Label();
            lblFolio = new Label();
            label21 = new Label();
            label22 = new Label();
            label17 = new Label();
            dgvPartidas = new DataGridView();
            Clave = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Notas = new DataGridViewTextBoxColumn();
            label18 = new Label();
            panel3 = new Panel();
            label25 = new Label();
            button4 = new Button();
            label23 = new Label();
            dgvSolicitudes = new DataGridView();
            pnlAlmacen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductosSAE2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductosSAE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bSAspelSAE).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPartidas).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(43, 37);
            label1.Name = "label1";
            label1.Size = new Size(500, 44);
            label1.TabIndex = 1;
            label1.Text = "SOLICITUD DE FABRICACION";
            // 
            // pnlAlmacen
            // 
            pnlAlmacen.BackColor = Color.FromArgb(3, 42, 76);
            pnlAlmacen.Controls.Add(btnSincronizar);
            pnlAlmacen.Controls.Add(lblSincronizacion);
            pnlAlmacen.Controls.Add(dgvProductosSAE2);
            pnlAlmacen.Controls.Add(btnCerrar);
            pnlAlmacen.Controls.Add(dgvProductosSAE);
            pnlAlmacen.Controls.Add(label9);
            pnlAlmacen.Location = new Point(36, 84);
            pnlAlmacen.Name = "pnlAlmacen";
            pnlAlmacen.Size = new Size(1277, 735);
            pnlAlmacen.TabIndex = 19;
            pnlAlmacen.Visible = false;
            // 
            // btnSincronizar
            // 
            btnSincronizar.BackColor = Color.FromArgb(255, 102, 0);
            btnSincronizar.Cursor = Cursors.Hand;
            btnSincronizar.FlatAppearance.BorderSize = 0;
            btnSincronizar.FlatStyle = FlatStyle.Flat;
            btnSincronizar.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnSincronizar.ForeColor = Color.White;
            btnSincronizar.Location = new Point(19, 685);
            btnSincronizar.Name = "btnSincronizar";
            btnSincronizar.Size = new Size(119, 27);
            btnSincronizar.TabIndex = 61;
            btnSincronizar.Text = "Sincronizar";
            btnSincronizar.UseVisualStyleBackColor = false;
            btnSincronizar.Click += btnSincronizar_Click;
            // 
            // lblSincronizacion
            // 
            lblSincronizacion.AutoSize = true;
            lblSincronizacion.BackColor = Color.Transparent;
            lblSincronizacion.Font = new Font("Montserrat", 9F);
            lblSincronizacion.ForeColor = Color.White;
            lblSincronizacion.Location = new Point(975, 685);
            lblSincronizacion.Name = "lblSincronizacion";
            lblSincronizacion.Size = new Size(10, 16);
            lblSincronizacion.TabIndex = 60;
            lblSincronizacion.Text = ".";
            lblSincronizacion.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvProductosSAE2
            // 
            dgvProductosSAE2.AllowUserToAddRows = false;
            dgvProductosSAE2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductosSAE2.Location = new Point(303, 23);
            dgvProductosSAE2.Name = "dgvProductosSAE2";
            dgvProductosSAE2.Size = new Size(21, 24);
            dgvProductosSAE2.TabIndex = 59;
            dgvProductosSAE2.Visible = false;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(255, 102, 0);
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(1090, 18);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(151, 35);
            btnCerrar.TabIndex = 19;
            btnCerrar.Text = "CERRAR";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // dgvProductosSAE
            // 
            dgvProductosSAE.AllowUserToAddRows = false;
            dgvProductosSAE.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductosSAE.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProductosSAE.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductosSAE.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductosSAE.Location = new Point(19, 59);
            dgvProductosSAE.Name = "dgvProductosSAE";
            dgvProductosSAE.ReadOnly = true;
            dgvProductosSAE.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvProductosSAE.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvProductosSAE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductosSAE.Size = new Size(1222, 614);
            dgvProductosSAE.TabIndex = 18;
            dgvProductosSAE.CellFormatting += dgvProductosSAE_CellFormatting;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(19, 17);
            label9.Name = "label9";
            label9.Size = new Size(263, 30);
            label9.TabIndex = 17;
            label9.Text = "ALMACEN ASPEL SAE";
            // 
            // btnAbrir
            // 
            btnAbrir.BackColor = Color.FromArgb(255, 102, 0);
            btnAbrir.Cursor = Cursors.Hand;
            btnAbrir.FlatAppearance.BorderSize = 0;
            btnAbrir.FlatStyle = FlatStyle.Flat;
            btnAbrir.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnAbrir.ForeColor = Color.White;
            btnAbrir.Location = new Point(490, 14);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(225, 35);
            btnAbrir.TabIndex = 20;
            btnAbrir.Text = "ABRIR ALMACEN SAE";
            btnAbrir.UseVisualStyleBackColor = false;
            btnAbrir.Click += btnAbrir_Click;
            // 
            // cbProductos
            // 
            cbProductos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbProductos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbProductos.Font = new Font("Montserrat", 12F);
            cbProductos.FormattingEnabled = true;
            cbProductos.Location = new Point(80, 19);
            cbProductos.Name = "cbProductos";
            cbProductos.Size = new Size(261, 30);
            cbProductos.TabIndex = 22;
            cbProductos.SelectedIndexChanged += cbProductos_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 22);
            label2.Name = "label2";
            label2.Size = new Size(57, 22);
            label2.TabIndex = 21;
            label2.Text = "Clave:";
            // 
            // btnEnviarSolicitud
            // 
            btnEnviarSolicitud.BackColor = Color.FromArgb(255, 102, 0);
            btnEnviarSolicitud.Cursor = Cursors.Hand;
            btnEnviarSolicitud.FlatAppearance.BorderSize = 0;
            btnEnviarSolicitud.FlatStyle = FlatStyle.Flat;
            btnEnviarSolicitud.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnEnviarSolicitud.ForeColor = Color.White;
            btnEnviarSolicitud.Location = new Point(449, 382);
            btnEnviarSolicitud.Name = "btnEnviarSolicitud";
            btnEnviarSolicitud.Size = new Size(265, 34);
            btnEnviarSolicitud.TabIndex = 43;
            btnEnviarSolicitud.Text = "ENVIAR SOLICITUD";
            btnEnviarSolicitud.UseVisualStyleBackColor = false;
            btnEnviarSolicitud.Click += btnEnviarSolicitud_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(20, 272);
            label3.Name = "label3";
            label3.Size = new Size(59, 22);
            label3.TabIndex = 42;
            label3.Text = "Notas:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 12F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(12, 68);
            label5.Name = "label5";
            label5.Size = new Size(140, 22);
            label5.TabIndex = 46;
            label5.Text = "Cantidad Actual:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(16, 229);
            label4.Name = "label4";
            label4.Size = new Size(243, 22);
            label4.TabIndex = 48;
            label4.Text = "Cantidad Sugerida a Fabricar:";
            // 
            // txbCantidad
            // 
            txbCantidad.Font = new Font("Montserrat", 12F);
            txbCantidad.Location = new Point(275, 226);
            txbCantidad.Name = "txbCantidad";
            txbCantidad.Size = new Size(213, 27);
            txbCantidad.TabIndex = 49;
            txbCantidad.KeyPress += txbCantidad_KeyPress;
            // 
            // txbNotas
            // 
            txbNotas.Font = new Font("Montserrat", 12F);
            txbNotas.Location = new Point(89, 269);
            txbNotas.Multiline = true;
            txbNotas.Name = "txbNotas";
            txbNotas.Size = new Size(399, 71);
            txbNotas.TabIndex = 50;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(btnNuevo);
            panel1.Controls.Add(lblMeses);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(lbl4Meses);
            panel1.Controls.Add(btnActualizar);
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(btnAgregar);
            panel1.Controls.Add(lbl3Meses);
            panel1.Controls.Add(lbl2Meses);
            panel1.Controls.Add(lbl1Mes);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(txbNotas);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txbCantidad);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lblCantidadActual);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cbProductos);
            panel1.Location = new Point(43, 87);
            panel1.Name = "panel1";
            panel1.Size = new Size(513, 430);
            panel1.TabIndex = 51;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(255, 102, 0);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(365, 19);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(123, 34);
            btnNuevo.TabIndex = 75;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Visible = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // lblMeses
            // 
            lblMeses.AutoSize = true;
            lblMeses.BackColor = Color.Transparent;
            lblMeses.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblMeses.ForeColor = Color.White;
            lblMeses.Location = new Point(406, 68);
            lblMeses.Name = "lblMeses";
            lblMeses.Size = new Size(46, 22);
            lblMeses.TabIndex = 74;
            lblMeses.Text = "------";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 12F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(336, 68);
            label8.Name = "label8";
            label8.Size = new Size(64, 22);
            label8.TabIndex = 73;
            label8.Text = "Meses:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 12F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(275, 148);
            label7.Name = "label7";
            label7.Size = new Size(141, 22);
            label7.TabIndex = 72;
            label7.Text = "SobreInventario:";
            label7.Click += label7_Click;
            // 
            // lbl4Meses
            // 
            lbl4Meses.AutoSize = true;
            lbl4Meses.BackColor = Color.Transparent;
            lbl4Meses.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lbl4Meses.ForeColor = Color.White;
            lbl4Meses.Location = new Point(430, 148);
            lbl4Meses.Name = "lbl4Meses";
            lbl4Meses.Size = new Size(46, 22);
            lbl4Meses.TabIndex = 71;
            lbl4Meses.Text = "------";
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(255, 102, 0);
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(189, 370);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(152, 34);
            btnActualizar.TabIndex = 70;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Visible = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(255, 102, 0);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(31, 370);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(123, 34);
            btnEliminar.TabIndex = 69;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Visible = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(255, 102, 0);
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(365, 370);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(123, 34);
            btnAgregar.TabIndex = 52;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lbl3Meses
            // 
            lbl3Meses.AutoSize = true;
            lbl3Meses.BackColor = Color.Transparent;
            lbl3Meses.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lbl3Meses.ForeColor = Color.White;
            lbl3Meses.Location = new Point(178, 172);
            lbl3Meses.Name = "lbl3Meses";
            lbl3Meses.Size = new Size(46, 22);
            lbl3Meses.TabIndex = 68;
            lbl3Meses.Text = "------";
            // 
            // lbl2Meses
            // 
            lbl2Meses.AutoSize = true;
            lbl2Meses.BackColor = Color.Transparent;
            lbl2Meses.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lbl2Meses.ForeColor = Color.White;
            lbl2Meses.Location = new Point(178, 145);
            lbl2Meses.Name = "lbl2Meses";
            lbl2Meses.Size = new Size(46, 22);
            lbl2Meses.TabIndex = 67;
            lbl2Meses.Text = "------";
            // 
            // lbl1Mes
            // 
            lbl1Mes.AutoSize = true;
            lbl1Mes.BackColor = Color.Transparent;
            lbl1Mes.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lbl1Mes.ForeColor = Color.White;
            lbl1Mes.Location = new Point(178, 119);
            lbl1Mes.Name = "lbl1Mes";
            lbl1Mes.Size = new Size(46, 22);
            lbl1Mes.TabIndex = 66;
            lbl1Mes.Text = "------";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 12F);
            label13.ForeColor = Color.White;
            label13.Location = new Point(23, 169);
            label13.Name = "label13";
            label13.Size = new Size(77, 22);
            label13.TabIndex = 65;
            label13.Text = "3 Meses:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Montserrat", 12F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(22, 145);
            label12.Name = "label12";
            label12.Size = new Size(77, 22);
            label12.TabIndex = 64;
            label12.Text = "2 Meses:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Montserrat", 12F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(24, 119);
            label11.Name = "label11";
            label11.Size = new Size(56, 22);
            label11.TabIndex = 63;
            label11.Text = "1 Mes:";
            // 
            // lblCantidadActual
            // 
            lblCantidadActual.AutoSize = true;
            lblCantidadActual.BackColor = Color.Transparent;
            lblCantidadActual.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblCantidadActual.ForeColor = Color.White;
            lblCantidadActual.Location = new Point(163, 68);
            lblCantidadActual.Name = "lblCantidadActual";
            lblCantidadActual.Size = new Size(124, 22);
            lblCantidadActual.TabIndex = 62;
            lblCantidadActual.Text = "-------------------";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 9F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(975, 673);
            label6.Name = "label6";
            label6.Size = new Size(10, 16);
            label6.TabIndex = 60;
            label6.Text = ".";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(3, 42, 76);
            panel2.Controls.Add(lblFolioOriginal);
            panel2.Controls.Add(lblFecha);
            panel2.Controls.Add(lblFolio);
            panel2.Controls.Add(label21);
            panel2.Controls.Add(label22);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(dgvPartidas);
            panel2.Controls.Add(btnEnviarSolicitud);
            panel2.Controls.Add(btnAbrir);
            panel2.Controls.Add(label18);
            panel2.Location = new Point(562, 87);
            panel2.Name = "panel2";
            panel2.Size = new Size(733, 430);
            panel2.TabIndex = 52;
            // 
            // lblFolioOriginal
            // 
            lblFolioOriginal.AutoSize = true;
            lblFolioOriginal.BackColor = Color.Transparent;
            lblFolioOriginal.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblFolioOriginal.ForeColor = Color.White;
            lblFolioOriginal.Location = new Point(419, 68);
            lblFolioOriginal.Name = "lblFolioOriginal";
            lblFolioOriginal.Size = new Size(124, 22);
            lblFolioOriginal.TabIndex = 67;
            lblFolioOriginal.Text = "-------------------";
            lblFolioOriginal.Visible = false;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BackColor = Color.Transparent;
            lblFecha.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblFecha.ForeColor = Color.White;
            lblFecha.Location = new Point(96, 61);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(124, 22);
            lblFecha.TabIndex = 66;
            lblFecha.Text = "-------------------";
            // 
            // lblFolio
            // 
            lblFolio.AutoSize = true;
            lblFolio.BackColor = Color.Transparent;
            lblFolio.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblFolio.ForeColor = Color.White;
            lblFolio.Location = new Point(96, 27);
            lblFolio.Name = "lblFolio";
            lblFolio.Size = new Size(124, 22);
            lblFolio.TabIndex = 65;
            lblFolio.Text = "-------------------";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.Transparent;
            label21.Font = new Font("Montserrat", 12F);
            label21.ForeColor = Color.White;
            label21.Location = new Point(24, 27);
            label21.Name = "label21";
            label21.Size = new Size(51, 22);
            label21.TabIndex = 64;
            label21.Text = "Folio:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.Transparent;
            label22.Font = new Font("Montserrat", 12F);
            label22.ForeColor = Color.White;
            label22.Location = new Point(24, 61);
            label22.Name = "label22";
            label22.Size = new Size(62, 22);
            label22.TabIndex = 63;
            label22.Text = "Fecha:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Transparent;
            label17.Font = new Font("Montserrat", 9F);
            label17.ForeColor = Color.White;
            label17.Location = new Point(975, 673);
            label17.Name = "label17";
            label17.Size = new Size(10, 16);
            label17.TabIndex = 60;
            label17.Text = ".";
            label17.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvPartidas
            // 
            dgvPartidas.AllowUserToAddRows = false;
            dgvPartidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPartidas.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPartidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPartidas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPartidas.Columns.AddRange(new DataGridViewColumn[] { Clave, Cantidad, Notas });
            dgvPartidas.Location = new Point(24, 156);
            dgvPartidas.Name = "dgvPartidas";
            dgvPartidas.ReadOnly = true;
            dgvPartidas.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvPartidas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvPartidas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPartidas.Size = new Size(691, 210);
            dgvPartidas.TabIndex = 18;
            dgvPartidas.DoubleClick += dgvPartidas_DoubleClick;
            // 
            // Clave
            // 
            Clave.HeaderText = "Clave";
            Clave.Name = "Clave";
            Clave.ReadOnly = true;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            // 
            // Notas
            // 
            Notas.HeaderText = "Notas";
            Notas.Name = "Notas";
            Notas.ReadOnly = true;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.Transparent;
            label18.Font = new Font("Montserrat", 12F);
            label18.ForeColor = Color.White;
            label18.Location = new Point(24, 126);
            label18.Name = "label18";
            label18.Size = new Size(74, 22);
            label18.TabIndex = 17;
            label18.Text = "Partidas";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(3, 42, 76);
            panel3.Controls.Add(label25);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(label23);
            panel3.Controls.Add(dgvSolicitudes);
            panel3.Location = new Point(43, 523);
            panel3.Name = "panel3";
            panel3.Size = new Size(1252, 296);
            panel3.TabIndex = 53;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.BackColor = Color.Transparent;
            label25.Font = new Font("Montserrat", 12F);
            label25.ForeColor = Color.White;
            label25.Location = new Point(543, 17);
            label25.Name = "label25";
            label25.Size = new Size(176, 22);
            label25.TabIndex = 72;
            label25.Text = "Solicitudes Enviadas:";
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(255, 102, 0);
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Location = new Point(19, 669);
            button4.Name = "button4";
            button4.Size = new Size(119, 27);
            button4.TabIndex = 61;
            button4.Text = "Sincronizar";
            button4.UseVisualStyleBackColor = false;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.BackColor = Color.Transparent;
            label23.Font = new Font("Montserrat", 9F);
            label23.ForeColor = Color.White;
            label23.Location = new Point(975, 673);
            label23.Name = "label23";
            label23.Size = new Size(10, 16);
            label23.TabIndex = 60;
            label23.Text = ".";
            label23.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvSolicitudes
            // 
            dgvSolicitudes.AllowUserToAddRows = false;
            dgvSolicitudes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSolicitudes.BackgroundColor = Color.White;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvSolicitudes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvSolicitudes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSolicitudes.Location = new Point(19, 42);
            dgvSolicitudes.Name = "dgvSolicitudes";
            dgvSolicitudes.ReadOnly = true;
            dgvSolicitudes.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dgvSolicitudes.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvSolicitudes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSolicitudes.Size = new Size(1215, 231);
            dgvSolicitudes.TabIndex = 18;
            // 
            // Almacen_Fabricacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(pnlAlmacen);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Almacen_Fabricacion";
            Text = "Almacen_Fabricacion";
            Load += Almacen_Fabricacion_Load;
            pnlAlmacen.ResumeLayout(false);
            pnlAlmacen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductosSAE2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductosSAE).EndInit();
            ((System.ComponentModel.ISupportInitialize)bSAspelSAE).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPartidas).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel pnlAlmacen;
        private DataGridView dgvProductosSAE;
        private Label label9;
        private Button btnCerrar;
        private Button btnAbrir;
        private DataGridView dgvProductosSAE2;
        private BindingSource bSAspelSAE;
        private Label lblSincronizacion;
        private ComboBox cbProductos;
        private Label label2;
        private Button btnEnviarSolicitud;
        private Label label3;
        private Label label5;
        private Label label4;
        private TextBox txbCantidad;
        private TextBox txbNotas;
        private Panel panel1;
        private Label lblCantidadActual;
        private Label label6;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnAgregar;
        private Label lbl3Meses;
        private Label lbl2Meses;
        private Label lbl1Mes;
        private Label label13;
        private Label label12;
        private Label label11;
        private Panel panel2;
        private Label lblFecha;
        private Label lblFolio;
        private Label label21;
        private Label label22;
        private Label label17;
        private DataGridView dgvPartidas;
        private Label label18;
        private Button btnSincronizar;
        private Panel panel3;
        private Label label25;
        private Button button4;
        private Label label23;
        private DataGridView dgvSolicitudes;
        private Label lbl4Meses;
        private Label label7;
        private Label lblMeses;
        private Label label8;
        private Label lblFolioOriginal;
        private DataGridViewTextBoxColumn Clave;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Notas;
        private Button btnNuevo;
    }
}