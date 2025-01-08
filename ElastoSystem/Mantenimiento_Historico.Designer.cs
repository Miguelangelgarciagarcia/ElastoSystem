namespace ElastoSystem
{
    partial class Mantenimiento_Historico
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
            pnlComprobante = new Panel();
            dgvMantenimiento = new DataGridView();
            btnDescargar = new Button();
            txbRuta = new TextBox();
            txbNombreArchivo = new TextBox();
            txbFolio = new TextBox();
            pnlComprobante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMantenimiento).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(509, 44);
            label1.TabIndex = 4;
            label1.Text = "HISTORICO MANTENIMIENTO";
            // 
            // pnlComprobante
            // 
            pnlComprobante.BackColor = Color.FromArgb(3, 42, 76);
            pnlComprobante.Controls.Add(dgvMantenimiento);
            pnlComprobante.Location = new Point(23, 89);
            pnlComprobante.Name = "pnlComprobante";
            pnlComprobante.Size = new Size(1287, 716);
            pnlComprobante.TabIndex = 45;
            // 
            // dgvMantenimiento
            // 
            dgvMantenimiento.AllowUserToAddRows = false;
            dgvMantenimiento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMantenimiento.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvMantenimiento.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMantenimiento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMantenimiento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMantenimiento.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMantenimiento.GridColor = SystemColors.ActiveCaptionText;
            dgvMantenimiento.Location = new Point(25, 25);
            dgvMantenimiento.Name = "dgvMantenimiento";
            dgvMantenimiento.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle3.Font = new Font("Montserrat", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvMantenimiento.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvMantenimiento.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvMantenimiento.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvMantenimiento.RowTemplate.Height = 25;
            dgvMantenimiento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMantenimiento.Size = new Size(1235, 667);
            dgvMantenimiento.TabIndex = 43;
            dgvMantenimiento.SelectionChanged += dgvMantenimiento_SelectionChanged;
            // 
            // btnDescargar
            // 
            btnDescargar.BackColor = Color.FromArgb(255, 102, 0);
            btnDescargar.Cursor = Cursors.Hand;
            btnDescargar.FlatAppearance.BorderSize = 0;
            btnDescargar.FlatStyle = FlatStyle.Flat;
            btnDescargar.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnDescargar.ForeColor = Color.White;
            btnDescargar.Location = new Point(1060, 45);
            btnDescargar.Name = "btnDescargar";
            btnDescargar.Size = new Size(223, 38);
            btnDescargar.TabIndex = 48;
            btnDescargar.Text = "Descargar Comprobante";
            btnDescargar.UseVisualStyleBackColor = false;
            btnDescargar.Visible = false;
            btnDescargar.Click += btnCargarDoc_Click;
            // 
            // txbRuta
            // 
            txbRuta.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbRuta.Location = new Point(828, 56);
            txbRuta.Name = "txbRuta";
            txbRuta.Size = new Size(187, 27);
            txbRuta.TabIndex = 51;
            txbRuta.Visible = false;
            // 
            // txbNombreArchivo
            // 
            txbNombreArchivo.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNombreArchivo.Location = new Point(828, 23);
            txbNombreArchivo.Name = "txbNombreArchivo";
            txbNombreArchivo.Size = new Size(187, 27);
            txbNombreArchivo.TabIndex = 50;
            txbNombreArchivo.Visible = false;
            // 
            // txbFolio
            // 
            txbFolio.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbFolio.Location = new Point(627, 56);
            txbFolio.Name = "txbFolio";
            txbFolio.Size = new Size(167, 27);
            txbFolio.TabIndex = 49;
            txbFolio.Visible = false;
            // 
            // Mantenimiento_Historico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(txbRuta);
            Controls.Add(txbNombreArchivo);
            Controls.Add(txbFolio);
            Controls.Add(btnDescargar);
            Controls.Add(pnlComprobante);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Mantenimiento_Historico";
            Text = "Mantenimiento_Historico";
            Load += Mantenimiento_Historico_Load;
            pnlComprobante.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMantenimiento).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel pnlComprobante;
        private DataGridView dgvMantenimiento;
        private Button btnDescargar;
        private TextBox txbRuta;
        private TextBox txbNombreArchivo;
        private TextBox txbFolio;
    }
}