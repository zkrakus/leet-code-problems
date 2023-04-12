using Problems.Database.CombineTwoTables;
using Tests.Fixtures.CombineTwoTables;
using Xunit;

namespace Tests.Problems.Database.CombineTwoTablesTests;
public class RunTests : IClassFixture<CombineTwoTablesDatabaseFixture>
{
    public CombineTwoTablesDatabaseFixture Fixture { get; }

    public RunTests(CombineTwoTablesDatabaseFixture fixture)
        => Fixture = fixture;

    [Fact]
    public async void Should_Get_Data()
    {
        using var context = CombineTwoTablesDatabaseFixture.CreateContext();

        var controller = new CombineTwoTablesController(context);

        var data = await controller.Index();

        foreach (var row in data)
        {
            System.Console.WriteLine(row.ToString());
        }
    }
}
