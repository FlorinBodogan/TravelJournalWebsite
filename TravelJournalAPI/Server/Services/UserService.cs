using TravelJournalAPI.Server.Data;
using TravelJournalAPI.Server.IServices;
using TravelJournalAPI.Shared.IRepositories;

namespace TravelJournalAPI.Server.Services
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> GetUsersStatusById(Guid id)
        {

            try
            {
                var holidays = await _userRepository.GetHolidayById(id);

                var numberOfHolidays = holidays.Count();

                if (numberOfHolidays > 2 && numberOfHolidays <= 4)
                {
                    return "Explorer";
                }
                else if (numberOfHolidays >= 5)
                {
                    return "Travel Master";
                }
                return "Beginner";
            }
            catch (Exception ex)
            {
                return $"User with id {id} not found.";
            }  
        }
    }
}
