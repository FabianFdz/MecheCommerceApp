using System;
using System.Collections.Generic;

#nullable disable

namespace Backend.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            Feedbacks = new HashSet<Feedback>();
            LineasOrdens = new HashSet<LineasOrden>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioBase { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<LineasOrden> LineasOrdens { get; set; }
    }
}
