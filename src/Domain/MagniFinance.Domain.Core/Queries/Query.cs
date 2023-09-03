using MediatR;

namespace MagniFinance.Domain.Core.Queries;

public abstract class Query<T> : IRequest<T>
{
    
}