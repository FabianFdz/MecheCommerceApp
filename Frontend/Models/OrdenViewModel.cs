using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class OrdenViewModel
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int DireccionCompleta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal PrecioTotal { get; set; }
        public string Estado { get; set; }
        public List<LineaOrdenViewModel> LineasOrden { get; set; }
    }
}
