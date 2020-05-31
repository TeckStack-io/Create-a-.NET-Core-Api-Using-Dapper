using DataAbstractions.Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DapperCore.Infrastructure
{
    public class DatabaseConnection : DataAccessor
    {
        public DatabaseConnection(IConfiguration configuration)
            : base(new SqlConnection(configuration.GetConnectionString("DefaultConnection"))) { }
    }
}
