using AutoMapper;
using facialRecognitionBackend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeniorBackend.Models;
using SeniorBackend.Models.DTOs.Attendance;
using SeniorBackend.Models.DTOs.Class;
using SeniorBackend.Models.DTOs.Student;

namespace SeniorBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class attendedController : ControllerBase
    {
        private readonly IMapper _mapper;

        public attendedController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //[HttpGet("/getStudentsAttendedBySessionId")]
        //public async Task<IActionResult> Get()
        //{
        //    using (facialRecognitionDbContext e = new facialRecognitionDbContext())
        //    {
        //        var classes = e.Classes.ToList();
        //        foreach (var c in classes)
        //        {
        //            c.Courses = e.Courses.Where(x => x.Classid == c.id).ToList();
        //        }
        //        return Ok(classes);
        //    }

        //}

        [HttpGet("/getStudentsAttendenceBySessionId{Id}")]
        public IActionResult Get(int Id)
        {
            using (facialRecognitionDbContext context = new facialRecognitionDbContext())
            {
                var list = context.Attendance.Where(x => x.Sessionid == Id);
                foreach (var item in list)
                {
                    item.Student = GetStudent(item.studentId);
                    item.Session =  context.Session.Find(Id);
                }
                return Ok(list);
            }
        }
        [HttpPost("/createAttendance")]
        public ActionResult<IEnumerable<Course>> CreateAttendance([FromBody] RequestAttendance request)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                try
                {
                    var attendance = _mapper.Map<Attendance>(request);
                    e.Attendance.Add(attendance);
                    e.SaveChanges();
                    return Ok();
                }
                catch (Exception x)
                {
                    return BadRequest(x.Message);
                }

            }
        }
        #region private methods
        private Student GetStudent(int Id)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                    var student = e.Students.First(x => x.Id == Id);
                    var mappedCourse = _mapper.Map<StudentDto>(student);
                    return student; 
            }
        }
        #endregion
    }
}
