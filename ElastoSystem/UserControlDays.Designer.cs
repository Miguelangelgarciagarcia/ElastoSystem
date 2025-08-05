namespace ElastoSystem
{
    partial class UserControlDays
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblDays = new Label();
            lblEvents = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            cmsCerrarMtto = new ContextMenuStrip(components);
            MttoPreventivo = new ToolStripMenuItem();
            cmsCerrarMtto.SuspendLayout();
            SuspendLayout();
            // 
            // lblDays
            // 
            lblDays.AutoSize = true;
            lblDays.BackColor = Color.Transparent;
            lblDays.Font = new Font("Montserrat", 9F);
            lblDays.ForeColor = Color.Black;
            lblDays.Location = new Point(12, 12);
            lblDays.Name = "lblDays";
            lblDays.Size = new Size(23, 16);
            lblDays.TabIndex = 40;
            lblDays.Text = "00";
            // 
            // lblEvents
            // 
            lblEvents.Font = new Font("Montserrat", 8.249999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEvents.ForeColor = Color.Red;
            lblEvents.Location = new Point(11, 34);
            lblEvents.Name = "lblEvents";
            lblEvents.Size = new Size(143, 45);
            lblEvents.TabIndex = 41;
            lblEvents.Click += lblEvents_Click;
            lblEvents.MouseClick += lblEvents_MouseClick;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // cmsCerrarMtto
            // 
            cmsCerrarMtto.Items.AddRange(new ToolStripItem[] { MttoPreventivo });
            cmsCerrarMtto.Name = "cmsOP";
            cmsCerrarMtto.Size = new Size(270, 48);
            // 
            // MttoPreventivo
            // 
            MttoPreventivo.Name = "MttoPreventivo";
            MttoPreventivo.Size = new Size(269, 22);
            MttoPreventivo.Text = "Adelantar Mantenimiento Preventivo";
            MttoPreventivo.Click += MttoPreventivo_Click;
            // 
            // UserControlDays
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblEvents);
            Controls.Add(lblDays);
            Cursor = Cursors.Hand;
            Name = "UserControlDays";
            Size = new Size(168, 85);
            Load += UserControlDays_Load;
            Click += UserControlDays_Click;
            MouseClick += UserControlDays_MouseClick;
            cmsCerrarMtto.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDays;
        private Label lblEvents;
        private System.Windows.Forms.Timer timer1;
        private ContextMenuStrip cmsCerrarMtto;
        private ToolStripMenuItem MttoPreventivo;
    }
}
