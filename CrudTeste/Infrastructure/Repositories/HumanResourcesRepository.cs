using CrudTeste.Infrastructure.Repositories.Interfaces;
using CrudTeste.Infrastructure.DbConnection;
using System.Data;
using Dapper;
using CrudTeste.Domain.VOs;
using System.Data.Common;
using CrudTeste.Domain.Entities;

namespace CrudTeste.Infrastructure.Repositories
{
    public class HumanResourcesRepository : IHumanResourcesRepository
    {
        private readonly DbSession _dbSession;

            public HumanResourcesRepository(DbSession dbSession) 
             {
                _dbSession = dbSession;
             }

        public async Task<EmployeeVO> GetEmployeeDataById(int id)
        {
            using(IDbConnection connection = _dbSession.Connection)
            {
                string query = $@"SELECT [Employee].[BusinessEntityID], 
                                [FirstName], [LastName], [DepartmentH].[DepartmentID], [Name], ROUND(Rate, 2) AS Rate
                                FROM [Person].[Person] AS Employee
                                INNER JOIN [HumanResources].[EmployeeDepartmentHistory] AS DepartmentH
                                ON [Employee].[BusinessEntityID] = [DepartmentH].[BusinessEntityID]
                                INNER JOIN [HumanResources].[Department] AS Department
                                ON [Department].[DepartmentID] = [DepartmentH].[DepartmentID]
                                INNER JOIN [HumanResources].[EmployeePayHistory] 
                                ON [Employee].[BusinessEntityID] = [EmployeePayHistory].[BusinessEntityID]
                                WHERE [Employee].[BusinessEntityID] = {id}";

                 var res =   await connection.QueryFirstOrDefaultAsync<EmployeeVO>(query);
                return res;
               
            }
          

            
        }
    }
}
