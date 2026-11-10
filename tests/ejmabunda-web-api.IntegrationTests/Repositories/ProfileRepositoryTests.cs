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
        await SeedProfileAsync();
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
        await SeedProfileAsync();
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

    [Fact]
    public async Task UpdateProfile_ProfileExists_FullUpdatePersistsAndReturnsProfile()
    {
        // Arrange
        await SeedProfileAsync();

        await using var act = db.CreateContext();
        var repository
            = new ProfileRepository(act, NullLogger<ProfileRepository>.Instance);
        var anyProfile = await act.Profiles.FirstOrDefaultAsync();
        Assert.NotNull(anyProfile);

        // Act
        var newProfilePutDto = NewProfilePutDto();
        var result = await repository.UpdateProfileAsync(anyProfile!, newProfilePutDto);

        // Assert
        var newProfile = NewProfile();
        await using var assert = db.CreateContext();
        var stored = Assert.Single(await assert.Profiles.ToListAsync());
        Assert.Equivalent(newProfile, stored);
        Assert.Equivalent(newProfile, result);
    }

    [Fact]
    public async Task UpdateProfile_ProfileExists_PartialUpdatePersistsAndReturnsProfile()
    {
        // Arrange
        await SeedProfileAsync();
        await using var act = db.CreateContext();
        var repository =
            new ProfileRepository(act, NullLogger<ProfileRepository>.Instance);

        var anyProfile = await act.Profiles.FirstOrDefaultAsync();
        Assert.NotNull(anyProfile);

        // Act
        var partialProfilePutDto = PartialProfilePutDto();
        var result = await repository.UpdateProfileAsync(anyProfile!, partialProfilePutDto);

        // Assert
        var partialProfile = PartialProfile();
        await using var assert = db.CreateContext();
        var stored = Assert.Single(await assert.Profiles.ToListAsync());
        Assert.Equivalent(partialProfile, stored);
        Assert.Equivalent(partialProfile, result);
    }

    [Fact]
    public async Task DeleteProfile_ProfileExists_RemovesFromDbAndReturnsProfile()
    {
        // Arrange
        await SeedProfileAsync();
        await using var act = db.CreateContext();
        var repository =
            new ProfileRepository(act, NullLogger<ProfileRepository>.Instance);
        var profile = await act.Profiles.FirstOrDefaultAsync();
        Assert.NotNull(profile);

        // Act
        var result = await repository.DeleteProfileAsync(profile);

        // Assert
        Assert.Same(profile, result);
        await using var assert = db.CreateContext();
        Assert.Empty(await assert.Profiles.ToListAsync());
    }

    // helpers
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

    private static Profile NewProfile() => new()
    {
        Title = "New Title",
        Subtitle = "New Subtitle",
        Headline = "New Headline"
    };

    private static ProfilePutDto NewProfilePutDto() => new()
    {
        Title = "New Title",
        Subtitle = "New Subtitle",
        Headline = "New Headline"
    };

    private static ProfilePutDto PartialProfilePutDto() => new()
    {
        Title = "Partial Title"
    };

    private static Profile PartialProfile() => new()
    {
        Title = "Partial Title",
        Headline = "Headline",
        Subtitle = "Subtitle"
    };

    private async Task SeedProfileAsync()
    {
        await using (var arrange = db.CreateContext())
        {
            await arrange.Profiles.AddAsync(AnyProfile());
            await arrange.SaveChangesAsync();
        }
    }
}