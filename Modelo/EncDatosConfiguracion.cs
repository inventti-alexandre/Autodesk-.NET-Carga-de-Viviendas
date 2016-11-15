using System.Collections.Generic;

namespace PluginInsViviendas_UNO.Modelo
{
    public class EncDatosConfiguracion
    {
        private static string layerManzana = "SMB_NUM_MANZANA";

        public static string LayerManzana
        {
            get { return layerManzana; }
            set { layerManzana = value; }
        }


        private static string layerDireccion = "SMB_DIRECCION";

        public static string LayerDireccion
        {
            get { return layerDireccion; }
            set { layerDireccion = value; }
        }
        private static string layerViviendas = "SMB_LOTES";

        public static string LayerViviendas
        {
            get { return layerViviendas; }
            set { layerViviendas = value; }
        }

        private static string layerLote = "SMB_NUM_LOTE";

        public static string LayerLote
        {
            get { return layerLote; }
            set { layerLote = value; }
        }
        private static string layerNoInterior = "SMB_NUM_INT_PB";

        public static string LayerNoInterior
        {
            get { return layerNoInterior; }
            set { layerNoInterior = value; }
        }
        private static string layerUPrivativa = "SMB_UP";

        public static string LayerUPrivativa
        {
            get { return layerUPrivativa; }
            set { layerUPrivativa = value; }
        }
        private static string layerNoOficial = "SMB_NUM_EXT";

        public static string LayerNoOficial
        {
            get { return layerNoOficial; }
            set { layerNoOficial = value; }
        }

        private static string layerVivContiene = "SMB_CONSTRUCCIONES";

        public static string LayerVivContiene
        {
            get { return layerVivContiene; }
            set { layerVivContiene = value; }
        }

        private static string layerNumIntContiene = "SMB_NUM_INT_";

        public static string LayerNumIntContiene
        {
            get { return layerNumIntContiene; }
            set { layerNumIntContiene = value; }
        }    

        private static double factorEscala = 1.5;

        public static double FactorEscala
        {
            get { return factorEscala; }
            set { factorEscala = value; }
        }

        private static List<string> msjGlobal = new List<string>();

        public static List<string> MsjGlobal
        {
            get { return msjGlobal; }
            set { msjGlobal = value; }
        }

        private static bool conDatos;
        public static bool ConDatos
        {
            get { return conDatos; }
            set { conDatos = value; }
        }

        private static bool cierreAuto = false;
        public static bool CierreAuto
        {
            get { return cierreAuto; }
            set { cierreAuto = value; }
        }
    }
}
