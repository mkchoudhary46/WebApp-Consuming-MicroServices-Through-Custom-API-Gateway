using Assignment.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Assignment.Common.Repositories.Contracts
{
    public interface IDbContext
    {
        void SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void SetModified<T>(T entity) where T : class, IEntity;
        //bool AutoDetectChanges { get; set; }
        //bool FlushEntriesOnException { get; set; }
        //void ExecuteSqlCommand(string sql, params object[] parameters);
        //bool DisableInterceptors { get; set; }
    }
}
