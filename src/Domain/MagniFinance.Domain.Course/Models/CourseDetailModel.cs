namespace MagniFinance.Domain.Course.Models;

public class CourseDetailModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? CourseCode { get; set; }
    public string? DateModified { get; set; }
    
    public int Duration { get; set; }
}