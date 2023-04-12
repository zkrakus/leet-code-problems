namespace Problems.Database.CombineTwoTables.Dtos;
public class PersonAddressDto
{
    public int PersonId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int AddressId { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }
}
