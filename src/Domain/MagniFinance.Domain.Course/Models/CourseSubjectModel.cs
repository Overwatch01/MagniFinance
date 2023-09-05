namespace MagniFinance.Domain.Course.Models;

public class CourseSubjectModel : CourseDetailModel
{
    public IEnumerable<CourseSubject> Subjects { get; set; }
}

public class CourseSubject
{
    public string Name { get; set; }
    public string Code { get; set; }
}