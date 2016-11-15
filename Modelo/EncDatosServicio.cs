using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginInsViviendas_UNO.Modelo
{
    public class EncDatosServicio
    {

        private static string wsdlFraccs = "http://192.168.44.60:10711/soa-infra/services/catalog/CatFraccionamientos/soap";

        private static string wsdlPrototipos = "http://192.168.44.60:10711/soa-infra/services/catalog/CatPrototipos/soap";

        private static string wsdlCargaVivs = "http://192.168.44.60:10711/soa-infra/services/default/ManageHome/soap";

        private static soaFracc.FraccionamientoType[] fraccsRecibidos;
        public static soaFracc.FraccionamientoType[] FraccsRecibidos
        {
            get { return EncDatosServicio.fraccsRecibidos; }
            set { EncDatosServicio.fraccsRecibidos = value; }
        }

        private static soaPrototipos.PrototipoType[] protosRecibidos;
        public static soaPrototipos.PrototipoType[] ProtosRecibidos
        {
            get { return EncDatosServicio.protosRecibidos; }
            set { EncDatosServicio.protosRecibidos = value; }
        }

        #region ModeloElementosSeleccionados
        private static List<String> listaFraccNombres = new List<String>();
        public static List<String> ListaFraccNombres
        {
            get { return EncDatosServicio.listaFraccNombres; }
            set { EncDatosServicio.listaFraccNombres = value; }
        }

        private static List<int> listaFraccIndex = new List<int>();
        public static List<int> ListaFraccIndex
        {
            get { return EncDatosServicio.listaFraccIndex; }
            set { EncDatosServicio.listaFraccIndex = value; }
        }

        private static List<String> listaFrentesNombres = new List<String>();
        public static List<String> ListaFrentesNombres
        {
            get { return EncDatosServicio.listaFrentesNombres; }
            set { EncDatosServicio.listaFrentesNombres = value; }
        }

        private static List<int> listaFrentesIndex = new List<int>();
        public static List<int> ListaFrentesIndex
        {
            get { return EncDatosServicio.listaFrentesIndex; }
            set { EncDatosServicio.listaFrentesIndex = value; }
        }

        private static List<string> listaConjuntosNombres = new List<string>();
        public static List<string> ListaConjuntosNombres
        {
            get { return EncDatosServicio.listaConjuntosNombres; }
            set { EncDatosServicio.listaConjuntosNombres = value; }
        }

        private static List<int> listaConjuntosIndex = new List<int>();
        public static List<int> ListaConjuntosIndex
        {
            get { return EncDatosServicio.listaConjuntosIndex; }
            set { EncDatosServicio.listaConjuntosIndex = value; }
        }
        #endregion        

        public static string WsdlFraccs
        {
            get
            {
                return wsdlFraccs;
            }

            set
            {
                wsdlFraccs = value;
            }
        }

        public static string WsdlPrototipos
        {
            get
            {
                return wsdlPrototipos;
            }

            set
            {
                wsdlPrototipos = value;
            }
        }

        public static string WsdlCargaVivs
        {
            get
            {
                return wsdlCargaVivs;
            }

            set
            {
                wsdlCargaVivs = value;
            }
        }


    }
}
