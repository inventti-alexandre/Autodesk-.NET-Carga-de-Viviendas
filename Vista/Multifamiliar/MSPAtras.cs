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
    public partial class MSPAtras : Form
    {
        public MSPAtras()
        {
            InitializeComponent();
        }

        private void btnIrAtras_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea ir al Módulo Selección de Prototipos?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MSelPrototipos msp = new MSelPrototipos();

                GoBack(msp);

                Owner.Dispose();
            }
        }


        private void GoBack(Form form)
        {
            form.Show();
            Modelo.EncDatosConfiguracion.CierreAuto = true;            
        }

        private void btnIrHome_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea ir al Módulo Selección de Datos Iniciales?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SelDatosIniciales sdi = new SelDatosIniciales();
                GoBack(sdi);
                Modelo.EncDatosConfiguracion.CierreAuto = true;               
                Owner.Dispose();
            }
        }

        private void MSPAtras_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.None:
                    if (!Modelo.EncDatosConfiguracion.CierreAuto)
                    {
                        Modelo.EncDatosIniciales.EstaAbierto = false;
                        Controlador.MetodosFinales.LimpiaTodoEncapsulado(true, true, true);
                    }                    
                    break;
            }
        }
    }
}
