using MagniFinance.Domain.Core.Commands;

namespace MagniFinance.Domain.Teacher.Commands;

public class DeleteTeacherCommand : Command
{
    public int TeacherId { get; set; }
    
    public override bool IsValid()
    {
        throw new NotImplementedException();
    }
}