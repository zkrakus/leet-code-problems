using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts.EmployeesEarningMoreThanTheirManagers.Functions;
public class SqlFunctions
{
    public const string Query = @"
        Select 
            e1.name as Employee
        From
            Employee as e1
            inner join Employee as e2
            on e1.managerId = e2.id
        Where
            e1.Salary > e2.Salary";

    public const string QueryWithCTE = @"
        WITH EmployeeManagers AS (
          SELECT e1.id AS EmployeeId, e1.name AS EmployeeName, e2.id AS ManagerId, e2.name AS ManagerName, e1.Salary as Salary1, e2.Salary as Salary2
          FROM Employee e1
          INNER JOIN Employee e2 ON e1.managerId = e2.id
        )
        SELECT EmployeeName as Employee
        FROM EmployeeManagers
        WHERE Salary1 > Salary2
";

}
