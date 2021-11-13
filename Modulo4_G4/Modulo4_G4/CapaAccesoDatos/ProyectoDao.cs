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
                           " p.id_responsable = u.id_usuario WHERE p.borrado = 0 ORDER BY p.descripcion ASC ";

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

            strSql += " ORDER BY p.descripcion ASC ";

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

        internal bool Create(Proyecto proyecto)
        {
            string strSql = String.Concat(" INSERT INTO Proyectos (descripcion, id_producto, alcance, version, id_responsable, borrado) ", 
                                            " VALUES (@Descripcion, @IdProducto, @Alcance, @Version, @IdUsuario, 0) ");

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("Descripcion", proyecto.Descripcion);
            parametros.Add("IdProducto", proyecto.Producto.IdProducto);
            parametros.Add("Alcance", proyecto.Alcance);
            parametros.Add("Version", proyecto.Version);
            parametros.Add("IdUsuario", proyecto.Responsable.IdUsuario);


            return (DataManager.GetInstance().EjecutarSQL(strSql,parametros) == 1);
        }

        internal bool Update(Proyecto proyecto)
        {
            var strSql = String.Concat(" UPDATE Proyectos SET descripcion = @Descripcion, id_producto = @IdProducto, version = @Version, ",
                                        " alcance = @Alcance, id_responsable = @IdResponsable WHERE id_proyecto = @IdProyecto ");
            var parametros = new Dictionary<string, object>();

            parametros.Add("IdProyecto", proyecto.IdProyecto);
            parametros.Add("Descripcion", proyecto.Descripcion);
            parametros.Add("IdProducto", proyecto.Producto.IdProducto);
            parametros.Add("Version", proyecto.Version);
            parametros.Add("Alcance", proyecto.Alcance);
            parametros.Add("IdResponsable", proyecto.Responsable.IdUsuario);

            return (DataManager.GetInstance().EjecutarSQL(strSql,parametros) == 1);
        }

        internal bool Delete(Proyecto proyecto)
        {
            var strSql = String.Concat("UPDATE Proyectos SET borrado = 1",
                                        " WHERE id_proyecto = " + proyecto.IdProyecto.ToString());

            return (DataManager.GetInstance().EjecutarSQL(strSql) == 1);
        }

        //Consultas para Reportes
        public DataTable GetReporteProyectos()
        {
            var strSql = String.Concat(" SELECT Usuarios.usuario, Proyectos.descripcion, Proyectos.version, Proyectos.alcance, Productos.nombre ",
                                            " FROM Usuarios INNER JOIN ",
                                            " Proyectos ON Usuarios.id_usuario = Proyectos.id_responsable INNER JOIN ",
                                            " Productos ON Proyectos.id_producto = Productos.id_producto ",
                                            " WHERE(Proyectos.borrado = 0)  ORDER BY Productos.nombre, Proyectos.descripcion, Proyectos.version  ");

            return DataManager.GetInstance().ConsultaSQL(strSql);
        }

        public DataTable GetReporteProyectosXProductos()
        {
            var strSql = String.Concat(" SELECT TOP 10 p.nombre as producto, COUNT(p.id_producto) as cantidad ",
                                             " FROM Proyectos pr JOIN Productos p ",
                                             " ON pr.id_producto = p.id_producto ",
                                             " WHERE pr.borrado = 0 ",
                                             " GROUP BY p.nombre ",
                                             " ORDER BY cantidad desc ");

            return DataManager.GetInstance().ConsultaSQL(strSql);
        }


        //Mapper de Proyectos
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

            if(row["id_responsable"] != null)
            {
                int idResponsable = Convert.ToInt32(row["id_responsable"].ToString());
                UsuarioDao usuarioDao = new UsuarioDao();
                oProyecto.Responsable = usuarioDao.GetById(idResponsable);
            }
            return oProyecto;
        }
    }
}
