using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.DepartmentHighestSalary;
public class Employee
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public int Salary { get; set; }
    public int DepartmentID { get; set; }

    public Department? Department { get; set; }
}
