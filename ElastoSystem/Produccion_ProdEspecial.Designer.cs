namespace ElastoSystem
{
    partial class Produccion_ProdEspecial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produccion_ProdEspecial));
            txbCliente = new TextBox();
            label14 = new Label();
            btnAceptar = new Button();
            txbOC = new TextBox();
            label1 = new Label();
            txbEspecificacion = new TextBox();
            label2 = new Label();
            panel3 = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox6 = new PictureBox();
            label8 = new Label();
            label3 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // txbCliente
            // 
            txbCliente.Font = new Font("Montserrat", 12F);
            txbCliente.Location = new Point(189, 117);
            txbCliente.Name = "txbCliente";
            txbCliente.Size = new Size(332, 27);
            txbCliente.TabIndex = 76;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Montserrat", 12F);
            label14.ForeColor = Color.White;
            label14.Location = new Point(26, 120);
            label14.Name = "label14";
            label14.Size = new Size(70, 22);
            label14.TabIndex = 75;
            label14.Text = "Cliente:";
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.FromArgb(255, 102, 0);
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(166, 274);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(250, 30);
            btnAceptar.TabIndex = 81;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txbOC
            // 
            txbOC.Font = new Font("Montserrat", 12F);
            txbOC.Location = new Point(189, 166);
            txbOC.Name = "txbOC";
            txbOC.Size = new Size(332, 27);
            txbOC.TabIndex = 83;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(26, 169);
            label1.Name = "label1";
            label1.Size = new Size(157, 22);
            label1.TabIndex = 82;
            label1.Text = "Orden de Compra:";
            // 
            // txbEspecificacion
            // 
            txbEspecificacion.Font = new Font("Montserrat", 12F);
            txbEspecificacion.Location = new Point(189, 214);
            txbEspecificacion.Name = "txbEspecificacion";
            txbEspecificacion.Size = new Size(332, 27);
            txbEspecificacion.TabIndex = 85;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(26, 217);
            label2.Name = "label2";
            label2.Size = new Size(128, 22);
            label2.TabIndex = 84;
            label2.Text = "Especificacion:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(153, 255, 255, 255);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(pictureBox6);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(560, 30);
            panel3.TabIndex = 86;
            panel3.MouseDown += panel3_MouseDown;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(523, 4);
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
            pictureBox6.Location = new Point(523, 4);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(23, 23);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 18;
            pictureBox6.TabStop = false;
            pictureBox6.Click += pictureBox6_Click;
            pictureBox6.MouseLeave += pictureBox6_MouseLeave;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 16F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(83, 52);
            label8.Name = "label8";
            label8.Size = new Size(381, 30);
            label8.TabIndex = 87;
            label8.Text = "DATOS PRODUCCIÓN ESPECIAL";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 8F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(26, 239);
            label3.Name = "label3";
            label3.Size = new Size(128, 15);
            label3.TabIndex = 88;
            label3.Text = "(Dibujo, Muestra, Otro)";
            // 
            // Produccion_ProdEspecial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(560, 339);
            Controls.Add(label3);
            Controls.Add(label8);
            Controls.Add(panel3);
            Controls.Add(txbEspecificacion);
            Controls.Add(label2);
            Controls.Add(txbOC);
            Controls.Add(label1);
            Controls.Add(btnAceptar);
            Controls.Add(txbCliente);
            Controls.Add(label14);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_ProdEspecial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Produccion_ProdEspecial";
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbCliente;
        private Label label14;
        private Button btnAceptar;
        private TextBox txbOC;
        private Label label1;
        private TextBox txbEspecificacion;
        private Label label2;
        private Panel panel3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox6;
        private Label label8;
        private Label label3;
    }
}