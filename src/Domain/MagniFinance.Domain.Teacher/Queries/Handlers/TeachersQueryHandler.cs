using AutoMapper;
using MagniFinance.Data.Context;
using MagniFinance.Domain.Core.Models;
using MagniFinance.Domain.Core.Queries.Handlers;
using MagniFinance.Domain.Teacher.Models;
using Microsoft.EntityFrameworkCore;

namespace MagniFinance.Domain.Teacher.Queries.Handlers;

public class TeachersQueryHandler  : QueryHandler<TeachersQuery, PaginationResultModel<TeacherModel>>
{
    public TeachersQueryHandler(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
    
    public override async Task<PaginationResultModel<TeacherModel>> Handle(TeachersQuery request, CancellationToken cancellationToken)
        => await GetTeachers(request.Filter, cancellationToken);
    
    private async Task<PaginationResultModel<TeacherModel>> GetTeachers(TeacherFilterModel filter, CancellationToken cancellationToken)
    {
        var query = DbContext.Teachers.Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).AsQueryable();

        if (!string.IsNullOrEmpty(filter.FirstName))
            query = query.Where(x => x.User.FirstName.Contains(filter.FirstName));
        
        if (!string.IsNullOrEmpty(filter.LastName))
            query = query.Where(x => x.User.LastName.Contains(filter.LastName));

        if (filter.SortField?.Equals(nameof(filter.LastName), StringComparison.OrdinalIgnoreCase) == true)
            query = filter.SortOrder == PaginatorSortOrder.Asc ? query.OrderBy(x => x.User.LastName) : query.OrderByDescending(x => x.User.LastName);
        
        return new PaginationResultModel<TeacherModel>
        {
            TotalCount = await query.CountAsync(cancellationToken: cancellationToken),
            Data = await Mapper.ProjectTo<TeacherModel>(query.Skip(filter.Skip).Take(filter.Take)).ToListAsync(cancellationToken: cancellationToken)
        };
    }

}