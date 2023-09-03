using MagniFinance.Domain.Student.Commands;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Students;

public class DeleteStudentEndpoint : EndpointWithoutRequest<AppResponse<string, object>>
{
    private readonly IMediator _mediator;

    public DeleteStudentEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Delete("/students/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var studentId = Route<int>("id");
        var command = new DeleteStudentCommand { StudentId = studentId };
        await _mediator.Send(command, ct);
        await SendAsync(new AppResponse<string, object>(ResponseCode.OkResponse, "Student Successfully Deleted", ResponseCode.GetResponseDescription(ResponseCode.OkResponse)), cancellation: ct);
    }
}