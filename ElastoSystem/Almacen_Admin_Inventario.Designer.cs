namespace ElastoSystem
{
    partial class Almacen_Admin_Inventario
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            cbProductos = new ComboBox();
            label3 = new Label();
            btnActualizar = new Button();
            txbConsumoMensual = new TextBox();
            dgvFacturasSAE = new DataGridView();
            label4 = new Label();
            btnDescargarReporte = new Button();
            bindingSource1 = new BindingSource(components);
            dgvPartidasFacturaSAE = new DataGridView();
            bindingSource2 = new BindingSource(components);
            panel1 = new Panel();
            dgvReporte = new DataGridView();
            progressBar1 = new ProgressBar();
            btnFiltrar = new Button();
            lblProductos = new Label();
            lblClientes = new Label();
            lblFechas = new Label();
            lblFechaInicio = new Label();
            lblFechaFinal = new Label();
            dgvClientes = new DataGridView();
            bindingSource3 = new BindingSource(components);
            bindingSource4 = new BindingSource(components);
            label5 = new Label();
            txbMaxOC = new TextBox();
            pnlCargando = new Panel();
            label6 = new Label();
            btnDescargarPDF = new Button();
            dgvProductosSAE = new DataGridView();
            bSAspelSAE = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dgvFacturasSAE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPartidasFacturaSAE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource4).BeginInit();
            pnlCargando.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductosSAE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bSAspelSAE).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 22F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(43, 27);
            label1.Name = "label1";
            label1.Size = new Size(362, 41);
            label1.TabIndex = 1;
            label1.Text = "ADMINISTRAR PT SAE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(54, 100);
            label2.Name = "label2";
            label2.Size = new Size(87, 22);
            label2.TabIndex = 2;
            label2.Text = "Producto:";
            // 
            // cbProductos
            // 
            cbProductos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbProductos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbProductos.Font = new Font("Montserrat", 12F);
            cbProductos.FormattingEnabled = true;
            cbProductos.Location = new Point(288, 97);
            cbProductos.Name = "cbProductos";
            cbProductos.Size = new Size(288, 30);
            cbProductos.TabIndex = 3;
            cbProductos.SelectedIndexChanged += cbProductos_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(54, 135);
            label3.Name = "label3";
            label3.Size = new Size(164, 22);
            label3.TabIndex = 4;
            label3.Text = "Consumo Mensual:";
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(255, 102, 0);
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(621, 157);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(173, 34);
            btnActualizar.TabIndex = 9;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click_1;
            // 
            // txbConsumoMensual
            // 
            txbConsumoMensual.Font = new Font("Montserrat", 12F);
            txbConsumoMensual.Location = new Point(288, 133);
            txbConsumoMensual.Name = "txbConsumoMensual";
            txbConsumoMensual.Size = new Size(288, 27);
            txbConsumoMensual.TabIndex = 41;
            txbConsumoMensual.KeyPress += txbConsumoMensual_KeyPress;
            // 
            // dgvFacturasSAE
            // 
            dgvFacturasSAE.AllowUserToAddRows = false;
            dgvFacturasSAE.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturasSAE.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 9.749999F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvFacturasSAE.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvFacturasSAE.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturasSAE.Location = new Point(519, 248);
            dgvFacturasSAE.Name = "dgvFacturasSAE";
            dgvFacturasSAE.ReadOnly = true;
            dgvFacturasSAE.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 10F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvFacturasSAE.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvFacturasSAE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturasSAE.Size = new Size(15, 26);
            dgvFacturasSAE.TabIndex = 42;
            dgvFacturasSAE.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 18F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(43, 242);
            label4.Name = "label4";
            label4.Size = new Size(321, 33);
            label4.TabIndex = 43;
            label4.Text = "REPORTE DE FACTURAS";
            // 
            // btnDescargarReporte
            // 
            btnDescargarReporte.BackColor = Color.FromArgb(255, 102, 0);
            btnDescargarReporte.Cursor = Cursors.Hand;
            btnDescargarReporte.FlatAppearance.BorderSize = 0;
            btnDescargarReporte.FlatStyle = FlatStyle.Flat;
            btnDescargarReporte.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnDescargarReporte.ForeColor = Color.White;
            btnDescargarReporte.Location = new Point(1012, 756);
            btnDescargarReporte.Name = "btnDescargarReporte";
            btnDescargarReporte.Size = new Size(238, 34);
            btnDescargarReporte.TabIndex = 44;
            btnDescargarReporte.Text = "DESCARGAR .XLSX";
            btnDescargarReporte.UseVisualStyleBackColor = false;
            btnDescargarReporte.Visible = false;
            btnDescargarReporte.Click += btnDescargarReporte_Click;
            // 
            // dgvPartidasFacturaSAE
            // 
            dgvPartidasFacturaSAE.AllowUserToAddRows = false;
            dgvPartidasFacturaSAE.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPartidasFacturaSAE.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Montserrat", 9.749999F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPartidasFacturaSAE.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPartidasFacturaSAE.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPartidasFacturaSAE.Location = new Point(540, 252);
            dgvPartidasFacturaSAE.Name = "dgvPartidasFacturaSAE";
            dgvPartidasFacturaSAE.ReadOnly = true;
            dgvPartidasFacturaSAE.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 10F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvPartidasFacturaSAE.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvPartidasFacturaSAE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPartidasFacturaSAE.Size = new Size(20, 23);
            dgvPartidasFacturaSAE.TabIndex = 45;
            dgvPartidasFacturaSAE.Visible = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(dgvReporte);
            panel1.Location = new Point(43, 285);
            panel1.Name = "panel1";
            panel1.Size = new Size(1224, 465);
            panel1.TabIndex = 46;
            // 
            // dgvReporte
            // 
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.BackgroundColor = Color.White;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Montserrat", 9.749999F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvReporte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(20, 19);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.ReadOnly = true;
            dgvReporte.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Montserrat", 10F);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dgvReporte.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.Size = new Size(1187, 427);
            dgvReporte.TabIndex = 43;
            dgvReporte.Visible = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(93, 248);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1057, 24);
            progressBar1.TabIndex = 0;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.FromArgb(255, 102, 0);
            btnFiltrar.Cursor = Cursors.Hand;
            btnFiltrar.FlatAppearance.BorderSize = 0;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(380, 248);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(125, 31);
            btnFiltrar.TabIndex = 47;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Visible = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // lblProductos
            // 
            lblProductos.AutoSize = true;
            lblProductos.BackColor = Color.Transparent;
            lblProductos.Font = new Font("Montserrat", 12F);
            lblProductos.ForeColor = Color.White;
            lblProductos.Location = new Point(821, 46);
            lblProductos.Name = "lblProductos";
            lblProductos.Size = new Size(0, 22);
            lblProductos.TabIndex = 48;
            lblProductos.Visible = false;
            // 
            // lblClientes
            // 
            lblClientes.AutoSize = true;
            lblClientes.BackColor = Color.Transparent;
            lblClientes.Font = new Font("Montserrat", 12F);
            lblClientes.ForeColor = Color.White;
            lblClientes.Location = new Point(821, 68);
            lblClientes.Name = "lblClientes";
            lblClientes.Size = new Size(0, 22);
            lblClientes.TabIndex = 49;
            lblClientes.Visible = false;
            // 
            // lblFechas
            // 
            lblFechas.AutoSize = true;
            lblFechas.BackColor = Color.Transparent;
            lblFechas.Font = new Font("Montserrat", 12F);
            lblFechas.ForeColor = Color.White;
            lblFechas.Location = new Point(821, 92);
            lblFechas.Name = "lblFechas";
            lblFechas.Size = new Size(0, 22);
            lblFechas.TabIndex = 50;
            lblFechas.Visible = false;
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.BackColor = Color.Transparent;
            lblFechaInicio.Font = new Font("Montserrat", 12F);
            lblFechaInicio.ForeColor = Color.White;
            lblFechaInicio.Location = new Point(821, 115);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(0, 22);
            lblFechaInicio.TabIndex = 51;
            lblFechaInicio.Visible = false;
            // 
            // lblFechaFinal
            // 
            lblFechaFinal.AutoSize = true;
            lblFechaFinal.BackColor = Color.Transparent;
            lblFechaFinal.Font = new Font("Montserrat", 12F);
            lblFechaFinal.ForeColor = Color.White;
            lblFechaFinal.Location = new Point(821, 137);
            lblFechaFinal.Name = "lblFechaFinal";
            lblFechaFinal.Size = new Size(0, 22);
            lblFechaFinal.TabIndex = 52;
            lblFechaFinal.Visible = false;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = Color.White;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Montserrat", 9.749999F, FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(566, 252);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Montserrat", 10F);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dgvClientes.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(14, 23);
            dgvClientes.TabIndex = 53;
            dgvClientes.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 12F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(54, 169);
            label5.Name = "label5";
            label5.Size = new Size(217, 22);
            label5.TabIndex = 54;
            label5.Text = "Cantidad Maxima de 1 OC:";
            // 
            // txbMaxOC
            // 
            txbMaxOC.Font = new Font("Montserrat", 12F);
            txbMaxOC.Location = new Point(288, 166);
            txbMaxOC.Name = "txbMaxOC";
            txbMaxOC.Size = new Size(288, 27);
            txbMaxOC.TabIndex = 55;
            txbMaxOC.KeyPress += txbMaxOC_KeyPress;
            // 
            // pnlCargando
            // 
            pnlCargando.BackColor = Color.FromArgb(3, 42, 76);
            pnlCargando.Controls.Add(label6);
            pnlCargando.Controls.Add(progressBar1);
            pnlCargando.Location = new Point(26, 74);
            pnlCargando.Name = "pnlCargando";
            pnlCargando.Size = new Size(1286, 725);
            pnlCargando.TabIndex = 56;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(3, 42, 76);
            label6.Font = new Font("Montserrat", 15F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(1025, 285);
            label6.Name = "label6";
            label6.Size = new Size(125, 27);
            label6.TabIndex = 58;
            label6.Text = "Cargando...";
            // 
            // btnDescargarPDF
            // 
            btnDescargarPDF.BackColor = Color.FromArgb(255, 102, 0);
            btnDescargarPDF.Cursor = Cursors.Hand;
            btnDescargarPDF.FlatAppearance.BorderSize = 0;
            btnDescargarPDF.FlatStyle = FlatStyle.Flat;
            btnDescargarPDF.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnDescargarPDF.ForeColor = Color.White;
            btnDescargarPDF.Location = new Point(757, 756);
            btnDescargarPDF.Name = "btnDescargarPDF";
            btnDescargarPDF.Size = new Size(238, 34);
            btnDescargarPDF.TabIndex = 57;
            btnDescargarPDF.Text = "DESCARGAR .PDF";
            btnDescargarPDF.UseVisualStyleBackColor = false;
            btnDescargarPDF.Visible = false;
            btnDescargarPDF.Click += btnDescargarPDF_Click;
            // 
            // dgvProductosSAE
            // 
            dgvProductosSAE.AllowUserToAddRows = false;
            dgvProductosSAE.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductosSAE.Location = new Point(449, 44);
            dgvProductosSAE.Name = "dgvProductosSAE";
            dgvProductosSAE.Size = new Size(21, 24);
            dgvProductosSAE.TabIndex = 58;
            dgvProductosSAE.Visible = false;
            // 
            // Almacen_Admin_Inventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(dgvProductosSAE);
            Controls.Add(pnlCargando);
            Controls.Add(txbMaxOC);
            Controls.Add(label5);
            Controls.Add(dgvClientes);
            Controls.Add(lblFechaFinal);
            Controls.Add(lblFechaInicio);
            Controls.Add(lblFechas);
            Controls.Add(lblClientes);
            Controls.Add(lblProductos);
            Controls.Add(btnFiltrar);
            Controls.Add(panel1);
            Controls.Add(dgvPartidasFacturaSAE);
            Controls.Add(btnDescargarReporte);
            Controls.Add(label4);
            Controls.Add(dgvFacturasSAE);
            Controls.Add(txbConsumoMensual);
            Controls.Add(btnActualizar);
            Controls.Add(label3);
            Controls.Add(cbProductos);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDescargarPDF);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Almacen_Admin_Inventario";
            Text = "Almacen_Admin_Inventario";
            Load += Almacen_Admin_Inventario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFacturasSAE).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPartidasFacturaSAE).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource3).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource4).EndInit();
            pnlCargando.ResumeLayout(false);
            pnlCargando.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductosSAE).EndInit();
            ((System.ComponentModel.ISupportInitialize)bSAspelSAE).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbProductos;
        private Label label3;
        private Button btnActualizar;
        private TextBox txbConsumoMensual;
        private DataGridView dgvFacturasSAE;
        private Label label4;
        private Button btnDescargarReporte;
        private BindingSource bindingSource1;
        private DataGridView dgvPartidasFacturaSAE;
        private BindingSource bindingSource2;
        private Panel panel1;
        private ProgressBar progressBar1;
        private DataGridView dgvReporte;
        private Button btnFiltrar;
        private Label lblProductos;
        private Label lblClientes;
        private Label lblFechas;
        private Label lblFechaInicio;
        private Label lblFechaFinal;
        private DataGridView dgvClientes;
        private BindingSource bindingSource3;
        private BindingSource bindingSource4;
        private Label label5;
        private TextBox txbMaxOC;
        private Panel pnlCargando;
        private Button btnDescargarPDF;
        private Label label6;
        private DataGridView dgvProductosSAE;
        private BindingSource bSAspelSAE;
    }
}