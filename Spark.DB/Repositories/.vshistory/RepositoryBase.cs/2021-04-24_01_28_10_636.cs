﻿using Spark.DB.Repositories.AplicationUserRepository;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Spark.DB.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly IAplicationUserRepository _aplicationUserRepository;

        public RepositoryBase(IAplicationUserRepository aplicationUserRepository)
        {
            _aplicationUserRepository = aplicationUserRepository;
        }

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
            !trackChanges ? RepositoryContext.Set<T>().AsNoTracking() : RepositoryContext.Set<T>();
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
