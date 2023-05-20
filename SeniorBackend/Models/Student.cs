using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeniorBackend.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string fName { get; set; } = null!;
        public string lName { get; set; } = null!;
        public string email { get; set; } = null!;
        public ICollection<CourseStudent> Courses { get; set; }
        
    }
}
