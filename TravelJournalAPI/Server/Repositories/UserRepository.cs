using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TravelJournalAPI.Server.Data;
using TravelJournalAPI.Shared.Entities;
using TravelJournalAPI.Shared.IRepositories;

namespace TravelJournalAPI.Shared.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext) 
        { 
            _dataContext = dataContext;
        }

        public async Task AddAsync(User user)
        {
            if(await CheckIfEmailExistsAsync(user.Email))
            {
                throw new Exception("This email already exits!");
            }

            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<bool> CheckIfEmailExistsAsync(string email)
        {
            return await _dataContext.Users.AnyAsync(u => u.Email == email);
        }
        
    }
}
