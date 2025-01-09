namespace ElastoSystem
{
    partial class Compras_RequisicionesEnviadas
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            label1 = new Label();
            panel5 = new Panel();
            txbBuscador = new TextBox();
            label13 = new Label();
            dgvRequisicions = new DataGridView();
            lblFolio = new Label();
            label2 = new Label();
            panel1 = new Panel();
            txbRutCot = new TextBox();
            btnDescargarCotizacion = new Button();
            lblIDProducto = new Label();
            btnDescargarComprobante = new Button();
            txbComprobante = new TextBox();
            lblOCResultado = new Label();
            lblOC = new Label();
            lblFechaFinal = new Label();
            label10 = new Label();
            lblFechaInicio = new Label();
            label8 = new Label();
            lblEstatus = new Label();
            label7 = new Label();
            label6 = new Label();
            txbTipoUso = new TextBox();
            txbNotas = new TextBox();
            label4 = new Label();
            panel2 = new Panel();
            label5 = new Label();
            dgvPartidas = new DataGridView();
            label3 = new Label();
            lblFolioREQ = new Label();
            txbNombreArchivo = new TextBox();
            txbRuta = new TextBox();
            txbRutaCotizacion = new TextBox();
            txbNombreCotizacion = new TextBox();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequisicions).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPartidas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(25, 33);
            label1.Name = "label1";
            label1.Size = new Size(469, 44);
            label1.TabIndex = 2;
            label1.Text = "REQUISICIONES ENVIADAS";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(3, 42, 76);
            panel5.Controls.Add(txbBuscador);
            panel5.Controls.Add(label13);
            panel5.Controls.Add(dgvRequisicions);
            panel5.Location = new Point(25, 104);
            panel5.Name = "panel5";
            panel5.Size = new Size(539, 700);
            panel5.TabIndex = 21;
            // 
            // txbBuscador
            // 
            txbBuscador.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbBuscador.Location = new Point(140, 29);
            txbBuscador.Name = "txbBuscador";
            txbBuscador.Size = new Size(382, 27);
            txbBuscador.TabIndex = 28;
            txbBuscador.TextChanged += txbBuscador_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label13.ForeColor = Color.White;
            label13.Location = new Point(22, 32);
            label13.Name = "label13";
            label13.Size = new Size(103, 21);
            label13.TabIndex = 27;
            label13.Text = "BUSCADOR:";
            // 
            // dgvRequisicions
            // 
            dgvRequisicions.AllowUserToAddRows = false;
            dgvRequisicions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequisicions.BackgroundColor = Color.White;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Montserrat SemiBold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvRequisicions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvRequisicions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequisicions.Location = new Point(22, 74);
            dgvRequisicions.Name = "dgvRequisicions";
            dgvRequisicions.ReadOnly = true;
            dgvRequisicions.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dgvRequisicions.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvRequisicions.RowTemplate.Height = 25;
            dgvRequisicions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequisicions.Size = new Size(500, 604);
            dgvRequisicions.TabIndex = 21;
            dgvRequisicions.SelectionChanged += dgvRequisicions_SelectionChanged;
            dgvRequisicions.Click += dgvRequisicions_Click;
            dgvRequisicions.DoubleClick += dgvRequisicions_DoubleClick;
            // 
            // lblFolio
            // 
            lblFolio.AutoSize = true;
            lblFolio.BackColor = Color.Transparent;
            lblFolio.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFolio.ForeColor = Color.White;
            lblFolio.Location = new Point(1174, 39);
            lblFolio.Name = "lblFolio";
            lblFolio.Size = new Size(48, 22);
            lblFolio.TabIndex = 22;
            lblFolio.Text = "Folio";
            lblFolio.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(16, 198);
            label2.Name = "label2";
            label2.Size = new Size(256, 22);
            label2.TabIndex = 5;
            label2.Text = "Proyecto / Notas / Comentarios";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(txbRutCot);
            panel1.Controls.Add(btnDescargarCotizacion);
            panel1.Controls.Add(lblIDProducto);
            panel1.Controls.Add(btnDescargarComprobante);
            panel1.Controls.Add(txbComprobante);
            panel1.Controls.Add(lblOCResultado);
            panel1.Controls.Add(lblOC);
            panel1.Controls.Add(lblFechaFinal);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(lblFechaInicio);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(lblEstatus);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txbTipoUso);
            panel1.Controls.Add(txbNotas);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(579, 347);
            panel1.Name = "panel1";
            panel1.Size = new Size(735, 457);
            panel1.TabIndex = 22;
            // 
            // txbRutCot
            // 
            txbRutCot.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbRutCot.Location = new Point(423, 198);
            txbRutCot.Multiline = true;
            txbRutCot.Name = "txbRutCot";
            txbRutCot.ReadOnly = true;
            txbRutCot.Size = new Size(248, 30);
            txbRutCot.TabIndex = 54;
            txbRutCot.Visible = false;
            // 
            // btnDescargarCotizacion
            // 
            btnDescargarCotizacion.BackColor = Color.FromArgb(255, 102, 0);
            btnDescargarCotizacion.Cursor = Cursors.Hand;
            btnDescargarCotizacion.FlatAppearance.BorderSize = 0;
            btnDescargarCotizacion.FlatStyle = FlatStyle.Flat;
            btnDescargarCotizacion.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDescargarCotizacion.ForeColor = Color.White;
            btnDescargarCotizacion.Location = new Point(405, 151);
            btnDescargarCotizacion.Name = "btnDescargarCotizacion";
            btnDescargarCotizacion.Size = new Size(291, 38);
            btnDescargarCotizacion.TabIndex = 53;
            btnDescargarCotizacion.Text = "Descargar Cotización";
            btnDescargarCotizacion.UseVisualStyleBackColor = false;
            btnDescargarCotizacion.Visible = false;
            btnDescargarCotizacion.Click += btnDescargarCotizacion_Click;
            // 
            // lblIDProducto
            // 
            lblIDProducto.AutoSize = true;
            lblIDProducto.BackColor = Color.Transparent;
            lblIDProducto.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblIDProducto.ForeColor = Color.White;
            lblIDProducto.Location = new Point(262, 18);
            lblIDProducto.Name = "lblIDProducto";
            lblIDProducto.Size = new Size(88, 22);
            lblIDProducto.TabIndex = 52;
            lblIDProducto.Text = "-------------";
            lblIDProducto.Visible = false;
            // 
            // btnDescargarComprobante
            // 
            btnDescargarComprobante.BackColor = Color.FromArgb(255, 102, 0);
            btnDescargarComprobante.Cursor = Cursors.Hand;
            btnDescargarComprobante.FlatAppearance.BorderSize = 0;
            btnDescargarComprobante.FlatStyle = FlatStyle.Flat;
            btnDescargarComprobante.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnDescargarComprobante.ForeColor = Color.White;
            btnDescargarComprobante.Location = new Point(380, 91);
            btnDescargarComprobante.Name = "btnDescargarComprobante";
            btnDescargarComprobante.Size = new Size(291, 38);
            btnDescargarComprobante.TabIndex = 51;
            btnDescargarComprobante.Text = "Descargar Comprobante";
            btnDescargarComprobante.UseVisualStyleBackColor = false;
            btnDescargarComprobante.Visible = false;
            btnDescargarComprobante.Click += btnDescargarComprobante_Click;
            // 
            // txbComprobante
            // 
            txbComprobante.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbComprobante.Location = new Point(475, 52);
            txbComprobante.Multiline = true;
            txbComprobante.Name = "txbComprobante";
            txbComprobante.ReadOnly = true;
            txbComprobante.Size = new Size(36, 30);
            txbComprobante.TabIndex = 34;
            txbComprobante.Visible = false;
            // 
            // lblOCResultado
            // 
            lblOCResultado.AutoSize = true;
            lblOCResultado.BackColor = Color.Transparent;
            lblOCResultado.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblOCResultado.ForeColor = Color.White;
            lblOCResultado.Location = new Point(349, 55);
            lblOCResultado.Name = "lblOCResultado";
            lblOCResultado.Size = new Size(94, 22);
            lblOCResultado.TabIndex = 33;
            lblOCResultado.Text = "--------------";
            lblOCResultado.Visible = false;
            // 
            // lblOC
            // 
            lblOC.AutoSize = true;
            lblOC.BackColor = Color.Transparent;
            lblOC.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblOC.ForeColor = Color.White;
            lblOC.Location = new Point(312, 55);
            lblOC.Name = "lblOC";
            lblOC.Size = new Size(38, 22);
            lblOC.TabIndex = 32;
            lblOC.Text = "OC:";
            lblOC.Visible = false;
            // 
            // lblFechaFinal
            // 
            lblFechaFinal.AutoSize = true;
            lblFechaFinal.BackColor = Color.Transparent;
            lblFechaFinal.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFechaFinal.ForeColor = Color.White;
            lblFechaFinal.Location = new Point(131, 87);
            lblFechaFinal.Name = "lblFechaFinal";
            lblFechaFinal.Size = new Size(88, 22);
            lblFechaFinal.TabIndex = 31;
            lblFechaFinal.Text = "-------------";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(16, 87);
            label10.Name = "label10";
            label10.Size = new Size(104, 22);
            label10.TabIndex = 30;
            label10.Text = "Fecha Final:";
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.BackColor = Color.Transparent;
            lblFechaInicio.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFechaInicio.ForeColor = Color.White;
            lblFechaInicio.Location = new Point(131, 55);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(88, 22);
            lblFechaInicio.TabIndex = 29;
            lblFechaInicio.Text = "-------------";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(16, 55);
            label8.Name = "label8";
            label8.Size = new Size(109, 22);
            label8.TabIndex = 28;
            label8.Text = "Fecha Inicio:";
            // 
            // lblEstatus
            // 
            lblEstatus.AutoSize = true;
            lblEstatus.BackColor = Color.Transparent;
            lblEstatus.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblEstatus.ForeColor = Color.White;
            lblEstatus.Location = new Point(595, 18);
            lblEstatus.Name = "lblEstatus";
            lblEstatus.Size = new Size(76, 22);
            lblEstatus.TabIndex = 27;
            lblEstatus.Text = "-----------";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(517, 18);
            label7.Name = "label7";
            label7.Size = new Size(72, 22);
            label7.TabIndex = 26;
            label7.Text = "Estatus:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(16, 18);
            label6.Name = "label6";
            label6.Size = new Size(159, 22);
            label6.TabIndex = 25;
            label6.Text = "Info de la Partida:";
            // 
            // txbTipoUso
            // 
            txbTipoUso.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbTipoUso.Location = new Point(16, 151);
            txbTipoUso.Multiline = true;
            txbTipoUso.Name = "txbTipoUso";
            txbTipoUso.ReadOnly = true;
            txbTipoUso.Size = new Size(353, 30);
            txbTipoUso.TabIndex = 15;
            // 
            // txbNotas
            // 
            txbNotas.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNotas.Location = new Point(16, 232);
            txbNotas.Multiline = true;
            txbNotas.Name = "txbNotas";
            txbNotas.ReadOnly = true;
            txbNotas.Size = new Size(700, 183);
            txbNotas.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(16, 126);
            label4.Name = "label4";
            label4.Size = new Size(104, 22);
            label4.TabIndex = 14;
            label4.Text = "Tipo de Uso";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(3, 42, 76);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(dgvPartidas);
            panel2.Location = new Point(579, 104);
            panel2.Name = "panel2";
            panel2.Size = new Size(735, 237);
            panel2.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(333, 10);
            label5.Name = "label5";
            label5.Size = new Size(74, 22);
            label5.TabIndex = 21;
            label5.Text = "Partidas";
            // 
            // dgvPartidas
            // 
            dgvPartidas.AllowUserToAddRows = false;
            dgvPartidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPartidas.BackgroundColor = Color.White;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Montserrat SemiBold", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvPartidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvPartidas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPartidas.Location = new Point(16, 35);
            dgvPartidas.Name = "dgvPartidas";
            dgvPartidas.ReadOnly = true;
            dgvPartidas.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dgvPartidas.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dgvPartidas.RowTemplate.Height = 25;
            dgvPartidas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPartidas.Size = new Size(705, 184);
            dgvPartidas.TabIndex = 20;
            dgvPartidas.Click += dgvPartidas_Click;
            dgvPartidas.DoubleClick += dgvPartidas_DoubleClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(1101, 65);
            label3.Name = "label3";
            label3.Size = new Size(67, 22);
            label3.TabIndex = 24;
            label3.Text = "FOLIO:";
            // 
            // lblFolioREQ
            // 
            lblFolioREQ.AutoSize = true;
            lblFolioREQ.BackColor = Color.Transparent;
            lblFolioREQ.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFolioREQ.ForeColor = Color.White;
            lblFolioREQ.Location = new Point(1174, 65);
            lblFolioREQ.Name = "lblFolioREQ";
            lblFolioREQ.Size = new Size(48, 22);
            lblFolioREQ.TabIndex = 25;
            lblFolioREQ.Text = "Folio";
            lblFolioREQ.Visible = false;
            // 
            // txbNombreArchivo
            // 
            txbNombreArchivo.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNombreArchivo.Location = new Point(912, 47);
            txbNombreArchivo.Multiline = true;
            txbNombreArchivo.Name = "txbNombreArchivo";
            txbNombreArchivo.ReadOnly = true;
            txbNombreArchivo.Size = new Size(17, 30);
            txbNombreArchivo.TabIndex = 26;
            txbNombreArchivo.Visible = false;
            // 
            // txbRuta
            // 
            txbRuta.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbRuta.Location = new Point(947, 47);
            txbRuta.Multiline = true;
            txbRuta.Name = "txbRuta";
            txbRuta.ReadOnly = true;
            txbRuta.Size = new Size(17, 30);
            txbRuta.TabIndex = 27;
            txbRuta.Visible = false;
            // 
            // txbRutaCotizacion
            // 
            txbRutaCotizacion.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbRutaCotizacion.Location = new Point(896, 47);
            txbRutaCotizacion.Multiline = true;
            txbRutaCotizacion.Name = "txbRutaCotizacion";
            txbRutaCotizacion.ReadOnly = true;
            txbRutaCotizacion.Size = new Size(10, 30);
            txbRutaCotizacion.TabIndex = 29;
            txbRutaCotizacion.Visible = false;
            // 
            // txbNombreCotizacion
            // 
            txbNombreCotizacion.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNombreCotizacion.Location = new Point(878, 47);
            txbNombreCotizacion.Multiline = true;
            txbNombreCotizacion.Name = "txbNombreCotizacion";
            txbNombreCotizacion.ReadOnly = true;
            txbNombreCotizacion.Size = new Size(12, 30);
            txbNombreCotizacion.TabIndex = 28;
            txbNombreCotizacion.Visible = false;
            // 
            // Compras_RequisicionesEnviadas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(txbRutaCotizacion);
            Controls.Add(txbNombreCotizacion);
            Controls.Add(txbRuta);
            Controls.Add(txbNombreArchivo);
            Controls.Add(lblFolioREQ);
            Controls.Add(label3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblFolio);
            Controls.Add(panel5);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Compras_RequisicionesEnviadas";
            Text = "Compras_RequisicionesEnviadas";
            Load += Compras_RequisicionesEnviadas_Load;
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequisicions).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPartidas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel5;
        private Label label2;
        private Panel panel1;
        private TextBox txbNotas;
        private Label label4;
        private Panel panel2;
        private Label label5;
        private DataGridView dgvPartidas;
        private DataGridView dgvRequisicions;
        private TextBox txbTipoUso;
        private Label lblFolio;
        private TextBox txbBuscador;
        private Label label13;
        private Label label3;
        private Label lblFolioREQ;
        private Label label6;
        private Label label7;
        private Label lblEstatus;
        private Label label8;
        private Label lblFechaInicio;
        private Label lblFechaFinal;
        private Label label10;
        private Label lblOCResultado;
        private Label lblOC;
        private TextBox txbComprobante;
        private Button btnDescargarComprobante;
        private Label lblIDProducto;
        private TextBox txbNombreArchivo;
        private TextBox txbRuta;
        private Button btnDescargarCotizacion;
        private TextBox txbRutCot;
        private TextBox txbRutaCotizacion;
        private TextBox txbNombreCotizacion;
    }
}