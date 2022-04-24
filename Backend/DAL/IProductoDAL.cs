using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL
{
    public interface IProductoDAL : IGenericDAL<Producto>
    {
        public IEnumerable<Producto> GetIDS(List<int> productosid);
    }
}
