using Modulo4_G4.CapaLogicaDeNegocio;
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
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            dgvProyectos.ColumnCount = 5;
            dgvProyectos.ColumnHeadersVisible = true;

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
                dgvProyectos.DataSource = proyectoService.ObtenerTodos();
                return;
            }
        }
    }
}
