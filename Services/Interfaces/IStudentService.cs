using StudentsInventory.Models;

namespace StudentsInventory.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Students>> GetStudentsAsync();
        Task<Students?> GetStudentByID(int id);
        Task<Students> AddStudentAsync(AddStudentDTO new_StudentDTO);
        Task<Students?> UpdateStudentAsync(int id, UpdateStudentDTO changed_studentDTO);
        Task<Students?> DeleteStudentAsync(int id);
    }
}