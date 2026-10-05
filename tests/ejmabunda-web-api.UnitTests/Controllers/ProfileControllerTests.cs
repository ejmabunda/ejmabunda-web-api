using ejmabunda_web_api.Controllers;
using ejmabunda_web_api.Services;
using ejmabunda_web_api.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace ejmabunda_web_api.UnitTests.Controllers;

public class ProfileControllerTests
{
    private readonly Mock<IProfileService> _service = new();
    private readonly ProfileController _controller;

    public ProfileControllerTests()
    {
        _controller = new ProfileController(_service.Object);
    }

    [Fact]
    public async Task GetProfile_NoProfileExists_ReturnsNotFound()
    {
        // Arrange
        _service.Setup(s => s.GetProfileAsync()).ReturnsAsync((Profile?)null);

        // Act
        var result = await _controller.GetProfileAsync();

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetProfile_ProfileExists_ReturnsOkWithProfile()
    {
        // Arrange
        var response = new Profile()
        { Id = 1, Title = "Title", Headline = "Headline", Subtitle = "Subtitle" };
        _service.Setup(s => s.GetProfileAsync()).ReturnsAsync(response);

        // Act
        var result = await _controller.GetProfileAsync();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);

        Assert.Equal(response, okResult.Value);
    }

    [Fact]
    public async Task PostProfile_NoProfileExists_ReturnsCreatedAtGetProfile()
    {
        // Arrange
        var request = new ProfileAddDto()
        {
            Title = "Title",
            Headline = "Headline",
            Subtitle = "Subtitle"
        };

        var response = new Profile()
        {
            Id = 1,
            Title = request.Title,
            Headline = request.Headline,
            Subtitle = request.Subtitle
        };

        _service.Setup(s => s.AddProfileAsync(request))
            .ReturnsAsync(response);

        // Act
        var result = await _controller.PostProfileAsync(request);

        // Assert
        var created = Assert.IsType<CreatedAtActionResult>(result.Result);

        Assert.Same(response, created.Value);
        Assert.Equal("GetProfile", created.ActionName);
    }

    [Fact]
    public async Task PostProfile_ProfileExists_ReturnsConflict()
    {
        // Arrange
        var request = new ProfileAddDto()
        {
            Title = "Title",
            Headline = "Headline",
            Subtitle = "Subtitle"
        };
        _service.Setup(s => s.AddProfileAsync(request))
            .ReturnsAsync((Profile?)null);

        // Act
        var result = await _controller.PostProfileAsync(request);

        // Assert
        var conflictResult = Assert.IsType<ConflictObjectResult>(result.Result);
    }

    [Fact]
    public async Task PutProfile_ProfileExists_ReturnsOkWithProfile()
    {
        // Arrange
        var request = new ProfilePutDto() { Title = "New Title" };
        var response = new Profile()
        { Id = 1, Title = "New Title", Headline = "Headline", Subtitle = "Subtitle" };

        _service.Setup(s => s.UpdateProfileAsync(request))
            .ReturnsAsync(response);

        // Act
        var result = await _controller.PutProfileAsync(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);

        Assert.Same(response, okResult.Value);
    }

    [Fact]
    public async Task PutProfile_NoProfileExists_ReturnsNotFound()
    {
        // Arrange
        var request = new ProfilePutDto() { Title = "New Title" };
        _service.Setup(s => s.UpdateProfileAsync(request))
            .ReturnsAsync((Profile?)null);

        // Act
        var result = await _controller.PutProfileAsync(request);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task PutProfile_ConcurrencyConflictAndProfileStillExists_Rethrows()
    {
        // Arrange
        var response = new Profile()
        { Id = 1, Title = "Title", Headline = "Headline", Subtitle = "Subtitle" };
        var request = new ProfilePutDto() { Title = "New Title" };
        _service.Setup(s => s.UpdateProfileAsync(request))
            .ThrowsAsync(new DbUpdateConcurrencyException());

        _service.Setup(s => s.GetProfileAsync())
            .ReturnsAsync(response);

        // Act & Assert
        await Assert.ThrowsAsync<DbUpdateConcurrencyException>(
            () => _controller.PutProfileAsync(request));
    }

    [Fact]
    public async Task PutProfile_ConcurrencyConflictAndProfileDeleted_ReturnsNotFound()
    {
        // Arrange
        var request = new ProfilePutDto() { Title = "New Title" };
        _service.Setup(s => s.UpdateProfileAsync(request))
            .ThrowsAsync(new DbUpdateConcurrencyException());

        _service.Setup(s => s.GetProfileAsync())
            .ReturnsAsync((Profile?)null);

        // Act
        var result = await _controller.PutProfileAsync(request);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}