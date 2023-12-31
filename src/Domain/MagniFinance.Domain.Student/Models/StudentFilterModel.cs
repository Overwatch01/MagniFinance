using MagniFinance.Domain.Core.Models;

namespace MagniFinance.Domain.Student.Models;

public class StudentFilterModel : PaginatorModel
{
    public string? FirstName { get; set; }
    public string? OtherName { get; set; } 
    public string? LastName { get; set; }
    public string? RegistrationNumber { get; set; }
}