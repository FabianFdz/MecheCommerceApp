using System;
using System.Collections.Generic;

#nullable disable

namespace Backend.Entities
{
    public partial class LineasOrden
    {
        public int Id { get; set; }
        public int IdOrden { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public virtual Orden IdOrdenNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
