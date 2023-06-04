using CrudTeste.Domain.Entities;
using CrudTeste.Domain.Model.HumanResources;
using CrudTeste.Domain.VOs.HumanResources;
using CrudTeste.Service.DTOs.Employee;

namespace CrudTeste.Service.Interfaces
{
    public interface IHumanResourcesService
    {
        Task<EmployeeDTO> GetEmployeeById(int id);

        Task<IEnumerable<EmployeeDTO>> GetAllEmployees();

        Task<EmployeeContactDTO> GetEmployeeContactById(int id);
    }
}
