using Modulo4_G4.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Modulo4_G4.CapaAccesoDatos
{
    class ProyectoDao
    {
        public IList<Proyecto> GetAll()
        {
            List<Proyecto> listadoProyecto = new List<Proyecto>();

            var strSql = "SELECT p.id_proyecto, p.id_producto, p.descripcion, p.version, p.alcance, p.id_responsable FROM    Proyectos p JOIN Usuarios u ON " +
                           " p.id_responsable = u.id_usuario WHERE p.borrado = 0";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoProyecto.Add(ObjectMapping(row));
            }

            return listadoProyecto;
        }

        public IList<Proyecto> GetByFilters(Dictionary<string,object> parametros)
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            var strSql = String.Concat(" SELECT p.id_proyecto, p.id_producto, p.descripcion, p.version, p.alcance, p.id_responsable ",
                                        " FROM Proyectos p WHERE p.borrado = 0 ");
            
            if (parametros.ContainsKey("IdProyecto"))
            {
                strSql += " AND p.id_proyecto = @IdProyecto ";
            }

            if (parametros.ContainsKey("IdProducto")){
                strSql += " AND p.id_producto = @IdProducto ";
            }

            if (parametros.ContainsKey("Descripcion"))
            {
                strSql += " AND ( p.descripcion LIKE '%' + @Descripcion + '%' ) ";
            }

            if (parametros.ContainsKey("Version"))
            {
                strSql += " AND p.version = @Version ";
            }

            if (parametros.ContainsKey("Alcance"))
            {
                strSql += " AND p.alcance = @Alcance ";
            }

            if (parametros.ContainsKey("IdResponsable"))
            {
                strSql += " AND p.id_responsable = @IdResponsable ";
            }

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            foreach(DataRow fila in resultadoConsulta.Rows)
            {
                proyectos.Add(ObjectMapping(fila));
            }

            return proyectos;
        }

        public Proyecto GetByID(int idProyecto)
        {
            var strSql = String.Concat(" SELECT id_proyecto, id_producto, descripcion, version, alcance, id_responsable "+
                                        " FROM Proyectos WHERE id_proyecto = " + idProyecto.ToString());
            var resultado = DataManager.GetInstance().ConsultaSQL(strSql);
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }
            return null;
        }

        private Proyecto ObjectMapping(DataRow row)
        {
            Proyecto oProyecto = new Proyecto
            {
                IdProyecto = Convert.ToInt32(row["id_proyecto"].ToString()),
                Descripcion = row["descripcion"].ToString(),
                Version = row["version"].ToString(),
                Alcance = row["alcance"].ToString()
            };

            if(row["id_producto"] != null)
            {
                int idProducto = Convert.ToInt32(row["id_producto"].ToString());
                ProductoDao productoDao = new ProductoDao();
                oProyecto.Producto = productoDao.GetById(idProducto);
            }
            
            return oProyecto;
        }
    }
}
