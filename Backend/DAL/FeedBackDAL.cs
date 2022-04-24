using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL
{
    public class FeedBackDAL : IFeedback
    {
        private UnidadDeTrabajo<Feedback> unidad;
        private MecheDBContext mecheDBContext;

        public FeedBackDAL()
        {
            this.mecheDBContext = new MecheDBContext();
        }

        public bool Add(Feedback entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Feedback>(new MecheDBContext()))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Feedback Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Feedback entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Feedback entity)
        {
            throw new NotImplementedException();
        }
    }
}
