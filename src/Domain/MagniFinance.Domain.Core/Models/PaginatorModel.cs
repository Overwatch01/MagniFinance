namespace MagniFinance.Domain.Core.Models;

public class PaginatorModel
{
    public int Skip { get; set; }
    public int Take { get; set; } = 20;
    public string? SortField { get; set; }
    public PaginatorSortOrder SortOrder { get; set; }
}

public enum PaginatorSortOrder
{
    Asc = 1,
    Desc = -1
}