using System.Net;
using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Queries.Handlers;
using MagniFinance.Domain.Course.Models;
using MagniFinance.Infrastructure.ExceptionHandler;
using MagniFinance.Infrastructure.ResponseHandler;
using Microsoft.EntityFrameworkCore;

namespace MagniFinance.Domain.Course.Queries.Handlers;

public class CourseSubjectsQueryHandler : QueryHandler<CourseSubjectsQuery, CourseSubjectModel>
{
    public CourseSubjectsQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public override async Task<CourseSubjectModel> Handle(CourseSubjectsQuery request, CancellationToken cancellationToken)
        => await GetCourseSubjects(request.CourseId).SingleOrDefaultAsync(cancellationToken: cancellationToken) ??  throw new AppException<object>(HttpStatusCode.NotFound, ResponseCode.RecordNotFound, ResponseCode.GetResponseDescription(ResponseCode.RecordNotFound));

    private IQueryable<CourseSubjectModel> GetCourseSubjects(int courseId)
    {
        var query = DbContext.Courses.Include(x => x.Subjects).Where(x => x.Id == courseId && !x.IsDeleted);
        return Mapper.ProjectTo<CourseSubjectModel>(query);
    }
}