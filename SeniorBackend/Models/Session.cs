using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeniorBackend.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime startDateTime { get; set; }
        [Required]
        public DateTime endDateTime { get; set; }

        [Required]
        public string Title { get; set; }
        public Course Course { get; set; }
        [ForeignKey("Course")]
        [Required]
        public int Coursesid { get; set; }
        
        public Class Class { get; set; }
        [ForeignKey("Class")]
        [Required]
        public int Classesid { get; set; }



    }
}
