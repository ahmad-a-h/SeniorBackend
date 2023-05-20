using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeniorBackend.Models
{
    public class Face
    {
        [Key]
        public int id { get; set; }
        public string FaceEncoding { get; set; } = null!;

        [ForeignKey("Student")]
        public int StudentsId { get; set; }
         
    }
}
