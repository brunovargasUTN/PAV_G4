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
    public partial class frmClientes : Form
    {
        private ClienteService oClienteService;

        public frmClientes()
        {
            InitializeComponent();
            oClienteService = new ClienteService();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
            btnEditar.Enabled = false;
            btnQuitar.Enabled = false;
        }

        private void InitializeDataGridView()
        {
            //Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvClientes.ColumnCount = 8;
            dgvClientes.ColumnHeadersVisible = true;
            dgvClientes.ReadOnly = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas.
            dgvClientes.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvClientes.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dgvClientes.Columns[0].Name = "ID Cliente";
            dgvClientes.Columns[0].DataPropertyName = "IdCliente";

            dgvClientes.Columns[1].Name = "CUIT";
            dgvClientes.Columns[1].DataPropertyName = "Cuit";

            dgvClientes.Columns[2].Name = "Razon Social";
            dgvClientes.Columns[2].DataPropertyName = "RazonSocial";

            dgvClientes.Columns[3].Name = "Calle";
            dgvClientes.Columns[3].DataPropertyName = "Calle";

            dgvClientes.Columns[4].Name = "N° Domicilio";
            dgvClientes.Columns[4].DataPropertyName = "NroCalle";

            dgvClientes.Columns[5].Name = "Fecha Alta";
            dgvClientes.Columns[5].DataPropertyName = "fechaAlta";

            dgvClientes.Columns[6].Name = "Barrio";
            dgvClientes.Columns[6].DataPropertyName = "Barrio";

            dgvClientes.Columns[7].Name = "Contacto";
            dgvClientes.Columns[7].DataPropertyName = "Contacto";

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvClientes.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvClientes.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (chkMostrarTodos.Checked)
            {
                dgvClientes.DataSource = oClienteService.ObtenerTodos();
                return;
            }

            if (String.IsNullOrEmpty(txtID.Text) && String.IsNullOrEmpty(txtCuit.Text) && String.IsNullOrEmpty(mtbFechaAlta.Text))
            {
                MessageBox.Show("Debe ingresar al menos un parametro de filtro");
                return;
            }

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            
            if (!String.IsNullOrEmpty(txtID.Text))
            {
                parametros.Add("IdCliente", txtID.Text);
            }
            
            if (!String.IsNullOrEmpty(txtCuit.Text))
            {
                parametros.Add("Cuit", txtCuit.Text);
            }

            if (!String.IsNullOrEmpty(mtbFechaAlta.Text))
            {
                parametros.Add("FechaAlta", mtbFechaAlta.Text);
            }

            //IList<Bug> listadoBugs = bugService.ConsultarBugsConFiltros(parametros);

            //dgvBugs.DataSource = listadoBugs;

            IList<Cliente> listadoClientes = oClienteService.ConsultarClientesConFiltros(parametros);
            dgvClientes.DataSource = listadoClientes;

            if (dgvClientes.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron coincidencias para el/los filtros ingresados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmABMCliente frm = new frmABMCliente();
            frm.ShowDialog();

            //Forzamos el evento Click para actualizar la grilla.
            btnConsultar_Click(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmABMCliente frm = new frmABMCliente();
            var cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            frm.InicializarFormulario(frmABMCliente.FormMode.modificar, cliente);
            frm.ShowDialog();

            btnConsultar_Click(sender, e);
        }


        private void btnQuitar_Click(object sender, EventArgs e)
        {
            frmABMCliente frm = new frmABMCliente();
            var cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            frm.InicializarFormulario(frmABMCliente.FormMode.eliminar, cliente);
            frm.ShowDialog();

            btnConsultar_Click(sender, e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkMostrarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarTodos.Checked)
            {
                txtID.Enabled = false;
                txtCuit.Enabled = false;
                mtbFechaAlta.Enabled = false;
            }
            else
            {
                txtID.Enabled = true;
                txtCuit.Enabled = true;
                mtbFechaAlta.Enabled = true;
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentRow.DataBoundItem != null)
            {
                btnEditar.Enabled = true;
                btnQuitar.Enabled = true;
            }
        }
    }
}