using CrudTeste.Service.DTOs.Employee;

namespace CrudTeste.Service.Interfaces
{
    public interface IHumanResourcesService
    {
        Task<EmployeeDTO> GetEmployeeById(int id);
    }
}
