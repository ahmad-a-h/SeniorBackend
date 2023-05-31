using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeniorBackend.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        public Session Session{ get; set; }

        [ForeignKey("Session")]
        public int Sessionid { get; set; }

        [ForeignKey("Student")]
        public int studentId { get; set; }
        public Student Student { get; set; }

        public string timeAttended { get; set; }
    }
}
