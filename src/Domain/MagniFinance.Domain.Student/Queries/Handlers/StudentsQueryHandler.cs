using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Models;
using MagniFinance.Domain.Core.Queries.Handlers;
using MagniFinance.Domain.Student.Models;
using Microsoft.EntityFrameworkCore;

namespace MagniFinance.Domain.Student.Queries.Handlers;

public class StudentsQueryHandler : QueryHandler<StudentsQuery, PaginationResultModel<StudentModel>>
{
    public StudentsQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public override async Task<PaginationResultModel<StudentModel>> Handle(StudentsQuery request, CancellationToken cancellationToken)
        => await GetStudents(request.Filter, cancellationToken);
    
    private async Task<PaginationResultModel<StudentModel>> GetStudents(StudentFilterModel filter, CancellationToken cancellationToken)
    {
        var query = DbContext.Students.Include(x => x.User).Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).AsQueryable();

        if (!string.IsNullOrEmpty(filter.FirstName))
            query = query.Where(x => x.User.FirstName.Contains(filter.FirstName));
        
        if (!string.IsNullOrEmpty(filter.LastName))
            query = query.Where(x => x.User.LastName.Contains(filter.LastName));

        if (filter.SortField?.Equals(nameof(filter.LastName), StringComparison.OrdinalIgnoreCase) == true)
            query = filter.SortOrder == PaginatorSortOrder.Asc ? query.OrderBy(x => x.User.LastName) : query.OrderByDescending(x => x.User.LastName);
        
        return new PaginationResultModel<StudentModel>
        {
            TotalCount = await query.CountAsync(cancellationToken: cancellationToken),
            Data = await Mapper.ProjectTo<StudentModel>(query.Skip(filter.Skip).Take(filter.Take)).ToListAsync(cancellationToken: cancellationToken)
        };
    }
}