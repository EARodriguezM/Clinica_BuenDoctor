using AutoMapper;

using BuenDoctorAPI.Entities;
using BuenDoctorAPI.Models;

namespace BuenDoctorAPI.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile(){
            //More Information in https://www.thecodebuzz.com/configure-automapper-asp-net-core-profile-map-object/
            //CreateMap<Source, Destination>();

            
            CreateMap<AuthenticateRequest, DataUser>()
                .ForMember(dest => dest.Email, o => o.MapFrom(src => src.Email))
            ;
            CreateMap<RegisterRequest, DataUser>()
                .ForMember(dest => dest.DataUserId, o => o.MapFrom(src => src.DataUserId))
                .ForMember(dest => dest.FirstName, o => o.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.SecondName, o => o.MapFrom(src => src.SecondName))
                .ForMember(dest => dest.FirstSurname, o => o.MapFrom(src => src.FirstSurname))
                .ForMember(dest => dest.SecondSurname, o => o.MapFrom(src => src.SecondSurname))
                .ForMember(dest => dest.Email, o => o.MapFrom(src => src.Email))
                .ForMember(dest => dest.Mobile, o => o.MapFrom(src => src.Mobile))
                .ForMember(dest => dest.ProfilePicture, o => o.MapFrom(src => src.ProfilePicture))
                .ForMember(dest => dest.UserTypeId, o => o.MapFrom(src => src.UserTypeId))
            ;
            CreateMap<UpdateRequest, DataUser>()
                .ForMember(dest => dest.DataUserId, o => o.MapFrom(src => src.DataUserId))
                .ForMember(dest => dest.FirstName, o => o.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.SecondName, o => o.MapFrom(src => src.SecondName))
                .ForMember(dest => dest.FirstSurname, o => o.MapFrom(src => src.FirstSurname))
                .ForMember(dest => dest.SecondSurname, o => o.MapFrom(src => src.SecondSurname))
                .ForMember(dest => dest.Email, o => o.MapFrom(src => src.Email))
                .ForMember(dest => dest.Mobile, o => o.MapFrom(src => src.Mobile))
                .ForMember(dest => dest.ProfilePicture, o => o.MapFrom(src => src.ProfilePicture))
                .ForMember(dest => dest.UserTypeId, o => o.MapFrom(src => src.UserTypeId))
            ;
            CreateMap<DataUser, AuthenticateResponse>();
        }
        
    }
}