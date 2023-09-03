using System.Net;
using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Queries.Handlers;
using MagniFinance.Domain.Course.Models;
using MagniFinance.Infrastructure.ExceptionHandler;
using MagniFinance.Infrastructure.ResponseHandler;
using Microsoft.EntityFrameworkCore;

namespace MagniFinance.Domain.Course.Queries.Handlers;

public class CourseDetailQueryHandler : QueryHandler<CourseDetailQuery, CourseDetailModel>
{
    public CourseDetailQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public override async Task<CourseDetailModel> Handle(CourseDetailQuery request, CancellationToken cancellationToken)
        => await GetCourseDetail(request.CourseId).SingleOrDefaultAsync(cancellationToken: cancellationToken) ??  throw new AppException<object>(HttpStatusCode.NotFound, ResponseCode.RecordNotFound, ResponseCode.GetResponseDescription(ResponseCode.RecordNotFound));

    private IQueryable<CourseDetailModel> GetCourseDetail(int courseId)
    {
        var query = DbContext.Courses.Where(x => x.Id == courseId && !x.IsDeleted);
        return Mapper.ProjectTo<CourseDetailModel>(query);
    }
}