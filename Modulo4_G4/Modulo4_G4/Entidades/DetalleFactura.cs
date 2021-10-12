using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo4_G4.Entidades
{
    public class DetalleFactura
    {
        public int NroOrden { get; set; }
        public Proyecto Proyecto { get; set; }
        public Producto Producto { get; set; }
        public decimal Precio { get; set; }
    }
}
