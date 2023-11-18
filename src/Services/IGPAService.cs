using TEABackEndCodingChallenge.Models;

namespace TEABackEndCodingChallenge.Services;

public interface IGPAService
{
    void CalculateStudentGPAs(IEnumerable<Student> students);
    decimal CalculateTotalCredits(int studentID, IEnumerable<Student> students);
    decimal CalculateTotalCreditHours(int studentID, IEnumerable<Student> students);
}
