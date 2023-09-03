using FluentValidation;
using MagniFinance.Domain.Student.Models;

namespace MagniFinance.Domain.Student.Commands.Validators;

public class StudentEditModelValidator : AbstractValidator<StudentEditModel>
{
    public StudentEditModelValidator()
    {
        RuleFor(x => x.FirstName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.LastName).MaximumLength(10).NotEmpty();
    }
}