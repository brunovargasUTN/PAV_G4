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

        private void frmABMCliente_Load(System.Object sender, System.EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        this.Text = "Nuevo Cliente";
                        break;
                    }
                case FormMode.modificar:
                    {
                        this.Text = "Actualizar Cliente";
                        // Recuperar usuario seleccionado en la grilla 
                        MostrarDatos();
                        txtNombre.Enabled = true;
                        txtEmail.Enabled = true;
                        txtEmail.Enabled = true;
                        txtPassword.Enabled = true;
                        txtConfirmarPass.Enabled = true;
                        cboPerfil.Enabled = true;
                        break;
                    }

                case FormMode.eliminar:
                    {
                        MostrarDatos();
                        this.Text = "Eliminar Usuario";
                        txtNombre.Enabled = false;
                        txtEmail.Enabled = false;
                        txtEmail.Enabled = false;
                        txtPassword.Enabled = false;
                        cboPerfil.Enabled = false;
                        txtConfirmarPass.Enabled = false;
                        break;
                    }
            }
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
