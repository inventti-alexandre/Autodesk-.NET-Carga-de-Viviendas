using Autodesk.AutoCAD.DatabaseServices;
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
    public partial class MSeleccionPlano : Form
    {

        private string LayerManzana = Modelo.EncDatosConfiguracion.LayerManzana1;
        private string LayerDireccion = Modelo.EncDatosConfiguracion.LayerDireccion1;
        private string LayerViviendas = Modelo.EncDatosConfiguracion.LayerViviendas1;
        private string LayerLote = Modelo.EncDatosConfiguracion.LayerLote1;
        private string LayerNoInterior = Modelo.EncDatosConfiguracion.LayerNoInterior1;
        private string LayerUPrivativa = Modelo.EncDatosConfiguracion.LayerUPrivativa1;
        private string LayerNoOficial = Modelo.EncDatosConfiguracion.LayerNoOficial1;
        public string ManzanaActual = "", Direccion = "";

        public MSeleccionPlano()
        {
            InitializeComponent();
        }

        private void btnSelManzana_Click(object sender, EventArgs e)
        {
            ObjectId idManzana = new ObjectId();
            DBText TextManzana = new DBText();

            this.WindowState = FormWindowState.Minimized;

            //Se solicita la entidad solamente de tipo DB Text
            if (Controlador.MetodosPlano.SeleccionaEntidadTipo("\n Seleccione la Manzana", out idManzana, typeof(DBText)))
            {
                //Abrimos la entidad DBText
                TextManzana = Controlador.MetodosPlano.AbrirEntidad(idManzana) as DBText;

                //Validamos que el layer en el que se encuentra el DBText sea el correcto
                if (TextManzana.Layer.ToUpper() == LayerManzana.Replace(" ", string.Empty))
                {
                    ManzanaActual = TextManzana.TextString;
                    setManActual.Text = TextManzana.TextString;
                    lblSelManzana.ForeColor = Color.Black;
                    btnCambiaManzana.Visible = true;
                    btnSelManzana.Enabled = false;
                    btnSelDireccion.Enabled = true;
                    btnCambiaDireccion.Enabled = true;
                }
                else
                {
                    Autodesk.AutoCAD.ApplicationServices.Core.Application.ShowAlertDialog("La selección no pertenece a la capa: " + LayerManzana);
                }

            }

            this.WindowState = FormWindowState.Normal;
        }

        private void MSeleccionPlano_Load(object sender, EventArgs e)
        {

        }
    }
}
