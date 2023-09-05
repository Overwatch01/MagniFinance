using MagniFinance.Domain.Course.Models;
using MagniFinance.Domain.Course.Queries;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Courses;

public class CourseSummaryEndpoint : EndpointWithoutRequest<AppResponse<CourseSummaryModel, object>>
{
    private readonly IMediator _mediator;

    public CourseSummaryEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Get("/courses/summary");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new CourseSummaryQuery();
        var result =  await _mediator.Send(query, ct);
        await SendAsync(new AppResponse<CourseSummaryModel, object>(ResponseCode.OkResponse, "Record Successfully Retrieved", result), cancellation: ct);
    }
}