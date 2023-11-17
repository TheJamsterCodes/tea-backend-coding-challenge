using TEABackEndCodingChallenge.Models;

namespace TEABackEndCodingChallenge.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepo;

    public StudentService(IStudentRepository studentRepo) => _studentRepo = studentRepo;

    public void CalculateGPA(IEnumerable<Student> students)
    {
        foreach (Student student in students.Where(s => s.Grade > 0))
        {
            decimal totalCredits = students.Where(s => s.StudentID == student.StudentID).Sum(g => g.Grade * g.Credits);
            decimal totalCreditHours = students.Where(s => s.StudentID == student.StudentID).Sum(g => g.Credits);

            student.GPA = totalCredits / totalCreditHours;
        }   
    }

    public IEnumerable<Student> GetAll() => _studentRepo.ReadAll();
}