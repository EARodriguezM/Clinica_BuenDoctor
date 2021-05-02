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

            
            CreateMap<LoginDto, LoginUser>();
            //CreateMap<RegisterDto, Login>();
            CreateMap<RegisterUserDto, DataUser>();
        }
        
    }
}