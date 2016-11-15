using System;
using System.Collections.Generic;

namespace PluginInsViviendas_UNO.Modelo
{
    public class EncDatosPlano
    {
        private static List<double> m2SuperFloteTipo = new List<double>();

        private static List<int> listaOrdenValor = new List<int>();

        private static List<string> listOrdenNoInt = new List<string>();

        private static List<string> listOrdenPiso = new List<string>();

        private static List<string> listOrdenPl = new List<string>();

        private static string[,] vivsSeleccionPlano;

        private static string[,] vivsFinales;

        private static int decimales = new int();

        private static string[,] noOficialSel;

        public static List<double> M2SuperFloteTipo
        {
            get { return EncDatosPlano.m2SuperFloteTipo; }
            set { EncDatosPlano.m2SuperFloteTipo = value; }
        }

        public static List<string> ListOrdenNoInt
        {
            get
            {
                return listOrdenNoInt;
            }

            set
            {
                listOrdenNoInt = value;
            }
        }

        public static List<string> ListOrdenPiso
        {
            get
            {
                return listOrdenPiso;
            }

            set
            {
                listOrdenPiso = value;
            }
        }

        public static List<string> ListOrdenPl
        {
            get
            {
                return listOrdenPl;
            }

            set
            {
                listOrdenPl = value;
            }
        }

        public static List<int> ListaOrdenValor
        {
            get
            {
                return listaOrdenValor;
            }

            set
            {
                listaOrdenValor = value;
            }
        }

        public static string[,] VivsSeleccionPlano
        {
            get
            {
                return vivsSeleccionPlano;
            }

            set
            {
                vivsSeleccionPlano = value;
            }
        }

        public static string[,] VivsFinales
        {
            get
            {
                return vivsFinales;
            }

            set
            {
                vivsFinales = value;
            }
        }

        public static int Decimales
        {
            get
            {
                return decimales;
            }

            set
            {
                decimales = value;
            }
        }

        public static string[,] NoOficialSel
        {
            get
            {
                return noOficialSel;
            }

            set
            {
                noOficialSel = value;
            }
        }



    }
}
