namespace MagniFinance.Domain.Core.Models;

public class PaginationResultModel<T>
{
    public int TotalCount { get; set; }
    public List<T>? Data { get; set; }
    
}