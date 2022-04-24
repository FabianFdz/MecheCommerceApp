using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }
        public int? IdProducto { get; set; }
        public List<Producto> Productos { get; set; }
        public string Comentario { get; set; }
        public int Calificacion { get; set; }
    }
}
