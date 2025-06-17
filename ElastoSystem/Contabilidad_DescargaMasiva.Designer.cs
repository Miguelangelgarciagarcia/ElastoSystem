namespace ElastoSystem
{
    partial class Contabilidad_DescargaMasiva
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
            panel1 = new Panel();
            lblClavePrivada = new Label();
            lblCertificado = new Label();
            btnValidarFiel = new Button();
            btnCargarCertificado = new Button();
            btnCargarKey = new Button();
            txbContrCertificado = new TextBox();
            txbRFC = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label21 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(lblClavePrivada);
            panel1.Controls.Add(lblCertificado);
            panel1.Controls.Add(btnValidarFiel);
            panel1.Controls.Add(btnCargarCertificado);
            panel1.Controls.Add(btnCargarKey);
            panel1.Controls.Add(txbContrCertificado);
            panel1.Controls.Add(txbRFC);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label21);
            panel1.Location = new Point(21, 76);
            panel1.Name = "panel1";
            panel1.Size = new Size(735, 253);
            panel1.TabIndex = 23;
            // 
            // lblClavePrivada
            // 
            lblClavePrivada.AutoSize = true;
            lblClavePrivada.BackColor = Color.Transparent;
            lblClavePrivada.Font = new Font("Montserrat", 12F);
            lblClavePrivada.ForeColor = Color.White;
            lblClavePrivada.Location = new Point(508, 131);
            lblClavePrivada.Name = "lblClavePrivada";
            lblClavePrivada.Size = new Size(164, 22);
            lblClavePrivada.TabIndex = 83;
            lblClavePrivada.Text = "No se eligió archivo";
            // 
            // lblCertificado
            // 
            lblCertificado.AutoSize = true;
            lblCertificado.BackColor = Color.Transparent;
            lblCertificado.Font = new Font("Montserrat", 12F);
            lblCertificado.ForeColor = Color.White;
            lblCertificado.Location = new Point(508, 59);
            lblCertificado.Name = "lblCertificado";
            lblCertificado.Size = new Size(164, 22);
            lblCertificado.TabIndex = 82;
            lblCertificado.Text = "No se eligió archivo";
            // 
            // btnValidarFiel
            // 
            btnValidarFiel.BackColor = Color.FromArgb(255, 102, 0);
            btnValidarFiel.Cursor = Cursors.Hand;
            btnValidarFiel.FlatAppearance.BorderSize = 0;
            btnValidarFiel.FlatStyle = FlatStyle.Flat;
            btnValidarFiel.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnValidarFiel.ForeColor = Color.White;
            btnValidarFiel.Location = new Point(147, 187);
            btnValidarFiel.Name = "btnValidarFiel";
            btnValidarFiel.Size = new Size(457, 34);
            btnValidarFiel.TabIndex = 81;
            btnValidarFiel.Text = "Validar FIEL";
            btnValidarFiel.UseVisualStyleBackColor = false;
            btnValidarFiel.Click += btnValidarFiel_Click;
            // 
            // btnCargarCertificado
            // 
            btnCargarCertificado.BackColor = Color.FromArgb(255, 102, 0);
            btnCargarCertificado.Cursor = Cursors.Hand;
            btnCargarCertificado.FlatAppearance.BorderSize = 0;
            btnCargarCertificado.FlatStyle = FlatStyle.Flat;
            btnCargarCertificado.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnCargarCertificado.ForeColor = Color.White;
            btnCargarCertificado.Location = new Point(249, 53);
            btnCargarCertificado.Name = "btnCargarCertificado";
            btnCargarCertificado.Size = new Size(253, 34);
            btnCargarCertificado.TabIndex = 80;
            btnCargarCertificado.Text = "Seleccionar archivo";
            btnCargarCertificado.UseVisualStyleBackColor = false;
            btnCargarCertificado.Click += btnCargarCertificado_Click;
            // 
            // btnCargarKey
            // 
            btnCargarKey.BackColor = Color.FromArgb(255, 102, 0);
            btnCargarKey.Cursor = Cursors.Hand;
            btnCargarKey.FlatAppearance.BorderSize = 0;
            btnCargarKey.FlatStyle = FlatStyle.Flat;
            btnCargarKey.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            btnCargarKey.ForeColor = Color.White;
            btnCargarKey.Location = new Point(249, 125);
            btnCargarKey.Name = "btnCargarKey";
            btnCargarKey.Size = new Size(253, 34);
            btnCargarKey.TabIndex = 79;
            btnCargarKey.Text = "Seleccionar archivo";
            btnCargarKey.UseVisualStyleBackColor = false;
            btnCargarKey.Click += btnCargarKey_Click;
            // 
            // txbContrCertificado
            // 
            txbContrCertificado.Font = new Font("Montserrat", 12F);
            txbContrCertificado.Location = new Point(249, 92);
            txbContrCertificado.Name = "txbContrCertificado";
            txbContrCertificado.Size = new Size(253, 27);
            txbContrCertificado.TabIndex = 75;
            // 
            // txbRFC
            // 
            txbRFC.Font = new Font("Montserrat", 12F);
            txbRFC.Location = new Point(249, 22);
            txbRFC.Name = "txbRFC";
            txbRFC.Size = new Size(253, 27);
            txbRFC.TabIndex = 74;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 12F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(19, 131);
            label5.Name = "label5";
            label5.Size = new Size(166, 22);
            label5.TabIndex = 68;
            label5.Text = "Clave Privada (.key):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(19, 95);
            label4.Name = "label4";
            label4.Size = new Size(224, 22);
            label4.TabIndex = 67;
            label4.Text = "Contraseña del Certificado:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(19, 59);
            label3.Name = "label3";
            label3.Size = new Size(142, 22);
            label3.TabIndex = 66;
            label3.Text = "Certificado (.cer):";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.Transparent;
            label21.Font = new Font("Montserrat", 12F);
            label21.ForeColor = Color.White;
            label21.Location = new Point(19, 25);
            label21.Name = "label21";
            label21.Size = new Size(47, 22);
            label21.TabIndex = 65;
            label21.Text = "RFC:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(28, 21);
            label1.Name = "label1";
            label1.Size = new Size(351, 44);
            label1.TabIndex = 24;
            label1.Text = "DESCARGA MASIVA";
            // 
            // Contabilidad_DescargaMasiva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Contabilidad_DescargaMasiva";
            Text = "Contabilidad_DescargaMasiva";
            Load += Contabilidad_DescargaMasiva_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label21;
        private TextBox txbContrCertificado;
        private TextBox txbRFC;
        private Button btnValidarFiel;
        private Button btnCargarCertificado;
        private Button btnCargarKey;
        private Label lblClavePrivada;
        private Label lblCertificado;
        private Label label1;
    }
}