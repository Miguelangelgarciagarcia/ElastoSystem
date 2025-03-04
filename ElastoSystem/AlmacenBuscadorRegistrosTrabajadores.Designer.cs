namespace ElastoSystem
{
    partial class AlmacenBuscadorRegistrosTrabajadores
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
            Nombre = new Label();
            label2 = new Label();
            txbNoTrabajador = new TextBox();
            chbTodosTrabajadores = new CheckBox();
            label3 = new Label();
            cbProducto = new ComboBox();
            chbTodosProductos = new CheckBox();
            label4 = new Label();
            label5 = new Label();
            txtbFechaInicio = new TextBox();
            txtbFechaTermino = new TextBox();
            checkBox3 = new CheckBox();
            dgv = new DataGridView();
            btnbuscar = new Button();
            pbCalendario1 = new PictureBox();
            pbCalendario2 = new PictureBox();
            Calendario1 = new MonthCalendar();
            pbCalendario1Cerrar = new PictureBox();
            Calendario2 = new MonthCalendar();
            pbCalendario2Cerrar = new PictureBox();
            button1 = new Button();
            cbNombreCompleto = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCalendario1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCalendario2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCalendario1Cerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCalendario2Cerrar).BeginInit();
            SuspendLayout();
            // 
            // Nombre
            // 
            Nombre.AutoSize = true;
            Nombre.BackColor = Color.Transparent;
            Nombre.Font = new Font("Montserrat", 14F);
            Nombre.ForeColor = Color.White;
            Nombre.Location = new Point(36, 32);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(91, 26);
            Nombre.TabIndex = 2;
            Nombre.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 14F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(622, 32);
            label2.Name = "label2";
            label2.Size = new Size(150, 26);
            label2.TabIndex = 4;
            label2.Text = "No. Trabajador";
            // 
            // txbNoTrabajador
            // 
            txbNoTrabajador.Font = new Font("Montserrat", 14F);
            txbNoTrabajador.Location = new Point(622, 61);
            txbNoTrabajador.Name = "txbNoTrabajador";
            txbNoTrabajador.ReadOnly = true;
            txbNoTrabajador.Size = new Size(165, 30);
            txbNoTrabajador.TabIndex = 5;
            // 
            // chbTodosTrabajadores
            // 
            chbTodosTrabajadores.AutoSize = true;
            chbTodosTrabajadores.BackColor = Color.Transparent;
            chbTodosTrabajadores.Font = new Font("Montserrat", 14F, FontStyle.Bold);
            chbTodosTrabajadores.ForeColor = Color.White;
            chbTodosTrabajadores.Location = new Point(36, 101);
            chbTodosTrabajadores.Name = "chbTodosTrabajadores";
            chbTodosTrabajadores.Size = new Size(261, 30);
            chbTodosTrabajadores.TabIndex = 6;
            chbTodosTrabajadores.Text = "Todos Los Trabajadores";
            chbTodosTrabajadores.UseVisualStyleBackColor = false;
            chbTodosTrabajadores.CheckedChanged += checkBox1_CheckedChanged;
            chbTodosTrabajadores.CheckStateChanged += checkBox1_CheckStateChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 14F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(36, 137);
            label3.Name = "label3";
            label3.Size = new Size(103, 26);
            label3.TabIndex = 7;
            label3.Text = "Producto";
            // 
            // cbProducto
            // 
            cbProducto.Font = new Font("Montserrat", 14F);
            cbProducto.FormattingEnabled = true;
            cbProducto.Location = new Point(36, 166);
            cbProducto.Name = "cbProducto";
            cbProducto.Size = new Size(280, 34);
            cbProducto.TabIndex = 8;
            cbProducto.TextChanged += cbProducto_TextChanged;
            // 
            // chbTodosProductos
            // 
            chbTodosProductos.AutoSize = true;
            chbTodosProductos.BackColor = Color.Transparent;
            chbTodosProductos.Font = new Font("Montserrat", 14F, FontStyle.Bold);
            chbTodosProductos.ForeColor = Color.White;
            chbTodosProductos.Location = new Point(36, 206);
            chbTodosProductos.Name = "chbTodosProductos";
            chbTodosProductos.Size = new Size(233, 30);
            chbTodosProductos.TabIndex = 9;
            chbTodosProductos.Text = "Todos Los Productos";
            chbTodosProductos.UseVisualStyleBackColor = false;
            chbTodosProductos.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 14F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(386, 137);
            label4.Name = "label4";
            label4.Size = new Size(127, 26);
            label4.TabIndex = 10;
            label4.Text = "Fecha Inicio";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 14F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(746, 137);
            label5.Name = "label5";
            label5.Size = new Size(154, 26);
            label5.TabIndex = 11;
            label5.Text = "Fecha Termino";
            // 
            // txtbFechaInicio
            // 
            txtbFechaInicio.Enabled = false;
            txtbFechaInicio.Font = new Font("Montserrat", 14F);
            txtbFechaInicio.Location = new Point(386, 170);
            txtbFechaInicio.Name = "txtbFechaInicio";
            txtbFechaInicio.Size = new Size(280, 30);
            txtbFechaInicio.TabIndex = 12;
            // 
            // txtbFechaTermino
            // 
            txtbFechaTermino.Enabled = false;
            txtbFechaTermino.Font = new Font("Montserrat", 14F);
            txtbFechaTermino.Location = new Point(746, 170);
            txtbFechaTermino.Name = "txtbFechaTermino";
            txtbFechaTermino.Size = new Size(280, 30);
            txtbFechaTermino.TabIndex = 13;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.BackColor = Color.Transparent;
            checkBox3.Font = new Font("Montserrat", 14F, FontStyle.Bold);
            checkBox3.ForeColor = Color.White;
            checkBox3.Location = new Point(637, 206);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(119, 30);
            checkBox3.TabIndex = 14;
            checkBox3.Text = "Historico";
            checkBox3.UseVisualStyleBackColor = false;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(36, 259);
            dgv.Name = "dgv";
            dgv.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(1260, 489);
            dgv.TabIndex = 15;
            // 
            // btnbuscar
            // 
            btnbuscar.BackColor = Color.FromArgb(255, 102, 0);
            btnbuscar.FlatAppearance.BorderSize = 0;
            btnbuscar.FlatStyle = FlatStyle.Flat;
            btnbuscar.Font = new Font("Montserrat", 14F, FontStyle.Bold);
            btnbuscar.ForeColor = Color.White;
            btnbuscar.Location = new Point(1104, 161);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(184, 50);
            btnbuscar.TabIndex = 16;
            btnbuscar.Text = "BUSCAR";
            btnbuscar.UseVisualStyleBackColor = false;
            btnbuscar.Click += button1_Click;
            // 
            // pbCalendario1
            // 
            pbCalendario1.BackColor = Color.White;
            pbCalendario1.Cursor = Cursors.Hand;
            pbCalendario1.Image = Properties.Resources.calendario;
            pbCalendario1.Location = new Point(637, 175);
            pbCalendario1.Name = "pbCalendario1";
            pbCalendario1.Size = new Size(19, 18);
            pbCalendario1.SizeMode = PictureBoxSizeMode.Zoom;
            pbCalendario1.TabIndex = 21;
            pbCalendario1.TabStop = false;
            pbCalendario1.Click += pictureBox1_Click;
            // 
            // pbCalendario2
            // 
            pbCalendario2.BackColor = Color.White;
            pbCalendario2.Cursor = Cursors.Hand;
            pbCalendario2.Image = Properties.Resources.calendario;
            pbCalendario2.Location = new Point(998, 175);
            pbCalendario2.Name = "pbCalendario2";
            pbCalendario2.Size = new Size(19, 18);
            pbCalendario2.SizeMode = PictureBoxSizeMode.Zoom;
            pbCalendario2.TabIndex = 22;
            pbCalendario2.TabStop = false;
            pbCalendario2.Click += pbCalendario2_Click;
            // 
            // Calendario1
            // 
            Calendario1.Font = new Font("Montserrat", 14F);
            Calendario1.Location = new Point(408, 205);
            Calendario1.Name = "Calendario1";
            Calendario1.TabIndex = 23;
            Calendario1.DateChanged += Calendario1_DateChanged;
            // 
            // pbCalendario1Cerrar
            // 
            pbCalendario1Cerrar.BackColor = Color.White;
            pbCalendario1Cerrar.Cursor = Cursors.Hand;
            pbCalendario1Cerrar.Image = Properties.Resources.calendario;
            pbCalendario1Cerrar.Location = new Point(637, 175);
            pbCalendario1Cerrar.Name = "pbCalendario1Cerrar";
            pbCalendario1Cerrar.Size = new Size(19, 18);
            pbCalendario1Cerrar.SizeMode = PictureBoxSizeMode.Zoom;
            pbCalendario1Cerrar.TabIndex = 24;
            pbCalendario1Cerrar.TabStop = false;
            pbCalendario1Cerrar.Click += pbCalendario1Cerrar_Click;
            // 
            // Calendario2
            // 
            Calendario2.Font = new Font("Montserrat", 14F);
            Calendario2.Location = new Point(769, 205);
            Calendario2.Name = "Calendario2";
            Calendario2.TabIndex = 25;
            Calendario2.DateChanged += Calendario2_DateChanged;
            // 
            // pbCalendario2Cerrar
            // 
            pbCalendario2Cerrar.BackColor = Color.White;
            pbCalendario2Cerrar.Cursor = Cursors.Hand;
            pbCalendario2Cerrar.Image = Properties.Resources.calendario;
            pbCalendario2Cerrar.Location = new Point(998, 175);
            pbCalendario2Cerrar.Name = "pbCalendario2Cerrar";
            pbCalendario2Cerrar.Size = new Size(19, 18);
            pbCalendario2Cerrar.SizeMode = PictureBoxSizeMode.Zoom;
            pbCalendario2Cerrar.TabIndex = 26;
            pbCalendario2Cerrar.TabStop = false;
            pbCalendario2Cerrar.Click += pbCalendario2Cerrar_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 102, 0);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1073, 770);
            button1.Name = "button1";
            button1.Size = new Size(215, 39);
            button1.TabIndex = 27;
            button1.Text = "EXPORTAR A EXCEL";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // cbNombreCompleto
            // 
            cbNombreCompleto.Font = new Font("Montserrat", 14F);
            cbNombreCompleto.FormattingEnabled = true;
            cbNombreCompleto.Location = new Point(36, 61);
            cbNombreCompleto.Name = "cbNombreCompleto";
            cbNombreCompleto.Size = new Size(536, 34);
            cbNombreCompleto.TabIndex = 28;
            cbNombreCompleto.SelectedIndexChanged += cbNombreCompleto_SelectedIndexChanged;
            cbNombreCompleto.TextChanged += cbNombreCompleto_TextChanged;
            // 
            // AlmacenBuscadorRegistrosTrabajadores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(pbCalendario2Cerrar);
            Controls.Add(pbCalendario1Cerrar);
            Controls.Add(cbNombreCompleto);
            Controls.Add(button1);
            Controls.Add(Calendario2);
            Controls.Add(Calendario1);
            Controls.Add(pbCalendario2);
            Controls.Add(pbCalendario1);
            Controls.Add(btnbuscar);
            Controls.Add(dgv);
            Controls.Add(checkBox3);
            Controls.Add(txtbFechaTermino);
            Controls.Add(txtbFechaInicio);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(chbTodosProductos);
            Controls.Add(cbProducto);
            Controls.Add(label3);
            Controls.Add(chbTodosTrabajadores);
            Controls.Add(txbNoTrabajador);
            Controls.Add(label2);
            Controls.Add(Nombre);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AlmacenBuscadorRegistrosTrabajadores";
            Text = "AlmacenBuscadorRegistrosTrabajadores";
            Load += AlmacenBuscadorRegistrosTrabajadores_Load;
            Click += AlmacenBuscadorRegistrosTrabajadores_Click;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCalendario1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCalendario2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCalendario1Cerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCalendario2Cerrar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private Label Nombre;
        private Label label2;
        private TextBox txbNoTrabajador;
        private CheckBox chbTodosTrabajadores;
        private Label label3;
        private ComboBox cbProducto;
        private CheckBox chbTodosProductos;
        private Label label4;
        private Label label5;
        private TextBox txtbFechaInicio;
        private TextBox txtbFechaTermino;
        private CheckBox checkBox3;
        private DataGridView dgv;
        private Button btnbuscar;
        private PictureBox pbCalendario1;
        private PictureBox pbCalendario2;
        private MonthCalendar Calendario1;
        private PictureBox pbCalendario1Cerrar;
        private MonthCalendar Calendario2;
        private PictureBox pbCalendario2Cerrar;
        private Button button1;
        private ComboBox cbNombreCompleto;
    }
}