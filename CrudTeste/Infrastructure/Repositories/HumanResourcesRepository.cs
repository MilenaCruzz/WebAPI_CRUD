using CrudTeste.Infrastructure.Repositories.Interfaces;
using CrudTeste.Infrastructure.DbConnection;
using System.Data;
using Dapper;
using System.Data.Common;
using CrudTeste.Domain.Entities;
using CrudTeste.Domain.VOs.Employee;
using CrudTeste.Domain.VOs.HumanResources;

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

        public async Task<EmployeeCompanyTimeVO> GetEmployeeCompanyTimeById(int id)
        {
            using(IDbConnection connection = _dbSession.Connection)
            {
                string query = $@"SELECT [Person].[BusinessEntityID], [FirstName], [LastName], [BirthDate], [HireDate], [Department].[DepartmentID],
                                            DATEDIFF(YEAR, [HireDate], GETDATE()) AS {nameof(EmployeeCompanyTimeVO.ServiceYears)},
                                            DATEDIFF(YEAR, [BirthDate], GETDATE()) AS {nameof(EmployeeCompanyTimeVO.EmployeeAge)}
                                            FROM [Person].[Person] Person
                                            INNER JOIN [HumanResources].[Employee] Employee
                                            ON [Person].[BusinessEntityID] = [Employee].[BusinessEntityID]
                                            INNER JOIN [HumanResources].[EmployeeDepartmentHistory] AS Department
                                            ON [Department].[BusinessEntityID] = [Employee].[BusinessEntityID]
                                            INNER JOIN HumanResources.Department DepartmentNumber
                                            ON [DepartmentNumber].[DepartmentID] = [Department].[DepartmentID]
                                            WHERE(DATEDIFF(YEAR, [HireDate], GETDATE()) >= 10) AND [Department].[BusinessEntityID] = {id}
                                            ORDER BY [Employee].[BusinessEntityID] ASC;";

                var result = await connection.QueryFirstOrDefaultAsync<EmployeeCompanyTimeVO>(query);

                return result;
            }
        }

        public async Task<IEnumerable<AverageEmployeePaymentVO>> AverageDepartmentsPayment()
        {
            using(IDbConnection connection = _dbSession.Connection)
            {
                string query = $@"SELECT COUNT([Employees].[BusinessEntityID]) AS Employees, [Department].[DepartmentID], [Department].[Name],
                                        AVG(Rate.AverageRate) as AveragePayment
                                        FROM [HumanResources].[EmployeeDepartmentHistory] Employees
                                        INNER JOIN [HumanResources].[Department] Department
                                        ON [Employees].[DepartmentID] = [Department].[DepartmentID]
                                        INNER JOIN
                                        (SELECT BusinessEntityID, MAX(Rate) AS AverageRate
                                        FROM [HumanResources].[EmployeePayHistory]
                                        GROUP BY BusinessEntityID) Rate
                                        ON [Rate].[BusinessEntityID] = [Employees].[BusinessEntityID]
                                        GROUP BY [Department].[DepartmentID], [Department].[Name]
                                        ORDER BY [DepartmentID] ASC;";

                var result =  await connection.QueryAsync<AverageEmployeePaymentVO>(query);

                return result;
            }
        }

        public async Task<IEnumerable<DepartmentsCostHistoryVO>> DepartmentCostById(int departmentId)
        {
            using(IDbConnection connection = _dbSession.Connection)
            {
                string query = $@"SELECT [DepartmentCost].[BusinessEntityID],[DepartmentCost].[DepartmentID],[ExpenseDate],
                            COUNT(DepartmentCost.BusinessEntityID) AS Transactions,
                            SUM(MoneySpent) AS TotalSpent
                            FROM [HumanResources].[DepartmentCostHistory] DepartmentCost
                            INNER JOIN [HumanResources].[Employee] Employee
                            ON DepartmentCost.BusinessEntityID = Employee.BusinessEntityID
                            INNER JOIN [HumanResources].[Department] DepartmentName
                            ON [DepartmentCost].[DepartmentID] = [DepartmentName].[DepartmentID]
                            WHERE [DepartmentName].[DepartmentID] = {departmentId}
                            GROUP BY [DepartmentCost].[BusinessEntityID],[DepartmentCost].[DepartmentID], [DepartmentCost].[ExpenseDate]
                            ORDER BY ExpenseDate DESC;";

                var result = await connection.QueryAsync<DepartmentsCostHistoryVO>(query);

                return result;
            }
        }
    }
}
