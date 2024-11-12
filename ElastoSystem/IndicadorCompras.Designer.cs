namespace ElastoSystem
{
    partial class IndicadorCompras
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
            cbAnios = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cbbimestre = new ComboBox();
            label3 = new Label();
            txbic = new TextBox();
            dgv = new DataGridView();
            lblOCTotal = new Label();
            lblPromedioGlobal = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // cbAnios
            // 
            cbAnios.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAnios.Font = new Font("Montserrat", 15F, FontStyle.Regular, GraphicsUnit.Point);
            cbAnios.FormattingEnabled = true;
            cbAnios.Location = new Point(61, 138);
            cbAnios.Name = "cbAnios";
            cbAnios.Size = new Size(270, 35);
            cbAnios.TabIndex = 0;
            cbAnios.SelectedIndexChanged += cbanio_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(61, 105);
            label1.Name = "label1";
            label1.Size = new Size(67, 30);
            label1.TabIndex = 1;
            label1.Text = "AÑO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(359, 105);
            label2.Name = "label2";
            label2.Size = new Size(132, 30);
            label2.TabIndex = 3;
            label2.Text = "BIMESTRE";
            // 
            // cbbimestre
            // 
            cbbimestre.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbimestre.Font = new Font("Montserrat", 15F, FontStyle.Regular, GraphicsUnit.Point);
            cbbimestre.FormattingEnabled = true;
            cbbimestre.Items.AddRange(new object[] { "Enero - Febrero", "Marzo - Abril", "Mayo - Junio", "Julio - Agosto", "Septiembre - Octubre", "Noviembre - Diciembre" });
            cbbimestre.Location = new Point(359, 138);
            cbbimestre.Name = "cbbimestre";
            cbbimestre.Size = new Size(270, 35);
            cbbimestre.TabIndex = 2;
            cbbimestre.SelectedIndexChanged += cbbimestre_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(669, 105);
            label3.Name = "label3";
            label3.Size = new Size(274, 30);
            label3.TabIndex = 4;
            label3.Text = "INDICADOR COMPRAS";
            // 
            // txbic
            // 
            txbic.Font = new Font("Montserrat", 15F, FontStyle.Regular, GraphicsUnit.Point);
            txbic.Location = new Point(669, 138);
            txbic.Multiline = true;
            txbic.Name = "txbic";
            txbic.ReadOnly = true;
            txbic.Size = new Size(270, 35);
            txbic.TabIndex = 5;
            txbic.TextChanged += txbic_TextChanged;
            // 
            // dgv
            // 
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Montserrat SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(22, 217);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Montserrat", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dgv.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgv.RowTemplate.Height = 25;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(1289, 556);
            dgv.TabIndex = 6;
            // 
            // lblOCTotal
            // 
            lblOCTotal.AutoSize = true;
            lblOCTotal.BackColor = Color.Transparent;
            lblOCTotal.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblOCTotal.ForeColor = Color.White;
            lblOCTotal.Location = new Point(963, 150);
            lblOCTotal.Name = "lblOCTotal";
            lblOCTotal.Size = new Size(0, 16);
            lblOCTotal.TabIndex = 7;
            // 
            // lblPromedioGlobal
            // 
            lblPromedioGlobal.AutoSize = true;
            lblPromedioGlobal.BackColor = Color.Transparent;
            lblPromedioGlobal.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPromedioGlobal.ForeColor = Color.White;
            lblPromedioGlobal.Location = new Point(986, 776);
            lblPromedioGlobal.Name = "lblPromedioGlobal";
            lblPromedioGlobal.Size = new Size(183, 16);
            lblPromedioGlobal.TabIndex = 8;
            lblPromedioGlobal.Text = "ERROR PROMEDIO GLOBAL ";
            lblPromedioGlobal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(22, 28);
            label4.Name = "label4";
            label4.Size = new Size(388, 37);
            label4.TabIndex = 9;
            label4.Text = "INDICADOR DE COMPRAS";
            // 
            // IndicadorCompras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(label4);
            Controls.Add(lblPromedioGlobal);
            Controls.Add(lblOCTotal);
            Controls.Add(dgv);
            Controls.Add(txbic);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cbbimestre);
            Controls.Add(label1);
            Controls.Add(cbAnios);
            FormBorderStyle = FormBorderStyle.None;
            Name = "IndicadorCompras";
            Text = "IndicadorCompras";
            Load += IndicadorCompras_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbAnios;
        private Label label1;
        private Label label2;
        private ComboBox cbbimestre;
        private Label label3;
        private TextBox txbic;
        private DataGridView dgv;
        private Label lblOCTotal;
        private Label lblPromedioGlobal;
        private Label label4;
    }
}