using Assignment.Common.Contracts;
using Assignment.Common.Repositories.Contracts;

namespace Assignment.Repositories.Contracts
{
    public interface IAuditableRepository<T> : IWriteRepository<T> where T : class, IEntity
    {
    }
}
