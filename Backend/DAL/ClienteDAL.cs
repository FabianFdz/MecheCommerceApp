using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL
{
    public class ClienteDAL : IClienteDAL
    {
        private UnidadDeTrabajo<Cliente> unidad;
        public bool Add(Cliente entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Cliente>(new MecheDBContext()))
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

        public Cliente Get(int id)
        {
            try
            {
                Cliente cliente;
                using (unidad = new UnidadDeTrabajo<Cliente>(new MecheDBContext()))
                {
                    cliente = unidad.genericDAL.Get(id);
                }
                return cliente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cliente GetByEmail(string email)
        {
            try
            {
                Cliente cliente;
                using (unidad = new UnidadDeTrabajo<Cliente>(new MecheDBContext()))
                {
                    cliente = unidad.context.Set<Cliente>().Where(cliente => cliente.Correo.Equals(email)).FirstOrDefault();
                }
                return cliente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            try
            {
                IEnumerable<Cliente> clientes;
                using (unidad = new UnidadDeTrabajo<Cliente>(new MecheDBContext()))
                {
                    clientes = unidad.genericDAL.GetAll();
                }
                return clientes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Cliente entity)
        {
            try
            {
                using(unidad = new UnidadDeTrabajo<Cliente>(new MecheDBContext()))
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

        public bool Update(Cliente entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Cliente>(new MecheDBContext()))
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
