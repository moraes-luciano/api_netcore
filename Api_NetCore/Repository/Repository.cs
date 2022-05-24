using System;
using System.Linq;
using System.Linq.Expressions;
using Api_NetCore.Data;
using Microsoft.EntityFrameworkCore;

namespace Api_NetCore.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<T> Get()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().SingleOrDefault(predicate);
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
    } 
}