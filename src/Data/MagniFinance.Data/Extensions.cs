using System.Collections;
using Bogus;
using MagniFinance.Data.Constants;
using MagniFinance.Data.Context;
using MagniFinance.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MagniFinance.Data;


public static class Extensions
{
    public static void AddDataService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MagniFinanceDatabase");
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("MagniFinanceDatabase")));
    }
    
    public static void AutoMigrateDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        try
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (!dbContext.Database.IsRelational()) return;
            
            dbContext.Database.Migrate();
            
            if (!dbContext.Subjects.Any())
                SeedSubjects(dbContext).GetAwaiter().GetResult();
            
            if (!dbContext.Courses.Any())
                SeedCourses(dbContext).GetAwaiter().GetResult();

            if (!dbContext.Students.Any())
                SeedStudents(dbContext, 300).GetAwaiter().GetResult();
            
            if (!dbContext.Teachers.Any())
                SeedTeachers(dbContext, 300).GetAwaiter().GetResult();
        }
        catch
        {
            // ignored
        }
    }

    private static async Task SeedSubjects(DbContext applicationDbContext)
    {   
        var subjects = GetSubjects().ToList();
        
        await applicationDbContext.AddRangeAsync(subjects);
        await applicationDbContext.SaveChangesAsync();
    }
    
    private static async Task SeedCourses(ApplicationDbContext applicationDbContext)
    {
        var subjects = await applicationDbContext.Subjects.ToListAsync();
        var courses = GetCourses(subjects).ToList();
        
        await applicationDbContext.AddRangeAsync(courses);
        await applicationDbContext.SaveChangesAsync();
    }
    
    private static async Task SeedStudents(ApplicationDbContext applicationDbContext, int count)
    {   
        var courses = await applicationDbContext.Courses.ToListAsync();
        
        var users = GeUsers(count, UserType.Student).ToList();
        var students = GetStudents(count, users, courses);
        
        await applicationDbContext.AddRangeAsync(students);
        await applicationDbContext.SaveChangesAsync();
    }
    
    private static async Task SeedTeachers(ApplicationDbContext applicationDbContext, int count)
    {
        var courses = await applicationDbContext.Courses.ToListAsync();
        count = courses.Count;
        
        var users = GeUsers(count, UserType.Teacher).ToList();
        var teachers = GetTeachers(count, users, courses);
        
        await applicationDbContext.AddRangeAsync(teachers);
        await applicationDbContext.SaveChangesAsync();
    }

    private static IEnumerable<Subject> GetSubjects()
    {
        var subjects = new List<Subject>();
        var keys = CourseSubjects.Values.SelectMany(x => x).OrderBy(x => x).ToList();
        int i = 1;
        foreach (var key in keys)
        {
            subjects.Add(new Subject
            {
                Name = key,
                Code = $"MFS0{i}"
            });
            i++;
        }

        return subjects;
    }

    private static IEnumerable<Course> GetCourses(List<Subject> subjects)
    {
        var courses = new List<Course>();
        
        int i = 1;
        foreach (var courseSubjectsKey in CourseSubjects.Keys)
        {
            courses.Add(new Course()
            {
                Name = courseSubjectsKey,
                Code = $"MFC0{i}",
                Duration = new Random().Next(1, 4),
                Subjects = subjects.FindAll(x => CourseSubjects[courseSubjectsKey].Contains(x.Name))
            });
            i++;
        }
        return courses;
    }

    private static IEnumerable<User> GeUsers(int count, UserType userType)
    {
        var fake = new Faker<User>()
            .RuleFor(c => c.FirstName, f => f.Person.FirstName)
            .RuleFor(c => c.OtherName, f => f.Person.UserName)
            .RuleFor(c => c.LastName, f => f.Person.LastName)
            .RuleFor(c => c.Email, f => f.Person.Email)
            .RuleFor(c => c.Email, (f,u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(c => c.UserType, f => userType);

        return fake.Generate(count);
    }
    
    private static IEnumerable<Student> GetStudents(int count, List<User> users, List<Course> courses)
    {
        var fake = new Faker<Student>()
            .RuleFor(c => c.RegistrationNumber, f => $"{f.Random.Number(1111, 9999)}")
            .RuleFor(c => c.User, f => GetRandomUniqueList(users))
            .RuleFor(c => c.Course, f => f.Random.ListItem(courses));
        return fake.Generate(count);
    }
    
    private static IEnumerable<Teacher> GetTeachers(int count, List<User> users, List<Course> courses)
    {
        var fake = new Faker<Teacher>()
            .RuleFor(c => c.AnnualSalary, f => f.Random.Double(48000, 60000))
            .RuleFor(c => c.User, f => GetRandomUniqueList(users))
            .RuleFor(c => c.Course, f => GetRandomUniqueList(courses));
        return fake.Generate(count);
    }
    
    private static object? GetRandomUniqueList(IList list)
    {
        int random = new Random().Next(0, list.Count - 1);
        var item =  list[random];
        list.RemoveAt(random);
        return item;
    }


    private static Dictionary<string, string[]> CourseSubjects = new Dictionary<string, string[]>
    {
        {
            "Agriculture and Veterinary Medicine", 
            new [] 
                { 
                    "Agriculture",
                    "Farm Management",
                    "Horticulture",
                    "Plant and Crop Sciences",
                    "Veterinary Medicine"
                }
        },
        {
            "Applied and Pure Science", 
            new [] 
            { 
                "Astronomy",
                "Biology",
                "Biomedical Sciences",
                "Chemistry",
                "Earth Sciences",
                "Environmental Sciences",
                "Food Science and Technology",
                "Forensic science",
                "General Sciences",
                "Life Sciences",
                "Materials Sciences",
                "Mathematics",
                "Physical Geography",
                "Physics",
                "Sports Science"
            }
        },
        {
            "Architecture and Construction", 
            new [] 
            { 
                "Architecture",
                "Built Environment",
                "Construction",
                "Maintenance Services",
                "PlanningProperty Management",
                "Surveying"
            }
        },
        {
            "Business and Management", 
            new [] 
            { 
                "Accounting",
                "Business Studies",
                "E-Commerce",
                "Entrepreneurship",
                "Finance",
                "Human Resource Management",
                "Management",
                "Marketing",
                "Office Administration",
                "Quality Management",
                "Retail",
                "Transportation and Logistics",
            }
        },
        {
            "Computer Science and IT", 
            new [] 
            { 
                "Computer Science",
                "Computing",
                "IT",
                "Multimedia",
                "Software"
            }
        },
        {
            "Creative Arts and Design", 
            new [] 
            { 
                "Art",
                "Art Administration",
                "Crafts",
                "Dance",
                "Fashion and Textile Design",
                "Graphic Design",
                "Industrial Design",
                "Interior Design",
                "Music",
                "Non-industrial Design",
                "Theatre and Drama Studies"
            }
        },
        {
            "Education and Training", 
            new [] 
            { 
                "Adult Education",
                "CPD",
                "Career Advice",
                "Childhood Education",
                "Coaching",
                "Education Learning",
                "Education Management",
                "Education Research",
                "Educational Psychology",
                "Pedagogy",
                "Special Education",
                "Specialised Teaching",
                "Teacher Training PGCE"
            }
        },
        {
            "Engineering", 
            new [] 
            { 
                "Aerospace Engineering",
                "Biomedical Engineering",
                "Chemical and Materials Engineering",
                "Civil Engineering",
                "Electrical Engineering",
                "Electronic Engineering",
                "Environmental Engineering",
                "General Engineering and Technology",
                "Manufacturing and Production",
                "Marine Engineering",
                "Mechanical Engineering",
                "Metallurgy",
                "Mining and Oil & Gas Operations",
                "Power and Energy Engineering",
                "Quality Control",
                "Structural Engineering",
                "Telecommunications",
                "Vehicle Engineering"
            }
        },
        {
            "Health and Medicine", 
            new [] 
            { 
                "Complementary Health",
                "Counselling",
                "Dentistry",
                "Health Studies",
                "Health and Safety",
                "Medicine",
                "Midwifery",
                "Nursing",
                "Nutrition and Health",
                "Ophthalmology",
                "Pharmacology",
                "Physiology",
                "Physiotherapy",
                "Psychology",
                "Public Health"
            }
        },
        {
            "Humanities", 
            new [] 
            { 
                "Archaeology",
                "Classics",
                "Cultural Studies",
                "English Studies",
                "General Studies",
                "History",
                "Languages",
                "Literature",
                "Museum Studies",
                "Philosophy",
                "Regional Studies",
                "Religious Studies"
            }
        },
        {
            "Law", 
            new [] 
            { 
                "Civil Law",
                "Criminal Law",
                "International Law",
                "Legal Advice",
                "Legal Studies",
                "Public Law"
            }
        },
        {
            "MBA",
            Array.Empty<string>()
        },
        {
            "Personal Care and Fitness", 
            new [] 
            { 
                "Beauty Therapy",
                "Hairdressing",
                "Health and Fitness",
                "Massage",
                "Therapeutic"
            }
        },
        {
            "Social Studies and Media", 
            new [] 
            { 
                "Anthropology",
                "Economics",
                "Environmental Management",
                "Film & Television",
                "Human Geography",
                "International Development",
                "International relations",
                "Journalism",
                "Library Studies",
                "Linguistics",
                "Media",
                "Photography",
                "Politics",
                "Public Administration",
                "Social Sciences",
                "Social Work",
                "Sociology",
                "Writing"
            }
        },
        {
            "Travel and Hospitality", 
            new [] 
            { 
                "Aviation",
                "Catering",
                "Food and Drink Production",
                "Hospitality",
                "Hotel Management",
                "Leisure Management",
                "Travel and Tourism"
            }
        },
    };
}