using CrudTeste.Domain.Entities;
using CrudTeste.Domain.VOs.HumanResources;
using CrudTeste.Service.DTOs.Employee;

namespace CrudTeste.Service.Interfaces
{
    public interface IHumanResourcesService
    {
        Task<EmployeeDTO> GetEmployeeById(int id);

        Task<IEnumerable<EmployeeDTO>> GetAllEmployees();

        Task<EmployeeContactDTO> GetEmployeeContactById(int id);

        Task<EmployeeCompanyTimeDTO> GetEmployeeCompanyTimeById(int id);

        Task<IEnumerable<AverageEmployeePaymentDTO>> GetDepartmentsPayment();

        Task<IEnumerable<DepartmentsCostHistoryDTO>> GetDepartmentsCostHistoryById(int departmentId);
    }
}
