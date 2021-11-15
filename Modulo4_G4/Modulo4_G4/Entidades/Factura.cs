using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo4_G4.Entidades
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public int NroFactura { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public Usuario UsuarioCreador { get; set; }

        public IList<DetalleFactura> DetalleFacturas { get; set; }

        public decimal TotalFactura
        {
            get
            {
                decimal total = 0;
                foreach (var detalle in DetalleFacturas)
                {
                    total += detalle.Precio;
                }
                return total;
            }
        }
    }
}
