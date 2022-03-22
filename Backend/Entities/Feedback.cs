using System;
using System.Collections.Generic;

#nullable disable

namespace Backend.Entities
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string Comentario { get; set; }
        public int Calificacion { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
    }
}
