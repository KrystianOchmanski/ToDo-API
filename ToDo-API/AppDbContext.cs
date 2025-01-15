using Microsoft.EntityFrameworkCore;

namespace ToDo_API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Model.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Task>()
                .Property(t => t.CreationDate)
                .HasColumnType("date");

            modelBuilder.Entity<Model.Task>()
                .Property(t => t.EndDate)
                .HasColumnType("date");

            modelBuilder.Entity<Model.Task>()
                .Property(t => t.CreationDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
