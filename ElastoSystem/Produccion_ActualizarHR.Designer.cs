namespace ElastoSystem
{
    partial class Produccion_ActualizarHR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produccion_ActualizarHR));
            label1 = new Label();
            panel3 = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox6 = new PictureBox();
            btnGuardarProceso = new Button();
            label31 = new Label();
            label2 = new Label();
            lblFamilia = new Label();
            lblProducto = new Label();
            lblNave = new Label();
            label6 = new Label();
            lblNoOperacion = new Label();
            label8 = new Label();
            lblArea = new Label();
            label10 = new Label();
            lblDescripcion = new Label();
            label12 = new Label();
            txbCantidadUnidad = new TextBox();
            txbNombreArea = new TextBox();
            label16 = new Label();
            chbNombreArea = new CheckBox();
            chbCantidadxUnidad = new CheckBox();
            label13 = new Label();
            lblProduccion = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 22F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(170, 46);
            label1.Name = "label1";
            label1.Size = new Size(385, 41);
            label1.TabIndex = 15;
            label1.Text = "ACTUALIZAR PROCESO";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(153, 255, 255, 255);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(pictureBox6);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(748, 30);
            panel3.TabIndex = 51;
            panel3.MouseDown += panel3_MouseDown;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(710, 4);
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
            pictureBox6.Location = new Point(710, 4);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(23, 23);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 18;
            pictureBox6.TabStop = false;
            pictureBox6.Click += pictureBox6_Click;
            pictureBox6.MouseLeave += pictureBox6_MouseLeave;
            // 
            // btnGuardarProceso
            // 
            btnGuardarProceso.BackColor = Color.FromArgb(255, 102, 0);
            btnGuardarProceso.Cursor = Cursors.Hand;
            btnGuardarProceso.FlatAppearance.BorderSize = 0;
            btnGuardarProceso.FlatStyle = FlatStyle.Flat;
            btnGuardarProceso.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnGuardarProceso.ForeColor = Color.White;
            btnGuardarProceso.Location = new Point(216, 443);
            btnGuardarProceso.Name = "btnGuardarProceso";
            btnGuardarProceso.Size = new Size(262, 35);
            btnGuardarProceso.TabIndex = 79;
            btnGuardarProceso.Text = "Guardar Proceso";
            btnGuardarProceso.UseVisualStyleBackColor = false;
            btnGuardarProceso.Click += btnGuardarProceso_Click;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.BackColor = Color.Transparent;
            label31.Font = new Font("Montserrat", 11F);
            label31.ForeColor = Color.White;
            label31.Location = new Point(21, 105);
            label31.Name = "label31";
            label31.Size = new Size(68, 21);
            label31.TabIndex = 80;
            label31.Text = "Familia:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 11F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(21, 137);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 82;
            label2.Text = "Producto:";
            // 
            // lblFamilia
            // 
            lblFamilia.AutoSize = true;
            lblFamilia.BackColor = Color.Transparent;
            lblFamilia.Font = new Font("Montserrat", 11F);
            lblFamilia.ForeColor = Color.White;
            lblFamilia.Location = new Point(145, 105);
            lblFamilia.Name = "lblFamilia";
            lblFamilia.Size = new Size(134, 21);
            lblFamilia.TabIndex = 83;
            lblFamilia.Text = "ERROR FAMILIA";
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.BackColor = Color.Transparent;
            lblProducto.Font = new Font("Montserrat", 11F);
            lblProducto.ForeColor = Color.White;
            lblProducto.Location = new Point(145, 137);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(162, 21);
            lblProducto.TabIndex = 84;
            lblProducto.Text = "ERROR PRODUCTO";
            // 
            // lblNave
            // 
            lblNave.AutoSize = true;
            lblNave.BackColor = Color.Transparent;
            lblNave.Font = new Font("Montserrat", 11F);
            lblNave.ForeColor = Color.White;
            lblNave.Location = new Point(145, 171);
            lblNave.Name = "lblNave";
            lblNave.Size = new Size(112, 21);
            lblNave.TabIndex = 86;
            lblNave.Text = "ERROR NAVE";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 11F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(21, 171);
            label6.Name = "label6";
            label6.Size = new Size(51, 21);
            label6.TabIndex = 85;
            label6.Text = "Nave:";
            // 
            // lblNoOperacion
            // 
            lblNoOperacion.AutoSize = true;
            lblNoOperacion.BackColor = Color.Transparent;
            lblNoOperacion.Font = new Font("Montserrat", 11F);
            lblNoOperacion.ForeColor = Color.White;
            lblNoOperacion.Location = new Point(145, 207);
            lblNoOperacion.Name = "lblNoOperacion";
            lblNoOperacion.Size = new Size(94, 21);
            lblNoOperacion.TabIndex = 88;
            lblNoOperacion.Text = "ERROR No.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 11F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(21, 207);
            label8.Name = "label8";
            label8.Size = new Size(118, 21);
            label8.TabIndex = 87;
            label8.Text = "No. Operacion:";
            // 
            // lblArea
            // 
            lblArea.AutoSize = true;
            lblArea.BackColor = Color.Transparent;
            lblArea.Font = new Font("Montserrat", 11F);
            lblArea.ForeColor = Color.White;
            lblArea.Location = new Point(145, 243);
            lblArea.Name = "lblArea";
            lblArea.Size = new Size(113, 21);
            lblArea.TabIndex = 90;
            lblArea.Text = "ERROR AREA";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 11F);
            label10.ForeColor = Color.White;
            label10.Location = new Point(21, 243);
            label10.Name = "label10";
            label10.Size = new Size(48, 21);
            label10.TabIndex = 89;
            label10.Text = "Area:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.BackColor = Color.Transparent;
            lblDescripcion.Font = new Font("Montserrat", 11F);
            lblDescripcion.ForeColor = Color.White;
            lblDescripcion.Location = new Point(145, 277);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(180, 21);
            lblDescripcion.TabIndex = 92;
            lblDescripcion.Text = "ERROR DESCRIPCION";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Montserrat", 11F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(21, 277);
            label12.Name = "label12";
            label12.Size = new Size(100, 21);
            label12.TabIndex = 91;
            label12.Text = "Descripcion:";
            // 
            // txbCantidadUnidad
            // 
            txbCantidadUnidad.Font = new Font("Montserrat", 11F);
            txbCantidadUnidad.Location = new Point(196, 397);
            txbCantidadUnidad.Name = "txbCantidadUnidad";
            txbCantidadUnidad.Size = new Size(259, 25);
            txbCantidadUnidad.TabIndex = 96;
            txbCantidadUnidad.Enter += txbCantidadUnidad_Enter;
            txbCantidadUnidad.KeyPress += txbCantidadUnidad_KeyPress;
            // 
            // txbNombreArea
            // 
            txbNombreArea.Font = new Font("Montserrat", 11F);
            txbNombreArea.Location = new Point(196, 361);
            txbNombreArea.Name = "txbNombreArea";
            txbNombreArea.Size = new Size(537, 25);
            txbNombreArea.TabIndex = 97;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Montserrat", 9F);
            label16.ForeColor = Color.White;
            label16.Location = new Point(26, 518);
            label16.Name = "label16";
            label16.Size = new Size(695, 16);
            label16.TabIndex = 98;
            label16.Text = "Info. Las casillas marcadas efectuaran cambios en todos los productos de esa familia con ese numero de operacion";
            // 
            // chbNombreArea
            // 
            chbNombreArea.AutoSize = true;
            chbNombreArea.BackColor = Color.Transparent;
            chbNombreArea.Font = new Font("Montserrat", 11F);
            chbNombreArea.ForeColor = Color.White;
            chbNombreArea.Location = new Point(21, 361);
            chbNombreArea.Name = "chbNombreArea";
            chbNombreArea.Size = new Size(142, 25);
            chbNombreArea.TabIndex = 99;
            chbNombreArea.Text = "Nombrea Area:";
            chbNombreArea.UseVisualStyleBackColor = false;
            // 
            // chbCantidadxUnidad
            // 
            chbCantidadxUnidad.AutoSize = true;
            chbCantidadxUnidad.BackColor = Color.Transparent;
            chbCantidadxUnidad.Font = new Font("Montserrat", 11F);
            chbCantidadxUnidad.ForeColor = Color.White;
            chbCantidadxUnidad.Location = new Point(18, 397);
            chbCantidadxUnidad.Name = "chbCantidadxUnidad";
            chbCantidadxUnidad.Size = new Size(172, 25);
            chbCantidadxUnidad.TabIndex = 101;
            chbCantidadxUnidad.Text = "Cantidad x Unidad:";
            chbCantidadxUnidad.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 11F);
            label13.ForeColor = Color.White;
            label13.Location = new Point(21, 312);
            label13.Name = "label13";
            label13.Size = new Size(169, 21);
            label13.TabIndex = 93;
            label13.Text = "Produccion Estandar:";
            // 
            // lblProduccion
            // 
            lblProduccion.AutoSize = true;
            lblProduccion.BackColor = Color.Transparent;
            lblProduccion.Font = new Font("Montserrat", 11F);
            lblProduccion.ForeColor = Color.White;
            lblProduccion.Location = new Point(196, 312);
            lblProduccion.Name = "lblProduccion";
            lblProduccion.Size = new Size(181, 21);
            lblProduccion.TabIndex = 102;
            lblProduccion.Text = "ERROR PRODUCCION";
            // 
            // Produccion_ActualizarHR
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(748, 546);
            Controls.Add(lblProduccion);
            Controls.Add(chbCantidadxUnidad);
            Controls.Add(chbNombreArea);
            Controls.Add(label16);
            Controls.Add(txbNombreArea);
            Controls.Add(txbCantidadUnidad);
            Controls.Add(label13);
            Controls.Add(lblDescripcion);
            Controls.Add(label12);
            Controls.Add(lblArea);
            Controls.Add(label10);
            Controls.Add(lblNoOperacion);
            Controls.Add(label8);
            Controls.Add(lblNave);
            Controls.Add(label6);
            Controls.Add(lblProducto);
            Controls.Add(lblFamilia);
            Controls.Add(label2);
            Controls.Add(btnGuardarProceso);
            Controls.Add(label31);
            Controls.Add(panel3);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_ActualizarHR";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Produccion_ActualizarHR";
            Load += Produccion_ActualizarHR_Load;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel3;
        private PictureBox pictureBox6;
        private Button btnGuardarProceso;
        private Label label31;
        private Label label2;
        private Label lblFamilia;
        private Label lblProducto;
        private Label lblNave;
        private Label label6;
        private Label lblNoOperacion;
        private Label label8;
        private Label lblArea;
        private Label label10;
        private Label lblDescripcion;
        private Label label12;
        private PictureBox pictureBox4;
        private TextBox txbCantidadUnidad;
        private TextBox txbNombreArea;
        private Label label16;
        private CheckBox chbNombreArea;
        private CheckBox chbCantidadxUnidad;
        private Label label13;
        private Label lblProduccion;
    }
}