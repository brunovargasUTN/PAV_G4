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
using System.Data.SqlClient;

namespace Modulo4_G4.CapaAccesoDatos
{
    public class UsuarioDao
    {
        public IList<Usuario> GetAll()
        {
            List<Usuario> listadoUsuarios = new List<Usuario>();

            String strSql = string.Concat("SELECT id_usuario,",
                                          "       id_perfil,",
                                          "       usuario,",
                                          "       password,",
                                          "       email, ",
                                          "       estado",
                                          "FROM Usuarios",
                                          "WHERE borrado = 0");

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoUsuarios.Add(ObjectMapping(row));
            }

            return listadoUsuarios;
        }
        public Usuario GetUser(string nombreUsuario)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String strSql = string.Concat("SELECT id_usuario,",
                                          "       id_perfil,",
                                          "       usuario,",
                                          "       password,",
                                          "       email, ",
                                          "       estado",
                                          "FROM Usuarios",
                                          "WHERE usuario = @usuario");

            var parametros = new Dictionary<string, object>();
            parametros.Add("usuario", nombreUsuario);
            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }

        public IList<Usuario> GetByFilters(Dictionary<string, object> parametros)
        {
            List<Usuario> lst = new List<Usuario>();
            String strSql = string.Concat("SELECT id_usuario,",
                                          "       id_perfil,",
                                          "       usuario,",
                                          "       password,",
                                          "       email, ",
                                          "       estado",
                                          "FROM Usuarios",
                                          "WHERE borrado = 0");

            if (parametros.ContainsKey("idPerfil"))
                strSql += "AND (id_perfil = @idPerfil) ";

            if (parametros.ContainsKey("usuario"))
                strSql += "AND (usuario LIKE '%' + @usuario + '%') ";

            var resultado = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }

        internal bool Create(Usuario oUsuario)
        {
            string strSql = "INSERT INTO Usuarios (id_perfil, usuario, password, email, estado, borrado)" +
                            "VALUES (@id_perfil, @usuario, @password, @email, @estado, 0)";

            var parametros = new Dictionary<string, object>();
            parametros.Add("id_perfil", oUsuario.Perfil);
            parametros.Add("usuario", oUsuario.NombreUsuario);
            parametros.Add("password", oUsuario.Password);
            parametros.Add("email", oUsuario.EmailUsuario);
            parametros.Add("estado", oUsuario.Estado);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1);

        }

        internal bool Update(Usuario oUsuario)
        {
            throw new NotImplementedException();
        }

        internal bool Delete(Usuario oUsuario)
        {
            throw new NotImplementedException();
        }

        private Usuario ObjectMapping(DataRow row)
        {
            Usuario oUsuario = new Usuario
            {
                IdUsuario = Convert.ToInt32(row["id_usuario"].ToString()),
                NombreUsuario = row["usuario"].ToString(),
                EmailUsuario = row["email"].ToString(),
                Password = row.Table.Columns.Contains("password") ? row["password"].ToString() : null,
                Perfil = Convert.ToInt32(row["id_perfil"].ToString())
            };

            return oUsuario;
        }

    }
}