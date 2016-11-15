namespace PluginInsViviendas_UNO.Vista.Multifamiliar
{
    partial class MBtViviendasError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MBtViviendasError));
            this.lblnota = new System.Windows.Forms.Label();
            this.btnCargarNuevo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpRegresar = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSelDatos = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.IDArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conjunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prototipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoOficial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoInterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manzana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fraccionamiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtErrores = new System.Windows.Forms.DataGridView();
            this.bkWorker = new System.ComponentModel.BackgroundWorker();
            this.loadingExport = new System.Windows.Forms.PictureBox();
            this.lblExportando = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.gpRegresar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtErrores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingExport)).BeginInit();
            this.SuspendLayout();
            // 
            // lblnota
            // 
            this.lblnota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblnota.AutoSize = true;
            this.lblnota.BackColor = System.Drawing.Color.Transparent;
            this.lblnota.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnota.Location = new System.Drawing.Point(578, 66);
            this.lblnota.Name = "lblnota";
            this.lblnota.Size = new System.Drawing.Size(232, 14);
            this.lblnota.TabIndex = 20;
            this.lblnota.Text = "* Favor de no tener otro archivo Excel abierto";
            // 
            // btnCargarNuevo
            // 
            this.btnCargarNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargarNuevo.BackColor = System.Drawing.Color.Transparent;
            this.btnCargarNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnCargarNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarNuevo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarNuevo.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnCargarNuevo.Location = new System.Drawing.Point(18, 21);
            this.btnCargarNuevo.Name = "btnCargarNuevo";
            this.btnCargarNuevo.Size = new System.Drawing.Size(148, 27);
            this.btnCargarNuevo.TabIndex = 13;
            this.btnCargarNuevo.Text = "Cargar Nuevo Conjunto";
            this.btnCargarNuevo.UseVisualStyleBackColor = false;
            this.btnCargarNuevo.Click += new System.EventHandler(this.btnCargarNuevo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnCargarNuevo);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(373, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(184, 65);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nuevo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Ir a módulo: ";
            // 
            // gpRegresar
            // 
            this.gpRegresar.BackColor = System.Drawing.Color.Transparent;
            this.gpRegresar.Controls.Add(this.label1);
            this.gpRegresar.Controls.Add(this.button1);
            this.gpRegresar.Controls.Add(this.btnSelDatos);
            this.gpRegresar.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpRegresar.Location = new System.Drawing.Point(10, 12);
            this.gpRegresar.Name = "gpRegresar";
            this.gpRegresar.Size = new System.Drawing.Size(357, 65);
            this.gpRegresar.TabIndex = 19;
            this.gpRegresar.TabStop = false;
            this.gpRegresar.Text = "Corregir Viviendas";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.SteelBlue;
            this.button1.Location = new System.Drawing.Point(233, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 27);
            this.button1.TabIndex = 13;
            this.button1.Text = "Complemento";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSelDatos
            // 
            this.btnSelDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelDatos.BackColor = System.Drawing.Color.Transparent;
            this.btnSelDatos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnSelDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelDatos.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelDatos.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnSelDatos.Location = new System.Drawing.Point(98, 19);
            this.btnSelDatos.Name = "btnSelDatos";
            this.btnSelDatos.Size = new System.Drawing.Size(129, 27);
            this.btnSelDatos.TabIndex = 13;
            this.btnSelDatos.Text = "Selección de Datos";
            this.btnSelDatos.UseVisualStyleBackColor = false;
            this.btnSelDatos.Click += new System.EventHandler(this.btnSelDatos_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnExcel.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.ExcelExport;
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Location = new System.Drawing.Point(770, 20);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(40, 40);
            this.btnExcel.TabIndex = 17;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // IDArchivo
            // 
            this.IDArchivo.HeaderText = "ID Archivo";
            this.IDArchivo.Name = "IDArchivo";
            this.IDArchivo.ReadOnly = true;
            // 
            // Conjunto
            // 
            this.Conjunto.HeaderText = "Conjunto";
            this.Conjunto.Name = "Conjunto";
            this.Conjunto.ReadOnly = true;
            // 
            // Frente
            // 
            this.Frente.HeaderText = "Frente";
            this.Frente.Name = "Frente";
            this.Frente.ReadOnly = true;
            // 
            // Prototipo
            // 
            this.Prototipo.HeaderText = "Prototipo";
            this.Prototipo.Name = "Prototipo";
            this.Prototipo.ReadOnly = true;
            // 
            // FechaCarga
            // 
            this.FechaCarga.HeaderText = "Fecha de Carga";
            this.FechaCarga.Name = "FechaCarga";
            this.FechaCarga.ReadOnly = true;
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Dirección";
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            // 
            // NoOficial
            // 
            this.NoOficial.HeaderText = "Número Oficial";
            this.NoOficial.Name = "NoOficial";
            this.NoOficial.ReadOnly = true;
            this.NoOficial.Width = 80;
            // 
            // NoInterior
            // 
            this.NoInterior.HeaderText = "Número Interior";
            this.NoInterior.Name = "NoInterior";
            this.NoInterior.ReadOnly = true;
            this.NoInterior.Width = 80;
            // 
            // NoLote
            // 
            this.NoLote.HeaderText = "Número Lote";
            this.NoLote.Name = "NoLote";
            this.NoLote.ReadOnly = true;
            this.NoLote.Width = 80;
            // 
            // Manzana
            // 
            this.Manzana.HeaderText = "Manzana";
            this.Manzana.Name = "Manzana";
            this.Manzana.ReadOnly = true;
            this.Manzana.Width = 80;
            // 
            // Error
            // 
            this.Error.HeaderText = "Resultado";
            this.Error.Name = "Error";
            this.Error.ReadOnly = true;
            this.Error.Width = 340;
            // 
            // Fraccionamiento
            // 
            this.Fraccionamiento.HeaderText = "Fraccionamiento";
            this.Fraccionamiento.Name = "Fraccionamiento";
            this.Fraccionamiento.ReadOnly = true;
            // 
            // dtErrores
            // 
            this.dtErrores.AllowUserToAddRows = false;
            this.dtErrores.AllowUserToDeleteRows = false;
            this.dtErrores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtErrores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtErrores.BackgroundColor = System.Drawing.Color.White;
            this.dtErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtErrores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Error,
            this.Manzana,
            this.NoLote,
            this.NoInterior,
            this.NoOficial,
            this.Direccion,
            this.FechaCarga,
            this.Prototipo,
            this.Fraccionamiento,
            this.Frente,
            this.Conjunto,
            this.IDArchivo});
            this.dtErrores.Location = new System.Drawing.Point(10, 86);
            this.dtErrores.Name = "dtErrores";
            this.dtErrores.ReadOnly = true;
            this.dtErrores.Size = new System.Drawing.Size(800, 261);
            this.dtErrores.TabIndex = 16;
            // 
            // loadingExport
            // 
            this.loadingExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingExport.BackColor = System.Drawing.Color.Transparent;
            this.loadingExport.Image = global::PluginInsViviendas_UNO.Properties.Resources.load_dots;
            this.loadingExport.Location = new System.Drawing.Point(720, 43);
            this.loadingExport.Name = "loadingExport";
            this.loadingExport.Size = new System.Drawing.Size(30, 10);
            this.loadingExport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingExport.TabIndex = 21;
            this.loadingExport.TabStop = false;
            this.loadingExport.Visible = false;
            // 
            // lblExportando
            // 
            this.lblExportando.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExportando.AutoSize = true;
            this.lblExportando.BackColor = System.Drawing.Color.Transparent;
            this.lblExportando.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportando.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblExportando.Location = new System.Drawing.Point(645, 38);
            this.lblExportando.Name = "lblExportando";
            this.lblExportando.Size = new System.Drawing.Size(79, 18);
            this.lblExportando.TabIndex = 20;
            this.lblExportando.Text = "Exportando";
            this.lblExportando.Visible = false;
            // 
            // MBtViviendasError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(824, 359);
            this.Controls.Add(this.loadingExport);
            this.Controls.Add(this.lblnota);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gpRegresar);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dtErrores);
            this.Controls.Add(this.lblExportando);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MBtViviendasError";
            this.Text = "Viviendas Enviadas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MBtViviendasError_FormClosing);
            this.Load += new System.EventHandler(this.MBtViviendasError_Load);
            this.groupBox2.ResumeLayout(false);
            this.gpRegresar.ResumeLayout(false);
            this.gpRegresar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtErrores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingExport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblnota;
        private System.Windows.Forms.Button btnCargarNuevo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpRegresar;
        private System.Windows.Forms.Button btnSelDatos;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conjunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prototipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoOficial;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoInterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manzana;
        private System.Windows.Forms.DataGridViewTextBoxColumn Error;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fraccionamiento;
        private System.Windows.Forms.DataGridView dtErrores;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker bkWorker;
        private System.Windows.Forms.PictureBox loadingExport;
        private System.Windows.Forms.Label lblExportando;
    }
}