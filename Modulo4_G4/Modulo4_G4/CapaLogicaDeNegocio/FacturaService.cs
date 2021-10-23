using Modulo4_G4.CapaAccesoDatos;
using Modulo4_G4.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo4_G4.CapaLogicaDeNegocio
{
    class FacturaService
    {
        private FacturaDao facturaDao;

        public FacturaService()
        {
            facturaDao = new FacturaDao();
        }

        public bool CrearFactura(Factura factura)
        {
            return facturaDao.Create(factura);
        }

        public IList<Factura> ObtenerTodos()
        {
            return facturaDao.GetAll();
        }
    }
}
