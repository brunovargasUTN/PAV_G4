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
            dgvClientes.ColumnCount = 7;
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

            dgvClientes.Columns[0].Name = "CUIT";
            dgvClientes.Columns[0].DataPropertyName = "Cuit";

            dgvClientes.Columns[1].Name = "Razon Social";
            dgvClientes.Columns[1].DataPropertyName = "RazonSocial";

            dgvClientes.Columns[2].Name = "Calle";
            dgvClientes.Columns[2].DataPropertyName = "Calle";
            dgvClientes.Columns[3].Width = 60;

            dgvClientes.Columns[3].Name = "N°";
            dgvClientes.Columns[3].DataPropertyName = "NroCalle";

            dgvClientes.Columns[4].Name = "Fecha Alta";
            dgvClientes.Columns[4].DataPropertyName = "fechaAlta";

            dgvClientes.Columns[5].Name = "Barrio";
            dgvClientes.Columns[5].DataPropertyName = "Barrio";

            dgvClientes.Columns[6].Name = "Contacto";
            dgvClientes.Columns[6].DataPropertyName = "Contacto";

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvClientes.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvClientes.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            //eliminamos fila en blanco por defecto
            dgvClientes.AllowUserToAddRows = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (chkMostrarTodos.Checked)
            {
                IList<Cliente> list = oClienteService.ObtenerTodos();
                dgvClientes.DataSource = list;
                return;

            }

            if (String.IsNullOrEmpty(txtRazonSocial.Text) && String.IsNullOrEmpty(mtbCuit.Text))
            {
                MessageBox.Show("Debe ingresar al menos un parametro de filtro");
                return;
            }

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            
            if (!String.IsNullOrEmpty(txtRazonSocial.Text))
            {
                parametros.Add("RazonSocial", txtRazonSocial.Text);
            }
            
            if (!String.IsNullOrEmpty(mtbCuit.Text))
            {   
                if(mtbCuit.MaskCompleted)
                parametros.Add("Cuit", mtbCuit.Text);
                else
                {
                    MessageBox.Show("Debe ingresar un Cuit valido");
                    return;
                }
            }

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
            frm.InicializarFormulario(frmABMCliente.FormMode.nuevo, new Cliente());
            frm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmABMCliente frm = new frmABMCliente();
            var cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            frm.InicializarFormulario(frmABMCliente.FormMode.modificar, cliente);
            frm.ShowDialog();

            //Forzamos el evento Click para actualizar la grilla.
            dgvClientes.DataSource = null;
            btnConsultar_Click(null, null);
        }


        private void btnQuitar_Click(object sender, EventArgs e)
        {
            frmABMCliente frm = new frmABMCliente();
            var cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            frm.InicializarFormulario(frmABMCliente.FormMode.eliminar, cliente);
            frm.ShowDialog();

            //Forzamos el evento Click para actualizar la grilla.
            dgvClientes.DataSource = null;
            btnConsultar_Click(null, null);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkMostrarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarTodos.Checked)
            {
                txtRazonSocial.Enabled = false;
                mtbCuit.Enabled = false;
            }
            else
            {
                txtRazonSocial.Enabled = true;
                mtbCuit.Enabled = true;
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentRow !=null && dgvClientes.CurrentRow.DataBoundItem != null)
            {
                btnEditar.Enabled = true;
                btnQuitar.Enabled = true;
            }
        }
    }
}