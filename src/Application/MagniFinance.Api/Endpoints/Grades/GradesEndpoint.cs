using MagniFinance.Domain.Core.Models;
using MagniFinance.Domain.Grade.Models;
using MagniFinance.Domain.Grade.Queries;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Grades;

public class GradesEndpoint : Endpoint<GradeFilterModel, AppResponse<PaginationResultModel<GradeModel>, object>>
{
    private readonly IMediator _mediator;

    public GradesEndpoint(IMediator mediator) => _mediator = mediator;
    
    public override void Configure()
    {
        Get("/grades/{Name}/{CourseCode}/{Skip}/{Take}/{SortField}/{SortOrder}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(GradeFilterModel req, CancellationToken ct)
    {
        var query = new GradesQuery { Filter = req };
        var result =  await _mediator.Send(query, ct);
        await SendAsync(new AppResponse<PaginationResultModel<GradeModel>, object>(ResponseCode.OkResponse, "Records Successfully Retrieved", result), cancellation: ct);
    }
}