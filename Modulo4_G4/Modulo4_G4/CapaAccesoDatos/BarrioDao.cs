using Modulo4_G4.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Modulo4_G4.CapaAccesoDatos
{
    public class BarrioDao
    {
        public IList<Barrio> GetAll()
        {
            List<Barrio> list = new List<Barrio>();
            var strSql = " SELECT b.id_barrio, b.nombre " +
                         " FROM Barrios b " +
                         " WHERE b.borrado = 0 " +
                         " ORDER BY b.nombre ";
            var resultConsulta = DataManager.GetInstance().ConsultaSQL(strSql);
            foreach (DataRow row in resultConsulta.Rows)
            {
                list.Add(ObjectMapping(row));
            }
            return list;
        }

        public Barrio GetBarrioById(int idBarrio)
        {
            var strSql = String.Concat(" SELECT b.id_barrio, ",
                                       "        b.nombre ",
                                       " FROM Barrios b ",
                                       " WHERE b.id_barrio = " + idBarrio.ToString());
            var resultado = DataManager.GetInstance().ConsultaSQL(strSql);
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }
            return null;
        }

        public Barrio GetBarrioByNombre(string nombre)
        {
            var strSql = String.Concat(" SELECT b.id_barrio, ",
                                       "       b.nombre ",
                                       " FROM Barrios b ",
                                       " WHERE b.borrado = 0 AND b.nombre LIKE @Nombre " );

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("Nombre", nombre);

            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, param);

            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }
            return null;
        }

        private Barrio ObjectMapping(DataRow row)
        {
            Barrio oBarrio = new Barrio
            {
                IdBarrio = Convert.ToInt32(row["id_barrio"].ToString()),
                NombreBarrio = row["nombre"].ToString()
            };

            return oBarrio;
        }

        internal bool Create(Barrio barrio)
        {
            string strSql = String.Concat(" INSERT INTO Barrios (nombre, borrado) ",
                                          " VALUES (@NombreBarrio, 0) ");

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("NombreBarrio", barrio.NombreBarrio);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1);
        }

        internal bool Update(Barrio barrio)
        {
            var strSql = String.Concat(" UPDATE Barrios SET nombre = @NombreBarrio ",
                                       " WHERE borrado = 0 AND id_barrio = @IdBarrio ");

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("IdBarrio", barrio.IdBarrio);
            parametros.Add("NombreBarrio", barrio.NombreBarrio);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1);
        }

        internal bool Delete(Barrio barrio)
        {
            var strSql = String.Concat(" UPDATE Barrios SET borrado = 1 ",
                                       " WHERE id_barrio = " + barrio.IdBarrio.ToString(),
                                       " AND borrado = 0 ");

            return (DataManager.GetInstance().EjecutarSQL(strSql) == 1);
        }
    }
}
