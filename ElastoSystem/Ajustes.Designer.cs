namespace ElastoSystem
{
    partial class Ajustes
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
            tabControl1 = new TabControl();
            tPEnvioCorreos = new TabPage();
            panel9 = new Panel();
            btnNuevo = new Button();
            txbCorreoOriginal = new TextBox();
            btnEliminar = new Button();
            btnAgregar = new Button();
            btnActualizar = new Button();
            txbCorreo = new TextBox();
            label10 = new Label();
            dgvCorreo = new DataGridView();
            cbCorreo = new ComboBox();
            label8 = new Label();
            tPFallasProduccion = new TabPage();
            panel1 = new Panel();
            lblIDFalla = new Label();
            btnActualizarFalla = new Button();
            btnNuevaFalla = new Button();
            txbFalla = new TextBox();
            label4 = new Label();
            btnRegistrarFalla = new Button();
            txbCodigo = new TextBox();
            label3 = new Label();
            dgvFallas = new DataGridView();
            label2 = new Label();
            tabControl1.SuspendLayout();
            tPEnvioCorreos.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCorreo).BeginInit();
            tPFallasProduccion.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFallas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 22F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(27, 29);
            label1.Name = "label1";
            label1.Size = new Size(160, 47);
            label1.TabIndex = 1;
            label1.Text = "AJUSTES";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tPEnvioCorreos);
            tabControl1.Controls.Add(tPFallasProduccion);
            tabControl1.Location = new Point(27, 84);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1281, 708);
            tabControl1.TabIndex = 13;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tPEnvioCorreos
            // 
            tPEnvioCorreos.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tPEnvioCorreos.Controls.Add(panel9);
            tPEnvioCorreos.Controls.Add(cbCorreo);
            tPEnvioCorreos.Controls.Add(label8);
            tPEnvioCorreos.Location = new Point(4, 24);
            tPEnvioCorreos.Name = "tPEnvioCorreos";
            tPEnvioCorreos.Size = new Size(1273, 680);
            tPEnvioCorreos.TabIndex = 2;
            tPEnvioCorreos.Text = "Envio de Correos";
            tPEnvioCorreos.UseVisualStyleBackColor = true;
            tPEnvioCorreos.Click += tPEnvioCorreos_Click;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(3, 42, 76);
            panel9.Controls.Add(btnNuevo);
            panel9.Controls.Add(txbCorreoOriginal);
            panel9.Controls.Add(btnEliminar);
            panel9.Controls.Add(btnAgregar);
            panel9.Controls.Add(btnActualizar);
            panel9.Controls.Add(txbCorreo);
            panel9.Controls.Add(label10);
            panel9.Controls.Add(dgvCorreo);
            panel9.Location = new Point(26, 93);
            panel9.Name = "panel9";
            panel9.Size = new Size(1208, 547);
            panel9.TabIndex = 9;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(255, 102, 0);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(1053, 24);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(130, 33);
            btnNuevo.TabIndex = 66;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Visible = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // txbCorreoOriginal
            // 
            txbCorreoOriginal.Font = new Font("Montserrat", 12F);
            txbCorreoOriginal.Location = new Point(825, 78);
            txbCorreoOriginal.Name = "txbCorreoOriginal";
            txbCorreoOriginal.Size = new Size(211, 27);
            txbCorreoOriginal.TabIndex = 65;
            txbCorreoOriginal.Visible = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(255, 102, 0);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(105, 76);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(130, 33);
            btnEliminar.TabIndex = 64;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Visible = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(255, 102, 0);
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(812, 24);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(130, 33);
            btnAgregar.TabIndex = 63;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Visible = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(255, 102, 0);
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(511, 76);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(275, 33);
            btnActualizar.TabIndex = 62;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Visible = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // txbCorreo
            // 
            txbCorreo.Font = new Font("Montserrat", 12F);
            txbCorreo.Location = new Point(103, 26);
            txbCorreo.Name = "txbCorreo";
            txbCorreo.Size = new Size(683, 27);
            txbCorreo.TabIndex = 61;
            txbCorreo.KeyDown += txbCorreo_KeyDown;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 12F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(30, 31);
            label10.Name = "label10";
            label10.Size = new Size(68, 25);
            label10.TabIndex = 60;
            label10.Text = "Correo:";
            // 
            // dgvCorreo
            // 
            dgvCorreo.AllowUserToAddRows = false;
            dgvCorreo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCorreo.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCorreo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCorreo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCorreo.Location = new Point(27, 130);
            dgvCorreo.Name = "dgvCorreo";
            dgvCorreo.ReadOnly = true;
            dgvCorreo.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvCorreo.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvCorreo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCorreo.Size = new Size(1156, 383);
            dgvCorreo.TabIndex = 20;
            dgvCorreo.CellClick += dgvCorreo_CellClick;
            // 
            // cbCorreo
            // 
            cbCorreo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCorreo.Font = new Font("Montserrat", 15F);
            cbCorreo.FormattingEnabled = true;
            cbCorreo.Items.AddRange(new object[] { "Actualizacion de Licitaciones", "Insumos del Almacen", "Prioridades del Almacen", "Requisicion de Mantenimiento", "Requisicion de Sistemas" });
            cbCorreo.Location = new Point(140, 34);
            cbCorreo.Name = "cbCorreo";
            cbCorreo.Size = new Size(427, 39);
            cbCorreo.TabIndex = 4;
            cbCorreo.SelectedIndexChanged += cbUsuariosEspeciales_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 15F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(26, 37);
            label8.Name = "label8";
            label8.Size = new Size(90, 31);
            label8.TabIndex = 3;
            label8.Text = "Correo:";
            // 
            // tPFallasProduccion
            // 
            tPFallasProduccion.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tPFallasProduccion.Controls.Add(panel1);
            tPFallasProduccion.Controls.Add(label2);
            tPFallasProduccion.Location = new Point(4, 24);
            tPFallasProduccion.Name = "tPFallasProduccion";
            tPFallasProduccion.Size = new Size(1273, 680);
            tPFallasProduccion.TabIndex = 3;
            tPFallasProduccion.Text = "Fallas de Producción";
            tPFallasProduccion.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(lblIDFalla);
            panel1.Controls.Add(btnActualizarFalla);
            panel1.Controls.Add(btnNuevaFalla);
            panel1.Controls.Add(txbFalla);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnRegistrarFalla);
            panel1.Controls.Add(txbCodigo);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dgvFallas);
            panel1.Location = new Point(32, 67);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 592);
            panel1.TabIndex = 10;
            // 
            // lblIDFalla
            // 
            lblIDFalla.AutoSize = true;
            lblIDFalla.BackColor = Color.Transparent;
            lblIDFalla.Font = new Font("Montserrat", 12F);
            lblIDFalla.ForeColor = Color.White;
            lblIDFalla.Location = new Point(288, 26);
            lblIDFalla.Name = "lblIDFalla";
            lblIDFalla.Size = new Size(83, 25);
            lblIDFalla.TabIndex = 68;
            lblIDFalla.Text = "ID FALLA";
            lblIDFalla.Visible = false;
            // 
            // btnActualizarFalla
            // 
            btnActualizarFalla.BackColor = Color.FromArgb(255, 102, 0);
            btnActualizarFalla.Cursor = Cursors.Hand;
            btnActualizarFalla.FlatAppearance.BorderSize = 0;
            btnActualizarFalla.FlatStyle = FlatStyle.Flat;
            btnActualizarFalla.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnActualizarFalla.ForeColor = Color.White;
            btnActualizarFalla.Location = new Point(152, 101);
            btnActualizarFalla.Name = "btnActualizarFalla";
            btnActualizarFalla.Size = new Size(225, 33);
            btnActualizarFalla.TabIndex = 67;
            btnActualizarFalla.Text = "ACTUALIZAR";
            btnActualizarFalla.UseVisualStyleBackColor = false;
            btnActualizarFalla.Visible = false;
            btnActualizarFalla.Click += btnActualizarFalla_Click;
            // 
            // btnNuevaFalla
            // 
            btnNuevaFalla.BackColor = Color.FromArgb(255, 102, 0);
            btnNuevaFalla.Cursor = Cursors.Hand;
            btnNuevaFalla.FlatAppearance.BorderSize = 0;
            btnNuevaFalla.FlatStyle = FlatStyle.Flat;
            btnNuevaFalla.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnNuevaFalla.ForeColor = Color.White;
            btnNuevaFalla.Location = new Point(379, 16);
            btnNuevaFalla.Name = "btnNuevaFalla";
            btnNuevaFalla.Size = new Size(110, 33);
            btnNuevaFalla.TabIndex = 66;
            btnNuevaFalla.Text = "NUEVA";
            btnNuevaFalla.UseVisualStyleBackColor = false;
            btnNuevaFalla.Visible = false;
            btnNuevaFalla.Click += btnNuevaFalla_Click;
            // 
            // txbFalla
            // 
            txbFalla.CharacterCasing = CharacterCasing.Upper;
            txbFalla.Font = new Font("Montserrat", 12F);
            txbFalla.Location = new Point(105, 57);
            txbFalla.MaxLength = 100;
            txbFalla.Name = "txbFalla";
            txbFalla.Size = new Size(384, 27);
            txbFalla.TabIndex = 65;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(27, 60);
            label4.Name = "label4";
            label4.Size = new Size(51, 25);
            label4.TabIndex = 64;
            label4.Text = "Falla:";
            // 
            // btnRegistrarFalla
            // 
            btnRegistrarFalla.BackColor = Color.FromArgb(255, 102, 0);
            btnRegistrarFalla.Cursor = Cursors.Hand;
            btnRegistrarFalla.FlatAppearance.BorderSize = 0;
            btnRegistrarFalla.FlatStyle = FlatStyle.Flat;
            btnRegistrarFalla.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnRegistrarFalla.ForeColor = Color.White;
            btnRegistrarFalla.Location = new Point(152, 101);
            btnRegistrarFalla.Name = "btnRegistrarFalla";
            btnRegistrarFalla.Size = new Size(225, 33);
            btnRegistrarFalla.TabIndex = 63;
            btnRegistrarFalla.Text = "REGISTRAR";
            btnRegistrarFalla.UseVisualStyleBackColor = false;
            btnRegistrarFalla.Click += btnRegistrarFalla_Click;
            // 
            // txbCodigo
            // 
            txbCodigo.CharacterCasing = CharacterCasing.Upper;
            txbCodigo.Font = new Font("Montserrat", 12F);
            txbCodigo.Location = new Point(105, 23);
            txbCodigo.MaxLength = 5;
            txbCodigo.Name = "txbCodigo";
            txbCodigo.Size = new Size(174, 27);
            txbCodigo.TabIndex = 61;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(27, 26);
            label3.Name = "label3";
            label3.Size = new Size(72, 25);
            label3.TabIndex = 60;
            label3.Text = "Código:";
            // 
            // dgvFallas
            // 
            dgvFallas.AllowUserToAddRows = false;
            dgvFallas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFallas.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvFallas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvFallas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFallas.Location = new Point(27, 150);
            dgvFallas.Name = "dgvFallas";
            dgvFallas.ReadOnly = true;
            dgvFallas.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvFallas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvFallas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFallas.Size = new Size(467, 415);
            dgvFallas.TabIndex = 20;
            dgvFallas.CellClick += dgvFallas_CellClick;
            dgvFallas.DataBindingComplete += dgvFallas_DataBindingComplete;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 15F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(157, 26);
            label2.Name = "label2";
            label2.Size = new Size(235, 31);
            label2.TabIndex = 4;
            label2.Text = "Fallas de Producción";
            // 
            // Ajustes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Ajustes";
            Text = "Ajustes";
            Load += Ajustes_Load;
            tabControl1.ResumeLayout(false);
            tPEnvioCorreos.ResumeLayout(false);
            tPEnvioCorreos.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCorreo).EndInit();
            tPFallasProduccion.ResumeLayout(false);
            tPFallasProduccion.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFallas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TabControl tabControl1;
        private TabPage tPEnvioCorreos;
        private Panel panel9;
        private ComboBox cbCorreo;
        private Label label8;
        private DataGridView dgvCorreo;
        private TextBox txbCorreo;
        private Label label10;
        private Button btnEliminar;
        private Button btnAgregar;
        private Button btnActualizar;
        private TextBox txbCorreoOriginal;
        private Button btnNuevo;
        private TabPage tPFallasProduccion;
        private Panel panel1;
        private Button btnRegistrarFalla;
        private TextBox txbCodigo;
        private Label label3;
        private DataGridView dgvFallas;
        private Label label2;
        private TextBox txbFalla;
        private Label label4;
        private Button btnNuevaFalla;
        private Button btnActualizarFalla;
        private Label lblIDFalla;
    }
}