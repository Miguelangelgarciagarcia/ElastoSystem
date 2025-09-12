namespace ElastoSystem
{
    partial class Mantenimiento_Pendientes
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            label1 = new Label();
            dgvPendientesMtto = new DataGridView();
            panel2 = new Panel();
            txbSolicitante = new TextBox();
            txbFolio = new TextBox();
            label5 = new Label();
            label12 = new Label();
            label2 = new Label();
            btnCargarComprobante = new Button();
            txbRefacciones = new TextBox();
            txbRecomendaciones = new TextBox();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            txbDescripcion = new TextBox();
            label7 = new Label();
            txbTipoFalla = new TextBox();
            txbPrioridad = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txbMaquina = new TextBox();
            txbUbicacion = new TextBox();
            txbMantenimiento = new TextBox();
            pbImagen = new PictureBox();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label8 = new Label();
            pnlComprobante = new Panel();
            lblRutaArchivo = new Label();
            txbNombreArchivo = new TextBox();
            btnCargarDoc = new Button();
            btnCerrar = new Button();
            btnFinalizarReq = new Button();
            pbComprobante = new PictureBox();
            label19 = new Label();
            txbNotas = new TextBox();
            label13 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPendientesMtto).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbImagen).BeginInit();
            pnlComprobante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbComprobante).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(23, 24);
            label1.Name = "label1";
            label1.Size = new Size(592, 44);
            label1.TabIndex = 3;
            label1.Text = "PENDIENTES DE MANTENIMIENTO";
            // 
            // dgvPendientesMtto
            // 
            dgvPendientesMtto.AllowUserToAddRows = false;
            dgvPendientesMtto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPendientesMtto.BackgroundColor = Color.FromArgb(205, 215, 224);
            dgvPendientesMtto.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Montserrat ExtraBold", 12F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvPendientesMtto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvPendientesMtto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.WindowFrame;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvPendientesMtto.DefaultCellStyle = dataGridViewCellStyle6;
            dgvPendientesMtto.GridColor = SystemColors.ActiveCaptionText;
            dgvPendientesMtto.Location = new Point(23, 89);
            dgvPendientesMtto.Name = "dgvPendientesMtto";
            dgvPendientesMtto.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(205, 215, 224);
            dataGridViewCellStyle7.Font = new Font("Montserrat", 8.999999F);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvPendientesMtto.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvPendientesMtto.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Montserrat", 11.25F);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dgvPendientesMtto.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dgvPendientesMtto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPendientesMtto.Size = new Size(673, 708);
            dgvPendientesMtto.TabIndex = 42;
            dgvPendientesMtto.DoubleClick += dgvPendientesMtto_DoubleClick;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(3, 42, 76);
            panel2.Controls.Add(txbSolicitante);
            panel2.Controls.Add(txbFolio);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnCargarComprobante);
            panel2.Controls.Add(txbRefacciones);
            panel2.Controls.Add(txbRecomendaciones);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(txbDescripcion);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txbTipoFalla);
            panel2.Controls.Add(txbPrioridad);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(txbMaquina);
            panel2.Controls.Add(txbUbicacion);
            panel2.Controls.Add(txbMantenimiento);
            panel2.Controls.Add(pbImagen);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label8);
            panel2.Location = new Point(702, 89);
            panel2.Name = "panel2";
            panel2.Size = new Size(624, 708);
            panel2.TabIndex = 43;
            // 
            // txbSolicitante
            // 
            txbSolicitante.Font = new Font("Montserrat", 10F);
            txbSolicitante.Location = new Point(154, 80);
            txbSolicitante.Name = "txbSolicitante";
            txbSolicitante.ReadOnly = true;
            txbSolicitante.Size = new Size(215, 24);
            txbSolicitante.TabIndex = 49;
            // 
            // txbFolio
            // 
            txbFolio.Font = new Font("Montserrat", 10F);
            txbFolio.Location = new Point(154, 50);
            txbFolio.Name = "txbFolio";
            txbFolio.ReadOnly = true;
            txbFolio.Size = new Size(215, 24);
            txbFolio.TabIndex = 48;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(21, 83);
            label5.Name = "label5";
            label5.Size = new Size(91, 20);
            label5.TabIndex = 47;
            label5.Text = "Solicitante:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label12.ForeColor = Color.White;
            label12.Location = new Point(21, 53);
            label12.Name = "label12";
            label12.Size = new Size(48, 20);
            label12.TabIndex = 46;
            label12.Text = "Folio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(21, 15);
            label2.Name = "label2";
            label2.Size = new Size(258, 22);
            label2.TabIndex = 45;
            label2.Text = "DATOS DEL REQUERIMIENTO";
            // 
            // btnCargarComprobante
            // 
            btnCargarComprobante.BackColor = Color.FromArgb(255, 102, 0);
            btnCargarComprobante.Cursor = Cursors.Hand;
            btnCargarComprobante.FlatAppearance.BorderSize = 0;
            btnCargarComprobante.FlatStyle = FlatStyle.Flat;
            btnCargarComprobante.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnCargarComprobante.ForeColor = Color.White;
            btnCargarComprobante.Location = new Point(121, 637);
            btnCargarComprobante.Name = "btnCargarComprobante";
            btnCargarComprobante.Size = new Size(397, 38);
            btnCargarComprobante.TabIndex = 44;
            btnCargarComprobante.Text = "Cargar Comprobante";
            btnCargarComprobante.UseVisualStyleBackColor = false;
            btnCargarComprobante.Click += btnCargarComprobante_Click;
            // 
            // txbRefacciones
            // 
            txbRefacciones.Font = new Font("Montserrat", 10F);
            txbRefacciones.Location = new Point(21, 566);
            txbRefacciones.Multiline = true;
            txbRefacciones.Name = "txbRefacciones";
            txbRefacciones.ReadOnly = true;
            txbRefacciones.Size = new Size(584, 46);
            txbRefacciones.TabIndex = 43;
            // 
            // txbRecomendaciones
            // 
            txbRecomendaciones.Font = new Font("Montserrat", 10F);
            txbRecomendaciones.Location = new Point(21, 484);
            txbRecomendaciones.Multiline = true;
            txbRecomendaciones.Name = "txbRecomendaciones";
            txbRecomendaciones.ReadOnly = true;
            txbRecomendaciones.Size = new Size(584, 46);
            txbRecomendaciones.TabIndex = 42;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label15.ForeColor = Color.White;
            label15.Location = new Point(21, 543);
            label15.Name = "label15";
            label15.Size = new Size(170, 20);
            label15.TabIndex = 41;
            label15.Text = "Refacciones a Utilizar:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label16.ForeColor = Color.White;
            label16.Location = new Point(21, 461);
            label16.Name = "label16";
            label16.Size = new Size(253, 20);
            label16.TabIndex = 40;
            label16.Text = "Recomendaciones / Sugerencias:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Transparent;
            label17.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            label17.ForeColor = Color.White;
            label17.Location = new Point(21, 429);
            label17.Name = "label17";
            label17.Size = new Size(206, 22);
            label17.TabIndex = 39;
            label17.Text = "APOYO Y ACCESORIOS";
            // 
            // txbDescripcion
            // 
            txbDescripcion.Font = new Font("Montserrat", 10F);
            txbDescripcion.Location = new Point(154, 369);
            txbDescripcion.Multiline = true;
            txbDescripcion.Name = "txbDescripcion";
            txbDescripcion.ReadOnly = true;
            txbDescripcion.Size = new Size(451, 46);
            txbDescripcion.TabIndex = 38;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(21, 372);
            label7.Name = "label7";
            label7.Size = new Size(100, 20);
            label7.TabIndex = 37;
            label7.Text = "Descripción:";
            // 
            // txbTipoFalla
            // 
            txbTipoFalla.Font = new Font("Montserrat", 10F);
            txbTipoFalla.Location = new Point(154, 339);
            txbTipoFalla.Name = "txbTipoFalla";
            txbTipoFalla.ReadOnly = true;
            txbTipoFalla.Size = new Size(215, 24);
            txbTipoFalla.TabIndex = 36;
            // 
            // txbPrioridad
            // 
            txbPrioridad.Font = new Font("Montserrat", 10F);
            txbPrioridad.Location = new Point(154, 309);
            txbPrioridad.Name = "txbPrioridad";
            txbPrioridad.ReadOnly = true;
            txbPrioridad.Size = new Size(215, 24);
            txbPrioridad.TabIndex = 35;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(21, 342);
            label9.Name = "label9";
            label9.Size = new Size(107, 20);
            label9.TabIndex = 34;
            label9.Text = "Tipo de Falla:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(21, 312);
            label10.Name = "label10";
            label10.Size = new Size(81, 20);
            label10.TabIndex = 33;
            label10.Text = "Prioridad:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            label11.ForeColor = Color.White;
            label11.Location = new Point(21, 272);
            label11.Name = "label11";
            label11.Size = new Size(211, 22);
            label11.TabIndex = 32;
            label11.Text = "DETALLES DE LA FALLA";
            // 
            // txbMaquina
            // 
            txbMaquina.Font = new Font("Montserrat", 10F);
            txbMaquina.Location = new Point(154, 206);
            txbMaquina.Name = "txbMaquina";
            txbMaquina.ReadOnly = true;
            txbMaquina.Size = new Size(215, 24);
            txbMaquina.TabIndex = 31;
            txbMaquina.TextChanged += txbMaquina_TextChanged;
            // 
            // txbUbicacion
            // 
            txbUbicacion.Font = new Font("Montserrat", 10F);
            txbUbicacion.Location = new Point(154, 176);
            txbUbicacion.Name = "txbUbicacion";
            txbUbicacion.ReadOnly = true;
            txbUbicacion.Size = new Size(215, 24);
            txbUbicacion.TabIndex = 30;
            // 
            // txbMantenimiento
            // 
            txbMantenimiento.Font = new Font("Montserrat", 10F);
            txbMantenimiento.Location = new Point(154, 146);
            txbMantenimiento.Name = "txbMantenimiento";
            txbMantenimiento.ReadOnly = true;
            txbMantenimiento.Size = new Size(215, 24);
            txbMantenimiento.TabIndex = 29;
            // 
            // pbImagen
            // 
            pbImagen.BackColor = Color.White;
            pbImagen.Location = new Point(386, 146);
            pbImagen.Name = "pbImagen";
            pbImagen.Size = new Size(219, 148);
            pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            pbImagen.TabIndex = 5;
            pbImagen.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(21, 209);
            label6.Name = "label6";
            label6.Size = new Size(78, 20);
            label6.TabIndex = 24;
            label6.Text = "Maquina:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(21, 179);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 23;
            label4.Text = "Ubicación:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(21, 149);
            label3.Name = "label3";
            label3.Size = new Size(127, 20);
            label3.TabIndex = 22;
            label3.Text = "Mantenimiento:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(21, 115);
            label8.Name = "label8";
            label8.Size = new Size(181, 22);
            label8.TabIndex = 21;
            label8.Text = "DATOS DEL EQUIPO";
            // 
            // pnlComprobante
            // 
            pnlComprobante.BackColor = Color.FromArgb(3, 42, 76);
            pnlComprobante.Controls.Add(label13);
            pnlComprobante.Controls.Add(txbNotas);
            pnlComprobante.Controls.Add(lblRutaArchivo);
            pnlComprobante.Controls.Add(txbNombreArchivo);
            pnlComprobante.Controls.Add(btnCargarDoc);
            pnlComprobante.Controls.Add(btnCerrar);
            pnlComprobante.Controls.Add(btnFinalizarReq);
            pnlComprobante.Controls.Add(pbComprobante);
            pnlComprobante.Controls.Add(label19);
            pnlComprobante.Location = new Point(23, 89);
            pnlComprobante.Name = "pnlComprobante";
            pnlComprobante.Size = new Size(673, 708);
            pnlComprobante.TabIndex = 44;
            pnlComprobante.Visible = false;
            // 
            // lblRutaArchivo
            // 
            lblRutaArchivo.AutoSize = true;
            lblRutaArchivo.BackColor = Color.Transparent;
            lblRutaArchivo.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            lblRutaArchivo.ForeColor = Color.White;
            lblRutaArchivo.Location = new Point(123, 420);
            lblRutaArchivo.Name = "lblRutaArchivo";
            lblRutaArchivo.Size = new Size(44, 20);
            lblRutaArchivo.TabIndex = 50;
            lblRutaArchivo.Text = "Ruta";
            lblRutaArchivo.Visible = false;
            // 
            // txbNombreArchivo
            // 
            txbNombreArchivo.Font = new Font("Montserrat", 10F);
            txbNombreArchivo.Location = new Point(173, 417);
            txbNombreArchivo.Name = "txbNombreArchivo";
            txbNombreArchivo.ReadOnly = true;
            txbNombreArchivo.Size = new Size(300, 24);
            txbNombreArchivo.TabIndex = 49;
            // 
            // btnCargarDoc
            // 
            btnCargarDoc.BackColor = Color.FromArgb(255, 102, 0);
            btnCargarDoc.Cursor = Cursors.Hand;
            btnCargarDoc.FlatAppearance.BorderSize = 0;
            btnCargarDoc.FlatStyle = FlatStyle.Flat;
            btnCargarDoc.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnCargarDoc.ForeColor = Color.White;
            btnCargarDoc.Location = new Point(222, 373);
            btnCargarDoc.Name = "btnCargarDoc";
            btnCargarDoc.Size = new Size(223, 38);
            btnCargarDoc.TabIndex = 47;
            btnCargarDoc.Text = "Cargar Documento";
            btnCargarDoc.UseVisualStyleBackColor = false;
            btnCargarDoc.Click += btnCargarDoc_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(255, 102, 0);
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(537, 15);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(114, 38);
            btnCerrar.TabIndex = 46;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnFinalizarReq
            // 
            btnFinalizarReq.BackColor = Color.FromArgb(255, 102, 0);
            btnFinalizarReq.Cursor = Cursors.Hand;
            btnFinalizarReq.FlatAppearance.BorderSize = 0;
            btnFinalizarReq.FlatStyle = FlatStyle.Flat;
            btnFinalizarReq.Font = new Font("Montserrat", 11F, FontStyle.Bold);
            btnFinalizarReq.ForeColor = Color.White;
            btnFinalizarReq.Location = new Point(132, 601);
            btnFinalizarReq.Name = "btnFinalizarReq";
            btnFinalizarReq.Size = new Size(397, 38);
            btnFinalizarReq.TabIndex = 45;
            btnFinalizarReq.Text = "Finalizar Requerimiento";
            btnFinalizarReq.UseVisualStyleBackColor = false;
            btnFinalizarReq.Click += btnFinalizarReq_Click;
            // 
            // pbComprobante
            // 
            pbComprobante.BackColor = Color.White;
            pbComprobante.Location = new Point(173, 142);
            pbComprobante.Name = "pbComprobante";
            pbComprobante.Size = new Size(300, 225);
            pbComprobante.SizeMode = PictureBoxSizeMode.Zoom;
            pbComprobante.TabIndex = 5;
            pbComprobante.TabStop = false;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = Color.Transparent;
            label19.Font = new Font("Montserrat", 14F, FontStyle.Bold);
            label19.ForeColor = Color.White;
            label19.Location = new Point(189, 63);
            label19.Name = "label19";
            label19.Size = new Size(266, 26);
            label19.TabIndex = 21;
            label19.Text = "CARGAR COMPROBANTE";
            // 
            // txbNotas
            // 
            txbNotas.Font = new Font("Montserrat", 10F);
            txbNotas.Location = new Point(173, 484);
            txbNotas.Multiline = true;
            txbNotas.Name = "txbNotas";
            txbNotas.Size = new Size(300, 89);
            txbNotas.TabIndex = 51;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Montserrat", 10F, FontStyle.Bold);
            label13.ForeColor = Color.White;
            label13.Location = new Point(173, 461);
            label13.Name = "label13";
            label13.Size = new Size(55, 20);
            label13.TabIndex = 52;
            label13.Text = "Notas:";
            // 
            // Mantenimiento_Pendientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(pnlComprobante);
            Controls.Add(panel2);
            Controls.Add(dgvPendientesMtto);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Mantenimiento_Pendientes";
            Text = "Mantenimiento_Pendientes";
            Load += Mantenimiento_Pendientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPendientesMtto).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbImagen).EndInit();
            pnlComprobante.ResumeLayout(false);
            pnlComprobante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbComprobante).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvPendientesMtto;
        private Panel panel2;
        private PictureBox pbImagen;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label8;
        private TextBox txbMaquina;
        private TextBox txbUbicacion;
        private TextBox txbMantenimiento;
        private TextBox txbTipoFalla;
        private TextBox txbPrioridad;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txbDescripcion;
        private Label label7;
        private TextBox txbRefacciones;
        private TextBox txbRecomendaciones;
        private Label label15;
        private Label label16;
        private Label label17;
        private Button btnCargarComprobante;
        private Label label2;
        private TextBox txbSolicitante;
        private TextBox txbFolio;
        private Label label5;
        private Label label12;
        private Panel pnlComprobante;
        private Button btnCargarDoc;
        private Button btnCerrar;
        private Button btnFinalizarReq;
        private PictureBox pbComprobante;
        private Label label19;
        private Label lblRutaArchivo;
        private TextBox txbNombreArchivo;
        private TextBox txbNotas;
        private Label label13;
    }
}