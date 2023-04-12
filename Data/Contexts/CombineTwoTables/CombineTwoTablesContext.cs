using Data.Models.CombineTwoTables;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts.CombineTwoTables;
public class CombineTwoTablesContext : DbContext
{
    public DbSet<Person> People { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;

    public CombineTwoTablesContext(DbContextOptions<CombineTwoTablesContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<Person>().ToTable("People");
        _ = modelBuilder.Entity<Address>().ToTable("Addresses");
    }
}
