using Modulo4_G4.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace Modulo4_G4.CapaAccesoDatos
{
    class FacturaDao
    {
        internal bool Create(Factura factura)
        {
            var string_conexion = "Data Source=.\\SQLEXPRESS;Initial Catalog=TPI_G4_Modulo_4;Integrated Security=true;";

            SqlConnection dbConnection = new SqlConnection();
            SqlTransaction dbTransaction = null;

            try
            {
                dbConnection.ConnectionString = string_conexion;
                dbConnection.Open();
                //Genero la transaccion
                dbTransaction = dbConnection.BeginTransaction();


                //SELECT Ultimo NRO-Factura Factura

                SqlCommand selectUltimoNroFactura = new SqlCommand();
                selectUltimoNroFactura.Connection = dbConnection;
                selectUltimoNroFactura.CommandType = CommandType.Text;
                selectUltimoNroFactura.Transaction = dbTransaction;
                selectUltimoNroFactura.CommandText = string.Concat(" SELECT TOP 1 f.nro_factura   ",
                                                                  " FROM Facturas f   ",
                                                                  " ORDER BY f.nro_factura DESC   ");

                factura.NroFactura = Int32.Parse(selectUltimoNroFactura.ExecuteScalar().ToString())+1;



                //INSERT Factura
                SqlCommand insertFactura = new SqlCommand();
                insertFactura.Connection = dbConnection;
                insertFactura.CommandType = CommandType.Text;
                insertFactura.Transaction = dbTransaction;
                //Establece la instruccion a ejecutar

                insertFactura.CommandText = String.Concat(" INSERT INTO Facturas    ",
                                                            "   (nro_factura, id_cliente, fecha, id_usuario_creador, borrado ) ",
                                                            "   VALUES (@nro_factura, @id_cliente, @fecha, @id_usuario, @borrado ) ",
                                                            "   ");
                //Agregamos los parametros
                insertFactura.Parameters.AddWithValue("nro_factura", factura.NroFactura);
                insertFactura.Parameters.AddWithValue("id_cliente", factura.Cliente.IdCliente);
                insertFactura.Parameters.AddWithValue("fecha", factura.Fecha);
                insertFactura.Parameters.AddWithValue("id_usuario", factura.UsuarioCreador.IdUsuario);
                insertFactura.Parameters.AddWithValue("borrado", 0);

                insertFactura.ExecuteNonQuery();

                //Obtenemos el ultimo ID de factura

                SqlCommand consultaIdFactura = new SqlCommand();
                consultaIdFactura.Connection = dbConnection;
                consultaIdFactura.CommandType = CommandType.Text;

                insertFactura.CommandText = "SELECT @@IDENTITY";
                var ultimoID = insertFactura.ExecuteScalar();
                factura.IdFactura = Convert.ToInt32(ultimoID);
                int nroOrden = 0;

                //Insert DetalleFactura
                foreach( var itemFactura in factura.DetalleFacturas)
                {
                    //INSERT FACTURA
                    SqlCommand insertDetalle = new SqlCommand();
                    insertDetalle.Connection = dbConnection;
                    insertDetalle.CommandType = CommandType.Text;
                    insertDetalle.Transaction = dbTransaction;
                    insertDetalle.CommandText = String.Concat("     INSERT INTO FacturasDetalle ",
                                                                "  ( id_factura, nro_orden, id_producto, id_proyecto, precio, borrado ) ",
                                                                "   VALUES ( @id_factura, @nro_orden, @id_producto, @id_proyecto, @precio, @borrado) ");
                    insertDetalle.Parameters.AddWithValue("id_factura",ultimoID);
                    insertDetalle.Parameters.AddWithValue("nro_orden", ++nroOrden);
                    insertDetalle.Parameters.AddWithValue("id_producto", itemFactura.Producto.IdProducto);
                    if(itemFactura.Proyecto != null)
                    {
                        insertDetalle.Parameters.AddWithValue("id_proyecto", itemFactura.Proyecto.IdProyecto);
                    }
                    else
                    {
                        insertDetalle.Parameters.AddWithValue("id_proyecto", DBNull.Value);
                    }
                    insertDetalle.Parameters.AddWithValue("precio", itemFactura.Precio);
                    insertDetalle.Parameters.AddWithValue("borrado", 0);

                    insertDetalle.ExecuteNonQuery();

                }

                dbTransaction.Commit();
                return true;
            }
            catch(Exception ex)
            {
                dbTransaction.Rollback();
                throw ex;
            }
            finally
            {
                dbConnection.Close();
            }
            
        }

        internal List<Factura> GetByFilters(Dictionary<string, object> parametros)
        {
            var strSql = string.Concat("    SELECT DISTINCT F.id_factura, F.nro_factura, F.id_cliente, F.fecha, F.id_usuario_creador   ",
                                        "   FROM Facturas F JOIN Clientes C ON F.id_cliente = C.id_cliente  ",
                                        "        JOIN FacturasDetalle FD ON F.id_factura = FD.id_factura    ",
                                        "   WHERE 1 = 1    "
                                        );
            if (parametros.ContainsKey("nroFactura"))
            {
                strSql += " AND F.nro_factura = @nroFactura  ";
            }
            if (parametros.ContainsKey("cuit"))
            {
                strSql += " AND C.cuit = @cuit  ";
            }
            if (parametros.ContainsKey("idProducto"))
            {
                strSql += " AND @idProducto IN (SELECT id_producto   FROM FacturasDetalle    WHERE id_factura = FD.id_factura )  ";
            }
            if (parametros.ContainsKey("idUsuario"))
            {
                strSql += " AND F.id_usuario_creador = @idUsuario  ";
            }
            if(parametros.ContainsKey("fechaDesde") && parametros.ContainsKey("fechaHasta"))
            {
                strSql += " AND F.fecha BETWEEN @fechaDesde AND @fechaHasta  ";
            }
            else if (parametros.ContainsKey("fechaDesde"))
            {
                strSql += " AND F.fecha > @fechaDesde   ";
            }
            else if (parametros.ContainsKey("fechaHasta"))
            {
                strSql += " AND F.fecha < @fechaHasta   ";
            }
            strSql += " ORDER BY F.fecha DESC   ";

            List<Factura> facturas = new List<Factura>();

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql, parametros);

            if (resultadoConsulta.Rows.Count > 0)
            {
                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    facturas.Add(ObjectMapping(row));
                }
            }
            return facturas;

        }

        public IList<Factura> GetAll() {
            var strSql = string.Concat("    SELECT id_factura, nro_factura, id_cliente, fecha, id_usuario_creador   ",
                                        "   FROM Facturas   ORDER BY fecha DESC");
            List<Factura> facturas = new List<Factura>();

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            if (resultadoConsulta.Rows.Count > 0)
            {
                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    facturas.Add(ObjectMapping(row));
                }
            }
            return facturas;
        }


        private Factura ObjectMapping(DataRow row)
        {
            Factura factura = new Factura();
            factura.IdFactura = Int32.Parse(row["id_factura"].ToString());
            factura.NroFactura = Int32.Parse(row["nro_factura"].ToString());
            factura.Cliente = new ClienteDao().GetClienteById(Int32.Parse(row["id_cliente"].ToString()));
            factura.Fecha = DateTime.Parse(row["fecha"].ToString());
            factura.UsuarioCreador = new UsuarioDao().GetById(Int32.Parse(row["id_usuario_creador"].ToString()));
            factura.DetalleFacturas = new DetalleFacturaDao().GetByIdFactura(factura.IdFactura);
            return factura; ;
        }
        
    }
}
