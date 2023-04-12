using Data.Contexts.CombineTwoTables;
using Data.Contexts.NthHighestSalary;
using Data.Contexts.SecondHighestSalary;
using Data.Contexts.SelfJoin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

static void LoadConfiguration(HostBuilderContext host, IConfigurationBuilder builder) =>
    builder
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Release"}.json", optional: true)
        .AddEnvironmentVariables();

static void ConfigureServices(HostBuilderContext host, IServiceCollection services) =>
    services
        .AddDbContext<CombineTwoTablesContext>(options => options.UseSqlServer(
                host.Configuration.GetConnectionString("CombineTwoTablesContext"), builder =>
                    builder.MigrationsAssembly("Data")))
        .AddDbContext<SelfJoinDbContext>(options => options.UseSqlServer(
                host.Configuration.GetConnectionString("SelfJoinContext"), builder =>
                    builder.MigrationsAssembly("Data")))
        .AddDbContext<SecondHighestSalaryDbContext>(options =>
            options.UseSqlServer(
                host.Configuration.GetConnectionString("SecondHighestSalary"), builder =>
                builder.MigrationsAssembly("Data"))
        )
        .AddDbContext<NthHighestSalaryDbContext>(options =>
            options.UseSqlServer(
                host.Configuration.GetConnectionString("NthHighestSalary"), builder =>
                builder.MigrationsAssembly("Data"))
        );

static IHostBuilder CreateHostBuilder(string[] args) =>
Host.CreateDefaultBuilder(args)
.ConfigureAppConfiguration((host, configuration) => LoadConfiguration(host, configuration))
.ConfigureServices((host, services) => ConfigureServices(host, services));

CreateHostBuilder(args).Build().Run();
