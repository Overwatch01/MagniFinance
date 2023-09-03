using System.Net;
using MagniFinance.Domain.Core.Commands;
using MagniFinance.Domain.Subject.Models;
using MagniFinance.Infrastructure.ExceptionHandler;
using MagniFinance.Infrastructure.ResponseHandler;

namespace MagniFinance.Domain.Subject.Commands;

public class UpsertSubjectCommand  :  Command
{
    public SubjectEditModel Data { get; set; }
    
    public override bool IsValid()
    {
        if (ValidationResult.Errors.Any())
            throw new ValidationException<object>(HttpStatusCode.BadRequest, ResponseCode.BadRequest, ResponseCode.GetResponseDescription(ResponseCode.BadRequest), ValidationResult.Errors.Select(x => x.ErrorMessage));
        
        return ValidationResult.IsValid;
    }
}