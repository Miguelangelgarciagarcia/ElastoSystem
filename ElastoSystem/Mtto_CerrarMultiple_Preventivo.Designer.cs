namespace ElastoSystem
{
    partial class Mtto_CerrarMultiple_Preventivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mtto_CerrarMultiple_Preventivo));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel3 = new Panel();
            pictureBox5 = new PictureBox();
            btncerrar = new PictureBox();
            label1 = new Label();
            txbRealizo = new TextBox();
            label15 = new Label();
            dtpFechaCierre = new DateTimePicker();
            lblFechaInicio = new Label();
            btnFinalizar = new Button();
            dgvACerrar = new DataGridView();
            txbObservaciones = new TextBox();
            label2 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btncerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvACerrar).BeginInit();
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
            panel3.Size = new Size(599, 30);
            panel3.TabIndex = 52;
            panel3.MouseDown += panel3_MouseDown;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Cursor = Cursors.Hand;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(564, 4);
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
            btncerrar.Location = new Point(564, 4);
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
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 18F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 48);
            label1.Name = "label1";
            label1.Size = new Size(599, 38);
            label1.TabIndex = 60;
            label1.Text = "FINALIZAR MULTIPLE MTTO. PREVENTIVO";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txbRealizo
            // 
            txbRealizo.Font = new Font("Montserrat", 12F);
            txbRealizo.Location = new Point(174, 246);
            txbRealizo.Name = "txbRealizo";
            txbRealizo.Size = new Size(397, 27);
            txbRealizo.TabIndex = 1;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Montserrat", 12F);
            label15.ForeColor = Color.White;
            label15.Location = new Point(28, 249);
            label15.Name = "label15";
            label15.Size = new Size(72, 25);
            label15.TabIndex = 77;
            label15.Text = "Realizo:";
            // 
            // dtpFechaCierre
            // 
            dtpFechaCierre.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaCierre.Location = new Point(174, 312);
            dtpFechaCierre.Name = "dtpFechaCierre";
            dtpFechaCierre.Size = new Size(397, 26);
            dtpFechaCierre.TabIndex = 3;
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.BackColor = Color.Transparent;
            lblFechaInicio.Font = new Font("Montserrat", 12F);
            lblFechaInicio.ForeColor = Color.White;
            lblFechaInicio.Location = new Point(28, 315);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(140, 25);
            lblFechaInicio.TabIndex = 75;
            lblFechaInicio.Text = "Fecha de Cierre:";
            // 
            // btnFinalizar
            // 
            btnFinalizar.BackColor = Color.FromArgb(255, 102, 0);
            btnFinalizar.Cursor = Cursors.Hand;
            btnFinalizar.FlatAppearance.BorderSize = 0;
            btnFinalizar.FlatStyle = FlatStyle.Flat;
            btnFinalizar.Font = new Font("Montserrat", 11.25F, FontStyle.Bold);
            btnFinalizar.ForeColor = Color.White;
            btnFinalizar.Location = new Point(155, 357);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(257, 33);
            btnFinalizar.TabIndex = 4;
            btnFinalizar.Text = "FINALIZAR";
            btnFinalizar.UseVisualStyleBackColor = false;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // dgvACerrar
            // 
            dgvACerrar.AllowUserToAddRows = false;
            dgvACerrar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvACerrar.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvACerrar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvACerrar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvACerrar.Location = new Point(28, 95);
            dgvACerrar.Name = "dgvACerrar";
            dgvACerrar.ReadOnly = true;
            dgvACerrar.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvACerrar.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvACerrar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvACerrar.Size = new Size(543, 132);
            dgvACerrar.TabIndex = 79;
            // 
            // txbObservaciones
            // 
            txbObservaciones.Font = new Font("Montserrat", 12F);
            txbObservaciones.Location = new Point(174, 279);
            txbObservaciones.Name = "txbObservaciones";
            txbObservaciones.Size = new Size(397, 27);
            txbObservaciones.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(28, 282);
            label2.Name = "label2";
            label2.Size = new Size(133, 25);
            label2.TabIndex = 80;
            label2.Text = "Observaciones:";
            // 
            // Mtto_CerrarMultiple_Preventivo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(599, 418);
            Controls.Add(txbObservaciones);
            Controls.Add(label2);
            Controls.Add(dgvACerrar);
            Controls.Add(txbRealizo);
            Controls.Add(label15);
            Controls.Add(dtpFechaCierre);
            Controls.Add(lblFechaInicio);
            Controls.Add(btnFinalizar);
            Controls.Add(label1);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Mtto_CerrarMultiple_Preventivo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mtto_CerrarMultiple_Preventivo";
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)btncerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvACerrar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private PictureBox pictureBox5;
        private PictureBox btncerrar;
        private Label label1;
        private TextBox txbRealizo;
        private Label label15;
        private DateTimePicker dtpFechaCierre;
        private Label lblFechaInicio;
        private Button btnFinalizar;
        private DataGridView dgvACerrar;
        private TextBox txbObservaciones;
        private Label label2;
    }
}