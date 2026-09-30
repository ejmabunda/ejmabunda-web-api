namespace ejmabunda_web_api.Tests;
using ejmabunda_web_api.Controllers;

public class ProfileControllerTests
{
    private readonly IProfileService _profileServiceMock;
    private readonly IProfileController _profileController;

    public ProfileControllerTests()
    {
        _profileServiceMock = new Mock<IProfileService>();
        _profileController = new ProfileControllerTests(_profileServiceMock.Object);
    }

    []
}
