using Microsoft.AspNetCore.Mvc;
using MusicPlayer.Backend.Core.Interfaces;

namespace MusicPlayer.Backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        public ISongService songService { get; set; }

        public SongController(ISongService songService)
        {
            this.songService = songService;
        }

        [HttpGet]
        [Route("/name")]
        public IActionResult GetSong(string name)
        {
            var song = songService.Get(x => x.Name == name);

            if (song == null)
            {
                return BadRequest("Song doesn't exist!");
            }
            else
            {
                return Ok(song);
            }
        }
    }
}