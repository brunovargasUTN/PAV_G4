using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo4_G4.Entidades
{
    public class DetalleFactura
    {
        public int IdDetalleFactura { get; set; }
        public int IdFactura { get; set; }
        public int NroOrden { get; set; }
        public int IdProyecto { get; set; }
        public int IdProducto { get; set; }
        public int Precio { get; set; }
    }
}
