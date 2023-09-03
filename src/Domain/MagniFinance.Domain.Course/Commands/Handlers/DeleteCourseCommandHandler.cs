using System.Net;
using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Commands.Handlers;
using MagniFinance.Infrastructure.ExceptionHandler;
using MagniFinance.Infrastructure.ResponseHandler;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MagniFinance.Domain.Course.Commands.Handlers;

public class DeleteCourseCommandHandler : CommandHandler<DeleteCourseCommand>
{
    public DeleteCourseCommandHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public override async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var existing = await DbContext.Courses.FirstOrDefaultAsync(x => x.Id == request.CourseId, cancellationToken: cancellationToken);
        if (existing == null)
            throw new AppException<object>(HttpStatusCode.NotFound, ResponseCode.RecordNotFound, ResponseCode.GetResponseDescription(ResponseCode.RecordNotFound));

        existing.IsDeleted = true;
        DbContext.Courses.Update(existing);
        await DbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}