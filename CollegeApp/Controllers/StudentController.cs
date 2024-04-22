using CollegeApp.Data;
using CollegeApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly ILogger<StudentController> _logger;
        private readonly CollegeDBContext _dbContext;
        public StudentController(ILogger<StudentController> logger, CollegeDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("All", Name ="GetAllStudents")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
        {
            _logger.LogInformation("GetStudents method started");

            var students = await _dbContext.Students.Select(s => new StudentDTO()
            {
                Id = s.Id,
                Address = s.Address,
                Email = s.Email, 
                StudentName = s.StudentName, 
                DOB = s.DOB,
            }).ToListAsync();

            //students = _dbContext.Students.ToList();
            return Ok(students);

        }

        [HttpGet]
        [Route("{id:int}", Name = "GetStudentById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
        {
            if(id <= 0)
            {
                _logger.LogWarning("Bad Request");
                return BadRequest();
            }

            var student = await _dbContext.Students.Where(n => n.Id == id).FirstOrDefaultAsync();
            if(student == null)
            {
                _logger.LogError("Student not found with the given id");
                return NotFound($"The student with id {id} not found");
            }

            var studentDTO = new StudentDTO{
                Id = student.Id,
                StudentName = student.StudentName,
                Email = student.Email,
                Address = student.Address,
                DOB = student.DOB
            };

            return Ok(studentDTO);
        }

        [HttpGet(Name = "GetStudentByName")]
        //[Route("{name}", Name = "GetStudentByName")]
        public async Task<ActionResult<StudentDTO>> GetStudentByName(string name)
        {
            //checking if string is Null or Empty
            if(string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            var student = await _dbContext.Students.Where(n => n.StudentName == name).FirstOrDefaultAsync();

            if (student == null)
            {
                return NotFound($"The student with name {name} not found");
            }

            var studentDTO = new StudentDTO
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Email = student.Email,
                Address = student.Address,
                DOB = student.DOB
            };

            return Ok(studentDTO);
        }

        [HttpPost]
        [Route("Create", Name = "CreateStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentDTO>> CreateStudent([FromBody]StudentDTO model) {
            if(model == null)
            {
                return BadRequest();
            }

            Student student = new Student
            {
                StudentName = model.StudentName,
                Email = model.Email,
                Address = model.Address,
                DOB = Convert.ToDateTime(model.DOB)
            };

            await _dbContext.Students.AddAsync(student); // EF tracking
            await _dbContext.SaveChangesAsync();

            model.Id = student.Id;

            Console.WriteLine($"Modified Model, ${model}");

            return Ok(model);

        }

        [HttpPut]
        [Route("Update")]
        //api/student/update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Student>> UpdateStudent([FromBody]StudentDTO request)
        {
            if(request == null || request.Id <= 0)
            {
                return BadRequest();
            }
            
            var existingStudent = await _dbContext.Students.Where(s => s.Id == request.Id).FirstOrDefaultAsync();

            if(existingStudent == null)
            {
                return NotFound();
            }


            existingStudent.StudentName = request.StudentName;
            existingStudent.Address = request.Address;
            existingStudent.Email = request.Email;
            existingStudent.DOB = Convert.ToDateTime(request.DOB);
            _dbContext.Students.Update(existingStudent);
            await _dbContext.SaveChangesAsync();

            return NoContent();
            
        }
        
        [HttpDelete("{id}", Name ="DeleteStudentById")]
        public async Task<ActionResult<bool>> DeleteStudentAsync(int id)
        {
            // BAD REQUEST
            if(id <= 0)
            {
                return BadRequest();
            }

            var student = await _dbContext.Students.Where(n => n.Id == id).FirstOrDefaultAsync();
            // NOT FOUND
            if(student == null)
            {
                return NotFound($"The Student with the id {id} not found");
            }

             _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
             // OK - 200 
            return Ok(true);
        }
    }
}
