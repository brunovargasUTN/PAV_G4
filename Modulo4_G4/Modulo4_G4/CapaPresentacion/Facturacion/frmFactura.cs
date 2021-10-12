using Modulo4_G4.CapaLogicaDeNegocio;
using Modulo4_G4.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modulo4_G4.CapaPresentacion.Facturacion
{
    public partial class frmFactura : Form
    {
        private Factura facturaSeleccionada;
        private Cliente clienteSeleccionado;

        private ClienteService clienteService;
        private ProyectoService proyectoService;
        private ProductoService productoService;

        private FormMode formMode;
        public frmFactura()
        {
            InitializeComponent();
            clienteService = new ClienteService();
            proyectoService = new ProyectoService();
            productoService = new ProductoService();
        }

        public enum FormMode
        {
            nuevo,          //Alta
            consulta        //Modo solo lectura para consultar una factura desde frmConsultarHistorico
        }

        public void inicializarFormulario(FormMode op, Factura factura = null)
        {
            facturaSeleccionada = factura;
            formMode = op;
        }
        private void frmFactura_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.ToShortDateString();
            llenarCombos(cboProductos,productoService.ObtenerTodos(),"NombreProducto","IdProducto");
            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        facturaSeleccionada = new Factura();
                        clienteSeleccionado = new Cliente();
                        break;
                    }

            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {   
            //Validamos los datos ingresados de CUIT
            if (!mtbCuit.MaskCompleted)
            {
                MessageBox.Show("Debe ingresar un numero de CUIT valido","Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Buscamos el cliente por numero de CUIT
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("Cuit", mtbCuit.Text);
            clienteSeleccionado = clienteService.ConsultarClientesConFiltros(parametros)[0];

            if(clienteSeleccionado is null) {
                MessageBox.Show("Cliente no encontrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Rellenamos los datos de los Textbox del Cliente
            txtRazonSocial.Text = clienteSeleccionado.RazonSocial;
            txtDireccion.Text = String.Concat(clienteSeleccionado.Calle," - ",clienteSeleccionado.NroCalle," - ",clienteSeleccionado.Barrio);
            txtContacto.Text = String.Concat(clienteSeleccionado.Contacto.NombreContacto,", ",clienteSeleccionado.Contacto.Apellido);
            txtTelefono.Text = clienteSeleccionado.Contacto.Telefono.ToString();
            txtEmail.Text = clienteSeleccionado.Contacto.EmailContacto;

            
        }



        private void mtbCuit_ModifiedChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevaFactura_Click(object sender, EventArgs e)
        {   
            mtbCuit.Enabled = true;
            btnBuscarCliente.Enabled = true;
            limpiarCampos();
            mtbCuit.Focus();


        }

        private void llenarCombos(ComboBox cbo, object source, string display, string value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }
        private void limpiarCampos()
        {
            txtRazonSocial.Text = "";
            txtDireccion.Text = "";
            txtContacto.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
        }

        private void rbProyecto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProductoFinal.Checked)
            {

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarDgvProyectos()
        {
            
        }

        private void inicializarDgvProyectos()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvProyectos.ColumnCount = 4;
            dgvProyectos.ColumnHeadersVisible = true;
            //dgvProyectos.ReadOnly = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvProyectos.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvProyectos.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dgvProyectos.Columns[0].Name = "Descripcion";
            dgvProyectos.Columns[0].DataPropertyName = "Descripcion";
            // Definimos el ancho de la columna.

            dgvProyectos.Columns[2].Name = "Version";
            dgvProyectos.Columns[2].DataPropertyName = "Version";

            dgvProyectos.Columns[3].Name = "Alcance";
            dgvProyectos.Columns[3].DataPropertyName = "Alcance";

            dgvProyectos.Columns[4].Name = "Responsable";
            dgvProyectos.Columns[4].DataPropertyName = "Responsable";

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvProyectos.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvProyectos.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
    }
}
