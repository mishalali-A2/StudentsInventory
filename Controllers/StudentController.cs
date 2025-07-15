using Microsoft.AspNetCore.Mvc;
using StudentsInventory.Models;
using StudentsInventory.Services.Interfaces;

namespace StudentsInventory.Controllers
{
    public class StudentController : BaseController
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService student_Service)
        {
            studentService = student_Service;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var allStudents = await studentService.GetStudentsAsync();
            return Success("Students fetched successfully", allStudents);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStudentbyID(int id)
        {
            var student = await studentService.GetStudentByID(id);
            if (student == null) return NotFound("Student not found");

            return Success("Student fetched successfully", student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudents(AddStudentDTO new_studentDTO)
        {
            try
            {
                var student = await studentService.AddStudentAsync(new_studentDTO);
                return Success("Student added successfully", student);
            }
            catch (Exception exep)
            {
                return BadRequest("Failed to add student", new List<string> { exep.Message });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDTO changed_studentDTO)
        {
            try
            {
                var student = await studentService.UpdateStudentAsync(id, changed_studentDTO);
                if (student == null) return NotFound("Student not found");

                return Success("Student updated successfully", student);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to update student", new List<string> { ex.Message });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var student = await studentService.DeleteStudentAsync(id);
                if (student == null) return NotFound("Student not found");

                return Success("Student deleted successfully", student);
            }
            catch (Exception exep)
            {
                return InternalServerError($"Failed to delete student: {exep.Message}");
            }
        }
    }
}