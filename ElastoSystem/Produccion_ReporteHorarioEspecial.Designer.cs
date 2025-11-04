namespace ElastoSystem
{
    partial class Produccion_ReporteHorarioEspecial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produccion_ReporteHorarioEspecial));
            panel3 = new Panel();
            pictureBox4 = new PictureBox();
            pbCerrar = new PictureBox();
            btnAceptar = new Button();
            txbHoraInicio = new TextBox();
            label7 = new Label();
            label2 = new Label();
            txbHoraFinal = new TextBox();
            label1 = new Label();
            txbObservaciones = new TextBox();
            label3 = new Label();
            label4 = new Label();
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
            panel3.Size = new Size(527, 30);
            panel3.TabIndex = 58;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(489, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(23, 23);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 20;
            pictureBox4.TabStop = false;
            // 
            // pbCerrar
            // 
            pbCerrar.BackColor = Color.Transparent;
            pbCerrar.Cursor = Cursors.Hand;
            pbCerrar.Image = (Image)resources.GetObject("pbCerrar.Image");
            pbCerrar.Location = new Point(489, 4);
            pbCerrar.Name = "pbCerrar";
            pbCerrar.Size = new Size(23, 23);
            pbCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            pbCerrar.TabIndex = 60;
            pbCerrar.TabStop = false;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.FromArgb(255, 102, 0);
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(161, 332);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(202, 35);
            btnAceptar.TabIndex = 61;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txbHoraInicio
            // 
            txbHoraInicio.Font = new Font("Montserrat", 11F);
            txbHoraInicio.Location = new Point(173, 114);
            txbHoraInicio.Name = "txbHoraInicio";
            txbHoraInicio.Size = new Size(267, 25);
            txbHoraInicio.TabIndex = 126;
            txbHoraInicio.TextAlign = HorizontalAlignment.Center;
            txbHoraInicio.KeyPress += txbHoraInicio_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 11F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(52, 117);
            label7.Name = "label7";
            label7.Size = new Size(115, 24);
            label7.TabIndex = 125;
            label7.Text = "Hora de Inicio:";
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 22F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 47);
            label2.Name = "label2";
            label2.Size = new Size(527, 41);
            label2.TabIndex = 127;
            label2.Text = "Horario Especial";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // txbHoraFinal
            // 
            txbHoraFinal.Font = new Font("Montserrat", 11F);
            txbHoraFinal.Location = new Point(173, 155);
            txbHoraFinal.Name = "txbHoraFinal";
            txbHoraFinal.Size = new Size(267, 25);
            txbHoraFinal.TabIndex = 129;
            txbHoraFinal.TextAlign = HorizontalAlignment.Center;
            txbHoraFinal.KeyPress += txbHoraFinal_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 11F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(52, 158);
            label1.Name = "label1";
            label1.Size = new Size(88, 24);
            label1.TabIndex = 128;
            label1.Text = "Hora Final:";
            // 
            // txbObservaciones
            // 
            txbObservaciones.Font = new Font("Montserrat", 11F);
            txbObservaciones.Location = new Point(73, 248);
            txbObservaciones.Multiline = true;
            txbObservaciones.Name = "txbObservaciones";
            txbObservaciones.Size = new Size(367, 70);
            txbObservaciones.TabIndex = 131;
            txbObservaciones.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 11F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 221);
            label3.Name = "label3";
            label3.Size = new Size(527, 24);
            label3.TabIndex = 130;
            label3.Text = "Observaciones:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 7F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(257, 183);
            label4.Name = "label4";
            label4.Size = new Size(183, 18);
            label4.TabIndex = 132;
            label4.Text = "EL FORMATO DE HORA ES 24HRS.";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Produccion_ReporteHorarioEspecial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(527, 388);
            Controls.Add(label4);
            Controls.Add(txbObservaciones);
            Controls.Add(label3);
            Controls.Add(txbHoraFinal);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txbHoraInicio);
            Controls.Add(label7);
            Controls.Add(btnAceptar);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_ReporteHorarioEspecial";
            Text = "Produccion_ReporteHorarioEspecial";
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
        private TextBox txbHoraInicio;
        private Label label7;
        private Label label2;
        private TextBox txbHoraFinal;
        private Label label1;
        private TextBox txbObservaciones;
        private Label label3;
        private Label label4;
    }
}