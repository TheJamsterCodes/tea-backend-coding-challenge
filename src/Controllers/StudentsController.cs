using Microsoft.AspNetCore.Mvc;
using TEABackEndCodingChallenge.Models;
using TEABackEndCodingChallenge.Services;

namespace TEABackEndCodingChallenge.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _students;

    public StudentsController(IStudentService students) => _students = students;

    [HttpGet(Name = "GetStudents")]
    public IEnumerable<Student> Get()
    {
        var students = _students.GetAll();
        _students.CalculateGPA(students);
        return students.GroupBy(s => s.StudentID).Select(x => x.First());
    }
}