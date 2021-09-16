using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo4_G4.Entidades
{
    public class Proyecto
    {
        public int IdProyecto { get; set; }
        public Producto Producto { get; set; }
        public string Descripcion { get; set; }
        public string Version { get; set; }
        public string Alcance { get; set; }
        public Usuario Responsable { get; set; }
    }
}
