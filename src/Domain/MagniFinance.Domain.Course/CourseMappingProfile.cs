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

        CreateMap<Data.Models.Course, CourseDetailModel>()
            .ForMember(dest => dest.CourseCode, src => src.MapFrom(x => x.Code))
            .ForMember(dest => dest.DateModified, src => src.MapFrom(x => x.DateModified.ToShortDateString()));

        
        CreateMap<Data.Models.Course, CourseEditModel>().ReverseMap();
        
        CreateMap<Data.Models.Course, Data.Models.Course>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}