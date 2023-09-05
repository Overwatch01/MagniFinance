namespace MagniFinance.Domain.Student.Models;

public class StudentEditModel
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? OtherName { get; set; }
    public string? Email { get; set; }
}