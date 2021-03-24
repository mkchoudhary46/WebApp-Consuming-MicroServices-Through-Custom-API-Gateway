using Assignment.Common.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Common.Repositories.Implementations
{
    public class DefaultDbContext : DbContext, IDbContext
    {
        public DefaultDbContext(string connectionString) 
        {
        }
        void IDbContext.SaveChanges()
        {
            base.SaveChanges();
        }

        void IDbContext.SetModified<T>(T entity)
        {
            var dbEntry = Entry<T>(entity);
            dbEntry.State = EntityState.Modified;
        }
    }
}
