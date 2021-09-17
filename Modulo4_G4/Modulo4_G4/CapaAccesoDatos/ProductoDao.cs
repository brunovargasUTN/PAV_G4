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
            List<Producto> listadoProducto = new List<Producto>();

            var strSql = "SELECT id_producto, nombre from Productos";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoProducto.Add(ObjectMapping(row));
            }

            return listadoProducto;
        }

        public Producto GetById(int idProducto)
        {
            var strSql = String.Concat(" SELECT p.id_producto, p.nombre",
                                        "  FROM Productos p WHERE p.id_producto = " + idProducto.ToString());
            return ObjectMapping(DataManager.GetInstance().ConsultaSQL(strSql).Rows[0]);
        }

        internal bool Create(Producto producto)
        {
            string strSql = String.Concat(" INSERT INTO Productos (nombre) VALUES ("+ producto.NombreProducto +") " +
                                            " WHERE id_producto = "+ producto.IdProducto.ToString());
            return (DataManager.GetInstance().EjecutarSQL(strSql)==1);
        }

        internal bool Update(Producto producto)
        {
            string strSql = String.Concat(" UPDATE Productos SET nombre = " +producto.NombreProducto+
                                            " WHERE id_producto = " + producto.IdProducto.ToString());

            return (DataManager.GetInstance().EjecutarSQL(strSql) == 1);
        }

        internal bool Delete(Producto producto)
        {
            string strSql = String.Concat(" UPDATE Productos SET borrado = 1 " +
                                            " WHERE id_producto = " + producto.IdProducto.ToString());

            return (DataManager.GetInstance().EjecutarSQL(strSql) == 1);
        }

        private Producto ObjectMapping(DataRow row)
        {
            Producto producto = new Producto
            {
                IdProducto = Convert.ToInt32(row["id_producto"].ToString()),
                NombreProducto = row["nombre"].ToString()
            };

            return producto;
        }
    }
}