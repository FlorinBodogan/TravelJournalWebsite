using Microsoft.EntityFrameworkCore;
using System.Linq;
using TravelJournalAPI.Server.Data;
using TravelJournalAPI.Shared.Entities;
using TravelJournalAPI.Shared.IRepositories;
using TravelJournalAPI.Shared.Models;

namespace TravelJournalAPI.Shared.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext) 
        { 
            _dataContext = dataContext;
        }

        public async Task<string> AddAsync(User user)
        {
            if(await CheckIfEmailExistsAsync(user.Email))
            {
                return "This email already exists!";
            }

            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return "Account created!";
        }

        public async Task<bool> CheckIfEmailExistsAsync(string email)
        {
            return await _dataContext.Users.AnyAsync(u => u.Email == email);
        }

        //public async Task<User> GetUserInfo(string email, string password)
        //{
        //    try
        //    {
        //        return await _dataContext.Users.FirstOrDefaultAsync(e => e.Email == email && e.Password == password);
        //    }
        //    catch (Exception ex)
        //    { 

        //    }           
        //}
        public async Task<string> AddHolidayAsync(Holiday holiday)
        {
            await _dataContext.Holidays.AddAsync(holiday);
            await _dataContext.SaveChangesAsync();

            return "Holiday created!";
        }
        
        public async Task<IEnumerable<Holiday>> GetHolidayById(Guid userId)
        {
            return await _dataContext.Holidays.Where(h => h.UserId == userId).ToListAsync();
        }
    }
}
