namespace MagniFinance.Domain.Student.Models;

public class StudentDetailModel 
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? OtherName { get; set; }
    public string? RegistrationNumber { get; set; }
}