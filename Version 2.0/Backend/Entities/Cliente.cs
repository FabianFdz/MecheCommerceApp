using System;
using System.Collections.Generic;

#nullable disable

namespace Backend.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            Ordens = new HashSet<Orden>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }

        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
