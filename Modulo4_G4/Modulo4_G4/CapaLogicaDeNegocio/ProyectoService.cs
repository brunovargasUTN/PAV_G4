using Modulo4_G4.CapaAccesoDatos;
using Modulo4_G4.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Modulo4_G4.CapaLogicaDeNegocio
{
    class ProyectoService
    {
        private ProyectoDao proyectoDao;

        public ProyectoService()
        {
            proyectoDao = new ProyectoDao();
        }

        public IList<Proyecto> ObtenerTodos()
        {
            return proyectoDao.GetAll();
        }

        public IList<Proyecto> ObtenerPorFiltro(Dictionary<string, object> parametros)
        {
            return proyectoDao.GetByFilters(parametros);
        }

        public bool NuevoProyecto(Proyecto proyecto)
        {
            return proyectoDao.Create(proyecto);
        }

        public bool ActualizarProyecto(Proyecto proyecto)
        {
            return proyectoDao.Update(proyecto);
        }

        public bool EliminarProyecto(Proyecto proyecto)
        {
            return proyectoDao.Delete(proyecto);
        }

        public DataTable MostrarReporteProyectos()
        {
            return proyectoDao.GetReporteProyectos();
        }

        public DataTable MostrarReporteProyectosXProductos()
        {
            return proyectoDao.GetReporteProyectosXProductos();
        }
    }
}