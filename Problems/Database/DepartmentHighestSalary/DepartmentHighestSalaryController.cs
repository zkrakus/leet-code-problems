using AutoMapper;
using Data.Contexts.CombineTwoTables;
using Data.Contexts.DepartmentHighestSalary;
using Data.Models.DepartmentHighestSalary;
using Microsoft.EntityFrameworkCore;
using Problems.Database.CombineTwoTables.Dtos;
using Problems.Database.DepartmentHighestSalary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Database.DepartmentHighestSalary;
public class DepartmentHighestSalaryController
{
    private readonly DepartmentHighestSalaryDbContext _context;

    public DepartmentHighestSalaryController(DepartmentHighestSalaryDbContext context) => _context = context;

    public async Task<IEnumerable<(string Department, string Employee, int Salary)>> Index() 
        => (IEnumerable<(string Department, string Employee, int Salary)>)await _context.Employees.FromSqlInterpolated($"SELECT * FROM usp_GetDepartmentHighestSalary()").ToListAsync();
}
