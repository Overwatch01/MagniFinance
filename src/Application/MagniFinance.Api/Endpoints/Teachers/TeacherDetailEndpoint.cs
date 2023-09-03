using MagniFinance.Domain.Course.Models;
using MagniFinance.Domain.Teacher.Models;
using MagniFinance.Domain.Teacher.Queries;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Teachers;

public class TeacherDetailEndpoint : EndpointWithoutRequest<AppResponse<TeacherDetailModel, object>>
{
    private readonly IMediator _mediator;

    public TeacherDetailEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Get("/teachers/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var teacherId = Route<int>("id");
        var query = new TeacherDetailQuery { TeacherId = teacherId };
        var result =  await _mediator.Send(query, ct);
        await SendAsync(new AppResponse<TeacherDetailModel, object>(ResponseCode.OkResponse, "Record Successfully Retrieved", result), cancellation: ct);
    }
}