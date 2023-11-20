using System.Data.SqlClient;
using System.Reflection;
using Npgsql;
using NPoco;

namespace TEABackEndCodingChallenge.Repository;

public class DatabaseConnection : IDatabaseConnection
{
    private readonly string _connectionString;
    private readonly IDatabase _nPocoDatabase;

    public DatabaseConnection(IConfiguration config, bool isUsingSQLServer)
    {
        if (isUsingSQLServer)
        {
            _connectionString = config.GetConnectionString("SQLServer");
            _nPocoDatabase = new Database(new SqlConnection(_connectionString));
        }
        else
        {
            // From secrets.json file
            _connectionString = config["ConnectionStrings:PostgreSQL"];
            _nPocoDatabase = new Database(_connectionString, DatabaseType.PostgreSQL, NpgsqlFactory.Instance);
        }
    }

    public IDatabase NPocoDatabase => _nPocoDatabase;
}