using System.Net;
using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Queries.Handlers;
using MagniFinance.Domain.Student.Models;
using MagniFinance.Infrastructure.ExceptionHandler;
using MagniFinance.Infrastructure.ResponseHandler;
using Microsoft.EntityFrameworkCore;

namespace MagniFinance.Domain.Student.Queries.Handlers;

public class StudentDetailQueryHandler : QueryHandler<StudentDetailQuery, StudentDetailModel>
{
    public StudentDetailQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public override async Task<StudentDetailModel> Handle(StudentDetailQuery request, CancellationToken cancellationToken)
        => await GetStudentDetail(request.StudentId).SingleOrDefaultAsync(cancellationToken: cancellationToken) ??  throw new AppException<object>(HttpStatusCode.NotFound, ResponseCode.RecordNotFound, ResponseCode.GetResponseDescription(ResponseCode.RecordNotFound));

    private IQueryable<StudentDetailModel> GetStudentDetail(int studentId)
    {
        var query = DbContext.Students.Include(x => x.User).Where(x => x.Id == studentId && !x.IsDeleted);
        return Mapper.ProjectTo<StudentDetailModel>(query);
    }
}