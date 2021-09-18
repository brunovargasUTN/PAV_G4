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
            var strSql = "SELECT b.id_barrio, b.nombre FROM Barrios b";
            var resultConsulta = DataManager.GetInstance().ConsultaSQL(strSql);
            foreach (DataRow row in resultConsulta.Rows)
            {
                list.Add(ObjectMapping(row));
            }
            return list;
        }

        public Barrio GetBarrioById(int idBarrio)
        {
            var strSql = String.Concat("SELECT b.id_barrio, ",
                                       "       b.nombre,",
                                       "FROM Barrios b,",
                                       "WHERE b.id_barrio = " + idBarrio.ToString());
            return ObjectMapping(DataManager.GetInstance().ConsultaSQL(strSql).Rows[0]);

        }

        public Barrio GetBarrioByNombre(string Nombre)
        {
            var strSql = String.Concat("SELECT b.id_barrio, ",
                                       "       b.nombre,",
                                       "FROM Barrios b,",
                                       "WHERE b.nombre LIKE '%' + @Nombre + '%' " );
            return ObjectMapping(DataManager.GetInstance().ConsultaSQL(strSql).Rows[0]);
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
    }
}
