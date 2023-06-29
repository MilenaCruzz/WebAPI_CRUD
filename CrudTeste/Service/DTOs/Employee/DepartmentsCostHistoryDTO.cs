namespace CrudTeste.Service.DTOs.Employee
{
    public class DepartmentsCostHistoryDTO
    {
        public int BusinessEntityID { get; set; }
        public DateTime ExpenseDate { get; set; }

        public int Transactions { get; set; }

        public double TotalSpent { get; set; }
    }
}
