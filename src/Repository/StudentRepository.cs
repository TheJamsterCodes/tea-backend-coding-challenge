﻿using Microsoft.Extensions.Caching.Memory;
using NPoco;
using TEABackEndCodingChallenge.Models;

namespace TEABackEndCodingChallenge.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly IMemoryCache _cache;
    private static readonly string _cacheName = "students";
    private readonly IDatabaseConnection _dbConnection;

    public StudentRepository(IMemoryCache cache, IDatabaseConnection dbConnection)
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
                    db.Connection.Open();
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