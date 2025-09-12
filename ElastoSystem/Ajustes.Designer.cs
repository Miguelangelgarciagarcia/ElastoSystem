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
            tabControl1.SuspendLayout();
            tPEnvioCorreos.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCorreo).BeginInit();
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
            label1.Size = new Size(158, 41);
            label1.TabIndex = 1;
            label1.Text = "AJUSTES";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tPEnvioCorreos);
            tabControl1.Location = new Point(27, 84);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1281, 708);
            tabControl1.TabIndex = 13;
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
            label10.Size = new Size(67, 22);
            label10.TabIndex = 60;
            label10.Text = "Correo:";
            // 
            // dgvCorreo
            // 
            dgvCorreo.AllowUserToAddRows = false;
            dgvCorreo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCorreo.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvCorreo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvCorreo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCorreo.Location = new Point(27, 130);
            dgvCorreo.Name = "dgvCorreo";
            dgvCorreo.ReadOnly = true;
            dgvCorreo.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvCorreo.RowsDefaultCellStyle = dataGridViewCellStyle4;
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
            cbCorreo.Size = new Size(427, 35);
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
            label8.Size = new Size(89, 27);
            label8.TabIndex = 3;
            label8.Text = "Correo:";
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
    }
}