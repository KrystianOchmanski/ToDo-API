using Microsoft.EntityFrameworkCore;

namespace ToDo_API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Model.Task> Tasks { get; set; }
    }
}
