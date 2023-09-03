using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Models;
using MagniFinance.Domain.Core.Queries.Handlers;
using MagniFinance.Domain.Course.Models;
using Microsoft.EntityFrameworkCore;

namespace MagniFinance.Domain.Course.Queries.Handlers;

public class CoursesQueryHandler : QueryHandler<CoursesQuery, PaginationResultModel<CourseModel>>
{
    public CoursesQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    
    public override async Task<PaginationResultModel<CourseModel>> Handle(CoursesQuery request, CancellationToken cancellationToken)
     => await GetCourses(request.Filter, cancellationToken);
    
    private async Task<PaginationResultModel<CourseModel>> GetCourses(CourseFilterModel filter, CancellationToken cancellationToken)
    {
        var query = DbContext.Courses.Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).AsQueryable();

        if (!string.IsNullOrEmpty(filter.Name))
            query = query.Where(x => x.Name.Contains(filter.Name));
        
        if (!string.IsNullOrEmpty(filter.CourseCode))
            query = query.Where(x => x.Code.Contains(filter.CourseCode));

        if (filter.SortField?.Equals(nameof(CourseModel.Name), StringComparison.OrdinalIgnoreCase) == true)
            query = filter.SortOrder == PaginatorSortOrder.Asc ? query.OrderBy(x => x.Name) : query.OrderByDescending(x => x.Name);
        
        return new PaginationResultModel<CourseModel>
        {
            TotalCount = await query.CountAsync(cancellationToken: cancellationToken),
            Data = await Mapper.ProjectTo<CourseModel>(query.Skip(filter.Skip).Take(filter.Take)).ToListAsync(cancellationToken: cancellationToken)
        };
    }
}