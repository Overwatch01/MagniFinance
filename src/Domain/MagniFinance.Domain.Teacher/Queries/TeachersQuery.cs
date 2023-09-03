using MagniFinance.Domain.Core.Queries;
using MagniFinance.Domain.Teacher.Models;

namespace MagniFinance.Domain.Teacher.Queries;

public class TeachersQuery : PaginationResultQuery<TeacherModel>
{
    public TeacherFilterModel Filter { get; set; } = new();
}