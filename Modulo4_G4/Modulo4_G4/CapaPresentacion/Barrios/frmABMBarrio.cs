using Modulo4_G4.CapaLogicaDeNegocio;
using Modulo4_G4.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modulo4_G4.CapaPresentacion.Barrios
{
    public partial class frmABMBarrio : Form
    {
        private Barrio oBarrioSelected;
        private BarrioService oBarrioService;

        public frmABMBarrio()
        {
            InitializeComponent();
            oBarrioService = new BarrioService();
        }

        public void InicializarFormulario(Barrio barrioSelected)
        {
            oBarrioSelected = barrioSelected;
            txtNombre.Text = oBarrioSelected.NombreBarrio;

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (oBarrioSelected is null)
                {
                    Barrio nuevo = new Barrio();
                    nuevo.NombreBarrio = txtNombre.Text;
                    if (oBarrioService.NuevoBarrio(nuevo))
                    {
                        MessageBox.Show("Cliente insertado exitosamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error al intentar insertar el Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }

                }

                else
                {
                    oBarrioSelected.NombreBarrio = txtNombre.Text;
                    if (oBarrioService.ActualizarBarrio(oBarrioSelected))
                    {
                        MessageBox.Show("Barrio actualizado !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el Barrio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool ValidarCampos()
        {
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe introducir un Nombre", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.BackColor = Color.Red;
                txtNombre.Focus();
                return false;
            }

            else
            {
                var oBarrio = new Barrio();
                oBarrio.NombreBarrio = txtNombre.Text;
                var ls_barrios = new List<Barrio>();
                ls_barrios = (List<Barrio>)oBarrioService.ObtenerTodos();
                foreach (Barrio i in ls_barrios)
                {
                    if (i.NombreBarrio == oBarrio.NombreBarrio)
                    {
                        MessageBox.Show("Ya existe un Barrio con el nombre ingresado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNombre.Text = null;
                        txtNombre.BackColor = Color.Red;
                        txtNombre.Focus();
                        return false;
                    }
                }
                return true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
