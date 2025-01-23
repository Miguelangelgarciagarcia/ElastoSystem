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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            dgvProductosSAE = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProductosSAE).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 22F, FontStyle.Bold, GraphicsUnit.Point);
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
            dataGridViewCellStyle1.Font = new Font("Montserrat", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProductosSAE.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductosSAE.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductosSAE.Location = new Point(23, 110);
            dgvProductosSAE.Name = "dgvProductosSAE";
            dgvProductosSAE.ReadOnly = true;
            dgvProductosSAE.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvProductosSAE.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvProductosSAE.RowTemplate.Height = 25;
            dgvProductosSAE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductosSAE.Size = new Size(1275, 692);
            dgvProductosSAE.TabIndex = 24;
            dgvProductosSAE.CellFormatting += dgvProductosSAE_CellFormatting;
            dgvProductosSAE.DataBindingComplete += dgvProductosSAE_DataBindingComplete;
            // 
            // Almacen_InventarioAlmacen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(dgvProductosSAE);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Almacen_InventarioAlmacen";
            Text = "Almacen_InventarioAlmacen";
            Load += Almacen_InventarioAlmacen_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductosSAE).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvProductosSAE;
    }
}