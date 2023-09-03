using System.Net;
using MagniFinance.Domain.Core.Commands;
using MagniFinance.Domain.Grade.Models;
using MagniFinance.Infrastructure.ExceptionHandler;
using MagniFinance.Infrastructure.ResponseHandler;

namespace MagniFinance.Domain.Grade.Commands;

public class UpsertGradeCommand :  Command
{
    public GradeEditModel Data { get; set; }
    
    public override bool IsValid()
    {
        if (ValidationResult.Errors.Any())
            throw new ValidationException<object>(HttpStatusCode.BadRequest, ResponseCode.BadRequest, ResponseCode.GetResponseDescription(ResponseCode.BadRequest), ValidationResult.Errors.Select(x => x.ErrorMessage));
        
        return ValidationResult.IsValid;
    }
}