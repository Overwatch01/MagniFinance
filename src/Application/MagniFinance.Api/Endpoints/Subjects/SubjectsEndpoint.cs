using MagniFinance.Domain.Core.Models;
using MagniFinance.Domain.Subject.Models;
using MagniFinance.Domain.Subject.Queries;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Subjects;

public class SubjectsEndpoint : Endpoint<SubjectFilterModel, AppResponse<PaginationResultModel<SubjectModel>, object>>
{
    private readonly IMediator _mediator;

    public SubjectsEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Get("/subjects/{Name}/{CourseCode}/{Skip}/{Take}/{SortField}/{SortOrder}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(SubjectFilterModel req, CancellationToken ct)
    {
        var query = new SubjectsQuery { Filter = req };
        var result =  await _mediator.Send(query, ct);
        await SendAsync(new AppResponse<PaginationResultModel<SubjectModel>, object>(ResponseCode.OkResponse, "Records Successfully Retrieved", result), cancellation: ct);
    }
}