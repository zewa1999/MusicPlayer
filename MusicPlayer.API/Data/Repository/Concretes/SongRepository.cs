using MusicPlayer.API.Data.Repository.Interfaces;
using MusicPlayer.API.Models;

namespace MusicPlayer.API.Data.Repository.Concretes;

public class SongRepository : BaseRepository<Song>, ISongRepository
{
    public SongRepository(MusicPlayerContext ctx, ILogger logger) : base(ctx, logger)
    {
    }

    public IEnumerable<Song> GetSongsBasedOnName(string songName)
    {
        return this.Get(x => x.Name.Equals(songName), x => x.OrderBy(y => y.Name));
    }
}