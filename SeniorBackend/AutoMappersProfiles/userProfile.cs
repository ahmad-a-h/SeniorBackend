using AutoMapper;
using SeniorBackend.Models;
using SeniorBackend.Models.DTOs;
using SeniorBackend.Models.DTOs.Class;
using SeniorBackend.Models.DTOs.sendFace;
using SeniorBackend.Models.IdentityModels;

namespace SeniorBackend.AutoMappersProfiles
{
    public class userProfile : Profile
    {
        public userProfile()
        {
            CreateMap<App_User, UserLoginRequest>();
            CreateMap<UserRegistrationRequest, App_User>();
        }
    }
}
