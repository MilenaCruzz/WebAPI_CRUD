using CrudTeste.Domain.Entities;
using CrudTeste.Domain.VOs.Employee;

namespace CrudTeste.Infrastructure.Repositories.Interfaces
{
    public interface IHumanResourcesRepository
    {
        Task<EmployeeVO> GetEmployeeDataById(int id);

        Task<IEnumerable<EmployeeVO>> GetEmployeesList();

        Task<EmployeeContactVO> GetEmployeeContactById(int id);
    }
}
