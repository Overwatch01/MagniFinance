using MagniFinance.Domain.Core.Commands;

namespace MagniFinance.Domain.Subject.Commands;

public class DeleteSubjectCommand : Command
{
    public int SubjectId { get; set; }
    
    public override bool IsValid()
    {
        throw new NotImplementedException();
    }
}