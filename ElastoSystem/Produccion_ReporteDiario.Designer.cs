namespace ElastoSystem
{
    partial class Produccion_ReporteDiario
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabNave1 = new TabPage();
            label2 = new Label();
            button1 = new Button();
            dgvNave1 = new DataGridView();
            tabNave2 = new TabPage();
            label3 = new Label();
            btnActualizarEncabezado = new Button();
            dgvNave2 = new DataGridView();
            tabEditarReporte = new TabPage();
            tabControl1.SuspendLayout();
            tabNave1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNave1).BeginInit();
            tabNave2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNave2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 22F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(16, 21);
            label1.Name = "label1";
            label1.Size = new Size(403, 41);
            label1.TabIndex = 15;
            label1.Text = "REPORTE PRODUCCIÓN";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabNave1);
            tabControl1.Controls.Add(tabNave2);
            tabControl1.Controls.Add(tabEditarReporte);
            tabControl1.Location = new Point(12, 78);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1314, 732);
            tabControl1.TabIndex = 16;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabNave1
            // 
            tabNave1.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabNave1.Controls.Add(label2);
            tabNave1.Controls.Add(button1);
            tabNave1.Controls.Add(dgvNave1);
            tabNave1.Location = new Point(4, 24);
            tabNave1.Name = "tabNave1";
            tabNave1.Padding = new Padding(3);
            tabNave1.Size = new Size(1306, 704);
            tabNave1.TabIndex = 1;
            tabNave1.Text = "NAVE 1";
            tabNave1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 22F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(21, 18);
            label2.Name = "label2";
            label2.Size = new Size(1265, 41);
            label2.TabIndex = 75;
            label2.Text = "NAVE 1";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 102, 0);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(525, 646);
            button1.Name = "button1";
            button1.Size = new Size(275, 35);
            button1.TabIndex = 74;
            button1.Text = "FIRMAR REPORTE";
            button1.UseVisualStyleBackColor = false;
            // 
            // dgvNave1
            // 
            dgvNave1.AllowUserToAddRows = false;
            dgvNave1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNave1.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvNave1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvNave1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNave1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvNave1.DefaultCellStyle = dataGridViewCellStyle2;
            dgvNave1.GridColor = SystemColors.ActiveCaptionText;
            dgvNave1.Location = new Point(21, 73);
            dgvNave1.Name = "dgvNave1";
            dgvNave1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle3.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvNave1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvNave1.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 11.25F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvNave1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvNave1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNave1.Size = new Size(1265, 553);
            dgvNave1.TabIndex = 73;
            // 
            // tabNave2
            // 
            tabNave2.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabNave2.Controls.Add(label3);
            tabNave2.Controls.Add(btnActualizarEncabezado);
            tabNave2.Controls.Add(dgvNave2);
            tabNave2.Location = new Point(4, 24);
            tabNave2.Name = "tabNave2";
            tabNave2.Size = new Size(1306, 704);
            tabNave2.TabIndex = 2;
            tabNave2.Text = "NAVE 2";
            tabNave2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 22F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(24, 15);
            label3.Name = "label3";
            label3.Size = new Size(1265, 41);
            label3.TabIndex = 76;
            label3.Text = "NAVE 2";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnActualizarEncabezado
            // 
            btnActualizarEncabezado.BackColor = Color.FromArgb(255, 102, 0);
            btnActualizarEncabezado.Cursor = Cursors.Hand;
            btnActualizarEncabezado.FlatAppearance.BorderSize = 0;
            btnActualizarEncabezado.FlatStyle = FlatStyle.Flat;
            btnActualizarEncabezado.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnActualizarEncabezado.ForeColor = Color.White;
            btnActualizarEncabezado.Location = new Point(1015, 648);
            btnActualizarEncabezado.Name = "btnActualizarEncabezado";
            btnActualizarEncabezado.Size = new Size(275, 35);
            btnActualizarEncabezado.TabIndex = 72;
            btnActualizarEncabezado.Text = "FIRMAR REPORTE";
            btnActualizarEncabezado.UseVisualStyleBackColor = false;
            btnActualizarEncabezado.Visible = false;
            // 
            // dgvNave2
            // 
            dgvNave2.AllowUserToAddRows = false;
            dgvNave2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNave2.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvNave2.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvNave2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvNave2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvNave2.DefaultCellStyle = dataGridViewCellStyle6;
            dgvNave2.GridColor = SystemColors.ActiveCaptionText;
            dgvNave2.Location = new Point(25, 67);
            dgvNave2.Name = "dgvNave2";
            dgvNave2.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle7.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvNave2.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvNave2.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Montserrat", 11.25F);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dgvNave2.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dgvNave2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNave2.Size = new Size(1265, 565);
            dgvNave2.TabIndex = 50;
            // 
            // tabEditarReporte
            // 
            tabEditarReporte.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabEditarReporte.Location = new Point(4, 24);
            tabEditarReporte.Name = "tabEditarReporte";
            tabEditarReporte.Size = new Size(1306, 704);
            tabEditarReporte.TabIndex = 3;
            tabEditarReporte.Text = "EDITAR REPORTE";
            tabEditarReporte.UseVisualStyleBackColor = true;
            // 
            // Produccion_ReporteDiario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_ReporteDiario";
            Text = "Produccion_ReporteDiario";
            Load += Produccion_ReporteDiario_Load;
            tabControl1.ResumeLayout(false);
            tabNave1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNave1).EndInit();
            tabNave2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNave2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TabControl tabControl1;
        private TabPage tabNave1;
        private TabPage tabNave2;
        private Button btnActualizarEncabezado;
        private DataGridView dgvNave2;
        private TabPage tabEditarReporte;
        private Label label2;
        private Button button1;
        private DataGridView dgvNave1;
        private Label label3;
    }
}