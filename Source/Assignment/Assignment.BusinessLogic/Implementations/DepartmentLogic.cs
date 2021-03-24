using Assignment.BusinessLogic.Contracts;
using Assignment.Common.Helper;
using Assignment.Data;
using Assignment.Models;
using Assignment.Repositories.Contracts;
using AutoMapper;

namespace Assignment.BusinessLogic.Implementations
{
    public class DepartmentLogic : IDepartmentLogic
    {
        public IEmployeeRepository _employeeRepository;

        private readonly IMapper _mapper;

        public DepartmentLogic(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeViewModel GetEmployee(int id)
        {
            //var empDao = _employeeRepository.Get(id);

            return new EmployeeViewModel();
        }

        public void CreateEmployee(EmployeeRegisterModel model)
        {
            var passwordSalt = PasswordHelper.GenerateRandomSalt();

            var password = model.Password + passwordSalt;
            var passwordHash = PasswordHelper.Sha256_UnicodeHash(password);

            var dao = _mapper.Map<Employee>(model);
            dao.PasswordHash = passwordHash;
            dao.PasswordSalt = passwordSalt;

            //_employeeRepository.Insert(new Data.Employee()
            //{
            //    Email = model.Email,
            //    Contact = model.Contact
            //});
        }
    }
}
