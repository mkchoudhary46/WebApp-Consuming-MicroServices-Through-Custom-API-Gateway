using System;
using System.Linq;
using System.Linq.Expressions;

namespace Assignment.Repositories.Common.Contracts
{
    public interface IGenericRepository<T> 
    {
       // IEnumerable<T> GetAll();
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        //T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
