namespace MagniFinance.Domain.Course.Models;

public class CourseTeacherModel
{
    public int CourseId { get; set; }
    public int TeacherId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? OtherName { get; set; }
    public double AnnualSalary { get; set; }
}