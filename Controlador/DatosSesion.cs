using System;
using System.Net;

namespace PluginInsViviendas_UNO.Controlador
{
    public class DatosSesion
    {
       public static void AsignaUsuarioIP()
        {

            Modelo.EncDatosIniciales.User = Environment.UserName.ToUpper();
                 
            IPHostEntry host;

            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    Modelo.EncDatosIniciales.Ip = ip.ToString();
                }
            }

            Console.ReadLine();
        }
    }
}
