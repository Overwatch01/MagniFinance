using AutoMapper;
using MagniFinance.Domain.Course.Models;

namespace MagniFinance.Domain.Course;

public class CourseMappingProfile : Profile
{
    public CourseMappingProfile()
    {
        CreateMap<Data.Models.Course, CourseModel>()
            .ForMember(dest => dest.CourseCode, src => src.MapFrom(x => x.Code))
            .ForMember(dest => dest.DateModified, src => src.MapFrom(x => x.DateModified.ToShortDateString()));

        
        CreateMap<Data.Models.Course, CourseEditModel>().ReverseMap();
        
        CreateMap<Data.Models.Course, Data.Models.Course>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Data.Models.Course, CourseSubjectModel>()
            .ForMember(dest => dest.CourseCode, src => src.MapFrom(x => x.Code))
            .ForMember(dest => dest.Subjects, src => src.MapFrom(x => x.Subjects));

        CreateMap<Data.Models.Subject, CourseSubject>();

        CreateMap<Data.Models.Student, CourseStudentModel>()
            .ForMember(dest => dest.FirstName, src => src.MapFrom(x => x.User.FirstName))
            .ForMember(dest => dest.LastName, src => src.MapFrom(x => x.User.LastName))
            .ForMember(dest => dest.OtherName, src => src.MapFrom(x => x.User.OtherName))
            .ForMember(dest => dest.RegistrationNumber, src => src.MapFrom(x => x.RegistrationNumber))
            .ForMember(dest => dest.Email, src => src.MapFrom(x => x.User.Email))
            .ForMember(dest => dest.StudentId, src => src.MapFrom(x => x.Id))
            .ForMember(dest => dest.CourseId, src => src.MapFrom(x => x.Course.Id));

        CreateMap<Data.Models.Teacher, CourseTeacherModel>()
            .ForMember(dest => dest.FirstName, src => src.MapFrom(x => x.User.FirstName))
            .ForMember(dest => dest.LastName, src => src.MapFrom(x => x.User.LastName))
            .ForMember(dest => dest.OtherName, src => src.MapFrom(x => x.User.OtherName))
            .ForMember(dest => dest.AnnualSalary, src => src.MapFrom(x => x.AnnualSalary))
            .ForMember(dest => dest.Email, src => src.MapFrom(x => x.User.Email))
            .ForMember(dest => dest.TeacherId, src => src.MapFrom(x => x.Id))
            .ForMember(dest => dest.CourseId, src => src.MapFrom(x => x.Course.Id));

    }
}