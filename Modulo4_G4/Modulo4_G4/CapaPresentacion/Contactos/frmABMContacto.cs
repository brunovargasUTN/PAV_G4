using Modulo4_G4.CapaLogicaDeNegocio;
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

namespace Modulo4_G4.CapaPresentacion.Contactos
{
    public partial class frmABMContacto : Form
    {
        private FormMode formMode = FormMode.nuevo;
        private Contacto oContactoSelected;
        private readonly ContactoService oContactoService;

        public frmABMContacto()
        {
            InitializeComponent();
            oContactoService = new ContactoService();
        }

        public enum FormMode
        {
            nuevo,          //Alta
            eliminar = 99,  //Baja
            modificar       //Modificacion
        }

        private void frmABMContacto_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        this.Text = "Nuevo Contacto";
                        lblAceptar.Text = "Agregar";
                        break;
                    }
                case FormMode.modificar:
                    {
                        this.Text = "Actualizar Contacto";
                        lblAceptar.Text = "Actualizar";
                        MostrarDatos();
                        txtNombre.Enabled = true;
                        txtApellido.Enabled = true;
                        txtEmail.Enabled = true;
                        txtTelefono.Enabled = true;
                        break;
                    }
                case FormMode.eliminar:
                    {
                        MostrarDatos();
                        this.Text = "Eliminar Contacto";
                        lblAceptar.Text = "Eliminar";                    
                        txtNombre.Enabled = false;
                        txtApellido.Enabled = false;
                        txtEmail.Enabled = false;
                        txtTelefono.Enabled = false;
                        break;
                    }
            }

        }

        public void InicializarFormulario(FormMode op, Contacto contactoSelected = null)
        {
            formMode = op;
            if (contactoSelected != null)
            {
                oContactoSelected = contactoSelected;
            }
        }

        private void MostrarDatos()
        {
            if (oContactoSelected != null)
            {
                txtNombre.Text = oContactoSelected.NombreContacto;
                txtApellido.Text = oContactoSelected.Apellido;
                txtEmail.Text = oContactoSelected.EmailContacto;
                txtTelefono.Text = oContactoSelected.Telefono;
            }
        }

        private void enviarAlerta(string msg)
        {
            MessageBox.Show(msg, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                enviarAlerta("Debe introducir un Nombre de Contacto");
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                enviarAlerta("Debe introducir un Apellido");
                txtApellido.Focus();
                return false;
            }


            return true;
        }

        private void btnAceptar_Click(System.Object sender, System.EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        if (ValidarCampos())
                        {
                            var oContacto = new Contacto();
                            oContacto.NombreContacto = txtNombre.Text;
                            oContacto.Apellido = txtApellido.Text;
                            oContacto.EmailContacto = txtEmail.Text;
                            oContacto.Telefono = txtTelefono.Text;

                            if (oContactoService.NuevoContacto(oContacto))
                            {
                                MessageBox.Show("Contacto insertado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Se produjo un error al insertar el contacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        //this.Close();
                        break;
                    }
                case FormMode.modificar:
                    {
                        if (ValidarCampos())
                        {
                            oContactoSelected.NombreContacto = txtNombre.Text;
                            oContactoSelected.Apellido = txtApellido.Text;
                            oContactoSelected.EmailContacto = txtEmail.Text;
                            oContactoSelected.Telefono = txtTelefono.Text;

                            if (oContactoService.ActualizarContacto(oContactoSelected))
                            {
                                MessageBox.Show("Contacto actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar el contacto!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }
                case FormMode.eliminar:
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desa eliminar el registro seleccionado?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (oContactoService.EliminarContacto(oContactoSelected))
                            {
                                MessageBox.Show("Contacto eliminado !!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Error al intentar eliminar proyecto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        break;
                    }               
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Esta seguro que desea abandonar los cambios?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
                this.Close();
        }
    }
}

