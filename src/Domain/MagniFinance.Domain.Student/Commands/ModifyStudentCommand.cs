using MagniFinance.Domain.Core.Commands;
using MagniFinance.Domain.Student.Models;

namespace MagniFinance.Domain.Student.Commands;

public class ModifyStudentCommand : Command
{
    public StudentEditModel Data { get; set; }
    
    public override bool IsValid()
    {
        if (ValidationResult.Errors.Any())
            throw new Exception(ValidationResult.Errors.ToString());
        
        return ValidationResult.IsValid;
    }
}