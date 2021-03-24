using Assignment.Data;
using Assignment.Repositories.Common.Implementations;
using Assignment.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Repositories.Implementations
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDBContext context) :base(context)
        {

        }

        public async Task<Employee> GetByUserame(string username)
        {
            var employees = FindByCondition(x => x.Email.Equals(username));
            return await employees.FirstOrDefaultAsync();
        }
    }
}
