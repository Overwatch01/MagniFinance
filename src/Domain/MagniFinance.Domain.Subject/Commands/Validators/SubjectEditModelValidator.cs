using FluentValidation;
using MagniFinance.Domain.Subject.Models;

namespace MagniFinance.Domain.Subject.Commands.Validators;

public class SubjectEditModelValidator : AbstractValidator<SubjectEditModel>
{
    public SubjectEditModelValidator()
    {
        
    }
}