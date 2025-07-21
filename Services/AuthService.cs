using Microsoft.IdentityModel.Tokens;
using StudentsInventory.Data.Interfaces;
using StudentsInventory.Models;
using StudentsInventory.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace StudentsInventory.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepo _userRepo;
        private readonly IConfiguration _config;

        public AuthService(IUserRepo userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        public async Task<AuthResponse> Login(LoginDTO loginDTO)
        {
            var user = await _userRepo.getUserbyname(loginDTO.Username);

            if (user == null || !VerifyPassword(loginDTO.Password, user.hashPassword))
            {
                return null;
            }

            return GenerateToken(user);
        }

        public async Task<AuthResponse> Register(RegisterDTO registerDTO)
        {
            if (await _userRepo.getUserbyname(registerDTO.Username) != null)
            {
                return null;
            }

            var user = new User
            {
                Username = registerDTO.Username,
                Email = registerDTO.Email,
                hashPassword = HashPassword(registerDTO.Password),
                Role = "User"
            };

            await _userRepo.AddUser(user);


            return new AuthResponse
            {
                Username = user.Username,
                Role = user.Role
            };
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var hash = HashPassword(password);
            //compare the hash of both passwords
            return hash == storedHash;
        }

        private AuthResponse GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:ExpiryInMinutes"])),
                signingCredentials: credentials);

            return new AuthResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo,
                Username = user.Username,
                Role = user.Role
            };
        }

        public async Task<IEnumerable<User>> getAllUsers()
        {
            return await _userRepo.getAllUsers();
        }
    }
}