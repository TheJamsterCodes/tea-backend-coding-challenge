using NPoco;

namespace TEABackEndCodingChallenge.Repository;

public interface IDatabaseConnection
{
    IDatabase NPocoDatabase { get; }
}