using ejmabunda_web_api.Models;
using ejmabunda_web_api.Repositories;
using ejmabunda_web_api.Services;
using Moq;
using Xunit;

namespace ejmabunda_web_api.UnitTests.Services;

public class ProfileServiceTests
{
    private readonly ProfileService _service;
    private readonly Mock<IProfileRepository> _repository = new();

    public ProfileServiceTests()
    {
        _service = new ProfileService(_repository.Object);
    }

    [Fact]
    public async Task AddProfileAsync_NoProfileExists_ReturnsProfile()
    {
        // Arrange
        var anyProfileAddDto = AnyProfileAddDto();
        var anyProfile = AnyProfile();

        _repository.Setup(r => r.AddProfileAsync(anyProfileAddDto))
            .ReturnsAsync(anyProfile);

        // Act
        var result = await _service.AddProfileAsync(anyProfileAddDto);

        // Assert
        Assert.IsType<Profile>(result);
    }

    [Fact]
    public async Task AddProfileAsync_ProfileExists_ReturnsNull()
    {
        // Arrange
        var anyProfileAddDto = AnyProfileAddDto();
        var anyProfile = AnyProfile();
        _repository.Setup(r => r.AddProfileAsync(anyProfileAddDto))
            .ReturnsAsync((Profile?)null);

        // Act
        var result = await _service.AddProfileAsync(anyProfileAddDto);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetProfile_ProfileExists_ReturnsProfile()
    {
        // Arrange
        var anyProfile = AnyProfile();
        _repository.Setup(r => r.GetProfileAsync())
            .ReturnsAsync(anyProfile);

        // Act
        var result = await _service.GetProfileAsync();

        // Assert
        Assert.IsType<Profile>(result);
    }

    [Fact]
    public async Task GetProfile_NoProfileExists_ReturnsNull()
    {
        // Arrange
        var anyProfile = AnyProfile();
        _repository.Setup(r => r.GetProfileAsync())
            .ReturnsAsync((Profile?)null);

        // Act
        var result = await _service.GetProfileAsync();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task UpdateProfile_ProfileExists_ReturnsUpdatedProfile()
    {
        // Arrange
        var profilePutDto = ProfilePutDto();
        var anyProfile = AnyProfile();
        var profile = Profile();
        _repository.Setup(r => r.GetProfileAsync())
            .ReturnsAsync(anyProfile);
        _repository.Setup(r => r.UpdateProfileAsync(anyProfile, profilePutDto))
            .ReturnsAsync(profile);

        // Act
        var result = await _service.UpdateProfileAsync(profilePutDto);

        // Assert
        Assert.NotNull(result);
        // Assert.Same(result, profile);
    }

    private static ProfileAddDto AnyProfileAddDto() => new()
    {
        Title = "Title", Headline = "Headline", Subtitle = "Subtitle"
    };

    private static Profile AnyProfile() => new()
    {
        Id = 1, Title = "Title", Headline = "Headline", Subtitle = "Subtitle"
    };

    private static Profile Profile() => new()
    {
        Title = "New Title", Headline = "New Headline", Subtitle = "New Subtitle"
    };

    private static ProfilePutDto AnyProfilePutDto() => new()
    {
        Title = "Title", Headline = "Headline", Subtitle = "Subtitle"
    };

    private static ProfilePutDto ProfilePutDto() => new()
    {
        Title = "New Title", Headline = "New Headline", Subtitle = "New Subtitle"
    };
}