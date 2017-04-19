using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Windows.Forms;

namespace PluginInsViviendas_UNO.Controlador
{
    public class MetodosFinales
    {

        public static bool SiEmptyoNull(DataGridView dt, int index)
        {
            bool SiEmpty = false;
            DataGridView dtFinal = dt;

            foreach (DataGridViewRow dtrow in dt.Rows)
            {
                object ValorCelda = dtrow.Cells[index].Value;

                if(string.IsNullOrEmpty((ValorCelda ?? "").ToString()) || string.IsNullOrWhiteSpace((ValorCelda ?? "").ToString()))
                {
                    SiEmpty = true;
                    dtrow.Cells[index].Style.BackColor = System.Drawing.Color.LightSkyBlue;
                }
            }


            return SiEmpty;
        }

        public static bool SiDatoNumerico(DataGridView dt, int index)
        {
            bool esNumerico = true;

            foreach (DataGridViewRow dtrow in dt.Rows)
            {
                float resNumerico = new float();
                bool ValorNumerico = float.TryParse(dtrow.Cells[index].Value.ToString(), out resNumerico);

                if (ValorNumerico == false)
                {
                    esNumerico = false;
                    dtrow.Cells[index].Style.BackColor = System.Drawing.Color.LightGray;
                }

            }

            return esNumerico;
        }

        internal static void ReciboDatosDF(DataGridView dtDatosFinales, string TipoCarga)
        {
            if(TipoCarga == "Unifamiliar")
            {
                #region U
                for (int row = 0; row < Modelo.EncDatosPlano.VivsSeleccionPlano.GetLength(0); row++)
                {
                    dtDatosFinales.Rows.Add();
                    for (int cell = 0; cell < Modelo.EncDatosPlano.VivsSeleccionPlano.GetLength(1); cell++)
                    {
                        switch(cell)
                        {
                            case Modelo.IndexColumn.UDFColumnaManzana:
                                dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsSeleccionPlano[row, Modelo.IndexColumn.USDPColumnaManzana];
                                break;

                            case Modelo.IndexColumn.UDFColumnaLote:
                                dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsSeleccionPlano[row, Modelo.IndexColumn.USDPColumnaLote];
                                break;

                            case Modelo.IndexColumn.UDFColumnaNoOficial:
                                dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsSeleccionPlano[row, Modelo.IndexColumn.USDPColumnaNoOficial];
                                break;

                            case Modelo.IndexColumn.UDFColumnaNoInterior:
                                dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsSeleccionPlano[row, Modelo.IndexColumn.USDPColumnaNoInterior];
                                break;

                            case Modelo.IndexColumn.UDFColumnaM2Superficie:
                                dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsSeleccionPlano[row, Modelo.IndexColumn.USDPColumnaM2Superficie];
                                break;

                            case Modelo.IndexColumn.UDFColumnaUP:
                                dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsSeleccionPlano[row, Modelo.IndexColumn.USDPColumnaUP];
                                break;

                            case Modelo.IndexColumn.UDFColumnaDireccion:
                                dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsSeleccionPlano[row, Modelo.IndexColumn.USDPColumnaCalle];
                                break;
                        }
                        
                    }
                }
                #endregion
            }
            else//Multifamiliar
            {
                #region M

                for (int row = 0; row < Modelo.EncDatosPlano.VivsSeleccionPlano.GetLength(0); row++)
                {
                    dtDatosFinales.Rows.Add();
                    for(int cell = 0; cell < Modelo.EncDatosPlano.VivsSeleccionPlano.GetLength(1); cell++)
                    {
                        switch (cell)
                        {
                            case Modelo.IndexColumn.MDFColumnaPrototipo:
                                dtDatosFinales.Rows[row].Cells[cell].Value 
                                    = Modelo.EncDatosPlano.VivsSeleccionPlano[row, Modelo.IndexColumn.MSDPColumnaPrototipo];
                                break;

                            case Modelo.IndexColumn.MDFColumnaManzana:
                                dtDatosFinales.Rows[row].Cells[cell].Value 
                                    = Modelo.EncDatosPlano.VivsSeleccionPlano[row, Modelo.IndexColumn.MSDPColumnaManzana];
                                break;

                            case Modelo.IndexColumn.MDFColumnaLote:
                                dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsSeleccionPlano[row, Modelo.IndexColumn.MSDPColumnaLote];
                                break;

                            case Modelo.IndexColumn.MDFColumnaNoOficial:
                                dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsSeleccionPlano[row, Modelo.IndexColumn.MSDPColumnaNoOficial];
                                break;

                            case Modelo.IndexColumn.MDFColumnaPiso:
                                dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsSeleccionPlano[row, Modelo.IndexColumn.MSDPColumnaPiso];
                                break;

                            case Modelo.IndexColumn.MDFColumnaNoInterior:
                                dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsSeleccionPlano[row, Modelo.IndexColumn.MSDPColumnaNoInterior];
                                break;

                            case Modelo.IndexColumn.MDFColumnaUP:
                                dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsSeleccionPlano[row, Modelo.IndexColumn.MSDPColumnaUP];
                                break;

                            case Modelo.IndexColumn.MDFColumnaCalle:
                                dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsSeleccionPlano[row, Modelo.IndexColumn.MSDPColumnaCalle];
                                break;

                            case Modelo.IndexColumn.MDFColumnaM2Sup:
                                dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsSeleccionPlano[row, Modelo.IndexColumn.MSDPColumnaM2Sup];
                                break;
                        }
                    }
                }

                #endregion
            }
        }

