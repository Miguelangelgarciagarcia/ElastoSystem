namespace ElastoSystem
{
    partial class Compras_RequisicionMaterial
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
            label1 = new Label();
            lblFolio = new Label();
            label8 = new Label();
            lblfecha = new Label();
            label5 = new Label();
            panel5 = new Panel();
            chbCompraOnline = new CheckBox();
            cbTipoUso = new ComboBox();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnNuevo = new Button();
            label13 = new Label();
            label12 = new Label();
            btnAgregar = new Button();
            txbNotas = new TextBox();
            cbProveedor = new ComboBox();
            label10 = new Label();
            cbUnidad = new ComboBox();
            txbPrecio = new TextBox();
            txbCantidad = new TextBox();
            label9 = new Label();
            label7 = new Label();
            label6 = new Label();
            label2 = new Label();
            label3 = new Label();
            txbDescripcion = new TextBox();
            panel1 = new Panel();
            label14 = new Label();
            dgvListaMateriales = new DataGridView();
            Descripcion = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Unidad = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Proveedor = new DataGridViewTextBoxColumn();
            TipoUso = new DataGridViewTextBoxColumn();
            Comentarios = new DataGridViewTextBoxColumn();
            Onlinea = new DataGridViewTextBoxColumn();
            panel4 = new Panel();
            btnRequerimiento = new Button();
            lblFolioREQ = new Label();
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaMateriales).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(24, 30);
            label1.Name = "label1";
            label1.Size = new Size(481, 44);
            label1.TabIndex = 1;
            label1.Text = "REQUISICION DE MATERIAL";
            // 
            // lblFolio
            // 
            lblFolio.AutoSize = true;
            lblFolio.BackColor = Color.Transparent;
            lblFolio.Font = new Font("Montserrat", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblFolio.ForeColor = Color.White;
            lblFolio.Location = new Point(1132, 9);
            lblFolio.Name = "lblFolio";
            lblFolio.Size = new Size(101, 30);
            lblFolio.TabIndex = 19;
            lblFolio.Text = "240000";
            lblFolio.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(1060, 41);
            label8.Name = "label8";
            label8.Size = new Size(75, 30);
            label8.TabIndex = 18;
            label8.Text = "Folio:";
            // 
            // lblfecha
            // 
            lblfecha.AutoSize = true;
            lblfecha.BackColor = Color.Transparent;
            lblfecha.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblfecha.ForeColor = Color.White;
            lblfecha.Location = new Point(1065, 72);
            lblfecha.Name = "lblfecha";
            lblfecha.Size = new Size(100, 20);
            lblfecha.TabIndex = 17;
            lblfecha.Text = "Fecha Larga";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(1009, 72);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 16;
            label5.Text = "Fecha:";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(3, 42, 76);
            panel5.Controls.Add(chbCompraOnline);
            panel5.Controls.Add(cbTipoUso);
            panel5.Controls.Add(btnModificar);
            panel5.Controls.Add(btnEliminar);
            panel5.Controls.Add(btnNuevo);
            panel5.Controls.Add(label13);
            panel5.Controls.Add(label12);
            panel5.Controls.Add(btnAgregar);
            panel5.Controls.Add(txbNotas);
            panel5.Controls.Add(cbProveedor);
            panel5.Controls.Add(label10);
            panel5.Controls.Add(cbUnidad);
            panel5.Controls.Add(txbPrecio);
            panel5.Controls.Add(txbCantidad);
            panel5.Controls.Add(label9);
            panel5.Controls.Add(label7);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(txbDescripcion);
            panel5.Location = new Point(24, 105);
            panel5.Name = "panel5";
            panel5.Size = new Size(564, 670);
            panel5.TabIndex = 20;
            panel5.Paint += panel5_Paint;
            // 
            // chbCompraOnline
            // 
            chbCompraOnline.AutoSize = true;
            chbCompraOnline.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chbCompraOnline.ForeColor = Color.White;
            chbCompraOnline.Location = new Point(390, 386);
            chbCompraOnline.Name = "chbCompraOnline";
            chbCompraOnline.Size = new Size(150, 26);
            chbCompraOnline.TabIndex = 28;
            chbCompraOnline.Text = "Compra Online";
            chbCompraOnline.UseVisualStyleBackColor = true;
            // 
            // cbTipoUso
            // 
            cbTipoUso.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoUso.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbTipoUso.FormattingEnabled = true;
            cbTipoUso.Items.AddRange(new object[] { "ACTIVO FIJO", "ENERGIA ELECTRICA", "GASTOS ADMINISTRATIVOS", "HERRAMIENTAS", "INTERNET Y TELEFONO", "LIMPIEZA", "MANTENIMIENTO", "MATERIA PRIMA", "PAPELERIA", "REFACCIONES", "UNIFORMES", "VIGILANCIA", "OTROS" });
            cbTipoUso.Location = new Point(147, 339);
            cbTipoUso.Name = "cbTipoUso";
            cbTipoUso.Size = new Size(393, 30);
            cbTipoUso.TabIndex = 15;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.FromArgb(255, 102, 0);
            btnModificar.Cursor = Cursors.Hand;
            btnModificar.Enabled = false;
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(224, 623);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(113, 30);
            btnModificar.TabIndex = 23;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(255, 102, 0);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Enabled = false;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(26, 624);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(113, 30);
            btnEliminar.TabIndex = 24;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(255, 102, 0);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(415, 623);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(113, 30);
            btnNuevo.TabIndex = 27;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Visible = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label13.ForeColor = Color.White;
            label13.Location = new Point(26, 342);
            label13.Name = "label13";
            label13.Size = new Size(104, 22);
            label13.TabIndex = 14;
            label13.Text = "Tipo de Uso";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(25, 423);
            label12.Name = "label12";
            label12.Size = new Size(256, 22);
            label12.TabIndex = 15;
            label12.Text = "Proyecto / Notas / Comentarios";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(255, 102, 0);
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(415, 623);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(113, 30);
            btnAgregar.TabIndex = 22;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += button1_Click;
            // 
            // txbNotas
            // 
            txbNotas.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNotas.Location = new Point(25, 448);
            txbNotas.Multiline = true;
            txbNotas.Name = "txbNotas";
            txbNotas.Size = new Size(515, 148);
            txbNotas.TabIndex = 14;
            // 
            // cbProveedor
            // 
            cbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProveedor.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbProveedor.FormattingEnabled = true;
            cbProveedor.Location = new Point(25, 297);
            cbProveedor.Name = "cbProveedor";
            cbProveedor.Size = new Size(515, 30);
            cbProveedor.TabIndex = 13;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(233, 272);
            label10.Name = "label10";
            label10.Size = new Size(93, 22);
            label10.TabIndex = 12;
            label10.Text = "Proveedor";
            label10.Click += label10_Click;
            // 
            // cbUnidad
            // 
            cbUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUnidad.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbUnidad.FormattingEnabled = true;
            cbUnidad.Items.AddRange(new object[] { "Atado", "Kilos", "Litros", "Metros", "Piezas", "Servicio" });
            cbUnidad.Location = new Point(208, 229);
            cbUnidad.Name = "cbUnidad";
            cbUnidad.Size = new Size(150, 30);
            cbUnidad.TabIndex = 11;
            // 
            // txbPrecio
            // 
            txbPrecio.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbPrecio.Location = new Point(390, 229);
            txbPrecio.Name = "txbPrecio";
            txbPrecio.Size = new Size(150, 27);
            txbPrecio.TabIndex = 10;
            txbPrecio.TextChanged += txbPrecio_TextChanged;
            txbPrecio.KeyPress += txbPrecio_KeyPress;
            // 
            // txbCantidad
            // 
            txbCantidad.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbCantidad.Location = new Point(25, 229);
            txbCantidad.Name = "txbCantidad";
            txbCantidad.Size = new Size(150, 27);
            txbCantidad.TabIndex = 9;
            txbCantidad.KeyPress += txbCantidad_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(435, 204);
            label9.Name = "label9";
            label9.Size = new Size(60, 22);
            label9.TabIndex = 8;
            label9.Text = "Precio";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(247, 204);
            label7.Name = "label7";
            label7.Size = new Size(69, 22);
            label7.TabIndex = 7;
            label7.Text = "Unidad";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(67, 204);
            label6.Name = "label6";
            label6.Size = new Size(83, 22);
            label6.TabIndex = 6;
            label6.Text = "Cantidad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(25, 48);
            label2.Name = "label2";
            label2.Size = new Size(105, 22);
            label2.TabIndex = 5;
            label2.Text = "Descripción";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(248, 7);
            label3.Name = "label3";
            label3.Size = new Size(68, 22);
            label3.TabIndex = 3;
            label3.Text = "DATOS";
            label3.Click += label3_Click;
            // 
            // txbDescripcion
            // 
            txbDescripcion.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbDescripcion.Location = new Point(25, 73);
            txbDescripcion.Multiline = true;
            txbDescripcion.Name = "txbDescripcion";
            txbDescripcion.Size = new Size(515, 113);
            txbDescripcion.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(dgvListaMateriales);
            panel1.Location = new Point(594, 105);
            panel1.Name = "panel1";
            panel1.Size = new Size(718, 596);
            panel1.TabIndex = 21;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.White;
            label14.Location = new Point(265, 7);
            label14.Name = "label14";
            label14.Size = new Size(95, 22);
            label14.TabIndex = 27;
            label14.Text = "PARTIDAS";
            // 
            // dgvListaMateriales
            // 
            dgvListaMateriales.AllowUserToAddRows = false;
            dgvListaMateriales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListaMateriales.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat SemiBold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvListaMateriales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvListaMateriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaMateriales.Columns.AddRange(new DataGridViewColumn[] { Descripcion, Cantidad, Unidad, Precio, Proveedor, TipoUso, Comentarios, Onlinea });
            dgvListaMateriales.Enabled = false;
            dgvListaMateriales.Location = new Point(16, 36);
            dgvListaMateriales.Name = "dgvListaMateriales";
            dgvListaMateriales.ReadOnly = true;
            dgvListaMateriales.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvListaMateriales.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvListaMateriales.RowTemplate.Height = 25;
            dgvListaMateriales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaMateriales.Size = new Size(688, 546);
            dgvListaMateriales.TabIndex = 19;
            dgvListaMateriales.DoubleClick += dgvListaMateriales_DoubleClick;
            // 
            // Descripcion
            // 
            Descripcion.HeaderText = "Descripción";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            // 
            // Unidad
            // 
            Unidad.HeaderText = "Unidad";
            Unidad.Name = "Unidad";
            Unidad.ReadOnly = true;
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio";
            Precio.Name = "Precio";
            Precio.ReadOnly = true;
            // 
            // Proveedor
            // 
            Proveedor.HeaderText = "Proveedor";
            Proveedor.Name = "Proveedor";
            Proveedor.ReadOnly = true;
            // 
            // TipoUso
            // 
            TipoUso.HeaderText = "TipoUso";
            TipoUso.Name = "TipoUso";
            TipoUso.ReadOnly = true;
            // 
            // Comentarios
            // 
            Comentarios.HeaderText = "Comentarios";
            Comentarios.Name = "Comentarios";
            Comentarios.ReadOnly = true;
            // 
            // Onlinea
            // 
            Onlinea.HeaderText = "Online";
            Onlinea.Name = "Onlinea";
            Onlinea.ReadOnly = true;
            Onlinea.Visible = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(3, 42, 76);
            panel4.Controls.Add(btnRequerimiento);
            panel4.Location = new Point(594, 707);
            panel4.Name = "panel4";
            panel4.Size = new Size(718, 68);
            panel4.TabIndex = 28;
            // 
            // btnRequerimiento
            // 
            btnRequerimiento.BackColor = Color.FromArgb(255, 102, 0);
            btnRequerimiento.Cursor = Cursors.Hand;
            btnRequerimiento.FlatAppearance.BorderSize = 0;
            btnRequerimiento.FlatStyle = FlatStyle.Flat;
            btnRequerimiento.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnRequerimiento.ForeColor = Color.White;
            btnRequerimiento.Location = new Point(97, 15);
            btnRequerimiento.Name = "btnRequerimiento";
            btnRequerimiento.Size = new Size(542, 36);
            btnRequerimiento.TabIndex = 13;
            btnRequerimiento.Text = "Enviar Requerimiento";
            btnRequerimiento.UseVisualStyleBackColor = false;
            btnRequerimiento.Click += button1_Click_1;
            // 
            // lblFolioREQ
            // 
            lblFolioREQ.AutoSize = true;
            lblFolioREQ.BackColor = Color.Transparent;
            lblFolioREQ.Font = new Font("Montserrat", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblFolioREQ.ForeColor = Color.White;
            lblFolioREQ.Location = new Point(1132, 42);
            lblFolioREQ.Name = "lblFolioREQ";
            lblFolioREQ.Size = new Size(101, 30);
            lblFolioREQ.TabIndex = 29;
            lblFolioREQ.Text = "240000";
            // 
            // Compras_RequisicionMaterial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(lblFolioREQ);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Controls.Add(panel5);
            Controls.Add(lblFolio);
            Controls.Add(label8);
            Controls.Add(lblfecha);
            Controls.Add(label5);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Compras_RequisicionMaterial";
            Text = "Compras_RequisicionMaterial";
            Load += Compras_RequisicionMaterial_Load;
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListaMateriales).EndInit();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblFolio;
        private Label label8;
        private Label lblfecha;
        private Label label5;
        private Panel panel5;
        private Label label3;
        private TextBox txbDescripcion;
        private Panel panel1;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Label label9;
        private Label label7;
        private Label label6;
        private Label label2;
        private ComboBox cbUnidad;
        private TextBox txbPrecio;
        private TextBox txbCantidad;
        private ComboBox cbProveedor;
        private Label label10;
        private ComboBox cbTipoUso;
        private Label label13;
        private Label label14;
        private DataGridView dgvListaMateriales;
        private Button btnNuevo;
        private Label label12;
        private TextBox txbNotas;
        private Panel panel4;
        private Button btnRequerimiento;
        private Label lblFolioREQ;
        private CheckBox chbCompraOnline;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Unidad;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Proveedor;
        private DataGridViewTextBoxColumn TipoUso;
        private DataGridViewTextBoxColumn Comentarios;
        private DataGridViewTextBoxColumn Onlinea;
    }
}