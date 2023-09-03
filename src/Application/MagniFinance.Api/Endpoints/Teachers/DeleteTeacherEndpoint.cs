using MagniFinance.Domain.Teacher.Commands;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Teachers;

public class DeleteTeacherEndpoint : EndpointWithoutRequest<AppResponse<string, object>>
{
    private readonly IMediator _mediator;

    public DeleteTeacherEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Delete("/teachers/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var teacherId = Route<int>("id");
        var command = new DeleteTeacherCommand { TeacherId = teacherId };
        await _mediator.Send(command, ct);
        await SendAsync(new AppResponse<string, object>(ResponseCode.OkResponse, "Record Successfully Deleted", ResponseCode.GetResponseDescription(ResponseCode.OkResponse)), cancellation: ct);
    }
}