        internal static void RegresoDatosSDP(DataGridView dtDatosPlano, string TipoCarga)
        {
            if (TipoCarga == "Unifamiliar")
            {
                #region U
                for (int row = 0; row < Modelo.EncDatosPlano.VivsSeleccionPlano.GetLength(0); row++)
                {
                    dtDatosPlano.Rows.Add();

                    for (int cell = 0; cell < Modelo.EncDatosPlano.VivsSeleccionPlano.GetLength(1); cell++)
                    {
                        if (cell != Modelo.IndexColumn.USDPColumnaNoOficial)
                        {
                            dtDatosPlano.Rows[row].Cells[cell].Value = Modelo.EncDatosPlano.VivsSeleccionPlano[row, cell];
                        }
                        else
                        {
                            ComboBox cmb = new ComboBox();
                            cmb.Items.Add(Modelo.EncDatosPlano.VivsSeleccionPlano[row, cell]);

                            ((DataGridViewComboBoxCell)dtDatosPlano.Rows[row].Cells[cell]).DataSource = cmb.Items;

                            dtDatosPlano.Rows[row].Cells[cell].Value = Modelo.EncDatosPlano.VivsSeleccionPlano[row, cell];
                        }
                    }
                }
                #endregion
            }
            else//Multifamiliar
            {
                #region M

                for (int row = 0; row < Modelo.EncDatosPlano.VivsSeleccionPlano.GetLength(0); row++)
                {
                    dtDatosPlano.Rows.Add();
                    for (int cell = 0; cell < Modelo.EncDatosPlano.VivsSeleccionPlano.GetLength(1); cell++)
                    {

                        if(cell != Modelo.IndexColumn.MSDPColumnaNoOficial)
                        {
                            dtDatosPlano.Rows[row].Cells[cell].Value = Modelo.EncDatosPlano.VivsSeleccionPlano[row, cell];
                        }
                        else
                        {
                            ComboBox cmb = new ComboBox();
                            cmb.Items.Add(Modelo.EncDatosPlano.VivsSeleccionPlano[row, cell]);

                            ((DataGridViewComboBoxCell)dtDatosPlano.Rows[row].Cells[cell]).DataSource = cmb.Items;

                            dtDatosPlano.Rows[row].Cells[cell].Value = Modelo.EncDatosPlano.VivsSeleccionPlano[row, cell];
                        }
                    }
                }

                #endregion
            }
        }

