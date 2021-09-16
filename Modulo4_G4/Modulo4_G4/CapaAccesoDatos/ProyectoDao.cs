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
            List<Proyecto> listadoBugs = new List<Proyecto>();

            var strSql = "SELECT p.id_proyecto, p.id_producto, p.descripcion, p.version, p.alcance, p.id_responsable from Proyectos p JOIN Usuarios u ON "+
                           " p.id_usuario = u.id_usuario";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoBugs.Add(ObjectMapping(row));
            }

            return listadoBugs;
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

            return oProyecto;
        }
    }
}

