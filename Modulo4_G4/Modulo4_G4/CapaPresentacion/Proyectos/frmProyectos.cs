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
    public partial class frmProyectos : Form
    {
        private UsuarioService usuarioService;
        private ProyectoService proyectoService;
        private ProductoService productoService;
        public frmProyectos()
        {
            InitializeComponent();
            InitializeDataGridView();
            usuarioService = new UsuarioService();
            proyectoService = new ProyectoService();
            productoService = new ProductoService();
            
        }

        private void LlenarCombo(ComboBox cbo, object source, string display, string value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void frmProyectos_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboResponsable, usuarioService.ObtenerTodos(), "NombreUsuario", "IdUsuario");
            LlenarCombo(cboProducto, productoService.ObtenerTodos(), "NombreProducto", "IdProducto");
            btnEditar.Enabled = false;
            btnQuitar.Enabled = false;
        }

        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvProyectos.ColumnCount = 5;
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
            dgvProyectos.Columns[0].Name = "Nombre";
            dgvProyectos.Columns[0].DataPropertyName = "Descripcion";
            // Definimos el ancho de la columna.

            dgvProyectos.Columns[1].Name = "Producto";
            dgvProyectos.Columns[1].DataPropertyName = "Producto";

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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {   
                IList<Proyecto> lista = proyectoService.ObtenerTodos();
                dgvProyectos.DataSource = lista;
                return;
            }

            if (String.IsNullOrEmpty(txtNombre.Text) && String.IsNullOrEmpty(cboResponsable.Text) && String.IsNullOrEmpty(cboProducto.Text)) {
                MessageBox.Show("Debe ingresar al menos un parametro de filtro");
                return;
            }

            Dictionary<string, object> parametros = new Dictionary<string, object>();

            if (!String.IsNullOrEmpty(txtNombre.Text))
            {
                parametros.Add("Descripcion", txtNombre.Text);
            }
            
            if (!String.IsNullOrEmpty(cboProducto.Text))
            {
                parametros.Add("IdProducto", cboProducto.SelectedValue);
            }
            

            if (!String.IsNullOrEmpty(cboResponsable.Text))
            {
                parametros.Add("IdResponsable", cboResponsable.SelectedValue);
            }

            dgvProyectos.DataSource = proyectoService.ObtenerPorFiltro(parametros);

        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                cboProducto.Enabled = false;
                cboResponsable.Enabled = false;
                txtNombre.Enabled = false;
            }
            else
            {
                cboProducto.Enabled = true;
                cboResponsable.Enabled = true;
                txtNombre.Enabled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProyectos_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
            // Solo se debe habilitar los controles de edicion y borrado si se selecciona un objeto valido del dgv

            if (dgvProyectos.CurrentRow.DataBoundItem != null)
            {
                btnEditar.Enabled = true;
                btnQuitar.Enabled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmABMProyecto frmABM = new frmABMProyecto();
            frmABM.inicializarFormulario(frmABMProyecto.FormMode.modificar, (Proyecto) dgvProyectos.CurrentRow.DataBoundItem);
            frmABM.ShowDialog();
            dgvProyectos.DataSource = null;
            btnConsultar_Click(null,null);

        }
    }
}
