using System;
using System.Collections.Generic;

#nullable disable

namespace Backend.Entities
{
    public partial class Orden
    {
        public Orden()
        {
            LineasOrdens = new HashSet<LineasOrden>();
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int DireccionCompleta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal PrecioTotal { get; set; }
        public string Estado { get; set; }
        public string FacturaHash { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<LineasOrden> LineasOrdens { get; set; }
    }
}
