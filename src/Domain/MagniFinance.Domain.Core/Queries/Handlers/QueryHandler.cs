using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Interfaces;

namespace MagniFinance.Domain.Core.Queries.Handlers;

public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : Query<TResult>
{
    protected ApplicationDbContext DbContext { get; }
    protected IMapper Mapper { get; }

    protected QueryHandler(ApplicationDbContext dbContext, IMapper mapper)
    {
        DbContext = dbContext;
        Mapper = mapper;
    }

    public abstract Task<TResult> Handle(TQuery request, CancellationToken cancellationToken);
}