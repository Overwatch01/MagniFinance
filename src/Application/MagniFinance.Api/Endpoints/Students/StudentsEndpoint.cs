using MagniFinance.Domain.Core.Models;
using MagniFinance.Domain.Student.Models;
using MagniFinance.Domain.Student.Queries;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Students;

public class StudentsEndpoint  : Endpoint<StudentFilterModel, AppResponse<PaginationResultModel<StudentModel>, object>>
{
    private readonly IMediator _mediator;

    public StudentsEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Get("/students/{FirstName}/{LastName}/{Skip}/{Take}/{SortField}/{SortOrder}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(StudentFilterModel req, CancellationToken ct)
    {
        var query = new StudentsQuery { Filter = req };
        var result =  await _mediator.Send(query, ct);
        await SendAsync(new AppResponse<PaginationResultModel<StudentModel>, object>(ResponseCode.OkResponse, "Records retrieved successfully", result), cancellation: ct);
    }
}