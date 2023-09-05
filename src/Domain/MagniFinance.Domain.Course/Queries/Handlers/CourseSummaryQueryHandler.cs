using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Queries.Handlers;
using MagniFinance.Domain.Course.Models;
using Microsoft.EntityFrameworkCore;

namespace MagniFinance.Domain.Course.Queries.Handlers;

public class CourseSummaryQueryHandler : QueryHandler<CourseSummaryQuery, CourseSummaryModel>
{
    public CourseSummaryQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public override async Task<CourseSummaryModel> Handle(CourseSummaryQuery request, CancellationToken cancellationToken)
        => await GetCourseSummary();

    private async Task<CourseSummaryModel> GetCourseSummary()
    {
        var courses = await DbContext.Courses.ToListAsync();
        return new CourseSummaryModel
        {   
            TotalCourse = courses.Count,
            TotalEnabled = courses.Count(x => !x.IsDeleted),
            TotalDisabled =  courses.Count(x => x.IsDeleted)
        };
    }
}