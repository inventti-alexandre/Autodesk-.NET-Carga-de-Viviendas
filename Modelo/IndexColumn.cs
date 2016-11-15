//Manuel Nieto
//Guarda Index de Columnas de los distintos DGVS existentes en los módulos para un acceso global --> Cambiar aquí si cambia algún orden

namespace PluginInsViviendas_UNO.Modelo
{
    public class IndexColumn
    {
        #region Multifamiliar

        //Modulo Selección del Prototipos (Vista/Multifamiliar/MSelPrototipos)
        public const int    MRSPColPrototipo = 0,
                            MRSPColLayer = 1,
                            MRSPColPiso = 2;


        //Modulo Selección del Plano (Vista/Multifamiliar/MSeleccionaPlano)
        public const int    MSDPColumnaIDPlLote = 0,
                            MSDPColumnaIDs = 1,
                            MSDPColumnaPrototipo = 2,
                            MSDPColumnaManzana = 3,
                            MSDPColumnaLote = 4,
                            MSDPColumnaNoOficial = 5,
                            MSDPColumnaPiso = 6,
                            MSDPColumnaNoInterior = 7,
                            MSDPColumnaM2Sup = 8,
                            MSDPColumnaUP = 9,
                            MSDPColumnaCalle = 10;

        //Modulo Ordenar Viviendas (Vista/Multifamiliar/MPntOrdenViviendas)
        public const int MOVColumnaVAgregado = 0,
                            MOVColumnaOrden = 1;

        //Módulo Datos Finales (Vista/Multifamiliar/MDatosFinales)
        public const int MDFColumnaPrototipo = 0,
                            MDFColumnaManzana = 1,
                            MDFColumnaLote = 2,
                            MDFColumnaNoOficial = 3,
                            MDFColumnaPiso = 4,
                            MDFColumnaNoInterior = 5,
                            MDFColumnaUP = 6,
                            MDFColumnaCalle = 7,
                            MDFColumnaM2Sup = 8,
                            MDFColumnaSuperfloteTipo = 9,
                            MDFColumnaM2Excedente = 10,
                            MDFColumnaM2Construccion = 11,
                            MDFViviendaVerde = 12,
                            MDFMuestra = 13,
                            MDFDisponible = 14,
                            MDFCablevision = 15;
        #endregion


        #region Unifamiliar

        //Modulo Selección del Plano (Vista/Unifamiliar/USelDatosPlano)
        public const int    USDPColumnaIDs = 0,
                            USDPColumnaManzana = 1,
                            USDPColumnaLote = 2,
                            USDPColumnaNoOficial = 3,
                            USDPColumnaNoInterior = 4,
                            USDPColumnaM2Superficie = 5,
                            USDPColumnaUP = 6,
                            USDPColumnaCalle = 7;

        //Módulo Datos Finales (Vista/Unifamiliar/UDatosFinales)
        public const int    UDFColumnaManzana = 0,
                            UDFColumnaLote = 1,
                            UDFColumnaNoOficial = 2,
                            UDFColumnaNoInterior = 3,
                            UDFColumnaUP = 4,
                            UDFColumnaDireccion = 5,
                            UDFColumnaM2Superficie = 6,
                            UDFColumnaSuperflotetipo = 7,
                            UDFColumnaM2Excedente = 8,
                            UDFColumnaM2Construccion = 9,
                            UDFColumnaBnVivVerde = 10,
                            UDFColumnaBnMuestra = 11,
                            UDFColumnaBnDisponible = 12,
                            UDFColumnaBnCablevision = 13;

        #endregion
    }
}
