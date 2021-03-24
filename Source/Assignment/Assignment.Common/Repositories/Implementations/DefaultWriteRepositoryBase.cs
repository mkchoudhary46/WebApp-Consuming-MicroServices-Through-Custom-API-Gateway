using Assignment.Common.Contracts;
using Assignment.Common.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Common.Repositories.Implementations
{
    public abstract class DefaultWriteRepositoryBase<T> : DefaultReadRepositoryBase<T>, IWriteRepository<T> where T : class, IEntity
    {
        protected DefaultWriteRepositoryBase(IDbContext dbContext) : base(dbContext)
        {
            //dbContext.AutoDetectChanges = true;
        }

        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            DbSet.Add(entity);
        }

        public virtual void CreateRange(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            DbSet.AddRange(entities);
        }

        public virtual void Update(T entity)
        {
            ValidateEntity(entity);
            DbContext.SetModified<T>(entity);
        }

        private static void ValidateEntity(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }

        public virtual void Delete(T entity)
        {
            ValidateEntity(entity);
            DbSet.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            DbSet.RemoveRange(entities);
        }

        public virtual void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
