using Data.Models.NthHighestSalaryDbContext;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts.NthHighestSalary;
public class NthHighestSalaryDbContext : DbContext
{
    public DbSet<Employee>? Employees { get; set; }

    public NthHighestSalaryDbContext(DbContextOptions<NthHighestSalaryDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => _ = modelBuilder.Entity<Employee>().ToTable("Employees");
}
