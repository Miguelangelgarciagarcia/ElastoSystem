namespace ElastoSystem
{
    partial class ReqSistemas
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            cbTipoReq = new ComboBox();
            label5 = new Label();
            lblfecha = new Label();
            fecha = new System.Windows.Forms.Timer(components);
            label6 = new Label();
            tbDescr = new TextBox();
            label7 = new Label();
            cbNivelPrio = new ComboBox();
            btnEnviarReq = new Button();
            label8 = new Label();
            lblFolio = new Label();
            label9 = new Label();
            panel1 = new Panel();
            dgvPendientesSistemas = new DataGridView();
            lblFolioOriginal = new Label();
            pbImagen = new PictureBox();
            txbNombreArchivo = new TextBox();
            btnCargarArchivo = new Button();
            panel2 = new Panel();
            lblRutaArchivo = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPendientesSistemas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbImagen).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(41, 50);
            label1.Name = "label1";
            label1.Size = new Size(369, 44);
            label1.TabIndex = 0;
            label1.Text = "TICKET DE SISTEMAS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(52, 179);
            label2.Name = "label2";
            label2.Size = new Size(171, 21);
            label2.TabIndex = 1;
            label2.Text = "Categoria del Ticket:";
            // 
            // cbTipoReq
            // 
            cbTipoReq.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoReq.Font = new Font("Montserrat", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cbTipoReq.FormattingEnabled = true;
            cbTipoReq.Items.AddRange(new object[] { "Consulta General", "Fallo en Equipo de Computo", "Mantenimiento Preventivo", "Problemas de Impresoras/Periféricos", "Problema de Seguridad", "Problemas de Red", "Requerimientos de Hardware", "Requerimientos de Software", "Respaldo de Datos", "Sin Acceso al Sistema", "Solicitud de Capacitación", "Solicitud de Cambio o Mejora" });
            cbTipoReq.Location = new Point(240, 176);
            cbTipoReq.Name = "cbTipoReq";
            cbTipoReq.Size = new Size(346, 29);
            cbTipoReq.TabIndex = 2;
            cbTipoReq.SelectedIndexChanged += cbTipoReq_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(995, 87);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 7;
            label5.Text = "Fecha:";
            // 
            // lblfecha
            // 
            lblfecha.AutoSize = true;
            lblfecha.BackColor = Color.Transparent;
            lblfecha.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblfecha.ForeColor = Color.White;
            lblfecha.Location = new Point(1051, 87);
            lblfecha.Name = "lblfecha";
            lblfecha.Size = new Size(100, 20);
            lblfecha.TabIndex = 8;
            lblfecha.Text = "Fecha Larga";
            // 
            // fecha
            // 
            fecha.Tick += fecha_Tick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(52, 228);
            label6.Name = "label6";
            label6.Size = new Size(107, 21);
            label6.TabIndex = 9;
            label6.Text = "Descripción:";
            // 
            // tbDescr
            // 
            tbDescr.Font = new Font("Montserrat", 11F, FontStyle.Regular, GraphicsUnit.Point);
            tbDescr.Location = new Point(52, 257);
            tbDescr.Multiline = true;
            tbDescr.Name = "tbDescr";
            tbDescr.Size = new Size(650, 180);
            tbDescr.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(51, 134);
            label7.Name = "label7";
            label7.Size = new Size(153, 21);
            label7.TabIndex = 11;
            label7.Text = "Nivel de Prioridad:";
            // 
            // cbNivelPrio
            // 
            cbNivelPrio.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNivelPrio.Font = new Font("Montserrat", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cbNivelPrio.FormattingEnabled = true;
            cbNivelPrio.Items.AddRange(new object[] { "Alta", "Media", "Baja" });
            cbNivelPrio.Location = new Point(240, 134);
            cbNivelPrio.Name = "cbNivelPrio";
            cbNivelPrio.Size = new Size(345, 29);
            cbNivelPrio.TabIndex = 12;
            cbNivelPrio.SelectedIndexChanged += cbNivelPrio_SelectedIndexChanged;
            // 
            // btnEnviarReq
            // 
            btnEnviarReq.BackColor = Color.FromArgb(255, 102, 0);
            btnEnviarReq.Cursor = Cursors.Hand;
            btnEnviarReq.FlatAppearance.BorderSize = 0;
            btnEnviarReq.FlatStyle = FlatStyle.Flat;
            btnEnviarReq.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnEnviarReq.ForeColor = Color.White;
            btnEnviarReq.Location = new Point(535, 451);
            btnEnviarReq.Name = "btnEnviarReq";
            btnEnviarReq.Size = new Size(334, 35);
            btnEnviarReq.TabIndex = 13;
            btnEnviarReq.Text = "ENVIAR TICKET";
            btnEnviarReq.UseVisualStyleBackColor = false;
            btnEnviarReq.Click += button1_Click;
            btnEnviarReq.KeyDown += btnEnviarReq_KeyDown;
            btnEnviarReq.KeyPress += btnEnviarReq_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(1035, 56);
            label8.Name = "label8";
            label8.Size = new Size(75, 30);
            label8.TabIndex = 14;
            label8.Text = "Folio:";
            // 
            // lblFolio
            // 
            lblFolio.AutoSize = true;
            lblFolio.BackColor = Color.Transparent;
            lblFolio.Font = new Font("Montserrat", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblFolio.ForeColor = Color.White;
            lblFolio.Location = new Point(1107, 57);
            lblFolio.Name = "lblFolio";
            lblFolio.Size = new Size(101, 30);
            lblFolio.TabIndex = 15;
            lblFolio.Text = "240000";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Montserrat", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(40, 17);
            label9.Name = "label9";
            label9.Size = new Size(440, 30);
            label9.TabIndex = 17;
            label9.Text = "HISTORIAL DE TICKETS DE SISTEMAS";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(3, 42, 76);
            panel1.Controls.Add(dgvPendientesSistemas);
            panel1.Controls.Add(label9);
            panel1.Location = new Point(52, 512);
            panel1.Name = "panel1";
            panel1.Size = new Size(1224, 300);
            panel1.TabIndex = 18;
            // 
            // dgvPendientesSistemas
            // 
            dgvPendientesSistemas.AllowUserToAddRows = false;
            dgvPendientesSistemas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPendientesSistemas.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPendientesSistemas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPendientesSistemas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPendientesSistemas.Location = new Point(40, 57);
            dgvPendientesSistemas.Name = "dgvPendientesSistemas";
            dgvPendientesSistemas.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dgvPendientesSistemas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvPendientesSistemas.RowTemplate.Height = 25;
            dgvPendientesSistemas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPendientesSistemas.Size = new Size(1148, 222);
            dgvPendientesSistemas.TabIndex = 18;
            // 
            // lblFolioOriginal
            // 
            lblFolioOriginal.AutoSize = true;
            lblFolioOriginal.BackColor = Color.Transparent;
            lblFolioOriginal.Font = new Font("Montserrat", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblFolioOriginal.ForeColor = Color.White;
            lblFolioOriginal.Location = new Point(1107, 27);
            lblFolioOriginal.Name = "lblFolioOriginal";
            lblFolioOriginal.Size = new Size(101, 30);
            lblFolioOriginal.TabIndex = 19;
            lblFolioOriginal.Text = "240000";
            lblFolioOriginal.Visible = false;
            // 
            // pbImagen
            // 
            pbImagen.BackColor = Color.White;
            pbImagen.Location = new Point(49, 24);
            pbImagen.Name = "pbImagen";
            pbImagen.Size = new Size(220, 190);
            pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            pbImagen.TabIndex = 40;
            pbImagen.TabStop = false;
            // 
            // txbNombreArchivo
            // 
            txbNombreArchivo.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txbNombreArchivo.Location = new Point(31, 220);
            txbNombreArchivo.Name = "txbNombreArchivo";
            txbNombreArchivo.ReadOnly = true;
            txbNombreArchivo.Size = new Size(261, 24);
            txbNombreArchivo.TabIndex = 39;
            txbNombreArchivo.TextAlign = HorizontalAlignment.Center;
            // 
            // btnCargarArchivo
            // 
            btnCargarArchivo.BackColor = Color.FromArgb(255, 102, 0);
            btnCargarArchivo.Cursor = Cursors.Hand;
            btnCargarArchivo.FlatAppearance.BorderSize = 0;
            btnCargarArchivo.FlatStyle = FlatStyle.Flat;
            btnCargarArchivo.Font = new Font("Montserrat", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCargarArchivo.ForeColor = Color.White;
            btnCargarArchivo.Location = new Point(62, 250);
            btnCargarArchivo.Name = "btnCargarArchivo";
            btnCargarArchivo.Size = new Size(193, 32);
            btnCargarArchivo.TabIndex = 38;
            btnCargarArchivo.Text = "Adjuntar Archivo o Imagen";
            btnCargarArchivo.UseVisualStyleBackColor = false;
            btnCargarArchivo.Click += btnCargarArchivo_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(3, 42, 76);
            panel2.Controls.Add(lblRutaArchivo);
            panel2.Controls.Add(pbImagen);
            panel2.Controls.Add(btnCargarArchivo);
            panel2.Controls.Add(txbNombreArchivo);
            panel2.Location = new Point(887, 134);
            panel2.Name = "panel2";
            panel2.Size = new Size(321, 303);
            panel2.TabIndex = 19;
            // 
            // lblRutaArchivo
            // 
            lblRutaArchivo.AutoSize = true;
            lblRutaArchivo.BackColor = Color.Transparent;
            lblRutaArchivo.Font = new Font("Montserrat", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblRutaArchivo.ForeColor = Color.White;
            lblRutaArchivo.Location = new Point(32, 223);
            lblRutaArchivo.Name = "lblRutaArchivo";
            lblRutaArchivo.Size = new Size(0, 20);
            lblRutaArchivo.TabIndex = 20;
            lblRutaArchivo.Visible = false;
            // 
            // ReqSistemas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(panel2);
            Controls.Add(lblFolioOriginal);
            Controls.Add(panel1);
            Controls.Add(lblFolio);
            Controls.Add(btnEnviarReq);
            Controls.Add(label8);
            Controls.Add(cbNivelPrio);
            Controls.Add(label7);
            Controls.Add(tbDescr);
            Controls.Add(label6);
            Controls.Add(lblfecha);
            Controls.Add(label5);
            Controls.Add(cbTipoReq);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReqSistemas";
            Text = "ReqSistemas";
            Load += ReqSistemas_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPendientesSistemas).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbImagen).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbTipoReq;
        private Label label5;
        private Label lblfecha;
        private System.Windows.Forms.Timer fecha;
        private Label label6;
        private TextBox tbDescr;
        private Label label7;
        private ComboBox cbNivelPrio;
        private Button btnEnviarReq;
        private Label label8;
        private Label lblFolio;
        private Label label9;
        private Panel panel1;
        private DataGridView dgvPendientesSistemas;
        private Label lblFolioOriginal;
        private PictureBox pbImagen;
        private TextBox txbNombreArchivo;
        private Button btnCargarArchivo;
        private Panel panel2;
        private Label lblRutaArchivo;
    }
}