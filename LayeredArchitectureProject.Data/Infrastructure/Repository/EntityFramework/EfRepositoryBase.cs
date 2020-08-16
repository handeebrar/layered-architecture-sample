using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitectureProject.Data.Infrastructure.Repository.EntityFramework
{
    public class EfRepositoryBase<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public EfRepositoryBase(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            dbContext.Entry(entity).State = EntityState.Added;
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public T Get(Expression<Func<T, bool>> filter = null)
        {
            return dbSet.AsQueryable().FirstOrDefault(filter);
        }

        public List<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? dbSet.AsQueryable().ToList() : dbSet.AsQueryable().Where(filter).ToList();
        }
    }
}
