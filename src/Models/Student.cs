using System.Text.Json.Serialization;
using NPoco;

namespace TEABackEndCodingChallenge.Models;

public class Student
{
    [JsonPropertyName("studentID")]
    public int StudentID { get; set; }

    [JsonPropertyName("firstName")]
    public string Firstname { get; set; }

    [JsonPropertyName("lastName")]
    public string Lastname { get; set; }    
    
    public decimal Grade { get; set; }

    [Ignore]
    [JsonPropertyName("gpa")]
    public decimal GPA { get; set; }
}