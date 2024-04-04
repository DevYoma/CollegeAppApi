using CollegeApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("All", Name ="GetAllStudents")]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(CollegeRepository.Students);

        }

        [HttpGet("{id:int}", Name ="GetStudentById")]
        public ActionResult<Student> GetStudentById(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            var student = CollegeRepository.Students.Where(n => n.Id == id).FirstOrDefault();
            if(student == null)
            {
                return NotFound($"The student with id {id} not found");
            }

            return Ok(student);
        }

        [HttpGet("{name:alpha}", Name = "GetStudentByName")]
        //[Route("{name}", Name ="GetStudentByName")]
        public ActionResult<Student> GetStudentByName(string name)
        {
            //checking if string is Null or Empty
            if(string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            var student = CollegeRepository.Students.Where(n => n.StudentName == name).FirstOrDefault();
            if(student == null)
            {
                return NotFound($"The student with name {name} not found");
            }

            return Ok(student);
        }

        [HttpDelete("{id}", Name ="DeleteStudentById")]
        public ActionResult<bool> DeleteStudent(int id)
        {
            // BAD REQUEST
            if(id <= 0)
            {
                return BadRequest();
            }

            var student = CollegeRepository.Students.Where(n => n.Id == id).FirstOrDefault();
            // NOT FOUND
            if(student == null)
            {
                return NotFound($"The Student with the id {id} not found");
            }

            CollegeRepository.Students.Remove(student);
             // OK - 200 
            return Ok(true);
        }
    }
}
