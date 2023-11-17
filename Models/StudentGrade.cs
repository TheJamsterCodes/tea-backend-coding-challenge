using NPoco;

namespace TEABackEndCodingChallenge.Models;

[TableName("StudentGrade")]
[PrimaryKey("StudentID")]
public class StudentGrade
{
    public int StudentID { get; set; }

    public int CourseID { get; set; }
    public int EnrollmentID { get; set; }
    public decimal Grade { get; set; }    
}