using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using TravelJournalAPI.Server.Data;
using TravelJournalAPI.Server.IServices;
using TravelJournalAPI.Server.Services;
using TravelJournalAPI.Shared.Entities;
using TravelJournalAPI.Shared.IRepositories;
using TravelJournalAPI.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelJournalAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService; 
        private readonly IUserRepository _userRepository;

        public UsersController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("GetHoliday")]
        public async Task<ActionResult<IEnumerable<HolidayModel>>> GetHoliday( Guid userId)
        {
            var holiday = await _userRepository.GetHolidayById(userId);

            var holidays = new List<HolidayModel>();

            foreach (var item in holiday)
            {
                var holidayModel = new HolidayModel()
                {
                    startDate = item.StartDate,
                    endDate = item.EndDate,
                    Title = item.Title,
                    Description = item.Description,
                    Location = item.Location
                };

                holidays.Add(holidayModel);
            }

            return holidays;
        }

        // POST api/<UsersController>
        [HttpPost("PostUser")]
        public async Task<ActionResult<UserModel>> PostUser([FromBody]UserModel user)
        {
            await _userRepository.AddAsync(new User()
            {
                   Name = user.Name,
                   Email = user.Email,
                   Password = user.Password,
            });
            return CreatedAtAction("Get", user);
        }


        [HttpPost("Login")]
        public async Task<ActionResult<LoginModel>> Login([FromBody] LoginRequestModel requestModel)
        {
            var authenticatedUser = await _userRepository.GetUserByEmail(requestModel.Email);

            if (await IsValidCredentialsAsync(requestModel.Email, requestModel.Password))
            {
                var authenticatedUserModel = new LoginModel()
                {
                    Id = authenticatedUser.Id,
                    Email = authenticatedUser.Email,
                    Name = authenticatedUser.Name,
                    Password = authenticatedUser.Password
                };

                return Ok(authenticatedUserModel);
            }
            else
            {
                return Unauthorized();
            }
        }

        private async Task<bool> IsValidCredentialsAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                return false;
            }

            return user.Password == password;
        }

        [HttpPost("PostHoliday")]
        public async Task<ActionResult<HolidayModel>> PostHoliday([FromBody] HolidayModel holiday)
        {
            await _userRepository.AddHolidayAsync(new Holiday()
            {
                StartDate = holiday.startDate,
                EndDate = holiday.endDate,
                Location = holiday.Location,
                Title = holiday.Title,
                Description = holiday.Description,
                UserId = holiday.UserId
            });
            return CreatedAtAction("Get", holiday);
        }

        [HttpGet("GetUserStatus")]
        public async Task<ActionResult<StatusModel>> GetUserStatus(Guid userId)
        {
            var status = await _userService.GetUsersStatusById(userId);
            return new StatusModel()
            {
                UserStatus = status,
            };
        }
    }
}
