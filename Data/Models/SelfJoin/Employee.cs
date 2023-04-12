using System.ComponentModel.DataAnnotations;

namespace Data.Models.SelfJoin;
public class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? SupervisorId { get; set; }

    public Employee(string firstName, string lastName, int? supervisorId)
    {
        FirstName = firstName;
        LastName = lastName;
        SupervisorId = supervisorId;
    }

}
