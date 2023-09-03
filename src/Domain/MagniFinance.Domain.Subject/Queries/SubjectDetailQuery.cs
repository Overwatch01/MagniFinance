using MagniFinance.Domain.Core.Queries;
using MagniFinance.Domain.Subject.Models;

namespace MagniFinance.Domain.Subject.Queries;

public class SubjectDetailQuery : Query<SubjectDetailModel>
{
    public int SubjectId { get; set; }
}