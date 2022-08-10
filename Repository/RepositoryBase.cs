using System;
using System.Linq.Expressions;
using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public abstract class RepositoryBase<T>: IRepositoryBase<T> where T: class
    {
        protected RepositoryContext dbContext { get; set; }

        public RepositoryBase(RepositoryContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(T entity)
        {
            this.dbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.dbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return this.dbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.dbContext.Set<T>().Where(expression).AsNoTracking();
        }

        
    }
}

