namespace CrudTeste.Service.DTOs.Employee
{
    public class AverageEmployeePaymentDTO
    {
        public int Employees { get; set; }

        public int DepartmentID { get; set; }

        public string Name { get; set; }

        public float AveragePayment { get; set; }
    }
}
