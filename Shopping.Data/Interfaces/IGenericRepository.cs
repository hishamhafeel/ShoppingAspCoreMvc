using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Delete(object id);
        void Update(TEntity entity);

        TEntity GetById(object id);
        IEnumerable<TEntity> GetAll();
    }
}
