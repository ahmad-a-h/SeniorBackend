using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SeniorBackend.Models;
namespace SeniorBackend.Models.DTOs.Attendance
{
    public class AttendanceDto
    {
        public int Id { get; set; }

        public int Sessionid { get; set; }

        public Models.Student Student { get; set; }
        public Models.Session Session { get; set; }
        public int studentId { get; set; }

        public string timeAttended { get; set; }
    }
}
