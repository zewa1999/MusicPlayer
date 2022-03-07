using MusicPlayer.API.Data.Repository.Interfaces;
using MusicPlayer.API.Models;

namespace MusicPlayer.API.Data.Repository.Concretes;

public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
{
    public ArtistRepository(MusicPlayerContext ctx, ILogger logger) : base(ctx, logger)
    {
    }
}