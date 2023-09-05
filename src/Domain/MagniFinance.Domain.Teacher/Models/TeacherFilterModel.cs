using MagniFinance.Domain.Core.Models;

namespace MagniFinance.Domain.Teacher.Models;

public class TeacherFilterModel : PaginatorModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}