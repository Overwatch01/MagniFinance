using MagniFinance.Domain.Course.Commands;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Courses;

public class DeleteCourseEndpoint : EndpointWithoutRequest<AppResponse<string, object>>
{
    private readonly IMediator _mediator;

    public DeleteCourseEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Delete("/courses/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var courseId = Route<int>("id");
        var command = new DeleteCourseCommand { CourseId = courseId };
        await _mediator.Send(command, ct);
        await SendAsync(new AppResponse<string, object>(ResponseCode.OkResponse, "Record Successfully Deleted", ResponseCode.GetResponseDescription(ResponseCode.OkResponse)), cancellation: ct);
    }
}