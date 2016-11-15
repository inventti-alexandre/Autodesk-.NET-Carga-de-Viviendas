using DaSoft.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PluginInsViviendas_UNO.Vista.Unifamiliar
{
    public partial class UBtViviendasError : Form
    {
        public UBtViviendasError()
        {
            InitializeComponent();
        }
        bool SiExporto = false;
        private void BtViviendasError_Load(object sender, EventArgs e)
        {
            string Registradas = "";

            if (Controlador.MetodosFinales.ErroresViviendas(dtErrores, Modelo.EncapsulaBitacora.Bulkresponse))
            {
                gpRegresar.Enabled = false;

                MessageBox.Show("Todas las viviendas fueron cargadas a Sembrado de manera exitosa", "Viviendas enviadas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Asigno cuantas viviendas tenía el conjunto
                Registradas = Modelo.EncDatosServicio.FraccsRecibidos[Modelo.EncDatosIniciales.IndexFraccionamiento].
                                   Frentes.Frente[Modelo.EncDatosIniciales.IndexFrente].Conjuntos.
                                   Conjunto[Modelo.EncDatosServicio.ListaConjuntosIndex[Modelo.EncDatosIniciales.ComboIndexConjunto]].
                                   HomeRegisteredQuantity;

                //Sumo las viviendas cargadas.
                Modelo.EncDatosServicio.FraccsRecibidos[Modelo.EncDatosIniciales.IndexFraccionamiento].
                Frentes.Frente[Modelo.EncDatosIniciales.IndexFrente].Conjuntos.
                Conjunto[Modelo.EncDatosServicio.ListaConjuntosIndex[Modelo.EncDatosIniciales.ComboIndexConjunto]].
                HomeRegisteredQuantity = (int.Parse(Registradas) + Modelo.EncapsulaBitacora.Bulkresponse.RecordList.Count()).ToString();

                Modelo.EncDatosIniciales.ViviendasCargadas = Modelo.EncDatosServicio.FraccsRecibidos[Modelo.EncDatosIniciales.IndexFraccionamiento].
                                                                            Frentes.Frente[Modelo.EncDatosIniciales.IndexFrente].Conjuntos.
                                                                            Conjunto[Modelo.EncDatosServicio.ListaConjuntosIndex[Modelo.EncDatosIniciales.ComboIndexConjunto]].
                                                                            HomeRegisteredQuantity;
            }
            else
            {
                MessageBox.Show("Ninguna vivienda fue cargada a Sembrado, favor de revisar vivienda(s) con error", "Viviendas enviadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCargarNuevo_Click(object sender, EventArgs e)
        {
            if (SiExporto)
            {
                DialogResult dr = MessageBox.Show("¿Desea ir a Inicio? Se perderán datos seleccionados en el conjunto actual", "Ir a Inicio",
                                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    //Elimino datos de segunda y tercer pantalla, conservo datos iniciales
                    Controlador.MetodosFinales.LimpiaTodoEncapsulado(false, true, true);

                    //Inicio primer pantalla y actualizo viviendas del conjunto
                    SelDatosIniciales sdi = new SelDatosIniciales();
                    sdi.ActualizaConjunto = true;
                    sdi.Show();
                    Modelo.EncDatosConfiguracion.CierreAuto = true;
                    this.Close();
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("¿Desea ir a Inicio? Se perderán datos seleccionados en el conjunto actual \n Nota: NO SE HAN EXPORTADO LOS DATOS A EXCEL", 
                                                    "Ir a Inicio", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    //Elimino datos de segunda y tercer pantalla, conservo datos iniciales
                    Controlador.MetodosFinales.LimpiaTodoEncapsulado(false, true, true);

                    //Inicio primer pantalla y actualizo viviendas del conjunto
                    SelDatosIniciales sdi = new SelDatosIniciales();
                    sdi.ActualizaConjunto = true;
                    sdi.Show();
                    Modelo.EncDatosConfiguracion.CierreAuto = true;
                    this.Close();
                }
            }

        }

        private void btnSelDatos_Click(object sender, EventArgs e)
        {
            if (SiExporto)
            {
                DialogResult dr = MessageBox.Show("¿Desea ir al módulo Selección de Datos?", "Corregir Viviendas con Error",
                                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    //Elimino datos de tercer pantalla, conservo datos iniciales y de selección
                    Controlador.MetodosFinales.LimpiaTodoEncapsulado(false, false, true);

                    //Envio señal para que llene el DTGV
                    Modelo.EncDatosConfiguracion.ConDatos = true;

                    //Inicio primer pantalla y actualizo viviendas del conjunto
                    USelDatosPlano sdp = new USelDatosPlano();
                    sdp.Show();
                    Modelo.EncDatosConfiguracion.CierreAuto = true;
                    this.Close();
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("¿Desea ir al módulo Selección de Datos? \n Nota: NO SE HAN EXPORTADO LOS DATOS A EXCEL", "Corregir Viviendas con Error",
                                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    //Elimino datos de tercer pantalla, conservo datos iniciales y de selección
                    Controlador.MetodosFinales.LimpiaTodoEncapsulado(false, false, true);

                    //Envio señal para que llene el DTGV
                    Modelo.EncDatosConfiguracion.ConDatos = true;

                    //Inicio primer pantalla y actualizo viviendas del conjunto
                    USelDatosPlano sdp = new USelDatosPlano();
                    sdp.Show();
                    Modelo.EncDatosConfiguracion.CierreAuto = true;
                    this.Close();
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //Pongo imagenes visibles
            lblExportando.Visible = true;
            loadingExport.Visible = true;

            bkWorker = new BackgroundWorker();
            bkWorker.DoWork += new DoWorkEventHandler(BGWorker_DoWork);
            if (bkWorker.IsBusy == false)
            {
                bkWorker.RunWorkerAsync();
            }

            bkWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            //Primero es conectarnos a Excel
            XlsConn xls = new XlsConn();

            //Abre Excel
            if (!xls.ConectionStatus)
                xls.Connect();
            string activeCell = xls.GetActiveCell(), rowCell = xls.GetActiveCell();

            foreach (DataGridViewCell dtcell in dtErrores.Rows[0].Cells)
            {
                string header = dtcell.OwningColumn.HeaderText;

                xls.WriteCell(activeCell, 1, 1, header);

                activeCell = XlsConn.NextCell(activeCell, CellOffset.Horizontal);
            }

            rowCell = XlsConn.NextCell(rowCell, CellOffset.Vertical);
            activeCell = rowCell;

            //2: Inserto la informacion dela tabla de Autocad a xcel
            //Horizontal y luego vertical
            foreach (DataGridViewRow row in this.dtErrores.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //Escribe la fila preguntando el offset
                    xls.WriteCell(activeCell, 1, 1, cell.Value as String);
                    //Actualizo la celda para el siguiente valor
                    activeCell = XlsConn.NextCell(activeCell, CellOffset.Horizontal);
                }
                //Salto de línea en excel
                rowCell = XlsConn.NextCell(rowCell, CellOffset.Vertical);
                activeCell = rowCell;
            }

            SiExporto = true;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingExport.Visible = false;
            lblExportando.Visible = false;
        }

        private void BtViviendasError_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea regresar a Módulo Complemento de Datos?", "Regresar", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                UDatosFinales sdp = new UDatosFinales();
                Modelo.EncDatosConfiguracion.ConDatos = true;
                sdp.Show();
                Modelo.EncDatosPlano.M2SuperFloteTipo.Clear();
                Modelo.EncDatosConfiguracion.CierreAuto = true;
                Close();
            }
        }
    }
}
