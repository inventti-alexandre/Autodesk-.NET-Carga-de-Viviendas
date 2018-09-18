using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginInsViviendas_UNO.Modelo
{
    public class EncDatosServicio
    {

        //private static string wsdlFraccs = "http://192.168.44.60:10711/soa-infra/services/catalog/CatFraccionamientos/soap";

        //private static string wsdlPrototipos = "http://192.168.44.60:10711/soa-infra/services/catalog/CatPrototipos/soap";

        //private static string wsdlCargaVivs = "http://192.168.44.60:10711/soa-infra/services/default/ManageHome/soap";


        //private static string wsdlFraccsPROD = "http://192.168.44.60:10711/soa-infra/services/catalog/CatFraccionamientos/soap";
        //private static string wsdlPrototiposPROD = "http://192.168.44.60:10711/soa-infra/services/catalog/CatPrototipos/soap";
        //private static string wsdlCargaVivsPROD = "http://192.168.44.60:10711/soa-infra/services/default/ManageHome/soap";

        //private static string wsdlFraccsQA = "http://192.168.44.49:10711/soa-infra/services/catalog/CatFraccionamientos/soap";
        //private static string wsdlPrototiposQA = "http://192.168.44.49:10711/soa-infra/services/catalog/CatPrototipos/soap";
        //private static string wsdlCargaVivsQA = "http://192.168.44.49:10711/soa-infra/services/default/ManageHome/soap";

        //private static string wsdlFraccsDESA = "http://192.168.44.244:10711/soa-infra/services/catalog/CatFraccionamientos/soap";
        //private static string wsdlPrototiposDESA = "http://192.168.44.244:10711/soa-infra/services/catalog/CatPrototipos/soap";
        //private static string wsdlCargaVivsDESA = "http://192.168.44.244:10711/soa-infra/services/default/ManageHome/soap";

        /*******NUEVOS SERVIDORES LINUX MNIETO 2018-09-18*******/

        private static string wsdlFraccsPROD = "http://192.168.44.110:18001/soa-infra/services/catalog/CatFraccionamientos/soap";
        private static string wsdlPrototiposPROD = "http://192.168.44.110:18001/soa-infra/services/catalog/CatPrototipos/soap";
        private static string wsdlCargaVivsPROD = "http://192.168.44.110:18001/soa-infra/services/default/ManageHome/soap";

        private static string wsdlFraccsQA = "http://192.168.44.17:18001/soa-infra/services/catalog/CatFraccionamientos/soap";
        private static string wsdlPrototiposQA = "http://192.168.44.17:18001/soa-infra/services/catalog/CatPrototipos/soap";
        private static string wsdlCargaVivsQA = "http://192.168.44.17:18001/soa-infra/services/default/ManageHome/soap";

        private static string wsdlFraccsDESA = "http://192.168.44.23:17001/soa-infra/services/catalog/CatFraccionamientos/soap";
        private static string wsdlPrototiposDESA = "http://192.168.44.23:17001/soa-infra/services/catalog/CatPrototipos/soap";
        private static string wsdlCargaVivsDESA = "http://192.168.44.23:17001/soa-infra/services/default/ManageHome/soap";

        private static string appAmbiente = "PROD";
        private static string appAmbientePass = "J4V3RPN1";
        private static Boolean appAmbienteFirmado = false;

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
                // AZ 20180105: dependiendo del ambiente se retorna la cadena de conexión
                switch (appAmbiente) {
                    case "PROD": return wsdlFraccsPROD;
                    case "QA": return wsdlFraccsQA;
                    case "DESA": return wsdlFraccsDESA;
                    default: return wsdlFraccsPROD;
                }
                
            }

            set
            {
                // AZ 20180105: se asigna el ambiente ya que la cadena de conexion no es editable
                appAmbiente = value;
            }
        }

        public static string WsdlPrototipos
        {
            get
            {
                // AZ 20180105: dependiendo del ambiente se retorna la cadena de conexión
                switch (appAmbiente)
                {
                    case "PROD": return wsdlPrototiposPROD;
                    case "QA": return wsdlPrototiposQA;
                    case "DESA": return wsdlPrototiposDESA;
                    default: return wsdlPrototiposPROD;
                }
            }

            set
            {
                // AZ 20180105: se asigna el ambiente ya que la cadena de conexion no es editable
                appAmbiente = value;
            }
        }

        public static string WsdlCargaVivs
        {
            get
            {
                switch (appAmbiente)
                {
                    case "PROD": return wsdlCargaVivsPROD;
                    case "QA": return wsdlCargaVivsQA;
                    case "DESA": return wsdlCargaVivsDESA;
                    default: return wsdlCargaVivsPROD;
                }
            }

            set
            {
                // AZ 20180105: se asigna el ambiente ya que la cadena de conexion no es editable
                appAmbiente = value;
            }
        }

        public static string AppAmbiente
        {
            get
            {
                return appAmbiente;
            }

            set
            {
                // AZ 20180105: se asigna el ambiente ya que la cadena de conexion no es editable
                appAmbiente = value;
            }
        }

        public static string AppAmbientePass
        {
            get
            {
                return appAmbientePass;
            }

            set
            {
                appAmbientePass = value;
            }
        }

        public static Boolean AppAmbienteFirmado
        {
            get
            {
                return appAmbienteFirmado;
            }

            set
            {
                appAmbienteFirmado = value;
            }
        }
    }
}
