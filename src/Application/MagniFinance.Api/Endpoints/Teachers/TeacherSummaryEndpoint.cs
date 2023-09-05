using MagniFinance.Domain.Teacher.Models;
using MagniFinance.Domain.Teacher.Queries;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Teachers;

public class TeacherSummaryEndpoint : EndpointWithoutRequest<AppResponse<TeacherSummaryModel, object>>
{
    private readonly IMediator _mediator;

    public TeacherSummaryEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Get("/teachers/summary");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new TeacherSummaryQuery();
        var result =  await _mediator.Send(query, ct);
        await SendAsync(new AppResponse<TeacherSummaryModel, object>(ResponseCode.OkResponse, "Record Successfully Retrieved", result), cancellation: ct);
    }
}