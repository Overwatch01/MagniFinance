using MagniFinance.Domain.Core.Queries;
using MagniFinance.Domain.Course.Models;

namespace MagniFinance.Domain.Course.Queries;

public class CourseDetailQuery : Query<CourseDetailModel>
{
    public int CourseId { get; set; }
}