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
            panel1 = new Panel();
            lblGAtendidos = new Label();
            label10 = new Label();
            lblGPorcentaje = new Label();
            lblGNAtendidos = new Label();
            lblGPartidas = new Label();
            lblGDias = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            panel2 = new Panel();
            lblAtendidos = new Label();
            label9 = new Label();
            lblPorcentaje = new Label();
            lblNAtendidos = new Label();
            lblPartidas = new Label();
            lblDias = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            dgv.Size = new Size(1293, 528);
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
            lblOCTotal.Visible = false;
            // 
            // lblPromedioGlobal
            // 
            lblPromedioGlobal.AutoSize = true;
            lblPromedioGlobal.BackColor = Color.Transparent;
            lblPromedioGlobal.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblPromedioGlobal.ForeColor = SystemColors.ControlText;
            lblPromedioGlobal.Location = new Point(556, 9);
            lblPromedioGlobal.Name = "lblPromedioGlobal";
            lblPromedioGlobal.Size = new Size(192, 21);
            lblPromedioGlobal.TabIndex = 8;
            lblPromedioGlobal.Text = "PROMEDIO HISTORICO";
            lblPromedioGlobal.TextAlign = ContentAlignment.MiddleLeft;
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
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(153, 255, 255, 255);
            panel1.Controls.Add(lblGAtendidos);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(lblGPorcentaje);
            panel1.Controls.Add(lblGNAtendidos);
            panel1.Controls.Add(lblGPartidas);
            panel1.Controls.Add(lblGDias);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblPromedioGlobal);
            panel1.Location = new Point(22, 751);
            panel1.Name = "panel1";
            panel1.Size = new Size(1293, 68);
            panel1.TabIndex = 10;
            // 
            // lblGAtendidos
            // 
            lblGAtendidos.AutoSize = true;
            lblGAtendidos.BackColor = Color.Transparent;
            lblGAtendidos.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblGAtendidos.ForeColor = SystemColors.ControlText;
            lblGAtendidos.Location = new Point(754, 44);
            lblGAtendidos.Name = "lblGAtendidos";
            lblGAtendidos.Size = new Size(52, 16);
            lblGAtendidos.TabIndex = 19;
            lblGAtendidos.Text = "ERROR";
            lblGAtendidos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.ControlText;
            label10.Location = new Point(674, 44);
            label10.Name = "label10";
            label10.Size = new Size(74, 16);
            label10.TabIndex = 18;
            label10.Text = "Atendidos:";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblGPorcentaje
            // 
            lblGPorcentaje.AutoSize = true;
            lblGPorcentaje.BackColor = Color.Transparent;
            lblGPorcentaje.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblGPorcentaje.ForeColor = SystemColors.ControlText;
            lblGPorcentaje.Location = new Point(1214, 44);
            lblGPorcentaje.Name = "lblGPorcentaje";
            lblGPorcentaje.Size = new Size(52, 16);
            lblGPorcentaje.TabIndex = 16;
            lblGPorcentaje.Text = "ERROR";
            lblGPorcentaje.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblGNAtendidos
            // 
            lblGNAtendidos.AutoSize = true;
            lblGNAtendidos.BackColor = Color.Transparent;
            lblGNAtendidos.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblGNAtendidos.ForeColor = SystemColors.ControlText;
            lblGNAtendidos.Location = new Point(957, 44);
            lblGNAtendidos.Name = "lblGNAtendidos";
            lblGNAtendidos.Size = new Size(52, 16);
            lblGNAtendidos.TabIndex = 15;
            lblGNAtendidos.Text = "ERROR";
            lblGNAtendidos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblGPartidas
            // 
            lblGPartidas.AutoSize = true;
            lblGPartidas.BackColor = Color.Transparent;
            lblGPartidas.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblGPartidas.ForeColor = SystemColors.ControlText;
            lblGPartidas.Location = new Point(558, 44);
            lblGPartidas.Name = "lblGPartidas";
            lblGPartidas.Size = new Size(52, 16);
            lblGPartidas.TabIndex = 14;
            lblGPartidas.Text = "ERROR";
            lblGPartidas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblGDias
            // 
            lblGDias.AutoSize = true;
            lblGDias.BackColor = Color.Transparent;
            lblGDias.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblGDias.ForeColor = SystemColors.ControlText;
            lblGDias.Location = new Point(235, 44);
            lblGDias.Name = "lblGDias";
            lblGDias.Size = new Size(52, 16);
            lblGDias.TabIndex = 13;
            lblGDias.Text = "ERROR";
            lblGDias.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.ControlText;
            label8.Location = new Point(1054, 44);
            label8.Name = "label8";
            label8.Size = new Size(157, 16);
            label8.TabIndex = 12;
            label8.Text = "Porcentaje no atendido:";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ControlText;
            label7.Location = new Point(861, 44);
            label7.Name = "label7";
            label7.Size = new Size(93, 16);
            label7.TabIndex = 11;
            label7.Text = "No atendidos:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlText;
            label6.Location = new Point(339, 44);
            label6.Name = "label6";
            label6.Size = new Size(216, 16);
            label6.TabIndex = 10;
            label6.Text = "Registros considerados (partidas):";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(11, 44);
            label5.Name = "label5";
            label5.Size = new Size(221, 16);
            label5.TabIndex = 9;
            label5.Text = "Tiempo ciclo de adquisicion (dias):";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(153, 255, 255, 255);
            panel2.Controls.Add(lblAtendidos);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(lblPorcentaje);
            panel2.Controls.Add(lblNAtendidos);
            panel2.Controls.Add(lblPartidas);
            panel2.Controls.Add(lblDias);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(label17);
            panel2.Location = new Point(992, 28);
            panel2.Name = "panel2";
            panel2.Size = new Size(312, 183);
            panel2.TabIndex = 11;
            // 
            // lblAtendidos
            // 
            lblAtendidos.AutoSize = true;
            lblAtendidos.BackColor = Color.Transparent;
            lblAtendidos.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblAtendidos.ForeColor = SystemColors.ControlText;
            lblAtendidos.Location = new Point(242, 98);
            lblAtendidos.Name = "lblAtendidos";
            lblAtendidos.Size = new Size(15, 16);
            lblAtendidos.TabIndex = 18;
            lblAtendidos.Text = "0";
            lblAtendidos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlText;
            label9.Location = new Point(8, 98);
            label9.Name = "label9";
            label9.Size = new Size(74, 16);
            label9.TabIndex = 17;
            label9.Text = "Atendidos:";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPorcentaje
            // 
            lblPorcentaje.AutoSize = true;
            lblPorcentaje.BackColor = Color.Transparent;
            lblPorcentaje.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPorcentaje.ForeColor = SystemColors.ControlText;
            lblPorcentaje.Location = new Point(242, 146);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new Size(26, 16);
            lblPorcentaje.TabIndex = 16;
            lblPorcentaje.Text = "0%";
            lblPorcentaje.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNAtendidos
            // 
            lblNAtendidos.AutoSize = true;
            lblNAtendidos.BackColor = Color.Transparent;
            lblNAtendidos.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblNAtendidos.ForeColor = SystemColors.ControlText;
            lblNAtendidos.Location = new Point(242, 122);
            lblNAtendidos.Name = "lblNAtendidos";
            lblNAtendidos.Size = new Size(15, 16);
            lblNAtendidos.TabIndex = 15;
            lblNAtendidos.Text = "0";
            lblNAtendidos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPartidas
            // 
            lblPartidas.AutoSize = true;
            lblPartidas.BackColor = Color.Transparent;
            lblPartidas.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPartidas.ForeColor = SystemColors.ControlText;
            lblPartidas.Location = new Point(242, 74);
            lblPartidas.Name = "lblPartidas";
            lblPartidas.Size = new Size(15, 16);
            lblPartidas.TabIndex = 14;
            lblPartidas.Text = "0";
            lblPartidas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDias
            // 
            lblDias.AutoSize = true;
            lblDias.BackColor = Color.Transparent;
            lblDias.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDias.ForeColor = SystemColors.ControlText;
            lblDias.Location = new Point(242, 50);
            lblDias.Name = "lblDias";
            lblDias.Size = new Size(15, 16);
            lblDias.TabIndex = 13;
            lblDias.Text = "0";
            lblDias.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = SystemColors.ControlText;
            label13.Location = new Point(8, 146);
            label13.Name = "label13";
            label13.Size = new Size(157, 16);
            label13.TabIndex = 12;
            label13.Text = "Porcentaje no atendido:";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = SystemColors.ControlText;
            label14.Location = new Point(8, 122);
            label14.Name = "label14";
            label14.Size = new Size(93, 16);
            label14.TabIndex = 11;
            label14.Text = "No atendidos:";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = SystemColors.ControlText;
            label15.Location = new Point(8, 74);
            label15.Name = "label15";
            label15.Size = new Size(216, 16);
            label15.TabIndex = 10;
            label15.Text = "Registros considerados (partidas):";
            label15.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label16.ForeColor = SystemColors.ControlText;
            label16.Location = new Point(8, 50);
            label16.Name = "label16";
            label16.Size = new Size(221, 16);
            label16.TabIndex = 9;
            label16.Text = "Tiempo ciclo de adquisicion (dias):";
            label16.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Transparent;
            label17.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = SystemColors.ControlText;
            label17.Location = new Point(113, 14);
            label17.Name = "label17";
            label17.Size = new Size(99, 21);
            label17.TabIndex = 8;
            label17.Text = "PROMEDIO";
            label17.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // IndicadorCompras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label4);
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
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Panel panel1;
        private Label label5;
        private Label lblGPorcentaje;
        private Label lblGNAtendidos;
        private Label lblGPartidas;
        private Label lblGDias;
        private Label label8;
        private Label label7;
        private Label label6;
        private Panel panel2;
        private Label lblPorcentaje;
        private Label lblNAtendidos;
        private Label lblPartidas;
        private Label lblDias;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label lblGAtendidos;
        private Label label10;
        private Label lblAtendidos;
        private Label label9;
    }
}