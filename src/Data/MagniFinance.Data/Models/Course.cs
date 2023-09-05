namespace MagniFinance.Data.Models;

public class Course : BaseEntity
{
    public string? Name { get; set; }
    public string? Code { get; set; }
    public int Duration { get; set; }
    public virtual List<Subject> Subjects { get; set; } = new();
}