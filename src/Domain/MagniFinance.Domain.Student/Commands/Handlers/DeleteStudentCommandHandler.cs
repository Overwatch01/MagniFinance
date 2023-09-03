using System.Net;
using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Commands.Handlers;
using MagniFinance.Infrastructure.ExceptionHandler;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MagniFinance.Domain.Student.Commands.Handlers;

public class DeleteStudentCommandHandler : CommandHandler<DeleteStudentCommand>
{
    public DeleteStudentCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public override async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var existing = await DbContext.Students.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == request.StudentId, cancellationToken: cancellationToken);
        if (existing == null)
            throw new AppException<object>(HttpStatusCode.NotFound, ResponseCode.RecordNotFound, ResponseCode.GetResponseDescription(ResponseCode.RecordNotFound));

        existing.IsDeleted = true;
        existing.User.IsDeleted = true;
        DbContext.Students.Update(existing);
        await DbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}