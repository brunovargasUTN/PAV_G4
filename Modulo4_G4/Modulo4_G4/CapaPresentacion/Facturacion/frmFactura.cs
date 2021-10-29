using Modulo4_G4.CapaLogicaDeNegocio;
using Modulo4_G4.CapaPresentacion.Login;
using Modulo4_G4.CapaPresentacion.Reportes;
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
        private List<Proyecto> proyectosPorProductos;
        private BindingList<DetalleFactura> detalleFactura;
        private Usuario usuarioResponsable;

        private ClienteService clienteService;
        private ProyectoService proyectoService;
        private ProductoService productoService;
        private FacturaService facturaService;

        private FormMode formMode;
        public frmFactura(Usuario usuario = null)
        {
            InitializeComponent();
            clienteService = new ClienteService();
            proyectoService = new ProyectoService();
            productoService = new ProductoService();
            facturaService = new FacturaService();
            detalleFactura = new BindingList<DetalleFactura>();
            usuarioResponsable = usuario;
        }

        public enum FormMode
        {
            nuevo,          //Alta
            consulta        //Modo solo lectura para consultar una factura desde frmConsultarHistorico
        }

        public void inicializarFormulario(FormMode op, Factura factura = null)
        {
            if (factura != null && op == FormMode.consulta)
            {
                facturaSeleccionada = factura;
                clienteSeleccionado = factura.Cliente;
                detalleFactura = new BindingList<DetalleFactura>(factura.DetalleFacturas);
            }
            formMode = op;
        }
        private void frmFactura_Load(object sender, EventArgs e)
        {
            inicializarDgvProyectos();
            inicializarDgvDetalleFactura();

            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        lblFecha.Text = DateTime.Today.ToShortDateString();
                        llenarCombos(cboProductos, productoService.ObtenerTodos(), "NombreProducto", "IdProducto");
                        txtFactura.Visible = false;
                        lblFactura.Visible = false;
                        break;
                    }

                case FormMode.consulta:
                    {
                        btnNuevaFactura.Enabled = false;
                        btnNuevaFactura.Visible = false;
                        deshabilitarControles();
                        lblFecha.Text = facturaSeleccionada.Fecha.ToShortDateString();
                        txtFactura.Text = facturaSeleccionada.NroFactura.ToString();
                        mtbCuit.Text = clienteSeleccionado.Cuit;
                        RellenarDatosCliente();
                        dgvDetalleFactura.DataSource = facturaSeleccionada.DetalleFacturas;
                        refrescarTotal();
                        btnImprimir.Enabled = true;
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
            var resultado = clienteService.ConsultarClientesConFiltros(parametros);

            if(resultado.Count == 0) {
                MessageBox.Show("Cliente no encontrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            clienteSeleccionado = resultado[0];

            //Rellenamos los datos de los Textbox del Cliente
            RellenarDatosCliente();

            
        }

        private void RellenarDatosCliente()
        {
            txtRazonSocial.Text = clienteSeleccionado.RazonSocial;
            txtDireccion.Text = String.Concat(clienteSeleccionado.Calle, " - ", clienteSeleccionado.NroCalle, " - ", clienteSeleccionado.Barrio);
            txtContacto.Text = String.Concat(clienteSeleccionado.Contacto.NombreContacto, ", ", clienteSeleccionado.Contacto.Apellido);
            txtTelefono.Text = clienteSeleccionado.Contacto.Telefono.ToString();
            txtEmail.Text = clienteSeleccionado.Contacto.EmailContacto;
        }

        private void btnNuevaFactura_Click(object sender, EventArgs e)
        {   
            mtbCuit.Enabled = true;
            btnConfirmar.Enabled = true;
            btnBuscarCliente.Enabled = true;
            btnLimpiarItems.Enabled = true;
            txtPrecio.Enabled = true;
            btnImprimir.Enabled = false;
            limpiarCampos();
            cboProductos.Enabled = true;
            mtbCuit.Focus();
            dgvDetalleFactura.Enabled = true;
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
            mtbCuit.Clear();
            txtRazonSocial.Clear();
            txtDireccion.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtFactura.Clear();
            txtTotal.Clear();
            detalleFactura.Clear();
        }

        private void rbProyecto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProductoFinal.Checked)
            {
                dgvProyectos.DataSource = null;
                dgvProyectos.Enabled = false;
                btnAgregar.Enabled = true;
                return;
            }
            dgvProyectos.DataSource = proyectosPorProductos;
            btnAgregar.Enabled = false;
            dgvProyectos.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void inicializarDgvProyectos()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvProyectos.ColumnCount = 4;
            dgvProyectos.ColumnHeadersVisible = true;
            dgvProyectos.ReadOnly = true;

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
            dgvProyectos.Columns[0].Width = 394;
            // Definimos el ancho de la columna.

            dgvProyectos.Columns[1].Name = "Version";
            dgvProyectos.Columns[1].DataPropertyName = "Version";

            dgvProyectos.Columns[2].Name = "Alcance";
            dgvProyectos.Columns[2].DataPropertyName = "Alcance";

            dgvProyectos.Columns[3].Name = "Responsable";
            dgvProyectos.Columns[3].DataPropertyName = "Responsable";

            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvProyectos.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvProyectos.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            //Eliminamos la fila en blanco por defecto que permite al usuario ingresar los datos en una grilla vacia. En este caso no lo necesitamos
            //y por el contrario nos perjudica al dejar una fila en blanco al final siempre.
            dgvProyectos.AllowUserToAddRows = false;

            dgvProyectos.DataSource = null;
        }

        private void inicializarDgvDetalleFactura()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvDetalleFactura.ColumnCount = 3;
            dgvDetalleFactura.ColumnHeadersVisible = true;
            dgvDetalleFactura.ReadOnly = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            dgvDetalleFactura.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvDetalleFactura.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dgvDetalleFactura.Columns[0].Name = "Producto";
            dgvDetalleFactura.Columns[0].DataPropertyName = "Producto";
            

            dgvDetalleFactura.Columns[1].Name = "Proyecto";
            dgvDetalleFactura.Columns[1].DataPropertyName = "Proyecto";
            dgvDetalleFactura.Columns[1].Width = 494;

            dgvDetalleFactura.Columns[2].Name = "Precio";
            dgvDetalleFactura.Columns[2].DataPropertyName = "Precio";


            // Cambia el tamaño de la altura de los encabezados de columna.
            dgvDetalleFactura.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dgvDetalleFactura.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            //Eliminamos la fila en blanco por defecto que permite al usuario ingresar los datos en una grilla vacia. En este caso no lo necesitamos
            //y por el contrario nos perjudica al dejar una fila en blanco al final siempre.
            dgvDetalleFactura.AllowUserToAddRows = false;

            dgvDetalleFactura.DataSource = detalleFactura;
        }

        private void cboProductos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboProductos.SelectedIndex == -1)
            {
                return;
            }

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("IdProducto", cboProductos.SelectedValue);

            var proyectos = proyectoService.ObtenerPorFiltro(param);

            if (proyectos.Count == 0)
            {
                dgvProyectos.DataSource = null;
                rbProductoFinal.Checked = true;
                rbProyecto.Enabled = false;
            }
            else
            {
                dgvProyectos.DataSource = null;
                proyectosPorProductos = (List<Proyecto>)proyectos;
                rbProductoFinal.Checked = true;
                rbProyecto.Enabled = true;
            }

            btnAgregar.Enabled = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DetalleFactura item = new DetalleFactura();
            item.Producto = (Producto)cboProductos.SelectedItem;
            //Verifico proyecto
            if (rbProyecto.Checked)
            {
                item.Proyecto = (Proyecto)dgvProyectos.CurrentRow.DataBoundItem;
                
            }
            //Verifico el precio
            decimal precio = 0;
            if (!Decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Debe ingresar un importe valido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            item.Precio = precio;

            detalleFactura.Add(item);
            btnQuitar.Enabled = false;
            refrescarTotal();
            limpiarItems();
            
        }

        private void limpiarItems()
        {
            //Limpio los controles de Items
            cboProductos.SelectedIndex = -1;
            rbProductoFinal.Checked = true;
            txtPrecio.Text = "";
            btnAgregar.Enabled = false;
            dgvProyectos.DataSource = null;
            dgvProyectos.Enabled = false;
            rbProyecto.Enabled = false;
            cboProductos.Focus();
            
        }
        private void dgvProyectos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProyectos.CurrentRow != null)
            {
                btnAgregar.Enabled = true;
            }
        }

        private void refrescarTotal()
        {
            decimal total = 0;

            foreach(DetalleFactura det in detalleFactura)
            {
                total += det.Precio;
            }

            txtTotal.Text = total.ToString();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            detalleFactura.Remove((DetalleFactura)dgvDetalleFactura.CurrentRow.DataBoundItem);
            refrescarTotal();
            btnQuitar.Enabled = false;
        }

        private void dgvDetalleFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDetalleFactura.CurrentRow != null)
            {
                btnQuitar.Enabled = true;
            }
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarFactura()) { return; }
            facturaSeleccionada = new Factura();
            facturaSeleccionada.Fecha = DateTime.Now;
            facturaSeleccionada.Cliente = clienteSeleccionado;
            facturaSeleccionada.UsuarioCreador = usuarioResponsable;
            facturaSeleccionada.DetalleFacturas = detalleFactura;
            try
            {
                facturaService.CrearFactura(facturaSeleccionada);
                MessageBox.Show("Transaccion exitosa", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                deshabilitarControles();
                txtFactura.Visible = true;
                lblFactura.Visible = true;
                txtFactura.Text = facturaSeleccionada.NroFactura.ToString();
                btnImprimir.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private bool ValidarFactura()
        {
            if(clienteSeleccionado == null) {
                MessageBox.Show("Debe seleccionar al menos un cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false; }
            if(detalleFactura.Count == 0) 
            {
                MessageBox.Show("Debe seleccionar al menos un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false; }
            if(cboProductos.SelectedIndex > -1)
            {
                MessageBox.Show("Aun tiene Items sin confirmar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboProductos.Focus();
                return false;
            }
        

            return true;
        }

        private void btnLimpiarItems_Click(object sender, EventArgs e)
        {
            limpiarItems();
        }

        private void deshabilitarControles()
        {
            mtbCuit.Enabled = false;
            cboProductos.Enabled = false;
            txtPrecio.Enabled = false;
            btnLimpiarItems.Enabled = false;
            dgvDetalleFactura.Enabled = false;
            btnConfirmar.Enabled = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            parametros.Add("nombreCliente", string.Concat(clienteSeleccionado.Contacto.Apellido, ", ", clienteSeleccionado.Contacto.NombreContacto));
            parametros.Add("emailCliente", clienteSeleccionado.Contacto.EmailContacto.ToString());
            parametros.Add("direccionCliente", string.Concat(clienteSeleccionado.Calle," ",clienteSeleccionado.NroCalle," - ",clienteSeleccionado.Barrio.NombreBarrio));
            parametros.Add("telefonoCliente", clienteSeleccionado.Contacto.Telefono.ToString());
            parametros.Add("cuitCliente", clienteSeleccionado.Cuit.ToString());
            parametros.Add("razonSocialCliente", clienteSeleccionado.RazonSocial.ToString());
            parametros.Add("nroFactura", facturaSeleccionada.NroFactura.ToString());
            parametros.Add("tipoFactura", "A");
            parametros.Add("fecha", facturaSeleccionada.Fecha.ToShortDateString());
            parametros.Add("emailEmpresa", "info@bugtracker.com.ar");
            parametros.Add("telefonoEmpresa", "(+54) 0351 - 4444444");
            parametros.Add("direccionEmpresa", "Av. Direccion 123 - Centro");
            parametros.Add("razonSocialEmpresa", "Bug Tracker S.R.L.");
            parametros.Add("sitioWebEmpresa", "www.bugtracker.com.ar");

            DataTable table = new DataTable();

            //1. Generamos los nombres de columnas en el datatable
            foreach (DataGridViewColumn column in dgvDetalleFactura.Columns)
                table.Columns.Add(column.Name, typeof(string));

            //2. looping through selected rows of dgv, and add them to datatable:
            for (int i = 0; i < dgvDetalleFactura.Rows.Count; i++)
            {
                table.Rows.Add();
                for (int j = 0; j < dgvDetalleFactura.Columns.Count; j++)
                {
                    //table.Rows[i][j] = dgvDetalleFactura[j, i].Value; // Funciona Igual que la de abajo, es otra forma valida
                    table.Rows[i][j] = dgvDetalleFactura.Rows[i].Cells[j].Value;
                }
            }

            frmReporte frmReporte = new frmReporte();
            frmReporte.inicializarReporte("DataSet1", @".\CapaPresentacion\Reportes\rptFactura.rdlc", table);
            frmReporte.CargarParametros(parametros);
            frmReporte.ShowDialog();

        }


    }
}
