using SeniorBackend.Models.DTOs.Class;
using SeniorBackend.Models.DTOs.Student;
using System.ComponentModel.DataAnnotations;

namespace SeniorBackend.Models.DTOs.Course
{
    public class courseDto
    {
        public int id { get; set; }
        public int course_Code { get; set; }
        public string course_Name { get; set; } = null!;
        public string course_Description { get; set; } = null!;
        public string course_Instructor { get; set; } = null!;

        public classDto Class { get; set; }

        public List<StudentDto> Students { get; set; } = new List<StudentDto>();
    }
}
