using AutoMapper;
using facialRecognitionBackend.Data;
using Microsoft.AspNetCore.Mvc;
using SeniorBackend.Models;
using SeniorBackend.Models.DTOs.Class;
using SeniorBackend.Models.DTOs.Course;
using SeniorBackend.Models.DTOs.sendFace;
using SeniorBackend.Models.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SeniorBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class coursesController : ControllerBase
    {
        private readonly IMapper _mapper;

        public coursesController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpGet("/getAllCourses")]
        public async Task<IActionResult> Get()
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                var courses = e.Courses.ToList();
                var courseDto = _mapper.Map<List<courseDto>>(courses);
                foreach (var s in courseDto)
                {
                  
                    var idsList = e.CourseStudent.Where(x => x.Coursesid == s.id).ToList();
                    s.Class = await getClassInfo(s.Classid);
                    foreach (var idList in idsList)
                    {
                        var c = await e.Students.FindAsync(idList.StudentsId);
                        var studentDto = _mapper.Map<StudentDto>(c);
                        studentDto.face = await getFaceByStudentID(c.Id);
                        s.Students.Add(studentDto);
                    }
                }
                return Ok(courseDto);

            }

        }
        [HttpGet("/getCourseById/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                try
                {
                    var course = e.Courses.First(x => x.id == Id);
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
                            studentDto.face = await getFaceByStudentID(student.Id);
                            courseDto.Students.Add(studentDto);
                        }
                    }
                    return Ok(courseDto);
                }
                catch (Exception x)
                {

                    return BadRequest(x.Message);
                }
                
            }
        }

        [HttpPost("/createCourse")] 
        public ActionResult<IEnumerable<courseDto>> CreateCourse([FromBody] Course course)
        {
            var courseObj = new Course();
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                try
                {
                    var checkClass_id = e.Classes.FirstOrDefault(x => x.id == course.Classid);
                    if (checkClass_id != null)
                    {
                        try
                        {
                            e.Courses.Add(course);
                            e.SaveChanges();
                            return Ok();
                        }
                        catch (Exception x)
                        {
                            return BadRequest(x.Message);
                        }
                    }
                    return BadRequest();
                }
                catch (Exception x)
                {

                    return BadRequest(x.Message);
                }

            }
        }
        
        [HttpDelete("/deleteCourse")]
        public ActionResult<IEnumerable<Course>> deleteCourse(int courseId)
        {

            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                var findCourse = e.Courses.FirstOrDefault(x => x.id == courseId);
                if (findCourse == null)
                    return NotFound();

                e.Courses.Remove(findCourse);
                e.SaveChanges();
                return Ok();
            }
        }
        [HttpPut("/editCourse{id}")]
        public IActionResult UpdateGrpName(int? id, [FromBody] courseDto Courses)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                var ID = e.Courses.Find(id);
                if (id == null)
                {
                    return NotFound();
                }

                ID.course_Name = Courses.course_Name;
                ID.course_Code = Courses.course_Code;
                ID.course_Description = Courses.course_Description;
                ID.course_Instructor = Courses.course_Instructor;

                e.SaveChanges();
            }

            return Ok();
        }
        [HttpPut("/changeClassForCourse{id}")]
        public IActionResult changeClass(int? id, [FromBody] changeClassDto Courses)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                var ID = e.Courses.Find(id);
                if (id == null)
                {
                    return NotFound();
                }

                ID.Classid = Courses.class_Id;
                e.SaveChanges();
            }

            return Ok();
        }
        #region private methods
        private async Task<classDto> getClassInfo(int Id)
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
        private async Task<faceDto> getFaceByStudentID(int Id)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {

                try
                {
                    var face = e.FaceEncoding.First(x => x.StudentsId == Id);
                    var faceDto = _mapper.Map<faceDto>(face);
                    return faceDto;
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