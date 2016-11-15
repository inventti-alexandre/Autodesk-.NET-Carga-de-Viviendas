using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PluginInsViviendas_UNO.Vista.Unifamiliar
{
    public partial class UBitacoraErrores : Form
    {
        public UBitacoraErrores()
        {
            InitializeComponent();
        }

        private void BitacoraErrores_Load(object sender, EventArgs e)
        {

            List<string> MsjGlobal = Modelo.EncDatosConfiguracion.MsjGlobal;

            foreach (string st in MsjGlobal)
            {
                this.listBitacora.Items.Add(st);
            }
        }

        private void cmbCapas_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selec;

            selec = cmbCapas.SelectedItem.ToString();

            switch (selec)
            {
                case "Manzana":
                    txtNomCapa.Enabled = false;
                    btnAsignaF.Visible = false;
                    this.txtNomCapa.Text = Modelo.EncDatosConfiguracion.LayerManzana1;
                    break;
                case "Direcciones":
                    txtNomCapa.Enabled = false;
                    btnAsignaF.Visible = false;
                    this.txtNomCapa.Text = Modelo.EncDatosConfiguracion.LayerDireccion1;
                    break;
                case "Viviendas":
                    txtNomCapa.Enabled = false;
                    btnAsignaF.Visible = false;
                    this.txtNomCapa.Text = Modelo.EncDatosConfiguracion.LayerViviendas1;
                    break;
                case "Lote":
                    txtNomCapa.Enabled = false;
                    btnAsignaF.Visible = false;
                    this.txtNomCapa.Text = Modelo.EncDatosConfiguracion.LayerLote1;
                    break;
                case "Número Interior":
                    txtNomCapa.Enabled = false;
                    btnAsignaF.Visible = false;
                    this.txtNomCapa.Text = Modelo.EncDatosConfiguracion.LayerNoInterior1;
                    break;
                case "Número Oficial":
                    txtNomCapa.Enabled = false;
                    btnAsignaF.Visible = false;
                    this.txtNomCapa.Text = Modelo.EncDatosConfiguracion.LayerNoOficial1;
                    break;
                case "Unidad Privativa":
                    txtNomCapa.Enabled = false;
                    btnAsignaF.Visible = false;
                    this.txtNomCapa.Text = Modelo.EncDatosConfiguracion.LayerUPrivativa1;
                    break;
                case "Factor de Detección":
                    this.txtNomCapa.Text = Modelo.EncDatosConfiguracion.FactorEscala1.ToString();
                    txtNomCapa.Enabled = true;
                    btnAsignaF.Visible = true;
                    break;

            }
        }


        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBitacora.SelectedItem != null)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (object row in listBitacora.SelectedItems)
                    {
                        sb.Append(row.ToString());
                        sb.AppendLine();
                    }
                    sb.Remove(sb.Length - 1, 1);
                    Clipboard.SetData(System.Windows.Forms.DataFormats.Text, sb.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            listBitacora.Items.Clear();
            Modelo.EncDatosConfiguracion.MsjGlobal = new List<string>();
        }


        private void btnAsignaF_Click(object sender, EventArgs e)
        {
            string stcmbcapas = cmbCapas.SelectedItem.ToString();
            double Factor = new double();
            if (stcmbcapas == "Factor de Detección")
            {
                if (Double.TryParse(txtNomCapa.Text, out Factor))
                {
                    if (Factor >= 1 && Factor <= 3)
                    {
                        Modelo.EncDatosConfiguracion.FactorEscala1 = Factor;
                    }
                    else
                        MessageBox.Show("El Factor debe de estar entre 1 y 3");
                }
                else
                    MessageBox.Show("Debe de ser númerico y no estar vacío");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
