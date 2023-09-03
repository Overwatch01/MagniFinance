using MagniFinance.Domain.Student.Models;
using MagniFinance.Domain.Student.Queries;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Students;

public class StudentDetailEndpoint : EndpointWithoutRequest<AppResponse<StudentDetailModel, object>>
{ 
    private readonly IMediator _mediator;

    public StudentDetailEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Get("/students/{id}");
        AllowAnonymous();
    }
    
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var studentId = Route<int>("id");
        var query = new StudentDetailQuery { StudentId = studentId };
        var result =  await _mediator.Send(query, ct);
        await SendAsync(new AppResponse<StudentDetailModel, object>(ResponseCode.OkResponse, "Student Successfully Retrieved", result), cancellation: ct);
    }
}