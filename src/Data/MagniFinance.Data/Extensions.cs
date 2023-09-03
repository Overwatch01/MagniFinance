using MagniFinance.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MagniFinance.Data;


public static class Extensions
{
    public static IServiceCollection AddDataService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
        return services;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MagniFinanceDatabase");
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("MagniFinanceDatabase")));
        return services;
    }
    
    public static IServiceProvider AutoMigrateDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        try
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (dbContext.Database.IsRelational())
            {
                dbContext.Database.Migrate();
            }
        }
        catch
        {
            // ignored
        }
        return serviceProvider;
    }
}