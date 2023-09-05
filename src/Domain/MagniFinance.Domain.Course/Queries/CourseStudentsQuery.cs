using MagniFinance.Domain.Core.Queries;
using MagniFinance.Domain.Course.Models;

namespace MagniFinance.Domain.Course.Queries;

public class CourseStudentsQuery  : Query<IEnumerable<CourseStudentModel>>
{
    public int CourseId { get; set; }
}