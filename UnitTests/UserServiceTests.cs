using Moq;
using TravelJournalAPI.Server.Services;
using TravelJournalAPI.Shared.Entities;
using TravelJournalAPI.Shared.IRepositories;

public class UserServiceTests
{
    private const string Expected = "Explorer";
    private Mock<IUserRepository> _mockUserRepository;
    private UserService _userService;

    [SetUp]
    public void Setup()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _userService = new UserService(_mockUserRepository.Object);
    }

    [Test]
    public async Task GetUsersStatusById_WithNoHolidays_ShouldReturnUndefined()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var holidays = new List<Holiday>(); // Empty list

        _mockUserRepository.Setup(x => x.GetHolidayById(It.IsAny<Guid>())).ReturnsAsync(holidays);

        // Act
        var result = await _userService.GetUsersStatusById(userId);

        // Assert
        Assert.AreEqual("Undefined", result);
        _mockUserRepository.Verify(x => x.GetHolidayById(userId), Times.Once);
    }

    [Test]
    public async Task GetUsersStatusById_WithFewHolidays_ShouldReturnBeginner()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var holidays = new List<Holiday>()
        {
            new Holiday { Id = Guid.NewGuid() },
            new Holiday { Id = Guid.NewGuid() }
        };

        _mockUserRepository.Setup(x => x.GetHolidayById(It.IsAny<Guid>())).ReturnsAsync(holidays);

        // Act
        var result = await _userService.GetUsersStatusById(userId);

        // Assert
        Assert.That(result, Is.EqualTo("Beginner"));
        _mockUserRepository.Verify(x => x.GetHolidayById(userId), Times.Once);
    }

    [Test]
    public async Task GetUsersStatusById_WithManyHolidays_ShouldReturnExplorer()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var holidays = new List<Holiday>()
        {
            new Holiday { Id = Guid.NewGuid() },
            new Holiday { Id = Guid.NewGuid() },
            new Holiday { Id = Guid.NewGuid() },
            new Holiday { Id = Guid.NewGuid() }
        };

        _mockUserRepository.Setup(x => x.GetHolidayById(It.IsAny<Guid>())).ReturnsAsync(holidays);

        // Act
        var result = await _userService.GetUsersStatusById(userId);

        // Assert
        Assert.AreEqual(Expected, result);
        _mockUserRepository.Verify(x => x.GetHolidayById(userId), Times.Once);
    }

    public async Task GetUsersStatusById_WithManyHolidays_ShouldReturnTravelMaster()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var holidays = new List<Holiday>()
        {
            new Holiday { Id = Guid.NewGuid() },
            new Holiday { Id = Guid.NewGuid() },
            new Holiday { Id = Guid.NewGuid() },
            new Holiday { Id = Guid.NewGuid() },
            new Holiday { Id = Guid.NewGuid() }
        };

        _mockUserRepository.Setup(x => x.GetHolidayById(It.IsAny<Guid>())).ReturnsAsync(holidays);

        // Act
        var result = await _userService.GetUsersStatusById(userId);

        // Assert
        Assert.That(result, Is.EqualTo("Travel Master"));
        _mockUserRepository.Verify(x => x.GetHolidayById(userId), Times.Once);
    }

}