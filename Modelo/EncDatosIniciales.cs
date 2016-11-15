using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginInsViviendas_UNO.Modelo
{
    public class EncDatosIniciales
    {
        private static bool estaAbierto;
        public static bool EstaAbierto
        {
            get { return EncDatosIniciales.estaAbierto; }
            set { EncDatosIniciales.estaAbierto = value; }
        }

        private static string ip;
        public static string Ip
        {
            get { return EncDatosIniciales.ip; }
            set { EncDatosIniciales.ip = value; }
        }

        private static string user;
        public static string User
        {
            get { return EncDatosIniciales.user; }
            set { EncDatosIniciales.user = value; }
        }

        private static string fraccionamiento;
        public static string Fraccionamiento
        {
            get { return EncDatosIniciales.fraccionamiento; }
            set { EncDatosIniciales.fraccionamiento = value; }
        }

        private static int indexFraccionamiento;
        public static int IndexFraccionamiento
        {
            get { return EncDatosIniciales.indexFraccionamiento; }
            set { EncDatosIniciales.indexFraccionamiento = value; }
        }

        private static int comboIndexFracc;
        public static int ComboIndexFracc
        {
            get { return EncDatosIniciales.comboIndexFracc; }
            set { EncDatosIniciales.comboIndexFracc = value; }
        }

        private static string prototipo;
        public static string Prototipo
        {
            get { return EncDatosIniciales.prototipo; }
            set { EncDatosIniciales.prototipo = value; }
        }        

        private static int comboIndexProto;
        public static int ComboIndexProto
        {
            get { return EncDatosIniciales.comboIndexProto; }
            set { EncDatosIniciales.comboIndexProto = value; }
        }

        private static string frente;
        public static string Frente
        {
            get { return EncDatosIniciales.frente; }
            set { EncDatosIniciales.frente = value; }
        }

        private static int indexFrente;
        public static int IndexFrente
        {
            get { return EncDatosIniciales.indexFrente; }
            set { EncDatosIniciales.indexFrente = value; }
        }

        private static int comboIndexFrente;
        public static int ComboIndexFrente
        {
            get { return EncDatosIniciales.comboIndexFrente; }
            set { EncDatosIniciales.comboIndexFrente = value; }
        }

        private static bool siFideicomiso;
        public static bool SiFideicomiso
        {
            get { return EncDatosIniciales.siFideicomiso; }
            set { EncDatosIniciales.siFideicomiso = value; }
        }

        private static string fideicomiso;
        public static string Fideicomiso
        {
            get { return EncDatosIniciales.fideicomiso; }
            set { EncDatosIniciales.fideicomiso = value; }
        }

        private static string conjunto;
        public static string Conjunto
        {
            get { return EncDatosIniciales.conjunto; }
            set { EncDatosIniciales.conjunto = value; }
        }

        private static int comboIndexConjunto;
        public static int ComboIndexConjunto
        {
            get { return EncDatosIniciales.comboIndexConjunto; }
            set { EncDatosIniciales.comboIndexConjunto = value; }
        }

        private static string viviendasMaximas;
        public static string ViviendasMaximas
        {
            get { return EncDatosIniciales.viviendasMaximas; }
            set { EncDatosIniciales.viviendasMaximas = value; }
        }

        private static string viviendasCargadas;
        public static string ViviendasCargadas
        {
            get { return EncDatosIniciales.viviendasCargadas; }
            set { EncDatosIniciales.viviendasCargadas = value; }
        }

        private static string viviendasPendientes;
        public static string ViviendasPendientes
        {
            get { return EncDatosIniciales.viviendasPendientes; }
            set { viviendasPendientes = value; }
        }

        //Plugin Multifamiliar Pantalla Vista\Multifamiliar\MSelPrototipos
        private static string[,] prototipoRelacional;

        public static string[,] PrototipoRelacional
        {
            get { return prototipoRelacional; }
            set { prototipoRelacional = value; }
        }

        public static bool EsMultifamiliar
        {
            get { return esMultifamiliar; }

            set { esMultifamiliar = value; }
        }

        private static bool esMultifamiliar;

    }
}
