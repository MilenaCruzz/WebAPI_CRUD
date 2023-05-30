namespace CrudTeste.Domain.VOs
{
    public class UpdateUserVO
    {
        public  int BusinessEntityID { get; set; }
        public string? MiddleName { get; set; }

        public string? EmailAddress { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
