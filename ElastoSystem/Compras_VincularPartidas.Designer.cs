namespace ElastoSystem
{
    partial class Compras_VincularPartidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compras_VincularPartidas));
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            panel3 = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox6 = new PictureBox();
            lblSolicito = new Label();
            label2 = new Label();
            dgvPartidas = new DataGridView();
            panel5 = new Panel();
            lblID = new Label();
            label3 = new Label();
            dgvRequisicions = new DataGridView();
            label1 = new Label();
            dgvLista = new DataGridView();
            ID_Producto = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            txbReqFolio = new TextBox();
            txbFolio = new TextBox();
            lblIDProducto = new Label();
            btnAgregarPartidas = new Button();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPartidas).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequisicions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
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
            panel3.Size = new Size(1301, 30);
            panel3.TabIndex = 50;
            panel3.MouseDown += panel3_MouseDown;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(1266, 4);
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
            pictureBox6.Location = new Point(1266, 4);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(23, 23);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 18;
            pictureBox6.TabStop = false;
            pictureBox6.Click += pictureBox6_Click;
            pictureBox6.MouseLeave += pictureBox6_MouseLeave;
            // 
            // lblSolicito
            // 
            lblSolicito.AutoSize = true;
            lblSolicito.BackColor = Color.Transparent;
            lblSolicito.Font = new Font("Montserrat", 12F);
            lblSolicito.ForeColor = Color.White;
            lblSolicito.Location = new Point(397, 222);
            lblSolicito.Name = "lblSolicito";
            lblSolicito.Size = new Size(105, 22);
            lblSolicito.TabIndex = 38;
            lblSolicito.Text = "Descripción";
            lblSolicito.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(23, 226);
            label2.Name = "label2";
            label2.Size = new Size(95, 22);
            label2.TabIndex = 23;
            label2.Text = "PARTIDAS";
            // 
            // dgvPartidas
            // 
            dgvPartidas.AllowUserToAddRows = false;
            dgvPartidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPartidas.BackgroundColor = Color.White;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle13.BackColor = Color.White;
            dataGridViewCellStyle13.Font = new Font("Montserrat SemiBold", 9.749999F, FontStyle.Bold);
            dataGridViewCellStyle13.ForeColor = Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle13.SelectionForeColor = Color.White;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            dgvPartidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dgvPartidas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPartidas.Location = new Point(20, 262);
            dgvPartidas.Name = "dgvPartidas";
            dgvPartidas.ReadOnly = true;
            dgvPartidas.RowHeadersVisible = false;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = Color.White;
            dataGridViewCellStyle14.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle14.ForeColor = Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle14.SelectionForeColor = Color.White;
            dgvPartidas.RowsDefaultCellStyle = dataGridViewCellStyle14;
            dgvPartidas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPartidas.Size = new Size(555, 172);
            dgvPartidas.TabIndex = 20;
            dgvPartidas.CellClick += dgvPartidas_CellClick;
            dgvPartidas.Click += dgvPartidas_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(3, 42, 76);
            panel5.Controls.Add(lblSolicito);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(lblID);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(dgvPartidas);
            panel5.Controls.Add(dgvRequisicions);
            panel5.Location = new Point(16, 102);
            panel5.Name = "panel5";
            panel5.Size = new Size(591, 466);
            panel5.TabIndex = 51;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.BackColor = Color.Transparent;
            lblID.Font = new Font("Montserrat", 12F);
            lblID.ForeColor = Color.White;
            lblID.Location = new Point(397, 23);
            lblID.Name = "lblID";
            lblID.Size = new Size(105, 22);
            lblID.TabIndex = 37;
            lblID.Text = "Descripción";
            lblID.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(22, 23);
            label3.Name = "label3";
            label3.Size = new Size(128, 22);
            label3.TabIndex = 22;
            label3.Text = "REQUISIONES";
            // 
            // dgvRequisicions
            // 
            dgvRequisicions.AllowUserToAddRows = false;
            dgvRequisicions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequisicions.BackgroundColor = Color.White;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle15.BackColor = Color.White;
            dataGridViewCellStyle15.Font = new Font("Montserrat SemiBold", 9.749999F, FontStyle.Bold);
            dataGridViewCellStyle15.ForeColor = Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle15.SelectionForeColor = Color.White;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            dgvRequisicions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            dgvRequisicions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequisicions.Location = new Point(22, 63);
            dgvRequisicions.Name = "dgvRequisicions";
            dgvRequisicions.ReadOnly = true;
            dgvRequisicions.RowHeadersVisible = false;
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = Color.White;
            dataGridViewCellStyle16.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle16.ForeColor = Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle16.SelectionForeColor = Color.White;
            dgvRequisicions.RowsDefaultCellStyle = dataGridViewCellStyle16;
            dgvRequisicions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequisicions.Size = new Size(552, 140);
            dgvRequisicions.TabIndex = 21;
            dgvRequisicions.Click += dgvRequisicions_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(16, 43);
            label1.Name = "label1";
            label1.Size = new Size(376, 44);
            label1.TabIndex = 53;
            label1.Text = "VINCULAR PARTIDAS";
            // 
            // dgvLista
            // 
            dgvLista.AllowUserToAddRows = false;
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLista.BackgroundColor = Color.White;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle17.BackColor = Color.White;
            dataGridViewCellStyle17.Font = new Font("Montserrat SemiBold", 9.749999F, FontStyle.Bold);
            dataGridViewCellStyle17.ForeColor = Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle17.SelectionForeColor = Color.White;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            dgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLista.Columns.AddRange(new DataGridViewColumn[] { ID_Producto, Descripcion });
            dgvLista.Location = new Point(629, 102);
            dgvLista.Name = "dgvLista";
            dgvLista.ReadOnly = true;
            dgvLista.RowHeadersVisible = false;
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = Color.White;
            dataGridViewCellStyle18.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle18.ForeColor = Color.Black;
            dataGridViewCellStyle18.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle18.SelectionForeColor = Color.White;
            dgvLista.RowsDefaultCellStyle = dataGridViewCellStyle18;
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLista.Size = new Size(648, 372);
            dgvLista.TabIndex = 54;
            dgvLista.CellClick += dgvLista_CellClick;
            // 
            // ID_Producto
            // 
            ID_Producto.HeaderText = "ID_Producto";
            ID_Producto.Name = "ID_Producto";
            ID_Producto.ReadOnly = true;
            ID_Producto.Visible = false;
            // 
            // Descripcion
            // 
            Descripcion.HeaderText = "Descripcion";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            // 
            // txbReqFolio
            // 
            txbReqFolio.Location = new Point(1163, 63);
            txbReqFolio.Name = "txbReqFolio";
            txbReqFolio.Size = new Size(114, 23);
            txbReqFolio.TabIndex = 56;
            txbReqFolio.Visible = false;
            // 
            // txbFolio
            // 
            txbFolio.Location = new Point(1026, 63);
            txbFolio.Name = "txbFolio";
            txbFolio.Size = new Size(122, 23);
            txbFolio.TabIndex = 55;
            txbFolio.Visible = false;
            // 
            // lblIDProducto
            // 
            lblIDProducto.AutoSize = true;
            lblIDProducto.BackColor = Color.Transparent;
            lblIDProducto.Font = new Font("Montserrat", 12F);
            lblIDProducto.ForeColor = Color.White;
            lblIDProducto.Location = new Point(706, 60);
            lblIDProducto.Name = "lblIDProducto";
            lblIDProducto.Size = new Size(88, 22);
            lblIDProducto.TabIndex = 57;
            lblIDProducto.Text = "IDERROR";
            lblIDProducto.Visible = false;
            // 
            // btnAgregarPartidas
            // 
            btnAgregarPartidas.BackColor = Color.FromArgb(255, 102, 0);
            btnAgregarPartidas.Cursor = Cursors.Hand;
            btnAgregarPartidas.FlatAppearance.BorderSize = 0;
            btnAgregarPartidas.FlatStyle = FlatStyle.Flat;
            btnAgregarPartidas.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnAgregarPartidas.ForeColor = Color.White;
            btnAgregarPartidas.Location = new Point(941, 498);
            btnAgregarPartidas.Name = "btnAgregarPartidas";
            btnAgregarPartidas.Size = new Size(314, 38);
            btnAgregarPartidas.TabIndex = 58;
            btnAgregarPartidas.Text = "Agregar Partidas";
            btnAgregarPartidas.UseVisualStyleBackColor = false;
            btnAgregarPartidas.Click += btnAgregarPartidas_Click;
            // 
            // Compras_VincularPartidas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1301, 580);
            Controls.Add(btnAgregarPartidas);
            Controls.Add(lblIDProducto);
            Controls.Add(txbReqFolio);
            Controls.Add(txbFolio);
            Controls.Add(dgvLista);
            Controls.Add(label1);
            Controls.Add(panel5);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Compras_VincularPartidas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Compras_VincularPartidas";
            Load += Compras_VincularPartidas_Load;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPartidas).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequisicions).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox6;
        private Label lblSolicito;
        private Label label2;
        private DataGridView dgvPartidas;
        private Panel panel5;
        private Label lblID;
        private Label label3;
        private DataGridView dgvRequisicions;
        private Label label1;
        private DataGridView dgvLista;
        private TextBox txbReqFolio;
        private TextBox txbFolio;
        private Label lblIDProducto;
        private DataGridViewTextBoxColumn ID_Producto;
        private DataGridViewTextBoxColumn Descripcion;
        private Button btnAgregarPartidas;
    }
}