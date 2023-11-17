using NPoco;

namespace TEABackEndCodingChallenge.Models;

[TableName("Person")]
[PrimaryKey("PersonID")]
public class Person
{
    public int PersonID { get; set; }

    public string Discriminator { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Firstname { get; set; }
    public DateTime HireDate { get; set; }
    public string Lastname { get; set; }
}