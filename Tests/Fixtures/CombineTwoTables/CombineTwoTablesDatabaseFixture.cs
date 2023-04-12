using Data.Contexts.CombineTwoTables;
using Data.Models.CombineTwoTables;
using Microsoft.EntityFrameworkCore;

namespace Tests.Fixtures.CombineTwoTables;
public class CombineTwoTablesDatabaseFixture
{

    private const string ConnectionString = "Data Source=localhost;User ID=sa;Password=password!123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database='CombineTwoTables'";

    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public CombineTwoTablesDatabaseFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using (var context = CreateContext())
                {
                    _ = context.Database.EnsureDeleted();
                    _ = context.Database.EnsureCreated();

                    for (var i = 0; i < 10; i++)
                    {
                        _ = context.Add(
                            new Person(firstName: "FirstName" + i, lastName: "LastName" + i,
                                address: new Address(city: "City" + i, state: "S" + i)));
                    }

                    _ = context.People.FromSqlRaw(
                        @"
                        USE [CombineTwoTables]
                        GO

                        Create Procedure [dbo].[GetPersonAddressById]
	                        @PersonId int = null

                        AS BEGIN

	                        SET NOCOUNT ON
	                        --When you use SET NOCOUNT ON, the message that indicates the number of rows that are affected by the T-SQL statement is not returned as part of the results.

                        SELECT p.[FirstName], p.[LastName], a.[City], a.[State]
                          FROM [CombineTwoTables].[dbo].[People]  p
                          JOIN [CombineTwoTables].[dbo].Addresses as a
	                        on p.PersonId = a.PersonId

                        END
                        "

                        );

                    _ = context.SaveChanges();
                }

                _databaseInitialized = true;
            }
        }
    }

    public static CombineTwoTablesContext CreateContext()
        => new(new DbContextOptionsBuilder<CombineTwoTablesContext>()
                .UseSqlServer(ConnectionString)
                .Options);
}
