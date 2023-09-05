using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Queries.Handlers;
using MagniFinance.Domain.Teacher.Models;
using Microsoft.EntityFrameworkCore;

namespace MagniFinance.Domain.Teacher.Queries.Handlers;

public class TeacherSummaryQueryHandler : QueryHandler<TeacherSummaryQuery, TeacherSummaryModel>
{
    public TeacherSummaryQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
    
    public override async Task<TeacherSummaryModel> Handle(TeacherSummaryQuery request, CancellationToken cancellationToken)
        => await GetTeacherSummary();

    private async Task<TeacherSummaryModel> GetTeacherSummary()
    {
        var teachers = await DbContext.Teachers.ToListAsync();
        return new TeacherSummaryModel()
        {   
            TotalTeachers = teachers.Count,
            TotalTeacherEnabled = teachers.Count(x => !x.IsDeleted),
            TotalTeacherDisabled =  teachers.Count(x => x.IsDeleted)
        };
    }
}