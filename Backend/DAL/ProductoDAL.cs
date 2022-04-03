using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL
{
    public class ProductoDAL : IProductoDAL
    {
        private UnidadDeTrabajo<Producto> unidad;
        public bool Add(Producto entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Producto>(new MecheDBContext()))
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

        public Producto Get(int id)
        {
            try
            {
                Producto producto;
                using (unidad = new UnidadDeTrabajo<Producto>(new MecheDBContext()))
                {
                    producto = unidad.genericDAL.Get(id);
                }
                return producto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Producto> GetIDS(List<int> productosid )
        {
            try
            {
                Producto producto;
                using (unidad = new UnidadDeTrabajo<Producto>(new MecheDBContext()))
                {
                    unidad.
                }
                return producto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Producto> GetAll()
        {
            try
            {
                IEnumerable<Producto> productos;
                using (unidad = new UnidadDeTrabajo<Producto>(new MecheDBContext()))
                {
                    productos = unidad.genericDAL.GetAll();
                }
                return productos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Producto entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Producto>(new MecheDBContext()))
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

        public bool Update(Producto entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Producto>(new MecheDBContext()))
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
