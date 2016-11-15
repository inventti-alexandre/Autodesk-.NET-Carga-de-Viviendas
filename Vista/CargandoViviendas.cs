using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PluginInsViviendas_UNO.Vista.Vista
{
    public partial class CargandoViviendas : Form
    {
        public CargandoViviendas()
        {
            InitializeComponent();
            int Ancho = ((Screen.FromControl(this).Bounds.Width / 2) - 117);
            int Alto = ((Screen.FromControl(this).Bounds.Height / 2) - 65);

            this.Location = new Point(Ancho, Alto);
            this.TopMost = true;
            this.BringToFront();
        }

        private void CargandoViviendas_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void CargandoViviendas_Load(object sender, EventArgs e)
        {
            
        }
    }
}
