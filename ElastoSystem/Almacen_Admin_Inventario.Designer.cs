namespace ElastoSystem
{
    partial class Almacen_Admin_Inventario
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
            label1 = new Label();
            label2 = new Label();
            cbProductos = new ComboBox();
            label3 = new Label();
            btnActualizar = new Button();
            txbConsumoMensual = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 22F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(23, 27);
            label1.Name = "label1";
            label1.Size = new Size(362, 41);
            label1.TabIndex = 1;
            label1.Text = "ADMINISTRAR PT SAE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(34, 90);
            label2.Name = "label2";
            label2.Size = new Size(87, 22);
            label2.TabIndex = 2;
            label2.Text = "Producto:";
            // 
            // cbProductos
            // 
            cbProductos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbProductos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbProductos.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbProductos.FormattingEnabled = true;
            cbProductos.Location = new Point(204, 86);
            cbProductos.Name = "cbProductos";
            cbProductos.Size = new Size(288, 30);
            cbProductos.TabIndex = 3;
            cbProductos.SelectedIndexChanged += cbProductos_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(34, 125);
            label3.Name = "label3";
            label3.Size = new Size(164, 22);
            label3.TabIndex = 4;
            label3.Text = "Consumo Mensual:";
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(255, 102, 0);
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(531, 103);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(173, 34);
            btnActualizar.TabIndex = 9;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click_1;
            // 
            // txbConsumoMensual
            // 
            txbConsumoMensual.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbConsumoMensual.Location = new Point(204, 122);
            txbConsumoMensual.Name = "txbConsumoMensual";
            txbConsumoMensual.Size = new Size(288, 27);
            txbConsumoMensual.TabIndex = 41;
            // 
            // Almacen_Admin_Inventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(txbConsumoMensual);
            Controls.Add(btnActualizar);
            Controls.Add(label3);
            Controls.Add(cbProductos);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Almacen_Admin_Inventario";
            Text = "Almacen_Admin_Inventario";
            Load += Almacen_Admin_Inventario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbProductos;
        private Label label3;
        private Button btnActualizar;
        private TextBox txbConsumoMensual;
    }
}