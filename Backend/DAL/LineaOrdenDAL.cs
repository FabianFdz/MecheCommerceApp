using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL
{
    public class LineaOrdenDAL : ILineaOrdenDAL
    {
        private UnidadDeTrabajo<LineasOrden> unidad;
        public bool Add(LineasOrden entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<LineasOrden>(new MecheDBContext()))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }

            }catch(Exception e)
            {
                return false;
            }
        }

        public LineasOrden Get(int id)
        {
            try
            {
                LineasOrden lineas;
                
                using (unidad = new UnidadDeTrabajo<LineasOrden>(new MecheDBContext()))
                {
                    lineas = unidad.genericDAL.Get(id);
                }
                return lineas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LineasOrden> GetAll()
        {
            try
            {
                IEnumerable<LineasOrden> lineas;
                using (unidad = new UnidadDeTrabajo<LineasOrden>(new MecheDBContext()))
                {
                    lineas = unidad.genericDAL.GetAll();
                }
                return lineas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(LineasOrden entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<LineasOrden>(new MecheDBContext()))
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

        public bool Update(LineasOrden entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<LineasOrden>(new MecheDBContext()))
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
