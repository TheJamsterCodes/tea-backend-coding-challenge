using System.Data;
using NPoco;
namespace TEABackEndCodingChallenge.Repository;

public class SqlConnection : ISqlConnection
{
    private readonly string _connectionString;
    private readonly string _databaseName;

    public SqlConnection(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("SQLServer");
        _databaseName = config.GetSection("DatabaseName").Value;
    }

    public string ConnectionString
    { 
        get => _connectionString; 
        set => throw new NotImplementedException(); 
    }

    public int ConnectionTimeout => throw new NotImplementedException();

    public string Database => _databaseName;

    public ConnectionState State => throw new NotImplementedException();

    public IDatabase NPocoDatabase => throw new NotImplementedException();

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
