using Assignment.Data;
using Assignment.Models;
using AutoMapper;

namespace Assignment.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeViewModel>();
            
            CreateMap<EmployeeRegisterModel, Employee>()
                .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.Contact, opt => opt.MapFrom(src => src.Contact))
                .ForMember(x => x.Salary, opt => opt.MapFrom(src => src.Salary))
                .ForAllOtherMembers(x => x.Ignore())
                ;

            CreateMap<Employee, UserViewModel>()
                 .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.Contact, opt => opt.MapFrom(src => src.Contact))
                .ForMember(x => x.Salary, opt => opt.MapFrom(src => src.Salary))
                .ForMember(x => x.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(x => x.GenderId, opt => opt.MapFrom(src => src.GenderId))
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(x => x.PasswordSalt, opt => opt.MapFrom(src => src.PasswordSalt))
                ;

            CreateMap<Employee, EmployeeViewModel>()
               .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(x => x.Contact, opt => opt.MapFrom(src => src.Contact))
              .ForMember(x => x.Salary, opt => opt.MapFrom(src => src.Salary))
              .ForMember(x => x.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
              .ForMember(x => x.GenderId, opt => opt.MapFrom(src => src.GenderId))
              ;

        }
    }
}
