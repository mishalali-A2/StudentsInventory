using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsInventory.Models;
using StudentsInventory.Services;
using StudentsInventory.Services.Interfaces;

namespace StudentsInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService auth_service;

        public AuthController(IAuthService auth_service)
        {
            this.auth_service = auth_service;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await auth_service.getAllUsers();

            var userDTOs = users.Select(u => new UserDTO
            {
                Username = u.Username,
                Email = u.Email,
                Role = u.Role
            });

            return Success("Users retrieved successfully", userDTOs);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid request format");

            var response = await auth_service.Login(loginDTO);

            if (response == null)
                return BadRequest("Invalid credentials");

            return Ok(new
            {
                success = true,
                message = "Login Successful",
                //token generation for swagger authorization
                token = response.Token,
                expires = response.Expiration
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var response = await auth_service.Register(registerDTO);

            if(response == null)
            {
                return BadRequest("Username already registered");
            }

            return Success("Registration Successful", response);
        }
    }
}
