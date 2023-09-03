using FluentValidation;
using MagniFinance.Domain.Course.Models;

namespace MagniFinance.Domain.Course.Commands.Validators;

public class CourseEditModelValidator : AbstractValidator<CourseEditModel>
{
    public CourseEditModelValidator()
    {
        RuleFor(x => x.Name).MaximumLength(50).NotEmpty();
        RuleFor(x => x.Code).MaximumLength(10).NotEmpty();
    }
}