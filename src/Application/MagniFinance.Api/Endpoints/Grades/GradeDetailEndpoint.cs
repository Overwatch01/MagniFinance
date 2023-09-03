using MagniFinance.Domain.Course.Models;
using MagniFinance.Domain.Grade.Models;
using MagniFinance.Domain.Grade.Queries;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Grades;

public class GradeDetailEndpoint : EndpointWithoutRequest<AppResponse<GradeDetailModel, object>>
{
    private readonly IMediator _mediator;

    public GradeDetailEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Get("/grades/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var gradeId = Route<int>("id");
        var query = new GradeDetailQuery { GradeId = gradeId };
        var result =  await _mediator.Send(query, ct);
        await SendAsync(new AppResponse<GradeDetailModel, object>(ResponseCode.OkResponse, "Record Successfully Retrieved", result), cancellation: ct);
    }
}