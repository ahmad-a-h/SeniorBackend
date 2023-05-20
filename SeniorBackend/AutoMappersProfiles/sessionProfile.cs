using AutoMapper;
using SeniorBackend.Models;
using SeniorBackend.Models.DTOs.Session;

namespace SeniorBackend.AutoMappersProfiles
{
    public class sessionProfile : Profile
    {
        public sessionProfile()
        {
            CreateMap<Session, sessionDto>();
            CreateMap<Session, GetCourseForSessionDto>();
        }
    }
}
