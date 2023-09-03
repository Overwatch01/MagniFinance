using MagniFinance.Domain.Core.Queries;
using MagniFinance.Domain.Teacher.Models;

namespace MagniFinance.Domain.Teacher.Queries;

public class TeacherDetailQuery : Query<TeacherDetailModel>
{
    public int TeacherId { get; set; }
}