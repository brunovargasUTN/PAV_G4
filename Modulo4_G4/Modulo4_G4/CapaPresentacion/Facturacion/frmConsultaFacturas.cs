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
        private UsuarioService usuarioService;
        public frmConsultaFacturas()
        {
            InitializeComponent();
            InitializeDataGridView();
            productoService = new ProductoService();
            facturaService = new FacturaService();
            usuarioService = new UsuarioService();
        }

        private void frmConsultaFacturas_Load(object sender, EventArgs e)
        {
            CargarCombos(cboProductos, productoService.ObtenerTodos(), "NombreProducto", "IdProducto");
            CargarCombos(cboVendedores, usuarioService.ObtenerTodos(), "NombreUsuario", "IdUsuario");
            btnMostrarFactura.Enabled = false;
            LimpiarControles();
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

            dgvFacturas.AllowUserToAddRows = false;
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
                return;
            }
            //Validamos los filtros que se hayan seleccionado
            if (!ValidarFiltros()) { return; }

            //Cargamos la coleccion de parametros para el filtro
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(mtbCuit.Text))
            {
                parametros.Add("cuit", mtbCuit.Text.ToString());
            }
            if (!string.IsNullOrEmpty(cboProductos.Text.ToString()))
            {
                parametros.Add("idProducto", cboProductos.SelectedValue.ToString());
            }
            if (!string.IsNullOrEmpty(cboVendedores.Text.ToString()))
            {
                parametros.Add("idUsuario", cboVendedores.SelectedValue.ToString());
            }
            //Cargamos las fechas entre
            //Desde deberia comenzar desde las 00:00:00 (Por defecto el dtp lo trae asi)
            //Hasta deberia ser hasta las 23:59:59 para que abarque todas las horas del ultimo dia 
            if (dtpDesde.Checked)
            {
                parametros.Add("fechaDesde", dtpDesde.Value.Date.ToString());
            }
            if (dtpHasta.Checked)
            {
                var hasta = dtpHasta.Value;
                parametros.Add("fechaHasta", new DateTime(hasta.Year, hasta.Month, hasta.Day, 23, 59, 59));
            }

            if (parametros.Count > 0)
            {
                facturas = (List<Factura>)facturaService.ObtenerPorFiltro(parametros);
                RecargarDataGridView(facturas);
                return;
            }
            else 
            {
                MessageBox.Show("Debe Ingresar al menos un parametro de filtro o marcar la casilla Todos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


        }

        private bool ValidarFiltros()
        {
            //Validamos el ingreso de un cuit valido
            if (!string.IsNullOrEmpty(mtbCuit.Text)  && !mtbCuit.MaskCompleted)
            {
                MessageBox.Show("Debe Ingresar un CUIT valido","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return false;
            }
            //Validamos las fechas
            if((dtpDesde.Checked && dtpHasta.Checked) && (dtpDesde.Value.Date > dtpHasta.Value.Date))
            {
                MessageBox.Show("La fecha Desde no puede ser mayor que la fecha Hasta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if(dtpDesde.Checked && dtpDesde.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha Desde no puede ser mayor que la fecha de hoy: " + DateTime.Today.ToShortDateString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (dtpHasta.Checked && dtpHasta.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha Hasta no puede ser mayor que la fecha de hoy: " + DateTime.Today.ToShortDateString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void RecargarDataGridView(IList<Factura> lista) {
            if(lista.Count == 0)
            {
                MessageBox.Show("La consulta no arrojó resultados. ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                cboVendedores.Enabled = false;
                LimpiarControles();
            }
            else
            {
                mtbCuit.Enabled = true;
                cboProductos.Enabled = true;
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;
                cboVendedores.Enabled = true;
            }
        }

        private void LimpiarControles()
        {
            mtbCuit.Clear();
            cboProductos.SelectedIndex = -1;
            cboVendedores.SelectedIndex = -1;
            dtpHasta.Value = DateTime.Today;
            dtpDesde.Value = DateTime.Today;
            dtpDesde.Checked = false;
            dtpHasta.Checked = false;   
        }

        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if(dgvFacturas.CurrentRow != null) {
                btnMostrarFactura.Enabled = true;
                facturaSeleccionada = (Factura)dgvFacturas.CurrentRow.DataBoundItem;
            }
            
        }

        private void btnMostrarFactura_Click(object sender, EventArgs e)
        {
            frmFactura frm = new frmFactura();
            frm.inicializarFormulario(frmFactura.FormMode.consulta, facturaSeleccionada);
            frm.ShowDialog();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            if(dtpDesde.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha Desde no puede ser mayor que la fecha Actual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            if(dtpHasta.Checked && dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha Desde no puede ser mayor que la fecha Hasta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            if (dtpHasta.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha Hasta no puede ser mayor que la fecha Actual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (dtpDesde.Checked && dtpHasta.Value.Date < dtpDesde.Value.Date)
            {
                MessageBox.Show("La fecha Hasta no puede ser menor que la fecha Desde", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
