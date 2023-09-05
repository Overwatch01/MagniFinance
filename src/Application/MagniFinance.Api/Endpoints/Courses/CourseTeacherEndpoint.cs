using MagniFinance.Domain.Course.Models;
using MagniFinance.Domain.Course.Queries;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Courses;

public class CourseTeacherEndpoint : EndpointWithoutRequest<AppResponse<CourseTeacherModel, object>>
{
    private readonly IMediator _mediator;
    
    public CourseTeacherEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Get("/courses/{id}/teacher");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var courseId = Route<int>("id");
        var query = new CourseTeacherQuery() { CourseId = courseId };
        var result =  await _mediator.Send(query, ct);
        await SendAsync(new AppResponse<CourseTeacherModel, object>(ResponseCode.OkResponse, "Record Successfully Retrieved", result), cancellation: ct);
    }
}