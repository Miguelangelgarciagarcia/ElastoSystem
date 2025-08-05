namespace ElastoSystem
{
    partial class Mtto_ActividadesDia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mtto_ActividadesDia));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel3 = new Panel();
            pictureBox5 = new PictureBox();
            btncerrar = new PictureBox();
            label1 = new Label();
            lblCampos = new Label();
            lblFecha = new Label();
            label2 = new Label();
            label3 = new Label();
            dgvPendientes = new DataGridView();
            dgvFinalizados = new DataGridView();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btncerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPendientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFinalizados).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(153, 255, 255, 255);
            panel3.Controls.Add(pictureBox5);
            panel3.Controls.Add(btncerrar);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1024, 30);
            panel3.TabIndex = 50;
            panel3.MouseDown += panel3_MouseDown;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Cursor = Cursors.Hand;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(987, 4);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(23, 23);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 16;
            pictureBox5.TabStop = false;
            pictureBox5.MouseMove += pictureBox5_MouseMove;
            // 
            // btncerrar
            // 
            btncerrar.BackColor = Color.Transparent;
            btncerrar.Cursor = Cursors.Hand;
            btncerrar.Image = (Image)resources.GetObject("btncerrar.Image");
            btncerrar.Location = new Point(987, 4);
            btncerrar.Name = "btncerrar";
            btncerrar.Size = new Size(23, 23);
            btncerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btncerrar.TabIndex = 14;
            btncerrar.TabStop = false;
            btncerrar.Click += btncerrar_Click;
            btncerrar.MouseLeave += btncerrar_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 40);
            label1.Name = "label1";
            label1.Size = new Size(541, 44);
            label1.TabIndex = 58;
            label1.Text = "MANTENIMIENTO PREVENTIVO";
            // 
            // lblCampos
            // 
            lblCampos.AutoSize = true;
            lblCampos.BackColor = Color.Transparent;
            lblCampos.Font = new Font("Montserrat", 12F);
            lblCampos.ForeColor = Color.White;
            lblCampos.Location = new Point(808, 55);
            lblCampos.Name = "lblCampos";
            lblCampos.Size = new Size(62, 22);
            lblCampos.TabIndex = 59;
            lblCampos.Text = "Fecha:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BackColor = Color.Transparent;
            lblFecha.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblFecha.ForeColor = Color.White;
            lblFecha.Location = new Point(876, 57);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(134, 22);
            lblFecha.TabIndex = 60;
            lblFecha.Text = "--/--/---- ERROR";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 18F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(26, 90);
            label2.Name = "label2";
            label2.Size = new Size(159, 33);
            label2.TabIndex = 61;
            label2.Text = "Pendientes";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(26, 302);
            label3.Name = "label3";
            label3.Size = new Size(157, 33);
            label3.TabIndex = 62;
            label3.Text = "Finalizados";
            // 
            // dgvPendientes
            // 
            dgvPendientes.AllowUserToAddRows = false;
            dgvPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPendientes.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPendientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPendientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPendientes.Location = new Point(26, 126);
            dgvPendientes.Name = "dgvPendientes";
            dgvPendientes.ReadOnly = true;
            dgvPendientes.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvPendientes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvPendientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPendientes.Size = new Size(984, 159);
            dgvPendientes.TabIndex = 63;
            dgvPendientes.CellClick += dgvPendientes_CellClick;
            // 
            // dgvFinalizados
            // 
            dgvFinalizados.AllowUserToAddRows = false;
            dgvFinalizados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFinalizados.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvFinalizados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvFinalizados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFinalizados.Location = new Point(26, 344);
            dgvFinalizados.Name = "dgvFinalizados";
            dgvFinalizados.ReadOnly = true;
            dgvFinalizados.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvFinalizados.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvFinalizados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFinalizados.Size = new Size(984, 161);
            dgvFinalizados.TabIndex = 64;
            // 
            // Mtto_ActividadesDia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1024, 549);
            Controls.Add(dgvFinalizados);
            Controls.Add(dgvPendientes);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblFecha);
            Controls.Add(lblCampos);
            Controls.Add(label1);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Mtto_ActividadesDia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mtto_ActividadesDia";
            Load += Mtto_ActividadesDia_Load;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)btncerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPendientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFinalizados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private PictureBox pictureBox5;
        private PictureBox btncerrar;
        private Label label1;
        private Label lblCampos;
        private Label lblFecha;
        private Label label2;
        private Label label3;
        private DataGridView dgvPendientes;
        private DataGridView dgvFinalizados;
    }
}