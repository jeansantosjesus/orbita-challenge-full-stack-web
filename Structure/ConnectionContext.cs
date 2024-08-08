using EdTechAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EdTechAPI.Structure
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext()
        {
        }

        public ConnectionContext(DbContextOptions<ConnectionContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=edtech;" +
                "User Id=edtech;" +
                "Password=edtech");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("student");
        }
    }

}
