
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdventureWorksApi.Repositories
{
    public class ProcedureRepository : IProcedureRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ProcedureRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<dynamic>> ExecuteProcedureAsync(string procedureName, IDictionary<string, object> parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            var dynamicParams = new DynamicParameters();

            foreach (var param in parameters)
            {
                dynamicParams.Add(param.Key, param.Value);
            }

            return await connection.QueryAsync(procedureName, dynamicParams, commandType: CommandType.StoredProcedure);
        }
    }
}
