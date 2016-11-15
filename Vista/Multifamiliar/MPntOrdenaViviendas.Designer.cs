namespace PluginInsViviendas_UNO.Vista.Multifamiliar
{
    partial class MPntOrdenaViviendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MPntOrdenaViviendas));
            this.BtnRadioNI = new System.Windows.Forms.RadioButton();
            this.groupManzana = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRadioPiso = new System.Windows.Forms.RadioButton();
            this.dtOrdenaViv = new System.Windows.Forms.DataGridView();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.ValorAgregado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupManzana.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtOrdenaViv)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnRadioNI
            // 
            this.BtnRadioNI.AutoSize = true;
            this.BtnRadioNI.Checked = true;
            this.BtnRadioNI.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRadioNI.ForeColor = System.Drawing.Color.Black;
            this.BtnRadioNI.Location = new System.Drawing.Point(125, 17);
            this.BtnRadioNI.Name = "BtnRadioNI";
            this.BtnRadioNI.Size = new System.Drawing.Size(113, 19);
            this.BtnRadioNI.TabIndex = 0;
            this.BtnRadioNI.TabStop = true;
            this.BtnRadioNI.Text = "Número Interior";
            this.BtnRadioNI.UseVisualStyleBackColor = true;
            this.BtnRadioNI.CheckedChanged += new System.EventHandler(this.BtnRadioNI_CheckedChanged);
            // 
            // groupManzana
            // 
            this.groupManzana.BackColor = System.Drawing.Color.Transparent;
            this.groupManzana.Controls.Add(this.label1);
            this.groupManzana.Controls.Add(this.btnRadioPiso);
            this.groupManzana.Controls.Add(this.BtnRadioNI);
            this.groupManzana.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupManzana.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupManzana.Location = new System.Drawing.Point(14, 3);
            this.groupManzana.Name = "groupManzana";
            this.groupManzana.Size = new System.Drawing.Size(342, 45);
            this.groupManzana.TabIndex = 17;
            this.groupManzana.TabStop = false;
            this.groupManzana.Enter += new System.EventHandler(this.groupManzana_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Ordenar por:";
            // 
            // btnRadioPiso
            // 
            this.btnRadioPiso.AutoSize = true;
            this.btnRadioPiso.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRadioPiso.ForeColor = System.Drawing.Color.Black;
            this.btnRadioPiso.Location = new System.Drawing.Point(261, 17);
            this.btnRadioPiso.Name = "btnRadioPiso";
            this.btnRadioPiso.Size = new System.Drawing.Size(49, 19);
            this.btnRadioPiso.TabIndex = 0;
            this.btnRadioPiso.Text = "Piso";
            this.btnRadioPiso.UseVisualStyleBackColor = true;
            this.btnRadioPiso.CheckedChanged += new System.EventHandler(this.btnRadioPiso_CheckedChanged);
            // 
            // dtOrdenaViv
            // 
            this.dtOrdenaViv.AllowUserToAddRows = false;
            this.dtOrdenaViv.AllowUserToDeleteRows = false;
            this.dtOrdenaViv.BackgroundColor = System.Drawing.Color.White;
            this.dtOrdenaViv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtOrdenaViv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ValorAgregado,
            this.Orden});
            this.dtOrdenaViv.Location = new System.Drawing.Point(16, 54);
            this.dtOrdenaViv.Name = "dtOrdenaViv";
            this.dtOrdenaViv.Size = new System.Drawing.Size(340, 164);
            this.dtOrdenaViv.TabIndex = 18;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.Transparent;
            this.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.Color.Black;
            this.btnEnviar.Location = new System.Drawing.Point(151, 224);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(66, 27);
            this.btnEnviar.TabIndex = 19;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // ValorAgregado
            // 
            this.ValorAgregado.HeaderText = "ValorAgregado";
            this.ValorAgregado.Name = "ValorAgregado";
            this.ValorAgregado.ReadOnly = true;
            this.ValorAgregado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ValorAgregado.Width = 145;
            // 
            // Orden
            // 
            this.Orden.HeaderText = "Orden";
            this.Orden.Name = "Orden";
            this.Orden.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Orden.Width = 145;
            // 
            // MPntOrdenaViviendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(368, 259);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.dtOrdenaViv);
            this.Controls.Add(this.groupManzana);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MPntOrdenaViviendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ordenar Viviendas";
            this.Load += new System.EventHandler(this.MPntOrdenaViviendas_Load);
            this.groupManzana.ResumeLayout(false);
            this.groupManzana.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtOrdenaViv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton BtnRadioNI;
        private System.Windows.Forms.GroupBox groupManzana;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton btnRadioPiso;
        private System.Windows.Forms.DataGridView dtOrdenaViv;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorAgregado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orden;
    }
}