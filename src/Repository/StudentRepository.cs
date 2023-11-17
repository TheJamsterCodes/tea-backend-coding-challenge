using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Caching.Memory;
using NPoco;
using TEABackEndCodingChallenge.Models;

namespace TEABackEndCodingChallenge.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly IMemoryCache _cache;
    private static readonly string _cacheName = "students";
    private readonly INpgsqlConnection _dbConnection;
    //private readonly ISqlConnection _dbConnection;

    public StudentRepository(
        IMemoryCache cache
        ,INpgsqlConnection dbConnection
        // ,ISqlConnection dbConnection
    )
    {
        _cache = cache;
        _dbConnection = dbConnection;        
    }

    public IEnumerable<Student> ReadAll()
    {                                
        var students = _cache.Get<IEnumerable<Student>>(_cacheName);

        if (students is null)
        {
            try
            {                
                string sql = "StudentGrades".GetSQLFromFile();

                using (IDatabase db = _dbConnection.NPocoDatabase)
                {
                    students = db.Fetch<Student>(sql);
                }

                _cache.Set(_cacheName, students, TimeSpan.FromMinutes(1));                
            }
            catch
            {
                throw;
            }
        }             

        return students;
    }
}