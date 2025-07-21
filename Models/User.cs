namespace StudentsInventory.Models
{
    public class User
    {
        public int id { get; set; }
        public string Username { get; set; }= null;
        public string Email { get; set; } = null;
        public string hashPassword { get; set; } = null;
        public string Role { get; set; } = "User";
    }
}
