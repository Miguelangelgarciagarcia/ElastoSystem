namespace ElastoSystem
{
    partial class Produccion_CrearOToRelacionar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Produccion_CrearOToRelacionar));
            panel4 = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox6 = new PictureBox();
            btnRelacionar = new Button();
            btnCrearOT = new Button();
            label13 = new Label();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
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
            panel4.Size = new Size(547, 30);
            panel4.TabIndex = 87;
            panel4.MouseDown += panel4_MouseDown;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(508, 4);
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
            pictureBox6.Location = new Point(508, 4);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(23, 23);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 18;
            pictureBox6.TabStop = false;
            pictureBox6.Click += pictureBox6_Click;
            pictureBox6.MouseLeave += pictureBox6_MouseLeave;
            // 
            // btnRelacionar
            // 
            btnRelacionar.BackColor = Color.FromArgb(255, 102, 0);
            btnRelacionar.Cursor = Cursors.Hand;
            btnRelacionar.FlatAppearance.BorderSize = 0;
            btnRelacionar.FlatStyle = FlatStyle.Flat;
            btnRelacionar.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnRelacionar.ForeColor = Color.White;
            btnRelacionar.Location = new Point(27, 97);
            btnRelacionar.Name = "btnRelacionar";
            btnRelacionar.Size = new Size(214, 37);
            btnRelacionar.TabIndex = 94;
            btnRelacionar.Text = "Relacionar Orden";
            btnRelacionar.UseVisualStyleBackColor = false;
            btnRelacionar.Click += btnRelacionar_Click;
            // 
            // btnCrearOT
            // 
            btnCrearOT.BackColor = Color.FromArgb(255, 102, 0);
            btnCrearOT.Cursor = Cursors.Hand;
            btnCrearOT.FlatAppearance.BorderSize = 0;
            btnCrearOT.FlatStyle = FlatStyle.Flat;
            btnCrearOT.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnCrearOT.ForeColor = Color.White;
            btnCrearOT.Location = new Point(278, 97);
            btnCrearOT.Name = "btnCrearOT";
            btnCrearOT.Size = new Size(239, 37);
            btnCrearOT.TabIndex = 95;
            btnCrearOT.Text = "Crear Orden de Trabajo";
            btnCrearOT.UseVisualStyleBackColor = false;
            btnCrearOT.Click += btnCrearOT_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            label13.ForeColor = Color.White;
            label13.Location = new Point(92, 51);
            label13.Name = "label13";
            label13.Size = new Size(337, 22);
            label13.TabIndex = 96;
            label13.Text = "¿Que deseas realizar con la Operacion?";
            // 
            // Produccion_CrearOToRelacionar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(547, 170);
            Controls.Add(label13);
            Controls.Add(btnCrearOT);
            Controls.Add(btnRelacionar);
            Controls.Add(panel4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Produccion_CrearOToRelacionar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Produccion_CrearOToRelacionar";
            Load += Produccion_CrearOToRelacionar_Load;
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel4;
        private PictureBox pictureBox4;
        private PictureBox pictureBox6;
        private Button btnRelacionar;
        private Button btnCrearOT;
        private Label label13;
    }
}