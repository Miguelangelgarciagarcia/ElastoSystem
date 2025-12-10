namespace ElastoSystem
{
    partial class Produccion_ParoMaquinas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produccion_ParoMaquinas));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            btncerrar = new PictureBox();
            label1 = new Label();
            lblNave = new Label();
            panel2 = new Panel();
            label2 = new Label();
            txbHoraFinal = new TextBox();
            cbMaquinas = new ComboBox();
            cbFalla = new ComboBox();
            btnRegistrarParo = new Button();
            label10 = new Label();
            label5 = new Label();
            label8 = new Label();
            txbObservaciones = new TextBox();
            label9 = new Label();
            txbHoraInicio = new TextBox();
            dgvParosMaquinas = new DataGridView();
            lblFecha = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btncerrar).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvParosMaquinas).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(153, 255, 255, 255);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btncerrar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(837, 30);
            panel1.TabIndex = 1;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(801, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(24, 24);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            // 
            // btncerrar
            // 
            btncerrar.BackColor = Color.Transparent;
            btncerrar.Cursor = Cursors.Hand;
            btncerrar.Image = (Image)resources.GetObject("btncerrar.Image");
            btncerrar.Location = new Point(801, 3);
            btncerrar.Name = "btncerrar";
            btncerrar.Size = new Size(24, 24);
            btncerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btncerrar.TabIndex = 2;
            btncerrar.TabStop = false;
            btncerrar.Click += btncerrar_Click;
            btncerrar.MouseLeave += btncerrar_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 22F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(22, 44);
            label1.Name = "label1";
            label1.Size = new Size(349, 47);
            label1.TabIndex = 2;
            label1.Text = "PARO DE MAQUINAS";
            // 
            // lblNave
            // 
            lblNave.AutoSize = true;
            lblNave.BackColor = Color.Transparent;
            lblNave.Font = new Font("Montserrat", 18F, FontStyle.Bold);
            lblNave.ForeColor = Color.White;
            lblNave.Location = new Point(22, 83);
            lblNave.Name = "lblNave";
            lblNave.Size = new Size(184, 38);
            lblNave.TabIndex = 3;
            lblNave.Text = "NAVE ERROR";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(3, 42, 76);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txbHoraFinal);
            panel2.Controls.Add(cbMaquinas);
            panel2.Controls.Add(cbFalla);
            panel2.Controls.Add(btnRegistrarParo);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txbObservaciones);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(txbHoraInicio);
            panel2.Location = new Point(16, 131);
            panel2.Name = "panel2";
            panel2.Size = new Size(803, 218);
            panel2.TabIndex = 147;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 11F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(509, 63);
            label2.Name = "label2";
            label2.Size = new Size(75, 24);
            label2.TabIndex = 129;
            label2.Text = "Hora Fin:";
            // 
            // txbHoraFinal
            // 
            txbHoraFinal.Font = new Font("Montserrat", 11F);
            txbHoraFinal.Location = new Point(607, 62);
            txbHoraFinal.Name = "txbHoraFinal";
            txbHoraFinal.ReadOnly = true;
            txbHoraFinal.Size = new Size(174, 25);
            txbHoraFinal.TabIndex = 4;
            txbHoraFinal.TextAlign = HorizontalAlignment.Center;
            txbHoraFinal.KeyPress += txbHoraFinal_KeyPress;
            // 
            // cbMaquinas
            // 
            cbMaquinas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMaquinas.Font = new Font("Montserrat", 11F);
            cbMaquinas.FormattingEnabled = true;
            cbMaquinas.IntegralHeight = false;
            cbMaquinas.Location = new Point(101, 20);
            cbMaquinas.MaxDropDownItems = 5;
            cbMaquinas.Name = "cbMaquinas";
            cbMaquinas.Size = new Size(386, 32);
            cbMaquinas.TabIndex = 1;
            cbMaquinas.SelectedIndexChanged += cbMaquinas_SelectedIndexChanged;
            // 
            // cbFalla
            // 
            cbFalla.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFalla.Font = new Font("Montserrat", 11F);
            cbFalla.FormattingEnabled = true;
            cbFalla.IntegralHeight = false;
            cbFalla.ItemHeight = 24;
            cbFalla.Location = new Point(101, 60);
            cbFalla.MaxDropDownItems = 5;
            cbFalla.Name = "cbFalla";
            cbFalla.Size = new Size(386, 32);
            cbFalla.TabIndex = 2;
            // 
            // btnRegistrarParo
            // 
            btnRegistrarParo.BackColor = Color.FromArgb(255, 102, 0);
            btnRegistrarParo.Cursor = Cursors.Hand;
            btnRegistrarParo.FlatAppearance.BorderSize = 0;
            btnRegistrarParo.FlatStyle = FlatStyle.Flat;
            btnRegistrarParo.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnRegistrarParo.ForeColor = Color.White;
            btnRegistrarParo.Location = new Point(458, 156);
            btnRegistrarParo.Name = "btnRegistrarParo";
            btnRegistrarParo.Size = new Size(323, 35);
            btnRegistrarParo.TabIndex = 6;
            btnRegistrarParo.Text = "REGISTRAR";
            btnRegistrarParo.UseVisualStyleBackColor = false;
            btnRegistrarParo.Click += btnRegistrarParo_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 11F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(16, 23);
            label10.Name = "label10";
            label10.Size = new Size(79, 24);
            label10.TabIndex = 114;
            label10.Text = "Maquina:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 11F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(16, 60);
            label5.Name = "label5";
            label5.Size = new Size(48, 24);
            label5.TabIndex = 119;
            label5.Text = "Falla:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 11F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(16, 116);
            label8.Name = "label8";
            label8.Size = new Size(122, 24);
            label8.TabIndex = 125;
            label8.Text = "Observaciones:";
            // 
            // txbObservaciones
            // 
            txbObservaciones.Font = new Font("Montserrat", 11F);
            txbObservaciones.Location = new Point(144, 113);
            txbObservaciones.Name = "txbObservaciones";
            txbObservaciones.Size = new Size(637, 25);
            txbObservaciones.TabIndex = 5;
            txbObservaciones.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Montserrat", 11F);
            label9.ForeColor = Color.White;
            label9.Location = new Point(509, 23);
            label9.Name = "label9";
            label9.Size = new Size(92, 24);
            label9.TabIndex = 127;
            label9.Text = "Hora Inicio:";
            // 
            // txbHoraInicio
            // 
            txbHoraInicio.Font = new Font("Montserrat", 11F);
            txbHoraInicio.Location = new Point(607, 22);
            txbHoraInicio.Name = "txbHoraInicio";
            txbHoraInicio.ReadOnly = true;
            txbHoraInicio.Size = new Size(174, 25);
            txbHoraInicio.TabIndex = 3;
            txbHoraInicio.TextAlign = HorizontalAlignment.Center;
            txbHoraInicio.KeyPress += txbHoraInicio_KeyPress;
            // 
            // dgvParosMaquinas
            // 
            dgvParosMaquinas.AllowUserToAddRows = false;
            dgvParosMaquinas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParosMaquinas.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvParosMaquinas.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvParosMaquinas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvParosMaquinas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvParosMaquinas.DefaultCellStyle = dataGridViewCellStyle2;
            dgvParosMaquinas.GridColor = SystemColors.ActiveCaptionText;
            dgvParosMaquinas.Location = new Point(16, 355);
            dgvParosMaquinas.Name = "dgvParosMaquinas";
            dgvParosMaquinas.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle3.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvParosMaquinas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvParosMaquinas.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 11.25F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvParosMaquinas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvParosMaquinas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParosMaquinas.Size = new Size(803, 221);
            dgvParosMaquinas.TabIndex = 148;
            dgvParosMaquinas.CellDoubleClick += dgvParosMaquinas_CellDoubleClick;
            dgvParosMaquinas.DataBindingComplete += dgvParosMaquinas_DataBindingComplete;
            // 
            // lblFecha
            // 
            lblFecha.BackColor = Color.Transparent;
            lblFecha.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblFecha.ForeColor = Color.White;
            lblFecha.Location = new Point(454, 92);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(365, 24);
            lblFecha.TabIndex = 149;
            lblFecha.Text = "FECHA: ERROR";
            lblFecha.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Produccion_ParoMaquinas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(837, 598);
            Controls.Add(lblFecha);
            Controls.Add(dgvParosMaquinas);
            Controls.Add(panel2);
            Controls.Add(lblNave);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_ParoMaquinas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Produccion_ParoMaquinas";
            Load += Produccion_ParoMaquinas_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)btncerrar).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvParosMaquinas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox btncerrar;
        private Label label1;
        private Label lblNave;
        private Panel panel2;
        private Label label10;
        private Label label8;
        private TextBox txbObservaciones;
        private Label label9;
        private TextBox txbHoraInicio;
        private Button btnRegistrarParo;
        private DataGridView dgvParosMaquinas;
        private Label lblFecha;
        private ComboBox comboBox2;
        private ComboBox cbMaquinas;
        private ComboBox cbFalla;
        private Label label5;
        private Label label2;
        private TextBox txbHoraFinal;
    }
}