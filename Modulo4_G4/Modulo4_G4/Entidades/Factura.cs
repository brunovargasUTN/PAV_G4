using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo4_G4.Entidades
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public int NroFactura { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuarioCreador { get; set; }
    }
}
