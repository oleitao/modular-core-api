using Microsoft.EntityFrameworkCore;

namespace backend_project.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> UserItems { get; set; }
    }
}
