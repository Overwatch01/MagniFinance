using FluentValidation;
using MagniFinance.Domain.Grade.Models;

namespace MagniFinance.Domain.Grade.Commands.Validators;

public class GradeEditModelValidator : AbstractValidator<GradeEditModel>
{
    public GradeEditModelValidator()
    {
        
    }
}