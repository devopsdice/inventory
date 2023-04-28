using Npgsql;
using System.Data;

namespace InventoryService.Repository.Base
{
    public class DapperContext : IDapperContext
    {
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("InventoryDBConn");
        }

        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
    }
}
