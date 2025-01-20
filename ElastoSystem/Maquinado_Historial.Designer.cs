namespace ElastoSystem
{
    partial class Maquinado_Historial
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
            label1 = new Label();
            btnDescargar = new Button();
            dgvHistorialMaquinado = new DataGridView();
            txbBuscador = new TextBox();
            label3 = new Label();
            txbFolio = new TextBox();
            txbNombreArchivo = new TextBox();
            txbRuta = new TextBox();
            txbBuscadorGeneral = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialMaquinado).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(21, 24);
            label1.Name = "label1";
            label1.Size = new Size(487, 44);
            label1.TabIndex = 3;
            label1.Text = "HISTORIAL DE MAQUINADO";
            // 
            // btnDescargar
            // 
            btnDescargar.BackColor = Color.FromArgb(255, 102, 0);
            btnDescargar.Cursor = Cursors.Hand;
            btnDescargar.FlatAppearance.BorderSize = 0;
            btnDescargar.FlatStyle = FlatStyle.Flat;
            btnDescargar.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnDescargar.ForeColor = Color.White;
            btnDescargar.Location = new Point(1044, 97);
            btnDescargar.Name = "btnDescargar";
            btnDescargar.Size = new Size(252, 38);
            btnDescargar.TabIndex = 22;
            btnDescargar.Text = "DESCARGAR COMPROBANTE";
            btnDescargar.UseVisualStyleBackColor = false;
            btnDescargar.Visible = false;
            btnDescargar.Click += btnDescargar_Click_1;
            // 
            // dgvHistorialMaquinado
            // 
            dgvHistorialMaquinado.AllowUserToAddRows = false;
            dgvHistorialMaquinado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorialMaquinado.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvHistorialMaquinado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvHistorialMaquinado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorialMaquinado.Location = new Point(21, 155);
            dgvHistorialMaquinado.Name = "dgvHistorialMaquinado";
            dgvHistorialMaquinado.ReadOnly = true;
            dgvHistorialMaquinado.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvHistorialMaquinado.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvHistorialMaquinado.RowTemplate.Height = 25;
            dgvHistorialMaquinado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorialMaquinado.Size = new Size(1275, 626);
            dgvHistorialMaquinado.TabIndex = 23;
            dgvHistorialMaquinado.SelectionChanged += dgvHistorialMaquinado_SelectionChanged;
            // 
            // txbBuscador
            // 
            txbBuscador.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbBuscador.Location = new Point(144, 98);
            txbBuscador.Name = "txbBuscador";
            txbBuscador.Size = new Size(208, 27);
            txbBuscador.TabIndex = 25;
            txbBuscador.TextChanged += txbBuscador_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(21, 97);
            label3.Name = "label3";
            label3.Size = new Size(112, 27);
            label3.TabIndex = 24;
            label3.Text = "Buscador:";
            // 
            // txbFolio
            // 
            txbFolio.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbFolio.Location = new Point(936, 97);
            txbFolio.Name = "txbFolio";
            txbFolio.Size = new Size(102, 27);
            txbFolio.TabIndex = 26;
            txbFolio.Visible = false;
            txbFolio.TextChanged += txbFolio_TextChanged;
            // 
            // txbNombreArchivo
            // 
            txbNombreArchivo.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbNombreArchivo.Location = new Point(1044, 12);
            txbNombreArchivo.Name = "txbNombreArchivo";
            txbNombreArchivo.Size = new Size(257, 27);
            txbNombreArchivo.TabIndex = 27;
            txbNombreArchivo.Visible = false;
            // 
            // txbRuta
            // 
            txbRuta.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbRuta.Location = new Point(1044, 45);
            txbRuta.Name = "txbRuta";
            txbRuta.Size = new Size(257, 27);
            txbRuta.TabIndex = 28;
            txbRuta.Visible = false;
            // 
            // txbBuscadorGeneral
            // 
            txbBuscadorGeneral.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbBuscadorGeneral.Location = new Point(144, 97);
            txbBuscadorGeneral.Name = "txbBuscadorGeneral";
            txbBuscadorGeneral.Size = new Size(208, 27);
            txbBuscadorGeneral.TabIndex = 29;
            txbBuscadorGeneral.TextChanged += txbBuscadorGeneral_TextChanged;
            // 
            // Maquinado_Historial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(txbBuscadorGeneral);
            Controls.Add(txbRuta);
            Controls.Add(txbNombreArchivo);
            Controls.Add(txbFolio);
            Controls.Add(txbBuscador);
            Controls.Add(label3);
            Controls.Add(dgvHistorialMaquinado);
            Controls.Add(btnDescargar);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Maquinado_Historial";
            Text = "Maquinado_Historial";
            Load += Maquinado_Historial_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistorialMaquinado).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnDescargar;
        private DataGridView dgvHistorialMaquinado;
        private TextBox txbBuscador;
        private Label label3;
        private TextBox txbFolio;
        private TextBox txbNombreArchivo;
        private TextBox txbRuta;
        private TextBox txbBuscadorGeneral;
    }
}