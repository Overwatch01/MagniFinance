using System.Net;
using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Queries.Handlers;
using MagniFinance.Domain.Course.Models;
using MagniFinance.Infrastructure.ExceptionHandler;
using MagniFinance.Infrastructure.ResponseHandler;
using Microsoft.EntityFrameworkCore;

namespace MagniFinance.Domain.Course.Queries.Handlers;

public class CourseStudentsQueryHandler : QueryHandler<CourseStudentsQuery, IEnumerable<CourseStudentModel>>
{
    public CourseStudentsQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
    
    public override async Task<IEnumerable<CourseStudentModel>> Handle(CourseStudentsQuery request, CancellationToken cancellationToken)
        => await GetCourseStudents(request.CourseId).ToListAsync(cancellationToken: cancellationToken) ??  throw new AppException<object>(HttpStatusCode.NotFound, ResponseCode.RecordNotFound, ResponseCode.GetResponseDescription(ResponseCode.RecordNotFound));

    private IQueryable<CourseStudentModel> GetCourseStudents(int courseId)
    {
        var query = DbContext.Students.Include(x => x.Course).Include(x => x.User).Where(x => x.Course.Id == courseId && !x.IsDeleted);
        return Mapper.ProjectTo<CourseStudentModel>(query);
    }
}