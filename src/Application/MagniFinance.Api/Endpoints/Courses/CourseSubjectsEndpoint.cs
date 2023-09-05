using MagniFinance.Domain.Course.Models;
using MagniFinance.Domain.Course.Queries;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Courses;

public class CourseSubjectsEndpoint : EndpointWithoutRequest<AppResponse<CourseSubjectModel, object>>
{
    private readonly IMediator _mediator;
    
    public CourseSubjectsEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Get("/courses/{id}/subjects");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var courseId = Route<int>("id");
        var query = new CourseSubjectsQuery() { CourseId = courseId };
        var result =  await _mediator.Send(query, ct);
        await SendAsync(new AppResponse<CourseSubjectModel, object>(ResponseCode.OkResponse, "Record Successfully Retrieved", result), cancellation: ct);
    }

}