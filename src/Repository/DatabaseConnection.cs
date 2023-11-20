using System.Data.SqlClient;
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
            _connectionString = config["ConnectionStrings:PostgreSQL"];
            _nPocoDatabase = new Database(new NpgsqlConnection(_connectionString), DatabaseType.PostgreSQL);
        }
    }

    public IDatabase NPocoDatabase => _nPocoDatabase;
}