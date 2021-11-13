using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Modulo4_G4.CapaLogicaDeNegocio;
using Modulo4_G4.Entidades;

namespace Modulo4_G4.CapaPresentacion.Contactos
{
    public partial class frmContactos : Form
    {   
        private ContactoService oContactoService;
        public frmContactos()
        {
            InitializeComponent();
            InitializeDataGridView();
            oContactoService = new ContactoService();
        }

        private void frmContactos_Load(object sender, EventArgs e)
        {
            //btnEditar.Enabled = false;
            //btnQuitar.Enabled = false;
        }

        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvContactos.ColumnCount = 4;
            dgvContactos.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvContactos.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvContactos.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dgvContactos.Columns[0].Name = "Nombre";
            dgvContactos.Columns[0].DataPropertyName = "NombreContacto";

            dgvContactos.Columns[1].Name = "Apellido";
            dgvContactos.Columns[1].DataPropertyName = "Apellido";

            dgvContactos.Columns[2].Name = "Email";
            dgvContactos.Columns[2].DataPropertyName = "EmailContacto";
            dgvContactos.Columns[2].Width = 150;

            dgvContactos.Columns[3].Name = "Telefono";
            dgvContactos.Columns[3].DataPropertyName = "Telefono";

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvContactos.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvContactos.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            dgvContactos.AllowUserToAddRows = false;
        }

        private void btnConsultar_Click(System.Object sender, System.EventArgs e)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            if (!chkTodos.Checked)
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))
                    parametros.Add("nombre", txtNombre.Text);

                if (!string.IsNullOrEmpty(txtApellido.Text))
                    parametros.Add("apellido", txtApellido.Text);

                if (parametros.Count > 0)
                    dgvContactos.DataSource = oContactoService.ObtenerPorFiltro(parametros);
                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                dgvContactos.DataSource = oContactoService.ObtenerTodos();
            }
            //if (String.IsNullOrEmpty(txtNombre.Text) && String.IsNullOrEmpty(txtApellido.Text))
            //{
            //    MessageBox.Show("Debe ingresar al menos un parametro de filtro");
            //    return;
                
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {              
            if (chkTodos.Checked)
            {
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
            }
            else
            {
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvContactos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvContactos.CurrentRow != null && dgvContactos.CurrentRow.DataBoundItem != null)
            {
                btnEditar.Enabled = true;
                btnQuitar.Enabled = true;
            }
        }

        private void btnEditar_Click(System.Object sender, System.EventArgs e)
        {
            frmABMContacto frmABM = new frmABMContacto();

            var contacto = (Contacto)dgvContactos.CurrentRow.DataBoundItem;
            frmABM.InicializarFormulario(frmABMContacto.FormMode.modificar, contacto);
            frmABM.ShowDialog();

            //dgvContactos.DataSource = null;
            btnConsultar_Click(sender, e);
        }

        private void btnQuitar_Click(System.Object sender, System.EventArgs e)
        {
            frmABMContacto frmABM = new frmABMContacto();

            var contacto = (Contacto)dgvContactos.CurrentRow.DataBoundItem;
            frmABM.InicializarFormulario(frmABMContacto.FormMode.eliminar, contacto);
            frmABM.ShowDialog();
            //dgvContactos.DataSource = null;
            btnConsultar_Click(sender, e);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmABMContacto frmABM = new frmABMContacto();
            frmABM.InicializarFormulario(frmABMContacto.FormMode.nuevo);
            frmABM.ShowDialog();
        }
    }
}
