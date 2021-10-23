using Modulo4_G4.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Modulo4_G4.CapaAccesoDatos
{
    class DetalleFacturaDao
    {
        public IList<DetalleFactura> GetByIdFactura(int idFactura)
        {
            var strSql = string.Concat("    SELECT id_factura, nro_orden, id_producto, id_proyecto, precio  "
                                        , "  FROM FacturasDetalle    "
                                        , "  WHERE id_factura = " + idFactura + "   "
                                        , "  ORDER BY nro_orden DESC    ");

            List<DetalleFactura> detalles = new List<DetalleFactura>();

            var resultado = DataManager.GetInstance().ConsultaSQL(strSql);

            if(resultado.Rows.Count > 0)
            {
                foreach(DataRow row in resultado.Rows)
                {
                    detalles.Add(ObjectMapping(row));
                }
            }

            return detalles;
        }

        private DetalleFactura ObjectMapping(DataRow row)
        {
            DetalleFactura detalle = new DetalleFactura();
            detalle.NroOrden = Int32.Parse(row["nro_orden"].ToString());
            detalle.Precio = Decimal.Parse(row["precio"].ToString());
            detalle.Producto = new ProductoDao().GetById(Int32.Parse(row["id_producto"].ToString()));
            if (!string.IsNullOrEmpty(row["id_proyecto"].ToString()))
            {
                detalle.Proyecto = new ProyectoDao().GetByID(Int32.Parse(row["id_proyecto"].ToString()));
            }
            return detalle;
        }
    }
}
