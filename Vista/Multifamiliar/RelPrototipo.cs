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
    public partial class RelPrototipo : Form
    {
        public RelPrototipo()
        {
            InitializeComponent();
        }

        private void RelPrototipo_Load(object sender, EventArgs e)
        {

            ////Obtengo el máximo de renglones y columnas insertados
            int MaxRenglones = Modelo.EncDatosIniciales.PrototipoRelacional.GetLength(0);
            int MaxCol = Modelo.EncDatosIniciales.PrototipoRelacional.GetLength(1);

            //for (int i = 0; i < MaxRenglones; i++)
            //{
            //    //Inserto Nuevo Renglon
            //    dtRelacionProto.Rows.Add();

            //    for (int j = 0; j < MaxCol; j++)
            //    {

            //    }

            //}

        }
    }
}
