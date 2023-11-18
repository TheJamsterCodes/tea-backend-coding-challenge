using TEABackEndCodingChallenge.Models;

namespace TEABackEndCodingChallenge.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepo;

    public StudentService(IStudentRepository studentRepo) => _studentRepo = studentRepo;

    public IEnumerable<Student> GetAllStudentGrades() => _studentRepo.ReadAll();
}