using AutoMapper;
using CrudTeste.Infrastructure.Repositories.Interfaces;
using CrudTeste.Service.DTOs.Employee;
using CrudTeste.Service.Interfaces;

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

    }
}
