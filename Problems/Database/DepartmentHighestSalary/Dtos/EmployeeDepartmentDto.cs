using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Database.DepartmentHighestSalary.Dtos;
public class EmployeeDepartmentDto
{
    public string? Department { get; set; }
    public string? Employee { get; set; }
    public int Salary { get; set; }
}
