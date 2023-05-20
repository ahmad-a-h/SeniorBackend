using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SeniorBackend.Models.DTOs.Course;
using SeniorBackend.Models.DTOs.Class;

namespace SeniorBackend.Models.DTOs.Session
{
    public class GetCourseForSessionDto
    {
        public int Id { get; set; }
     
        public DateTime startDateTime { get; set; }
        
        public DateTime endDateTime { get; set; }

        public string title { get; set; }

        public courseDto Course { get; set; }

        public classDto Class { get; set; } 

        public int Coursesid { get; set; }


        public int Classesid { get; set; }

    }
}
