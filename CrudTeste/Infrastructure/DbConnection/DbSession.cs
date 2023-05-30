using System.Data;
using System.Data.SqlClient;

namespace CrudTeste.Infrastructure.DbConnection
{
    public class DbSession : IDisposable
    {
        
        public DbSession(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            Connection.Open();
        }
        public IDbConnection Connection { get;}
        public void Dispose()
        {
            Connection?.Dispose();
        }
    }
}
