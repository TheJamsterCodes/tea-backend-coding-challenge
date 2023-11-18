using TEABackEndCodingChallenge.Models;
using TEABackEndCodingChallenge.Services;

namespace TEATests;

[TestClass]
public class GPAServiceTests
{
    private readonly IGPAService _gpa = new GPAService();

    [TestMethod]
    [DataRow("3.8", 2)]
    [DataRow("3.4", 3)]
    [DataRow("3.07", 6)]
    [DataRow("3.79", 7)]
    [DataRow("3", 8)]
    [DataRow("3.5", 9)]
    [DataRow("2.5", 11)]        
    public void CalculateStudentGPAs(string expectedGPA, int studentID)
    {
        decimal expected = Convert.ToDecimal(expectedGPA);        

        _gpa.CalculateStudentGPAs(_students);
        decimal actual = _students.First(s => s.StudentID == studentID).GPA;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(10)]
    [DataRow(12)]
    public void CalculateStudentGPAs_IgnoreZeroGrades(int studentID)
    {               
        decimal expected = 0;
        _gpa.CalculateStudentGPAs(_students);
        decimal actual = _students.First(s => s.StudentID == studentID).GPA;

        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    [DataRow("19", 2)]
    [DataRow("17", 3)]
    [DataRow("21.5", 6)]
    [DataRow("26.5", 7)]
    [DataRow("21", 8)]
    [DataRow("10.5", 9)]
    [DataRow("0", 10)]
    [DataRow("7.5", 11)]
    [DataRow("0", 12)]
    public void CalculateTotalCredits(string expectedTotalCredits, int studentID)
    {                
        decimal expected = Convert.ToDecimal(expectedTotalCredits);
        decimal actual = _gpa.CalculateTotalCredits(studentID, _students);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("5", 2)]
    [DataRow("5", 3)]
    [DataRow("7", 6)]
    [DataRow("7", 7)]
    [DataRow("7", 8)]
    [DataRow("3", 9)]
    [DataRow("0", 10)]
    [DataRow("3", 11)]
    [DataRow("0", 12)]    
    public void CalculateTotalCreditHours(string expectedTotalHours, int studentID)
    {
        decimal expected = Convert.ToDecimal(expectedTotalHours);
        decimal actual = _gpa.CalculateTotalCreditHours(studentID, _students);
        Assert.AreEqual(expected, actual);
    }

    private readonly IEnumerable<Student> _students = new List<Student>
    {
        new() { StudentID = 2, Grade = 4, Credits = 3 },
        new() { StudentID = 2, Grade = 3.5M, Credits = 2 },
        new() { StudentID = 3, Grade = 3, Credits = 3 },
        new() { StudentID = 3, Grade = 4, Credits = 2 },
        new() { StudentID = 6, Grade = 2.5M, Credits = 3 },
        new() { StudentID = 6, Grade = 3.5M, Credits = 4 },
        new() { StudentID = 7, Grade = 3.5M, Credits = 3 },
        new() { StudentID = 7, Grade = 4, Credits = 4 },
        new() { StudentID = 8, Grade = 3, Credits = 3 },
        new() { StudentID = 8, Grade = 3, Credits = 4 },
        new() { StudentID = 9, Grade = 3.5M, Credits = 3 },
        new() { StudentID = 10, Grade = 0, Credits = 3 },
        new() { StudentID = 11, Grade = 2.5M, Credits = 3 },
        new() { StudentID = 12, Grade = 0, Credits = 3 },
        new() { StudentID = 12, Grade = 0, Credits = 2 },
    };
}
