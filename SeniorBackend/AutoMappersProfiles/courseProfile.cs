using AutoMapper;
using SeniorBackend.Models;
using SeniorBackend.Models.DTOs.Course;

namespace SeniorBackend.AutoMappersProfiles
{
    public class courseProfile: Profile
    {
        public courseProfile()
        {
            CreateMap<Course, courseDto>();
            CreateMap<Course, courseDtoForGetClass>();
        }
    }
}
