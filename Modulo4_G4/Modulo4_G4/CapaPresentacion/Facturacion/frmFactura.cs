using Modulo4_G4.CapaLogicaDeNegocio;
using Modulo4_G4.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modulo4_G4.CapaPresentacion.Facturacion
{
    public partial class frmFactura : Form
    {
        private Factura facturaSeleccionada;
        private Cliente clienteSeleccionado;

        private ClienteService clienteService;
        private ProyectoService proyectoService;

        private FormMode formMode;
        public frmFactura()
        {
            InitializeComponent();
            clienteService = new ClienteService();
            proyectoService = new ProyectoService();
            
        }

        public enum FormMode
        {
            nuevo,          //Alta
            consulta        //Modo solo lectura para consultar una factura desde frmConsultarHistorico
        }

        public void inicializarFormulario(FormMode op, Factura factura = null)
        {
            facturaSeleccionada = factura;
            formMode = op;
        }
        private void frmFactura_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.ToShortDateString();
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        facturaSeleccionada = new Factura();
                        clienteSeleccionado = new Cliente();
                        break;
                    }

            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {   
            //Validamos los datos ingresados de CUIT
            if (!mtbCuit.MaskCompleted)
            {
                MessageBox.Show("Debe ingresar un numero de CUIT valido","Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Buscamos el cliente por numero de CUIT
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("Cuit", mtbCuit.Text);
            clienteSeleccionado = clienteService.ConsultarClientesConFiltros(parametros)[0];

            if(clienteSeleccionado is null) {
                MessageBox.Show("Cliente no encontrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Rellenamos los datos de los Textbox del Cliente
            txtRazonSocial.Text = clienteSeleccionado.RazonSocial;
            txtDireccion.Text = String.Concat(clienteSeleccionado.Calle," - ",clienteSeleccionado.NroCalle," - ",clienteSeleccionado.Barrio);
            txtContacto.Text = String.Concat(clienteSeleccionado.Contacto.NombreContacto,", ",clienteSeleccionado.Contacto.Apellido);
            txtTelefono.Text = clienteSeleccionado.Contacto.Telefono.ToString();
            txtEmail.Text = clienteSeleccionado.Contacto.EmailContacto;

            
        }



        private void mtbCuit_ModifiedChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevaFactura_Click(object sender, EventArgs e)
        {   
            mtbCuit.Enabled = true;
            btnBuscarCliente.Enabled = true;
            limpiarCampos();
            mtbCuit.Focus();


        }

        private void limpiarCampos()
        {
            txtRazonSocial.Text = "";
            txtDireccion.Text = "";
            txtContacto.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
        }
    }
}
