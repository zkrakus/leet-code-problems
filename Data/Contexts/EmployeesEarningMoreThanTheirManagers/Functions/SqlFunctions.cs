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

}
