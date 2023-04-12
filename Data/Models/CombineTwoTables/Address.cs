using System.ComponentModel.DataAnnotations;

namespace Data.Models.CombineTwoTables;
public class Address
{
    [Key]
    public int AddressId { get; set; }

    public int PersonId { get; set; }

    public Person Person { get; set; }

    [MaxLength(25)]
    public string City { get; set; }

    [MinLength(2), MaxLength(2)]
    public string State { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Address(string city, string state)

    {
        City = city;
        State = state;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
