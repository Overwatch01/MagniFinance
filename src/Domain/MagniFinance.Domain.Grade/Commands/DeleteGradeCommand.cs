using MagniFinance.Domain.Core.Commands;

namespace MagniFinance.Domain.Grade.Commands;

public class DeleteGradeCommand : Command
{
    public int GradeId { get; set; }
    
    public override bool IsValid()
    {
        throw new NotImplementedException();
    }
}