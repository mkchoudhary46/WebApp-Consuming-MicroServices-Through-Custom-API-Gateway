using Assignment.Common.Contracts;
using Assignment.Common.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Common.Repositories.Implementations
{
    public abstract class DefaultReadRepositoryBase<T> : IReadRepository<T> where T : class, IEntity
    {
        protected IDbContext DbContext { get; }
        internal DbSet<T> DbSet { get; }

        protected DefaultReadRepositoryBase(IDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        public virtual IQueryable<T> All => DbSet;

        public virtual T GetById(object id)
        {
            return All.FirstOrDefault(a => a.Id == id);
        }

        public virtual IQueryable<T> GetByIds<TId>(IEnumerable<TId> ids)
        {
            return All.Where(a => ids.Contains((TId)a.Id));
        }
    }
}
