using Data.Contexts.SelfJoin;
using Data.Models.SelfJoin;
using Microsoft.EntityFrameworkCore;

namespace Tests.Fixtures.SelfJoin;
public class SelfJoinDatabaseFixture
{

    private const string ConnectionString = "Data Source=localhost;User ID=sa;Password=password!123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database='SelfJoin'";

    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public SelfJoinDatabaseFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using (var context = CreateContext())
                {
                    _ = context.Database.EnsureDeleted();
                    _ = context.Database.EnsureCreated();

                    for (var i = 1; i < 11; i++)
                    {
                        _ = context.Add(
                            new Employee(firstName: "FirstName" + i, lastName: "LastName" + i, supervisorId: GetSupervisorId(i)));
                    }

                    _ = context.SaveChanges();
                }

                _databaseInitialized = true;
            }
        }
    }

    public static SelfJoinDbContext CreateContext()
        => new(new DbContextOptionsBuilder<SelfJoinDbContext>()
                .UseSqlServer(ConnectionString)
                .Options);

#pragma warning disable IDE0046 // Convert to conditional expression
    private static int? GetSupervisorId(int i)
    {

        if (i % 2 == 0)
            return i - 1;
        else if (i % 3 == 0)
            return i - 1;
        else
            return null;
    }
#pragma warning restore IDE0046 // Convert to conditional expression
}
