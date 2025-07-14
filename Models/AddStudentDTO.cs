namespace StudentsInventory.Models
{
    public class AddStudentDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public DateTime Enroll_Date { get; set; }
        public string? Address { get; set; }
    }
}
