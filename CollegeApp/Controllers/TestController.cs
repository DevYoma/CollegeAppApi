using CollegeApp.Data;
using CollegeApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly CollegeDBContext _dbContext;

        public TestController(CollegeDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet("GetAllStudents")]
        public ActionResult<IEnumerable<StudentDTO>> GetStudents()
        {


            var students = _dbContext.Students.Select(s => new StudentDTO()

            {
                Id = s.Id,
                StudentName = s.StudentName,
                Email = s.Email,
                Address = s.Address,
            });
            return Ok(students);
        }
    }
}
