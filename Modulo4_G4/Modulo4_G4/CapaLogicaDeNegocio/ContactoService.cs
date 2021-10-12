
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modulo4_G4.Entidades;
using Modulo4_G4.CapaAccesoDatos;

namespace Modulo4_G4.CapaLogicaDeNegocio
{
    public class ContactoService
    {
        private ContactoDao oContactoDao;
        public ContactoService()
        {
            oContactoDao = new ContactoDao();
        }
        public IList<Contacto> ObtenerTodos()
        {
            return oContactoDao.GetAll();
        }
        public IList<Contacto> ObtenerPorFiltro(Dictionary<string, object> parametros)
        {
            return oContactoDao.GetByFilters(parametros);
        }
        public bool NuevoContacto(Contacto contacto)
        {
            return oContactoDao.Create(contacto);
        }

        public bool ActualizarContacto(Contacto oContactoSelected)
        {
            return oContactoDao.Update(oContactoSelected);
        }

        public bool EliminarContacto(Contacto oContactoSelected)
        {
            return oContactoDao.Delete(oContactoSelected);
        }
    }
}
