namespace StudentsInventory.Models
{
    public class AddStudentDTO
    {
        public string Name { get; set; } = null;
        public string Email { get; set; } = null;
        public string Phone { get; set; } = null;
        public DateOnly Enroll_Date { get; set; }
        public string? Address { get; set; }
    }
}
