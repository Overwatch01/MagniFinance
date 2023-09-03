using MediatR;

namespace MagniFinance.Domain.Core.Interfaces;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IRequest<TResult>
{
    
}