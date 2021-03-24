using Assignment.Common.Contracts;
using System.Collections.Generic;

namespace Assignment.Common.Repositories.Contracts
{
    public interface IWriteRepository<T> : IReadRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Create(T entity);

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void CreateRange(IEnumerable<T> entities);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Deletes the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void DeleteRange(IEnumerable<T> entities);

        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();
    }
}
