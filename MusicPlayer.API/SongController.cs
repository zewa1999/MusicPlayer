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

        public SongController(ISongRepository songRepo, ILogger logger)
        {
            _logger = logger;
            songRepository = songRepo;
        }

        [HttpGet("/all")]
        public IActionResult GetAllSongs()
        {
            //var artists = new List<Artist>
            //{ new Artist
            //{
            //    Name ="Marius de la Focsani"
            //}
            //};

            //var song = new Song
            //{
            //    Name = "Patru puncte cardinale",
            //    Duration = "03:59",
            //    Artists = artists,
            //    Content = Song.GetFileAsBytes(@"C:\Users\costa\Desktop\MusicPlayer\Patru puncte cardinale.mp3"),
            //    Image = Song.GetFileAsBytes(@"C:\Users\costa\Desktop\MusicPlayer\maxresdefault.jpg")
            //};
            //songRepository.Insert(song);
            //return Ok();

            var listOfSongs = new List<Song>();
            try
            {
                listOfSongs = songRepository.Get(null, x => x.OrderBy(s => s.Name)).ToList();
            }
            catch (Exception ex)
            {
                // _logger.LogError("Something has gone wrong.. ooops. {0}", ex.Message);
                // checked to see if it is this case.. if not, change it
                return BadRequest();
            }
            System.IO.File.WriteAllBytes(@"D:\demo\mariusica.mp3", listOfSongs.FirstOrDefault().Content);
            return Ok(listOfSongs);
        }

        [HttpGet("/{songName}")]
        public IActionResult GetSongsByName(string songName)
        {
            var listOfSongs = new List<Song>();
            try
            {
                listOfSongs = songRepository.GetSongsBasedOnName(songName).ToList();
            }
            catch (Exception ex)
            {
                //  _logger.LogError("Something has gone wrong.. ooops. {0}", ex.Message);
                // checked to see if it is this case.. if not, change it
                return BadRequest();
            }

            return Ok(listOfSongs);
        }
    }
}