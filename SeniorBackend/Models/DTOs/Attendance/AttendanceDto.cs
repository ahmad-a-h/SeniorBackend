using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeniorBackend.Models.DTOs.Attendance
{
    public class AttendanceDto
    {
        public int Id { get; set; }

        public int Sessionid { get; set; }
        
        public int studentId { get; set; }

        public string timeAttended { get; set; }
    }
}
