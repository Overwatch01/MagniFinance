using MagniFinance.Domain.Student.Commands;
using MagniFinance.Domain.Student.Commands.Validators;
using MagniFinance.Domain.Student.Models;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;

namespace MagniFinance.Api.Endpoints.Students;

public class UpsertStudentEndpoint : Endpoint<StudentEditModel, AppResponse<string, object>>
{
    private readonly IMediator _mediator;

    public UpsertStudentEndpoint(IMediator mediator) => _mediator = mediator;
    
    
    public override void Configure()
    {
        Verbs(Http.POST, Http.PUT);
        Routes("/students");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(StudentEditModel req, CancellationToken ct)
    {
        var command = new UpsertStudentCommand
        {
            Data = req,
            ValidationResult = await new StudentEditModelValidator().ValidateAsync(req, ct)
        };
        await _mediator.Send(command, ct);
        await SendAsync(new AppResponse<string, object>(ResponseCode.OkResponse, "Record updated successfully", ResponseCode.GetResponseDescription(ResponseCode.OkResponse)), cancellation: ct);
    }
    
}