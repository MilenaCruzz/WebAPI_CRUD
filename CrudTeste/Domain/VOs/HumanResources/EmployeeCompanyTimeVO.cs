namespace CrudTeste.Domain.VOs.HumanResources
{
    public class EmployeeCompanyTimeVO
    {
        public int BusinessEntityID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public DateTime HireDate { get; set; }

        public int DepartmentID { get; set; }

        public int ServiceYears { get; set; }

        public int EmployeeAge { get; set; }
    }
}
