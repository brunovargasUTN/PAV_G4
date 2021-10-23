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

namespace Modulo4_G4.CapaPresentacion.Facturacion
{
    public partial class frmConsultaFacturas : Form
    {
        private ProductoService productoService;
        private List<Factura> facturas;
        private FacturaService facturaService;
        private Factura facturaSeleccionada;
        public frmConsultaFacturas()
        {
            InitializeComponent();
            InitializeDataGridView();
            productoService = new ProductoService();
            facturaService = new FacturaService();
        }

        private void frmConsultaFacturas_Load(object sender, EventArgs e)
        {
            CargarCombos(cboProductos, productoService.ObtenerTodos(), "NombreProducto", "IdProducto");
            btnMostrarFactura.Enabled = false;

        }
        private void CargarCombos(ComboBox cbo, object dataSource, string display, string value)
        {
            cbo.DataSource = dataSource;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }
        

        
    private void InitializeDataGridView()
    {
        // Cree un DataGridView no vinculado declarando un recuento de columnas.
        dgvFacturas.ColumnCount = 6;
        dgvFacturas.ColumnHeadersVisible = true;
        dgvFacturas.ReadOnly = true;

        // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
        dgvFacturas.AutoGenerateColumns = false;

        // Cambia el estilo de la cabecera de la grilla.
        DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

        columnHeaderStyle.BackColor = Color.Beige;
        columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
        dgvFacturas.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

        // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
        dgvFacturas.Columns[0].Name = "Fecha";
        dgvFacturas.Columns[0].DataPropertyName = "Fecha";
        // Definimos el ancho de la columna.

            dgvFacturas.Columns[1].Name = "Nro. Factura";
            dgvFacturas.Columns[1].DataPropertyName = "NroFactura";
            dgvFacturas.Columns[1].Width = 120;

            dgvFacturas.Columns[2].Name = "CUIT";

            dgvFacturas.Columns[3].Name = "Razon Social";
            dgvFacturas.Columns[3].Width = 130;

            dgvFacturas.Columns[4].Name = "Usuario";
            dgvFacturas.Columns[4].Width = 110;

            dgvFacturas.Columns[5].Name = "Total";
            dgvFacturas.Columns[5].DataPropertyName = "TotalFactura";
            dgvFacturas.Columns[5].Width = 100;

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvFacturas.AutoResizeColumnHeadersHeight();

        // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
        dgvFacturas.AutoResizeRows(
            DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
    }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                facturas = (List<Factura>)facturaService.ObtenerTodos();
                RecargarDataGridView(facturas);
            }

        }

        private void RecargarDataGridView(IList<Factura> lista) {
            dgvFacturas.DataSource = null;
            dgvFacturas.DataSource = lista;
            foreach (DataGridViewRow fila in dgvFacturas.Rows)
            {
                fila.Cells[2].Value = ((Factura)fila.DataBoundItem).Cliente.Cuit;
                fila.Cells[3].Value = ((Factura)fila.DataBoundItem).Cliente.RazonSocial;
                fila.Cells[4].Value = ((Factura)fila.DataBoundItem).UsuarioCreador.NombreUsuario;
            }

        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {               
                mtbCuit.Enabled = false;
                cboProductos.Enabled = false;
                dtpDesde.Enabled = false;
                dtpHasta.Enabled = false;
            }
            else
            {
                mtbCuit.Enabled = true;
                cboProductos.Enabled = true;
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;
            }
        }

        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnMostrarFactura.Enabled = true;
            facturaSeleccionada = (Factura)dgvFacturas.CurrentRow.DataBoundItem;
        }

        private void btnMostrarFactura_Click(object sender, EventArgs e)
        {
            frmFactura frm = new frmFactura();
            frm.inicializarFormulario(frmFactura.FormMode.consulta, facturaSeleccionada);
            frm.ShowDialog();
        }
    }
}
