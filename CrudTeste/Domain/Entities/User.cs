using System.ComponentModel.DataAnnotations.Schema;

namespace CrudTeste.Domain.Entities
{

    [Table("Users")]
    public class User
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? EmailAddress { get; set; }
    }
}
