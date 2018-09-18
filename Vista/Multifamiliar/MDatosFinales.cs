using Autodesk.AutoCAD.DatabaseServices;
using PluginInsViviendas_UNO.Vista.Vista;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PluginInsViviendas_UNO.Vista.Multifamiliar
{
    public partial class MDatosFinales : Form
    {
        ToolTip t1 = new ToolTip();
        //Bandera para mostrar u ocultar condiciones especiales 
        private bool verCondicionesEspeciales = false;

        CargandoViviendas CargaVivForm = new CargandoViviendas();

        public MDatosFinales()
        {
            InitializeComponent();
        }

        private void MDatosFinales_Load(object sender, EventArgs e)
        {
            //Datos Generales-------------------------------------------------------------------------------------------------
            this.WindowState = FormWindowState.Maximized;
            lblResFracc.Text = Modelo.EncDatosIniciales.Fraccionamiento;
            lblResFrente.Text = Modelo.EncDatosIniciales.Frente;
            lblResConjunto.Text = Modelo.EncDatosIniciales.Conjunto;
            if (Modelo.EncDatosIniciales.Fideicomiso != string.Empty && Modelo.EncDatosIniciales.Fideicomiso != null)
            {
                lblResFideicomiso.Text = Modelo.EncDatosIniciales.Fideicomiso;
            }
            else
                lblResFideicomiso.Text = "No cuenta con Fideicomiso";

            for (int i = 0; i < Modelo.EncDatosIniciales.PrototipoRelacional.GetLength(0); i++)
            {
                listVPrototipo.Items.Add(Modelo.EncDatosIniciales.PrototipoRelacional[i, Modelo.IndexColumn.MRSPColPrototipo]);
            }
            //-----------------------------------------------------------------------------------------------------------------


            
            //Realizo llenado de superflote tipo
            foreach (double superflote in Modelo.EncDatosPlano.M2SuperFloteTipo)
            {
                //Cmb Superflote Tipo
                chlSuperFlote.Items.Add(superflote);
                cmbSuperFlote.Items.Add(superflote);
            }

            //Buscar el valor mas chico como default
            Double minSuperflote = 100000000;
            Double auxSuperflote = 0;
            for (int i = 0; i < chlSuperFlote.Items.Count; i++)
            {
                try { auxSuperflote = Double.Parse(chlSuperFlote.Items[i].ToString()); }
                catch
                { auxSuperflote = 0; }
                if (minSuperflote >= auxSuperflote)
                {
                    for (int j = 0; j < chlSuperFlote.Items.Count; j++)
                    { chlSuperFlote.SetItemChecked(j, false); }
                    chlSuperFlote.SetItemChecked(i, true);
                    minSuperflote = auxSuperflote;
                }
            
               
            }

           


            cmbSuperFlote.SelectedIndex = -1;
            dtDatosFinales.AllowUserToAddRows = false;            
            

            if (Modelo.EncDatosConfiguracion.ConDatos == true)
            {
                Controlador.MetodosFinales.RegresoDatosDF(dtDatosFinales, "Multifamiliar");

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
                Controlador.MetodosFinales.ReciboDatosDF(dtDatosFinales, "Multifamiliar");
            }

            //se llena y calculan los metros en la tabla
            actualizaSuperFloteCalculos();

        }

        private void MDatosFinales_FormClosing(object sender, FormClosingEventArgs e)
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
                        //Al no cancelar inicializa el Guid
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

        private void cmbSuperFlote_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSuperFlote.SelectedIndex != -1)
            {
                //Llena los datos a partir de 
                foreach (DataGridViewRow dtrow in dtDatosFinales.Rows)
                {
                    dtrow.Cells[Modelo.IndexColumn.MDFColumnaSuperfloteTipo].Value = cmbSuperFlote.SelectedItem;
                    checkSFT.Checked = true;

                    //Asingo paso 2
                    lblpaso1.Font = new System.Drawing.Font(lblpaso1.Font, FontStyle.Regular);
                    lblpaso2.Font = new System.Drawing.Font(lblpaso2.Font, FontStyle.Bold);

                    dtrow.Cells[Modelo.IndexColumn.MDFColumnaM2Excedente].Value = 0;

                }

                MessageBox.Show("Favor de asignar M2 Excedentes a las viviendas que correspondan", "M2 Excedentes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void chlSuperFlote_SelectedIndexChanged(object sender, EventArgs e)
        {
            //se llena y calculan los metros en la tabla
            actualizaSuperFloteCalculos();
        }

        //se llena y calculan los metros en la tabla
        private void actualizaSuperFloteCalculos()
        {
            double m2Superficie = 0;
            double auxSuperflote = 0;
            double selSuperflote = 0;
            double m2Diferencia = 100000000;
            bool chlSuperFloteSelected = false;
            bool minDif = true;

            foreach (DataGridViewRow dtrow in dtDatosFinales.Rows)
            {
                m2Diferencia = 100000000;

                if (!double.TryParse(dtrow.Cells[Modelo.IndexColumn.MDFColumnaM2Sup].Value.ToString(), out m2Superficie))
                    m2Superficie = 0;

                dtrow.Cells[Modelo.IndexColumn.MDFColumnaSuperfloteTipo].Value = 0;
                dtrow.Cells[Modelo.IndexColumn.MDFColumnaM2Excedente].Value = 0;


                for (int i = 0; i < chlSuperFlote.Items.Count; i++)
                { 
                    if (chlSuperFlote.GetItemCheckState(i) == CheckState.Checked)
                    {
                        chlSuperFloteSelected = true;

                        if (!double.TryParse(chlSuperFlote.Items[i].ToString(), out auxSuperflote))
                            auxSuperflote = 0;

                        if (m2Superficie - auxSuperflote >= 0 && (m2Superficie - auxSuperflote) <= m2Diferencia)
                        {
                            m2Diferencia = m2Superficie - auxSuperflote;
                            selSuperflote = auxSuperflote;
                            
                        }
                    }

                }
                
                dtrow.Cells[Modelo.IndexColumn.MDFColumnaSuperfloteTipo].Value = selSuperflote;
                dtrow.Cells[Modelo.IndexColumn.MDFColumnaM2Excedente].Value = Math.Round(m2Superficie - selSuperflote, 2);

                if (Math.Round(m2Superficie - selSuperflote, 2) < 0)
                    minDif = false;

                //Asingo paso 2
                lblpaso1.Font = new System.Drawing.Font(lblpaso1.Font, FontStyle.Regular);
                lblpaso2.Font = new System.Drawing.Font(lblpaso2.Font, FontStyle.Bold);

            //    dtrow.Cells[Modelo.IndexColumn.MDFColumnaM2Excedente].Value = 0;

            }
            

            //actualizacion de checkbox de validacion
            checkSFT.Checked = chlSuperFloteSelected;

            if (chlSuperFloteSelected && minDif)
            {
                checkExcedente.Checked = minDif;
            }
            else
            {
                checkExcedente.Checked = false;
            }
            
        }

        private void chkVivVerdefull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVivVerdefull.Checked == true)
                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[Modelo.IndexColumn.MDFViviendaVerde].Value = true;

                }
            else
                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[Modelo.IndexColumn.MDFViviendaVerde].Value = false;
                }
        }

        private void chkMuestrafull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMuestrafull.Checked == true)
                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[Modelo.IndexColumn.MDFMuestra].Value = true;
                }
            else
                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[Modelo.IndexColumn.MDFMuestra].Value = false;
                }
        }

        private void chkDisponiblefull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDisponiblefull.Checked == true)
                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[Modelo.IndexColumn.MDFDisponible].Value = true;
                }
            else
                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[Modelo.IndexColumn.MDFDisponible].Value = false;
                }
        }

        private void chkCablefull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCablefull.Checked == true)
                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[Modelo.IndexColumn.MDFCablevision].Value = true;
                }
            else
                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[Modelo.IndexColumn.MDFCablevision].Value = false;
                }
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
                        dtrow.Cells[Modelo.IndexColumn.MDFColumnaM2Construccion].Value = txtM2Const.Text;
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

        private void btnIrAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea regresar a Módulo Selección de Viviendas?", "Regresar", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MSeleccionaPlano sdp = new MSeleccionaPlano();
                Modelo.EncDatosConfiguracion.ConDatos = true;
                sdp.Show();
                Modelo.EncDatosPlano.M2SuperFloteTipo.Clear();
                Modelo.EncDatosConfiguracion.CierreAuto = true;
                Close();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea ir al Módulo Selección de Datos Iniciales? \n*Se perderán todos los datos", "Inicio",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SelDatosIniciales sdi = new SelDatosIniciales();
                sdi.Show();
                Modelo.EncDatosConfiguracion.CierreAuto = true;

                this.Close();
            }
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

                    Double dareaPl = 0;
                    Double dareachlSuperFlote = 0;

                    try { dareaPl = Double.Parse(areaPl); }
                    catch
                    { dareaPl = 0; }

                    
                    

                    //Buscar el valor mas chico como default
                    bool registroEncontrado = false;
                    for (int i = 0; i < chlSuperFlote.Items.Count; i++)
                    {
                        try { dareachlSuperFlote = Double.Parse(chlSuperFlote.Items[i].ToString()); }
                        catch
                        { dareachlSuperFlote = 0; }

                        if (dareachlSuperFlote == dareaPl)
                        {
                            registroEncontrado = true;
                            chlSuperFlote.SetItemChecked(i, true);
                           // break;
                        }
                       


                    }

                    if (registroEncontrado)
                    {
                        //se llena y calculan los metros en la tabla
                        actualizaSuperFloteCalculos();
                        //Envío señal de paso cumplido
                        checkSFT.Checked = true;
                    }
                    else {
                        MessageBox.Show("El área de la polilínea seleccionada no se encontró en la lista de Tipos de Lotes",
                       "Selección del Plano", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    

                    //foreach (DataGridViewRow dtrow in dtDatosFinales.Rows)
                    //{
                    //    dtrow.Cells[Modelo.IndexColumn.MDFColumnaSuperfloteTipo].Value = areaPl;

                    //    //Asingo paso 2
                    //    lblpaso1.Font = new System.Drawing.Font(lblpaso1.Font, FontStyle.Regular);
                    //    lblpaso2.Font = new System.Drawing.Font(lblpaso2.Font, FontStyle.Bold);

                    //    dtrow.Cells[Modelo.IndexColumn.MDFColumnaM2Excedente].Value = 0;
                    //}

                }
                else
                {
                    MessageBox.Show("La polilínea seleccionada no tiene el layer " + Modelo.EncDatosConfiguracion.LayerViviendas,
                        "Selección del Plano", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                    WindowState = FormWindowState.Maximized;
                }
            }

            WindowState = FormWindowState.Maximized;
            MessageBox.Show("Favor de asignar M2 Excedentes a las viviendas que correspondan", "M2 Excedentes", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        #region Tooltips
        private void chkVivVerdefull_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Asignar Masivamente Vivienda Verde", chkVivVerdefull, 5000);
        }

        private void chkMuestrafull_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Asignar Masivamente Es Muestra", chkMuestrafull, 5000);
        }

        private void chkDisponiblefull_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Asignar Masivamente Disponible", chkDisponiblefull, 5000);
        }

        private void chkCablefull_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Asignar Masivamente Cablevisión", chkCablefull, 5000);
        }

        private void cmbSuperFlote_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Asignar Superficie Lote Tipo", cmbSuperFlote, 5000);
        }

        private void btnAsignSPFT_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Seleccionar del plano Superficie Lote Tipo", btnAsignSPFT, 5000);
        }

        private void btnM2Const_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Asignar Masivamente M2 de Construcción", btnM2Const, 5000);
        }

        #endregion

        private void btnCargaVivs_Click(object sender, EventArgs e)
        {
            if (checkSFT.Checked == true)
            {
                Controlador.MetodosFinales.EnviaBlancoCeldas(dtDatosFinales);

                //Reviso que no haya espacios vacíos
                if (!Controlador.MetodosFinales.SiEmptyoNull(dtDatosFinales, Modelo.IndexColumn.MDFColumnaM2Excedente) &&
                    !Controlador.MetodosFinales.SiEmptyoNull(dtDatosFinales, Modelo.IndexColumn.MDFColumnaM2Construccion))
                {
                    //Reviso que todos sean númericos
                    if (Controlador.MetodosFinales.SiDatoNumerico(dtDatosFinales, Modelo.IndexColumn.MDFColumnaM2Excedente)
                        && Controlador.MetodosFinales.SiDatoNumerico(dtDatosFinales, Modelo.IndexColumn.MDFColumnaM2Construccion))
                    {

                        //Reviso suma de M2 Excedentes
                        if (Controlador.MetodosFinales.SiSumaM2Excedente(dtDatosFinales))
                        {
                            //Envío señal de que cumplió con los 3 pasos correctamente
                            checkExcedente.Checked = true;
                            lblpaso2.Font = new System.Drawing.Font(lblpaso2.Font, FontStyle.Regular);

                            //Comienzo la carga de viviendas
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
                            MessageBox.Show("La Suma de los Excedentes mas el Lote Tipo No coincide con la Superficie Real");
                    }
                    else
                        MessageBox.Show("Datos no númericos en M2 de Construcción y/o M2 Excedentes");

                }
                else
                    MessageBox.Show("Datos vacíos en M2 de Construcción y/o M2 Excedentes");

            }
            else
                MessageBox.Show("Favor de seleccionar Superficie Lote Tipo");

        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            CargaVivForm.lblPorcentaje.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Modelo.EncapsulaBitacora.Bulkresponse.Success == true)
            {
                CargaVivForm.Close();
                CargaVivForm = new CargandoViviendas();
                MBtViviendasError FormVivError = new MBtViviendasError();
                FormVivError.Show();
                Modelo.EncDatosConfiguracion.CierreAuto = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error de conexión, favor de contactar administrador \n Error: " + Modelo.EncapsulaBitacora.Bulkresponse.Error,
                                    "Error en Carga a Sembrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Envío datos a Array
            Controlador.MetodosFinales.CargoDatosFinales(dtDatosFinales, "Multifamiliar");
            
            //Inicializo
            Modelo.EncapsulaBitacora.Bulkresponse = new soaBulk.BulkUploadRs();
            
            //Envío datos a Sembrado
            Modelo.EncapsulaBitacora.Bulkresponse = Controlador.MetodosFinales.CargaViviendas(Modelo.EncDatosPlano.VivsFinales, bkWorker, "Multifamiliar");            
        }

        private void btnCondicionesEspeciales_Click(object sender, EventArgs e)
        {
            if (verCondicionesEspeciales)
            {
                btnCondicionesEspeciales.Text = "Condiciones Especiales";
                dtDatosFinales.Columns["Cablevision"].Visible = false;
                dtDatosFinales.Columns["PermisoConstruccion"].Visible = false;
                dtDatosFinales.Columns["LadoSol"].Visible = false;
                dtDatosFinales.Columns["LadoSombra"].Visible = false;
                dtDatosFinales.Columns["FrenteParque"].Visible = false;
                dtDatosFinales.Columns["FrenteAvenida"].Visible = false;
                dtDatosFinales.Columns["EsEsquina"].Visible = false;
                dtDatosFinales.Columns["Regimen"].Visible = false;
                dtDatosFinales.Columns["Gravamen"].Visible = false;

                dtDatosFinales.Columns["Calle"].Visible = true;
                dtDatosFinales.Columns["M2Superficie"].Visible = true;
                dtDatosFinales.Columns["SuperfloteTipo"].Visible = true;
                dtDatosFinales.Columns["M2Excedente"].Visible = true;
                dtDatosFinales.Columns["M2Construccion"].Visible = true;
                dtDatosFinales.Columns["VivVerde"].Visible = true;
                dtDatosFinales.Columns["Muestra"].Visible = true;
                dtDatosFinales.Columns["Disponible"].Visible = true;
                txtM2Const.Visible = true;
                btnM2Const.Visible = true;
                verCondicionesEspeciales = false;
            }
            else
            {
                btnCondicionesEspeciales.Text = "Datos Finales";
                dtDatosFinales.Columns["Cablevision"].Visible = true;
                //dtDatosFinales.Columns["PermisoConstruccion"].Visible = true;
                dtDatosFinales.Columns["LadoSol"].Visible = true;
                dtDatosFinales.Columns["LadoSombra"].Visible = true;
                dtDatosFinales.Columns["FrenteParque"].Visible = true;
                dtDatosFinales.Columns["FrenteAvenida"].Visible = true;
                dtDatosFinales.Columns["EsEsquina"].Visible = true;
               // dtDatosFinales.Columns["Regimen"].Visible = true;
                dtDatosFinales.Columns["Gravamen"].Visible = true;

                dtDatosFinales.Columns["Calle"].Visible = false;
                dtDatosFinales.Columns["M2Superficie"].Visible = false;
                dtDatosFinales.Columns["SuperfloteTipo"].Visible = false;
                dtDatosFinales.Columns["M2Excedente"].Visible = false;
                dtDatosFinales.Columns["M2Construccion"].Visible = false;
                dtDatosFinales.Columns["VivVerde"].Visible = false;
                dtDatosFinales.Columns["Muestra"].Visible = false;
                dtDatosFinales.Columns["Disponible"].Visible = false;
                txtM2Const.Visible = false;
                btnM2Const.Visible = false;
                verCondicionesEspeciales = true;
            }
        }

        private void dtDatosFinales_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool seleccionarTodos = true;


            if (e.ColumnIndex == Modelo.IndexColumn.MDFViviendaVerde || e.ColumnIndex == Modelo.IndexColumn.MDFMuestra
            || e.ColumnIndex == Modelo.IndexColumn.MDFDisponible || e.ColumnIndex == Modelo.IndexColumn.MDFCablevision
            || e.ColumnIndex == Modelo.IndexColumn.MDFPermisoConstruccion || e.ColumnIndex == Modelo.IndexColumn.MDFLadoSol
            || e.ColumnIndex == Modelo.IndexColumn.MDFLadoSombra || e.ColumnIndex == Modelo.IndexColumn.MDFFrenteParque
            || e.ColumnIndex == Modelo.IndexColumn.MDFFrenteAvenida || e.ColumnIndex == Modelo.IndexColumn.MDFEsEsquina
            || e.ColumnIndex == Modelo.IndexColumn.MDFRegimen || e.ColumnIndex == Modelo.IndexColumn.MDFGravamen)
            {
                dtDatosFinales.EndEdit();
                dtDatosFinales.CurrentCell = null;

                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {

                    if (((Convert.ToBoolean(dtgvrow.Cells[e.ColumnIndex].Value) ? 1 : 0).ToString()) == "1")
                    {
                        seleccionarTodos = false;
                    }
                    else { seleccionarTodos = true; }
                    break;
                }

                foreach (DataGridViewRow dtgvrow in dtDatosFinales.Rows)
                {
                    dtgvrow.Cells[e.ColumnIndex].Value = seleccionarTodos;
                }

            }
        }
    }
    }
