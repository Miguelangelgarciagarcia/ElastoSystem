namespace ElastoSystem
{
    partial class Almacen_AdministrarSolicitudes
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label7 = new Label();
            panel1 = new Panel();
            btnCancelarSolicitud = new Button();
            lblClave = new Label();
            dgvSolicitudes = new DataGridView();
            btnActualizarSolicitud = new Button();
            lblFecha = new Label();
            lblMeses = new Label();
            lblFolio = new Label();
            label8 = new Label();
            label21 = new Label();
            label1 = new Label();
            label22 = new Label();
            lbl4Meses = new Label();
            lbl3Meses = new Label();
            lbl2Meses = new Label();
            lbl1Mes = new Label();
            label13 = new Label();
            txbNotas = new TextBox();
            label12 = new Label();
            label3 = new Label();
            txbCantidad = new TextBox();
            label11 = new Label();
            label4 = new Label();
            lblCantidadActual = new Label();
            label6 = new Label();
            label2 = new Label();
            label5 = new Label();
            dgvProductosSAE2 = new DataGridView();
            bSAspelSAE = new BindingSource(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductosSAE2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bSAspelSAE).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 24F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(26, 34);
            label7.Name = "label7";
            label7.Size = new Size(791, 44);
            label7.TabIndex = 16;
            label7.Text = "ADMINISTRAR SOLICITUDES DE FABRICACION";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(btnCancelarSolicitud);
            panel1.Controls.Add(lblClave);
            panel1.Controls.Add(dgvSolicitudes);
            panel1.Controls.Add(btnActualizarSolicitud);
            panel1.Controls.Add(lblFecha);
            panel1.Controls.Add(lblMeses);
            panel1.Controls.Add(lblFolio);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label21);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label22);
            panel1.Controls.Add(lbl4Meses);
            panel1.Controls.Add(lbl3Meses);
            panel1.Controls.Add(lbl2Meses);
            panel1.Controls.Add(lbl1Mes);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(txbNotas);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txbCantidad);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lblCantidadActual);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(26, 93);
            panel1.Name = "panel1";
            panel1.Size = new Size(1288, 708);
            panel1.TabIndex = 52;
            panel1.Paint += panel1_Paint;
            // 
            // btnCancelarSolicitud
            // 
            btnCancelarSolicitud.BackColor = Color.FromArgb(255, 102, 0);
            btnCancelarSolicitud.Cursor = Cursors.Hand;
            btnCancelarSolicitud.FlatAppearance.BorderSize = 0;
            btnCancelarSolicitud.FlatStyle = FlatStyle.Flat;
            btnCancelarSolicitud.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnCancelarSolicitud.ForeColor = Color.White;
            btnCancelarSolicitud.Location = new Point(65, 639);
            btnCancelarSolicitud.Name = "btnCancelarSolicitud";
            btnCancelarSolicitud.Size = new Size(382, 34);
            btnCancelarSolicitud.TabIndex = 77;
            btnCancelarSolicitud.Text = "CANCELAR SOLICITUD";
            btnCancelarSolicitud.UseVisualStyleBackColor = false;
            btnCancelarSolicitud.Visible = false;
            btnCancelarSolicitud.Click += btnCancelarSolicitud_Click;
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.BackColor = Color.Transparent;
            lblClave.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblClave.ForeColor = Color.White;
            lblClave.Location = new Point(195, 403);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(124, 22);
            lblClave.TabIndex = 76;
            lblClave.Text = "-------------------";
            // 
            // dgvSolicitudes
            // 
            dgvSolicitudes.AllowUserToAddRows = false;
            dgvSolicitudes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSolicitudes.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSolicitudes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSolicitudes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSolicitudes.Location = new Point(17, 20);
            dgvSolicitudes.Name = "dgvSolicitudes";
            dgvSolicitudes.ReadOnly = true;
            dgvSolicitudes.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 12F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvSolicitudes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvSolicitudes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSolicitudes.Size = new Size(1248, 357);
            dgvSolicitudes.TabIndex = 75;
            dgvSolicitudes.Click += dgvSolicitudes_Click;
            // 
            // btnActualizarSolicitud
            // 
            btnActualizarSolicitud.BackColor = Color.FromArgb(255, 102, 0);
            btnActualizarSolicitud.Cursor = Cursors.Hand;
            btnActualizarSolicitud.FlatAppearance.BorderSize = 0;
            btnActualizarSolicitud.FlatStyle = FlatStyle.Flat;
            btnActualizarSolicitud.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnActualizarSolicitud.ForeColor = Color.White;
            btnActualizarSolicitud.Location = new Point(748, 636);
            btnActualizarSolicitud.Name = "btnActualizarSolicitud";
            btnActualizarSolicitud.Size = new Size(386, 34);
            btnActualizarSolicitud.TabIndex = 43;
            btnActualizarSolicitud.Text = "ACTUALIZAR SOLICITUD";
            btnActualizarSolicitud.UseVisualStyleBackColor = false;
            btnActualizarSolicitud.Visible = false;
            btnActualizarSolicitud.Click += btnActualizarSolicitud_Click;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BackColor = Color.Transparent;
            lblFecha.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblFecha.ForeColor = Color.White;
            lblFecha.Location = new Point(1006, 434);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(124, 22);
            lblFecha.TabIndex = 66;
            lblFecha.Text = "-------------------";
            // 
            // lblMeses
            // 
            lblMeses.AutoSize = true;
            lblMeses.BackColor = Color.Transparent;
            lblMeses.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblMeses.ForeColor = Color.White;
            lblMeses.Location = new Point(470, 449);
            lblMeses.Name = "lblMeses";
            lblMeses.Size = new Size(46, 22);
            lblMeses.TabIndex = 74;
            lblMeses.Text = "------";
            // 
            // lblFolio
            // 
            lblFolio.AutoSize = true;
            lblFolio.BackColor = Color.Transparent;
            lblFolio.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblFolio.ForeColor = Color.White;
            lblFolio.Location = new Point(1006, 400);
            lblFolio.Name = "lblFolio";
            lblFolio.Size = new Size(124, 22);
            lblFolio.TabIndex = 65;
            lblFolio.Text = "-------------------";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 12F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(400, 449);
            label8.Name = "label8";
            label8.Size = new Size(64, 22);
            label8.TabIndex = 73;
            label8.Text = "Meses:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.Transparent;
            label21.Font = new Font("Montserrat", 12F);
            label21.ForeColor = Color.White;
            label21.Location = new Point(934, 400);
            label21.Name = "label21";
            label21.Size = new Size(51, 22);
            label21.TabIndex = 64;
            label21.Text = "Folio:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(88, 578);
            label1.Name = "label1";
            label1.Size = new Size(141, 22);
            label1.TabIndex = 72;
            label1.Text = "SobreInventario:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.Transparent;
            label22.Font = new Font("Montserrat", 12F);
            label22.ForeColor = Color.White;
            label22.Location = new Point(934, 434);
            label22.Name = "label22";
            label22.Size = new Size(62, 22);
            label22.TabIndex = 63;
            label22.Text = "Fecha:";
            // 
            // lbl4Meses
            // 
            lbl4Meses.AutoSize = true;
            lbl4Meses.BackColor = Color.Transparent;
            lbl4Meses.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lbl4Meses.ForeColor = Color.White;
            lbl4Meses.Location = new Point(273, 578);
            lbl4Meses.Name = "lbl4Meses";
            lbl4Meses.Size = new Size(46, 22);
            lbl4Meses.TabIndex = 71;
            lbl4Meses.Text = "------";
            // 
            // lbl3Meses
            // 
            lbl3Meses.AutoSize = true;
            lbl3Meses.BackColor = Color.Transparent;
            lbl3Meses.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lbl3Meses.ForeColor = Color.White;
            lbl3Meses.Location = new Point(273, 556);
            lbl3Meses.Name = "lbl3Meses";
            lbl3Meses.Size = new Size(46, 22);
            lbl3Meses.TabIndex = 68;
            lbl3Meses.Text = "------";
            // 
            // lbl2Meses
            // 
            lbl2Meses.AutoSize = true;
            lbl2Meses.BackColor = Color.Transparent;
            lbl2Meses.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lbl2Meses.ForeColor = Color.White;
            lbl2Meses.Location = new Point(273, 529);
            lbl2Meses.Name = "lbl2Meses";
            lbl2Meses.Size = new Size(46, 22);
            lbl2Meses.TabIndex = 67;
            lbl2Meses.Text = "------";
            // 
            // lbl1Mes
            // 
            lbl1Mes.AutoSize = true;
            lbl1Mes.BackColor = Color.Transparent;
            lbl1Mes.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lbl1Mes.ForeColor = Color.White;
            lbl1Mes.Location = new Point(273, 503);
            lbl1Mes.Name = "lbl1Mes";
            lbl1Mes.Size = new Size(46, 22);
            lbl1Mes.TabIndex = 66;
            lbl1Mes.Text = "------";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 12F);
            label13.ForeColor = Color.White;
            label13.Location = new Point(87, 550);
            label13.Name = "label13";
            label13.Size = new Size(77, 22);
            label13.TabIndex = 65;
            label13.Text = "3 Meses:";
            // 
            // txbNotas
            // 
            txbNotas.Font = new Font("Montserrat", 12F);
            txbNotas.Location = new Point(748, 529);
            txbNotas.Multiline = true;
            txbNotas.Name = "txbNotas";
            txbNotas.Size = new Size(403, 71);
            txbNotas.TabIndex = 50;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Montserrat", 12F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(86, 526);
            label12.Name = "label12";
            label12.Size = new Size(77, 22);
            label12.TabIndex = 64;
            label12.Text = "2 Meses:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(679, 532);
            label3.Name = "label3";
            label3.Size = new Size(59, 22);
            label3.TabIndex = 42;
            label3.Text = "Notas:";
            // 
            // txbCantidad
            // 
            txbCantidad.Font = new Font("Montserrat", 12F);
            txbCantidad.Location = new Point(934, 486);
            txbCantidad.Name = "txbCantidad";
            txbCantidad.Size = new Size(217, 27);
            txbCantidad.TabIndex = 49;
            txbCantidad.KeyPress += txbCantidad_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Montserrat", 12F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(88, 500);
            label11.Name = "label11";
            label11.Size = new Size(56, 22);
            label11.TabIndex = 63;
            label11.Text = "1 Mes:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(675, 489);
            label4.Name = "label4";
            label4.Size = new Size(247, 22);
            label4.TabIndex = 48;
            label4.Text = "Cantidad Solicitada a Fabricar:";
            // 
            // lblCantidadActual
            // 
            lblCantidadActual.AutoSize = true;
            lblCantidadActual.BackColor = Color.Transparent;
            lblCantidadActual.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            lblCantidadActual.ForeColor = Color.White;
            lblCantidadActual.Location = new Point(227, 449);
            lblCantidadActual.Name = "lblCantidadActual";
            lblCantidadActual.Size = new Size(124, 22);
            lblCantidadActual.TabIndex = 62;
            lblCantidadActual.Text = "-------------------";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 9F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(975, 673);
            label6.Name = "label6";
            label6.Size = new Size(10, 16);
            label6.TabIndex = 60;
            label6.Text = ".";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(76, 403);
            label2.Name = "label2";
            label2.Size = new Size(57, 22);
            label2.TabIndex = 21;
            label2.Text = "Clave:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 12F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(76, 449);
            label5.Name = "label5";
            label5.Size = new Size(140, 22);
            label5.TabIndex = 46;
            label5.Text = "Cantidad Actual:";
            // 
            // dgvProductosSAE2
            // 
            dgvProductosSAE2.AllowUserToAddRows = false;
            dgvProductosSAE2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductosSAE2.Location = new Point(823, 54);
            dgvProductosSAE2.Name = "dgvProductosSAE2";
            dgvProductosSAE2.Size = new Size(21, 24);
            dgvProductosSAE2.TabIndex = 60;
            dgvProductosSAE2.Visible = false;
            // 
            // Almacen_AdministrarSolicitudes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(dgvProductosSAE2);
            Controls.Add(panel1);
            Controls.Add(label7);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Almacen_AdministrarSolicitudes";
            Text = "Almacen_AdministrarSolicitudes";
            Load += Almacen_AdministrarSolicitudes_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductosSAE2).EndInit();
            ((System.ComponentModel.ISupportInitialize)bSAspelSAE).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Panel panel1;
        private Button btnActualizarSolicitud;
        private Label lblFecha;
        private Label lblMeses;
        private Label lblFolio;
        private Label label8;
        private Label label21;
        private Label label1;
        private Label label22;
        private Label lbl4Meses;
        private Label lbl3Meses;
        private Label lbl2Meses;
        private Label lbl1Mes;
        private Label label13;
        private TextBox txbNotas;
        private Label label12;
        private Label label3;
        private TextBox txbCantidad;
        private Label label11;
        private Label label4;
        private Label lblCantidadActual;
        private Label label6;
        private Label label2;
        private Label label5;
        private DataGridView dgvSolicitudes;
        private Label lblClave;
        private DataGridView dgvProductosSAE2;
        private BindingSource bSAspelSAE;
        private Button btnCancelarSolicitud;
    }
}