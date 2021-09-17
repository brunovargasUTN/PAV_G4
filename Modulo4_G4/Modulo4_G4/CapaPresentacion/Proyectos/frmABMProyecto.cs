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
    public partial class frmABMProyecto : Form
    {
        private FormMode formMode = FormMode.nuevo;
        private Proyecto proyectoSeleccionado;
        private ProyectoService proyectoService;
        private ProductoService productoService;
        private UsuarioService usuarioService;


        public frmABMProyecto()
        {
            InitializeComponent();
            proyectoService = new ProyectoService();
            productoService = new ProductoService();
            usuarioService = new UsuarioService();
        }

        public enum FormMode
        {
            nuevo,          //Alta
            eliminar = 99,  //Baja
            modificar       //Modificacion
        }

        private void frmABMProyecto_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboProducto, productoService.ObtenerTodos(), "NombreProducto", "IdProducto");
            LlenarCombo(cboProducto, usuarioService.ObtenerTodos(), "NombreUsuario", "Idusuario");

            switch (formMode)
            {
                case FormMode.nuevo:
                    {
                        this.Text = "Nuevo Proyecto";
                        break;
                    }
                case FormMode.modificar:
                    {
                        break;
                    }
            }

        }

        public void inicializarFormulario(FormMode op, Proyecto proyectoSelected)
        {
            proyectoSeleccionado = proyectoSelected;
            formMode = op;
        }

        private void LlenarCombo(ComboBox cbo, Object source, String display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }
    }
}
