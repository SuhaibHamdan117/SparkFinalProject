using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Spark.DB.Models.DBModels
{
    public class RepositoryBase<T> : IRepositoryBase<T>
    {
        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
