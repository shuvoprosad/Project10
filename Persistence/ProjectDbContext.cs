using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project10.Models;

namespace Project10.Persistence
{
    public class ProjectDbContext: IdentityDbContext<User>
    {
        public DbSet<Room>Room { get; set; }
        public DbSet<User>User { get; set; }
        public DbSet<Routine>Routine { get; set; }
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options):base(options)
        {
            
        }

    }
}