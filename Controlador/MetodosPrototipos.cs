using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Autodesk.AutoCAD.DatabaseServices;

namespace PluginInsViviendas_UNO.Controlador
{
    public class MetodosPrototipos
    {
        public static void MueveItemsListBox(ListBox Proviene, ListBox destino)
        {
            ListBox.SelectedObjectCollection itemsElegidos = Proviene.SelectedItems;
            foreach (var item in itemsElegidos)
            {
                destino.Items.Add(item);
            }
            while (Proviene.SelectedItems.Count > 0)
            {
                Proviene.Items.Remove(Proviene.SelectedItems[0]);
            }
        }

        public static List<string> ObtengoTodasLayers(Database db)
        {
            List<string> lstlay = new List<string>();

            LayerTableRecord layer = new LayerTableRecord();
            //Entity layer;
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                foreach (ObjectId layerId in lt)
                {
                    layer = tr.GetObject(layerId, OpenMode.ForRead) as LayerTableRecord;
                    lstlay.Add(layer.Name);
                }

            }
            return lstlay;
        }

        public static void FiltroPrototipos(soaPrototipos.PrototipoType[] Prototipos, ListBox ListaPrototipos, 
                                                int Index, string PalabraBusqueda, List<string> ListaProtosSeleccionados)
        {
            ListaPrototipos.Items.Clear();

            for (int i = 0; i < Modelo.EncDatosServicio.ProtosRecibidos.Count(); i++)
            {
                string ProtoActual = Modelo.EncDatosServicio.ProtosRecibidos[i].Name;
                switch (Index)
                {
                    case 0: /*-----------------CONTIENE-----------------------------*/
                        //Reviso que contenga la palabra escrita
                        if((ProtoActual.ToUpper()).Contains(PalabraBusqueda.ToUpper()))
                        {
                            //Reviso que no este dentro de la lista de seleccionados
                            if(ListaProtosSeleccionados.IndexOf(ProtoActual) == -1)
                            {
                                ListaPrototipos.Items.Add(ProtoActual);
                            }
                            
                        };
                        break;
                    case 1:
                        if ((ProtoActual.ToUpper()).StartsWith(PalabraBusqueda.ToUpper()))
                        {
                            if (ListaProtosSeleccionados.IndexOf(ProtoActual) == -1)
                            {
                                ListaPrototipos.Items.Add(ProtoActual);
                            }
                        };
                        break;
                }
            }

           // return ListaPrototipos;
        }

    }
}
