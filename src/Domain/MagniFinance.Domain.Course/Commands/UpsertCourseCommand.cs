using System.Net;
using FluentValidation.Results;
using MagniFinance.Domain.Core.Commands;
using MagniFinance.Domain.Course.Models;
using MagniFinance.Infrastructure.ExceptionHandler;
using MagniFinance.Infrastructure.ResponseHandler;

namespace MagniFinance.Domain.Course.Commands;

public class UpsertCourseCommand :  Command
{
    public CourseEditModel Data { get; set; }
    
    public override bool IsValid()
    {
        if (ValidationResult.Errors.Any())
            throw new ValidationException<object>(HttpStatusCode.BadRequest, ResponseCode.BadRequest, ResponseCode.GetResponseDescription(ResponseCode.BadRequest), ValidationResult.Errors.Select(x => x.ErrorMessage));
        
        return ValidationResult.IsValid;
    }
}