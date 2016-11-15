namespace PluginInsViviendas_UNO.Vista.Multifamiliar
{
    partial class RelPrototipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelPrototipo));
            this.dtRelacionProto = new System.Windows.Forms.DataGridView();
            this.Prototipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Layer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtRelacionProto)).BeginInit();
            this.SuspendLayout();
            // 
            // dtRelacionProto
            // 
            this.dtRelacionProto.AllowUserToAddRows = false;
            this.dtRelacionProto.AllowUserToDeleteRows = false;
            this.dtRelacionProto.BackgroundColor = System.Drawing.Color.White;
            this.dtRelacionProto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtRelacionProto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Prototipo,
            this.Layer,
            this.Piso});
            this.dtRelacionProto.Location = new System.Drawing.Point(12, 16);
            this.dtRelacionProto.Name = "dtRelacionProto";
            this.dtRelacionProto.ReadOnly = true;
            this.dtRelacionProto.Size = new System.Drawing.Size(475, 179);
            this.dtRelacionProto.TabIndex = 0;
            // 
            // Prototipo
            // 
            this.Prototipo.HeaderText = "Prototipo";
            this.Prototipo.Name = "Prototipo";
            this.Prototipo.ReadOnly = true;
            this.Prototipo.Width = 150;
            // 
            // Layer
            // 
            this.Layer.HeaderText = "Layer";
            this.Layer.Name = "Layer";
            this.Layer.ReadOnly = true;
            this.Layer.Width = 150;
            // 
            // Piso
            // 
            this.Piso.HeaderText = "Piso";
            this.Piso.Name = "Piso";
            this.Piso.ReadOnly = true;
            this.Piso.Width = 130;
            // 
            // RelPrototipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(499, 207);
            this.Controls.Add(this.dtRelacionProto);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RelPrototipo";
            this.Text = "Detalle de Relación de Prototipo";
            this.Load += new System.EventHandler(this.RelPrototipo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtRelacionProto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtRelacionProto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prototipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Layer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Piso;
    }
}