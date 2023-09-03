using MagniFinance.Domain.Core.Commands;

namespace MagniFinance.Domain.Student.Commands;

public class DeleteStudentCommand : Command
{
    public int StudentId { get; set; }
    
    public override bool IsValid()
    {
        throw new NotImplementedException();
    }
}