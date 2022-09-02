using Microsoft.AspNetCore.Mvc;
using MusicPlayer.Backend.Core.Interfaces;
using MusicPlayer.Backend.Core.ProjectAggregate;

namespace MusicPlayer.Backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        public IAccountService accountService { get; set; }

        public AccountController(IAccountService iAccountService)
        {
            accountService = iAccountService;
        }

        [HttpGet]
        [Route("/{username}/{passwordHash}")]
        public IActionResult GetAccount(string username, string passwordHash)
        {
            var account = accountService.Get(x => x.Username == username && x.Password == passwordHash);

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
        [Route("/{email}/{username}/{password}")]
        public IActionResult CreateAccount(string email, string username, string password)
        {
            var account = new Account
            {
                Email = email,
                Username = username,
                Password = password
            };

            if (accountService.Insert(account))
            {
                return Created("", "");
            }
            else
            {
                return BadRequest("Object invalid. Try again!");
            }
        }
    }
}