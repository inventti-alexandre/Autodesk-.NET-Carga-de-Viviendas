using System.Windows.Forms;

namespace PluginInsViviendas_UNO.Modelo
{
    public class EncapsulaBitacora
    {
        private static soaBulk.BulkUploadRs bulkresponse = new soaBulk.BulkUploadRs();

        private static DataGridView mDtSeleccionPlano;

        private static bool siModificaDGV = false;

        public static soaBulk.BulkUploadRs Bulkresponse
        {
            get { return bulkresponse; }
            set { bulkresponse = value; }
        }

        public static DataGridView MDtSeleccionPlano
        {
            get
            {
                return mDtSeleccionPlano;
            }

            set
            {
                mDtSeleccionPlano = value;
            }
        }

        public static bool SiModificaDGV
        {
            get
            {
                return siModificaDGV;
            }

            set
            {
                siModificaDGV = value;
            }
        }
    }
}
