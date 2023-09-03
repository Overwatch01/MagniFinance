using MagniFinance.Domain.Subject.Commands;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Subjects;

public class DeleteSubjectEndpoint  : EndpointWithoutRequest<AppResponse<string, object>>
{
    private readonly IMediator _mediator;

    public DeleteSubjectEndpoint(IMediator mediator) => _mediator = mediator;

    public override void Configure()
    {
        Delete("/subjects/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var subjectId = Route<int>("id");
        var command = new DeleteSubjectCommand { SubjectId = subjectId };
        await _mediator.Send(command, ct);
        await SendAsync(new AppResponse<string, object>(ResponseCode.OkResponse, "Record Successfully Deleted", ResponseCode.GetResponseDescription(ResponseCode.OkResponse)), cancellation: ct);
    }
}