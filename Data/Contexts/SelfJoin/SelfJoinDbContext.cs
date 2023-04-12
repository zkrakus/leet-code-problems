using Data.Models.SelfJoin;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts.SelfJoin;
public class SelfJoinDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; } = null!;

    public SelfJoinDbContext(DbContextOptions<SelfJoinDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => _ = modelBuilder.Entity<Employee>().ToTable("Employees");
}
