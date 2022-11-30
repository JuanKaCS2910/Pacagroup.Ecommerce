using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Pacagroup.Ecommerce.Infrastructure.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._connectionString = configuration.GetConnectionString("NorthwindConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(this._connectionString);

    }
}
