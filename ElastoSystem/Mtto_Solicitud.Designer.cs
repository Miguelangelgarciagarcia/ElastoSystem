namespace ElastoSystem
{
    partial class Mtto_Solicitud
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            panel2 = new Panel();
            pbImagen = new PictureBox();
            cbMaquinas = new ComboBox();
            cbUbicacion = new ComboBox();
            cbTipoReq = new ComboBox();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label8 = new Label();
            lblFolio = new Label();
            label2 = new Label();
            lblfecha = new Label();
            label5 = new Label();
            fecha = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            txbRefacciones = new TextBox();
            txbDescripcion = new TextBox();
            label15 = new Label();
            txbRecSug = new TextBox();
            label7 = new Label();
            cbTipoFalla = new ComboBox();
            label16 = new Label();
            cbPrioridad = new ComboBox();
            label17 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            btnEnviarReq = new Button();
            lblFolioOriginal = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbImagen).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(38, 33);
            label1.Name = "label1";
            label1.Size = new Size(558, 44);
            label1.TabIndex = 2;
            label1.Text = "SOLICITUD DE MANTENIMIENTO";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(3, 42, 76);
            panel2.Controls.Add(pbImagen);
            panel2.Controls.Add(cbMaquinas);
            panel2.Controls.Add(cbUbicacion);
            panel2.Controls.Add(cbTipoReq);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label8);
            panel2.Location = new Point(22, 141);
            panel2.Name = "panel2";
            panel2.Size = new Size(494, 440);
            panel2.TabIndex = 20;
            // 
            // pbImagen
            // 
            pbImagen.BackColor = Color.White;
            pbImagen.Location = new Point(85, 195);
            pbImagen.Name = "pbImagen";
            pbImagen.Size = new Size(300, 225);
            pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            pbImagen.TabIndex = 5;
            pbImagen.TabStop = false;
            // 
            // cbMaquinas
            // 
            cbMaquinas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMaquinas.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbMaquinas.FormattingEnabled = true;
            cbMaquinas.Location = new Point(191, 137);
            cbMaquinas.Name = "cbMaquinas";
            cbMaquinas.Size = new Size(282, 26);
            cbMaquinas.TabIndex = 27;
            cbMaquinas.SelectedIndexChanged += cbMaquinas_SelectedIndexChanged;
            // 
            // cbUbicacion
            // 
            cbUbicacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUbicacion.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbUbicacion.FormattingEnabled = true;
            cbUbicacion.Items.AddRange(new object[] { "NAVE 1", "NAVE 2", "OFICINAS" });
            cbUbicacion.Location = new Point(191, 99);
            cbUbicacion.Name = "cbUbicacion";
            cbUbicacion.Size = new Size(282, 26);
            cbUbicacion.TabIndex = 26;
            cbUbicacion.SelectedIndexChanged += cbUbicacion_SelectedIndexChanged;
            // 
            // cbTipoReq
            // 
            cbTipoReq.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoReq.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbTipoReq.FormattingEnabled = true;
            cbTipoReq.Items.AddRange(new object[] { "EQUIPO", "INSTALACIONES", "MAQUINARIA" });
            cbTipoReq.Location = new Point(191, 61);
            cbTipoReq.Name = "cbTipoReq";
            cbTipoReq.Size = new Size(282, 26);
            cbTipoReq.TabIndex = 25;
            cbTipoReq.SelectedIndexChanged += cbTipoReq_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(21, 136);
            label6.Name = "label6";
            label6.Size = new Size(87, 22);
            label6.TabIndex = 24;
            label6.Text = "Maquina:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(21, 98);
            label4.Name = "label4";
            label4.Size = new Size(97, 22);
            label4.TabIndex = 23;
            label4.Text = "Ubicación:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(21, 60);
            label3.Name = "label3";
            label3.Size = new Size(143, 22);
            label3.TabIndex = 22;
            label3.Text = "Mantenimiento:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(21, 16);
            label8.Name = "label8";
            label8.Size = new Size(212, 26);
            label8.TabIndex = 21;
            label8.Text = "DATOS DEL EQUIPO";
            // 
            // lblFolio
            // 
            lblFolio.AutoSize = true;
            lblFolio.BackColor = Color.Transparent;
            lblFolio.Font = new Font("Montserrat", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblFolio.ForeColor = Color.White;
            lblFolio.Location = new Point(1095, 57);
            lblFolio.Name = "lblFolio";
            lblFolio.Size = new Size(101, 30);
            lblFolio.TabIndex = 22;
            lblFolio.Text = "240000";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(1023, 56);
            label2.Name = "label2";
            label2.Size = new Size(75, 30);
            label2.TabIndex = 21;
            label2.Text = "Folio:";
            // 
            // lblfecha
            // 
            lblfecha.AutoSize = true;
            lblfecha.BackColor = Color.Transparent;
            lblfecha.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblfecha.ForeColor = Color.White;
            lblfecha.Location = new Point(1039, 87);
            lblfecha.Name = "lblfecha";
            lblfecha.Size = new Size(100, 20);
            lblfecha.TabIndex = 24;
            lblfecha.Text = "Fecha Larga";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(983, 87);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 23;
            label5.Text = "Fecha:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(txbRefacciones);
            panel1.Controls.Add(txbDescripcion);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(txbRecSug);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(cbTipoFalla);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(cbPrioridad);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label11);
            panel1.Location = new Point(546, 141);
            panel1.Name = "panel1";
            panel1.Size = new Size(748, 529);
            panel1.TabIndex = 25;
            // 
            // txbRefacciones
            // 
            txbRefacciones.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbRefacciones.Location = new Point(21, 450);
            txbRefacciones.Multiline = true;
            txbRefacciones.Name = "txbRefacciones";
            txbRefacciones.Size = new Size(708, 54);
            txbRefacciones.TabIndex = 30;
            // 
            // txbDescripcion
            // 
            txbDescripcion.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbDescripcion.Location = new Point(21, 170);
            txbDescripcion.Multiline = true;
            txbDescripcion.Name = "txbDescripcion";
            txbDescripcion.Size = new Size(708, 109);
            txbDescripcion.TabIndex = 28;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.White;
            label15.Location = new Point(21, 425);
            label15.Name = "label15";
            label15.Size = new Size(195, 22);
            label15.TabIndex = 23;
            label15.Text = "Refacciones a Utilizar:";
            // 
            // txbRecSug
            // 
            txbRecSug.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbRecSug.Location = new Point(21, 363);
            txbRecSug.Multiline = true;
            txbRecSug.Name = "txbRecSug";
            txbRecSug.Size = new Size(708, 45);
            txbRecSug.TabIndex = 29;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(21, 136);
            label7.Name = "label7";
            label7.Size = new Size(112, 22);
            label7.TabIndex = 27;
            label7.Text = "Descripción:";
            // 
            // cbTipoFalla
            // 
            cbTipoFalla.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoFalla.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbTipoFalla.FormattingEnabled = true;
            cbTipoFalla.Items.AddRange(new object[] { "ELECTRICA", "HIDRAULICA", "MECANICA", "NEUMATICA", "OTRA" });
            cbTipoFalla.Location = new Point(191, 99);
            cbTipoFalla.Name = "cbTipoFalla";
            cbTipoFalla.Size = new Size(282, 26);
            cbTipoFalla.TabIndex = 26;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label16.ForeColor = Color.White;
            label16.Location = new Point(21, 338);
            label16.Name = "label16";
            label16.Size = new Size(285, 22);
            label16.TabIndex = 22;
            label16.Text = "Recomendaciones / Sugerencias:";
            // 
            // cbPrioridad
            // 
            cbPrioridad.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPrioridad.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbPrioridad.FormattingEnabled = true;
            cbPrioridad.Items.AddRange(new object[] { "CRITICA", "ALTA", "MEDIA", "BAJA" });
            cbPrioridad.Location = new Point(191, 61);
            cbPrioridad.Name = "cbPrioridad";
            cbPrioridad.Size = new Size(282, 26);
            cbPrioridad.TabIndex = 25;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Transparent;
            label17.Font = new Font("Montserrat", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.White;
            label17.Location = new Point(21, 306);
            label17.Name = "label17";
            label17.Size = new Size(239, 26);
            label17.TabIndex = 21;
            label17.Text = "APOYO Y ACCESORIOS";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(21, 98);
            label9.Name = "label9";
            label9.Size = new Size(121, 22);
            label9.TabIndex = 23;
            label9.Text = "Tipo de Falla:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(21, 60);
            label10.Name = "label10";
            label10.Size = new Size(92, 22);
            label10.TabIndex = 22;
            label10.Text = "Prioridad:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Montserrat", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.White;
            label11.Location = new Point(21, 16);
            label11.Name = "label11";
            label11.Size = new Size(247, 26);
            label11.TabIndex = 21;
            label11.Text = "DETALLES DE LA FALLA";
            // 
            // btnEnviarReq
            // 
            btnEnviarReq.BackColor = Color.FromArgb(255, 102, 0);
            btnEnviarReq.Cursor = Cursors.Hand;
            btnEnviarReq.FlatAppearance.BorderSize = 0;
            btnEnviarReq.FlatStyle = FlatStyle.Flat;
            btnEnviarReq.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnEnviarReq.ForeColor = Color.White;
            btnEnviarReq.Location = new Point(724, 719);
            btnEnviarReq.Name = "btnEnviarReq";
            btnEnviarReq.Size = new Size(397, 38);
            btnEnviarReq.TabIndex = 13;
            btnEnviarReq.Text = "Enviar Requerimiento";
            btnEnviarReq.UseVisualStyleBackColor = false;
            btnEnviarReq.Click += btnEnviarReq_Click;
            // 
            // lblFolioOriginal
            // 
            lblFolioOriginal.AutoSize = true;
            lblFolioOriginal.BackColor = Color.Transparent;
            lblFolioOriginal.Font = new Font("Montserrat", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblFolioOriginal.ForeColor = Color.White;
            lblFolioOriginal.Location = new Point(1095, 26);
            lblFolioOriginal.Name = "lblFolioOriginal";
            lblFolioOriginal.Size = new Size(101, 30);
            lblFolioOriginal.TabIndex = 26;
            lblFolioOriginal.Text = "240000";
            lblFolioOriginal.Visible = false;
            // 
            // Mtto_Solicitud
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(lblFolioOriginal);
            Controls.Add(btnEnviarReq);
            Controls.Add(panel1);
            Controls.Add(lblfecha);
            Controls.Add(label5);
            Controls.Add(lblFolio);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Mtto_Solicitud";
            Text = "Mtto_Solicitud";
            Load += Mtto_Solicitud_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbImagen).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel2;
        private Label label8;
        private Label lblFolio;
        private Label label2;
        private Label lblfecha;
        private Label label5;
        private System.Windows.Forms.Timer fecha;
        private Label label6;
        private Label label4;
        private Label label3;
        private ComboBox cbMaquinas;
        private ComboBox cbUbicacion;
        private ComboBox cbTipoReq;
        private Panel panel1;
        private ComboBox cbTipoFalla;
        private ComboBox cbPrioridad;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txbDescripcion;
        private Label label7;
        private PictureBox pbImagen;
        private Button btnEnviarReq;
        private TextBox txbRecSug;
        private Label label15;
        private Label label16;
        private Label label17;
        private TextBox txbRefacciones;
        private Label lblFolioOriginal;
    }
}