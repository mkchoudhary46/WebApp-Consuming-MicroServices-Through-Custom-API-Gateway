using Assignment.Data;
using Assignment.Repositories.Common.Contracts;
using System.Threading.Tasks;

namespace Assignment.Repositories.Contracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee> GetByUserame(string username);
    }
}
