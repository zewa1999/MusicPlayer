using MusicPlayer.API.Models;

namespace MusicPlayer.API.Data.Repository.Interfaces;

public interface ISongRepository : IBaseRepository<Song>
{
    IEnumerable<Song> GetSongsBasedOnName(string songName);
}