using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel.Channels;
using System.Xml;

namespace PluginInsViviendas_UNO.Vista
{
    public partial class SelDatosIniciales : Form
    {
        public SelDatosIniciales()
        {
            InitializeComponent();
        }

        //Declaro solicitud y recepción de servicio Fraccionamientos SOA
        private soaFracc.GetFraccionamientosRq solicitoFracc = new soaFracc.GetFraccionamientosRq();
        private soaFracc.GetFraccionamientosRs reciboFracc = new soaFracc.GetFraccionamientosRs();

        //Declaro solicitud y recepción de servicio Prototipos SOA
        private soaPrototipos.GetPrototiposRq solicitoPrototipos = new soaPrototipos.GetPrototiposRq();
        private soaPrototipos.GetPrototiposRs reciboPrototipos = new soaPrototipos.GetPrototiposRs();

        //Elimina Conjunto Seleccionado
        public bool ActualizaConjunto;

        private void SelDatosIniciales_Load(object sender, EventArgs e)
        {            
            if (Modelo.EncDatosServicio.FraccsRecibidos != null && Modelo.EncDatosServicio.ProtosRecibidos != null)
            {
                if (Modelo.EncDatosServicio.FraccsRecibidos.Count() > 0 && Modelo.EncDatosServicio.ProtosRecibidos.Count() > 0)
                {
                    //Despliego al usuario que ya tiene datos cargados
                    lblsetEstatus.Text = "Online";
                    lblsetEstatus.ForeColor = Color.Green;
                    btnIniciarSesion.Text = "Sesión Iniciada";
                    btnIniciarSesion.Enabled = false;
                    btnRefresh.Visible = true;
                    lblResUser.Text = Modelo.EncDatosIniciales.User;

                    //Habilito los combobox
                    cmbPrototipo.Enabled = true;
                    cmbFraccionamiento.Enabled = true;
                    cmbFrente.Enabled = true;
                    cmbConjunto.Enabled = true;
                    SiMultifamiliar.Enabled = true;

                    //Agrego directamente los prototipos
                    for (int i = 0; i < Modelo.EncDatosServicio.ProtosRecibidos.Count(); i++)
                    {
                        cmbPrototipo.Items.Add(Modelo.EncDatosServicio.ProtosRecibidos[i].Name);
                    }

                    //Agrego a comobox lo insertado en la lista
                    foreach (String indFracc in Modelo.EncDatosServicio.ListaFraccNombres)
                    {
                        cmbFraccionamiento.Items.Add(indFracc);
                    }

                    foreach (String indFrente in Modelo.EncDatosServicio.ListaFrentesNombres)
                    {
                        cmbFrente.Items.Add(indFrente);
                    }

                    foreach (String indConjunto in Modelo.EncDatosServicio.ListaConjuntosNombres)
                    {
                        cmbConjunto.Items.Add(indConjunto);
                    }

                    cmbPrototipo.SelectedIndex = Modelo.EncDatosIniciales.ComboIndexProto;
                    cmbFraccionamiento.SelectedIndex = Modelo.EncDatosIniciales.ComboIndexFracc;
                    cmbFrente.SelectedIndex = Modelo.EncDatosIniciales.ComboIndexFrente;
                    cmbConjunto.SelectedIndex = Modelo.EncDatosIniciales.ComboIndexConjunto;
                    SiMultifamiliar.Checked = Modelo.EncDatosIniciales.EsMultifamiliar;

                    if (ActualizaConjunto == true)
                    {
                        cmbConjunto.SelectedIndex = -1;
                        lblValueVivPdts.Visible = false;
                        lblVivPendientes.Visible = false;
                    }
                    else
                    {
                        cmbConjunto.SelectedIndex = Modelo.EncDatosIniciales.ComboIndexConjunto;
                    }
                }
                else
                {
                    //Obtengo Usuario e IP y asigno a el Encapsulado de Datos
                    Controlador.DatosSesion.AsignaUsuarioIP();
                    lblResUser.Text = Modelo.EncDatosIniciales.User;
                }
            }
            else
            {
                //Obtengo Usuario e IP y asigno a el Encapsulado de Datos
                Controlador.DatosSesion.AsignaUsuarioIP();
                lblResUser.Text = Modelo.EncDatosIniciales.User;
            }
        }

