using TEABackEndCodingChallenge.Models;

namespace TEABackEndCodingChallenge.Services;

public interface IStudentService
{
    IEnumerable<Student> GetAllStudentGrades();
}