        internal static void RegresoDatosDF(DataGridView dtDatosFinales, string TipoCarga)
        {
            if (TipoCarga == "Unifamiliar")
            {
                #region U
                for (int row = 0; row < Modelo.EncDatosPlano.VivsFinales.GetLength(0); row++)
                {
                    dtDatosFinales.Rows.Add();
                    for (int cell = 0; cell < Modelo.EncDatosPlano.VivsFinales.GetLength(1); cell++)
                    {
                        if (cell != Modelo.IndexColumn.UDFColumnaBnVivVerde && cell != Modelo.IndexColumn.UDFColumnaBnMuestra
                            && cell != Modelo.IndexColumn.UDFColumnaBnDisponible && cell != Modelo.IndexColumn.UDFColumnaBnCablevision)
                        {
                            dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsFinales[row, cell];
                        }
                        else
                        {
                            dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsFinales[row, cell] == "1";
                        }
                    }
                }
                #endregion
            }
            else//Multifamiliar
            {
                #region M

                for (int row = 0; row < Modelo.EncDatosPlano.VivsFinales.GetLength(0); row++)
                {
                    dtDatosFinales.Rows.Add();
                    for (int cell = 0; cell < Modelo.EncDatosPlano.VivsFinales.GetLength(1); cell++)
                    {
                        if (cell != Modelo.IndexColumn.MDFViviendaVerde && cell != Modelo.IndexColumn.MDFMuestra
                            && cell != Modelo.IndexColumn.MDFDisponible && cell != Modelo.IndexColumn.MDFCablevision)
                        {
                            dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsFinales[row, cell];                            
                        }
                        else
                        {                            
                            dtDatosFinales.Rows[row].Cells[cell].Value
                                    = Modelo.EncDatosPlano.VivsFinales[row, cell] == "1";
                        }
                    }
                }

                #endregion
            }
        }

        public static void EnviaBlancoCeldas(DataGridView dt)
        {
            DataGridView dtFinal = dt;

            foreach (DataGridViewRow dtrow in dtFinal.Rows)
            {
                for (int i = 0; i < dtFinal.ColumnCount; i++)
                {
                    dtrow.Cells[i].Style.BackColor = System.Drawing.Color.White;
                }
            }            

        }

        public static soaBulk.BulkUploadRs CargaViviendas(string[,] VivsEnviadas, BackgroundWorker worker, string tipoCarga)
        {

            soaBulk.BulkUploadRq bulkupload = new soaBulk.BulkUploadRq();
            soaBulk.BulkUploadRs bulkResponse = new soaBulk.BulkUploadRs();

            worker.WorkerReportsProgress = true;
            int ViviendasTotales = VivsEnviadas.GetLength(0);
            int PeriodoPorcentaje = 100 / ViviendasTotales;
            int PorcentajeAvance = 0;

            #region DeclaroCliente
            //1. Binding agregandole transporte y parametros para ambos servicios
            CustomBinding csBinding = ConfiguraServicio.AsignaCustomBinding();

            //2. Asigno URL de endpoint de Carga de Viviendas
            EndpointAddress endpointAddress = new
            EndpointAddress(Modelo.EncDatosServicio.WsdlCargaVivs);

            //3. Declaro Cliente asignandole binding y URL de prototipo
            soaBulk.ManageHomePortTypeClient bulkClient =
                new soaBulk.ManageHomePortTypeClient(csBinding, endpointAddress);
            #endregion

            #region InicializoVariablesdeCarga
            //Declario Datos Iniciales
            bulkupload.IpAddress = Modelo.EncDatosIniciales.Ip;
            bulkupload.User = Modelo.EncDatosIniciales.User;
            bulkupload.RequestDate = DateTime.Now;
            bulkupload.RequestDateSpecified = true;
            bulkupload.SourceSystem = "AUTODESK";
            bulkupload.Version = "1";


            //Inicializo todas las variables del servicio
            //*FRACCIONAMIENTOS*//
            bulkupload.Fraccionamientos = new soaBulk.FraccionamientoListType();
            bulkupload.Fraccionamientos.Fraccionamiento = new soaBulk.FraccionamientoType[1];
            bulkupload.Fraccionamientos.Fraccionamiento[0] = new soaBulk.FraccionamientoType();

            //*FRENTES*//
            bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes = new soaBulk.FrenteListType();
            bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente = new soaBulk.FrenteType[1];
            bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0] = new soaBulk.FrenteType();
            bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Fideicomiso = new soaBulk.FideicomisoType();

