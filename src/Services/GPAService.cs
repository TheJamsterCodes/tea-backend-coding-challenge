using TEABackEndCodingChallenge.Models;

namespace TEABackEndCodingChallenge.Services;

public class GPAService : IGPAService
{    
    public void CalculateStudentGPAs(IEnumerable<Student> students)
    {
        var studentsWithGrades = students
            .Where(s => s.Grade > 0)
            .GroupBy(s => s.StudentID)
            .Select(s => s.First());

        foreach (Student student in studentsWithGrades)
        {
            student.TotalCredits = CalculateTotalCredits(student.StudentID, students);
            student.TotalCreditHours = CalculateTotalCreditHours(student.StudentID, students);
            student.GPA = student.TotalCredits / student.TotalCreditHours;

            if (decimal.Round(student.GPA, 2) != student.GPA)
            {
                student.GPA = Convert.ToDecimal(string.Format("{0:0.00}", student.GPA));
            }                        
        } 
    }

    public decimal CalculateTotalCredits(int studentID, IEnumerable<Student> students)
    {
        decimal totalCredits = students
            .Where(s => s.StudentID == studentID && s.Grade > 0)
            .Sum(g => g.Grade * g.Credits);
        
        return totalCredits;
    }

    public decimal CalculateTotalCreditHours(int studentID, IEnumerable<Student> students)
    {
        decimal totalCreditHours = students
            .Where(s => s.StudentID == studentID && s.Grade > 0)
            .Sum(g => g.Credits);

        return totalCreditHours;
    }
}