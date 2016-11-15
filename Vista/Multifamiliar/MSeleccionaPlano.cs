using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.AutoCAD.Geometry;
using System.Collections;
using System.Collections.Generic;

namespace PluginInsViviendas_UNO.Vista.Multifamiliar
{
    public partial class MSeleccionaPlano : Form
    {         
        public string   manzanaActual = "", 
                        direccion = "",
                        msjRetorno="";

        ToolTip t1 = new ToolTip();

        private void MSeleccionaPlano_FormClosing(object sender, FormClosingEventArgs e)
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
                    Modelo.EncDatosConfiguracion.CierreAuto= false;
                    break;
                default:
                    Modelo.EncDatosIniciales.EstaAbierto = false;
                    Controlador.MetodosFinales.LimpiaTodoEncapsulado(true, true, true);
                    break;
            }
        }

        public MSeleccionaPlano()
        {
            InitializeComponent();
        }

        private void MSeleccionaPlano_Load(object sender, EventArgs e)
        {
            setConjunto.Text = Modelo.EncDatosIniciales.Conjunto;
            cmDecimales.SelectedItem = "2";

            Modelo.EncDatosPlano.Decimales = int.Parse(cmDecimales.SelectedItem.ToString());

            Modelo.EncDatosIniciales.ViviendasPendientes = (Convert.ToInt32(Modelo.EncDatosIniciales.ViviendasMaximas) -
                            Convert.ToInt32(Modelo.EncDatosIniciales.ViviendasCargadas)).ToString();

            lblResViviendas.Text = Modelo.EncDatosIniciales.ViviendasPendientes;

            if (Modelo.EncDatosConfiguracion.ConDatos == true)
            {
                Controlador.MetodosFinales.RegresoDatosSDP(dtDatosPlano, "Multifamiliar");

                Modelo.EncDatosConfiguracion.ConDatos = false;
            }

        }

        /*----------------------------------------------PASOS----------------------------------------------*/
        
        #region PASO 1

        private void btnSelManzana_Click(object sender, EventArgs e)
        {
            ObjectId idManzana = new ObjectId();
            DBText TextManzana = new DBText();

            this.WindowState = FormWindowState.Minimized;

            //Se solicita la entidad solamente de tipo DB Text
            if (Controlador.MetodosPlano.SeleccionaEntidadTipo("\n Seleccione la Manzana", out idManzana, typeof(DBText)))
            {
                //Abrimos la entidad DBText
                TextManzana = Controlador.MetodosPlano.AbrirEntidad(idManzana) as DBText;

                //Validamos que el layer en el que se encuentra el DBText sea el correcto
                if (TextManzana.Layer.ToUpper() == Modelo.EncDatosConfiguracion.LayerManzana)
                {
                    manzanaActual = TextManzana.TextString;
                    setManActual.Text = TextManzana.TextString;
                    lblSelManzana.ForeColor = Color.Black;
                    btnCambiaManzana.Visible = true;
                    btnSelManzana.Enabled = false;
                    btnSelDireccion.Enabled = true;
                    btnCambiaDireccion.Enabled = true;
                }
                else
                {
                    Autodesk.AutoCAD.ApplicationServices.Core.Application.ShowAlertDialog("La selección no pertenece a la capa: " + Modelo.EncDatosConfiguracion.LayerManzana);
                }

            }

            this.WindowState = FormWindowState.Normal;
        }

        private void btnCambiaManzana_Click(object sender, EventArgs e)
        {
            //Habilito Paso Actual
            btnSelManzana.Enabled = true;
            lblSelManzana.ForeColor = Color.Red;
            btnCambiaManzana.Visible = false;

            //Deshabilito Paso 2
            btnSelDireccion.Enabled = false;
            btnCambiaDireccion.Enabled = false;            
        }


        #endregion

        #region PASO 2

        private void btnSelDireccion_Click(object sender, EventArgs e)
        {
            ObjectId idDireccion = new ObjectId();
            DBText TextDireccion = new DBText();

            this.WindowState = FormWindowState.Minimized;

            //Se solicita la entidad solamente de tipo DB Text
            if (Controlador.MetodosPlano.SeleccionaEntidadTipo("\n Seleccione la Dirección", out idDireccion, typeof(DBText)))
            {
                //Abrimos la entidad DBText
                TextDireccion = Controlador.MetodosPlano.AbrirEntidad(idDireccion) as DBText;

                if (TextDireccion.Layer.ToUpper() == Modelo.EncDatosConfiguracion.LayerDireccion)
                {
                    direccion = TextDireccion.TextString;
                    setDireccionActual.Text = TextDireccion.TextString;
                    lblSelDireccion.ForeColor = Color.Black;
                    btnCambiaManzana.Visible = true;
                    btnCambiaDireccion.Visible = true;
                    btnSelDireccion.Enabled = false;
                    btnSelMultiple.Enabled = true;
                    btnSelUnica.Enabled = true;
                    btnCambiaManzana.Enabled = true;

                }
                else
                {
                    Autodesk.AutoCAD.ApplicationServices.Core.Application.ShowAlertDialog("La selección no pertenece a la capa: "
                                                                                            + Modelo.EncDatosConfiguracion.LayerDireccion);
                }

                WindowState = FormWindowState.Normal;
            }
        }

        private void dtDatosPlano_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //Inicializo contador y resultado
            int conteoActual = new int(), PendienteReal = new int();
            lblResViviendas.ForeColor = Color.SteelBlue;
            lblVivPndts.ForeColor = Color.Black;

            conteoActual = dtDatosPlano.Rows.Count;

            PendienteReal = Convert.ToInt32(Modelo.EncDatosIniciales.ViviendasPendientes) - conteoActual;

            lblResViviendas.Text = PendienteReal.ToString();
        }

        private void dtDatosPlano_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblResViviendas.ForeColor = Color.SteelBlue;
            lblVivPndts.ForeColor = Color.Black;
            //Inicializo contador y resultado
            int conteoActual = new int(), PendienteReal = new int();

            conteoActual = dtDatosPlano.Rows.Count;

            PendienteReal = Convert.ToInt32(Modelo.EncDatosIniciales.ViviendasPendientes) - conteoActual;

            lblResViviendas.Text = PendienteReal.ToString();
        }

        private void btnCambiaDireccion_Click(object sender, EventArgs e)
        {
            btnSelDireccion.Enabled = true;
            lblSelDireccion.ForeColor = Color.Red;
            btnCambiaDireccion.Visible = false;
            btnCambiaManzana.Enabled = false;
        }

        private void checkSD_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSD.Checked == true)
            {
                btnSelDireccion.Visible = false;
                direccion = "";
                groupDireccion.ForeColor = Color.LightGray;
                lblSelDireccion.ForeColor = Color.LightGray;
                btnCambiaDireccion.ForeColor = Color.LightGray;
                btnCambiaDireccion.Visible = false;
                btnSelDireccion.Enabled = false;
                setDireccionActual.Text = "Sin Dirección";
                btnSelMultiple.Enabled = true;
                btnSelUnica.Enabled = true;

            }

            if (checkSD.Checked == false)
            {
                btnSelDireccion.Visible = true;
                groupDireccion.ForeColor = Color.SteelBlue;
                lblSelDireccion.ForeColor = Color.Black;
                btnCambiaDireccion.ForeColor = Color.Black;
                btnSelDireccion.Enabled = true;
                setDireccionActual.Text = "Pendiente";
                btnSelMultiple.Enabled = false;
                btnSelUnica.Enabled = false;

            }
        }

        #endregion

        #region PASO 3

        private void btnSelUnica_Click(object sender, EventArgs e)
        {
            //Inicializo las variables
            ObjectId IdVivienda = new ObjectId();
            Polyline pl = new Polyline();

            Point3dCollection   pts = new Point3dCollection();
            ObjectIdCollection  IdLotes = new ObjectIdCollection(),                                
                                IdsUnidadPrivativa = new ObjectIdCollection(),
                                IdsNoOficial = new ObjectIdCollection(),
                                ViviendasContenidas = new ObjectIdCollection();
            Point3d min = new Point3d(),
                    max = new Point3d();          

            ArrayList   listaIdsComparar = new ArrayList(),
                        listaIdsRepetidos = new ArrayList();
            ComboBox    cmbNoOficial = new ComboBox();

            WindowState = FormWindowState.Minimized;
            if (Controlador.MetodosPlano.SeleccionaEntidadTipo("\n Selecciona una Vivienda ", out IdVivienda, typeof(Polyline)))
            {

                pl = Controlador.MetodosPlano.AbrirEntidad(IdVivienda) as Polyline;

                //Remuevo espacios del nombre del layer y lo pongo en mayusculas
                string plstring = (pl.Layer.ToUpper().Replace(" ", string.Empty));

                if (plstring == Modelo.EncDatosConfiguracion.LayerViviendas)
                {
                    //Valido que la vivienda que se recibió esta insertada, en dado caso que si la elimino
                    if (!Controlador.MetodosPlano.ValidaNoRepetirVivienda(IdVivienda, dtDatosPlano))
                    {
                        Modelo.EncDatosConfiguracion.MsjGlobal.Add("ID Actualizado: " + IdVivienda);
                    }

                    //Inicializo Variables
                    string NumeroLote = "",
                            NumeroOficial = "",
                            Areapl = "",
                            strUnidadPrivativa = "";
                                                                                     

                    //Obtengo punto mínimo de la polílinea para obtener Viviendas - Numero Interior
                    min = pl.GeometricExtents.MinPoint;
                    max = pl.GeometricExtents.MaxPoint;

                    //Extraigo vertices para Obtener Lote, Numero Interior, Unidad Privativa
                    pts = Controlador.MetodosPlano.ExtraerVertices(IdVivienda);

                    #region Valores Calculados 1 vez (Lote, No. Oficial, M2 Superficie, UP)

                    //Obtengo el número de lote ----------------------------------------------------------------------------------------                           
                    IdLotes = Controlador.MetodosPlano.TomarEntidadLayer(Modelo.EncDatosConfiguracion.LayerLote, pts, out msjRetorno);

                    if (msjRetorno == "")
                    {
                        foreach (ObjectId idlote in IdLotes)
                        {
                            if (IdLotes.Count == 1 && IdLotes != null)
                            {
                                NumeroLote = (Controlador.MetodosPlano.AbrirEntidad(idlote) as DBText).TextString;
                                
                            }
                            else if (IdLotes.Count > 1)
                            {
                                Modelo.EncDatosConfiguracion.MsjGlobal.Add("Se tiene más de un elemento en la capa: " + Modelo.EncDatosConfiguracion.LayerLote);
                            }
                            else
                            {
                                Modelo.EncDatosConfiguracion.MsjGlobal.Add("No se encontraron elementos en la capa: " + Modelo.EncDatosConfiguracion.LayerLote);
                            }
                        }
                    }
                    else
                    {
                        Modelo.EncDatosConfiguracion.MsjGlobal.Add(msjRetorno);
                    }
                    //--------------------------------------------------------------------------------------------------------


                    //Número Oficial---------------------------------------------------------------------------------------------------
                   
                    IdsNoOficial = Controlador.MetodosPlano.TomaNoOficialLayer(pl, Modelo.EncDatosConfiguracion.LayerNoOficial,
                                                                                    Modelo.EncDatosConfiguracion.FactorEscala);

                    foreach (ObjectId idNoOficial in IdsNoOficial)
                    {
                        if (IdsNoOficial.Count == 1)
                        {
                            NumeroOficial = (Controlador.MetodosPlano.AbrirEntidad(idNoOficial) as DBText).TextString;

                            cmbNoOficial.Items.Add(NumeroOficial);                           
                        }
                        else if (IdsNoOficial.Count > 1)
                        {
                            NumeroOficial = (Controlador.MetodosPlano.AbrirEntidad(idNoOficial) as DBText).TextString;
                            cmbNoOficial.Items.Add(NumeroOficial);                           
                        }
                        else
                        {
                            Modelo.EncDatosConfiguracion.MsjGlobal.Add("No se encontraron elementos en la capa: " +
                                                                            Modelo.EncDatosConfiguracion.LayerNoOficial);
                        }
                    }
                    //-----------------------------------------------------------------------------------------------------------------

                    //M2 Superficie - Calculo el área de la polílinea------------------------------------------------------------------ 
                    Areapl = string.Format(Controlador.MetodosPlano.EnviaFormatoArea(cmDecimales.SelectedItem.ToString()), pl.Area);
                    //-----------------------------------------------------------------------------------------------------------------

                    //Obtener Unidad Privativa-------------------------------------------------------------------------
                    IdsUnidadPrivativa = Controlador.MetodosPlano.TomarEntidadLayer(Modelo.EncDatosConfiguracion.LayerUPrivativa, 
                                                                                        pts, out msjRetorno);

                    if (msjRetorno == "")
                    {
                        foreach (ObjectId idUprivativa in IdsUnidadPrivativa)
                        {
                            if (IdsUnidadPrivativa.Count == 1 && IdsUnidadPrivativa != null)
                            {
                                strUnidadPrivativa = (Controlador.MetodosPlano.AbrirEntidad(idUprivativa) as DBText).TextString;
                            }
                            else if (IdsUnidadPrivativa.Count > 1)
                            {
                                Modelo.EncDatosConfiguracion.MsjGlobal.Add("Se tiene más de un elemento en la capa: " + Modelo.EncDatosConfiguracion.LayerUPrivativa);
                            }
                            else
                            {
                                Modelo.EncDatosConfiguracion.MsjGlobal.Add("No se encontraron elementos en la capa: " + Modelo.EncDatosConfiguracion.LayerUPrivativa);
                            }
                        }
                    }
                    else
                    {
                        Modelo.EncDatosConfiguracion.MsjGlobal.Add(msjRetorno);
                    }

                    #endregion

                    ViviendasContenidas = Controlador.MetodosPlano.TomarViviendasLayer(Modelo.EncDatosConfiguracion.LayerVivContiene, 
                                                                                        min, max, out msjRetorno);

                    if(msjRetorno == "")
                    {
                        
                        //Comienzo con el llenado de viviendas dentro del Lote
                        foreach (ObjectId idViviendaLote in ViviendasContenidas)
                        {
                            string  NumeroInterior = "",
                                    LayerVivActual = "",
                                    TerminacionViv = "";

                            Polyline plViviendaActual = new Polyline();

                            Point3d minVivActual = new Point3d(),
                                    maxVivActual = new Point3d();                            

                            Point3dCollection ptsVivActual = new Point3dCollection();
                        
                            ObjectIdCollection IdNoInteriores = new ObjectIdCollection();                            

                            //cmbNoOficialActual = cmbNoOficial;

                            //Vertices de la vivienda Actual
                            ptsVivActual = Controlador.MetodosPlano.ExtraerVertices(idViviendaLote);

                            //Polilínea de la Vivienda ACTUAL
                            plViviendaActual = Controlador.MetodosPlano.AbrirEntidad(idViviendaLote) as Polyline;

                            //Obtengo el layer de la vivienda en turno
                            LayerVivActual = plViviendaActual.Layer.ToUpper().Replace(" ", string.Empty);

                            //Obtengo la terminación del layer
                            TerminacionViv = LayerVivActual.Substring(LayerVivActual.LastIndexOf('_') + 1);

                            minVivActual = plViviendaActual.GeometricExtents.MinPoint;
                            maxVivActual = plViviendaActual.GeometricExtents.MaxPoint;

                            //Obtener Numero Interior Uniendo Terminación de Caracteres de Layers------------------------------------------------------------
                            IdNoInteriores = Controlador.MetodosPlano.TomarEntidadLayer((Modelo.EncDatosConfiguracion.LayerNumIntContiene + TerminacionViv),
                                                                                            ptsVivActual, out msjRetorno);
                            if (msjRetorno == "")
                            {
                                foreach (ObjectId idnointerior in IdNoInteriores)
                                {
                                    if (IdNoInteriores.Count == 1 && IdNoInteriores != null)
                                    {
                                        NumeroInterior = (Controlador.MetodosPlano.AbrirEntidad(idnointerior) as DBText).TextString;                                        
                                    }
                                    else if (IdNoInteriores.Count > 1)
                                    {
                                        Modelo.EncDatosConfiguracion.MsjGlobal.Add("Se tiene más de un elemento en la capa: " + 
                                                                                        Modelo.EncDatosConfiguracion.LayerNoInterior);
                                    }
                                    else
                                    {
                                        Modelo.EncDatosConfiguracion.MsjGlobal.Add("No se encontraron elementos en la capa: " +
                                                                                        Modelo.EncDatosConfiguracion.LayerNoInterior);
                                    }
                                }
                            }
                            else
                            {
                                Modelo.EncDatosConfiguracion.MsjGlobal.Add(msjRetorno);
                            }

                            //-------------------------------------------------------------------------------------------------------------

                            //Inserto Renglón
                            dtDatosPlano.Rows.Add();

                            //Obtengo Index de Inserción
                            int index = dtDatosPlano.Rows.Count - 1;

                            //Obtengo del Layer que Prototipo y que piso                            
                            string  PrototipoActual = "",
                                    Piso = "";

                            for (int i = 0; i < Modelo.EncDatosIniciales.PrototipoRelacional.GetLength(0); i++)
                            {
                                string LayerActual = "";

                                LayerActual = Modelo.EncDatosIniciales.PrototipoRelacional[i, Modelo.IndexColumn.MRSPColLayer];                                

                                if (LayerActual.Substring(LayerActual.LastIndexOf('_') + 1) == TerminacionViv)
                                {                                     
                                    PrototipoActual = Modelo.EncDatosIniciales.PrototipoRelacional[i, Modelo.IndexColumn.MRSPColPrototipo];

                                    Piso = Modelo.EncDatosIniciales.PrototipoRelacional[i, Modelo.IndexColumn.MRSPColPiso];
                                }
                            }


                            //Comienzo el llenado de acuerdo lo calculado

                            /*Valores 1 vez:    Id de polilínea BD, Manzana Seleccionada, 
                                                Número Oficial, Número de Lote,  M2 Superficie, Unidad Privativa, Direccion*/
                            dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaIDPlLote].Value = IdVivienda;
                            dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaIDs].Value = idViviendaLote;
                            dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaManzana].Value = manzanaActual;                            
                            ((DataGridViewComboBoxCell)dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoOficial]).DataSource = cmbNoOficial.Items; 
                            dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaLote].Value = NumeroLote;
                            dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaM2Sup].Value = Areapl;
                            dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaUP].Value = strUnidadPrivativa;
                            dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaCalle].Value = direccion;

                            //Valores cada Vivienda: Número Interior, Prototipo, Piso
                            dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoInterior].Value = NumeroInterior;
                            dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaPrototipo].Value = PrototipoActual;
                            dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaPiso].Value = Piso;

                            //Le asignó el index 0 si sólo tiene un item de No. Oficial
                            if (cmbNoOficial.Items.Count == 1)
                                dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoOficial].Value = ((DataGridViewComboBoxCell)dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoOficial]).Items[0];
                            else if(cmbNoOficial.Items.Count > 1)
                                dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoOficial].Style.BackColor = Color.FromArgb(255, 255, 128);
                        }
                    }   
                    else
                    {
                        Modelo.EncDatosConfiguracion.MsjGlobal.Add(msjRetorno);
                    }

                    //Habilito paso Siguiente


                    WindowState = FormWindowState.Normal;
                }//Fin Vlidación de layer Lotes
                else
                {
                    MessageBox.Show("La polilínea seleccionada no tiene el layer " + Modelo.EncDatosConfiguracion.LayerViviendas,
                        "Selección del Plano", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                    WindowState = FormWindowState.Normal;
                }
            }
        }
        private void btnSelMultiple_Click(object sender, EventArgs e)
        {
            ObjectIdCollection ids = new ObjectIdCollection();

            WindowState = FormWindowState.Minimized;

            if(Controlador.MetodosPlano.SelMultipleViviendas(out ids, typeof(Polyline)))
            {
                //Por cada lote
                foreach(ObjectId IdLotePrincipal in ids)
                {
                    //Polilínea principal
                    Polyline plLote = new Polyline();

                    string layerPolilinea = "",
                            NumeroLote = "",
                            NumeroOficial = "",
                            Areapl = "",
                            strUnidadPrivativa = "",
                            decimales = "";

                    ArrayList   listaIdsComparar = new ArrayList(),
                                listaIdsRepetidos = new ArrayList();

                    Point3d min = new Point3d(),
                            max = new Point3d();

                    Point3dCollection pts = new Point3dCollection();

                    ObjectIdCollection  IdLotes = new ObjectIdCollection(),
                                        IdsUnidadPrivativa = new ObjectIdCollection(),
                                        IdsNoOficial = new ObjectIdCollection(),
                                        ViviendasContenidas = new ObjectIdCollection();

                    ComboBox cmbNoOficial = new ComboBox();

                    plLote = Controlador.MetodosPlano.AbrirEntidad(IdLotePrincipal) as Polyline;

                    //Remuevo espacios del nombre del layer y lo pongo en mayusculas
                    layerPolilinea = (plLote.Layer.ToUpper().Replace(" ", string.Empty));

                    //Si el layer de la polilínea corresponde al layer del Lote
                    if(layerPolilinea == Modelo.EncDatosConfiguracion.LayerViviendas)
                    {
                        if(!Controlador.MetodosPlano.ValidaNoRepetirVivienda(IdLotePrincipal, dtDatosPlano))
                        {
                            Modelo.EncDatosConfiguracion.MsjGlobal.Add("ID Actualizado: " + IdLotePrincipal);
                        }

                        //Obtengo punto mínimo de la polílinea para obtener Viviendas - Numero Interior
                        min = plLote.GeometricExtents.MinPoint;
                        max = plLote.GeometricExtents.MaxPoint;

                        //Extraigo vertices para Obtener Lote, Numero Interior, Unidad Privativa
                        pts = Controlador.MetodosPlano.ExtraerVertices(IdLotePrincipal);

                        #region AtributosdelLote

                        //Obtengo el número de lote ----------------------------------------------------------------------------------------                           
                        IdLotes = Controlador.MetodosPlano.TomarEntidadLayer(Modelo.EncDatosConfiguracion.LayerLote, pts, out msjRetorno);

                        if (msjRetorno == "")
                        {
                            foreach (ObjectId idlote in IdLotes)
                            {
                                if (IdLotes.Count == 1 && IdLotes != null)
                                {
                                    NumeroLote = (Controlador.MetodosPlano.AbrirEntidad(idlote) as DBText).TextString;

                                }
                                else if (IdLotes.Count > 1)
                                {
                                    Modelo.EncDatosConfiguracion.MsjGlobal.Add("Se tiene más de un elemento en la capa: " + Modelo.EncDatosConfiguracion.LayerLote);
                                }
                                else
                                {
                                    Modelo.EncDatosConfiguracion.MsjGlobal.Add("No se encontraron elementos en la capa: " + Modelo.EncDatosConfiguracion.LayerLote);
                                }
                            }
                        }
                        else
                        {
                            Modelo.EncDatosConfiguracion.MsjGlobal.Add(msjRetorno);
                        }
                        //--------------------------------------------------------------------------------------------------------


                        //Número Oficial---------------------------------------------------------------------------------------------------

                        IdsNoOficial = Controlador.MetodosPlano.TomaNoOficialLayer(plLote,  Modelo.EncDatosConfiguracion.LayerNoOficial,
                                                                                            Modelo.EncDatosConfiguracion.FactorEscala);

                        foreach (ObjectId idNoOficial in IdsNoOficial)
                        {
                            if (IdsNoOficial.Count == 1)
                            {
                                NumeroOficial = (Controlador.MetodosPlano.AbrirEntidad(idNoOficial) as DBText).TextString;

                                cmbNoOficial.Items.Add(NumeroOficial);
                            }
                            else if (IdsNoOficial.Count > 1)
                            {
                                NumeroOficial = (Controlador.MetodosPlano.AbrirEntidad(idNoOficial) as DBText).TextString;
                                cmbNoOficial.Items.Add(NumeroOficial);
                            }
                            else
                            {
                                Modelo.EncDatosConfiguracion.MsjGlobal.Add("No se encontraron elementos en la capa: " +
                                                                                Modelo.EncDatosConfiguracion.LayerNoOficial);
                            }
                        }
                        //-----------------------------------------------------------------------------------------------------------------

                        //M2 Superficie - Calculo el área de la polílinea------------------------------------------------------------------ 
                        //Calculo el área de la polílinea (Celda 5)
                        decimales = Controlador.MetodosPlano.EnviaFormatoArea(cmDecimales.SelectedItem.ToString());
                        Areapl = string.Format(decimales, plLote.Area);
                        //-----------------------------------------------------------------------------------------------------------------

                        //Obtener Unidad Privativa-------------------------------------------------------------------------
                        IdsUnidadPrivativa = Controlador.MetodosPlano.TomarEntidadLayer(Modelo.EncDatosConfiguracion.LayerUPrivativa,
                                                                                            pts, out msjRetorno);

                        if (msjRetorno == "")
                        {
                            foreach (ObjectId idUprivativa in IdsUnidadPrivativa)
                            {
                                if (IdsUnidadPrivativa.Count == 1 && IdsUnidadPrivativa != null)
                                {
                                    strUnidadPrivativa = (Controlador.MetodosPlano.AbrirEntidad(idUprivativa) as DBText).TextString;
                                }
                                else if (IdsUnidadPrivativa.Count > 1)
                                {
                                    Modelo.EncDatosConfiguracion.MsjGlobal.Add("Se tiene más de un elemento en la capa: " + Modelo.EncDatosConfiguracion.LayerUPrivativa);
                                }
                                else
                                {
                                    Modelo.EncDatosConfiguracion.MsjGlobal.Add("No se encontraron elementos en la capa: " + Modelo.EncDatosConfiguracion.LayerUPrivativa);
                                }
                            }
                        }
                        else
                        {
                            Modelo.EncDatosConfiguracion.MsjGlobal.Add(msjRetorno);
                        }


                        #endregion

                        ViviendasContenidas = Controlador.MetodosPlano.TomarViviendasLayer(Modelo.EncDatosConfiguracion.LayerVivContiene,
                                                                                              min, max, out msjRetorno);

                        if (msjRetorno == "")
                        {                            
                            
                            //Comienzo con el llenado de viviendas dentro del Lote
                            foreach (ObjectId idViviendaLote in ViviendasContenidas)
                            {
                                string NumeroInterior = "",
                                        LayerVivActual = "",
                                        TerminacionViv = "";

                                Polyline plViviendaActual = new Polyline();

                                Point3d minVivActual = new Point3d(),
                                        maxVivActual = new Point3d();

                                Point3dCollection ptsVivActual = new Point3dCollection();

                                ObjectIdCollection IdNoInteriores = new ObjectIdCollection();

                                //cmbNoOficialActual = cmbNoOficial;

                                //Vertices de la vivienda Actual
                                ptsVivActual = Controlador.MetodosPlano.ExtraerVertices(idViviendaLote);

                                //Polilínea de la Vivienda ACTUAL
                                plViviendaActual = Controlador.MetodosPlano.AbrirEntidad(idViviendaLote) as Polyline;

                                //Obtengo el layer de la vivienda en turno
                                LayerVivActual = plViviendaActual.Layer.ToUpper().Replace(" ", string.Empty);

                                //Obtengo la terminación del layer
                                TerminacionViv = LayerVivActual.Substring(LayerVivActual.LastIndexOf('_') + 1);

                                minVivActual = plViviendaActual.GeometricExtents.MinPoint;
                                maxVivActual = plViviendaActual.GeometricExtents.MaxPoint;

                                //Obtener Numero Interior Uniendo Terminación de Caracteres de Layers------------------------------------------------------------
                                IdNoInteriores = Controlador.MetodosPlano.TomarEntidadLayer((Modelo.EncDatosConfiguracion.LayerNumIntContiene + TerminacionViv),
                                                                                                ptsVivActual, out msjRetorno);
                                if (msjRetorno == "")
                                {
                                    foreach (ObjectId idnointerior in IdNoInteriores)
                                    {
                                        if (IdNoInteriores.Count == 1 && IdNoInteriores != null)
                                        {
                                            NumeroInterior = (Controlador.MetodosPlano.AbrirEntidad(idnointerior) as DBText).TextString;
                                        }
                                        else if (IdNoInteriores.Count > 1)
                                        {
                                            Modelo.EncDatosConfiguracion.MsjGlobal.Add("Se tiene más de un elemento en la capa: " +
                                                                                            Modelo.EncDatosConfiguracion.LayerNoInterior);
                                        }
                                        else
                                        {
                                            Modelo.EncDatosConfiguracion.MsjGlobal.Add("No se encontraron elementos en la capa: " +
                                                                                            Modelo.EncDatosConfiguracion.LayerNoInterior);
                                        }
                                    }
                                }
                                else
                                {
                                    Modelo.EncDatosConfiguracion.MsjGlobal.Add(msjRetorno);
                                }

                                //-------------------------------------------------------------------------------------------------------------

                                //Inserto Renglón
                                dtDatosPlano.Rows.Add();

                                //Obtengo Index de Inserción
                                int index = dtDatosPlano.Rows.Count - 1;

                                //Obtengo del Layer que Prototipo y que piso                            
                                string PrototipoActual = "",
                                       Piso = "";

                                //Obtengo prototipo y piso de acuerdo al Número Interior
                                for (int i = 0; i < Modelo.EncDatosIniciales.PrototipoRelacional.GetLength(0); i++)
                                {
                                    string LayerActual = "";

                                    LayerActual = Modelo.EncDatosIniciales.PrototipoRelacional[i, Modelo.IndexColumn.MRSPColLayer];

                                    if (LayerActual.Substring(LayerActual.LastIndexOf('_') + 1) == TerminacionViv)
                                    {
                                        PrototipoActual = Modelo.EncDatosIniciales.PrototipoRelacional[i, Modelo.IndexColumn.MRSPColPrototipo];

                                        Piso = Modelo.EncDatosIniciales.PrototipoRelacional[i, Modelo.IndexColumn.MRSPColPiso];
                                    }
                                }


                                //Comienzo el llenado de acuerdo lo calculado

                                /*Valores 1 vez:    Id de polilínea BD, Manzana Seleccionada, 
                                                    Número Oficial, Número de Lote,  M2 Superficie, Unidad Privativa, Direccion*/
                                dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaIDs].Value = idViviendaLote;
                                dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaIDPlLote].Value = IdLotePrincipal;
                                dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaManzana].Value = manzanaActual;
                                ((DataGridViewComboBoxCell)dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoOficial]).DataSource = cmbNoOficial.Items;
                                dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaLote].Value = NumeroLote;
                                dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaM2Sup].Value = Areapl;
                                dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaUP].Value = strUnidadPrivativa;
                                dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaCalle].Value = direccion;

                                //Valores cada Vivienda: Número Interior, Prototipo, Piso
                                dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoInterior].Value = NumeroInterior;
                                dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaPrototipo].Value = PrototipoActual;
                                dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaPiso].Value = Piso;

                                //Le asignó el index 0 si sólo tiene un item de No. Oficial
                                if (cmbNoOficial.Items.Count == 1)
                                    dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoOficial].Value = ((DataGridViewComboBoxCell)dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoOficial]).Items[0];
                                else if (cmbNoOficial.Items.Count > 1)
                                    dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoOficial].Style.BackColor = Color.FromArgb(255, 255, 128);
                            }
                        }
                        else
                        {
                            Modelo.EncDatosConfiguracion.MsjGlobal.Add(msjRetorno);
                        }
                        
                    }

                }

                WindowState = FormWindowState.Normal;
            }

        }

        #endregion

        #region PASO 4

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            //Reviso que haya renglones
            if (dtDatosPlano.Rows.Count > 0)
            {
                //Reviso que se hayan seleccionado todas las viviendas correspondientes al conjunto
                if (Convert.ToInt32(Modelo.EncDatosIniciales.ViviendasPendientes) == dtDatosPlano.Rows.Count)
                {
                    //Piso y No. Interior no deben de estar vacíos
                    if (Controlador.MetodosPlano.ValidoPisoNoInt(dtDatosPlano))
                    {
                        //Llamo Función para Ordenar Viviendas
                        Controlador.MetodosPlano.OrdenoViviendas(dtDatosPlano);

                        //Valido que si haya modificación después de cerrar diálogo
                        if (Modelo.EncapsulaBitacora.SiModificaDGV == true)
                        {
                            //Inicializo variable
                            Modelo.EncapsulaBitacora.SiModificaDGV = false;

                            //Habilito Siguiente Paso
                            btnSiguiente.Enabled = true;

                            //Al ya contar con el nuevo DGV elimino renglones
                            dtDatosPlano.Rows.Clear();

                            //Inserto renglones con el nuevo orden
                            foreach (DataGridViewRow dtrow in Modelo.EncapsulaBitacora.MDtSeleccionPlano.Rows)
                            {
                                //Inserto Renglon DGV                    
                                dtDatosPlano.Rows.Add();

                                foreach (DataGridViewCell dtcell in dtrow.Cells)
                                {
                                    if (dtcell.ColumnIndex != Modelo.IndexColumn.MSDPColumnaNoOficial)
                                    {
                                        dtDatosPlano.Rows[dtrow.Index].Cells[dtcell.ColumnIndex].Value = dtcell.Value;
                                    }
                                    else
                                    {
                                        string idPlLote = (dtrow.Cells[Modelo.IndexColumn.MSDPColumnaIDPlLote].Value ?? "").ToString();

                                        int indxRow = Modelo.EncDatosPlano.ListOrdenPl.IndexOf(idPlLote);
                                        int cont = 0;

                                        for (int col = 0; col < Modelo.EncDatosPlano.NoOficialSel.GetLength(1); col++)
                                        {                                            
                                            if(Modelo.EncDatosPlano.NoOficialSel[indxRow, col] != null)
                                            {
                                                cont += 1;
                                                ((DataGridViewComboBoxCell)dtDatosPlano.Rows[dtrow.Index].Cells[dtcell.ColumnIndex]).Items.Add(Modelo.EncDatosPlano.NoOficialSel[indxRow, col]);
                                            }
                                        }

                                        if(cont == 1)
                                        {
                                            dtDatosPlano.Rows[dtrow.Index].Cells[dtcell.ColumnIndex].Value = ((DataGridViewComboBoxCell)dtDatosPlano.Rows[dtrow.Index].Cells[dtcell.ColumnIndex]).Items[0];
                                        }
                                        else if(cont > 1)
                                        {
                                            dtDatosPlano.Rows[dtrow.Index].Cells[dtcell.ColumnIndex].Style.BackColor = Color.FromArgb(255, 255, 128);
                                        }
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("El Piso y/o No. Interior no deben de estar vacíos. \n Favor de revisar celdas marcadas",
                            "Datos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (dtDatosPlano.Rows.Count < Convert.ToInt32(Modelo.EncDatosIniciales.ViviendasPendientes))
                    {
                        MessageBox.Show("Hay menos viviendas insertadas de las específicadas en el conjunto", "Error de Conjunto",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        lblResViviendas.ForeColor = Color.Red;
                        lblVivPndts.ForeColor = Color.Red;
                    }
                    else
                    {
                        MessageBox.Show("Hay más viviendas insertadas de las específicadas en el conjunto", "Error de Conjunto",
                                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        lblResViviendas.ForeColor = Color.Red;
                        lblVivPndts.ForeColor = Color.Red;
                    }
                }

            }
            else
            {
                MessageBox.Show("La tabla de datos se encuentra vacía", "Datos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region PASO 5

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            //Bandera que determina que todo este correcto
            bool bnErrorTipoDato = false;
            bool bnErrorVacio = false;

            //Reviso que haya más de un renglón en el dtgv
            if (dtDatosPlano.RowCount > 0)
            {
                //Que se hayan seleccionado las viviendas restantes
                if (Convert.ToInt32(Modelo.EncDatosIniciales.ViviendasPendientes) == dtDatosPlano.Rows.Count)
                {
                    if (MessageBox.Show("¿Desea ir a módulo complemento de datos?", "Ir a complemento de datos", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //Reviso formato de datos correcto y que no estén vacíos
                        Controlador.MetodosPlano.RevisoDatosSeleccionados(dtDatosPlano, "Multifamiliar", out bnErrorTipoDato, out bnErrorVacio);

                        if (bnErrorTipoDato == true || bnErrorVacio == true)
                        {
                            Modelo.EncDatosPlano.M2SuperFloteTipo.Clear();
                            if (bnErrorTipoDato == true && bnErrorVacio == true)                            
                                MessageBox.Show("Favor de revisar tipos de datos incorrectos y vacíos", "Advertencia", MessageBoxButtons.OK);                            

                            else if (bnErrorTipoDato == true && bnErrorVacio == false)
                                MessageBox.Show("Favor de revisar tipos de datos incorrectos", "Advertencia", MessageBoxButtons.OK);   
                                                     
                            else
                                MessageBox.Show("Favor de revisar Datos Vacíos", "Advertencia", MessageBoxButtons.OK);
                        }
                        else //En dado caso que no haya error de formato de dato o vacíos que son obligatorios
                        {
                            bool siUP = Controlador.MetodosPlano.SiValidaUP(dtDatosPlano, Modelo.IndexColumn.MSDPColumnaUP);
                            if (siUP)
                            {
                                MDatosFinales df = new MDatosFinales();
                                df.Show();
                                Modelo.EncDatosConfiguracion.CierreAuto = true;
                                Close();
                            }
                            else
                                MessageBox.Show("Todas las viviendas deben de tener Unidad Prvativa", 
                                    "Advertencia", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    if (dtDatosPlano.Rows.Count < Convert.ToInt32(Modelo.EncDatosIniciales.ViviendasPendientes))
                    {
                        MessageBox.Show("Hay menos viviendas insertadas de las específicadas en el conjunto", "Error de Conjunto",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        lblResViviendas.ForeColor = Color.Red;
                        lblVivPndts.ForeColor = Color.Red;
                    }
                    else
                    {
                        MessageBox.Show("Hay más viviendas insertadas de las específicadas en el conjunto", "Error de Conjunto",
                                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        lblResViviendas.ForeColor = Color.Red;
                        lblVivPndts.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay datos capturados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        /*--------------------------------------------------------------------------------------------------*/

        #region Metodos de Barra de Herramientas

        private void btnViewRelation_Click(object sender, EventArgs e)
        {
            MBtRelPrototipo rp = new MBtRelPrototipo();
            rp.ShowDialog();
        }

        private void btnSiguienteNull_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dtrow in dtDatosPlano.Rows)
            {
                foreach (DataGridViewCell dtcell in dtrow.Cells)
                {
                    //Valida que no busqué en vacíos las columnas que pudieran llegar a ir en blanco
                    if (dtrow.Cells[dtcell.ColumnIndex] != dtrow.Cells[Modelo.IndexColumn.MSDPColumnaCalle]
                        && dtrow.Cells[dtcell.ColumnIndex] != dtrow.Cells[Modelo.IndexColumn.MSDPColumnaNoOficial])
                    {
                        switch (dtcell.ColumnIndex)
                        {
                            //Manzana
                            case Modelo.IndexColumn.MSDPColumnaManzana:
                                if (string.IsNullOrWhiteSpace((dtrow.Cells[dtcell.ColumnIndex].Value ?? "").ToString()))
                                {
                                    dtDatosPlano.CurrentCell = dtDatosPlano[dtcell.ColumnIndex, dtcell.RowIndex];
                                    return;
                                }
                                break; 
                            //Lote Final
                            case Modelo.IndexColumn.MSDPColumnaLote:
                                if (dtrow.Cells[dtcell.ColumnIndex].Value != null)
                                {
                                    if (String.IsNullOrWhiteSpace(dtrow.Cells[dtcell.ColumnIndex].Value.ToString()))
                                    {
                                        dtDatosPlano.CurrentCell = dtDatosPlano[dtcell.ColumnIndex, dtcell.RowIndex];
                                        return;
                                    }
                                }
                                else
                                {
                                    dtDatosPlano.CurrentCell = dtDatosPlano[dtcell.ColumnIndex, dtcell.RowIndex];
                                    return;
                                }
                                break;
                            //Numero Interior
                            case Modelo.IndexColumn.MSDPColumnaNoInterior:
                                if (dtrow.Cells[dtcell.ColumnIndex].Value != null)
                                {
                                    if (string.IsNullOrWhiteSpace(dtrow.Cells[dtcell.ColumnIndex].Value.ToString()))
                                    {
                                        dtDatosPlano.CurrentCell = dtDatosPlano[dtcell.ColumnIndex, dtcell.RowIndex];
                                        return;
                                    }
                                }
                                else
                                {
                                    dtDatosPlano.CurrentCell = dtDatosPlano[dtcell.ColumnIndex, dtcell.RowIndex];
                                    return;
                                }
                                break;
                            case Modelo.IndexColumn.MSDPColumnaM2Sup:
                                if (dtrow.Cells[dtcell.ColumnIndex].Value != null)
                                {
                                    if (string.IsNullOrWhiteSpace(dtrow.Cells[dtcell.ColumnIndex].Value.ToString()))
                                    {
                                        dtDatosPlano.CurrentCell = dtDatosPlano[dtcell.ColumnIndex, dtcell.RowIndex];
                                        return;
                                    }
                                }
                                else
                                {
                                    dtDatosPlano.CurrentCell = dtDatosPlano[dtcell.ColumnIndex, dtcell.RowIndex];
                                    return;
                                }
                                break;
                        }

                    }
                }
            }
        }

        private void cmDecimales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmDecimales.SelectedIndex != -1)
            {
                Modelo.EncDatosPlano.Decimales = int.Parse(cmDecimales.SelectedItem.ToString());
            }
        }


        private void btnBorrarTabla_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar datos de la tabla?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dtDatosPlano.Rows.Clear();
            }
        }

        private void btnLayerBitacora_Click(object sender, EventArgs e)
        {
            BitacoraErrores be = new BitacoraErrores();
            be.StartPosition = FormStartPosition.CenterParent;
            be.ShowDialog();
        }

        private void btnRevelarId_Click(object sender, EventArgs e)
        {
            if (dtDatosPlano.Columns[Modelo.IndexColumn.MSDPColumnaIDs].Visible == true)
            {
                dtDatosPlano.Columns[Modelo.IndexColumn.MSDPColumnaIDs].Visible = false;
                dtDatosPlano.Columns[Modelo.IndexColumn.MSDPColumnaIDPlLote].Visible = false;
            }
            else
            {
                dtDatosPlano.Columns[Modelo.IndexColumn.MSDPColumnaIDs].Visible = true;
                dtDatosPlano.Columns[Modelo.IndexColumn.MSDPColumnaIDPlLote].Visible = true;
            }
        }

        #endregion

        private void btnAtras_Click(object sender, EventArgs e)
        {
            MSPAtras msp = new MSPAtras();            
            msp.ShowDialog(this);
            
        }


        #region Tooltips
        private void btnSelUnica_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Seleccion de 1 vivienda" + Environment.NewLine + "del plano", btnSelUnica, 5000);
        }

        private void btnSelMultiple_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Selección de múltiples viviendas" + Environment.NewLine + "del plano", btnSelMultiple, 5000);
        }

        private void checkSD_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Sin Dirección", checkSD, 5000);
        }

        private void btnLayerBitacora_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Bitácora y nombre de capas", btnLayerBitacora, 5000);
        }

        private void btnBorrarTabla_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Elimina registros", btnBorrarTabla, 5000);
        }

        private void btnSiguienteNull_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Encontrar el registro en blanco más cercano", btnSiguienteNull, 5000);
        }

        private void btnOrdenar_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Ordenar viviendas seleccionadas", btnOrdenar, 5000);
        }

        private void btnSiguiente_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Ir al siguiente módulo", btnSiguiente, 5000);
        }

        private void btnAtras_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Regresar a un módulo anterior", btnAtras, 5000);
        }

        private void btnViewRelation_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Relación Prototipo-Layer-Piso", btnViewRelation, 5000);
        }

        private void cmDecimales_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Decimales de M2 de Construcción", cmDecimales, 5000);
        }

        private void btnRevelarId_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Muestra Ids de polilínea", btnRevelarId, 5000);
        }

        #endregion

    }
}
