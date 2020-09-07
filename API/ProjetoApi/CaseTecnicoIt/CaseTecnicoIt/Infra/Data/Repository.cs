using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace CaseTecnicoIt.Infra.Data
{
    public abstract class Repository
    {
        private readonly IOptions<ConnectionStringOptions> _connectionString;

        public Repository(ILogger logger, IOptions<ConnectionStringOptions> connectionString)
        {
            Logger = logger;
            _connectionString = connectionString;
        }

        protected ILogger Logger { get; }
        protected string ConnectionString => _connectionString.Value.SqlConnection;

        protected IDbConnection GetConnection() => new SqlConnection(ConnectionString);
    }

}
