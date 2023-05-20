using AutoMapper;
using SeniorBackend.Models;
using SeniorBackend.Models.DTOs;
using SeniorBackend.Models.DTOs.Student;

namespace SeniorBackend.AutoMappersProfiles
{
    public class studentProfile : Profile
    {
        public studentProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Student, StudentDtoWithMapping>(); 
        }
}
}
