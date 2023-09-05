using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Queries.Handlers;
using MagniFinance.Domain.Student.Models;
using Microsoft.EntityFrameworkCore;

namespace MagniFinance.Domain.Student.Queries.Handlers;

public class StudentSummaryQueryHandler : QueryHandler<StudentSummaryQuery, StudentSummaryModel>
{
    public StudentSummaryQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public override async Task<StudentSummaryModel> Handle(StudentSummaryQuery request, CancellationToken cancellationToken)
        => await GetStudentSummary();

    private async Task<StudentSummaryModel> GetStudentSummary()
    {
        var students = await DbContext.Students.ToListAsync();
        return new StudentSummaryModel
        {   
            TotalStudent = students.Count,
            TotalStudentEnabled = students.Count(x => !x.IsDeleted),
            TotalStudentDisabled =  students.Count(x => x.IsDeleted)
        };
    }
}