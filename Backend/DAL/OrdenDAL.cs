using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL
{
    public class OrdenDAL : IOrdenDAL
    {
        private UnidadDeTrabajo<Orden> unidad;

        public bool Add(Orden entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Orden>(new MecheDBContext()))
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

        public Orden Get(int id)
        {
            try
            {
                Orden orden;
                using (unidad = new UnidadDeTrabajo<Orden>(new MecheDBContext()))
                {
                    orden = unidad.genericDAL.Get(id);
                    
                }
                return orden;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IEnumerable<Orden> GetAll()
        {
            try
            {
                IEnumerable<Orden> ordenes;
                using (unidad = new UnidadDeTrabajo<Orden>(new MecheDBContext()))
                {
                    ordenes = unidad.genericDAL.GetAll();
                }
                return ordenes;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool Remove(Orden entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Orden>(new MecheDBContext()))
                {
                    unidad.genericDAL.Remove(entity);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Orden entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Orden>(new MecheDBContext()))
                {
                    unidad.genericDAL.Update(entity);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
