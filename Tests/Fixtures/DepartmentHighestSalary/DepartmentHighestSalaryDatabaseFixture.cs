using Data.Contexts.DepartmentHighestSalary;
using Data.Models.DepartmentHighestSalary;
using Microsoft.EntityFrameworkCore;

namespace Tests.Fixtures.DepartmentHighestSalary;
public class DepartmentHighestSalaryDatabaseFixture
{
    private const string _connectionString = "Data Source=localhost;User ID=sa;Password=password!123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database='DepartmentHighestSalary'";

    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public DepartmentHighestSalaryDatabaseFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using (var context = CreateContext())
                {

                    if (!context.Database.EnsureCreated())
                    {

                        var d1 = new Department() { Id = 1, Name = "IT" };
                        var d2 = new Department() { Id = 2, Name = "Sales" };

                        context.Add(d1);
                        context.Add(d2);

                        _ = context.Add(new Employee() { Id = 1, Name = "Joe", Salary = 70000, DepartmentID = 1 });
                        _ = context.Add(new Employee() { Id = 2, Name = "Jim", Salary = 90000, DepartmentID = 1 });
                        _ = context.Add(new Employee() { Id = 3, Name = "Henry", Salary = 80000, DepartmentID = 2 });
                        _ = context.Add(new Employee() { Id = 4, Name = "Sam", Salary = 60000, DepartmentID = 2 });
                        _ = context.Add(new Employee() { Id = 5, Name = "Max", Salary = 90000, DepartmentID = 1 });

                        _ = context.SaveChanges();
                    }
                }

                _databaseInitialized = true;
            }
        }
    }

    public static DepartmentHighestSalaryDbContext CreateContext()
        => new(new DbContextOptionsBuilder<DepartmentHighestSalaryDbContext>()
                .UseSqlServer(_connectionString)
                .Options);

}
