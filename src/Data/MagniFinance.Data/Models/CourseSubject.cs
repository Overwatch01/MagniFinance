namespace MagniFinance.Data.Models;

public class CourseSubject : BaseEntity
{
    public virtual Course Course { get; set; }
    public virtual Subject Subject { get; set; }
}