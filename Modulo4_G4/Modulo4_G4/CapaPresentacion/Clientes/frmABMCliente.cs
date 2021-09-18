using Modulo4_G4.CapaLogicaDeNegocio;
using Modulo4_G4.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modulo4_G4.CapaPresentacion.Clientes
{
    public partial class frmABMCliente : Form
    {

        private FormMode formMode = FormMode.nuevo;
        private ClienteService oClienteService;
        private Cliente oClienteSelected;
        public frmABMCliente()
        {
            InitializeComponent();
            oClienteService = new ClienteService();
        }

        public enum FormMode
        {
            nuevo,          // Alta
            eliminar,       // Baja
            modificar       //Modificación
        }

        public void InicializarFormulario(FormMode op, Cliente clienteSelected)
        {
            formMode = op;
            oClienteSelected = clienteSelected;
        }


        private void MostrarDatos()
        {
            if (oClienteSelected != null)
            {
               /* txtNombre.Text = oUsuarioSelected.NombreUsuario;
                txtEmail.Text = oUsuarioSelected.Email;
                txtPassword.Text = oUsuarioSelected.Password;
                txtConfirmarPass.Text = txtPassword.Text;
                cboPerfil.Text = oUsuarioSelected.Perfil.Nombre; */
            }
        }
    }
}
