using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Data.Models.CombineTwoTables;

[Index(nameof(PersonId), IsDescending = new[] { false, true })]
public class Person
{
    [Key]
    public int PersonId { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; }

    [MaxLength(50)]
    public string LastName { get; set; }

    public Person(string firstName, string lastName, Address address)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
    }

    public Address Address { get; set; }
}
