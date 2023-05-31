using AutoMapper;
using SeniorBackend.Models;
using SeniorBackend.Models.DTOs.Class;
using SeniorBackend.Models.DTOs.sendFace;

namespace SeniorBackend.AutoMappersProfiles
{
    public class AttendanceDto : Profile
    {
        public AttendanceDto()
        {
            CreateMap<Attendance, AttendanceDto>();
        }
    }
}
