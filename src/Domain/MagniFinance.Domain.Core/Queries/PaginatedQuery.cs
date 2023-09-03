using MagniFinance.Domain.Core.Models;

namespace MagniFinance.Domain.Core.Queries;

public abstract class PaginationResultQuery<T> : Query<PaginationResultModel<T>>
{
   // public PaginatorModel? Paginator { get; set; }
}