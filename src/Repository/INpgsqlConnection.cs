using System.Data;
using NPoco;
namespace TEABackEndCodingChallenge.Repository;
public interface INpgsqlConnection : IDbConnection
{ 
    IDatabase NPocoDatabase { get; }
}