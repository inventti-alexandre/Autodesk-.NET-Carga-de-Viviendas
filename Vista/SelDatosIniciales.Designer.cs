namespace PluginInsViviendas_UNO.Vista
{
    partial class SelDatosIniciales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelDatosIniciales));
            this.cmbFraccionamiento = new System.Windows.Forms.ComboBox();
            this.cmbFrente = new System.Windows.Forms.ComboBox();
            this.cmbConjunto = new System.Windows.Forms.ComboBox();
            this.cmbPrototipo = new System.Windows.Forms.ComboBox();
            this.lblFraccionamiento = new System.Windows.Forms.Label();
            this.lblFrente = new System.Windows.Forms.Label();
            this.lblConjunto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkFideicomiso = new System.Windows.Forms.CheckBox();
            this.btnSiguiente = new System.Windows.Forms.PictureBox();
            this.lblConectando = new System.Windows.Forms.Label();
            this.lblEstatus = new System.Windows.Forms.Label();
            this.lblsetEstatus = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.bkWork = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.lblVivPendientes = new System.Windows.Forms.Label();
            this.lblValueVivPdts = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblResUser = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SiMultifamiliar = new System.Windows.Forms.CheckBox();
            this.cmbAmbiente = new System.Windows.Forms.ComboBox();
            this.btnFirmarAmbiente = new System.Windows.Forms.Button();
            this.txtAmbientePassword = new System.Windows.Forms.TextBox();
            this.btnAmbienteLogin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnSiguiente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbFraccionamiento
            // 
            this.cmbFraccionamiento.BackColor = System.Drawing.SystemColors.Window;
            this.cmbFraccionamiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFraccionamiento.Enabled = false;
            this.cmbFraccionamiento.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFraccionamiento.FormattingEnabled = true;
            this.cmbFraccionamiento.Location = new System.Drawing.Point(135, 118);
            this.cmbFraccionamiento.Name = "cmbFraccionamiento";
            this.cmbFraccionamiento.Size = new System.Drawing.Size(209, 23);
            this.cmbFraccionamiento.TabIndex = 3;
            this.cmbFraccionamiento.SelectedIndexChanged += new System.EventHandler(this.cmbFraccionamiento_SelectedIndexChanged);
            // 
            // cmbFrente
            // 
            this.cmbFrente.BackColor = System.Drawing.SystemColors.Window;
            this.cmbFrente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrente.Enabled = false;
            this.cmbFrente.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFrente.FormattingEnabled = true;
            this.cmbFrente.Location = new System.Drawing.Point(135, 164);
            this.cmbFrente.Name = "cmbFrente";
            this.cmbFrente.Size = new System.Drawing.Size(209, 23);
            this.cmbFrente.TabIndex = 3;
            this.cmbFrente.SelectedIndexChanged += new System.EventHandler(this.cmbFrente_SelectedIndexChanged);
            // 
            // cmbConjunto
            // 
            this.cmbConjunto.BackColor = System.Drawing.SystemColors.Window;
            this.cmbConjunto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConjunto.Enabled = false;
            this.cmbConjunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConjunto.FormattingEnabled = true;
            this.cmbConjunto.Location = new System.Drawing.Point(135, 225);
            this.cmbConjunto.Name = "cmbConjunto";
            this.cmbConjunto.Size = new System.Drawing.Size(209, 21);
            this.cmbConjunto.TabIndex = 3;
            this.cmbConjunto.SelectedIndexChanged += new System.EventHandler(this.cmbConjunto_SelectedIndexChanged);
            // 
            // cmbPrototipo
            // 
            this.cmbPrototipo.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPrototipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrototipo.Enabled = false;
            this.cmbPrototipo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPrototipo.FormattingEnabled = true;
            this.cmbPrototipo.Location = new System.Drawing.Point(135, 57);
            this.cmbPrototipo.Name = "cmbPrototipo";
            this.cmbPrototipo.Size = new System.Drawing.Size(209, 23);
            this.cmbPrototipo.TabIndex = 3;
            this.cmbPrototipo.SelectedIndexChanged += new System.EventHandler(this.cmbPrototipo_SelectedIndexChanged);
            // 
            // lblFraccionamiento
            // 
            this.lblFraccionamiento.AutoSize = true;
            this.lblFraccionamiento.BackColor = System.Drawing.Color.Transparent;
            this.lblFraccionamiento.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFraccionamiento.Location = new System.Drawing.Point(23, 121);
            this.lblFraccionamiento.Name = "lblFraccionamiento";
            this.lblFraccionamiento.Size = new System.Drawing.Size(110, 17);
            this.lblFraccionamiento.TabIndex = 4;
            this.lblFraccionamiento.Text = "Fraccionamiento:";
            // 
            // lblFrente
            // 
            this.lblFrente.AutoSize = true;
            this.lblFrente.BackColor = System.Drawing.Color.Transparent;
            this.lblFrente.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrente.Location = new System.Drawing.Point(23, 167);
            this.lblFrente.Name = "lblFrente";
            this.lblFrente.Size = new System.Drawing.Size(53, 17);
            this.lblFrente.TabIndex = 4;
            this.lblFrente.Text = "Frente: ";
            // 
            // lblConjunto
            // 
            this.lblConjunto.AutoSize = true;
            this.lblConjunto.BackColor = System.Drawing.Color.Transparent;
            this.lblConjunto.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConjunto.Location = new System.Drawing.Point(23, 227);
            this.lblConjunto.Name = "lblConjunto";
            this.lblConjunto.Size = new System.Drawing.Size(71, 17);
            this.lblConjunto.TabIndex = 4;
            this.lblConjunto.Text = "Conjunto: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Prototipo:";
            // 
            // chkFideicomiso
            // 
            this.chkFideicomiso.AutoSize = true;
            this.chkFideicomiso.BackColor = System.Drawing.Color.Transparent;
            this.chkFideicomiso.Enabled = false;
            this.chkFideicomiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkFideicomiso.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFideicomiso.Location = new System.Drawing.Point(135, 193);
            this.chkFideicomiso.Name = "chkFideicomiso";
            this.chkFideicomiso.Size = new System.Drawing.Size(89, 21);
            this.chkFideicomiso.TabIndex = 5;
            this.chkFideicomiso.Text = "Fideicomiso";
            this.chkFideicomiso.UseVisualStyleBackColor = false;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.Transparent;
            this.btnSiguiente.Image = global::PluginInsViviendas_UNO.Properties.Resources.nextbtn;
            this.btnSiguiente.Location = new System.Drawing.Point(334, 287);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(59, 47);
            this.btnSiguiente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSiguiente.TabIndex = 6;
            this.btnSiguiente.TabStop = false;
            this.btnSiguiente.Visible = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblConectando
            // 
            this.lblConectando.AutoSize = true;
            this.lblConectando.BackColor = System.Drawing.Color.Transparent;
            this.lblConectando.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConectando.ForeColor = System.Drawing.Color.Black;
            this.lblConectando.Location = new System.Drawing.Point(176, 291);
            this.lblConectando.Name = "lblConectando";
            this.lblConectando.Size = new System.Drawing.Size(92, 17);
            this.lblConectando.TabIndex = 2;
            this.lblConectando.Text = "Conectando...";
            this.lblConectando.Visible = false;
            // 
            // lblEstatus
            // 
            this.lblEstatus.AutoSize = true;
            this.lblEstatus.BackColor = System.Drawing.Color.Transparent;
            this.lblEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstatus.Location = new System.Drawing.Point(272, 9);
            this.lblEstatus.Name = "lblEstatus";
            this.lblEstatus.Size = new System.Drawing.Size(57, 13);
            this.lblEstatus.TabIndex = 2;
            this.lblEstatus.Text = "Estatus: ";
            // 
            // lblsetEstatus
            // 
            this.lblsetEstatus.AutoSize = true;
            this.lblsetEstatus.BackColor = System.Drawing.Color.Transparent;
            this.lblsetEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsetEstatus.ForeColor = System.Drawing.Color.Red;
            this.lblsetEstatus.Location = new System.Drawing.Point(321, 10);
            this.lblsetEstatus.Name = "lblsetEstatus";
            this.lblsetEstatus.Size = new System.Drawing.Size(44, 13);
            this.lblsetEstatus.TabIndex = 2;
            this.lblsetEstatus.Text = "Offline";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::PluginInsViviendas_UNO.Properties.Resources.LogoOficialNuevo;
            this.pictureBox4.Location = new System.Drawing.Point(12, 287);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(55, 47);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(179, 311);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(88, 23);
            this.progressBar.TabIndex = 9;
            this.progressBar.Visible = false;
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.BackColor = System.Drawing.Color.Transparent;
            this.btnIniciarSesion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Location = new System.Drawing.Point(12, 10);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(92, 23);
            this.btnIniciarSesion.TabIndex = 10;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // lblVivPendientes
            // 
            this.lblVivPendientes.AutoSize = true;
            this.lblVivPendientes.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVivPendientes.Location = new System.Drawing.Point(135, 249);
            this.lblVivPendientes.Name = "lblVivPendientes";
            this.lblVivPendientes.Size = new System.Drawing.Size(132, 14);
            this.lblVivPendientes.TabIndex = 11;
            this.lblVivPendientes.Text = "Viviendas Pendientes: ";
            this.lblVivPendientes.Visible = false;
            // 
            // lblValueVivPdts
            // 
            this.lblValueVivPdts.AutoSize = true;
            this.lblValueVivPdts.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueVivPdts.Location = new System.Drawing.Point(263, 249);
            this.lblValueVivPdts.Name = "lblValueVivPdts";
            this.lblValueVivPdts.Size = new System.Drawing.Size(13, 14);
            this.lblValueVivPdts.TabIndex = 11;
            this.lblValueVivPdts.Text = "0";
            this.lblValueVivPdts.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(272, 25);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(54, 13);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Usuario:";
            // 
            // lblResUser
            // 
            this.lblResUser.AutoSize = true;
            this.lblResUser.BackColor = System.Drawing.Color.Transparent;
            this.lblResUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResUser.ForeColor = System.Drawing.Color.DimGray;
            this.lblResUser.Location = new System.Drawing.Point(321, 25);
            this.lblResUser.Name = "lblResUser";
            this.lblResUser.Size = new System.Drawing.Size(33, 13);
            this.lblResUser.TabIndex = 2;
            this.lblResUser.Text = "User";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(110, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // SiMultifamiliar
            // 
            this.SiMultifamiliar.AutoSize = true;
            this.SiMultifamiliar.BackColor = System.Drawing.Color.Transparent;
            this.SiMultifamiliar.Enabled = false;
            this.SiMultifamiliar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SiMultifamiliar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.SiMultifamiliar.Location = new System.Drawing.Point(138, 87);
            this.SiMultifamiliar.Name = "SiMultifamiliar";
            this.SiMultifamiliar.Size = new System.Drawing.Size(114, 21);
            this.SiMultifamiliar.TabIndex = 12;
            this.SiMultifamiliar.Text = "Es Multifamiliar";
            this.SiMultifamiliar.UseVisualStyleBackColor = false;
            this.SiMultifamiliar.CheckedChanged += new System.EventHandler(this.SiMultifamiliar_CheckedChanged);
            // 
            // cmbAmbiente
            // 
            this.cmbAmbiente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAmbiente.FormattingEnabled = true;
            this.cmbAmbiente.Items.AddRange(new object[] {
            "Producción",
            "QA",
            "Desarrollo"});
            this.cmbAmbiente.Location = new System.Drawing.Point(139, 12);
            this.cmbAmbiente.Name = "cmbAmbiente";
            this.cmbAmbiente.Size = new System.Drawing.Size(92, 21);
            this.cmbAmbiente.TabIndex = 13;
            this.cmbAmbiente.Visible = false;
            this.cmbAmbiente.SelectedIndexChanged += new System.EventHandler(this.cmbAmbiente_SelectedIndexChanged);
            // 
            // btnFirmarAmbiente
            // 
            this.btnFirmarAmbiente.BackColor = System.Drawing.Color.Transparent;
            this.btnFirmarAmbiente.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.database_settings_icon;
            this.btnFirmarAmbiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFirmarAmbiente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFirmarAmbiente.FlatAppearance.BorderSize = 0;
            this.btnFirmarAmbiente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnFirmarAmbiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirmarAmbiente.Location = new System.Drawing.Point(245, 9);
            this.btnFirmarAmbiente.Name = "btnFirmarAmbiente";
            this.btnFirmarAmbiente.Size = new System.Drawing.Size(23, 23);
            this.btnFirmarAmbiente.TabIndex = 14;
            this.btnFirmarAmbiente.UseVisualStyleBackColor = false;
            this.btnFirmarAmbiente.Click += new System.EventHandler(this.btnFirmarAmbiente_Click);
            // 
            // txtAmbientePassword
            // 
            this.txtAmbientePassword.Location = new System.Drawing.Point(139, 13);
            this.txtAmbientePassword.Name = "txtAmbientePassword";
            this.txtAmbientePassword.PasswordChar = '*';
            this.txtAmbientePassword.Size = new System.Drawing.Size(92, 20);
            this.txtAmbientePassword.TabIndex = 15;
            this.txtAmbientePassword.Visible = false;
            this.txtAmbientePassword.TextChanged += new System.EventHandler(this.txtAmbientePassword_TextChanged);
            // 
            // btnAmbienteLogin
            // 
            this.btnAmbienteLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnAmbienteLogin.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.data_protection_icon;
            this.btnAmbienteLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAmbienteLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAmbienteLogin.FlatAppearance.BorderSize = 0;
            this.btnAmbienteLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnAmbienteLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmbienteLogin.Location = new System.Drawing.Point(245, 9);
            this.btnAmbienteLogin.Name = "btnAmbienteLogin";
            this.btnAmbienteLogin.Size = new System.Drawing.Size(23, 23);
            this.btnAmbienteLogin.TabIndex = 16;
            this.btnAmbienteLogin.UseVisualStyleBackColor = false;
            this.btnAmbienteLogin.Visible = false;
            this.btnAmbienteLogin.Click += new System.EventHandler(this.btnAmbienteLogin_Click);
            // 
            // SelDatosIniciales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PluginInsViviendas_UNO.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(405, 346);
            this.Controls.Add(this.btnAmbienteLogin);
            this.Controls.Add(this.txtAmbientePassword);
            this.Controls.Add(this.btnFirmarAmbiente);
            this.Controls.Add(this.cmbAmbiente);
            this.Controls.Add(this.SiMultifamiliar);
            this.Controls.Add(this.lblValueVivPdts);
            this.Controls.Add(this.lblVivPendientes);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.chkFideicomiso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblConjunto);
            this.Controls.Add(this.lblFrente);
            this.Controls.Add(this.lblFraccionamiento);
            this.Controls.Add(this.cmbPrototipo);
            this.Controls.Add(this.cmbConjunto);
            this.Controls.Add(this.cmbFrente);
            this.Controls.Add(this.cmbFraccionamiento);
            this.Controls.Add(this.lblConectando);
            this.Controls.Add(this.lblResUser);
            this.Controls.Add(this.lblsetEstatus);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblEstatus);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SelDatosIniciales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelDatosIniciales_FormClosing);
            this.Load += new System.EventHandler(this.SelDatosIniciales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSiguiente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFraccionamiento;
        private System.Windows.Forms.ComboBox cmbFrente;
        private System.Windows.Forms.ComboBox cmbConjunto;
        private System.Windows.Forms.ComboBox cmbPrototipo;
        private System.Windows.Forms.Label lblFraccionamiento;
        private System.Windows.Forms.Label lblFrente;
        private System.Windows.Forms.Label lblConjunto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkFideicomiso;
        private System.Windows.Forms.PictureBox btnSiguiente;
        private System.Windows.Forms.Label lblConectando;
        private System.Windows.Forms.Label lblEstatus;
        private System.Windows.Forms.Label lblsetEstatus;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.ComponentModel.BackgroundWorker bkWork;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.Label lblVivPendientes;
        private System.Windows.Forms.Label lblValueVivPdts;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblResUser;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox SiMultifamiliar;
        private System.Windows.Forms.ComboBox cmbAmbiente;
        private System.Windows.Forms.Button btnFirmarAmbiente;
        private System.Windows.Forms.TextBox txtAmbientePassword;
        private System.Windows.Forms.Button btnAmbienteLogin;
    }
}