
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Modulo4_G4.Entidades;
using System.Data;


namespace Modulo4_G4.CapaAccesoDatos
{
    public class ContactoDao
    {
        public IList<Contacto> GetAll()
        {
            List<Contacto> listadoContactos = new List<Contacto>();

            var strSql = "SELECT id_contacto, nombre, apellido, email, telefono FROM Contactos WHERE borrado = 0 ORDER BY apellido, nombre ";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoContactos.Add(ObjectMapping(row));
            }

            return listadoContactos;

        }

        internal bool Create(Contacto oContacto)
        {
            var strSql = String.Concat("INSERT INTO Contactos (nombre, apellido, email, telefono, borrado)",
                                       "VALUES (@Nombre, @Apellido, @Email, @Telefono, 0)");

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("Nombre", oContacto.NombreContacto);
            parametros.Add("Apellido", oContacto.Apellido);
            parametros.Add("Email", oContacto.EmailContacto);
            parametros.Add("Telefono", oContacto.Telefono);

            return DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1;
        }

        internal bool Update(Contacto oContacto)
        {
            var strSql = String.Concat("UPDATE Contactos ",
                                       "SET nombre = @Nombre,",
                                       "  apellido = @Apellido,",
                                       "     email = @Email,",
                                       "  telefono = @Telefono ",
                                       "WHERE id_contacto = @IdContacto ");

            var parametros = new Dictionary<string, object>();

            parametros.Add("IdContacto", oContacto.IdContacto);
            parametros.Add("Nombre", oContacto.NombreContacto);
            parametros.Add("Apellido", oContacto.Apellido);
            parametros.Add("Email", oContacto.EmailContacto);
            parametros.Add("Telefono", oContacto.Telefono);

            return DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1;

        }

        internal bool Delete(Contacto oContacto)
        {
            var strSql = String.Concat("UPDATE Contactos SET borrado = 1 ",
                                       "WHERE id_contacto = " + oContacto.IdContacto.ToString());
            return (DataManager.GetInstance().EjecutarSQL(strSql) == 1);
        }

        public IList<Contacto> GetByFilters(Dictionary<string, object> parametros)
        {
            List<Contacto> listadoContactos = new List<Contacto>();
            var strSql = string.Concat("    SELECT id_contacto, nombre, apellido, email, telefono ",
                                       "    FROM Contactos WHERE borrado = 0 ");

            if (parametros.ContainsKey("Nombre"))
            {
                strSql += " AND (nombre LIKE '%' + @nombre + '%') ";
            }
            if (parametros.ContainsKey("Apellido"))
            {
                strSql += " AND (apellido LIKE '%' + @apellido + '%') ";
            }
            if (parametros.ContainsKey("Email"))
            {
                strSql += " AND email = @Email ";
            }
            if (parametros.ContainsKey("Telefono"))
            {
                strSql += " AND telefono = @Telefono ";
            }

            strSql += " ORDER BY apellido, nombre ";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoContactos.Add(ObjectMapping(row));
            }

            return listadoContactos;
        }

        public Contacto GetContactoById(int idContacto)
        {
            var strSql = String.Concat(" SELECT id_contacto, nombre, apellido, email, telefono ",
                                       " FROM Contactos ",
                                       " WHERE id_contacto = " + idContacto.ToString());

            //System.IndexOutOfRangeException: 'There is no row at position 0.'
            return ObjectMapping(DataManager.GetInstance().ConsultaSQL(strSql).Rows[0]);
        }

        private Contacto ObjectMapping(DataRow row)
        {
            Contacto oContacto = new Contacto
            {
                IdContacto = Convert.ToInt32(row["id_contacto"].ToString()),
                NombreContacto = row["nombre"].ToString(),
                Apellido = row["apellido"].ToString(),
                EmailContacto = row["email"].ToString(),
                Telefono = row["telefono"].ToString(),
            };

            return oContacto;
        }
    }
}
