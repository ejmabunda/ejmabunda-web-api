using ejmabunda_web_api.Models;
using ejmabunda_web_api.Repositories;
using ejmabunda_web_api.Services;
using Moq;

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
    public async Task AddProfile_RepositoryReturnsProfile_ReturnsProfile()
    {
        // Arrange
        var anyProfileAddDto = AnyProfileAddDto();
        var anyProfile = AnyProfile();

        _repository.Setup(r => r.AddProfileAsync(anyProfileAddDto))
            .ReturnsAsync(anyProfile);

        // Act
        var result = await _service.AddProfileAsync(anyProfileAddDto);

        // Assert
        Assert.Same(anyProfile, result);
    }

    [Fact]
    public async Task AddProfile_RepositoryReturnsNull_ReturnsNull()
    {
        // Arrange
        var anyProfileAddDto = AnyProfileAddDto();
        _repository.Setup(r => r.AddProfileAsync(anyProfileAddDto))
            .ReturnsAsync((Profile?)null);

        // Act
        var result = await _service.AddProfileAsync(anyProfileAddDto);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetProfile_RepositoryReturnsProfile_ReturnsProfile()
    {
        // Arrange
        var anyProfile = AnyProfile();
        _repository.Setup(r => r.GetProfileAsync())
            .ReturnsAsync(anyProfile);

        // Act
        var result = await _service.GetProfileAsync();

        // Assert
        Assert.Same(anyProfile, result);
    }

    [Fact]
    public async Task GetProfile_RepositoryReturnsNull_ReturnsNull()
    {
        // Arrange
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
        var profilePutDto = UpdatedProfilePutDto();
        var anyProfile = AnyProfile();
        var profile = UpdatedProfile();
        _repository.Setup(r => r.GetProfileAsync())
            .ReturnsAsync(anyProfile);
        _repository.Setup(r => r.UpdateProfileAsync(anyProfile, profilePutDto))
            .ReturnsAsync(profile);

        // Act
        var result = await _service.UpdateProfileAsync(profilePutDto);

        // Assert
        Assert.Same(profile, result);
    }

    [Fact]
    public async Task UpdateProfile_NoProfileExists_ReturnsNull()
    {
        // Arrange
        var profilePutDto = UpdatedProfilePutDto();
        _repository.Setup(r => r.GetProfileAsync())
            .ReturnsAsync((Profile?)null);

        // Act
        var result = await _service.UpdateProfileAsync(profilePutDto);

        // Assert
        Assert.Null(result);
        _repository.Verify(
            r => r.UpdateProfileAsync(It.IsAny<Profile>(), It.IsAny<ProfilePutDto>()),
            Times.Never);
    }

    [Fact]
    public async Task DeleteProfile_ProfileExists_ReturnsDeletedProfile()
    {
        // Arrange
        var anyProfile = AnyProfile();
        _repository.Setup(r => r.GetProfileAsync())
            .ReturnsAsync(anyProfile);
        _repository.Setup(r => r.DeleteProfileAsync(anyProfile))
            .ReturnsAsync(anyProfile);

        // Act
        var result = await _service.DeleteProfileAsync();

        // Assert
        Assert.Same(anyProfile, result);
    }

    [Fact]
    public async Task DeleteProfile_NoProfileExists_ReturnsNull()
    {
        // Arrange
        _repository.Setup(r => r.GetProfileAsync())
            .ReturnsAsync((Profile?)null);

        // Act
        var result = await _service.DeleteProfileAsync();

        // Assert
        Assert.Null(result);
        _repository.Verify(
            r => r.DeleteProfileAsync(It.IsAny<Profile>()),
            Times.Never);
    }

    private static ProfileAddDto AnyProfileAddDto() => new()
    {
        Title = "Title", Headline = "Headline", Subtitle = "Subtitle"
    };

    private static Profile AnyProfile() => new()
    {
        Id = 1, Title = "Title", Headline = "Headline", Subtitle = "Subtitle"
    };

    private static Profile UpdatedProfile() => new()
    {
        Title = "New Title", Headline = "New Headline", Subtitle = "New Subtitle"
    };

    private static ProfilePutDto UpdatedProfilePutDto() => new()
    {
        Title = "New Title", Headline = "New Headline", Subtitle = "New Subtitle"
    };
}