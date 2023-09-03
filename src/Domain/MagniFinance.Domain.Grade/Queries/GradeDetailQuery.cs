using MagniFinance.Domain.Core.Queries;
using MagniFinance.Domain.Grade.Models;

namespace MagniFinance.Domain.Grade.Queries;

public class GradeDetailQuery : Query<GradeDetailModel>
{
    public int GradeId { get; set; }
}