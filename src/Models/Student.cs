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
    
    [JsonIgnore]
    public decimal Grade { get; set; }

    [JsonIgnore]
    public int Credits { get; set; }

    [Ignore]
    [JsonPropertyName("gpa")]
    public decimal GPA { get; set; }

    [Ignore]
    [JsonIgnore]
    public decimal TotalCredits { get; set; }

    [Ignore]
    [JsonIgnore]
    public decimal TotalCreditHours { get; set; }
}