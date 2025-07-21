using StudentsInventory.Data.Interfaces;
using StudentsInventory.Models;
using StudentsInventory.Services.Interfaces;

namespace StudentsInventory.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo student_repo;

        public StudentService(IStudentRepo stud_repo)
        {
            student_repo = stud_repo;
        }

        public async Task<IEnumerable<Students>> GetStudentsAsync()
        {
            return await student_repo.GetStudentAsync();
        }

        public async Task<Students?> GetStudentByID(int id)
        {
            return await student_repo.GetStudentByID(id);
        }

        public async Task<Students> AddStudentAsync(AddStudentDTO new_StudentDTO)
        {
            return await student_repo.AddStudentAsync(new_StudentDTO);
        }

        public async Task<Students?> UpdateStudentAsync(int id, UpdateStudentDTO changed_studentDTO)
        {
            return await student_repo.UpdateStudentAsync(id, changed_studentDTO);
        }

        public async Task<Students?> DeleteStudentAsync(int id)
        {
            return await student_repo.DeleteStudentAsync(id);
        }
    }
}