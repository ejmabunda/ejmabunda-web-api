using ejmabunda_web_api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Respawn;
using Testcontainers.MsSql;

namespace ejmabunda_web_api.IntegrationTests.Fixtures;

public class SqlServerFixture : IAsyncLifetime
{
    private readonly MsSqlContainer _container = 
        new MsSqlBuilder("mcr.microsoft.com/mssql/server:2022-latest")
            .Build();

    public Respawner _respawner = null!;

    public string ConnectionString => _container.GetConnectionString();

    public Task DisposeAsync() => _container.DisposeAsync().AsTask();

    public async Task InitializeAsync()
    {
        // start the container
        await _container.StartAsync();

        // apply any pending migrations
        await using var context = CreateContext();
        await context.Database.MigrateAsync();

        // open a connection and pass to the respawner
        await using var connection = new SqlConnection(ConnectionString);
        await connection.OpenAsync();

        _respawner = await Respawner.CreateAsync(connection, new RespawnerOptions
        {
            DbAdapter = DbAdapter.SqlServer,
            TablesToIgnore = ["__EFMigrationsHistory"]
        });
    }

    public PortfolioContext CreateContext() =>
        new(new DbContextOptionsBuilder<PortfolioContext>()
            .UseSqlServer(ConnectionString)
            .Options);

    public async Task ResetAsync()
    {
        // open the connectiion and reset
        await using var connection = new SqlConnection(ConnectionString);
        await connection.OpenAsync();
        await _respawner.ResetAsync(connection);
    }
}