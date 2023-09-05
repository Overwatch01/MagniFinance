using MagniFinance.Domain.Student.Models;
using MagniFinance.Domain.Student.Queries;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Students;

public class StudentSummaryEndpoint : EndpointWithoutRequest<AppResponse<StudentSummaryModel, object>>
{
    private readonly IMediator _mediator;

    public StudentSummaryEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Get("/students/summary");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new StudentSummaryQuery();
        var result =  await _mediator.Send(query, ct);
        await SendAsync(new AppResponse<StudentSummaryModel, object>(ResponseCode.OkResponse, "Record Successfully Retrieved", result), cancellation: ct);
    }
}