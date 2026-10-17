using ejmabunda_web_api.IntegrationTests.Fixtures;
using ejmabunda_web_api.Models;
using ejmabunda_web_api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace ejmabunda_web_api.IntegrationTests;

[Collection(nameof(DatabaseCollection))]
public class ProfileRepositoryTests(SqlServerFixture db) : IAsyncLifetime
{
    public Task InitializeAsync() => db.ResetAsync();
    public Task DisposeAsync() => Task.CompletedTask;

    [Fact]
    public async Task GetProfile_WhenEmpty_ReturnsNull()
    {
        // Arrange
        await using var act = db.CreateContext();
        var repository =
            new ProfileRepository(act, NullLogger<ProfileRepository>.Instance);

        // Act
        var result = await repository.GetProfileAsync();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetProfile_WhenExists_ReturnsProfile()
    {
        // Arrange
        await using (var arrange = db.CreateContext())
        {
            arrange.Profiles.Add(AnyProfile());
            await arrange.SaveChangesAsync();
        }

        await using var act = db.CreateContext();
        var repository =
            new ProfileRepository(act, NullLogger<ProfileRepository>.Instance);

        // Act
        var result = await repository.GetProfileAsync();

        // Assert
        Assert.Equivalent(AnyProfile(), result);
    }

    [Fact]
    public async Task AddProfile_WhenExists_ReturnsNull()
    {
        // Arrange
        await using (var arrange = db.CreateContext())
        {
            await arrange.Profiles.AddAsync(AnyProfile());
            await arrange.SaveChangesAsync();
        }

        await using var act = db.CreateContext();
        var repository =
            new ProfileRepository(act, NullLogger<ProfileRepository>.Instance);

        // Act
        var sampleProfile = new ProfileAddDto()
        { Title = "Sample Title", Headline = "Sample Headline", Subtitle = "Sample Subtitle" };
        var result = await repository.AddProfileAsync(sampleProfile);

        // Assert
        Assert.Null(result);

        // "arranged" profile must stay untouched
        await using var assert = db.CreateContext();
        var stored = Assert.Single(await assert.Profiles.ToListAsync());
        Assert.Equivalent(AnyProfile(), stored);
    }

    [Fact]
    public async Task AddProfile_WhenEmpty_PersistsAndReturnsProfile()
    {
        // Arrange
        await using var act = db.CreateContext();
        var repository =
            new ProfileRepository(act, NullLogger<ProfileRepository>.Instance);

        // Act
        var result = await repository.AddProfileAsync(AnyProfileAddDto());

        // Assert
        Assert.Equivalent(AnyProfile(), result);
        await using var assert = db.CreateContext();
        var stored = Assert.Single(await assert.Profiles.ToListAsync());
        Assert.Equivalent(AnyProfile(), stored);
    }

    private static Profile AnyProfile() => new()
    {
        Title = "Title",
        Headline = "Headline",
        Subtitle = "Subtitle"
    };

    private static ProfileAddDto AnyProfileAddDto() => new()
    {
        Title = "Title",
        Headline = "Headline",
        Subtitle = "Subtitle"
    };
}