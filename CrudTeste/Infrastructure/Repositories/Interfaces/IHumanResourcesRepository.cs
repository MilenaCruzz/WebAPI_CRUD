using CrudTeste.Domain.VOs;

namespace CrudTeste.Infrastructure.Repositories.Interfaces
{
    public interface IHumanResourcesRepository
    {
        Task<EmployeeVO> GetEmployeeDataById(int id);
    }
}
