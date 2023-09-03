using FluentValidation;
using MagniFinance.Domain.Teacher.Models;

namespace MagniFinance.Domain.Teacher.Commands.Validators;

public class TeacherEditModelValidator : AbstractValidator<TeacherEditModel>
{
    public TeacherEditModelValidator()
    {
        RuleFor(x => x.FirstName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.LastName).MaximumLength(10).NotEmpty();
    }
}