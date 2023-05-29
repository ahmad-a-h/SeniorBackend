using AutoMapper;
using facialRecognitionBackend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeniorBackend.Models;
using SeniorBackend.Models.DTOs.Class;

namespace SeniorBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class classController : ControllerBase
    {
        private readonly IMapper _mapper;

        public classController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("/getAllClasses")]
        public async Task<IActionResult> Get()
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                var classes = e.Classes.ToList();
                foreach (var c in classes)
                {
                    c.Courses = e.Courses.Where(x => x.Classid == c.id).ToList();
                }
                return Ok(classes);
            }

        }
        [HttpGet("/getClassById{Id}")]
        public ActionResult<IEnumerable<Class>> Get(int Id)
        {
            using (facialRecognitionDbContext context = new facialRecognitionDbContext())
            {
                var getNotes = context.Classes.Where(x => x.id == Id);
                return Ok(getNotes.ToList());
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
    }
}
