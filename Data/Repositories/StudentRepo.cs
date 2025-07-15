using Microsoft.EntityFrameworkCore;
using StudentsInventory.Models;
using StudentsInventory.Data.Interfaces;

namespace StudentsInventory.Data.Repositories
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ApplicationDbContext dbContext;

        public StudentRepo(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public async Task<Students> AddStudentAsync(AddStudentDTO new_studentDTO)
        {
            var student = new Students()
            {
                Name = new_studentDTO.Name,
                Email = new_studentDTO.Email,
                Phone = new_studentDTO.Phone,
                Enroll_Date = new_studentDTO.Enroll_Date,
                Address = new_studentDTO.Address
            };

            dbContext.Students.Add(student);
            await dbContext.SaveChangesAsync();
            return student;   
        }

        public async Task<Students?> DeleteStudentAsync(int id)
        {
            var student =await dbContext.Students.FindAsync(id);

            if (student == null) return null;

            dbContext.Students.Remove(student);
            await dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<IEnumerable<Students>> GetStudentAsync()
        {
            return await dbContext.Students.ToListAsync();
        }

        public async Task<Students?> GetStudentByID(int id)
        {
            return await dbContext.Students.FindAsync(id);
        }

        public async Task<Students?> UpdateStudentAsync(int id, UpdateStudentDTO changed_studentDTO)
        {
            var student = await dbContext.Students.FindAsync(id);

            if (student == null) return null;

            student.Name= changed_studentDTO.Name;
            student.Email= changed_studentDTO.Email;    
            student.Address= changed_studentDTO.Address;    
            student.Phone= changed_studentDTO.Phone;    
            student.Enroll_Date= changed_studentDTO.Enroll_Date;

            await dbContext.SaveChangesAsync();
            return student; 
        }
    }
}

