
using Modulo4_G4.CapaLogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Modulo4_G4.CapaPresentacion.Reportes
{
    public partial class frmReporte : Form
    {
       
        private ReportViewer reporte;
        public frmReporte()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            reporte = new ReportViewer();
            reporte.ProcessingMode = ProcessingMode.Local;
            reporte.Dock = DockStyle.Fill; //Setea el ReportViewer al tamaño del contenedor, en este caso, el Formulario
            Controls.Add(reporte);
        }

        private void frmReporteProyectos_Load(object sender, EventArgs e)
        {

            reporte.RefreshReport();
        
        }

        public void inicializarReporte(string dataSourceName, string pathReporte,DataTable table)
        {
            //Configuracion de origen de datos
            reporte.LocalReport.DataSources.Clear();
            reporte.LocalReport.DataSources.Add(new ReportDataSource(dataSourceName, table));
            reporte.LocalReport.ReportPath = pathReporte;
            //Personalizamos la presentacion del informe dentro del ReportViewer
            reporte.SetDisplayMode(DisplayMode.PrintLayout); //Muestra el informe en Modo impresion
            reporte.ZoomMode = ZoomMode.Percent; //Al modo impresion lo seteamos en ZoomMode con un porcentaje de zoom
            reporte.ZoomPercent = 100; //Seteamos la vista de impresion al 100% del tamaño del informe
           

        }

        public void CargarParametros(Dictionary<string, object> parametros)
        {
            foreach(var param in parametros)
            {
                reporte.LocalReport.SetParameters(new ReportParameter(param.Key.ToString(), param.Value.ToString()));
            }
        }
    }
}
