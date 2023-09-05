using System.Net;
using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Data.Models;
using MagniFinance.Domain.Core.Commands.Handlers;
using MagniFinance.Domain.Student.Models;
using MagniFinance.Infrastructure.ExceptionHandler;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MagniFinance.Domain.Student.Commands.Handlers;

public class UpsertStudentCommandHandler : CommandHandler<UpsertStudentCommand>
{
    private readonly ILogger<UpsertStudentCommandHandler> _logger;
    
    public UpsertStudentCommandHandler(ILogger<UpsertStudentCommandHandler> logger, ApplicationDbContext context, IMapper mapper) : base(context, mapper)
     => _logger = logger;
    

    public override async Task<Unit> Handle(UpsertStudentCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating or Updating student info");
        
        request.IsValid();
        var entity = Mapper.Map<Data.Models.Student>(request.Data);
        var existing = await DbContext.Students.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == entity.Id, cancellationToken: cancellationToken);
        switch (existing)
        {
            case null when entity.Id != 0:
                throw new AppException<object>(HttpStatusCode.NotFound, ResponseCode.RecordNotFound, ResponseCode.GetResponseDescription(ResponseCode.RecordNotFound));
            case null:
                entity.RegistrationNumber = $"{new Random().Next(1111, 9999)}";
                await DbContext.Students.AddAsync(entity, cancellationToken);
                break;
            default:
                Mapper.Map(entity, existing);
                DbContext.Students.Update(existing);
                break;
        }
        await DbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}