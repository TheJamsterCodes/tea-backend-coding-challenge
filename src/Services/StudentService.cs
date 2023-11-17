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
            decimal gradesSum = students.Where(s => s.StudentID == student.StudentID).Sum(g => g.Grade);
            decimal gradeCount = students.Where(s => s.StudentID == student.StudentID && s.Grade > 0).Count();
            student.GPA = gradesSum / gradeCount;
        }   
    }    

    public IEnumerable<Student> GetAll() => _studentRepo.ReadAll();
}