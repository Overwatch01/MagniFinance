using MagniFinance.Domain.Core.Models;

namespace MagniFinance.Domain.Course.Models;

public class CourseFilterModel : PaginatorModel
{
    public string? Name { get; set; }
    public string? CourseCode { get; set; }
}