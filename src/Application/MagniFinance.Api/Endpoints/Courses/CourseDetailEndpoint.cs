using MagniFinance.Domain.Core.Models;
using MagniFinance.Domain.Course.Models;
using MagniFinance.Domain.Course.Queries;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Courses;

public class CourseDetailEndpoint : EndpointWithoutRequest<AppResponse<CourseDetailModel, object>>
{
    private readonly IMediator _mediator;

    public CourseDetailEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Get("/courses/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var courseId = Route<int>("id");
        var query = new CourseDetailQuery { CourseId = courseId };
        var result =  await _mediator.Send(query, ct);
        await SendAsync(new AppResponse<CourseDetailModel, object>(ResponseCode.OkResponse, "Record Successfully Retrieved", result), cancellation: ct);
    }
}