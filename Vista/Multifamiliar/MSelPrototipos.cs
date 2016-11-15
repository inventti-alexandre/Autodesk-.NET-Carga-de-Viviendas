using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PluginInsViviendas_UNO.Vista.Multifamiliar
{
    public partial class MSelPrototipos : Form
    {
        //Declaro marcadores de Paso Actual del Usuario
        bool boolPaso1 = false, boolPaso2 = false;

        //Declaro Index de Columnas
        

        List<int> listaPisos = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};

        public MSelPrototipos()
        {
            InitializeComponent();
        }

        private void MSelPrototipos_Load(object sender, EventArgs e)
        {
            //Agrego prototipos a listbox
            for (int i = 0; i < Modelo.EncDatosServicio.ProtosRecibidos.Count(); i++)
            {
                listbProtoIniciales.Items.Add(Modelo.EncDatosServicio.ProtosRecibidos[i].Name);
            }

            cmbSearch.SelectedIndex = 0;
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            Controlador.MetodosPrototipos.MueveItemsListBox(listbProtoIniciales, listbProtoSelec);
            listbProtoSelec.Sorted = true;
        }

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            Controlador.MetodosPrototipos.MueveItemsListBox(listbProtoSelec, listbProtoIniciales);
            listbProtoIniciales.Sorted = true;
        }

        private void btnPaso1Listo_Click(object sender, EventArgs e)
        {
            switch (boolPaso1)
            {
                //Cuando no hemos pasado por el paso-------------------------------------------------------------------
                case false:

                    if(listbProtoSelec.Items.Count > 0)
                    { 
                        //Deshabilito G1
                        btnDerecha.BackgroundImage = Properties.Resources.double_arrow_right_gray;
                        btnIzquierda.BackgroundImage = Properties.Resources.double_arrow_left_gray;
                        gpPaso1.Enabled = false;
                        lblAvanzar1.Visible = false;

                        //Habilito G2 y Despliego al usuario siguiente Paso
                        btnPaso2.BackgroundImage = Properties.Resources.listiconBlue;
                        btnAgregardtg.Enabled = true;
                        Line2.Image = Properties.Resources.horizontalblueline;
                        ChPaso1.Visible = true;
                        gpPaso2.Enabled = true;
                        btnPaso2.Enabled = true;
                        lblAvanzar2.Visible = true;
                        btnRefresh.BackgroundImage = Properties.Resources.refresh;

                        //Limpio Combobox y Asigno -> PROTOTIPOS
                        cmbAddProto.Items.Clear();

                        foreach (object itemActual in listbProtoSelec.Items)
                        {
                            cmbAddProto.Items.Add(itemActual);
                        }

                        //**************************************Limpio Combobox y Asigno -> LAYERS

                        //Declaro BD
                        Database db = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument.Database;

                        //Obtengo todos los Layers
                        List<string> listaLayers = Controlador.MetodosPrototipos.ObtengoTodasLayers(db);
                        
                        cmbAddLayer.Items.Clear();

                        foreach (string sLayer in listaLayers)
                        {
                            cmbAddLayer.Items.Add(sLayer);
                        }

                        //Limpio Combobox y Asigno -> PISO
                        cmbAddPiso.Items.Clear();

                        foreach (int Piso in listaPisos)
                        {
                            cmbAddPiso.Items.Add(Piso.ToString());
                        }

                        //Envío Paso a Verdadero
                        boolPaso1 = true;

                    }
                    else
                    {
                        MessageBox.Show("Favor de seleccionar Prototipos para Avanzar", "Paso 1",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                //Cuando regresas el paso-------------------------------------------------------------------
                case true:
                    if (MessageBox.Show("¿Desea regresar al Paso 1? \n Se perderán datos introducidos", "Regresar a Paso 1", 
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        //Elimino Avance
                        cmbAddLayer.Items.Clear();                        
                        cmbAddProto.Items.Clear();
                        cmbAddPiso.Items.Clear();
                        dtRelacion.Rows.Clear();

                        //Reestablezco Imagenes
                        btnSiguiente.BackgroundImage = Properties.Resources.nextPGray;
                        btnPaso2.BackgroundImage = Properties.Resources.listiconGray;
                        Line3.Image = Properties.Resources.horizontalgrayline;
                        Line2.Image = Properties.Resources.horizontalgrayline;

                        //Desactivo Visbilidad y Activo
                        lblAvanzar2.Visible = false;
                        lblSigModulo.Visible = false;
                        ChPaso1.Visible = false;
                        CHPaso2.Visible = false;
                        lblAvanzar1.Visible = true;

                        //Habilito Grupo
                        gpPaso1.Enabled = true;
                        btnDerecha.BackgroundImage = Properties.Resources.double_arrow_right1;
                        btnIzquierda.BackgroundImage = Properties.Resources.double_arrow_left1;

                        //Deshabilito
                        gpPaso2.Enabled = false;
                        btnPaso2.Enabled = false;
                        btnSiguiente.Enabled = false;
                    }

                    //Reinicio Pasos
                    boolPaso1 = false;
                    boolPaso2 = false;                    

                    break;
            }            
                       
        }

        private void btnAgregardtg_Click(object sender, EventArgs e)
        {
            //Reviso que no este en NULL ningún valor
            if (cmbAddLayer.SelectedItem != null && cmbAddProto.SelectedItem != null && cmbAddPiso.SelectedItem != null)
            {
                if (cmbAddLayer.SelectedItem.ToString() != string.Empty && cmbAddProto.SelectedItem.ToString() != string.Empty
                    && cmbAddPiso.SelectedItem.ToString() != string.Empty)
                {
                    //Boleanos para revisar si ya existe algún valor
                    bool RepProto = false, RepLayer = false, RepPiso = false;

                    //Reviso Valores Repetidos
                    foreach (DataGridViewRow dtRow in dtRelacion.Rows)
                    {
                        foreach (DataGridViewCell dtCell in dtRow.Cells)
                        {
                            switch (dtCell.ColumnIndex)
                            {
                                case Modelo.IndexColumn.MRSPColPrototipo:

                                    if (dtCell.Value == cmbAddProto.SelectedItem)
                                    {
                                        RepProto = true;
                                    }

                                    break;

                                case Modelo.IndexColumn.MRSPColLayer:

                                    if (dtCell.Value == cmbAddLayer.SelectedItem)
                                    {
                                        RepLayer = true;
                                    }

                                    break;

                                case Modelo.IndexColumn.MRSPColPiso:

                                    if (dtCell.Value == cmbAddPiso.SelectedItem)
                                    {
                                        RepPiso = true;
                                    }

                                    break;

                            }
                        }
                    }

                    if (RepProto == false && RepPiso == false && RepLayer == false)
                        dtRelacion.Rows.Add(cmbAddProto.SelectedItem.ToString(), cmbAddLayer.SelectedItem.ToString(),
                                    cmbAddPiso.SelectedItem.ToString());
                    else
                        MessageBox.Show("Se estan ingresando datos repetidos", "Datos Repetidos",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    MessageBox.Show("No se deben relacionar valores vacíos", "Datos Vacíos",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Favor de llenar los datos de relación completos", "Datos Incompletos",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbAddLayer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtProtoSearch_TextChanged(object sender, EventArgs e)
        {
            List<string> ListaProtoSelec = new List<string>();

            foreach(object itemActual in listbProtoSelec.Items)
            {
                ListaProtoSelec.Add(itemActual.ToString());
            }

            Controlador.MetodosPrototipos.FiltroPrototipos(Modelo.EncDatosServicio.ProtosRecibidos, listbProtoIniciales, 
                                                            cmbSearch.SelectedIndex, txtProtoSearch.Text, ListaProtoSelec);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //Declaro DB
            Database db = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument.Database;

            //Asigno a lista todos los Layers
            List<string> listaLayers = Controlador.MetodosPrototipos.ObtengoTodasLayers(db);

            cmbAddLayer.Items.Clear();

            foreach (string sLayer in listaLayers)
            {

                dtRelacion.Columns.Equals(sLayer);
                cmbAddLayer.Items.Add(sLayer);
            }
        }

        private void dtRelacion_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if(gpPaso2.Enabled == false)
            {
                //Reestablezco Paso 2
                lblAvanzar2.Visible = true;
                CHPaso2.Visible = false;
                gpPaso2.Enabled = true;
                btnRefresh.BackgroundImage = Properties.Resources.refresh;
                boolPaso2 = false;

            }

            //Deshabilito Paso Final
            Line3.Image = Properties.Resources.horizontalgrayline;
            btnSiguiente.BackgroundImage = Properties.Resources.nextPGray;
            btnSiguiente.Enabled = false;
            lblSigModulo.Visible = false;            

        }

        private void MSelPrototipos_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
                Modelo.EncDatosIniciales.PrototipoRelacional = new string[dtRelacion.RowCount, dtRelacion.ColumnCount];

                foreach (DataGridViewRow dtRow in dtRelacion.Rows)
                {
                    foreach (DataGridViewCell dtCell in dtRow.Cells)
                    {
                        Modelo.EncDatosIniciales.PrototipoRelacional[dtCell.RowIndex, dtCell.ColumnIndex] = dtCell.Value.ToString();
                    }
                }

                MSeleccionaPlano msp = new MSeleccionaPlano();
                msp.Show();
                Modelo.EncDatosConfiguracion.CierreAuto = true;
                this.Close();            

        }

        private void btnPaso2_Click(object sender, EventArgs e)
        {
            switch (boolPaso2)
            {
                case false:
                    if (cmbAddProto.Items.Count == dtRelacion.RowCount)
                    {
                        //Habilito Paso Siguiente
                        btnRefresh.BackgroundImage = Properties.Resources.refreshGray;
                        btnSiguiente.Enabled = true;

                        //Deshabilito grupo          
                        gpPaso2.Enabled = false;
                        lblAvanzar2.Visible = false;

                        //Despliego y habilito al usuario siguiente paso
                        Line3.Image = Properties.Resources.horizontalblueline;
                        btnSiguiente.BackgroundImage = Properties.Resources.nextPBlue;
                        lblSigModulo.Visible = true;
                        CHPaso2.Visible = true;

                        //Envío señal de Paso 2 cumplido
                        boolPaso2 = true;
                    }
                    else
                    {
                        MessageBox.Show("Favor de relacionar todos los prototipos seleccionados", "Paso 2",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case true:

                    if (MessageBox.Show("¿Desea regresar al Paso 2? \n Se perderán datos introducidos", "Regresar a Paso 2",
                                            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        //Limpio DTGView
                        dtRelacion.Rows.Clear();

                        //Reinicio paso Final
                        btnSiguiente.BackgroundImage = Properties.Resources.nextPGray;
                        Line3.Image = Properties.Resources.horizontalgrayline;
                        btnRefresh.BackgroundImage = Properties.Resources.refresh;

                        //Deshabilito
                        btnSiguiente.Enabled = false;
                        lblSigModulo.Visible = false;
                        CHPaso2.Visible = false;

                        //Habilito
                        lblAvanzar2.Visible = true;
                        gpPaso2.Enabled = true;

                        //Reinicio Paso 2
                        boolPaso2 = false;
                    }
                    break;
            }
         
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Desea regresar a Inicio?", "Ir a Inicio", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SelDatosIniciales sdi = new SelDatosIniciales();

                sdi.Show();
                Modelo.EncDatosConfiguracion.CierreAuto = true;
                Close();
            }
        }
    }
}
