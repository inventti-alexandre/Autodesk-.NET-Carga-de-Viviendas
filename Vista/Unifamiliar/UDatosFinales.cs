using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PluginInsViviendas_UNO.Vista.Unifamiliar
{
    public partial class UDatosFinales : Form
    {
        public UDatosFinales()
        {
            InitializeComponent();            
        }

        ToolTip t1 = new ToolTip();         

        Vista.CargandoViviendas CargaVivForm = new Vista.CargandoViviendas();

        private void DatosFinales_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            //Asigno Datos Generales
            lblResPrototipo.Text = Modelo.EncDatosIniciales.Prototipo;
            lblResFracc.Text = Modelo.EncDatosIniciales.Fraccionamiento;
            lblResFrente.Text = Modelo.EncDatosIniciales.Frente;
            lblResConjunto.Text = Modelo.EncDatosIniciales.Conjunto;

            //Tomo leyenda del fideicomiso
            if (Modelo.EncDatosIniciales.Fideicomiso != string.Empty && Modelo.EncDatosIniciales.Fideicomiso != null)           
                lblResFideicomiso.Text = Modelo.EncDatosIniciales.Fideicomiso;            
            else
                lblResFideicomiso.Text = "No cuenta con Fideicomiso";

            //Lleno DGV de acuerdo a la fuente de donde proviene
            if (Modelo.EncDatosConfiguracion.ConDatos == true)
            {
                Controlador.MetodosFinales.RegresoDatosDF(dtDatosFinales, "Unifamiliar");

                Modelo.EncDatosConfiguracion.ConDatos = false;

                checkSFT.Checked = true;
                checkExcedente.Checked = true;
                checkM2Cons.Checked = true;
            }
            else
            {
                //Paso Actual
                lblpaso1.Font = new System.Drawing.Font(lblpaso1.Font, FontStyle.Bold);

                //Recibo datos DGV
                Controlador.MetodosFinales.ReciboDatosDF(dtDatosFinales, "Unifamiliar");
            }

            //Superficie Lote Tipo llenado---------------------------------------
            foreach (double superflote in Modelo.EncDatosPlano.M2SuperFloteTipo)
            {
                cmbSuperFlote.Items.Add(superflote);
            }

            cmbSuperFlote.SelectedIndex = -1;            
            //-------------------------------------------------------------------
        }

        
        #region booleanos
        private void chkVivVerdefull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVivVerdefull.Checked == true)
            {
                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[Modelo.IndexColumn.UDFColumnaBnVivVerde].Value = true;

                }
            }
            else
            {
                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[Modelo.IndexColumn.UDFColumnaBnVivVerde].Value = false;
                }
            }

        }

        private void chkMuestrafull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMuestrafull.Checked == true)
                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[Modelo.IndexColumn.UDFColumnaBnMuestra].Value = true;                    
                }
            else
                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[Modelo.IndexColumn.UDFColumnaBnMuestra].Value = false;
                }
        }

        private void chkDisponiblefull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDisponiblefull.Checked == true)
                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[Modelo.IndexColumn.UDFColumnaBnDisponible].Value = true;                    
                }
            else
                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[Modelo.IndexColumn.UDFColumnaBnDisponible].Value = false;
                }
        }

        private void chkCablefull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCablefull.Checked == true)
                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[Modelo.IndexColumn.UDFColumnaBnCablevision].Value = true;                    
                }
            else
                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[Modelo.IndexColumn.UDFColumnaBnCablevision].Value = false;
                }
        }

        #endregion
        
        private void cmbSuperFlote_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSuperFlote.SelectedIndex != -1)
            {
                //Llena los datos a partir de 
                foreach (DataGridViewRow dtrow in dtDatosFinales.Rows)
                {
                    float m2superficieactual = 0,
                            superfloteactual = 0,
                            restaEx = 0;
                    string excedente = "";

                    //Asigno SuperficieLoteTipo
                    dtrow.Cells[Modelo.IndexColumn.UDFColumnaSuperflotetipo].Value = cmbSuperFlote.SelectedItem;
                    
                   //Parse a float
                    m2superficieactual = float.Parse(dtrow.Cells[Modelo.IndexColumn.UDFColumnaM2Superficie].Value.ToString());
                    superfloteactual = float.Parse(dtrow.Cells[Modelo.IndexColumn.UDFColumnaSuperflotetipo].Value.ToString());

                    restaEx = m2superficieactual - superfloteactual;

                    //Calculo Excedente
                    excedente = string.Format(Controlador.MetodosPlano.EnviaFormatoArea(Modelo.EncDatosPlano.Decimales.ToString()), //Decimales a asignar
                                                restaEx);//Excedentes

                    //Asigno Excedente
                    dtrow.Cells[Modelo.IndexColumn.UDFColumnaM2Excedente].Value = excedente;

                    //Envío paso 1 y 2 realizado
                    checkExcedente.Checked = true;
                    checkSFT.Checked = true;
                    lblpaso1.Font = new System.Drawing.Font(lblpaso1.Font, FontStyle.Regular);
                    lblpaso2.Font = new System.Drawing.Font(lblpaso2.Font, FontStyle.Regular);
                    lblpaso3.Font = new System.Drawing.Font(lblpaso3.Font, FontStyle.Bold);

                }

                foreach (DataGridViewRow dtrow in dtDatosFinales.Rows)
                {
                    

                }
            }

        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea regresar a Módulo Selección de Viviendas?", "Regresar", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                USelDatosPlano sdp = new USelDatosPlano();
                Modelo.EncDatosConfiguracion.ConDatos = true;
                sdp.Show();
                Modelo.EncDatosPlano.M2SuperFloteTipo.Clear();
                Modelo.EncDatosConfiguracion.CierreAuto = true;
                Close();
            }
        }

        private void DatosFinales_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    //Reviso que el usuario haya activado el cierre
                    if (Modelo.EncDatosConfiguracion.CierreAuto == false)
                    {
                        //Reviso si cancela el cierre
                        if (MessageBox.Show("¿Esta seguro que desea cerrar? Se perderá la conexión", "Advertencia",
                             MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                        }
                        //Al no cancelar inicializa envia señal de cerrado
                        else
                        {
                            Controlador.MetodosFinales.LimpiaTodoEncapsulado(true, true, true);
                            Modelo.EncDatosIniciales.EstaAbierto = false;                            
                        }
                    }
                    Modelo.EncDatosConfiguracion.CierreAuto = false;
                    break;
                default:
                    Modelo.EncDatosIniciales.EstaAbierto = false;
                    Controlador.MetodosFinales.LimpiaTodoEncapsulado(true, true, true);
                    break;
            }
        }

        private void btnAsignaConst_Click(object sender, EventArgs e)
        {

        }

        private void btnCargaVivs_Click(object sender, EventArgs e)
        {

            //Reviso que se haya seleccionado el SPFT
            if (checkSFT.CheckState == CheckState.Checked && checkExcedente.CheckState == CheckState.Checked)
            {
                Controlador.MetodosFinales.EnviaBlancoCeldas(dtDatosFinales);                

                if (!Controlador.MetodosFinales.SiEmptyoNull(dtDatosFinales, Modelo.IndexColumn.UDFColumnaM2Construccion))
                {                   
                    if (Controlador.MetodosFinales.SiDatoNumerico(dtDatosFinales, Modelo.IndexColumn.UDFColumnaM2Construccion))
                    {
                        CargaVivForm.Show(this);
                        bkWorker = new BackgroundWorker();
                        bkWorker.DoWork += new DoWorkEventHandler(BGWorker_DoWork);
                        if (bkWorker.IsBusy == false)
                        {
                            bkWorker.RunWorkerAsync();
                        }

                        bkWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                        bkWorker.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                    }
                    else
                    {
                        MessageBox.Show("Datos no númericos en M2 de Construcción");
                    }
                }
                else
                {
                    MessageBox.Show("Datos vacíos en M2 de Construcción");
                }
            }
            else
                MessageBox.Show("Favor de seleccionar Superficie Lote tipo");
        }

        private void btnAsignSPFT_Click(object sender, EventArgs e)
        {
            //Inicializo las variables
            ObjectId IdVivienda = new ObjectId();
            Polyline pl = new Polyline();

            this.WindowState = FormWindowState.Minimized;

            if (Controlador.MetodosPlano.SeleccionaEntidadTipo("\n Selecciona la vivienda Superflote Tipo", out IdVivienda, typeof(Polyline)))
            {
                pl = Controlador.MetodosPlano.AbrirEntidad(IdVivienda) as Polyline;

                //Remuevo espacios del nombre del layer y lo pongo en mayusculas
                string plstring = (pl.Layer.ToUpper().Replace(" ", string.Empty));

                if (plstring == Modelo.EncDatosConfiguracion.LayerViviendas)
                {
                    string areaPl = "";

                    //M2 Superficie - Calculo el área de la polílinea------------------------------------------------------------------ 
                    areaPl = string.Format(Controlador.MetodosPlano.EnviaFormatoArea(Modelo.EncDatosPlano.Decimales.ToString()), pl.Area);                    

                    foreach (DataGridViewRow dtrow in dtDatosFinales.Rows)
                    {
                        float   m2superficieactual = 0,
                                superfloteactual = 0;
                        string  excedente = "";

                        dtrow.Cells[Modelo.IndexColumn.UDFColumnaSuperflotetipo].Value = areaPl;

                        //Parse a float
                        m2superficieactual = float.Parse(dtrow.Cells[Modelo.IndexColumn.UDFColumnaM2Superficie].Value.ToString());
                        superfloteactual = float.Parse(areaPl);

                        //Calculo Excedente
                        excedente = string.Format(Controlador.MetodosPlano.EnviaFormatoArea(Modelo.EncDatosPlano.Decimales.ToString()), //Decimales a asignar
                                                    (m2superficieactual - superfloteactual));//Excedentes

                        //Asigno Excedente
                        dtrow.Cells[Modelo.IndexColumn.UDFColumnaM2Excedente].Value = excedente;
                    }

                    //Asingo paso 3
                    lblpaso1.Font = new System.Drawing.Font(lblpaso1.Font, FontStyle.Regular);
                    lblpaso2.Font = new System.Drawing.Font(lblpaso2.Font, FontStyle.Regular);
                    lblpaso3.Font = new System.Drawing.Font(lblpaso2.Font, FontStyle.Bold);

                    //Envío señal de paso cumplido
                    checkSFT.Checked = true;
                    checkExcedente.Checked = true;

                }
                else
                {
                    MessageBox.Show("La polilínea seleccionada no tiene el layer " + Modelo.EncDatosConfiguracion.LayerViviendas,
                        "Selección del Plano", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                    WindowState = FormWindowState.Maximized;
                }
            }

            WindowState = FormWindowState.Maximized;
        }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Envío datos a Array
            Controlador.MetodosFinales.CargoDatosFinales(dtDatosFinales, "Unifamiliar");

            //Inicializo
            Modelo.EncapsulaBitacora.Bulkresponse = new soaBulk.BulkUploadRs();

            //Envío datos a Sembrado
            Modelo.EncapsulaBitacora.Bulkresponse = Controlador.MetodosFinales.CargaViviendas(Modelo.EncDatosPlano.VivsFinales, bkWorker, "Unifamiliar");
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Modelo.EncapsulaBitacora.Bulkresponse.Success == true)
            {
                CargaVivForm.Close();
                CargaVivForm = new Vista.CargandoViviendas();
                UBtViviendasError FormVivError = new UBtViviendasError();
                FormVivError.Show();
                Modelo.EncDatosConfiguracion.CierreAuto = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error de conexión, favor de contactar administrador \n Error: "+ Modelo.EncapsulaBitacora.Bulkresponse.Error ,
                                    "Error en Carga a Sembrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            DialogResult Dresult = MessageBox.Show("¿Desea conservar los datos introducidos en módulo 'Selección de Viviendas'?", "Ir a Inicio",
                         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (Dresult == DialogResult.Yes)
            {                
                SelDatosIniciales sdi = new SelDatosIniciales();
                sdi.Show();
                Modelo.EncDatosConfiguracion.CierreAuto = true;
                this.Close();
                Modelo.EncDatosConfiguracion.ConDatos = true;
            }
            else if (Dresult == DialogResult.No)
            {
                Controlador.MetodosFinales.LimpiaTodoEncapsulado(false, true, true);
                SelDatosIniciales sdi = new SelDatosIniciales();
                sdi.Show();
                Modelo.EncDatosConfiguracion.CierreAuto = true;                
                this.Close();
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            CargaVivForm.lblPorcentaje.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void btnM2Const_Click(object sender, EventArgs e)
        {
            if (txtM2Const.Text != string.Empty && txtM2Const.Text != null)
            {
                float M2ConstruccionGeneral = new float();
                bool SiNumero = false;

                SiNumero = float.TryParse(txtM2Const.Text, out M2ConstruccionGeneral);

                //Es Númerico
                if (SiNumero == true)
                {
                    //Llena los datos a partir de txt M2 Construcción
                    foreach (DataGridViewRow dtrow in dtDatosFinales.Rows)
                    {
                        dtrow.Cells[Modelo.IndexColumn.UDFColumnaM2Construccion].Value = txtM2Const.Text;
                    }
                    checkM2Cons.Checked = true;
                    lblpaso3.Font = new System.Drawing.Font(lblpaso3.Font, FontStyle.Regular);
                }
                else
                {
                    //No es Númerico
                    MessageBox.Show("M2 de Construcción sólo acepta datos númericos");
                }


            }
            else
                MessageBox.Show("Se debe de insertar un valor de M2 de Construcción");
        }

        #region Tooltips
        private void cmbSuperFlote_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Asigna SuperFlote Tipo", cmbSuperFlote, 5000);
        }

        private void txtM2Const_MouseHover(object sender, EventArgs e)
        {
            t1.Show("M2 de Construcción", txtM2Const, 5000);
        }

        private void btnM2Const_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Asigna M2 de Construcción", btnM2Const, 5000);
        }

        private void chkVivVerdefull_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Todas Viviendas Verdes", chkVivVerdefull, 5000);
        }

        private void chkMuestrafull_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Son Muestra", chkMuestrafull, 5000);
        }

        private void chkDisponiblefull_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Todas Disponibles", chkDisponiblefull, 5000);
        }

        private void chkCablefull_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Todas con Cablevisión", chkCablefull, 5000);
        }
        #endregion
    }
}
