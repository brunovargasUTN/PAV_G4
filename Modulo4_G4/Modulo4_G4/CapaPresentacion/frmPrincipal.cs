using Modulo4_G4.CapaPresentacion.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modulo4_G4
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void proyectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProyectos frm = new frmProyectos();
            frm.ShowDialog();
        }
    }
}
