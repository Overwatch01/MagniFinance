using System.Net;
using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Commands.Handlers;
using MagniFinance.Infrastructure.ExceptionHandler;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MagniFinance.Domain.Teacher.Commands.Handlers;

public class DeleteTeacherCommandHandler : CommandHandler<DeleteTeacherCommand>
{
    public DeleteTeacherCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public override async Task<Unit> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
    {
        var existing = await DbContext.Teachers.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == request.TeacherId, cancellationToken: cancellationToken);
        if (existing == null)
            throw new AppException<object>(HttpStatusCode.NotFound, ResponseCode.RecordNotFound, ResponseCode.GetResponseDescription(ResponseCode.RecordNotFound));

        existing.IsDeleted = true;
        existing.User.IsDeleted = true;
        DbContext.Teachers.Update(existing);
        await DbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}