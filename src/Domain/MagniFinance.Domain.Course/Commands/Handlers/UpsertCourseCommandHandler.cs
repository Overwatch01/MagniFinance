using System.Net;
using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Commands.Handlers;
using MagniFinance.Infrastructure.ExceptionHandler;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MagniFinance.Domain.Course.Commands.Handlers;

public class UpsertCourseCommandHandler : CommandHandler<UpsertCourseCommand>
{
    private readonly ILogger<UpsertCourseCommandHandler> _logger;

    public UpsertCourseCommandHandler(ILogger<UpsertCourseCommandHandler> logger, ApplicationDbContext dbContext,
        IMapper mapper) : base(dbContext, mapper)
        =>  _logger = logger;
    
    

    public override async Task<Unit> Handle(UpsertCourseCommand request, CancellationToken cancellationToken)
    {
        request.IsValid();
        
        var entity = Mapper.Map<Data.Models.Course>(request.Data);
        var existing = await DbContext.Courses.FirstOrDefaultAsync(x => x.Id == entity.Id, cancellationToken: cancellationToken);
        switch (existing)
        {
            case null when entity.Id != 0:
                throw new AppException<object>(HttpStatusCode.NotFound, ResponseCode.RecordNotFound, ResponseCode.GetResponseDescription(ResponseCode.RecordNotFound));
            case null:
                _logger.LogInformation("Create new course for {EntityName}", entity.Name);
                await DbContext.Courses.AddAsync(entity, cancellationToken);
                break;
            default:
                _logger.LogInformation("Updating course for {EntityName}", entity.Name);
                Mapper.Map(entity, existing);
                DbContext.Courses.Update(existing);
                break;
        }
        await DbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}