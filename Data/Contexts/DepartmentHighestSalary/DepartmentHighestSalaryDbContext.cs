using Data.Models.DepartmentHighestSalary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts.DepartmentHighestSalary;
public class DepartmentHighestSalaryDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    public DepartmentHighestSalaryDbContext(DbContextOptions<DepartmentHighestSalaryDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<Employee>().ToTable("Employees")
            .Property(e => e.Id)
            .ValueGeneratedNever();
        _ = modelBuilder.Entity<Department>().ToTable("Departments")
            .Property(e => e.Id)
            .ValueGeneratedNever();
    }
}