namespace ElastoSystem
{
    partial class Almacen_Fabricacion
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
            pnlAlmacen = new Panel();
            btnCerrar = new Button();
            dgvProductosSAE = new DataGridView();
            label9 = new Label();
            btnAbrir = new Button();
            pnlAlmacen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductosSAE).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(43, 37);
            label1.Name = "label1";
            label1.Size = new Size(500, 44);
            label1.TabIndex = 1;
            label1.Text = "SOLICITUD DE FABRICACION";
            // 
            // pnlAlmacen
            // 
            pnlAlmacen.BackColor = Color.FromArgb(3, 42, 76);
            pnlAlmacen.Controls.Add(btnCerrar);
            pnlAlmacen.Controls.Add(dgvProductosSAE);
            pnlAlmacen.Controls.Add(label9);
            pnlAlmacen.Location = new Point(36, 96);
            pnlAlmacen.Name = "pnlAlmacen";
            pnlAlmacen.Size = new Size(1277, 705);
            pnlAlmacen.TabIndex = 19;
            pnlAlmacen.Visible = false;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(255, 102, 0);
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(1090, 18);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(151, 35);
            btnCerrar.TabIndex = 19;
            btnCerrar.Text = "CERRAR";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // dgvProductosSAE
            // 
            dgvProductosSAE.AllowUserToAddRows = false;
            dgvProductosSAE.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductosSAE.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProductosSAE.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductosSAE.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductosSAE.Location = new Point(19, 59);
            dgvProductosSAE.Name = "dgvProductosSAE";
            dgvProductosSAE.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvProductosSAE.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvProductosSAE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductosSAE.Size = new Size(1222, 624);
            dgvProductosSAE.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(19, 17);
            label9.Name = "label9";
            label9.Size = new Size(263, 30);
            label9.TabIndex = 17;
            label9.Text = "ALMACEN ASPEL SAE";
            // 
            // btnAbrir
            // 
            btnAbrir.BackColor = Color.FromArgb(255, 102, 0);
            btnAbrir.Cursor = Cursors.Hand;
            btnAbrir.FlatAppearance.BorderSize = 0;
            btnAbrir.FlatStyle = FlatStyle.Flat;
            btnAbrir.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnAbrir.ForeColor = Color.White;
            btnAbrir.Location = new Point(1034, 114);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(225, 35);
            btnAbrir.TabIndex = 20;
            btnAbrir.Text = "ABRIR ALMACEN SAE";
            btnAbrir.UseVisualStyleBackColor = false;
            btnAbrir.Click += btnAbrir_Click;
            // 
            // Almacen_Fabricacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(pnlAlmacen);
            Controls.Add(btnAbrir);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Almacen_Fabricacion";
            Text = "Almacen_Fabricacion";
            Load += Almacen_Fabricacion_Load;
            pnlAlmacen.ResumeLayout(false);
            pnlAlmacen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductosSAE).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel pnlAlmacen;
        private DataGridView dgvProductosSAE;
        private Label label9;
        private Button btnCerrar;
        private Button btnAbrir;
    }
}