using System.Data;
using NPoco;
namespace TEABackEndCodingChallenge.Repository;
public interface ISqlConnection : IDbConnection
{
    IDatabase NPocoDatabase { get; }
}