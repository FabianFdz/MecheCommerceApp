using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioBase { get; set; }
    }
}
