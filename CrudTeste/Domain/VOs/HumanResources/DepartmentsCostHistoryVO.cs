namespace CrudTeste.Domain.VOs.HumanResources
{
    public class DepartmentsCostHistoryVO
    {
      
         public int BusinessEntityID { get; set; }

        public int DepartmentID { get; set; }

        public DateTime ExpenseDate { get; set; }

        public int Transactions { get; set; }

        public double TotalSpent { get; set; }

 
     
    }
}
