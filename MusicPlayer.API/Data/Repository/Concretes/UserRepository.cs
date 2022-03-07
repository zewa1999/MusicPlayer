using MusicPlayer.API.Data.Repository.Interfaces;
using MusicPlayer.API.Models;

namespace MusicPlayer.API.Data.Repository.Concretes;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(MusicPlayerContext ctx, ILogger logger) : base(ctx, logger)
    {
    }
}