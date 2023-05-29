using AutoMapper;
using SeniorBackend.Models;
using SeniorBackend.Models.DTOs.sendFace;

namespace SeniorBackend.AutoMappersProfiles
{

    public class faceProfile : Profile
    {
        public faceProfile()
        {
            CreateMap<Face, faceDto>();
        }
    }
}
