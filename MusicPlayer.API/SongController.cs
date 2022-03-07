using Microsoft.AspNetCore.Mvc;
using MusicPlayer.API.Data.Repository.Interfaces;
using MusicPlayer.API.Models;

namespace MusicPlayer.API
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : Controller
    {
        private ILogger _logger;
        private ISongRepository songRepository;

        public SongController(ILogger logger, ISongRepository songRepo)
        {
            _logger = logger;
            songRepository = songRepo;
        }

        [HttpGet]
        public IActionResult GetAllSongs()
        {
            var listOfSongs = new List<Song>();
            try
            {
                listOfSongs = songRepository.Get(null, x => x.OrderBy(s => s.Name)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something has gone wrong.. ooops. {0}", ex.Message);
                // checked to see if it is this case.. if not, change it
                return BadRequest();
            }

            return Ok(listOfSongs);
        }

        [HttpGet(@"songs")]
        public IActionResult GetSongsByName(string songName)
        {
            var listOfSongs = new List<Song>();
            try
            {
                listOfSongs = songRepository.GetSongsBasedOnName(songName).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something has gone wrong.. ooops. {0}", ex.Message);
                // checked to see if it is this case.. if not, change it
                return BadRequest();
            }

            return Ok(listOfSongs);
        }
    }
}