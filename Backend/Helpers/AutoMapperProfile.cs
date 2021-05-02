using AutoMapper;

using BuenDoctorAPI.Models.Data;
using BuenDoctorAPI.Models.Login;

using BuenDoctorAPI.Dtos.Data;
using BuenDoctorAPI.Dtos.Login;

namespace BuenDoctorAPI.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile(){
            //More Information in https://www.thecodebuzz.com/configure-automapper-asp-net-core-profile-map-object/
            //CreateMap<Source, Destination>();

            
            CreateMap<LoginDto, LoginUser>()
                .ForMember(dest => dest.LoginUserId, o => o.MapFrom(src => src.UserId))            
            ;
            //CreateMap<RegisterDto, Login>();
            CreateMap<RegisterUserDto, DataUser>()
                .ForMember(dest => dest.DataUserId, o => o.MapFrom(src => src.UserId))
                .ForMember(dest => dest.FirstName, o => o.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.SecondName, o => o.MapFrom(src => src.SecondName))
                .ForMember(dest => dest.FirstSurname, o => o.MapFrom(src => src.FirstSurname))
                .ForMember(dest => dest.SecondSurname, o => o.MapFrom(src => src.SecondSurname))
                .ForMember(dest => dest.Email, o => o.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, o => o.MapFrom(src => src.Phone))
                .ForMember(dest => dest.ProfilePicture, o => o.MapFrom(src => src.ProfilePicture))
            ;
        }
        
    }
}