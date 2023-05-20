using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeniorBackend.Models
{
    public class Course
    {
        [Key]
        public int id { get; set; }
        public int course_Code { get; set; }
        public string course_Name { get; set; } = null!;
        public string course_Description { get; set; } = null!;
        public string course_Instructor { get; set; } = null!;
        
        [ForeignKey("Class")]
        public int Classid { get; set; }

        public ICollection<CourseStudent> Students { get; set; }



    }
}
