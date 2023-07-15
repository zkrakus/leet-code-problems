using Data.Contexts.ValueObjects;
using Data.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;
class PersonEntityTypeConfiguration
    : IEntityTypeConfiguration<PersonEntity>
{
    public void Configure(EntityTypeBuilder<PersonEntity> personConfiguration)
    {
        personConfiguration.ToTable("People", ValueObjectsDbContext.DEFAULT_SCHEMA);
        personConfiguration.HasKey(p => p.PersonId);


    }
}
