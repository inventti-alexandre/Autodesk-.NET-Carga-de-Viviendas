namespace PluginInsViviendas_UNO.Vista
{
    partial class BitacoraErrores
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
            this.listBitacora = new System.Windows.Forms.ListBox();
            this.txtNomCapa = new System.Windows.Forms.TextBox();
            this.cmbCapas = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAsignaF = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.PictureBox();
            this.btnClear = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            this.SuspendLayout();
            // 
            // listBitacora
            // 
            this.listBitacora.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBitacora.FormattingEnabled = true;
            this.listBitacora.ItemHeight = 15;
            this.listBitacora.Location = new System.Drawing.Point(18, 101);
            this.listBitacora.Name = "listBitacora";
            this.listBitacora.Size = new System.Drawing.Size(451, 79);
            this.listBitacora.TabIndex = 0;
            // 
            // txtNomCapa
            // 
            this.txtNomCapa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomCapa.Enabled = false;
            this.txtNomCapa.Location = new System.Drawing.Point(172, 20);
            this.txtNomCapa.Name = "txtNomCapa";
            this.txtNomCapa.Size = new System.Drawing.Size(241, 23);
            this.txtNomCapa.TabIndex = 2;
            // 
            // cmbCapas
            // 
            this.cmbCapas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCapas.FormattingEnabled = true;
            this.cmbCapas.Items.AddRange(new object[] {
            "Manzana",
            "Direcciones",
            "Viviendas",
            "Lote",
            "Número Interior",
            "Número Oficial",
            "Unidad Privativa",
            "Factor de Detección"});
            this.cmbCapas.Location = new System.Drawing.Point(6, 20);
            this.cmbCapas.Name = "cmbCapas";
            this.cmbCapas.Size = new System.Drawing.Size(160, 23);
            this.cmbCapas.TabIndex = 3;
            this.cmbCapas.SelectedIndexChanged += new System.EventHandler(this.cmbCapas_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnAsignaF);
            this.groupBox1.Controls.Add(this.cmbCapas);
            this.groupBox1.Controls.Add(this.txtNomCapa);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 52);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Capas AUTODESK";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnAsignaF
            // 
            this.btnAsignaF.BackColor = System.Drawing.Color.Transparent;
            this.btnAsignaF.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.uploaded2;
            this.btnAsignaF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAsignaF.FlatAppearance.BorderSize = 0;
            this.btnAsignaF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnAsignaF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignaF.Location = new System.Drawing.Point(422, 18);
            this.btnAsignaF.Name = "btnAsignaF";
            this.btnAsignaF.Size = new System.Drawing.Size(29, 25);
            this.btnAsignaF.TabIndex = 12;
            this.btnAsignaF.UseVisualStyleBackColor = false;
            this.btnAsignaF.Visible = false;
            this.btnAsignaF.Click += new System.EventHandler(this.btnAsignaF_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.BackColor = System.Drawing.Color.Transparent;
            this.btnCopy.Image = global::PluginInsViviendas_UNO.Properties.Resources.copy;
            this.btnCopy.Location = new System.Drawing.Point(20, 70);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(29, 25);
            this.btnCopy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCopy.TabIndex = 10;
            this.btnCopy.TabStop = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.Image = global::PluginInsViviendas_UNO.Properties.Resources.clear_list;
            this.btnClear.Location = new System.Drawing.Point(55, 70);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(29, 25);
            this.btnClear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClear.TabIndex = 9;
            this.btnClear.TabStop = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // BitacoraErrores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(481, 192);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.listBitacora);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "BitacoraErrores";
            this.Text = "Bitácora";
            this.Load += new System.EventHandler(this.BitacoraErrores_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox listBitacora;
        private System.Windows.Forms.TextBox txtNomCapa;
        private System.Windows.Forms.ComboBox cmbCapas;
        private System.Windows.Forms.PictureBox btnClear;
        private System.Windows.Forms.PictureBox btnCopy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAsignaF;

    }
}