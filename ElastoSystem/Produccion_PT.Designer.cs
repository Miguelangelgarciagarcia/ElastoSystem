namespace ElastoSystem
{
    partial class Produccion_PT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produccion_PT));
            panel4 = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox6 = new PictureBox();
            label1 = new Label();
            panel1 = new Panel();
            txbLote = new TextBox();
            txbCantidad = new TextBox();
            btnRegistrar = new Button();
            cbTurno = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            lblFecha = new Label();
            lblOP = new Label();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnGuardar = new Button();
            label5 = new Label();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(153, 255, 255, 255);
            panel4.Controls.Add(pictureBox4);
            panel4.Controls.Add(pictureBox6);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(814, 30);
            panel4.TabIndex = 87;
            panel4.MouseDown += panel4_MouseDown;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(783, 4);
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
            pictureBox6.Location = new Point(783, 4);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(23, 23);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 18;
            pictureBox6.TabStop = false;
            pictureBox6.Click += pictureBox6_Click;
            pictureBox6.MouseLeave += pictureBox6_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 20F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 42);
            label1.Name = "label1";
            label1.Size = new Size(741, 42);
            label1.TabIndex = 88;
            label1.Text = "PRODUCTO TERMINADO ENTREGADO A ALMACEN";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(txbLote);
            panel1.Controls.Add(txbCantidad);
            panel1.Controls.Add(btnRegistrar);
            panel1.Controls.Add(cbTurno);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(lblFecha);
            panel1.Controls.Add(lblOP);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(11, 87);
            panel1.Name = "panel1";
            panel1.Size = new Size(793, 207);
            panel1.TabIndex = 91;
            // 
            // txbLote
            // 
            txbLote.Font = new Font("Montserrat", 11F);
            txbLote.Location = new Point(78, 130);
            txbLote.Name = "txbLote";
            txbLote.Size = new Size(345, 25);
            txbLote.TabIndex = 2;
            txbLote.TextAlign = HorizontalAlignment.Center;
            // 
            // txbCantidad
            // 
            txbCantidad.Font = new Font("Montserrat", 11F);
            txbCantidad.Location = new Point(541, 79);
            txbCantidad.Name = "txbCantidad";
            txbCantidad.Size = new Size(232, 25);
            txbCantidad.TabIndex = 3;
            txbCantidad.TextAlign = HorizontalAlignment.Center;
            txbCantidad.TextChanged += txbCantidad_TextChanged;
            txbCantidad.KeyPress += txbCantidad_KeyPress;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(255, 102, 0);
            btnRegistrar.Cursor = Cursors.Hand;
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(469, 128);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(284, 35);
            btnRegistrar.TabIndex = 4;
            btnRegistrar.Text = "GUARDAR";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // cbTurno
            // 
            cbTurno.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTurno.Font = new Font("Montserrat", 11F);
            cbTurno.FormattingEnabled = true;
            cbTurno.Items.AddRange(new object[] { "MATUTINO", "MIXTO", "NOCTURNO", "VESPERTINO" });
            cbTurno.Location = new Point(78, 79);
            cbTurno.Name = "cbTurno";
            cbTurno.Size = new Size(345, 32);
            cbTurno.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 11F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(453, 82);
            label8.Name = "label8";
            label8.Size = new Size(82, 24);
            label8.TabIndex = 91;
            label8.Text = "Cantidad:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 11F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(15, 133);
            label7.Name = "label7";
            label7.Size = new Size(46, 24);
            label7.TabIndex = 90;
            label7.Text = "Lote:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 11F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(15, 82);
            label6.Name = "label6";
            label6.Size = new Size(57, 24);
            label6.TabIndex = 89;
            label6.Text = "Turno:";
            // 
            // lblFecha
            // 
            lblFecha.BackColor = Color.Transparent;
            lblFecha.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            lblFecha.ForeColor = Color.White;
            lblFecha.Location = new Point(406, 35);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(367, 24);
            lblFecha.TabIndex = 88;
            lblFecha.Text = "ERROR";
            lblFecha.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblOP
            // 
            lblOP.AutoSize = true;
            lblOP.BackColor = Color.Transparent;
            lblOP.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            lblOP.ForeColor = Color.White;
            lblOP.Location = new Point(15, 35);
            lblOP.Name = "lblOP";
            lblOP.Size = new Size(66, 24);
            lblOP.TabIndex = 74;
            lblOP.Text = "ERROR";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 11F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(15, 12);
            label4.Name = "label4";
            label4.Size = new Size(173, 24);
            label4.TabIndex = 73;
            label4.Text = "Orden de Producción:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 11F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(15, 20);
            label2.Name = "label2";
            label2.Size = new Size(57, 24);
            label2.TabIndex = 89;
            label2.Text = "Turno:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 11F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(15, 77);
            label3.Name = "label3";
            label3.Size = new Size(46, 24);
            label3.TabIndex = 90;
            label3.Text = "Lote:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(255, 102, 0);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(486, 62);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(287, 35);
            btnGuardar.TabIndex = 92;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 11F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(398, 27);
            label5.Name = "label5";
            label5.Size = new Size(82, 24);
            label5.TabIndex = 93;
            label5.Text = "Cantidad:";
            // 
            // Produccion_PT
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(814, 306);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(panel4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_PT";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Produccion_PT";
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel4;
        private PictureBox pictureBox4;
        private PictureBox pictureBox6;
        private Label label1;
        private Panel panel1;
        private Label lblFecha;
        private Label lblOP;
        private Label label4;
        private Label label2;
        private ComboBox cbTurno;
        private Label label3;
        private TextBox txbLote;
        private Label label5;
        private Button btnGuardar;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button btnRegistrar;
        private TextBox txbCantidad;
    }
}