using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Model;

public class ConnectionContext : DbContext
{
    public ConnectionContext(DbContextOptions<ConnectionContext> options)
        : base(options)
    {
    }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>().ToTable("Student");
    }
}
