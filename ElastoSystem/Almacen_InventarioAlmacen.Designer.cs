namespace ElastoSystem
{
    partial class Almacen_InventarioAlmacen
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            dgvProductosSAE = new DataGridView();
            dgvProductosSAE2 = new DataGridView();
            bSAspelSAE = new BindingSource(components);
            lblSincronizacion = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductosSAE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductosSAE2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bSAspelSAE).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 22F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(23, 22);
            label1.Name = "label1";
            label1.Size = new Size(334, 41);
            label1.TabIndex = 2;
            label1.Text = "INVENTARIO PT SAE";
            // 
            // dgvProductosSAE
            // 
            dgvProductosSAE.AllowUserToAddRows = false;
            dgvProductosSAE.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductosSAE.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 9.749999F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProductosSAE.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductosSAE.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductosSAE.Location = new Point(23, 77);
            dgvProductosSAE.Name = "dgvProductosSAE";
            dgvProductosSAE.ReadOnly = true;
            dgvProductosSAE.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 10F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvProductosSAE.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvProductosSAE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductosSAE.Size = new Size(1275, 692);
            dgvProductosSAE.TabIndex = 24;
            dgvProductosSAE.CellFormatting += dgvProductosSAE_CellFormatting;
            dgvProductosSAE.DataBindingComplete += dgvProductosSAE_DataBindingComplete;
            // 
            // dgvProductosSAE2
            // 
            dgvProductosSAE2.AllowUserToAddRows = false;
            dgvProductosSAE2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductosSAE2.Location = new Point(384, 39);
            dgvProductosSAE2.Name = "dgvProductosSAE2";
            dgvProductosSAE2.Size = new Size(21, 24);
            dgvProductosSAE2.TabIndex = 59;
            dgvProductosSAE2.Visible = false;
            // 
            // lblSincronizacion
            // 
            lblSincronizacion.AutoSize = true;
            lblSincronizacion.BackColor = Color.Transparent;
            lblSincronizacion.Font = new Font("Montserrat", 9F);
            lblSincronizacion.ForeColor = Color.White;
            lblSincronizacion.Location = new Point(1018, 781);
            lblSincronizacion.Name = "lblSincronizacion";
            lblSincronizacion.Size = new Size(10, 16);
            lblSincronizacion.TabIndex = 61;
            lblSincronizacion.Text = ".";
            lblSincronizacion.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Almacen_InventarioAlmacen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(lblSincronizacion);
            Controls.Add(dgvProductosSAE2);
            Controls.Add(dgvProductosSAE);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Almacen_InventarioAlmacen";
            Text = "Almacen_InventarioAlmacen";
            Load += Almacen_InventarioAlmacen_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductosSAE).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductosSAE2).EndInit();
            ((System.ComponentModel.ISupportInitialize)bSAspelSAE).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvProductosSAE;
        private DataGridView dgvProductosSAE2;
        private BindingSource bSAspelSAE;
        private Label lblSincronizacion;
    }
}