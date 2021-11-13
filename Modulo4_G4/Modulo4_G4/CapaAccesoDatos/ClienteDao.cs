using Modulo4_G4.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Modulo4_G4.CapaAccesoDatos
{
    class ClienteDao
    {
        public IList<Cliente> GetAll()
        {
            List<Cliente> list = new List<Cliente>();

            var strSql = " SELECT c.id_cliente, c.cuit, c.razon_social, c.calle, c.numero, c.fecha_alta, c.id_barrio, c.id_contacto " +
                         " FROM Clientes c JOIN Barrios b ON c.id_barrio = b.id_barrio JOIN Contactos cn ON c.id_contacto = cn.id_contacto " +
                         " WHERE c.borrado = 0 ORDER BY c.razon_social ";
            
            var resultConsulta = DataManager.GetInstance().ConsultaSQL(strSql);
            foreach (DataRow row in resultConsulta.Rows)
            {
                list.Add(ObjectMapping(row));
            }
            return list;
        }

        public Cliente GetClienteById(int idCliente)
        {
            var strSql = String.Concat(" SELECT c.id_cliente, c.cuit, c.razon_social, c.calle, c.numero, c.fecha_alta, c.id_barrio, c.id_contacto ",
                                       " FROM Clientes c",
                                       " WHERE c.id_cliente = " + idCliente.ToString());
            //c.borrado = 0 AND 
            return ObjectMapping(DataManager.GetInstance().ConsultaSQL(strSql).Rows[0]);
        }

        private Cliente ObjectMapping(DataRow row)
        {   
            Cliente oCliente = new Cliente
            {
                IdCliente = Convert.ToInt32(row["id_cliente"].ToString()),
                Cuit = row["cuit"].ToString(),
                RazonSocial = row["razon_social"].ToString(),
                Calle = row["calle"].ToString(),
                NroCalle = Convert.ToInt32(row["numero"].ToString()),
                FechaAlta = Convert.ToDateTime(row["fecha_alta"].ToString())
            };
            BarrioDao barrio = new BarrioDao();
            oCliente.Barrio = barrio.GetBarrioById(Convert.ToInt32(row["id_barrio"].ToString()));
            ContactoDao contacto = new ContactoDao();
            oCliente.Contacto = contacto.GetContactoById(Convert.ToInt32(row["id_contacto"].ToString()));

            return oCliente;
        }

        public IList<Cliente> GetClienteByFilters(Dictionary<string, object> parametros)
        {
            List<Cliente> list = new List<Cliente>();
            var strSql = String.Concat(" SELECT c.id_cliente, ",
                                       "       c.cuit,",
                                       "       c.razon_social,",
                                       "       c.calle,",
                                       "       c.numero,",
                                       "       c.fecha_alta,",
                                       "       c.id_barrio,",
                                       "       b.nombre as barrio,",
                                       "       c.id_contacto,",
                                       "       cn.nombre as contacto ",
                                       " FROM Clientes c ",
                                       " LEFT JOIN Barrios b ON c.id_barrio = b.id_barrio ",
                                       " LEFT JOIN Contactos cn ON c.id_contacto = cn.id_contacto ",
                                       " WHERE c.borrado = 0 ");
            if (parametros.ContainsKey("IdCliente"))
                strSql += " AND (c.id_cliente=@IdCliente) ";
            if (parametros.ContainsKey("Cuit"))
                strSql += " AND (c.cuit=@Cuit) ";
            if (parametros.ContainsKey("RazonSocial"))
                strSql += " AND (c.razon_social LIKE '%' + @RazonSocial + '%' ) ";
            if (parametros.ContainsKey("Calle"))
                strSql += " AND (c.calle=@Calle) ";
            if (parametros.ContainsKey("NroCalle"))
                strSql += " AND (c.numero=@NroCalle) ";
            if (parametros.ContainsKey("FechaAlta"))
                strSql += " AND (c.fecha_alta=@FechaAlta)";
            if (parametros.ContainsKey("Barrio"))
                strSql += " AND (c.id_barrio=@Barrio)";
            if (parametros.ContainsKey("Contacto"))
                strSql += " AND (c.id_contacto=@Contacto)";
            strSql += " ORDER BY c.fecha_alta DESC";
            var resultConsulta = (DataRowCollection)DataManager.GetInstance().ConsultaSQL(strSql, parametros).Rows;
            if (resultConsulta.Count > 0)
            {
                foreach (DataRow row in resultConsulta)
                {
                    list.Add(ObjectMapping(row));
                }
            }
            return list;
        }

        internal bool Create(Cliente cliente)
        {
            string strSql = String.Concat(" INSERT INTO Clientes (cuit, razon_social, calle, numero, fecha_alta, id_barrio, id_contacto, borrado)",
                                          " VALUES (@Cuit, @RazonSocial, @Calle, @NroCalle, @FechaAlta, @IdBarrio, @IdContacto, 0)");

            Dictionary<string, object> parametros = new Dictionary<string, object>();

            parametros.Add("Cuit", cliente.Cuit);
            parametros.Add("RazonSocial", cliente.RazonSocial);
            parametros.Add("Calle", cliente.Calle);
            parametros.Add("NroCalle", cliente.NroCalle);
            parametros.Add("FechaAlta", cliente.FechaAlta);
            parametros.Add("IdBarrio", cliente.Barrio.IdBarrio);
            parametros.Add("IdContacto", cliente.Contacto.IdContacto);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1);
        }

        internal bool Update(Cliente cliente)
        {
            var strSql = String.Concat(" UPDATE Clientes SET cuit = @Cuit, razon_social = @RazonSocial, calle = @Calle, numero = @NroCalle, ",
                                       " fecha_alta = @FechaAlta, id_barrio = @IdBarrio, id_contacto = @IdContacto ",
                                       " WHERE borrado = 0 AND id_cliente = @IdCliente ");
            
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            parametros.Add("IdCliente", cliente.IdCliente);
            parametros.Add("Cuit", cliente.Cuit);
            parametros.Add("RazonSocial", cliente.RazonSocial);
            parametros.Add("Calle", cliente.Calle);
            parametros.Add("NroCalle", cliente.NroCalle);
            parametros.Add("FechaAlta", cliente.FechaAlta);
            parametros.Add("IdBarrio", cliente.Barrio.IdBarrio);
            parametros.Add("IdContacto", cliente.Contacto.IdContacto);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            return (DataManager.GetInstance().EjecutarSQL(strSql, parametros) == 1);
        }

        internal bool Delete(Cliente cliente)
        {
            var strSql = String.Concat(" UPDATE Clientes SET borrado = 1 ",
                                        " WHERE id_cliente = " + cliente.IdCliente.ToString(),
                                        " AND borrado = 0");

            return (DataManager.GetInstance().EjecutarSQL(strSql) == 1);
        }

    }
}