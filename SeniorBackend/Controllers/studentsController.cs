using AutoMapper;
using facialRecognitionBackend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeniorBackend.Migrations;
using SeniorBackend.Models;
using SeniorBackend.Models.DTOs.Course;
using SeniorBackend.Models.DTOs.Student;

namespace SeniorBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public studentsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("/getAllStudents")]
        public async Task<IActionResult> Get()
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                var students = e.Students.ToList();
                var studentDtos = students.Select(s => _mapper.Map<StudentDto>(s)).ToList();
                foreach (var student in studentDtos)
                {
                    var face = e.FaceEncoding.FirstOrDefault(x => x.StudentsId == student.Id);
                    if (face != null)
                    {
                        student.face = face;
                    }
                }
                
                return Ok(studentDtos);

            }

        }
        [HttpGet("/getStudentById{Id}")]
        public ActionResult<IEnumerable<Student>> Get(int Id)
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
        [HttpGet("/getCoursesForStudent{Id}")]
        public ActionResult<IEnumerable<Student>> GetCourses(int Id)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                try
                {
                    var student = e.Students.First(x => x.Id == Id);
                    var studentDto = _mapper.Map<StudentDtoWithMapping>(student);
                    var idsList = e.CourseStudent.Where(x => x.StudentsId == student.Id).ToList();
                    foreach (var idList in idsList)
                    {
                        var course = e.Courses.Find(idList.Coursesid);
                        if (student != null)
                        {
                            var newCourseDto = _mapper.Map<courseDtoForGetClass>(course);
                            studentDto.Courses.Add(newCourseDto);
                        }
                    }
                    return Ok(studentDto);
                }
                catch (Exception x)
                {

                    return BadRequest(x.Message);
                }

            }
        }


        [HttpPost("/registerStudent")]
        public ActionResult<IEnumerable<courseDto>> CreateCourse([FromBody] newStudentDto student)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                var stud = new Student();
                stud.fName = student.fName;
                stud.lName = student.lName;
                stud.email = student.email;
                e.Students.Add(stud);
                e.SaveChanges();
                
                return Ok(stud.Id);

            }
        }
        [HttpPost("/assignCourseStudent{id}")]
        public ActionResult<IEnumerable<courseDto>> assignCourseStudent(int id,int courseId)
        {
            try
            {
                using (facialRecognitionDbContext e = new facialRecognitionDbContext())
                {
                    var students = e.Students.ToList();
                    var courses = e.Courses.ToList();
                    foreach (var ids in students)
                    {
                        var matching = students.Find(x => x.Id == id);
                        foreach (var course in courses)
                        {
                            var matchingCourse = courses.Find(x => x.id == courseId);
                            if (matching != null)
                            {
                                if (matchingCourse != null)
                                {
                                    var newCourseStudent = new CourseStudent() { StudentsId = id, Coursesid = courseId };
                                    e.CourseStudent.Add(newCourseStudent);
                                    e.SaveChanges();
                                    return Ok();
                                }
                            }
                        }
                    }
                    return BadRequest();

                }
            }
            catch(Exception x)
            {
                return BadRequest(x.Message);
            }
            
        }
    }
}
