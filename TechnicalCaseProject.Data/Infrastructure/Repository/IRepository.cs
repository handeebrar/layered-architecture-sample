using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LayeredArchitectureProject.Data.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Get(Expression<Func<T, bool>> filter = null);

        List<T> GetList(Expression<Func<T, bool>> filter = null);
    }
}
