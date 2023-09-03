using MagniFinance.Domain.Core.Queries;
using MagniFinance.Domain.Course.Models;

namespace MagniFinance.Domain.Course.Queries;

public class CoursesQuery : PaginationResultQuery<CourseModel>
{
    public CourseFilterModel Filter { get; set; } = new();
}