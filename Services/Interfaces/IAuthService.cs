using StudentsInventory.Models;

namespace StudentsInventory.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(LoginDTO loginDTO);
        Task<AuthResponse> Register(RegisterDTO registerDTO);
        //for testing purpose only
        Task<IEnumerable<User>> getAllUsers();
    }
}
