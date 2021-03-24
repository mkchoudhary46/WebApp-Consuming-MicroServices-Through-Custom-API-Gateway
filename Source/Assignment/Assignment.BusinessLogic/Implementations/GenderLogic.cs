using Assignment.BusinessLogic.Contracts;
using Assignment.Common.Helper;
using Assignment.Data;
using Assignment.Models;
using Assignment.Repositories.Contracts;
using AutoMapper;

namespace Assignment.BusinessLogic.Implementations
{
    public class GenderLogic : IGenderLogic
    {
        public IGenderRepository _genderRepository;

        private readonly IMapper _mapper;

        public GenderLogic(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
        }

        public EmployeeViewModel GetGender(int id)
        {
            //var empDao = _genderRepository.GetById(id);

            return new EmployeeViewModel();
        }
    }
}
