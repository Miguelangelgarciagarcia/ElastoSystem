namespace ElastoSystem
{
    partial class AlmacenRegistrarExistencias
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txbID = new TextBox();
            txbNotas = new TextBox();
            txbAdd = new TextBox();
            txbExistencias = new TextBox();
            txbProducto = new TextBox();
            button2 = new Button();
            dgvAlmacen = new DataGridView();
            labelprueba = new Label();
            label8 = new Label();
            label10 = new Label();
            txbBuscador = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            dgvHistorial = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAlmacen).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 11F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(20, 32);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 1;
            label2.Text = "Producto:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 11F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(20, 71);
            label3.Name = "label3";
            label3.Size = new Size(95, 21);
            label3.TabIndex = 2;
            label3.Text = "Existencias:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 11F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(20, 108);
            label4.Name = "label4";
            label4.Size = new Size(128, 21);
            label4.TabIndex = 3;
            label4.Text = "Existencia Final:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 11F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(20, 145);
            label5.Name = "label5";
            label5.Size = new Size(49, 21);
            label5.TabIndex = 4;
            label5.Text = "Nota:";
            // 
            // txbID
            // 
            txbID.Font = new Font("Montserrat", 16F);
            txbID.Location = new Point(1238, 33);
            txbID.Name = "txbID";
            txbID.Size = new Size(46, 34);
            txbID.TabIndex = 5;
            txbID.Visible = false;
            txbID.KeyPress += txbID_KeyPress;
            // 
            // txbNotas
            // 
            txbNotas.Font = new Font("Montserrat", 11F);
            txbNotas.Location = new Point(162, 142);
            txbNotas.Name = "txbNotas";
            txbNotas.Size = new Size(381, 25);
            txbNotas.TabIndex = 6;
            // 
            // txbAdd
            // 
            txbAdd.Font = new Font("Montserrat", 11F);
            txbAdd.Location = new Point(162, 105);
            txbAdd.Name = "txbAdd";
            txbAdd.Size = new Size(381, 25);
            txbAdd.TabIndex = 7;
            txbAdd.KeyPress += txbAdd_KeyPress;
            // 
            // txbExistencias
            // 
            txbExistencias.Font = new Font("Montserrat", 11F);
            txbExistencias.Location = new Point(162, 68);
            txbExistencias.Name = "txbExistencias";
            txbExistencias.ReadOnly = true;
            txbExistencias.Size = new Size(381, 25);
            txbExistencias.TabIndex = 8;
            // 
            // txbProducto
            // 
            txbProducto.Font = new Font("Montserrat", 11F);
            txbProducto.Location = new Point(162, 31);
            txbProducto.Name = "txbProducto";
            txbProducto.ReadOnly = true;
            txbProducto.Size = new Size(381, 25);
            txbProducto.TabIndex = 9;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 102, 0);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(162, 206);
            button2.Name = "button2";
            button2.Size = new Size(262, 31);
            button2.TabIndex = 12;
            button2.Text = "ACTUALIZAR EXISTENCIAS";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // dgvAlmacen
            // 
            dgvAlmacen.AllowUserToAddRows = false;
            dgvAlmacen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlmacen.BackgroundColor = Color.White;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(0, 33, 64);
            dataGridViewCellStyle7.Font = new Font("Montserrat", 11.25F, FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvAlmacen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvAlmacen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlmacen.Location = new Point(32, 423);
            dgvAlmacen.Name = "dgvAlmacen";
            dgvAlmacen.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.Transparent;
            dataGridViewCellStyle8.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvAlmacen.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvAlmacen.RowHeadersVisible = false;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dgvAlmacen.RowsDefaultCellStyle = dataGridViewCellStyle9;
            dgvAlmacen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlmacen.Size = new Size(1264, 344);
            dgvAlmacen.TabIndex = 13;
            dgvAlmacen.Click += dgvAlmacen_Click;
            dgvAlmacen.DoubleClick += dgv_DoubleClick;
            // 
            // labelprueba
            // 
            labelprueba.AutoSize = true;
            labelprueba.BackColor = Color.Transparent;
            labelprueba.Location = new Point(12, 768);
            labelprueba.Name = "labelprueba";
            labelprueba.Size = new Size(38, 15);
            labelprueba.TabIndex = 16;
            labelprueba.Text = "label8";
            labelprueba.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 22F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(32, 33);
            label8.Name = "label8";
            label8.Size = new Size(639, 41);
            label8.TabIndex = 17;
            label8.Text = "REGISTRO DE CONSUMIBLES ALMACEN";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 11F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(34, 395);
            label10.Name = "label10";
            label10.Size = new Size(83, 21);
            label10.TabIndex = 45;
            label10.Text = "Buscador:";
            // 
            // txbBuscador
            // 
            txbBuscador.Font = new Font("Montserrat", 11F);
            txbBuscador.Location = new Point(123, 392);
            txbBuscador.Name = "txbBuscador";
            txbBuscador.Size = new Size(389, 25);
            txbBuscador.TabIndex = 44;
            txbBuscador.TextChanged += txbBuscador_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(txbAdd);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txbNotas);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(txbExistencias);
            panel1.Controls.Add(txbProducto);
            panel1.Location = new Point(34, 89);
            panel1.Name = "panel1";
            panel1.Size = new Size(569, 273);
            panel1.TabIndex = 46;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(3, 42, 76);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(dgvHistorial);
            panel2.Location = new Point(609, 89);
            panel2.Name = "panel2";
            panel2.Size = new Size(687, 273);
            panel2.TabIndex = 47;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 11F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(19, 16);
            label1.Name = "label1";
            label1.Size = new Size(160, 21);
            label1.TabIndex = 48;
            label1.Text = "Historial de Registro";
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.BackgroundColor = Color.White;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(0, 33, 64);
            dataGridViewCellStyle10.Font = new Font("Montserrat", 11.25F, FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = Color.White;
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle10.SelectionForeColor = Color.White;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dgvHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(13, 43);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = Color.Transparent;
            dataGridViewCellStyle11.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle11.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            dgvHistorial.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dgvHistorial.RowHeadersVisible = false;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = Color.White;
            dataGridViewCellStyle12.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.ForeColor = Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle12.SelectionForeColor = Color.White;
            dgvHistorial.RowsDefaultCellStyle = dataGridViewCellStyle12;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(662, 217);
            dgvHistorial.TabIndex = 48;
            // 
            // AlmacenRegistrarExistencias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1322, 792);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label10);
            Controls.Add(txbBuscador);
            Controls.Add(label8);
            Controls.Add(labelprueba);
            Controls.Add(dgvAlmacen);
            Controls.Add(txbID);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AlmacenRegistrarExistencias";
            Text = "AlmacenRegistrarExistencias";
            Load += AlmacenRegistrarExistencias_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAlmacen).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txbID;
        private TextBox txbNotas;
        private TextBox txbAdd;
        private TextBox txbExistencias;
        private TextBox txbProducto;
        private Button button2;
        private DataGridView dgvAlmacen;
        private Label labelprueba;
        private Label label8;
        private Label label10;
        private TextBox txbBuscador;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private DataGridView dgvHistorial;
    }
}