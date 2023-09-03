using MagniFinance.Domain.Core.Queries;
using MagniFinance.Domain.Student.Models;

namespace MagniFinance.Domain.Student.Queries;

public class StudentDetailQuery : Query<StudentDetailModel>
{
    public int StudentId { get; set; }
}