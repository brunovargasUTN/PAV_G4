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


                //SELECT Ultimo ID Factura

                //SqlCommand selectUltimoIdFactura = new SqlCommand();
                //selectUltimoIdFactura.Connection = dbConnection;
                //selectUltimoIdFactura.CommandType = CommandType.Text;
                //selectUltimoIdFactura.Transaction = dbTransaction;
                //selectUltimoIdFactura.CommandText = string.Concat(" SELECT TOP 1 f.nro_factura   ",
                //                                                  " FROM Facturas f   ",
                //                                                  " ORDER BY f.nro_factura DESC   ");
                //var nroFactura = selectUltimoIdFactura.ExecuteScalar();



                //INSERT Factura
                SqlCommand insertFactura = new SqlCommand();
                insertFactura.Connection = dbConnection;
                insertFactura.CommandType = CommandType.Text;
                //Establece la instruccion a ejecutar

                insertFactura.CommandText = String.Concat(" INSERT INTO Facturas    ",
                                                            "   (nro_factura, id_cliente, fecha, id_usuario_creador, borrado ) ",
                                                            "   VALUES (@nro_factura, @id_cliente, @fecha, @id_usuario, @borrado ) ",
                                                            "   ");
                //Agregamos los parametros
                insertFactura.Parameters.AddWithValue("nro_factura",factura.NroFactura);
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
            
        }

        
    }
}
