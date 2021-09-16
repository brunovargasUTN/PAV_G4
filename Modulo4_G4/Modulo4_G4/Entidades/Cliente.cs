using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo4_G4.Entidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public int Cuit { get; set; }
        public string RazonSocial { get; set; }
        public string Calle { get; set; }
        public int NroCalle { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IdBarrio { get; set; }
        public int IdContacto { get; set; }
    }
}
