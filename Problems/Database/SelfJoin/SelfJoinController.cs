using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Contexts.SelfJoin;
using Data.Models.SelfJoin;
using Microsoft.EntityFrameworkCore;
using Problems.Database.SecondHighestSalary.Dtos;

namespace Problems.Database.SelfJoin;
public class SelfJoinController
{
    private readonly SelfJoinDbContext _context;

    private readonly MapperConfiguration _autoMapper = new(cfg =>
        cfg.CreateProjection<Employee, EmployeeDto>());

    public SelfJoinController(SelfJoinDbContext context) => _context = context;

    public async Task<IEnumerable<EmployeeDto>> RawSQL()
    {
        return await _context.Employees.FromSqlRaw(
            @"
            SELECT * 
                FROM [CombineTwoTables].[dbo].[People] p
                INNER JOIN [CombineTwoTables].[dbo].Addresses a
	            on p.PersonId = a.PersonId 
            ").ProjectTo<EmployeeDto>(_autoMapper).ToListAsync();
    }
}
