using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Backend.DAL
{
    public interface IGenericDAL<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);
    }
}
