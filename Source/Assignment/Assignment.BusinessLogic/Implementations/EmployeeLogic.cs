using Assignment.BusinessLogic.Contracts;
using Assignment.Common.Helper;
using Assignment.Data;
using Assignment.Models;
using Assignment.Repositories.Contracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.BusinessLogic.Implementations
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly IDepartmentRepository _departmentRepository;


        private readonly IMapper _mapper;

        public EmployeeLogic(
            IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,
           IGenderRepository genderRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _genderRepository = genderRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public EmployeeViewModel GetEmployee(int id)
        {
            var empDao = _employeeRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            return _mapper.Map<EmployeeViewModel>(empDao);
        }

        public async Task RegisterEmployee(EmployeeRegisterModel model)
        {
            var existingEmployee = await _employeeRepository.GetByUserame(model.Email);
            if (existingEmployee != null)
                throw new System.Exception("User already exists!!");

            var passwordSalt = PasswordHelper.GenerateRandomSalt();
            var password = model.Password + passwordSalt;
            var passwordHash = PasswordHelper.Sha256_UnicodeHash(password);
            var dao = _mapper.Map<Employee>(model);
            dao.PasswordHash = passwordHash;
            dao.PasswordSalt = passwordSalt;

            var existingDept = await _departmentRepository.FindByCondition(x => x.Name.Equals(model.Department)).FirstOrDefaultAsync();
            if (existingDept == null)
            {
                var department = new Department() { Name = model.Department };
                _departmentRepository.Insert(department);
                dao.DepartmentId = department.Id;
            }
            else
            {
                dao.DepartmentId = existingDept.Id;
            }

            var existingGender = await _genderRepository.FindByCondition(x => x.Name.Equals(model.Gender)).FirstOrDefaultAsync();
            if (existingGender == null)
            {
                var gender = new Gender() { Name = model.Gender };
                _genderRepository.Insert(gender);
                dao.GenderId = gender.Id;
            }
            else
            {
                dao.GenderId = existingGender.Id;
            }
            _employeeRepository.Insert(dao);
        }

        public async Task<UserViewModel> FindByUsername(string username)
        {
            var existingEmployee =await  _employeeRepository.GetByUserame(username);

            if (existingEmployee != null)
            {
                return _mapper.Map<UserViewModel>(existingEmployee);
            }
            return null;
        }

       
    }
}
