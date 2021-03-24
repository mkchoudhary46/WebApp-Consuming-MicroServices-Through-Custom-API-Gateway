using Assignment.Models;
using System.Threading.Tasks;

namespace Assignment.BusinessLogic.Contracts
{
    public interface IEmployeeLogic
    {
        EmployeeViewModel GetEmployee(int id);

        Task RegisterEmployee(EmployeeRegisterModel model);
        Task<UserViewModel> FindByUsername(string username);
    }
}
