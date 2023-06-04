using AutoMapper;
using CrudTeste.Domain.Entities;
using CrudTeste.Domain.VOs.Employee;
using CrudTeste.Infrastructure.Repositories.Interfaces;
using CrudTeste.Service.DTOs.Employee;
using CrudTeste.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudTeste.Service
{
    public class HumanResourcesService : IHumanResourcesService
    {
        private readonly IHumanResourcesRepository _humanResourcesRepository;
        private readonly IMapper _mapper;

        public HumanResourcesService(IHumanResourcesRepository humanResourcesRepository,
            IMapper mapper )
        {
            _humanResourcesRepository = humanResourcesRepository;
            _mapper = mapper;
        }
        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            var employee = await _humanResourcesRepository.GetEmployeeDataById(id);
            var employeeData = _mapper.Map<EmployeeDTO>( employee);

            if(employee != null)
            {
                employeeData = new EmployeeDTO
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DepartmentID = employee.DepartmentID,
                    Name = employee.Name,
                    Rate = employee.Rate
                };            
            }

            return employeeData;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            var employeesData = await _humanResourcesRepository.GetEmployeesList();
            var employeesList = _mapper.Map<IEnumerable<EmployeeVO>, IEnumerable<EmployeeDTO>>(employeesData);

            return employeesList;
        }

        public async Task<EmployeeContactDTO> GetEmployeeContactById(int id)
        {
            var employee = await _humanResourcesRepository.GetEmployeeContactById(id);
            var employeeContact = _mapper.Map<EmployeeContactDTO>(employee);

            if(employee != null)
            {
                employeeContact = new EmployeeContactDTO
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    EmailAddress = employee.EmailAddress,
                    PhoneNumber = employee.PhoneNumber,
                    PhoneNumberTypeID = employee.PhoneNumberTypeID,
                    Name = employee.Name
                };
            }
            return employeeContact;       
        }     

    }
}
