using Microsoft.AspNetCore.Mvc;
using TEABackEndCodingChallenge.Models;
using TEABackEndCodingChallenge.Services;

namespace TEABackEndCodingChallenge.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IGPAService _gpa;
    private readonly IStudentService _student;

    public StudentsController(IGPAService gpa, IStudentService student)
    {
        _gpa = gpa;
        _student = student;
    }

    [HttpGet(Name = "GetStudents")]
    public IEnumerable<Student> Get()
    {
        var students = _student.GetAllStudentGrades();
        _gpa.CalculateStudentGPAs(students);        
        return students.GroupBy(s => s.StudentID).Select(s => s.First());
    }
}