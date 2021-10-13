using Modulo4_G4.CapaLogicaDeNegocio;
using Modulo4_G4.CapaPresentacion.Clientes;
using Modulo4_G4.CapaPresentacion.Facturacion;
using Modulo4_G4.CapaPresentacion.Login;
using Modulo4_G4.CapaPresentacion.Proyectos;
using Modulo4_G4.CapaPresentacion.Reportes;
using Modulo4_G4.Entidades;
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
        private Usuario usuariologueado;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void proyectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProyectos frm = new frmProyectos();
            frm.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            frm.ShowDialog();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.ShowDialog();
            usuariologueado = login.UsuarioLogueado;
            lblUsuarioLogueado.Text = "Usuario logueado: " + usuariologueado;
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rpta;
            rpta = MessageBox.Show("Seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rpta == DialogResult.No)
                e.Cancel = true;
            else
                Environment.Exit(0);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrincipal_FormClosing(null, null);
        }

        private void listadoDeProyectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteProyectos frmReporte = new frmReporteProyectos();
            //frmReporte.inicializarReporte("tableProyectos", @".\CapaPresentacion\Reportes\rptProyectos.rdlc", new ProyectoService().MostrarReporteProyectos());
            frmReporte.ShowDialog();
        }

        private void top10DistribucionDeProyectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteProyectos frmReporte = new frmReporteProyectos();
            //frmReporte.inicializarReporte("DataSet1", @".\CapaPresentacion\Reportes\rptCantidadProyectos.rdlc", new ProyectoService().MostrarReporteProyectosXProductos());
            frmReporte.ShowDialog();
        }

        private void registrarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFactura factura = new frmFactura(usuariologueado);
            factura.inicializarFormulario(frmFactura.FormMode.nuevo);
            factura.ShowDialog();
        }

        private void contactosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContactos frm = new frmContactos();
            frm.ShowDialog();
        }
    }
}
