using Microsoft.AspNetCore.Mvc;
using TravelJournalAPI.Server.Data;
using TravelJournalAPI.Shared.Entities;
using TravelJournalAPI.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelJournalAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
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

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<UserModel>> Post([FromBody]UserModel user)
        {
            _context.Users.Add(new User()
            {   
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
            });
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
