using CrudTeste.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudTeste.Infrastructure.DbConnection
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        // Outros DbSets e configurações do contexto

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
    }
}
