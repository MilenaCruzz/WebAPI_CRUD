namespace CrudTeste.Service.DTOs.User
{
    public class PostUserDTO
    {
        public string? PersonType { get; set; }

        public int NameStyle { get; set; }

        public string? Title { get; set; }
        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
