using MagniFinance.Domain.Grade.Commands;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Grades;

public class DeleteGradeEndpoint : EndpointWithoutRequest<AppResponse<string, object>>
{
    private readonly IMediator _mediator;

    public DeleteGradeEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Delete("/grades/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var gradeId = Route<int>("id");
        var command = new DeleteGradeCommand { GradeId = gradeId };
        await _mediator.Send(command, ct);
        await SendAsync(new AppResponse<string, object>(ResponseCode.OkResponse, "Record Successfully Deleted", ResponseCode.GetResponseDescription(ResponseCode.OkResponse)), cancellation: ct);
    }
    
}