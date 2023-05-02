using Problems.Database.CombineTwoTables;
using Problems.Database.DepartmentHighestSalary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Fixtures.CombineTwoTables;
using Tests.Fixtures.DepartmentHighestSalary;
using Xunit;

namespace Tests.Problems.Database.DepartmentHighestSalary;
public class RunTests : IClassFixture<DepartmentHighestSalaryDatabaseFixture>
{
    public DepartmentHighestSalaryDatabaseFixture Fixture { get; }

    public RunTests(DepartmentHighestSalaryDatabaseFixture fixture)
        => Fixture = fixture;

    [Fact]
    public async Task ShouldGetData()
    {
        using var context = DepartmentHighestSalaryDatabaseFixture.CreateContext();
        var controller = new DepartmentHighestSalaryController(context);
        var data = await controller.Index();

        foreach (var row in data)
        {
            Console.WriteLine(row.ToString());
        }
    }
}