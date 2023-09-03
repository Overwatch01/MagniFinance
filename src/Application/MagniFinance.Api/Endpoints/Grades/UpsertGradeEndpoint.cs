using MagniFinance.Domain.Grade.Commands;
using MagniFinance.Domain.Grade.Commands.Validators;
using MagniFinance.Domain.Grade.Models;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Grades;

public class UpsertGradeEndpoint : Endpoint<GradeEditModel, AppResponse<string, object>>
{
    private readonly IMediator _mediator;

    public UpsertGradeEndpoint(IMediator mediator) =>_mediator = mediator;
    
    public override void Configure()
    {
        Verbs(Http.POST, Http.PUT);
        Routes("/grades");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(GradeEditModel req, CancellationToken ct)
    {
        var command = new UpsertGradeCommand()
        {
            Data = req,
            ValidationResult = await new GradeEditModelValidator().ValidateAsync(req, ct)
        };
        
        await _mediator.Send(command, ct);
        await SendAsync(new AppResponse<string, object>(ResponseCode.OkResponse, "Record updated successfully", ResponseCode.GetResponseDescription(ResponseCode.OkResponse)), cancellation: ct);
    }
}