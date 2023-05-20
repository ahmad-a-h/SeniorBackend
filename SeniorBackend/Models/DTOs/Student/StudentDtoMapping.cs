using SeniorBackend.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeniorBackend.Models.DTOs.Student
{
    public class StudentDtoMapping
    {
        public int Id { get; set; }
        public string fName { get; set; } = null!;
        public string lName { get; set; } = null!;
        public string email { get; set; } = null!;

    }
}
