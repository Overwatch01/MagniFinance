using MediatR;

namespace MagniFinance.Domain.Core.Interfaces;
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Unit> where TCommand : IRequest<Unit>
{
    
}