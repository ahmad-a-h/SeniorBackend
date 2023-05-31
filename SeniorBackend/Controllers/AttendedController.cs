using AutoMapper;
using facialRecognitionBackend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeniorBackend.Models;
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

        [HttpGet("/getStudentsAttendedBySessionId{Id}")]
        public Task<Attendance> Get(int Id)
        {
            using (facialRecognitionDbContext context = new facialRecognitionDbContext())
            {
                var list = context.Attendance.Where(x => x.Id == Id);
                //foreach (var item in list)
                //{
                //    item.Student = GetStudent(item.studentId);
                //    //item.Session = 
                //}
                //return Ok(list.ToList());
            }
        }
        [HttpPost("/createClass")]
        public ActionResult<IEnumerable<Course>> CreateCourse([FromBody] classDto Classes)
        {
            var classes = new Class();
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                try
                {
                    classes.floor_nb = Classes.floor_nb;
                    classes.class_nb = Classes.class_nb;
                    classes.building= Classes.building;

                    e.Classes.Add(classes);
                    e.SaveChanges();
                    return Ok();
                }
                catch (Exception x)
                {
                    return BadRequest(x.Message);
                }

            }
        }
        
        [HttpDelete("/deleteclass")]
        public ActionResult<IEnumerable<Class>> deleteClass(int classId)
        {

            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                var findClass = e.Classes.FirstOrDefault(x => x.id == classId);
                if (findClass == null)
                    return NotFound();

                e.Classes.Remove(findClass);
                e.SaveChanges();
                return Ok();
            }
        }
        [HttpPut("/editClass{id}")]
        public IActionResult UpdateGrpName(int? id, [FromBody] classDto Classes)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                var ID = e.Classes.Find(id);
                if (id == null)
                {
                    return NotFound();
                }
                ID.floor_nb = Classes.floor_nb;
                ID.class_nb = Classes.class_nb;
                ID.building = Classes.building;
                e.Classes.Add(ID);
                e.SaveChanges();
            }

            return Ok();
        }
        #region private methods
        public ActionResult<IEnumerable<Student>> GetStudent(int Id)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                try
                {
                    var student = e.Students.First(x => x.Id == Id);
                    var mappedCourse = _mapper.Map<StudentDto>(student);
                    return Ok(mappedCourse);
                }
                catch (Exception x)
                {

                    return BadRequest(x.Message);
                }

            }
        }
        #endregion
    }
}
