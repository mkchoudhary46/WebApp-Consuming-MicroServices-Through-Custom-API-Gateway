using Assignment.Data;
using Assignment.Repositories.Common.Implementations;
using Assignment.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Assignment.Repositories.Implementations
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDBContext context) :base(context)
        {

        }

        public async Task<Department> GetByName(string name)
        {
            var depts = FindByCondition(x => x.Name.Equals(name));
            return await depts.FirstOrDefaultAsync();
        }
    }
}
