using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsInventory.Data;
using StudentsInventory.Models;

namespace StudentsInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var allStudents = dbContext.Students.ToList();
            return Ok(allStudents);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStudentbyID(int id)
        {
            var student = dbContext.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudents(AddStudentDTO new_strudentDTO)
        {
            var studentEntity = new Students()
            {
                Name = new_strudentDTO.Name,
                Email = new_strudentDTO.Email,
                Phone = new_strudentDTO.Phone,
                Enroll_Date = new_strudentDTO.Enroll_Date,
                Address = new_strudentDTO.Address
            };
            dbContext.Students.Add(studentEntity);
            dbContext.SaveChanges();

            return Ok(studentEntity);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult updateStudent(int id, UpdateStudentDTO change_studentDTO)
        {
            var student = dbContext.Students.Find(id);

            if (student == null) return NotFound();

            student.Name = change_studentDTO.Name;
            student.Email = change_studentDTO.Email;
            student.Phone = change_studentDTO.Phone;
            student.Enroll_Date = change_studentDTO.Enroll_Date;
            student.Address = change_studentDTO.Address;

            dbContext.SaveChanges();
            return Ok(student);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult deleteStudent(int id)
        {
            var student = dbContext.Students.Find(id);

            if (student == null) return NotFound();

            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
            return Ok(student);
        }
    }
}
