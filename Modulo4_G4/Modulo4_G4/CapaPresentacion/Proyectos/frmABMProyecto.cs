using Modulo4_G4.CapaLogicaDeNegocio;
using Modulo4_G4.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modulo4_G4.CapaPresentacion.Proyectos
{
    public partial class frmABMProyecto : Form
    {
        private FormMode formMode = FormMode.nuevo;
        private Proyecto proyectoSeleccionado;
        private ProyectoService proyectoService;
        private ProductoService productoService;
        private UsuarioService usuarioService;


        public frmABMProyecto()
        {
            InitializeComponent();
            proyectoService = new ProyectoService();
            productoService = new ProductoService();
            usuarioService = new UsuarioService();
        }

        public enum FormMode
        {
            nuevo,          //Alta
            eliminar = 99,  //Baja
            modificar       //Modificacion
        }

        private void frmABMProyecto_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboProducto, productoService.ObtenerTodos(), "NombreProducto", "IdProducto");
            LlenarCombo(cboResponsable, usuarioService.ObtenerTodos(), "NombreUsuario", "IdUsuario");

            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        this.Text = "Nuevo Proyecto";
                        break;
                    }
                case FormMode.modificar:
                    {
                        this.Text = "Actualizar Proyecto";
                        MostrarDatos();
                        break;
                    }

                case FormMode.eliminar:
                    {
                        this.Text = "Eliminar Proyecto";
                        lblAceptar.Text = "Eliminar";
                        MostrarDatos();
                        DeshabilitarDatos();
                        break;
                    }
            }

        }

        public void inicializarFormulario(FormMode op, Proyecto proyectoSelected)
        {
            proyectoSeleccionado = proyectoSelected;
            formMode = op;
        }

        private void LlenarCombo(ComboBox cbo, Object source, String display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void MostrarDatos()
        {
            if(proyectoSeleccionado != null)
            {
                txtDescripcion.Text = proyectoSeleccionado.Descripcion;
                cboProducto.Text = proyectoSeleccionado.Producto.NombreProducto;
                txtAlcance.Text = proyectoSeleccionado.Alcance;
                txtVersion.Text = proyectoSeleccionado.Version;
                cboResponsable.Text = proyectoSeleccionado.Responsable.NombreUsuario;
            }
        }

        private void DeshabilitarDatos()
        {
            txtDescripcion.Enabled = false;
            cboProducto.Enabled = false;
            txtAlcance.Enabled = false;
            txtVersion.Enabled = false;
            cboResponsable.Enabled = false;
        }

        private void enviarAlerta(string msg)
        {
            MessageBox.Show(msg, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidarCampos()
        { 
            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                enviarAlerta("Debe introducir un valor de descripcion");
                txtAlcance.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtAlcance.Text))
            {
                enviarAlerta("Debe introducir un valor de alcance");
                txtAlcance.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtVersion.Text))
            {
                enviarAlerta("Debe introducir un valor de version");
                txtAlcance.Focus();
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.modificar:
                    {
                        if (ValidarCampos())
                        {
                            proyectoSeleccionado.Descripcion = txtDescripcion.Text.ToString();
                            Producto producto = new Producto();
                            producto.IdProducto = (int)cboProducto.SelectedValue;
                            proyectoSeleccionado.Producto = producto;
                            proyectoSeleccionado.Version = txtVersion.Text;
                            proyectoSeleccionado.Alcance = txtAlcance.Text;
                            Usuario usuario = new Usuario();
                            usuario.IdUsuario = (int)cboResponsable.SelectedValue;

                            if (proyectoService.ActualizarProyecto(proyectoSeleccionado))
                            {
                                MessageBox.Show("Proyecto actualizado !!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("Error al actualizar Proyecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        break;
                    }
                case FormMode.eliminar:
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desa eliminar el registro seleccionado?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(dialogResult == DialogResult.Yes)
                        {
                            if (proyectoService.EliminarProyecto(proyectoSeleccionado))
                            {
                                MessageBox.Show("Proyecto eliminado !!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("Error al intentar eliminar proyecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        break;
                    }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           DialogResult dialog = MessageBox.Show("¿Esta seguro que desea abandonar los cambios?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialog == DialogResult.Yes)
            {
                this.Close();
            }   
        }
    }
}
