using Modulo4_G4.CapaAccesoDatos;
using Modulo4_G4.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo4_G4.CapaLogicaDeNegocio
{
    public class ClienteService
    {
        private ClienteDao oClienteDao;
        public ClienteService()
        {
            oClienteDao = new ClienteDao();
        }
        public IList<Cliente> ObtenerTodos()
        {
            return oClienteDao.GetAll();
        }

        public Cliente ConsultarClientePorId(int id)
        {
            return oClienteDao.GetClienteById(id);
        }

        public IList<Cliente> ConsultarClientesConFiltros(Dictionary<string, object> parametros)
        {
            return oClienteDao.GetClienteByFilters(parametros);
        }
    }
}
