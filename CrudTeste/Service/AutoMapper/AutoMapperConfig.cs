using AutoMapper;
using CrudTeste.Domain.Entities;
using CrudTeste.Domain.VOs.Employee;
using CrudTeste.Domain.VOs.HumanResources;
using CrudTeste.Service.DTOs.Employee;
using CrudTeste.Service.DTOs.User;

namespace CrudTeste.Service.AutoMapper
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<EmployeeVO, EmployeeDTO>();
            CreateMap<EmployeeDTO, EmployeeVO>();
            CreateMap<EmployeeContactVO, EmployeeContactDTO>();
            CreateMap<EmployeeContactDTO, EmployeeContactVO>();
            CreateMap<EmployeeCompanyTimeVO, EmployeeCompanyTimeDTO>();
            CreateMap<EmployeeCompanyTimeDTO, EmployeeCompanyTimeVO>();
            CreateMap<AverageEmployeePaymentVO, AverageEmployeePaymentDTO>();
            CreateMap<AverageEmployeePaymentDTO, AverageEmployeePaymentVO>();
            CreateMap<DepartmentsCostHistoryVO, DepartmentsCostHistoryDTO>();
            CreateMap<DepartmentsCostHistoryDTO, DepartmentsCostHistoryVO>();

        }


    }
}
