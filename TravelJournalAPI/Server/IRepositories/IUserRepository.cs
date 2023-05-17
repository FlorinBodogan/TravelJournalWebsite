using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelJournalAPI.Shared.Entities;

namespace TravelJournalAPI.Shared.IRepositories
{
    public interface IUserRepository
    {
        public Task<bool> CheckIfEmailExistsAsync(string email);

        public Task<User> GetUserByEmail(string email);

        public Task<string> AddAsync(User user);

        public Task<string> AddHolidayAsync(Holiday holiday);

        public Task<IEnumerable<Holiday>> GetHolidayById(Guid userId);
    }
}
