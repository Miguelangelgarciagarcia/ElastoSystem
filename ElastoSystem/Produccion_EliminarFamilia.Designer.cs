namespace ElastoSystem
{
    partial class Produccion_EliminarFamilia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produccion_EliminarFamilia));
            panel3 = new Panel();
            pictureBox4 = new PictureBox();
            pbCerrar = new PictureBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnAceptar = new Button();
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
            panel3.Size = new Size(799, 30);
            panel3.TabIndex = 59;
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
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 12F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(34, 238);
            label8.Name = "label8";
            label8.Size = new Size(623, 22);
            label8.TabIndex = 79;
            label8.Text = "¿Desea en su lugar marcar la familia como inactiva para ocultarla del sistema?";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 12F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(55, 207);
            label7.Name = "label7";
            label7.Size = new Size(338, 22);
            label7.TabIndex = 78;
            label7.Text = "Eliminación de ayudas visuales asociadas";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 12F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(55, 185);
            label6.Name = "label6";
            label6.Size = new Size(548, 22);
            label6.TabIndex = 77;
            label6.Text = "Eliminación de procesos de hoja de ruta (por familia y por producto)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 12F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(55, 163);
            label5.Name = "label5";
            label5.Size = new Size(386, 22);
            label5.TabIndex = 76;
            label5.Text = "Desvinculación de productos asociados en SAE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(55, 141);
            label3.Name = "label3";
            label3.Size = new Size(325, 22);
            label3.TabIndex = 75;
            label3.Text = "Eliminación del registro de encabezado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(31, 108);
            label4.Name = "label4";
            label4.Size = new Size(340, 22);
            label4.TabIndex = 74;
            label4.Text = "por soporte técnico. Este proceso implica:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(31, 88);
            label2.Name = "label2";
            label2.Size = new Size(705, 22);
            label2.TabIndex = 73;
            label2.Text = "La eliminación de una familia es un procedimiento crítico que solo puede ser ejecutado";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 20F, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(34, 46);
            label1.Name = "label1";
            label1.Size = new Size(284, 37);
            label1.TabIndex = 72;
            label1.Text = "ELIMINAR FAMILIA";
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.FromArgb(255, 102, 0);
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(275, 282);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(282, 35);
            btnAceptar.TabIndex = 71;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // Produccion_EliminarFamilia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(799, 345);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAceptar);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_EliminarFamilia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Produccion_EliminarFamilia";
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
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
        private Button btnAceptar;
    }
}