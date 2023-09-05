using System.Data.Common;

namespace MagniFinance.Domain.Course.Models;

public class CourseStudentModel
{
    public int CourseId { get; set; }
    public int StudentId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? OtherName { get; set; }
    public string? RegistrationNumber { get; set; }
}