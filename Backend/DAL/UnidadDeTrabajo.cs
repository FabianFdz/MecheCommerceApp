using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL
{
    public class UnidadDeTrabajo<T> : IDisposable where T : class
    {
        public MecheDBContext context;
        
        public IGenericDAL<T> genericDAL;

        public UnidadDeTrabajo(MecheDBContext _context)
        {
            context = _context;
            genericDAL = new GenericDAL<T>(context);
        }
        public bool Complete()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return false;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
