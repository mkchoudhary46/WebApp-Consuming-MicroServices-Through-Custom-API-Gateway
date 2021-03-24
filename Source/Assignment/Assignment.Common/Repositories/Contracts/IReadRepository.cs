using Assignment.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment.Common.Repositories.Contracts
{
    public interface IReadRepository<out T> where T : class, IEntity
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <value></value>
        IQueryable<T> All { get; }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T GetById(object id);


        /// <summary>
        /// get multiple records by ids
        /// </summary>
        /// <typeparam name="TId"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<T> GetByIds<TId>(IEnumerable<TId> ids);
    }
}
