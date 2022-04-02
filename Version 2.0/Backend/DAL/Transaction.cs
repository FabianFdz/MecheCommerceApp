using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL
{
    public class Transaction<T> : IDisposable where T : class
    {
        private readonly MecheDBContext context;
        public IGenericDAL<T> genericDAL;

        public Transaction()
        {
            context = new MecheDBContext();
            genericDAL = new GenericDAL<T>();
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
