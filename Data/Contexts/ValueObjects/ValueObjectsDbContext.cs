using Data.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts.ValueObjects;
public class ValueObjectsDbContext : DbContext
{
    public const string DEFAULT_SCHEMA = "valueObjects";

    public DbSet<PersonEntity> People { get; set; } = null!;

    public ValueObjectsDbContext(DbContextOptions<ValueObjectsDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());

        //modelBuilder.Entity<PersonEntity>().ToTable("People");
    } 
}