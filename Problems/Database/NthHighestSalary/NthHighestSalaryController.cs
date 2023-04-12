using Data.Contexts.NthHighestSalary;
using Microsoft.EntityFrameworkCore;

namespace Problems.Database.NthHighestSalary;
public class NthHighestSalaryController
{
    private readonly NthHighestSalaryDbContext _context;

    //private readonly MapperConfiguration _autoMapper = new MapperConfiguration(cfg =>
    //    cfg.CreateProjection<Employee, EmployeeDto>());

    public NthHighestSalaryController(NthHighestSalaryDbContext context) => _context = context;

    public async Task<int> GetNthHighestSalary(int n) => await _context.Database.ExecuteSqlAsync($"[dbo].[usp_GetNthHighestSalary] ({n}) as Salary");
}
