using System.Net;
using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Commands.Handlers;
using MagniFinance.Infrastructure.ExceptionHandler;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MagniFinance.Domain.Teacher.Commands.Handlers;

public class UpsertTeacherCommandHandler :  CommandHandler<UpsertTeacherCommand>
{
    private readonly ILogger<UpsertTeacherCommandHandler> _logger;
    
    public UpsertTeacherCommandHandler(ILogger<UpsertTeacherCommandHandler> logger, ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        => _logger = logger;
    
    public override async Task<Unit> Handle(UpsertTeacherCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating or Updating teacher info");
        
        request.IsValid();
        var entity = Mapper.Map<Data.Models.Teacher>(request.Data);
        var existing = await DbContext.Teachers.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == entity.Id, cancellationToken: cancellationToken);
        switch (existing)
        {
            case null when entity.Id != 0:
                throw new AppException<object>(HttpStatusCode.NotFound, ResponseCode.RecordNotFound, ResponseCode.GetResponseDescription(ResponseCode.RecordNotFound));
            case null:
                await DbContext.Teachers.AddAsync(entity, cancellationToken);
                break;
            default:
                Mapper.Map(entity, existing);
                DbContext.Teachers.Update(existing);
                break;
        }
        await DbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }

}