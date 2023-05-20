using AutoMapper.Execution;
using facialRecognitionBackend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeniorBackend.Models;
using SeniorBackend.Models.DTOs.Student;

namespace SeniorBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaceControllercs : ControllerBase
    {
        // get face enconding for specific student
        // add new face for specific student
        // update face encoding for a specific student
        // delte face encoding for a specific student
        [HttpGet("/getFaceEncodingByStudentId/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                try
                {
                    var face = e.FaceEncoding.First(x => x.StudentsId == id);
                    return Ok(face);
                }
                catch (Exception x)
                {

                    return BadRequest(x.Message);
                }

            }

        }

        [HttpPost("/AssignFaceForStudent")]
        public async Task<IActionResult> AssignFaceForStudent([FromBody]string FaceEncoding, int studentID)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                try
                {
                    var checkFace = await e.Students.FindAsync(studentID);
                    if (checkFace != null)
                    {

                        if (FaceEncoding != null && FaceEncoding.Length > 0)
                        {
                            var newFace = new Face();
                            newFace.StudentsId = studentID;
                            newFace.FaceEncoding = FaceEncoding;
                            e.Add(newFace);
                            e.SaveChanges();
                            return Ok();
                        }
                        else return BadRequest();
                    }
                    else return BadRequest("StudentID is either incorrect or not Found");

                }
                catch (Exception x)
                {

                    return BadRequest(x.Message);
                }

            }
        }
        [HttpPut("/ChangeFaceForStudent")]
        public async Task<IActionResult> ChangeFaceForStudent(IFormFile file, int studentID)
        {
            using (facialRecognitionDbContext e = new facialRecognitionDbContext())
            {
                try
                {
                    var checkFace = e.FaceEncoding.First(x=>x.StudentsId == studentID);
                    if (checkFace != null)
                    {
                        if (checkFace != null)
                        {

                            if (file != null && file.Length > 0)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    var newFace = new Face();
                                    newFace.StudentsId = studentID;
                                    file.CopyTo(ms);
                                    byte[] fileBytes = ms.ToArray();
                                    string base64String = Convert.ToBase64String(fileBytes);
                                    newFace.FaceEncoding = base64String;
                                    e.Add(newFace);
                                    e.SaveChanges();
                                    return Ok();
                                }
                            }
                            else return BadRequest();
                        }
                        else return BadRequest();
                    }
                    else return BadRequest("StudentID is either incorrect or not Found");

                }
                catch (Exception x)
                {

                    return BadRequest(x.Message);
                }

            }
        }
    }
}
