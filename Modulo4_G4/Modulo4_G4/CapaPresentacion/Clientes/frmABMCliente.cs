using Modulo4_G4.CapaLogicaDeNegocio;
using Modulo4_G4.CapaPresentacion.Barrios;
using Modulo4_G4.CapaPresentacion.Contactos;
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
        private BarrioService oBarrioService;
        private ContactoService oContactoService;
        private Cliente oClienteSelected;

        public frmABMCliente()
        {
            InitializeComponent();
            oClienteService = new ClienteService();
            oBarrioService = new BarrioService();
            oContactoService = new ContactoService();
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

        private void LlenarCombo(ComboBox cbo, Object source, String display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }
        private void frmABMCliente_Load(System.Object sender, System.EventArgs e)
        {
            LlenarCombo(cboBarrio, oBarrioService.ObtenerTodos(), "NombreBarrio", "IdBarrio");
            LlenarCombo(cboContacto, oContactoService.ObtenerTodos(), "NombreCompleto", "IdContacto");


            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        this.Text = "Nuevo Cliente";
                        btnAgregarBarrio.Enabled = true;
                        btnAgregarContacto.Enabled = true;
                        mtbFecha.Text = DateTime.Today.ToShortDateString();
                        break;
                    }
                case FormMode.modificar:
                    {
                        this.Text = "Actualizar Cliente";
                        btnAgregarBarrio.Enabled = true;
                        btnAgregarContacto.Enabled = true;
                        // Recuperar usuario seleccionado en la grilla
                        MostrarDatos();
                        mtbCuit.Enabled = true;
                        txtRazon.Enabled = true;
                        txtCalle.Enabled = true;
                        txtNro.Enabled = true;
                        mtbFecha.Enabled = true;
                        cboBarrio.Enabled = true;
                        cboContacto.Enabled = true;
                        break;
                    }

                case FormMode.eliminar:
                    {
                        this.Text = "Eliminar Usuario";
                        MostrarDatos();
                        mtbCuit.Enabled = false;
                        txtRazon.Enabled = false;
                        txtCalle.Enabled = false;
                        txtNro.Enabled = false;
                        mtbFecha.Enabled = false;
                        cboBarrio.Enabled = false;
                        cboContacto.Enabled = false;
                        break;
                    }
            }

        }

        private void MostrarDatos()
        {
            if (oClienteSelected != null)
            {
                mtbCuit.Text = oClienteSelected.Cuit.ToString();
                txtRazon.Text = oClienteSelected.RazonSocial;
                txtCalle.Text = oClienteSelected.Calle;
                txtNro.Text = oClienteSelected.NroCalle.ToString();
                mtbFecha.Text = oClienteSelected.FechaAlta.ToString();
                cboBarrio.Text = oClienteSelected.Barrio.NombreBarrio;
                cboContacto.Text = oClienteSelected.Contacto.NombreContacto;
            }
        }

        private bool ValidarCampos()
        {
            if (String.IsNullOrEmpty(mtbCuit.Text) || !mtbCuit.MaskCompleted)
            {
                MessageBox.Show("Debe introducir un CUIT valido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(txtRazon.Text))
            {
                MessageBox.Show("Debe introducir un nombre de Razon Social", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(txtCalle.Text))
            {
                MessageBox.Show("Debe introducir un nombre de Calle", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(txtNro.Text))
            {
                MessageBox.Show("Debe introducir un numero de domicilio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (String.IsNullOrEmpty(mtbFecha.Text) || !mtbFecha.MaskCompleted)
            {
                MessageBox.Show("Debe introducir una fecha de alta valida", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(cboBarrio.Text.ToString()))
            {
                MessageBox.Show("Debe seleccionar un Barrio", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(cboContacto.Text.ToString()))
            {
                MessageBox.Show("Debe seleccionar un Contacto", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


            return true;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        if (ValidarCampos())
                        {
                            var oCliente = new Cliente();
                            oCliente.Cuit = mtbCuit.Text;
                            oCliente.RazonSocial = txtRazon.Text;
                            oCliente.Calle = txtCalle.Text;
                            oCliente.NroCalle = Int32.Parse(txtNro.Text);
                            oCliente.FechaAlta = DateTime.Parse(mtbFecha.Text);
                            Barrio barrio = new Barrio();
                            barrio.IdBarrio = (int)cboBarrio.SelectedValue;
                            oCliente.Barrio = barrio;
                            Contacto contacto = new Contacto();
                            contacto.IdContacto = (int)cboContacto.SelectedValue;
                            oCliente.Contacto = contacto;

                            if (oClienteService.NuevoCliente(oCliente))
                            {
                                MessageBox.Show("Cliente insertado exitosamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }

                            else
                            {
                                MessageBox.Show("Se produjo un error al intentar insertar el Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        break;
                    }

                case FormMode.modificar:
                    {
                        if (ValidarCampos())
                        {
                            oClienteSelected.Cuit = mtbCuit.Text;
                            oClienteSelected.RazonSocial = txtRazon.Text;
                            oClienteSelected.Calle = txtCalle.Text;
                            oClienteSelected.NroCalle = Int32.Parse(txtNro.Text);
                            oClienteSelected.FechaAlta = DateTime.Parse(mtbFecha.Text);
                            Barrio barrio = new Barrio();
                            barrio.IdBarrio = (int)cboBarrio.SelectedValue;
                            oClienteSelected.Barrio = barrio;
                            Contacto contacto = new Contacto();
                            contacto.IdContacto = (int)cboContacto.SelectedValue;
                            oClienteSelected.Contacto = contacto;

                            if (oClienteService.ActualizarCliente(oClienteSelected))
                            {
                                MessageBox.Show("Cliente actualizado !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar el Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }

                case FormMode.eliminar:
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desa eliminar el registro seleccionado?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (oClienteService.EliminarCliente(oClienteSelected))
                            {
                                MessageBox.Show("Cliente eliminado !!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("Error al intentar eliminar el Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            {
                this.Close();
            }
        }

        private void btnAgregarBarrio_Click(object sender, EventArgs e)
        {
            frmBarrios barrios = new frmBarrios();
            barrios.ShowDialog();
            LlenarCombo(cboBarrio, oBarrioService.ObtenerTodos(), "NombreBarrio", "IdBarrio");

        }

        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            frmABMContacto aBMContacto = new frmABMContacto();
            aBMContacto.InicializarFormulario(frmABMContacto.FormMode.nuevo);
            aBMContacto.ShowDialog();
            LlenarCombo(cboContacto, oContactoService.ObtenerTodos(), "NombreContacto", "IdContacto");
        }
    }
}








