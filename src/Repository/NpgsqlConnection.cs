using System.Data;
using Npgsql;
using NPoco;

namespace TEABackEndCodingChallenge.Repository;

public class NpgsqlConnection : INpgsqlConnection
{
    private readonly string _connectionString;

    public NpgsqlConnection()
    {
        _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=psQl832!;Database=School";
    }

    public string ConnectionString 
    { 
        get => _connectionString; 
        set => throw new NotImplementedException(); 
    }

    public int ConnectionTimeout => throw new NotImplementedException();

    public string Database => "School";

    public ConnectionState State => throw new NotImplementedException();

    public IDatabase NPocoDatabase => new Database(ConnectionString, DatabaseType.PostgreSQL, NpgsqlFactory.Instance);

    public IDbTransaction BeginTransaction()
    {
        throw new NotImplementedException();
    }

    public IDbTransaction BeginTransaction(IsolationLevel il)
    {
        throw new NotImplementedException();
    }

    public void ChangeDatabase(string databaseName)
    {
        throw new NotImplementedException();
    }

    public void Close()
    {
        throw new NotImplementedException();
    }

    public IDbCommand CreateCommand()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        NPocoDatabase.Dispose();
        GC.SuppressFinalize(this);
    }

    public void Open()
    {
        throw new NotImplementedException();
    }
}
