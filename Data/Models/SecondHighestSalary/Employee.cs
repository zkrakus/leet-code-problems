using System.ComponentModel.DataAnnotations;

namespace Data.Models.SecondHighestSalary;
public class Employee
{
    [Key]
    public int Id { get; set; }
    public int Salary { get; set; }
}
