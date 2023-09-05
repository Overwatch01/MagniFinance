using MagniFinance.Domain.Core.Models;
using MagniFinance.Domain.Course.Models;
using MagniFinance.Domain.Course.Queries;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Courses;

public class CoursesEndpoint : Endpoint<CourseFilterModel, AppResponse<PaginationResultModel<CourseModel>, object>>
{
    private readonly IMediator _mediator;

    public CoursesEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Get("/courses");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CourseFilterModel req, CancellationToken ct)
    {
        var query = new CoursesQuery { Filter = req };
        var result =  await _mediator.Send(query, ct);
        await SendAsync(new AppResponse<PaginationResultModel<CourseModel>, object>(ResponseCode.OkResponse, "Records Successfully Retrieved", result), cancellation: ct);
    }
}