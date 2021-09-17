using Modulo4_G4.CapaAccesoDatos;
using Modulo4_G4.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo4_G4.CapaLogicaDeNegocio
{
    public class BarrioService
    {
        private BarrioDao oBarrioDao;
        public BarrioService()
        {
            oBarrioDao = new BarrioDao();
        }

        public IList<Barrio> ObtenerTodos()
        {
            return oBarrioDao.GetAll();
        }

        public Barrio ConsultarBarrioPorId(int id)
        {
            return oBarrioDao.GetBarrioById(id);
        }
    }
}
