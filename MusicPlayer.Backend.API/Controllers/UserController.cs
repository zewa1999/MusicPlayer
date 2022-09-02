using Microsoft.AspNetCore.Mvc;
using MusicPlayer.Backend.Core.Interfaces;
using MusicPlayer.Backend.Core.ProjectAggregate;

namespace MusicPlayer.Backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public IUserService userService { get; set; }

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("/{username}/{password}")]
        public IActionResult GetUser(string username, string password)
        {
            var account = userService.Get(x => x.Account.Username == username && x.Account.Password == password);

            if (account == null)
            {
                return NotFound("The account could not been found! Please try again!");
            }
            else
            {
                return Ok(account);
            }
        }

        [HttpPost]
        [Route("/{firstname}/{lastname}/{country}/{email}/{username}/{password}")]
        public IActionResult CreateUser(string firstname, string lastname, string country, string email, string username, string password)
        {
            var user = new User
            {
                FirstName = firstname,
                LastName = lastname,
                Country = country,
                Account = new Account
                {
                    Email = email,
                    Username = username,
                    Password = password
                }
            };

            if (userService.Insert(user))
            {
                return Created("", "");
            }
            else
            {
                return BadRequest("Invalid model!");
            }
        }
    }
}