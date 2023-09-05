using System.Net;
using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Queries.Handlers;
using MagniFinance.Domain.Course.Models;
using MagniFinance.Infrastructure.ExceptionHandler;
using MagniFinance.Infrastructure.ResponseHandler;
using Microsoft.EntityFrameworkCore;

namespace MagniFinance.Domain.Course.Queries.Handlers;

public class CourseTeacherQueryHandler : QueryHandler<CourseTeacherQuery, CourseTeacherModel>
{
    public CourseTeacherQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
    
    public override async Task<CourseTeacherModel> Handle(CourseTeacherQuery request, CancellationToken cancellationToken)
        => await GetCourseTeacher(request.CourseId).SingleOrDefaultAsync(cancellationToken: cancellationToken) ??  throw new AppException<object>(HttpStatusCode.NotFound, ResponseCode.RecordNotFound, ResponseCode.GetResponseDescription(ResponseCode.RecordNotFound));

    private IQueryable<CourseTeacherModel> GetCourseTeacher(int courseId)
    {
        var query = DbContext.Teachers.Include(x => x.Course).Where(x => x.Course.Id == courseId && !x.IsDeleted);
        return Mapper.ProjectTo<CourseTeacherModel>(query);
    }
}