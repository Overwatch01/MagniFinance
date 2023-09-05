using System.Reflection;
using MagniFinance.Domain.Course;
using MagniFinance.Domain.Course.Commands;
using MagniFinance.Domain.Student;
using MagniFinance.Domain.Student.Commands;
using MagniFinance.Domain.Teacher;
using MagniFinance.Domain.Teacher.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MagniFinance.Domain.Shared;

public static class Extensions
{
    public static void AddDomainService(this IServiceCollection services)
    {
        services
            .AddMappingProfiles()
            .AddMediatrAssemblies();
    }

    private static IServiceCollection AddMappingProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(StudentMappingProfile).Assembly,
            typeof(CourseMappingProfile).Assembly,
            typeof(TeacherMappingProfile).Assembly
        );
        return services;
    }
    
    private static void AddMediatrAssemblies(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(
            typeof(UpsertStudentCommand).Assembly,
            typeof(UpsertCourseCommand).Assembly,
            typeof(UpsertTeacherCommand).Assembly
        ));
    }
}