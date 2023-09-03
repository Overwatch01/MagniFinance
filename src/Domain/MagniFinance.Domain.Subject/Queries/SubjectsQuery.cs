using MagniFinance.Domain.Core.Queries;
using MagniFinance.Domain.Subject.Models;

namespace MagniFinance.Domain.Subject.Queries;

public class SubjectsQuery : PaginationResultQuery<SubjectModel>
{
    public SubjectFilterModel Filter { get; set; } = new();
}