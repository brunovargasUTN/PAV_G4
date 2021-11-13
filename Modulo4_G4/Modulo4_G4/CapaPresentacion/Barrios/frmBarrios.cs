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
    public partial class frmBarrios : Form
    {
        private BarrioService oBarrioService;
        private Barrio oBarrioSelected;
        public frmBarrios()
        {
            InitializeComponent();
            oBarrioService = new BarrioService();
        }

        private void frmBarrios_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboBarrios, oBarrioService.ObtenerTodos(), "NombreBarrio", "IdBarrio");
            btnEditar.Enabled = false;
            btnQuitar.Enabled = false;
            cboBarrios.Focus();

        }


        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            // Datasource: establece el origen de datos de este objeto.
            cbo.DataSource = source;
            // DisplayMember: establece la propiedad que se va a mostrar para este ListControl.
            cbo.DisplayMember = display;
            // ValueMember: establece la ruta de acceso de la propiedad que se utilizará como valor real para los elementos de ListControl.
            cbo.ValueMember = value;
            //SelectedIndex: establece el índice que especifica el elemento seleccionado actualmente.
            cbo.SelectedIndex = -1;
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            oBarrioSelected = (Barrio)cboBarrios.SelectedItem;
            frmABMBarrio frm = new frmABMBarrio();
            frm.InicializarFormulario(oBarrioSelected);
            frm.ShowDialog();
            LlenarCombo(cboBarrios, oBarrioService.ObtenerTodos(), "NombreBarrio", "IdBarrio");
        }



        private void btnQuitar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desa eliminar el registro seleccionado?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                oBarrioSelected = (Barrio)cboBarrios.SelectedItem;
                if (oBarrioService.EliminarBarrio(oBarrioSelected))
                {
                    MessageBox.Show("Barrio eliminado !!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al intentar eliminar el Barrio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LlenarCombo(cboBarrios, oBarrioService.ObtenerTodos(), "NombreBarrio", "IdBarrio");
            btnEditar.Enabled = false;
            btnQuitar.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var oBarrio = new Barrio();
                oBarrio.NombreBarrio = txtNombre.Text;
                if (oBarrioService.NuevoBarrio(oBarrio))
                {
                    MessageBox.Show("Barrio insertado exitosamente !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombre.Text = null;
                }

                else
                {
                    MessageBox.Show("Se produjo un error al intentar insertar el Barrio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Text = null;
                }
            }
            LlenarCombo(cboBarrios, oBarrioService.ObtenerTodos(), "NombreBarrio", "IdBarrio");
        }

        private bool ValidarCampos()
        {
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe introducir un Nombre", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
                return false;
            }
            if (oBarrioService.ConsultarBarrioPorNombre(txtNombre.Text) != null)
            {
                MessageBox.Show("El nombre del Barrio ingresado ya existe!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //else
            //{
            //    var oBarrio = new Barrio();
            //    oBarrio.NombreBarrio = txtNombre.Text;
            //    var ls_barrios = new List<Barrio>();
            //    ls_barrios = (List<Barrio>)oBarrioService.ObtenerTodos();
            //    foreach (Barrio i in ls_barrios)
            //    {
            //        if (i.NombreBarrio == oBarrio.NombreBarrio)
            //        {
            //            MessageBox.Show("Ya existe un Barrio con el nombre ingresado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            txtNombre.Text = null;
            //            txtNombre.BackColor = Color.Red;
            //            txtNombre.Focus();
            //            btnEditar.Enabled = false;
            //            btnQuitar.Enabled = false;
            //            btnNuevo.Enabled = true;
            //            return false;
            //        }

            //        else
            //        {
            //            return true;
            //        }
            //    }
            //}
            return true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboBarrios_SelectedValueChanged(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnQuitar.Enabled = true;
            btnNuevo.Enabled = false;

        }

        private void txtNombre_Click(object sender, EventArgs e)
        {
            LlenarCombo(cboBarrios, oBarrioService.ObtenerTodos(), "NombreBarrio", "IdBarrio");
            btnEditar.Enabled = false;
            btnQuitar.Enabled = false;
            btnNuevo.Enabled = true;
            txtNombre.BackColor = Color.White;
        }
    }
}
