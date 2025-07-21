using Microsoft.Extensions.Logging.Abstractions;

namespace StudentsInventory.Models
{
    public class AuthResponse
    {
        public string Token { get; set; } = null;
        public DateTime Expiration { get; set; }
        public string Username { get; set; } = null;
        public string Role { get; set; } = null;
    }
}
