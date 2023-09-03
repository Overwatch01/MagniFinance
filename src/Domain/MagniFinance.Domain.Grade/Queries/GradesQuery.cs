using MagniFinance.Domain.Core.Queries;
using MagniFinance.Domain.Grade.Models;

namespace MagniFinance.Domain.Grade.Queries;

public class GradesQuery : PaginationResultQuery<GradeModel>
{
    public GradeFilterModel Filter { get; set; } = new();
}