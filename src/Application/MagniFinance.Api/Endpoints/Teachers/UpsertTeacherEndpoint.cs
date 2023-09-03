using MagniFinance.Domain.Teacher.Commands;
using MagniFinance.Domain.Teacher.Commands.Validators;
using MagniFinance.Domain.Teacher.Models;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Teachers;

public class UpsertTeacherEndpoint : Endpoint<TeacherEditModel, AppResponse<string, object>>
{
    private readonly IMediator _mediator;

    public UpsertTeacherEndpoint(IMediator mediator) =>_mediator = mediator;
    
    public override void Configure()
    {
        Verbs(Http.POST, Http.PUT);
        Routes("/teachers");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(TeacherEditModel req, CancellationToken ct)
    {
        var command = new UpsertTeacherCommand
        {
            Data = req,
            ValidationResult = await new TeacherEditModelValidator().ValidateAsync(req, ct)
        };
        
        await _mediator.Send(command, ct);
        await SendAsync(new AppResponse<string, object>(ResponseCode.OkResponse, "Record updated successfully", ResponseCode.GetResponseDescription(ResponseCode.OkResponse)), cancellation: ct);
    }
}