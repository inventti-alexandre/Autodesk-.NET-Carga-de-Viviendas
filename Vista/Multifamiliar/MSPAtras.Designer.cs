namespace PluginInsViviendas_UNO.Vista.Multifamiliar
{
    partial class MSPAtras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MSPAtras));
            this.btnIrAtras = new System.Windows.Forms.Button();
            this.btnIrHome = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIrAtras
            // 
            this.btnIrAtras.BackColor = System.Drawing.Color.Transparent;
            this.btnIrAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIrAtras.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIrAtras.ForeColor = System.Drawing.Color.Black;
            this.btnIrAtras.Location = new System.Drawing.Point(21, 39);
            this.btnIrAtras.Name = "btnIrAtras";
            this.btnIrAtras.Size = new System.Drawing.Size(66, 27);
            this.btnIrAtras.TabIndex = 1;
            this.btnIrAtras.Text = "Ir Atrás";
            this.btnIrAtras.UseVisualStyleBackColor = false;
            this.btnIrAtras.Click += new System.EventHandler(this.btnIrAtras_Click);
            // 
            // btnIrHome
            // 
            this.btnIrHome.BackColor = System.Drawing.Color.Transparent;
            this.btnIrHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIrHome.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIrHome.ForeColor = System.Drawing.Color.Black;
            this.btnIrHome.Location = new System.Drawing.Point(113, 39);
            this.btnIrHome.Name = "btnIrHome";
            this.btnIrHome.Size = new System.Drawing.Size(66, 27);
            this.btnIrHome.TabIndex = 1;
            this.btnIrHome.Text = "Inicio";
            this.btnIrHome.UseVisualStyleBackColor = false;
            this.btnIrHome.Click += new System.EventHandler(this.btnIrHome_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione Módulo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "*Se perderán los datos introducidos";
            // 
            // MSPAtras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(203, 98);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIrHome);
            this.Controls.Add(this.btnIrAtras);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MSPAtras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ir Atrás";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MSPAtras_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIrAtras;
        private System.Windows.Forms.Button btnIrHome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}