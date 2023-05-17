using Moq;
using NUnit.Framework;
using TravelJournalAPI.Server.IServices;

namespace TravelJournalAPI.Server.UnitTests
{
    public class UserShouldTests
    {
        private readonly IUserService _userService;

        public UserShouldTests(IUserService userService)
        {
            _userService = userService;
        }

        [Test]
        public void UserStatus_ShouldBe_Beginner()
        {
            var mockRepository = new Mock<>
        }

    }
}
