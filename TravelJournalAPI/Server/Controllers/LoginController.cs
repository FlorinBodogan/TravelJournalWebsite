using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelJournalAPI.Shared.IRepositories;
using TravelJournalAPI.Shared.Models;

namespace TravelJournalAPI.Server.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] LoginModel loginModel)
        //{
        //    if(loginModel != null && loginModel.Email != null && loginModel.Password != null)
        //    {
        //        var user = 
        //    }
        //}

        //private async Task<LoginModel> GetUser(string email, string password)
        //{
        //    return await _userRepository..FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        //}

    }

}
