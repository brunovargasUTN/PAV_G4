using Modulo4_G4.CapaAccesoDatos;
using Modulo4_G4.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo4_G4.CapaLogicaDeNegocio
{
    class ProductoService
    {
        private ProductoDao oProductoDao;
        public ProductoService()
        {
            oProductoDao = new ProductoDao();
        }
        public IList<Producto> ObtenerTodos()
        {
            return oProductoDao.GetAll();
        }
    }
}
