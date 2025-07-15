using Microsoft.EntityFrameworkCore;
using StudentsInventory.Models;

namespace StudentsInventory.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Students> Students { get; set; }
    }
}
