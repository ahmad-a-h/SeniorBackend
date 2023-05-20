using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeniorBackend.Models
{
    public class Class
    {
        [Key]
        public int id { get; set; }
        public string building { get; set; } = null!;
        public int floor_nb { get; set; }
        public int class_nb { get; set; }
        [NotMapped]
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    

    }
}
