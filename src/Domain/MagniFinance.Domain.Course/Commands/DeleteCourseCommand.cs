using MagniFinance.Domain.Core.Commands;

namespace MagniFinance.Domain.Course.Commands;

public class DeleteCourseCommand : Command
{
    public int CourseId { get; set; }
    
    public override bool IsValid()
    {
        throw new NotImplementedException();
    }
}