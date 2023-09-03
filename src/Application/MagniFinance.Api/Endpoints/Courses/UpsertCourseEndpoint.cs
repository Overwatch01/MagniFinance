using FluentValidation;
using MagniFinance.Domain.Course.Commands;
using MagniFinance.Domain.Course.Commands.Validators;
using MagniFinance.Domain.Course.Models;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;
using Namotion.Reflection;

namespace MagniFinance.Api.Endpoints.Courses;

public class UpsertCourseEndpoint : Endpoint<CourseEditModel, AppResponse<string, object>>
{
    private readonly IMediator _mediator;

    public UpsertCourseEndpoint(IMediator mediator) =>_mediator = mediator;
    
    public override void Configure()
    {
        Verbs(Http.POST, Http.PUT);
        Routes("/courses");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CourseEditModel req, CancellationToken ct)
    {
        var command = new UpsertCourseCommand
        {
            Data = req,
            ValidationResult = await new CourseEditModelValidator().ValidateAsync(req, ct)
        };
        
        await _mediator.Send(command, ct);
        await SendAsync(new AppResponse<string, object>(ResponseCode.OkResponse, "Record updated successfully", ResponseCode.GetResponseDescription(ResponseCode.OkResponse)), cancellation: ct);
    }
}