using SeniorBackend.Models.DTOs.Course;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeniorBackend.Models.DTOs.Student
{
    public class StudentDtoWithMapping
    {
        public int Id { get; set; }
        public string fName { get; set; } = null!;
        public string lName { get; set; } = null!;
        public string email { get; set; } = null!;
        public List<courseDtoForGetClass> Courses { get; set; } = new List<courseDtoForGetClass>();

    }
}