        private void cmbFraccionamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Limpia combobox y lista de los frentes,conjuntos
            cmbFrente.SelectedIndex = -1;
            cmbConjunto.SelectedIndex = -1;
            lblVivPendientes.Visible = false;
            lblValueVivPdts.Visible = false;
            cmbFrente.Items.Clear();
            Modelo.EncDatosServicio.ListaFrentesNombres.Clear();
            Modelo.EncDatosServicio.ListaFrentesIndex.Clear();
            Modelo.EncDatosServicio.ListaConjuntosNombres.Clear();
            Modelo.EncDatosServicio.ListaConjuntosIndex.Clear();

            if (cmbFraccionamiento.SelectedIndex != -1)
            {
                Modelo.EncDatosIniciales.ComboIndexFracc = cmbFraccionamiento.SelectedIndex;
                //Encapsulo el index y nombre del fraccionamiento seleccionado
                Modelo.EncDatosIniciales.Fraccionamiento = cmbFraccionamiento.SelectedItem.ToString();
                Modelo.EncDatosIniciales.IndexFraccionamiento = Modelo.EncDatosServicio.ListaFraccIndex[Modelo.EncDatosIniciales.ComboIndexFracc];

                //Reviso que si haya Frentes dentro del fraccionamiento seleccionado
                if (Modelo.EncDatosServicio.FraccsRecibidos[Modelo.EncDatosIniciales.IndexFraccionamiento].Frentes.Frente != null)
                {
                    for (int i = 0; i < Modelo.EncDatosServicio.FraccsRecibidos[Modelo.EncDatosIniciales.IndexFraccionamiento].Frentes.Frente.Count();
                            i++)
                    {
                        if (Modelo.EncDatosServicio.FraccsRecibidos[Modelo.EncDatosIniciales.IndexFraccionamiento].Frentes.Frente[i].Estatus == "1")
                        {
                            Modelo.EncDatosServicio.ListaFrentesNombres.Add(Modelo.EncDatosServicio.FraccsRecibidos[Modelo.EncDatosIniciales.
                                                                       IndexFraccionamiento].Frentes.Frente[i].Name);
                            Modelo.EncDatosServicio.ListaFrentesIndex.Add(i);
                        }
                    }

                    foreach (String indFrente in Modelo.EncDatosServicio.ListaFrentesNombres)
                    {
                        cmbFrente.Items.Add(indFrente);
                    }

                    cmbFrente.SelectedIndex = -1;
                    this.cmbFrente.Enabled = true;
                }
                //En dado caso que no haya frentes, despliego mensaje
                else
                {
                    MessageBox.Show(Modelo.EncDatosIniciales.Fraccionamiento + " no cuenta con Frentes");
                }
            }
        }

        private void cmbFrente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Limpia combobox y lista de los frentes,conjuntos
            cmbConjunto.SelectedIndex = -1;
            lblVivPendientes.Visible = false;
            lblValueVivPdts.Visible = false;
            cmbConjunto.Items.Clear();
            Modelo.EncDatosServicio.ListaConjuntosNombres.Clear();
            Modelo.EncDatosServicio.ListaConjuntosIndex.Clear();

