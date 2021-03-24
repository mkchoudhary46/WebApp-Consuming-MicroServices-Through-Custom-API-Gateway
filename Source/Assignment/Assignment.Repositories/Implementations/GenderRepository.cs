using Assignment.Data;
using Assignment.Repositories.Common.Implementations;
using Assignment.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Assignment.Repositories.Implementations
{
    public class GenderRepository : GenericRepository<Gender>, IGenderRepository
    {
        public GenderRepository(ApplicationDBContext context) : base(context)
        {

        }

        public async Task<Gender> GetByName(string name)
        {
            var genders = FindByCondition(x => x.Name.Equals(name));
            return await genders.FirstOrDefaultAsync();
        }
    }
}
