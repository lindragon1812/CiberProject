
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

using System.Data;

namespace Ciber.Context
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MySqlConnection");
        }
        public virtual IDbConnection CreateConnection()
            => new MySqlConnection(_connectionString);
    }
}
