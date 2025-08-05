namespace ElastoSystem
{
    partial class Mtto_ConsultasPreventivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mtto_ConsultasPreventivo));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel3 = new Panel();
            pictureBox5 = new PictureBox();
            btncerrar = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            dgvHistorialGeneral = new DataGridView();
            txbBuscador = new TextBox();
            label14 = new Label();
            btnExportarExcel = new Button();
            dtpFechaInicio = new DateTimePicker();
            lblFechaInicio = new Label();
            dtpFechaFinal = new DateTimePicker();
            label3 = new Label();
            btnFiltrar = new Button();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btncerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialGeneral).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(153, 255, 255, 255);
            panel3.Controls.Add(pictureBox5);
            panel3.Controls.Add(btncerrar);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1135, 30);
            panel3.TabIndex = 52;
            panel3.MouseDown += panel3_MouseDown;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Cursor = Cursors.Hand;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(1099, 4);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(23, 23);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 16;
            pictureBox5.TabStop = false;
            pictureBox5.MouseMove += pictureBox5_MouseMove;
            // 
            // btncerrar
            // 
            btncerrar.BackColor = Color.Transparent;
            btncerrar.Cursor = Cursors.Hand;
            btncerrar.Image = (Image)resources.GetObject("btncerrar.Image");
            btncerrar.Location = new Point(1099, 4);
            btncerrar.Name = "btncerrar";
            btncerrar.Size = new Size(23, 23);
            btncerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btncerrar.TabIndex = 14;
            btncerrar.TabStop = false;
            btncerrar.Click += btncerrar_Click;
            btncerrar.MouseLeave += btncerrar_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(21, 51);
            label1.Name = "label1";
            label1.Size = new Size(370, 44);
            label1.TabIndex = 53;
            label1.Text = "HISTORIAL GENERAL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 18F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(21, 87);
            label2.Name = "label2";
            label2.Size = new Size(568, 33);
            label2.TabIndex = 54;
            label2.Text = "DE PLAN DE MANTENIMIENTO PREVENTIVO";
            // 
            // dgvHistorialGeneral
            // 
            dgvHistorialGeneral.AllowUserToAddRows = false;
            dgvHistorialGeneral.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorialGeneral.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvHistorialGeneral.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvHistorialGeneral.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorialGeneral.Location = new Point(21, 278);
            dgvHistorialGeneral.Name = "dgvHistorialGeneral";
            dgvHistorialGeneral.ReadOnly = true;
            dgvHistorialGeneral.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvHistorialGeneral.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvHistorialGeneral.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorialGeneral.Size = new Size(1102, 478);
            dgvHistorialGeneral.TabIndex = 71;
            // 
            // txbBuscador
            // 
            txbBuscador.Font = new Font("Montserrat", 12F);
            txbBuscador.Location = new Point(121, 144);
            txbBuscador.Name = "txbBuscador";
            txbBuscador.Size = new Size(397, 27);
            txbBuscador.TabIndex = 70;
            txbBuscador.TextChanged += txbBuscador_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Montserrat", 12F);
            label14.ForeColor = Color.White;
            label14.Location = new Point(26, 147);
            label14.Name = "label14";
            label14.Size = new Size(89, 22);
            label14.TabIndex = 69;
            label14.Text = "Buscador:";
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.BackColor = Color.FromArgb(255, 102, 0);
            btnExportarExcel.Cursor = Cursors.Hand;
            btnExportarExcel.FlatAppearance.BorderSize = 0;
            btnExportarExcel.FlatStyle = FlatStyle.Flat;
            btnExportarExcel.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.Location = new Point(408, 770);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(326, 29);
            btnExportarExcel.TabIndex = 72;
            btnExportarExcel.Text = "Exportar Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaInicio.Location = new Point(142, 198);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(392, 26);
            dtpFechaInicio.TabIndex = 74;
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.BackColor = Color.Transparent;
            lblFechaInicio.Font = new Font("Montserrat", 12F);
            lblFechaInicio.ForeColor = Color.White;
            lblFechaInicio.Location = new Point(27, 199);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(109, 22);
            lblFechaInicio.TabIndex = 73;
            lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // dtpFechaFinal
            // 
            dtpFechaFinal.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaFinal.Location = new Point(142, 230);
            dtpFechaFinal.Name = "dtpFechaFinal";
            dtpFechaFinal.Size = new Size(392, 26);
            dtpFechaFinal.TabIndex = 76;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(27, 231);
            label3.Name = "label3";
            label3.Size = new Size(91, 22);
            label3.TabIndex = 75;
            label3.Text = "Fecha Fin:";
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.FromArgb(255, 102, 0);
            btnFiltrar.Cursor = Cursors.Hand;
            btnFiltrar.FlatAppearance.BorderSize = 0;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(558, 210);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(207, 29);
            btnFiltrar.TabIndex = 77;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // Mtto_ConsultasPreventivo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1135, 815);
            Controls.Add(btnFiltrar);
            Controls.Add(dtpFechaFinal);
            Controls.Add(label3);
            Controls.Add(dtpFechaInicio);
            Controls.Add(lblFechaInicio);
            Controls.Add(btnExportarExcel);
            Controls.Add(dgvHistorialGeneral);
            Controls.Add(txbBuscador);
            Controls.Add(label14);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Mtto_ConsultasPreventivo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mtto_ConsultasPreventivo";
            Load += Mtto_ConsultasPreventivo_Load;
            MouseLeave += Mtto_ConsultasPreventivo_MouseLeave;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)btncerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialGeneral).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private PictureBox pictureBox5;
        private PictureBox btncerrar;
        private Label label1;
        private Label label2;
        private DataGridView dgvHistorialGeneral;
        private TextBox txbBuscador;
        private Label label14;
        private Button btnExportarExcel;
        private DateTimePicker dtpFechaInicio;
        private Label lblFechaInicio;
        private DateTimePicker dtpFechaFinal;
        private Label label3;
        private Button btnFiltrar;
    }
}