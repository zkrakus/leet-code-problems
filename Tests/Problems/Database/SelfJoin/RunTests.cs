using Problems.Database.SelfJoin;
using Tests.Fixtures.SelfJoin;
using Xunit;

namespace Tests.Problems.Database.SelfJoin;
public class RunTests : IClassFixture<SelfJoinDatabaseFixture>
{
    public SelfJoinDatabaseFixture Fixture { get; }

    public RunTests(SelfJoinDatabaseFixture fixture)
        => Fixture = fixture;

    [Fact]
    public async void Should_Get_Data()
    {
        using var context = SelfJoinDatabaseFixture.CreateContext();
        var controller = new SelfJoinController(context);
        var data = await controller.RawSQL();

        System.Console.WriteLine(data);
    }
}

