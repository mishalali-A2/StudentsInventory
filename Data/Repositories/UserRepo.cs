using Microsoft.EntityFrameworkCore;
using StudentsInventory.Models;
using StudentsInventory.Data.Interfaces;

namespace StudentsInventory.Data.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> getUserbyname(string username)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> getAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}