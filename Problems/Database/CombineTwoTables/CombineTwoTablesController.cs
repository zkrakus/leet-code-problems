using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Contexts.CombineTwoTables;
using Data.Models.CombineTwoTables;
using Microsoft.EntityFrameworkCore;
using Problems.Database.CombineTwoTables.Dtos;

namespace Problems.Database.CombineTwoTables;
public class CombineTwoTablesController
{
    private readonly CombineTwoTablesContext _context;

    private readonly MapperConfiguration _autoMapper = new(cfg =>
        cfg.CreateProjection<Person, PersonAddressDto>()
        .ForMember(dto => dto.AddressId, conf => conf.MapFrom(o => o.Address.AddressId))
        .ForMember(dto => dto.City, conf => conf.MapFrom(o => o.Address.City))
        .ForMember(dto => dto.State, conf => conf.MapFrom(o => o.Address.State))
    );

    public CombineTwoTablesController(CombineTwoTablesContext context) => _context = context;

    public async Task<IEnumerable<PersonAddressDto>> Index() => await _context.People.ProjectTo<PersonAddressDto>(_autoMapper).ToListAsync();

    public async Task<IEnumerable<PersonAddressDto>> RawSQL()
    {
        return await _context.People.FromSqlRaw(
            @"
            SELECT * 
                FROM [CombineTwoTables].[dbo].[People] p
                INNER JOIN [CombineTwoTables].[dbo].Addresses a
	            on p.PersonId = a.PersonId 
            ").ProjectTo<PersonAddressDto>(_autoMapper).ToListAsync();
    }
}
