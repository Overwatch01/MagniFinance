using MagniFinance.Domain.Subject.Models;
using MagniFinance.Domain.Subject.Queries;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Subjects;

public class SubjectDetailEndpoint : EndpointWithoutRequest<AppResponse<SubjectDetailModel, object>>
{
    private readonly IMediator _mediator;

    public SubjectDetailEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Get("/subjects/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var subjectId = Route<int>("id");
        var query = new SubjectDetailQuery { SubjectId = subjectId };
        var result =  await _mediator.Send(query, ct);
        await SendAsync(new AppResponse<SubjectDetailModel, object>(ResponseCode.OkResponse, "Record Successfully Retrieved", result), cancellation: ct);
    }
    
}