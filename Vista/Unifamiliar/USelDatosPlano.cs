using System;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using System.Collections;

namespace PluginInsViviendas_UNO.Vista.Unifamiliar
{
    public partial class USelDatosPlano : Form
    {                                
               
        public string   ManzanaActual="", 
                        Direccion="";
        
        public Editor ed = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument.Editor;
        public string msjretorno;        
        ToolTip t1 = new ToolTip();

        public USelDatosPlano()
        {
            InitializeComponent();
        }


        private void SelDatosPlano_Load(object sender, EventArgs e)
        {
            setConjunto.Text = Modelo.EncDatosIniciales.Conjunto;

            Modelo.EncDatosIniciales.ViviendasPendientes = (Convert.ToInt32(Modelo.EncDatosIniciales.ViviendasMaximas) -
                                        Convert.ToInt32(Modelo.EncDatosIniciales.ViviendasCargadas)).ToString();
            
            lblResViviendas.Text = Modelo.EncDatosIniciales.ViviendasPendientes;
            btnCambiaManzana.Visible = false;
            btnCambiaDireccion.Visible = false;
            btnSelDireccion.Enabled = false;
            btnSelUnica.Enabled = false;
            btnSelMultiple.Enabled = false;
            cmDecimales.SelectedItem = "2";

            if (Modelo.EncDatosConfiguracion.ConDatos == true)
            {
                Controlador.MetodosFinales.RegresoDatosSDP(dtDatosPlano, "Unifamiliar");

                Modelo.EncDatosConfiguracion.ConDatos = false;
            }

            dtDatosPlano.AllowUserToAddRows = false;

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            bool    bnErrorTipoDato = false, 
                    bnErrorVacio = false;

            if (dtDatosPlano.RowCount > 0)
            {
                DialogResult dr = MessageBox.Show("¿Desea conservar los datos ingresados en este módulo?", "Ir a Inicio", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    Modelo.EncDatosPlano.M2SuperFloteTipo.Clear();
                    Controlador.MetodosPlano.RevisoDatosSeleccionados(dtDatosPlano, "Unifamiliar", out bnErrorTipoDato, out bnErrorVacio);

                    if (bnErrorTipoDato == false && bnErrorVacio == false)
                    {
                        Modelo.EncDatosConfiguracion.ConDatos = true;
                        SelDatosIniciales sdi = new SelDatosIniciales();

                        sdi.Show();
                        Modelo.EncDatosConfiguracion.CierreAuto = true;
                        this.Close();
                    }
                    else if (bnErrorTipoDato == true && bnErrorVacio == true)
                    {
                        MessageBox.Show("Favor de revisar datos vacíos e incorrectos", "Advertencia", MessageBoxButtons.OK);
                        Modelo.EncDatosPlano.M2SuperFloteTipo.Clear();
                    }
                    else if (bnErrorTipoDato == false && bnErrorVacio == true)
                    {
                        MessageBox.Show("Favor de revisar datos vacíos");
                        Modelo.EncDatosPlano.M2SuperFloteTipo.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Favor de revisar tipo de datos incorrectos");
                        Modelo.EncDatosPlano.M2SuperFloteTipo.Clear();
                    }
                }
                else if (dr == DialogResult.No)
                {
                    Controlador.MetodosFinales.LimpiaTodoEncapsulado(false, true, true);
                    SelDatosIniciales sdi = new SelDatosIniciales();
                    sdi.Show();
                    Modelo.EncDatosConfiguracion.CierreAuto = true;
                    Close();
                }
            }
            else
            {
                if (MessageBox.Show("¿Desea regresar a Inicio?", "Ir a Inicio", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SelDatosIniciales sdi = new SelDatosIniciales();

                    sdi.Show();
                    Modelo.EncDatosConfiguracion.CierreAuto = true;
                    this.Close();
                }
            }
        }

        //Celda 0 Manzana
        #region PASO 1 Selecciona Manzana
        private void btnSelManzana_Click(object sender, EventArgs e)
        {
            ObjectId idManzana = new ObjectId();
            DBText TextManzana = new DBText() ;

            this.WindowState = FormWindowState.Minimized;

            //Se solicita la entidad solamente de tipo DB Text
            if (Controlador.MetodosPlano.SeleccionaEntidadTipo("\n Seleccione la Manzana", out idManzana, typeof(DBText)))
            {
                //Abrimos la entidad DBText
                TextManzana = Controlador.MetodosPlano.AbrirEntidad(idManzana) as DBText;

                //Validamos que el layer en el que se encuentra el DBText sea el correcto
                if (TextManzana.Layer.ToUpper() == Modelo.EncDatosConfiguracion.LayerManzana)
                {
                    ManzanaActual = TextManzana.TextString;
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
            btnSelManzana.Enabled = true;
            lblSelManzana.ForeColor = System.Drawing.Color.Red;
            btnCambiaManzana.Visible = false;
            btnSelDireccion.Enabled = false;
            btnCambiaDireccion.Enabled = false;
        }
        #endregion

        //Celda 1 Calle
        #region PASO 2 Selecciona Dirección
        private void btnDireccion_Click(object sender, EventArgs e)
        {
            ObjectId idDireccion;
            DBText TextDireccion;

            this.WindowState = FormWindowState.Minimized;

            //Se solicita la entidad solamente de tipo DB Text
            if (Controlador.MetodosPlano.SeleccionaEntidadTipo("\n Seleccione la Dirección", out idDireccion, typeof(DBText)))
            {
                //Abrimos la entidad DBText
                TextDireccion = Controlador.MetodosPlano.AbrirEntidad(idDireccion) as DBText;

                if (TextDireccion.Layer.ToUpper() == Modelo.EncDatosConfiguracion.LayerDireccion)
                {
                    Direccion = TextDireccion.TextString;
                    setDireccionActual.Text = TextDireccion.TextString;
                    lblSelDireccion.ForeColor = System.Drawing.Color.Black;
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

                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnCambiaDireccion_Click(object sender, EventArgs e)
        {
            btnSelDireccion.Enabled = true;
            lblSelDireccion.ForeColor = System.Drawing.Color.Red;
            btnCambiaDireccion.Visible = false;
            btnCambiaManzana.Enabled = false;
        }

        private void checkSD_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSD.Checked == true)
            {
                Direccion = "";
                groupDireccion.ForeColor = System.Drawing.Color.LightGray;
                lblSelDireccion.ForeColor = System.Drawing.Color.LightGray;
                btnCambiaDireccion.ForeColor = System.Drawing.Color.LightGray;
                btnCambiaDireccion.Visible = false;
                btnSelDireccion.Enabled = false;
                setDireccionActual.Text = "Sin Dirección";
                btnSelMultiple.Enabled = true;
                btnSelUnica.Enabled = true;

            }

            if (checkSD.Checked == false)
            {
                groupDireccion.ForeColor = System.Drawing.Color.SteelBlue;
                lblSelDireccion.ForeColor = System.Drawing.Color.Black;
                btnCambiaDireccion.ForeColor = System.Drawing.Color.Black;
                btnSelDireccion.Enabled = true;
                setDireccionActual.Text = "Pendiente";
                btnSelMultiple.Enabled = false;
                btnSelUnica.Enabled = false;

            }

        }
        #endregion

        #region PASO 3 Selección de Viviendas
        private void btnSelUnica_Click(object sender, EventArgs e)
        {
            ObjectId IdVivienda = new ObjectId();
            Polyline pl = new Polyline();

            Point3dCollection pts = new Point3dCollection();
            ObjectIdCollection  IdLotes = new ObjectIdCollection(),
                                IdNoInteriores = new ObjectIdCollection(),
                                IdsUnidadPrivativa = new ObjectIdCollection(),
                                IdsNoOficial = new ObjectIdCollection();

            ArrayList listaIdsComparar = new ArrayList();
            ArrayList listaIdsRepetidos = new ArrayList();

            //Combobox del Número Oficial
            DataGridViewComboBoxCell cmbNoOficial = new DataGridViewComboBoxCell();
            cmbNoOficial.FlatStyle = FlatStyle.Flat;

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
                        MessageBox.Show("Se actualizaron los datos de la polilínea: " + IdVivienda);
                    }

                    string  NumeroLote = "", 
                            NumeroInterior = "", 
                            NumeroOficial = "", 
                            Areapl = "", 
                            strUnidadPrivativa = "";

                    //Asigno un nuevo renglón vacío y comienzo a llenarlo
                    //Asigno el último index
                    int index = dtDatosPlano.Rows.Add();
                                       
                    //Extraigo vertices para Obtener Lote, Numero Interior, Unidad Privativa
                    pts = Controlador.MetodosPlano.ExtraerVertices(IdVivienda);

                    //Obtengo el número de lote ----------------------------------------------------------------------------------------                           
                    IdLotes = Controlador.MetodosPlano.TomarEntidadLayer(Modelo.EncDatosConfiguracion.LayerLote, pts, out msjretorno);

                    if (msjretorno == "")
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
                        Modelo.EncDatosConfiguracion.MsjGlobal.Add(msjretorno);
                    }
                    //------------------------------------------------------------------------------------------------------------------


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

                    //Obtener Numero Interior-----------------------------------------------------------------------------------
                    IdNoInteriores = Controlador.MetodosPlano.TomarEntidadLayer(Modelo.EncDatosConfiguracion.LayerNoInterior, pts, 
                                                                                    out msjretorno);

                    if (msjretorno == "")
                    {
                        foreach (ObjectId idnointerior in IdNoInteriores)
                        {
                            if (IdNoInteriores.Count == 1 && IdNoInteriores != null)
                            {
                                NumeroInterior = (Controlador.MetodosPlano.AbrirEntidad(idnointerior) as DBText).TextString;                                
                            }
                            else if (IdNoInteriores.Count > 1)
                            {
                                Modelo.EncDatosConfiguracion.MsjGlobal.Add("Se tiene más de un elemento en la capa: " + Modelo.EncDatosConfiguracion.LayerNoInterior);
                            }
                            else
                            {
                                Modelo.EncDatosConfiguracion.MsjGlobal.Add("No se encontraron elementos en la capa: " + Modelo.EncDatosConfiguracion.LayerNoInterior);
                            }
                        }
                    }
                    else
                    {
                        Modelo.EncDatosConfiguracion.MsjGlobal.Add(msjretorno);
                    }
                    //-----------------------------------------------------------------------------------------------------------------

                    //M2 de Superficie - Calculo el área de la polílinea---------------------------------------------------------------
                    Areapl = string.Format(Controlador.MetodosPlano.EnviaFormatoArea(cmDecimales.SelectedItem.ToString()), pl.Area);
                    //-----------------------------------------------------------------------------------------------------------------

                    //Obtener Unidad Privativa-------------------------------------------------------------------------
                    IdsUnidadPrivativa = Controlador.MetodosPlano.TomarEntidadLayer(Modelo.EncDatosConfiguracion.LayerUPrivativa, pts, 
                                                                                        out msjretorno);
                    if (msjretorno == "")
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
                        Modelo.EncDatosConfiguracion.MsjGlobal.Add(msjretorno);
                    }                    

                    //Asigno valores a renglon insertado
                    dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaIDs].Value = IdVivienda;
                    dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaManzana].Value = ManzanaActual;
                    dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaLote].Value = NumeroLote;
                    ((DataGridViewComboBoxCell)dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaNoOficial]).DataSource = cmbNoOficial.Items;
                    dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaNoInterior].Value = NumeroInterior;
                    dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaM2Superficie].Value = Areapl;
                    dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaUP].Value = strUnidadPrivativa;
                    dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaCalle].Value = Direccion;

                    //Le asignó el index 0 si sólo tiene un item de No. Oficial
                    if (cmbNoOficial.Items.Count == 1)
                        dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaNoOficial].Value = ((DataGridViewComboBoxCell)dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaNoOficial]).Items[0];
                    else if (cmbNoOficial.Items.Count > 1)
                        dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaNoOficial].Style.BackColor = Color.FromArgb(255, 255, 128);

                }

                #endregion//Viviendas Repetidas                
            }
            WindowState = FormWindowState.Normal;
        }



        private void btnSelMultiple_Click(object sender, EventArgs e)
        {
            ObjectIdCollection ids = new ObjectIdCollection();
            WindowState = FormWindowState.Minimized;
            if (Controlador.MetodosPlano.SelMultipleViviendas(out ids, typeof(Polyline)))
            {
                foreach (ObjectId IdVivienda in ids)
                {
                    //Polílinea de la vivienda
                    Polyline plMultiple = new Polyline();
                    
                    //Layer de Polilínea seleccionada
                    string  plLayer = "";

                    //Puntos de la polílinea
                    Point3dCollection   pts = new Point3dCollection();

                    //Objetos obtenidos dentro de la vivienda
                    ObjectIdCollection  IdLotes = new ObjectIdCollection(), 
                                        IdNoInteriores = new ObjectIdCollection(),
                                        IdsUnidadPrivativa = new ObjectIdCollection(), 
                                        IdsNoOficial = new ObjectIdCollection();

                    //Comparación de 
                    ArrayList   listaIdsComparar = new ArrayList(),
                                listaIdsRepetidos = new ArrayList();

                    string  NumeroLote = "",
                            NumeroInterior = "",
                            NumeroOficial = "",
                            Areapl = "",
                            strUnidadPrivativa = "";                            

                    //Combobox del Número Oficial
                    DataGridViewComboBoxCell cmbNoOficial = new DataGridViewComboBoxCell();
                    cmbNoOficial.FlatStyle = FlatStyle.Flat;

                    //creo polilínea
                    plMultiple = Controlador.MetodosPlano.AbrirEntidad(IdVivienda) as Polyline;

                    //Remuevo espacios del nombre del layer y lo pongo en mayusculas
                    plLayer = (plMultiple.Layer.ToUpper().Replace(" ", string.Empty));

                    if (plLayer == Modelo.EncDatosConfiguracion.LayerViviendas)
                    {
                        //Valido que la vivienda que se recibió no este ya insertada en el DataGridView
                        if (!Controlador.MetodosPlano.ValidaNoRepetirVivienda(IdVivienda, dtDatosPlano))
                        {
                            Modelo.EncDatosConfiguracion.MsjGlobal.Add("ID Actualizado: " + IdVivienda);
                        }

                        //Asigno un nuevo renglón vacío y comienzo a llenarlo
                        //Asigno el último index
                        int index = dtDatosPlano.Rows.Add();

                        //Extraigo vertices para Obtener Lote, Numero Interior, Unidad Privativa
                        pts = Controlador.MetodosPlano.ExtraerVertices(IdVivienda);

                        //Obtengo el número de lote ----------------------------------------------------------------------------------------                           
                        IdLotes = Controlador.MetodosPlano.TomarEntidadLayer(Modelo.EncDatosConfiguracion.LayerLote, pts, out msjretorno);

                        if (msjretorno == "")
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
                            Modelo.EncDatosConfiguracion.MsjGlobal.Add(msjretorno);
                        }
                        //------------------------------------------------------------------------------------------------------------------


                        //Número Oficial---------------------------------------------------------------------------------------------------
                        IdsNoOficial = Controlador.MetodosPlano.TomaNoOficialLayer(plMultiple, Modelo.EncDatosConfiguracion.LayerNoOficial,
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

                        //Obtener Numero Interior-----------------------------------------------------------------------------------
                        IdNoInteriores = Controlador.MetodosPlano.TomarEntidadLayer(Modelo.EncDatosConfiguracion.LayerNoInterior, pts,
                                                                                        out msjretorno);

                        if (msjretorno == "")
                        {
                            foreach (ObjectId idnointerior in IdNoInteriores)
                            {
                                if (IdNoInteriores.Count == 1 && IdNoInteriores != null)
                                {
                                    NumeroInterior = (Controlador.MetodosPlano.AbrirEntidad(idnointerior) as DBText).TextString;
                                }
                                else if (IdNoInteriores.Count > 1)
                                {
                                    Modelo.EncDatosConfiguracion.MsjGlobal.Add("Se tiene más de un elemento en la capa: " + Modelo.EncDatosConfiguracion.LayerNoInterior);
                                }
                                else
                                {
                                    Modelo.EncDatosConfiguracion.MsjGlobal.Add("No se encontraron elementos en la capa: " + Modelo.EncDatosConfiguracion.LayerNoInterior);
                                }
                            }
                        }
                        else
                        {
                            Modelo.EncDatosConfiguracion.MsjGlobal.Add(msjretorno);
                        }
                        //-----------------------------------------------------------------------------------------------------------------

                        //M2 de Superficie - Calculo el área de la polílinea---------------------------------------------------------------
                        Areapl = string.Format(Controlador.MetodosPlano.EnviaFormatoArea(cmDecimales.SelectedItem.ToString()), plMultiple.Area);
                        //-----------------------------------------------------------------------------------------------------------------

                        //Obtener Unidad Privativa-------------------------------------------------------------------------
                        IdsUnidadPrivativa = Controlador.MetodosPlano.TomarEntidadLayer(Modelo.EncDatosConfiguracion.LayerUPrivativa, pts,
                                                                                            out msjretorno);
                        if (msjretorno == "")
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
                            Modelo.EncDatosConfiguracion.MsjGlobal.Add(msjretorno);
                        }

                        //Asigno valores a renglon insertado
                        dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaIDs].Value = IdVivienda;
                        dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaManzana].Value = ManzanaActual;
                        dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaLote].Value = NumeroLote;
                        ((DataGridViewComboBoxCell)dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaNoOficial]).DataSource = cmbNoOficial.Items;
                        dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaNoInterior].Value = NumeroInterior;
                        dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaM2Superficie].Value = Areapl;
                        dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaUP].Value = strUnidadPrivativa;
                        dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaCalle].Value = Direccion;

                        //Le asignó el index 0 si sólo tiene un item de No. Oficial
                        if (cmbNoOficial.Items.Count == 1)
                            dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaNoOficial].Value = ((DataGridViewComboBoxCell)dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaNoOficial]).Items[0];
                        else if (cmbNoOficial.Items.Count > 1)
                            dtDatosPlano.Rows[index].Cells[Modelo.IndexColumn.USDPColumnaNoOficial].Style.BackColor = Color.FromArgb(255, 255, 128);
                    }//Fin de validación que la capa de Viviendas sea la correcta

                }//Fin Foreach ObjectIDCollection de Viviendas
                
            }//Fin de selección de Viviendas de tipo polilinea
            else
            {
                Autodesk.AutoCAD.ApplicationServices.Core.Application.ShowAlertDialog("Favor de sólo seleccionar polilíneas");
            }

            WindowState = FormWindowState.Normal;
        }        

        private void btnLayerBitacora_Click(object sender, EventArgs e)
        {
            BitacoraErrores be = new BitacoraErrores();
            be.StartPosition = FormStartPosition.CenterParent;
            be.ShowDialog();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            //Bandera que determina que todo este correcto
            bool bnErrorTipoDato = false;
            bool bnErrorVacio = false;
            if (MessageBox.Show("¿Desea ir a módulo complemento de datos?", "Ir a complemento de datos", MessageBoxButtons.OKCancel) 
                == DialogResult.OK)
            {
                //Reviso que haya más de un renglón en el dtgv
                if (dtDatosPlano.RowCount > 0)
                {
                    //Confirmo que las viviendas pendientes sean las mismas que las cargadas
                    if (Convert.ToInt32(Modelo.EncDatosIniciales.ViviendasPendientes) == dtDatosPlano.Rows.Count)
                    {
                        Modelo.EncDatosPlano.M2SuperFloteTipo.Clear();

                        Controlador.MetodosPlano.RevisoDatosSeleccionados(dtDatosPlano, "Unifamiliar", out bnErrorTipoDato, out bnErrorVacio);
                       
                        if (bnErrorTipoDato == true || bnErrorVacio == true)
                        {
                            
                            if (bnErrorTipoDato == true && bnErrorVacio == true)
                            {                                
                                MessageBox.Show("Favor de revisar tipos de datos incorrectos y vacíos", "Advertencia", MessageBoxButtons.OK);
                            }
                            else if (bnErrorTipoDato == true && bnErrorVacio == false)
                            {
                                MessageBox.Show("Favor de revisar tipos de datos incorrectos", "Advertencia", MessageBoxButtons.OK);
                            }
                            else
                                MessageBox.Show("Favor de revisar Datos Vacíos", "Advertencia", MessageBoxButtons.OK);
                        }
                        else
                        {
                            if (Controlador.MetodosPlano.SiValidaUP(dtDatosPlano, Modelo.IndexColumn.USDPColumnaUP))
                            {
                                UDatosFinales df = new UDatosFinales();
                                df.Show();
                                Modelo.EncDatosConfiguracion.CierreAuto = true;
                                Close();
                            }
                            else
                                MessageBox.Show("Todas las viviendas deben de tener Unidad Prvativa",
                                    "Advertencia", MessageBoxButtons.OK);
                        }
                    }
                    //Reviso si hay más o menos viviendas de las específicadas en el conjunto
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
                }//FIN DE ROWCOUNT
                else
                {
                    MessageBox.Show("No hay datos capturados","Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRevelarId_Click(object sender, EventArgs e)
        {
            if (dtDatosPlano.Columns[Modelo.IndexColumn.USDPColumnaIDs].Visible == true)
            {
                dtDatosPlano.Columns[Modelo.IndexColumn.USDPColumnaIDs].Visible = false;
            }
            else
            {
                dtDatosPlano.Columns[Modelo.IndexColumn.USDPColumnaIDs].Visible = true;
            }
        }

        //Elimina los registros del datagridview
        private void btnBorrarTabla_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar datos de la tabla?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dtDatosPlano.Rows.Clear();
            }
        }

        private void cmDecimales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmDecimales.SelectedIndex != -1)
            {
                Modelo.EncDatosPlano.Decimales = int.Parse(cmDecimales.SelectedItem.ToString());
            }
        }

        #region Tooltips
        private void btnSelUnica_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Seleccion de 1 vivienda"+Environment.NewLine+"del plano", btnSelUnica,5000);
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

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            t1.Show("Encontrar el registro en blanco más cercano", btnSiguienteNull, 5000);
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


        private void dtDatosPlano_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //Inicializo contador y resultado
            int conteoActual = new int(), PendienteReal = new int();
            lblResViviendas.ForeColor = Color.SteelBlue;
            lblVivPndts.ForeColor = Color.Black;
            
            conteoActual = dtDatosPlano.Rows.Count;
            
            PendienteReal = Convert.ToInt32 (Modelo.EncDatosIniciales.ViviendasPendientes) - conteoActual;

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

        private void SelDatosPlano_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnSiguienteNull_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dtrow in dtDatosPlano.Rows)
            {
                foreach (DataGridViewCell dtcell in dtrow.Cells)
                {
                    //Valida que no busqué en vacíos las columnas que pudieran llegar a ir en blanco
                    if (dtrow.Cells[dtcell.ColumnIndex] != dtrow.Cells[Modelo.IndexColumn.USDPColumnaCalle]
                        && dtrow.Cells[dtcell.ColumnIndex] != dtrow.Cells[Modelo.IndexColumn.USDPColumnaNoOficial])
                    {
                        switch (dtcell.ColumnIndex)
                        {
                            //Celda 0 IDS
                            case Modelo.IndexColumn.USDPColumnaIDs:
                                break;
                            //Manzana
                            case Modelo.IndexColumn.USDPColumnaManzana:

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
                            //Dirección (Calle)
                            case Modelo.IndexColumn.USDPColumnaCalle:
                                break;
                            //Lote Final
                            case Modelo.IndexColumn.USDPColumnaLote:
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
                            case Modelo.IndexColumn.USDPColumnaNoInterior:
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
                            //Numero Oficial
                            case Modelo.IndexColumn.USDPColumnaNoOficial:
                                break;
                            case Modelo.IndexColumn.USDPColumnaM2Superficie:
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
                            //Unidad Privativa
                            case Modelo.IndexColumn.USDPColumnaUP:

                                //Valido que sólo asigne en blanco si se seleccionó true la Unidad Privativa
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

        private void dtDatosPlano_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtDatosPlano.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dtDatosPlano_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dtDatosPlano.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
        }
        
    }
}
