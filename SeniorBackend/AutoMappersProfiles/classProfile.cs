using AutoMapper;
using SeniorBackend.Models;
using SeniorBackend.Models.DTOs.Class;

namespace SeniorBackend.AutoMappersProfiles
{
    public class classProfile : Profile
    {
        public classProfile()
        {
            CreateMap<Class, classDto>();
        }
}
}
