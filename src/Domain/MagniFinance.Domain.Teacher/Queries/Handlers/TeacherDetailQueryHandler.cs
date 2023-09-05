using System.Net;
using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Queries.Handlers;
using MagniFinance.Domain.Teacher.Models;
using MagniFinance.Infrastructure.ExceptionHandler;
using MagniFinance.Infrastructure.ResponseHandler;
using Microsoft.EntityFrameworkCore;

namespace MagniFinance.Domain.Teacher.Queries.Handlers;

public class TeacherDetailQueryHandler : QueryHandler<TeacherDetailQuery, TeacherDetailModel>
{
    public TeacherDetailQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
    
    public override async Task<TeacherDetailModel> Handle(TeacherDetailQuery request, CancellationToken cancellationToken)
        => await GetTeacherDetail(request.TeacherId).SingleOrDefaultAsync(cancellationToken: cancellationToken) ??  throw new AppException<object>(HttpStatusCode.NotFound, ResponseCode.RecordNotFound, ResponseCode.GetResponseDescription(ResponseCode.RecordNotFound));

    private IQueryable<TeacherDetailModel> GetTeacherDetail(int teacherId)
    {
        var query = DbContext.Teachers.Include(x => x.User).Where(x => x.Id == teacherId && !x.IsDeleted);
        return Mapper.ProjectTo<TeacherDetailModel>(query);
    }
    
}