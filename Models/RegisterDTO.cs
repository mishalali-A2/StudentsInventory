﻿namespace StudentsInventory.Models
{
    public class RegisterDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = null;
        public string Email { get; set; } = null;
        public string Password { get; set; } = null;
    }
}
