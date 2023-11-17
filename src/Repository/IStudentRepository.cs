using TEABackEndCodingChallenge.Models;

namespace TEABackEndCodingChallenge;

public interface IStudentRepository
{
    IEnumerable<Student> ReadAll();
}
