using System.Data;
using NPoco;
namespace TEABackEndCodingChallenge.Repository;

public class SqlConnection : ISqlConnection
{
    public SqlConnection()
    {
        
    }

    public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int ConnectionTimeout => throw new NotImplementedException();

    public string Database => "School";

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
