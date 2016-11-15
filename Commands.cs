//AutocadLibs
using Autodesk.AutoCAD.Runtime;
using System.Windows.Forms;

namespace PluginInsViviendas_UNO
{
    public class Commands
    {

        [CommandMethod("CARGAV")]
        public void AbreCarga()
        {

            if (Modelo.EncDatosIniciales.EstaAbierto == true)
            {
                MessageBox.Show("El programa ya esta abierto");
            }
            else
            {
                Vista.SelDatosIniciales sdi = new Vista.SelDatosIniciales();
                //P2_SeleccionPlano.SelDatosPlano sdi = new P2_SeleccionPlano.SelDatosPlano();
                //P3_CompDatos.DatosFinales sdi = new P3_CompDatos.DatosFinales();
                //P3_CompDatos.V.BtViviendasError sdi = new P3_CompDatos.V.BtViviendasError();

                //Vista.Multifamiliar.MDatosFinales sdi = new Vista.Multifamiliar.MDatosFinales();
                sdi.Show();

                Modelo.EncDatosIniciales.EstaAbierto = true;
            }
            
        }
        
    }
}
