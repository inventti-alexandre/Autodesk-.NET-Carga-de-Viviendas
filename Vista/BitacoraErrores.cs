using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PluginInsViviendas_UNO.Vista
{
    public partial class BitacoraErrores : Form
    {
        public BitacoraErrores()
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
            String selec = "";

            selec = cmbCapas.SelectedItem.ToString();

            switch (selec)
            {
                case "Manzana":
                    txtNomCapa.Enabled = false;
                    btnAsignaF.Visible = false;
                    this.txtNomCapa.Text = Modelo.EncDatosConfiguracion.LayerManzana;
                    break;
                case "Direcciones":
                    txtNomCapa.Enabled = false;
                    btnAsignaF.Visible = false;
                    this.txtNomCapa.Text = Modelo.EncDatosConfiguracion.LayerDireccion;
                    break;
                case "Viviendas":
                    txtNomCapa.Enabled = false;
                    btnAsignaF.Visible = false;
                    this.txtNomCapa.Text = Modelo.EncDatosConfiguracion.LayerViviendas;
                    break;
                case "Lote":
                    txtNomCapa.Enabled = false;
                    btnAsignaF.Visible = false;
                    this.txtNomCapa.Text = Modelo.EncDatosConfiguracion.LayerLote;
                    break;
                case "Número Interior":
                    txtNomCapa.Enabled = false;
                    btnAsignaF.Visible = false;
                    this.txtNomCapa.Text = Modelo.EncDatosConfiguracion.LayerNoInterior;
                    break;
                case "Número Oficial":
                    txtNomCapa.Enabled = false;
                    btnAsignaF.Visible = false;
                    this.txtNomCapa.Text = Modelo.EncDatosConfiguracion.LayerNoOficial;
                    break;
                case "Unidad Privativa":
                    txtNomCapa.Enabled = false;
                    btnAsignaF.Visible = false;
                    this.txtNomCapa.Text = Modelo.EncDatosConfiguracion.LayerUPrivativa;
                    break;
                case "Factor de Detección":
                    this.txtNomCapa.Text = Modelo.EncDatosConfiguracion.FactorEscala.ToString();
                    txtNomCapa.Enabled = true;
                    btnAsignaF.Visible = true;
                    break;

            }
        }


        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Copiar línea seleccionada?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
                        Clipboard.SetData(DataFormats.Text, sb.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Limpiar Datos de Bitacora?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                listBitacora.Items.Clear();
                Modelo.EncDatosConfiguracion.MsjGlobal = new List<string>();
            }
        }


        private void btnAsignaF_Click(object sender, EventArgs e)
        {
            string stcmbcapas = cmbCapas.SelectedItem.ToString();
            double Factor = new double();
            if (stcmbcapas == "Factor de Detección")
            {
                if (double.TryParse(txtNomCapa.Text, out Factor))
                {
                    if (Factor >= 1 && Factor <= 3)
                    {
                        Modelo.EncDatosConfiguracion.FactorEscala = Factor;
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
