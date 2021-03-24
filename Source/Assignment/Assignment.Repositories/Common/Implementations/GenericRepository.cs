using Assignment.Data;
using Assignment.Repositories.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Assignment.Repositories.Common.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext context;
        private readonly DbSet<T> entities;
        public GenericRepository(ApplicationDBContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        //public T Get(int id)
        //{
        //    return entities.SingleOrDefault(s => s == id);
        //}
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);

            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public IQueryable<T> FindAll()
        {
            return entities;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return entities.Where(expression);
        }
    }
}
