using CrudTeste.Domain.Entities;
using CrudTeste.Domain.VOs.Employee;
using CrudTeste.Domain.VOs.HumanResources;

namespace CrudTeste.Infrastructure.Repositories.Interfaces
{
    public interface IHumanResourcesRepository
    {
        Task<EmployeeVO> GetEmployeeDataById(int id);

        Task<IEnumerable<EmployeeVO>> GetEmployeesList();

        Task<EmployeeContactVO> GetEmployeeContactById(int id);

        Task<EmployeeCompanyTimeVO> GetEmployeeCompanyTimeById(int id);

        Task<IEnumerable<AverageEmployeePaymentVO>> AverageDepartmentsPayment();

        Task<IEnumerable<DepartmentsCostHistoryVO>> DepartmentCostById(int departmentId);
    }
}
