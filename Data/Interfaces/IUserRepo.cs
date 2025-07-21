using StudentsInventory.Models;

namespace StudentsInventory.Data.Interfaces
{
    public interface IUserRepo
    {
        Task<User> getUserbyname(string username);
        Task AddUser(User user);
        //for testing purpose
        Task<IEnumerable<User>> getAllUsers();
    }
}
