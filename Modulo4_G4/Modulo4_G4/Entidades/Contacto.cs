using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo4_G4.Entidades
{
    public class Contacto
    {
        public int IdContacto { get; set; }
        public string NombreContacto { get; set; }
        public string Apellido { get; set; }
        public string EmailContacto { get; set; }
        public int Telefono { get; set; }

        public override string ToString()
        {
            string str = NombreContacto.ToString() + " " + Apellido.ToString();
            return str;
        }
    }
}
