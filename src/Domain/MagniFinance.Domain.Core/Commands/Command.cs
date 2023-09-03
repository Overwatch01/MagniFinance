using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace MagniFinance.Domain.Core.Commands;

public abstract class Command :  IRequest<Unit>
{   
    public ValidationResult ValidationResult { get; init; }

    public abstract bool IsValid();
}