using Data.Models.SecondHighestSalary;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts.SecondHighestSalary;
public class SecondHighestSalaryDbContext : DbContext
{
    public DbSet<Employee>? Employees { get; set; }

    public SecondHighestSalaryDbContext(DbContextOptions<SecondHighestSalaryDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => _ = modelBuilder.Entity<Employee>().ToTable("Employees");
}
