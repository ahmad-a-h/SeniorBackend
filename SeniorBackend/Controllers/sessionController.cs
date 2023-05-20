using AutoMapper;
using facialRecognitionBackend.Data;
using Microsoft.AspNetCore.Mvc;
using SeniorBackend.Models;
using SeniorBackend.Models.DTOs.Session;
using SeniorBackend.Models.DTOs.Course;
using SeniorBackend.Models.DTOs.Student;
using SeniorBackend.Models.DTOs.Class;

namespace SeniorBackend.Controllers
{
    public class sessionController : ControllerBase
    {
        private readonly IMapper _mapper;

        public sessionController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("/getAllSessions")]
        public async Task<IActionResult> Get()
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                var sessionsList = e.Session.ToList();
                var sessions = _mapper.Map<List<sessionDto>>(sessionsList);
                //var studentDtos = students.Select(s => _mapper.Map<StudentDto>(s)).ToList();
                return Ok(sessionsList);

            }

        }
        //[HttpGet("/getSessionInfoBySessionID {Id}")]
        //public async Task<IActionResult> getSessionParams(int Id)
        //{
        //    using (facialRecognitionDbContext e = new facialRecognitionDbContext())
        //    {
        //        try
        //        {
        //            var session = e.Session.FindAsync(Id);
        //            return session;
        //        }
        //        catch (Exception x)
        //        {

        //            return null;
        //        }
        //    }

        //}

        [HttpGet("/getSessionsByCourseId{Id}")]
        public async Task<ActionResult<IEnumerable<Session>>> Get(int Id)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                try
                {
                    var session = e.Session.Where(x => x.Coursesid == Id).ToList();
                    var mappedSession = _mapper.Map<List<GetCourseForSessionDto>>(session);

                    
                    foreach (var item in mappedSession)
                    {
                        item.Course = await getCourseInfo(Id);
                        item.Class = await getClassInfo(item.Classesid);
                    }
                    
                    return Ok(mappedSession);
                }
                catch (Exception x)
                {

                    return BadRequest(x.Message);
                }

            }
        }

        //[HttpGet("/getCoursesForStudent{Id}")]
        //public ActionResult<IEnumerable<Student>> GetCourses(int Id)
        //{
        //    using (facialRecognitionDbContext e = new facialRecognitionDbContext())
        //    {
        //        try
        //        {
        //            var student = e.Students.First(x => x.Id == Id);
        //            var studentDto = _mapper.Map<StudentDtoWithMapping>(student);
        //            var idsList = e.CourseStudent.Where(x => x.StudentsId == student.Id).ToList();
        //            foreach (var idList in idsList)
        //            {
        //                var course = e.Courses.Find(idList.Coursesid);
        //                if (student != null)
        //                {
        //                    var newCourseDto = _mapper.Map<courseDtoForGetClass>(course);
        //                    studentDto.Courses.Add(newCourseDto);
        //                }
        //            }
        //            return Ok(studentDto);
        //        }
        //        catch (Exception x)
        //        {

        //            return BadRequest(x.Message);
        //        }

        //    }
        //}


        [HttpPost("/createSession")]
        public ActionResult<IEnumerable<Session>> CreateCourse([FromBody] sessionDto Session)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                try
                {
                    var checkCourseID = e.Courses.Find(Session.courseID);
                    var checkClassID = e.Classes.Find(checkCourseID.Classid);

                    if (checkCourseID  != null && checkClassID != null)
                    {
                        var session = new Session()
                        {
                            startDateTime = Session.startDateTime,
                            endDateTime = Session.endDateTime,
                            Coursesid = Session.courseID,
                            Classesid = checkCourseID.Classid,
                            Title = Session.Title,
                        };
                        e.Session.Add(session);
                        e.SaveChanges();
                    return Ok();
                    }
                    else { return BadRequest(); }
                   
                }
                catch (Exception x)
                {

                    return BadRequest(x.Message);
                }
               

            }
        }

        //[HttpPost("/assignCourseStudent{id}")]
        //public ActionResult<IEnumerable<courseDto>> assignCourseStudent(int id, int courseId)
        //{
        //    try
        //    {
        //        using (facialRecognitionDbContext e = new facialRecognitionDbContext())
        //        {
        //            var students = e.Students.ToList();
        //            var courses = e.Courses.ToList();
        //            foreach (var ids in students)
        //            {
        //                var matching = students.Find(x => x.Id == id);
        //                foreach (var course in courses)
        //                {
        //                    var matchingCourse = courses.Find(x => x.id == courseId);
        //                    if (matching != null)
        //                    {
        //                        if (matchingCourse != null)
        //                        {
        //                            var newCourseStudent = new CourseStudent() { StudentsId = id, Coursesid = courseId };
        //                            e.CourseStudent.Add(newCourseStudent);
        //                            e.SaveChanges();
        //                            return Ok();
        //                        }
        //                    }
        //                }
        //            }
        //            return BadRequest();

        //        }
        //    }
        //    catch (Exception x)
        //    {
        //        return BadRequest(x.Message);
        //    }

        //}

        #region private methods
        public async Task<courseDto> getCourseInfo(int Id)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                try
                {
                    var course = await e.Courses.FindAsync(Id);
                    //var mappedCourse = _mapper.Map<courseDtoForGetClass>(course);
                    //Where(x => x.id == Id);
                    var courseDto = _mapper.Map<courseDto>(course);
                    var idsList = e.CourseStudent.Where(x => x.Coursesid == course.id).ToList();
                    foreach (var idList in idsList)
                    {
                        var student = e.Students.Find(idList.StudentsId);
                        if (student != null)
                        {
                            var studentDto = _mapper.Map<StudentDto>(student);
                            courseDto.Students.Add(studentDto);
                        }
                    }
                    return courseDto;
                }
                catch (Exception x)
                {

                    return null/*BadRequest(x.Message)*/;
                }

            }
        }
        public async Task<classDto> getClassInfo(int Id)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {

                try
                {
                    var classInfo = await e.Classes.FindAsync(Id);
                    var classMapper = _mapper.Map<classDto>(classInfo);
                    return classMapper;
                }
                catch (Exception x)
                {

                    return null;
                }
                
    }
        }
        #endregion

    }
}

