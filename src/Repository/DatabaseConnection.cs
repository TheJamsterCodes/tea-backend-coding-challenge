using System.Data.SqlClient;
using System.Reflection;
using Npgsql;
using NPoco;

namespace TEABackEndCodingChallenge.Repository;

public class DatabaseConnection : IDatabaseConnection
{
    private readonly string _connectionString;
    private readonly IDatabase _nPocoDatabase;

    public DatabaseConnection(bool isUsingSQLServer)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json")
            .AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true)
            .AddEnvironmentVariables()
            .Build();

        if (isUsingSQLServer)
        {
            _connectionString = config.GetConnectionString("SQLServer");
            _nPocoDatabase = new Database(_connectionString, DatabaseType.SqlServer2012, SqlClientFactory.Instance);
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