using MagniFinance.Domain.Core.Models;
using MagniFinance.Domain.Teacher.Models;
using MagniFinance.Domain.Teacher.Queries;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Teachers;

public class TeachersEndpoint : Endpoint<TeacherFilterModel, AppResponse<PaginationResultModel<TeacherModel>, object>>
{   
    private readonly IMediator _mediator;

    public TeachersEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Get("/teachers");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(TeacherFilterModel req, CancellationToken ct)
    {
        var query = new TeachersQuery { Filter = req };
        var result =  await _mediator.Send(query, ct);
        await SendAsync(new AppResponse<PaginationResultModel<TeacherModel>, object>(ResponseCode.OkResponse, "Records Successfully Retrieved", result), cancellation: ct);
    }
    
}