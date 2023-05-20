using SeniorBackend.Models.DTOs.Course;

namespace SeniorBackend.Models.DTOs.Student
{
    public class sessionDtoMapping
    {
        public int id { get; set; }
        public int course_Code { get; set; }
        public string course_Name { get; set; } = null!;
        public string course_Description { get; set; } = null!;
        public string course_Instructor { get; set; } = null!;
        public List<courseDto> Students { get; set; } = new List<courseDto>();
    }
}
