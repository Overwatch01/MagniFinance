using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Interfaces;
using MediatR;

namespace MagniFinance.Domain.Core.Commands.Handlers;


public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : Command
{
    protected ApplicationDbContext DbContext { get; }
    protected IMapper Mapper { get; }

    protected CommandHandler(ApplicationDbContext dbContext, IMapper mapper)
    {
        DbContext = dbContext;
        Mapper = mapper;
    }

    public abstract Task<Unit> Handle(TCommand request, CancellationToken cancellationToken);
}