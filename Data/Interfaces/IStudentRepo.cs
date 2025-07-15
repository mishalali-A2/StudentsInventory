using StudentsInventory.Models;

namespace StudentsInventory.Data.Interfaces
{
    public interface IStudentRepo
    {
        Task<IEnumerable<Students>> GetStudentAsync();
        Task<Students?> GetStudentByID( int id);
        Task<Students> AddStudentAsync(AddStudentDTO new_studentDTO);
        Task<Students?> UpdateStudentAsync(int id, UpdateStudentDTO changed_studentDTO);
        Task<Students?> DeleteStudentAsync(int id);
    }
}

