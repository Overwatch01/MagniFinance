using MagniFinance.Domain.Core.Queries;
using MagniFinance.Domain.Course.Models;

namespace MagniFinance.Domain.Course.Queries;

public class CourseTeacherQuery  : Query<CourseTeacherModel>
{
    public int CourseId { get; set; }
}