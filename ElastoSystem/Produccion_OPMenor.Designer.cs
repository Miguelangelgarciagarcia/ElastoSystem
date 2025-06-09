namespace ElastoSystem
{
    partial class Produccion_OPMenor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produccion_OPMenor));
            panel3 = new Panel();
            pictureBox4 = new PictureBox();
            pbCerrar = new PictureBox();
            btnAceptar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCerrar).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(153, 255, 255, 255);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(pbCerrar);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 30);
            panel3.TabIndex = 58;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(768, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(23, 23);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 20;
            pictureBox4.TabStop = false;
            pictureBox4.MouseMove += pictureBox4_MouseMove;
            // 
            // pbCerrar
            // 
            pbCerrar.BackColor = Color.Transparent;
            pbCerrar.Cursor = Cursors.Hand;
            pbCerrar.Image = (Image)resources.GetObject("pbCerrar.Image");
            pbCerrar.Location = new Point(768, 4);
            pbCerrar.Name = "pbCerrar";
            pbCerrar.Size = new Size(23, 23);
            pbCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            pbCerrar.TabIndex = 60;
            pbCerrar.TabStop = false;
            pbCerrar.Click += pbCerrar_Click;
            pbCerrar.MouseLeave += pbCerrar_MouseLeave;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.FromArgb(255, 102, 0);
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(323, 175);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(151, 35);
            btnAceptar.TabIndex = 61;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 20F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(43, 61);
            label1.Name = "label1";
            label1.Size = new Size(722, 37);
            label1.TabIndex = 62;
            label1.Text = "LA CANTIDAD DE TU ORDEN DE PRODUCCIÓN ES";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 20F, FontStyle.Bold);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(84, 98);
            label2.Name = "label2";
            label2.Size = new Size(661, 37);
            label2.TabIndex = 63;
            label2.Text = "MENOR QUE LA SOLICITUD DE FABRICACIÓN";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 15F, FontStyle.Bold);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(268, 135);
            label3.Name = "label3";
            label3.Size = new Size(255, 27);
            label3.TabIndex = 64;
            label3.Text = "¿DESEAS CONTINUAR?";
            // 
            // Produccion_OPMenor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(800, 242);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAceptar);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_OPMenor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Produccion_OPMenor";
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCerrar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private PictureBox pictureBox4;
        private PictureBox pbCerrar;
        private Button btnAceptar;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}