
namespace SeniorBackend.Models.DTOs.Student
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string fName { get; set; } = null!;
        public string lName { get; set; } = null!;
        public string email { get; set; } = null!;
        public Face face { get; set; }
    }
}