            //*CONJUNTOS*//
            bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos = new soaBulk.ConjuntoListType();
            bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto = new soaBulk.ConjuntoType[1];
            bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0] = new soaBulk.ConjuntoType();

            //*VIVIENDAS*//
            bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList = new soaBulk.HomeListType();
            bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home =
                                                                                                            new soaBulk.HomeType[ViviendasTotales];
            #endregion

            //Fraccionamiento
            bulkupload.Fraccionamientos.Fraccionamiento[0].Name = Modelo.EncDatosIniciales.Fraccionamiento;

            //Frente y Fideicomiso
            bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Name = Modelo.EncDatosIniciales.Frente;
            bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].FideicomisoFlag =
                                                                             Modelo.EncDatosIniciales.SiFideicomiso;
            bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Fideicomiso.Description =
                                                                             Modelo.EncDatosIniciales.Fideicomiso;
            bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].IsNewFlag = "0";


            //Conjunto y Prototipo
            bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].Name =
                                                                             Modelo.EncDatosIniciales.Conjunto;
            
            
            if (tipoCarga == "Unifamiliar")
            {
                //Asigno prototipo a Nivel Conjunto (Cambio realizado el 14 de Marzo del 2017)
                //No llegaba a SOA carga de Prototipo a Nivel conjunto Unifamiliar
                //bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0]
                //    .Prototipo = Modelo.EncDatosIniciales.Prototipo;

                for (int row = 0; row < Modelo.EncDatosPlano.VivsSeleccionPlano.GetLength(0); row++)
                {
                    PorcentajeAvance += PeriodoPorcentaje;

                    worker.ReportProgress(PorcentajeAvance);

                    //Inicializo la vivienda a asignar
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                                                                                                                = new soaBulk.HomeType();
                    //Asigno prototipo
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .Prototipo = Modelo.EncDatosIniciales.Prototipo;

                    //Asigno manzana
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .Manzana = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.UDFColumnaManzana];

                    //Lote
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .NumeroLote = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.UDFColumnaLote];

                    //Número Oficial
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .NumeroOficial = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.UDFColumnaNoOficial];

                    //Piso
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .Piso = "0";

                    //Número Interior
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .NumeroInterior = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.UDFColumnaNoInterior];

                    //Unidad Privativa-----------------------------------------------------------------------------------------
                    if (!string.IsNullOrWhiteSpace(Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.UDFColumnaUP]))
                    {
                        //Si tiene UP
                        bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                            .FlagUnidadPrivativa = "1";

                        //Unidad Privativa
                        bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                            .UnidadPrivativa = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.UDFColumnaUP];
                    }
                    else
                    {
                        //No tiene UP
                        bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                            .FlagUnidadPrivativa = "0";

                        //Unidad Privativa
                        bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                            .UnidadPrivativa = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.UDFColumnaUP];
                    }
                    //----------------------------------------------------------------------------------------------------------

                    //Calle o Dirección
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .Direccion = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.UDFColumnaDireccion];

                    //M2 de Superficie
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .M2Superficie = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.UDFColumnaM2Superficie];

                    //Superficie Lote Tipo
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .SuperfloteTipo = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.UDFColumnaSuperflotetipo];

                    //M2 Superficie Excedente
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .M2SuperficieExcedente = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.UDFColumnaM2Excedente];

                    //Vivienda Verde
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .FlagViviendaVerde = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.UDFColumnaBnVivVerde];

                    //Es Muestra
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .FlagMuestra = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.UDFColumnaBnMuestra];

                    //Disponible
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .FlagDisponible = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.UDFColumnaBnDisponible];

                    //Cablevision
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .Cablevision = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.UDFColumnaBnCablevision];

                }
            }
            else//Multifamiliar
            {
                for (int row = 0; row < Modelo.EncDatosPlano.VivsSeleccionPlano.GetLength(0); row++)
                {
                    PorcentajeAvance += PeriodoPorcentaje;

                    worker.ReportProgress(PorcentajeAvance);

                    //Inicializo la vivienda a asignar
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                                                                                                                = new soaBulk.HomeType();

                    //Asigno prototipo
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .Prototipo = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFColumnaPrototipo];

                    //Asigno manzana
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .Manzana = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFColumnaManzana];

                    //Lote
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .NumeroLote = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFColumnaLote];

                    //Número Oficial
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .NumeroOficial = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFColumnaNoOficial];

                    //Piso
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .Piso = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFColumnaPiso];

                    //Número Interior
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .NumeroInterior = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFColumnaNoInterior];

                    //Unidad Privativa-----------------------------------------------------------------------------------------
                    if (!string.IsNullOrWhiteSpace(Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFColumnaUP]))
                    {
                        //Si tiene UP
                        bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                            .FlagUnidadPrivativa = "1";

                        //Unidad Privativa
                        bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                            .UnidadPrivativa = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFColumnaUP];
                    }
                    else
                    {
                        //No tiene UP
                        bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                            .FlagUnidadPrivativa = "0";

                        //Unidad Privativa
                        bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                            .UnidadPrivativa = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFColumnaUP];
                    }
                    //----------------------------------------------------------------------------------------------------------

                    //Calle o Dirección
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .Direccion = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFColumnaCalle];

                    //M2 de Superficie
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .M2Superficie = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFColumnaM2Sup];

                    //Superficie Lote Tipo
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .SuperfloteTipo = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFColumnaSuperfloteTipo];

                    //M2 Superficie Excedente
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .M2SuperficieExcedente = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFColumnaM2Excedente];

                    //M2 de Construcción
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .M2Construccion = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFColumnaM2Construccion];

                    //Vivienda Verde
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .FlagViviendaVerde = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFViviendaVerde];

                    //Es Muestra
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .FlagMuestra = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFMuestra];

                    //Disponible
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .FlagDisponible = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFDisponible];

                    //Cablevision
                    bulkupload.Fraccionamientos.Fraccionamiento[0].Frentes.Frente[0].Conjuntos.Conjunto[0].HomeList.Home[row]
                        .Cablevision = Modelo.EncDatosPlano.VivsFinales[row, Modelo.IndexColumn.MDFCablevision];
                }

            }

            bulkResponse = bulkClient.BulkUpload(bulkupload);

            return bulkResponse;
        }

        public static void CargoDatosFinales(DataGridView dtDatosFinales, string TipoCarga)
        {
            Modelo.EncDatosPlano.VivsFinales = new string[dtDatosFinales.RowCount, dtDatosFinales.ColumnCount];

            if (TipoCarga == "Multifamiliar")
            {
                foreach (DataGridViewRow dtrow in dtDatosFinales.Rows)
                {
                    foreach (DataGridViewCell dtcell in dtrow.Cells)
                    {
                        if (dtcell.ColumnIndex != Modelo.IndexColumn.MDFViviendaVerde && dtcell.ColumnIndex != Modelo.IndexColumn.MDFMuestra
                            && dtcell.ColumnIndex != Modelo.IndexColumn.MDFDisponible && dtcell.ColumnIndex != Modelo.IndexColumn.MDFCablevision)
                        {
                            Modelo.EncDatosPlano.VivsFinales[dtcell.RowIndex, dtcell.ColumnIndex] = dtcell.Value.ToString();
                        }
                        else
                        {
                            Modelo.EncDatosPlano.VivsFinales[dtcell.RowIndex, dtcell.ColumnIndex] =
                                ((Convert.ToBoolean(dtrow.Cells[dtcell.ColumnIndex].Value) ? 1 : 0).ToString());
                        }
                    }
                }
            }
            else//Unifamiliar
            {
                foreach (DataGridViewRow dtrow in dtDatosFinales.Rows)
                {
                    foreach (DataGridViewCell dtcell in dtrow.Cells)
                    {
                        if (dtcell.ColumnIndex != Modelo.IndexColumn.UDFColumnaBnVivVerde && dtcell.ColumnIndex != Modelo.IndexColumn.UDFColumnaBnMuestra
                            && dtcell.ColumnIndex != Modelo.IndexColumn.UDFColumnaBnDisponible && dtcell.ColumnIndex != Modelo.IndexColumn.UDFColumnaBnCablevision)
                        {
                            Modelo.EncDatosPlano.VivsFinales[dtcell.RowIndex, dtcell.ColumnIndex] = dtcell.Value.ToString();
                        }
                        else
                        {
                            Modelo.EncDatosPlano.VivsFinales[dtcell.RowIndex, dtcell.ColumnIndex] =
                                ((Convert.ToBoolean(dtrow.Cells[dtcell.ColumnIndex].Value) ? 1 : 0).ToString());
                        }
                    }
                }
            }
        }

        internal static bool SiSumaM2Excedente(DataGridView dtDatosFinales)
        {
            bool SiSumaCorrecta = true;
            List<string> DistintosLotes = new List<string>();

            foreach(DataGridViewRow dtrow in dtDatosFinales.Rows)
            {
                if(!DistintosLotes.Contains((dtrow.Cells[Modelo.IndexColumn.MDFColumnaLote].Value ?? "").ToString()))
                    DistintosLotes.Add((dtrow.Cells[Modelo.IndexColumn.MDFColumnaLote].Value ?? "").ToString());
            }

            foreach(string LoteActual in DistintosLotes)
            {
                int     RenglonesLote = 0;
                decimal SumaM2Superficie = 0,
                        SumaSuperficieLoteTipo = 0,
                        SumaExcedente = 0;

                List<int> RenglonesaMarcar = new List<int>();

                foreach(DataGridViewRow dtrow in dtDatosFinales.Rows)
                {
                    if((dtrow.Cells[Modelo.IndexColumn.MDFColumnaLote].Value ?? "").ToString() == LoteActual)
                    {
                        RenglonesaMarcar.Add(dtrow.Index);
                        RenglonesLote += 1;
                        SumaM2Superficie += decimal.Parse(dtrow.Cells[Modelo.IndexColumn.MDFColumnaM2Sup].Value.ToString());
                        SumaExcedente += decimal.Parse(dtrow.Cells[Modelo.IndexColumn.MDFColumnaM2Excedente].Value.ToString());
                        SumaSuperficieLoteTipo += decimal.Parse(dtrow.Cells[Modelo.IndexColumn.MDFColumnaSuperfloteTipo].Value.ToString());
                    }
                }

                decimal excedenteRedondeo =((SumaM2Superficie - SumaSuperficieLoteTipo) / RenglonesLote);

                string excedenteCorrecto = string.Format(MetodosPlano.EnviaFormatoArea(Modelo.EncDatosPlano.Decimales.ToString()),
                                                            excedenteRedondeo);

                if(SumaExcedente != decimal.Parse(excedenteCorrecto))
                {
                    SiSumaCorrecta = false;
                    
                    foreach(int indexActual in RenglonesaMarcar)
                    {
                        dtDatosFinales.Rows[indexActual].Cells[Modelo.IndexColumn.MDFColumnaM2Excedente].Style.BackColor
                            = System.Drawing.Color.FromArgb(255, 255, 128);

                    }
                }

            }

            return SiSumaCorrecta;
        }

        public static bool ErroresViviendas(DataGridView dtInicia, soaBulk.BulkUploadRs bulkrs)
        {
            bool CargaExitosa = false;            
            int conError = 0,
                sinError = 0;           
            
            if (bulkrs.RecordList != null && bulkrs.RecordList.Count() > 0)
            {
                for (int i = 0; i < bulkrs.RecordList.Count(); i++)
                {
                    string  error = "", manzana = "", noLote = "", noInterior = "", noOficial = "", direccion = "",
                            prototipo = "", fraccionamiento = "", frente = "", conjunto = "",fechaCarga = "", idArchivo = "";

                    bool SiError = false;
                    error = bulkrs.RecordList[i].Error;
                    if (error == string.Empty)
                    {
                        error = "VIVIENDA CORRECTA";
                        sinError += 1;
                    }
                    else//Tiene error
                    {
                        SiError = true;
                        conError += 1;
                    }
                    manzana = bulkrs.RecordList[i].Manzana;
                    noLote = bulkrs.RecordList[i].NumeroLote;
                    noInterior = bulkrs.RecordList[i].NumeroInterior;
                    noOficial = bulkrs.RecordList[i].NumeroOficial;
                    direccion = bulkrs.RecordList[i].Direccion;
                    prototipo = bulkrs.RecordList[i].Prototipo;
                    fraccionamiento = bulkrs.RecordList[i].Fraccionamiento;
                    frente = bulkrs.RecordList[i].Sector;
                    conjunto = bulkrs.RecordList[i].Etapa;
                    fechaCarga = bulkrs.RecordList[i].FechaCarga;
                    idArchivo = bulkrs.RecordList[i].ID_Archivo;

                    dtInicia.Rows.Add(error, manzana, noLote, noInterior,noOficial,direccion,
                                      fechaCarga, prototipo, fraccionamiento, frente, conjunto, idArchivo);

                    if (SiError == true)
                    {
                        int lastRow = dtInicia.Rows.Count-1;
                        dtInicia.Rows[lastRow].Cells[0].Style.BackColor = System.Drawing.Color.Red;
                    }
                }

                if (sinError == bulkrs.RecordList.Count())
                {
                    //Todas las viviendas fueron cargadas con éxito
                    CargaExitosa = true;
                }

            }
            
            return CargaExitosa;
        }

        public static void LimpiaTodoEncapsulado(bool SDI, bool SDP, bool DF)
        {
            #region Selección de Datos Iniciales

            //Encapsulado de Datos Iniciales
            if (SDI)
            {

                Modelo.EncDatosIniciales.Conjunto = string.Empty;
                Modelo.EncDatosIniciales.Fideicomiso = string.Empty;
                Modelo.EncDatosIniciales.Fraccionamiento = string.Empty;
                Modelo.EncDatosIniciales.Frente = string.Empty;
                Modelo.EncDatosIniciales.IndexFraccionamiento = new int();
                Modelo.EncDatosIniciales.IndexFrente = new int();
                Modelo.EncDatosIniciales.Ip = string.Empty;
                Modelo.EncDatosIniciales.Prototipo = string.Empty;
                Modelo.EncDatosIniciales.SiFideicomiso = new bool();
                Modelo.EncDatosIniciales.User = string.Empty;
                Modelo.EncDatosIniciales.ViviendasCargadas = string.Empty;
                Modelo.EncDatosIniciales.ViviendasMaximas = string.Empty;
                Modelo.EncDatosIniciales.ViviendasPendientes = string.Empty;
                Modelo.EncDatosIniciales.ComboIndexConjunto = new int();
                Modelo.EncDatosIniciales.ComboIndexFracc = new int();
                Modelo.EncDatosIniciales.ComboIndexFrente = new int();
                Modelo.EncDatosIniciales.ComboIndexProto = new int();
                Modelo.EncDatosIniciales.EsMultifamiliar = new bool();
                Modelo.EncDatosIniciales.PrototipoRelacional = null;

                //Encapsulado de Datos Servicio
                Modelo.EncDatosServicio.FraccsRecibidos = null;
                Modelo.EncDatosServicio.ProtosRecibidos = null;
                Modelo.EncDatosServicio.ListaConjuntosNombres.Clear();
                Modelo.EncDatosServicio.ListaConjuntosIndex.Clear();
                Modelo.EncDatosServicio.ListaFrentesNombres.Clear();
                Modelo.EncDatosServicio.ListaFrentesIndex.Clear();
                Modelo.EncDatosServicio.ListaFraccNombres.Clear();
                Modelo.EncDatosServicio.ListaFraccIndex.Clear();
            }
            #endregion

            #region Selección de Datos del Plano
            if (SDP)
            {
                Modelo.EncDatosPlano.VivsSeleccionPlano = null;
                Modelo.EncDatosPlano.Decimales = new int();
                Modelo.EncDatosPlano.M2SuperFloteTipo.Clear();
                Modelo.EncDatosPlano.ListaOrdenValor.Clear();
                Modelo.EncDatosPlano.NoOficialSel = null;
                Modelo.EncDatosPlano.ListOrdenPl.Clear();
                Modelo.EncDatosPlano.ListOrdenNoInt.Clear();
                Modelo.EncDatosPlano.ListOrdenPiso.Clear();
            }
            #endregion

            #region Datos Finales / Complemento de Datos
            if (DF == true)
            {
                Modelo.EncDatosPlano.VivsFinales = null;
                Modelo.EncapsulaBitacora.Bulkresponse = new soaBulk.BulkUploadRs();
            }
            #endregion
        }

    }
}
