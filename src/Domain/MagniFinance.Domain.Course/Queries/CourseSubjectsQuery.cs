using MagniFinance.Domain.Core.Queries;
using MagniFinance.Domain.Course.Models;

namespace MagniFinance.Domain.Course.Queries;

public class CourseSubjectsQuery : Query<CourseSubjectModel>
{
    public int CourseId { get; set; }
}