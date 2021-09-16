using Modulo4_G4.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Modulo4_G4.CapaAccesoDatos
{
    class ProductoDao
    {
        public IList<Producto> GetAll()
        {
            List<Producto> listadoBugs = new List<Producto>();

            var strSql = "SELECT id_producto, nombre from Productos";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoBugs.Add(ObjectMapping(row));
            }

            return listadoBugs;
        }

        private Producto ObjectMapping(DataRow row)
        {
            Producto oProducto = new Producto
            {
                IdProducto = Convert.ToInt32(row["id_producto"].ToString()),
                NombreProducto = row["nombre"].ToString()
            };

            return oProducto;
        }
    }
}
