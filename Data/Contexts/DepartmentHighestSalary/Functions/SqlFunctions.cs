using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts.DepartmentHighestSalary.Functions;
public class SqlFunctions
{
    public const string GetDepartmentHighestSalary =
    @"EXEC('
        CREATE OR ALTER FUNCTION usp_GetDepartmentHighestSalary() 
        RETURNS Table AS
            RETURN (
                Select 
                    dr.DepartmentName as Department,
                    dr.EmployeeName as Employee, 
                    dr.Salary
                From (
                    Select
                    Dense_rank() OVER (PARTITION BY d.id ORDER BY Salary DESC) as [Rank],
                    e.Name as EmployeeName, 
                    e.Salary, 
                    d.Name as DepartmentName
                        From Employees as e
                        inner join Departments as d
                        on e.departmentId = d.id
                ) as dr
                where [Rank] = 1
            );
        ')";

    public const string DropGetDepartmentHighestSalary =
        @"EXEC('
            DROP FUNCTION FUNCTION usp_GetDepartmentHighestSalary;
        ');";
}
