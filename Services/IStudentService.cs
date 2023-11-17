using TEABackEndCodingChallenge.Models;

namespace TEABackEndCodingChallenge.Services;

public interface IStudentService
{
    void CalculateGPA(IEnumerable<Student> students);
    IEnumerable<Student> GetAll();
}