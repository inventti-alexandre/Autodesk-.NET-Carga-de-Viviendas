namespace PluginInsViviendas_UNO.Vista.Multifamiliar
{
    partial class MSeleccionaPlano
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MSeleccionaPlano));
            this.dtDatosPlano = new System.Windows.Forms.DataGridView();
            this.IDPolLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDSistema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prototipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manzana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoOficial = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoInterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M2Superficie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadPrivativa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpFinSeleccion = new System.Windows.Forms.GroupBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBorrarTabla = new System.Windows.Forms.Button();
            this.btnSiguienteNull = new System.Windows.Forms.Button();
            this.btnLayerBitacora = new System.Windows.Forms.Button();
            this.btnRevelarId = new System.Windows.Forms.Button();
            this.btnViewRelation = new System.Windows.Forms.Button();
            this.lblDecimales = new System.Windows.Forms.Label();
            this.cmDecimales = new System.Windows.Forms.ComboBox();
            this.gpPaso4 = new System.Windows.Forms.GroupBox();
            this.btnOrdenar = new System.Windows.Forms.Button();
            this.lblOrd1 = new System.Windows.Forms.Label();
            this.groupDireccion = new System.Windows.Forms.GroupBox();
            this.btnSelDireccion = new System.Windows.Forms.Button();
            this.checkSD = new System.Windows.Forms.CheckBox();
            this.lblSelDireccion = new System.Windows.Forms.Label();
            this.btnCambiaDireccion = new System.Windows.Forms.Button();
            this.groupManzana = new System.Windows.Forms.GroupBox();
            this.btnSelManzana = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSelManzana = new System.Windows.Forms.Label();
            this.btnCambiaManzana = new System.Windows.Forms.Button();
            this.groupViviendas = new System.Windows.Forms.GroupBox();
            this.btnSelMultiple = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelUnica = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.lblManActual = new System.Windows.Forms.Label();
            this.setDireccionActual = new System.Windows.Forms.Label();
            this.lblDirActual = new System.Windows.Forms.Label();
            this.lblResViviendas = new System.Windows.Forms.Label();
            this.lblVivPndts = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.setManActual = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.setConjunto = new System.Windows.Forms.Label();
            this.lblConjunto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatosPlano)).BeginInit();
            this.gpFinSeleccion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpPaso4.SuspendLayout();
            this.groupDireccion.SuspendLayout();
            this.groupManzana.SuspendLayout();
            this.groupViviendas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // dtDatosPlano
            // 
            this.dtDatosPlano.AllowUserToAddRows = false;
            this.dtDatosPlano.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtDatosPlano.BackgroundColor = System.Drawing.Color.White;
            this.dtDatosPlano.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDatosPlano.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPolLote,
            this.IDSistema,
            this.Prototipo,
            this.Manzana,
            this.Lote,
            this.NoOficial,
            this.Piso,
            this.NoInterior,
            this.M2Superficie,
            this.UnidadPrivativa,
            this.Calle});
            this.dtDatosPlano.Location = new System.Drawing.Point(12, 169);
            this.dtDatosPlano.Name = "dtDatosPlano";
            this.dtDatosPlano.Size = new System.Drawing.Size(846, 217);
            this.dtDatosPlano.TabIndex = 19;
            this.dtDatosPlano.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtDatosPlano_RowsAdded);
            this.dtDatosPlano.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtDatosPlano_RowsRemoved);
            // 
            // IDPolLote
            // 
            this.IDPolLote.HeaderText = "ID Polilinea Lote";
            this.IDPolLote.Name = "IDPolLote";
            this.IDPolLote.ReadOnly = true;
            this.IDPolLote.Visible = false;
            // 
            // IDSistema
            // 
            this.IDSistema.HeaderText = "ID Polilinea Vivienda";
            this.IDSistema.Name = "IDSistema";
            this.IDSistema.ReadOnly = true;
            this.IDSistema.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IDSistema.Visible = false;
            this.IDSistema.Width = 130;
            // 
            // Prototipo
            // 
            this.Prototipo.HeaderText = "Prototipo";
            this.Prototipo.Name = "Prototipo";
            this.Prototipo.ReadOnly = true;
            this.Prototipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Prototipo.Width = 150;
            // 
            // Manzana
            // 
            this.Manzana.HeaderText = "Manzana";
            this.Manzana.Name = "Manzana";
            this.Manzana.ReadOnly = true;
            this.Manzana.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Manzana.Width = 70;
            // 
            // Lote
            // 
            this.Lote.HeaderText = "Lote";
            this.Lote.Name = "Lote";
            this.Lote.ReadOnly = true;
            this.Lote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Lote.Width = 70;
            // 
            // NoOficial
            // 
            this.NoOficial.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NoOficial.HeaderText = "No. Oficial";
            this.NoOficial.Name = "NoOficial";
            this.NoOficial.Width = 80;
            // 
            // Piso
            // 
            this.Piso.HeaderText = "Piso";
            this.Piso.Name = "Piso";
            this.Piso.ReadOnly = true;
            this.Piso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Piso.Width = 70;
            // 
            // NoInterior
            // 
            this.NoInterior.HeaderText = "No. Interior";
            this.NoInterior.Name = "NoInterior";
            this.NoInterior.ReadOnly = true;
            this.NoInterior.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NoInterior.Width = 90;
            // 
            // M2Superficie
            // 
            this.M2Superficie.HeaderText = "M2 Superficie";
            this.M2Superficie.Name = "M2Superficie";
            this.M2Superficie.ReadOnly = true;
            this.M2Superficie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.M2Superficie.Width = 110;
            // 
            // UnidadPrivativa
            // 
            this.UnidadPrivativa.HeaderText = "Unidad Privativa";
            this.UnidadPrivativa.Name = "UnidadPrivativa";
            this.UnidadPrivativa.ReadOnly = true;
            this.UnidadPrivativa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnidadPrivativa.Width = 120;
            // 
            // Calle
            // 
            this.Calle.HeaderText = "Calle";
            this.Calle.Name = "Calle";
            this.Calle.ReadOnly = true;
            this.Calle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Calle.Width = 140;
            // 
            // gpFinSeleccion
            // 
            this.gpFinSeleccion.BackColor = System.Drawing.Color.Transparent;
            this.gpFinSeleccion.Controls.Add(this.btnSiguiente);
            this.gpFinSeleccion.Controls.Add(this.label9);
            this.gpFinSeleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpFinSeleccion.ForeColor = System.Drawing.Color.SteelBlue;
            this.gpFinSeleccion.Location = new System.Drawing.Point(721, 12);
            this.gpFinSeleccion.Name = "gpFinSeleccion";
            this.gpFinSeleccion.Size = new System.Drawing.Size(137, 112);
            this.gpFinSeleccion.TabIndex = 37;
            this.gpFinSeleccion.TabStop = false;
            this.gpFinSeleccion.Text = "Paso 5";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.NextFinal;
            this.btnSiguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSiguiente.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Location = new System.Drawing.Point(44, 44);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(62, 53);
            this.btnSiguiente.TabIndex = 40;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            this.btnSiguiente.MouseHover += new System.EventHandler(this.btnSiguiente_MouseHover);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(47, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "Avanzar";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnBorrarTabla);
            this.groupBox1.Controls.Add(this.btnSiguienteNull);
            this.groupBox1.Controls.Add(this.btnLayerBitacora);
            this.groupBox1.Controls.Add(this.btnRevelarId);
            this.groupBox1.Controls.Add(this.btnViewRelation);
            this.groupBox1.Controls.Add(this.lblDecimales);
            this.groupBox1.Controls.Add(this.cmDecimales);
            this.groupBox1.Location = new System.Drawing.Point(12, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(846, 39);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // btnBorrarTabla
            // 
            this.btnBorrarTabla.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.erase;
            this.btnBorrarTabla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBorrarTabla.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBorrarTabla.FlatAppearance.BorderSize = 0;
            this.btnBorrarTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarTabla.Location = new System.Drawing.Point(116, 9);
            this.btnBorrarTabla.Name = "btnBorrarTabla";
            this.btnBorrarTabla.Size = new System.Drawing.Size(29, 25);
            this.btnBorrarTabla.TabIndex = 14;
            this.btnBorrarTabla.UseVisualStyleBackColor = true;
            this.btnBorrarTabla.Click += new System.EventHandler(this.btnBorrarTabla_Click);
            this.btnBorrarTabla.MouseHover += new System.EventHandler(this.btnBorrarTabla_MouseHover);
            // 
            // btnSiguienteNull
            // 
            this.btnSiguienteNull.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.docleft;
            this.btnSiguienteNull.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSiguienteNull.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSiguienteNull.FlatAppearance.BorderSize = 0;
            this.btnSiguienteNull.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguienteNull.Location = new System.Drawing.Point(172, 9);
            this.btnSiguienteNull.Name = "btnSiguienteNull";
            this.btnSiguienteNull.Size = new System.Drawing.Size(29, 25);
            this.btnSiguienteNull.TabIndex = 14;
            this.btnSiguienteNull.UseVisualStyleBackColor = true;
            this.btnSiguienteNull.Click += new System.EventHandler(this.btnSiguienteNull_Click);
            this.btnSiguienteNull.MouseHover += new System.EventHandler(this.btnSiguienteNull_MouseHover);
            // 
            // btnLayerBitacora
            // 
            this.btnLayerBitacora.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.layers_error;
            this.btnLayerBitacora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLayerBitacora.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLayerBitacora.FlatAppearance.BorderSize = 0;
            this.btnLayerBitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLayerBitacora.Location = new System.Drawing.Point(58, 7);
            this.btnLayerBitacora.Name = "btnLayerBitacora";
            this.btnLayerBitacora.Size = new System.Drawing.Size(29, 25);
            this.btnLayerBitacora.TabIndex = 14;
            this.btnLayerBitacora.UseVisualStyleBackColor = true;
            this.btnLayerBitacora.Click += new System.EventHandler(this.btnLayerBitacora_Click);
            this.btnLayerBitacora.MouseHover += new System.EventHandler(this.btnLayerBitacora_MouseHover);
            // 
            // btnRevelarId
            // 
            this.btnRevelarId.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.more1;
            this.btnRevelarId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRevelarId.FlatAppearance.BorderSize = 0;
            this.btnRevelarId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevelarId.Location = new System.Drawing.Point(9, 13);
            this.btnRevelarId.Name = "btnRevelarId";
            this.btnRevelarId.Size = new System.Drawing.Size(17, 16);
            this.btnRevelarId.TabIndex = 14;
            this.btnRevelarId.UseVisualStyleBackColor = true;
            this.btnRevelarId.Click += new System.EventHandler(this.btnRevelarId_Click);
            this.btnRevelarId.MouseHover += new System.EventHandler(this.btnRevelarId_MouseHover);
            // 
            // btnViewRelation
            // 
            this.btnViewRelation.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.ViewRelationIcon;
            this.btnViewRelation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnViewRelation.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnViewRelation.FlatAppearance.BorderSize = 0;
            this.btnViewRelation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewRelation.Location = new System.Drawing.Point(238, 10);
            this.btnViewRelation.Name = "btnViewRelation";
            this.btnViewRelation.Size = new System.Drawing.Size(29, 25);
            this.btnViewRelation.TabIndex = 14;
            this.btnViewRelation.UseVisualStyleBackColor = true;
            this.btnViewRelation.Click += new System.EventHandler(this.btnViewRelation_Click);
            this.btnViewRelation.MouseHover += new System.EventHandler(this.btnViewRelation_MouseHover);
            // 
            // lblDecimales
            // 
            this.lblDecimales.AutoSize = true;
            this.lblDecimales.BackColor = System.Drawing.Color.Transparent;
            this.lblDecimales.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecimales.Location = new System.Drawing.Point(574, 15);
            this.lblDecimales.Name = "lblDecimales";
            this.lblDecimales.Size = new System.Drawing.Size(62, 14);
            this.lblDecimales.TabIndex = 9;
            this.lblDecimales.Text = "Decimales:";
            // 
            // cmDecimales
            // 
            this.cmDecimales.BackColor = System.Drawing.Color.White;
            this.cmDecimales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmDecimales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmDecimales.FormattingEnabled = true;
            this.cmDecimales.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmDecimales.Location = new System.Drawing.Point(638, 12);
            this.cmDecimales.Name = "cmDecimales";
            this.cmDecimales.Size = new System.Drawing.Size(41, 21);
            this.cmDecimales.TabIndex = 10;
            this.cmDecimales.SelectedIndexChanged += new System.EventHandler(this.cmDecimales_SelectedIndexChanged);
            this.cmDecimales.MouseHover += new System.EventHandler(this.cmDecimales_MouseHover);
            // 
            // gpPaso4
            // 
            this.gpPaso4.BackColor = System.Drawing.Color.Transparent;
            this.gpPaso4.Controls.Add(this.btnOrdenar);
            this.gpPaso4.Controls.Add(this.lblOrd1);
            this.gpPaso4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpPaso4.ForeColor = System.Drawing.Color.SteelBlue;
            this.gpPaso4.Location = new System.Drawing.Point(578, 12);
            this.gpPaso4.Name = "gpPaso4";
            this.gpPaso4.Size = new System.Drawing.Size(137, 112);
            this.gpPaso4.TabIndex = 36;
            this.gpPaso4.TabStop = false;
            this.gpPaso4.Text = "Paso 4";
            // 
            // btnOrdenar
            // 
            this.btnOrdenar.BackColor = System.Drawing.Color.Transparent;
            this.btnOrdenar.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.ReorderBlueIcon;
            this.btnOrdenar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOrdenar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOrdenar.FlatAppearance.BorderSize = 0;
            this.btnOrdenar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnOrdenar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdenar.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.btnOrdenar.Location = new System.Drawing.Point(39, 46);
            this.btnOrdenar.Name = "btnOrdenar";
            this.btnOrdenar.Size = new System.Drawing.Size(53, 49);
            this.btnOrdenar.TabIndex = 40;
            this.btnOrdenar.UseVisualStyleBackColor = false;
            this.btnOrdenar.Click += new System.EventHandler(this.btnOrdenar_Click);
            this.btnOrdenar.MouseHover += new System.EventHandler(this.btnOrdenar_MouseHover);
            // 
            // lblOrd1
            // 
            this.lblOrd1.AutoSize = true;
            this.lblOrd1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrd1.ForeColor = System.Drawing.Color.Black;
            this.lblOrd1.Location = new System.Drawing.Point(8, 16);
            this.lblOrd1.Name = "lblOrd1";
            this.lblOrd1.Size = new System.Drawing.Size(98, 14);
            this.lblOrd1.TabIndex = 1;
            this.lblOrd1.Text = "Ordenar Viviendas";
            // 
            // groupDireccion
            // 
            this.groupDireccion.BackColor = System.Drawing.Color.Transparent;
            this.groupDireccion.Controls.Add(this.btnSelDireccion);
            this.groupDireccion.Controls.Add(this.checkSD);
            this.groupDireccion.Controls.Add(this.lblSelDireccion);
            this.groupDireccion.Controls.Add(this.btnCambiaDireccion);
            this.groupDireccion.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDireccion.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupDireccion.Location = new System.Drawing.Point(196, 12);
            this.groupDireccion.Name = "groupDireccion";
            this.groupDireccion.Size = new System.Drawing.Size(195, 112);
            this.groupDireccion.TabIndex = 18;
            this.groupDireccion.TabStop = false;
            this.groupDireccion.Text = "Paso 2";
            // 
            // btnSelDireccion
            // 
            this.btnSelDireccion.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.btndireccion;
            this.btnSelDireccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelDireccion.Enabled = false;
            this.btnSelDireccion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSelDireccion.FlatAppearance.BorderSize = 0;
            this.btnSelDireccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelDireccion.Location = new System.Drawing.Point(19, 44);
            this.btnSelDireccion.Name = "btnSelDireccion";
            this.btnSelDireccion.Size = new System.Drawing.Size(64, 56);
            this.btnSelDireccion.TabIndex = 40;
            this.btnSelDireccion.UseVisualStyleBackColor = true;
            this.btnSelDireccion.Click += new System.EventHandler(this.btnSelDireccion_Click);
            // 
            // checkSD
            // 
            this.checkSD.AutoSize = true;
            this.checkSD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkSD.Location = new System.Drawing.Point(151, 10);
            this.checkSD.Name = "checkSD";
            this.checkSD.Size = new System.Drawing.Size(43, 19);
            this.checkSD.TabIndex = 2;
            this.checkSD.Text = "S/D";
            this.checkSD.UseVisualStyleBackColor = true;
            this.checkSD.CheckedChanged += new System.EventHandler(this.checkSD_CheckedChanged);
            this.checkSD.MouseHover += new System.EventHandler(this.checkSD_CheckedChanged);
            // 
            // lblSelDireccion
            // 
            this.lblSelDireccion.AutoSize = true;
            this.lblSelDireccion.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelDireccion.ForeColor = System.Drawing.Color.Black;
            this.lblSelDireccion.Location = new System.Drawing.Point(6, 16);
            this.lblSelDireccion.Name = "lblSelDireccion";
            this.lblSelDireccion.Size = new System.Drawing.Size(127, 15);
            this.lblSelDireccion.TabIndex = 1;
            this.lblSelDireccion.Text = "Selección de Dirección";
            // 
            // btnCambiaDireccion
            // 
            this.btnCambiaDireccion.BackColor = System.Drawing.Color.Transparent;
            this.btnCambiaDireccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiaDireccion.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiaDireccion.ForeColor = System.Drawing.Color.Black;
            this.btnCambiaDireccion.Location = new System.Drawing.Point(104, 73);
            this.btnCambiaDireccion.Name = "btnCambiaDireccion";
            this.btnCambiaDireccion.Size = new System.Drawing.Size(66, 27);
            this.btnCambiaDireccion.TabIndex = 0;
            this.btnCambiaDireccion.Text = "Cambiar";
            this.btnCambiaDireccion.UseVisualStyleBackColor = false;
            this.btnCambiaDireccion.Visible = false;
            this.btnCambiaDireccion.Click += new System.EventHandler(this.btnCambiaDireccion_Click);
            // 
            // groupManzana
            // 
            this.groupManzana.BackColor = System.Drawing.Color.Transparent;
            this.groupManzana.Controls.Add(this.btnSelManzana);
            this.groupManzana.Controls.Add(this.label4);
            this.groupManzana.Controls.Add(this.lblSelManzana);
            this.groupManzana.Controls.Add(this.btnCambiaManzana);
            this.groupManzana.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupManzana.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupManzana.Location = new System.Drawing.Point(12, 12);
            this.groupManzana.Name = "groupManzana";
            this.groupManzana.Size = new System.Drawing.Size(178, 112);
            this.groupManzana.TabIndex = 16;
            this.groupManzana.TabStop = false;
            this.groupManzana.Text = "Paso 1";
            // 
            // btnSelManzana
            // 
            this.btnSelManzana.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.btnManzana;
            this.btnSelManzana.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelManzana.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSelManzana.FlatAppearance.BorderSize = 0;
            this.btnSelManzana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelManzana.Location = new System.Drawing.Point(23, 44);
            this.btnSelManzana.Name = "btnSelManzana";
            this.btnSelManzana.Size = new System.Drawing.Size(64, 56);
            this.btnSelManzana.TabIndex = 40;
            this.btnSelManzana.UseVisualStyleBackColor = true;
            this.btnSelManzana.Click += new System.EventHandler(this.btnSelManzana_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(-179, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Selección de Manzana";
            // 
            // lblSelManzana
            // 
            this.lblSelManzana.AutoSize = true;
            this.lblSelManzana.ForeColor = System.Drawing.Color.Black;
            this.lblSelManzana.Location = new System.Drawing.Point(6, 16);
            this.lblSelManzana.Name = "lblSelManzana";
            this.lblSelManzana.Size = new System.Drawing.Size(125, 15);
            this.lblSelManzana.TabIndex = 1;
            this.lblSelManzana.Text = "Selección de Manzana";
            // 
            // btnCambiaManzana
            // 
            this.btnCambiaManzana.BackColor = System.Drawing.Color.Transparent;
            this.btnCambiaManzana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiaManzana.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiaManzana.ForeColor = System.Drawing.Color.Black;
            this.btnCambiaManzana.Location = new System.Drawing.Point(97, 73);
            this.btnCambiaManzana.Name = "btnCambiaManzana";
            this.btnCambiaManzana.Size = new System.Drawing.Size(66, 27);
            this.btnCambiaManzana.TabIndex = 0;
            this.btnCambiaManzana.Text = "Cambiar";
            this.btnCambiaManzana.UseVisualStyleBackColor = false;
            this.btnCambiaManzana.Visible = false;
            this.btnCambiaManzana.Click += new System.EventHandler(this.btnCambiaManzana_Click);
            // 
            // groupViviendas
            // 
            this.groupViviendas.BackColor = System.Drawing.Color.Transparent;
            this.groupViviendas.Controls.Add(this.btnSelMultiple);
            this.groupViviendas.Controls.Add(this.label6);
            this.groupViviendas.Controls.Add(this.label5);
            this.groupViviendas.Controls.Add(this.btnSelUnica);
            this.groupViviendas.Controls.Add(this.label3);
            this.groupViviendas.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupViviendas.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupViviendas.Location = new System.Drawing.Point(397, 12);
            this.groupViviendas.Name = "groupViviendas";
            this.groupViviendas.Size = new System.Drawing.Size(175, 112);
            this.groupViviendas.TabIndex = 17;
            this.groupViviendas.TabStop = false;
            this.groupViviendas.Text = "Paso 3";
            // 
            // btnSelMultiple
            // 
            this.btnSelMultiple.BackColor = System.Drawing.Color.Transparent;
            this.btnSelMultiple.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.multiple_Select;
            this.btnSelMultiple.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelMultiple.Enabled = false;
            this.btnSelMultiple.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSelMultiple.FlatAppearance.BorderSize = 0;
            this.btnSelMultiple.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnSelMultiple.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelMultiple.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.btnSelMultiple.Location = new System.Drawing.Point(106, 59);
            this.btnSelMultiple.Name = "btnSelMultiple";
            this.btnSelMultiple.Size = new System.Drawing.Size(48, 47);
            this.btnSelMultiple.TabIndex = 40;
            this.btnSelMultiple.UseVisualStyleBackColor = false;
            this.btnSelMultiple.Click += new System.EventHandler(this.btnSelMultiple_Click);
            this.btnSelMultiple.MouseHover += new System.EventHandler(this.btnSelMultiple_MouseHover);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(103, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Múltiple";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(36, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Única";
            // 
            // btnSelUnica
            // 
            this.btnSelUnica.BackColor = System.Drawing.Color.Transparent;
            this.btnSelUnica.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.select;
            this.btnSelUnica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSelUnica.Enabled = false;
            this.btnSelUnica.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSelUnica.FlatAppearance.BorderSize = 0;
            this.btnSelUnica.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnSelUnica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelUnica.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.btnSelUnica.Location = new System.Drawing.Point(27, 59);
            this.btnSelUnica.Name = "btnSelUnica";
            this.btnSelUnica.Size = new System.Drawing.Size(48, 47);
            this.btnSelUnica.TabIndex = 40;
            this.btnSelUnica.UseVisualStyleBackColor = false;
            this.btnSelUnica.Click += new System.EventHandler(this.btnSelUnica_Click);
            this.btnSelUnica.MouseHover += new System.EventHandler(this.btnSelUnica_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Selección de Viviendas";
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.Transparent;
            this.btnAtras.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources._1468633294_back;
            this.btnAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAtras.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnAtras.FlatAppearance.BorderSize = 0;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Location = new System.Drawing.Point(13, 392);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(44, 42);
            this.btnAtras.TabIndex = 55;
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            this.btnAtras.MouseHover += new System.EventHandler(this.btnAtras_MouseHover);
            // 
            // lblManActual
            // 
            this.lblManActual.AutoSize = true;
            this.lblManActual.BackColor = System.Drawing.Color.Transparent;
            this.lblManActual.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManActual.Location = new System.Drawing.Point(485, 415);
            this.lblManActual.Name = "lblManActual";
            this.lblManActual.Size = new System.Drawing.Size(96, 15);
            this.lblManActual.TabIndex = 42;
            this.lblManActual.Text = "Manzana Actual:";
            // 
            // setDireccionActual
            // 
            this.setDireccionActual.AutoSize = true;
            this.setDireccionActual.BackColor = System.Drawing.Color.Transparent;
            this.setDireccionActual.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setDireccionActual.ForeColor = System.Drawing.Color.SteelBlue;
            this.setDireccionActual.Location = new System.Drawing.Point(265, 415);
            this.setDireccionActual.Name = "setDireccionActual";
            this.setDireccionActual.Size = new System.Drawing.Size(64, 15);
            this.setDireccionActual.TabIndex = 43;
            this.setDireccionActual.Text = "Pendiente";
            // 
            // lblDirActual
            // 
            this.lblDirActual.AutoSize = true;
            this.lblDirActual.BackColor = System.Drawing.Color.Transparent;
            this.lblDirActual.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirActual.Location = new System.Drawing.Point(161, 415);
            this.lblDirActual.Name = "lblDirActual";
            this.lblDirActual.Size = new System.Drawing.Size(98, 15);
            this.lblDirActual.TabIndex = 44;
            this.lblDirActual.Text = "Direccion Actual:";
            // 
            // lblResViviendas
            // 
            this.lblResViviendas.AutoSize = true;
            this.lblResViviendas.BackColor = System.Drawing.Color.Transparent;
            this.lblResViviendas.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResViviendas.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblResViviendas.Location = new System.Drawing.Point(578, 394);
            this.lblResViviendas.Name = "lblResViviendas";
            this.lblResViviendas.Size = new System.Drawing.Size(64, 15);
            this.lblResViviendas.TabIndex = 45;
            this.lblResViviendas.Text = "Pendiente";
            // 
            // lblVivPndts
            // 
            this.lblVivPndts.AutoSize = true;
            this.lblVivPndts.BackColor = System.Drawing.Color.Transparent;
            this.lblVivPndts.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVivPndts.Location = new System.Drawing.Point(450, 394);
            this.lblVivPndts.Name = "lblVivPndts";
            this.lblVivPndts.Size = new System.Drawing.Size(131, 15);
            this.lblVivPndts.TabIndex = 46;
            this.lblVivPndts.Text = "Viviendas Pendientes: ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(840, 424);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 10);
            this.pictureBox2.TabIndex = 54;
            this.pictureBox2.TabStop = false;
            // 
            // setManActual
            // 
            this.setManActual.AutoSize = true;
            this.setManActual.BackColor = System.Drawing.Color.Transparent;
            this.setManActual.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setManActual.ForeColor = System.Drawing.Color.SteelBlue;
            this.setManActual.Location = new System.Drawing.Point(581, 415);
            this.setManActual.Name = "setManActual";
            this.setManActual.Size = new System.Drawing.Size(64, 15);
            this.setManActual.TabIndex = 47;
            this.setManActual.Text = "Pendiente";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(791, 423);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Sin Datos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(763, 391);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Dato Númerico";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(840, 408);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 10);
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(769, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Más de 1 dato";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(840, 392);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 10);
            this.pictureBox3.TabIndex = 53;
            this.pictureBox3.TabStop = false;
            // 
            // setConjunto
            // 
            this.setConjunto.AutoSize = true;
            this.setConjunto.BackColor = System.Drawing.Color.Transparent;
            this.setConjunto.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setConjunto.ForeColor = System.Drawing.Color.SteelBlue;
            this.setConjunto.Location = new System.Drawing.Point(265, 394);
            this.setConjunto.Name = "setConjunto";
            this.setConjunto.Size = new System.Drawing.Size(64, 15);
            this.setConjunto.TabIndex = 48;
            this.setConjunto.Text = "Pendiente";
            // 
            // lblConjunto
            // 
            this.lblConjunto.AutoSize = true;
            this.lblConjunto.BackColor = System.Drawing.Color.Transparent;
            this.lblConjunto.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConjunto.Location = new System.Drawing.Point(198, 394);
            this.lblConjunto.Name = "lblConjunto";
            this.lblConjunto.Size = new System.Drawing.Size(61, 15);
            this.lblConjunto.TabIndex = 41;
            this.lblConjunto.Text = "Conjunto:";
            // 
            // MSeleccionaPlano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(870, 439);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.lblManActual);
            this.Controls.Add(this.setDireccionActual);
            this.Controls.Add(this.lblDirActual);
            this.Controls.Add(this.lblResViviendas);
            this.Controls.Add(this.lblVivPndts);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.setManActual);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.setConjunto);
            this.Controls.Add(this.lblConjunto);
            this.Controls.Add(this.dtDatosPlano);
            this.Controls.Add(this.gpFinSeleccion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpPaso4);
            this.Controls.Add(this.groupDireccion);
            this.Controls.Add(this.groupManzana);
            this.Controls.Add(this.groupViviendas);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MSeleccionaPlano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección de Viviendas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MSeleccionaPlano_FormClosing);
            this.Load += new System.EventHandler(this.MSeleccionaPlano_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtDatosPlano)).EndInit();
            this.gpFinSeleccion.ResumeLayout(false);
            this.gpFinSeleccion.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpPaso4.ResumeLayout(false);
            this.gpPaso4.PerformLayout();
            this.groupDireccion.ResumeLayout(false);
            this.groupDireccion.PerformLayout();
            this.groupManzana.ResumeLayout(false);
            this.groupManzana.PerformLayout();
            this.groupViviendas.ResumeLayout(false);
            this.groupViviendas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dtDatosPlano;
        private System.Windows.Forms.GroupBox gpFinSeleccion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDecimales;
        private System.Windows.Forms.ComboBox cmDecimales;
        private System.Windows.Forms.GroupBox gpPaso4;
        private System.Windows.Forms.Label lblOrd1;
        private System.Windows.Forms.GroupBox groupDireccion;
        private System.Windows.Forms.CheckBox checkSD;
        private System.Windows.Forms.Label lblSelDireccion;
        private System.Windows.Forms.Button btnCambiaDireccion;
        private System.Windows.Forms.GroupBox groupManzana;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSelManzana;
        private System.Windows.Forms.Button btnCambiaManzana;
        private System.Windows.Forms.GroupBox groupViviendas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnViewRelation;
        private System.Windows.Forms.Button btnSiguienteNull;
        private System.Windows.Forms.Button btnBorrarTabla;
        private System.Windows.Forms.Button btnLayerBitacora;
        private System.Windows.Forms.Button btnRevelarId;
        private System.Windows.Forms.Button btnSelManzana;
        private System.Windows.Forms.Button btnSelDireccion;
        private System.Windows.Forms.Button btnSelUnica;
        private System.Windows.Forms.Button btnSelMultiple;
        private System.Windows.Forms.Button btnOrdenar;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPolLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDSistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prototipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manzana;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lote;
        private System.Windows.Forms.DataGridViewComboBoxColumn NoOficial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Piso;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoInterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn M2Superficie;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadPrivativa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calle;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label lblManActual;
        private System.Windows.Forms.Label setDireccionActual;
        private System.Windows.Forms.Label lblDirActual;
        private System.Windows.Forms.Label lblResViviendas;
        private System.Windows.Forms.Label lblVivPndts;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label setManActual;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label setConjunto;
        private System.Windows.Forms.Label lblConjunto;
    }
}