namespace ElastoSystem
{
    partial class Maquinado_Administrar
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            pnlPendientesMaquinado = new Panel();
            btnActualizar = new Button();
            btnRealizado = new Button();
            dgvPendientesMaquinado = new DataGridView();
            pnlRealizado = new Panel();
            pbComprobanteMaquinado = new PictureBox();
            lblRutaComprobante = new Label();
            label8 = new Label();
            btnRegresar = new Button();
            txbNombreComprobante = new TextBox();
            btnCargarArchivo = new Button();
            btnFinalizado = new Button();
            panel4 = new Panel();
            txbTipo = new TextBox();
            label5 = new Label();
            txbFecha = new TextBox();
            label4 = new Label();
            txbPrioridad = new TextBox();
            label3 = new Label();
            txbSolicitante = new TextBox();
            label2 = new Label();
            label15 = new Label();
            panel2 = new Panel();
            txbDescripcion = new TextBox();
            label10 = new Label();
            panel3 = new Panel();
            txbDescripcionMaquinado = new TextBox();
            label6 = new Label();
            panel5 = new Panel();
            txbRecomendaciones = new TextBox();
            label7 = new Label();
            panel6 = new Panel();
            pbImagen = new PictureBox();
            txbNombreArchivo = new TextBox();
            btnDescargar = new Button();
            txbFolio = new TextBox();
            label12 = new Label();
            txbRuta = new TextBox();
            lblFolio = new Label();
            pnlPendientesMaquinado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPendientesMaquinado).BeginInit();
            pnlRealizado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbComprobanteMaquinado).BeginInit();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbImagen).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(34, 24);
            label1.Name = "label1";
            label1.Size = new Size(536, 44);
            label1.TabIndex = 2;
            label1.Text = "ACTIVIDADES DE MAQUINADO";
            // 
            // pnlPendientesMaquinado
            // 
            pnlPendientesMaquinado.BackColor = Color.FromArgb(3, 42, 76);
            pnlPendientesMaquinado.Controls.Add(btnActualizar);
            pnlPendientesMaquinado.Controls.Add(btnRealizado);
            pnlPendientesMaquinado.Controls.Add(dgvPendientesMaquinado);
            pnlPendientesMaquinado.Location = new Point(22, 90);
            pnlPendientesMaquinado.Name = "pnlPendientesMaquinado";
            pnlPendientesMaquinado.Size = new Size(742, 709);
            pnlPendientesMaquinado.TabIndex = 19;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(255, 102, 0);
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(582, 22);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(145, 29);
            btnActualizar.TabIndex = 20;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnRealizado
            // 
            btnRealizado.BackColor = Color.FromArgb(255, 102, 0);
            btnRealizado.Cursor = Cursors.Hand;
            btnRealizado.FlatAppearance.BorderSize = 0;
            btnRealizado.FlatStyle = FlatStyle.Flat;
            btnRealizado.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnRealizado.ForeColor = Color.White;
            btnRealizado.Location = new Point(400, 22);
            btnRealizado.Name = "btnRealizado";
            btnRealizado.Size = new Size(157, 29);
            btnRealizado.TabIndex = 19;
            btnRealizado.Text = "REALIZADO";
            btnRealizado.UseVisualStyleBackColor = false;
            btnRealizado.Click += btnRealizado_Click;
            // 
            // dgvPendientesMaquinado
            // 
            dgvPendientesMaquinado.AllowUserToAddRows = false;
            dgvPendientesMaquinado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPendientesMaquinado.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Montserrat", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPendientesMaquinado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPendientesMaquinado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPendientesMaquinado.Location = new Point(16, 67);
            dgvPendientesMaquinado.Name = "dgvPendientesMaquinado";
            dgvPendientesMaquinado.ReadOnly = true;
            dgvPendientesMaquinado.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Montserrat", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 102, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvPendientesMaquinado.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvPendientesMaquinado.RowTemplate.Height = 25;
            dgvPendientesMaquinado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPendientesMaquinado.Size = new Size(711, 626);
            dgvPendientesMaquinado.TabIndex = 18;
            dgvPendientesMaquinado.Click += dgvPendientesMaquinado_Click;
            dgvPendientesMaquinado.DoubleClick += dgvPendientesSistemas_DoubleClick;
            // 
            // pnlRealizado
            // 
            pnlRealizado.BackColor = Color.FromArgb(3, 42, 76);
            pnlRealizado.Controls.Add(pbComprobanteMaquinado);
            pnlRealizado.Controls.Add(lblRutaComprobante);
            pnlRealizado.Controls.Add(label8);
            pnlRealizado.Controls.Add(btnRegresar);
            pnlRealizado.Controls.Add(txbNombreComprobante);
            pnlRealizado.Controls.Add(btnCargarArchivo);
            pnlRealizado.Controls.Add(btnFinalizado);
            pnlRealizado.Location = new Point(22, 90);
            pnlRealizado.Name = "pnlRealizado";
            pnlRealizado.Size = new Size(742, 709);
            pnlRealizado.TabIndex = 21;
            pnlRealizado.Visible = false;
            // 
            // pbComprobanteMaquinado
            // 
            pbComprobanteMaquinado.BackColor = Color.White;
            pbComprobanteMaquinado.Location = new Point(157, 193);
            pbComprobanteMaquinado.Name = "pbComprobanteMaquinado";
            pbComprobanteMaquinado.Size = new Size(245, 199);
            pbComprobanteMaquinado.SizeMode = PictureBoxSizeMode.Zoom;
            pbComprobanteMaquinado.TabIndex = 39;
            pbComprobanteMaquinado.TabStop = false;
            // 
            // lblRutaComprobante
            // 
            lblRutaComprobante.AutoSize = true;
            lblRutaComprobante.BackColor = Color.Transparent;
            lblRutaComprobante.Font = new Font("Montserrat", 8F, FontStyle.Bold, GraphicsUnit.Point);
            lblRutaComprobante.ForeColor = Color.White;
            lblRutaComprobante.Location = new Point(59, 446);
            lblRutaComprobante.Name = "lblRutaComprobante";
            lblRutaComprobante.Size = new Size(120, 15);
            lblRutaComprobante.TabIndex = 29;
            lblRutaComprobante.Text = "Ruta Comprobante";
            lblRutaComprobante.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Montserrat", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(214, 80);
            label8.Name = "label8";
            label8.Size = new Size(334, 33);
            label8.TabIndex = 28;
            label8.Text = "CARGAR COMPROBANTE";
            // 
            // btnRegresar
            // 
            btnRegresar.BackColor = Color.FromArgb(255, 102, 0);
            btnRegresar.Cursor = Cursors.Hand;
            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegresar.ForeColor = Color.White;
            btnRegresar.Location = new Point(24, 19);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(134, 29);
            btnRegresar.TabIndex = 27;
            btnRegresar.Text = "REGRESAR";
            btnRegresar.UseVisualStyleBackColor = false;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // txbNombreComprobante
            // 
            txbNombreComprobante.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txbNombreComprobante.Location = new Point(59, 409);
            txbNombreComprobante.Name = "txbNombreComprobante";
            txbNombreComprobante.ReadOnly = true;
            txbNombreComprobante.Size = new Size(425, 22);
            txbNombreComprobante.TabIndex = 26;
            txbNombreComprobante.TextAlign = HorizontalAlignment.Center;
            // 
            // btnCargarArchivo
            // 
            btnCargarArchivo.BackColor = Color.FromArgb(255, 102, 0);
            btnCargarArchivo.Cursor = Cursors.Hand;
            btnCargarArchivo.FlatAppearance.BorderSize = 0;
            btnCargarArchivo.FlatStyle = FlatStyle.Flat;
            btnCargarArchivo.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnCargarArchivo.ForeColor = Color.White;
            btnCargarArchivo.Location = new Point(502, 404);
            btnCargarArchivo.Name = "btnCargarArchivo";
            btnCargarArchivo.Size = new Size(178, 29);
            btnCargarArchivo.TabIndex = 20;
            btnCargarArchivo.Text = "CARGAR ARCHIVO";
            btnCargarArchivo.UseVisualStyleBackColor = false;
            btnCargarArchivo.Click += btnCargarArchivo_Click;
            // 
            // btnFinalizado
            // 
            btnFinalizado.BackColor = Color.FromArgb(255, 102, 0);
            btnFinalizado.Cursor = Cursors.Hand;
            btnFinalizado.FlatAppearance.BorderSize = 0;
            btnFinalizado.FlatStyle = FlatStyle.Flat;
            btnFinalizado.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnFinalizado.ForeColor = Color.White;
            btnFinalizado.Location = new Point(276, 486);
            btnFinalizado.Name = "btnFinalizado";
            btnFinalizado.Size = new Size(183, 35);
            btnFinalizado.TabIndex = 19;
            btnFinalizado.Text = "FINALIZADO";
            btnFinalizado.UseVisualStyleBackColor = false;
            btnFinalizado.Click += btnFinalizado_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(3, 42, 76);
            panel4.Controls.Add(txbTipo);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(txbFecha);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(txbPrioridad);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(txbSolicitante);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(label15);
            panel4.Location = new Point(779, 90);
            panel4.Name = "panel4";
            panel4.Size = new Size(240, 302);
            panel4.TabIndex = 30;
            // 
            // txbTipo
            // 
            txbTipo.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbTipo.Location = new Point(18, 255);
            txbTipo.Name = "txbTipo";
            txbTipo.ReadOnly = true;
            txbTipo.Size = new Size(204, 27);
            txbTipo.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(86, 230);
            label5.Name = "label5";
            label5.Size = new Size(50, 22);
            label5.TabIndex = 23;
            label5.Text = "Tipo:";
            // 
            // txbFecha
            // 
            txbFecha.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbFecha.Location = new Point(18, 193);
            txbFecha.Name = "txbFecha";
            txbFecha.ReadOnly = true;
            txbFecha.Size = new Size(204, 27);
            txbFecha.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(86, 168);
            label4.Name = "label4";
            label4.Size = new Size(64, 22);
            label4.TabIndex = 21;
            label4.Text = "Fecha:";
            // 
            // txbPrioridad
            // 
            txbPrioridad.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbPrioridad.Location = new Point(18, 133);
            txbPrioridad.Name = "txbPrioridad";
            txbPrioridad.ReadOnly = true;
            txbPrioridad.Size = new Size(204, 27);
            txbPrioridad.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(69, 105);
            label3.Name = "label3";
            label3.Size = new Size(92, 22);
            label3.TabIndex = 19;
            label3.Text = "Prioridad:";
            // 
            // txbSolicitante
            // 
            txbSolicitante.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbSolicitante.Location = new Point(18, 67);
            txbSolicitante.Name = "txbSolicitante";
            txbSolicitante.ReadOnly = true;
            txbSolicitante.Size = new Size(204, 27);
            txbSolicitante.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(86, 11);
            label2.Name = "label2";
            label2.Size = new Size(68, 22);
            label2.TabIndex = 17;
            label2.Text = "DATOS";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.White;
            label15.Location = new Point(69, 39);
            label15.Name = "label15";
            label15.Size = new Size(103, 22);
            label15.TabIndex = 3;
            label15.Text = "Solicitante:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(3, 42, 76);
            panel2.Controls.Add(txbDescripcion);
            panel2.Controls.Add(label10);
            panel2.Location = new Point(779, 405);
            panel2.Name = "panel2";
            panel2.Size = new Size(535, 118);
            panel2.TabIndex = 31;
            // 
            // txbDescripcion
            // 
            txbDescripcion.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbDescripcion.Location = new Point(18, 40);
            txbDescripcion.Multiline = true;
            txbDescripcion.Name = "txbDescripcion";
            txbDescripcion.ReadOnly = true;
            txbDescripcion.Size = new Size(500, 63);
            txbDescripcion.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(18, 13);
            label10.Name = "label10";
            label10.Size = new Size(112, 22);
            label10.TabIndex = 3;
            label10.Text = "Descripcion:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(3, 42, 76);
            panel3.Controls.Add(txbDescripcionMaquinado);
            panel3.Controls.Add(label6);
            panel3.Location = new Point(779, 536);
            panel3.Name = "panel3";
            panel3.Size = new Size(535, 118);
            panel3.TabIndex = 32;
            // 
            // txbDescripcionMaquinado
            // 
            txbDescripcionMaquinado.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbDescripcionMaquinado.Location = new Point(18, 40);
            txbDescripcionMaquinado.Multiline = true;
            txbDescripcionMaquinado.Name = "txbDescripcionMaquinado";
            txbDescripcionMaquinado.ReadOnly = true;
            txbDescripcionMaquinado.Size = new Size(500, 63);
            txbDescripcionMaquinado.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(18, 13);
            label6.Name = "label6";
            label6.Size = new Size(211, 22);
            label6.TabIndex = 3;
            label6.Text = "Descripcion Maquinado:";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(3, 42, 76);
            panel5.Controls.Add(txbRecomendaciones);
            panel5.Controls.Add(label7);
            panel5.Location = new Point(779, 666);
            panel5.Name = "panel5";
            panel5.Size = new Size(535, 118);
            panel5.TabIndex = 32;
            // 
            // txbRecomendaciones
            // 
            txbRecomendaciones.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbRecomendaciones.Location = new Point(18, 40);
            txbRecomendaciones.Multiline = true;
            txbRecomendaciones.Name = "txbRecomendaciones";
            txbRecomendaciones.ReadOnly = true;
            txbRecomendaciones.Size = new Size(500, 63);
            txbRecomendaciones.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(18, 13);
            label7.Name = "label7";
            label7.Size = new Size(167, 22);
            label7.TabIndex = 3;
            label7.Text = "Recomendaciones:";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(3, 42, 76);
            panel6.Controls.Add(pbImagen);
            panel6.Controls.Add(txbNombreArchivo);
            panel6.Controls.Add(btnDescargar);
            panel6.Controls.Add(txbFolio);
            panel6.Controls.Add(label12);
            panel6.Location = new Point(1025, 90);
            panel6.Name = "panel6";
            panel6.Size = new Size(289, 302);
            panel6.TabIndex = 33;
            // 
            // pbImagen
            // 
            pbImagen.BackColor = Color.White;
            pbImagen.Location = new Point(64, 53);
            pbImagen.Name = "pbImagen";
            pbImagen.Size = new Size(150, 150);
            pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            pbImagen.TabIndex = 38;
            pbImagen.TabStop = false;
            // 
            // txbNombreArchivo
            // 
            txbNombreArchivo.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txbNombreArchivo.Location = new Point(13, 211);
            txbNombreArchivo.Name = "txbNombreArchivo";
            txbNombreArchivo.ReadOnly = true;
            txbNombreArchivo.Size = new Size(252, 22);
            txbNombreArchivo.TabIndex = 25;
            // 
            // btnDescargar
            // 
            btnDescargar.BackColor = Color.FromArgb(255, 102, 0);
            btnDescargar.Cursor = Cursors.Hand;
            btnDescargar.FlatAppearance.BorderSize = 0;
            btnDescargar.FlatStyle = FlatStyle.Flat;
            btnDescargar.Font = new Font("Montserrat", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnDescargar.ForeColor = Color.White;
            btnDescargar.Location = new Point(13, 244);
            btnDescargar.Name = "btnDescargar";
            btnDescargar.Size = new Size(252, 38);
            btnDescargar.TabIndex = 21;
            btnDescargar.Text = "DESCARGAR";
            btnDescargar.UseVisualStyleBackColor = false;
            btnDescargar.Click += btnDescargar_Click;
            // 
            // txbFolio
            // 
            txbFolio.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbFolio.Location = new Point(82, 14);
            txbFolio.Name = "txbFolio";
            txbFolio.ReadOnly = true;
            txbFolio.Size = new Size(190, 27);
            txbFolio.TabIndex = 19;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(13, 17);
            label12.Name = "label12";
            label12.Size = new Size(67, 22);
            label12.TabIndex = 17;
            label12.Text = "FOLIO:";
            // 
            // txbRuta
            // 
            txbRuta.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbRuta.Location = new Point(1025, 57);
            txbRuta.Name = "txbRuta";
            txbRuta.ReadOnly = true;
            txbRuta.Size = new Size(204, 27);
            txbRuta.TabIndex = 35;
            txbRuta.Visible = false;
            // 
            // lblFolio
            // 
            lblFolio.AutoSize = true;
            lblFolio.BackColor = Color.Transparent;
            lblFolio.Font = new Font("Montserrat", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblFolio.ForeColor = Color.White;
            lblFolio.Location = new Point(797, 57);
            lblFolio.Name = "lblFolio";
            lblFolio.Size = new Size(123, 22);
            lblFolio.TabIndex = 25;
            lblFolio.Text = "Folio Original";
            lblFolio.Visible = false;
            // 
            // Maquinado_Administrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondocontrolalmacen;
            ClientSize = new Size(1338, 831);
            Controls.Add(lblFolio);
            Controls.Add(pnlRealizado);
            Controls.Add(txbRuta);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(pnlPendientesMaquinado);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Maquinado_Administrar";
            Text = "Maquinado_Administrar";
            Load += Maquinado_Administrar_Load;
            pnlPendientesMaquinado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPendientesMaquinado).EndInit();
            pnlRealizado.ResumeLayout(false);
            pnlRealizado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbComprobanteMaquinado).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbImagen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel pnlPendientesMaquinado;
        private DataGridView dgvPendientesMaquinado;
        private Button btnActualizar;
        private Button btnRealizado;
        private Panel panel4;
        private TextBox txbTipo;
        private Label label5;
        private TextBox txbFecha;
        private Label label4;
        private TextBox txbPrioridad;
        private Label label3;
        private TextBox txbSolicitante;
        private Label label2;
        private Label label15;
        private Panel panel2;
        private TextBox txbDescripcion;
        private Label label10;
        private Panel panel3;
        private TextBox txbDescripcionMaquinado;
        private Label label6;
        private Panel panel5;
        private TextBox txbRecomendaciones;
        private Label label7;
        private Panel panel6;
        private Label label12;
        private TextBox txbNombreArchivo;
        private Button btnDescargar;
        private TextBox txbFolio;
        private PictureBox pbImagen;
        private TextBox txbRuta;
        private Panel pnlRealizado;
        private Button btnRegresar;
        private TextBox txbNombreComprobante;
        private Button btnCargarArchivo;
        private Button btnFinalizado;
        private Label label8;
        private Label lblRutaComprobante;
        private Label lblFolio;
        private PictureBox pbComprobanteMaquinado;
    }
}