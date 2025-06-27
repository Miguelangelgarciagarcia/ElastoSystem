namespace ElastoSystem
{
    partial class Produccion_ActivarFamilia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produccion_ActivarFamilia));
            panel3 = new Panel();
            pictureBox4 = new PictureBox();
            pbCerrar = new PictureBox();
            btnAceptar = new Button();
            label2 = new Label();
            label1 = new Label();
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
            panel3.Size = new Size(493, 30);
            panel3.TabIndex = 60;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(460, 4);
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
            pbCerrar.Location = new Point(460, 4);
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
            btnAceptar.Location = new Point(111, 117);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(282, 35);
            btnAceptar.TabIndex = 72;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(41, 55);
            label2.Name = "label2";
            label2.Size = new Size(409, 22);
            label2.TabIndex = 74;
            label2.Text = "La familia ya existe solo se encuentra INACTIVA";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(152, 77);
            label1.Name = "label1";
            label1.Size = new Size(181, 22);
            label1.TabIndex = 75;
            label1.Text = "¿Deseas reactivarla?";
            // 
            // Produccion_ActivarFamilia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(493, 175);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(btnAceptar);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_ActivarFamilia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Produccion_ActivarFamilia";
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
        private Label label2;
        private Label label1;
    }
}