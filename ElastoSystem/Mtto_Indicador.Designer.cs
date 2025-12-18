namespace ElastoSystem
{
    partial class Mtto_Indicador
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            label7 = new Label();
            panel1 = new Panel();
            cbAnio = new ComboBox();
            dgvMaquinas = new DataGridView();
            cbMeses = new ComboBox();
            label2 = new Label();
            panel2 = new Panel();
            txbIndicador = new TextBox();
            txbTotalFallas = new TextBox();
            label3 = new Label();
            label10 = new Label();
            panel3 = new Panel();
            label4 = new Label();
            dgvRegistros = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaquinas).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistros).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 22F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(24, 33);
            label1.Name = "label1";
            label1.Size = new Size(543, 47);
            label1.TabIndex = 1;
            label1.Text = "INDICADOR DE MANTENIMIENTO";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(71, 30);
            label7.Name = "label7";
            label7.Size = new Size(45, 24);
            label7.TabIndex = 13;
            label7.Text = "Año:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(cbAnio);
            panel1.Controls.Add(dgvMaquinas);
            panel1.Controls.Add(cbMeses);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(24, 98);
            panel1.Name = "panel1";
            panel1.Size = new Size(493, 700);
            panel1.TabIndex = 91;
            // 
            // cbAnio
            // 
            cbAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAnio.Font = new Font("Montserrat", 11F);
            cbAnio.FormattingEnabled = true;
            cbAnio.Items.AddRange(new object[] { "Alta", "Media", "Baja" });
            cbAnio.Location = new Point(122, 27);
            cbAnio.Name = "cbAnio";
            cbAnio.Size = new Size(291, 32);
            cbAnio.TabIndex = 20;
            cbAnio.SelectedIndexChanged += cbAnio_SelectedIndexChanged;
            // 
            // dgvMaquinas
            // 
            dgvMaquinas.AllowUserToAddRows = false;
            dgvMaquinas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMaquinas.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMaquinas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMaquinas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaquinas.Location = new Point(20, 120);
            dgvMaquinas.Name = "dgvMaquinas";
            dgvMaquinas.ReadOnly = true;
            dgvMaquinas.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvMaquinas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvMaquinas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaquinas.Size = new Size(451, 557);
            dgvMaquinas.TabIndex = 19;
            dgvMaquinas.DataBindingComplete += dgvMaquinas_DataBindingComplete;
            // 
            // cbMeses
            // 
            cbMeses.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMeses.Font = new Font("Montserrat", 11F);
            cbMeses.FormattingEnabled = true;
            cbMeses.Items.AddRange(new object[] { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" });
            cbMeses.Location = new Point(122, 71);
            cbMeses.Name = "cbMeses";
            cbMeses.Size = new Size(291, 32);
            cbMeses.TabIndex = 16;
            cbMeses.SelectedIndexChanged += cbMeses_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(71, 74);
            label2.Name = "label2";
            label2.Size = new Size(45, 24);
            label2.TabIndex = 15;
            label2.Text = "Mes:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(153, 255, 255, 255);
            panel2.Controls.Add(txbIndicador);
            panel2.Controls.Add(txbTotalFallas);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label10);
            panel2.Location = new Point(587, 607);
            panel2.Name = "panel2";
            panel2.Size = new Size(633, 191);
            panel2.TabIndex = 92;
            // 
            // txbIndicador
            // 
            txbIndicador.Font = new Font("Montserrat", 14F);
            txbIndicador.Location = new Point(185, 113);
            txbIndicador.Name = "txbIndicador";
            txbIndicador.ReadOnly = true;
            txbIndicador.Size = new Size(431, 30);
            txbIndicador.TabIndex = 76;
            txbIndicador.TextAlign = HorizontalAlignment.Center;
            // 
            // txbTotalFallas
            // 
            txbTotalFallas.Font = new Font("Montserrat", 14F);
            txbTotalFallas.Location = new Point(185, 47);
            txbTotalFallas.Name = "txbTotalFallas";
            txbTotalFallas.ReadOnly = true;
            txbTotalFallas.Size = new Size(431, 30);
            txbTotalFallas.TabIndex = 75;
            txbTotalFallas.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 14F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(3, 42, 76);
            label3.Location = new Point(19, 113);
            label3.Name = "label3";
            label3.Size = new Size(112, 30);
            label3.TabIndex = 74;
            label3.Text = "Indicador:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 14F, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(3, 42, 76);
            label10.Location = new Point(19, 47);
            label10.Name = "label10";
            label10.Size = new Size(160, 30);
            label10.TabIndex = 73;
            label10.Text = "Total de Fallas:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(3, 42, 76);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(dgvRegistros);
            panel3.Location = new Point(523, 98);
            panel3.Name = "panel3";
            panel3.Size = new Size(791, 503);
            panel3.TabIndex = 92;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 14F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(309, 22);
            label4.Name = "label4";
            label4.Size = new Size(187, 30);
            label4.TabIndex = 20;
            label4.Text = "Registro de Paros";
            // 
            // dgvRegistros
            // 
            dgvRegistros.AllowUserToAddRows = false;
            dgvRegistros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRegistros.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvRegistros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvRegistros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistros.Location = new Point(20, 60);
            dgvRegistros.Name = "dgvRegistros";
            dgvRegistros.ReadOnly = true;
            dgvRegistros.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvRegistros.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvRegistros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistros.Size = new Size(754, 426);
            dgvRegistros.TabIndex = 19;
            dgvRegistros.DataBindingComplete += dgvRegistros_DataBindingComplete;
            // 
            // Mtto_Indicador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Mtto_Indicador";
            Text = "Mtto_Indicador";
            Load += Mtto_Indicador_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaquinas).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbNivelPrio;
        private Label label7;
        private Panel panel1;
        private ComboBox cbMeses;
        private Label label2;
        private DataGridView dgvMaquinas;
        private Panel panel2;
        private Label label3;
        private Label label10;
        private TextBox txbIndicador;
        private TextBox txbTotalFallas;
        private ComboBox cbAnio;
        private Panel panel3;
        private DataGridView dgvRegistros;
        private Label label4;
    }
}