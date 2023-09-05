using AutoMapper;
using MagniFinance.Data.Constants;
using MagniFinance.Domain.Student.Models;
using Microsoft.AspNetCore.Server.Kestrel.Https;

namespace MagniFinance.Domain.Student;

public class StudentMappingProfile : Profile
{
    public StudentMappingProfile()
    {
        CreateMap<StudentEditModel, Data.Models.Student>()
            .ForPath(dest => dest.User.FirstName, opt => opt.MapFrom(x => x.FirstName))
            .ForPath(dest => dest.User.LastName, opt => opt.MapFrom(x => x.LastName))
            .ForPath(dest => dest.User.OtherName, opt => opt.MapFrom(x => x.OtherName))
            .ForPath(dest => dest.User.Email, opt => opt.MapFrom(x => x.Email))
            .ForPath(dest => dest.User.UserType, opt => opt.MapFrom(x => UserType.Student));
        
        CreateMap<Data.Models.Student, Data.Models.Student>()
            .ForMember(dest => dest.RegistrationNumber, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Data.Models.Student, StudentModel>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.User.LastName))
            .ForMember(dest => dest.OtherName, opt => opt.MapFrom(x => x.User.OtherName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.User.Email))
            .ForMember(dest => dest.RegistrationNumber, opt => opt.MapFrom(x => x.RegistrationNumber));

        CreateMap<Data.Models.Student, StudentDetailModel>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.User.LastName))
            .ForMember(dest => dest.OtherName, opt => opt.MapFrom(x => x.User.OtherName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.User.Email))
            .ForMember(dest => dest.RegistrationNumber, opt => opt.MapFrom(x => x.RegistrationNumber));


    }
    
}