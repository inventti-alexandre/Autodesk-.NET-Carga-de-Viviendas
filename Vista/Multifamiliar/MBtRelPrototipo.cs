using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PluginInsViviendas_UNO.Vista.Multifamiliar
{
    public partial class MBtRelPrototipo : Form
    {
        public MBtRelPrototipo()
        {
            InitializeComponent();
        }

        private void RelPrototipo_Load(object sender, EventArgs e)
        {            

            ////Obtengo el máximo de renglones y columnas insertados
            int MaxRenglones = Modelo.EncDatosIniciales.PrototipoRelacional.GetLength(0);
            int MaxCol = Modelo.EncDatosIniciales.PrototipoRelacional.GetLength(1);

            //Elimino registros
            dtRelacionProto.Rows.Clear();

            for (int i = 0; i < MaxRenglones; i++)
            {
                //Inserto Nuevo Renglon
                dtRelacionProto.Rows.Add();

                for (int j = 0; j < MaxCol; j++)
                {
                    dtRelacionProto.Rows[i].Cells[j].Value = Modelo.EncDatosIniciales.PrototipoRelacional[i, j];
                }

            }

        }
    }
}
