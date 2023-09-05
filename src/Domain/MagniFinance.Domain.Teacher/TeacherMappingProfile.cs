using AutoMapper;
using MagniFinance.Data.Constants;
using MagniFinance.Domain.Teacher.Models;

namespace MagniFinance.Domain.Teacher;

public class TeacherMappingProfile : Profile
{
    public TeacherMappingProfile()
    {
        CreateMap<TeacherEditModel, Data.Models.Teacher>()
            .ForPath(dest => dest.User.FirstName, opt => opt.MapFrom(x => x.FirstName))
            .ForPath(dest => dest.User.LastName, opt => opt.MapFrom(x => x.LastName))
            .ForPath(dest => dest.User.OtherName, opt => opt.MapFrom(x => x.OtherName))
            .ForPath(dest => dest.User.Email, opt => opt.MapFrom(x => x.Email))
            .ForPath(dest => dest.User.UserType, opt => opt.MapFrom(x => UserType.Teacher));
        
        CreateMap<Data.Models.Teacher, Data.Models.Teacher>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Data.Models.Teacher, TeacherModel>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.User.LastName))
            .ForMember(dest => dest.OtherName, opt => opt.MapFrom(x => x.User.OtherName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.User.Email));

        CreateMap<Data.Models.Teacher, TeacherDetailModel>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.User.LastName))
            .ForMember(dest => dest.OtherName, opt => opt.MapFrom(x => x.User.OtherName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.User.Email));


    }   
}