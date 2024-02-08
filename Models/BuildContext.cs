using Microsoft.EntityFrameworkCore;

namespace ModularCoreApi.Models
{
    public class BuildContext : DbContext
    {

        public BuildContext(DbContextOptions<BuildContext> options): base(options){ }

        public DbSet<Touch> Touchs { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