            if (cmbFrente.SelectedIndex != -1)
            {
                Modelo.EncDatosIniciales.ComboIndexFrente = cmbFrente.SelectedIndex;
                //Asigno el frente seleccionado y al index del servicio
                Modelo.EncDatosIniciales.Frente = this.cmbFrente.SelectedItem.ToString();
                Modelo.EncDatosIniciales.IndexFrente = Modelo.EncDatosServicio.ListaFrentesIndex[cmbFrente.SelectedIndex];

                //Asigno Fideicomiso
                Modelo.EncDatosIniciales.SiFideicomiso = Modelo.EncDatosServicio.FraccsRecibidos[Modelo.EncDatosIniciales.IndexFraccionamiento].
                                                                Frentes.Frente[Modelo.EncDatosIniciales.IndexFrente].FideicomisoFlag;

                if (Modelo.EncDatosIniciales.SiFideicomiso == true)
                {
                    Modelo.EncDatosIniciales.Fideicomiso = Modelo.EncDatosServicio.FraccsRecibidos[Modelo.EncDatosIniciales.IndexFraccionamiento].Frentes
                        .Frente[Modelo.EncDatosIniciales.IndexFrente].Fideicomiso.Description;
                    chkFideicomiso.CheckState = CheckState.Checked;
                }
                else
                {
                    Modelo.EncDatosIniciales.Fideicomiso = "";
                    chkFideicomiso.CheckState = CheckState.Unchecked;
                }
                //------------------------------------------------

                //Valido que haya conjuntos en frente seleccionado
                if (Modelo.EncDatosServicio.FraccsRecibidos[Modelo.EncDatosIniciales.IndexFraccionamiento].//Nivel Fraccionamientos
                                Frentes.Frente[Modelo.EncDatosIniciales.IndexFrente].//Nivel Frentes
                                Conjuntos.Conjunto != null) //Nivel Conjuntos
                {
                    for (int i = 0; i < Modelo.EncDatosServicio.FraccsRecibidos[Modelo.EncDatosIniciales.IndexFraccionamiento].//Nivel Fraccionamientos
                                Frentes.Frente[Modelo.EncDatosIniciales.IndexFrente].//Nivel Frentes
                                Conjuntos.Conjunto.Count(); i++)
                    {
                        if (Modelo.EncDatosServicio.FraccsRecibidos[Modelo.EncDatosIniciales.IndexFraccionamiento].
                                                              Frentes.Frente[Modelo.EncDatosIniciales.IndexFrente]
                                                              .Conjuntos.Conjunto[i].Estatus == "1")
                        {
                            Modelo.EncDatosServicio.ListaConjuntosNombres.Add(Modelo.EncDatosServicio.FraccsRecibidos[Modelo.EncDatosIniciales.
                                                                       IndexFraccionamiento].Frentes.Frente[Modelo.EncDatosIniciales.IndexFrente]
                                                                       .Conjuntos.Conjunto[i].Name);
                            Modelo.EncDatosServicio.ListaConjuntosIndex.Add(i);
                        }
                    }

                    foreach (String indConjunto in Modelo.EncDatosServicio.ListaConjuntosNombres)
                    {
                        cmbConjunto.Items.Add(indConjunto);
                    }
                }

                this.cmbConjunto.Enabled = true;
            }
        }

        private void cmbPrototipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrototipo.SelectedIndex > -1)
            {
                Modelo.EncDatosIniciales.ComboIndexProto = cmbPrototipo.SelectedIndex;
                Modelo.EncDatosIniciales.Prototipo = this.cmbPrototipo.SelectedItem.ToString();
            }
        }

        private void cmbConjunto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Maximas = new int();
            int Cargadas = new int();
            if (cmbConjunto.SelectedIndex != -1)
            {
                Modelo.EncDatosIniciales.ComboIndexConjunto = cmbConjunto.SelectedIndex;
                Modelo.EncDatosIniciales.Conjunto = this.cmbConjunto.SelectedItem.ToString();
                this.btnSiguiente.Visible = true;
                                //Asigno Fideicomiso

                Modelo.EncDatosIniciales.ViviendasMaximas = Modelo.EncDatosServicio.FraccsRecibidos[Modelo.EncDatosIniciales.IndexFraccionamiento].
                                                                Frentes.Frente[Modelo.EncDatosIniciales.IndexFrente].Conjuntos.Conjunto[cmbConjunto.SelectedIndex].HomeQuantity;

                Modelo.EncDatosIniciales.ViviendasCargadas = Modelo.EncDatosServicio.FraccsRecibidos[Modelo.EncDatosIniciales.IndexFraccionamiento].
                                                                Frentes.Frente[Modelo.EncDatosIniciales.IndexFrente].Conjuntos.
                                                                Conjunto[Modelo.EncDatosServicio.ListaConjuntosIndex[cmbConjunto.SelectedIndex]].
                                                                HomeRegisteredQuantity;

                Boolean siMaxima = int.TryParse(Modelo.EncDatosIniciales.ViviendasMaximas, out Maximas);

                Boolean siCargadas = int.TryParse(Modelo.EncDatosIniciales.ViviendasCargadas, out Cargadas);

                //Reviso que se haya recibido números
                if (siCargadas == true && siMaxima == true)
                {
                    Modelo.EncDatosIniciales.ViviendasPendientes = (Maximas - Cargadas).ToString();

                    if (Convert.ToInt32(Modelo.EncDatosIniciales.ViviendasPendientes) >= 0)
                    {
                        lblVivPendientes.Visible = true;
                        lblValueVivPdts.Text = Modelo.EncDatosIniciales.ViviendasPendientes;
                        lblValueVivPdts.Visible = true;
                    }
                    else
                    {
                        lblValueVivPdts.Visible = true;
                        lblVivPendientes.Visible = true;
                        Modelo.EncDatosIniciales.ViviendasPendientes = "0";
                        lblValueVivPdts.Text = Modelo.EncDatosIniciales.ViviendasPendientes;
                    }
                }
                else
                {
                    lblVivPendientes.Visible = false;
                    lblValueVivPdts.Visible = false;
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {       //Reviso que ningun valor este null
            if (cmbConjunto.SelectedItem != null && (cmbPrototipo.SelectedItem != null || SiMultifamiliar.Checked == true)
                && cmbFraccionamiento.SelectedItem != null && cmbFrente.SelectedItem != null)
            {

                //Reviso que ningun valor este vacío
                if (cmbConjunto.SelectedItem.ToString() != "" && ((cmbPrototipo.SelectedItem ?? "").ToString() != "" || SiMultifamiliar.Checked == true)
                && cmbFraccionamiento.SelectedItem.ToString() != "" && cmbFrente.SelectedItem.ToString() != "")
                {
                    //Reviso que haya viviendas para cargar, en dado caso que no, no dejo avanzar
                    if ((Convert.ToInt32(Modelo.EncDatosIniciales.ViviendasPendientes)) > 0)
                    {
                        //Si el fideicomiso esta desactivado muestro advertencia
                        if (chkFideicomiso.CheckState == CheckState.Unchecked)
                        {
                            MessageBox.Show("El Frente no cuenta con Fideicomiso", "Información del Frente", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                            if(!SiMultifamiliar.Checked)
                            { 
                                Unifamiliar.USelDatosPlano sdp = new Unifamiliar.USelDatosPlano();
                                //P3_CompDatos.V.BtViviendasError sdp = new P3_CompDatos.V.BtViviendasError();

                                sdp.Show();
                                Modelo.EncDatosConfiguracion.CierreAuto = true;
                                this.Close();
                            }
                            else
                            {
                                Multifamiliar.MSelPrototipos msp = new Multifamiliar.MSelPrototipos();
                                msp.Show();
                                Modelo.EncDatosConfiguracion.CierreAuto = true;
                                this.Close();
                            }
                        }
                        else
                        {
                            if (!SiMultifamiliar.Checked)
                            {
                                Unifamiliar.USelDatosPlano sdp = new Unifamiliar.USelDatosPlano();
                                sdp.Show();
                                Modelo.EncDatosConfiguracion.CierreAuto = true;
                                this.Close();
                            }
                            else
                            {
                                Multifamiliar.MSelPrototipos msp = new Multifamiliar.MSelPrototipos();
                                msp.Show();
                                Modelo.EncDatosConfiguracion.CierreAuto = true;
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay viviendas pendientes para este conjunto", "Información del Conjunto", MessageBoxButtons.OK,
                                        MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    Autodesk.AutoCAD.ApplicationServices.Core.Application.ShowAlertDialog("Favor de llenar todos los datos");
            }
            else
                Autodesk.AutoCAD.ApplicationServices.Core.Application.ShowAlertDialog("Favor de llenar todos los datos");
        }

        //Ejecución del botón que envía señal para llamar Servicio
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            this.lblConectando.Visible = true;
            progressBar.Visible = true;
            btnIniciarSesion.Enabled = false;

            //Background Work
            bkWork = new BackgroundWorker();
            bkWork.WorkerReportsProgress = true;
            bkWork.DoWork += new DoWorkEventHandler(BGWorker_DoWork);
            if (bkWork.IsBusy == false)
            {
                bkWork.RunWorkerAsync();
            }
            bkWork.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bkWork.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
        }

        //Comienza el llamado del servicio SOA
        public void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {            
            //1. Binding agregandole transporte y parametros para ambos servicios
            CustomBinding csBinding = Controlador.ConfiguraServicio.AsignaCustomBinding();
            bkWork.ReportProgress(10);
       //----------------------------------------------------------------------------------------------------------------
            #region LlamaServicioPrototipos
            //2. Asigno URL de endpoint de Protototipos
            EndpointAddress endpointAddressPrototipos= new
            EndpointAddress(Modelo.EncDatosServicio.WsdlPrototipos);

            bkWork.ReportProgress(20);

            //3. Declaro Cliente asignandole binding y URL de prototipo
            soaPrototipos.CatPrototiposPortTypeClient serviceClientProto =
                new soaPrototipos.CatPrototiposPortTypeClient(csBinding, endpointAddressPrototipos);
            bkWork.ReportProgress(30);

            //Autentico mediante credenciales del usuario
            solicitoPrototipos.IP_Address = Modelo.EncDatosIniciales.Ip;
            solicitoPrototipos.RequestedAccess = "PF_ALTA_VIV";
            solicitoPrototipos.Username = Modelo.EncDatosIniciales.User;//Usuario Correcto
            solicitoPrototipos.RequestDate = DateTime.Now;
            solicitoPrototipos.SourceSystem = "AUTODESK";
            solicitoPrototipos.Version = "1";            
            //-------------------------------------------------------

            //Recibo Datos de Prototipos
            reciboPrototipos = serviceClientProto.GetPrototipos(solicitoPrototipos);
            bkWork.ReportProgress(40);
            #endregion

            #region LlamaServicioFraccionamiento
            //Crea EndPoint de Servicio SOA Fraccionamiento
            EndpointAddress endpointAddressFraccionamiento = new
            EndpointAddress(Modelo.EncDatosServicio.WsdlFraccs);

            //-------------------------------------------------------------------------

            //Instancia Cliente de Servicio SOA Fraccionamiento, solicitud y recepción
            soaFracc.CatFraccionamientosPortTypeClient serviceClientFracc =
               new soaFracc.CatFraccionamientosPortTypeClient(csBinding, endpointAddressFraccionamiento);
            bkWork.ReportProgress(60);
            //-------------------------------------------------------------------------

            //Autentico mediante credenciales del usuario
            solicitoFracc.IP_Address = Modelo.EncDatosIniciales.Ip;
            solicitoFracc.RequestedAccess = "PF_ALTA_VIV";
            solicitoFracc.Username = Modelo.EncDatosIniciales.User;
            solicitoFracc.RequestDate = DateTime.Now;
            solicitoFracc.SourceSystem = "AUTODESK";
            solicitoFracc.Version = "1";
            bkWork.ReportProgress(80);
            //------------------------------------------------------------------------ 
          
            //Realizo solicitud de datos de Fraccionamientos
            reciboFracc = serviceClientFracc.GetFraccionamientosByUserAndRight(solicitoFracc);
            bkWork.ReportProgress(100);
            //-------------------------------------------------------------------------
            #endregion

        }

        //Se ejecuta una vez que el llamado al servicio SOA terminó
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Boolean SiFraccionamientos = false;
                SiFraccionamientos = reciboFracc.Success;
            Boolean SiPrototipos = false;
                SiPrototipos = reciboPrototipos.Success;
            
            if (SiFraccionamientos == true && SiPrototipos == true)
            {
                //Despliego la conexión
                btnIniciarSesion.Text = "Sesión Iniciada";
                btnIniciarSesion.ForeColor = Color.Green;
                lblConectando.Visible = false;
                progressBar.Visible = false;
                lblsetEstatus.Text = "Online";
                lblsetEstatus.ForeColor = Color.Green;
                btnRefresh.Visible = true;

                //Encapsulo Datos Recibidos
                Modelo.EncDatosServicio.FraccsRecibidos = reciboFracc.Fraccionamientos.Fraccionamiento;
                Modelo.EncDatosServicio.ProtosRecibidos = reciboPrototipos.Prototipos.Prototipo;

                //Asigno los Fraccionamietos en el combobox siempre y cuando tenga permiso a ellos ( Si no se recibe como null)
                if (Modelo.EncDatosServicio.FraccsRecibidos != null && Modelo.EncDatosServicio.ProtosRecibidos != null)
                {
                    //Agrego a listas tanto el nombre como la posición del servicio
                    for (int i = 0; i < Modelo.EncDatosServicio.FraccsRecibidos.Count(); i++) //
                    {
                        if (Modelo.EncDatosServicio.FraccsRecibidos[i].Estatus == "1")
                        {
                            Modelo.EncDatosServicio.ListaFraccNombres.Add(Modelo.EncDatosServicio.FraccsRecibidos[i].Name);
                            Modelo.EncDatosServicio.ListaFraccIndex.Add(i);
                        }
                    }

                    //Agrego a comobox lo insertado en la lista
                    foreach (String indFracc in Modelo.EncDatosServicio.ListaFraccNombres)
                    {
                        cmbFraccionamiento.Items.Add(indFracc);
                    }                    

                    //Agrego directamente los prototipos
                    for (int i = 0; i < Modelo.EncDatosServicio.ProtosRecibidos.Count(); i++)
                    {
                        cmbPrototipo.Items.Add(reciboPrototipos.Prototipos.Prototipo[i].Name);
                    }

                    //Habilito los dos  combobox
                    cmbPrototipo.Enabled = true;
                    SiMultifamiliar.Enabled = true;
                    cmbFraccionamiento.Enabled = true;

                    //Ordeno Comboboxs 
                    cmbFraccionamiento.SelectedIndex = -1;
                    cmbPrototipo.SelectedIndex = -1;
                    cmbPrototipo.Sorted = true;
                }
                //Valido que no tengo acceso y no despliego nada
                else
                    MessageBox.Show("Favor de revisar permisos en Sembrado \n del usuario "+Modelo.EncDatosIniciales.User);
            }
            else
            {
                MessageBox.Show("Error de conexión favor de contactar al administrador","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblConectando.Visible = false;
                progressBar.Visible = false;
            }





        }

        //Despliega visualmente el porcentaje cambiado
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void SelDatosIniciales_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //Cambio visibilidad
            this.lblConectando.Visible = true;
            progressBar.Visible = true;
            lblValueVivPdts.Visible = false;
            lblVivPendientes.Visible = false;
            btnSiguiente.Visible = false;
            //Deshabilito los combobox          
            cmbConjunto.Enabled = false;            
            cmbFrente.Enabled = false;          
            cmbFraccionamiento.Enabled = false;            
            cmbPrototipo.Enabled = false;
            SiMultifamiliar.Enabled = false;

            //Limpio los combobox para que sean nuevamente insertados
            cmbPrototipo.Items.Clear();
            cmbFraccionamiento.Items.Clear();
            cmbFrente.Items.Clear();
            cmbConjunto.Items.Clear();

            bkWork = new BackgroundWorker();
            bkWork.WorkerReportsProgress = true;
            bkWork.DoWork += new DoWorkEventHandler(BGWorker_DoWork);
            if (bkWork.IsBusy == false)
            {
                bkWork.RunWorkerAsync();
            }
            bkWork.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bkWork.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
        }

        private void SiMultifamiliar_CheckedChanged(object sender, EventArgs e)
        {
            if(SiMultifamiliar.Checked == true)
            {
                cmbPrototipo.SelectedIndex = -1;
                cmbPrototipo.Enabled = false;
                Modelo.EncDatosIniciales.EsMultifamiliar = true;
            }
            else
            {
                cmbPrototipo.Enabled = true;
                Modelo.EncDatosIniciales.EsMultifamiliar = false;
            }
        }
    }
}
