using MagniFinance.Domain.Subject.Commands;
using MagniFinance.Domain.Subject.Commands.Validators;
using MagniFinance.Domain.Subject.Models;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Subjects;

public class UpsertSubjectEndpoint : Endpoint<SubjectEditModel, AppResponse<string, object>>
{
    private readonly IMediator _mediator;

    public UpsertSubjectEndpoint(IMediator mediator) =>_mediator = mediator;
    
    public override void Configure()
    {
        Verbs(Http.POST, Http.PUT);
        Routes("/subjects");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(SubjectEditModel req, CancellationToken ct)
    {
        var command = new UpsertSubjectCommand
        {
            Data = req,
            ValidationResult = await new SubjectEditModelValidator().ValidateAsync(req, ct)
        };
        
        await _mediator.Send(command, ct);
        await SendAsync(new AppResponse<string, object>(ResponseCode.OkResponse, "Record updated successfully", ResponseCode.GetResponseDescription(ResponseCode.OkResponse)), cancellation: ct);
    }
}