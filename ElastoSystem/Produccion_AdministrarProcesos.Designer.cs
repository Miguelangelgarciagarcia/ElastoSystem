namespace ElastoSystem
{
    partial class Produccion_AdministrarProcesos
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
            tabControl1 = new TabControl();
            tabAdministrar = new TabPage();
            panel2 = new Panel();
            txbAreasOriginal = new TextBox();
            dgvAreas = new DataGridView();
            txbAreas = new TextBox();
            btnNuevoAreas = new Button();
            btnEliminarAreas = new Button();
            btnEditarAreas = new Button();
            btnAgregarAreas = new Button();
            label2 = new Label();
            panel1 = new Panel();
            dgvFamilias = new DataGridView();
            txbFamiliaOriginal = new TextBox();
            txbFamilia = new TextBox();
            btnNuevoFamilias = new Button();
            btnEliminarFamilias = new Button();
            btnEditarFamilias = new Button();
            btnAgregarFamilias = new Button();
            label3 = new Label();
            tabHojaRuta = new TabPage();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabAdministrar.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAreas).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFamilias).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabAdministrar);
            tabControl1.Controls.Add(tabHojaRuta);
            tabControl1.Location = new Point(12, 74);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1314, 745);
            tabControl1.TabIndex = 13;
            // 
            // tabAdministrar
            // 
            tabAdministrar.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabAdministrar.Controls.Add(panel2);
            tabAdministrar.Controls.Add(panel1);
            tabAdministrar.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            tabAdministrar.Location = new Point(4, 24);
            tabAdministrar.Name = "tabAdministrar";
            tabAdministrar.Padding = new Padding(3);
            tabAdministrar.Size = new Size(1306, 717);
            tabAdministrar.TabIndex = 0;
            tabAdministrar.Text = "Administrar";
            tabAdministrar.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(3, 42, 76);
            panel2.Controls.Add(txbAreasOriginal);
            panel2.Controls.Add(dgvAreas);
            panel2.Controls.Add(txbAreas);
            panel2.Controls.Add(btnNuevoAreas);
            panel2.Controls.Add(btnEliminarAreas);
            panel2.Controls.Add(btnEditarAreas);
            panel2.Controls.Add(btnAgregarAreas);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(20, 361);
            panel2.Name = "panel2";
            panel2.Size = new Size(353, 335);
            panel2.TabIndex = 5;
            // 
            // txbAreasOriginal
            // 
            txbAreasOriginal.Font = new Font("Montserrat", 12F);
            txbAreasOriginal.Location = new Point(136, 21);
            txbAreasOriginal.Name = "txbAreasOriginal";
            txbAreasOriginal.Size = new Size(64, 27);
            txbAreasOriginal.TabIndex = 45;
            txbAreasOriginal.Visible = false;
            // 
            // dgvAreas
            // 
            dgvAreas.AllowUserToAddRows = false;
            dgvAreas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAreas.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAreas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAreas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAreas.Location = new Point(22, 61);
            dgvAreas.Name = "dgvAreas";
            dgvAreas.ReadOnly = true;
            dgvAreas.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvAreas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvAreas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAreas.Size = new Size(309, 180);
            dgvAreas.TabIndex = 21;
            dgvAreas.CellClick += dgvAreas_CellClick;
            dgvAreas.CellContentClick += dgvAreas_CellContentClick;
            // 
            // txbAreas
            // 
            txbAreas.Font = new Font("Montserrat", 12F);
            txbAreas.Location = new Point(22, 247);
            txbAreas.Name = "txbAreas";
            txbAreas.Size = new Size(205, 27);
            txbAreas.TabIndex = 48;
            txbAreas.KeyDown += txbAreas_KeyDown;
            txbAreas.KeyPress += txbAreas_KeyPress;
            // 
            // btnNuevoAreas
            // 
            btnNuevoAreas.BackColor = Color.FromArgb(255, 102, 0);
            btnNuevoAreas.Cursor = Cursors.Hand;
            btnNuevoAreas.FlatAppearance.BorderSize = 0;
            btnNuevoAreas.FlatStyle = FlatStyle.Flat;
            btnNuevoAreas.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnNuevoAreas.ForeColor = Color.White;
            btnNuevoAreas.Location = new Point(233, 24);
            btnNuevoAreas.Name = "btnNuevoAreas";
            btnNuevoAreas.Size = new Size(98, 27);
            btnNuevoAreas.TabIndex = 47;
            btnNuevoAreas.Text = "NUEVO";
            btnNuevoAreas.UseVisualStyleBackColor = false;
            btnNuevoAreas.Visible = false;
            btnNuevoAreas.Click += btnNuevoAreas_Click;
            // 
            // btnEliminarAreas
            // 
            btnEliminarAreas.BackColor = Color.FromArgb(255, 102, 0);
            btnEliminarAreas.Cursor = Cursors.Hand;
            btnEliminarAreas.FlatAppearance.BorderSize = 0;
            btnEliminarAreas.FlatStyle = FlatStyle.Flat;
            btnEliminarAreas.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnEliminarAreas.ForeColor = Color.White;
            btnEliminarAreas.Location = new Point(23, 280);
            btnEliminarAreas.Name = "btnEliminarAreas";
            btnEliminarAreas.Size = new Size(98, 27);
            btnEliminarAreas.TabIndex = 46;
            btnEliminarAreas.Text = "ELIMINAR";
            btnEliminarAreas.UseVisualStyleBackColor = false;
            btnEliminarAreas.Visible = false;
            btnEliminarAreas.Click += btnEliminarAreas_Click;
            // 
            // btnEditarAreas
            // 
            btnEditarAreas.BackColor = Color.FromArgb(255, 102, 0);
            btnEditarAreas.Cursor = Cursors.Hand;
            btnEditarAreas.FlatAppearance.BorderSize = 0;
            btnEditarAreas.FlatStyle = FlatStyle.Flat;
            btnEditarAreas.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnEditarAreas.ForeColor = Color.White;
            btnEditarAreas.Location = new Point(233, 247);
            btnEditarAreas.Name = "btnEditarAreas";
            btnEditarAreas.Size = new Size(98, 27);
            btnEditarAreas.TabIndex = 45;
            btnEditarAreas.Text = "EDITAR";
            btnEditarAreas.UseVisualStyleBackColor = false;
            btnEditarAreas.Visible = false;
            btnEditarAreas.Click += btnEditarAreas_Click;
            // 
            // btnAgregarAreas
            // 
            btnAgregarAreas.BackColor = Color.FromArgb(255, 102, 0);
            btnAgregarAreas.Cursor = Cursors.Hand;
            btnAgregarAreas.FlatAppearance.BorderSize = 0;
            btnAgregarAreas.FlatStyle = FlatStyle.Flat;
            btnAgregarAreas.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnAgregarAreas.ForeColor = Color.White;
            btnAgregarAreas.Location = new Point(233, 247);
            btnAgregarAreas.Name = "btnAgregarAreas";
            btnAgregarAreas.Size = new Size(98, 27);
            btnAgregarAreas.TabIndex = 44;
            btnAgregarAreas.Text = "AGREGAR";
            btnAgregarAreas.UseVisualStyleBackColor = false;
            btnAgregarAreas.Click += btnAgregarAreas_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 15F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(22, 24);
            label2.Name = "label2";
            label2.Size = new Size(72, 27);
            label2.TabIndex = 22;
            label2.Text = "Areas";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(dgvFamilias);
            panel1.Controls.Add(txbFamiliaOriginal);
            panel1.Controls.Add(txbFamilia);
            panel1.Controls.Add(btnNuevoFamilias);
            panel1.Controls.Add(btnEliminarFamilias);
            panel1.Controls.Add(btnEditarFamilias);
            panel1.Controls.Add(btnAgregarFamilias);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(20, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(353, 335);
            panel1.TabIndex = 4;
            // 
            // dgvFamilias
            // 
            dgvFamilias.AllowUserToAddRows = false;
            dgvFamilias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFamilias.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvFamilias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvFamilias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFamilias.Location = new Point(23, 62);
            dgvFamilias.Name = "dgvFamilias";
            dgvFamilias.ReadOnly = true;
            dgvFamilias.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvFamilias.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvFamilias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFamilias.Size = new Size(309, 180);
            dgvFamilias.TabIndex = 20;
            dgvFamilias.CellClick += dgvFamilias_CellClick;
            dgvFamilias.CellContentClick += dgvFamilias_CellContentClick;
            dgvFamilias.Click += dgvFamilias_Click;
            // 
            // txbFamiliaOriginal
            // 
            txbFamiliaOriginal.Font = new Font("Montserrat", 12F);
            txbFamiliaOriginal.Location = new Point(136, 26);
            txbFamiliaOriginal.Name = "txbFamiliaOriginal";
            txbFamiliaOriginal.Size = new Size(64, 27);
            txbFamiliaOriginal.TabIndex = 44;
            txbFamiliaOriginal.Visible = false;
            // 
            // txbFamilia
            // 
            txbFamilia.Font = new Font("Montserrat", 12F);
            txbFamilia.Location = new Point(22, 248);
            txbFamilia.Name = "txbFamilia";
            txbFamilia.Size = new Size(205, 27);
            txbFamilia.TabIndex = 43;
            txbFamilia.KeyDown += txbFamilia_KeyDown;
            txbFamilia.KeyPress += txbFamilia_KeyPress;
            // 
            // btnNuevoFamilias
            // 
            btnNuevoFamilias.BackColor = Color.FromArgb(255, 102, 0);
            btnNuevoFamilias.Cursor = Cursors.Hand;
            btnNuevoFamilias.FlatAppearance.BorderSize = 0;
            btnNuevoFamilias.FlatStyle = FlatStyle.Flat;
            btnNuevoFamilias.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnNuevoFamilias.ForeColor = Color.White;
            btnNuevoFamilias.Location = new Point(233, 29);
            btnNuevoFamilias.Name = "btnNuevoFamilias";
            btnNuevoFamilias.Size = new Size(98, 27);
            btnNuevoFamilias.TabIndex = 42;
            btnNuevoFamilias.Text = "NUEVO";
            btnNuevoFamilias.UseVisualStyleBackColor = false;
            btnNuevoFamilias.Visible = false;
            btnNuevoFamilias.Click += btnNuevoFamilias_Click;
            // 
            // btnEliminarFamilias
            // 
            btnEliminarFamilias.BackColor = Color.FromArgb(255, 102, 0);
            btnEliminarFamilias.Cursor = Cursors.Hand;
            btnEliminarFamilias.FlatAppearance.BorderSize = 0;
            btnEliminarFamilias.FlatStyle = FlatStyle.Flat;
            btnEliminarFamilias.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnEliminarFamilias.ForeColor = Color.White;
            btnEliminarFamilias.Location = new Point(23, 281);
            btnEliminarFamilias.Name = "btnEliminarFamilias";
            btnEliminarFamilias.Size = new Size(98, 27);
            btnEliminarFamilias.TabIndex = 41;
            btnEliminarFamilias.Text = "ELIMINAR";
            btnEliminarFamilias.UseVisualStyleBackColor = false;
            btnEliminarFamilias.Visible = false;
            btnEliminarFamilias.Click += btnEliminarFamilias_Click;
            // 
            // btnEditarFamilias
            // 
            btnEditarFamilias.BackColor = Color.FromArgb(255, 102, 0);
            btnEditarFamilias.Cursor = Cursors.Hand;
            btnEditarFamilias.FlatAppearance.BorderSize = 0;
            btnEditarFamilias.FlatStyle = FlatStyle.Flat;
            btnEditarFamilias.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnEditarFamilias.ForeColor = Color.White;
            btnEditarFamilias.Location = new Point(233, 248);
            btnEditarFamilias.Name = "btnEditarFamilias";
            btnEditarFamilias.Size = new Size(98, 27);
            btnEditarFamilias.TabIndex = 40;
            btnEditarFamilias.Text = "EDITAR";
            btnEditarFamilias.UseVisualStyleBackColor = false;
            btnEditarFamilias.Visible = false;
            btnEditarFamilias.Click += btnEditarFamilias_Click;
            // 
            // btnAgregarFamilias
            // 
            btnAgregarFamilias.BackColor = Color.FromArgb(255, 102, 0);
            btnAgregarFamilias.Cursor = Cursors.Hand;
            btnAgregarFamilias.FlatAppearance.BorderSize = 0;
            btnAgregarFamilias.FlatStyle = FlatStyle.Flat;
            btnAgregarFamilias.Font = new Font("Montserrat", 9F, FontStyle.Bold);
            btnAgregarFamilias.ForeColor = Color.White;
            btnAgregarFamilias.Location = new Point(233, 248);
            btnAgregarFamilias.Name = "btnAgregarFamilias";
            btnAgregarFamilias.Size = new Size(98, 27);
            btnAgregarFamilias.TabIndex = 39;
            btnAgregarFamilias.Text = "AGREGAR";
            btnAgregarFamilias.UseVisualStyleBackColor = false;
            btnAgregarFamilias.Click += btnAgregarFamilias_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 15F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(22, 25);
            label3.Name = "label3";
            label3.Size = new Size(99, 27);
            label3.TabIndex = 21;
            label3.Text = "Familias";
            // 
            // tabHojaRuta
            // 
            tabHojaRuta.BackgroundImage = Properties.Resources.fondocontrolalmacen;
            tabHojaRuta.Location = new Point(4, 24);
            tabHojaRuta.Name = "tabHojaRuta";
            tabHojaRuta.Padding = new Padding(3);
            tabHojaRuta.Size = new Size(1306, 717);
            tabHojaRuta.TabIndex = 1;
            tabHojaRuta.Text = "Hoja de Ruta";
            tabHojaRuta.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 22F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(16, 21);
            label1.Name = "label1";
            label1.Size = new Size(426, 41);
            label1.TabIndex = 14;
            label1.Text = "ADMINISTRAR PROCESOS";
            // 
            // Produccion_AdministrarProcesos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(label1);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_AdministrarProcesos";
            Text = "Produccion_AdministrarProcesos";
            Load += Produccion_AdministrarProcesos_Load;
            tabControl1.ResumeLayout(false);
            tabAdministrar.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAreas).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFamilias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabAdministrar;
        private TabPage tabHojaRuta;
        private Label label1;
        private Panel panel2;
        private Panel panel1;
        private Label label2;
        private Label label3;
        private Button btnNuevoFamilias;
        private Button btnEliminarFamilias;
        private Button btnEditarFamilias;
        private Button btnAgregarFamilias;
        private TextBox txbAreas;
        private Button btnNuevoAreas;
        private Button btnEliminarAreas;
        private Button btnEditarAreas;
        private Button btnAgregarAreas;
        private TextBox txbFamilia;
        private DataGridView dgvFamilias;
        private DataGridView dgvAreas;
        private TextBox txbAreasOriginal;
        private TextBox txbFamiliaOriginal;
    }
}