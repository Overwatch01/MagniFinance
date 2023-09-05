using MagniFinance.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MagniFinance.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Subject> Subjects { get; set; }
  
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddTimestamps();
        return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(true);
    }
    
    private void AddTimestamps()
    {
        const string localTimeZoneId = "Africa/Lagos";
        DateTime now;
        try
        {
            var localTimeZone = TimeZoneInfo.FindSystemTimeZoneById(localTimeZoneId);
            now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, localTimeZone);
        }
        catch (Exception)
        {
            now = DateTime.UtcNow;
        }
        
        var entityEntries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
        foreach (var entity in entityEntries)
        {
            if (entity.State == EntityState.Added)
            {
                ((BaseEntity)entity.Entity).DateCreated = now;
            }
            ((BaseEntity)entity.Entity).DateModified = now;
        }
    }
}