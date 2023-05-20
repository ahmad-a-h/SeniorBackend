using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeniorBackend.Models
{
    public class Attendended
    {
        [Key]
        public int Id { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
    }
}
