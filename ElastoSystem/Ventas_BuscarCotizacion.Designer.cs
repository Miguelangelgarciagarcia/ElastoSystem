namespace ElastoSystem
{
    partial class Ventas_BuscarCotizacion
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
            panel1 = new Panel();
            txbFolio = new TextBox();
            btnBuscador = new Button();
            label6 = new Label();
            lblFecha = new Label();
            label7 = new Label();
            panel2 = new Panel();
            txbContacto = new TextBox();
            txbEmpresa = new TextBox();
            txbCorreo = new TextBox();
            txbTelefono = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel3 = new Panel();
            btnLimpiarCampos = new Button();
            btnAgregarProducto = new Button();
            txbPrecio = new TextBox();
            txbCantidad = new TextBox();
            cbProductos = new ComboBox();
            cbClave = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            chbDescuento = new CheckBox();
            txbDescuento = new TextBox();
            lblExcepto = new Label();
            txbPartidas = new TextBox();
            chbSigla03 = new CheckBox();
            btnGenerarCot = new Button();
            label13 = new Label();
            txbTotal = new TextBox();
            label14 = new Label();
            txbIVA = new TextBox();
            txbSubtotal = new TextBox();
            label12 = new Label();
            dgvListaProductos = new DataGridView();
            lblIDCliente = new Label();
            lblIDConEmp = new Label();
            txbTotalLetras = new TextBox();
            pnlBuscador = new Panel();
            dgvCotizaciones = new DataGridView();
            label15 = new Label();
            txbBuscador = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaProductos).BeginInit();
            pnlBuscador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCotizaciones).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 22F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(28, 29);
            label1.Name = "label1";
            label1.Size = new Size(359, 41);
            label1.TabIndex = 4;
            label1.Text = "BUSCAR COTIZACIÓN";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(txbFolio);
            panel1.Controls.Add(btnBuscador);
            panel1.Controls.Add(label6);
            panel1.Location = new Point(909, 101);
            panel1.Name = "panel1";
            panel1.Size = new Size(388, 177);
            panel1.TabIndex = 25;
            // 
            // txbFolio
            // 
            txbFolio.Enabled = false;
            txbFolio.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbFolio.Location = new Point(89, 80);
            txbFolio.Name = "txbFolio";
            txbFolio.ReadOnly = true;
            txbFolio.Size = new Size(269, 27);
            txbFolio.TabIndex = 35;
            txbFolio.TextAlign = HorizontalAlignment.Center;
            // 
            // btnBuscador
            // 
            btnBuscador.BackColor = Color.FromArgb(255, 102, 0);
            btnBuscador.Cursor = Cursors.Hand;
            btnBuscador.FlatAppearance.BorderSize = 0;
            btnBuscador.FlatStyle = FlatStyle.Flat;
            btnBuscador.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnBuscador.ForeColor = Color.White;
            btnBuscador.Location = new Point(67, 17);
            btnBuscador.Name = "btnBuscador";
            btnBuscador.Size = new Size(286, 36);
            btnBuscador.TabIndex = 36;
            btnBuscador.Text = "BUSCADOR";
            btnBuscador.UseVisualStyleBackColor = false;
            btnBuscador.Click += btnBuscar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(21, 84);
            label6.Name = "label6";
            label6.Size = new Size(62, 21);
            label6.TabIndex = 33;
            label6.Text = "FOLIO:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BackColor = Color.Transparent;
            lblFecha.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblFecha.ForeColor = Color.White;
            lblFecha.Location = new Point(1030, 49);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(121, 21);
            lblFecha.TabIndex = 35;
            lblFecha.Text = "FECHA LARGA";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(961, 49);
            label7.Name = "label7";
            label7.Size = new Size(66, 21);
            label7.TabIndex = 34;
            label7.Text = "FECHA:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(3, 42, 76);
            panel2.Controls.Add(txbContacto);
            panel2.Controls.Add(txbEmpresa);
            panel2.Controls.Add(txbCorreo);
            panel2.Controls.Add(txbTelefono);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(30, 101);
            panel2.Name = "panel2";
            panel2.Size = new Size(868, 177);
            panel2.TabIndex = 26;
            // 
            // txbContacto
            // 
            txbContacto.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbContacto.Location = new Point(153, 13);
            txbContacto.Name = "txbContacto";
            txbContacto.Size = new Size(673, 27);
            txbContacto.TabIndex = 34;
            // 
            // txbEmpresa
            // 
            txbEmpresa.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbEmpresa.Location = new Point(153, 51);
            txbEmpresa.Name = "txbEmpresa";
            txbEmpresa.Size = new Size(673, 27);
            txbEmpresa.TabIndex = 33;
            // 
            // txbCorreo
            // 
            txbCorreo.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbCorreo.Location = new Point(153, 131);
            txbCorreo.Name = "txbCorreo";
            txbCorreo.Size = new Size(673, 27);
            txbCorreo.TabIndex = 32;
            // 
            // txbTelefono
            // 
            txbTelefono.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbTelefono.Location = new Point(153, 93);
            txbTelefono.Name = "txbTelefono";
            txbTelefono.Size = new Size(673, 27);
            txbTelefono.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(23, 17);
            label2.Name = "label2";
            label2.Size = new Size(101, 21);
            label2.TabIndex = 2;
            label2.Text = "CONTACTO:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(23, 55);
            label3.Name = "label3";
            label3.Size = new Size(89, 21);
            label3.TabIndex = 3;
            label3.Text = "EMPRESA:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(23, 96);
            label4.Name = "label4";
            label4.Size = new Size(98, 21);
            label4.TabIndex = 8;
            label4.Text = "TELEFONO:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(23, 134);
            label5.Name = "label5";
            label5.Size = new Size(82, 21);
            label5.TabIndex = 12;
            label5.Text = "CORREO:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(3, 42, 76);
            panel3.Controls.Add(btnLimpiarCampos);
            panel3.Controls.Add(btnAgregarProducto);
            panel3.Controls.Add(txbPrecio);
            panel3.Controls.Add(txbCantidad);
            panel3.Controls.Add(cbProductos);
            panel3.Controls.Add(cbClave);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label11);
            panel3.Location = new Point(30, 284);
            panel3.Name = "panel3";
            panel3.Size = new Size(1267, 97);
            panel3.TabIndex = 27;
            // 
            // btnLimpiarCampos
            // 
            btnLimpiarCampos.BackColor = Color.FromArgb(255, 102, 0);
            btnLimpiarCampos.Cursor = Cursors.Hand;
            btnLimpiarCampos.FlatAppearance.BorderSize = 0;
            btnLimpiarCampos.FlatStyle = FlatStyle.Flat;
            btnLimpiarCampos.Font = new Font("Montserrat", 8F, FontStyle.Bold, GraphicsUnit.Point);
            btnLimpiarCampos.ForeColor = Color.White;
            btnLimpiarCampos.Location = new Point(721, 55);
            btnLimpiarCampos.Name = "btnLimpiarCampos";
            btnLimpiarCampos.Size = new Size(185, 27);
            btnLimpiarCampos.TabIndex = 38;
            btnLimpiarCampos.Text = "LIMPIAR CAMPOS";
            btnLimpiarCampos.UseVisualStyleBackColor = false;
            btnLimpiarCampos.Click += btnLimpiarCampos_Click;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.BackColor = Color.FromArgb(255, 102, 0);
            btnAgregarProducto.Cursor = Cursors.Hand;
            btnAgregarProducto.FlatAppearance.BorderSize = 0;
            btnAgregarProducto.FlatStyle = FlatStyle.Flat;
            btnAgregarProducto.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregarProducto.ForeColor = Color.White;
            btnAgregarProducto.Location = new Point(1089, 32);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(143, 36);
            btnAgregarProducto.TabIndex = 37;
            btnAgregarProducto.Text = "AGREGAR";
            btnAgregarProducto.UseVisualStyleBackColor = false;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // txbPrecio
            // 
            txbPrecio.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbPrecio.Location = new Point(392, 55);
            txbPrecio.Name = "txbPrecio";
            txbPrecio.Size = new Size(109, 27);
            txbPrecio.TabIndex = 32;
            // 
            // txbCantidad
            // 
            txbCantidad.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbCantidad.Location = new Point(125, 55);
            txbCantidad.Name = "txbCantidad";
            txbCantidad.Size = new Size(141, 27);
            txbCantidad.TabIndex = 31;
            // 
            // cbProductos
            // 
            cbProductos.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbProductos.FormattingEnabled = true;
            cbProductos.Location = new Point(392, 13);
            cbProductos.Name = "cbProductos";
            cbProductos.Size = new Size(673, 30);
            cbProductos.TabIndex = 30;
            cbProductos.SelectedIndexChanged += cbProductos_SelectedIndexChanged;
            // 
            // cbClave
            // 
            cbClave.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClave.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbClave.FormattingEnabled = true;
            cbClave.Location = new Point(92, 13);
            cbClave.Name = "cbClave";
            cbClave.Size = new Size(174, 30);
            cbClave.TabIndex = 29;
            cbClave.SelectedIndexChanged += cbClave_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(23, 17);
            label8.Name = "label8";
            label8.Size = new Size(63, 21);
            label8.TabIndex = 2;
            label8.Text = "CLAVE:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(281, 17);
            label9.Name = "label9";
            label9.Size = new Size(105, 21);
            label9.TabIndex = 3;
            label9.Text = "PRODUCTO:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(23, 59);
            label10.Name = "label10";
            label10.Size = new Size(96, 21);
            label10.TabIndex = 8;
            label10.Text = "CANTIDAD:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = Color.White;
            label11.Location = new Point(281, 59);
            label11.Name = "label11";
            label11.Size = new Size(74, 21);
            label11.TabIndex = 12;
            label11.Text = "PRECIO:";
            // 
            // chbDescuento
            // 
            chbDescuento.AutoSize = true;
            chbDescuento.BackColor = Color.Transparent;
            chbDescuento.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chbDescuento.ForeColor = Color.White;
            chbDescuento.Location = new Point(998, 676);
            chbDescuento.Name = "chbDescuento";
            chbDescuento.Size = new Size(134, 26);
            chbDescuento.TabIndex = 77;
            chbDescuento.Text = "Descuento %";
            chbDescuento.UseVisualStyleBackColor = false;
            chbDescuento.CheckedChanged += chbDescuento_CheckedChanged;
            // 
            // txbDescuento
            // 
            txbDescuento.Enabled = false;
            txbDescuento.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbDescuento.Location = new Point(1147, 674);
            txbDescuento.Multiline = true;
            txbDescuento.Name = "txbDescuento";
            txbDescuento.Size = new Size(149, 30);
            txbDescuento.TabIndex = 76;
            txbDescuento.Text = "0";
            txbDescuento.TextChanged += txbDescuento_TextChanged;
            // 
            // lblExcepto
            // 
            lblExcepto.AutoSize = true;
            lblExcepto.BackColor = Color.Transparent;
            lblExcepto.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblExcepto.ForeColor = Color.White;
            lblExcepto.Location = new Point(53, 635);
            lblExcepto.Name = "lblExcepto";
            lblExcepto.Size = new Size(87, 21);
            lblExcepto.TabIndex = 75;
            lblExcepto.Text = "EXCEPTO:";
            lblExcepto.Visible = false;
            // 
            // txbPartidas
            // 
            txbPartidas.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbPartidas.Location = new Point(141, 635);
            txbPartidas.Name = "txbPartidas";
            txbPartidas.Size = new Size(458, 24);
            txbPartidas.TabIndex = 74;
            txbPartidas.Visible = false;
            // 
            // chbSigla03
            // 
            chbSigla03.AutoSize = true;
            chbSigla03.BackColor = Color.Transparent;
            chbSigla03.Checked = true;
            chbSigla03.CheckState = CheckState.Checked;
            chbSigla03.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point);
            chbSigla03.ForeColor = Color.White;
            chbSigla03.Location = new Point(30, 608);
            chbSigla03.Name = "chbSigla03";
            chbSigla03.Size = new Size(569, 24);
            chbSigla03.TabIndex = 73;
            chbSigla03.Text = "TODOS LOS MATERIALES CUENTAN CON AVISO DE PRUEBA SIGLA 03 CFE";
            chbSigla03.UseVisualStyleBackColor = false;
            chbSigla03.CheckedChanged += chbSigla03_CheckedChanged;
            // 
            // btnGenerarCot
            // 
            btnGenerarCot.BackColor = Color.FromArgb(255, 102, 0);
            btnGenerarCot.Cursor = Cursors.Hand;
            btnGenerarCot.FlatAppearance.BorderSize = 0;
            btnGenerarCot.FlatStyle = FlatStyle.Flat;
            btnGenerarCot.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerarCot.ForeColor = Color.White;
            btnGenerarCot.Location = new Point(678, 688);
            btnGenerarCot.Name = "btnGenerarCot";
            btnGenerarCot.Size = new Size(258, 44);
            btnGenerarCot.TabIndex = 72;
            btnGenerarCot.Text = "GENERAR PDF";
            btnGenerarCot.UseVisualStyleBackColor = false;
            btnGenerarCot.Click += btnGenerarCot_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label13.ForeColor = Color.White;
            label13.Location = new Point(1015, 644);
            label13.Name = "label13";
            label13.Size = new Size(69, 22);
            label13.TabIndex = 71;
            label13.Text = "IVA 16%";
            // 
            // txbTotal
            // 
            txbTotal.Enabled = false;
            txbTotal.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbTotal.Location = new Point(1147, 707);
            txbTotal.Multiline = true;
            txbTotal.Name = "txbTotal";
            txbTotal.Size = new Size(149, 30);
            txbTotal.TabIndex = 70;
            txbTotal.TextChanged += txbTotal_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label14.ForeColor = Color.White;
            label14.Location = new Point(1015, 710);
            label14.Name = "label14";
            label14.Size = new Size(97, 22);
            label14.TabIndex = 69;
            label14.Text = "Total (USD)";
            // 
            // txbIVA
            // 
            txbIVA.Enabled = false;
            txbIVA.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbIVA.Location = new Point(1147, 641);
            txbIVA.Multiline = true;
            txbIVA.Name = "txbIVA";
            txbIVA.Size = new Size(149, 30);
            txbIVA.TabIndex = 68;
            // 
            // txbSubtotal
            // 
            txbSubtotal.Enabled = false;
            txbSubtotal.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbSubtotal.Location = new Point(1147, 608);
            txbSubtotal.Multiline = true;
            txbSubtotal.Name = "txbSubtotal";
            txbSubtotal.Size = new Size(149, 30);
            txbSubtotal.TabIndex = 67;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(1015, 610);
            label12.Name = "label12";
            label12.Size = new Size(77, 22);
            label12.TabIndex = 66;
            label12.Text = "Subtotal";
            // 
            // dgvListaProductos
            // 
            dgvListaProductos.AllowUserToAddRows = false;
            dgvListaProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListaProductos.BackgroundColor = Color.White;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Montserrat SemiBold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvListaProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvListaProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaProductos.Location = new Point(30, 410);
            dgvListaProductos.Name = "dgvListaProductos";
            dgvListaProductos.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dgvListaProductos.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dgvListaProductos.RowTemplate.Height = 25;
            dgvListaProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaProductos.Size = new Size(1267, 187);
            dgvListaProductos.TabIndex = 65;
            dgvListaProductos.CellDoubleClick += dgvListaProductos_CellDoubleClick;
            // 
            // lblIDCliente
            // 
            lblIDCliente.AutoSize = true;
            lblIDCliente.BackColor = Color.Transparent;
            lblIDCliente.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblIDCliente.ForeColor = Color.White;
            lblIDCliente.Location = new Point(462, 49);
            lblIDCliente.Name = "lblIDCliente";
            lblIDCliente.Size = new Size(93, 21);
            lblIDCliente.TabIndex = 78;
            lblIDCliente.Text = "IDCLIENTE";
            lblIDCliente.Visible = false;
            // 
            // lblIDConEmp
            // 
            lblIDConEmp.AutoSize = true;
            lblIDConEmp.BackColor = Color.Transparent;
            lblIDConEmp.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblIDConEmp.ForeColor = Color.White;
            lblIDConEmp.Location = new Point(462, 28);
            lblIDConEmp.Name = "lblIDConEmp";
            lblIDConEmp.Size = new Size(255, 21);
            lblIDConEmp.TabIndex = 79;
            lblIDConEmp.Text = "ID POR CONTACTO O EMPRESA";
            lblIDConEmp.Visible = false;
            // 
            // txbTotalLetras
            // 
            txbTotalLetras.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbTotalLetras.Location = new Point(838, 795);
            txbTotalLetras.Name = "txbTotalLetras";
            txbTotalLetras.Size = new Size(458, 24);
            txbTotalLetras.TabIndex = 80;
            txbTotalLetras.Visible = false;
            // 
            // pnlBuscador
            // 
            pnlBuscador.BackColor = Color.FromArgb(3, 42, 76);
            pnlBuscador.Controls.Add(dgvCotizaciones);
            pnlBuscador.Controls.Add(label15);
            pnlBuscador.Controls.Add(txbBuscador);
            pnlBuscador.Location = new Point(28, 101);
            pnlBuscador.Name = "pnlBuscador";
            pnlBuscador.Size = new Size(1269, 671);
            pnlBuscador.TabIndex = 37;
            // 
            // dgvCotizaciones
            // 
            dgvCotizaciones.AllowUserToAddRows = false;
            dgvCotizaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCotizaciones.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvCotizaciones.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvCotizaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvCotizaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dgvCotizaciones.DefaultCellStyle = dataGridViewCellStyle10;
            dgvCotizaciones.GridColor = SystemColors.ActiveCaptionText;
            dgvCotizaciones.Location = new Point(22, 87);
            dgvCotizaciones.Name = "dgvCotizaciones";
            dgvCotizaciones.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle11.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle11.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle11.SelectionForeColor = Color.White;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            dgvCotizaciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dgvCotizaciones.RowHeadersVisible = false;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = Color.White;
            dataGridViewCellStyle12.Font = new Font("Montserrat", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle12.ForeColor = Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle12.SelectionForeColor = Color.White;
            dgvCotizaciones.RowsDefaultCellStyle = dataGridViewCellStyle12;
            dgvCotizaciones.RowTemplate.Height = 25;
            dgvCotizaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCotizaciones.Size = new Size(1235, 570);
            dgvCotizaciones.TabIndex = 30;
            dgvCotizaciones.MouseDoubleClick += dgvCotizaciones_MouseDoubleClick;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.White;
            label15.Location = new Point(26, 37);
            label15.Name = "label15";
            label15.Size = new Size(101, 21);
            label15.TabIndex = 29;
            label15.Text = "BUSCADOR";
            // 
            // txbBuscador
            // 
            txbBuscador.Font = new Font("Montserrat", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txbBuscador.Location = new Point(133, 32);
            txbBuscador.Name = "txbBuscador";
            txbBuscador.Size = new Size(286, 29);
            txbBuscador.TabIndex = 28;
            txbBuscador.TextChanged += txbBuscador_TextChanged;
            // 
            // Ventas_BuscarCotizacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(pnlBuscador);
            Controls.Add(txbTotalLetras);
            Controls.Add(lblIDConEmp);
            Controls.Add(lblFecha);
            Controls.Add(label7);
            Controls.Add(lblIDCliente);
            Controls.Add(chbDescuento);
            Controls.Add(txbDescuento);
            Controls.Add(panel1);
            Controls.Add(lblExcepto);
            Controls.Add(txbPartidas);
            Controls.Add(chbSigla03);
            Controls.Add(btnGenerarCot);
            Controls.Add(label13);
            Controls.Add(txbTotal);
            Controls.Add(label14);
            Controls.Add(txbIVA);
            Controls.Add(txbSubtotal);
            Controls.Add(label12);
            Controls.Add(dgvListaProductos);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Ventas_BuscarCotizacion";
            Text = "Ventas_BuscarCotizacion";
            Load += Ventas_BuscarCotizacion_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaProductos).EndInit();
            pnlBuscador.ResumeLayout(false);
            pnlBuscador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCotizaciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Button btnBuscador;
        private Label lblFecha;
        private Label label7;
        private Label label6;
        private Panel panel2;
        private TextBox txbCorreo;
        private TextBox txbTelefono;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panel3;
        private Button btnLimpiarCampos;
        private Button btnAgregarProducto;
        private TextBox txbPrecio;
        private TextBox txbCantidad;
        private ComboBox cbProductos;
        private ComboBox cbClave;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private CheckBox chbDescuento;
        private TextBox txbDescuento;
        private Label lblExcepto;
        private TextBox txbPartidas;
        private CheckBox chbSigla03;
        private Button btnGenerarCot;
        private Label label13;
        private TextBox txbTotal;
        private Label label14;
        private TextBox txbIVA;
        private TextBox txbSubtotal;
        private Label label12;
        private DataGridView dgvListaProductos;
        private Label lblIDCliente;
        private Label lblIDConEmp;
        private TextBox txbTotalLetras;
        private Panel pnlBuscador;
        private DataGridView dgvCotizaciones;
        private Label label15;
        private TextBox txbBuscador;
        private TextBox txbFolio;
        private TextBox txbContacto;
        private TextBox txbEmpresa;
    }
}