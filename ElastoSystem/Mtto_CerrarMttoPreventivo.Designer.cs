namespace ElastoSystem
{
    partial class Mtto_CerrarMttoPreventivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mtto_CerrarMttoPreventivo));
            panel3 = new Panel();
            pictureBox5 = new PictureBox();
            btncerrar = new PictureBox();
            label1 = new Label();
            dtpFechaCierre = new DateTimePicker();
            lblFechaInicio = new Label();
            btnFinalizar = new Button();
            txbRealizo = new TextBox();
            label15 = new Label();
            txbObservaciones = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txbActivo = new TextBox();
            txbActividad = new TextBox();
            txbDescripcionFin = new TextBox();
            txbFechaInicio = new TextBox();
            txbID = new TextBox();
            txbPerio = new TextBox();
            txbTipo = new TextBox();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btncerrar).BeginInit();
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
            panel3.Size = new Size(606, 30);
            panel3.TabIndex = 51;
            panel3.MouseDown += panel3_MouseDown;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Cursor = Cursors.Hand;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(564, 4);
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
            btncerrar.Location = new Point(564, 4);
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
            label1.Font = new Font("Montserrat", 18F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(26, 50);
            label1.Name = "label1";
            label1.Size = new Size(547, 33);
            label1.TabIndex = 59;
            label1.Text = "FINALIZAR MANTENIMIENTO PREVENTIVO";
            // 
            // dtpFechaCierre
            // 
            dtpFechaCierre.Font = new Font("Montserrat", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaCierre.Location = new Point(195, 365);
            dtpFechaCierre.Name = "dtpFechaCierre";
            dtpFechaCierre.Size = new Size(378, 26);
            dtpFechaCierre.TabIndex = 71;
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.BackColor = Color.Transparent;
            lblFechaInicio.Font = new Font("Montserrat", 12F);
            lblFechaInicio.ForeColor = Color.White;
            lblFechaInicio.Location = new Point(30, 368);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(139, 22);
            lblFechaInicio.TabIndex = 70;
            lblFechaInicio.Text = "Fecha de Cierre:";
            // 
            // btnFinalizar
            // 
            btnFinalizar.BackColor = Color.FromArgb(255, 102, 0);
            btnFinalizar.Cursor = Cursors.Hand;
            btnFinalizar.FlatAppearance.BorderSize = 0;
            btnFinalizar.FlatStyle = FlatStyle.Flat;
            btnFinalizar.Font = new Font("Montserrat", 11.25F, FontStyle.Bold);
            btnFinalizar.ForeColor = Color.White;
            btnFinalizar.Location = new Point(173, 438);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(257, 33);
            btnFinalizar.TabIndex = 69;
            btnFinalizar.Text = "FINALIZAR";
            btnFinalizar.UseVisualStyleBackColor = false;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // txbRealizo
            // 
            txbRealizo.Font = new Font("Montserrat", 12F);
            txbRealizo.Location = new Point(195, 270);
            txbRealizo.Name = "txbRealizo";
            txbRealizo.Size = new Size(378, 27);
            txbRealizo.TabIndex = 73;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Montserrat", 12F);
            label15.ForeColor = Color.White;
            label15.Location = new Point(30, 273);
            label15.Name = "label15";
            label15.Size = new Size(70, 22);
            label15.TabIndex = 72;
            label15.Text = "Realizo:";
            // 
            // txbObservaciones
            // 
            txbObservaciones.Font = new Font("Montserrat", 12F);
            txbObservaciones.Location = new Point(195, 320);
            txbObservaciones.Name = "txbObservaciones";
            txbObservaciones.Size = new Size(378, 27);
            txbObservaciones.TabIndex = 75;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(30, 323);
            label2.Name = "label2";
            label2.Size = new Size(131, 22);
            label2.TabIndex = 74;
            label2.Text = "Observaciones:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(30, 204);
            label3.Name = "label3";
            label3.Size = new Size(134, 22);
            label3.TabIndex = 76;
            label3.Text = "Fecha de Inicio:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(30, 171);
            label4.Name = "label4";
            label4.Size = new Size(108, 22);
            label4.TabIndex = 77;
            label4.Text = "Descripcion:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 12F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(30, 138);
            label5.Name = "label5";
            label5.Size = new Size(87, 22);
            label5.TabIndex = 78;
            label5.Text = "Actividad:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 12F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(30, 105);
            label6.Name = "label6";
            label6.Size = new Size(62, 22);
            label6.TabIndex = 79;
            label6.Text = "Activo:";
            // 
            // txbActivo
            // 
            txbActivo.Font = new Font("Montserrat", 12F);
            txbActivo.Location = new Point(195, 102);
            txbActivo.Name = "txbActivo";
            txbActivo.ReadOnly = true;
            txbActivo.Size = new Size(378, 27);
            txbActivo.TabIndex = 80;
            // 
            // txbActividad
            // 
            txbActividad.Font = new Font("Montserrat", 12F);
            txbActividad.Location = new Point(195, 135);
            txbActividad.Name = "txbActividad";
            txbActividad.ReadOnly = true;
            txbActividad.Size = new Size(378, 27);
            txbActividad.TabIndex = 81;
            // 
            // txbDescripcionFin
            // 
            txbDescripcionFin.Font = new Font("Montserrat", 12F);
            txbDescripcionFin.Location = new Point(195, 168);
            txbDescripcionFin.Name = "txbDescripcionFin";
            txbDescripcionFin.ReadOnly = true;
            txbDescripcionFin.Size = new Size(378, 27);
            txbDescripcionFin.TabIndex = 82;
            // 
            // txbFechaInicio
            // 
            txbFechaInicio.Font = new Font("Montserrat", 12F);
            txbFechaInicio.Location = new Point(195, 201);
            txbFechaInicio.Name = "txbFechaInicio";
            txbFechaInicio.ReadOnly = true;
            txbFechaInicio.Size = new Size(378, 27);
            txbFechaInicio.TabIndex = 83;
            // 
            // txbID
            // 
            txbID.Font = new Font("Montserrat", 12F);
            txbID.Location = new Point(6, 56);
            txbID.Name = "txbID";
            txbID.Size = new Size(24, 27);
            txbID.TabIndex = 84;
            txbID.Visible = false;
            // 
            // txbPerio
            // 
            txbPerio.Font = new Font("Montserrat", 12F);
            txbPerio.Location = new Point(30, 229);
            txbPerio.Name = "txbPerio";
            txbPerio.ReadOnly = true;
            txbPerio.Size = new Size(47, 27);
            txbPerio.TabIndex = 85;
            txbPerio.Visible = false;
            // 
            // txbTipo
            // 
            txbTipo.Font = new Font("Montserrat", 12F);
            txbTipo.Location = new Point(280, 235);
            txbTipo.Name = "txbTipo";
            txbTipo.ReadOnly = true;
            txbTipo.Size = new Size(85, 27);
            txbTipo.TabIndex = 86;
            txbTipo.Visible = false;
            // 
            // Mtto_CerrarMttoPreventivo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(606, 504);
            Controls.Add(txbTipo);
            Controls.Add(txbPerio);
            Controls.Add(txbID);
            Controls.Add(txbFechaInicio);
            Controls.Add(txbDescripcionFin);
            Controls.Add(txbActividad);
            Controls.Add(txbActivo);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txbObservaciones);
            Controls.Add(label2);
            Controls.Add(txbRealizo);
            Controls.Add(label15);
            Controls.Add(dtpFechaCierre);
            Controls.Add(lblFechaInicio);
            Controls.Add(btnFinalizar);
            Controls.Add(label1);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Mtto_CerrarMttoPreventivo";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Mtto_CerrarMttoPreventivo_Load;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)btncerrar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private PictureBox pictureBox5;
        private PictureBox btncerrar;
        private Label label1;
        private DateTimePicker dtpFechaCierre;
        private Label lblFechaInicio;
        private Button btnFinalizar;
        private TextBox txbRealizo;
        private Label label15;
        private TextBox txbObservaciones;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txbActivo;
        private TextBox txbActividad;
        private TextBox txbDescripcionFin;
        private TextBox txbFechaInicio;
        private TextBox txbID;
        private TextBox txbPerio;
        private TextBox txbTipo;
    }
}