namespace ElastoSystem
{
    partial class Almacen_FacturasSAE_Filtro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Almacen_FacturasSAE_Filtro));
            panel3 = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox6 = new PictureBox();
            label1 = new Label();
            cbProductos = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txbFechaInicio = new TextBox();
            txbFechaFin = new TextBox();
            btnBuscar = new Button();
            chbTodoslosProductos = new CheckBox();
            chbNoFiltrarFechas = new CheckBox();
            chbTodosClientes = new CheckBox();
            cbClientes = new ComboBox();
            label5 = new Label();
            bindingSource1 = new BindingSource(components);
            lblClaveCliente = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(153, 255, 255, 255);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(pictureBox6);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(696, 30);
            panel3.TabIndex = 51;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(663, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(23, 23);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 20;
            pictureBox4.TabStop = false;
            pictureBox4.MouseMove += pictureBox4_MouseMove;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Cursor = Cursors.Hand;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(663, 4);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(23, 23);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 18;
            pictureBox6.TabStop = false;
            pictureBox6.Click += pictureBox6_Click;
            pictureBox6.MouseLeave += pictureBox6_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(29, 51);
            label1.Name = "label1";
            label1.Size = new Size(109, 30);
            label1.TabIndex = 52;
            label1.Text = "FILTRAR";
            // 
            // cbProductos
            // 
            cbProductos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbProductos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbProductos.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbProductos.FormattingEnabled = true;
            cbProductos.Location = new Point(153, 115);
            cbProductos.Name = "cbProductos";
            cbProductos.Size = new Size(473, 30);
            cbProductos.TabIndex = 54;
            cbProductos.SelectedIndexChanged += cbProductos_SelectedIndexChanged;
            cbProductos.TextChanged += cbProductos_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(29, 118);
            label2.Name = "label2";
            label2.Size = new Size(87, 22);
            label2.TabIndex = 53;
            label2.Text = "Producto:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(22, 264);
            label3.Name = "label3";
            label3.Size = new Size(109, 22);
            label3.TabIndex = 55;
            label3.Text = "Fecha Inicio:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(27, 297);
            label4.Name = "label4";
            label4.Size = new Size(104, 22);
            label4.TabIndex = 56;
            label4.Text = "Fecha Final:";
            // 
            // txbFechaInicio
            // 
            txbFechaInicio.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbFechaInicio.Location = new Point(153, 261);
            txbFechaInicio.Name = "txbFechaInicio";
            txbFechaInicio.Size = new Size(473, 27);
            txbFechaInicio.TabIndex = 57;
            txbFechaInicio.TextChanged += txbFechaInicio_TextChanged;
            txbFechaInicio.KeyPress += txbFechaInicio_KeyPress;
            // 
            // txbFechaFin
            // 
            txbFechaFin.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbFechaFin.Location = new Point(153, 294);
            txbFechaFin.Name = "txbFechaFin";
            txbFechaFin.Size = new Size(473, 27);
            txbFechaFin.TabIndex = 58;
            txbFechaFin.TextChanged += txbFechaFin_TextChanged;
            txbFechaFin.KeyPress += txbFechaFin_KeyPress;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(255, 102, 0);
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(223, 354);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(206, 31);
            btnBuscar.TabIndex = 59;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // chbTodoslosProductos
            // 
            chbTodoslosProductos.AutoSize = true;
            chbTodoslosProductos.BackColor = Color.Transparent;
            chbTodoslosProductos.Checked = true;
            chbTodoslosProductos.CheckState = CheckState.Checked;
            chbTodoslosProductos.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chbTodoslosProductos.ForeColor = Color.White;
            chbTodoslosProductos.Location = new Point(471, 89);
            chbTodoslosProductos.Name = "chbTodoslosProductos";
            chbTodoslosProductos.Size = new Size(149, 20);
            chbTodoslosProductos.TabIndex = 60;
            chbTodoslosProductos.Text = "Todos los Productos";
            chbTodoslosProductos.UseVisualStyleBackColor = false;
            chbTodoslosProductos.CheckedChanged += chbTodoslosProductos_CheckedChanged;
            // 
            // chbNoFiltrarFechas
            // 
            chbNoFiltrarFechas.AutoSize = true;
            chbNoFiltrarFechas.BackColor = Color.Transparent;
            chbNoFiltrarFechas.Checked = true;
            chbNoFiltrarFechas.CheckState = CheckState.Checked;
            chbNoFiltrarFechas.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chbNoFiltrarFechas.ForeColor = Color.White;
            chbNoFiltrarFechas.Location = new Point(488, 235);
            chbNoFiltrarFechas.Name = "chbNoFiltrarFechas";
            chbNoFiltrarFechas.Size = new Size(128, 20);
            chbNoFiltrarFechas.TabIndex = 61;
            chbNoFiltrarFechas.Text = "No Filtrar Fechas";
            chbNoFiltrarFechas.UseVisualStyleBackColor = false;
            chbNoFiltrarFechas.CheckedChanged += chbNoFiltrarFechas_CheckedChanged;
            // 
            // chbTodosClientes
            // 
            chbTodosClientes.AutoSize = true;
            chbTodosClientes.BackColor = Color.Transparent;
            chbTodosClientes.Checked = true;
            chbTodosClientes.CheckState = CheckState.Checked;
            chbTodosClientes.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chbTodosClientes.ForeColor = Color.White;
            chbTodosClientes.Location = new Point(483, 162);
            chbTodosClientes.Name = "chbTodosClientes";
            chbTodosClientes.Size = new Size(133, 20);
            chbTodosClientes.TabIndex = 64;
            chbTodosClientes.Text = "Todos los Clientes";
            chbTodosClientes.UseVisualStyleBackColor = false;
            chbTodosClientes.CheckedChanged += chbTodosClientes_CheckedChanged;
            // 
            // cbClientes
            // 
            cbClientes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbClientes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbClientes.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cbClientes.FormattingEnabled = true;
            cbClientes.Location = new Point(148, 188);
            cbClientes.Name = "cbClientes";
            cbClientes.Size = new Size(473, 30);
            cbClientes.TabIndex = 63;
            cbClientes.SelectedIndexChanged += cbClientes_SelectedIndexChanged;
            cbClientes.TextChanged += cbClientes_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(56, 191);
            label5.Name = "label5";
            label5.Size = new Size(70, 22);
            label5.TabIndex = 62;
            label5.Text = "Cliente:";
            // 
            // lblClaveCliente
            // 
            lblClaveCliente.AutoSize = true;
            lblClaveCliente.BackColor = Color.Transparent;
            lblClaveCliente.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblClaveCliente.ForeColor = Color.White;
            lblClaveCliente.Location = new Point(15, 231);
            lblClaveCliente.Name = "lblClaveCliente";
            lblClaveCliente.Size = new Size(70, 22);
            lblClaveCliente.TabIndex = 66;
            lblClaveCliente.Text = "Cliente:";
            lblClaveCliente.Visible = false;
            // 
            // Almacen_FacturasSAE_Filtro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(696, 417);
            Controls.Add(lblClaveCliente);
            Controls.Add(chbTodosClientes);
            Controls.Add(cbClientes);
            Controls.Add(label5);
            Controls.Add(chbNoFiltrarFechas);
            Controls.Add(chbTodoslosProductos);
            Controls.Add(btnBuscar);
            Controls.Add(txbFechaFin);
            Controls.Add(txbFechaInicio);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cbProductos);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Almacen_FacturasSAE_Filtro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Almacen_FacturasSAE_Filtro";
            Load += Almacen_FacturasSAE_Filtro_Load;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox6;
        private Label label1;
        private ComboBox cbProductos;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txbFechaInicio;
        private TextBox txbFechaFin;
        private Button btnBuscar;
        private CheckBox chbTodoslosProductos;
        private CheckBox chbNoFiltrarFechas;
        private CheckBox chbTodosClientes;
        private ComboBox cbClientes;
        private Label label5;
        private BindingSource bindingSource1;
        private Label lblClaveCliente;
    }
}