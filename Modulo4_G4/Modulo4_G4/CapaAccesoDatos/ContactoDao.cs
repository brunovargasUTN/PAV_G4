
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

            var strSql = "SELECT id_contacto, nombre, apellido, email, telefono FROM Contactos";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoContactos.Add(ObjectMapping(row));
            }

            return listadoContactos;

        }
        public Contacto GetContactoById(int idContacto)
        {
            var strSql = String.Concat("SELECT id_contacto, nombre, apellido, email, telefono",
                                       "FROM Contactos",
                                       "WHERE c.id_cliente = " + idContacto.ToString());

            return ObjectMapping(DataManager.GetInstance().ConsultaSQL(strSql).Rows[0]);
        }

        private Contacto ObjectMapping(DataRow row)
        {
            Contacto oContacto = new Contacto
            {
                IdContacto = Convert.ToInt32(row["id_contacto"].ToString()),
                NombreContacto = row["nombre"].ToString(),
                Apellido = row["apellido"].ToString(),
                EmailContacto = row["email"].ToString()
            };

            return oContacto;
        }
    }
}
