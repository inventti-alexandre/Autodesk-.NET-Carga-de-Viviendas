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
    public partial class MPntOrdenaViviendas : Form
    {
        //Datagridview para Ordenar Columnas
        private const int   ColumnaValorAgreado = 0,
                            ColumnaOrden = 1,
        //Datagridview Original
                            ColumnaPolLote = 0;                           

        public MPntOrdenaViviendas()
        {
            InitializeComponent();
        }

        private void MPntOrdenaViviendas_Load(object sender, EventArgs e)
        {
            dtOrdenaViv.Columns[ColumnaValorAgreado].HeaderText = BtnRadioNI.Text;

            int i = 1;
            dtOrdenaViv.Rows.Clear();
            foreach (string Valor in Modelo.EncDatosPlano.ListOrdenNoInt)
            {
                dtOrdenaViv.Rows.Add(Valor, i);
                i += 1;
            }
        }

        private void BtnRadioNI_CheckedChanged(object sender, EventArgs e)
        {
            dtOrdenaViv.Columns[ColumnaValorAgreado].HeaderText = BtnRadioNI.Text;

            int i = 1;
            dtOrdenaViv.Rows.Clear();
            foreach (string Valor in Modelo.EncDatosPlano.ListOrdenNoInt)
            {
                dtOrdenaViv.Rows.Add(Valor, i);
                i += 1;
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Controlador.MetodosPlano.ValidaFormato(dtOrdenaViv))
            {
                Modelo.EncapsulaBitacora.MDtSeleccionPlano = Controlador.MetodosPlano.OrdenaDGV(dtOrdenaViv, BtnRadioNI.Checked);

                MessageBox.Show("Cambios en el orden enviados con éxito", "Ordenar Viviendas", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Modelo.EncapsulaBitacora.SiModificaDGV = true;

                Close();
            }
            else
            {
                MessageBox.Show("Favor de utilizar sólo números enteros en el orden", "Ordenar Viviendas", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void groupManzana_Enter(object sender, EventArgs e)
        {

        }

        private void btnRadioPiso_CheckedChanged(object sender, EventArgs e)
        {
            dtOrdenaViv.Columns[ColumnaValorAgreado].HeaderText = btnRadioPiso.Text;

            int i = 1;
            dtOrdenaViv.Rows.Clear();
            foreach (string Valor in Modelo.EncDatosPlano.ListOrdenPiso)
            {
                dtOrdenaViv.Rows.Add(Valor, i);
                i += 1;
            }
        }
    }
}
