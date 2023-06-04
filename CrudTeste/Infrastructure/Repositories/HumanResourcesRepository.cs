using CrudTeste.Infrastructure.Repositories.Interfaces;
using CrudTeste.Infrastructure.DbConnection;
using System.Data;
using Dapper;
using System.Data.Common;
using CrudTeste.Domain.Entities;
using CrudTeste.Domain.VOs.Employee;
using CrudTeste.Domain.VOs.HumanResources;
using CrudTeste.Domain.Model.HumanResources;

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
        public async Task<IEnumerable<EmployeeVO>> GetEmployeesList()
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
                                ";

                var result = await connection.QueryAsync<EmployeeVO>(query);

                return result;
            }
        }
        public async Task<EmployeeContactVO> GetEmployeeContactById(int id)
        {
            using(IDbConnection connection = _dbSession.Connection)
            {
                string query = $@"SELECT [Employee].[BusinessEntityID], [FirstName], [LastName], [EmailAddress],[PhoneNumber],[PhoneType].[PhoneNumberTypeID],[Name]
                                    FROM [Person].[Person] AS Employee
                                    INNER JOIN [Person].[EmailAddress] AS Email ON [Employee].[BusinessEntityID] = [Email].[BusinessEntityID]
                                    INNER JOIN [Person].[PersonPhone]  AS Phone ON [Employee].[BusinessEntityID] = [Phone].[BusinessEntityID]
                                    INNER JOIN [Person].[PhoneNumberType] AS PhoneType ON [PhoneType].[PhoneNumberTypeID] = [Phone].[PhoneNumberTypeID]
                                    WHERE [Employee].[BusinessEntityID] = {id}";

                var result = await connection.QueryFirstOrDefaultAsync<EmployeeContactVO>(query);

                return result;
            }
        }
    }
}
