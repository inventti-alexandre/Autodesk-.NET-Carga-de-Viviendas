namespace PluginInsViviendas_UNO.Vista.Unifamiliar
{
    partial class UDatosFinales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UDatosFinales));
            this.dtDatosFinales = new System.Windows.Forms.DataGridView();
            this.Manzana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoOficial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoInterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M2Superficie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuperfloteTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M2Excedente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M2Construccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VivVerde = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Muestra = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Disponible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Cablevision = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chkVivVerdefull = new System.Windows.Forms.CheckBox();
            this.chkMuestrafull = new System.Windows.Forms.CheckBox();
            this.chkDisponiblefull = new System.Windows.Forms.CheckBox();
            this.chkCablefull = new System.Windows.Forms.CheckBox();
            this.lblPrototipo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblResPrototipo = new System.Windows.Forms.Label();
            this.lblResFideicomiso = new System.Windows.Forms.Label();
            this.lblFideicomiso = new System.Windows.Forms.Label();
            this.lblResFrente = new System.Windows.Forms.Label();
            this.lblFrente = new System.Windows.Forms.Label();
            this.lblResFracc = new System.Windows.Forms.Label();
            this.lblFraccionamiento = new System.Windows.Forms.Label();
            this.lblResConjunto = new System.Windows.Forms.Label();
            this.lblConjunto = new System.Windows.Forms.Label();
            this.lblHOME = new System.Windows.Forms.Label();
            this.btnCargaVivs = new System.Windows.Forms.Button();
            this.gpPasos = new System.Windows.Forms.GroupBox();
            this.checkM2Cons = new System.Windows.Forms.CheckBox();
            this.checkExcedente = new System.Windows.Forms.CheckBox();
            this.checkSFT = new System.Windows.Forms.CheckBox();
            this.lblpaso3 = new System.Windows.Forms.Label();
            this.lblpaso2 = new System.Windows.Forms.Label();
            this.lblpaso1 = new System.Windows.Forms.Label();
            this.txtM2Const = new System.Windows.Forms.TextBox();
            this.bkWorker = new System.ComponentModel.BackgroundWorker();
            this.btnM2Const = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSuperFlote = new System.Windows.Forms.ComboBox();
            this.btnAsignSPFT = new System.Windows.Forms.Button();
            this.btnIrAtras = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatosFinales)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gpPasos.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dtDatosFinales
            // 
            this.dtDatosFinales.AllowUserToAddRows = false;
            this.dtDatosFinales.AllowUserToDeleteRows = false;
            this.dtDatosFinales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDatosFinales.BackgroundColor = System.Drawing.Color.White;
            this.dtDatosFinales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDatosFinales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Manzana,
            this.Lote,
            this.NoOficial,
            this.NoInterior,
            this.UP,
            this.Calle,
            this.M2Superficie,
            this.SuperfloteTipo,
            this.M2Excedente,
            this.M2Construccion,
            this.VivVerde,
            this.Muestra,
            this.Disponible,
            this.Cablevision});
            this.dtDatosFinales.GridColor = System.Drawing.Color.DarkGray;
            this.dtDatosFinales.Location = new System.Drawing.Point(12, 144);
            this.dtDatosFinales.Name = "dtDatosFinales";
            this.dtDatosFinales.Size = new System.Drawing.Size(1312, 236);
            this.dtDatosFinales.TabIndex = 0;
            // 
            // Manzana
            // 
            this.Manzana.HeaderText = "Manzana";
            this.Manzana.Name = "Manzana";
            this.Manzana.ReadOnly = true;
            this.Manzana.Width = 65;
            // 
            // Lote
            // 
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            this.Lote.ReadOnly = true;
            this.Lote.Width = 75;
            // 
            // NoOficial
            // 
            this.NoOficial.HeaderText = "No. Oficial";
            this.NoOficial.Name = "NoOficial";
            this.NoOficial.ReadOnly = true;
            this.NoOficial.Width = 75;
            // 
            // NoInterior
            // 
            this.NoInterior.HeaderText = "No. Interior";
            this.NoInterior.Name = "NoInterior";
            this.NoInterior.ReadOnly = true;
            this.NoInterior.Width = 75;
            // 
            // UP
            // 
            this.UP.HeaderText = "Unidad Privativa";
            this.UP.Name = "UP";
            this.UP.ReadOnly = true;
            // 
            // Calle
            // 
            this.Calle.HeaderText = "Calle";
            this.Calle.Name = "Calle";
            this.Calle.ReadOnly = true;
            this.Calle.Width = 175;
            // 
            // M2Superficie
            // 
            this.M2Superficie.HeaderText = "M2 Superficie";
            this.M2Superficie.Name = "M2Superficie";
            this.M2Superficie.ReadOnly = true;
            // 
            // SuperfloteTipo
            // 
            this.SuperfloteTipo.HeaderText = "Superficie Lote Tipo";
            this.SuperfloteTipo.Name = "SuperfloteTipo";
            this.SuperfloteTipo.ReadOnly = true;
            // 
            // M2Excedente
            // 
            this.M2Excedente.HeaderText = "M2 Excedente";
            this.M2Excedente.Name = "M2Excedente";
            this.M2Excedente.ReadOnly = true;
            this.M2Excedente.Width = 105;
            // 
            // M2Construccion
            // 
            this.M2Construccion.HeaderText = "M2 Construcción";
            this.M2Construccion.Name = "M2Construccion";
            this.M2Construccion.Width = 95;
            // 
            // VivVerde
            // 
            this.VivVerde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VivVerde.HeaderText = "Vivienda Verde";
            this.VivVerde.Name = "VivVerde";
            this.VivVerde.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VivVerde.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.VivVerde.Width = 75;
            // 
            // Muestra
            // 
            this.Muestra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Muestra.HeaderText = "Muestra";
            this.Muestra.Name = "Muestra";
            this.Muestra.Width = 75;
            // 
            // Disponible
            // 
            this.Disponible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Disponible.HeaderText = "Disponible";
            this.Disponible.Name = "Disponible";
            this.Disponible.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Disponible.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Disponible.Width = 75;
            // 
            // Cablevision
            // 
            this.Cablevision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cablevision.HeaderText = "Cablevisión";
            this.Cablevision.Name = "Cablevision";
            this.Cablevision.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cablevision.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Cablevision.Width = 75;
            // 
            // chkVivVerdefull
            // 
            this.chkVivVerdefull.AutoSize = true;
            this.chkVivVerdefull.BackColor = System.Drawing.Color.Transparent;
            this.chkVivVerdefull.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVivVerdefull.Location = new System.Drawing.Point(1051, 127);
            this.chkVivVerdefull.Name = "chkVivVerdefull";
            this.chkVivVerdefull.Size = new System.Drawing.Size(12, 11);
            this.chkVivVerdefull.TabIndex = 1;
            this.chkVivVerdefull.UseVisualStyleBackColor = false;
            this.chkVivVerdefull.CheckedChanged += new System.EventHandler(this.chkVivVerdefull_CheckedChanged);
            this.chkVivVerdefull.MouseHover += new System.EventHandler(this.chkVivVerdefull_MouseHover);
            // 
            // chkMuestrafull
            // 
            this.chkMuestrafull.AutoSize = true;
            this.chkMuestrafull.BackColor = System.Drawing.Color.Transparent;
            this.chkMuestrafull.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMuestrafull.Location = new System.Drawing.Point(1125, 127);
            this.chkMuestrafull.Name = "chkMuestrafull";
            this.chkMuestrafull.Size = new System.Drawing.Size(12, 11);
            this.chkMuestrafull.TabIndex = 1;
            this.chkMuestrafull.UseVisualStyleBackColor = false;
            this.chkMuestrafull.CheckedChanged += new System.EventHandler(this.chkMuestrafull_CheckedChanged);
            this.chkMuestrafull.MouseHover += new System.EventHandler(this.chkMuestrafull_MouseHover);
            // 
            // chkDisponiblefull
            // 
            this.chkDisponiblefull.AutoSize = true;
            this.chkDisponiblefull.BackColor = System.Drawing.Color.Transparent;
            this.chkDisponiblefull.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDisponiblefull.Location = new System.Drawing.Point(1198, 127);
            this.chkDisponiblefull.Name = "chkDisponiblefull";
            this.chkDisponiblefull.Size = new System.Drawing.Size(12, 11);
            this.chkDisponiblefull.TabIndex = 1;
            this.chkDisponiblefull.UseVisualStyleBackColor = false;
            this.chkDisponiblefull.CheckedChanged += new System.EventHandler(this.chkDisponiblefull_CheckedChanged);
            this.chkDisponiblefull.MouseHover += new System.EventHandler(this.chkDisponiblefull_MouseHover);
            // 
            // chkCablefull
            // 
            this.chkCablefull.AutoSize = true;
            this.chkCablefull.BackColor = System.Drawing.Color.Transparent;
            this.chkCablefull.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCablefull.Location = new System.Drawing.Point(1274, 127);
            this.chkCablefull.Name = "chkCablefull";
            this.chkCablefull.Size = new System.Drawing.Size(12, 11);
            this.chkCablefull.TabIndex = 1;
            this.chkCablefull.UseVisualStyleBackColor = false;
            this.chkCablefull.CheckedChanged += new System.EventHandler(this.chkCablefull_CheckedChanged);
            this.chkCablefull.MouseHover += new System.EventHandler(this.chkCablefull_MouseHover);
            // 
            // lblPrototipo
            // 
            this.lblPrototipo.AutoSize = true;
            this.lblPrototipo.BackColor = System.Drawing.Color.Transparent;
            this.lblPrototipo.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrototipo.ForeColor = System.Drawing.Color.Black;
            this.lblPrototipo.Location = new System.Drawing.Point(359, 54);
            this.lblPrototipo.Name = "lblPrototipo";
            this.lblPrototipo.Size = new System.Drawing.Size(69, 17);
            this.lblPrototipo.TabIndex = 5;
            this.lblPrototipo.Text = "Prototipo:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblResPrototipo);
            this.groupBox1.Controls.Add(this.lblResFideicomiso);
            this.groupBox1.Controls.Add(this.lblFideicomiso);
            this.groupBox1.Controls.Add(this.lblResFrente);
            this.groupBox1.Controls.Add(this.lblFrente);
            this.groupBox1.Controls.Add(this.lblResFracc);
            this.groupBox1.Controls.Add(this.lblFraccionamiento);
            this.groupBox1.Controls.Add(this.lblResConjunto);
            this.groupBox1.Controls.Add(this.lblConjunto);
            this.groupBox1.Controls.Add(this.lblPrototipo);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 128);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales";
            // 
            // lblResPrototipo
            // 
            this.lblResPrototipo.AutoSize = true;
            this.lblResPrototipo.BackColor = System.Drawing.Color.Transparent;
            this.lblResPrototipo.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResPrototipo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblResPrototipo.Location = new System.Drawing.Point(425, 54);
            this.lblResPrototipo.Name = "lblResPrototipo";
            this.lblResPrototipo.Size = new System.Drawing.Size(73, 17);
            this.lblResPrototipo.TabIndex = 5;
            this.lblResPrototipo.Text = "Sin Asignar";
            // 
            // lblResFideicomiso
            // 
            this.lblResFideicomiso.AutoSize = true;
            this.lblResFideicomiso.BackColor = System.Drawing.Color.Transparent;
            this.lblResFideicomiso.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResFideicomiso.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblResFideicomiso.Location = new System.Drawing.Point(425, 24);
            this.lblResFideicomiso.Name = "lblResFideicomiso";
            this.lblResFideicomiso.Size = new System.Drawing.Size(73, 17);
            this.lblResFideicomiso.TabIndex = 5;
            this.lblResFideicomiso.Text = "Sin Asignar";
            // 
            // lblFideicomiso
            // 
            this.lblFideicomiso.AutoSize = true;
            this.lblFideicomiso.BackColor = System.Drawing.Color.Transparent;
            this.lblFideicomiso.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFideicomiso.ForeColor = System.Drawing.Color.Black;
            this.lblFideicomiso.Location = new System.Drawing.Point(347, 24);
            this.lblFideicomiso.Name = "lblFideicomiso";
            this.lblFideicomiso.Size = new System.Drawing.Size(81, 17);
            this.lblFideicomiso.TabIndex = 5;
            this.lblFideicomiso.Text = "Fideicomiso:";
            // 
            // lblResFrente
            // 
            this.lblResFrente.AutoSize = true;
            this.lblResFrente.BackColor = System.Drawing.Color.Transparent;
            this.lblResFrente.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResFrente.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblResFrente.Location = new System.Drawing.Point(133, 54);
            this.lblResFrente.Name = "lblResFrente";
            this.lblResFrente.Size = new System.Drawing.Size(73, 17);
            this.lblResFrente.TabIndex = 5;
            this.lblResFrente.Text = "Sin Asignar";
            // 
            // lblFrente
            // 
            this.lblFrente.AutoSize = true;
            this.lblFrente.BackColor = System.Drawing.Color.Transparent;
            this.lblFrente.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrente.ForeColor = System.Drawing.Color.Black;
            this.lblFrente.Location = new System.Drawing.Point(17, 54);
            this.lblFrente.Name = "lblFrente";
            this.lblFrente.Size = new System.Drawing.Size(50, 17);
            this.lblFrente.TabIndex = 5;
            this.lblFrente.Text = "Frente:";
            // 
            // lblResFracc
            // 
            this.lblResFracc.AutoSize = true;
            this.lblResFracc.BackColor = System.Drawing.Color.Transparent;
            this.lblResFracc.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResFracc.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblResFracc.Location = new System.Drawing.Point(133, 24);
            this.lblResFracc.Name = "lblResFracc";
            this.lblResFracc.Size = new System.Drawing.Size(73, 17);
            this.lblResFracc.TabIndex = 5;
            this.lblResFracc.Text = "Sin Asignar";
            // 
            // lblFraccionamiento
            // 
            this.lblFraccionamiento.AutoSize = true;
            this.lblFraccionamiento.BackColor = System.Drawing.Color.Transparent;
            this.lblFraccionamiento.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFraccionamiento.ForeColor = System.Drawing.Color.Black;
            this.lblFraccionamiento.Location = new System.Drawing.Point(17, 24);
            this.lblFraccionamiento.Name = "lblFraccionamiento";
            this.lblFraccionamiento.Size = new System.Drawing.Size(110, 17);
            this.lblFraccionamiento.TabIndex = 5;
            this.lblFraccionamiento.Text = "Fraccionamiento:";
            // 
            // lblResConjunto
            // 
            this.lblResConjunto.AutoSize = true;
            this.lblResConjunto.BackColor = System.Drawing.Color.Transparent;
            this.lblResConjunto.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResConjunto.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblResConjunto.Location = new System.Drawing.Point(133, 84);
            this.lblResConjunto.Name = "lblResConjunto";
            this.lblResConjunto.Size = new System.Drawing.Size(73, 17);
            this.lblResConjunto.TabIndex = 5;
            this.lblResConjunto.Text = "Sin Asignar";
            // 
            // lblConjunto
            // 
            this.lblConjunto.AutoSize = true;
            this.lblConjunto.BackColor = System.Drawing.Color.Transparent;
            this.lblConjunto.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConjunto.ForeColor = System.Drawing.Color.Black;
            this.lblConjunto.Location = new System.Drawing.Point(17, 84);
            this.lblConjunto.Name = "lblConjunto";
            this.lblConjunto.Size = new System.Drawing.Size(71, 17);
            this.lblConjunto.TabIndex = 5;
            this.lblConjunto.Text = "Conjunto: ";
            // 
            // lblHOME
            // 
            this.lblHOME.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHOME.AutoSize = true;
            this.lblHOME.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHOME.Location = new System.Drawing.Point(54, 399);
            this.lblHOME.Name = "lblHOME";
            this.lblHOME.Size = new System.Drawing.Size(36, 15);
            this.lblHOME.TabIndex = 10;
            this.lblHOME.Text = "Atrás";
            // 
            // btnCargaVivs
            // 
            this.btnCargaVivs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargaVivs.BackColor = System.Drawing.Color.Transparent;
            this.btnCargaVivs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnCargaVivs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargaVivs.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargaVivs.ForeColor = System.Drawing.Color.Black;
            this.btnCargaVivs.Location = new System.Drawing.Point(1215, 395);
            this.btnCargaVivs.Name = "btnCargaVivs";
            this.btnCargaVivs.Size = new System.Drawing.Size(109, 27);
            this.btnCargaVivs.TabIndex = 12;
            this.btnCargaVivs.Text = "Cargar Viviendas";
            this.btnCargaVivs.UseVisualStyleBackColor = false;
            this.btnCargaVivs.Click += new System.EventHandler(this.btnCargaVivs_Click);
            // 
            // gpPasos
            // 
            this.gpPasos.BackColor = System.Drawing.Color.Transparent;
            this.gpPasos.Controls.Add(this.checkM2Cons);
            this.gpPasos.Controls.Add(this.checkExcedente);
            this.gpPasos.Controls.Add(this.checkSFT);
            this.gpPasos.Controls.Add(this.lblpaso3);
            this.gpPasos.Controls.Add(this.lblpaso2);
            this.gpPasos.Controls.Add(this.lblpaso1);
            this.gpPasos.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpPasos.ForeColor = System.Drawing.Color.SteelBlue;
            this.gpPasos.Location = new System.Drawing.Point(622, 12);
            this.gpPasos.Name = "gpPasos";
            this.gpPasos.Size = new System.Drawing.Size(242, 83);
            this.gpPasos.TabIndex = 13;
            this.gpPasos.TabStop = false;
            this.gpPasos.Text = "Pasos";
            // 
            // checkM2Cons
            // 
            this.checkM2Cons.AutoSize = true;
            this.checkM2Cons.BackColor = System.Drawing.Color.Transparent;
            this.checkM2Cons.Enabled = false;
            this.checkM2Cons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkM2Cons.ForeColor = System.Drawing.Color.Green;
            this.checkM2Cons.Location = new System.Drawing.Point(197, 58);
            this.checkM2Cons.Name = "checkM2Cons";
            this.checkM2Cons.Size = new System.Drawing.Size(12, 11);
            this.checkM2Cons.TabIndex = 14;
            this.checkM2Cons.UseVisualStyleBackColor = false;
            // 
            // checkExcedente
            // 
            this.checkExcedente.AutoSize = true;
            this.checkExcedente.BackColor = System.Drawing.Color.Transparent;
            this.checkExcedente.Enabled = false;
            this.checkExcedente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkExcedente.ForeColor = System.Drawing.Color.Green;
            this.checkExcedente.Location = new System.Drawing.Point(197, 39);
            this.checkExcedente.Name = "checkExcedente";
            this.checkExcedente.Size = new System.Drawing.Size(12, 11);
            this.checkExcedente.TabIndex = 14;
            this.checkExcedente.UseVisualStyleBackColor = false;
            // 
            // checkSFT
            // 
            this.checkSFT.AutoSize = true;
            this.checkSFT.BackColor = System.Drawing.Color.Transparent;
            this.checkSFT.Enabled = false;
            this.checkSFT.FlatAppearance.BorderSize = 0;
            this.checkSFT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkSFT.ForeColor = System.Drawing.Color.Green;
            this.checkSFT.Location = new System.Drawing.Point(197, 19);
            this.checkSFT.Name = "checkSFT";
            this.checkSFT.Size = new System.Drawing.Size(12, 11);
            this.checkSFT.TabIndex = 14;
            this.checkSFT.UseVisualStyleBackColor = false;
            // 
            // lblpaso3
            // 
            this.lblpaso3.AutoSize = true;
            this.lblpaso3.BackColor = System.Drawing.Color.Transparent;
            this.lblpaso3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpaso3.ForeColor = System.Drawing.Color.Black;
            this.lblpaso3.Location = new System.Drawing.Point(6, 58);
            this.lblpaso3.Name = "lblpaso3";
            this.lblpaso3.Size = new System.Drawing.Size(163, 14);
            this.lblpaso3.TabIndex = 5;
            this.lblpaso3.Text = "3. Introducir M2 Construcción";
            // 
            // lblpaso2
            // 
            this.lblpaso2.AutoSize = true;
            this.lblpaso2.BackColor = System.Drawing.Color.Transparent;
            this.lblpaso2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpaso2.ForeColor = System.Drawing.Color.Black;
            this.lblpaso2.Location = new System.Drawing.Point(6, 39);
            this.lblpaso2.Name = "lblpaso2";
            this.lblpaso2.Size = new System.Drawing.Size(140, 14);
            this.lblpaso2.TabIndex = 5;
            this.lblpaso2.Text = "2. Calcular M2 Excedente";
            // 
            // lblpaso1
            // 
            this.lblpaso1.AutoSize = true;
            this.lblpaso1.BackColor = System.Drawing.Color.Transparent;
            this.lblpaso1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpaso1.ForeColor = System.Drawing.Color.Black;
            this.lblpaso1.Location = new System.Drawing.Point(6, 19);
            this.lblpaso1.Name = "lblpaso1";
            this.lblpaso1.Size = new System.Drawing.Size(185, 14);
            this.lblpaso1.TabIndex = 5;
            this.lblpaso1.Text = "1. Asignación de SuperFlote Tipo";
            // 
            // txtM2Const
            // 
            this.txtM2Const.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtM2Const.Location = new System.Drawing.Point(935, 117);
            this.txtM2Const.Name = "txtM2Const";
            this.txtM2Const.Size = new System.Drawing.Size(49, 22);
            this.txtM2Const.TabIndex = 14;
            this.txtM2Const.MouseHover += new System.EventHandler(this.txtM2Const_MouseHover);
            // 
            // bkWorker
            // 
            this.bkWorker.WorkerReportsProgress = true;
            // 
            // btnM2Const
            // 
            this.btnM2Const.BackColor = System.Drawing.Color.Transparent;
            this.btnM2Const.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.btndown;
            this.btnM2Const.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnM2Const.FlatAppearance.BorderSize = 0;
            this.btnM2Const.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnM2Const.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnM2Const.Location = new System.Drawing.Point(984, 116);
            this.btnM2Const.Name = "btnM2Const";
            this.btnM2Const.Size = new System.Drawing.Size(26, 23);
            this.btnM2Const.TabIndex = 15;
            this.btnM2Const.UseVisualStyleBackColor = false;
            this.btnM2Const.Click += new System.EventHandler(this.btnM2Const_Click);
            this.btnM2Const.MouseHover += new System.EventHandler(this.btnM2Const_MouseHover);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbSuperFlote);
            this.groupBox2.Controls.Add(this.btnAsignSPFT);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox2.Location = new System.Drawing.Point(622, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 44);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Superf. lote Tipo:";
            // 
            // cmbSuperFlote
            // 
            this.cmbSuperFlote.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbSuperFlote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuperFlote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSuperFlote.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSuperFlote.FormattingEnabled = true;
            this.cmbSuperFlote.Location = new System.Drawing.Point(100, 13);
            this.cmbSuperFlote.Name = "cmbSuperFlote";
            this.cmbSuperFlote.Size = new System.Drawing.Size(61, 22);
            this.cmbSuperFlote.TabIndex = 22;
            this.cmbSuperFlote.SelectedIndexChanged += new System.EventHandler(this.cmbSuperFlote_SelectedIndexChanged);
            this.cmbSuperFlote.MouseHover += new System.EventHandler(this.cmbSuperFlote_MouseHover);
            // 
            // btnAsignSPFT
            // 
            this.btnAsignSPFT.BackColor = System.Drawing.Color.Transparent;
            this.btnAsignSPFT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignSPFT.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignSPFT.ForeColor = System.Drawing.Color.Black;
            this.btnAsignSPFT.Location = new System.Drawing.Point(167, 13);
            this.btnAsignSPFT.Name = "btnAsignSPFT";
            this.btnAsignSPFT.Size = new System.Drawing.Size(64, 21);
            this.btnAsignSPFT.TabIndex = 31;
            this.btnAsignSPFT.Text = "Selección";
            this.btnAsignSPFT.UseVisualStyleBackColor = false;
            this.btnAsignSPFT.Click += new System.EventHandler(this.btnAsignSPFT_Click);
            // 
            // btnIrAtras
            // 
            this.btnIrAtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIrAtras.BackColor = System.Drawing.Color.Transparent;
            this.btnIrAtras.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources._1468633294_back;
            this.btnIrAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIrAtras.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnIrAtras.FlatAppearance.BorderSize = 0;
            this.btnIrAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIrAtras.Location = new System.Drawing.Point(12, 386);
            this.btnIrAtras.Name = "btnIrAtras";
            this.btnIrAtras.Size = new System.Drawing.Size(43, 40);
            this.btnIrAtras.TabIndex = 36;
            this.btnIrAtras.UseVisualStyleBackColor = false;
            this.btnIrAtras.Click += new System.EventHandler(this.BtnAtras_Click);
            // 
            // btnHome
            // 
            this.btnHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.btnHome;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Location = new System.Drawing.Point(1281, 12);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(43, 40);
            this.btnHome.TabIndex = 37;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox3.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(667, 388);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 10);
            this.pictureBox3.TabIndex = 40;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(758, 388);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 10);
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(698, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 14);
            this.label8.TabIndex = 38;
            this.label8.Text = "Sin Datos";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(579, 386);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 14);
            this.label7.TabIndex = 39;
            this.label7.Text = "Dato Númerico";
            // 
            // UDatosFinales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1356, 428);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnIrAtras);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnM2Const);
            this.Controls.Add(this.txtM2Const);
            this.Controls.Add(this.gpPasos);
            this.Controls.Add(this.btnCargaVivs);
            this.Controls.Add(this.lblHOME);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkCablefull);
            this.Controls.Add(this.chkDisponiblefull);
            this.Controls.Add(this.chkMuestrafull);
            this.Controls.Add(this.chkVivVerdefull);
            this.Controls.Add(this.dtDatosFinales);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UDatosFinales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Complemento de Datos Finales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatosFinales_FormClosing);
            this.Load += new System.EventHandler(this.DatosFinales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtDatosFinales)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpPasos.ResumeLayout(false);
            this.gpPasos.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtDatosFinales;
        private System.Windows.Forms.CheckBox chkVivVerdefull;
        private System.Windows.Forms.CheckBox chkMuestrafull;
        private System.Windows.Forms.CheckBox chkDisponiblefull;
        private System.Windows.Forms.CheckBox chkCablefull;
        private System.Windows.Forms.Label lblPrototipo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblResPrototipo;
        private System.Windows.Forms.Label lblResFrente;
        private System.Windows.Forms.Label lblFrente;
        private System.Windows.Forms.Label lblResFracc;
        private System.Windows.Forms.Label lblFraccionamiento;
        private System.Windows.Forms.Label lblHOME;
        private System.Windows.Forms.Button btnCargaVivs;
        private System.Windows.Forms.Label lblResConjunto;
        private System.Windows.Forms.Label lblConjunto;
        private System.Windows.Forms.Label lblResFideicomiso;
        private System.Windows.Forms.Label lblFideicomiso;
        private System.Windows.Forms.GroupBox gpPasos;
        private System.Windows.Forms.Label lblpaso1;
        private System.Windows.Forms.Label lblpaso2;
        private System.Windows.Forms.Label lblpaso3;
        private System.Windows.Forms.CheckBox checkSFT;
        private System.Windows.Forms.CheckBox checkM2Cons;
        private System.Windows.Forms.CheckBox checkExcedente;
        private System.Windows.Forms.TextBox txtM2Const;
        public System.ComponentModel.BackgroundWorker bkWorker;
        private System.Windows.Forms.Button btnM2Const;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSuperFlote;
        private System.Windows.Forms.Button btnAsignSPFT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manzana;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoOficial;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoInterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn UP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calle;
        private System.Windows.Forms.DataGridViewTextBoxColumn M2Superficie;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuperfloteTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn M2Excedente;
        private System.Windows.Forms.DataGridViewTextBoxColumn M2Construccion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VivVerde;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Muestra;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Disponible;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cablevision;
        private System.Windows.Forms.Button btnIrAtras;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}