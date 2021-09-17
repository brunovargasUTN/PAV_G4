
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modulo4_G4.Entidades;
using Modulo4_G4.CapaAccesoDatos;

namespace Modulo4_G4.CapaLogicaDeNegocio
{
    public class UsuarioService
    {
        private UsuarioDao oUsuarioDao;
        public UsuarioService()
        {
            oUsuarioDao = new UsuarioDao();
        }
        public IList<Usuario> ObtenerTodos()
        {
            return oUsuarioDao.GetAll();
        }
        public Usuario ValidarUsuario(string usuario, string password)
        {
            var usr = oUsuarioDao.GetUser(usuario);

            if (usr != null && usr.Password.Equals(password))
            {
                return usr;
            }

            return null;
        }

        internal bool CrearUsuario(Usuario oUsuario)
        {
            return oUsuarioDao.Create(oUsuario);
        }

        internal bool ActualizarUsuario(Usuario oUsuarioSelect)
        {
            return oUsuarioDao.Update(oUsuarioSelect);
        }

        internal bool EliminarUsuario(Usuario oUsuarioSelect)
        {
            return oUsuarioDao.Delete(oUsuarioSelect);
        }

        internal object ObtenerUsuario(string usuario)
        {
            return oUsuarioDao.GetUser(usuario);
        }

        internal IList<Usuario> ConsultarConFiltro(Dictionary<string, object> filtros)
        {
            return oUsuarioDao.GetByFilters(filtros);
        }
    }
}
