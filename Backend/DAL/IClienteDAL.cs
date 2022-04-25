using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL
{
    public interface IClienteDAL : IGenericDAL<Cliente>
    {
        public Cliente GetByEmail(string email);
    }
}
