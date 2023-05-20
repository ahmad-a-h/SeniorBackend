using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeniorBackend.Models
{
    public class CourseStudent
    {
        [Key]
        public int Id { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Student")]
        public int StudentsId { get; set;}
        public Course Course { get; set; }
        [ForeignKey("Course")]
        public int Coursesid { get; set; }
    }
}
